using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.ActionPlanning.State;
using GameData.Domains;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Runtime;

internal static class CharacterGoalTargetConditionPrefilter
{
    private const int HasCandidateSet = 1;
    private const int UnknownCandidateSet = 2;
    private const ushort FriendlyRelationMask = 32767;

    private static readonly int[] ActorRelativeStates =
    {
        302, 303, 304, 305, 306, 307, 308, 309, 310, 311, 312, 313, 314, 316,
    };

    private static readonly int[] DirectRelationStates =
    {
        302, 303, 304, 312,
    };

    private static readonly int[] ReversedRelationStates =
    {
        304, 305, 306, 307, 308, 309, 310, 311, 312, 313,
    };

    private static readonly HashSet<int> EmptyCandidateSet = new();

    private static Snapshot? _frozenSnapshot;
    private static volatile bool _isFrozen;

    [ThreadStatic]
    private static int _offlineCurrentGoalActionScopeDepth;

    [ThreadStatic]
    private static Snapshot? _offlineTargetConditionSnapshot;

    [ThreadStatic]
    private static Stack<List<Character>>? _candidateListPool;

    /// <summary>NPC 行动阶段开始前冻结目标条件快照，热路径只读快照。</summary>
    public static void FreezeBeforeAdvanceMonth()
    {
        if (!IsEnabled())
        {
            UnfreezeAndInvalidate();
            return;
        }

        try
        {
            int[] characterIds = CharacterActionTargetLookupCache.GetFrozenCharacterIdsForRelationTargetCache();
            if (characterIds.Length == 0)
            {
                UnfreezeAndInvalidate();
                return;
            }

            Snapshot snapshot = BuildSnapshot(characterIds);
            Volatile.Write(ref _frozenSnapshot, snapshot);
            _isFrozen = true;
        }
        catch (Exception exception)
        {
            RecordException(exception);
            UnfreezeAndInvalidate();
        }
    }

    /// <summary>过月结束或离开世界时释放快照，避免引用旧世界数据。</summary>
    public static void UnfreezeAndInvalidate()
    {
        _isFrozen = false;
        Volatile.Write(ref _frozenSnapshot, null);
        _offlineCurrentGoalActionScopeDepth = 0;
        _offlineTargetConditionSnapshot = null;
        _candidateListPool?.Clear();
    }

    /// <summary>批量关系变化后关闭本轮预过滤；单条关系变化使用 `InvalidateRelationMutation`。</summary>
    public static void InvalidateForRelationMutation()
    {
        if (!_isFrozen)
        {
            return;
        }

        _isFrozen = false;
        Volatile.Write(ref _frozenSnapshot, null);
        _offlineTargetConditionSnapshot = null;
    }

    /// <summary>单条关系变化只标记受影响的 actor/state，下一次命中时局部重建。</summary>
    public static void InvalidateRelationMutation(int charId, int relatedCharId)
    {
        if (!_isFrozen)
        {
            return;
        }

        Snapshot? snapshot = Volatile.Read(ref _frozenSnapshot);
        snapshot?.InvalidateRelationMutation(charId, relatedCharId);
    }

    /// <summary>进入原版 `OfflineUpdateCurrentGoalActions` 阶段。</summary>
    public static void EnterOfflineCurrentGoalActions()
    {
        if (_isFrozen)
        {
            _offlineCurrentGoalActionScopeDepth++;
            _offlineTargetConditionSnapshot = Volatile.Read(ref _frozenSnapshot);
        }
    }

    /// <summary>离开原版 `OfflineUpdateCurrentGoalActions` 阶段。</summary>
    public static void LeaveOfflineCurrentGoalActions()
    {
        if (_offlineCurrentGoalActionScopeDepth > 0)
        {
            _offlineCurrentGoalActionScopeDepth--;
            if (_offlineCurrentGoalActionScopeDepth == 0)
            {
                _offlineTargetConditionSnapshot = null;
            }
        }
        else
        {
            _offlineTargetConditionSnapshot = null;
        }
    }

    /// <summary>在原版 `FilterActionTargets` 前按安全目标条件缩小候选集。</summary>
    public static bool TryPrefilterCandidates(
        CharacterPlanningAgent agent,
        PlanningGoalNode? currentGoal,
        PlanningActionNode? currentAction,
        ContextArgGroupHandle actionArgs,
        IReadOnlyList<Character>? source,
        out IReadOnlyList<Character> filtered,
        out List<Character>? rentedList)
    {
        filtered = source ?? Array.Empty<Character>();
        rentedList = null;
        if (!_isFrozen || _offlineCurrentGoalActionScopeDepth <= 0 || agent?.Object == null)
        {
            RecordSkip(CharacterRelationTargetPrefilterSkipReason.OutOfScope);
            return false;
        }

        if (_offlineTargetConditionSnapshot == null)
        {
            RecordSkip(CharacterRelationTargetPrefilterSkipReason.UnsafeRule);
            return false;
        }

        if (source == null || source.Count <= 1)
        {
            RecordSkip(CharacterRelationTargetPrefilterSkipReason.EmptySource);
            return false;
        }

        int actorCharId = agent.Object.GetId();
        if (!TryBuildGoalCandidateSet(actorCharId, currentGoal, out HashSet<int>? goalCandidates) ||
            !TryBuildActionCandidateSet(actorCharId, currentAction, out HashSet<int>? actionCandidates))
        {
            RecordSkip(CharacterRelationTargetPrefilterSkipReason.UnsafeRule);
            return false;
        }

        bool hasInventoryFilter = CharacterInventoryTargetPrefilter.TryCreateHolderFilter(
            currentAction,
            actionArgs,
            out CharacterInventoryTargetPrefilter.HolderFilter inventoryFilter);

        if (goalCandidates == null && actionCandidates == null && !hasInventoryFilter)
        {
            RecordSkip(CharacterRelationTargetPrefilterSkipReason.NoRelationRule);
            return false;
        }

        List<Character> result = RentCandidateList(source.Count);
        foreach (Character character in source)
        {
            if (character == null)
            {
                continue;
            }

            int candidateCharId = character.GetId();
            if ((goalCandidates == null || goalCandidates.Contains(candidateCharId)) &&
                (actionCandidates == null || actionCandidates.Contains(candidateCharId)) &&
                (!hasInventoryFilter || inventoryFilter.MayHold(candidateCharId)))
            {
                result.Add(character);
            }
        }

        filtered = result;
        rentedList = result;
        RecordApplied(currentAction, source.Count, result.Count);
        return true;
    }

    /// <summary>记录预过滤异常，避免异常路径在日志中不可见。</summary>
    public static void RecordException(Exception exception)
    {
        if (CharacterActionPlanningDiagnostics.IsRecording)
        {
            CharacterActionPlanningDiagnostics.RecordRelationTargetPrefilterException(exception);
        }
    }

    /// <summary>归还候选列表，供同一 worker 线程后续复用。</summary>
    public static void ReturnCandidateList(List<Character>? list)
    {
        if (list == null)
        {
            return;
        }

        list.Clear();
        (_candidateListPool ??= new Stack<List<Character>>(4)).Push(list);
    }

    private static bool IsEnabled() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled &&
        TaiwuOptimizationSettings.EnableCharacterActionTargetLookupCache;

    private static Snapshot BuildSnapshot(int[] characterIds)
    {
        Dictionary<long, HashSet<int>> actorCandidateSets = new(characterIds.Length * ActorRelativeStates.Length / 2);
        Dictionary<int, HashSet<int>> globalCandidateSets = new(8);
        Dictionary<int, HashSet<int>> factionCandidateSets = new();
        Dictionary<short, HashSet<int>> belongAreaCandidateSets = new();

        BuildCharacterTargetGroups(characterIds, globalCandidateSets, factionCandidateSets, belongAreaCandidateSets);

        foreach (int actorCharId in characterIds)
        {
            BuildActorRelationCandidateSets(actorCandidateSets, actorCharId);
            BuildActorStaticCandidateSets(
                actorCandidateSets,
                actorCharId,
                factionCandidateSets,
                belongAreaCandidateSets);
        }

        return new Snapshot(actorCandidateSets, globalCandidateSets);
    }

    private static void BuildCharacterTargetGroups(
        int[] characterIds,
        Dictionary<int, HashSet<int>> globalCandidateSets,
        Dictionary<int, HashSet<int>> factionCandidateSets,
        Dictionary<short, HashSet<int>> belongAreaCandidateSets)
    {
        int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
        if (taiwuCharId >= 0)
        {
            AddToSet(globalCandidateSets, 296, taiwuCharId);
        }

        foreach (int charId in characterIds)
        {
            if (!DomainManager.Character.TryGetElement_Objects(charId, out Character character))
            {
                continue;
            }

            AddOrganizationCandidateSets(globalCandidateSets, character, charId);

            int factionId = character.GetFactionId();
            if (factionId >= 0)
            {
                AddToSet(factionCandidateSets, factionId, charId);
            }

            short belongArea = character.GetBelongMapArea();
            if (belongArea >= 0)
            {
                AddToSet(belongAreaCandidateSets, belongArea, charId);
            }
        }
    }

    private static void AddOrganizationCandidateSets(
        Dictionary<int, HashSet<int>> globalCandidateSets,
        Character character,
        int charId)
    {
        var organizationInfo = character.GetOrganizationInfo();
        OrganizationItem organizationConfig = organizationInfo.GetOrganizationConfig();

        if (organizationConfig.IsSect)
        {
            AddToSet(globalCandidateSets, 317, charId);
            switch (organizationConfig.Goodness)
            {
                case -1:
                    AddToSet(globalCandidateSets, 331, charId);
                    break;
                case 0:
                    AddToSet(globalCandidateSets, 333, charId);
                    break;
                case 1:
                    AddToSet(globalCandidateSets, 332, charId);
                    break;
            }
        }

        if (organizationConfig.IsCivilian)
        {
            AddToSet(globalCandidateSets, 318, charId);
        }

        if (organizationInfo.OrgTemplateId == 16)
        {
            AddToSet(globalCandidateSets, 321, charId);
        }
        else if (organizationInfo.OrgTemplateId == 0)
        {
            AddToSet(globalCandidateSets, 606, charId);
        }
    }

    private static void BuildActorRelationCandidateSets(
        Dictionary<long, HashSet<int>> actorCandidateSets,
        int actorCharId)
    {
        foreach (int stateTemplateId in ActorRelativeStates)
        {
            if (stateTemplateId is 314 or 316)
            {
                continue;
            }

            HashSet<int> candidateSet = BuildRelationCandidateSet(actorCharId, stateTemplateId);
            if (candidateSet.Count != 0)
            {
                actorCandidateSets[MakeStateKey(actorCharId, stateTemplateId)] = candidateSet;
            }
        }
    }

    private static void BuildActorStaticCandidateSets(
        Dictionary<long, HashSet<int>> actorCandidateSets,
        int actorCharId,
        Dictionary<int, HashSet<int>> factionCandidateSets,
        Dictionary<short, HashSet<int>> belongAreaCandidateSets)
    {
        if (!DomainManager.Character.TryGetElement_Objects(actorCharId, out Character actor))
        {
            return;
        }

        int factionId = actor.GetFactionId();
        if (factionId >= 0 && factionCandidateSets.TryGetValue(factionId, out HashSet<int>? factionSet))
        {
            actorCandidateSets[MakeStateKey(actorCharId, 314)] = factionSet;
        }

        short belongArea = actor.GetBelongMapArea();
        if (belongArea >= 0 && belongAreaCandidateSets.TryGetValue(belongArea, out HashSet<int>? areaSet))
        {
            actorCandidateSets[MakeStateKey(actorCharId, 316)] = areaSet;
        }
    }

    private static bool TryBuildGoalCandidateSet(
        int actorCharId,
        PlanningGoalNode? goal,
        out HashSet<int>? candidateSet)
    {
        candidateSet = null;
        if (goal == null)
        {
            return true;
        }

        var template = goal.Template;
        StateConditionAndValue<StateKey>[]? groupA = template.TargetCharacterConditionsA;
        if (groupA == null || groupA.Length == 0)
        {
            return true;
        }

        bool hasAnyTargetConditionGroup = false;
        if (!TryUnionGoalConditionGroup(actorCharId, groupA, ref candidateSet, ref hasAnyTargetConditionGroup))
        {
            return false;
        }

        if (!TryUnionGoalConditionGroup(actorCharId, template.TargetCharacterConditionsB, ref candidateSet, ref hasAnyTargetConditionGroup) ||
            !TryUnionGoalConditionGroup(actorCharId, template.TargetCharacterConditionsC, ref candidateSet, ref hasAnyTargetConditionGroup))
        {
            return false;
        }

        return hasAnyTargetConditionGroup;
    }

    private static bool TryUnionGoalConditionGroup(
        int actorCharId,
        StateConditionAndValue<StateKey>[]? conditions,
        ref HashSet<int>? unionSet,
        ref bool hasAnyTargetConditionGroup)
    {
        if (conditions == null || conditions.Length == 0)
        {
            return true;
        }

        if (!TryBuildRequiredCandidateSet(actorCharId, conditions, out HashSet<int>? groupSet))
        {
            return false;
        }

        if (groupSet == null)
        {
            return false;
        }

        hasAnyTargetConditionGroup = true;
        if (unionSet == null)
        {
            unionSet = new HashSet<int>(groupSet);
        }
        else
        {
            unionSet.UnionWith(groupSet);
        }

        return true;
    }

    private static bool TryBuildActionCandidateSet(
        int actorCharId,
        PlanningActionNode? action,
        out HashSet<int>? candidateSet)
    {
        candidateSet = null;
        StateConditionAndValue<StateKey>[]? conditions = action?.Template.TargetCharacterConditions;
        return conditions == null ||
            conditions.Length == 0 ||
            TryBuildRequiredCandidateSet(actorCharId, conditions, out candidateSet);
    }

    private static bool TryBuildRequiredCandidateSet(
        int actorCharId,
        StateConditionAndValue<StateKey>[] conditions,
        out HashSet<int>? candidateSet)
    {
        candidateSet = null;
        foreach (StateConditionAndValue<StateKey> condition in conditions)
        {
            int kind = TryGetPositiveTargetConditionCandidateSet(actorCharId, condition, out HashSet<int>? conditionSet);
            if (kind == UnknownCandidateSet)
            {
                continue;
            }

            if (conditionSet == null)
            {
                return false;
            }

            if (candidateSet == null)
            {
                candidateSet = new HashSet<int>(conditionSet);
            }
            else
            {
                candidateSet.IntersectWith(conditionSet);
            }

            if (candidateSet.Count == 0)
            {
                break;
            }
        }

        return true;
    }

    private static int TryGetPositiveTargetConditionCandidateSet(
        int actorCharId,
        StateConditionAndValue<StateKey> condition,
        out HashSet<int>? candidateSet)
    {
        candidateSet = null;
        if (!condition.IsConstValue || !RequiresPositiveBoolean(condition))
        {
            return UnknownCandidateSet;
        }

        if (!TryGetSupportedTargetConditionState(condition.Key, out int stateTemplateId))
        {
            return UnknownCandidateSet;
        }

        Snapshot? snapshot = _offlineTargetConditionSnapshot;
        if (snapshot == null)
        {
            return UnknownCandidateSet;
        }

        candidateSet = snapshot.GetCandidateSet(actorCharId, stateTemplateId);
        return HasCandidateSet;
    }

    private static bool RequiresPositiveBoolean(StateConditionAndValue<StateKey> condition) =>
        condition.ConditionType switch
        {
            EStateCondition.Enabled => true,
            EStateCondition.Equal => condition.Value == 1,
            EStateCondition.NotEqual => condition.Value == 0,
            EStateCondition.GreaterThan => condition.Value == 0,
            EStateCondition.GreaterOrEqual => condition.Value == 1,
            _ => false,
        };

    private static bool TryGetSupportedTargetConditionState(StateKey key, out int stateTemplateId)
    {
        stateTemplateId = key.StateTemplateId;
        return key.Template.SensorType switch
        {
            EPlanningStateSensorType.CharacterStateSensor => stateTemplateId == 296,
            EPlanningStateSensorType.TargetStateSensor =>
                stateTemplateId is 302 or 303 or 304 or 305 or 306 or 307 or 308 or 309 or 310 or 311 or 312 or 313 or 314 or 316,
            EPlanningStateSensorType.OrganizationStateSensor =>
                stateTemplateId is 317 or 318 or 321 or 331 or 332 or 333 or 606,
            _ => false,
        };
    }

    private static HashSet<int> BuildRelationCandidateSet(int actorCharId, int stateTemplateId)
    {
        HashSet<int> result = new();
        switch (stateTemplateId)
        {
            case 302:
                AddDirectRelationMask(result, actorCharId, 16384);
                break;
            case 303:
                AddDirectRelationMask(result, actorCharId, 32768);
                break;
            case 304:
                AddDirectRelationMask(result, actorCharId, FriendlyRelationMask);
                AddReversedRelationMask(result, actorCharId, FriendlyRelationMask);
                break;
            case 305:
                AddReversedRelationMask(result, actorCharId, 73);
                break;
            case 306:
                AddReversedRelationMask(result, actorCharId, 292);
                break;
            case 307:
                AddReversedRelationMask(result, actorCharId, 146);
                break;
            case 308:
                AddReversedRelationMask(result, actorCharId, 8192);
                break;
            case 309:
                AddReversedRelationMask(result, actorCharId, 448);
                break;
            case 310:
                AddReversedRelationMask(result, actorCharId, 1024);
                break;
            case 311:
                AddReversedRelationMask(result, actorCharId, 512);
                break;
            case 312:
                AddDirectRelationMask(result, actorCharId, 16384);
                if (result.Count != 0)
                {
                    HashSet<int> reversed = new();
                    AddReversedRelationMask(reversed, actorCharId, 16384);
                    result.IntersectWith(reversed);
                }
                break;
            case 313:
                AddReversedRelationMask(result, actorCharId, 6144);
                break;
        }

        return result;
    }

    private static void AddDirectRelationMask(HashSet<int> target, int actorCharId, ushort relationMask)
    {
        for (int bitIndex = 0; bitIndex < 16; bitIndex++)
        {
            ushort relationBit = (ushort)(1 << bitIndex);
            if ((relationMask & relationBit) != 0)
            {
                AddRelated(target, DomainManager.Character.GetRelatedCharIds(actorCharId, relationBit));
            }
        }
    }

    private static void AddReversedRelationMask(HashSet<int> target, int actorCharId, ushort relationMask)
    {
        for (int bitIndex = 0; bitIndex < 16; bitIndex++)
        {
            ushort relationBit = (ushort)(1 << bitIndex);
            if ((relationMask & relationBit) != 0)
            {
                AddRelated(target, DomainManager.Character.GetReversedRelatedCharIds(actorCharId, relationBit).GetCollection());
            }
        }
    }

    private static void AddRelated(HashSet<int> target, IEnumerable<int> relatedCharIds)
    {
        foreach (int charId in relatedCharIds)
        {
            target.Add(charId);
        }
    }

    private static void AddToSet<TKey>(Dictionary<TKey, HashSet<int>> candidateSets, TKey key, int charId)
        where TKey : notnull
    {
        if (!candidateSets.TryGetValue(key, out HashSet<int>? candidateSet))
        {
            candidateSet = new HashSet<int>();
            candidateSets[key] = candidateSet;
        }

        candidateSet.Add(charId);
    }

    private static List<Character> RentCandidateList(int sourceCount)
    {
        Stack<List<Character>>? pool = _candidateListPool;
        if (pool != null && pool.Count > 0)
        {
            List<Character> list = pool.Pop();
            list.EnsureCapacity(sourceCount);
            return list;
        }

        return new List<Character>(sourceCount);
    }

    private static void RecordApplied(PlanningActionNode? action, int inputCount, int outputCount)
    {
        if (!CharacterActionPlanningDiagnostics.IsRecording || action == null)
        {
            return;
        }

        var template = action.Template;
        CharacterActionPlanningDiagnostics.RecordRelationTargetPrefilterApplied(
            template.TemplateId,
            template.CharacterSelector,
            template.CharacterSelectRange,
            template.SelectRangeValue,
            inputCount,
            outputCount);
    }

    private static void RecordSkip(CharacterRelationTargetPrefilterSkipReason reason)
    {
        if (CharacterActionPlanningDiagnostics.IsRecording)
        {
            CharacterActionPlanningDiagnostics.RecordRelationTargetPrefilterSkipped(reason);
        }
    }

    private static long MakeStateKey(int actorCharId, int stateTemplateId) =>
        ((long)actorCharId << 32) | (uint)stateTemplateId;

    private sealed class Snapshot
    {
        private readonly ConcurrentDictionary<long, HashSet<int>> _actorCandidateSets;
        private readonly Dictionary<int, HashSet<int>> _globalCandidateSets;
        private readonly ConcurrentDictionary<long, byte> _dirtyActorRelationStates = new();
        private readonly object _dirtyRelationStatesLock = new();

        public Snapshot(
            Dictionary<long, HashSet<int>> actorCandidateSets,
            Dictionary<int, HashSet<int>> globalCandidateSets)
        {
            _actorCandidateSets = new ConcurrentDictionary<long, HashSet<int>>(actorCandidateSets);
            _globalCandidateSets = globalCandidateSets;
        }

        public void InvalidateRelationMutation(int charId, int relatedCharId)
        {
            lock (_dirtyRelationStatesLock)
            {
                if (charId >= 0)
                {
                    MarkDirectRelationStatesDirty(charId);
                }

                if (relatedCharId >= 0)
                {
                    MarkReversedRelationStatesDirty(relatedCharId);
                }
            }
        }

        public HashSet<int> GetCandidateSet(int actorCharId, int stateTemplateId)
        {
            long stateKey = MakeStateKey(actorCharId, stateTemplateId);
            RebuildIfDirty(actorCharId, stateTemplateId, stateKey);

            if (_actorCandidateSets.TryGetValue(stateKey, out HashSet<int>? actorSet))
            {
                return actorSet;
            }

            return _globalCandidateSets.TryGetValue(stateTemplateId, out HashSet<int>? globalSet)
                ? globalSet
                : EmptyCandidateSet;
        }

        private void MarkDirectRelationStatesDirty(int actorCharId)
        {
            foreach (int stateTemplateId in DirectRelationStates)
            {
                _dirtyActorRelationStates.TryAdd(MakeStateKey(actorCharId, stateTemplateId), 0);
            }
        }

        private void MarkReversedRelationStatesDirty(int actorCharId)
        {
            foreach (int stateTemplateId in ReversedRelationStates)
            {
                _dirtyActorRelationStates.TryAdd(MakeStateKey(actorCharId, stateTemplateId), 0);
            }
        }

        private void RebuildIfDirty(int actorCharId, int stateTemplateId, long stateKey)
        {
            if (!_dirtyActorRelationStates.ContainsKey(stateKey))
            {
                return;
            }

            lock (_dirtyRelationStatesLock)
            {
                if (!_dirtyActorRelationStates.ContainsKey(stateKey))
                {
                    return;
                }

                HashSet<int> rebuiltSet = BuildRelationCandidateSet(actorCharId, stateTemplateId);
                if (rebuiltSet.Count == 0)
                {
                    _actorCandidateSets.TryRemove(stateKey, out _);
                }
                else
                {
                    _actorCandidateSets[stateKey] = rebuiltSet;
                }

                _dirtyActorRelationStates.TryRemove(stateKey, out _);
            }
        }
    }
}

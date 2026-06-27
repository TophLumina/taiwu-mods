using System;
using System.Collections.Generic;
using System.Threading;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Domains;
using GameData.Domains.Map;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Runtime;

internal static class CharacterPlanningAgentTargetLookupCache
{
    private static readonly object SyncRoot = new();

    private static OfflineCurrentGoalActionTargetSnapshot? _frozenSnapshot;
    private static int _locationEpoch;

    [ThreadStatic]
    private static int _offlineCurrentGoalActionScopeDepth;

    [ThreadStatic]
    private static OfflineCurrentGoalActionTargetSnapshot? _offlineTargetLookupSnapshot;

    [ThreadStatic]
    private static List<MapBlockData>? _blockRangeScratch;

    /// <summary>进入原版 `OfflineUpdateCurrentGoalActions` 阶段；主/副目标阶段共用同一份冻结索引。</summary>
    /// <param name="goalType">原版当前处理的目标类型。</param>
    public static void EnterOfflineCurrentGoalActions(ActionPlanningData.ECurrentGoalType goalType)
    {
        if (!IsEnabled())
        {
            _offlineTargetLookupSnapshot = null;
            return;
        }

        _offlineCurrentGoalActionScopeDepth++;
        _offlineTargetLookupSnapshot = Volatile.Read(ref _frozenSnapshot);
    }

    /// <summary>离开原版 `OfflineUpdateCurrentGoalActions` 阶段。</summary>
    public static void LeaveOfflineCurrentGoalActions()
    {
        if (_offlineCurrentGoalActionScopeDepth > 0)
        {
            _offlineCurrentGoalActionScopeDepth--;
            if (_offlineCurrentGoalActionScopeDepth == 0)
            {
                _offlineTargetLookupSnapshot = null;
            }
        }
        else
        {
            _offlineTargetLookupSnapshot = null;
        }
    }

    /// <summary>在 NPC 行动规划前同步全量生成并冻结目标索引。</summary>
    public static void EnsureFrozenBeforeUpdateCurrentGoalActions()
    {
        if (!IsEnabled())
        {
            UnfreezeAndInvalidate();
            return;
        }

        int locationEpoch = Volatile.Read(ref _locationEpoch);
        OfflineCurrentGoalActionTargetSnapshot? snapshot = Volatile.Read(ref _frozenSnapshot);
        if (snapshot != null && snapshot.LocationEpoch == locationEpoch)
        {
            return;
        }

        lock (SyncRoot)
        {
            locationEpoch = Volatile.Read(ref _locationEpoch);
            snapshot = Volatile.Read(ref _frozenSnapshot);
            if (snapshot == null || snapshot.LocationEpoch != locationEpoch)
            {
                Volatile.Write(ref _frozenSnapshot, OfflineCurrentGoalActionTargetSnapshot.Build(locationEpoch));
            }
        }
    }

    /// <summary>角色位置变化只推进版本号；下一次规划阶段入口再决定是否重建索引。</summary>
    public static void NotifyCharacterLocationChanged() =>
        Interlocked.Increment(ref _locationEpoch);

    /// <summary>返回当前 planning 阶段共享快照；关系和物品预过滤在同一构建屏障内复用它。</summary>
    public static bool TryGetFrozenPlanningSnapshot(out OfflineCurrentGoalActionTargetSnapshot snapshot)
    {
        snapshot = Volatile.Read(ref _frozenSnapshot)!;
        return snapshot != null;
    }

    /// <summary>过月结束后丢弃冻结快照；下一次过月前会重新全量生成。</summary>
    public static void UnfreezeAndInvalidate()
    {
        lock (SyncRoot)
        {
            Volatile.Write(ref _frozenSnapshot, null);
        }
    }

    /// <summary>退出世界、切档或设置变化时清理全部运行时缓存。</summary>
    public static void Reset()
    {
        lock (SyncRoot)
        {
            Volatile.Write(ref _frozenSnapshot, null);
        }

        _offlineCurrentGoalActionScopeDepth = 0;
        _offlineTargetLookupSnapshot = null;
        Volatile.Write(ref _locationEpoch, 0);
    }

    /// <summary>尝试用冻结快照追加同一地块候选角色。</summary>
    public static bool TryAddCharactersInBlock(CharacterPlanningAgent agent, List<Character> characters, MapBlockData block)
    {
        if (!TryGetFrozenSnapshot(out OfflineCurrentGoalActionTargetSnapshot? snapshot))
        {
            CharacterActionPlanningDiagnostics.RecordTargetLookup(CharacterPlanningAgentTargetLookupKind.SameBlock, false, 0, 0);
            return false;
        }

        int[] characterIds = snapshot!.GetBlockCharacterIds(block.AreaId, block.BlockId);
        int added = AddIndexedCharacters(agent, characters, characterIds);
        CharacterActionPlanningDiagnostics.RecordTargetLookup(
            CharacterPlanningAgentTargetLookupKind.SameBlock,
            true,
            characterIds.Length,
            added);
        return true;
    }

    /// <summary>尝试用冻结快照追加同一地区候选角色。</summary>
    public static bool TryAddCharactersInArea(CharacterPlanningAgent agent, List<Character> characters, short areaId)
    {
        if (!TryGetFrozenSnapshot(out OfflineCurrentGoalActionTargetSnapshot? snapshot) ||
            areaId < 0 ||
            areaId >= snapshot!.AreaCharacterIds.Length)
        {
            CharacterActionPlanningDiagnostics.RecordTargetLookup(CharacterPlanningAgentTargetLookupKind.SameArea, false, 0, 0);
            return false;
        }

        int[] characterIds = snapshot.AreaCharacterIds[areaId];
        int added = AddIndexedCharacters(agent, characters, characterIds);
        CharacterActionPlanningDiagnostics.RecordTargetLookup(
            CharacterPlanningAgentTargetLookupKind.SameArea,
            true,
            characterIds.Length,
            added);
        return true;
    }

    /// <summary>尝试用冻结快照追加同一州域候选角色。</summary>
    public static bool TryAddCharactersInState(CharacterPlanningAgent agent, List<Character> characters, sbyte stateId)
    {
        if (!TryGetFrozenSnapshot(out OfflineCurrentGoalActionTargetSnapshot? snapshot) ||
            !snapshot!.StateCharacterIds.TryGetValue(stateId, out int[]? characterIds))
        {
            CharacterActionPlanningDiagnostics.RecordTargetLookup(CharacterPlanningAgentTargetLookupKind.SameState, false, 0, 0);
            return false;
        }

        int added = AddIndexedCharacters(agent, characters, characterIds);
        CharacterActionPlanningDiagnostics.RecordTargetLookup(
            CharacterPlanningAgentTargetLookupKind.SameState,
            true,
            characterIds.Length,
            added);
        return true;
    }

    /// <summary>尝试用冻结快照追加地块范围内候选角色。</summary>
    public static bool TryAddCharactersInBlockRange(
        CharacterPlanningAgent agent,
        List<Character> characters,
        Location location,
        int steps)
    {
        if (!TryGetFrozenSnapshot(out OfflineCurrentGoalActionTargetSnapshot? snapshot))
        {
            CharacterActionPlanningDiagnostics.RecordTargetLookup(CharacterPlanningAgentTargetLookupKind.BlockRange, false, 0, 0);
            return false;
        }

        List<MapBlockData> blocks = _blockRangeScratch ??= new List<MapBlockData>(64);
        blocks.Clear();
        DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, blocks, steps, includeCenter: true);
        int candidateIds = 0;
        int beforeCount = characters.Count;
        foreach (MapBlockData block in blocks)
        {
            int[] characterIds = snapshot!.GetBlockCharacterIds(block.AreaId, block.BlockId);
            candidateIds += characterIds.Length;
            AddIndexedCharacters(agent, characters, characterIds);
        }

        CharacterActionPlanningDiagnostics.RecordTargetLookup(
            CharacterPlanningAgentTargetLookupKind.BlockRange,
            true,
            candidateIds,
            characters.Count - beforeCount);
        blocks.Clear();
        return true;
    }

    /// <summary>尝试用冻结快照追加聚落范围内候选角色。</summary>
    public static bool TryAddCharactersInSettlementRange(
        CharacterPlanningAgent agent,
        List<Character> characters,
        Location settlementLocation)
    {
        if (!TryGetFrozenSnapshot(out OfflineCurrentGoalActionTargetSnapshot? snapshot))
        {
            CharacterActionPlanningDiagnostics.RecordTargetLookup(CharacterPlanningAgentTargetLookupKind.SettlementRange, false, 0, 0);
            return false;
        }

        int[] characterIds = snapshot!.GetSettlementCharacterIds(settlementLocation);
        int added = AddIndexedCharacters(agent, characters, characterIds);
        CharacterActionPlanningDiagnostics.RecordTargetLookup(
            CharacterPlanningAgentTargetLookupKind.SettlementRange,
            true,
            characterIds.Length,
            added);
        return true;
    }

    private static bool IsEnabled() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled &&
        TaiwuOptimizationSettings.EnableCharacterActionPlanningOptimization;

    private static bool TryGetFrozenSnapshot(out OfflineCurrentGoalActionTargetSnapshot? snapshot)
    {
        snapshot = null;
        if (_offlineCurrentGoalActionScopeDepth <= 0)
        {
            return false;
        }

        snapshot = _offlineTargetLookupSnapshot;
        return snapshot != null;
    }

    private static int AddIndexedCharacters(CharacterPlanningAgent agent, List<Character> characters, int[] characterIds)
    {
        int selfId = agent.Object.GetId();
        int beforeCount = characters.Count;
        characters.EnsureCapacity(characters.Count + characterIds.Length);
        foreach (int characterId in characterIds)
        {
            if (characterId == selfId)
            {
                continue;
            }

            if (DomainManager.Character.TryGetElement_Objects(characterId, out Character character))
            {
                characters.Add(character);
            }
        }

        return characters.Count - beforeCount;
    }
}

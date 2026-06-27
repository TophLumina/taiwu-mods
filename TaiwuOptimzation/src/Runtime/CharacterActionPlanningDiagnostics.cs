using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.State;
using GameData.Domains;
using NLog;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Runtime;

internal enum CharacterActionPlanningParallelStage
{
    UpdateCharacterMission,
    UpdateCharacterGoal,
    UpdatePrimaryGoalAndActions,
    UpdateSecondaryGoalAndActions,
    UpdateInfectedCharacterActions,
    UpdateLegendaryBookOwnersActions,
}

internal enum CharacterActionPlanningStep
{
    OfflineUpdateCurrentGoalActions,
    ComplementUpdateCurrentGoalActions,
    OfflineUpdateGoalPlan,
    ReassessPlan,
    OfflineCreateNextAction,
    ExecuteAction,
    CheckPrerequisites,
    GetCharactersInSelectRange,
    FilterActionTargets,
    CharacterActionPlannerPlan,
    CharacterActionPlannerReassess,
    WeightBasedFindPath,
    WeightBasedFindPathRecursive,
    WeightBasedGetUnsatisfiedStateCount,
    StateMemoryCheckCondition,
    PrepareContext,
    CalcCurrentState,
    MatchTargetCharacter,
    MatchTargetCharacterByConditions,
}

internal enum CharacterActionTargetLookupKind
{
    SameBlock,
    SameArea,
    SameState,
    BlockRange,
    SettlementRange,
}

internal enum CharacterTargetMatchScopeKind
{
    None,
    Goal,
    Action,
}

internal enum CharacterRelationTargetPrefilterSkipReason
{
    OutOfScope,
    EmptySource,
    NoRelationRule,
    UnsafeRule,
    Exception,
}

internal enum CharacterTargetMatcherCacheRejectReason
{
    None,
    StageInactive,
    OutsideOfflineCurrentGoalActions,
    UnsupportedDisplayGender,
    UnsupportedMerchantType,
    UnsupportedSubCondition,
}

internal readonly struct TargetMatchDiagnosticsState
{
    public readonly long StartTicks;
    public readonly CharacterTargetMatchScopeKind ScopeKind;
    public readonly int ActionTemplateId;
    public readonly int GoalTemplateId;
    public readonly CharacterTargetMatchScopeKind PreviousScopeKind;
    public readonly int PreviousActionTemplateId;
    public readonly int PreviousGoalTemplateId;
    public readonly EPlanningActionCharacterSelector PreviousSelector;
    public readonly EPlanningActionCharacterSelectRange PreviousRange;
    public readonly int PreviousRangeValue;
    public readonly EPlanningActionCharacterSelector Selector;
    public readonly EPlanningActionCharacterSelectRange Range;
    public readonly int RangeValue;

    public TargetMatchDiagnosticsState(
        long startTicks,
        CharacterTargetMatchScopeKind scopeKind,
        int actionTemplateId,
        int goalTemplateId,
        CharacterTargetMatchScopeKind previousScopeKind,
        int previousActionTemplateId,
        int previousGoalTemplateId,
        EPlanningActionCharacterSelector previousSelector = default,
        EPlanningActionCharacterSelectRange previousRange = default,
        int previousRangeValue = 0,
        EPlanningActionCharacterSelector selector = default,
        EPlanningActionCharacterSelectRange range = default,
        int rangeValue = 0)
    {
        StartTicks = startTicks;
        ScopeKind = scopeKind;
        ActionTemplateId = actionTemplateId;
        GoalTemplateId = goalTemplateId;
        PreviousScopeKind = previousScopeKind;
        PreviousActionTemplateId = previousActionTemplateId;
        PreviousGoalTemplateId = previousGoalTemplateId;
        PreviousSelector = previousSelector;
        PreviousRange = previousRange;
        PreviousRangeValue = previousRangeValue;
        Selector = selector;
        Range = range;
        RangeValue = rangeValue;
    }
}

internal readonly struct TargetConditionDiagnosticsState
{
    public readonly long StartTicks;
    public readonly CharacterTargetMatchScopeKind ScopeKind;
    public readonly int ActionTemplateId;
    public readonly int GoalTemplateId;
    public readonly EPlanningActionCharacterSelector Selector;
    public readonly EPlanningActionCharacterSelectRange Range;
    public readonly int RangeValue;
    public readonly int ConditionCount;

    public TargetConditionDiagnosticsState(
        long startTicks,
        CharacterTargetMatchScopeKind scopeKind,
        int actionTemplateId,
        int goalTemplateId,
        EPlanningActionCharacterSelector selector,
        EPlanningActionCharacterSelectRange range,
        int rangeValue,
        int conditionCount)
    {
        StartTicks = startTicks;
        ScopeKind = scopeKind;
        ActionTemplateId = actionTemplateId;
        GoalTemplateId = goalTemplateId;
        Selector = selector;
        Range = range;
        RangeValue = rangeValue;
        ConditionCount = conditionCount;
    }
}

internal static class CharacterActionPlanningDiagnostics
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private static readonly object SyncRoot = new();
    private static readonly Metric[] ParallelStages = CreateMetricArray<CharacterActionPlanningParallelStage>();
    private static readonly GoalMetrics PrimaryMetrics = new();
    private static readonly GoalMetrics SecondaryMetrics = new();
    private static readonly TargetLookupMetric[] TargetLookupMetrics = CreateTargetLookupMetricArray();
    private static readonly SkipMetric[] RelationTargetPrefilterSkips = CreateSkipMetricArray();
    private static readonly Dictionary<Type, ExceptionMetric> RelationTargetPrefilterExceptions = new(8);

    private static Session _current;

    [ThreadStatic]
    private static int _goalScopeDepth;

    [ThreadStatic]
    private static ActionPlanningData.ECurrentGoalType _goalType;

    [ThreadStatic]
    private static CharacterTargetMatchScopeKind _targetMatchScopeKind;

    [ThreadStatic]
    private static int _targetMatchActionTemplateId;

    [ThreadStatic]
    private static int _targetMatchGoalTemplateId;

    [ThreadStatic]
    private static EPlanningActionCharacterSelector _targetMatchSelector;

    [ThreadStatic]
    private static EPlanningActionCharacterSelectRange _targetMatchRange;

    [ThreadStatic]
    private static int _targetMatchRangeValue;

    /// <summary>开始记录一次过月中的 NPC 行动规划诊断。</summary>
    public static void BeginAdvanceMonth()
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled)
        {
            return;
        }

        lock (SyncRoot)
        {
            _current = default;
            _current.StartTicks = Stopwatch.GetTimestamp();
            ClearMetrics();
        }
    }

    /// <summary>结束并写出本次 NPC 行动规划诊断。</summary>
    public static void EndAdvanceMonth()
    {
        if (_current.StartTicks == 0)
        {
            return;
        }

        lock (SyncRoot)
        {
            if (_current.StartTicks == 0)
            {
                return;
            }

            long totalTicks = Stopwatch.GetTimestamp() - _current.StartTicks;
            if (Logger.IsInfoEnabled)
            {
                Logger.Info(BuildMessage(totalTicks));
            }

            _current = default;
            ClearMetrics();
        }
    }

    /// <summary>开始记录 NPC 目标索引全量构建。</summary>
    public static long BeginTargetLookupBuild() =>
        IsActive() ? Stopwatch.GetTimestamp() : 0;

    /// <summary>结束 NPC 目标索引全量构建。</summary>
    public static void EndTargetLookupBuild(long startTicks)
    {
        if (startTicks == 0)
        {
            return;
        }

        lock (SyncRoot)
        {
            _current.TargetLookupBuildTicks += Stopwatch.GetTimestamp() - startTicks;
            _current.TargetLookupBuildCalls++;
        }
    }

    /// <summary>记录目标索引全量构建出的数据规模。</summary>
    public static void RecordTargetLookupSnapshotSize(int blockCount, int areaCount, int stateCount, int characterIdCount)
    {
        if (!IsActive())
        {
            return;
        }

        lock (SyncRoot)
        {
            _current.TargetLookupBlockCount = blockCount;
            _current.TargetLookupAreaCount = areaCount;
            _current.TargetLookupStateCount = stateCount;
            _current.TargetLookupCharacterIdCount = characterIdCount;
        }
    }

    /// <summary>进入原版 `OfflineUpdateCurrentGoalActions`。</summary>
    public static long BeginOfflineCurrentGoalActions(ActionPlanningData.ECurrentGoalType goalType)
    {
        if (!IsActive())
        {
            return 0;
        }

        _goalType = goalType;
        _goalScopeDepth++;
        return Stopwatch.GetTimestamp();
    }

    /// <summary>离开原版 `OfflineUpdateCurrentGoalActions`。</summary>
    public static void EndOfflineCurrentGoalActions(ActionPlanningData.ECurrentGoalType goalType, long startTicks)
    {
        EndGoalStep(goalType, CharacterActionPlanningStep.OfflineUpdateCurrentGoalActions, startTicks);
        LeaveGoalScope();
    }

    /// <summary>进入原版 `ComplementUpdateCurrentGoalActions`。</summary>
    public static long BeginComplementCurrentGoalActions(ActionPlanningData.ECurrentGoalType goalType)
    {
        if (!IsActive())
        {
            return 0;
        }

        _goalType = goalType;
        _goalScopeDepth++;
        return Stopwatch.GetTimestamp();
    }

    /// <summary>离开原版 `ComplementUpdateCurrentGoalActions`。</summary>
    public static void EndComplementCurrentGoalActions(ActionPlanningData.ECurrentGoalType goalType, long startTicks)
    {
        EndGoalStep(goalType, CharacterActionPlanningStep.ComplementUpdateCurrentGoalActions, startTicks);
        LeaveGoalScope();
    }

    /// <summary>开始记录当前 goal scope 内的细分步骤。</summary>
    public static long BeginGoalStep() =>
        IsActive() && _goalScopeDepth > 0 ? Stopwatch.GetTimestamp() : 0;

    /// <summary>结束当前 goal scope 内的细分步骤。</summary>
    public static void EndGoalStep(CharacterActionPlanningStep step, long startTicks) =>
        EndGoalStep(_goalType, step, startTicks);

    /// <summary>开始记录原版并行月结子阶段。</summary>
    public static long BeginParallelStage(CharacterActionPlanningParallelStage stage)
    {
        _ = stage;
        return IsActive() ? Stopwatch.GetTimestamp() : 0;
    }

    /// <summary>结束原版并行月结子阶段。</summary>
    public static void EndParallelStage(CharacterActionPlanningParallelStage stage, long startTicks)
    {
        if (startTicks == 0)
        {
            return;
        }

        AddMetric(ParallelStages[(int)stage], Stopwatch.GetTimestamp() - startTicks);
    }

    /// <summary>记录一次 `GetCharactersInSelectRange` 的耗时和候选数。</summary>
    public static void EndGetCharactersInSelectRange(long startTicks, int candidateCount)
    {
        if (startTicks == 0)
        {
            return;
        }

        AddGoalMetricExtra(CharacterActionPlanningStep.GetCharactersInSelectRange, startTicks, candidateCount, 0);
    }

    /// <summary>记录一次目标过滤的耗时、输入候选数和输出候选数。</summary>
    public static void EndFilterActionTargets(long startTicks, int selectableCount, int resultCount)
    {
        if (startTicks == 0)
        {
            return;
        }

        AddGoalMetricExtra(CharacterActionPlanningStep.FilterActionTargets, startTicks, selectableCount, resultCount);
    }

    /// <summary>记录一次目标过滤，并归因到具体 `PlanningAction`。</summary>
    public static void EndFilterActionTargets(
        long startTicks,
        int selectableCount,
        int resultCount,
        int actionTemplateId,
        EPlanningActionCharacterSelector selector,
        EPlanningActionCharacterSelectRange range,
        int rangeValue)
    {
        if (startTicks == 0)
        {
            return;
        }

        long ticks = Stopwatch.GetTimestamp() - startTicks;
        GoalMetrics metrics = _goalType == ActionPlanningData.ECurrentGoalType.Primary ? PrimaryMetrics : SecondaryMetrics;
        AddMetric(metrics.Steps[(int)CharacterActionPlanningStep.FilterActionTargets], ticks, selectableCount, resultCount);
        AddActionMetric(
            metrics.FilterTargetsByAction,
            actionTemplateId,
            selector,
            range,
            rangeValue,
            ticks,
            selectableCount,
            resultCount);
    }

    /// <summary>记录如果先用关系索引预筛，`FilterActionTargets` 理论上可以少检查多少候选。</summary>
    public static void RecordRelationPrefilterCandidates(
        int selfCharId,
        IReadOnlyList<Character>? selectableCharacters,
        int actionTemplateId,
        EPlanningActionCharacterSelector selector,
        EPlanningActionCharacterSelectRange range,
        int rangeValue)
    {
        if (!IsActive() || _goalScopeDepth <= 0 || actionTemplateId < 0 || selectableCharacters == null)
        {
            return;
        }

        int selectableCount = selectableCharacters.Count;
        if (selectableCount <= 0)
        {
            return;
        }

        int relationCandidateCount = 0;
        for (int i = 0; i < selectableCharacters.Count; i++)
        {
            Character targetChar = selectableCharacters[i];
            if (targetChar != null &&
                DomainManager.Character.TryGetRelation(selfCharId, targetChar.GetId(), out var _))
            {
                relationCandidateCount++;
            }
        }

        GoalMetrics metrics = _goalType == ActionPlanningData.ECurrentGoalType.Primary ? PrimaryMetrics : SecondaryMetrics;
        lock (SyncRoot)
        {
            if (!metrics.RelationPrefilterByAction.TryGetValue(actionTemplateId, out RelationPrefilterMetric? metric))
            {
                metric = new RelationPrefilterMetric(actionTemplateId, selector, range, rangeValue);
                metrics.RelationPrefilterByAction.Add(actionTemplateId, metric);
            }

            metric.Add(selectableCount, relationCandidateCount);
        }
    }

    /// <summary>记录关系目标反查表实际生效后的候选数量变化。</summary>
    public static void RecordRelationTargetPrefilterApplied(
        int actionTemplateId,
        EPlanningActionCharacterSelector selector,
        EPlanningActionCharacterSelectRange range,
        int rangeValue,
        int inputCount,
        int outputCount)
    {
        if (!IsActive() || _goalScopeDepth <= 0 || actionTemplateId < 0)
        {
            return;
        }

        GoalMetrics metrics = _goalType == ActionPlanningData.ECurrentGoalType.Primary ? PrimaryMetrics : SecondaryMetrics;
        lock (SyncRoot)
        {
            if (!metrics.RelationTargetPrefilterByAction.TryGetValue(actionTemplateId, out RelationTargetPrefilterMetric? metric))
            {
                metric = new RelationTargetPrefilterMetric(actionTemplateId, selector, range, rangeValue);
                metrics.RelationTargetPrefilterByAction.Add(actionTemplateId, metric);
            }

            metric.Add(inputCount, outputCount);
        }
    }

    /// <summary>记录关系目标反查表没有接管本次过滤的原因。</summary>
    public static void RecordRelationTargetPrefilterSkipped(CharacterRelationTargetPrefilterSkipReason reason)
    {
        if (!IsActive() || _goalScopeDepth <= 0)
        {
            return;
        }

        lock (SyncRoot)
        {
            RelationTargetPrefilterSkips[(int)reason].Count++;
        }
    }

    /// <summary>记录关系目标反查表异常类型，用于判断当前加速路径是否适合保留。</summary>
    public static void RecordRelationTargetPrefilterException(Exception exception)
    {
        if (!IsActive() || _goalScopeDepth <= 0)
        {
            return;
        }

        Type exceptionType = exception.GetType();
        lock (SyncRoot)
        {
            RelationTargetPrefilterSkips[(int)CharacterRelationTargetPrefilterSkipReason.Exception].Count++;
            if (!RelationTargetPrefilterExceptions.TryGetValue(exceptionType, out ExceptionMetric? metric))
            {
                metric = new ExceptionMetric(exceptionType, exception.Message);
                RelationTargetPrefilterExceptions.Add(exceptionType, metric);
            }

            metric.Count++;
        }
    }

    /// <summary>记录 `TargetMatcher` 阶段缓存命中。</summary>
    public static void RecordTargetMatcherCacheHit(bool result) =>
        RecordTargetMatcherCache(hit: true, miss: false, fallback: false, result: result);

    /// <summary>记录 `TargetMatcher` 阶段缓存未命中并执行原版匹配。</summary>
    public static void RecordTargetMatcherCacheMiss(bool result) =>
        RecordTargetMatcherCache(hit: false, miss: true, fallback: false, result: result);

    /// <summary>记录 `TargetMatcher` 阶段缓存未启用时的原版回退。</summary>
    public static void RecordTargetMatcherCacheFallback(bool result) =>
        RecordTargetMatcherCache(hit: false, miss: false, fallback: true, result: result);

    /// <summary>记录 `TargetMatcher` 阶段缓存因安全边界而回退原版的原因。</summary>
    public static void RecordTargetMatcherCacheFallback(
        CharacterTargetMatcherCacheRejectReason rejectReason,
        int rejectDetail,
        bool result) =>
        RecordTargetMatcherCache(
            hit: false,
            miss: false,
            fallback: true,
            result: result,
            rejectReason: rejectReason,
            rejectDetail: rejectDetail);

    /// <summary>记录一次 `PrepareContext`，并归因到具体 `PlanningAction`。</summary>
    public static void EndPrepareContext(
        long startTicks,
        int actionTemplateId,
        EPlanningActionCharacterSelector selector,
        EPlanningActionCharacterSelectRange range,
        int rangeValue)
    {
        if (startTicks == 0)
        {
            return;
        }

        long ticks = Stopwatch.GetTimestamp() - startTicks;
        GoalMetrics metrics = _goalType == ActionPlanningData.ECurrentGoalType.Primary ? PrimaryMetrics : SecondaryMetrics;
        AddMetric(metrics.Steps[(int)CharacterActionPlanningStep.PrepareContext], ticks);
        AddActionMetric(
            metrics.PrepareContextByAction,
            actionTemplateId,
            selector,
            range,
            rangeValue,
            ticks,
            0,
            0);
    }

    /// <summary>进入 `PlanningGoalNode.MatchTargetCharacter`，用于拆分目标匹配成本。</summary>
    public static TargetMatchDiagnosticsState BeginGoalTargetMatch(int goalTemplateId, int actionTemplateId)
    {
        if (!IsActive() || _goalScopeDepth <= 0)
        {
            return default;
        }

        var state = new TargetMatchDiagnosticsState(
            Stopwatch.GetTimestamp(),
            CharacterTargetMatchScopeKind.Goal,
            actionTemplateId,
            goalTemplateId,
            _targetMatchScopeKind,
            _targetMatchActionTemplateId,
            _targetMatchGoalTemplateId,
            _targetMatchSelector,
            _targetMatchRange,
            _targetMatchRangeValue);
        _targetMatchScopeKind = CharacterTargetMatchScopeKind.Goal;
        _targetMatchActionTemplateId = actionTemplateId;
        _targetMatchGoalTemplateId = goalTemplateId;
        return state;
    }

    /// <summary>离开 `PlanningGoalNode.MatchTargetCharacter`。</summary>
    public static void EndGoalTargetMatch(TargetMatchDiagnosticsState state, bool result)
    {
        if (state.StartTicks == 0)
        {
            return;
        }

        GoalMetrics metrics = _goalType == ActionPlanningData.ECurrentGoalType.Primary ? PrimaryMetrics : SecondaryMetrics;
        AddTemplateMetric(
            metrics.GoalTargetMatchByGoal,
            state.GoalTemplateId,
            Stopwatch.GetTimestamp() - state.StartTicks,
            result,
            0,
            0);
        RestoreTargetMatchScope(state);
    }

    /// <summary>进入 `PlanningActionNode.MatchTargetCharacter`，用于拆分目标匹配成本。</summary>
    public static TargetMatchDiagnosticsState BeginActionTargetMatch(
        int actionTemplateId,
        EPlanningActionCharacterSelector selector,
        EPlanningActionCharacterSelectRange range,
        int rangeValue)
    {
        if (!IsActive() || _goalScopeDepth <= 0)
        {
            return default;
        }

        var state = new TargetMatchDiagnosticsState(
            Stopwatch.GetTimestamp(),
            CharacterTargetMatchScopeKind.Action,
            actionTemplateId,
            _targetMatchGoalTemplateId,
            _targetMatchScopeKind,
            _targetMatchActionTemplateId,
            _targetMatchGoalTemplateId,
            _targetMatchSelector,
            _targetMatchRange,
            _targetMatchRangeValue,
            selector,
            range,
            rangeValue);
        _targetMatchScopeKind = CharacterTargetMatchScopeKind.Action;
        _targetMatchActionTemplateId = actionTemplateId;
        _targetMatchSelector = selector;
        _targetMatchRange = range;
        _targetMatchRangeValue = rangeValue;
        return state;
    }

    /// <summary>离开 `PlanningActionNode.MatchTargetCharacter`。</summary>
    public static void EndActionTargetMatch(TargetMatchDiagnosticsState state, bool result)
    {
        if (state.StartTicks == 0)
        {
            return;
        }

        GoalMetrics metrics = _goalType == ActionPlanningData.ECurrentGoalType.Primary ? PrimaryMetrics : SecondaryMetrics;
        AddActionMetric(
            metrics.ActionTargetMatchByAction,
            state.ActionTemplateId,
            state.Selector,
            state.Range,
            state.RangeValue,
            Stopwatch.GetTimestamp() - state.StartTicks,
            0,
            0,
            result);
        RestoreTargetMatchScope(state);
    }

    /// <summary>进入目标条件数组匹配，记录当前 goal/action 上下文。</summary>
    public static TargetConditionDiagnosticsState BeginTargetConditions(StateConditionAndValue<StateKey>[] conditions)
    {
        long startTicks = BeginGoalStep();
        if (startTicks == 0)
        {
            return default;
        }

        return new TargetConditionDiagnosticsState(
            startTicks,
            _targetMatchScopeKind,
            _targetMatchActionTemplateId,
            _targetMatchGoalTemplateId,
            _targetMatchSelector,
            _targetMatchRange,
            _targetMatchRangeValue,
            conditions?.Length ?? 0);
    }

    /// <summary>离开目标条件数组匹配，并按 action/goal/sensor 粗分成本。</summary>
    public static void EndTargetConditions(
        TargetConditionDiagnosticsState state,
        StateConditionAndValue<StateKey>[] conditions,
        bool result,
        Character selfChar,
        Character targetChar)
    {
        if (state.StartTicks == 0)
        {
            return;
        }

        long ticks = Stopwatch.GetTimestamp() - state.StartTicks;
        GoalMetrics metrics = _goalType == ActionPlanningData.ECurrentGoalType.Primary ? PrimaryMetrics : SecondaryMetrics;
        AddMetric(metrics.Steps[(int)CharacterActionPlanningStep.MatchTargetCharacterByConditions], ticks);

        int conditionCount = conditions?.Length ?? state.ConditionCount;
        int referenceConditionCount = CountReferenceConditions(conditions);
        if (state.ScopeKind == CharacterTargetMatchScopeKind.Action)
        {
            AddActionMetric(
                metrics.TargetConditionsByAction,
                state.ActionTemplateId,
                state.Selector,
                state.Range,
                state.RangeValue,
                ticks,
                conditionCount,
                referenceConditionCount,
                result);
        }
        else if (state.ScopeKind == CharacterTargetMatchScopeKind.Goal)
        {
            AddTemplateMetric(
                metrics.TargetConditionsByGoal,
                state.GoalTemplateId,
                ticks,
                result,
                conditionCount,
                referenceConditionCount);
        }

        AddTargetConditionSensorUsage(metrics.TargetConditionSensors, conditions);
        RecordTargetRelationConditionPrefilter(metrics, state, conditions, result, selfChar, targetChar);
    }

    /// <summary>记录一次目标索引查询。</summary>
    public static void RecordTargetLookup(
        CharacterActionTargetLookupKind kind,
        bool hit,
        int candidateIds,
        int charactersAdded)
    {
        if (!IsActive() || _goalScopeDepth <= 0)
        {
            return;
        }

        TargetLookupMetric metric = TargetLookupMetrics[(int)kind];
        lock (SyncRoot)
        {
            metric.Calls++;
            if (hit)
            {
                metric.Hits++;
                metric.CandidateIds += Math.Max(candidateIds, 0);
                metric.CharactersAdded += Math.Max(charactersAdded, 0);
            }
            else
            {
                metric.Fallbacks++;
            }
        }
    }

    private static void EndGoalStep(
        ActionPlanningData.ECurrentGoalType goalType,
        CharacterActionPlanningStep step,
        long startTicks)
    {
        if (startTicks == 0)
        {
            return;
        }

        GoalMetrics metrics = goalType == ActionPlanningData.ECurrentGoalType.Primary ? PrimaryMetrics : SecondaryMetrics;
        AddMetric(metrics.Steps[(int)step], Stopwatch.GetTimestamp() - startTicks);
    }

    private static void AddGoalMetricExtra(
        CharacterActionPlanningStep step,
        long startTicks,
        int inputCount,
        int outputCount)
    {
        GoalMetrics metrics = _goalType == ActionPlanningData.ECurrentGoalType.Primary ? PrimaryMetrics : SecondaryMetrics;
        AddMetric(metrics.Steps[(int)step], Stopwatch.GetTimestamp() - startTicks, inputCount, outputCount);
    }

    private static void AddMetric(Metric metric, long ticks, int inputCount = 0, int outputCount = 0)
    {
        lock (SyncRoot)
        {
            metric.Calls++;
            metric.Ticks += ticks;
            if (ticks > metric.MaxTicks)
            {
                metric.MaxTicks = ticks;
            }

            if (inputCount > 0)
            {
                metric.InputCount += inputCount;
                if (inputCount > metric.MaxInputCount)
                {
                    metric.MaxInputCount = inputCount;
                }
            }

            if (outputCount > 0)
            {
                metric.OutputCount += outputCount;
                if (outputCount > metric.MaxOutputCount)
                {
                    metric.MaxOutputCount = outputCount;
                }
            }
        }
    }

    private static void AddActionMetric(
        Dictionary<int, ActionMetric> metrics,
        int actionTemplateId,
        EPlanningActionCharacterSelector selector,
        EPlanningActionCharacterSelectRange range,
        int rangeValue,
        long ticks,
        int inputCount,
        int outputCount,
        bool? result = null)
    {
        if (actionTemplateId < 0)
        {
            return;
        }

        lock (SyncRoot)
        {
            if (!metrics.TryGetValue(actionTemplateId, out ActionMetric? metric))
            {
                metric = new ActionMetric(actionTemplateId, selector, range, rangeValue);
                metrics.Add(actionTemplateId, metric);
            }

            metric.Add(ticks, inputCount, outputCount, result);
        }
    }

    private static void AddTemplateMetric(
        Dictionary<int, TemplateMetric> metrics,
        int templateId,
        long ticks,
        bool result,
        int inputCount,
        int outputCount)
    {
        if (templateId < 0)
        {
            return;
        }

        lock (SyncRoot)
        {
            if (!metrics.TryGetValue(templateId, out TemplateMetric? metric))
            {
                metric = new TemplateMetric(templateId);
                metrics.Add(templateId, metric);
            }

            metric.Add(ticks, inputCount, outputCount, result);
        }
    }

    private static void RestoreTargetMatchScope(TargetMatchDiagnosticsState state)
    {
        _targetMatchScopeKind = state.PreviousScopeKind;
        _targetMatchActionTemplateId = state.PreviousActionTemplateId;
        _targetMatchGoalTemplateId = state.PreviousGoalTemplateId;
        _targetMatchSelector = state.PreviousSelector;
        _targetMatchRange = state.PreviousRange;
        _targetMatchRangeValue = state.PreviousRangeValue;
    }

    private static int CountReferenceConditions(StateConditionAndValue<StateKey>[]? conditions)
    {
        if (conditions == null)
        {
            return 0;
        }

        int count = 0;
        foreach (StateConditionAndValue<StateKey> condition in conditions)
        {
            if (!condition.IsConstValue)
            {
                count++;
            }
        }

        return count;
    }

    private static void AddTargetConditionSensorUsage(
        Dictionary<int, SensorUsageMetric> metrics,
        StateConditionAndValue<StateKey>[]? conditions)
    {
        if (conditions == null || conditions.Length == 0)
        {
            return;
        }

        lock (SyncRoot)
        {
            foreach (StateConditionAndValue<StateKey> condition in conditions)
            {
                AddSensorUsage(metrics, (int)condition.Key.Template.SensorType);
                if (!condition.IsConstValue)
                {
                    AddSensorUsage(metrics, (int)condition.ReferenceKey.Template.SensorType);
                }
            }
        }
    }

    private static void AddSensorUsage(Dictionary<int, SensorUsageMetric> metrics, int sensorType)
    {
        if (!metrics.TryGetValue(sensorType, out SensorUsageMetric? metric))
        {
            metric = new SensorUsageMetric(sensorType);
            metrics.Add(sensorType, metric);
        }

        metric.Count++;
    }

    private static void RecordTargetRelationConditionPrefilter(
        GoalMetrics metrics,
        TargetConditionDiagnosticsState state,
        StateConditionAndValue<StateKey>[]? conditions,
        bool fullResult,
        Character selfChar,
        Character targetChar)
    {
        if (!TryEvaluateTargetRelationConditions(
                conditions,
                selfChar,
                targetChar,
                out int relationConditionCount,
                out bool relationConditionsPassed))
        {
            return;
        }

        if (state.ScopeKind == CharacterTargetMatchScopeKind.Action)
        {
            AddRelationConditionMetric(
                metrics.RelationConditionsByAction,
                state.ActionTemplateId,
                state.Selector,
                state.Range,
                state.RangeValue,
                relationConditionCount,
                relationConditionsPassed,
                fullResult);
        }
        else if (state.ScopeKind == CharacterTargetMatchScopeKind.Goal)
        {
            AddRelationConditionMetric(
                metrics.RelationConditionsByGoal,
                state.GoalTemplateId,
                relationConditionCount,
                relationConditionsPassed,
                fullResult);
        }
    }

    private static bool TryEvaluateTargetRelationConditions(
        StateConditionAndValue<StateKey>[]? conditions,
        Character selfChar,
        Character targetChar,
        out int relationConditionCount,
        out bool relationConditionsPassed)
    {
        relationConditionCount = 0;
        relationConditionsPassed = true;
        if (conditions == null || conditions.Length == 0 || selfChar == null || targetChar == null)
        {
            return false;
        }

        int actorCharId = selfChar.GetId();
        int candidateCharId = targetChar.GetId();
        foreach (StateConditionAndValue<StateKey> condition in conditions)
        {
            if (!condition.IsConstValue ||
                !TryGetTargetRelationStateValue(actorCharId, candidateCharId, condition.Key.StateTemplateId, out int value))
            {
                continue;
            }

            relationConditionCount++;
            if (!StateConditionHelper.Check(condition.ConditionType, value, condition.Value))
            {
                relationConditionsPassed = false;
            }
        }

        return relationConditionCount > 0;
    }

    private static bool TryGetTargetRelationStateValue(int actorCharId, int candidateCharId, int stateTemplateId, out int value)
    {
        // 原版在 TargetStateSensor 中以候选角色为 selfChar、行动角色为 targetChar。
        value = 0;
        switch (stateTemplateId)
        {
            case 302:
                value = ToInt(DomainManager.Character.HasRelation(actorCharId, candidateCharId, 16384));
                return true;
            case 303:
                value = ToInt(DomainManager.Character.HasRelation(actorCharId, candidateCharId, 32768));
                return true;
            case 304:
                value = ToInt(DomainManager.Character.IsCharacterRelationFriendly(candidateCharId, actorCharId));
                return true;
            case 305:
                value = ToInt(DomainManager.Character.HasRelation(candidateCharId, actorCharId, 73));
                return true;
            case 306:
                value = ToInt(DomainManager.Character.HasRelation(candidateCharId, actorCharId, 292));
                return true;
            case 307:
                value = ToInt(DomainManager.Character.HasRelation(candidateCharId, actorCharId, 146));
                return true;
            case 308:
                value = ToInt(DomainManager.Character.HasRelation(candidateCharId, actorCharId, 8192));
                return true;
            case 309:
                value = ToInt(DomainManager.Character.HasRelation(candidateCharId, actorCharId, 448));
                return true;
            case 310:
                value = ToInt(DomainManager.Character.HasRelation(candidateCharId, actorCharId, 1024));
                return true;
            case 311:
                value = ToInt(DomainManager.Character.HasRelation(candidateCharId, actorCharId, 512));
                return true;
            case 312:
                value = ToInt(
                    DomainManager.Character.HasRelation(candidateCharId, actorCharId, 16384) &&
                    DomainManager.Character.HasRelation(actorCharId, candidateCharId, 16384));
                return true;
            case 313:
                value = ToInt(DomainManager.Character.HasRelation(candidateCharId, actorCharId, 6144));
                return true;
            default:
                return false;
        }
    }

    private static int ToInt(bool value) => value ? 1 : 0;

    private static void AddRelationConditionMetric(
        Dictionary<int, RelationConditionMetric> metrics,
        int templateId,
        int relationConditionCount,
        bool relationConditionsPassed,
        bool fullResult)
    {
        if (templateId < 0)
        {
            return;
        }

        lock (SyncRoot)
        {
            if (!metrics.TryGetValue(templateId, out RelationConditionMetric? metric))
            {
                metric = new RelationConditionMetric(templateId);
                metrics.Add(templateId, metric);
            }

            metric.Add(relationConditionCount, relationConditionsPassed, fullResult);
        }
    }

    private static void AddRelationConditionMetric(
        Dictionary<int, ActionRelationConditionMetric> metrics,
        int actionTemplateId,
        EPlanningActionCharacterSelector selector,
        EPlanningActionCharacterSelectRange range,
        int rangeValue,
        int relationConditionCount,
        bool relationConditionsPassed,
        bool fullResult)
    {
        if (actionTemplateId < 0)
        {
            return;
        }

        lock (SyncRoot)
        {
            if (!metrics.TryGetValue(actionTemplateId, out ActionRelationConditionMetric? metric))
            {
                metric = new ActionRelationConditionMetric(actionTemplateId, selector, range, rangeValue);
                metrics.Add(actionTemplateId, metric);
            }

            metric.Add(relationConditionCount, relationConditionsPassed, fullResult);
        }
    }

    private static void RecordTargetMatcherCache(
        bool hit,
        bool miss,
        bool fallback,
        bool result,
        CharacterTargetMatcherCacheRejectReason rejectReason = CharacterTargetMatcherCacheRejectReason.None,
        int rejectDetail = 0)
    {
        if (!IsActive() || _goalScopeDepth <= 0 || _targetMatchScopeKind != CharacterTargetMatchScopeKind.Action)
        {
            return;
        }

        int actionTemplateId = _targetMatchActionTemplateId;
        if (actionTemplateId < 0)
        {
            return;
        }

        GoalMetrics metrics = _goalType == ActionPlanningData.ECurrentGoalType.Primary ? PrimaryMetrics : SecondaryMetrics;
        lock (SyncRoot)
        {
            if (!metrics.TargetMatcherCacheByAction.TryGetValue(actionTemplateId, out TargetMatcherCacheMetric? metric))
            {
                metric = new TargetMatcherCacheMetric(
                    actionTemplateId,
                    _targetMatchSelector,
                    _targetMatchRange,
                    _targetMatchRangeValue);
                metrics.TargetMatcherCacheByAction.Add(actionTemplateId, metric);
            }

            metric.Add(hit, miss, fallback, result, rejectReason, rejectDetail);
        }
    }

    private static void LeaveGoalScope()
    {
        if (_goalScopeDepth > 0)
        {
            _goalScopeDepth--;
        }

        if (_goalScopeDepth == 0)
        {
            _goalType = default;
        }
    }

    public static bool IsRecording => IsActive();

    private static bool IsActive() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled && _current.StartTicks != 0;

    private static string BuildMessage(long totalTicks)
    {
        StringBuilder builder = new(7600);
        builder.AppendLine("TaiwuOptimization: CharacterActionPlanning diagnostics");
        builder.AppendLine("  total:");
        AppendMetric(builder, "elapsed", FormatMilliseconds(totalTicks));

        builder.AppendLine("  targetLookupBuild:");
        AppendMetric(builder, "elapsed", FormatMilliseconds(_current.TargetLookupBuildTicks) + ", calls=" + _current.TargetLookupBuildCalls);
        AppendMetric(builder, "blocks", _current.TargetLookupBlockCount);
        AppendMetric(builder, "areas", _current.TargetLookupAreaCount);
        AppendMetric(builder, "states", _current.TargetLookupStateCount);
        AppendMetric(builder, "characterIds", _current.TargetLookupCharacterIdCount);
        AppendRelationTargetPrefilterSkips(builder);
        AppendRelationTargetPrefilterExceptions(builder);

        builder.AppendLine("  parallelStages:");
        AppendMetric(builder, nameof(CharacterActionPlanningParallelStage.UpdateCharacterMission), ParallelStages[(int)CharacterActionPlanningParallelStage.UpdateCharacterMission]);
        AppendMetric(builder, nameof(CharacterActionPlanningParallelStage.UpdateCharacterGoal), ParallelStages[(int)CharacterActionPlanningParallelStage.UpdateCharacterGoal]);
        AppendMetric(builder, nameof(CharacterActionPlanningParallelStage.UpdateInfectedCharacterActions), ParallelStages[(int)CharacterActionPlanningParallelStage.UpdateInfectedCharacterActions]);
        AppendMetric(builder, nameof(CharacterActionPlanningParallelStage.UpdateLegendaryBookOwnersActions), ParallelStages[(int)CharacterActionPlanningParallelStage.UpdateLegendaryBookOwnersActions]);
        AppendMetric(builder, nameof(CharacterActionPlanningParallelStage.UpdatePrimaryGoalAndActions), ParallelStages[(int)CharacterActionPlanningParallelStage.UpdatePrimaryGoalAndActions]);
        AppendMetric(builder, nameof(CharacterActionPlanningParallelStage.UpdateSecondaryGoalAndActions), ParallelStages[(int)CharacterActionPlanningParallelStage.UpdateSecondaryGoalAndActions]);

        AppendGoalMetrics(builder, "primaryGoalActions", PrimaryMetrics);
        AppendGoalMetrics(builder, "secondaryGoalActions", SecondaryMetrics);

        builder.AppendLine("  targetLookupCalls:");
        AppendTargetLookup(builder, nameof(CharacterActionTargetLookupKind.SameBlock), TargetLookupMetrics[(int)CharacterActionTargetLookupKind.SameBlock]);
        AppendTargetLookup(builder, nameof(CharacterActionTargetLookupKind.SameArea), TargetLookupMetrics[(int)CharacterActionTargetLookupKind.SameArea]);
        AppendTargetLookup(builder, nameof(CharacterActionTargetLookupKind.SameState), TargetLookupMetrics[(int)CharacterActionTargetLookupKind.SameState]);
        AppendTargetLookup(builder, nameof(CharacterActionTargetLookupKind.BlockRange), TargetLookupMetrics[(int)CharacterActionTargetLookupKind.BlockRange]);
        AppendTargetLookup(builder, nameof(CharacterActionTargetLookupKind.SettlementRange), TargetLookupMetrics[(int)CharacterActionTargetLookupKind.SettlementRange]);
        return builder.ToString();
    }

    private static void AppendGoalMetrics(StringBuilder builder, string title, GoalMetrics metrics)
    {
        builder.Append("  ");
        builder.Append(title);
        builder.AppendLine(":");
        AppendMetric(builder, nameof(CharacterActionPlanningStep.OfflineUpdateCurrentGoalActions), metrics.Steps[(int)CharacterActionPlanningStep.OfflineUpdateCurrentGoalActions]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.ComplementUpdateCurrentGoalActions), metrics.Steps[(int)CharacterActionPlanningStep.ComplementUpdateCurrentGoalActions]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.OfflineUpdateGoalPlan), metrics.Steps[(int)CharacterActionPlanningStep.OfflineUpdateGoalPlan]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.ReassessPlan), metrics.Steps[(int)CharacterActionPlanningStep.ReassessPlan]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.OfflineCreateNextAction), metrics.Steps[(int)CharacterActionPlanningStep.OfflineCreateNextAction]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.ExecuteAction), metrics.Steps[(int)CharacterActionPlanningStep.ExecuteAction]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.CheckPrerequisites), metrics.Steps[(int)CharacterActionPlanningStep.CheckPrerequisites]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.GetCharactersInSelectRange), metrics.Steps[(int)CharacterActionPlanningStep.GetCharactersInSelectRange]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.FilterActionTargets), metrics.Steps[(int)CharacterActionPlanningStep.FilterActionTargets]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.CharacterActionPlannerPlan), metrics.Steps[(int)CharacterActionPlanningStep.CharacterActionPlannerPlan]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.CharacterActionPlannerReassess), metrics.Steps[(int)CharacterActionPlanningStep.CharacterActionPlannerReassess]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.WeightBasedFindPath), metrics.Steps[(int)CharacterActionPlanningStep.WeightBasedFindPath]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.WeightBasedFindPathRecursive), metrics.Steps[(int)CharacterActionPlanningStep.WeightBasedFindPathRecursive]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.WeightBasedGetUnsatisfiedStateCount), metrics.Steps[(int)CharacterActionPlanningStep.WeightBasedGetUnsatisfiedStateCount]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.StateMemoryCheckCondition), metrics.Steps[(int)CharacterActionPlanningStep.StateMemoryCheckCondition]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.PrepareContext), metrics.Steps[(int)CharacterActionPlanningStep.PrepareContext]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.CalcCurrentState), metrics.Steps[(int)CharacterActionPlanningStep.CalcCurrentState]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.MatchTargetCharacter), metrics.Steps[(int)CharacterActionPlanningStep.MatchTargetCharacter]);
        AppendMetric(builder, nameof(CharacterActionPlanningStep.MatchTargetCharacterByConditions), metrics.Steps[(int)CharacterActionPlanningStep.MatchTargetCharacterByConditions]);
        AppendActionMetricTop(builder, "prepareContextByActionTop", metrics.PrepareContextByAction);
        AppendActionMetricTop(builder, "filterActionTargetsByActionTop", metrics.FilterTargetsByAction);
        AppendRelationTargetPrefilterTop(builder, "actualRelationTargetPrefilterByActionTop", metrics.RelationTargetPrefilterByAction);
        AppendRelationPrefilterTop(builder, "relationPrefilterByActionTop", metrics.RelationPrefilterByAction);
        AppendTemplateMetricTop(builder, "goalTargetMatchByGoalTop", metrics.GoalTargetMatchByGoal);
        AppendActionMetricTop(builder, "actionTargetMatchByActionTop", metrics.ActionTargetMatchByAction);
        AppendTargetMatcherCacheTop(builder, "targetMatcherCacheByActionTop", metrics.TargetMatcherCacheByAction);
        AppendTemplateMetricTop(
            builder,
            "targetConditionsByGoalTop",
            metrics.TargetConditionsByGoal,
            "conditions",
            "refConditions");
        AppendActionMetricTop(
            builder,
            "targetConditionsByActionTop",
            metrics.TargetConditionsByAction,
            "conditions",
            "refConditions");
        AppendRelationConditionTop(builder, "relationConditionPrefilterByGoalTop", metrics.RelationConditionsByGoal);
        AppendRelationConditionTop(builder, "relationConditionPrefilterByActionTop", metrics.RelationConditionsByAction);
        AppendSensorUsageTop(builder, "targetConditionSensorUsageTop", metrics.TargetConditionSensors);
    }

    private static void AppendMetric(StringBuilder builder, string name, Metric metric)
    {
        builder.Append("    ");
        builder.Append(name);
        builder.Append(": ");
        builder.Append(FormatMilliseconds(metric.Ticks));
        builder.Append(", calls=");
        builder.Append(metric.Calls);
        builder.Append(", max=");
        builder.Append(FormatMilliseconds(metric.MaxTicks));
        if (metric.InputCount > 0 || metric.OutputCount > 0)
        {
            builder.Append(", input=");
            builder.Append(metric.InputCount);
            builder.Append(", output=");
            builder.Append(metric.OutputCount);
            builder.Append(", maxInput=");
            builder.Append(metric.MaxInputCount);
            builder.Append(", maxOutput=");
            builder.Append(metric.MaxOutputCount);
        }

        builder.AppendLine();
    }

    private static void AppendTargetLookup(StringBuilder builder, string name, TargetLookupMetric metric)
    {
        builder.Append("    ");
        builder.Append(name);
        builder.Append(": calls=");
        builder.Append(metric.Calls);
        builder.Append(", hits=");
        builder.Append(metric.Hits);
        builder.Append(", fallbacks=");
        builder.Append(metric.Fallbacks);
        builder.Append(", candidateIds=");
        builder.Append(metric.CandidateIds);
        builder.Append(", charactersAdded=");
        builder.Append(metric.CharactersAdded);
        builder.AppendLine();
    }

    private static void AppendRelationTargetPrefilterSkips(StringBuilder builder)
    {
        builder.AppendLine("  actualRelationTargetPrefilterSkips:");
        AppendSkipMetric(builder, nameof(CharacterRelationTargetPrefilterSkipReason.OutOfScope), RelationTargetPrefilterSkips[(int)CharacterRelationTargetPrefilterSkipReason.OutOfScope]);
        AppendSkipMetric(builder, nameof(CharacterRelationTargetPrefilterSkipReason.EmptySource), RelationTargetPrefilterSkips[(int)CharacterRelationTargetPrefilterSkipReason.EmptySource]);
        AppendSkipMetric(builder, nameof(CharacterRelationTargetPrefilterSkipReason.NoRelationRule), RelationTargetPrefilterSkips[(int)CharacterRelationTargetPrefilterSkipReason.NoRelationRule]);
        AppendSkipMetric(builder, nameof(CharacterRelationTargetPrefilterSkipReason.UnsafeRule), RelationTargetPrefilterSkips[(int)CharacterRelationTargetPrefilterSkipReason.UnsafeRule]);
        AppendSkipMetric(builder, nameof(CharacterRelationTargetPrefilterSkipReason.Exception), RelationTargetPrefilterSkips[(int)CharacterRelationTargetPrefilterSkipReason.Exception]);
    }

    private static void AppendSkipMetric(StringBuilder builder, string name, SkipMetric metric)
    {
        builder.Append("    ");
        builder.Append(name);
        builder.Append(": ");
        builder.Append(metric.Count);
        builder.AppendLine();
    }

    private static void AppendRelationTargetPrefilterExceptions(StringBuilder builder)
    {
        if (RelationTargetPrefilterExceptions.Count == 0)
        {
            return;
        }

        List<ExceptionMetric> sorted = new(RelationTargetPrefilterExceptions.Values);
        sorted.Sort(static (left, right) => right.Count.CompareTo(left.Count));

        builder.AppendLine("  actualRelationTargetPrefilterExceptions:");
        int count = Math.Min(8, sorted.Count);
        for (int i = 0; i < count; i++)
        {
            ExceptionMetric metric = sorted[i];
            builder.Append("    ");
            builder.Append(metric.ExceptionType.FullName);
            builder.Append(": count=");
            builder.Append(metric.Count);
            if (!string.IsNullOrEmpty(metric.FirstMessage))
            {
                builder.Append(", firstMessage=");
                builder.Append(metric.FirstMessage.Replace('\r', ' ').Replace('\n', ' '));
            }

            builder.AppendLine();
        }
    }

    private static void AppendActionMetricTop(
        StringBuilder builder,
        string title,
        Dictionary<int, ActionMetric> metrics,
        string inputLabel = "input",
        string outputLabel = "output")
    {
        if (metrics.Count == 0)
        {
            return;
        }

        List<ActionMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.Ticks.CompareTo(left.Ticks));

        builder.Append("    ");
        builder.Append(title);
        builder.AppendLine(":");

        int count = Math.Min(12, sorted.Count);
        for (int i = 0; i < count; i++)
        {
            ActionMetric metric = sorted[i];
            builder.Append("      A");
            builder.Append(metric.ActionTemplateId);
            builder.Append(' ');
            builder.Append(GetActionRefName(metric.ActionTemplateId));
            builder.Append(": ");
            builder.Append(FormatMilliseconds(metric.Ticks));
            builder.Append(", calls=");
            builder.Append(metric.Calls);
            builder.Append(", max=");
            builder.Append(FormatMilliseconds(metric.MaxTicks));
            builder.Append(", selector=");
            builder.Append(metric.Selector);
            builder.Append(", range=");
            builder.Append(metric.Range);
            builder.Append(", rangeValue=");
            builder.Append(metric.RangeValue);
            AppendResultCounts(builder, metric.SuccessCount, metric.FailureCount);
            if (metric.InputCount > 0 || metric.OutputCount > 0)
            {
                builder.Append(", ");
                builder.Append(inputLabel);
                builder.Append('=');
                builder.Append(metric.InputCount);
                builder.Append(", ");
                builder.Append(outputLabel);
                builder.Append('=');
                builder.Append(metric.OutputCount);
                builder.Append(", avg");
                AppendPascalLabel(builder, inputLabel);
                builder.Append('=');
                builder.Append(metric.Calls == 0 ? "0.0" : (metric.InputCount / (double)metric.Calls).ToString("N1"));
                builder.Append(", max");
                AppendPascalLabel(builder, inputLabel);
                builder.Append('=');
                builder.Append(metric.MaxInputCount);
                builder.Append(", max");
                AppendPascalLabel(builder, outputLabel);
                builder.Append('=');
                builder.Append(metric.MaxOutputCount);
            }

            builder.AppendLine();
        }
    }

    private static void AppendTemplateMetricTop(
        StringBuilder builder,
        string title,
        Dictionary<int, TemplateMetric> metrics,
        string inputLabel = "input",
        string outputLabel = "output")
    {
        if (metrics.Count == 0)
        {
            return;
        }

        List<TemplateMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.Ticks.CompareTo(left.Ticks));

        builder.Append("    ");
        builder.Append(title);
        builder.AppendLine(":");

        int count = Math.Min(12, sorted.Count);
        for (int i = 0; i < count; i++)
        {
            TemplateMetric metric = sorted[i];
            builder.Append("      G");
            builder.Append(metric.TemplateId);
            builder.Append(' ');
            builder.Append(GetGoalRefName(metric.TemplateId));
            builder.Append(": ");
            builder.Append(FormatMilliseconds(metric.Ticks));
            builder.Append(", calls=");
            builder.Append(metric.Calls);
            builder.Append(", max=");
            builder.Append(FormatMilliseconds(metric.MaxTicks));
            AppendResultCounts(builder, metric.SuccessCount, metric.FailureCount);
            if (metric.InputCount > 0 || metric.OutputCount > 0)
            {
                builder.Append(", ");
                builder.Append(inputLabel);
                builder.Append('=');
                builder.Append(metric.InputCount);
                builder.Append(", ");
                builder.Append(outputLabel);
                builder.Append('=');
                builder.Append(metric.OutputCount);
                builder.Append(", avg");
                AppendPascalLabel(builder, inputLabel);
                builder.Append('=');
                builder.Append(metric.Calls == 0 ? "0.0" : (metric.InputCount / (double)metric.Calls).ToString("N1"));
                builder.Append(", max");
                AppendPascalLabel(builder, inputLabel);
                builder.Append('=');
                builder.Append(metric.MaxInputCount);
                builder.Append(", max");
                AppendPascalLabel(builder, outputLabel);
                builder.Append('=');
                builder.Append(metric.MaxOutputCount);
            }

            builder.AppendLine();
        }
    }

    private static void AppendSensorUsageTop(
        StringBuilder builder,
        string title,
        Dictionary<int, SensorUsageMetric> metrics)
    {
        if (metrics.Count == 0)
        {
            return;
        }

        List<SensorUsageMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.Count.CompareTo(left.Count));

        builder.Append("    ");
        builder.Append(title);
        builder.AppendLine(":");

        int count = Math.Min(12, sorted.Count);
        for (int i = 0; i < count; i++)
        {
            SensorUsageMetric metric = sorted[i];
            builder.Append("      ");
            builder.Append(GetSensorName(metric.SensorType));
            builder.Append(": ");
            builder.Append(metric.Count);
            builder.AppendLine();
        }
    }

    private static void AppendRelationPrefilterTop(
        StringBuilder builder,
        string title,
        Dictionary<int, RelationPrefilterMetric> metrics)
    {
        if (metrics.Count == 0)
        {
            return;
        }

        List<RelationPrefilterMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.Dropped.CompareTo(left.Dropped));

        builder.Append("    ");
        builder.Append(title);
        builder.AppendLine(":");

        int count = Math.Min(12, sorted.Count);
        for (int i = 0; i < count; i++)
        {
            RelationPrefilterMetric metric = sorted[i];
            builder.Append("      A");
            builder.Append(metric.ActionTemplateId);
            builder.Append(' ');
            builder.Append(GetActionRefName(metric.ActionTemplateId));
            builder.Append(": calls=");
            builder.Append(metric.Calls);
            builder.Append(", selector=");
            builder.Append(metric.Selector);
            builder.Append(", range=");
            builder.Append(metric.Range);
            builder.Append(", rangeValue=");
            builder.Append(metric.RangeValue);
            builder.Append(", selectable=");
            builder.Append(metric.SelectableCount);
            builder.Append(", relationCandidates=");
            builder.Append(metric.RelationCandidateCount);
            builder.Append(", dropped=");
            builder.Append(metric.Dropped);
            builder.Append(", avgSelectable=");
            builder.Append(metric.Calls == 0 ? "0.0" : (metric.SelectableCount / (double)metric.Calls).ToString("N1"));
            builder.Append(", avgRelationCandidates=");
            builder.Append(metric.Calls == 0 ? "0.0" : (metric.RelationCandidateCount / (double)metric.Calls).ToString("N1"));
            builder.Append(", maxSelectable=");
            builder.Append(metric.MaxSelectableCount);
            builder.Append(", maxDropped=");
            builder.Append(metric.MaxDropped);
            builder.AppendLine();
        }
    }

    private static void AppendRelationTargetPrefilterTop(
        StringBuilder builder,
        string title,
        Dictionary<int, RelationTargetPrefilterMetric> metrics)
    {
        if (metrics.Count == 0)
        {
            return;
        }

        List<RelationTargetPrefilterMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.Dropped.CompareTo(left.Dropped));

        builder.Append("    ");
        builder.Append(title);
        builder.AppendLine(":");

        int count = Math.Min(12, sorted.Count);
        for (int i = 0; i < count; i++)
        {
            RelationTargetPrefilterMetric metric = sorted[i];
            builder.Append("      A");
            builder.Append(metric.ActionTemplateId);
            builder.Append(' ');
            builder.Append(GetActionRefName(metric.ActionTemplateId));
            builder.Append(": calls=");
            builder.Append(metric.Calls);
            builder.Append(", selector=");
            builder.Append(metric.Selector);
            builder.Append(", range=");
            builder.Append(metric.Range);
            builder.Append(", rangeValue=");
            builder.Append(metric.RangeValue);
            builder.Append(", input=");
            builder.Append(metric.InputCount);
            builder.Append(", output=");
            builder.Append(metric.OutputCount);
            builder.Append(", dropped=");
            builder.Append(metric.Dropped);
            builder.Append(", zeroOutput=");
            builder.Append(metric.ZeroOutputCount);
            builder.Append(", avgInput=");
            builder.Append(metric.Calls == 0 ? "0.0" : (metric.InputCount / (double)metric.Calls).ToString("N1"));
            builder.Append(", avgOutput=");
            builder.Append(metric.Calls == 0 ? "0.0" : (metric.OutputCount / (double)metric.Calls).ToString("N1"));
            builder.Append(", maxInput=");
            builder.Append(metric.MaxInputCount);
            builder.Append(", maxDropped=");
            builder.Append(metric.MaxDropped);
            builder.AppendLine();
        }
    }

    private static void AppendTargetMatcherCacheTop(
        StringBuilder builder,
        string title,
        Dictionary<int, TargetMatcherCacheMetric> metrics)
    {
        if (metrics.Count == 0)
        {
            return;
        }

        List<TargetMatcherCacheMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.SavedCalls.CompareTo(left.SavedCalls));

        builder.Append("    ");
        builder.Append(title);
        builder.AppendLine(":");

        int count = Math.Min(12, sorted.Count);
        for (int i = 0; i < count; i++)
        {
            TargetMatcherCacheMetric metric = sorted[i];
            builder.Append("      A");
            builder.Append(metric.ActionTemplateId);
            builder.Append(' ');
            builder.Append(GetActionRefName(metric.ActionTemplateId));
            builder.Append(": calls=");
            builder.Append(metric.Calls);
            builder.Append(", hits=");
            builder.Append(metric.Hits);
            builder.Append(", misses=");
            builder.Append(metric.Misses);
            builder.Append(", fallbacks=");
            builder.Append(metric.Fallbacks);
            builder.Append(", savedCalls=");
            builder.Append(metric.SavedCalls);
            builder.Append(", true=");
            builder.Append(metric.TrueCount);
            builder.Append(", false=");
            builder.Append(metric.FalseCount);
            AppendTargetMatcherFallbackReasons(builder, metric);
            builder.Append(", selector=");
            builder.Append(metric.Selector);
            builder.Append(", range=");
            builder.Append(metric.Range);
            builder.Append(", rangeValue=");
            builder.Append(metric.RangeValue);
            builder.AppendLine();
        }
    }

    private static void AppendTargetMatcherFallbackReasons(StringBuilder builder, TargetMatcherCacheMetric metric)
    {
        if (metric.FallbackReasonCounts.Count == 0)
        {
            return;
        }

        List<KeyValuePair<(CharacterTargetMatcherCacheRejectReason Reason, int Detail), int>> sorted =
            new(metric.FallbackReasonCounts);
        sorted.Sort(static (left, right) => right.Value.CompareTo(left.Value));

        builder.Append(", fallbackReasons=");
        int count = Math.Min(5, sorted.Count);
        for (int i = 0; i < count; i++)
        {
            if (i > 0)
            {
                builder.Append('|');
            }

            KeyValuePair<(CharacterTargetMatcherCacheRejectReason Reason, int Detail), int> pair = sorted[i];
            AppendTargetMatcherFallbackReason(builder, pair.Key.Reason, pair.Key.Detail);
            builder.Append('=');
            builder.Append(pair.Value);
        }
    }

    private static void AppendTargetMatcherFallbackReason(
        StringBuilder builder,
        CharacterTargetMatcherCacheRejectReason reason,
        int detail)
    {
        builder.Append(reason);
        string? detailName = reason switch
        {
            CharacterTargetMatcherCacheRejectReason.UnsupportedDisplayGender =>
                Enum.GetName(typeof(ECharacterMatcherGenderType), detail),
            CharacterTargetMatcherCacheRejectReason.UnsupportedSubCondition =>
                Enum.GetName(typeof(ECharacterMatcherSubCondition), detail),
            CharacterTargetMatcherCacheRejectReason.UnsupportedMerchantType =>
                detail.ToString(),
            _ => null,
        };

        if (!string.IsNullOrEmpty(detailName))
        {
            builder.Append('(');
            builder.Append(detailName);
            builder.Append(')');
        }
    }

    private static void AppendRelationConditionTop(
        StringBuilder builder,
        string title,
        Dictionary<int, RelationConditionMetric> metrics)
    {
        if (metrics.Count == 0)
        {
            return;
        }

        List<RelationConditionMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.RelationFailCount.CompareTo(left.RelationFailCount));

        builder.Append("    ");
        builder.Append(title);
        builder.AppendLine(":");

        int count = Math.Min(12, sorted.Count);
        for (int i = 0; i < count; i++)
        {
            RelationConditionMetric metric = sorted[i];
            builder.Append("      G");
            builder.Append(metric.TemplateId);
            builder.Append(' ');
            builder.Append(GetGoalRefName(metric.TemplateId));
            AppendRelationConditionMetric(builder, metric);
        }
    }

    private static void AppendRelationConditionTop(
        StringBuilder builder,
        string title,
        Dictionary<int, ActionRelationConditionMetric> metrics)
    {
        if (metrics.Count == 0)
        {
            return;
        }

        List<ActionRelationConditionMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.RelationFailCount.CompareTo(left.RelationFailCount));

        builder.Append("    ");
        builder.Append(title);
        builder.AppendLine(":");

        int count = Math.Min(12, sorted.Count);
        for (int i = 0; i < count; i++)
        {
            ActionRelationConditionMetric metric = sorted[i];
            builder.Append("      A");
            builder.Append(metric.ActionTemplateId);
            builder.Append(' ');
            builder.Append(GetActionRefName(metric.ActionTemplateId));
            builder.Append(": selector=");
            builder.Append(metric.Selector);
            builder.Append(", range=");
            builder.Append(metric.Range);
            builder.Append(", rangeValue=");
            builder.Append(metric.RangeValue);
            AppendRelationConditionMetric(builder, metric);
        }
    }

    private static void AppendRelationConditionMetric(StringBuilder builder, RelationConditionMetric metric)
    {
        builder.Append(": calls=");
        builder.Append(metric.Calls);
        builder.Append(", relationConditions=");
        builder.Append(metric.RelationConditionCount);
        builder.Append(", relationPass=");
        builder.Append(metric.RelationPassCount);
        builder.Append(", relationFail=");
        builder.Append(metric.RelationFailCount);
        builder.Append(", fullTrue=");
        builder.Append(metric.FullSuccessCount);
        builder.Append(", fullFalse=");
        builder.Append(metric.FullFailureCount);
        builder.Append(", avgRelationConditions=");
        builder.Append(metric.Calls == 0 ? "0.0" : (metric.RelationConditionCount / (double)metric.Calls).ToString("N1"));
        builder.AppendLine();
    }

    private static void AppendResultCounts(StringBuilder builder, int successCount, int failureCount)
    {
        if (successCount <= 0 && failureCount <= 0)
        {
            return;
        }

        builder.Append(", true=");
        builder.Append(successCount);
        builder.Append(", false=");
        builder.Append(failureCount);
    }

    private static void AppendPascalLabel(StringBuilder builder, string label)
    {
        if (label.Length == 0)
        {
            return;
        }

        builder.Append(char.ToUpperInvariant(label[0]));
        if (label.Length > 1)
        {
            builder.Append(label.AsSpan(1));
        }
    }

    private static string GetActionRefName(int actionTemplateId)
    {
        try
        {
            return PlanningAction.Instance.GetRefName(actionTemplateId);
        }
        catch
        {
            return "<unknown>";
        }
    }

    private static string GetGoalRefName(int goalTemplateId)
    {
        try
        {
            return PlanningGoal.Instance.GetRefName(goalTemplateId);
        }
        catch
        {
            return "<unknown>";
        }
    }

    private static string GetSensorName(int sensorType) =>
        Enum.GetName(typeof(EPlanningStateSensorType), sensorType) ?? sensorType.ToString();

    private static void AppendMetric(StringBuilder builder, string name, string value)
    {
        builder.Append("    ");
        builder.Append(name);
        builder.Append(": ");
        builder.Append(value);
        builder.AppendLine();
    }

    private static void AppendMetric(StringBuilder builder, string name, int value)
    {
        builder.Append("    ");
        builder.Append(name);
        builder.Append(": ");
        builder.Append(value);
        builder.AppendLine();
    }

    private static string FormatMilliseconds(long ticks) =>
        (ticks * 1000.0 / Stopwatch.Frequency).ToString("N3") + "ms";

    private static Metric[] CreateMetricArray<TEnum>() where TEnum : Enum
    {
        Array values = Enum.GetValues(typeof(TEnum));
        Metric[] metrics = new Metric[values.Length];
        for (int i = 0; i < metrics.Length; i++)
        {
            metrics[i] = new Metric();
        }

        return metrics;
    }

    private static TargetLookupMetric[] CreateTargetLookupMetricArray()
    {
        Array values = Enum.GetValues(typeof(CharacterActionTargetLookupKind));
        TargetLookupMetric[] metrics = new TargetLookupMetric[values.Length];
        for (int i = 0; i < metrics.Length; i++)
        {
            metrics[i] = new TargetLookupMetric();
        }

        return metrics;
    }

    private static SkipMetric[] CreateSkipMetricArray()
    {
        Array values = Enum.GetValues(typeof(CharacterRelationTargetPrefilterSkipReason));
        SkipMetric[] metrics = new SkipMetric[values.Length];
        for (int i = 0; i < metrics.Length; i++)
        {
            metrics[i] = new SkipMetric();
        }

        return metrics;
    }

    private static void ClearMetrics()
    {
        ClearMetrics(ParallelStages);
        PrimaryMetrics.Clear();
        SecondaryMetrics.Clear();
        foreach (TargetLookupMetric metric in TargetLookupMetrics)
        {
            metric.Clear();
        }

        foreach (SkipMetric metric in RelationTargetPrefilterSkips)
        {
            metric.Clear();
        }

        RelationTargetPrefilterExceptions.Clear();
    }

    private static void ClearMetrics(Metric[] metrics)
    {
        foreach (Metric metric in metrics)
        {
            metric.Clear();
        }
    }

    private sealed class GoalMetrics
    {
        public readonly Metric[] Steps = CreateMetricArray<CharacterActionPlanningStep>();
        public readonly Dictionary<int, ActionMetric> PrepareContextByAction = new(128);
        public readonly Dictionary<int, ActionMetric> FilterTargetsByAction = new(128);
        public readonly Dictionary<int, TemplateMetric> GoalTargetMatchByGoal = new(64);
        public readonly Dictionary<int, ActionMetric> ActionTargetMatchByAction = new(128);
        public readonly Dictionary<int, TemplateMetric> TargetConditionsByGoal = new(64);
        public readonly Dictionary<int, ActionMetric> TargetConditionsByAction = new(128);
        public readonly Dictionary<int, RelationTargetPrefilterMetric> RelationTargetPrefilterByAction = new(128);
        public readonly Dictionary<int, RelationPrefilterMetric> RelationPrefilterByAction = new(128);
        public readonly Dictionary<int, TargetMatcherCacheMetric> TargetMatcherCacheByAction = new(128);
        public readonly Dictionary<int, RelationConditionMetric> RelationConditionsByGoal = new(64);
        public readonly Dictionary<int, ActionRelationConditionMetric> RelationConditionsByAction = new(128);
        public readonly Dictionary<int, SensorUsageMetric> TargetConditionSensors = new(16);

        public void Clear()
        {
            ClearMetrics(Steps);
            PrepareContextByAction.Clear();
            FilterTargetsByAction.Clear();
            GoalTargetMatchByGoal.Clear();
            ActionTargetMatchByAction.Clear();
            TargetConditionsByGoal.Clear();
            TargetConditionsByAction.Clear();
            RelationTargetPrefilterByAction.Clear();
            RelationPrefilterByAction.Clear();
            TargetMatcherCacheByAction.Clear();
            RelationConditionsByGoal.Clear();
            RelationConditionsByAction.Clear();
            TargetConditionSensors.Clear();
        }
    }

    private sealed class Metric
    {
        public int Calls;
        public long Ticks;
        public long MaxTicks;
        public long InputCount;
        public long OutputCount;
        public int MaxInputCount;
        public int MaxOutputCount;
        public int SuccessCount;
        public int FailureCount;

        public void Clear()
        {
            Calls = 0;
            Ticks = 0;
            MaxTicks = 0;
            InputCount = 0;
            OutputCount = 0;
            MaxInputCount = 0;
            MaxOutputCount = 0;
            SuccessCount = 0;
            FailureCount = 0;
        }
    }

    private sealed class TargetLookupMetric
    {
        public int Calls;
        public int Hits;
        public int Fallbacks;
        public long CandidateIds;
        public long CharactersAdded;

        public void Clear()
        {
            Calls = 0;
            Hits = 0;
            Fallbacks = 0;
            CandidateIds = 0;
            CharactersAdded = 0;
        }
    }

    private sealed class SkipMetric
    {
        public int Count;

        public void Clear()
        {
            Count = 0;
        }
    }

    private sealed class ExceptionMetric
    {
        public readonly Type ExceptionType;
        public readonly string FirstMessage;
        public int Count;

        public ExceptionMetric(Type exceptionType, string firstMessage)
        {
            ExceptionType = exceptionType;
            FirstMessage = firstMessage;
        }
    }

    private sealed class ActionMetric
    {
        public readonly int ActionTemplateId;
        public readonly EPlanningActionCharacterSelector Selector;
        public readonly EPlanningActionCharacterSelectRange Range;
        public readonly int RangeValue;
        public int Calls;
        public long Ticks;
        public long MaxTicks;
        public long InputCount;
        public long OutputCount;
        public int MaxInputCount;
        public int MaxOutputCount;
        public int SuccessCount;
        public int FailureCount;

        public ActionMetric(
            int actionTemplateId,
            EPlanningActionCharacterSelector selector,
            EPlanningActionCharacterSelectRange range,
            int rangeValue)
        {
            ActionTemplateId = actionTemplateId;
            Selector = selector;
            Range = range;
            RangeValue = rangeValue;
        }

        public void Add(long ticks, int inputCount, int outputCount, bool? result)
        {
            Calls++;
            Ticks += ticks;
            if (ticks > MaxTicks)
            {
                MaxTicks = ticks;
            }

            if (inputCount > 0)
            {
                InputCount += inputCount;
                if (inputCount > MaxInputCount)
                {
                    MaxInputCount = inputCount;
                }
            }

            if (outputCount > 0)
            {
                OutputCount += outputCount;
                if (outputCount > MaxOutputCount)
                {
                    MaxOutputCount = outputCount;
                }
            }

            if (result.HasValue)
            {
                if (result.Value)
                {
                    SuccessCount++;
                }
                else
                {
                    FailureCount++;
                }
            }
        }
    }

    private sealed class TemplateMetric
    {
        public readonly int TemplateId;
        public int Calls;
        public long Ticks;
        public long MaxTicks;
        public long InputCount;
        public long OutputCount;
        public int MaxInputCount;
        public int MaxOutputCount;
        public int SuccessCount;
        public int FailureCount;

        public TemplateMetric(int templateId)
        {
            TemplateId = templateId;
        }

        public void Add(long ticks, int inputCount, int outputCount, bool result)
        {
            Calls++;
            Ticks += ticks;
            if (ticks > MaxTicks)
            {
                MaxTicks = ticks;
            }

            if (inputCount > 0)
            {
                InputCount += inputCount;
                if (inputCount > MaxInputCount)
                {
                    MaxInputCount = inputCount;
                }
            }

            if (outputCount > 0)
            {
                OutputCount += outputCount;
                if (outputCount > MaxOutputCount)
                {
                    MaxOutputCount = outputCount;
                }
            }

            if (result)
            {
                SuccessCount++;
            }
            else
            {
                FailureCount++;
            }
        }
    }

    private sealed class RelationPrefilterMetric
    {
        public readonly int ActionTemplateId;
        public readonly EPlanningActionCharacterSelector Selector;
        public readonly EPlanningActionCharacterSelectRange Range;
        public readonly int RangeValue;
        public int Calls;
        public long SelectableCount;
        public long RelationCandidateCount;
        public int MaxSelectableCount;
        public int MaxDropped;

        public long Dropped => SelectableCount - RelationCandidateCount;

        public RelationPrefilterMetric(
            int actionTemplateId,
            EPlanningActionCharacterSelector selector,
            EPlanningActionCharacterSelectRange range,
            int rangeValue)
        {
            ActionTemplateId = actionTemplateId;
            Selector = selector;
            Range = range;
            RangeValue = rangeValue;
        }

        public void Add(int selectableCount, int relationCandidateCount)
        {
            Calls++;
            SelectableCount += selectableCount;
            RelationCandidateCount += relationCandidateCount;
            if (selectableCount > MaxSelectableCount)
            {
                MaxSelectableCount = selectableCount;
            }

            int dropped = selectableCount - relationCandidateCount;
            if (dropped > MaxDropped)
            {
                MaxDropped = dropped;
            }
        }
    }

    private sealed class RelationTargetPrefilterMetric
    {
        public readonly int ActionTemplateId;
        public readonly EPlanningActionCharacterSelector Selector;
        public readonly EPlanningActionCharacterSelectRange Range;
        public readonly int RangeValue;
        public int Calls;
        public long InputCount;
        public long OutputCount;
        public int MaxInputCount;
        public int MaxDropped;
        public int ZeroOutputCount;

        public long Dropped => InputCount - OutputCount;

        public RelationTargetPrefilterMetric(
            int actionTemplateId,
            EPlanningActionCharacterSelector selector,
            EPlanningActionCharacterSelectRange range,
            int rangeValue)
        {
            ActionTemplateId = actionTemplateId;
            Selector = selector;
            Range = range;
            RangeValue = rangeValue;
        }

        public void Add(int inputCount, int outputCount)
        {
            Calls++;
            InputCount += inputCount;
            OutputCount += outputCount;
            if (inputCount > MaxInputCount)
            {
                MaxInputCount = inputCount;
            }

            int dropped = inputCount - outputCount;
            if (dropped > MaxDropped)
            {
                MaxDropped = dropped;
            }

            if (outputCount == 0)
            {
                ZeroOutputCount++;
            }
        }
    }

    private sealed class TargetMatcherCacheMetric
    {
        public readonly int ActionTemplateId;
        public readonly EPlanningActionCharacterSelector Selector;
        public readonly EPlanningActionCharacterSelectRange Range;
        public readonly int RangeValue;
        public int Calls;
        public int Hits;
        public int Misses;
        public int Fallbacks;
        public int TrueCount;
        public int FalseCount;
        public readonly Dictionary<(CharacterTargetMatcherCacheRejectReason Reason, int Detail), int> FallbackReasonCounts = new(4);

        public int SavedCalls => Hits;

        public TargetMatcherCacheMetric(
            int actionTemplateId,
            EPlanningActionCharacterSelector selector,
            EPlanningActionCharacterSelectRange range,
            int rangeValue)
        {
            ActionTemplateId = actionTemplateId;
            Selector = selector;
            Range = range;
            RangeValue = rangeValue;
        }

        public void Add(
            bool hit,
            bool miss,
            bool fallback,
            bool result,
            CharacterTargetMatcherCacheRejectReason rejectReason,
            int rejectDetail)
        {
            Calls++;
            if (hit)
            {
                Hits++;
            }

            if (miss)
            {
                Misses++;
            }

            if (fallback)
            {
                Fallbacks++;
                if (rejectReason != CharacterTargetMatcherCacheRejectReason.None)
                {
                    var key = (rejectReason, rejectDetail);
                    FallbackReasonCounts.TryGetValue(key, out int count);
                    FallbackReasonCounts[key] = count + 1;
                }
            }

            if (result)
            {
                TrueCount++;
            }
            else
            {
                FalseCount++;
            }
        }
    }

    private class RelationConditionMetric
    {
        public readonly int TemplateId;
        public int Calls;
        public long RelationConditionCount;
        public int RelationPassCount;
        public int RelationFailCount;
        public int FullSuccessCount;
        public int FullFailureCount;

        public RelationConditionMetric(int templateId)
        {
            TemplateId = templateId;
        }

        public void Add(int relationConditionCount, bool relationConditionsPassed, bool fullResult)
        {
            Calls++;
            RelationConditionCount += relationConditionCount;
            if (relationConditionsPassed)
            {
                RelationPassCount++;
            }
            else
            {
                RelationFailCount++;
            }

            if (fullResult)
            {
                FullSuccessCount++;
            }
            else
            {
                FullFailureCount++;
            }
        }
    }

    private sealed class ActionRelationConditionMetric : RelationConditionMetric
    {
        public readonly int ActionTemplateId;
        public readonly EPlanningActionCharacterSelector Selector;
        public readonly EPlanningActionCharacterSelectRange Range;
        public readonly int RangeValue;

        public ActionRelationConditionMetric(
            int actionTemplateId,
            EPlanningActionCharacterSelector selector,
            EPlanningActionCharacterSelectRange range,
            int rangeValue)
            : base(actionTemplateId)
        {
            ActionTemplateId = actionTemplateId;
            Selector = selector;
            Range = range;
            RangeValue = rangeValue;
        }
    }

    private sealed class SensorUsageMetric
    {
        public readonly int SensorType;
        public int Count;

        public SensorUsageMetric(int sensorType)
        {
            SensorType = sensorType;
        }
    }

    private struct Session
    {
        public long StartTicks;
        public long TargetLookupBuildTicks;
        public int TargetLookupBuildCalls;
        public int TargetLookupBlockCount;
        public int TargetLookupAreaCount;
        public int TargetLookupStateCount;
        public int TargetLookupCharacterIdCount;
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.State;
using GameData.Domains;
using Character = GameData.Domains.Character.Character;

namespace TaiwuDiagnostics.Runtime;

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

internal enum CharacterTargetMatchScopeKind
{
    None,
    Goal,
    Action,
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

internal readonly struct ParallelActionInvocationState
{
    public readonly long StartTicks;
    public readonly string ActionTypeName;
    public readonly string MethodName;
    public readonly string? PreviousActionType;

    public ParallelActionInvocationState(
        long startTicks,
        string actionTypeName,
        string methodName,
        string? previousActionType)
    {
        StartTicks = startTicks;
        ActionTypeName = actionTypeName;
        MethodName = methodName;
        PreviousActionType = previousActionType;
    }
}

internal readonly struct CharacterMonthlyMethodState
{
    public readonly long StartTicks;
    public readonly string ActionTypeName;
    public readonly string MethodName;

    public CharacterMonthlyMethodState(long startTicks, string actionTypeName, string methodName)
    {
        StartTicks = startTicks;
        ActionTypeName = actionTypeName;
        MethodName = methodName;
    }
}

internal readonly struct CharacterMonthlyMethodKey : IEquatable<CharacterMonthlyMethodKey>
{
    public readonly string ActionTypeName;
    public readonly string MethodName;

    public CharacterMonthlyMethodKey(string actionTypeName, string methodName)
    {
        ActionTypeName = actionTypeName;
        MethodName = methodName;
    }

    public bool Equals(CharacterMonthlyMethodKey other) =>
        string.Equals(ActionTypeName, other.ActionTypeName, StringComparison.Ordinal) &&
        string.Equals(MethodName, other.MethodName, StringComparison.Ordinal);

    public override bool Equals(object? obj) =>
        obj is CharacterMonthlyMethodKey other && Equals(other);

    public override int GetHashCode() =>
        HashCode.Combine(
            StringComparer.Ordinal.GetHashCode(ActionTypeName),
            StringComparer.Ordinal.GetHashCode(MethodName));
}

internal static class CharacterActionPlanningDiagnostics
{
    private static readonly object SyncRoot = new();
    private static readonly Metric[] ParallelStages = CreateMetricArray<CharacterActionPlanningParallelStage>();
    private static readonly Dictionary<string, Metric> ParallelActionTypes = new(16, StringComparer.Ordinal);
    private static readonly Dictionary<string, Metric> ParallelActionInvocations = new(32, StringComparer.Ordinal);
    private static readonly Dictionary<CharacterMonthlyMethodKey, Metric> CharacterMonthlyMethods = new(64);
    private static readonly GoalMetrics PrimaryMetrics = new();
    private static readonly GoalMetrics SecondaryMetrics = new();
    private static readonly Dictionary<ObservedMatcherKey, bool> ObservedTargetMatcherCache = new(4096);
    private static long _startTicks;
    private static long _planningStageStartTicks;
    private static long _planningStageTicks;
    private static int _advanceMonthExecuteDepth;

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

    [ThreadStatic]
    private static string? _currentParallelActionType;

    public static void BeginAdvanceMonth()
    {
        if (!TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics)
        {
            return;
        }

        lock (SyncRoot)
        {
            _startTicks = Stopwatch.GetTimestamp();
            ClearMetrics();
        }
    }

    public static void EndAdvanceMonth()
    {
        long startTicks;
        lock (SyncRoot)
        {
            startTicks = _startTicks;
        }

        if (startTicks == 0)
        {
            return;
        }

        lock (SyncRoot)
        {
            if (_startTicks == 0)
            {
                return;
            }

            EndCharacterActionPlanningStageNoLock();
            long totalTicks = Stopwatch.GetTimestamp() - _startTicks;
            string legacyText = BuildMessage(totalTicks);
            TaiwuDiagnosticsExporter.Publish(
                "diagnostics.character_action_planning",
                BuildPayload(totalTicks, legacyText));
            _startTicks = 0;
            ClearMetrics();
        }
    }

    public static void BeginCharacterActionPlanningStage()
    {
        if (!IsActive())
        {
            return;
        }

        lock (SyncRoot)
        {
            if (_advanceMonthExecuteDepth <= 0)
            {
                return;
            }

            if (_planningStageStartTicks == 0)
            {
                _planningStageStartTicks = Stopwatch.GetTimestamp();
            }
        }
    }

    public static void EndCharacterActionPlanningStage()
    {
        lock (SyncRoot)
        {
            EndCharacterActionPlanningStageNoLock();
        }
    }

    public static void BeginAdvanceMonthExecute()
    {
        if (!IsActive())
        {
            return;
        }

        lock (SyncRoot)
        {
            _advanceMonthExecuteDepth++;
        }
    }

    public static void EndAdvanceMonthExecute()
    {
        lock (SyncRoot)
        {
            EndCharacterActionPlanningStageNoLock();
            if (_advanceMonthExecuteDepth > 0)
            {
                _advanceMonthExecuteDepth--;
            }
        }
    }

    public static long BeginOfflineUpdateCurrentGoalActions(ActionPlanningData.ECurrentGoalType goalType)
    {
        if (!IsActive())
        {
            return 0;
        }

        _goalType = goalType;
        _goalScopeDepth++;
        return Stopwatch.GetTimestamp();
    }

    public static void EndOfflineUpdateCurrentGoalActions(ActionPlanningData.ECurrentGoalType goalType, long startTicks)
    {
        EndGoalStep(goalType, CharacterActionPlanningStep.OfflineUpdateCurrentGoalActions, startTicks);
        LeaveGoalScope();
    }

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

    public static void EndComplementCurrentGoalActions(ActionPlanningData.ECurrentGoalType goalType, long startTicks)
    {
        EndGoalStep(goalType, CharacterActionPlanningStep.ComplementUpdateCurrentGoalActions, startTicks);
        LeaveGoalScope();
    }

    public static long BeginGoalStep() =>
        IsActive() && _goalScopeDepth > 0 ? Stopwatch.GetTimestamp() : 0;

    public static void EndGoalStep(CharacterActionPlanningStep step, long startTicks) =>
        EndGoalStep(_goalType, step, startTicks);

    public static long BeginParallelStage(CharacterActionPlanningParallelStage stage)
    {
        _ = stage;
        return IsActive() ? Stopwatch.GetTimestamp() : 0;
    }

    public static void EndParallelStage(CharacterActionPlanningParallelStage stage, long startTicks)
    {
        if (startTicks != 0)
        {
            AddMetric(ParallelStages[(int)stage], Stopwatch.GetTimestamp() - startTicks);
        }
    }

    public static long BeginParallelAction(string actionTypeName) =>
        IsActive() && !string.IsNullOrEmpty(actionTypeName) ? Stopwatch.GetTimestamp() : 0;

    public static void EndParallelAction(string actionTypeName, long startTicks)
    {
        if (startTicks == 0 || string.IsNullOrEmpty(actionTypeName))
        {
            return;
        }

        lock (SyncRoot)
        {
            if (!ParallelActionTypes.TryGetValue(actionTypeName, out Metric? metric))
            {
                metric = new Metric();
                ParallelActionTypes.Add(actionTypeName, metric);
            }

            AddMetricNoLock(metric, Stopwatch.GetTimestamp() - startTicks);
        }
    }

    public static ParallelActionInvocationState BeginParallelActionInvocation(string actionTypeName, string methodName)
    {
        if (!IsActive())
        {
            return default;
        }

        string? previousActionType = _currentParallelActionType;
        _currentParallelActionType = actionTypeName;
        return new ParallelActionInvocationState(
            Stopwatch.GetTimestamp(),
            actionTypeName,
            methodName,
            previousActionType);
    }

    public static void EndParallelActionInvocation(ParallelActionInvocationState state)
    {
        if (state.StartTicks == 0)
        {
            return;
        }

        _currentParallelActionType = state.PreviousActionType;
        string key = state.ActionTypeName + "." + state.MethodName;
        lock (SyncRoot)
        {
            if (!ParallelActionInvocations.TryGetValue(key, out Metric? metric))
            {
                metric = new Metric();
                ParallelActionInvocations.Add(key, metric);
            }

            AddMetricNoLock(metric, Stopwatch.GetTimestamp() - state.StartTicks);
        }
    }

    public static CharacterMonthlyMethodState BeginCharacterMonthlyMethod(string methodName)
    {
        if (!IsActive())
        {
            return default;
        }

        return new CharacterMonthlyMethodState(
            Stopwatch.GetTimestamp(),
            _currentParallelActionType ?? string.Empty,
            methodName);
    }

    public static void EndCharacterMonthlyMethod(CharacterMonthlyMethodState state)
    {
        if (state.StartTicks == 0)
        {
            return;
        }

        CharacterMonthlyMethodKey key = new(state.ActionTypeName, state.MethodName);
        lock (SyncRoot)
        {
            if (!CharacterMonthlyMethods.TryGetValue(key, out Metric? metric))
            {
                metric = new Metric();
                CharacterMonthlyMethods.Add(key, metric);
            }

            AddMetricNoLock(metric, Stopwatch.GetTimestamp() - state.StartTicks);
        }
    }

    public static void EndGetCharactersInSelectRange(long startTicks, int candidateCount)
    {
        if (startTicks != 0)
        {
            AddGoalMetricExtra(CharacterActionPlanningStep.GetCharactersInSelectRange, startTicks, candidateCount, 0);
        }
    }

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
        GoalMetrics metrics = GetGoalMetrics();
        AddMetric(metrics.Steps[(int)CharacterActionPlanningStep.FilterActionTargets], ticks, selectableCount, resultCount);
        AddActionMetric(metrics.FilterTargetsByAction, actionTemplateId, selector, range, rangeValue, ticks, selectableCount, resultCount);
    }

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
            if (targetChar != null && DomainManager.Character.TryGetRelation(selfCharId, targetChar.GetId(), out var _))
            {
                relationCandidateCount++;
            }
        }

        GoalMetrics metrics = GetGoalMetrics();
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
        GoalMetrics metrics = GetGoalMetrics();
        AddMetric(metrics.Steps[(int)CharacterActionPlanningStep.PrepareContext], ticks);
        AddActionMetric(metrics.PrepareContextByAction, actionTemplateId, selector, range, rangeValue, ticks, 0, 0);
    }

    public static TargetMatchDiagnosticsState BeginGoalTargetMatch(int goalTemplateId, int actionTemplateId)
    {
        if (!IsActive() || _goalScopeDepth <= 0)
        {
            return default;
        }

        TargetMatchDiagnosticsState state = new(
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

    public static void EndGoalTargetMatch(TargetMatchDiagnosticsState state, bool result)
    {
        if (state.StartTicks == 0)
        {
            return;
        }

        AddTemplateMetric(
            GetGoalMetrics().GoalTargetMatchByGoal,
            state.GoalTemplateId,
            Stopwatch.GetTimestamp() - state.StartTicks,
            result,
            0,
            0);
        RestoreTargetMatchScope(state);
    }

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

        TargetMatchDiagnosticsState state = new(
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

    public static void EndActionTargetMatch(TargetMatchDiagnosticsState state, bool result)
    {
        if (state.StartTicks == 0)
        {
            return;
        }

        AddActionMetric(
            GetGoalMetrics().ActionTargetMatchByAction,
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
        GoalMetrics metrics = GetGoalMetrics();
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
            RecordObservedTargetMatcherCache(metrics, state, conditions, targetChar, result);
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
    }

    public static bool IsRecording => IsActive();

    private static bool IsActive() =>
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics && _startTicks != 0;

    private static void EndGoalStep(
        ActionPlanningData.ECurrentGoalType goalType,
        CharacterActionPlanningStep step,
        long startTicks)
    {
        if (startTicks != 0)
        {
            GoalMetrics metrics = goalType == ActionPlanningData.ECurrentGoalType.Primary ? PrimaryMetrics : SecondaryMetrics;
            AddMetric(metrics.Steps[(int)step], Stopwatch.GetTimestamp() - startTicks);
        }
    }

    private static void AddGoalMetricExtra(
        CharacterActionPlanningStep step,
        long startTicks,
        int inputCount,
        int outputCount)
    {
        AddMetric(GetGoalMetrics().Steps[(int)step], Stopwatch.GetTimestamp() - startTicks, inputCount, outputCount);
    }

    private static void AddMetric(Metric metric, long ticks, int inputCount = 0, int outputCount = 0)
    {
        lock (SyncRoot)
        {
            AddMetricNoLock(metric, ticks, inputCount, outputCount);
        }
    }

    private static void AddMetricNoLock(Metric metric, long ticks, int inputCount = 0, int outputCount = 0)
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
            metric.MaxInputCount = Math.Max(metric.MaxInputCount, inputCount);
        }

        if (outputCount > 0)
        {
            metric.OutputCount += outputCount;
            metric.MaxOutputCount = Math.Max(metric.MaxOutputCount, outputCount);
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

    private static void RecordObservedTargetMatcherCache(
        GoalMetrics metrics,
        TargetConditionDiagnosticsState state,
        StateConditionAndValue<StateKey>[]? conditions,
        Character targetChar,
        bool result)
    {
        if (targetChar == null || state.ActionTemplateId < 0)
        {
            return;
        }

        ObservedMatcherKey key = new(
            (int)_goalType,
            state.ActionTemplateId,
            targetChar.GetId(),
            conditions == null ? 0 : RuntimeHelpers.GetHashCode(conditions),
            conditions?.Length ?? state.ConditionCount,
            (int)state.Selector,
            (int)state.Range,
            state.RangeValue);

        lock (SyncRoot)
        {
            bool hit = ObservedTargetMatcherCache.ContainsKey(key);
            if (!hit)
            {
                ObservedTargetMatcherCache[key] = result;
            }

            if (!metrics.TargetMatcherCacheByAction.TryGetValue(state.ActionTemplateId, out TargetMatcherCacheMetric? metric))
            {
                metric = new TargetMatcherCacheMetric(
                    state.ActionTemplateId,
                    state.Selector,
                    state.Range,
                    state.RangeValue);
                metrics.TargetMatcherCacheByAction.Add(state.ActionTemplateId, metric);
            }

            metric.Add(hit, !hit, result);
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

    private static GoalMetrics GetGoalMetrics() =>
        _goalType == ActionPlanningData.ECurrentGoalType.Primary ? PrimaryMetrics : SecondaryMetrics;

    private static string BuildMessage(long totalTicks)
    {
        StringBuilder builder = new(4096);
        builder.AppendLine("TaiwuDiagnostics: 过月 NPC 行动规划诊断");
        AppendTextMetric(builder, "总耗时", FormatMilliseconds(totalTicks));
        AppendTextMetric(builder, "诊断缓存候选", ObservedTargetMatcherCache.Count);
        AppendTextGoal(builder, "主目标行动", PrimaryMetrics);
        AppendTextGoal(builder, "副目标行动", SecondaryMetrics);
        return builder.ToString();
    }

    private static object BuildPayload(long totalTicks, string legacyText) =>
        new
        {
            probe = "character_action_planning",
            probeVersion = 2,
            scope = "advance_month_with_character_action_planning_window",
            elapsedMs = ToMilliseconds(totalTicks),
            characterActionPlanningStage = new
            {
                captured = _planningStageTicks > 0,
                elapsedMs = ToMilliseconds(_planningStageTicks),
                note = "此耗时窗口由 WorldDomain.SetAndNotifyAdvancingMonthState(8 -> 11) 捕获，对应游戏日志中的 [AdvanceMonth_Execute] CharacterActionPlanning。",
            },
            diagnosticCache = new
            {
                observedTargetMatcherKeys = ObservedTargetMatcherCache.Count,
                note = "诊断缓存只统计重复目标条件匹配机会，不改变原版返回值。",
            },
            parallelStages = BuildParallelStagePayloads(),
            parallelActionTypes = BuildParallelActionTypePayloads(),
            parallelActionInvocations = BuildParallelActionInvocationPayloads(),
            characterMonthlyMethods = BuildCharacterMonthlyMethodPayloads(),
            primaryGoalActions = BuildGoalPayload(PrimaryMetrics),
            secondaryGoalActions = BuildGoalPayload(SecondaryMetrics),
            legacyText,
        };

    private static object BuildGoalPayload(GoalMetrics metrics) =>
        new
        {
            steps = BuildStepPayloads(metrics),
            top = new
            {
                prepareContextByAction = BuildActionTop(metrics.PrepareContextByAction),
                filterTargetsByAction = BuildActionTop(metrics.FilterTargetsByAction),
                goalTargetMatchByGoal = BuildTemplateTop(metrics.GoalTargetMatchByGoal),
                actionTargetMatchByAction = BuildActionTop(metrics.ActionTargetMatchByAction),
                targetConditionsByGoal = BuildTemplateTop(metrics.TargetConditionsByGoal),
                targetConditionsByAction = BuildActionTop(metrics.TargetConditionsByAction),
                relationPrefilterByAction = BuildRelationPrefilterTop(metrics.RelationPrefilterByAction),
                targetMatcherCacheByAction = BuildCacheTop(metrics.TargetMatcherCacheByAction),
                targetConditionSensors = BuildSensorTop(metrics.TargetConditionSensors),
            },
            topCounts = new
            {
                prepareContextByAction = metrics.PrepareContextByAction.Count,
                filterTargetsByAction = metrics.FilterTargetsByAction.Count,
                goalTargetMatchByGoal = metrics.GoalTargetMatchByGoal.Count,
                actionTargetMatchByAction = metrics.ActionTargetMatchByAction.Count,
                targetConditionsByGoal = metrics.TargetConditionsByGoal.Count,
                targetConditionsByAction = metrics.TargetConditionsByAction.Count,
                relationPrefilterByAction = metrics.RelationPrefilterByAction.Count,
                targetMatcherCacheByAction = metrics.TargetMatcherCacheByAction.Count,
                targetConditionSensors = metrics.TargetConditionSensors.Count,
            },
        };

    private static List<object> BuildParallelStagePayloads()
    {
        Array values = Enum.GetValues(typeof(CharacterActionPlanningParallelStage));
        List<object> result = new(values.Length);
        foreach (CharacterActionPlanningParallelStage value in values)
        {
            result.Add(MetricPayload(value.ToString(), ParallelStages[(int)value]));
        }

        return result;
    }

    private static List<object> BuildParallelActionTypePayloads()
    {
        List<KeyValuePair<string, Metric>> sorted = new(ParallelActionTypes);
        sorted.Sort(static (left, right) => right.Value.Ticks.CompareTo(left.Value.Ticks));
        List<object> result = new(Math.Min(24, sorted.Count));
        for (int i = 0; i < sorted.Count && i < 24; i++)
        {
            KeyValuePair<string, Metric> pair = sorted[i];
            result.Add(MetricPayload(pair.Key, pair.Value));
        }

        return result;
    }

    private static List<object> BuildParallelActionInvocationPayloads()
    {
        List<KeyValuePair<string, Metric>> sorted = new(ParallelActionInvocations);
        sorted.Sort(static (left, right) => right.Value.Ticks.CompareTo(left.Value.Ticks));
        List<object> result = new(Math.Min(40, sorted.Count));
        for (int i = 0; i < sorted.Count && i < 40; i++)
        {
            KeyValuePair<string, Metric> pair = sorted[i];
            result.Add(MetricPayload(pair.Key, pair.Value));
        }

        return result;
    }

    private static List<object> BuildCharacterMonthlyMethodPayloads()
    {
        List<KeyValuePair<CharacterMonthlyMethodKey, Metric>> sorted = new(CharacterMonthlyMethods);
        sorted.Sort(static (left, right) => right.Value.Ticks.CompareTo(left.Value.Ticks));
        List<object> result = new(Math.Min(48, sorted.Count));
        for (int i = 0; i < sorted.Count && i < 48; i++)
        {
            KeyValuePair<CharacterMonthlyMethodKey, Metric> pair = sorted[i];
            result.Add(new
            {
                actionType = string.IsNullOrEmpty(pair.Key.ActionTypeName) ? null : pair.Key.ActionTypeName,
                name = pair.Key.MethodName,
                calls = pair.Value.Calls,
                elapsedMs = ToMilliseconds(pair.Value.Ticks),
                maxMs = ToMilliseconds(pair.Value.MaxTicks),
            });
        }

        return result;
    }

    private static List<object> BuildStepPayloads(GoalMetrics metrics)
    {
        Array values = Enum.GetValues(typeof(CharacterActionPlanningStep));
        List<object> result = new(values.Length);
        foreach (CharacterActionPlanningStep value in values)
        {
            result.Add(MetricPayload(value.ToString(), metrics.Steps[(int)value]));
        }

        return result;
    }

    private static List<object> BuildActionTop(Dictionary<int, ActionMetric> metrics)
    {
        List<ActionMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.Ticks.CompareTo(left.Ticks));
        List<object> result = new(Math.Min(16, sorted.Count));
        for (int i = 0; i < sorted.Count && i < 16; i++)
        {
            ActionMetric metric = sorted[i];
            result.Add(new
            {
                actionTemplateId = metric.ActionTemplateId,
                actionName = GetActionRefName(metric.ActionTemplateId),
                selector = metric.Selector.ToString(),
                range = metric.Range.ToString(),
                metric.RangeValue,
                calls = metric.Calls,
                elapsedMs = ToMilliseconds(metric.Ticks),
                maxMs = ToMilliseconds(metric.MaxTicks),
                inputCount = metric.InputCount,
                outputCount = metric.OutputCount,
                maxInputCount = metric.MaxInputCount,
                maxOutputCount = metric.MaxOutputCount,
                successCount = metric.SuccessCount,
                failureCount = metric.FailureCount,
            });
        }

        return result;
    }

    private static List<object> BuildTemplateTop(Dictionary<int, TemplateMetric> metrics)
    {
        List<TemplateMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.Ticks.CompareTo(left.Ticks));
        List<object> result = new(Math.Min(16, sorted.Count));
        for (int i = 0; i < sorted.Count && i < 16; i++)
        {
            TemplateMetric metric = sorted[i];
            result.Add(new
            {
                templateId = metric.TemplateId,
                templateName = GetGoalRefName(metric.TemplateId),
                calls = metric.Calls,
                elapsedMs = ToMilliseconds(metric.Ticks),
                maxMs = ToMilliseconds(metric.MaxTicks),
                inputCount = metric.InputCount,
                outputCount = metric.OutputCount,
                maxInputCount = metric.MaxInputCount,
                maxOutputCount = metric.MaxOutputCount,
                successCount = metric.SuccessCount,
                failureCount = metric.FailureCount,
            });
        }

        return result;
    }

    private static List<object> BuildRelationPrefilterTop(Dictionary<int, RelationPrefilterMetric> metrics)
    {
        List<RelationPrefilterMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.Dropped.CompareTo(left.Dropped));
        List<object> result = new(Math.Min(16, sorted.Count));
        for (int i = 0; i < sorted.Count && i < 16; i++)
        {
            RelationPrefilterMetric metric = sorted[i];
            result.Add(new
            {
                actionTemplateId = metric.ActionTemplateId,
                actionName = GetActionRefName(metric.ActionTemplateId),
                selector = metric.Selector.ToString(),
                range = metric.Range.ToString(),
                metric.RangeValue,
                calls = metric.Calls,
                selectableCount = metric.SelectableCount,
                relationCandidateCount = metric.RelationCandidateCount,
                dropped = metric.Dropped,
                maxSelectableCount = metric.MaxSelectableCount,
                maxDropped = metric.MaxDropped,
            });
        }

        return result;
    }

    private static List<object> BuildCacheTop(Dictionary<int, TargetMatcherCacheMetric> metrics)
    {
        List<TargetMatcherCacheMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.SavedCalls.CompareTo(left.SavedCalls));
        List<object> result = new(Math.Min(16, sorted.Count));
        for (int i = 0; i < sorted.Count && i < 16; i++)
        {
            TargetMatcherCacheMetric metric = sorted[i];
            result.Add(new
            {
                actionTemplateId = metric.ActionTemplateId,
                actionName = GetActionRefName(metric.ActionTemplateId),
                selector = metric.Selector.ToString(),
                range = metric.Range.ToString(),
                metric.RangeValue,
                calls = metric.Calls,
                hits = metric.Hits,
                misses = metric.Misses,
                savedCalls = metric.SavedCalls,
                hitRate = metric.Calls == 0 ? 0 : metric.Hits / (double)metric.Calls,
                trueCount = metric.TrueCount,
                falseCount = metric.FalseCount,
            });
        }

        return result;
    }

    private static List<object> BuildSensorTop(Dictionary<int, SensorUsageMetric> metrics)
    {
        List<SensorUsageMetric> sorted = new(metrics.Values);
        sorted.Sort(static (left, right) => right.Count.CompareTo(left.Count));
        List<object> result = new(Math.Min(16, sorted.Count));
        for (int i = 0; i < sorted.Count && i < 16; i++)
        {
            SensorUsageMetric metric = sorted[i];
            result.Add(new
            {
                sensorType = metric.SensorType,
                count = metric.Count,
            });
        }

        return result;
    }

    private static object MetricPayload(string name, Metric metric) =>
        new
        {
            name,
            calls = metric.Calls,
            elapsedMs = ToMilliseconds(metric.Ticks),
            maxMs = ToMilliseconds(metric.MaxTicks),
            inputCount = metric.InputCount,
            outputCount = metric.OutputCount,
            maxInputCount = metric.MaxInputCount,
            maxOutputCount = metric.MaxOutputCount,
        };

    private static void AppendTextGoal(StringBuilder builder, string title, GoalMetrics metrics)
    {
        builder.Append("  ");
        builder.Append(title);
        builder.AppendLine(":");
        foreach (CharacterActionPlanningStep step in Enum.GetValues(typeof(CharacterActionPlanningStep)))
        {
            Metric metric = metrics.Steps[(int)step];
            if (metric.Calls > 0)
            {
                AppendTextMetric(builder, step.ToString(), FormatMilliseconds(metric.Ticks) + ", calls=" + metric.Calls);
            }
        }
    }

    private static void AppendTextMetric(StringBuilder builder, string name, object value)
    {
        builder.Append("    ");
        builder.Append(name);
        builder.Append(": ");
        builder.Append(value);
        builder.AppendLine();
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

    private static string FormatMilliseconds(long ticks) =>
        ToMilliseconds(ticks).ToString("N3") + "ms";

    private static double ToMilliseconds(long ticks) =>
        ticks * 1000.0 / Stopwatch.Frequency;

    private static Metric[] CreateMetricArray<TEnum>()
        where TEnum : Enum
    {
        Array values = Enum.GetValues(typeof(TEnum));
        Metric[] metrics = new Metric[values.Length];
        for (int i = 0; i < metrics.Length; i++)
        {
            metrics[i] = new Metric();
        }

        return metrics;
    }

    private static void ClearMetrics()
    {
        ClearMetrics(ParallelStages);
        ParallelActionTypes.Clear();
        ParallelActionInvocations.Clear();
        CharacterMonthlyMethods.Clear();
        PrimaryMetrics.Clear();
        SecondaryMetrics.Clear();
        ObservedTargetMatcherCache.Clear();
        _planningStageStartTicks = 0;
        _planningStageTicks = 0;
        _advanceMonthExecuteDepth = 0;
    }

    private static void EndCharacterActionPlanningStageNoLock()
    {
        if (_planningStageStartTicks == 0)
        {
            return;
        }

        _planningStageTicks += Stopwatch.GetTimestamp() - _planningStageStartTicks;
        _planningStageStartTicks = 0;
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
        public readonly Dictionary<int, RelationPrefilterMetric> RelationPrefilterByAction = new(128);
        public readonly Dictionary<int, TargetMatcherCacheMetric> TargetMatcherCacheByAction = new(128);
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
            RelationPrefilterByAction.Clear();
            TargetMatcherCacheByAction.Clear();
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

        public void Clear()
        {
            Calls = 0;
            Ticks = 0;
            MaxTicks = 0;
            InputCount = 0;
            OutputCount = 0;
            MaxInputCount = 0;
            MaxOutputCount = 0;
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
            MaxTicks = Math.Max(MaxTicks, ticks);
            if (inputCount > 0)
            {
                InputCount += inputCount;
                MaxInputCount = Math.Max(MaxInputCount, inputCount);
            }

            if (outputCount > 0)
            {
                OutputCount += outputCount;
                MaxOutputCount = Math.Max(MaxOutputCount, outputCount);
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
            MaxTicks = Math.Max(MaxTicks, ticks);
            if (inputCount > 0)
            {
                InputCount += inputCount;
                MaxInputCount = Math.Max(MaxInputCount, inputCount);
            }

            if (outputCount > 0)
            {
                OutputCount += outputCount;
                MaxOutputCount = Math.Max(MaxOutputCount, outputCount);
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
            MaxSelectableCount = Math.Max(MaxSelectableCount, selectableCount);
            MaxDropped = Math.Max(MaxDropped, selectableCount - relationCandidateCount);
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
        public int TrueCount;
        public int FalseCount;
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

        public void Add(bool hit, bool miss, bool result)
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

    private sealed class SensorUsageMetric
    {
        public readonly int SensorType;
        public int Count;

        public SensorUsageMetric(int sensorType)
        {
            SensorType = sensorType;
        }
    }

    private readonly struct ObservedMatcherKey : IEquatable<ObservedMatcherKey>
    {
        private readonly int _goalType;
        private readonly int _actionTemplateId;
        private readonly int _targetCharId;
        private readonly int _conditionsHash;
        private readonly int _conditionCount;
        private readonly int _selector;
        private readonly int _range;
        private readonly int _rangeValue;

        public ObservedMatcherKey(
            int goalType,
            int actionTemplateId,
            int targetCharId,
            int conditionsHash,
            int conditionCount,
            int selector,
            int range,
            int rangeValue)
        {
            _goalType = goalType;
            _actionTemplateId = actionTemplateId;
            _targetCharId = targetCharId;
            _conditionsHash = conditionsHash;
            _conditionCount = conditionCount;
            _selector = selector;
            _range = range;
            _rangeValue = rangeValue;
        }

        public bool Equals(ObservedMatcherKey other) =>
            _goalType == other._goalType &&
            _actionTemplateId == other._actionTemplateId &&
            _targetCharId == other._targetCharId &&
            _conditionsHash == other._conditionsHash &&
            _conditionCount == other._conditionCount &&
            _selector == other._selector &&
            _range == other._range &&
            _rangeValue == other._rangeValue;

        public override bool Equals(object? obj) =>
            obj is ObservedMatcherKey other && Equals(other);

        public override int GetHashCode() =>
            HashCode.Combine(
                _goalType,
                _actionTemplateId,
                _targetCharId,
                _conditionsHash,
                _conditionCount,
                _selector,
                _range,
                _rangeValue);
    }
}

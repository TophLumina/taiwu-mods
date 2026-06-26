using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameData.ActionPlanning.MonthlyAI;
using NLog;

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
}

internal enum CharacterActionTargetLookupKind
{
    SameBlock,
    SameArea,
    SameState,
    BlockRange,
    SettlementRange,
}

internal static class CharacterActionPlanningDiagnostics
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private static readonly object SyncRoot = new();
    private static readonly Metric[] ParallelStages = CreateMetricArray<CharacterActionPlanningParallelStage>();
    private static readonly GoalMetrics PrimaryMetrics = new();
    private static readonly GoalMetrics SecondaryMetrics = new();
    private static readonly TargetLookupMetric[] TargetLookupMetrics = CreateTargetLookupMetricArray();

    private static Session _current;

    [ThreadStatic]
    private static int _goalScopeDepth;

    [ThreadStatic]
    private static ActionPlanningData.ECurrentGoalType _goalType;

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

    private static bool IsActive() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled && _current.StartTicks != 0;

    private static string BuildMessage(long totalTicks)
    {
        StringBuilder builder = new(2200);
        builder.AppendLine("TaiwuOptimization: CharacterActionPlanning diagnostics");
        builder.AppendLine("  total:");
        AppendMetric(builder, "elapsed", FormatMilliseconds(totalTicks));

        builder.AppendLine("  targetLookupBuild:");
        AppendMetric(builder, "elapsed", FormatMilliseconds(_current.TargetLookupBuildTicks) + ", calls=" + _current.TargetLookupBuildCalls);
        AppendMetric(builder, "blocks", _current.TargetLookupBlockCount);
        AppendMetric(builder, "areas", _current.TargetLookupAreaCount);
        AppendMetric(builder, "states", _current.TargetLookupStateCount);
        AppendMetric(builder, "characterIds", _current.TargetLookupCharacterIdCount);

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

    private static void ClearMetrics()
    {
        ClearMetrics(ParallelStages);
        ClearMetrics(PrimaryMetrics.Steps);
        ClearMetrics(SecondaryMetrics.Steps);
        foreach (TargetLookupMetric metric in TargetLookupMetrics)
        {
            metric.Clear();
        }
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

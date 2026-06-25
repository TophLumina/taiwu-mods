using System.Diagnostics;
using System.Text;
using NLog;

namespace TaiwuOptimization.Runtime;

internal static class AdvanceMonthOptimizationDiagnostics
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    // 当前日志聚合窗口的边界。
    private static long _intervalStartedAt;
    private static long _nextFlushAt;

    // 当前窗口内活跃优化帧的耗时聚合。
    private static long _elapsedTicksTotal;
    private static long _elapsedTicksMax;
    private static long _lastBudgetTicks;

    // 同步补完 cache 很少见，但对卡顿判断很重要。
    private static long _forcedCacheBuildElapsedTicks;
    private static int _activeFrames;
    private static int _overrunFrames;
    private static int _cacheBuildSteps;
    private static int _cacheStepOverruns;

    // 当前窗口内 pending job 的处理吞吐。
    private static int _pendingJobsExecuted;
    private static int _forcedCacheBuilds;
    private static int _forcedCacheBuildSteps;
    private static PeriAdvanceMonthDeferredJobStats _executedJobStats;

    /// <summary>清空当前聚合窗口。</summary>
    public static void Reset()
    {
        _intervalStartedAt = 0;
        _nextFlushAt = 0;
        ResetIntervalCounters();
    }

    /// <summary>
    /// 将一个活跃优化帧加入诊断聚合窗口。
    /// </summary>
    /// <param name="frameBudget">本 tick 使用的帧预算。</param>
    /// <param name="cacheBuildSteps">本 tick 执行的 protection-cache build step 数。</param>
    /// <param name="executedJobStats">本 tick 执行的 deferred job 类型统计。</param>
    /// <returns>返回 true 表示调用方应写出摘要日志。</returns>
    public static bool RecordFrame(
        in AdvanceMonthOptimizationFrameBudget frameBudget,
        int cacheBuildSteps,
        in PeriAdvanceMonthDeferredJobStats executedJobStats)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled)
        {
            return false;
        }

        long now = Stopwatch.GetTimestamp();
        EnsureInterval(now);

        long elapsedTicks = frameBudget.ElapsedTicks;
        _activeFrames++;
        _elapsedTicksTotal += elapsedTicks;
        if (elapsedTicks > _elapsedTicksMax)
        {
            _elapsedTicksMax = elapsedTicks;
        }

        _lastBudgetTicks = frameBudget.BudgetTicks;
        if (elapsedTicks > frameBudget.BudgetTicks)
        {
            _overrunFrames++;
        }

        _cacheBuildSteps += cacheBuildSteps;
        _pendingJobsExecuted += executedJobStats.Total;
        _executedJobStats.Add(in executedJobStats);
        return now >= _nextFlushAt;
    }

    /// <summary>记录一次超过帧预算的 cache build step。</summary>
    public static void RecordCacheStepOverrun()
    {
        if (TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled)
        {
            _cacheStepOverruns++;
        }
    }

    /// <summary>
    /// 记录一次在 AdvanceMonth 前被迫同步补完的 cache 构建。
    /// </summary>
    /// <param name="steps">被迫同步执行的 build step 数。</param>
    /// <param name="elapsedTicks">同步补完总耗时，单位为 ticks。</param>
    public static void RecordSynchronousCacheBuild(int steps, long elapsedTicks)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled)
        {
            return;
        }

        _forcedCacheBuilds++;
        _forcedCacheBuildSteps += steps;
        _forcedCacheBuildElapsedTicks += elapsedTicks;
    }

    /// <summary>
    /// 记录一次保存前、过月前或保存写入兜底阶段的 pending 强制回放。
    /// </summary>
    /// <param name="reason">触发强制回放的原版流程位置。</param>
    /// <param name="stats">本次回放的 job 类型统计。</param>
    /// <param name="elapsedTicks">本次回放耗时，单位为 Stopwatch ticks。</param>
    public static void RecordForcedPendingFlush(
        PeriAdvanceMonthForcedFlushReason reason,
        in PeriAdvanceMonthDeferredJobStats stats,
        long elapsedTicks)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled || !Logger.IsInfoEnabled)
        {
            return;
        }

        Logger.Info(BuildForcedPendingFlushMessage(
            reason,
            stats.Total,
            TicksToMilliseconds(elapsedTicks),
            in stats));
    }

    /// <summary>
    /// 通过游戏后端 logger 写出聚合诊断日志。
    /// </summary>
    /// <param name="pendingJobCount">当前 deferred job 队列长度。</param>
    /// <param name="pendingJobStats">当前 deferred job 队列类型构成。</param>
    /// <param name="overrunCooldownFrames">预算超时后剩余的 cooldown 帧数。</param>
    public static void FlushSummary(
        int pendingJobCount,
        in PeriAdvanceMonthDeferredJobStats pendingJobStats,
        int overrunCooldownFrames)
    {
        if (!TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled)
        {
            Reset();
            return;
        }

        long now = Stopwatch.GetTimestamp();
        EnsureInterval(now);

        if (Logger.IsInfoEnabled)
        {
            double intervalSeconds = TicksToSeconds(now - _intervalStartedAt);
            double avgElapsedMs = _activeFrames == 0
                ? 0.0
                : TicksToMilliseconds(_elapsedTicksTotal / _activeFrames);
            PeriAdvanceMonthProtectionCache.ProtectionCacheDiagnosticsSnapshot cacheSnapshot =
                PeriAdvanceMonthProtectionCache.GetDiagnosticsSnapshot();

            Logger.Info(BuildSummaryMessage(
                intervalSeconds,
                _activeFrames,
                TicksToMilliseconds(_lastBudgetTicks),
                avgElapsedMs,
                TicksToMilliseconds(_elapsedTicksMax),
                _overrunFrames,
                _cacheBuildSteps,
                _cacheStepOverruns,
                _pendingJobsExecuted,
                in _executedJobStats,
                pendingJobCount,
                in pendingJobStats,
                _forcedCacheBuilds,
                _forcedCacheBuildSteps,
                TicksToMilliseconds(_forcedCacheBuildElapsedTicks),
                overrunCooldownFrames,
                in cacheSnapshot));
        }

        _intervalStartedAt = now;
        _nextFlushAt = now + GetIntervalTicks();
        ResetIntervalCounters();
    }

    private static void EnsureInterval(long now)
    {
        if (_intervalStartedAt != 0)
        {
            return;
        }

        _intervalStartedAt = now;
        _nextFlushAt = now + GetIntervalTicks();
    }

    private static long GetIntervalTicks() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsIntervalSeconds * Stopwatch.Frequency;

    private static void ResetIntervalCounters()
    {
        _elapsedTicksTotal = 0;
        _elapsedTicksMax = 0;
        _lastBudgetTicks = 0;
        _forcedCacheBuildElapsedTicks = 0;
        _activeFrames = 0;
        _overrunFrames = 0;
        _cacheBuildSteps = 0;
        _cacheStepOverruns = 0;
        _pendingJobsExecuted = 0;
        _forcedCacheBuilds = 0;
        _forcedCacheBuildSteps = 0;
        _executedJobStats = default;
    }

    private static double TicksToMilliseconds(long ticks) =>
        ticks * 1000.0 / Stopwatch.Frequency;

    private static double TicksToSeconds(long ticks) =>
        (double)ticks / Stopwatch.Frequency;

    private static string BuildSummaryMessage(
        double intervalSeconds,
        int activeFrames,
        double budgetMs,
        double avgElapsedMs,
        double maxElapsedMs,
        int overrunFrames,
        int cacheBuildSteps,
        int cacheStepOverruns,
        int pendingJobsExecuted,
        in PeriAdvanceMonthDeferredJobStats executedJobStats,
        int pendingJobCount,
        in PeriAdvanceMonthDeferredJobStats pendingJobStats,
        int forcedCacheBuilds,
        int forcedCacheBuildSteps,
        double forcedCacheBuildElapsedMs,
        int overrunCooldownFrames,
        in PeriAdvanceMonthProtectionCache.ProtectionCacheDiagnosticsSnapshot cacheSnapshot)
    {
        StringBuilder builder = new(1600);
        builder.AppendLine("TaiwuOptimization: runtime budget summary");
        builder.AppendLine("  frame:");
        AppendMetric(builder, "interval", intervalSeconds.ToString("N1") + "s");
        AppendMetric(builder, "activeFrames", activeFrames);
        AppendMetric(builder, "budget", budgetMs.ToString("N3") + "ms");
        AppendMetric(builder, "avgElapsed", avgElapsedMs.ToString("N3") + "ms");
        AppendMetric(builder, "maxElapsed", maxElapsedMs.ToString("N3") + "ms");
        AppendMetric(builder, "overrunFrames", overrunFrames);
        AppendMetric(builder, "cooldownFrames", overrunCooldownFrames);

        builder.AppendLine("  protectionCache:");
        AppendMetric(builder, "state", cacheSnapshot.State);
        AppendMetric(builder, "needsFrameBuild", cacheSnapshot.NeedsFrameBuild);
        AppendMetric(builder, "hasSnapshot", cacheSnapshot.HasSnapshot);
        AppendMetric(builder, "hasFrozenSnapshot", cacheSnapshot.HasFrozenSnapshot);
        AppendMetric(builder, "versions", cacheSnapshot.GroupVersion + "/" + cacheSnapshot.RelationVersion + "/" + cacheSnapshot.AreaVersion);
        AppendMetric(builder, "cacheBuildSteps", cacheBuildSteps);
        AppendMetric(builder, "cacheStepOverruns", cacheStepOverruns);
        AppendMetric(builder, "forcedBuilds", forcedCacheBuilds);
        AppendMetric(builder, "forcedBuildSteps", forcedCacheBuildSteps);
        AppendMetric(builder, "forcedBuildElapsed", forcedCacheBuildElapsedMs.ToString("N3") + "ms");
        AppendMetric(builder, "publishedGroupChars", cacheSnapshot.PublishedGroupCharCount);
        AppendMetric(builder, "publishedRelatedChars", cacheSnapshot.PublishedRelationCharCount);
        AppendMetric(builder, "publishedProtectedAreas", cacheSnapshot.PublishedProtectedAreaCount);
        AppendMetric(builder, "buildStage", cacheSnapshot.BuildStage);
        AppendMetric(builder, "buildAnchors", cacheSnapshot.BuildAnchorIndex + "/" + cacheSnapshot.BuildAnchorCount);
        AppendMetric(builder, "buildAnchorCharId", cacheSnapshot.BuildAnchorCharId);
        AppendMetric(builder, "buildRelationTypes", cacheSnapshot.BuildRelationTypeIndex + "/" + cacheSnapshot.BuildRelationTypeCount);
        AppendMetric(builder, "buildRelationType", cacheSnapshot.BuildRelationType);
        AppendMetric(builder, "buildGroupChars", cacheSnapshot.BuildGroupCharCount);
        AppendMetric(builder, "buildRelatedChars", cacheSnapshot.BuildRelationCharCount);
        AppendMetric(builder, "buildProtectedAreas", cacheSnapshot.BuildProtectedAreaCount);
        AppendMetric(builder, "protectedAreaSource", cacheSnapshot.HasProtectedAreaSource ? cacheSnapshot.ProtectedAreaSource.ToString() : "none");
        AppendMetric(builder, "protectNeighborAreas", cacheSnapshot.ProtectedAreaIncludesNeighbors);

        builder.AppendLine("  pending:");
        AppendMetric(builder, "executed", pendingJobsExecuted);
        AppendJobStats(builder, "executedByKind", in executedJobStats);
        AppendMetric(builder, "remaining", pendingJobCount);
        AppendJobStats(builder, "remainingByKind", in pendingJobStats);
        return builder.ToString();
    }

    private static string BuildForcedPendingFlushMessage(
        PeriAdvanceMonthForcedFlushReason reason,
        int jobCount,
        double elapsedMs,
        in PeriAdvanceMonthDeferredJobStats stats)
    {
        StringBuilder builder = new(600);
        builder.AppendLine("TaiwuOptimization: forced pending flush");
        AppendMetric(builder, "reason", FormatForcedPendingFlushReason(reason));
        AppendMetric(builder, "jobs", jobCount);
        AppendMetric(builder, "elapsed", elapsedMs.ToString("N3") + "ms");
        AppendJobStats(builder, "byKind", in stats);
        return builder.ToString();
    }

    private static string FormatForcedPendingFlushReason(PeriAdvanceMonthForcedFlushReason reason)
    {
        return reason switch
        {
            PeriAdvanceMonthForcedFlushReason.BeforeAdvanceMonth => "BeforeAdvanceMonth",
            PeriAdvanceMonthForcedFlushReason.BeforeSaveWorld => "BeforeSaveWorld",
            PeriAdvanceMonthForcedFlushReason.SavingWorldUpdate => "SavingWorldUpdate",
            _ => "Unknown",
        };
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

    private static void AppendMetric(StringBuilder builder, string name, ushort value)
    {
        builder.Append("    ");
        builder.Append(name);
        builder.Append(": ");
        builder.Append(value);
        builder.AppendLine();
    }

    private static void AppendMetric(StringBuilder builder, string name, bool value)
    {
        builder.Append("    ");
        builder.Append(name);
        builder.Append(": ");
        builder.Append(value);
        builder.AppendLine();
    }

    private static void AppendJobStats(StringBuilder builder, string name, in PeriAdvanceMonthDeferredJobStats stats)
    {
        builder.Append("    ");
        builder.Append(name);
        builder.AppendLine(":");
        AppendMetric(builder, "  CharacterParallelActionChunk", stats.CharacterParallelActionChunks);
        AppendMetric(builder, "  MapBrokenBlockUpdate", stats.MapBrokenBlockUpdates);
        AppendMetric(builder, "  AnimalAreaData", stats.AnimalAreaDataUpdates);
        AppendMetric(builder, "  SkeletonGeneration", stats.SkeletonGenerations);
        AppendMetric(builder, "  MapPickupCleanup", stats.MapPickupCleanups);
    }
}

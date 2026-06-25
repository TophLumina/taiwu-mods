using System.Diagnostics;
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
    /// <returns>返回 true 表示调用方应写出一行摘要日志。</returns>
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
    /// 通过游戏后端 logger 写出一行聚合诊断日志。
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

            Logger.Info(
                "TaiwuOptimization: runtime budget summary. " +
                "interval={0:N1}s, activeFrames={1}, budget={2:N3}ms, avgElapsed={3:N3}ms, maxElapsed={4:N3}ms, " +
                "overrunFrames={5}, cooldownFrames={6}, cacheBuildSteps={7}, cacheStepOverruns={8}, " +
                "pendingExecuted={9}, pendingExecutedByKind=[{10}], pendingRemaining={11}, pendingRemainingByKind=[{12}], " +
                "forcedCacheBuilds={13}, forcedCacheBuildSteps={14}, forcedCacheBuildElapsed={15:N3}ms.",
                intervalSeconds,
                _activeFrames,
                TicksToMilliseconds(_lastBudgetTicks),
                avgElapsedMs,
                TicksToMilliseconds(_elapsedTicksMax),
                _overrunFrames,
                overrunCooldownFrames,
                _cacheBuildSteps,
                _cacheStepOverruns,
                _pendingJobsExecuted,
                _executedJobStats.ToLogString(),
                pendingJobCount,
                pendingJobStats.ToLogString(),
                _forcedCacheBuilds,
                _forcedCacheBuildSteps,
                TicksToMilliseconds(_forcedCacheBuildElapsedTicks));
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
}

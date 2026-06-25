using System;
using System.Diagnostics;

namespace TaiwuOptimization.Runtime;

internal struct AdvanceMonthOptimizationFrameBudget
{
    // 本帧优化时间片开始时的 Stopwatch 时间戳。
    private readonly long _startedAt;

    // 将配置中的毫秒预算换算为 Stopwatch ticks。
    private readonly long _budgetTicks;

    // 绝对截止 tick，用于快速判断本帧是否还有预算。
    private readonly long _deadline;

    // 本帧已执行的 pending job 数；cache build step 另行统计。
    private int _executedPendingAdvanceMonthJobs;

    /// <summary>根据配置的毫秒值创建帧预算。</summary>
    /// <param name="budgetMs">本帧最多允许使用的毫秒数。</param>
    private AdvanceMonthOptimizationFrameBudget(int budgetMs)
    {
        _startedAt = Stopwatch.GetTimestamp();
        _budgetTicks = Math.Max(1, budgetMs) * Stopwatch.Frequency / 1000;
        _deadline = _startedAt + _budgetTicks;
    }

    /// <summary>本帧预算长度，单位为 Stopwatch ticks。</summary>
    public long BudgetTicks => _budgetTicks;

    /// <summary>从本帧优化时间片开始到现在经过的 ticks。</summary>
    public readonly long ElapsedTicks => Stopwatch.GetTimestamp() - _startedAt;

    /// <summary>使用当前 mod 设置启动新的帧预算。</summary>
    public static AdvanceMonthOptimizationFrameBudget Start() =>
        new(TaiwuOptimizationSettings.AdvanceMonthOptimizationFrameBudgetMs);

    /// <summary>检查本帧是否仍有剩余时间预算。</summary>
    public readonly bool HasTimeRemaining() =>
        Stopwatch.GetTimestamp() < _deadline;

    /// <summary>检查是否还能继续执行一个 pending job，同时受任务数和时间预算限制。</summary>
    public readonly bool CanExecutePendingAdvanceMonthJob() =>
        _executedPendingAdvanceMonthJobs < TaiwuOptimizationSettings.MaxPeriAdvanceMonthDeferredJobsPerFrame &&
        HasTimeRemaining();

    /// <summary>记录本帧已执行一个 pending job。</summary>
    public void CountPendingAdvanceMonthJob()
    {
        _executedPendingAdvanceMonthJobs++;
    }

    /// <summary>
    /// 将明显超出预算的情况转换为短暂 cooldown，用于平滑后续帧。
    /// </summary>
    /// <param name="maxCooldownFrames">cooldown 帧数上限。</param>
    public readonly int GetOverrunCooldownFrames(int maxCooldownFrames)
    {
        if (ElapsedTicks <= _budgetTicks * 2)
        {
            return 0;
        }

        long excessFrames = (ElapsedTicks - _budgetTicks) / _budgetTicks;
        return (int)Math.Min(maxCooldownFrames, Math.Max(1, excessFrames));
    }
}

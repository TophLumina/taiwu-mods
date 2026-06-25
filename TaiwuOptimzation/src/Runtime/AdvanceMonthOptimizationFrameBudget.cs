using System;
using System.Diagnostics;

namespace TaiwuOptimization.Runtime;

internal sealed class AdvanceMonthOptimizationFrameBudget
{
    private readonly long _startedAt;
    private readonly long _budgetTicks;
    private readonly long _deadline;
    private int _executedPendingAdvanceMonthJobs;

    private AdvanceMonthOptimizationFrameBudget(int budgetMs)
    {
        _startedAt = Stopwatch.GetTimestamp();
        _budgetTicks = Math.Max(1, budgetMs) * Stopwatch.Frequency / 1000;
        _deadline = _startedAt + _budgetTicks;
    }

    public long BudgetTicks => _budgetTicks;

    public long ElapsedTicks => Stopwatch.GetTimestamp() - _startedAt;

    public static AdvanceMonthOptimizationFrameBudget Start() =>
        new(TaiwuOptimizationSettings.AdvanceMonthOptimizationFrameBudgetMs);

    public bool HasTimeRemaining() =>
        Stopwatch.GetTimestamp() < _deadline;

    public bool CanExecutePendingAdvanceMonthJob() =>
        _executedPendingAdvanceMonthJobs < TaiwuOptimizationSettings.MaxPeriAdvanceMonthDeferredJobsPerFrame &&
        HasTimeRemaining();

    public void CountPendingAdvanceMonthJob()
    {
        _executedPendingAdvanceMonthJobs++;
    }

    public int GetOverrunCooldownFrames(int maxCooldownFrames)
    {
        if (ElapsedTicks <= _budgetTicks * 2)
        {
            return 0;
        }

        long excessFrames = (ElapsedTicks - _budgetTicks) / _budgetTicks;
        return (int)Math.Min(maxCooldownFrames, Math.Max(1, excessFrames));
    }
}

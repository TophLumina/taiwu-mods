using System;
using System.Diagnostics;

namespace TaiwuOptimization.Runtime;

internal readonly struct AdvanceMonthOptimizationFrameBudget
{
    private readonly long _startedAt;
    private readonly long _budgetTicks;
    private readonly long _deadline;

    private AdvanceMonthOptimizationFrameBudget(int budgetMs)
    {
        _startedAt = Stopwatch.GetTimestamp();
        _budgetTicks = Math.Max(1, budgetMs) * Stopwatch.Frequency / 1000;
        _deadline = _startedAt + _budgetTicks;
    }

    /// <summary>本帧预算长度，单位为 `Stopwatch` ticks。</summary>
    public long BudgetTicks => _budgetTicks;

    /// <summary>从本帧优化时间片开始到现在经过的 ticks。</summary>
    public long ElapsedTicks => Stopwatch.GetTimestamp() - _startedAt;

    /// <summary>使用当前设置启动新的帧预算。</summary>
    public static AdvanceMonthOptimizationFrameBudget Start() =>
        new(TaiwuOptimizationSettings.AdvanceMonthOptimizationFrameBudgetMs);

    /// <summary>检查当前帧是否仍有剩余预算。</summary>
    public bool HasTimeRemaining() =>
        Stopwatch.GetTimestamp() < _deadline;
}

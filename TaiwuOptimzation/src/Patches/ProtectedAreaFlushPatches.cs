using GameData.Common;
using GameData.Domains.Map;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.StartTravel))]
internal static class StartTravelPendingAdvanceMonthAreaFlushPatch
{
    // 进入旅行前先同步目的 area，避免落点仍处于延迟状态。
    private static void Prefix(DataContext context, short toAreaId)
    {
        AdvanceMonthOptimizationRuntime.FlushPendingAdvanceMonthJobsInArea(context, toAreaId);
    }

    // 旅行会改变保护区域来源，标记 protection cache 的 area 部分失效。
    private static void Postfix() =>
        PeriAdvanceMonthProtectionCache.MarkProtectedAreasDirty();
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.DirectTravel), new[] { typeof(DataContext), typeof(short) })]
internal static class DirectTravelPendingAdvanceMonthAreaFlushPatch
{
    // 直接旅行同样需要保证目标 area 立刻同步。
    private static void Prefix(DataContext context, short toAreaId)
    {
        AdvanceMonthOptimizationRuntime.FlushPendingAdvanceMonthJobsInArea(context, toAreaId);
    }

    // 当前位置变化后重建保护区域快照。
    private static void Postfix() =>
        PeriAdvanceMonthProtectionCache.MarkProtectedAreasDirty();
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.QuickTravel))]
internal static class QuickTravelPendingAdvanceMonthAreaFlushPatch
{
    // 快速旅行只会立即同步最终落点 area。
    private static void Prefix(DataContext context, short destAreaId)
    {
        AdvanceMonthOptimizationRuntime.FlushPendingAdvanceMonthJobsInArea(context, destAreaId);
    }

    // 快速旅行完成后刷新当前/相邻州域保护范围。
    private static void Postfix() =>
        PeriAdvanceMonthProtectionCache.MarkProtectedAreasDirty();
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.StopTravel))]
internal static class StopTravelPendingAdvanceMonthProtectedAreaFlushPatch
{
    // 中途停止旅行时，立即同步新的当前州域和可选相邻州域。
    private static void Postfix(DataContext context)
    {
        AdvanceMonthOptimizationRuntime.FlushPendingAdvanceMonthJobsInProtectedAreas(context);
        PeriAdvanceMonthProtectionCache.MarkProtectedAreasDirty();
    }
}

using GameData.Common;
using GameData.Domains.Map;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.StartTravel))]
internal static class StartTravelPendingAdvanceMonthAreaFlushPatch
{
    private static void Prefix(DataContext context, short toAreaId)
    {
        AdvanceMonthOptimizationRuntime.FlushPendingAdvanceMonthJobsInArea(context, toAreaId);
    }

    private static void Postfix() =>
        PeriAdvanceMonthProtectionCache.MarkLiveSyncAreasDirty();
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.DirectTravel), new[] { typeof(DataContext), typeof(short) })]
internal static class DirectTravelPendingAdvanceMonthAreaFlushPatch
{
    private static void Prefix(DataContext context, short toAreaId)
    {
        AdvanceMonthOptimizationRuntime.FlushPendingAdvanceMonthJobsInArea(context, toAreaId);
    }

    private static void Postfix() =>
        PeriAdvanceMonthProtectionCache.MarkLiveSyncAreasDirty();
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.QuickTravel))]
internal static class QuickTravelPendingAdvanceMonthAreaFlushPatch
{
    private static void Prefix(DataContext context, short destAreaId)
    {
        AdvanceMonthOptimizationRuntime.FlushPendingAdvanceMonthJobsInArea(context, destAreaId);
    }

    private static void Postfix() =>
        PeriAdvanceMonthProtectionCache.MarkLiveSyncAreasDirty();
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.StopTravel))]
internal static class StopTravelPendingAdvanceMonthLiveSyncAreaFlushPatch
{
    private static void Postfix(DataContext context)
    {
        AdvanceMonthOptimizationRuntime.FlushPendingAdvanceMonthJobsInLiveSyncAreas(context);
        PeriAdvanceMonthProtectionCache.MarkLiveSyncAreasDirty();
    }
}

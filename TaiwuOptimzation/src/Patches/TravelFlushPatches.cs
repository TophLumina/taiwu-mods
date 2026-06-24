using GameData.Common;
using GameData.Domains.Map;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.StartTravel))]
internal static class StartTravelAreaFlushPatch
{
    private static void Prefix(DataContext context, short toAreaId) =>
        DelayMonthRuntime.FlushAreaJobs(context, toAreaId);
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.DirectTravel), new[] { typeof(DataContext), typeof(short) })]
internal static class DirectTravelAreaFlushPatch
{
    private static void Prefix(DataContext context, short toAreaId) =>
        DelayMonthRuntime.FlushAreaJobs(context, toAreaId);
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.QuickTravel))]
internal static class QuickTravelAreaFlushPatch
{
    private static void Prefix(DataContext context, short destAreaId) =>
        DelayMonthRuntime.FlushAreaJobs(context, destAreaId);
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.StopTravel))]
internal static class StopTravelLiveSyncFlushPatch
{
    private static void Postfix(DataContext context) =>
        DelayMonthRuntime.FlushCurrentLiveSyncAreas(context);
}

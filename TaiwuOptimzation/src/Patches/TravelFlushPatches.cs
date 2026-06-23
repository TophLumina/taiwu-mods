using GameData.Common;
using GameData.Domains.Map;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.StartTravel))]
internal static class StartTravelFlushPatch
{
    private static void Prefix(DataContext context, short toAreaId)
    {
        DelayMonthRuntime.FlushArea(context, toAreaId);
    }
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.DirectTravel), new[] { typeof(DataContext), typeof(short) })]
internal static class DirectTravelFlushPatch
{
    private static void Prefix(DataContext context, short toAreaId)
    {
        DelayMonthRuntime.FlushArea(context, toAreaId);
    }
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.QuickTravel))]
internal static class QuickTravelFlushPatch
{
    private static void Prefix(DataContext context, short destAreaId)
    {
        DelayMonthRuntime.FlushArea(context, destAreaId);
    }
}

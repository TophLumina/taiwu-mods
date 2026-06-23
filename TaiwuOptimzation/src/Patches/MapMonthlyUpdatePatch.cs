using GameData.Domains.Map;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.ParallelUpdateOnMonthChange))]
internal static class MapMonthlyUpdatePatch
{
    private static bool Prefix(int areaIdInt)
    {
        return !DelayMonthRuntime.TryDelayMapMonthlyArea(areaIdInt);
    }
}

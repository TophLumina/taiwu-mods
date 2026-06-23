using GameData.Domains.Map;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.ParallelUpdateBrokenBlockOnMonthChange))]
internal static class MapBrokenBlockPatch
{
    private static bool Prefix(int areaIdInt)
    {
        return !DelayMonthRuntime.TryDelayBrokenBlockArea(areaIdInt);
    }
}

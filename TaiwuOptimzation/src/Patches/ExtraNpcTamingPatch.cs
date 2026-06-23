using GameData.Domains.Extra;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(ExtraDomain), nameof(ExtraDomain.PostAdvanceMonth_UpdateNpcTaming))]
internal static class ExtraNpcTamingPatch
{
    private static bool Prefix(int areaId)
    {
        return !DelayMonthRuntime.TryDelayNpcTamingArea(areaId);
    }
}

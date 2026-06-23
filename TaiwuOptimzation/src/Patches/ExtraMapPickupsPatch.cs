using GameData.Common;
using GameData.Domains.Extra;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(ExtraDomain), nameof(ExtraDomain.MapPickupsPostAdvanceMonth))]
internal static class ExtraMapPickupsPatch
{
    private static bool Prefix(DataContext context)
    {
        return !DelayMonthRuntime.TryHandleMapPickupsPostAdvanceMonth(context);
    }
}

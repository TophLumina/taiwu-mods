using GameData.Common;
using GameData.Domains.Extra;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(ExtraDomain), nameof(ExtraDomain.UpdateAnimalAreaData))]
internal static class ExtraAnimalAreaDataPatch
{
    private static bool Prefix(DataContext context)
    {
        return !DelayMonthRuntime.TryHandleAnimalAreaData(context);
    }
}

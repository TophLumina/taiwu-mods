using GameData.Common;
using GameData.Domains.Global;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(GlobalDomain), nameof(GlobalDomain.OnUpdate))]
internal static class GlobalOnUpdatePatch
{
    private static void Postfix(DataContext context)
    {
        DelayMonthRuntime.Tick(context);
    }
}

using GameData.Common;
using GameData.Domains.World;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(WorldDomain), nameof(WorldDomain.AdvanceMonth))]
internal static class WorldAdvanceMonthPatch
{
    private static void Prefix(DataContext context)
    {
        DelayMonthRuntime.BeginAdvanceMonth(context);
    }

    private static void Finalizer()
    {
        DelayMonthRuntime.EndAdvanceMonth();
    }
}

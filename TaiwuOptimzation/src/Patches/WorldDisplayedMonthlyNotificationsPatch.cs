using GameData.Common;
using GameData.Domains.World;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(WorldDomain), nameof(WorldDomain.AdvanceMonth_DisplayedMonthlyNotifications))]
internal static class WorldDisplayedMonthlyNotificationsPatch
{
    private static void Prefix(DataContext context, ref bool saveWorld)
    {
        DelayMonthRuntime.PostponeSaveIfNeeded(ref saveWorld);
    }
}

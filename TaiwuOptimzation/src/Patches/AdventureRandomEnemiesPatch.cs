using GameData.Domains.Adventure;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(AdventureDomain), nameof(AdventureDomain.PreAdvanceMonth_UpdateRandomEnemies))]
internal static class AdventureRandomEnemiesPatch
{
    private static bool Prefix(int areaId)
    {
        return !DelayMonthRuntime.TryDelayRandomEnemiesArea(areaId);
    }
}

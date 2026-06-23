using GameData.Common;
using GameData.Domains.Character;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(CharacterDomain), nameof(CharacterDomain.GenerateSkeletons))]
internal static class CharacterSkeletonGenerationPatch
{
    private static bool Prefix(DataContext context)
    {
        return !DelayMonthRuntime.TryHandleSkeletonGeneration(context);
    }
}

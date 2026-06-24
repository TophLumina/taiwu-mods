using System.Reflection;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Extra;
using GameData.Domains.Map;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch]
internal static class CharacterParallelActionAreaDelayPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(ParallelActionManager),
            "OfflineExecuteCharacterActionsInArea",
            new[] { typeof(DataContext), typeof(int), typeof(ICharacterParallelAction) });

    private static bool Prefix(int areaId, ICharacterParallelAction action) =>
        !DeferredAdvanceMonthRuntime.TryDeferCharacterParallelActionInArea(areaId, action);
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.ParallelUpdateBrokenBlockOnMonthChange))]
internal static class MapBrokenBlockUpdateDelayPatch
{
    private static bool Prefix(int areaIdInt) =>
        !DeferredAdvanceMonthRuntime.TryDelayMapBrokenBlockUpdate(areaIdInt);
}

[HarmonyPatch(typeof(ExtraDomain), nameof(ExtraDomain.UpdateAnimalAreaData))]
internal static class ExtraAnimalAreaDataDelayPatch
{
    private static bool Prefix(DataContext context) =>
        !DeferredAdvanceMonthRuntime.TryHandleAnimalAreaData(context);
}

[HarmonyPatch(typeof(CharacterDomain), nameof(CharacterDomain.GenerateSkeletons))]
internal static class CharacterSkeletonGenerationDelayPatch
{
    private static bool Prefix(DataContext context) =>
        !DeferredAdvanceMonthRuntime.TryHandleSkeletonGeneration(context);
}

[HarmonyPatch(typeof(ExtraDomain), nameof(ExtraDomain.MapPickupsPostAdvanceMonth))]
internal static class ExtraMapPickupCleanupDelayPatch
{
    private static bool Prefix(DataContext context) =>
        !DeferredAdvanceMonthRuntime.TryDelayMapPickupCleanup(context);
}

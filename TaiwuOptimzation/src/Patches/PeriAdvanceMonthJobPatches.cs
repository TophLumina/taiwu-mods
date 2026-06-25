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
internal static class OfflineExecuteCharacterActionsInAreaDeferPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(ParallelActionManager),
            "OfflineExecuteCharacterActionsInArea",
            new[] { typeof(DataContext), typeof(int), typeof(ICharacterParallelAction) });

    private static bool Prefix(DataContext context, int areaId, ICharacterParallelAction action) =>
        !AdvanceMonthOptimizationRuntime.TryDeferCharacterParallelActionInArea(context, areaId, action);
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.ParallelUpdateBrokenBlockOnMonthChange))]
internal static class ParallelUpdateBrokenBlockOnMonthChangeDeferPatch
{
    private static bool Prefix(int areaIdInt) =>
        !AdvanceMonthOptimizationRuntime.TryDeferParallelUpdateBrokenBlockOnMonthChange(areaIdInt);
}

[HarmonyPatch(typeof(ExtraDomain), nameof(ExtraDomain.UpdateAnimalAreaData))]
internal static class UpdateAnimalAreaDataDeferPatch
{
    private static bool Prefix(DataContext context) =>
        !AdvanceMonthOptimizationRuntime.TryDeferUpdateAnimalAreaData(context);
}

[HarmonyPatch(typeof(CharacterDomain), nameof(CharacterDomain.GenerateSkeletons))]
internal static class GenerateSkeletonsDeferPatch
{
    private static bool Prefix(DataContext context) =>
        !AdvanceMonthOptimizationRuntime.TryDeferGenerateSkeletons(context);
}

[HarmonyPatch(typeof(ExtraDomain), nameof(ExtraDomain.MapPickupsPostAdvanceMonth))]
internal static class MapPickupsPostAdvanceMonthDeferPatch
{
    private static bool Prefix(DataContext context) =>
        !AdvanceMonthOptimizationRuntime.TryDeferMapPickupsPostAdvanceMonth(context);
}

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
    // 原版按 area 执行 NPC 行动前并行任务；此处尝试拆出远区角色块。
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(ParallelActionManager),
            "OfflineExecuteCharacterActionsInArea",
            new[] { typeof(DataContext), typeof(int), typeof(ICharacterParallelAction) });

    // 返回 false 表示已入队或已同步处理，跳过原版本次 area 执行。
    private static bool Prefix(DataContext context, int areaId, ICharacterParallelAction action) =>
        !AdvanceMonthOptimizationRuntime.TryDeferCharacterParallelActionInArea(context, areaId, action);
}

[HarmonyPatch(typeof(MapDomain), nameof(MapDomain.ParallelUpdateBrokenBlockOnMonthChange))]
internal static class ParallelUpdateBrokenBlockOnMonthChangeDeferPatch
{
    // 远区破损地块倒计时可拆成 block range job。
    private static bool Prefix(int areaIdInt) =>
        !AdvanceMonthOptimizationRuntime.TryDeferParallelUpdateBrokenBlockOnMonthChange(areaIdInt);
}

[HarmonyPatch(typeof(ExtraDomain), nameof(ExtraDomain.UpdateAnimalAreaData))]
internal static class UpdateAnimalAreaDataDeferPatch
{
    // 野生动物生态按 area 入队；实时 area 仍走原版同步。
    private static bool Prefix(DataContext context) =>
        !AdvanceMonthOptimizationRuntime.TryDeferUpdateAnimalAreaData(context);
}

[HarmonyPatch(typeof(CharacterDomain), nameof(CharacterDomain.GenerateSkeletons))]
internal static class GenerateSkeletonsDeferPatch
{
    // 坟墓骷髅生成只处理原版覆盖的前 45 个 area。
    private static bool Prefix(DataContext context) =>
        !AdvanceMonthOptimizationRuntime.TryDeferGenerateSkeletons(context);
}

[HarmonyPatch(typeof(ExtraDomain), nameof(ExtraDomain.MapPickupsPostAdvanceMonth))]
internal static class MapPickupsPostAdvanceMonthDeferPatch
{
    // 地图拾取物按月结时的位置快照分批清理。
    private static bool Prefix(DataContext context) =>
        !AdvanceMonthOptimizationRuntime.TryDeferMapPickupsPostAdvanceMonth(context);
}

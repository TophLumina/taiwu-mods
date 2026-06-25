using GameData.Common;
using GameData.Domains.Global;
using GameData.Domains.World;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(WorldDomain), nameof(WorldDomain.AdvanceMonth))]
internal static class AdvanceMonthLifecyclePatch
{
    // 只冻结已经由游玩帧构建好的保护快照；未就绪则本月行动点实验项自动跳过。
    private static void Prefix() =>
        AdvanceMonthOptimizationRuntime.BeginAdvanceMonthOptimizationScope();

    // 过月结束后释放冻结快照，让月中帧继续构建下一次使用的快照。
    private static void Finalizer() =>
        AdvanceMonthOptimizationRuntime.EndAdvanceMonthOptimizationScope();
}

[HarmonyPatch(typeof(GlobalDomain), nameof(GlobalDomain.OnUpdate))]
internal static class AdvanceMonthOptimizationRuntimeTickPatch
{
    // 复用原版后端 update，在游玩状态中按帧预算推进保护快照。
    private static void Postfix(DataContext context) =>
        AdvanceMonthOptimizationRuntime.TickAdvanceMonthOptimization(context);
}

[HarmonyPatch(typeof(GlobalDomain), nameof(GlobalDomain.LeaveWorld))]
internal static class AdvanceMonthOptimizationLeaveWorldPatch
{
    // 退出世界/切档时清理快照，避免旧世界数据被下一次读取复用。
    private static void Prefix() =>
        AdvanceMonthOptimizationRuntime.LeaveWorld();
}

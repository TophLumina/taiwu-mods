using System.Reflection;
using GameData.Common;
using GameData.Domains.Global;
using GameData.Domains.World;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(WorldDomain), nameof(WorldDomain.AdvanceMonth))]
internal static class AdvanceMonthLifecyclePatch
{
    // 过月前先清空旧 pending，并冻结本次过月保护快照。
    private static void Prefix(DataContext context) =>
        AdvanceMonthOptimizationRuntime.BeginAdvanceMonthOptimizationScope(context);

    // 无论原版过月是否异常退出，都释放过月状态。
    private static void Finalizer() =>
        AdvanceMonthOptimizationRuntime.EndAdvanceMonthOptimizationScope();
}

[HarmonyPatch(typeof(GlobalDomain), nameof(GlobalDomain.SaveWorld), new[] { typeof(DataContext), typeof(sbyte) })]
internal static class PendingAdvanceMonthJobsSidecarOnSaveWorldPatch
{
    // 普通保存不再同步 flush pending，而是把剩余任务写到存档旁 sidecar。
    private static void Postfix(DataContext context) =>
        AdvanceMonthOptimizationRuntime.SavePendingAdvanceMonthJobsSidecarOrFlush(context);
}

[HarmonyPatch]
internal static class PendingAdvanceMonthJobsBeforeSaveWorldAtPatch
{
    // SaveWorldAt 会写临时世界文件，例如进入指引世界前，保守地保持同步完整。
    private static MethodBase TargetMethod() =>
        AccessTools.Method(typeof(GlobalDomain), "SaveWorldAt", new[] { typeof(DataContext), typeof(string), typeof(bool) });

    // 不接管原版保存，只在特殊保存前强制补完 pending。
    private static void Prefix(DataContext context) =>
        AdvanceMonthOptimizationRuntime.FlushAllPendingAdvanceMonthJobs(
            context,
            PeriAdvanceMonthForcedFlushReason.BeforeSaveWorld);
}

[HarmonyPatch(typeof(GlobalDomain), nameof(GlobalDomain.OnUpdate))]
internal static class AdvanceMonthOptimizationRuntimeTickPatch
{
    // 复用原版 GlobalDomain.OnUpdate 作为后台帧预算入口。
    private static void Postfix(DataContext context) =>
        AdvanceMonthOptimizationRuntime.TickAdvanceMonthOptimization(context);
}

[HarmonyPatch(typeof(GlobalDomain), nameof(GlobalDomain.LeaveWorld))]
internal static class PendingAdvanceMonthJobsLeaveWorldPatch
{
    // 退出世界不保存当前世界状态，直接丢弃未完成 pending。
    private static void Prefix() =>
        AdvanceMonthOptimizationRuntime.ClearPendingAdvanceMonthJobs();
}

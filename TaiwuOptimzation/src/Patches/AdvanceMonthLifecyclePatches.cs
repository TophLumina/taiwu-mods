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
    private static void Prefix(DataContext context) =>
        AdvanceMonthOptimizationRuntime.BeginAdvanceMonthOptimizationScope(context);

    private static void Finalizer() =>
        AdvanceMonthOptimizationRuntime.EndAdvanceMonthOptimizationScope();
}

[HarmonyPatch]
internal static class PendingAdvanceMonthJobsBeforeSavePatch
{
    // SaveWorldAt writes temporary world files, for example before entering guide worlds.
    private static MethodBase[] TargetMethods() =>
        new[]
        {
            AccessTools.Method(typeof(GlobalDomain), nameof(GlobalDomain.SaveWorld), new[] { typeof(DataContext), typeof(sbyte) }),
            AccessTools.Method(typeof(GlobalDomain), "SaveWorldAt", new[] { typeof(DataContext), typeof(string), typeof(bool) }),
        };

    private static void Prefix(DataContext context) =>
        AdvanceMonthOptimizationRuntime.FlushAllPendingAdvanceMonthJobs(context);
}

[HarmonyPatch(typeof(GlobalDomain), nameof(GlobalDomain.OnUpdate))]
internal static class AdvanceMonthOptimizationRuntimeTickPatch
{
    private static void Postfix(DataContext context) =>
        AdvanceMonthOptimizationRuntime.TickAdvanceMonthOptimization(context);
}

[HarmonyPatch(typeof(GlobalDomain), nameof(GlobalDomain.LeaveWorld))]
internal static class PendingAdvanceMonthJobsLeaveWorldPatch
{
    private static void Prefix() =>
        AdvanceMonthOptimizationRuntime.ClearPendingAdvanceMonthJobs();
}

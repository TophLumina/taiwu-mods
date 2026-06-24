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
        DeferredAdvanceMonthRuntime.BeginAdvanceMonthDelayScope(context);

    private static void Finalizer() =>
        DeferredAdvanceMonthRuntime.EndAdvanceMonthDelayScope();
}

[HarmonyPatch]
internal static class PendingJobsBeforeSavePatch
{
    // SaveWorldAt writes temporary world files, for example before entering guide worlds.
    private static MethodBase[] TargetMethods() =>
        new[]
        {
            AccessTools.Method(typeof(GlobalDomain), nameof(GlobalDomain.SaveWorld), new[] { typeof(DataContext), typeof(sbyte) }),
            AccessTools.Method(typeof(GlobalDomain), "SaveWorldAt", new[] { typeof(DataContext), typeof(string), typeof(bool) }),
        };

    private static void Prefix(DataContext context) =>
        DeferredAdvanceMonthRuntime.FlushAllPendingJobs(context);
}

[HarmonyPatch(typeof(GlobalDomain), nameof(GlobalDomain.OnUpdate))]
internal static class DeferredAdvanceMonthRuntimeTickPatch
{
    private static void Postfix(DataContext context) =>
        DeferredAdvanceMonthRuntime.TickDelayedJobs(context);
}

[HarmonyPatch(typeof(GlobalDomain), nameof(GlobalDomain.LeaveWorld))]
internal static class PendingJobsLeaveWorldPatch
{
    private static void Prefix() =>
        DeferredAdvanceMonthRuntime.ClearPendingJobs();
}

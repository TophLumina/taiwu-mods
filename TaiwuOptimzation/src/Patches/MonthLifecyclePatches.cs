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
        DelayMonthRuntime.BeginAdvanceMonthDelayScope(context);

    private static void Finalizer() =>
        DelayMonthRuntime.EndAdvanceMonthDelayScope();
}

[HarmonyPatch(typeof(WorldDomain), nameof(WorldDomain.AdvanceMonth_DisplayedMonthlyNotifications))]
internal static class MonthlyNotificationSavePatch
{
    private static void Prefix(ref bool saveWorld) =>
        DelayMonthRuntime.PostponeSaveUntilJobsComplete(ref saveWorld);
}

[HarmonyPatch(typeof(GlobalDomain), nameof(GlobalDomain.OnUpdate))]
internal static class DelayedMonthRuntimeTickPatch
{
    private static void Postfix(DataContext context) =>
        DelayMonthRuntime.TickDelayedJobs(context);
}

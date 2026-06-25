using System.Collections.Generic;
using System.Reflection;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Taiwu;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch]
internal static class OfflineUpdateCurrentGoalActionsActionPointPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            "OfflineUpdateCurrentGoalActions",
            new[] { typeof(DataContext), typeof(ActionPlanningData.ECurrentGoalType) });

    private static void Prefix(
        Character __instance,
        ActionPlanningData.ECurrentGoalType goalType,
        out OfflineUpdateCurrentGoalActionsActionPointReducer.OfflineCurrentGoalActionPointState __state)
    {
        __state = OfflineUpdateCurrentGoalActionsActionPointReducer.CaptureBeforeOfflineUpdateCurrentGoalActions(__instance, goalType);
    }

    private static void Postfix(
        Character __instance,
        ActionPlanningData.ECurrentGoalType goalType,
        OfflineUpdateCurrentGoalActionsActionPointReducer.OfflineCurrentGoalActionPointState __state)
    {
        OfflineUpdateCurrentGoalActionsActionPointReducer.ReduceOfflineCurrentGoalActionPointGainIfNeeded(__instance, goalType, __state);
    }
}

[HarmonyPatch]
internal static class PeriAdvanceMonthRelationCacheInvalidationPatch
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.AddRelation),
            new[] { typeof(DataContext), typeof(int), typeof(int), typeof(ushort), typeof(int) });
        yield return AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.ChangeRelationType),
            new[] { typeof(DataContext), typeof(int), typeof(int), typeof(ushort), typeof(ushort) });
        yield return AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.RemoveRelation),
            new[] { typeof(DataContext), typeof(int), typeof(int) });
    }

    private static void Postfix(int charId, int relatedCharId) =>
        PeriAdvanceMonthProtectionCache.MarkRelationDirtyIfTaiwuGroupRelated(charId, relatedCharId);
}

[HarmonyPatch]
internal static class PeriAdvanceMonthTaiwuGroupCacheInvalidationPatch
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        yield return AccessTools.Method(
            typeof(TaiwuDomain),
            nameof(TaiwuDomain.JoinGroup),
            new[] { typeof(DataContext), typeof(int), typeof(bool) });
        yield return AccessTools.Method(
            typeof(TaiwuDomain),
            nameof(TaiwuDomain.LeaveGroup),
            new[] { typeof(DataContext), typeof(int), typeof(bool), typeof(bool), typeof(bool) });
    }

    private static void Postfix() =>
        PeriAdvanceMonthProtectionCache.MarkTaiwuGroupDirty();
}

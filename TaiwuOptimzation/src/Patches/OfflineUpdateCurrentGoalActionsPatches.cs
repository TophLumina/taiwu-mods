using System.Collections.Generic;
using System.Reflection;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Domains.Taiwu;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch]
internal static class OfflineUpdateCurrentGoalActionsActionPointPatch
{
    // 目标方法是 private，需要用 AccessTools 精确定位签名。
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            "OfflineUpdateCurrentGoalActions",
            new[] { typeof(DataContext), typeof(ActionPlanningData.ECurrentGoalType) });

    // Prefix 捕获原行动点，Postfix 才能只削减“本月新增量”。
    private static void Prefix(
        Character __instance,
        ActionPlanningData.ECurrentGoalType goalType,
        out OfflineUpdateCurrentGoalActionsActionPointReducer.OfflineCurrentGoalActionPointState __state)
    {
        __state = OfflineUpdateCurrentGoalActionsActionPointReducer.CaptureBeforeOfflineUpdateCurrentGoalActions(__instance, goalType);
    }

    // 原版更新完成后再按保护规则回调行动点。
    private static void Postfix(
        Character __instance,
        ActionPlanningData.ECurrentGoalType goalType,
        OfflineUpdateCurrentGoalActionsActionPointReducer.OfflineCurrentGoalActionPointState __state)
    {
        OfflineUpdateCurrentGoalActionsActionPointReducer.ReduceOfflineCurrentGoalActionPointGainIfNeeded(__instance, goalType, __state);
    }
}

[HarmonyPatch]
internal static class AdvanceMonthProtectionRelationInvalidationPatch
{
    // 只监听会改变人物关系图的原版入口。
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

    // 只有关系变更涉及太吾/队友时才让 relation cache 失效。
    private static void Postfix(int charId, int relatedCharId) =>
        AdvanceMonthProtectionSnapshotCache.MarkRelationDirtyIfTaiwuGroupRelated(charId, relatedCharId);
}

[HarmonyPatch]
internal static class AdvanceMonthProtectionTaiwuGroupInvalidationPatch
{
    // 队友加入/离开会改变保护锚点，需要重建 group 和 relation cache。
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

    // 不尝试增量修补，直接标记相关 cache dirty。
    private static void Postfix()
    {
        AdvanceMonthProtectionSnapshotCache.MarkTaiwuGroupDirty();
    }
}

[HarmonyPatch]
internal static class AdvanceMonthProtectionTaiwuLocationInvalidationPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            nameof(Character.SetLocation),
            new[] { typeof(Location), typeof(DataContext) });

    // 目标索引过月前全量重建；这里仅处理太吾跨 area 对行动点保护区域的影响。
    private static void Prefix(Character __instance, Location location)
    {
        if (__instance.GetId() != DomainManager.Taiwu.GetTaiwuCharId())
        {
            return;
        }

        Location oldLocation = __instance.GetLocation();
        if (IsAreaChanged(oldLocation, location))
        {
            AdvanceMonthProtectionSnapshotCache.MarkProtectedAreasDirty();
        }
    }

    private static bool IsAreaChanged(Location oldLocation, Location newLocation)
    {
        bool oldValid = oldLocation.IsValid();
        bool newValid = newLocation.IsValid();
        return oldValid != newValid || oldValid && oldLocation.AreaId != newLocation.AreaId;
    }
}

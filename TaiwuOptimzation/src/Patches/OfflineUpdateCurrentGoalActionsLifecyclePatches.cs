using System;
using System.Reflection;
using GameData.ActionPlanning;
using GameData.ActionPlanning.Interface;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;
using GameData.GameDataBridge;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch]
[HarmonyPriority(Priority.First)]
internal static class OfflineUpdateCurrentGoalActionsOptimizationStagePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(ParallelActionManager),
            nameof(ParallelActionManager.Execute),
            new[] { typeof(DataMonitorManager), typeof(ICharacterParallelAction) });

    // 原版 `CharacterRelationsUpdate` 位于 NPC 行动规划之前，缓存必须在该屏障之后冻结。
    private static void Prefix(ICharacterParallelAction action)
    {
        Type actionType = action.GetType();
        if (actionType == typeof(UpdatePrimaryGoalAndActions) ||
            actionType == typeof(UpdateSecondaryGoalAndActions))
        {
            AdvanceMonthOptimizationRuntime.BeginOfflineUpdateCurrentGoalActionsOptimizationStage(
                actionType == typeof(UpdatePrimaryGoalAndActions));
        }
    }

    private static Exception? Finalizer(ICharacterParallelAction action, Exception? __exception)
    {
        Type actionType = action.GetType();
        if (actionType == typeof(UpdatePrimaryGoalAndActions) ||
            actionType == typeof(UpdateSecondaryGoalAndActions))
        {
            AdvanceMonthOptimizationRuntime.FinishOfflineUpdateCurrentGoalActionsOptimizationStage();
        }

        return __exception;
    }
}

[HarmonyPatch]
[HarmonyPriority(Priority.First)]
internal static class OfflineUpdateCurrentGoalActionsApplyAllBoundaryPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(ParallelModificationsRecorder),
            nameof(ParallelModificationsRecorder.ApplyAll),
            new[] { typeof(DataContext) });

    // 所有 worker planning 结束后，原版会串行执行 `ApplyAll`；这里关闭只读屏障并开始记录写回 delta。
    private static void Prefix() =>
        AdvanceMonthOptimizationRuntime.EnterOfflineUpdateCurrentGoalActionsApplyAll();
}

[HarmonyPatch]
internal static class OfflineUpdateCurrentGoalActionsTargetPrefilterAddRelationPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.AddRelation),
            new[] { typeof(DataContext), typeof(int), typeof(int), typeof(ushort), typeof(int) });

    // 新增关系只标记相关 actor/state dirty，不废弃整张预过滤快照。
    private static void Postfix(
        [HarmonyArgument(1)] int charId,
        [HarmonyArgument(2)] int relatedCharId) =>
        OfflineUpdateCurrentGoalActionsCacheInvalidation.InvalidateBidirectionalRelationMutation(charId, relatedCharId);
}

[HarmonyPatch]
internal static class OfflineUpdateCurrentGoalActionsTargetPrefilterChangeRelationTypePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.ChangeRelationType),
            new[] { typeof(DataContext), typeof(int), typeof(int), typeof(ushort), typeof(ushort) });

    // 单条关系类型变化只标记相关 actor/state dirty。
    private static void Postfix(
        [HarmonyArgument(1)] int charId,
        [HarmonyArgument(2)] int relatedCharId) =>
        OfflineUpdateCurrentGoalActionsCacheInvalidation.InvalidateRelationMutation(charId, relatedCharId);
}

[HarmonyPatch]
internal static class OfflineUpdateCurrentGoalActionsTargetPrefilterRemoveRelationPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.RemoveRelation),
            new[] { typeof(DataContext), typeof(int), typeof(int) });

    // 单条关系删除只标记相关 actor/state dirty。
    private static void Postfix(
        [HarmonyArgument(1)] int charId,
        [HarmonyArgument(2)] int relatedCharId) =>
        OfflineUpdateCurrentGoalActionsCacheInvalidation.InvalidateRelationMutation(charId, relatedCharId);
}

[HarmonyPatch]
internal static class OfflineUpdateCurrentGoalActionsTargetPrefilterRemoveAllGeneralRelationsPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.RemoveAllGeneralRelations),
            new[] { typeof(DataContext), typeof(int) });

    // 批量删除无法精确枚举全部反向受影响者，保守废弃关系预过滤快照。
    private static void Postfix([HarmonyArgument(1)] int charId) =>
        OfflineUpdateCurrentGoalActionsCacheInvalidation.InvalidateRelationSet(charId);
}

[HarmonyPatch]
internal static class OfflineUpdateCurrentGoalActionsTargetPrefilterRemoveAllRelationsPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.RemoveAllRelations),
            new[] { typeof(DataContext), typeof(int), typeof(bool) });

    // 批量删除无法精确枚举全部反向受影响者，保守废弃关系预过滤快照。
    private static void Postfix([HarmonyArgument(1)] int charId) =>
        OfflineUpdateCurrentGoalActionsCacheInvalidation.InvalidateRelationSet(charId);
}

internal static class OfflineUpdateCurrentGoalActionsCacheInvalidation
{
    public static void InvalidateBidirectionalRelationMutation(int charId, int relatedCharId)
    {
        OfflineUpdateCurrentGoalActionsTargetPrefilter.InvalidateRelationMutation(charId, relatedCharId);
        OfflineUpdateCurrentGoalActionsTargetPrefilter.InvalidateRelationMutation(relatedCharId, charId);
        OfflineUpdateCurrentGoalActionsMatcherCache.InvalidateRelationTargets(charId, relatedCharId);
    }

    public static void InvalidateRelationMutation(int charId, int relatedCharId)
    {
        OfflineUpdateCurrentGoalActionsTargetPrefilter.InvalidateRelationMutation(charId, relatedCharId);
        OfflineUpdateCurrentGoalActionsTargetPrefilter.InvalidateRelationMutation(relatedCharId, charId);
        OfflineUpdateCurrentGoalActionsMatcherCache.InvalidateRelationTargets(charId, relatedCharId);
    }

    public static void InvalidateRelationSet(int charId)
    {
        OfflineUpdateCurrentGoalActionsTargetPrefilter.InvalidateForRelationMutation();
        if (charId == DomainManager.Taiwu.GetTaiwuCharId())
        {
            OfflineUpdateCurrentGoalActionsMatcherCache.InvalidateAll();
            return;
        }

        OfflineUpdateCurrentGoalActionsMatcherCache.InvalidateTarget(charId);
    }
}

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
internal static class UpdateCurrentGoalActionsOptimizationStagePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(ParallelActionManager),
            nameof(ParallelActionManager.Execute),
            new[] { typeof(DataMonitorManager), typeof(ICharacterParallelAction) });

    // 原版 CharacterRelationsUpdate 位于 NPC 行动规划之前，快照必须在该屏障之后冻结。
    private static void Prefix(ICharacterParallelAction action)
    {
        Type actionType = action.GetType();
        if (actionType == typeof(UpdatePrimaryGoalAndActions) ||
            actionType == typeof(UpdateSecondaryGoalAndActions))
        {
            AdvanceMonthOptimizationRuntime.BeginUpdateCurrentGoalActionsOptimizationStage(
                actionType == typeof(UpdatePrimaryGoalAndActions));
        }
    }

    private static Exception? Finalizer(ICharacterParallelAction action, Exception? __exception)
    {
        Type actionType = action.GetType();
        if (actionType == typeof(UpdatePrimaryGoalAndActions) ||
            actionType == typeof(UpdateSecondaryGoalAndActions))
        {
            AdvanceMonthOptimizationRuntime.FinishUpdateCurrentGoalActionsOptimizationStage();
        }

        return __exception;
    }
}

[HarmonyPatch]
[HarmonyPriority(Priority.First)]
internal static class UpdateCurrentGoalActionsApplyAllBoundaryPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(ParallelModificationsRecorder),
            nameof(ParallelModificationsRecorder.ApplyAll),
            new[] { typeof(DataContext) });

    // `WorkerThreadManager.Run` 在所有 worker planning 完成后立刻调用 ApplyAll。
    // 这里关闭只读快照阶段，让 primary 写回产生的变更进入 epoch，供 secondary 前重建。
    private static void Prefix() =>
        AdvanceMonthOptimizationRuntime.EnterUpdateCurrentGoalActionsApplyAll();
}

[HarmonyPatch]
internal static class CharacterPlanningAgentTargetPrefilterAddRelationPatch
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
        UpdateCurrentGoalActionsCacheInvalidation.InvalidateBidirectionalRelationMutation(charId, relatedCharId);
}

[HarmonyPatch]
internal static class CharacterPlanningAgentTargetPrefilterChangeRelationTypePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.ChangeRelationType),
            new[] { typeof(DataContext), typeof(int), typeof(int), typeof(ushort), typeof(ushort) });

    // 单条关系变化只标记相关 actor/state dirty，不废弃整张预过滤快照。
    private static void Postfix(
        [HarmonyArgument(1)] int charId,
        [HarmonyArgument(2)] int relatedCharId) =>
        UpdateCurrentGoalActionsCacheInvalidation.InvalidateRelationMutation(charId, relatedCharId);
}

[HarmonyPatch]
internal static class CharacterPlanningAgentTargetPrefilterRemoveRelationPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.RemoveRelation),
            new[] { typeof(DataContext), typeof(int), typeof(int) });

    // 单条关系删除只标记相关 actor/state dirty，不废弃整张预过滤快照。
    private static void Postfix(
        [HarmonyArgument(1)] int charId,
        [HarmonyArgument(2)] int relatedCharId) =>
        UpdateCurrentGoalActionsCacheInvalidation.InvalidateRelationMutation(charId, relatedCharId);
}

[HarmonyPatch]
internal static class CharacterPlanningAgentTargetPrefilterRemoveAllGeneralRelationsPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.RemoveAllGeneralRelations),
            new[] { typeof(DataContext), typeof(int) });

    // 批量删除无法精确枚举全部反向受影响者，保守废弃预过滤快照。
    private static void Postfix([HarmonyArgument(1)] int charId) =>
        UpdateCurrentGoalActionsCacheInvalidation.InvalidateRelationSet(charId);
}

[HarmonyPatch]
internal static class CharacterPlanningAgentTargetPrefilterRemoveAllRelationsPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.RemoveAllRelations),
            new[] { typeof(DataContext), typeof(int), typeof(bool) });

    // 批量删除无法精确枚举全部反向受影响者，保守废弃预过滤快照。
    private static void Postfix([HarmonyArgument(1)] int charId) =>
        UpdateCurrentGoalActionsCacheInvalidation.InvalidateRelationSet(charId);
}

internal static class UpdateCurrentGoalActionsCacheInvalidation
{
    public static void InvalidateBidirectionalRelationMutation(int charId, int relatedCharId)
    {
        CharacterPlanningAgentTargetPrefilter.InvalidateRelationMutation(charId, relatedCharId);
        CharacterPlanningAgentTargetPrefilter.InvalidateRelationMutation(relatedCharId, charId);
        CharacterMatcherStageCache.InvalidateRelationTargets(charId, relatedCharId);
    }

    public static void InvalidateRelationMutation(int charId, int relatedCharId)
    {
        CharacterPlanningAgentTargetPrefilter.InvalidateRelationMutation(charId, relatedCharId);
        CharacterPlanningAgentTargetPrefilter.InvalidateRelationMutation(relatedCharId, charId);
        CharacterMatcherStageCache.InvalidateRelationTargets(charId, relatedCharId);
    }

    public static void InvalidateRelationSet(int charId)
    {
        CharacterPlanningAgentTargetPrefilter.InvalidateForRelationMutation();
        if (charId == DomainManager.Taiwu.GetTaiwuCharId())
        {
            CharacterMatcherStageCache.InvalidateAll();
            return;
        }

        CharacterMatcherStageCache.InvalidateTarget(charId);
    }
}

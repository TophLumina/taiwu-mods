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
            AdvanceMonthOptimizationRuntime.BeginUpdateCurrentGoalActionsOptimizationStage();
        }
    }

    private static Exception? Finalizer(ICharacterParallelAction action, Exception? __exception)
    {
        Type actionType = action.GetType();
        if (actionType == typeof(UpdatePrimaryGoalAndActions) ||
            actionType == typeof(UpdateSecondaryGoalAndActions))
        {
            AdvanceMonthOptimizationRuntime.EndUpdateCurrentGoalActionsOptimizationStage();
        }

        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterGoalTargetConditionPrefilterAddRelationPatch
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
internal static class CharacterGoalTargetConditionPrefilterChangeRelationTypePatch
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
internal static class CharacterGoalTargetConditionPrefilterRemoveRelationPatch
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
internal static class CharacterGoalTargetConditionPrefilterRemoveAllGeneralRelationsPatch
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
internal static class CharacterGoalTargetConditionPrefilterRemoveAllRelationsPatch
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
        CharacterGoalTargetConditionPrefilter.InvalidateRelationMutation(charId, relatedCharId);
        CharacterGoalTargetConditionPrefilter.InvalidateRelationMutation(relatedCharId, charId);
        CharacterActionTargetMatcherStageCache.InvalidateRelationTargets(charId, relatedCharId);
    }

    public static void InvalidateRelationMutation(int charId, int relatedCharId)
    {
        CharacterGoalTargetConditionPrefilter.InvalidateRelationMutation(charId, relatedCharId);
        CharacterActionTargetMatcherStageCache.InvalidateRelationTargets(charId, relatedCharId);
    }

    public static void InvalidateRelationSet(int charId)
    {
        CharacterGoalTargetConditionPrefilter.InvalidateForRelationMutation();
        if (charId == DomainManager.Taiwu.GetTaiwuCharId())
        {
            CharacterActionTargetMatcherStageCache.InvalidateAll();
            return;
        }

        CharacterActionTargetMatcherStageCache.InvalidateTarget(charId);
    }
}

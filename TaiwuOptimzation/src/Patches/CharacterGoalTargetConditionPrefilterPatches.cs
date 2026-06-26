using System;
using System.Reflection;
using GameData.ActionPlanning;
using GameData.ActionPlanning.Interface;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;
using GameData.GameDataBridge;
using HarmonyLib;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch]
[HarmonyPriority(Priority.First)]
internal static class CharacterGoalTargetConditionPrefilterGoalActionStagePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(ParallelActionManager),
            nameof(ParallelActionManager.Execute),
            new[] { typeof(DataMonitorManager), typeof(ICharacterParallelAction) });

    // 原版 CharacterRelationsUpdate 位于 NPC 行动规划之前；快照必须在该屏障之后冻结。
    private static void Prefix(ICharacterParallelAction action)
    {
        Type actionType = action.GetType();
        if (actionType == typeof(UpdatePrimaryGoalAndActions) ||
            actionType == typeof(UpdateSecondaryGoalAndActions))
        {
            AdvanceMonthOptimizationRuntime.PrepareRelationTargetCacheBeforeGoalActions();
        }
    }
}

[HarmonyPatch]
internal static class CharacterGoalTargetConditionPrefilterChangeRelationTypePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.ChangeRelationType),
            new[] { typeof(DataContext), typeof(int), typeof(int), typeof(ushort), typeof(ushort) });

    // 关系类型改变后不能继续使用旧快照。
    private static void Postfix() =>
        CharacterGoalTargetConditionPrefilter.InvalidateForRelationMutation();
}

[HarmonyPatch]
internal static class CharacterGoalTargetConditionPrefilterRemoveRelationPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.RemoveRelation),
            new[] { typeof(DataContext), typeof(int), typeof(int) });

    // 删除关系后不能继续使用旧快照。
    private static void Postfix() =>
        CharacterGoalTargetConditionPrefilter.InvalidateForRelationMutation();
}

[HarmonyPatch]
internal static class CharacterGoalTargetConditionPrefilterRemoveAllGeneralRelationsPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.RemoveAllGeneralRelations),
            new[] { typeof(DataContext), typeof(int) });

    // 批量删除泛关系后不能继续使用旧快照。
    private static void Postfix() =>
        CharacterGoalTargetConditionPrefilter.InvalidateForRelationMutation();
}

[HarmonyPatch]
internal static class CharacterGoalTargetConditionPrefilterRemoveAllRelationsPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterDomain),
            nameof(CharacterDomain.RemoveAllRelations),
            new[] { typeof(DataContext), typeof(int), typeof(bool) });

    // 批量删除全部关系后不能继续使用旧快照。
    private static void Postfix() =>
        CharacterGoalTargetConditionPrefilter.InvalidateForRelationMutation();
}

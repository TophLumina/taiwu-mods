using System;
using System.Collections.Generic;
using System.Reflection;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.Common;
using GameData.Domains.Map;
using HarmonyLib;
using Redzen.Random;
using TaiwuOptimization.Runtime;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Patches;

[HarmonyPatch]
internal static class CharacterActionTargetLookupCacheScopePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            "OfflineUpdateCurrentGoalActions",
            new[] { typeof(DataContext), typeof(ActionPlanningData.ECurrentGoalType) });

    // 只在原版离线规划阶段启用候选查找索引；补全阶段仍走原版扫描。
    private static void Prefix(ActionPlanningData.ECurrentGoalType goalType)
    {
        CharacterActionTargetLookupCache.EnterOfflineCurrentGoalActions(goalType);
        CharacterGoalTargetConditionPrefilter.EnterOfflineCurrentGoalActions();
        CharacterActionTargetMatcherStageCache.EnterOfflineCurrentGoalActions();
    }

    private static Exception? Finalizer(Exception? __exception)
    {
        CharacterActionTargetMatcherStageCache.LeaveOfflineCurrentGoalActions();
        CharacterGoalTargetConditionPrefilter.LeaveOfflineCurrentGoalActions();
        CharacterActionTargetLookupCache.LeaveOfflineCurrentGoalActions();
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionTargetLookupCacheBlockPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            "AddCharactersInBlock",
            new[] { typeof(List<Character>), typeof(MapBlockData) });

    // SameBlock 查询直接从地块索引追加候选；失败时回退原版。
    private static bool Prefix(CharacterPlanningAgent __instance, List<Character> characters, MapBlockData mapBlockData) =>
        !CharacterActionTargetLookupCache.TryAddCharactersInBlock(__instance, characters, mapBlockData);
}

[HarmonyPatch]
internal static class CharacterActionTargetLookupCacheAreaPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            "AddCharactersInArea",
            new[] { typeof(List<Character>), typeof(short) });

    // SameArea 查询避免反复扫描地区内所有地块。
    private static bool Prefix(CharacterPlanningAgent __instance, List<Character> characters, short areaId) =>
        !CharacterActionTargetLookupCache.TryAddCharactersInArea(__instance, characters, areaId);
}

[HarmonyPatch]
internal static class CharacterActionTargetLookupCacheStatePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            "AddCharactersInState",
            new[] { typeof(List<Character>), typeof(sbyte) });

    // SameState 查询通常最重，直接使用 state -> charIds 索引。
    private static bool Prefix(CharacterPlanningAgent __instance, List<Character> characters, sbyte stateId) =>
        !CharacterActionTargetLookupCache.TryAddCharactersInState(__instance, characters, stateId);
}

[HarmonyPatch]
internal static class CharacterActionTargetLookupCacheBlockRangePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            "AddCharactersInBlockRange",
            new[] { typeof(List<Character>), typeof(Location), typeof(int) });

    // BlockRange 仍使用原版邻居地块查询，只把每个地块的人物扫描换成索引读取。
    private static bool Prefix(
        CharacterPlanningAgent __instance,
        List<Character> characters,
        Location location,
        int steps) =>
        !CharacterActionTargetLookupCache.TryAddCharactersInBlockRange(__instance, characters, location, steps);
}

[HarmonyPatch]
internal static class CharacterActionTargetLookupCacheSettlementPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            "AddCharactersInSettlementRange",
            new[] { typeof(List<Character>), typeof(Location) });

    // 聚落查询按 settlement location 懒缓存，避免同一聚落重复拼接 block 角色。
    private static bool Prefix(
        CharacterPlanningAgent __instance,
        List<Character> characters,
        Location settlementLocation) =>
        !CharacterActionTargetLookupCache.TryAddCharactersInSettlementRange(__instance, characters, settlementLocation);
}

[HarmonyPatch]
[HarmonyPriority(Priority.First)]
internal static class CharacterGoalTargetConditionPrefilterFilterPatch
{
    private static readonly AccessTools.FieldRef<CharacterPlanningAgent, PlanningGoalNode> CurrentPlanningGoalRef =
        AccessTools.FieldRefAccess<CharacterPlanningAgent, PlanningGoalNode>("_currPlanningGoal");

    private static readonly AccessTools.FieldRef<CharacterPlanningAgent, PlanningActionNode> CurrentPlanningActionRef =
        AccessTools.FieldRefAccess<CharacterPlanningAgent, PlanningActionNode>("_currPlanningAction");

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            "FilterActionTargets",
            new[]
            {
                typeof(IRandomSource),
                typeof(IReadOnlyList<Character>),
                typeof(ICollection<int>),
                typeof(Predicate<Character>),
                typeof(EPlanningActionCharacterSelector),
            });

    // 在原版 selector/predicate 过滤前缩小关系类目标候选；最终判断仍由原版逻辑完成。
    private static void Prefix(
        CharacterPlanningAgent __instance,
        ref IReadOnlyList<Character> selectableCharacters,
        out List<Character>? __state)
    {
        __state = null;
        try
        {
            if (CharacterGoalTargetConditionPrefilter.TryPrefilterCandidates(
                    __instance,
                    CurrentPlanningGoalRef(__instance),
                    CurrentPlanningActionRef(__instance),
                    selectableCharacters,
                    out IReadOnlyList<Character> filtered,
                    out List<Character>? rentedList))
            {
                selectableCharacters = filtered;
                __state = rentedList;
            }
        }
        catch (Exception exception)
        {
            // 预过滤只是加速路径，失败时必须保持原版候选列表。
            CharacterGoalTargetConditionPrefilter.RecordException(exception);
            __state = null;
        }
    }

    private static Exception? Finalizer(List<Character>? __state, Exception? __exception)
    {
        CharacterGoalTargetConditionPrefilter.ReturnCandidateList(__state);
        return __exception;
    }
}

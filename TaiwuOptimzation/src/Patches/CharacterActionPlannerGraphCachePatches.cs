using System.Collections.Generic;
using System.Reflection;
using Config;
using GameData.ActionPlanning;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.State;
using GameData.Common;
using HarmonyLib;
using TaiwuOptimization.Runtime;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Patches;

[HarmonyPatch(typeof(CharacterActionPlanner), nameof(CharacterActionPlanner.Initialize))]
internal static class CharacterActionPlannerGraphCacheWarmUpPatch
{
    // 原版配置图加载完成后预热静态邻接表。
    private static void Postfix(CharacterActionPlanner __instance)
    {
        CharacterActionPlannerGraphCache.Reset();
        CharacterActionPlannerGraphCache.WarmUp(__instance);
    }
}

[HarmonyPatch]
internal static class CharacterActionPlannerGraphCacheConditionPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(ActionPlanner<DataContext, CharacterStateMemory, Character, StateKey>),
            nameof(ActionPlanner<DataContext, CharacterStateMemory, Character, StateKey>.GetConditionConnectedActions),
            new[] { typeof(StateCondition<StateKey>) });

    // 原版每次都会扫描 effect -> action 表；这里替换为只读静态邻接表。
    private static bool Prefix(
        ActionPlanner<DataContext, CharacterStateMemory, Character, StateKey> __instance,
        StateCondition<StateKey> condition,
        ref IEnumerable<INode<Character, StateKey>> __result)
    {
        if (CharacterActionPlannerGraphCache.TryGetConditionConnectedActions(__instance, condition, out IEnumerable<INode<Character, StateKey>> actions))
        {
            __result = actions;
            return false;
        }

        return true;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlannerGraphCacheEffectPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(ActionPlanner<DataContext, CharacterStateMemory, Character, StateKey>),
            nameof(ActionPlanner<DataContext, CharacterStateMemory, Character, StateKey>.GetEffectConnectedActions),
            new[] { typeof(StateEffect<StateKey>) });

    // 与 condition 邻接表同源，保持公开查询接口也能复用静态快照。
    private static bool Prefix(
        ActionPlanner<DataContext, CharacterStateMemory, Character, StateKey> __instance,
        StateEffect<StateKey> effect,
        ref IEnumerable<INode<Character, StateKey>> __result)
    {
        if (CharacterActionPlannerGraphCache.TryGetEffectConnectedActions(__instance, effect, out IEnumerable<INode<Character, StateKey>> nodes))
        {
            __result = nodes;
            return false;
        }

        return true;
    }
}

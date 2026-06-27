using System;
using System.Collections.Generic;
using System.Reflection;
using Config;
using GameData.ActionPlanning.MonthlyAI;
using GameData.Common;
using GameData.Domains;
using GameData.Domains.Taiwu.Profession;
using HarmonyLib;
using TaiwuOptimization.Runtime;
using Character = GameData.Domains.Character.Character;

namespace TaiwuOptimization.Patches;

[HarmonyPatch]
internal static class CharacterPlanningAgentSelectActionTargetPatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled &&
        TaiwuOptimizationSettings.EnableCharacterActionPlanningOptimization;

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            nameof(CharacterPlanningAgent.SelectActionTarget),
            new[]
            {
                typeof(DataContext),
                typeof(Predicate<Character>),
                typeof(EPlanningActionCharacterSelector),
                typeof(EPlanningActionCharacterSelectRange),
                typeof(int),
            });

    /// <summary>
    /// 使用局部列表替代原版 `_targetCharIds`，避免 pathfinder 递归选目标时重入临时容器。
    /// </summary>
    private static bool Prefix(
        CharacterPlanningAgent __instance,
        DataContext context,
        Predicate<Character> predicate,
        EPlanningActionCharacterSelector selector,
        EPlanningActionCharacterSelectRange range,
        int rangeValue,
        ref Character? __result)
    {
        try
        {
            List<int> targets = new(16);
            __instance.GetAllActionTargets(context.Random, targets, predicate, selector, range, rangeValue);
            BoostTaiwuAsTargetIfNeeded(targets);
            if (targets.Count == 0)
            {
                __result = null;
                return false;
            }

            int charId = targets[context.Random.Next(targets.Count)];
            __result = DomainManager.Character.GetElement_Objects(charId);
            return false;
        }
        catch
        {
            // 任何异常都回退原版，避免 worker 线程异常导致过月等待屏障无法结束。
            return true;
        }
    }

    private static void BoostTaiwuAsTargetIfNeeded(List<int> targets)
    {
        int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
        if (targets.Contains(taiwuCharId) &&
            DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(34))
        {
            ProfessionSkillHandle.AristocratSkill_BoostTaiwuAsTargetInCollection(targets);
        }
    }
}

[HarmonyPatch]
internal static class CharacterPlanningAgentSelectActionTargetGroupPatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationEnabled &&
        TaiwuOptimizationSettings.EnableCharacterActionPlanningOptimization;

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            nameof(CharacterPlanningAgent.SelectActionTargetGroup),
            new[]
            {
                typeof(DataContext),
                typeof(Predicate<Character>),
                typeof(EPlanningActionCharacterSelector),
                typeof(int),
                typeof(EPlanningActionCharacterSelectRange),
                typeof(int),
            });

    /// <summary>
    /// 提前生成结果集合，避免原版 iterator 在 `yield` 之间长期占用 `_targetCharIds`。
    /// </summary>
    private static bool Prefix(
        CharacterPlanningAgent __instance,
        DataContext context,
        Predicate<Character> predicate,
        EPlanningActionCharacterSelector selector,
        int selectCount,
        EPlanningActionCharacterSelectRange range,
        int rangeValue,
        ref IEnumerable<Character> __result)
    {
        try
        {
            List<int> targets = new(16);
            __instance.GetAllActionTargets(context.Random, targets, predicate, selector, range, rangeValue);
            List<Character> result = new(Math.Min(selectCount, targets.Count));
            for (int i = 0; i < selectCount && targets.Count > 0; i++)
            {
                int index = context.Random.Next(targets.Count);
                int charId = targets[index];
                result.Add(DomainManager.Character.GetElement_Objects(charId));
                targets[index] = targets[^1];
                targets.RemoveAt(targets.Count - 1);
            }

            __result = result;
            return false;
        }
        catch
        {
            // 任何异常都回退原版，避免 worker 线程异常导致过月等待屏障无法结束。
            return true;
        }
    }
}

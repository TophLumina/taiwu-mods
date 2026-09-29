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
    private const int MaxPooledTargetListCapacity = 65536;

    [ThreadStatic]
    private static Stack<List<int>>? _targetListPool;

    internal static bool IsEnabled() =>
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

    /// <summary>用局部列表替代原版 `_targetCharIds`，避免 pathfinder 递归选目标时重入临时容器。</summary>
    private static bool Prefix(
        CharacterPlanningAgent __instance,
        DataContext context,
        Predicate<Character> predicate,
        EPlanningActionCharacterSelector selector,
        EPlanningActionCharacterSelectRange range,
        int rangeValue,
        ref Character? __result)
    {
        if (!IsEnabled())
        {
            return true;
        }

        List<int> targets = RentTargetList();
        try
        {
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
            // 任意异常都回退原版，避免 worker 线程异常导致过月等待屏障无法结束。
            return true;
        }
        finally
        {
            ReturnTargetList(targets);
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

    internal static List<int> RentTargetList()
    {
        Stack<List<int>>? pool = _targetListPool;
        if (pool is { Count: > 0 })
        {
            List<int> list = pool.Pop();
            list.Clear();
            return list;
        }

        return new List<int>(16);
    }

    internal static void ReturnTargetList(List<int> targets)
    {
        if (targets.Capacity > MaxPooledTargetListCapacity)
        {
            return;
        }

        targets.Clear();
        (_targetListPool ??= new Stack<List<int>>(2)).Push(targets);
    }
}

[HarmonyPatch]
internal static class CharacterPlanningAgentSelectActionTargetGroupPatch
{
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

    /// <summary>每个枚举器独占池化列表，保留原版按 MoveNext 逐个抽取目标的随机数顺序。</summary>
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
        if (!CharacterPlanningAgentSelectActionTargetPatch.IsEnabled())
        {
            return true;
        }

        __result = SelectTargets(__instance, context, predicate, selector, selectCount, range, rangeValue);
        return false;
    }

    private static IEnumerable<Character> SelectTargets(
        CharacterPlanningAgent agent,
        DataContext context,
        Predicate<Character> predicate,
        EPlanningActionCharacterSelector selector,
        int selectCount,
        EPlanningActionCharacterSelectRange range,
        int rangeValue)
    {
        List<int> targets = CharacterPlanningAgentSelectActionTargetPatch.RentTargetList();
        try
        {
            agent.GetAllActionTargets(context.Random, targets, predicate, selector, range, rangeValue);
            for (int i = 0; i < selectCount && targets.Count > 0; i++)
            {
                int index = context.Random.Next(targets.Count);
                int charId = targets[index];
                yield return DomainManager.Character.GetElement_Objects(charId);
                targets[index] = targets[^1];
                targets.RemoveAt(targets.Count - 1);
            }
        }
        finally
        {
            CharacterPlanningAgentSelectActionTargetPatch.ReturnTargetList(targets);
        }
    }
}

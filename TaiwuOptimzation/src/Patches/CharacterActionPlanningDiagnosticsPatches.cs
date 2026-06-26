using System;
using System.Collections.Generic;
using System.Reflection;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.ActionPlanning.State;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth;
using GameData.Domains.Character.Ai.ParallelAdvanceMonth.Definition;
using GameData.Domains.LegendaryBook;
using GameData.GameDataBridge;
using HarmonyLib;
using Redzen.Random;
using TaiwuOptimization.Runtime;

namespace TaiwuOptimization.Patches;

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsParallelActionPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(ParallelActionManager),
            nameof(ParallelActionManager.Execute),
            new[] { typeof(DataMonitorManager), typeof(ICharacterParallelAction) });

    // 记录原版 CharacterParallelAction 整段耗时，包含 worker 调度和结果补全。
    private static void Prefix(ICharacterParallelAction action, out State __state)
    {
        if (TryGetStage(action, out __state))
        {
            __state.StartTicks = CharacterActionPlanningDiagnostics.BeginParallelStage(__state.Stage);
            return;
        }

        __state = default;
    }

    private static void Postfix(State __state) =>
        CharacterActionPlanningDiagnostics.EndParallelStage(__state.Stage, __state.StartTicks);

    private static bool TryGetStage(ICharacterParallelAction action, out State state)
    {
        Type type = action.GetType();
        if (type == typeof(UpdateCharacterMission))
        {
            state = new State(CharacterActionPlanningParallelStage.UpdateCharacterMission);
            return true;
        }

        if (type == typeof(UpdateCharacterGoal))
        {
            state = new State(CharacterActionPlanningParallelStage.UpdateCharacterGoal);
            return true;
        }

        if (type == typeof(UpdatePrimaryGoalAndActions))
        {
            state = new State(CharacterActionPlanningParallelStage.UpdatePrimaryGoalAndActions);
            return true;
        }

        if (type == typeof(UpdateSecondaryGoalAndActions))
        {
            state = new State(CharacterActionPlanningParallelStage.UpdateSecondaryGoalAndActions);
            return true;
        }

        state = default;
        return false;
    }

    private struct State
    {
        public readonly CharacterActionPlanningParallelStage Stage;
        public long StartTicks;

        public State(CharacterActionPlanningParallelStage stage)
        {
            Stage = stage;
            StartTicks = 0;
        }
    }
}

[HarmonyPatch(typeof(CharacterDomain), nameof(CharacterDomain.UpdateInfectedCharacterActions))]
internal static class CharacterActionPlanningDiagnosticsInfectedActionsPatch
{
    // 记录感染者特殊行动更新耗时。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginParallelStage(
            CharacterActionPlanningParallelStage.UpdateInfectedCharacterActions);

    private static void Postfix(long __state) =>
        CharacterActionPlanningDiagnostics.EndParallelStage(
            CharacterActionPlanningParallelStage.UpdateInfectedCharacterActions,
            __state);
}

[HarmonyPatch(typeof(LegendaryBookDomain), nameof(LegendaryBookDomain.UpdateLegendaryBookOwnersActions))]
internal static class CharacterActionPlanningDiagnosticsLegendaryBookActionsPatch
{
    // 记录奇书持有者特殊行动更新耗时。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginParallelStage(
            CharacterActionPlanningParallelStage.UpdateLegendaryBookOwnersActions);

    private static void Postfix(long __state) =>
        CharacterActionPlanningDiagnostics.EndParallelStage(
            CharacterActionPlanningParallelStage.UpdateLegendaryBookOwnersActions,
            __state);
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsOfflineCurrentGoalActionsPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            "OfflineUpdateCurrentGoalActions",
            new[] { typeof(DataContext), typeof(ActionPlanningData.ECurrentGoalType) });

    // 记录 primary/secondary 离线目标行动更新外层耗时。
    private static void Prefix(ActionPlanningData.ECurrentGoalType goalType, out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginOfflineCurrentGoalActions(goalType);

    private static Exception? Finalizer(ActionPlanningData.ECurrentGoalType goalType, long __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndOfflineCurrentGoalActions(goalType, __state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsComplementCurrentGoalActionsPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            "ComplementUpdateCurrentGoalActions",
            new[] { typeof(DataContext), typeof(ActionPlanningData.ECurrentGoalType) });

    // 记录原版并行结果补全阶段内的行动执行耗时。
    private static void Prefix(ActionPlanningData.ECurrentGoalType goalType, out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginComplementCurrentGoalActions(goalType);

    private static Exception? Finalizer(ActionPlanningData.ECurrentGoalType goalType, long __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndComplementCurrentGoalActions(goalType, __state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsOfflineUpdateGoalPlanPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            "OfflineUpdateGoalPlan",
            new[] { typeof(DataContext), typeof(CharacterGoalData) });

    // 记录完整 pathfinder plan 生成耗时。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static void Postfix(long __state) =>
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.OfflineUpdateGoalPlan,
            __state);
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsReassessPlanPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            "ReassessPlan",
            new[] { typeof(DataContext), typeof(CharacterGoalData) });

    // 记录已有 plan 复核耗时。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static void Postfix(long __state) =>
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.ReassessPlan,
            __state);
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsOfflineCreateNextActionPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            "OfflineCreateNextAction",
            new[] { typeof(DataContext), typeof(CharacterGoalData) });

    // 记录从 plan 中创建下一步 action 的耗时。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static void Postfix(long __state) =>
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.OfflineCreateNextAction,
            __state);
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsExecuteActionPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            "ExecuteAction",
            new[]
            {
                typeof(DataContext),
                typeof(ActionPlanningData.ECurrentGoalType),
                typeof(CharacterGoalData),
                typeof(CharacterActionData),
            });

    // 记录月行动真正执行耗时。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static void Postfix(long __state) =>
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.ExecuteAction,
            __state);
}

[HarmonyPatch(typeof(CharacterPlanningAgent), nameof(CharacterPlanningAgent.CheckPrerequisites))]
internal static class CharacterActionPlanningDiagnosticsCheckPrerequisitesPatch
{
    // 记录 planner 搜索时检查 action/goal 前置条件的耗时。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static void Postfix(long __state) =>
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.CheckPrerequisites,
            __state);
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsGetCharactersInSelectRangePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            "GetCharactersInSelectRange",
            new[] { typeof(EPlanningActionCharacterSelectRange), typeof(int) });

    // 记录候选目标列表构造耗时和候选数量。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static void Postfix(IReadOnlyList<Character> __result, long __state) =>
        CharacterActionPlanningDiagnostics.EndGetCharactersInSelectRange(
            __state,
            __result?.Count ?? 0);
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsFilterActionTargetsPatch
{
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

    // 记录候选目标经过关系、predicate、selector 过滤的耗时和输入/输出规模。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static void Postfix(IReadOnlyList<Character> selectableCharacters, ICollection<int> result, long __state) =>
        CharacterActionPlanningDiagnostics.EndFilterActionTargets(
            __state,
            selectableCharacters?.Count ?? 0,
            result?.Count ?? 0);
}

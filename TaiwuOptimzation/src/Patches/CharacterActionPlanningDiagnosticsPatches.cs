using System;
using System.Collections.Generic;
using System.Reflection;
using GameData.ActionPlanning;
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
    private static void Prefix(CharacterPlanningAgent __instance, out ActionTargetDiagnosticsState __state)
    {
        long startTicks = CharacterActionPlanningDiagnostics.BeginGoalStep();
        __state = startTicks == 0
            ? default
            : new ActionTargetDiagnosticsState(
                startTicks,
                CharacterActionPlanningDiagnosticsPatchHelper.GetCurrentActionInfo(__instance));
    }

    private static void Postfix(
        CharacterPlanningAgent __instance,
        IReadOnlyList<Character> selectableCharacters,
        ICollection<int> result,
        ActionTargetDiagnosticsState __state)
    {
        CharacterActionPlanningDiagnostics.EndFilterActionTargets(
            __state.StartTicks,
            selectableCharacters?.Count ?? 0,
            result?.Count ?? 0,
            __state.ActionTemplateId,
            __state.Selector,
            __state.Range,
            __state.RangeValue);
        if (__state.StartTicks != 0)
        {
            Character selfChar = __instance.Object;
            if (selfChar != null)
            {
                CharacterActionPlanningDiagnostics.RecordRelationPrefilterCandidates(
                    selfChar.GetId(),
                    selectableCharacters,
                    __state.ActionTemplateId,
                    __state.Selector,
                    __state.Range,
                    __state.RangeValue);
            }
        }
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsPlannerPlanPatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled;

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterActionPlanner),
            nameof(CharacterActionPlanner.Plan),
            new[] { typeof(DataContext), typeof(IAgent<Character, StateKey>), typeof(int) });

    // 记录原版 `CharacterActionPlanner.Plan` 外层耗时，便于和 `OfflineUpdateGoalPlan` 区分初始化成本。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.CharacterActionPlannerPlan,
            __state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsPlannerReassessPatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled;

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterActionPlanner),
            nameof(CharacterActionPlanner.ReassessPlan),
            new[] { typeof(DataContext), typeof(IAgent<Character, StateKey>), typeof(bool).MakeByRefType() });

    // 记录原版 `CharacterActionPlanner.ReassessPlan` 外层耗时。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.CharacterActionPlannerReassess,
            __state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsWeightBasedFindPathPatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled;

    private static MethodBase TargetMethod()
    {
        Type pathfinderType = typeof(WeightBasedPathfinder<,,>).MakeGenericType(
            typeof(CharacterStateMemory),
            typeof(Character),
            typeof(StateKey));
        return AccessTools.Method(
            pathfinderType,
            nameof(WeightBasedPathfinder<CharacterStateMemory, Character, StateKey>.FindPath),
            new[]
            {
                typeof(IAgent<Character, StateKey>),
                typeof(IGoal<Character, StateKey>),
                typeof(IList<INode<Character, StateKey>>),
                typeof(int),
            });
    }

    // 记录权重 pathfinder 一次完整寻路耗时。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.WeightBasedFindPath,
            __state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsWeightBasedFindPathRecursivePatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled;

    private static MethodBase TargetMethod()
    {
        Type pathfinderType = typeof(WeightBasedPathfinder<,,>).MakeGenericType(
            typeof(CharacterStateMemory),
            typeof(Character),
            typeof(StateKey));
        return AccessTools.Method(
            pathfinderType,
            "FindPathRecursive",
            new[]
            {
                typeof(IAgent<Character, StateKey>),
                typeof(INode<Character, StateKey>),
                typeof(IStateMemory<Character, StateKey>),
                typeof(IGoal<Character, StateKey>),
                typeof(IList<INode<Character, StateKey>>),
                typeof(int),
            });
    }

    // 记录递归搜索层的累计耗时；此项会包含子递归时间，主要看 calls/max 和量级。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.WeightBasedFindPathRecursive,
            __state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsUnsatisfiedStateCountPatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled;

    private static MethodBase TargetMethod()
    {
        Type pathfinderType = typeof(WeightBasedPathfinder<,,>).MakeGenericType(
            typeof(CharacterStateMemory),
            typeof(Character),
            typeof(StateKey));
        return AccessTools.Method(
            pathfinderType,
            "GetUnsatisfiedStateCount",
            new[]
            {
                typeof(IAgent<Character, StateKey>),
                typeof(IStateMemory<Character, StateKey>),
            });
    }

    // 记录 pathfinder 每次统计未满足状态条件的耗时。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.WeightBasedGetUnsatisfiedStateCount,
            __state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsStateMemoryCheckConditionPatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled;

    private static MethodBase TargetMethod()
    {
        Type stateMemoryType = typeof(StateMemory<,>).MakeGenericType(typeof(Character), typeof(StateKey));
        return AccessTools.Method(
            stateMemoryType,
            nameof(StateMemory<Character, StateKey>.CheckCondition),
            new[] { typeof(IAgent<Character, StateKey>), typeof(StateConditionAndValue<StateKey>) });
    }

    // 记录状态条件判定耗时；它会触发 `CalcCurrentState` 和传感器查询。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.StateMemoryCheckCondition,
            __state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsPrepareContextPatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled;

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            nameof(CharacterPlanningAgent.PrepareContext),
            new[]
            {
                typeof(IStateMemory<Character, StateKey>),
                typeof(INode<Character, StateKey>),
                typeof(INode<Character, StateKey>),
                typeof(INode<Character, StateKey>),
            });

    // 记录进入下一行动节点前准备上下文、选择目标角色的耗时。
    private static void Prefix(INode<Character, StateKey> nextNode, out ActionTargetDiagnosticsState __state)
    {
        long startTicks = CharacterActionPlanningDiagnostics.BeginGoalStep();
        __state = startTicks == 0
            ? default
            : new ActionTargetDiagnosticsState(
                startTicks,
                CharacterActionPlanningDiagnosticsPatchHelper.GetActionInfo(nextNode));
    }

    private static Exception? Finalizer(ActionTargetDiagnosticsState __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndPrepareContext(
            __state.StartTicks,
            __state.ActionTemplateId,
            __state.Selector,
            __state.Range,
            __state.RangeValue);
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsCalcCurrentStatePatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled;

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            nameof(CharacterPlanningAgent.CalcCurrentState),
            new[] { typeof(IStateMemory<Character, StateKey>), typeof(StateKey) });

    // 记录规划传感器实际计算状态值的耗时。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.CalcCurrentState,
            __state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsMatchTargetCharacterPatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled;

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            "MatchTargetCharacter",
            new[] { typeof(Character) });

    // 记录候选角色 predicate 中目标匹配的整体耗时。
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginGoalStep();

    private static Exception? Finalizer(long __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndGoalStep(
            CharacterActionPlanningStep.MatchTargetCharacter,
            __state);
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsMatchTargetCharacterByConditionsPatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled;

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            nameof(CharacterPlanningAgent.MatchTargetCharacterByConditions),
            new[]
            {
                typeof(Character),
                typeof(Character),
                typeof(ContextArgGroupHandle),
                typeof(StateConditionAndValue<StateKey>[]),
            });

    // 记录目标角色条件数组逐项匹配的耗时，并归因到当前 goal/action。
    private static void Prefix(
        StateConditionAndValue<StateKey>[] conditions,
        out TargetConditionDiagnosticsState __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginTargetConditions(conditions);

    private static Exception? Finalizer(
        Character selfChar,
        Character targetChar,
        StateConditionAndValue<StateKey>[] conditions,
        TargetConditionDiagnosticsState __state,
        bool __result,
        Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndTargetConditions(__state, conditions, __result, selfChar, targetChar);
        return __exception;
    }
}

[HarmonyPatch(typeof(PlanningGoalNode), nameof(PlanningGoalNode.MatchTargetCharacter))]
internal static class CharacterActionPlanningDiagnosticsGoalTargetMatchPatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled;

    // 记录 goal 目标角色匹配耗时，判断 goal 条件是否是候选过滤热点。
    private static void Prefix(
        PlanningGoalNode __instance,
        DataContext context,
        out TargetMatchDiagnosticsState __state)
    {
        int actionTemplateId = context?.PlanningAgent == null
            ? -1
            : CharacterActionPlanningDiagnosticsPatchHelper.GetCurrentActionInfo(context.PlanningAgent).ActionTemplateId;
        __state = CharacterActionPlanningDiagnostics.BeginGoalTargetMatch(
            __instance.Template.TemplateId,
            actionTemplateId);
    }

    private static Exception? Finalizer(
        TargetMatchDiagnosticsState __state,
        bool __result,
        Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndGoalTargetMatch(__state, __result);
        return __exception;
    }
}

[HarmonyPatch(typeof(PlanningActionNode), nameof(PlanningActionNode.MatchTargetCharacter))]
internal static class CharacterActionPlanningDiagnosticsActionTargetMatchPatch
{
    private static bool Prepare() =>
        TaiwuOptimizationSettings.AdvanceMonthOptimizationDiagnosticsEnabled;

    // 记录 action 目标角色匹配耗时，包含 TargetMatcher、配置条件和实现委托。
    private static void Prefix(PlanningActionNode __instance, out TargetMatchDiagnosticsState __state)
    {
        var template = __instance.Template;
        __state = CharacterActionPlanningDiagnostics.BeginActionTargetMatch(
            template.TemplateId,
            template.CharacterSelector,
            template.CharacterSelectRange,
            template.SelectRangeValue);
    }

    private static Exception? Finalizer(
        TargetMatchDiagnosticsState __state,
        bool __result,
        Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndActionTargetMatch(__state, __result);
        return __exception;
    }
}

internal static class CharacterActionPlanningDiagnosticsPatchHelper
{
    private static readonly AccessTools.FieldRef<CharacterPlanningAgent, PlanningActionNode> CurrentPlanningActionRef =
        AccessTools.FieldRefAccess<CharacterPlanningAgent, PlanningActionNode>("_currPlanningAction");

    public static ActionTargetDiagnosticsState GetCurrentActionInfo(CharacterPlanningAgent agent) =>
        CreateActionInfo(CurrentPlanningActionRef(agent), 0);

    public static ActionTargetDiagnosticsState GetActionInfo(INode<Character, StateKey> node) =>
        CreateActionInfo(node as PlanningActionNode, 0);

    private static ActionTargetDiagnosticsState CreateActionInfo(PlanningActionNode? action, long startTicks)
    {
        if (action == null)
        {
            return new ActionTargetDiagnosticsState(startTicks);
        }

        var template = action.Template;
        return new ActionTargetDiagnosticsState(
            startTicks,
            template.TemplateId,
            template.CharacterSelector,
            template.CharacterSelectRange,
            template.SelectRangeValue);
    }
}

internal readonly struct ActionTargetDiagnosticsState
{
    public readonly long StartTicks;
    public readonly int ActionTemplateId;
    public readonly EPlanningActionCharacterSelector Selector;
    public readonly EPlanningActionCharacterSelectRange Range;
    public readonly int RangeValue;

    public ActionTargetDiagnosticsState(long startTicks)
    {
        StartTicks = startTicks;
        ActionTemplateId = -1;
        Selector = default;
        Range = default;
        RangeValue = 0;
    }

    public ActionTargetDiagnosticsState(long startTicks, ActionTargetDiagnosticsState actionInfo)
    {
        StartTicks = startTicks;
        ActionTemplateId = actionInfo.ActionTemplateId;
        Selector = actionInfo.Selector;
        Range = actionInfo.Range;
        RangeValue = actionInfo.RangeValue;
    }

    public ActionTargetDiagnosticsState(
        long startTicks,
        int actionTemplateId,
        EPlanningActionCharacterSelector selector,
        EPlanningActionCharacterSelectRange range,
        int rangeValue)
    {
        StartTicks = startTicks;
        ActionTemplateId = actionTemplateId;
        Selector = selector;
        Range = range;
        RangeValue = rangeValue;
    }
}

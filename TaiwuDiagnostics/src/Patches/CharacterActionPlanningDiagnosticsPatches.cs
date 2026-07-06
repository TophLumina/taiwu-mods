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
using GameData.Domains.World;
using GameData.GameDataBridge;
using HarmonyLib;
using Redzen.Random;
using TaiwuDiagnostics.Runtime;

namespace TaiwuDiagnostics.Patches;

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsAdvanceMonthExecutePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(WorldDomain),
            "AdvanceMonth_Execute",
            new[] { typeof(DataContext), typeof(DataMonitorManager) });

    private static void Prefix() =>
        CharacterActionPlanningDiagnostics.BeginAdvanceMonthExecute();

    private static Exception? Finalizer(Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndAdvanceMonthExecute();
        return __exception;
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsAdvanceMonthStatePatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(WorldDomain),
            "SetAndNotifyAdvancingMonthState",
            new[] { typeof(DataContext), typeof(sbyte), typeof(DataMonitorManager) });

    private static void Prefix(sbyte value)
    {
        if (value == 8)
        {
            CharacterActionPlanningDiagnostics.BeginCharacterActionPlanningStage();
        }
        else if (value == 11)
        {
            CharacterActionPlanningDiagnostics.EndCharacterActionPlanningStage();
        }
    }
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsParallelActionPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(ParallelActionManager),
            nameof(ParallelActionManager.Execute),
            new[] { typeof(DataMonitorManager), typeof(ICharacterParallelAction) });

    // 璁板綍鍘熺増 CharacterParallelAction 鏁存鑰楁椂锛屽寘鍚?worker 璋冨害鍜岀粨鏋滆ˉ鍏ㄣ€?
    private static void Prefix(ICharacterParallelAction action, out State __state)
    {
        Type type = action.GetType();
        string actionTypeName = type.FullName ?? type.Name;
        __state = new State(actionTypeName)
        {
            ActionTypeStartTicks = CharacterActionPlanningDiagnostics.BeginParallelAction(actionTypeName),
        };

        if (TryGetStage(type, out CharacterActionPlanningParallelStage stage))
        {
            __state.HasStage = true;
            __state.Stage = stage;
            __state.StageStartTicks = CharacterActionPlanningDiagnostics.BeginParallelStage(stage);
        }
    }

    private static void Postfix(State __state)
    {
        CharacterActionPlanningDiagnostics.EndParallelAction(__state.ActionTypeName, __state.ActionTypeStartTicks);
        if (__state.HasStage)
        {
            CharacterActionPlanningDiagnostics.EndParallelStage(__state.Stage, __state.StageStartTicks);
        }
    }

    private static bool TryGetStage(Type type, out CharacterActionPlanningParallelStage stage)
    {
        string typeName = type.Name;
        if (type == typeof(UpdateCharacterMission) || typeName.Contains(nameof(UpdateCharacterMission), StringComparison.Ordinal))
        {
            stage = CharacterActionPlanningParallelStage.UpdateCharacterMission;
            return true;
        }

        if (type == typeof(UpdateCharacterGoal) || typeName.Contains(nameof(UpdateCharacterGoal), StringComparison.Ordinal))
        {
            stage = CharacterActionPlanningParallelStage.UpdateCharacterGoal;
            return true;
        }

        if (type == typeof(UpdatePrimaryGoalAndActions) || typeName.Contains(nameof(UpdatePrimaryGoalAndActions), StringComparison.Ordinal))
        {
            stage = CharacterActionPlanningParallelStage.UpdatePrimaryGoalAndActions;
            return true;
        }

        if (type == typeof(UpdateSecondaryGoalAndActions) || typeName.Contains(nameof(UpdateSecondaryGoalAndActions), StringComparison.Ordinal))
        {
            stage = CharacterActionPlanningParallelStage.UpdateSecondaryGoalAndActions;
            return true;
        }

        stage = default;
        return false;
    }

    private struct State
    {
        public readonly string ActionTypeName;
        public long ActionTypeStartTicks;
        public bool HasStage;
        public CharacterActionPlanningParallelStage Stage;
        public long StageStartTicks;

        public State(string actionTypeName)
        {
            ActionTypeName = actionTypeName;
            ActionTypeStartTicks = 0;
            HasStage = false;
            Stage = default;
            StageStartTicks = 0;
        }
    }
}

[HarmonyPatch(typeof(CharacterDomain), nameof(CharacterDomain.UpdateInfectedCharacterActions))]
internal static class CharacterActionPlanningDiagnosticsInfectedActionsPatch
{
    // 璁板綍鎰熸煋鑰呯壒娈婅鍔ㄦ洿鏂拌€楁椂銆?
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
    // 璁板綍濂囦功鎸佹湁鑰呯壒娈婅鍔ㄦ洿鏂拌€楁椂銆?
    private static void Prefix(out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginParallelStage(
            CharacterActionPlanningParallelStage.UpdateLegendaryBookOwnersActions);

    private static void Postfix(long __state) =>
        CharacterActionPlanningDiagnostics.EndParallelStage(
            CharacterActionPlanningParallelStage.UpdateLegendaryBookOwnersActions,
            __state);
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsOfflineUpdateCurrentGoalActionsPatch
{
    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(Character),
            "OfflineUpdateCurrentGoalActions",
            new[] { typeof(DataContext), typeof(ActionPlanningData.ECurrentGoalType) });

    // 璁板綍 primary/secondary 绂荤嚎鐩爣琛屽姩鏇存柊澶栧眰鑰楁椂銆?
    private static void Prefix(ActionPlanningData.ECurrentGoalType goalType, out long __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginOfflineUpdateCurrentGoalActions(goalType);

    private static Exception? Finalizer(ActionPlanningData.ECurrentGoalType goalType, long __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndOfflineUpdateCurrentGoalActions(goalType, __state);
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

    // 璁板綍鍘熺増骞惰缁撴灉琛ュ叏闃舵鍐呯殑琛屽姩鎵ц鑰楁椂銆?
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

    // 璁板綍瀹屾暣 pathfinder plan 鐢熸垚鑰楁椂銆?
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

    // 璁板綍宸叉湁 plan 澶嶆牳鑰楁椂銆?
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

    // 璁板綍浠?plan 涓垱寤轰笅涓€姝?action 鐨勮€楁椂銆?
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

    // 璁板綍鏈堣鍔ㄧ湡姝ｆ墽琛岃€楁椂銆?
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
    // 璁板綍 planner 鎼滅储鏃舵鏌?action/goal 鍓嶇疆鏉′欢鐨勮€楁椂銆?
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

    // 璁板綍鍊欓€夌洰鏍囧垪琛ㄦ瀯閫犺€楁椂鍜屽€欓€夋暟閲忋€?
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

    // 璁板綍鍊欓€夌洰鏍囩粡杩囧叧绯汇€乸redicate銆乻elector 杩囨护鐨勮€楁椂鍜岃緭鍏?杈撳嚭瑙勬ā銆?
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
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics;

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterActionPlanner),
            nameof(CharacterActionPlanner.Plan),
            new[] { typeof(DataContext), typeof(IAgent<Character, StateKey>), typeof(int) });

    // 璁板綍鍘熺増 `CharacterActionPlanner.Plan` 澶栧眰鑰楁椂锛屼究浜庡拰 `OfflineUpdateGoalPlan` 鍖哄垎鍒濆鍖栨垚鏈€?
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
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics;

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterActionPlanner),
            nameof(CharacterActionPlanner.ReassessPlan),
            new[] { typeof(DataContext), typeof(IAgent<Character, StateKey>), typeof(bool).MakeByRefType() });

    // 璁板綍鍘熺増 `CharacterActionPlanner.ReassessPlan` 澶栧眰鑰楁椂銆?
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
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics;

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

    // 璁板綍鏉冮噸 pathfinder 涓€娆″畬鏁村璺€楁椂銆?
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
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics;

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

    // 璁板綍閫掑綊鎼滅储灞傜殑绱鑰楁椂锛涙椤逛細鍖呭惈瀛愰€掑綊鏃堕棿锛屼富瑕佺湅 calls/max 鍜岄噺绾с€?
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
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics;

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

    // 璁板綍 pathfinder 姣忔缁熻鏈弧瓒崇姸鎬佹潯浠剁殑鑰楁椂銆?
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
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics;

    private static MethodBase TargetMethod()
    {
        Type stateMemoryType = typeof(StateMemory<,>).MakeGenericType(typeof(Character), typeof(StateKey));
        return AccessTools.Method(
            stateMemoryType,
            nameof(StateMemory<Character, StateKey>.CheckCondition),
            new[] { typeof(IAgent<Character, StateKey>), typeof(StateConditionAndValue<StateKey>) });
    }

    // 璁板綍鐘舵€佹潯浠跺垽瀹氳€楁椂锛涘畠浼氳Е鍙?`CalcCurrentState` 鍜屼紶鎰熷櫒鏌ヨ銆?
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
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics;

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

    // 璁板綍杩涘叆涓嬩竴琛屽姩鑺傜偣鍓嶅噯澶囦笂涓嬫枃銆侀€夋嫨鐩爣瑙掕壊鐨勮€楁椂銆?
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
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics;

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            nameof(CharacterPlanningAgent.CalcCurrentState),
            new[] { typeof(IStateMemory<Character, StateKey>), typeof(StateKey) });

    // 璁板綍瑙勫垝浼犳劅鍣ㄥ疄闄呰绠楃姸鎬佸€肩殑鑰楁椂銆?
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
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics;

    private static MethodBase TargetMethod() =>
        AccessTools.Method(
            typeof(CharacterPlanningAgent),
            "MatchTargetCharacter",
            new[] { typeof(Character) });

    // 璁板綍鍊欓€夎鑹?predicate 涓洰鏍囧尮閰嶇殑鏁翠綋鑰楁椂銆?
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
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics;

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

    // 璁板綍鐩爣瑙掕壊鏉′欢鏁扮粍閫愰」鍖归厤鐨勮€楁椂锛屽苟褰掑洜鍒板綋鍓?goal/action銆?
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
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics;

    // 璁板綍 goal 鐩爣瑙掕壊鍖归厤鑰楁椂锛屽垽鏂?goal 鏉′欢鏄惁鏄€欓€夎繃婊ょ儹鐐广€?
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
        TaiwuDiagnosticsSettings.CaptureAdvanceMonthPlanningDiagnostics;

    // 璁板綍 action 鐩爣瑙掕壊鍖归厤鑰楁椂锛屽寘鍚?TargetMatcher銆侀厤缃潯浠跺拰瀹炵幇濮旀墭銆?
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

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsParallelActionInvocationPatch
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        Type actionInterface = typeof(ICharacterParallelAction);
        foreach (Type type in actionInterface.Assembly.GetTypes())
        {
            if (type.IsAbstract || !actionInterface.IsAssignableFrom(type))
            {
                continue;
            }

            foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                if (method.DeclaringType == type && IsActionEntry(method.Name))
                {
                    yield return method;
                }
            }
        }
    }

    private static void Prefix(
        ICharacterParallelAction __instance,
        MethodBase __originalMethod,
        out ParallelActionInvocationState __state)
    {
        string actionTypeName = __instance.GetType().FullName ?? __instance.GetType().Name;
        __state = CharacterActionPlanningDiagnostics.BeginParallelActionInvocation(
            actionTypeName,
            __originalMethod.Name);
    }

    private static Exception? Finalizer(ParallelActionInvocationState __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndParallelActionInvocation(__state);
        return __exception;
    }

    private static bool IsActionEntry(string methodName) =>
        methodName is
            "Execute" or
            "KidnappedExecute" or
            "PrisonerExecute" or
            "TaiwuExecute" or
            "GearMateExecute" or
            "InfectedExecute";
}

[HarmonyPatch]
internal static class CharacterActionPlanningDiagnosticsPeriAdvanceMonthMethodPatch
{
    private static IEnumerable<MethodBase> TargetMethods()
    {
        foreach (MethodInfo method in typeof(Character).GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            if (method.Name.StartsWith("PeriAdvanceMonth_", StringComparison.Ordinal))
            {
                yield return method;
            }
        }
    }

    private static void Prefix(MethodBase __originalMethod, out CharacterMonthlyMethodState __state) =>
        __state = CharacterActionPlanningDiagnostics.BeginCharacterMonthlyMethod(__originalMethod.Name);

    private static Exception? Finalizer(CharacterMonthlyMethodState __state, Exception? __exception)
    {
        CharacterActionPlanningDiagnostics.EndCharacterMonthlyMethod(__state);
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



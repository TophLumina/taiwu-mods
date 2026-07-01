using Config;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.Utilities;
using Character = GameData.Domains.Character.Character;

namespace TaiwuRemoveAILimitation.Runtime;

internal readonly struct NpcActionCreationLogState
{
    public readonly int ActionTemplateId;
    public readonly int GoalTemplateId;
    public readonly sbyte GoalState;

    public NpcActionCreationLogState(int actionTemplateId, int goalTemplateId, sbyte goalState)
    {
        ActionTemplateId = actionTemplateId;
        GoalTemplateId = goalTemplateId;
        GoalState = goalState;
    }
}

internal readonly struct NpcActionExecutionLogState
{
    public readonly int ActionTemplateId;
    public readonly int ActionState;

    public NpcActionExecutionLogState(int actionTemplateId, int actionState)
    {
        ActionTemplateId = actionTemplateId;
        ActionState = actionState;
    }
}

internal static class NpcActionLimitationRemovalLog
{
    private const string LogTag = "TaiwuRemoveAILimitation";

    public static bool Enabled => TaiwuRemoveAILimitationSettings.EnableNpcActionLimitationRemovalLog;

    public static void LogReachableBypass(INode<Character, StateKey> node)
    {
        if (!Enabled)
        {
            return;
        }

        if (node is PlanningActionNode actionNode)
        {
            AdaptableLog.TagInfo(LogTag,
                $"ReachableBypass action={FormatAction(actionNode.Template.TemplateId)}");
        }
        else if (node is PlanningGoalNode goalNode)
        {
            AdaptableLog.TagInfo(LogTag,
                $"ReachableBypass goal={FormatGoal(goalNode.Template.TemplateId)}");
        }
    }

    public static void LogActionCreation(
        Character character,
        NpcActionCreationLogState state,
        CharacterActionData? actionData)
    {
        if (!Enabled || !NpcActionLimitationRemoval.IsBypassedAction(state.ActionTemplateId))
        {
            return;
        }

        string result = actionData == null ? "failed" : "succeeded";
        AdaptableLog.TagInfo(LogTag,
            $"CreateAction {result}: charId={FormatCharacterId(character)}, " +
            $"actionId={state.ActionTemplateId}, goalId={state.GoalTemplateId}, state={state.GoalState}");
    }

    public static void LogActionExecution(
        Character character,
        NpcActionExecutionLogState state,
        CharacterActionData actionData,
        CharacterActionData? result)
    {
        if (!Enabled || !NpcActionLimitationRemoval.IsBypassedAction(state.ActionTemplateId))
        {
            return;
        }

        bool finishedNow = state.ActionState != (int)CharacterActionData.EActionState.Finished &&
                           actionData.State == CharacterActionData.EActionState.Finished;
        if (!finishedNow)
        {
            return;
        }

        string next = result == null
            ? "no-next-action"
            : result == actionData
                ? "same-action"
                : $"next={FormatAction(result.ActionTemplateId)}";
        AdaptableLog.TagInfo(LogTag,
            $"ExecuteAction finished: char={FormatCharacter(character)}, " +
            $"action={FormatAction(state.ActionTemplateId)}, target={FormatTargets(actionData)}, {next}");
    }

    public static string FormatAction(int actionTemplateId)
    {
        string name = SafeGetActionName(actionTemplateId);
        return $"{name}(A{actionTemplateId})";
    }

    private static string FormatGoal(int goalTemplateId)
    {
        string name = SafeGetGoalName(goalTemplateId);
        return $"{name}(G{goalTemplateId})";
    }

    private static string FormatCharacter(Character character)
    {
        return character == null ? "<null>" : $"{character}(id={character.GetId()})";
    }

    private static int FormatCharacterId(Character character)
    {
        return character?.GetId() ?? -1;
    }

    private static string FormatTargets(CharacterActionData? actionData)
    {
        if (actionData == null)
        {
            return "<none>";
        }

        if (actionData.TargetCharId >= 0)
        {
            return $"char:{actionData.TargetCharId}";
        }

        if (actionData.TargetCharIds.Length > 0)
        {
            return $"chars:{string.Join(",", actionData.TargetCharIds)}";
        }

        if (actionData.TargetLocation.IsValid())
        {
            return $"location:{actionData.TargetLocation}";
        }

        return "<none>";
    }

    private static string SafeGetActionName(int actionTemplateId)
    {
        try
        {
            return PlanningAction.Instance.GetRefName(actionTemplateId);
        }
        catch
        {
            return "UnknownAction";
        }
    }

    private static string SafeGetGoalName(int goalTemplateId)
    {
        try
        {
            return PlanningGoal.Instance.GetRefName(goalTemplateId);
        }
        catch
        {
            return "UnknownGoal";
        }
    }
}

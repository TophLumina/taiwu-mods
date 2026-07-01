using System.Linq;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.MonthlyAI;
using GameData.ActionPlanning.MonthlyAI.Node;
using GameData.ActionPlanning.State;
using GameData.Domains.Character;

namespace TaiwuRemoveAILimitation.Runtime;

internal static class NpcActionLimitationRemoval
{
    private const int ReadingExpAvailabilityState = 599;

    public static bool CheckNodeReachable(
        CharacterActionPlanner planner,
        INode<Character, StateKey> node)
    {
        bool allowedNoneSensorState = false;
        foreach (StateConditionAndValue<StateKey> precondition in node.GetPreconditions())
        {
            if (!CanTreatAsCurrentAvailability(precondition.Key.StateTemplateId) &&
                !planner.GetConditionConnectedActions(precondition.Condition).Any())
            {
                return false;
            }

            allowedNoneSensorState |= IsAllowedNoneSensorState(node, precondition);
        }

        foreach (StateConditionAndValue<StateKey> precondition in node.GetPreconditions())
        {
            if (IsBlockedNoneSensor(node, precondition))
            {
                return false;
            }
        }

        if (node is PlanningGoalNode planningGoalNode)
        {
            allowedNoneSensorState |= HasAllowedNoneSensorState(node, planningGoalNode.Template.TargetCharacterConditionsA) ||
                                      HasAllowedNoneSensorState(node, planningGoalNode.Template.TargetCharacterConditionsB) ||
                                      HasAllowedNoneSensorState(node, planningGoalNode.Template.TargetCharacterConditionsC);

            if (HasBlockedNoneSensor(node, planningGoalNode.Template.TargetCharacterConditionsA) ||
                HasBlockedNoneSensor(node, planningGoalNode.Template.TargetCharacterConditionsB) ||
                HasBlockedNoneSensor(node, planningGoalNode.Template.TargetCharacterConditionsC))
            {
                return false;
            }
        }
        else if (node is PlanningActionNode planningActionNode)
        {
            allowedNoneSensorState |= HasAllowedNoneSensorState(node, planningActionNode.Template.SelfRestrictions) ||
                                      HasAllowedNoneSensorState(node, planningActionNode.Template.TargetCharacterConditions);

            if (HasBlockedNoneSensor(node, planningActionNode.Template.SelfRestrictions) ||
                HasBlockedNoneSensor(node, planningActionNode.Template.TargetCharacterConditions))
            {
                return false;
            }
        }

        if (node.HasDirectConnections() &&
            !node.GetDirectConnections().Any(static connection =>
                connection is PlanningActionNode planningActionNode && planningActionNode.IsImplemented))
        {
            return false;
        }

        if (allowedNoneSensorState)
        {
            NpcActionLimitationRemovalLog.LogReachableBypass(node);
        }

        return true;
    }

    public static bool TryGetLooseCurrentState(StateKey key, out int value)
    {
        int stateTemplateId = key.StateTemplateId;
        if (CanTreatAsCurrentAvailability(stateTemplateId))
        {
            value = 1;
            return true;
        }

        value = 0;
        return false;
    }

    private static bool HasBlockedNoneSensor(
        INode<Character, StateKey> node,
        StateConditionAndValue<StateKey>[]? conditions)
    {
        if (conditions == null)
        {
            return false;
        }

        foreach (StateConditionAndValue<StateKey> condition in conditions)
        {
            if (IsBlockedNoneSensor(node, condition))
            {
                return true;
            }
        }

        return false;
    }

    private static bool HasAllowedNoneSensorState(
        INode<Character, StateKey> node,
        StateConditionAndValue<StateKey>[]? conditions)
    {
        if (conditions == null)
        {
            return false;
        }

        foreach (StateConditionAndValue<StateKey> condition in conditions)
        {
            if (IsAllowedNoneSensorState(node, condition))
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsBlockedNoneSensor(
        INode<Character, StateKey> node,
        StateConditionAndValue<StateKey> condition)
    {
        if (condition.Key.Template.SensorType != EPlanningStateSensorType.None)
        {
            return false;
        }

        int stateTemplateId = condition.Key.StateTemplateId;
        if (node is PlanningGoalNode && IsLifeSkillCraftGoalState(stateTemplateId))
        {
            return false;
        }

        if (node is PlanningActionNode planningActionNode)
        {
            int actionTemplateId = planningActionNode.Template.TemplateId;
            if (IsLifeSkillCraftAction(actionTemplateId) && IsLifeSkillCraftAvailabilityState(stateTemplateId))
            {
                return false;
            }

            if (actionTemplateId == 59 && stateTemplateId == ReadingExpAvailabilityState)
            {
                return false;
            }
        }

        return true;
    }

    private static bool IsAllowedNoneSensorState(
        INode<Character, StateKey> node,
        StateConditionAndValue<StateKey> condition)
    {
        if (condition.Key.Template.SensorType != EPlanningStateSensorType.None)
        {
            return false;
        }

        int stateTemplateId = condition.Key.StateTemplateId;
        if (node is PlanningGoalNode && IsLifeSkillCraftGoalState(stateTemplateId))
        {
            return true;
        }

        if (node is PlanningActionNode planningActionNode)
        {
            int actionTemplateId = planningActionNode.Template.TemplateId;
            return IsLifeSkillCraftAction(actionTemplateId) && IsLifeSkillCraftAvailabilityState(stateTemplateId) ||
                   actionTemplateId == 59 && stateTemplateId == ReadingExpAvailabilityState;
        }

        return false;
    }

    public static bool IsBypassedAction(int actionTemplateId)
    {
        return IsLifeSkillCraftAction(actionTemplateId) || actionTemplateId == 59;
    }

    public static bool CanTreatAsCurrentAvailabilityState(int stateTemplateId)
    {
        return CanTreatAsCurrentAvailability(stateTemplateId);
    }

    public static bool CanBypassNoneSensorForNode(
        bool isGoalNode,
        int actionTemplateId,
        int stateTemplateId)
    {
        if (isGoalNode)
        {
            return IsLifeSkillCraftGoalState(stateTemplateId);
        }

        return IsLifeSkillCraftAction(actionTemplateId) && IsLifeSkillCraftAvailabilityState(stateTemplateId) ||
               actionTemplateId == 59 && stateTemplateId == ReadingExpAvailabilityState;
    }

    private static bool CanTreatAsCurrentAvailability(int stateTemplateId)
    {
        return IsLifeSkillCraftAvailabilityState(stateTemplateId) ||
               stateTemplateId == ReadingExpAvailabilityState;
    }

    private static bool IsLifeSkillCraftAction(int actionTemplateId)
    {
        return actionTemplateId is >= 14 and <= 23;
    }

    private static bool IsLifeSkillCraftAvailabilityState(int stateTemplateId)
    {
        return stateTemplateId is >= 402 and <= 408;
    }

    private static bool IsLifeSkillCraftGoalState(int stateTemplateId)
    {
        return stateTemplateId is >= 434 and <= 440;
    }
}

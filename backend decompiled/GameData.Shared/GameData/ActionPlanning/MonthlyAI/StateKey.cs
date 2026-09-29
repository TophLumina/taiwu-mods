using System;
using Config;
using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning.MonthlyAI;

public readonly struct StateKey : IStateKey<StateKey>, IEquatable<StateKey>
{
	public readonly int StateTemplateId;

	public PlanningStateItem Template => PlanningState.Instance[StateTemplateId];

	public StateKey(int stateTemplateId)
	{
		StateTemplateId = stateTemplateId;
	}

	public bool IsSubStateOf(StateKey other)
	{
		if (StateTemplateId == other.StateTemplateId)
		{
			return true;
		}
		for (int parentState = Template.ParentState; parentState >= 0; parentState = PlanningState.Instance[parentState].ParentState)
		{
			if (parentState == other.StateTemplateId)
			{
				return true;
			}
		}
		return false;
	}

	public static implicit operator StateKey(int templateId)
	{
		return new StateKey(templateId);
	}

	public override int GetHashCode()
	{
		return StateTemplateId;
	}

	public bool Equals(StateKey other)
	{
		return StateTemplateId == other.StateTemplateId;
	}

	public override string ToString()
	{
		return $"{PlanningState.Instance.GetRefName(StateTemplateId)}({StateTemplateId})";
	}
}

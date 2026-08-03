using System;
using Config;
using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning.MonthlyAI;

/// <summary>
/// 过月AI行为规划中的状态
/// </summary>
public readonly struct StateKey : IStateKey<StateKey>, IEquatable<StateKey>
{
	/// <summary>
	/// <see cref="F:Config.PlanningStateItem.TemplateId" />
	/// </summary>
	public readonly int StateTemplateId;

	/// <summary>
	/// 模板数据
	/// </summary>
	public PlanningStateItem Template => PlanningState.Instance[StateTemplateId];

	/// <summary>
	/// 初始化
	/// </summary>
	/// <param name="stateTemplateId"><see cref="F:Config.PlanningStateItem.TemplateId" /></param>
	public StateKey(int stateTemplateId)
	{
		StateTemplateId = stateTemplateId;
	}

	/// <inheritdoc />
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

	/// <summary>
	/// 将 模板ID 隐式转换成 Key.
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static implicit operator StateKey(int templateId)
	{
		return new StateKey(templateId);
	}

	/// <inheritdoc />
	public override int GetHashCode()
	{
		return StateTemplateId;
	}

	/// <inheritdoc />
	public bool Equals(StateKey other)
	{
		return StateTemplateId == other.StateTemplateId;
	}

	/// <inheritdoc />
	public override string ToString()
	{
		return $"{PlanningState.Instance.GetRefName(StateTemplateId)}({StateTemplateId})";
	}
}

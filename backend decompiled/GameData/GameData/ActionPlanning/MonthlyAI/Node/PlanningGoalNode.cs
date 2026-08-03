using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Config;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.State;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Utilities;

namespace GameData.ActionPlanning.MonthlyAI.Node;

public class PlanningGoalNode : IGoal<GameData.Domains.Character.Character, StateKey>, INode<GameData.Domains.Character.Character, StateKey>, IEquatable<INode<GameData.Domains.Character.Character, StateKey>>
{
	public delegate bool GoalCreator(DataContext context, GameData.Domains.Character.Character selfChar);

	public readonly PlanningGoalItem Template;

	private readonly GoalCreator _goalCreator;

	public bool Reachable;

	public PlanningGoalSettings Settings;

	public PlanningGoalNode(PlanningGoalItem template)
	{
		Template = template;
		if (template.IsPrioritizedGoal)
		{
			_goalCreator = typeof(PrioritizedGoalCreation).GetMethod(template.CreateGoalImpl.Trim(), BindingFlags.Static | BindingFlags.NonPublic)?.CreateDelegate<GoalCreator>();
		}
	}

	public bool TryCreate(DataContext context, GameData.Domains.Character.Character selfChar)
	{
		try
		{
			return _goalCreator?.Invoke(context, selfChar) ?? false;
		}
		catch (Exception arg)
		{
			PredefinedLog.DefValue.CharacterGoalCreationFailed.Log(selfChar, this, arg);
		}
		return false;
	}

	public bool CheckCanBeAdded()
	{
		return Reachable && !Settings.Disabled;
	}

	public bool CheckCanBeAdded(DataContext context, GameData.Domains.Character.Character character)
	{
		if (!CheckCanBeAdded())
		{
			return false;
		}
		StateConditionAndValue<StateKey>[] addConditions = Template.AddConditions;
		if (addConditions == null || addConditions.Length <= 0)
		{
			return true;
		}
		CharacterPlanningAgent agent = context.PlanningAgent;
		agent.Initialize(context, character, this);
		IStateMemory<GameData.Domains.Character.Character, StateKey> stateMemory = agent.Memory;
		try
		{
			StateConditionAndValue<StateKey>[] addConditions2 = Template.AddConditions;
			foreach (StateConditionAndValue<StateKey> condition in addConditions2)
			{
				if (!stateMemory.CheckCondition(agent, condition))
				{
					return false;
				}
			}
		}
		catch (Exception arg)
		{
			PredefinedLog.DefValue.CharacterGoalCreationFailed.Log(character, this, arg);
			return false;
		}
		return true;
	}

	public bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		StateConditionAndValue<StateKey>[] targetCharacterConditionsA = Template.TargetCharacterConditionsA;
		if (targetCharacterConditionsA != null && targetCharacterConditionsA.Length > 0)
		{
			if (!context.PlanningAgent.MatchTargetCharacterByConditions(selfChar, targetChar, args, Template.TargetCharacterConditionsA))
			{
				targetCharacterConditionsA = Template.TargetCharacterConditionsB;
				if (targetCharacterConditionsA == null || targetCharacterConditionsA.Length <= 0 || !context.PlanningAgent.MatchTargetCharacterByConditions(selfChar, targetChar, args, Template.TargetCharacterConditionsB))
				{
					targetCharacterConditionsA = Template.TargetCharacterConditionsC;
					if (targetCharacterConditionsA == null || targetCharacterConditionsA.Length <= 0 || !context.PlanningAgent.MatchTargetCharacterByConditions(selfChar, targetChar, args, Template.TargetCharacterConditionsC))
					{
						return false;
					}
				}
			}
			return true;
		}
		return true;
	}

	public int GetMaxDepth()
	{
		return Template.MaxPlanningDepth;
	}

	public bool AllowNodeInPath(INode<GameData.Domains.Character.Character, StateKey> node)
	{
		int[] conflictActions = Template.ConflictActions;
		return conflictActions == null || conflictActions.Length <= 0 || !(node is PlanningActionNode action) || !Template.ConflictActions.Exist(action.Template.TemplateId);
	}

	public bool IsValid(GameData.Domains.Character.Character obj)
	{
		return true;
	}

	public bool Equals(INode<GameData.Domains.Character.Character, StateKey> other)
	{
		return this == other;
	}

	public IEnumerable<StateConditionAndValue<StateKey>> GetPreconditions()
	{
		return Template.Preconditions;
	}

	public IEnumerable<INode<GameData.Domains.Character.Character, StateKey>> GetDirectConnections()
	{
		return Enumerable.Empty<INode<GameData.Domains.Character.Character, StateKey>>();
	}

	public bool HasDirectConnections()
	{
		return false;
	}

	public bool HasDirectConnection(INode<GameData.Domains.Character.Character, StateKey> other)
	{
		return false;
	}

	public IEnumerable<StateEffect<StateKey>> GetEffects()
	{
		throw new InvalidOperationException();
	}

	public int GetWeight(IAgent<GameData.Domains.Character.Character, StateKey> agent)
	{
		throw new InvalidOperationException();
	}

	public override string ToString()
	{
		return $"{Template.Name}(G{Template.TemplateId})";
	}
}

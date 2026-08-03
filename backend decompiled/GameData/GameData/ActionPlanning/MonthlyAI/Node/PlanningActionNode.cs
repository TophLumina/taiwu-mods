using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Config;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.State;
using GameData.Common;
using GameData.Domains.Character;

namespace GameData.ActionPlanning.MonthlyAI.Node;

public class PlanningActionNode : IAction<GameData.Domains.Character.Character, StateKey>, INode<GameData.Domains.Character.Character, StateKey>, IEquatable<INode<GameData.Domains.Character.Character, StateKey>>
{
	private delegate bool TargetCharacterMatcher(DataContext context, GameData.Domains.Character.Character character, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args);

	private delegate ICharacterActionImpl ActionImplCreator(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle argGroup, PlanningActionItem actionTemplate);

	public readonly PlanningActionItem Template;

	public PlanningActionSettings Settings;

	private ActionImplCreator _actionImplCreator;

	private TargetCharacterMatcher _targetCharacterMatcher;

	private Type _implementationType;

	public bool Reachable;

	public bool IsImplemented => _implementationType != null;

	public PlanningActionNode(PlanningActionItem template)
	{
		Template = template;
	}

	public void SetImplementation(Type implementationType)
	{
		_implementationType = implementationType;
		_targetCharacterMatcher = implementationType.GetMethod("MatchTargetCharacter", (BindingFlags)(-1))?.CreateDelegate<TargetCharacterMatcher>();
		_actionImplCreator = implementationType.GetMethod("TryCreateActionImpl", (BindingFlags)(-1))?.CreateDelegate<ActionImplCreator>();
	}

	public ICharacterActionImpl CreateImplementation()
	{
		return (_implementationType != null) ? (Activator.CreateInstance(_implementationType) as ICharacterActionImpl) : null;
	}

	public ICharacterActionImpl CreateImplementation(DataContext context, GameData.Domains.Character.Character character, ContextArgGroupHandle args)
	{
		return (_actionImplCreator != null) ? _actionImplCreator(context, character, args, Template) : CreateImplementation();
	}

	public bool Equals(INode<GameData.Domains.Character.Character, StateKey> other)
	{
		return this == other;
	}

	public IEnumerable<StateEffect<StateKey>> GetEffects()
	{
		return Template.Effects.Concat(Template.DeEffects);
	}

	public IEnumerable<StateConditionAndValue<StateKey>> GetPreconditions()
	{
		return Template.Preconditions;
	}

	public IEnumerable<INode<GameData.Domains.Character.Character, StateKey>> GetDirectConnections()
	{
		return Array.Empty<INode<GameData.Domains.Character.Character, StateKey>>();
	}

	public bool HasDirectConnections()
	{
		return false;
	}

	public bool HasDirectConnection(INode<GameData.Domains.Character.Character, StateKey> other)
	{
		return false;
	}

	public bool MatchTargetCharacter(DataContext context, GameData.Domains.Character.Character selfChar, GameData.Domains.Character.Character targetChar, ContextArgGroupHandle args)
	{
		if (Template.TargetMatcher >= 0 && !CharacterMatcher.Instance[Template.TargetMatcher].Match(targetChar))
		{
			return false;
		}
		StateConditionAndValue<StateKey>[] targetCharacterConditions = Template.TargetCharacterConditions;
		if (targetCharacterConditions != null && targetCharacterConditions.Length > 0 && !context.PlanningAgent.MatchTargetCharacterByConditions(selfChar, targetChar, args, Template.TargetCharacterConditions))
		{
			return false;
		}
		return _targetCharacterMatcher?.Invoke(context, selfChar, targetChar, args) ?? true;
	}

	public int GetWeight(IAgent<GameData.Domains.Character.Character, StateKey> agent)
	{
		GameData.Domains.Character.Character character = agent.Object;
		int weight = 0;
		if (Settings.Disabled)
		{
			return 0;
		}
		if (Template.PersonalityType >= 0)
		{
			weight += character.GetPersonalities()[Template.PersonalityType];
		}
		int[] behaviorTypeWeights = Template.BehaviorTypeWeights;
		if (behaviorTypeWeights != null && behaviorTypeWeights.Length > 0)
		{
			weight += Template.BehaviorTypeWeights[character.GetBehaviorType()];
		}
		return weight + Settings.WeightAdjust;
	}

	public bool CanBeInterrupted()
	{
		return false;
	}

	public override string ToString()
	{
		return $"{PlanningAction.Instance.GetRefName(Template.TemplateId)}(A{Template.TemplateId})";
	}
}

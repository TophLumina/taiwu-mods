using System;
using System.Collections.Generic;

namespace GameData.ActionPlanning.State;

public readonly struct StateEffect<TStateKey> : IEquatable<StateEffect<TStateKey>> where TStateKey : IStateKey<TStateKey>
{
	public readonly TStateKey Key;

	public readonly EStateChange ChangeType;

	public StateEffect(TStateKey key, string changeType)
	{
		Key = key;
		EStateChange changeType2;
		if (!(changeType == "+"))
		{
			if (!(changeType == "-"))
			{
				throw new ArgumentException("Unrecognized change type " + changeType + ".");
			}
			changeType2 = EStateChange.Decrease;
		}
		else
		{
			changeType2 = EStateChange.Increase;
		}
		ChangeType = changeType2;
	}

	public StateEffect(TStateKey key, int changeValue = 1)
	{
		Key = key;
		ChangeType = changeValue switch
		{
			0 => EStateChange.Disable, 
			1 => EStateChange.Enable, 
			_ => throw new ArgumentException($"Unrecognized change type {changeValue}."), 
		};
	}

	public StateEffect(TStateKey key, EStateChange changeType)
	{
		Key = key;
		ChangeType = changeType;
	}

	public bool CanSatisfy(StateCondition<TStateKey> condition)
	{
		if (!Key.Equals(condition.Key) && !Key.IsSubStateOf(condition.Key))
		{
			return false;
		}
		return condition.ConditionType switch
		{
			EStateCondition.Equal => true, 
			EStateCondition.NotEqual => true, 
			EStateCondition.GreaterThan => ChangeType == EStateChange.Increase, 
			EStateCondition.GreaterOrEqual => ChangeType == EStateChange.Increase, 
			EStateCondition.LessThan => ChangeType == EStateChange.Decrease, 
			EStateCondition.LessOrEqual => ChangeType == EStateChange.Decrease, 
			EStateCondition.Enabled => ChangeType == EStateChange.Enable, 
			EStateCondition.Disabled => ChangeType == EStateChange.Disable, 
			EStateCondition.GreaterThanPercent => ChangeType == EStateChange.Increase, 
			EStateCondition.GreaterOrEqualPercent => ChangeType == EStateChange.Increase, 
			EStateCondition.LessThanPercent => ChangeType == EStateChange.Decrease, 
			EStateCondition.LessOrEqualPercent => ChangeType == EStateChange.Decrease, 
			_ => throw new ActionPlanningException($"Invalid condition type {condition.ConditionType}."), 
		};
	}

	public override string ToString()
	{
		return $"{{{Key}, {ChangeType}}}";
	}

	public bool Equals(StateEffect<TStateKey> other)
	{
		if (EqualityComparer<TStateKey>.Default.Equals(Key, other.Key))
		{
			return ChangeType == other.ChangeType;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is StateEffect<TStateKey> other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Key, (int)ChangeType);
	}
}

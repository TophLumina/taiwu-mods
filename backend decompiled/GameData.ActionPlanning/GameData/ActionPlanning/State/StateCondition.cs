using System;
using System.Collections.Generic;

namespace GameData.ActionPlanning.State;

public readonly struct StateCondition<TStateKey> : IEquatable<StateCondition<TStateKey>> where TStateKey : IStateKey<TStateKey>
{
	public readonly EStateCondition ConditionType;

	public TStateKey Key { get; }

	public StateCondition(TStateKey key, string conditionType)
	{
		Key = key;
		ConditionType = conditionType switch
		{
			"==" => EStateCondition.Equal, 
			"!=" => EStateCondition.NotEqual, 
			">" => EStateCondition.GreaterThan, 
			">=" => EStateCondition.GreaterOrEqual, 
			"<" => EStateCondition.LessThan, 
			"<=" => EStateCondition.LessOrEqual, 
			">%" => EStateCondition.GreaterThanPercent, 
			">=%" => EStateCondition.GreaterOrEqualPercent, 
			"<%" => EStateCondition.LessThanPercent, 
			"<=%" => EStateCondition.LessOrEqualPercent, 
			_ => throw new ArgumentException("Unrecognized condition type " + conditionType + "."), 
		};
	}

	public StateCondition(TStateKey key, int value)
	{
		Key = key;
		ConditionType = value switch
		{
			0 => EStateCondition.Disabled, 
			1 => EStateCondition.Enabled, 
			_ => throw new ArgumentException($"Unrecognized condition type {value}."), 
		};
	}

	public StateCondition(TStateKey key, EStateCondition conditionType)
	{
		Key = key;
		ConditionType = conditionType;
	}

	public override string ToString()
	{
		return $"{{{Key}, {ConditionType}}}";
	}

	public bool Equals(StateCondition<TStateKey> other)
	{
		if (ConditionType == other.ConditionType)
		{
			return EqualityComparer<TStateKey>.Default.Equals(Key, other.Key);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is StateCondition<TStateKey> other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return HashCode.Combine((int)ConditionType, Key);
	}
}

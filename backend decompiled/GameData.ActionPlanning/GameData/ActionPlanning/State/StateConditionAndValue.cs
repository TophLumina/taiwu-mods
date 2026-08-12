using System;
using GameData.Utilities;

namespace GameData.ActionPlanning.State;

public class StateConditionAndValue<TStateKey> where TStateKey : IStateKey<TStateKey>
{
	public readonly StateCondition<TStateKey> Condition;

	public readonly bool IsConstValue;

	public readonly int Value;

	public readonly TStateKey ReferenceKey;

	public TStateKey Key => Condition.Key;

	public EStateCondition ConditionType => Condition.ConditionType;

	public StateConditionAndValue(TStateKey key, string conditionType, int value)
	{
		Condition = new StateCondition<TStateKey>(key, conditionType);
		IsConstValue = true;
		ReferenceKey = default(TStateKey);
		Value = value;
		Tester.Assert(value != int.MinValue);
	}

	public StateConditionAndValue(TStateKey key, string conditionType, int offset, TStateKey value)
	{
		Condition = new StateCondition<TStateKey>(key, conditionType);
		IsConstValue = false;
		Value = offset;
		ReferenceKey = value;
	}

	public StateConditionAndValue(TStateKey key, string conditionType)
	{
		Condition = new StateCondition<TStateKey>(key, conditionType);
		IsConstValue = false;
		Value = 0;
		ReferenceKey = key;
	}

	public StateConditionAndValue(TStateKey key, int value = 1)
	{
		Condition = new StateCondition<TStateKey>(key, value);
		IsConstValue = true;
		ReferenceKey = default(TStateKey);
		Value = value;
		Tester.Assert(value != int.MinValue);
	}

	public StateConditionAndValue(TStateKey key, EStateCondition type)
	{
		Condition = new StateCondition<TStateKey>(key, type);
		IsConstValue = true;
		ReferenceKey = default(TStateKey);
		Value = 0;
	}

	public StateConditionAndValue(TStateKey key, EStateCondition type, int value)
	{
		Condition = new StateCondition<TStateKey>(key, type);
		IsConstValue = true;
		ReferenceKey = default(TStateKey);
		Value = value;
		Tester.Assert(value != int.MinValue);
	}

	public StateConditionAndValue(StateCondition<TStateKey> condition, int value)
	{
		Condition = condition;
		IsConstValue = true;
		ReferenceKey = default(TStateKey);
		Value = value;
		Tester.Assert(value != int.MinValue);
	}

	public override string ToString()
	{
		return $"{{{Key}, {ConditionType}, {(IsConstValue ? ((object)Value) : ((object)ReferenceKey))}}}";
	}

	public static bool TryMerge(StateConditionAndValue<TStateKey> conditionA, StateConditionAndValue<TStateKey> conditionB, out StateConditionAndValue<TStateKey> result)
	{
		if (conditionA.CheckSubsetOf(conditionB))
		{
			result = conditionA;
			return true;
		}
		if (conditionB.CheckSubsetOf(conditionA))
		{
			result = conditionB;
			return true;
		}
		result = null;
		return false;
	}

	public bool CheckSubsetOf(StateConditionAndValue<TStateKey> condition)
	{
		if (!Key.Equals(condition.Key))
		{
			return false;
		}
		if (condition.IsConstValue != IsConstValue || !condition.ReferenceKey.Equals(ReferenceKey))
		{
			return false;
		}
		return condition.ConditionType switch
		{
			EStateCondition.Equal => CheckSubsetEqual(condition.Value), 
			EStateCondition.NotEqual => CheckSubsetNotEqual(condition.Value), 
			EStateCondition.GreaterThan => CheckSubsetGreaterThan(condition.Value), 
			EStateCondition.GreaterOrEqual => CheckSubsetGreaterOrEqual(condition.Value), 
			EStateCondition.LessThan => CheckSubsetLessThan(condition.Value), 
			EStateCondition.LessOrEqual => CheckSubsetLessOrEqual(condition.Value), 
			EStateCondition.Enabled => CheckSubsetEnabled(), 
			EStateCondition.Disabled => CheckSubsetDisabled(), 
			EStateCondition.GreaterThanPercent => CheckSubsetGreaterThanPercent(condition.Value), 
			EStateCondition.GreaterOrEqualPercent => CheckSubsetGreaterOrEqualPercent(condition.Value), 
			EStateCondition.LessThanPercent => CheckSubsetLessThanPercent(condition.Value), 
			EStateCondition.LessOrEqualPercent => CheckSubsetLessOrEqualPercent(condition.Value), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public bool CheckConflict(StateConditionAndValue<TStateKey> condition)
	{
		if (!Key.Equals(condition.Key))
		{
			return false;
		}
		if (condition.IsConstValue != IsConstValue || !condition.ReferenceKey.Equals(ReferenceKey))
		{
			return false;
		}
		return condition.ConditionType switch
		{
			EStateCondition.Equal => CheckConflictEqual(condition.Value), 
			EStateCondition.NotEqual => CheckConflictNotEqual(condition.Value), 
			EStateCondition.GreaterThan => CheckConflictGreaterThan(condition.Value), 
			EStateCondition.GreaterOrEqual => CheckConflictGreaterOrEqual(condition.Value), 
			EStateCondition.LessThan => CheckConflictLessThan(condition.Value), 
			EStateCondition.LessOrEqual => CheckConflictLessOrEqual(condition.Value), 
			EStateCondition.Enabled => CheckConflictEnabled(), 
			EStateCondition.Disabled => CheckConflictDisabled(), 
			EStateCondition.GreaterThanPercent => CheckConflictGreaterThanPercent(condition.Value), 
			EStateCondition.GreaterOrEqualPercent => CheckConflictGreaterOrEqualPercent(condition.Value), 
			EStateCondition.LessThanPercent => CheckConflictLessThanPercent(condition.Value), 
			EStateCondition.LessOrEqualPercent => CheckConflictLessOrEqualPercent(condition.Value), 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	private bool CheckSubsetEqual(int value)
	{
		return ConditionType switch
		{
			EStateCondition.Equal => value == Value, 
			EStateCondition.NotEqual => value != Value, 
			EStateCondition.GreaterThan => value > Value, 
			EStateCondition.GreaterOrEqual => value >= Value, 
			EStateCondition.LessThan => value < Value, 
			EStateCondition.LessOrEqual => value <= Value, 
			EStateCondition.Enabled => value != 0, 
			EStateCondition.Disabled => value != 1, 
			_ => false, 
		};
	}

	private bool CheckSubsetNotEqual(int value)
	{
		return ConditionType switch
		{
			EStateCondition.NotEqual => value == Value, 
			EStateCondition.GreaterThan => value <= Value, 
			EStateCondition.GreaterOrEqual => value < Value, 
			EStateCondition.Enabled => value != 1, 
			EStateCondition.Disabled => value != 0, 
			_ => false, 
		};
	}

	private bool CheckSubsetGreaterThan(int value)
	{
		return ConditionType switch
		{
			EStateCondition.Equal => value < Value, 
			EStateCondition.GreaterThan => value <= Value, 
			EStateCondition.GreaterOrEqual => value < Value, 
			_ => false, 
		};
	}

	private bool CheckSubsetGreaterOrEqual(int value)
	{
		return ConditionType switch
		{
			EStateCondition.Equal => value <= Value, 
			EStateCondition.GreaterThan => value <= Value + 1, 
			EStateCondition.GreaterOrEqual => value <= Value, 
			_ => false, 
		};
	}

	private bool CheckSubsetLessThan(int value)
	{
		return ConditionType switch
		{
			EStateCondition.Equal => value > Value, 
			EStateCondition.LessThan => value >= Value, 
			EStateCondition.LessOrEqual => value > Value, 
			_ => false, 
		};
	}

	private bool CheckSubsetLessOrEqual(int value)
	{
		return ConditionType switch
		{
			EStateCondition.Equal => value >= Value, 
			EStateCondition.LessThan => value >= Value + 1, 
			EStateCondition.LessOrEqual => value >= Value, 
			_ => false, 
		};
	}

	private bool CheckSubsetEnabled()
	{
		return ConditionType switch
		{
			EStateCondition.Equal => Value != 0, 
			EStateCondition.NotEqual => Value != 1, 
			EStateCondition.Enabled => true, 
			_ => false, 
		};
	}

	private bool CheckSubsetDisabled()
	{
		return ConditionType switch
		{
			EStateCondition.Equal => Value != 1, 
			EStateCondition.NotEqual => Value != 0, 
			EStateCondition.Disabled => true, 
			_ => false, 
		};
	}

	private bool CheckSubsetGreaterThanPercent(int value)
	{
		return ConditionType switch
		{
			EStateCondition.GreaterThanPercent => value <= Value, 
			EStateCondition.GreaterOrEqualPercent => value < Value, 
			_ => false, 
		};
	}

	private bool CheckSubsetGreaterOrEqualPercent(int value)
	{
		return ConditionType switch
		{
			EStateCondition.GreaterThanPercent => value <= Value + 1, 
			EStateCondition.GreaterOrEqualPercent => value <= Value, 
			_ => false, 
		};
	}

	private bool CheckSubsetLessThanPercent(int value)
	{
		return ConditionType switch
		{
			EStateCondition.LessThanPercent => value >= Value, 
			EStateCondition.LessOrEqualPercent => value > Value, 
			_ => false, 
		};
	}

	private bool CheckSubsetLessOrEqualPercent(int value)
	{
		return ConditionType switch
		{
			EStateCondition.LessThanPercent => value >= Value + 1, 
			EStateCondition.LessOrEqualPercent => value >= Value, 
			_ => false, 
		};
	}

	private bool CheckConflictEqual(int value)
	{
		return ConditionType switch
		{
			EStateCondition.Equal => value != Value, 
			EStateCondition.NotEqual => value == Value, 
			EStateCondition.GreaterThan => value <= Value, 
			EStateCondition.GreaterOrEqual => value < Value, 
			EStateCondition.LessThan => value >= Value, 
			EStateCondition.LessOrEqual => value > Value, 
			EStateCondition.Enabled => value != 1, 
			EStateCondition.Disabled => value != 0, 
			_ => false, 
		};
	}

	private bool CheckConflictNotEqual(int value)
	{
		return ConditionType switch
		{
			EStateCondition.Equal => value == Value, 
			EStateCondition.NotEqual => value != Value, 
			EStateCondition.Enabled => value != 0, 
			EStateCondition.Disabled => value != 1, 
			_ => false, 
		};
	}

	private bool CheckConflictGreaterThan(int value)
	{
		return ConditionType switch
		{
			EStateCondition.Equal => value >= Value, 
			EStateCondition.LessThan => value >= Value, 
			EStateCondition.LessOrEqual => value > Value, 
			_ => false, 
		};
	}

	private bool CheckConflictGreaterOrEqual(int value)
	{
		return ConditionType switch
		{
			EStateCondition.Equal => value > Value, 
			EStateCondition.LessThan => value > Value, 
			EStateCondition.LessOrEqual => value > Value + 1, 
			_ => false, 
		};
	}

	private bool CheckConflictLessThan(int value)
	{
		return ConditionType switch
		{
			EStateCondition.Equal => value <= Value, 
			EStateCondition.GreaterThan => value <= Value, 
			EStateCondition.GreaterOrEqual => value < Value, 
			_ => false, 
		};
	}

	private bool CheckConflictLessOrEqual(int value)
	{
		return ConditionType switch
		{
			EStateCondition.Equal => value < Value, 
			EStateCondition.GreaterThan => value < Value, 
			EStateCondition.GreaterOrEqual => value < Value - 1, 
			_ => false, 
		};
	}

	private bool CheckConflictEnabled()
	{
		return ConditionType switch
		{
			EStateCondition.Equal => Value != 1, 
			EStateCondition.NotEqual => Value != 0, 
			EStateCondition.Disabled => true, 
			_ => false, 
		};
	}

	private bool CheckConflictDisabled()
	{
		return ConditionType switch
		{
			EStateCondition.Equal => Value != 0, 
			EStateCondition.NotEqual => Value != 1, 
			EStateCondition.Enabled => true, 
			_ => false, 
		};
	}

	private bool CheckConflictGreaterThanPercent(int value)
	{
		return ConditionType switch
		{
			EStateCondition.LessThanPercent => value >= Value, 
			EStateCondition.LessOrEqualPercent => value > Value, 
			_ => false, 
		};
	}

	private bool CheckConflictGreaterOrEqualPercent(int value)
	{
		return ConditionType switch
		{
			EStateCondition.LessThanPercent => value > Value, 
			EStateCondition.LessOrEqualPercent => value > Value + 1, 
			_ => false, 
		};
	}

	private bool CheckConflictLessThanPercent(int value)
	{
		return ConditionType switch
		{
			EStateCondition.GreaterThanPercent => value <= Value, 
			EStateCondition.GreaterOrEqualPercent => value < Value, 
			_ => false, 
		};
	}

	private bool CheckConflictLessOrEqualPercent(int value)
	{
		return ConditionType switch
		{
			EStateCondition.GreaterThanPercent => value < Value, 
			EStateCondition.GreaterOrEqualPercent => value < Value - 1, 
			_ => false, 
		};
	}
}

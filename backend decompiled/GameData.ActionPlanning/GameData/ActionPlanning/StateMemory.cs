using System;
using System.Collections.Generic;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning;

public class StateMemory<TObject, TStateKey> : IStateMemory<TObject, TStateKey>, INode<TObject, TStateKey>, IEquatable<INode<TObject, TStateKey>> where TStateKey : IStateKey<TStateKey>
{
	private readonly Dictionary<TStateKey, int> _currStates = new Dictionary<TStateKey, int>();

	private readonly List<StateConditionAndValue<TStateKey>> _stateConditions = new List<StateConditionAndValue<TStateKey>>();

	public int GetState(IAgent<TObject, TStateKey> agent, TStateKey key)
	{
		if (_currStates.TryGetValue(key, out var value))
		{
			return value;
		}
		value = agent.CalcCurrentState(this, key);
		if (value != int.MinValue)
		{
			SetState(key, value);
		}
		return value;
	}

	public void SetState(TStateKey key, int value)
	{
		_currStates[key] = value;
	}

	public IEnumerable<KeyValuePair<TStateKey, int>> GetStates()
	{
		return _currStates;
	}

	public IEnumerable<StateConditionAndValue<TStateKey>> GetPreconditions()
	{
		return _stateConditions;
	}

	public virtual void InitContext(IAgent<TObject, TStateKey> agent)
	{
		Inherit(agent.Memory);
		foreach (StateConditionAndValue<TStateKey> condition in agent.Goal.GetPreconditions())
		{
			AddCondition(agent, condition);
		}
	}

	public virtual void Inherit(IStateMemory<TObject, TStateKey> other)
	{
		_currStates.Clear();
		_stateConditions.Clear();
		foreach (KeyValuePair<TStateKey, int> pair in other.GetStates())
		{
			_currStates.Add(pair.Key, pair.Value);
		}
		foreach (StateConditionAndValue<TStateKey> pair2 in other.GetPreconditions())
		{
			_stateConditions.Add(pair2);
		}
	}

	public virtual void Clear()
	{
		_currStates.Clear();
		_stateConditions.Clear();
	}

	public bool ApplyEffect(StateEffect<TStateKey> stateEffect)
	{
		for (int index = _stateConditions.Count - 1; index >= 0; index--)
		{
			StateConditionAndValue<TStateKey> conditionAndValue = _stateConditions[index];
			if (stateEffect.CanSatisfy(conditionAndValue.Condition) && TryMatchAndInheritStateParameter(stateEffect.Key, conditionAndValue.Key))
			{
				_stateConditions.RemoveAt(index);
				return true;
			}
		}
		return false;
	}

	protected virtual bool TryMatchAndInheritStateParameter(TStateKey effectState, TStateKey conditionState)
	{
		return true;
	}

	public bool AddCondition(IAgent<TObject, TStateKey> agent, StateConditionAndValue<TStateKey> newCondition)
	{
		if (CheckCondition(agent, newCondition))
		{
			return true;
		}
		for (int index = _stateConditions.Count - 1; index >= 0; index--)
		{
			StateConditionAndValue<TStateKey> stateCondition = _stateConditions[index];
			if (newCondition.CheckConflict(stateCondition))
			{
				return false;
			}
			if (StateConditionAndValue<TStateKey>.TryMerge(newCondition, stateCondition, out var result))
			{
				_stateConditions[index] = result;
				return true;
			}
		}
		_stateConditions.Add(newCondition);
		return true;
	}

	public bool Equals(INode<TObject, TStateKey> other)
	{
		return this == other;
	}

	public IEnumerable<StateEffect<TStateKey>> GetEffects()
	{
		throw new NotImplementedException();
	}

	public bool HasDirectConnections()
	{
		throw new NotImplementedException();
	}

	public bool HasDirectConnection(INode<TObject, TStateKey> other)
	{
		throw new NotImplementedException();
	}

	public int GetWeight(IAgent<TObject, TStateKey> agent)
	{
		throw new NotImplementedException();
	}

	public IEnumerable<INode<TObject, TStateKey>> GetDirectConnections()
	{
		throw new NotImplementedException();
	}

	public bool CheckCondition(IAgent<TObject, TStateKey> agent, StateConditionAndValue<TStateKey> condition)
	{
		int currValue = GetState(agent, condition.Key);
		if (currValue == int.MinValue)
		{
			return false;
		}
		int expectedValue = condition.Value;
		if (!condition.IsConstValue)
		{
			int targetStateValue = GetState(agent, condition.ReferenceKey);
			if (targetStateValue == int.MinValue)
			{
				return false;
			}
			expectedValue = (condition.ConditionType.IsPercent() ? (expectedValue * targetStateValue / 100) : (expectedValue + targetStateValue));
		}
		return StateConditionHelper.Check(condition.ConditionType, currValue, expectedValue);
	}
}

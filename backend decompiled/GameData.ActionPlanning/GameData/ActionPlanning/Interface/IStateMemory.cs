using System;
using System.Collections.Generic;
using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning.Interface;

public interface IStateMemory<TObject, TStateKey> : INode<TObject, TStateKey>, IEquatable<INode<TObject, TStateKey>> where TStateKey : IStateKey<TStateKey>
{
	int GetState(IAgent<TObject, TStateKey> target, TStateKey key);

	void SetState(TStateKey key, int value);

	IEnumerable<KeyValuePair<TStateKey, int>> GetStates();

	void Clear();

	void Inherit(IStateMemory<TObject, TStateKey> other);

	bool CheckCondition(IAgent<TObject, TStateKey> agent, StateConditionAndValue<TStateKey> condition);
}

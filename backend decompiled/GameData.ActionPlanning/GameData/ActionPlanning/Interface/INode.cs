using System;
using System.Collections.Generic;
using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning.Interface;

public interface INode<TObject, TStateKey> : IEquatable<INode<TObject, TStateKey>> where TStateKey : IStateKey<TStateKey>
{
	IEnumerable<StateEffect<TStateKey>> GetEffects();

	IEnumerable<StateConditionAndValue<TStateKey>> GetPreconditions();

	IEnumerable<INode<TObject, TStateKey>> GetDirectConnections();

	bool HasDirectConnections();

	bool HasDirectConnection(INode<TObject, TStateKey> other);

	int GetWeight(IAgent<TObject, TStateKey> agent);
}

using System;
using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning.Interface;

public interface IAction<TObject, TStateKey> : INode<TObject, TStateKey>, IEquatable<INode<TObject, TStateKey>> where TStateKey : IStateKey<TStateKey>
{
	bool CanBeInterrupted();
}

using System.Collections.Generic;
using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning.Interface;

public interface IPlan<TObject, TStateKey> where TStateKey : IStateKey<TStateKey>
{
	List<INode<TObject, TStateKey>> Nodes { get; }

	IAction<TObject, TStateKey> GetNextAction();
}

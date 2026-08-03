using System.Collections.Generic;
using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning.Interface;

public interface IAgent<TObject, TStateKey> where TStateKey : IStateKey<TStateKey>
{
	TObject Object { get; }

	IStateMemory<TObject, TStateKey> Memory { get; }

	IGoal<TObject, TStateKey> Goal { get; }

	IList<INode<TObject, TStateKey>> Plan { get; }

	IPathfinder<TObject, TStateKey> Pathfinder { get; }

	void PrepareContext(IStateMemory<TObject, TStateKey> stateMemory, INode<TObject, TStateKey> currNode, INode<TObject, TStateKey> nextNode, INode<TObject, TStateKey> destNode);

	bool CheckPrerequisites(IStateMemory<TObject, TStateKey> stateMemory, INode<TObject, TStateKey> node);

	int CalcCurrentState(IStateMemory<TObject, TStateKey> currMemory, TStateKey key);
}

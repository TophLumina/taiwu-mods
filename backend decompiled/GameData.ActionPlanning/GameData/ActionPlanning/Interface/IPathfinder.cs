using System.Collections.Generic;
using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning.Interface;

public interface IPathfinder<TObject, TStateKey> where TStateKey : IStateKey<TStateKey>
{
	void FindPath(IAgent<TObject, TStateKey> agent, IGoal<TObject, TStateKey> startNode, IList<INode<TObject, TStateKey>> nodesOnPath, int maxDepth);

	bool ReassessPath(IAgent<TObject, TStateKey> agent, IGoal<TObject, TStateKey> startNode, IList<INode<TObject, TStateKey>> nodesOnPath);
}

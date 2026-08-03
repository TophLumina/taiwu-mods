using System;
using GameData.ActionPlanning.State;

namespace GameData.ActionPlanning.Interface;

public interface IGoal<TObject, TStateKey> : INode<TObject, TStateKey>, IEquatable<INode<TObject, TStateKey>> where TStateKey : IStateKey<TStateKey>
{
	int GetMaxDepth();

	bool AllowNodeInPath(INode<TObject, TStateKey> node);

	bool IsValid(TObject obj);

	bool IsComplete(IAgent<TObject, TStateKey> agent)
	{
		foreach (StateConditionAndValue<TStateKey> condition in GetPreconditions())
		{
			if (!agent.Memory.CheckCondition(agent, condition))
			{
				return false;
			}
		}
		return !HasDirectConnections();
	}
}

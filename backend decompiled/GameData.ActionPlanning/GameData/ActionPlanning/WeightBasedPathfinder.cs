using System.Collections.Generic;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.State;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.ActionPlanning;

public class WeightBasedPathfinder<TContext, TObject, TStateKey> : IPathfinder<TObject, TStateKey> where TContext : StateMemory<TObject, TStateKey>, new() where TStateKey : IStateKey<TStateKey>
{
	private readonly IGraph<IAgent<TObject, TStateKey>, INode<TObject, TStateKey>> _graph;

	private readonly IRandomSource _randomSource;

	private readonly LocalObjectPool<WeightTable<INode<TObject, TStateKey>>> _weightTablePool;

	private readonly LocalObjectPool<TContext> _stateMemoryPool;

	private readonly HashSet<INode<TObject, TStateKey>> _tmpNodeSet;

	public WeightBasedPathfinder(IGraph<IAgent<TObject, TStateKey>, INode<TObject, TStateKey>> graph)
	{
		_randomSource = RandomDefaults.CreateRandomSource();
		_graph = graph;
		_weightTablePool = new LocalObjectPool<WeightTable<INode<TObject, TStateKey>>>(4, 12);
		_stateMemoryPool = new LocalObjectPool<TContext>(4, 12);
		_tmpNodeSet = new HashSet<INode<TObject, TStateKey>>();
	}

	public bool ReassessPath(IAgent<TObject, TStateKey> agent, IGoal<TObject, TStateKey> startNode, IList<INode<TObject, TStateKey>> nodesOnPath)
	{
		bool modified = false;
		TContext currMemory = _stateMemoryPool.Get();
		currMemory.InitContext(agent);
		if (GetUnsatisfiedStateCount(agent, currMemory) == 0 && !startNode.HasDirectConnections())
		{
			nodesOnPath.Clear();
			nodesOnPath.Add(startNode);
			_stateMemoryPool.Return(currMemory);
			return true;
		}
		for (int i = nodesOnPath.Count - 2; i >= 0; i--)
		{
			INode<TObject, TStateKey> nextNode = nodesOnPath[i];
			agent.PrepareContext(currMemory, startNode, nextNode, startNode);
			bool hasAnyEffect = startNode.HasDirectConnection(nextNode);
			IEnumerable<StateEffect<TStateKey>> effects = nextNode.GetEffects();
			if (effects != null)
			{
				foreach (StateEffect<TStateKey> effect in effects)
				{
					hasAnyEffect |= currMemory.ApplyEffect(effect);
				}
			}
			if (!hasAnyEffect)
			{
				modified = true;
				nodesOnPath.RemoveAt(i);
			}
			else
			{
				IEnumerable<StateConditionAndValue<TStateKey>> conditions = nextNode.GetPreconditions();
				if (conditions != null)
				{
					foreach (StateConditionAndValue<TStateKey> condition in conditions)
					{
						currMemory.AddCondition(agent, condition);
					}
				}
			}
		}
		if (nodesOnPath.Count <= 1)
		{
			nodesOnPath.Clear();
			modified = true;
		}
		agent.Memory.Inherit(currMemory);
		_stateMemoryPool.Return(currMemory);
		return modified;
	}

	public void FindPath(IAgent<TObject, TStateKey> context, IGoal<TObject, TStateKey> startNode, IList<INode<TObject, TStateKey>> nodesOnPath, int maxDepth)
	{
		TContext currMemory = _stateMemoryPool.Get();
		currMemory.InitContext(context);
		nodesOnPath.Clear();
		if (FindPathRecursive(context, startNode, currMemory, startNode, nodesOnPath, maxDepth))
		{
			nodesOnPath.Add(startNode);
		}
		_stateMemoryPool.Return(currMemory);
	}

	private bool FindPathRecursive(IAgent<TObject, TStateKey> agent, INode<TObject, TStateKey> currNode, IStateMemory<TObject, TStateKey> currMemory, IGoal<TObject, TStateKey> destNode, IList<INode<TObject, TStateKey>> nodesOnPath, int depth)
	{
		if (GetUnsatisfiedStateCount(agent, currMemory) == 0 && !currNode.HasDirectConnections())
		{
			return true;
		}
		if (depth == 0)
		{
			return false;
		}
		WeightTable<INode<TObject, TStateKey>> weightTable = _weightTablePool.Get();
		weightTable.Clear();
		_tmpNodeSet.Clear();
		if (currNode.HasDirectConnections())
		{
			foreach (INode<TObject, TStateKey> directConnection in currNode.GetDirectConnections())
			{
				if (destNode.AllowNodeInPath(directConnection) && _tmpNodeSet.Add(directConnection) && agent.CheckPrerequisites(currMemory, directConnection))
				{
					int weight = _graph.GetWeight(agent, currNode, directConnection);
					if (weight > 0)
					{
						weightTable.Add(directConnection, weight);
					}
				}
			}
		}
		foreach (INode<TObject, TStateKey> node in _graph.GetNeighborNodes(currMemory))
		{
			if (destNode.AllowNodeInPath(node) && _tmpNodeSet.Add(node) && agent.CheckPrerequisites(currMemory, node))
			{
				int weight2 = _graph.GetWeight(agent, currNode, node);
				if (weight2 > 0)
				{
					weightTable.Add(node, weight2);
				}
			}
		}
		TContext nextMemory = _stateMemoryPool.Get();
		while (weightTable.Count > 0)
		{
			bool hasConflict = false;
			INode<TObject, TStateKey> nextNode = weightTable.GetRandom(_randomSource);
			nextMemory.Inherit(currMemory);
			agent.PrepareContext(nextMemory, currNode, nextNode, destNode);
			IEnumerable<StateEffect<TStateKey>> effects = nextNode.GetEffects();
			bool anyEffect = currNode.HasDirectConnection(nextNode);
			if (effects != null)
			{
				foreach (StateEffect<TStateKey> effect in effects)
				{
					anyEffect |= nextMemory.ApplyEffect(effect);
				}
			}
			if (!anyEffect)
			{
				weightTable.Remove(nextNode);
				continue;
			}
			IEnumerable<StateConditionAndValue<TStateKey>> conditions = nextNode.GetPreconditions();
			if (conditions != null)
			{
				foreach (StateConditionAndValue<TStateKey> condition in conditions)
				{
					if (!nextMemory.AddCondition(agent, condition))
					{
						hasConflict = true;
					}
				}
			}
			if (!hasConflict && FindPathRecursive(agent, nextNode, nextMemory, destNode, nodesOnPath, depth - 1))
			{
				nodesOnPath.Add(nextNode);
				_weightTablePool.Return(weightTable);
				_stateMemoryPool.Return(nextMemory);
				return true;
			}
			weightTable.Remove(nextNode);
		}
		_weightTablePool.Return(weightTable);
		_stateMemoryPool.Return(nextMemory);
		return false;
	}

	private int GetUnsatisfiedStateCount(IAgent<TObject, TStateKey> agent, IStateMemory<TObject, TStateKey> currMemory)
	{
		int count = 0;
		foreach (StateConditionAndValue<TStateKey> condition in currMemory.GetPreconditions())
		{
			if (!currMemory.CheckCondition(agent, condition))
			{
				count++;
			}
		}
		return count;
	}
}

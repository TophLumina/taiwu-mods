using System;
using System.Collections.Generic;
using GameData.ActionPlanning.Interface;
using GameData.ActionPlanning.State;
using GameData.Utilities;

namespace GameData.ActionPlanning;

public class AStarPathfinder<TObject, TStateKey> : IPathfinder<TObject, TStateKey> where TStateKey : IStateKey<TStateKey>
{
	public delegate int CalcHeuristic(IAgent<TObject, TStateKey> agent, INode<TObject, TStateKey> curr, INode<TObject, TStateKey> dest);

	private readonly struct Node(INode<TObject, TStateKey> id, int g, int h) : IComparable<Node>
	{
		public readonly INode<TObject, TStateKey> Id = id;

		public readonly int G = g;

		public readonly int F = g + h;

		public int CompareTo(Node other)
		{
			return -F.CompareTo(other.F);
		}
	}

	private readonly Dictionary<INode<TObject, TStateKey>, INode<TObject, TStateKey>> _bestPath;

	private readonly MaxHeap<Node> _priorityQueue;

	private readonly Dictionary<INode<TObject, TStateKey>, int> _currentDist;

	private readonly CalcHeuristic _calcHeuristic;

	private IGraph<IAgent<TObject, TStateKey>, INode<TObject, TStateKey>> _graph;

	public AStarPathfinder(IGraph<IAgent<TObject, TStateKey>, INode<TObject, TStateKey>> graph, CalcHeuristic calcHeuristic)
	{
		_currentDist = new Dictionary<INode<TObject, TStateKey>, int>();
		_priorityQueue = new MaxHeap<Node>();
		_bestPath = new Dictionary<INode<TObject, TStateKey>, INode<TObject, TStateKey>>();
		_graph = graph;
		_calcHeuristic = calcHeuristic;
	}

	public void FindPath(IAgent<TObject, TStateKey> agent, IGoal<TObject, TStateKey> startNode, IList<INode<TObject, TStateKey>> nodesOnPath, int maxDepth)
	{
		throw new NotImplementedException();
	}

	public bool ReassessPath(IAgent<TObject, TStateKey> agent, IGoal<TObject, TStateKey> startNode, IList<INode<TObject, TStateKey>> nodesOnPath)
	{
		throw new NotImplementedException();
	}

	public void FindPath(IAgent<TObject, TStateKey> agent, INode<TObject, TStateKey> startNode, INode<TObject, TStateKey> endNode, List<INode<TObject, TStateKey>> nodesOnPath)
	{
		nodesOnPath.Clear();
		Generate(agent, startNode, endNode);
		if (_bestPath.Count > 0)
		{
			GetPathTo(startNode, endNode, nodesOnPath);
		}
	}

	private void Generate(IAgent<TObject, TStateKey> agent, INode<TObject, TStateKey> startNode, INode<TObject, TStateKey> endNode)
	{
		_currentDist.Clear();
		_bestPath.Clear();
		if (startNode.Equals(endNode))
		{
			return;
		}
		foreach (INode<TObject, TStateKey> toNode in _graph.GetNeighborNodes(startNode))
		{
			int h = _calcHeuristic(agent, toNode, endNode);
			int weight = _graph.GetWeight(agent, startNode, toNode);
			_priorityQueue.Push(new Node(toNode, weight, h));
			_currentDist.Add(toNode, weight);
			_bestPath.Add(toNode, startNode);
		}
		while (_priorityQueue.Count > 0)
		{
			Node node = _priorityQueue.Pop();
			if (node.Id.Equals(endNode))
			{
				break;
			}
			foreach (INode<TObject, TStateKey> toNode2 in _graph.GetNeighborNodes(node.Id))
			{
				int weight2 = _graph.GetWeight(agent, node.Id, toNode2);
				int g = node.G + weight2;
				if (GetCurrentG(toNode2) > g)
				{
					_currentDist[toNode2] = g;
					_bestPath[toNode2] = node.Id;
					int h2 = _calcHeuristic(agent, toNode2, endNode);
					_priorityQueue.Push(new Node(toNode2, g, h2));
				}
			}
		}
	}

	private void GetPathTo(INode<TObject, TStateKey> startNode, INode<TObject, TStateKey> endNode, List<INode<TObject, TStateKey>> nodesOnPath)
	{
		INode<TObject, TStateKey> currNode = endNode;
		while (!currNode.Equals(startNode))
		{
			nodesOnPath.Add(currNode);
			if (!_bestPath.TryGetValue(currNode, out var fromNode))
			{
				nodesOnPath.Clear();
				return;
			}
			currNode = fromNode;
		}
		nodesOnPath.Add(currNode);
		nodesOnPath.Reverse();
	}

	private int GetCurrentG(INode<TObject, TStateKey> node)
	{
		return _currentDist.GetValueOrDefault(node, int.MaxValue);
	}
}

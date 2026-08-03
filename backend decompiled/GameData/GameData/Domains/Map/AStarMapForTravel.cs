using System;
using System.Collections.Generic;

namespace GameData.Domains.Map;

public class AStarMapForTravel
{
	private class AStarNode
	{
		public short AreaId;

		public int GValue;

		public int HValue;

		public int FValue;

		public AStarNode ParentNode;
	}

	private class OpenNodeHandler
	{
		private List<AStarNode> _openNodeList;

		public void AddOpenNode(AStarNode node)
		{
			if (node == null || _openNodeList.Exists((AStarNode n) => n.AreaId == node.AreaId))
			{
				return;
			}
			bool added = false;
			for (int i = 0; i < _openNodeList.Count; i++)
			{
				if (_openNodeList[i].FValue > node.FValue)
				{
					_openNodeList.Insert(i, node);
					added = true;
					break;
				}
			}
			if (!added)
			{
				_openNodeList.Add(node);
			}
		}

		public void Sort()
		{
			_openNodeList?.Sort(delegate(AStarNode left, AStarNode right)
			{
				if (left.FValue != right.FValue)
				{
					return left.FValue - right.FValue;
				}
				return (left.HValue != right.HValue) ? (left.HValue - right.HValue) : (left.GValue - right.GValue);
			});
		}

		public AStarNode GetNodeByLocation(short areaId)
		{
			for (int i = 0; i < _openNodeList.Count; i++)
			{
				if (_openNodeList[i].AreaId == areaId)
				{
					return _openNodeList[i];
				}
			}
			return null;
		}

		public AStarNode GetBestOpenNode()
		{
			if (_openNodeList.Count <= 0)
			{
				return null;
			}
			AStarNode node = _openNodeList[0];
			_openNodeList.Remove(node);
			return node;
		}

		public void GetReady()
		{
			if (_openNodeList == null)
			{
				_openNodeList = new List<AStarNode>();
			}
			else
			{
				_openNodeList.Clear();
			}
		}
	}

	private Func<short, short, short> _getMoveCost;

	private OpenNodeHandler _openNodeHandler;

	private List<AStarNode> _closedList;

	private short _start;

	private short _end;

	public void InitMap(Func<short, short, short> getCostFunc)
	{
		_getMoveCost = getCostFunc;
		if (_openNodeHandler == null)
		{
			_openNodeHandler = new OpenNodeHandler();
		}
	}

	public void FindWay(short start, short end, ref List<short> path)
	{
		if (_closedList == null)
		{
			_closedList = new List<AStarNode>();
		}
		else
		{
			_closedList.Clear();
		}
		_openNodeHandler.GetReady();
		AStarNode nodeStart = new AStarNode();
		nodeStart.AreaId = start;
		nodeStart.GValue = 0;
		nodeStart.HValue = 0;
		nodeStart.FValue = nodeStart.HValue;
		_closedList.Add(nodeStart);
		if (start == end)
		{
			return;
		}
		_start = nodeStart.AreaId;
		_end = end;
		bool findFinish = false;
		List<AStarNode> firstAroundNodeList = GetNodeAround(nodeStart);
		foreach (AStarNode node in firstAroundNodeList)
		{
			if (node.AreaId != _end)
			{
				_openNodeHandler.AddOpenNode(node);
				continue;
			}
			_closedList.Add(node);
			findFinish = true;
			break;
		}
		while (!findFinish)
		{
			AStarNode bestNode = _openNodeHandler.GetBestOpenNode();
			if (bestNode == null)
			{
				return;
			}
			_closedList.Add(bestNode);
			List<AStarNode> nodeList = GetNodeAround(bestNode);
			foreach (AStarNode node2 in nodeList)
			{
				if (node2.AreaId != _end)
				{
					_openNodeHandler.AddOpenNode(node2);
					continue;
				}
				_closedList.Add(node2);
				findFinish = true;
				break;
			}
		}
		ConvertResult(ref path);
	}

	private List<AStarNode> GetNodeAround(AStarNode nowNode)
	{
		List<AStarNode> nodeList = new List<AStarNode>();
		HashSet<short> neighbors = DomainManager.Map.GetElement_Areas(nowNode.AreaId).NeighborAreas;
		foreach (short areaId in neighbors)
		{
			CreateNode(areaId, nowNode, nodeList);
		}
		return nodeList;
	}

	private void CreateNode(short nodeLocation, AStarNode nowNode, List<AStarNode> nodeList)
	{
		if (_closedList.Exists((AStarNode aStarNode) => aStarNode.AreaId == nodeLocation))
		{
			return;
		}
		short moveCost = _getMoveCost(nowNode.AreaId, nodeLocation);
		AStarNode node = _openNodeHandler.GetNodeByLocation(nodeLocation);
		if (node != null)
		{
			int gValue = nowNode.GValue + moveCost;
			if (gValue < node.GValue)
			{
				node.GValue = gValue;
				node.FValue = node.GValue + node.HValue;
				node.ParentNode = nowNode;
				_openNodeHandler.Sort();
				nodeList.Add(node);
			}
		}
		else
		{
			node = new AStarNode();
			node.AreaId = nodeLocation;
			node.GValue = nowNode.GValue + moveCost;
			node.HValue = 0;
			node.FValue = node.GValue + node.HValue;
			node.ParentNode = nowNode;
			nodeList.Add(node);
		}
	}

	private void ConvertResult(ref List<short> path)
	{
		path.Clear();
		if (_closedList.Count <= 0)
		{
			return;
		}
		AStarNode node = _closedList[_closedList.Count - 1];
		while (true)
		{
			path.Add(node.AreaId);
			if (node.AreaId == _start)
			{
				break;
			}
			node = node.ParentNode;
			if (node == null)
			{
				break;
			}
			bool flag = true;
		}
		path.Reverse();
	}
}

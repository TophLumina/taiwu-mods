using System;
using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Map;

public class AStarMap
{
	private class AStarNode
	{
		public ByteCoordinate Location;

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
			if (node == null)
			{
				return;
			}
			if (_openNodeList.Count <= 0)
			{
				_openNodeList.Add(node);
			}
			else
			{
				if (_openNodeList.Find((AStarNode e) => e.Location == node.Location) != null)
				{
					return;
				}
				bool add = false;
				for (int i = 0; i < _openNodeList.Count; i++)
				{
					if (_openNodeList[i].FValue > node.FValue)
					{
						_openNodeList.Insert(i, node);
						add = true;
						break;
					}
				}
				if (!add)
				{
					_openNodeList.Add(node);
				}
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

		public AStarNode GetNodeByLocation(ByteCoordinate location)
		{
			for (int i = 0; i < _openNodeList.Count; i++)
			{
				if (_openNodeList[i].Location == location)
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

	private short[,] _mapMoveData;

	private int _mapWidth;

	private int _mapHeight;

	private Func<ByteCoordinate, sbyte> _getMoveCost;

	private OpenNodeHandler _openNodeHandler;

	private List<AStarNode> _closedList;

	private ByteCoordinate _start;

	private ByteCoordinate _end;

	public void InitMap(int mapWidth, int mapHeight, Func<ByteCoordinate, sbyte> getCostFunc)
	{
		_getMoveCost = getCostFunc;
		_mapWidth = mapWidth;
		_mapHeight = mapHeight;
		_mapMoveData = new short[mapWidth, mapHeight];
		if (_openNodeHandler == null)
		{
			_openNodeHandler = new OpenNodeHandler();
		}
	}

	public void FindWay(ByteCoordinate start, ByteCoordinate end, ref List<ByteCoordinate> path, List<ByteCoordinate> avoidPosList = null)
	{
		if (_closedList == null)
		{
			_closedList = new List<AStarNode>();
		}
		else
		{
			_closedList.Clear();
		}
		if (!IsLocationValid(start) || !IsLocationValid(end))
		{
			return;
		}
		if (avoidPosList != null)
		{
			for (int i = 0; i < avoidPosList.Count; i++)
			{
				ByteCoordinate pos = avoidPosList[i];
				_mapMoveData[pos.X, pos.Y] = 1000;
			}
		}
		if (_mapMoveData[end.X, end.Y] <= 0)
		{
			_mapMoveData[end.X, end.Y] = _getMoveCost(end);
		}
		if (-1 == _mapMoveData[end.X, end.Y])
		{
			return;
		}
		_openNodeHandler.GetReady();
		AStarNode nodeStart = new AStarNode();
		nodeStart.Location = start;
		nodeStart.GValue = 0;
		nodeStart.HValue = start.GetManhattanDistance(end);
		nodeStart.FValue = nodeStart.HValue;
		_closedList.Add(nodeStart);
		if (start == end)
		{
			return;
		}
		_start = nodeStart.Location;
		_end = end;
		List<ByteCoordinate> endList = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		endList.Clear();
		bool findFinish = false;
		List<AStarNode> firstAroundNodeList = GetNodeAround(nodeStart, end);
		foreach (AStarNode node in firstAroundNodeList)
		{
			bool isGroupReach = endList.Contains(node.Location);
			if (node.Location != _end && !isGroupReach)
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
			List<AStarNode> nodeList = GetNodeAround(bestNode, end);
			foreach (AStarNode node2 in nodeList)
			{
				bool isGroupReach2 = endList.Contains(node2.Location);
				if (node2.Location != _end && !isGroupReach2)
				{
					_openNodeHandler.AddOpenNode(node2);
					continue;
				}
				_closedList.Add(node2);
				findFinish = true;
				break;
			}
		}
		ObjectPool<List<ByteCoordinate>>.Instance.Return(endList);
		ConvertResult(ref path);
	}

	private List<AStarNode> GetNodeAround(AStarNode nowNode, ByteCoordinate end)
	{
		List<AStarNode> nodeList = new List<AStarNode>();
		List<ByteCoordinate> neighbors = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		neighbors.Clear();
		if (nowNode.Location.X > 0)
		{
			neighbors.Add(new ByteCoordinate((byte)(nowNode.Location.X - 1), nowNode.Location.Y));
		}
		if (nowNode.Location.X < _mapWidth - 1)
		{
			neighbors.Add(new ByteCoordinate((byte)(nowNode.Location.X + 1), nowNode.Location.Y));
		}
		if (nowNode.Location.Y > 0)
		{
			neighbors.Add(new ByteCoordinate(nowNode.Location.X, (byte)(nowNode.Location.Y - 1)));
		}
		if (nowNode.Location.Y < _mapHeight - 1)
		{
			neighbors.Add(new ByteCoordinate(nowNode.Location.X, (byte)(nowNode.Location.Y + 1)));
		}
		for (int i = 0; i < neighbors.Count; i++)
		{
			CreateNode(neighbors[i], nowNode, nodeList, end);
		}
		ObjectPool<List<ByteCoordinate>>.Instance.Return(neighbors);
		return nodeList;
	}

	private void CreateNode(ByteCoordinate nodeLocation, AStarNode nowNode, List<AStarNode> nodeList, ByteCoordinate end)
	{
		if (!IsLocationValid(nodeLocation))
		{
			return;
		}
		if (_mapMoveData[nodeLocation.X, nodeLocation.Y] <= 0)
		{
			_mapMoveData[nodeLocation.X, nodeLocation.Y] = _getMoveCost(nodeLocation);
		}
		if (-1 == _mapMoveData[nodeLocation.X, nodeLocation.Y])
		{
			return;
		}
		for (int i = 0; i < _closedList.Count; i++)
		{
			if (_closedList[i].Location == nodeLocation)
			{
				return;
			}
		}
		AStarNode node = _openNodeHandler.GetNodeByLocation(nodeLocation);
		if (node != null)
		{
			int gValue = nowNode.GValue + _mapMoveData[nodeLocation.X, nodeLocation.Y];
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
			node.Location = nodeLocation;
			node.GValue = nowNode.GValue + _mapMoveData[nodeLocation.X, nodeLocation.Y];
			node.HValue = end.GetManhattanDistance(nodeLocation);
			node.FValue = node.GValue + node.HValue;
			node.ParentNode = nowNode;
			nodeList.Add(node);
		}
	}

	private bool IsLocationValid(ByteCoordinate pos)
	{
		return pos.X >= 0 && pos.X < _mapWidth && pos.Y >= 0 && pos.Y < _mapHeight;
	}

	private void ConvertResult(ref List<ByteCoordinate> path)
	{
		path.Clear();
		if (_closedList.Count <= 0)
		{
			return;
		}
		AStarNode node = _closedList[_closedList.Count - 1];
		while (true)
		{
			path.Add(node.Location);
			if (node.Location == _start)
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

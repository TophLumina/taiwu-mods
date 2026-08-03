using System;
using System.Collections.Generic;
using System.Linq;

namespace GameData.Common.Algorithm;

public class AStarAlgorithm<T> where T : IAStarPos<T>
{
	public delegate IEnumerable<T> GetValidNeighbors(T pos, int step);

	public delegate int GetMoveCost(T pos, int step);

	public struct AStarPoint(T position) : IComparable<AStarPoint>, IEquatable<AStarPoint>
	{
		public T Position = position;

		public T Parent = default(T);

		public int GValue;

		public int HValue;

		public int FValue;

		public int Step = (GValue = (HValue = (FValue = 0)));

		public int CompareTo(AStarPoint other)
		{
			return FValue.CompareTo(other.FValue);
		}

		public bool Equals(AStarPoint other)
		{
			ref T position = ref Position;
			T position2 = other.Position;
			return position.Equals(position2);
		}

		public override bool Equals(object obj)
		{
			if (obj is AStarPoint point)
			{
				return Equals(point);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return EqualityComparer<T>.Default.GetHashCode(Position);
		}

		public static bool operator ==(AStarPoint left, AStarPoint right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(AStarPoint left, AStarPoint right)
		{
			return !left.Equals(right);
		}

		public override string ToString()
		{
			return $"AStarPoint({Position})[G={GValue}, H={HValue}, F={FValue}, Step={Step}, Parent=({Parent})]";
		}
	}

	private readonly GetValidNeighbors _getValidNeighbors;

	private readonly GetMoveCost _getMoveCost;

	private readonly List<T> _path = new List<T>();

	private AStarPoint _start;

	private AStarPoint _end;

	private readonly List<AStarPoint> _open = new List<AStarPoint>();

	private readonly List<AStarPoint> _close = new List<AStarPoint>();

	public AStarAlgorithm(GetValidNeighbors getValidNeighbors, GetMoveCost getMoveCost)
	{
		_getValidNeighbors = getValidNeighbors;
		_getMoveCost = getMoveCost;
	}

	public IReadOnlyList<T> FindShortestPath(T from, T to)
	{
		_start = new AStarPoint(from);
		_end = new AStarPoint(to);
		if (!FindShortestPath())
		{
			return null;
		}
		return GetShortestPath();
	}

	private bool FindShortestPath()
	{
		_open.Clear();
		_close.Clear();
		ref T position = ref _start.Position;
		T position2 = _end.Position;
		if (position.Equals(position2))
		{
			return false;
		}
		_open.Add(_start);
		while (_open.Count != 0)
		{
			AStarPoint temp = _open.Min();
			int minIndex = _open.IndexOf(temp);
			_open.RemoveAt(minIndex);
			_close.Add(temp);
			foreach (AStarPoint point in SpreadPoint(temp))
			{
				T position3 = point.Position;
				if (position3.Equals(_end.Position))
				{
					return true;
				}
				_open.Add(point);
			}
		}
		return false;
	}

	private IReadOnlyList<T> GetShortestPath()
	{
		_path.Clear();
		_path.Add(_end.Position);
		List<AStarPoint> close = _close;
		AStarPoint current = close[close.Count - 1];
		while (true)
		{
			ref T position = ref current.Position;
			T position2 = _start.Position;
			if (position.Equals(position2))
			{
				break;
			}
			_path.Add(current.Position);
			foreach (AStarPoint point in _close)
			{
				T position3 = point.Position;
				if (position3.Equals(current.Parent))
				{
					current = point;
					break;
				}
			}
		}
		_path.Add(_start.Position);
		_path.Reverse();
		return _path;
	}

	private IEnumerable<AStarPoint> SpreadPoint(AStarPoint point)
	{
		foreach (T neighbor in _getValidNeighbors(point.Position, point.Step))
		{
			AStarPoint temp = new AStarPoint(neighbor);
			if (!CheckPoint(ref temp))
			{
				continue;
			}
			CalcAndSave(ref point, ref temp);
			if (!_open.Contains(temp) || _open.First(delegate(AStarPoint x)
			{
				ref T position = ref x.Position;
				T position2 = temp.Position;
				return position.Equals(position2);
			}).FValue > temp.FValue)
			{
				if (_open.Contains(temp))
				{
					_open.Remove(temp);
				}
				yield return temp;
			}
		}
	}

	private bool CheckPoint(ref AStarPoint point)
	{
		return !_close.Contains(point);
	}

	private void CalcAndSave(ref AStarPoint parent, ref AStarPoint point)
	{
		point.Step = parent.Step + 1;
		point.GValue = parent.GValue + Math.Max(_getMoveCost(point.Position, point.Step), 1);
		ref T position = ref point.Position;
		T position2 = _end.Position;
		point.HValue = position.GetManhattanDistance(position2);
		point.FValue = point.GValue + point.HValue;
		point.Parent = parent.Position;
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameData.Common.Algorithm;

public class DijkstraAlgorithm<T> where T : IEquatable<T>
{
	public delegate IEnumerable<(T pos, int cost)> DijkstraAlgorithmGetNeighbors(T pos);

	public delegate string DijkstraAlgorithmNameProvider(T pos);

	public class DijkstraAlgorithmData
	{
		public DijkstraAlgorithmNameProvider NameProvider;

		public T Invalid { get; }

		public StringBuilder Builder { get; } = new StringBuilder();

		public DijkstraAlgorithmData(T invalid)
		{
			Invalid = invalid;
		}
	}

	public interface IReadonlyDijkstraNode
	{
		T Pos { get; }

		T Last { get; }

		int Cost { get; }
	}

	public class DijkstraNode : IEquatable<DijkstraNode>, IReadonlyDijkstraNode
	{
		public DijkstraAlgorithmData Data { get; }

		public T Pos { get; }

		public T Last { get; set; }

		public int Cost { get; set; }

		public bool Marked { get; set; }

		public DijkstraNode(DijkstraAlgorithmData data, T pos)
		{
			Data = data;
			Pos = pos;
			Last = data.Invalid;
			Cost = -1;
			Marked = false;
		}

		public void Reset()
		{
			Last = Data.Invalid;
			Cost = -1;
			Marked = false;
		}

		public void Change(bool marked)
		{
			Change(Last, Cost, marked);
		}

		public void Change(int cost, bool marked = true)
		{
			Change(Last, cost, marked);
		}

		public void Change(T last, int cost, bool marked)
		{
			Last = last;
			Cost = cost;
			Marked = marked;
		}

		public bool Equals(DijkstraNode other)
		{
			if (other != null)
			{
				return Pos.Equals(other.Pos);
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as DijkstraNode);
		}

		public override int GetHashCode()
		{
			return EqualityComparer<T>.Default.GetHashCode(Pos);
		}

		private string ParseString(T pos)
		{
			DijkstraAlgorithmNameProvider nameProvider = Data?.NameProvider;
			return string.Format("{0}{1}", pos, (nameProvider == null) ? string.Empty : (" " + nameProvider(pos)));
		}

		private string ToStringBasic()
		{
			return "Node " + ParseString(Pos);
		}

		private string ToStringInternal()
		{
			if (Cost < 0)
			{
				return "Not yet";
			}
			StringBuilder builder = Data.Builder;
			builder.Clear();
			builder.Append('(');
			if (Marked)
			{
				builder.Append("Marked ");
			}
			builder.Append($"cost {Cost}");
			if (!Last.Equals(Data.Invalid))
			{
				builder.Append(", found in " + ParseString(Last));
			}
			builder.Append(')');
			return builder.ToString();
		}

		public override string ToString()
		{
			return ToStringBasic() + " : " + ToStringInternal();
		}
	}

	private DijkstraAlgorithmGetNeighbors _getNeighbors;

	private Dictionary<T, DijkstraNode> _dijkstraNodes;

	private readonly List<DijkstraNode> _path = new List<DijkstraNode>();

	public DijkstraAlgorithmData Data { get; private set; }

	public void Initialize(IEnumerable<T> allPos, DijkstraAlgorithmGetNeighbors getNeighbors, T invalid)
	{
		Data = new DijkstraAlgorithmData(invalid);
		_dijkstraNodes = allPos.ToDictionary((T pos) => pos, (T pos) => new DijkstraNode(Data, pos)
		{
			Marked = false
		});
		_getNeighbors = getNeighbors;
	}

	public IReadOnlyList<IReadonlyDijkstraNode> FindShortestPath(T from, T to)
	{
		lock (_path)
		{
			return FindShortestPathInternal(from, to) ? _path : null;
		}
	}

	private DijkstraNode GetMinNode()
	{
		DijkstraNode min = null;
		foreach (DijkstraNode node in _dijkstraNodes.Values)
		{
			if (!node.Marked && node.Cost >= 0 && (min == null || node.Cost < min.Cost))
			{
				min = node;
			}
		}
		return min;
	}

	private void CalculateNeighbors(DijkstraNode node)
	{
		foreach (var item in _getNeighbors(node.Pos))
		{
			T pos = item.pos;
			int cost = item.cost;
			int trulyCost = Math.Max(node.Cost + cost, 1);
			DijkstraNode neighborNode = _dijkstraNodes[pos];
			if (!neighborNode.Marked && (neighborNode.Cost <= 0 || neighborNode.Cost > trulyCost))
			{
				neighborNode.Change(node.Pos, trulyCost, marked: false);
			}
		}
	}

	private bool FindShortestPathInternal(T from, T to)
	{
		foreach (DijkstraNode value in _dijkstraNodes.Values)
		{
			value.Reset();
		}
		_path.Clear();
		DijkstraNode current = _dijkstraNodes[from];
		current.Change(0);
		while (current != null && !current.Pos.Equals(to))
		{
			CalculateNeighbors(current);
			current = GetMinNode();
			current?.Change(marked: true);
		}
		if (current == null)
		{
			return false;
		}
		DijkstraNode temp = current;
		while (temp != null)
		{
			_path.Add(temp);
			_dijkstraNodes.TryGetValue(temp.Last, out temp);
		}
		_path.Reverse();
		return true;
	}
}

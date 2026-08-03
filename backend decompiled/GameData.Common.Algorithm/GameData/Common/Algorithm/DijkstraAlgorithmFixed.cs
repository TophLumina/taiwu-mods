using System;
using System.Collections.Generic;

namespace GameData.Common.Algorithm;

public class DijkstraAlgorithmFixed<T> : DijkstraAlgorithm<T> where T : IEquatable<T>
{
	public delegate IEnumerable<T> DijkstraAlgorithmGetNeighborsFixed(T pos);

	private DijkstraAlgorithmGetNeighborsFixed _getNeighborsFixed;

	public void Initialize(IEnumerable<T> allPos, DijkstraAlgorithmGetNeighborsFixed getNeighborsFixed, T invalid)
	{
		_getNeighborsFixed = getNeighborsFixed;
		Initialize(allPos, (DijkstraAlgorithmGetNeighbors)GetNeighbors, invalid);
	}

	private IEnumerable<(T pos, int cost)> GetNeighbors(T pos)
	{
		foreach (T neighbor in _getNeighborsFixed(pos))
		{
			yield return (pos: neighbor, cost: 1);
		}
	}
}

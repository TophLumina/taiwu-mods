using System.Collections.Generic;

namespace GameData.Common.Algorithm;

public class AStarAlgorithmSimple<T> where T : IAStarPos<T>
{
	public delegate IEnumerable<T> GetValidNeighbors(T pos);

	public delegate int GetMoveCost(T pos);

	private readonly GetValidNeighbors _getValidNeighbors;

	private readonly GetMoveCost _getMoveCost;

	private readonly AStarAlgorithm<T> _algorithm;

	public AStarAlgorithmSimple(GetValidNeighbors getValidNeighbors, GetMoveCost getMoveCost)
	{
		_getValidNeighbors = getValidNeighbors;
		_getMoveCost = getMoveCost;
		_algorithm = new AStarAlgorithm<T>(GetValidNeighborsImplement, GetMoveCostImplement);
	}

	private IEnumerable<T> GetValidNeighborsImplement(T pos, int step)
	{
		return _getValidNeighbors(pos);
	}

	private int GetMoveCostImplement(T pos, int step)
	{
		return _getMoveCost(pos);
	}

	public IReadOnlyList<T> FindShortestPath(T from, T to)
	{
		return _algorithm.FindShortestPath(from, to);
	}
}

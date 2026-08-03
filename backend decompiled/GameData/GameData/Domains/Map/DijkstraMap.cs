using System.Collections.Generic;
using GameData.Common.Algorithm;

namespace GameData.Domains.Map;

public class DijkstraMap : DijkstraAlgorithm<short>
{
	public void Initialize(IEnumerable<short> allAreas, DijkstraAlgorithmGetNeighbors getNeighborsDelegate)
	{
		Initialize(allAreas, getNeighborsDelegate, -1);
	}
}

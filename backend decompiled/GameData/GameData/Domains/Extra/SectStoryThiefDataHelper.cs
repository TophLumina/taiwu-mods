using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Extra;

public static class SectStoryThiefDataHelper
{
	public static void UpdatePlace(this SectStoryThiefData data, IRandomSource random)
	{
		List<int> notTriggeredThiefIndexes = ObjectPool<List<int>>.Instance.Get();
		for (int i = 0; i < data.ThiefBlockIds.Count; i++)
		{
			if (!data.ThiefTriggered[i])
			{
				notTriggeredThiefIndexes.Add(i);
			}
		}
		if (notTriggeredThiefIndexes.Count > 0)
		{
			List<MapBlockData> neighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
			List<MapBlockData> newCenterNeighborBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
			MapBlockData centerBlock = DomainManager.Map.GetBlock(data.AreaId, data.ThiefBlockIds[notTriggeredThiefIndexes[0]]);
			ByteCoordinate centerBlockPos = centerBlock.GetBlockPos();
			DomainManager.Map.GetRealNeighborBlocks(data.AreaId, centerBlock.BlockId, neighborBlocks, 3);
			neighborBlocks.RemoveAll(IsBlockUnAvailable);
			neighborBlocks.Sort((MapBlockData blockA, MapBlockData blockB) => blockA.GetBlockPos().GetManhattanDistance(centerBlockPos).CompareTo(blockB.GetBlockPos().GetManhattanDistance(centerBlockPos)));
			foreach (MapBlockData block in neighborBlocks)
			{
				DomainManager.Map.GetRealNeighborBlocks(data.AreaId, block.BlockId, newCenterNeighborBlocks);
				newCenterNeighborBlocks.RemoveAll(IsBlockUnAvailable);
				if (newCenterNeighborBlocks.Count < notTriggeredThiefIndexes.Count)
				{
					continue;
				}
				CollectionUtils.Shuffle(random, newCenterNeighborBlocks);
				for (int i2 = 0; i2 < notTriggeredThiefIndexes.Count; i2++)
				{
					data.ThiefBlockIds[notTriggeredThiefIndexes[i2]] = newCenterNeighborBlocks[i2].BlockId;
				}
				break;
			}
			ObjectPool<List<MapBlockData>>.Instance.Return(neighborBlocks);
			ObjectPool<List<MapBlockData>>.Instance.Return(newCenterNeighborBlocks);
		}
		ObjectPool<List<int>>.Instance.Return(notTriggeredThiefIndexes);
	}

	public static bool IsBlockAvailable(MapBlockData blockData)
	{
		if (!blockData.IsPassable() || blockData.IsCityTown())
		{
			return false;
		}
		if (blockData.GetLocation() == DomainManager.Taiwu.GetTaiwu().GetLocation())
		{
			return false;
		}
		if (DomainManager.Story.TryGetThief(blockData.GetLocation(), out var _, out var _))
		{
			return false;
		}
		if (DomainManager.Map.IsCricketInLocation(blockData.GetLocation()))
		{
			return false;
		}
		return !DomainManager.Map.IsBlockSpecial(blockData, strictCheck: false);
	}

	public static bool IsBlockUnAvailable(MapBlockData blockData)
	{
		return !IsBlockAvailable(blockData);
	}
}

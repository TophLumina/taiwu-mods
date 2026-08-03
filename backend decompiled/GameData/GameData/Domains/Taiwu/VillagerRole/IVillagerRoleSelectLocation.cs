using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Taiwu.VillagerRole;

public interface IVillagerRoleSelectLocation
{
	Location SelectNextWorkLocation(IRandomSource random, Location baseLocation)
	{
		if (baseLocation.BlockId >= 0)
		{
			MapBlockData block = DomainManager.Map.GetBlock(baseLocation);
			List<MapBlockData> groupBlockList = block.GroupBlockList;
			return (groupBlockList != null && groupBlockList.Count > 0) ? block.GroupBlockList.GetRandom(random).GetLocation() : baseLocation;
		}
		List<MapBlockData> validBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetMapBlocksInAreaByFilters(baseLocation.AreaId, NextLocationFilter, validBlocks);
		if (validBlocks.Count == 0)
		{
			ObjectPool<List<MapBlockData>>.Instance.Return(validBlocks);
			short stationBlockId = DomainManager.Map.GetElement_Areas(baseLocation.AreaId).StationBlockId;
			return new Location(baseLocation.AreaId, stationBlockId);
		}
		MapBlockData nextBlock = validBlocks.GetRandom(random);
		ObjectPool<List<MapBlockData>>.Instance.Return(validBlocks);
		return nextBlock.GetLocation();
	}

	bool NextLocationFilter(MapBlockData block)
	{
		return !block.IsNonDeveloped() && block.CharacterSet != null;
	}

	static bool MatchWorkLocation(Location workLocation, Location currLocation)
	{
		if (workLocation.BlockId >= 0 && !DomainManager.Map.CheckLocationsHasSameRoot(workLocation, currLocation))
		{
			return false;
		}
		if (workLocation.BlockId < 0 && workLocation.AreaId != currLocation.AreaId)
		{
			return false;
		}
		return true;
	}
}

using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Map;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Adventure;

public static class ResourceDisasterHelper
{
	private static Dictionary<sbyte, List<int>> _resourceTypeToAdventureCoreIdsCache;

	private static Dictionary<sbyte, List<int>> GenerateCache()
	{
		Dictionary<sbyte, List<int>> result = new Dictionary<sbyte, List<int>>();
		foreach (ResourceDisasterItem config in (IEnumerable<ResourceDisasterItem>)ResourceDisaster.Instance)
		{
			result.GetOrNew(config.ResourceType).AddUnique(config.TargetId);
		}
		return result;
	}

	public static bool IsDisasterAdventure(int coreId)
	{
		foreach (ResourceDisasterItem config in (IEnumerable<ResourceDisasterItem>)ResourceDisaster.Instance)
		{
			if (config.TargetId == coreId)
			{
				return true;
			}
		}
		return false;
	}

	public static bool GenerateDisasterAdventure(DataContext context, sbyte resourceType, Location location)
	{
		if (DomainManager.Adventure.QueryAnyAdventureOrMajorEvent(location))
		{
			return false;
		}
		int coreId = RandomDisasterAdventureId(context.Random, resourceType);
		return coreId > 0 && DomainManager.Adventure.GenerateAny(context, coreId, location) != null;
	}

	public static int RandomDisasterAdventureId(IRandomSource random, sbyte resourceType)
	{
		if (_resourceTypeToAdventureCoreIdsCache == null)
		{
			_resourceTypeToAdventureCoreIdsCache = GenerateCache();
		}
		List<int> coreIds = _resourceTypeToAdventureCoreIdsCache.GetOrDefault(resourceType);
		return (coreIds != null && coreIds.Count > 0) ? coreIds.GetRandom(random) : 0;
	}

	public static int RandomDisasterAdventureId(IRandomSource random, MapBlockData block)
	{
		if (DomainManager.Adventure.QueryAnyAdventureOrMajorEvent(block))
		{
			return 0;
		}
		if (!random.CheckPercentProb(GlobalConfig.Instance.DisasterAdventureSpawnChance))
		{
			return 0;
		}
		if (_resourceTypeToAdventureCoreIdsCache == null)
		{
			_resourceTypeToAdventureCoreIdsCache = GenerateCache();
		}
		List<int> pool = ObjectPool<List<int>>.Instance.Get();
		for (sbyte i = 0; i < 6; i++)
		{
			List<int> coreIds = _resourceTypeToAdventureCoreIdsCache.GetOrDefault(i);
			if (coreIds != null && coreIds.Count > 0)
			{
				pool.AddUniqueRange(coreIds);
			}
		}
		int result = ((pool.Count > 0) ? pool.GetRandom(random) : 0);
		ObjectPool<List<int>>.Instance.Return(pool);
		return result;
	}
}

using System.Collections.Generic;
using Config;
using GameData.Utilities;

namespace GameData.Domains.Map;

public static class MapBlockMatcherHelper
{
	public static void UnstableFilter(this MapBlockMatcherItem matcherItem, List<MapBlockData> mapBlockList)
	{
		for (int i = mapBlockList.Count - 1; i >= 0; i--)
		{
			if (!matcherItem.Match(mapBlockList[i]))
			{
				CollectionUtils.SwapAndRemove(mapBlockList, i);
			}
		}
	}

	public static bool Match(this MapBlockMatcherItem matcherItem, MapBlockData mapBlockData)
	{
		if (!matcherItem.MatchType(mapBlockData.BlockType))
		{
			return false;
		}
		if (!matcherItem.MatchSubType(mapBlockData.BlockSubType))
		{
			return false;
		}
		if (matcherItem.ExcludeBlocksWithAdventure && DomainManager.Adventure.QueryAnyAdventureOrMajorEvent(mapBlockData))
		{
			return false;
		}
		if (matcherItem.ExcludeBlocksWithEffect && MatchBlockWithEffect(mapBlockData))
		{
			return false;
		}
		return true;
	}

	private static bool MatchBlockWithEffect(MapBlockData mapBlockData)
	{
		Location location = mapBlockData.GetLocation();
		if (DomainManager.Extra.GetSectEmeiBloodLocations().Contains(location))
		{
			return true;
		}
		if (DomainManager.Extra.GetSectXuehouBloodLightLocations().Contains(location))
		{
			return true;
		}
		if (DomainManager.Map.IsLocationInFulongFlameArea(location))
		{
			return true;
		}
		return false;
	}

	private static bool MatchType(this MapBlockMatcherItem matcherItem, EMapBlockType blockType)
	{
		EMapBlockType[] excludeTypes = matcherItem.ExcludeTypes;
		if (excludeTypes != null && excludeTypes.Length > 0)
		{
			for (int i = 0; i < matcherItem.ExcludeTypes.Length; i++)
			{
				if (matcherItem.ExcludeTypes[i] == blockType)
				{
					return false;
				}
			}
		}
		excludeTypes = matcherItem.IncludeTypes;
		if (excludeTypes != null && excludeTypes.Length > 0)
		{
			for (int j = 0; j < matcherItem.IncludeTypes.Length; j++)
			{
				if (matcherItem.IncludeTypes[j] == blockType)
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}

	private static bool MatchSubType(this MapBlockMatcherItem matcherItem, EMapBlockSubType blockSubType)
	{
		EMapBlockSubType[] excludeSubTypes = matcherItem.ExcludeSubTypes;
		if (excludeSubTypes != null && excludeSubTypes.Length > 0)
		{
			for (int i = 0; i < matcherItem.ExcludeSubTypes.Length; i++)
			{
				if (matcherItem.ExcludeSubTypes[i] == blockSubType)
				{
					return false;
				}
			}
		}
		excludeSubTypes = matcherItem.IncludeSubTypes;
		if (excludeSubTypes != null && excludeSubTypes.Length > 0)
		{
			for (int j = 0; j < matcherItem.IncludeSubTypes.Length; j++)
			{
				if (matcherItem.IncludeSubTypes[j] == blockSubType)
				{
					return true;
				}
			}
			return false;
		}
		return true;
	}
}

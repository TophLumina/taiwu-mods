using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Map;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Story.MainStory;

public static class TwelveImmortalsHelper
{
	public static IEnumerable<GameData.Domains.Character.Character> GetImpactRangeCharacters(this TwelveImmortalsItem config, GameData.Domains.Character.Character immortal = null)
	{
		foreach (MapBlockData block in config.GetImpactRangeBlocks(immortal))
		{
			HashSet<int> characterSet = block.CharacterSet;
			if (characterSet == null || characterSet.Count <= 0)
			{
				continue;
			}
			foreach (int charId in block.CharacterSet)
			{
				if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
				{
					yield return character;
				}
				character = null;
			}
		}
	}

	public static IEnumerable<MapBlockData> GetImpactRangeBlocks(this TwelveImmortalsItem config, GameData.Domains.Character.Character immortal = null)
	{
		if (immortal == null)
		{
			DomainManager.Character.TryGetFixedCharacterByTemplateId(config.Character, out immortal);
		}
		if (immortal == null)
		{
			yield break;
		}
		Location location = immortal.GetLocation();
		if (!location.IsValid())
		{
			yield break;
		}
		List<MapBlockData> blocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetRealNeighborBlocks(location.AreaId, location.BlockId, blocks, config.ImpactRange, includeCenter: true);
		foreach (MapBlockData item in blocks)
		{
			yield return item;
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(blocks);
	}

	public static TwelveImmortalsItem GetTwelveImmortalsConfig(this GameData.Domains.Character.Character immortal)
	{
		short templateId = immortal.GetTemplateId();
		foreach (TwelveImmortalsItem config in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
		{
			if (config.Character == templateId)
			{
				return config;
			}
		}
		return null;
	}

	public static Location GetTwelveImmortalsNextLocation(this GameData.Domains.Character.Character immortal, IRandomSource random)
	{
		TwelveImmortalsItem config = immortal.GetTwelveImmortalsConfig();
		if (config == null)
		{
			throw new ArgumentException($"Failed to get next location because {immortal} is not a Twelve Immortals");
		}
		short nextAreaTemplateId = immortal.GetTwelveImmortalsNextAreaId(config, random);
		short nextAreaId = DomainManager.Map.GetAreaIdByAreaTemplateId(nextAreaTemplateId);
		short nextBlockId = GetTwelveImmortalsNextBlockId(nextAreaId, random);
		if (nextBlockId < 0)
		{
			nextBlockId = DomainManager.Map.GetRandomEdgeBlock(random, nextAreaId);
		}
		return new Location(nextAreaId, nextBlockId);
	}

	private static short GetTwelveImmortalsNextAreaId(this GameData.Domains.Character.Character immortal, TwelveImmortalsItem config, IRandomSource random)
	{
		Location prevLocation = immortal.GetLocation();
		if (prevLocation.IsValid())
		{
			MapAreaData areaData = DomainManager.Map.GetElement_Areas(prevLocation.AreaId);
			MapAreaItem area = areaData.GetConfig();
			MapStateItem state = MapState.Instance[area.StateID];
			return (area.TemplateId == state.SectAreaID) ? state.MainAreaID : state.SectAreaID;
		}
		sbyte stateTemplateId = config.MapState;
		MapStateItem stateCfg = MapState.Instance[stateTemplateId];
		return random.NextBool() ? stateCfg.MainAreaID : stateCfg.SectAreaID;
	}

	public static short GetTwelveImmortalsNextBlockId(short nextAreaId, IRandomSource random)
	{
		short result = -1;
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(nextAreaId);
		SettlementInfo[] settlementInfos = areaData.SettlementInfos;
		if (settlementInfos == null || settlementInfos.Length <= 0)
		{
			return result;
		}
		byte areaSize = DomainManager.Map.GetAreaSize(nextAreaId);
		List<ByteCoordinate> settlementPos = ObjectPool<List<ByteCoordinate>>.Instance.Get();
		SettlementInfo[] settlementInfos2 = areaData.SettlementInfos;
		for (int i = 0; i < settlementInfos2.Length; i++)
		{
			SettlementInfo settlementInfo = settlementInfos2[i];
			if (settlementInfo.BlockId >= 0)
			{
				settlementPos.Add(ByteCoordinate.IndexToCoordinate(settlementInfo.BlockId, areaSize));
			}
		}
		if (settlementPos != null && settlementPos.Count > 0)
		{
			List<short> pool = ObjectPool<List<short>>.Instance.Get();
			Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(nextAreaId);
			Span<MapBlockData> span = areaBlocks;
			for (int j = 0; j < span.Length; j++)
			{
				MapBlockData block = span[j];
				if (block.IsPassable())
				{
					ByteCoordinate blockPos = ByteCoordinate.IndexToCoordinate(block.BlockId, areaSize);
					if (!settlementPos.All(delegate(ByteCoordinate x)
					{
						int manhattanDistance = x.GetManhattanDistance(blockPos);
						return (manhattanDistance < 4 || manhattanDistance > 6) ? true : false;
					}))
					{
						pool.Add(block.BlockId);
					}
				}
			}
			if (pool.Count > 0)
			{
				result = pool.GetRandom(random);
			}
			ObjectPool<List<short>>.Instance.Return(pool);
		}
		ObjectPool<List<ByteCoordinate>>.Instance.Return(settlementPos);
		return result;
	}

	public static void AddTwelveImmortalsFeatureAutoDetected(DataContext context, GameData.Domains.Character.Character character)
	{
		if (character.GetTwelveImmortalsConfig() != null)
		{
			AddTwelveImmortalsFeatureForTwelveImmortals(context, character);
		}
		else
		{
			AddTwelveImmortalsFeature(context, character);
		}
	}

	public static void AddTwelveImmortalsFeature(DataContext context, GameData.Domains.Character.Character character)
	{
		bool noFeature = character.GetCreatingType() == 1;
		foreach (TwelveImmortalsItem immortal in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
		{
			bool needFeature = DomainManager.Story.TaiwuAsXiangshuIsTwelveImmortalsAlive(immortal);
			character.ChangeFeature(context, immortal.BonusFeature, needFeature && !noFeature);
		}
		character.SetFeatureIds(character.GetFeatureIds(), context);
	}

	public static void AddTwelveImmortalsFeatureForTwelveImmortals(DataContext context, GameData.Domains.Character.Character character)
	{
		bool noFeature = character.GetCreatingType() == 1;
		short templateId = character.GetTemplateId();
		foreach (TwelveImmortalsItem immortal in (IEnumerable<TwelveImmortalsItem>)TwelveImmortals.Instance)
		{
			bool bonusDefeated = !DomainManager.Story.TaiwuAsXiangshuIsTwelveImmortalsAlive(immortal);
			bool bonusNormal = !bonusDefeated && templateId == immortal.Character;
			character.ChangeFeature(context, immortal.BonusFeature, bonusNormal && !noFeature);
			character.ChangeFeature(context, immortal.BonusFeatureInDefeated, bonusDefeated && !noFeature);
		}
		character.SetFeatureIds(character.GetFeatureIds(), context);
	}
}

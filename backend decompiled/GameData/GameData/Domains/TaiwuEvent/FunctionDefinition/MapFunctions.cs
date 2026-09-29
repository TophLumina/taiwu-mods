using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Combat;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class MapFunctions
{
	[EventFunction(54)]
	private static void ChangeSpiritualDebtByAreaId(EventScriptRuntime runtime, MapAreaData areaData, int changeValue)
	{
		DomainManager.Extra.ChangeAreaSpiritualDebt(runtime.Context, areaData.GetId(), changeValue);
	}

	[EventFunction(57)]
	private static void SetBlockAndViewRangeVisible(EventScriptRuntime runtime, MapBlockData mapBlockData)
	{
		DomainManager.Map.SetBlockAndViewRangeVisible(runtime.Context, mapBlockData.AreaId, mapBlockData.BlockId);
	}

	[EventFunction(89)]
	private static void StartCombat(EventScriptRuntime runtime, GameData.Domains.Character.Character targetChar, short combatConfigId, string onFinishEvent, bool noGuard)
	{
		GameData.Domains.TaiwuEvent.EventHelper.EventHelper.StartCombat(targetChar.GetId(), combatConfigId, onFinishEvent, runtime.Current.ArgBox, noGuard);
	}

	[EventFunction(778)]
	private static void StartNpcCombat(EventScriptRuntime runtime, GameData.Domains.Character.Character leftChar, GameData.Domains.Character.Character rightChar, short combatConfigId, string onFinishEvent, bool noGuard)
	{
		CombatConfigItem config = CombatConfig.Instance[combatConfigId];
		if (config.ForceDefeatFrame == 0 || config.ForceDefeatType != ECombatConfigForceDefeatType.TiredMark)
		{
			throw new Exception($"Not support npc combat config with {config.TemplateId}");
		}
		List<int> leftTeam;
		List<int> rightTeam;
		if (noGuard)
		{
			leftTeam = new List<int> { leftChar.GetId() };
			rightTeam = new List<int> { rightChar.GetId() };
		}
		else
		{
			DataContext context = runtime.Context;
			CombatType combatType = (CombatType)config.CombatType;
			bool leftIntelligent = leftChar.GetCreatingType() == 1;
			bool rightIntelligent = rightChar.GetCreatingType() == 1;
			bool exceptGroupChar = leftIntelligent && rightIntelligent && leftChar.GetLeaderId() == rightChar.GetLeaderId();
			leftTeam = (leftIntelligent ? DomainManager.Character.GetIntelligentNpcCombatTeam(context, leftChar, combatType, exceptGroupChar) : DomainManager.Character.GetNonIntelligentNpcCombatTeam(context, leftChar));
			rightTeam = (rightIntelligent ? DomainManager.Character.GetIntelligentNpcCombatTeam(context, rightChar, combatType, exceptGroupChar) : DomainManager.Character.GetNonIntelligentNpcCombatTeam(context, rightChar));
		}
		EventArgBox argBox = runtime.Current.ArgBox;
		argBox?.Set("ProtectedByWeiQiCharacter", DomainManager.Character.GetAvoidDeathCharId());
		DomainManager.TaiwuEvent.SetListenerWithActionName(onFinishEvent, argBox, "CombatOver");
		DomainManager.TaiwuEvent.RecordCharacterEnterCombat();
		DomainManager.Combat.CombatEntry(leftTeam, rightTeam, combatConfigId);
	}

	[EventFunction(841)]
	private static void StartCombatWithSpecialTeammate(EventScriptRuntime runtime, GameData.Domains.Character.Character targetChar, GameData.Domains.Character.Character teammateChar, short combatConfigId, string onFinishEvent, bool noGuard)
	{
		CombatConfigItem config = CombatConfig.Instance[combatConfigId];
		CombatType combatType = (CombatType)config.CombatType;
		List<int> enemyTeam = new List<int>();
		if (noGuard)
		{
			enemyTeam.Add(targetChar.GetId());
		}
		else
		{
			DomainManager.Character.GetTaiwuCombatEnemyTeam(runtime.Context, targetChar, combatType, enemyTeam);
		}
		List<int> taiwuTeam = new List<int>
		{
			DomainManager.Taiwu.GetTaiwuCharId(),
			teammateChar.GetId()
		};
		EventArgBox argBox = runtime.Current.ArgBox;
		argBox?.Set("ProtectedByWeiQiCharacter", DomainManager.Character.GetAvoidDeathCharId());
		DomainManager.TaiwuEvent.SetListenerWithActionName(onFinishEvent, argBox, "CombatOver");
		DomainManager.TaiwuEvent.RecordCharacterEnterCombat();
		DomainManager.Combat.CombatEntry(taiwuTeam, enemyTeam, combatConfigId);
	}

	[EventFunction(184)]
	private static void SwitchEmeiBlood(EventScriptRuntime runtime, MapBlockData mapBlockData, bool isOn)
	{
		Location location = new Location(mapBlockData.AreaId, mapBlockData.BlockId);
		if (isOn)
		{
			DomainManager.Extra.TurnOnEmeiBlood(runtime.Context, location);
		}
		else
		{
			DomainManager.Extra.TurnOffEmeiBlood(runtime.Context, location);
		}
	}

	[EventFunction(167)]
	private static MapBlockData FilterMapBlockInRange(EventScriptRuntime runtime, MapBlockData mapBlockData, int minDistance, int maxDistance, short matcherTemplateId)
	{
		List<MapBlockData> blockDataList = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetLocationByDistance(mapBlockData.GetLocation(), minDistance, maxDistance, ref blockDataList);
		if (matcherTemplateId >= 0)
		{
			MapBlockMatcherItem matcher = MapBlockMatcher.Instance[matcherTemplateId];
			for (int i = blockDataList.Count - 1; i >= 0; i--)
			{
				if (!matcher.Match(blockDataList[i]))
				{
					CollectionUtils.SwapAndRemove(blockDataList, i);
				}
			}
		}
		MapBlockData selectedBlock = blockDataList.GetRandomOrDefault(runtime.Context.Random, null);
		ObjectPool<List<MapBlockData>>.Instance.Return(blockDataList);
		return selectedBlock;
	}

	[EventFunction(698)]
	private static MapBlockData FilterMapBlockOnEdge(EventScriptRuntime runtime, MapAreaData area, short matcherTemplateId)
	{
		short areaId = area.GetId();
		List<short> edgeBlockIdList = new List<short>();
		List<MapBlockData> mapBlockDataList = new List<MapBlockData>();
		DomainManager.Map.GetEdgeBlockList(area.GetId(), edgeBlockIdList);
		foreach (short blockId in edgeBlockIdList)
		{
			MapBlockData mapBlockData = DomainManager.Map.GetBlock(areaId, blockId);
			if (MapBlockMatcher.Instance[matcherTemplateId].Match(mapBlockData))
			{
				mapBlockDataList.Add(mapBlockData);
			}
		}
		return mapBlockDataList.GetRandomOrDefault(runtime.Context.Random, null);
	}

	[EventFunction(199)]
	private static MapBlockData GetSettlementMapBlock(EventScriptRuntime runtime, Settlement settlement)
	{
		Location location = settlement.GetLocation();
		return DomainManager.Map.GetBlock(location);
	}

	[EventFunction(354)]
	private static MapBlockData GetSettlementRandomMapBlock(EventScriptRuntime runtime, Settlement settlement)
	{
		Location location = settlement.GetLocation();
		List<short> blocks = ObjectPool<List<short>>.Instance.Get();
		DomainManager.Map.GetSettlementBlocks(location.AreaId, location.BlockId, blocks);
		short blockId = blocks.GetRandom(runtime.Context.Random);
		ObjectPool<List<short>>.Instance.Return(blocks);
		return DomainManager.Map.GetBlock(new Location(location.AreaId, blockId));
	}

	[EventFunction(198)]
	private static MapBlockData GetCharacterCurrentMapBlock(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		Location location = character.GetValidLocation();
		return DomainManager.Map.GetBlock(location);
	}

	[EventFunction(261)]
	private static MapAreaData GetCharacterCurrentMapArea(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		Location location = character.GetValidLocation();
		return DomainManager.Map.GetElement_Areas(location.AreaId);
	}

	[EventFunction(262)]
	private static MapAreaData GetSettlementMapArea(EventScriptRuntime runtime, Settlement settlement)
	{
		Location location = settlement.GetLocation();
		return DomainManager.Map.GetElement_Areas(location.AreaId);
	}

	[EventFunction(647)]
	private static Location GetMapBlockByCoordinate(MapAreaData areaData, int x, int y)
	{
		ByteCoordinate coordinate = new ByteCoordinate((byte)x, (byte)y);
		short blockId = ByteCoordinate.CoordinateToIndex(coordinate, areaData.GetConfig().Size);
		return new Location(areaData.GetId(), blockId);
	}

	[EventFunction(648)]
	private static void ClearMapBlockCurrResources(EventScriptRuntime runtime, MapBlockData mapBlockData)
	{
		mapBlockData.CurrResources.Initialize();
		DomainManager.Map.SetBlockData(runtime.Context, mapBlockData);
	}

	[EventFunction(650)]
	private static void FillMapBlockCurrResourceByType(EventScriptRuntime runtime, MapBlockData mapBlockData, sbyte resourceType)
	{
		mapBlockData.CurrResources[resourceType] = mapBlockData.MaxResources[resourceType];
		DomainManager.Map.SetBlockData(runtime.Context, mapBlockData);
	}

	[EventFunction(651)]
	private static void SetForceCollectResourceItem(EventScriptRuntime runtime, sbyte resourceType, UnmanagedVariant<TemplateKey> templateKey)
	{
		DomainManager.Map.SetForceCollectResourceItem(resourceType, templateKey.Value);
	}

	[EventFunction(652)]
	private static void SetForceCollectResourceAmount(EventScriptRuntime runtime, sbyte resourceType, int amount)
	{
		DomainManager.Map.SetForceCollectResourceAmount(resourceType, amount);
	}

	[EventFunction(693)]
	private static void TriggerCricketCatch(EventScriptRuntime runtime, string afterEvent)
	{
		DomainManager.TaiwuEvent.SetListenerWithActionName(afterEvent, runtime.ArgBox, "CricketCatchOver");
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.TriggerCricketCatch);
	}

	[EventFunction(721)]
	private static void ChangeBlockTemplate(EventScriptRuntime runtime, MapBlockData block, short blockTemplateId)
	{
		DomainManager.Map.ChangeBlockTemplate(runtime.Context, block, blockTemplateId);
	}

	[EventFunction(935)]
	private static void ClearBlockEnemies(EventScriptRuntime runtime, MapBlockData block)
	{
		if (block != null)
		{
			DomainManager.Map.ClearBlockRandomEnemies(runtime.Context, block);
		}
	}
}

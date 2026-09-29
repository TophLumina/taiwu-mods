using System.Collections.Generic;
using CompDevLib.Interpreter;
using CompDevLib.Interpreter.Parse;
using Config;
using GameData.Common;
using GameData.DLC;
using GameData.DLC.TaiwuAsXiangshu;
using GameData.Domains.Adventure;
using GameData.Domains.Character;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Story.MainStory;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.GameDataBridge;

namespace GameData.Domains.TaiwuEvent.FunctionDefinition;

public class DlcTaiwuAsXiangshuFunctions
{
	[EventFunction(901)]
	private static bool CreateXiangshuTower(EventScriptRuntime runtime)
	{
		if (!DlcManager.IsDlcInstalled(5093790uL))
		{
			return false;
		}
		DataContext context = runtime.Context;
		EventArgBox argBox = DomainManager.Extra.GetOrCreateDlcArgBox(5093790uL, context);
		argBox.Set("XiangshuTowerUnlocked", arg: true);
		DomainManager.Extra.SetDlcArgBox(5093790uL, argBox, context);
		return true;
	}

	[EventFunction(950)]
	private static void OpenTaiwuAsXiangshuTowerFinalLayer()
	{
		if (DlcManager.IsDlcInstalled(5093790uL))
		{
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenTaiwuAsXiangshuTowerFinalLayer);
		}
	}

	[EventFunction(920)]
	private static void ShowXiangshuLevelChanged(EventScriptRuntime runtime, string afterEvent)
	{
		if (!DlcManager.IsDlcInstalled(5093790uL))
		{
			return;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		sbyte consummateLevelOld = taiwu.GetConsummateLevel();
		if (consummateLevelOld < GlobalConfig.Instance.MaxConsummateLevel)
		{
			taiwu.SetConsummateLevel(GlobalConfig.Instance.MaxConsummateLevel, runtime.Context);
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ShowXiangshuLevelChanged, consummateLevelOld);
			if (!string.IsNullOrEmpty(afterEvent))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(afterEvent, runtime.ArgBox, "ShowXiangshuLevelChangedFinish");
			}
		}
	}

	[EventFunction(905)]
	private static void RemoveAllSwordTomb(EventScriptRuntime runtime, string afterEvent)
	{
		if (!DlcManager.IsDlcInstalled(5093790uL))
		{
			return;
		}
		List<MapBlockData> blockList = new List<MapBlockData>();
		for (int i = 0; i < 8; i++)
		{
			Location location = DomainManager.Map.GetElement_SwordTombLocations(i);
			if (location.IsValid())
			{
				MapBlockData mapBlockData = DomainManager.Map.GetBlock(location);
				short mapBlockTemplateId = mapBlockData.GetConfig().TemplateId;
				MapBlockItem config = MapBlock.Instance[mapBlockTemplateId];
				if (config.SubType == EMapBlockSubType.SwordTomb)
				{
					blockList.Add(mapBlockData);
				}
			}
		}
		if (blockList.Count > 0)
		{
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.RemoveAllSwordTomb, blockList);
			if (!string.IsNullOrEmpty(afterEvent))
			{
				GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AddEventInListenWithActionName(afterEvent, runtime.ArgBox, "RemoveAllSwordTombFinish");
			}
		}
	}

	[EventFunction(928)]
	private static void RemoveAllSwordTombAdventure(EventScriptRuntime runtime)
	{
		foreach (var (swordTombRuntime, xiangshuAvatarId) in DomainManager.Adventure.GetSwordTombs())
		{
			DomainManager.Adventure.RemoveAdventure(runtime.Context, swordTombRuntime.Id, EAdventureRemoveType.Instruction);
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Inventory taiwuInventory = taiwu.GetInventory();
		for (short templateId = 229; templateId <= 238; templateId++)
		{
			ItemKey itemKey = taiwuInventory.GetInventoryItemKey(12, templateId);
			if (itemKey.IsValid() && taiwuInventory.Items.TryGetValue(itemKey, out var amount) && amount > 0)
			{
				taiwu.RemoveInventoryItem(runtime.Context, itemKey, amount, deleteItem: true);
			}
		}
	}

	[EventFunction(929)]
	private static void TaiwuAsXiangshuDeleteCharacter(EventScriptRuntime runtime)
	{
		foreach (CharacterItem characterItem in (IEnumerable<CharacterItem>)Config.Character.Instance)
		{
			if (characterItem.CreatingType == 0 && characterItem.TaiwuAsXiangshuDelete && DomainManager.Character.TryGetFixedCharacterByTemplateId(characterItem.TemplateId, out var character))
			{
				DomainManager.Character.RemoveNonIntelligentCharacter(runtime.Context, character);
			}
		}
	}

	[EventFunction(921)]
	private static ValueInfo CheckHasSwordTomb(EventScriptRuntime runtime, ASTNode[] parameters)
	{
		List<MapBlockData> blockList = new List<MapBlockData>();
		for (int i = 0; i < 8; i++)
		{
			Location location = DomainManager.Map.GetElement_SwordTombLocations(i);
			if (location.IsValid())
			{
				MapBlockData mapBlockData = DomainManager.Map.GetBlock(location);
				short mapBlockTemplateId = mapBlockData.GetConfig().TemplateId;
				MapBlockItem config = MapBlock.Instance[mapBlockTemplateId];
				if (config.SubType == EMapBlockSubType.SwordTomb)
				{
					blockList.Add(mapBlockData);
				}
			}
		}
		return runtime.Evaluator.PushEvaluationResult(blockList.Count > 0);
	}

	[EventFunction(911)]
	private static void PagodaofTheFallenCreateTwelveImmortals(EventScriptRuntime runtime)
	{
		DomainManager.Story.GenerateTaiwuAsXiangshuCharacters(runtime.Context);
	}

	[EventFunction(912)]
	private static void TaiwuAsXiangshuEntered(EventScriptRuntime runtime)
	{
		if (DlcManager.IsDlcInstalled(5093790uL))
		{
			DomainManager.Story.SetTaiwuAsXiangshuEntered(value: true, runtime.Context);
		}
	}

	[EventFunction(913)]
	private static short TaiwuAsXiangshuGetUndefeatedAvatarTemplateId(EventScriptRuntime runtime)
	{
		sbyte xiangshuAvatarId = DomainManager.World.GetXiangshuAvatarTasksInOrder()[^1];
		return (short)(1304 + xiangshuAvatarId);
	}

	[EventFunction(931)]
	private static void AddTwelveImmortalsFeature(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		TwelveImmortalsHelper.AddTwelveImmortalsFeature(runtime.Context, character);
	}

	[EventFunction(957)]
	private static void AddTwelveImmortalsFeatureForTwelveImmortals(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		TwelveImmortalsHelper.AddTwelveImmortalsFeatureForTwelveImmortals(runtime.Context, character);
	}

	[EventFunction(934)]
	private static void SetTaiwuAsXiangshuTwelveImmortalsStatus(EventScriptRuntime runtime, short characterTemplateId, ETwelveImmortalsStatus status)
	{
		bool flag = ((characterTemplateId < 1075 || characterTemplateId > 1086) ? true : false);
		if (flag || !DlcManager.IsDlcInstalled(5093790uL))
		{
			return;
		}
		DlcId? dlcId = DlcManager.GetDlcIdByAppId(5093790uL);
		if (dlcId.HasValue)
		{
			DlcId id = dlcId.GetValueOrDefault();
			if (DomainManager.Extra.TryGetDlcEntry<TaiwuAsXiangshuEntry>(5093790uL, out var entry))
			{
				entry.SetTwelveImmortalsStatus(characterTemplateId, status);
				DomainManager.Extra.SetDlcEntry(runtime.Context, id, entry);
			}
		}
	}

	[EventFunction(964)]
	private static void ReserveThreeRealmsPowerPerformance(EventScriptRuntime runtime, short characterTemplateId, ETwelveImmortalsStatus status)
	{
		if (!TaiwuAsXiangshuTowerPerformanceHelper.IsThreeRealmsPowerCharacter(characterTemplateId) || !DlcManager.IsDlcInstalled(5093790uL))
		{
			return;
		}
		DlcId? dlcId = DlcManager.GetDlcIdByAppId(5093790uL);
		if (dlcId.HasValue)
		{
			DlcId id = dlcId.GetValueOrDefault();
			if (DomainManager.Extra.TryGetDlcEntry<TaiwuAsXiangshuEntry>(5093790uL, out var entry))
			{
				entry.AddPendingThreeRealmsPowerPerformance(TaiwuAsXiangshuTowerPerformanceHelper.GetPowerCharacterTemplateId(characterTemplateId), status);
				DomainManager.Extra.SetDlcEntry(runtime.Context, id, entry);
			}
		}
	}

	[EventFunction(962)]
	private static bool IsConvertToIntelligentConfig(EventScriptRuntime runtime, GameData.Domains.Character.Character character)
	{
		short templateId = character.GetTemplateId();
		CharacterItem config = Config.Character.Instance[templateId];
		return config.ConvertToIntelligent;
	}
}

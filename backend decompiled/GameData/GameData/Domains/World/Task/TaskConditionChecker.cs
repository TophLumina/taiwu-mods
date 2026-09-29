using System;
using System.Collections.Generic;
using Config;
using Config.ConfigCells;
using GameData.DLC;
using GameData.Domains.Adventure;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Filters;
using GameData.Domains.Extra;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.Taiwu.Profession.SkillsData;
using GameData.Domains.TaiwuEvent;

namespace GameData.Domains.World.Task;

public static class TaskConditionChecker
{
	public static bool CheckCondition(int conditionId)
	{
		return CheckCondition(TaskCondition.Instance[conditionId]);
	}

	public static bool CheckCondition(TaskConditionItem condition)
	{
		ETaskConditionType type = condition.Type;
		if (1 == 0)
		{
		}
		bool flag = type switch
		{
			ETaskConditionType.AdventureVisible => CheckAdventureVisible(condition), 
			ETaskConditionType.CharacterExists => CheckCharacterExists(condition), 
			ETaskConditionType.CharacterAtMapBlock => CheckCharacterAtMapBlock(condition), 
			ETaskConditionType.CharacterAtMapArea => CheckCharacterAtMapArea(condition), 
			ETaskConditionType.CharacterAtAdventure => CheckCharacterAtAdventureSite(condition), 
			ETaskConditionType.CharacterHasItems => CheckCharacterHasItems(condition), 
			ETaskConditionType.CharacterHasItemSubType => CheckCharacterHasItemSubType(condition), 
			ETaskConditionType.FavorabilityToTaiwu => CheckFavorabilityToTaiwu(condition), 
			ETaskConditionType.SettlementHasBuilding => CheckSettlementHasBuilding(condition), 
			ETaskConditionType.FunctionUnlocked => DomainManager.World.GetWorldFunctionsStatus((byte)condition.IntParam), 
			ETaskConditionType.JuniorXiangshuTaskStatus => CheckJuniorXiangshuTaskStatus(condition), 
			ETaskConditionType.SwordTombStatus => CheckSwordTombStatus(condition), 
			ETaskConditionType.GlobalArgBoxValueRange => CheckGlobalArgBoxValueRange(condition), 
			ETaskConditionType.GlobalArgBoxKeyExists => CheckGlobalArgBoxKeyExists(condition), 
			ETaskConditionType.JuniorXiangshuTaskCompleteAmount => CheckJuniorXiangshuTaskCompleteAmount(condition), 
			ETaskConditionType.MartialArtTournamentPreparing => CheckMartialArtTournamentPreparing(condition), 
			ETaskConditionType.ConditionAnd => condition.AndTaskCondition.TrueForAll(CheckCondition), 
			ETaskConditionType.ConditionOr => condition.OrTaskCondition.Exists(CheckCondition), 
			ETaskConditionType.IsInAdventure => CheckIsInAdventure(condition), 
			ETaskConditionType.ProfessionSkillValid => CheckProfessionSkillValid(condition), 
			ETaskConditionType.StateTemplateVisited => CheckStateTempleVisited(condition), 
			ETaskConditionType.SectFunctionStatus => CheckSectFunctionStatus(condition), 
			ETaskConditionType.CharacterIsTaiwuForJixi => CheckCharacterIsTaiwuForJixi(condition), 
			ETaskConditionType.SectArgBoxValueRange => CheckSectArgBoxValueRange(condition), 
			ETaskConditionType.SectArgBoxKeyExists => CheckSectArgBoxKeyExists(condition), 
			ETaskConditionType.DlcArgBoxKeyExists => CheckDlcArgBoxKeyExists(condition), 
			ETaskConditionType.CharacterInTaiwuGroup => CheckCharacterInTaiwuGroup(condition), 
			ETaskConditionType.CorpseCharacterGoodEnd => CheckCorpseCharacterGoodEnd(condition), 
			ETaskConditionType.NonStoryHeavenlyTreeExists => CheckNonStoryHeavenlyTreeExists(condition), 
			ETaskConditionType.CharacterHasFeature => CheckCharacterHasFeature(condition), 
			ETaskConditionType.SectMainStoryEnding => CheckSectMainStoryEnding(condition), 
			ETaskConditionType.ExtraTaskFinished => CheckExtraTaskFinished(condition), 
			_ => false, 
		};
		if (1 == 0)
		{
		}
		bool result = flag;
		return condition.IsReverseCondition != result;
	}

	private static GameData.Domains.Character.Character GetCharacterArgument(TaskConditionItem condition)
	{
		switch (condition.CharacterType)
		{
		case ETaskConditionCharacterType.Taiwu:
			return DomainManager.Taiwu.GetTaiwu();
		case ETaskConditionCharacterType.FixedCharacter:
		{
			DomainManager.Character.TryGetFixedCharacterByTemplateId(condition.CharacterTemplateId, out var character2);
			return character2;
		}
		case ETaskConditionCharacterType.ConvertedFixedCharacter:
		{
			DomainManager.Character.TryGetConvertedFixedCharacterByTemplateId(condition.CharacterTemplateId, out var character3);
			return character3;
		}
		case ETaskConditionCharacterType.XiangshuAvatar:
		{
			sbyte level = Math.Min(DomainManager.World.GetXiangshuLevel(), 8);
			short charTemplateId = (short)(condition.CharacterTemplateId + level);
			GameData.Domains.Character.Character character;
			while (!DomainManager.Character.TryGetFixedCharacterByTemplateId(charTemplateId, out character) && level > 0)
			{
				level--;
				charTemplateId = (short)(condition.CharacterTemplateId + level);
			}
			return character;
		}
		default:
			return null;
		}
	}

	public static bool CheckAdventureVisible(TaskConditionItem condition)
	{
		switch (condition.AreaType)
		{
		case ETaskConditionAreaType.TaiwuVillageArea:
		{
			short areaId3 = DomainManager.Taiwu.GetTaiwuVillageLocation().AreaId;
			return CheckAdventureVisibleInArea(areaId3, condition.Adventure);
		}
		case ETaskConditionAreaType.CurrentArea:
		{
			short areaId2 = DomainManager.Taiwu.GetTaiwu().GetLocation().AreaId;
			return CheckAdventureVisibleInArea(areaId2, condition.Adventure);
		}
		default:
		{
			for (short areaId = 0; areaId < 141; areaId++)
			{
				if (CheckAdventureVisibleInArea(areaId, condition.Adventure))
				{
					return true;
				}
			}
			return false;
		}
		}
	}

	private static bool CheckAdventureVisibleInArea(short areaId, int adventureCoreId)
	{
		if (areaId < 1)
		{
			return false;
		}
		return DomainManager.Adventure.QueryAnyActivatedInArea(areaId, adventureCoreId);
	}

	public static bool CheckCharacterAtAdventureSite(TaskConditionItem condition)
	{
		GameData.Domains.Character.Character character = GetCharacterArgument(condition);
		if (character == null)
		{
			return false;
		}
		Location location = character.GetLocation();
		if (!location.IsValid())
		{
			return false;
		}
		foreach (IAdventureRuntime runtime in DomainManager.Adventure.QueryAnyInLocation(location))
		{
			if (runtime.CoreId == condition.Adventure)
			{
				return true;
			}
		}
		return false;
	}

	public static bool CheckCharacterAtMapBlock(TaskConditionItem condition)
	{
		GameData.Domains.Character.Character character = GetCharacterArgument(condition);
		if (character == null)
		{
			return false;
		}
		Location location = character.GetLocation();
		if (!location.IsValid())
		{
			return false;
		}
		MapBlockData blockData = DomainManager.Map.GetBlock(location);
		return condition.MapBlockList.Contains(blockData.TemplateId);
	}

	public static bool CheckCharacterAtMapArea(TaskConditionItem condition)
	{
		GameData.Domains.Character.Character character = GetCharacterArgument(condition);
		if (character == null)
		{
			return false;
		}
		short areaId = character.GetLocation().AreaId;
		if (areaId < 0)
		{
			return false;
		}
		return condition.AreaType switch
		{
			ETaskConditionAreaType.TaiwuVillageArea => DomainManager.Taiwu.GetTaiwuVillageLocation().AreaId == areaId, 
			ETaskConditionAreaType.CurrentArea => areaId == DomainManager.Taiwu.GetTaiwu().GetLocation().AreaId, 
			_ => true, 
		};
	}

	public static bool CheckCharacterExists(TaskConditionItem condition)
	{
		GameData.Domains.Character.Character character = GetCharacterArgument(condition);
		return character != null;
	}

	public static bool CheckCharacterHasItems(TaskConditionItem condition)
	{
		GameData.Domains.Character.Character character = GetCharacterArgument(condition);
		if (character == null)
		{
			return false;
		}
		foreach (PresetItemWithCount itemToCheck in condition.Items)
		{
			if (CharacterMatchers.MatchHasInventoryItem(character, itemToCheck.ItemType, itemToCheck.TemplateId, itemToCheck.Count) || (itemToCheck.Count == 1 && ItemType.IsEquipmentItemType(itemToCheck.ItemType) && CharacterMatchers.MatchHasEquippedItem(character, itemToCheck.ItemType, itemToCheck.TemplateId)))
			{
				continue;
			}
			return false;
		}
		return true;
	}

	public static bool CheckCharacterHasItemSubType(TaskConditionItem condition)
	{
		GameData.Domains.Character.Character character = GetCharacterArgument(condition);
		if (character == null)
		{
			return false;
		}
		Dictionary<ItemKey, int> inventoryItem = character.GetInventory().Items;
		foreach (ItemKey itemKey in inventoryItem.Keys)
		{
			if (ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId) == condition.IntParam)
			{
				return true;
			}
		}
		return false;
	}

	public static bool CheckCharacterInTaiwuGroup(TaskConditionItem condition)
	{
		List<int> specialGroup = DomainManager.Taiwu.GetTaiwuSpecialGroup();
		foreach (int charId in specialGroup)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character) && character.GetTemplateId() == condition.CharacterTemplateId)
			{
				return true;
			}
		}
		foreach (int charId2 in DomainManager.Taiwu.GetGroupCharIds().GetCollection())
		{
			if (DomainManager.Character.TryGetElement_Objects(charId2, out var character2) && character2.GetTemplateId() == condition.CharacterTemplateId)
			{
				return true;
			}
		}
		return false;
	}

	public static bool CheckFavorabilityToTaiwu(TaskConditionItem condition)
	{
		GameData.Domains.Character.Character character = GetCharacterArgument(condition);
		if (character == null)
		{
			return false;
		}
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		short favorability = DomainManager.Character.GetFavorability(character.GetId(), taiwuCharId);
		return favorability >= condition.ValueRange.First && favorability < condition.ValueRange.Second;
	}

	public static bool CheckSettlementHasBuilding(TaskConditionItem condition)
	{
		foreach (short mapBlockTemplateId in condition.MapBlockList)
		{
			switch (mapBlockTemplateId)
			{
			case 0:
			{
				Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
				BuildingAreaData buildingArea = DomainManager.Building.GetBuildingAreaData(location);
				BuildingBlockKey buildingKey = BuildingDomain.FindBuildingKey(location, buildingArea, condition.Building);
				if (DomainManager.Building.BuildingBlockLevel(buildingKey) > 0)
				{
					return true;
				}
				continue;
			}
			case 17:
				if (FindInArea(135, mapBlockTemplateId, condition.Building))
				{
					return true;
				}
				continue;
			case 18:
				if (FindInArea(136, mapBlockTemplateId, condition.Building))
				{
					return true;
				}
				continue;
			case 16:
				if (FindInArea(137, mapBlockTemplateId, condition.Building))
				{
					return true;
				}
				continue;
			}
			for (short areaId = 0; areaId < 45; areaId++)
			{
				if (FindInArea(areaId, mapBlockTemplateId, condition.Building))
				{
					return true;
				}
			}
		}
		return false;
		static bool FindInArea(short num, short blockTemplateId, short buildingTemplateId)
		{
			MapAreaData areaData = DomainManager.Map.GetElement_Areas(num);
			SettlementInfo[] settlementInfos = areaData.SettlementInfos;
			for (int i = 0; i < settlementInfos.Length; i++)
			{
				SettlementInfo settlementInfo = settlementInfos[i];
				if (settlementInfo.SettlementId >= 0)
				{
					MapBlockData block = DomainManager.Map.GetBlock(num, settlementInfo.BlockId);
					if (block.TemplateId == blockTemplateId)
					{
						Location location2 = new Location(num, settlementInfo.BlockId);
						BuildingAreaData buildingArea2 = DomainManager.Building.GetBuildingAreaData(location2);
						BuildingBlockKey buildingKey2 = BuildingDomain.FindBuildingKey(location2, buildingArea2, buildingTemplateId);
						if (DomainManager.Building.BuildingBlockLevel(buildingKey2) > 0)
						{
							return true;
						}
					}
				}
			}
			return false;
		}
	}

	public static bool CheckJuniorXiangshuTaskStatus(TaskConditionItem condition)
	{
		sbyte avatarId = XiangshuAvatarIds.GetXiangshuAvatarIdByCharacterTemplateId(condition.CharacterTemplateId);
		XiangshuAvatarTaskStatus taskStatus = DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(avatarId);
		return taskStatus.JuniorXiangshuTaskStatus >= condition.ValueRange.First && taskStatus.JuniorXiangshuTaskStatus < condition.ValueRange.Second;
	}

	public static bool CheckSwordTombStatus(TaskConditionItem condition)
	{
		sbyte avatarId = XiangshuAvatarIds.GetXiangshuAvatarIdByCharacterTemplateId(condition.CharacterTemplateId);
		return DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(avatarId).SwordTombStatus == condition.IntParam;
	}

	public static bool CheckGlobalArgBoxValueRange(TaskConditionItem condition)
	{
		EventArgBox argBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		int val = 0;
		if (!argBox.Get(condition.ArgBoxKey, ref val))
		{
			return false;
		}
		return val >= condition.ValueRange.First && val < condition.ValueRange.Second;
	}

	public static bool CheckGlobalArgBoxKeyExists(TaskConditionItem condition)
	{
		EventArgBox argBox = DomainManager.TaiwuEvent.GetGlobalEventArgumentBox();
		return argBox.Contains<bool>(condition.ArgBoxKey) || argBox.Contains<int>(condition.ArgBoxKey) || argBox.Contains<string>(condition.ArgBoxKey);
	}

	public static bool CheckSectArgBoxValueRange(TaskConditionItem condition)
	{
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(condition.Organization);
		int val = 0;
		if (!argBox.Get(condition.ArgBoxKey, ref val))
		{
			return false;
		}
		return val >= condition.ValueRange.First && val < condition.ValueRange.Second;
	}

	public static bool CheckSectArgBoxKeyExists(TaskConditionItem condition)
	{
		EventArgBox argBox = DomainManager.Extra.GetSectMainStoryEventArgBox(condition.Organization);
		return argBox.Contains<bool>(condition.ArgBoxKey) || argBox.Contains<int>(condition.ArgBoxKey) || argBox.Contains<string>(condition.ArgBoxKey);
	}

	public static bool CheckDlcArgBoxKeyExists(TaskConditionItem condition)
	{
		if (!DlcManager.IsDlcInstalled(condition.DlcAppId))
		{
			return false;
		}
		if (!DomainManager.Extra.TryGetDlcArgBox(condition.DlcAppId, out var argBox))
		{
			return false;
		}
		return argBox.Contains<bool>(condition.ArgBoxKey) || argBox.Contains<int>(condition.ArgBoxKey) || argBox.Contains<string>(condition.ArgBoxKey);
	}

	public static bool CheckJuniorXiangshuTaskCompleteAmount(TaskConditionItem condition)
	{
		int amount = 0;
		for (sbyte avatarId = 0; avatarId < 9; avatarId++)
		{
			if (DomainManager.World.GetElement_XiangshuAvatarTaskStatuses(avatarId).JuniorXiangshuTaskStatus > 4)
			{
				amount++;
			}
		}
		return amount >= condition.ValueRange.First && amount < condition.ValueRange.Second;
	}

	public static bool CheckMartialArtTournamentPreparing(TaskConditionItem condition)
	{
		return DomainManager.Organization.GetCurrTournamentState() == EMartialArtTournamentState.Prepare;
	}

	public static bool CheckIsInAdventure(TaskConditionItem condition)
	{
		IAdventureRuntime runtime = DomainManager.Adventure.QueryTaiwuCurrentAdventure();
		return runtime != null && runtime.CoreId == condition.Adventure;
	}

	public static bool CheckProfessionSkillValid(TaskConditionItem condition)
	{
		int skillId = condition.ProfessionSkill;
		if (!DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(skillId))
		{
			return false;
		}
		ProfessionSkillItem skillCfg = ProfessionSkill.Instance[skillId];
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(skillCfg.Profession);
		if (!professionData.HadBeenUnlocked[skillCfg.Level - 1])
		{
			return false;
		}
		if (!ProfessionSkillHandle.CheckSpecialCondition(professionData, skillCfg.Level - 1))
		{
			return false;
		}
		return true;
	}

	public static bool CheckStateTempleVisited(TaskConditionItem condition)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(12);
		if (professionData == null)
		{
			return false;
		}
		TravelingBuddhistMonkSkillsData skillsData = professionData.GetSkillsData<TravelingBuddhistMonkSkillsData>();
		sbyte stateId = DomainManager.Map.GetStateIdByStateTemplateId(condition.StateTemplateId);
		return skillsData.StateHasTemple(stateId) && skillsData.IsStateTempleVisited(stateId);
	}

	public static bool CheckSectFunctionStatus(TaskConditionItem condition)
	{
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(condition.Organization);
		return settlement is Sect sect && sect.GetFunctionStatus((SectFunctionStatuses.SectFunctionStatusType)condition.IntParam);
	}

	public static bool CheckSectMainStoryEnding(TaskConditionItem condition)
	{
		sbyte taskStatus = DomainManager.Story.GetSectMainStoryTaskStatus(condition.Organization);
		return taskStatus == condition.IntParam;
	}

	public static bool CheckExtraTaskFinished(TaskConditionItem condition)
	{
		return DomainManager.World.IsExtraTaskFinished(condition.Task);
	}

	public static bool CheckCharacterIsTaiwuForJixi(TaskConditionItem condition)
	{
		GameData.Domains.Character.Character character = GetCharacterArgument(condition);
		if (character == null)
		{
			return false;
		}
		return character.GetId() == DomainManager.Taiwu.GetTaiwuCharIdForJixi();
	}

	public static bool CheckCorpseCharacterGoodEnd(TaskConditionItem condition)
	{
		GameData.Domains.Character.Character character = GetCharacterArgument(condition);
		if (character == null)
		{
			return false;
		}
		short templateId = character.GetTemplateId();
		return DomainManager.Extra.GetRanshanThreeCorpsesCharacterByTemplateId(templateId)?.IsGoodEnd ?? false;
	}

	public static bool CheckNonStoryHeavenlyTreeExists(TaskConditionItem condition)
	{
		List<SectStoryHeavenlyTreeExtendable> heavenlyTrees = DomainManager.Extra.GetAllHeavenlyTrees();
		foreach (SectStoryHeavenlyTreeExtendable tree in heavenlyTrees)
		{
			if (Config.Misc.Instance[tree.TemplateId].GroupId == 304 && tree.Location.IsValid())
			{
				return true;
			}
		}
		return false;
	}

	public static bool CheckCharacterHasFeature(TaskConditionItem condition)
	{
		GameData.Domains.Character.Character character = GetCharacterArgument(condition);
		return character.GetFeatureIds().Contains(condition.Feature);
	}
}

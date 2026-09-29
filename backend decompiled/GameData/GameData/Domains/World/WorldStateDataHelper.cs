using System;
using System.Collections.Generic;
using Config;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Taiwu;
using GameData.Domains.Taiwu.Profession;
using GameData.Domains.Taiwu.Profession.SkillsData;
using GameData.Domains.TaiwuEvent;
using GameData.Utilities;

namespace GameData.Domains.World;

public static class WorldStateDataHelper
{
	public static void DetectEquipmentOverload(this ref WorldStateData data)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int currLoad = taiwu.GetCurrEquipmentLoad();
		int maxLoad = taiwu.GetMaxEquipmentLoad();
		if (currLoad > maxLoad)
		{
			data.SetWorldState(10);
		}
	}

	public static void DetectWarehouseOverload(this ref WorldStateData data)
	{
		int warehouseCurrLoad = DomainManager.Taiwu.GetWarehouseCurrLoad();
		int warehouseMaxLoad = DomainManager.Taiwu.GetWarehouseMaxLoad();
		if (warehouseCurrLoad > warehouseMaxLoad)
		{
			data.SetWorldState(12);
			data.AddOverloadStorageType(WorldStateData.EStorageType.Warehouse);
		}
		int troughCurrLoad = DomainManager.Taiwu.GetTroughCurrLoad();
		int troughMaxLoad = DomainManager.Taiwu.GetTroughMaxLoad();
		if (troughCurrLoad > troughMaxLoad)
		{
			data.SetWorldState(12);
			data.AddOverloadStorageType(WorldStateData.EStorageType.Trough);
		}
	}

	public unsafe static void DetectResourceOverload(this ref WorldStateData data)
	{
		int maxAmount = DomainManager.Taiwu.GetMaterialResourceMaxCount();
		ResourceInts resources = DomainManager.Taiwu.GetTotalResources();
		for (sbyte resourceType = 0; resourceType < 6; resourceType++)
		{
			if (resources.Items[resourceType] > maxAmount)
			{
				data.SetWorldState(13);
				data.AddOverloadingResourceType(resourceType);
			}
		}
	}

	public static void DetectInventoryOverload(this ref WorldStateData data)
	{
		List<IntPair> overloadChars = DomainManager.Taiwu.GetOverweightSanctionPercent();
		if (overloadChars.Count > 0)
		{
			data.SetWorldState(11);
		}
	}

	public static void DetectInjuries(this ref WorldStateData data)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Injuries injuries = taiwu.GetInjuries();
		for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
		{
			var (outer, inner) = injuries.Get(bodyPart);
			if (outer >= 2)
			{
				data.AddOuterInjuryBodyPart(bodyPart);
			}
			if (inner >= 2)
			{
				data.AddInnerInjuryBodyPart(bodyPart);
			}
		}
		if (data.AnyOuterInjury())
		{
			data.SetWorldState(14);
		}
		if (data.AnyInnerInjury())
		{
			data.SetWorldState(15);
		}
	}

	public unsafe static void DetectPoisons(this ref WorldStateData data)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		PoisonInts poisoned = taiwu.GetPoisoned();
		for (sbyte poisonType = 0; poisonType < 6; poisonType++)
		{
			sbyte level = PoisonsAndLevels.CalcPoisonedLevel(poisoned.Items[poisonType]);
			if (level > 0)
			{
				data.SetWorldState(17);
				data.AddPoisonType(poisonType);
			}
		}
	}

	public static void DetectDisorderOfQi(this ref WorldStateData data)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		short disorderOfQi = taiwu.GetDisorderOfQi();
		if (DisorderLevelOfQi.GetDisorderLevelOfQi(disorderOfQi) != 0)
		{
			data.SetWorldState(16);
		}
	}

	public static void DetectTeammateInjuries(this ref WorldStateData data)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		HashSet<int> ids = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		foreach (int id in ids)
		{
			if (id == taiwuId)
			{
				continue;
			}
			Injuries injuries = DomainManager.Character.GetElement_Objects(id).GetInjuries();
			for (sbyte bodyPart = 0; bodyPart < 7; bodyPart++)
			{
				var (outer, inner) = injuries.Get(bodyPart);
				if (outer >= 2 || inner >= 2)
				{
					data.SetWorldState(40);
					return;
				}
			}
		}
	}

	public static void DetectMainStory(this ref WorldStateData data)
	{
		if (DomainManager.World.GetExorcismEnabled())
		{
			data.SetWorldState(50);
		}
	}

	public static void DetectXiangshuAvatars(this ref WorldStateData data)
	{
		short minRemainMonths = short.MaxValue;
		foreach (var (runtime, xiangshuAvatarId) in DomainManager.Adventure.GetSwordTombs())
		{
			if (runtime.RemainMonths > 0)
			{
				minRemainMonths = (short)Math.Min(minRemainMonths, runtime.RemainMonths);
				data.SetWorldState(20);
				data.AddAwakeningXiangshuAvatar(xiangshuAvatarId);
			}
		}
		if (minRemainMonths == short.MaxValue)
		{
			minRemainMonths = 0;
		}
		data.SetMinAwakeSwordTombRemainMonths(minRemainMonths);
		foreach (int attackingSwordTomb in DomainManager.Adventure.GetAttackingSwordTombs())
		{
			data.SetWorldState(21);
			sbyte xiangshuAvatarId2 = XiangshuAvatarIds.GetXiangshuAvatarIdBySwordTomb(attackingSwordTomb);
			data.AddAttackingXiangshuAvatar(xiangshuAvatarId2);
		}
	}

	public static void DetectXiangshuInvasionProgress(this ref WorldStateData data)
	{
		if (DomainManager.Global.IsInNormalWorld() && DomainManager.Taiwu.GetTaiwu().GetLocation().AreaId != 135)
		{
			data.SetWorldState(SharedMethods.GetInvasionWorldStateTemplateId());
		}
	}

	public static void DetectXiangshuInfection(this ref WorldStateData data)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		byte xiangshuInfection = taiwu.GetXiangshuInfection();
		foreach (short featureId in taiwu.GetFeatureIds())
		{
			if (CharacterFeature.Instance[featureId].IgnoreInfected)
			{
				return;
			}
		}
		if (xiangshuInfection >= 200)
		{
			data.SetWorldState(19);
		}
		else if (xiangshuInfection >= 100)
		{
			data.SetWorldState(18);
		}
	}

	public static void DetectMartialArtTournament(this ref WorldStateData data)
	{
		switch (DomainManager.Organization.GetCurrTournamentState())
		{
		case EMartialArtTournamentState.Prepare:
			data.SetWorldState(22);
			break;
		case EMartialArtTournamentState.Confirmed:
			data.SetWorldState(23);
			break;
		case EMartialArtTournamentState.Open:
			data.SetWorldState(24);
			break;
		}
	}

	public static void DetectChangeWorldCreation(this ref WorldStateData data)
	{
		if (DomainManager.World.GetCanResetWorldSettings())
		{
			data.SetWorldState(41);
		}
	}

	public static void DetectLoongDebuff(this ref WorldStateData data)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		foreach (var (_, loongInfo2) in DomainManager.Extra.FiveLoongDict)
		{
			if (loongInfo2.CharacterDebuffCounts != null && loongInfo2.CharacterDebuffCounts.TryGetValue(taiwuId, out var debuffCount) && debuffCount > 0)
			{
				data.SetWorldState(loongInfo2.ConfigData.WorldState);
			}
		}
	}

	public static void DetectInFulongFlameArea(this ref WorldStateData data)
	{
		if (DomainManager.Map.GetIsTaiwuInFulongFlameArea())
		{
			data.SetWorldState(47);
		}
	}

	public static void DetectTribulation(this ref WorldStateData data)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(5);
		TaoistMonkSkillsData skillsData = professionData.GetSkillsData<TaoistMonkSkillsData>();
		if (skillsData.IsTriggeringTribulation)
		{
			data.SetWorldState(48);
		}
	}

	public static void DetectSectMainStory(this ref WorldStateData data)
	{
		if (!DomainManager.World.GetWorldFunctionsStatus(4))
		{
			return;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwu.GetLocation();
		if (!location.IsValid())
		{
			location = taiwu.GetValidLocation();
		}
		if (MapAreaData.IsBrokenArea(location.AreaId))
		{
			return;
		}
		MapAreaData areaData = DomainManager.Map.GetElement_Areas(location.AreaId);
		MapAreaItem areaCfg = areaData.GetConfig();
		MapStateItem mapStateCfg = MapState.Instance[areaCfg.StateID];
		if (mapStateCfg.SectID < 0 || !Config.Organization.Instance[mapStateCfg.SectID].IsSect || DomainManager.Story.SectMainStoryTriggeredThisMonth(mapStateCfg.SectID) || !DomainManager.Story.CheckSectMainStoryAvailable(mapStateCfg.SectID))
		{
			return;
		}
		sbyte worldState = Config.Organization.Instance[mapStateCfg.SectID].SectMainStory.TaskReadyWorldState;
		if (worldState < 0)
		{
			return;
		}
		WorldStateItem config = WorldState.Instance[worldState];
		if (config.TriggerArea < 0 || areaData.GetTemplateId() == config.TriggerArea)
		{
			EventArgBox eventArgBox = DomainManager.Extra.GetSectMainStoryEventArgBox(mapStateCfg.SectID);
			sbyte sectID = mapStateCfg.SectID;
			if (1 == 0)
			{
			}
			bool flag = sectID switch
			{
				1 => !eventArgBox.GetBool(SectMainStoryEventArgKey.DefValue.ShaolinLearnedAny), 
				2 => !eventArgBox.Contains<int>(SectMainStoryEventArgKey.DefValue.EmeiAdventureTwoAppearDate), 
				_ => true, 
			};
			if (1 == 0)
			{
			}
			if (flag)
			{
				data.SetWorldState(worldState);
			}
		}
	}

	public static void DetectTaiwuWanted(this ref WorldStateData data)
	{
		if (!DomainManager.World.GetWorldFunctionsStatus(4))
		{
			return;
		}
		foreach (int charId in DomainManager.Taiwu.GetGroupCharIds().GetCollection())
		{
			sbyte sectOrgTemplateId;
			SettlementBounty bounty = DomainManager.Organization.GetBounty(charId, out sectOrgTemplateId);
			if (bounty == null || sectOrgTemplateId < 0)
			{
				continue;
			}
			data.SetWorldState(49);
			break;
		}
	}

	public static void DetectTeammateDying(this ref WorldStateData data)
	{
		HashSet<int> ids = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		foreach (int id in ids)
		{
			GameData.Domains.Character.Character groupChar = DomainManager.Character.GetElement_Objects(id);
			EHealthType type = groupChar.GetHealthType();
			if ((uint)type <= 1u)
			{
				data.SetWorldState(51);
				break;
			}
		}
	}

	public static void DetectHomelessVillager(this ref WorldStateData data)
	{
		if (DomainManager.Building.GetHomeless().GetCount() > 0 && DomainManager.Global.IsInNormalWorld() && DomainManager.World.GetWorldFunctionsStatus(10))
		{
			data.SetWorldState(52);
		}
	}

	public static void DetectNeiliConflicting(this ref WorldStateData data)
	{
		HashSet<int> ids = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		foreach (int id in ids)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(id);
			NeiliTypeItem neiliTypeConfig = NeiliType.Instance[character.GetNeiliType()];
			if (neiliTypeConfig.ShowConflictingWorldState)
			{
				data.SetWorldState(53);
				break;
			}
		}
	}

	public static void DetectChallengeMode(this ref WorldStateData data)
	{
		ChallengeModeData challengeModeData = DomainManager.World.GetChallengeModeData();
		if (challengeModeData != null && challengeModeData.IsEnabled())
		{
			data.SetWorldState(55);
		}
	}

	public static void DetectLoopingStates(this ref WorldStateData data)
	{
		if (DomainManager.TutorialChapter.InGuiding && !DomainManager.TutorialChapter.GetTutorialFunctionStatus(12))
		{
			return;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		short loopingNeigong = taiwu.GetLoopingNeigong();
		List<short> loopingEventSkillIdList = DomainManager.Extra.GetLoopingEventSkillIdList();
		if (loopingNeigong >= 0 && loopingEventSkillIdList.Contains(loopingNeigong))
		{
			data.AddLoopingType(WorldStateData.ELoopingType.HasLoopingEvent);
		}
		List<short> learnedCombatSkills = taiwu.GetLearnedCombatSkills();
		bool hasUnfinishedNeigong = false;
		bool currentNeigongFinished = false;
		bool allNeigongFinished = true;
		int unfinishedNeigongCount = 0;
		foreach (short skillId in learnedCombatSkills)
		{
			CombatSkillItem skillCfg = Config.CombatSkill.Instance[skillId];
			if (skillCfg.EquipType == 0 && DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(taiwu.GetId(), skillId), out var skill))
			{
				short obtainedNeili = skill.GetObtainedNeili();
				short totalObtainableNeili = skill.GetTotalObtainableNeili();
				bool isFinished = obtainedNeili >= totalObtainableNeili;
				if (!isFinished)
				{
					hasUnfinishedNeigong = true;
					allNeigongFinished = false;
					unfinishedNeigongCount++;
				}
				if (skillId == loopingNeigong)
				{
					currentNeigongFinished = isFinished;
				}
			}
		}
		if (loopingNeigong < 0 && hasUnfinishedNeigong)
		{
			data.AddLoopingType(WorldStateData.ELoopingType.NoLoopingNeigongWithUnfinished);
		}
		if (loopingNeigong < 0 && !hasUnfinishedNeigong)
		{
			NeiliAllocation extraNeiliAllocation = taiwu.GetExtraNeiliAllocation();
			for (int i = 0; i < 4; i++)
			{
				if (extraNeiliAllocation[i] < GlobalConfig.Instance.MaxExtraNeiliAllocation)
				{
					data.AddLoopingType(WorldStateData.ELoopingType.NoLoopingNeigongQiNotFull);
					break;
				}
			}
		}
		if (loopingNeigong >= 0 && currentNeigongFinished && hasUnfinishedNeigong)
		{
			data.AddLoopingType(WorldStateData.ELoopingType.LoopingNeigongFinishedWithUnfinished);
		}
		if (loopingNeigong >= 0 && !currentNeigongFinished)
		{
			List<short> referenceBooks = DomainManager.Extra.GetReferenceSkillList();
			bool hasEmptyReferenceSlot = false;
			for (int j = 0; j < referenceBooks.Count; j++)
			{
				if (referenceBooks[j] < 0 && DomainManager.Taiwu.IsReferenceSkillSlotUnlocked(j))
				{
					hasEmptyReferenceSlot = true;
					break;
				}
			}
			if (hasEmptyReferenceSlot && !WillNeiliBeFullNextMonth(taiwu, loopingNeigong))
			{
				data.AddLoopingType(WorldStateData.ELoopingType.LoopingNeigongCanFillAuxiliary);
			}
		}
		NeiliTypeItem neiliTypeConfig = NeiliType.Instance[taiwu.GetNeiliType()];
		if (neiliTypeConfig.ShowConflictingWorldState)
		{
			data.AddLoopingType(WorldStateData.ELoopingType.NeiliFiveElementsConflicting);
		}
		if (data.HasLoopingTypes())
		{
			data.SetWorldState(54);
		}
	}

	private static bool WillNeiliBeFullNextMonth(GameData.Domains.Character.Character taiwu, short loopingNeigong)
	{
		if (loopingNeigong < 0)
		{
			return false;
		}
		if (!DomainManager.CombatSkill.TryGetElement_CombatSkills(new CombatSkillKey(taiwu.GetId(), loopingNeigong), out var skill))
		{
			return false;
		}
		short obtainedNeili = skill.GetObtainedNeili();
		short totalObtainableNeili = skill.GetTotalObtainableNeili();
		int remainingNeili = totalObtainableNeili - obtainedNeili;
		if (remainingNeili <= 0)
		{
			return true;
		}
		CombatSkillItem skillCfg = Config.CombatSkill.Instance[loopingNeigong];
		DataContext context = DomainManager.TaiwuEvent.MainThreadDataContext;
		short neili = CombatSkillDomain.CalcNeigongLoopingEffect(context.Random, taiwu, skillCfg).neili;
		byte loopingDifficulty = DomainManager.World.GetLoopingDifficulty();
		short factor = WorldCreation.Instance[(byte)4].InfluenceFactors[loopingDifficulty];
		neili = (short)(neili * factor / 100);
		int minNeiliPerLoop = neili * 3 / 4;
		return minNeiliPerLoop >= remainingNeili;
	}

	public static void DetectReadingStates(this ref WorldStateData data)
	{
		if (DomainManager.TutorialChapter.InGuiding && !DomainManager.TutorialChapter.GetTutorialFunctionStatus(11))
		{
			return;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		ItemKey curReadingBook = DomainManager.Taiwu.GetCurReadingBook();
		List<int> readingEventBookIdList = DomainManager.Extra.GetReadingEventBookIdList();
		Inventory inventory = taiwu.GetInventory();
		bool hasReadableBookInInventory = false;
		bool hasUnfinishedBookInInventory = false;
		bool allBooksFinished = true;
		foreach (KeyValuePair<ItemKey, int> itemKv in inventory.Items)
		{
			if (itemKv.Key.ItemType == 10)
			{
				sbyte readingProgress = DomainManager.Taiwu.GetTotalReadingProgress(itemKv.Key.Id);
				if (readingProgress < 100)
				{
					hasUnfinishedBookInInventory = true;
					hasReadableBookInInventory = true;
					allBooksFinished = false;
				}
				else if (readingProgress >= 0)
				{
					hasReadableBookInInventory = true;
				}
			}
		}
		if (!curReadingBook.IsValid() && hasReadableBookInInventory)
		{
			data.AddReadingType(WorldStateData.EReadingType.NoReadingBookWithReadable);
		}
		if (!curReadingBook.IsValid() && !hasUnfinishedBookInInventory && allBooksFinished)
		{
			data.AddReadingType(WorldStateData.EReadingType.NoReadingBookAllFinished);
		}
		if (curReadingBook.IsValid())
		{
			sbyte currentBookProgress = DomainManager.Taiwu.GetTotalReadingProgress(curReadingBook.Id);
			bool currentBookFinished = currentBookProgress >= 100;
			if (currentBookFinished && hasUnfinishedBookInInventory)
			{
				data.AddReadingType(WorldStateData.EReadingType.ReadingBookFinishedWithUnfinished);
			}
			if (!currentBookFinished)
			{
				ItemKey[] referenceBooks = DomainManager.Taiwu.GetReferenceBooks();
				bool hasEmptyReferenceSlot = false;
				for (int i = 0; i < referenceBooks.Length; i++)
				{
					if (!referenceBooks[i].IsValid() && DomainManager.Taiwu.IsReferenceBookSlotUnlocked(i))
					{
						hasEmptyReferenceSlot = true;
						break;
					}
				}
				if (hasEmptyReferenceSlot && !WillReadingProgressBeFullNextMonth(taiwu, curReadingBook))
				{
					data.AddReadingType(WorldStateData.EReadingType.ReadingBookCanFillReference);
				}
			}
			if (readingEventBookIdList.Contains(curReadingBook.Id))
			{
				data.AddReadingType(WorldStateData.EReadingType.HasReadingEvent);
			}
		}
		if (data.HasReadingTypes())
		{
			data.SetWorldState(54);
		}
	}

	private static bool WillReadingProgressBeFullNextMonth(GameData.Domains.Character.Character taiwu, ItemKey curReadingBook)
	{
		if (!curReadingBook.IsValid())
		{
			return false;
		}
		GameData.Domains.Item.SkillBook book = DomainManager.Item.GetElement_SkillBooks(curReadingBook.Id);
		if (book == null)
		{
			return false;
		}
		if (!DomainManager.SpecialEffect.ModifyData(taiwu.GetId(), -1, 259, dataValue: true))
		{
			return false;
		}
		ReadingBookStrategies strategies = DomainManager.Taiwu.GetCurReadingStrategies();
		bool isCombatSkill = SkillGroup.FromItemSubType(book.GetItemSubType()) == 1;
		byte currentPage;
		if (isCombatSkill)
		{
			short skillTemplateId = book.GetCombatSkillTemplateId();
			if (!DomainManager.Taiwu.TryGetElement_CombatSkills(skillTemplateId, out var taiwuCombatSkill) && !DomainManager.Taiwu.TryGetElement_NotLearnCombatSkillReadingProgress(skillTemplateId, out taiwuCombatSkill))
			{
				return false;
			}
			currentPage = DomainManager.Taiwu.GetCurrentReadingPage(book, strategies, taiwuCombatSkill);
		}
		else
		{
			short skillTemplateId2 = book.GetLifeSkillTemplateId();
			if (!DomainManager.Taiwu.TryGetElement_LifeSkills(skillTemplateId2, out var taiwuLifeSkill) && !DomainManager.Taiwu.TryGetElement_NotLearnLifeSkillReadingProgress(skillTemplateId2, out taiwuLifeSkill))
			{
				return false;
			}
			currentPage = DomainManager.Taiwu.GetCurrentReadingPage(book, strategies, taiwuLifeSkill);
		}
		int remainingSpeedPercent = 100;
		byte pagesCount = (byte)(isCombatSkill ? 6 : 5);
		while (remainingSpeedPercent > 0 && currentPage < pagesCount)
		{
			if ((isCombatSkill ? DomainManager.Taiwu.IsCombatSkillBookPageRead(book, currentPage) : DomainManager.Taiwu.IsLifeSkillBookPageRead(book, currentPage)) || strategies.GetSkipPage(currentPage))
			{
				currentPage++;
				continue;
			}
			sbyte baseSpeed = DomainManager.Taiwu.GetBaseReadingSpeed(currentPage);
			int speedBonus = DomainManager.Taiwu.GetReadingSpeedBonus(currentPage, isInBattle: false, 0, 0);
			int actualSpeed = baseSpeed * speedBonus / 100;
			if (actualSpeed <= 0)
			{
				break;
			}
			int addingProgress = actualSpeed * remainingSpeedPercent / 100;
			if (addingProgress < 100)
			{
				break;
			}
			remainingSpeedPercent -= 10000 / Math.Max(1, actualSpeed);
			currentPage++;
		}
		return currentPage >= pagesCount;
	}

	public static void DetectChallengeModeChanged(this ref WorldStateData data)
	{
		List<int> waitForDecideIds = DomainManager.World.GetWaitForDecideChallengeModeIds();
		if (waitForDecideIds != null && waitForDecideIds.Count > 0)
		{
			data.SetWorldState(56);
		}
	}
}

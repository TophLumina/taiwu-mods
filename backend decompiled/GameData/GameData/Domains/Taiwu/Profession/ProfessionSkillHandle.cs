using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Creation;
using GameData.Domains.Character.Filters;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Extra;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.LifeRecord;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.Organization.SettlementPrisonRecord;
using GameData.Domains.Taiwu.Profession.SkillsData;
using GameData.Domains.TaiwuEvent;
using GameData.Domains.TaiwuEvent.EventHelper;
using GameData.Domains.World.MonthlyEvent;
using GameData.Domains.World.Notification;
using GameData.GameDataBridge;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession;

public static class ProfessionSkillHandle
{
	public static readonly IReadOnlyList<short> AnimalCharacterTemplateIds = new short[18]
	{
		228, 229, 230, 231, 232, 233, 234, 235, 236, 237,
		238, 239, 240, 241, 242, 243, 244, 245
	};

	public static bool CanExecuteSkill(ProfessionData professionData, int skillIndex)
	{
		ProfessionSkillItem skillCfg = professionData.GetSkillConfig(skillIndex);
		if (skillCfg.IgnoreCanExecuteSkill)
		{
			return true;
		}
		if (skillCfg.TriggerType != EProfessionSkillTriggerType.Active)
		{
			return false;
		}
		if (DomainManager.Taiwu.GetTaiwu().GetExp() < skillCfg.ExpCost)
		{
			return false;
		}
		if (DomainManager.World.GetLeftDaysInCurrMonth() < skillCfg.TimeCost)
		{
			return false;
		}
		if (professionData.IsSkillCooldown(DomainManager.World.GetCurrDate(), skillIndex))
		{
			return false;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		ResourceInts resources = taiwu.GetResources();
		foreach (ResourceInfo resourceInfo in skillCfg.ResourcesCost)
		{
			if (!resources.CheckIsMeet(resourceInfo.ResourceType, resourceInfo.ResourceCount))
			{
				return false;
			}
		}
		if (!CheckSpecialCondition(professionData, skillIndex))
		{
			return false;
		}
		return true;
	}

	public static int GetSkillIndex(ProfessionSkillItem skillCfg)
	{
		ProfessionItem professionCfg = Config.Profession.Instance[skillCfg.Profession];
		return (professionCfg.ExtraProfessionSkill == skillCfg.TemplateId) ? professionCfg.ProfessionSkills.Length : professionCfg.ProfessionSkills.IndexOf(skillCfg.TemplateId);
	}

	public static bool CheckSpecialCondition(int professionId, int skillIndex)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(professionId);
		return CheckSpecialCondition(professionData, skillIndex);
	}

	public static bool CheckSpecialCondition(ProfessionData professionData, int skillIndex)
	{
		return professionData.TemplateId switch
		{
			0 => CheckSpecialCondition_SavageSkill(professionData, skillIndex), 
			1 => CheckSpecialCondition_HunterSkill(professionData, skillIndex), 
			3 => CheckSpecialCondition_MartialArtistSkill(professionData, skillIndex), 
			4 => CheckSpecialCondition_LiteratiSkill(professionData, skillIndex), 
			5 => CheckSpecialCondition_TaoistMonkSkill(professionData, skillIndex), 
			6 => CheckSpecialCondition_BuddhistMonkSkill(professionData, skillIndex), 
			7 => CheckSpecialCondition_WineTasterSkill(professionData, skillIndex), 
			8 => CheckSpecialCondition_AristocratSkill(professionData, skillIndex), 
			9 => CheckSpecialCondition_BeggarSkill(professionData, skillIndex), 
			10 => CheckSpecialCondition_CivilianSkill(professionData, skillIndex), 
			12 => CheckSpecialCondition_TravelingBuddhistMonkSkill(professionData, skillIndex), 
			13 => CheckSpecialCondition_DoctorSkill(professionData, skillIndex), 
			14 => CheckSpecialCondition_TravelingTaoistMonkSkill(professionData, skillIndex), 
			15 => CheckSpecialCondition_CapitalistSkill(professionData, skillIndex), 
			16 => CheckSpecialCondition_TeaTasterSkill(professionData, skillIndex), 
			17 => CheckSpecialCondition_DukeSkill(professionData, skillIndex), 
			_ => true, 
		};
	}

	public static void OnSkillExecuted(DataContext context, ref ProfessionSkillArg arg)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(arg.ProfessionId);
		int skillIndex = professionData.GetSkillIndex(arg.SkillId);
		ProfessionSkillItem skillCfg = professionData.GetSkillConfig(skillIndex);
		if (!DomainManager.Extra.NoProfessionSkillCost)
		{
			if (!skillCfg.CostTimeWhenFinished)
			{
				DomainManager.World.AdvanceDaysInMonth(context, skillCfg.TimeCost);
			}
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			foreach (ResourceInfo resourceInfo in skillCfg.ResourcesCost)
			{
				taiwu.ChangeResource(context, resourceInfo.ResourceType, -resourceInfo.ResourceCount);
			}
			DomainManager.Taiwu.GetTaiwu().ChangeExp(context, -skillCfg.ExpCost);
		}
		professionData.OfflineSkillCooldown(skillIndex);
		DomainManager.Extra.SetProfessionData(context, professionData);
		if (skillCfg.Type == EProfessionSkillType.Interactive)
		{
			DomainManager.TaiwuEvent.SetIsSequential(value: true);
		}
	}

	public static void OnActiveSkillExecuted(DataContext context, ref ProfessionSkillArg arg)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(arg.ProfessionId);
		int skillIndex = professionData.GetSkillIndex(arg.SkillId);
		ProfessionSkillItem skillCfg = professionData.GetSkillConfig(skillIndex);
		if (skillCfg.Type == EProfessionSkillType.Active)
		{
			switch (professionData.TemplateId)
			{
			case 0:
				ExecuteOnClick_SavageSkill(context, professionData, skillIndex, ref arg);
				break;
			case 1:
				ExecuteOnClick_HunterSkill(context, professionData, skillIndex, ref arg);
				break;
			case 2:
				ExecuteOnClick_CraftSkill(context, professionData, skillIndex, ref arg);
				break;
			case 3:
				ExecuteOnClick_MartialArtist(context, professionData, skillIndex, ref arg);
				break;
			case 4:
				break;
			case 5:
				ExecuteOnClick_TaoistMonkSkill(context, professionData, skillIndex, ref arg);
				break;
			case 6:
				ExecuteOnClick_BuddhistMonkSkill(context, professionData, skillIndex, ref arg);
				break;
			case 7:
				ExecuteOnClick_WineTasterSkill(context, professionData, skillIndex, ref arg);
				break;
			case 8:
				ExecuteOnClick_AristocratSkill(context, professionData, skillIndex, ref arg);
				break;
			case 9:
				ExecuteOnClick_BeggarSkill(context, professionData, skillIndex, ref arg);
				break;
			case 10:
				ExecuteOnClick_CivilianSkill(context, professionData, skillIndex, ref arg);
				break;
			case 11:
				ExecuteOnClick_TravelerSkill(context, professionData, skillIndex, ref arg);
				break;
			case 12:
				ExecuteOnClick_TravelingBuddhistMonkSkill(context, professionData, skillIndex, ref arg);
				break;
			case 13:
				ExecuteOnClick_DoctorSkill(context, professionData, skillIndex, ref arg);
				break;
			case 14:
				ExecuteOnClick_TravelingTaoistMonkSkill(context, professionData, skillIndex, ref arg);
				break;
			case 15:
				break;
			case 16:
				ExecuteOnClick_TeaTasterSkill(context, professionData, skillIndex, ref arg);
				break;
			case 17:
				ExecuteOnClick_DukeSkill(context, professionData, skillIndex, ref arg);
				break;
			}
		}
	}

	public static void ConfirmSkillExecute(ref ProfessionSkillArg professionSkillArg)
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ConfirmProfessionSkillExecute, professionSkillArg);
	}

	public static void ConfirmSkillExecuteWithEvent(ProfessionSkillArg professionSkillArg, string afterEvent, EventArgBox argBox)
	{
		if (!string.IsNullOrEmpty(afterEvent))
		{
			DomainManager.TaiwuEvent.SetListenerWithActionName(afterEvent, argBox, "ConfirmProfessionSkillExecuteAndAnimComplete");
		}
		int beggarMoneyCount = 0;
		if (argBox.Contains<int>("BeggarMoneyCount"))
		{
			beggarMoneyCount = argBox.GetInt("BeggarMoneyCount");
		}
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ConfirmProfessionSkillExecute, professionSkillArg, beggarMoneyCount);
	}

	public static void ExecuteActiveProfessionSkill(int professionId, int skillIndex)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(professionId);
		ProfessionSkillItem skillCfg = professionData.GetSkillConfig(skillIndex);
		DomainManager.TaiwuEvent.OnEvent_ProfessionSkillClicked(skillCfg.TemplateId);
		if (skillCfg.Instant)
		{
			ProfessionSkillArg professionSkillArg = new ProfessionSkillArg
			{
				ProfessionId = professionId,
				SkillId = skillCfg.TemplateId,
				IsSuccess = true,
				SkipAnimation = (skillCfg.TemplateId == 23 || skillCfg.TemplateId == 15)
			};
			ConfirmSkillExecute(ref professionSkillArg);
			return;
		}
		switch (skillCfg.TemplateId)
		{
		case 3:
			OpenItemSelectFromBlock();
			break;
		case 10:
			OpenSetWeaponTrick();
			break;
		case 31:
		case 39:
		case 46:
		case 47:
		case 51:
		case 67:
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenProfessionSkillSpecial, skillCfg.TemplateId);
			break;
		case 18:
		{
			SecretInformationDisplayPackage secrets = DomainManager.Information.GetSecretInformationDisplayPackageFromCharacter(DomainManager.Taiwu.GetTaiwuCharId());
			if (secrets.SecretInformationDisplayDataList != null)
			{
				foreach (SecretInformationDisplayData secret in secrets.SecretInformationDisplayDataList)
				{
					SecretInformationItem config = SecretInformation.Instance.GetItem(secret.SecretInformationTemplateId);
					secret.AuthorityCostWhenDisseminatingForBroadcast = CalcLiteratiSkill2AuthorityCost(config, secret.HolderCount);
				}
			}
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenSelectSecretInformationLiteratiSkill2, secrets);
			break;
		}
		case 19:
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenSelectNormalInformationLiteratiSkill3);
			break;
		case 70:
		{
			List<ItemDisplayData> cricketList = new List<ItemDisplayData>();
			foreach (KeyValuePair<ItemKey, int> itemPair in DomainManager.Taiwu.GetTaiwu().GetInventory().Items)
			{
				if (itemPair.Key.ItemType == 11 && DomainManager.Item.TryGetElement_Crickets(itemPair.Key.Id, out var cricket) && !cricket.IsAlive)
				{
					cricketList.Add(DomainManager.Item.GetItemDisplayData(itemPair.Key));
				}
			}
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenSelectCricketDukeSkill2, cricketList);
			break;
		}
		case 62:
			OpenInvestCaravan();
			break;
		}
	}

	public static void OnPreAdvanceMonth(DataContext context)
	{
		TravelingTaoistMonkSkill_OnPreAdvanceMonth(context);
	}

	public static void OnPostAdvanceMonth(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		TeaTasterSkill_SetActionPointGained(context, 0);
		BeggarSkill_AdvanceMonth(context);
		HunterSkill_AdvanceMonth(context);
		MartialArtistSkill_AdvanceMonth(context);
		TaoistMonkSkill_OnPostAdvanceMonth(context);
		UpdateSeniorityOnPostAdvanceMonth(context, taiwu);
		UpdateDukeMonthlyEvent(context);
		int currDate = DomainManager.World.GetCurrDate();
		TaiwuProfessionSkillSlots slots = DomainManager.Extra.GetTaiwuProfessionSkillSlots();
		IntList[] slots2 = slots.Slots;
		for (int i = 0; i < slots2.Length; i++)
		{
			IntList levelSlots = slots2[i];
			foreach (int skillId in levelSlots.Items)
			{
				if (skillId < 0)
				{
					continue;
				}
				ProfessionSkillItem skillConfig = ProfessionSkill.Instance[skillId];
				if (skillConfig.Type == EProfessionSkillType.Passive)
				{
					continue;
				}
				ProfessionData professionData = DomainManager.Extra.GetProfessionData(skillConfig.Profession);
				int skillIndex = skillConfig.Level - 1;
				if (professionData.IsSkillUnlocked(skillIndex))
				{
					int offCooldownDate = professionData.SkillOffCooldownDates[skillIndex];
					if (offCooldownDate != 0 && currDate == offCooldownDate)
					{
						DomainManager.World.GetInstantNotificationCollection().AddProfessionSkillHasCoolDown(skillConfig.TemplateId);
					}
				}
			}
		}
	}

	private static bool IsSkillUnlocked(int skillTemplateId)
	{
		return DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(skillTemplateId);
	}

	private static void UpdateSeniorityOnPostAdvanceMonth(DataContext context, GameData.Domains.Character.Character character)
	{
		ItemKey clothingKey = character.GetEquipment()[4];
		if (!clothingKey.IsValid() || DomainManager.Item.GetBaseItem(clothingKey).IsDurabilityRunningOut())
		{
			return;
		}
		foreach (ProfessionItem professionCfg in (IEnumerable<ProfessionItem>)Config.Profession.Instance)
		{
			if (professionCfg.BonusClothing != clothingKey.TemplateId)
			{
				continue;
			}
			DomainManager.Extra.ChangeProfessionSeniority(context, professionCfg.TemplateId, GlobalConfig.Instance.ProfessionSeniorityPerMonth);
			break;
		}
	}

	private static void UpdateDukeMonthlyEvent(DataContext context)
	{
		SeasonItem autumnConfig = Season.Instance[(sbyte)2];
		sbyte currMonth = DomainManager.World.GetCurrMonthInYear();
		if (autumnConfig.Months.Contains(currMonth))
		{
			ProfessionData professionData = DomainManager.Extra.GetProfessionData(17);
			DukeSkillsData duke = (DukeSkillsData)professionData.SkillsData;
			if (duke.GetNotGivenCricketTitles(DomainManager.Character.IsCharacterAlive).Any())
			{
				DomainManager.World.GetMonthlyEventCollection().AddProfessionDukeReceiveCricket(DomainManager.Taiwu.GetTaiwuCharId());
			}
		}
		else if (currMonth == 10)
		{
			ProfessionData professionData2 = DomainManager.Extra.GetProfessionData(17);
			DukeSkillsData duke2 = (DukeSkillsData)professionData2.SkillsData;
			duke2.ResetAllCricketGivenData();
			DomainManager.Extra.SetProfessionData(context, professionData2);
		}
	}

	public static void UnpackCrossArchiveProfession(DataContext context, int professionId)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(professionId);
		ProfessionItem professionCfg = Config.Profession.Instance[professionId];
		if (professionData.SkillsData != null && professionCfg.ReinitOnCrossArchive)
		{
			professionData.SkillsData.Initialize();
			DomainManager.Extra.SetProfessionData(context, professionData);
		}
		switch (professionId)
		{
		case 5:
			UnpackCrossArchiveProfession_TaoistMonk(context);
			break;
		case 6:
			UnpackCrossArchiveProfession_BuddhistMonk(context);
			break;
		}
	}

	public static void OnTaiwuDeath(DataContext context)
	{
		TaoistMonkSkill_ResetSurvivedTribulationCount(context);
		BuddhistMonkSkill_ClearSavedSoulCount(context);
		TravelingTaoistMonkSkill_ClearHealthBonus(context);
	}

	public static void AristocratSkill_ChangeInfluencePower(DataContext context, int charId, bool isAdd)
	{
		SettlementCharacter settlementCharacter = DomainManager.Organization.GetSettlementCharacter(charId);
		short currInfluencePower = settlementCharacter.GetInfluencePower();
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(8);
		int percentage = 50 + 50 * professionData.GetSeniorityPercent() / 100;
		AristocratSkillsData skillsData = professionData.GetSkillsData<AristocratSkillsData>();
		int bonus = currInfluencePower * percentage / 100;
		if (isAdd)
		{
			skillsData.OfflineAddRecommendedCharId(charId);
		}
		else
		{
			bonus = -bonus;
		}
		skillsData.OfflineSetInfluencePowerBonus(charId, (short)bonus);
		DomainManager.Extra.SetProfessionData(context, professionData);
		short influencePower = (short)Math.Clamp(currInfluencePower + bonus, 0, 32767);
		settlementCharacter.SetInfluencePower(influencePower, context);
		int delta = Math.Abs(influencePower - currInfluencePower);
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (DomainManager.Taiwu.GetTaiwu().GetLocation().IsValid())
		{
			MapBlockData blockData = DomainManager.Map.GetBlock(taiwuLocation);
			DomainManager.Map.SetBlockData(context, blockData);
			InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotificationCollection();
			if (isAdd)
			{
				instantNotification.AddRecommendFellowUp(charId, delta, influencePower);
			}
			else
			{
				instantNotification.AddRecommendFellowDown(charId, delta, influencePower);
			}
			EventHelper.ChangeAlertnessOnProfessionAristocratSkill0(charId, delta);
		}
	}

	public static void AristocratSkill_BoostTaiwuAsTargetInCollection(List<int> collection)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		for (int i = 0; i < 4; i++)
		{
			collection.Add(taiwuId);
		}
	}

	private static void ExecuteOnClick_AristocratSkill4(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuId = taiwu.GetId();
		Location location = taiwu.GetLocation();
		MapBlockData currBlock = DomainManager.Map.GetBlock(location);
		MapBlockData blockData = currBlock.GetRootBlock();
		Settlement settlement = DomainManager.Organization.GetSettlementByLocation(blockData.GetLocation());
		short settlementId = settlement.GetId();
		sbyte orgTemplateId = settlement.GetOrgTemplateId();
		int currDate = DomainManager.World.GetCurrDate();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		SettlementPrisonRecordCollection prisonRecordCollection = DomainManager.Organization.GetSettlementPrisonRecordCollection(context, settlementId);
		if (!(settlement is Sect { Prison: var prison } sect))
		{
			return;
		}
		int count = prison.Prisoners.Count;
		int realCount = 0;
		for (int i = count - 1; i >= 0; i--)
		{
			SettlementPrisoner prisoner = prison.Prisoners[i];
			if (DomainManager.Character.TryGetElement_Objects(prisoner.CharId, out var character) && !character.IsCompletelyInfected())
			{
				sect.RemovePrisoner(context, prisoner.CharId);
				realCount++;
				OrganizationMemberItem orgMemberCfg = OrganizationDomain.GetOrgMemberConfig(orgTemplateId, character.GetOrganizationInfo().Grade);
				sbyte rejoinGrade = orgMemberCfg.GetRejoinGrade();
				OrganizationInfo newOrgInfo = new OrganizationInfo(orgTemplateId, rejoinGrade, principal: true, settlementId);
				int remaining = prisoner.Duration - (currDate - prisoner.KidnapBeginDate);
				DomainManager.Character.ChangeFavorabilityOptional(context, character, taiwu, 2500 * prisoner.PunishmentSeverity * remaining / prisoner.Duration, 3);
				lifeRecordCollection.AddAristocratReleasePrisoner(taiwuId, currDate, settlementId);
				lifeRecordCollection.AddPrisonerBeReleaseByAristocrat(prisoner.CharId, currDate, taiwuId, settlementId);
				DomainManager.Organization.ChangeOrganization(context, character, newOrgInfo);
				SectCharacter sectChar = DomainManager.Organization.GetElement_SectCharacters(prisoner.CharId);
				sectChar.SetApprovedTaiwu(context, approve: true);
				prisonRecordCollection.AddPrisonerBeReleaseByAristocrat(currDate, settlementId, prisoner.CharId, taiwuId);
				DomainManager.Organization.SetSettlementPrisonRecordCollection(context, settlementId, prisonRecordCollection);
			}
		}
		if (realCount > 0)
		{
			DomainManager.World.GetInstantNotificationCollection().AddReleasePrisoners(settlementId, realCount);
		}
	}

	private static void ExecuteOnClick_AristocratSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		if (index == 3)
		{
			ExecuteOnClick_AristocratSkill4(context);
			return;
		}
		throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
	}

	private static bool CheckSpecialCondition_AristocratSkill(ProfessionData professionData, int index)
	{
		if (index == 3)
		{
			return DomainManager.Extra.CheckAristocratUltimateSpecialCondition() == 0;
		}
		return true;
	}

	private static bool CheckSpecialCondition_BeggarSkill(ProfessionData professionData, int index)
	{
		return index switch
		{
			0 => CheckSpecialCondition_BeggarSkill_1(professionData), 
			1 => true, 
			3 => CheckSpecialCondition_BeggarSkill_4(professionData), 
			_ => true, 
		};
	}

	private static bool CheckSpecialCondition_BeggarSkill_1(ProfessionData professionData)
	{
		sbyte settlementType = professionData.GetSeniorityBeggarMaxSettlementType();
		return CheckSettlementBlockTypeValid(settlementType);
	}

	private static bool CheckSpecialCondition_BeggarSkill_4(ProfessionData professionData)
	{
		return DomainManager.Extra.CheckBeggarUltimateSpecialCondition() == 0;
	}

	private static void ExecuteOnClick_BeggarSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		switch (index)
		{
		case 1:
			ExecuteOnClick_BeggarSkill2(context);
			break;
		case 3:
			ExecuteOnClick_BeggarSkill4(context, arg.CharId, arg.ItemKey);
			break;
		default:
			throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
		}
	}

	public static int BeggarSkill_GetBeggingMoney(DataContext context, GameData.Domains.Character.Character character)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(9);
		int baseValue = 10 + 90 * professionData.GetSeniorityPercent() / 100;
		int happinessBonusFactor = -taiwu.GetHappiness();
		int injuriesBonusFactor = taiwu.GetInjuries().GetSum() * 3;
		int poisonedBonusFactor = taiwu.GetPoisonMarkCount() * 9;
		CValuePercentBonus factor1 = happinessBonusFactor + injuriesBonusFactor + poisonedBonusFactor;
		CValuePercent factor2 = ProfessionRelatedConstants.BeggarMoneyBehaviorTypeFactors[character.GetBehaviorType()];
		int value = baseValue * factor1 * factor2;
		return Math.Min(value, character.GetResource(6) * ProfessionRelatedConstants.BeggarMoneyMaxPercent);
	}

	public static int BeggarSkill_GetLocationBeggingMoney(DataContext context, Location location, bool isTransferMoney = false)
	{
		MapBlockData mapBlockData = DomainManager.Map.GetBlockData(location.AreaId, location.BlockId);
		HashSet<int> characterSet = mapBlockData.CharacterSet;
		int moneyTaiwuGet = 0;
		foreach (int charId in characterSet)
		{
			if (DomainManager.Character.TryGetElement_Objects(charId, out var character))
			{
				int moneyValue = BeggarSkill_GetBeggingMoney(context, character);
				if (isTransferMoney)
				{
					character.ChangeResource(context, 6, -moneyValue);
				}
				moneyTaiwuGet += moneyValue;
			}
		}
		return moneyTaiwuGet;
	}

	public static void BeggarSkill_AddLookingForCharacter(DataContext context, string name)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(9);
		BeggarSkillsData skillsData = (BeggarSkillsData)professionData.SkillsData;
		skillsData.LookingForCharName = name;
		skillsData.AlreadyFoundCharacters.Clear();
		DomainManager.Extra.SetProfessionData(context, professionData);
	}

	public static void BeggarSkill_ClearLookingForCharacter(DataContext context)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(9);
		BeggarSkillsData skillsData = (BeggarSkillsData)professionData.SkillsData;
		skillsData.LookingForCharName = null;
		skillsData.AlreadyFoundCharacters.Clear();
		DomainManager.Extra.SetProfessionData(context, professionData);
	}

	public static string BeggarSkill_LookingForCharacter()
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(9);
		BeggarSkillsData skillsData = (BeggarSkillsData)professionData.SkillsData;
		return skillsData.LookingForCharName;
	}

	public static bool BeggarSkill_FoundMoreAlive()
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(9);
		BeggarSkillsData skillsData = (BeggarSkillsData)professionData.SkillsData;
		return skillsData.FoundMoreAlive;
	}

	public static bool BeggarSkill_FoundMoreDead()
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(9);
		BeggarSkillsData skillsData = (BeggarSkillsData)professionData.SkillsData;
		return skillsData.FoundMoreDead;
	}

	public static void ExecuteOnClick_BeggarSkill2(DataContext context)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location centerLocation = taiwu.GetLocation();
		int range = 3;
		List<MapBlockData> neighborMapBlockList = ObjectPool<List<MapBlockData>>.Instance.Get();
		DomainManager.Map.GetLocationByDistance(centerLocation, range, range, ref neighborMapBlockList);
		MapBlockData centerBlock = DomainManager.Map.GetAreaBlocks(centerLocation.AreaId)[centerLocation.BlockId];
		List<int> characters = new List<int>();
		if (centerBlock.CharacterSet != null)
		{
			characters.AddRange(centerBlock.CharacterSet);
		}
		if (characters.Count > 0)
		{
			characters.ForEach(delegate(int charId)
			{
				GameData.Domains.Character.Character element_Objects = DomainManager.Character.GetElement_Objects(charId);
				if (element_Objects.GetId() != taiwu.GetId())
				{
					DomainManager.Character.GroupMove(context, element_Objects, SelectRandomValidTargetLocation(ref neighborMapBlockList));
				}
			});
		}
		BeggarSkill_AddCurrentLocationForbiddenMapBlock(context, centerLocation);
		DomainManager.World.GetInstantNotificationCollection().AddDriveAwayPeople(centerLocation);
		ObjectPool<List<MapBlockData>>.Instance.Return(neighborMapBlockList);
		Location SelectRandomValidTargetLocation(ref List<MapBlockData> reference)
		{
			CollectionUtils.Shuffle(context.Random, reference);
			Location targetLocation = Location.Invalid;
			foreach (MapBlockData neighborBlock in reference)
			{
				Location neighborLocation = neighborBlock.GetLocation();
				if (neighborLocation.IsValid() && !IsLocationForbiddenByBeggarSkill(neighborLocation))
				{
					targetLocation = neighborLocation;
					break;
				}
			}
			return targetLocation;
		}
	}

	public static void ExecuteOnClick_BeggarSkill4(DataContext context, int charId, ItemKey itemKey)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		GameData.Domains.Character.Character target = DomainManager.Character.GetElement_Objects(charId);
		ItemBase baseItem = DomainManager.Item.GetBaseItem(itemKey);
		int favorChange = baseItem.GetFavorabilityChange();
		sbyte happinessChange = baseItem.GetHappinessChange();
		ItemKey eatItem = itemKey;
		int count = 1;
		if (ItemTemplateHelper.IsTianJieFuLu(itemKey.ItemType, itemKey.TemplateId))
		{
			count = ItemTemplateHelper.GetTianJieFuLuCountUnit();
			eatItem = DomainManager.Item.CreateItem(context, 8, 432);
			taiwu.AddInventoryItem(context, eatItem, 1);
		}
		target.RemoveInventoryItem(context, itemKey, count, deleteItem: false);
		taiwu.AddEatingItem(context, eatItem);
		DomainManager.Character.ChangeFavorabilityOptional(context, target, taiwu, favorChange, 0);
		DomainManager.Character.AddFavorabilityChangeInstantNotification(target, taiwu, favorChange > 0);
		target.ChangeHappiness(context, happinessChange);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		lifeRecordCollection.AddBeggarEatSomeoneFood(taiwu.GetId(), currDate, target.GetId(), taiwu.GetLocation(), itemKey.ItemType, itemKey.TemplateId);
		EventHelper.ChangeAlertnessOnProfessionBeggarSkill3(charId, itemKey);
	}

	public static bool IsLocationForbiddenByBeggarSkill(Location location)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(9);
		BeggarSkillsData skillsData = (BeggarSkillsData)professionData.SkillsData;
		return skillsData.ForbiddenLocations != null && skillsData.ForbiddenLocations.Contains(location);
	}

	private static void BeggarSkill_AddCurrentLocationForbiddenMapBlock(DataContext context, Location targetLocation)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(9);
		BeggarSkillsData skillsData = (BeggarSkillsData)professionData.SkillsData;
		if (skillsData.ForbiddenLocations == null)
		{
			skillsData.ForbiddenLocations = new List<Location>();
		}
		skillsData.ForbiddenLocations.Add(targetLocation);
		DomainManager.Extra.SetProfessionData(context, professionData);
	}

	private static void BeggarSkill_AdvanceMonth(DataContext context)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(9);
		BeggarSkillsData skillsData = professionData.GetSkillsData<BeggarSkillsData>();
		skillsData?.ForbiddenLocations?.Clear();
		DomainManager.Extra.SetProfessionData(context, professionData);
		if (!IsSkillUnlocked(38))
		{
			return;
		}
		skillsData.FoundMoreAlive = false;
		skillsData.FoundMoreDead = false;
		if (string.IsNullOrEmpty(skillsData.LookingForCharName))
		{
			return;
		}
		HashSet<int> exceptions = skillsData.AlreadyFoundCharacters.GetCollection();
		MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
		List<GameData.Domains.Character.Character> characterResults = new List<GameData.Domains.Character.Character>();
		MapCharacterFilter.ParallelFind(CharacterPredicate, characterResults, 0, 135);
		MapCharacterFilter.FindTraveling(CharacterPredicate, characterResults);
		Predicate<GameData.Domains.Character.Character> calledByAdventure = (GameData.Domains.Character.Character character3) => character3.IsActiveExternalRelationState(188uL);
		if (characterResults.Count > 0)
		{
			if (characterResults.TrueForAll(calledByAdventure))
			{
				GameData.Domains.Character.Character character = characterResults.GetRandom(context.Random);
				int foundCharId = character.GetId();
				monthlyEventCollection.AddBeggerSkill2TargetUnavailable(foundCharId);
				skillsData.AlreadyFoundCharacters.Add(foundCharId);
				DomainManager.Extra.SetProfessionData(context, professionData);
				return;
			}
			characterResults.RemoveAll(calledByAdventure);
			GameData.Domains.Character.Character foundCharacter = characterResults.GetRandom(context.Random);
			monthlyEventCollection.AddBeggarSkill2TargetBrought(foundCharacter.GetId(), foundCharacter.GetLocation());
			skillsData.FoundMoreAlive = characterResults.Count > 1;
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			Location targetLocation = taiwu.GetLocation();
			if (!targetLocation.IsValid())
			{
				targetLocation = taiwu.GetValidLocation();
			}
			DomainManager.Character.GroupMove(context, foundCharacter, targetLocation);
			skillsData.AlreadyFoundCharacters.Add(foundCharacter.GetId());
			DomainManager.Extra.SetProfessionData(context, professionData);
			return;
		}
		MapCharacterFilter.FindHiddenCharacters(CharacterPredicate, characterResults);
		MapCharacterFilter.FindKidnappedCharacters(CharacterPredicate, characterResults);
		if (characterResults.Count > 0)
		{
			GameData.Domains.Character.Character character2 = characterResults.GetRandom(context.Random);
			int foundCharId2 = character2.GetId();
			monthlyEventCollection.AddBeggerSkill2TargetUnavailable(foundCharId2);
			skillsData.AlreadyFoundCharacters.Add(foundCharId2);
			DomainManager.Extra.SetProfessionData(context, professionData);
			return;
		}
		List<Grave> foundGraves = new List<Grave>();
		DomainManager.Character.FindGrave(GravePredicate, foundGraves);
		if (foundGraves.Count > 0)
		{
			Grave targetGrave = foundGraves.GetRandom(context.Random);
			int foundCharId3 = targetGrave.GetId();
			monthlyEventCollection.AddBeggarSkill2TargetDead(foundCharId3, targetGrave.GetLocation());
			skillsData.FoundMoreDead = foundGraves.Count > 0;
			skillsData.AlreadyFoundCharacters.Add(foundCharId3);
			DomainManager.Extra.SetProfessionData(context, professionData);
		}
		else
		{
			monthlyEventCollection.AddBeggarSkill2TargetNoneExistent(skillsData.LookingForCharName);
		}
		bool CharacterPredicate(GameData.Domains.Character.Character character3)
		{
			if (character3.GetAgeGroup() == 0)
			{
				return false;
			}
			if (character3.GetLegendaryBookOwnerState() >= 2)
			{
				return false;
			}
			if (!CharacterMatchers.MatchMonasticTitleOrDisplayName(character3, skillsData.LookingForCharName))
			{
				return false;
			}
			if (exceptions != null && exceptions.Contains(character3.GetId()))
			{
				return false;
			}
			return true;
		}
		bool GravePredicate(Grave grave)
		{
			int charId = grave.GetId();
			if (exceptions != null && exceptions.Contains(charId))
			{
				return false;
			}
			var (surname, givenName) = DomainManager.Character.GetNameRelatedData(charId).GetMonasticTitleOrDisplayName(isTaiwu: false);
			return skillsData.LookingForCharName == surname + givenName;
		}
	}

	private static bool CheckSettlementBlockTypeValid(sbyte settlementType)
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return false;
		}
		MapBlockData block = DomainManager.Map.GetBlock(taiwuLocation);
		MapBlockData rootBlock = block.GetRootBlock();
		if (!rootBlock.IsCityTown())
		{
			return false;
		}
		return settlementType switch
		{
			0 => rootBlock.BlockSubType == EMapBlockSubType.Village || rootBlock.BlockSubType == EMapBlockSubType.TaiwuCun, 
			1 => rootBlock.BlockType != EMapBlockType.Sect && rootBlock.BlockType != EMapBlockType.City && rootBlock.BlockSubType != EMapBlockSubType.Town, 
			2 => rootBlock.BlockType == EMapBlockType.Town, 
			3 => true, 
			_ => false, 
		};
	}

	private static void ExecuteOnClick_BuddhistMonkSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		if (index == 3)
		{
			BuddhistMonkSkill_SetSamsaraFeature(context, DomainManager.Taiwu.GetTaiwu().GetId(), arg.EffectId);
			return;
		}
		throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
	}

	public static void BuddhistMonkSkill_SelectDirectedSamsara(DataContext context, int motherId, int reincarnatedCharId)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
		BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
		skillsData.OfflineAddDirectedSamsara(motherId, reincarnatedCharId);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		DomainManager.Extra.SetProfessionData(context, professionData);
		GameData.Domains.Character.Character mother = DomainManager.Character.GetElement_Objects(motherId);
		if (!DomainManager.Character.TryGetPregnantState(motherId, out var _))
		{
			DomainManager.Character.RemovePregnantLock(context, motherId);
			DomainManager.Character.MakePregnantWithoutMale(context, mother);
		}
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		lifeRecordCollection.AddTaiwuReincarnationPregnancy(motherId, currDate, mother.GetLocation());
		lifeRecordCollection.AddTaiwuReincarnation(reincarnatedCharId, currDate, motherId, taiwu.GetLocation(), mother.GetOrganizationInfo().SettlementId);
	}

	public static void BuddhistMonkSkill_TryRemoveDirectedSamsara(DataContext context, int motherId, bool addMonthlyEvent = true)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
		BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
		int charId = skillsData.GetDirectedSamsara(motherId);
		if (!skillsData.OfflineRemoveDirectedSamsara(motherId))
		{
			return;
		}
		DomainManager.Extra.SetProfessionData(context, professionData);
		if (addMonthlyEvent)
		{
			if (DomainManager.World.GetAdvancingMonthState() != 0)
			{
				MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
				int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
				monthlyEventCollection.AddTaiwuComingDefeated(taiwuCharId, charId);
			}
			else
			{
				Events.RegisterHandler_PostAdvanceMonthBegin(AddTaiwuComingEvent);
			}
		}
		void AddTaiwuComingEvent(DataContext dataContext)
		{
			MonthlyEventCollection monthlyEventCollection2 = DomainManager.World.GetMonthlyEventCollection();
			int taiwuCharId2 = DomainManager.Taiwu.GetTaiwuCharId();
			monthlyEventCollection2.AddTaiwuComingDefeated(taiwuCharId2, charId);
			Events.UnRegisterHandler_PostAdvanceMonthBegin(AddTaiwuComingEvent);
		}
	}

	public static bool BuddhistMonkSkill_IsDirectedSamsaraMother(int motherId)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
		BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
		return skillsData.GetDirectedSamsara(motherId) >= 0;
	}

	public static bool BuddhistMonkSkill_IsDirectedSamsaraCharacter(int reincarnatedCharId)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
		BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
		return skillsData.IsDirectedSamsaraCharacter(reincarnatedCharId);
	}

	public static void BuddhistMonkSkill_SetSamsaraFeature(DataContext context, int reincarnatedCharId, short featureID)
	{
		if (reincarnatedCharId != -1)
		{
			ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
			BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
			skillsData.OfflineAddSamsaraFeature(reincarnatedCharId, featureID);
			DomainManager.Extra.SetProfessionData(context, professionData);
		}
	}

	public static bool BuddhistMonkSkill_TryGetSamsaraFeature(int reincarnatedCharId, out short featureID)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
		BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
		return skillsData.TryGetSamaraFeature(reincarnatedCharId, out featureID);
	}

	public static bool BuddhistMonkSkill_RemoveSamsaraFeature(DataContext context, int reincarnatedCharId)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
		BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
		if (skillsData.OfflineRemoveSamsaraFeature(reincarnatedCharId))
		{
			DomainManager.Extra.SetProfessionData(context, professionData);
			return true;
		}
		return false;
	}

	public static void BuddhistMonkSkill_SetSamsaraReplaceAvatar(DataContext context, int reincarnatedCharId, bool res)
	{
		if (reincarnatedCharId != -1)
		{
			ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
			BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
			skillsData.OfflineAddSamsaraReplaceAvatar(reincarnatedCharId, res);
			DomainManager.Extra.SetProfessionData(context, professionData);
		}
	}

	public static bool BuddhistMonkSkill_TryGetSamsaraReplaceAvatar(int reincarnatedCharId, out bool res)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
		BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
		return skillsData.TryGetSamaraReplaceAvatar(reincarnatedCharId, out res);
	}

	public static bool BuddhistMonkSkill_RemoveSamsaraReplaceAvatar(DataContext context, int reincarnatedCharId)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
		BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
		if (skillsData.OfflineRemoveSamsaraReplaceAvatar(reincarnatedCharId))
		{
			DomainManager.Extra.SetProfessionData(context, professionData);
			return true;
		}
		return false;
	}

	public static int BuddhistMonkSkill_GetDirectedSamsaraMother(int reincarnatedCharId)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
		BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
		return skillsData.GetDirectedSamsaraMother(reincarnatedCharId);
	}

	private static void BuddhistMonkSkill_ClearSavedSoulCount(DataContext context)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
		BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
		skillsData.OfflineClearSavedSoulsCount();
		DomainManager.Extra.SetProfessionData(context, professionData);
	}

	private static void UnpackCrossArchiveProfession_BuddhistMonk(DataContext context)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(6);
		BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
		skillsData.OfflineClearDirectedSamsara();
		DomainManager.Extra.SetProfessionData(context, professionData);
	}

	private static bool CheckSpecialCondition_BuddhistMonkSkill(ProfessionData professionData, int index)
	{
		if (index == 3)
		{
			return CheckSpecialCondition_BuddhistMonkSkill_3(professionData);
		}
		return true;
	}

	private static bool CheckSpecialCondition_BuddhistMonkSkill_3(ProfessionData professionData)
	{
		BuddhistMonkSkillsData skillsData = professionData.GetSkillsData<BuddhistMonkSkillsData>();
		return skillsData.GetSavedSoulsCount() >= 100;
	}

	private static bool CheckSpecialCondition_CapitalistSkill(ProfessionData professionData, int index)
	{
		return true;
	}

	public static void OpenInvestCaravan()
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenInvestCaravan);
	}

	private static void ExecuteOnClick_CivilianSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		if (index == 1)
		{
			ExecuteOnClick_CivilianSkill_1(context, professionData);
			return;
		}
		throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
	}

	private static void ExecuteOnClick_CivilianSkill_1(DataContext context, ProfessionData professionData)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		Location location = taiwu.GetLocation();
		if (!location.IsValid())
		{
			return;
		}
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		int count = 0;
		int limit = ProfessionData.GetSeniorityCivilianSeverHatredLimit(professionData.Seniority);
		List<int> availableCharIds = new List<int>();
		List<(int, int)> pairs = new List<(int, int)>();
		MapBlockData block = DomainManager.Map.GetBlock(location);
		if (block.CharacterSet != null && block.CharacterSet.Count != 0)
		{
			foreach (int charId in block.CharacterSet)
			{
				availableCharIds.Add(charId);
			}
		}
		foreach (int charId2 in DomainManager.Taiwu.GetGroupCharIds().GetCollection())
		{
			if (charId2 != taiwuCharId)
			{
				availableCharIds.Add(charId2);
			}
		}
		foreach (int charId3 in availableCharIds)
		{
			if (DomainManager.Character.GetRelatedCharIds(charId3, 32768).Contains(taiwuCharId))
			{
				pairs.Add((charId3, taiwuCharId));
				count++;
				if (count >= limit)
				{
					break;
				}
			}
		}
		if (count < limit)
		{
			foreach (int charId4 in availableCharIds)
			{
				HashSet<int> characterSet = DomainManager.Character.GetRelatedCharIds(charId4, 32768);
				foreach (int charIdB in availableCharIds)
				{
					HashSet<int> characterSetB = DomainManager.Character.GetRelatedCharIds(charIdB, 32768);
					if (characterSet.Contains(charIdB) && !pairs.Contains((charId4, charIdB)) && characterSetB.Contains(charId4) && !pairs.Contains((charIdB, charId4)))
					{
						pairs.Add((charId4, charIdB));
						pairs.Add((charIdB, charId4));
						count++;
						if (count >= limit)
						{
							break;
						}
					}
				}
				if (count >= limit)
				{
					break;
				}
			}
		}
		if (count < limit)
		{
			foreach (int charId5 in availableCharIds)
			{
				HashSet<int> characterSet2 = DomainManager.Character.GetRelatedCharIds(charId5, 32768);
				foreach (int charIdB2 in availableCharIds)
				{
					if (characterSet2.Contains(charIdB2) && !pairs.Contains((charId5, charIdB2)))
					{
						pairs.Add((charId5, charIdB2));
						count++;
						if (count >= limit)
						{
							break;
						}
					}
				}
				if (count >= limit)
				{
					break;
				}
			}
		}
		foreach (var item in pairs)
		{
			int charIdA = item.Item1;
			int charIdB3 = item.Item2;
			GameData.Domains.Character.Character characterA = DomainManager.Character.GetElement_Objects(charIdA);
			GameData.Domains.Character.Character characterB = DomainManager.Character.GetElement_Objects(charIdB3);
			ProfessionFormulaItem formulaItem = ProfessionFormula.Instance[68];
			DomainManager.Extra.ChangeProfessionSeniority(context, 10, formulaItem.Calculate(characterA.GetInteractionGrade(targetIsTaiwu: true) + characterB.GetInteractionGrade(targetIsTaiwu: true)));
			lifeRecordCollection.AddForgiveForCivilianSkill(charIdA, currDate, taiwuCharId, location, charIdB3);
			DomainManager.Character.ChangeRelationType(context, charIdA, charIdB3, 32768, 0);
			characterA.ChangeHappiness(context, 20);
			characterA.RecordFameAction(context, 4, charIdB3, 1);
			if (charIdB3 == DomainManager.Taiwu.GetTaiwuCharId())
			{
				EventHelper.ChangeAlertnessOnProfessionCivilianSkill1(charIdB3);
			}
		}
		if (count > 0)
		{
			taiwu.RecordFameAction(context, 12, taiwuCharId, (short)count);
			lifeRecordCollection.AddCivilianSkillDissolveResentment(taiwuCharId, currDate, location);
			DomainManager.World.GetInstantNotificationCollection().AddQuenchHatred(pairs.Count);
			DomainManager.Map.SetBlockData(context, block);
		}
	}

	public static void CivilianSkill_MakeCharacterLeaveSect(DataContext context, GameData.Domains.Character.Character character)
	{
		OrganizationInfo oriOrgInfo = character.GetOrganizationInfo();
		Tester.Assert(OrganizationDomain.IsSect(oriOrgInfo.OrgTemplateId), "$OrganizationDomain.IsSect({oriOrgInfo.OrgTemplateId})");
		Settlement oriSettlement = DomainManager.Organization.GetSettlement(oriOrgInfo.SettlementId);
		short oriAreaId = oriSettlement.GetLocation().AreaId;
		sbyte stateId = DomainManager.Map.GetStateIdByAreaId(oriAreaId);
		sbyte retireGrade = Config.Organization.Instance[oriOrgInfo.OrgTemplateId].RetireGrade;
		List<short> settlementIds = new List<short>();
		DomainManager.Map.GetStateSettlementIds(stateId, settlementIds, containsMainCity: true);
		settlementIds.Remove(DomainManager.Taiwu.GetTaiwuVillageSettlementId());
		if (retireGrade == 1)
		{
			settlementIds.RemoveAll((short settlementId2) => DomainManager.Organization.GetSettlement(settlementId2).GetOrgTemplateId() == 36);
		}
		short settlementId = settlementIds.GetRandom(context.Random);
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		OrganizationInfo orgInfo = new OrganizationInfo(settlement.GetOrgTemplateId(), retireGrade, principal: true, settlementId);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		int currDate = DomainManager.World.GetCurrDate();
		Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		lifeRecordCollection.AddPersuadeWithdrawlFromOrganization(taiwuCharId, currDate, character.GetId(), location);
		DomainManager.Organization.ChangeOrganization(context, character, orgInfo);
		DomainManager.Merchant.RemoveMerchantData(context, character.GetId());
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		DomainManager.World.GetInstantNotificationCollection().AddProfessionCivilianSkill2(character.GetId(), taiwuId, orgInfo.OrgTemplateId, orgInfo.Grade, orgPrincipal: true, character.GetGender());
		if (location.IsValid())
		{
			MapBlockData block = DomainManager.Map.GetBlock(location);
			DomainManager.Map.SetBlockData(context, block);
		}
		int limit = ProfessionData.GetSeniorityCivilianAddHatredLimit(DomainManager.Extra.GetProfessionData(10).Seniority);
		int count = 0;
		OrgMemberCollection members = oriSettlement.GetMembers();
		for (sbyte grade = 8; grade >= 0; grade--)
		{
			foreach (int orgMemberId in members.GetMembers(grade))
			{
				DomainManager.Character.TryAddAndApplyOneWayRelation(context, orgMemberId, character.GetId(), 32768);
				EventHelper.ChangeAlertnessOnProfessionCivilianSkill2(orgMemberId);
				count++;
				if (count >= limit)
				{
					break;
				}
			}
			if (count >= limit)
			{
				break;
			}
		}
	}

	private static bool CheckSpecialCondition_CivilianSkill(ProfessionData professionData, int index)
	{
		if (index == 1)
		{
			return CheckSpecialCondition_CivilianSkill_1(professionData);
		}
		return true;
	}

	private static bool CheckSpecialCondition_CivilianSkill_1(ProfessionData professionData)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		Location location = taiwu.GetLocation();
		if (!location.IsValid())
		{
			return false;
		}
		MapBlockData block = DomainManager.Map.GetBlock(location);
		List<int> availableCharIds = new List<int>();
		if (block.CharacterSet != null && block.CharacterSet.Count != 0)
		{
			foreach (int charId in block.CharacterSet)
			{
				availableCharIds.Add(charId);
			}
		}
		foreach (int charId2 in DomainManager.Taiwu.GetGroupCharIds().GetCollection())
		{
			if (charId2 != taiwuCharId)
			{
				availableCharIds.Add(charId2);
			}
		}
		foreach (int charId3 in availableCharIds)
		{
			HashSet<int> characterSet = DomainManager.Character.GetRelatedCharIds(charId3, 32768);
			if (characterSet.Contains(taiwuCharId))
			{
				return true;
			}
			foreach (int charIdB in availableCharIds)
			{
				if (characterSet.Contains(charIdB))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static void ExecuteOnClick_CraftSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		if (index == 2)
		{
			ExecuteOnClick_CraftSkill_2(context, professionData, ref arg);
			return;
		}
		throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
	}

	public static void ExecuteOnClick_CraftSkill_2(DataContext context, ProfessionData professionData, ref ProfessionSkillArg arg)
	{
		ItemKey weaponKey = arg.WeaponKey;
		List<sbyte> trickList = arg.TrickList;
		ItemKey toolKey = arg.ToolKey;
		ItemSourceType toolSourceType = arg.ToolSourceType;
		Dictionary<ItemSourceType, Inventory> costMaterials = arg.CostMaterials;
		GameData.Domains.Item.Weapon weapon = DomainManager.Item.GetElement_Weapons(weaponKey.Id);
		List<sbyte> oldTricks = weapon.GetTricks();
		CraftSkillsData craftSkillsData = professionData.SkillsData as CraftSkillsData;
		if (craftSkillsData == null)
		{
			craftSkillsData = (CraftSkillsData)(professionData.SkillsData = new CraftSkillsData());
		}
		CraftSkillsData craftSkillsData2 = craftSkillsData;
		if (craftSkillsData2.WeaponOriginTrickDict == null)
		{
			craftSkillsData2.WeaponOriginTrickDict = new Dictionary<ItemKey, GameData.Utilities.ShortList>();
		}
		if (!craftSkillsData.WeaponOriginTrickDict.TryGetValue(weaponKey, out var originTricks))
		{
			originTricks = GameData.Utilities.ShortList.Create();
			foreach (sbyte t in oldTricks)
			{
				originTricks.Items.Add(t);
			}
			craftSkillsData.WeaponOriginTrickDict[weaponKey] = originTricks;
			DomainManager.Extra.SetProfessionData(context, professionData);
		}
		weapon.SetTricks(trickList, context);
		sbyte grade = ItemTemplateHelper.GetGrade(weaponKey.ItemType, weaponKey.TemplateId);
		int charId = DomainManager.Taiwu.GetTaiwuCharId();
		if (toolKey.IsValid() && toolKey.TemplateId != 54)
		{
			CraftToolItem toolConfig = Config.CraftTool.Instance[toolKey.TemplateId];
			short cost = toolConfig.DurabilityCost[grade];
			DomainManager.Item.ReduceToolDurability(context, charId, toolKey, cost, (sbyte)toolSourceType);
		}
		if (costMaterials != null)
		{
			foreach (var (sourceType, inventory2) in costMaterials)
			{
				foreach (var (itemKey2, count) in inventory2.Items)
				{
					DomainManager.Taiwu.RemoveItem(context, itemKey2, count, sourceType, deleteItem: true);
				}
			}
		}
		WeaponItem weaponConfig = Config.Weapon.Instance[weaponKey.TemplateId];
		int resourceAmount = professionData.GetSeniorityChangeWeaponTrickCostResource(arg.ChangeCountToLast, weaponConfig.Grade);
		DomainManager.Building.ConsumeResource(context, weaponConfig.ResourceType, resourceAmount);
		ItemDisplayData itemData = DomainManager.Item.GetItemDisplayData(weaponKey, DomainManager.Taiwu.GetTaiwuCharId());
		List<ItemDisplayData> itemDisplayDataList = new List<ItemDisplayData> { itemData };
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Item, itemDisplayDataList, arg2: false);
	}

	public static void OpenSetWeaponTrick()
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenChangeWeaponTrick);
	}

	public static int GetAddSeniority_CraftSkill_0(sbyte itemType, short templateId)
	{
		int value = ItemTemplateHelper.GetBaseValue(itemType, templateId);
		return value / 100;
	}

	public static int GetRefineBonus_CraftSkill_2(int refineBonus, int equippedCharId)
	{
		if ((!DomainManager.Character.TryGetElement_Objects(equippedCharId, out var _) || equippedCharId == DomainManager.Taiwu.GetTaiwuCharId()) && DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(11))
		{
			refineBonus = refineBonus * 150 / 100;
		}
		return refineBonus;
	}

	private static void ExecuteOnClick_DoctorSkill(DataContext context, ProfessionData professionData, int skillIndex, ref ProfessionSkillArg arg)
	{
		if (skillIndex == 1)
		{
			ExecuteOnClick_DoctorSkill_1(context, professionData);
			return;
		}
		throw new Exception(professionData.GetSkillConfig(skillIndex).Name + " is not an executable skill.");
	}

	private static void ExecuteOnClick_DoctorSkill_1(DataContext context, ProfessionData professionData)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		short medicineAttainment = taiwu.GetLifeSkillAttainment(8);
		short toxicologyAttainment = taiwu.GetLifeSkillAttainment(9);
		short disorderOfQiDelta = (short)(-Math.Clamp((medicineAttainment + toxicologyAttainment) * 5, DisorderLevelOfQi.MinValue, DisorderLevelOfQi.MaxValue));
		Location location = taiwu.GetLocation();
		MapBlockData settlementBlock = DomainManager.Map.GetBelongSettlementBlock(location);
		int treatCount = 0;
		int maxGrade = professionData.GetSeniorityOrgGrade();
		List<short> blockIds = new List<short>();
		DomainManager.Map.GetSettlementBlocks(settlementBlock.AreaId, settlementBlock.BlockId, blockIds);
		foreach (short blockId in blockIds)
		{
			MapBlockData block = DomainManager.Map.GetBlock(settlementBlock.AreaId, blockId);
			if (block.CharacterSet == null)
			{
				continue;
			}
			foreach (int charId in block.CharacterSet)
			{
				GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(charId);
				if (character.GetInteractionGrade(targetIsTaiwu: true) <= maxGrade && character.GetLegendaryBookOwnerState() < 2 && TryTreatCharacter(character))
				{
					treatCount++;
				}
			}
		}
		HashSet<int> taiwuGroup = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		foreach (int charId2 in taiwuGroup)
		{
			if (charId2 != taiwu.GetId())
			{
				GameData.Domains.Character.Character character2 = DomainManager.Character.GetElement_Objects(charId2);
				if (TryTreatCharacter(character2))
				{
					treatCount++;
				}
			}
		}
		taiwu.RecordFameAction(context, 24, -1, 1);
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		lifeRecordCollection.AddFreeMedicalConsultation(taiwu.GetId(), currDate, location);
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		DomainManager.World.GetInstantNotificationCollection().AddProfessionDoctorSkill1(taiwuId, location, treatCount);
		bool TryTreatCharacter(GameData.Domains.Character.Character character3)
		{
			Injuries injuries = character3.GetInjuries();
			PoisonInts poisons = character3.GetPoisoned();
			short disorderOfQi = character3.GetDisorderOfQi();
			if (disorderOfQi <= 0 && !poisons.IsNonZero() && injuries.GetSum() <= 0)
			{
				return false;
			}
			Injuries healedInjuries = DomainManager.Combat.HealInjury(character3.GetId(), taiwu);
			character3.SetInjuries(healedInjuries, context);
			PoisonInts result = DomainManager.Combat.HealPoison(character3.GetId(), taiwu);
			character3.SetPoisoned(ref result, context);
			character3.ChangeDisorderOfQi(context, disorderOfQiDelta);
			int spiritualDebt = (character3.GetInteractionGrade(targetIsTaiwu: true) + 1) * (10 + 10 * professionData.Seniority / 3000000);
			DomainManager.Extra.ChangeAreaSpiritualDebt(context, location.AreaId, spiritualDebt);
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, character3, taiwu, 6000);
			EventHelper.ChangeAlertnessOnProfessionDoctorSkill1(character3.GetId());
			return true;
		}
	}

	private static bool CheckSpecialCondition_DoctorSkill(ProfessionData professionData, int index)
	{
		if (index == 1)
		{
			return CheckSpecialCondition_DoctorSkill_1(professionData);
		}
		return true;
	}

	private static bool CheckSpecialCondition_DoctorSkill_1(ProfessionData professionData)
	{
		sbyte settlementType = professionData.GetSeniorityDoctorMaxSettlementType();
		return CheckSettlementBlockTypeValid(settlementType);
	}

	private static void ExecuteOnClick_DukeSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		switch (index)
		{
		case 2:
			break;
		case 3:
			ExecuteOnClick_DukeSkill_3(context, professionData, ref arg);
			break;
		default:
			throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
		}
	}

	private static void ExecuteOnClick_DukeSkill_3(DataContext context, ProfessionData professionData, ref ProfessionSkillArg arg)
	{
		GetCricketBlocks(context, professionData);
	}

	private static void GetCricketBlocks(DataContext context, ProfessionData professionData)
	{
		TaiwuDomain taiwuDomain = DomainManager.Taiwu;
		if (!DomainManager.Character.TryGetElement_Objects(taiwuDomain.GetTaiwuCharId(), out var taiwuChar))
		{
			return;
		}
		List<MapBlockData> blocks = new List<MapBlockData>();
		Location location = taiwuChar.GetLocation();
		MapDomain mapDomain = DomainManager.Map;
		mapDomain.GetNeighborBlocks(location.AreaId, location.BlockId, blocks, 3);
		List<MapBlockData> effectBlocks = new List<MapBlockData>();
		if (blocks.Count > 0)
		{
			CollectionUtils.Shuffle(context.Random, blocks);
			blocks.RemoveRange(0, blocks.Count / 2);
			foreach (MapBlockData block in blocks)
			{
				Location blockLocation = block.GetLocation();
				if (!mapDomain.LocationHasCricket(context, blockLocation))
				{
					effectBlocks.Add(block);
				}
			}
			taiwuDomain.SetCricketLuckPoint(taiwuDomain.GetCricketLuckPoint() + 300, context);
		}
		ProfessionSkillArg professionSkillArg = new ProfessionSkillArg
		{
			ProfessionId = 17,
			SkillId = 71,
			IsSuccess = true,
			EffectBlocks = effectBlocks.Select((MapBlockData mapBlockData) => mapBlockData.BlockId).ToList()
		};
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.ConfirmSkillExecuteAndPlayAnim, professionSkillArg, arg2: false);
	}

	private static bool CheckSpecialCondition_DukeSkill(ProfessionData professionData, int skillIndex)
	{
		if (skillIndex == 3)
		{
			return CheckSpecialCondition_DukeSkill_3(professionData);
		}
		return true;
	}

	private static bool CheckSpecialCondition_DukeSkill_3(ProfessionData professionData)
	{
		TaiwuDomain taiwuDomain = DomainManager.Taiwu;
		if (DomainManager.Character.TryGetElement_Objects(taiwuDomain.GetTaiwuCharId(), out var taiwuChar))
		{
			return taiwuChar.GetLocation().IsValid();
		}
		return false;
	}

	public static bool DukeSkill_CheckCharacterHasTitle(int charId, ProfessionData professionData)
	{
		Tester.Assert(professionData.SkillsData is DukeSkillsData);
		DukeSkillsData duke = (DukeSkillsData)professionData.SkillsData;
		return duke.CharacterHasTitle(charId);
	}

	public static short DukeSkill_GetTitleFromOwner(int charId, ProfessionData professionData)
	{
		Tester.Assert(professionData.SkillsData is DukeSkillsData);
		DukeSkillsData duke = (DukeSkillsData)professionData.SkillsData;
		return duke.GetTitleFromOwner(charId);
	}

	public static int DukeSkill_GetOwnerOfTitle(short templateId, ProfessionData professionData)
	{
		Tester.Assert(professionData.SkillsData is DukeSkillsData);
		DukeSkillsData duke = (DukeSkillsData)professionData.SkillsData;
		return duke.GetOwnerOfTitle(templateId);
	}

	public static void DukeSkill_AddCharacterTitle(DataContext context, ProfessionData professionData, int charId, short templateId)
	{
		Tester.Assert(professionData.SkillsData is DukeSkillsData);
		DukeSkillsData duke = (DukeSkillsData)professionData.SkillsData;
		duke.OfflineAssignTitleToCharacter(context.Random, templateId, charId);
		DomainManager.Extra.SetProfessionData(context, professionData);
		DomainManager.Character.AddCharacterProfessionExtraTitle(context, charId, templateId);
		DomainManager.Organization.TryRemoveBounty(context, charId);
		EventHelper.ChangeAlertnessOnProfessionDukeSkill1Add(charId);
	}

	public static bool DukeSkill_RemoveCharacterTitle(DataContext context, ProfessionData professionData, int charId, bool isTaiwuOperation)
	{
		Tester.Assert(professionData.SkillsData is DukeSkillsData);
		DukeSkillsData duke = (DukeSkillsData)professionData.SkillsData;
		short templateId = duke.OfflineRemoveTitleFromCharacter(charId);
		if (templateId == -1)
		{
			return false;
		}
		DomainManager.World.GetInstantNotifications().AddResignationPosition(charId);
		DomainManager.Extra.SetProfessionData(context, professionData);
		DomainManager.Character.RemoveCharacterProfessionExtraTitle(context, charId, templateId);
		if (isTaiwuOperation)
		{
			EventHelper.ChangeAlertnessOnProfessionDukeSkill1Remove(charId);
		}
		return true;
	}

	public static void DukeSkill_ClearAllTitle(DataContext context, ProfessionData professionData)
	{
		Tester.Assert(professionData.SkillsData is DukeSkillsData);
		DukeSkillsData duke = (DukeSkillsData)professionData.SkillsData;
		foreach (var dso in duke.GetAllOwners())
		{
			DomainManager.Character.RemoveCharacterProfessionExtraTitle(context, dso.CharacterId, dso.TemplateId);
		}
		duke.OfflineClearAllTitles();
		DomainManager.Extra.SetProfessionData(context, professionData);
	}

	public static ItemKey DukeSkill_GetNewCricket(DataContext context, int charId)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(17);
		DukeSkillsData dukeSkillData = professionData.GetSkillsData<DukeSkillsData>();
		ItemKey itemKey = OfflineCreateCricketAndModifyLuckPoint(context, dukeSkillData, charId);
		DomainManager.Extra.SetProfessionData(context, professionData);
		DomainManager.Taiwu.AddItem(context, itemKey, 1, ItemSourceType.Inventory);
		GameData.Domains.Item.Cricket cricket = DomainManager.Item.GetElement_Crickets(itemKey.Id);
		DomainManager.Item.AddCatchCricketProfessionSeniority(context, cricket);
		return itemKey;
	}

	private static ItemKey OfflineCreateCricketAndModifyLuckPoint(DataContext context, DukeSkillsData data, int charId)
	{
		short title = data.GetTitleFromOwner(charId);
		if (title < 0)
		{
			return ItemKey.Invalid;
		}
		if (!DomainManager.Character.TryGetElement_Objects(charId, out var character))
		{
			return ItemKey.Invalid;
		}
		if (!character.GetValidLocation().IsValid())
		{
			return ItemKey.Invalid;
		}
		int formulaId = 113;
		int count = ProfessionFormula.Instance[formulaId].Calculate();
		int luckPoint = data.GetDukeLuckPointByTitle(title);
		ItemKey itemKey = DomainManager.Item.CreateCricketByLuckPoint(context, ref luckPoint, count);
		sbyte stateId = character.GetValidOrganizationStateId();
		GameData.Domains.Item.Cricket cricket = DomainManager.Item.GetElement_Crickets(itemKey.Id);
		cricket.SetOriginState(stateId, context);
		data.OfflineSetDukeLuckPointByTitle(title, luckPoint);
		return itemKey;
	}

	internal static bool DukeSkill_CheckCharacterHasTitle(int charId)
	{
		if (!DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(69))
		{
			return false;
		}
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(17);
		return DukeSkill_CheckCharacterHasTitle(charId, professionData);
	}

	internal static void DukeSkill_RemoveCharacterTitle(DataContext context, int charId, bool isTaiwuOperation)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(17);
		DukeSkill_RemoveCharacterTitle(context, professionData, charId, isTaiwuOperation);
	}

	internal static void DukeSkill_ClearAllTitle(DataContext context)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(17);
		DukeSkill_ClearAllTitle(context, professionData);
	}

	private static void ExecuteOnClick_HunterSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		switch (index)
		{
		case 0:
			ExecuteOnClick_HunterSkill_0(context, professionData);
			break;
		case 2:
			ExecuteOnClick_HunterSkill_2(context, professionData);
			break;
		default:
			throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
		}
	}

	private static void HunterSkill_AdvanceMonth(DataContext context)
	{
		DomainManager.Extra.RecoverHunterCarrierAttackCount(context);
	}

	public static CarrierItem GetCarrierByAnimal(short animalCharTemplateId)
	{
		sbyte animalId = GameData.Domains.Combat.SharedConstValue.CharId2AnimalId[animalCharTemplateId];
		AnimalItem animalItem = Config.Animal.Instance[animalId];
		return Config.Carrier.Instance[animalItem.CarrierId];
	}

	private static void ExecuteOnClick_HunterSkill_2(DataContext context, ProfessionData professionData)
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		Location centerLocation = DomainManager.Extra.GetAnimalGenerateCenterLocationByHunterSkill(context, taiwuLocation.AreaId);
		if (!centerLocation.IsValid())
		{
			DomainManager.World.GetInstantNotificationCollection().AddProfessionHunterSkill0None();
			return;
		}
		sbyte animalCount = professionData.GetSeniorityAnimalCount();
		int prob = GlobalConfig.Instance.HunterSkill2_OddFormulaFactorA + GlobalConfig.Instance.HunterSkill2_OddFormulaFactorB * professionData.GetSeniorityPercent() / 100;
		List<CharacterItem> animalConfigList = new List<CharacterItem>(animalCount);
		for (int i = 0; i < animalCount; i++)
		{
			byte[] animalConsummateLevelList = GlobalConfig.Instance.HunterSkill2_AnimalCountIndexToAnimalConsummateLevelList[i];
			byte animalConsummateLevel = animalConsummateLevelList[0];
			for (int j = animalConsummateLevelList.Length - 1; j >= 1; j--)
			{
				if (context.Random.CheckPercentProb(prob))
				{
					animalConsummateLevel = animalConsummateLevelList[j];
				}
			}
			CharacterItem[] templateIds = (from templateId in AnimalCharacterTemplateIds
				select Config.Character.Instance.GetItem(templateId) into characterItem
				where characterItem.ConsummateLevel <= animalConsummateLevel
				orderby characterItem.ConsummateLevel descending
				select characterItem).ToArray();
			CharacterItem animalConfig = templateIds[0];
			if (templateIds.Length != 0)
			{
				for (int k = 1; k < templateIds.Length; k++)
				{
					CharacterItem template = templateIds[k];
					if (template.ConsummateLevel == animalConfig.ConsummateLevel && template.TemplateId >= 237 && template.TemplateId > animalConfig.TemplateId && context.Random.CheckPercentProb(33))
					{
						animalConfig = template;
						break;
					}
				}
			}
			animalConfigList.Add(animalConfig);
		}
		List<Location> locationList = ObjectPool<List<Location>>.Instance.Get();
		DomainManager.Extra.GetAnimalGenerateLocationListByCenterLocation(context, centerLocation, animalCount, ref locationList);
		for (int i2 = 0; i2 < animalConfigList.Count; i2++)
		{
			if (i2 == 0)
			{
				DomainManager.Extra.AnimalGenerateInAreaByHunterSkill(context, centerLocation, animalConfigList[i2].TemplateId);
			}
			else if (i2 < locationList.Count)
			{
				DomainManager.Extra.AnimalGenerateInAreaByHunterSkill(context, locationList[i2], animalConfigList[i2].TemplateId);
			}
			else
			{
				ExtraDomain extra = DomainManager.Extra;
				List<Location> list = locationList;
				extra.AnimalGenerateInAreaByHunterSkill(context, list[list.Count - 1], animalConfigList[i2].TemplateId);
			}
			CharacterItem characterConfig = Config.Character.Instance.GetItem(animalConfigList[i2].TemplateId);
			DomainManager.World.GetInstantNotificationCollection().AddProfessionHunterSkill0(characterConfig.OrganizationInfo.OrgTemplateId, characterConfig.OrganizationInfo.Grade, orgPrincipal: true, characterConfig.Gender);
		}
	}

	[Obsolete]
	private static void ExecuteOnClick_HunterSkill_0(DataContext context, ProfessionData professionData)
	{
	}

	public static GameData.Domains.Character.Character HunterSkill_ItemToAnimalCharacter(DataContext context, ItemKey animalItemKey, string displayName)
	{
		short animalCharTemplateId = Config.Carrier.Instance[animalItemKey.TemplateId].CharacterIdInCombat;
		if (animalCharTemplateId < 0)
		{
			throw new Exception($"Invalid carrier to become animal character {animalItemKey}.");
		}
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(1);
		HunterSkillsData skillsData = professionData.GetSkillsData<HunterSkillsData>();
		HunterSkillsData hunterSkillsData = skillsData;
		if (hunterSkillsData.AnimalItemKeyToGender == null)
		{
			hunterSkillsData.AnimalItemKeyToGender = new Dictionary<ItemKey, sbyte>();
		}
		hunterSkillsData = skillsData;
		if (hunterSkillsData.AnimalCharIdToItemKey == null)
		{
			hunterSkillsData.AnimalCharIdToItemKey = new Dictionary<int, ItemKey>();
		}
		hunterSkillsData = skillsData;
		if (hunterSkillsData.AnimalCharIdToAttraction == null)
		{
			hunterSkillsData.AnimalCharIdToAttraction = new Dictionary<ItemKey, short>();
		}
		sbyte gender = Config.Character.Instance[animalCharTemplateId].Gender;
		bool needSaveGender = false;
		if (gender == -1)
		{
			if (skillsData.AnimalItemKeyToGender.TryGetValue(animalItemKey, out var savedGender))
			{
				gender = savedGender;
			}
			else
			{
				gender = (sbyte)context.Random.Next(2);
				needSaveGender = true;
			}
		}
		FixedEnemyCreationInfo fixedEnemyCreationInfo = new FixedEnemyCreationInfo();
		fixedEnemyCreationInfo.Gender = gender;
		FixedEnemyCreationInfo creationInfo = fixedEnemyCreationInfo;
		GameData.Domains.Character.Character character = DomainManager.Character.CreateFixedEnemy(context, animalCharTemplateId, isTemporary: false, ref creationInfo);
		FullName fullName = character.GetFullName();
		fullName.Type = 8;
		character.SetFullName(fullName, context);
		int charId = character.GetId();
		if (!skillsData.AnimalCharIdToAttraction.TryGetValue(animalItemKey, out var _))
		{
			short attraction = (short)context.Random.Next(0, 901);
			skillsData.AnimalCharIdToAttraction.Add(animalItemKey, attraction);
		}
		DomainManager.Character.CompleteCreatingCharacter(charId);
		DomainManager.Extra.AssignCharacterCustomDisplayName(context, charId, displayName);
		DomainManager.Taiwu.JoinGroup(context, charId);
		skillsData.AnimalCharIdToItemKey.Add(charId, animalItemKey);
		if (needSaveGender)
		{
			skillsData.AnimalItemKeyToGender.Add(animalItemKey, gender);
		}
		DomainManager.Extra.SetProfessionData(context, professionData);
		DomainManager.Taiwu.RemoveItem(context, animalItemKey, 1, 1, deleteItem: false);
		DomainManager.Item.SetOwner(animalItemKey, ItemOwnerType.SpecialGroupMember, DomainManager.Taiwu.GetTaiwuCharId());
		EventHelper.ShowGetItemPageForCharacters(new List<int> { charId }, isVillager: false);
		DomainManager.World.GetInstantNotificationCollection().AddBeastUpgrade(animalItemKey.ItemType, animalItemKey.TemplateId);
		return character;
	}

	public static ItemKey HunterSkill_AnimalCharacterToItem(DataContext context, GameData.Domains.Character.Character character)
	{
		int charId = character.GetId();
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(1);
		HunterSkillsData skillsData = professionData.GetSkillsData<HunterSkillsData>();
		ItemKey itemKey = skillsData.AnimalCharIdToItemKey[charId];
		Dictionary<ItemKey, int> items = character.GetInventory().Items;
		List<(ItemKey, int)> toRemoveItems = new List<(ItemKey, int)>();
		foreach (KeyValuePair<ItemKey, int> item in items)
		{
			toRemoveItems.Add((item.Key, item.Value));
		}
		int leader = character.GetLeaderId();
		GameData.Domains.Character.Character leaderChar = DomainManager.Character.GetElement_Objects(leader);
		Location location = leaderChar.GetLocation();
		MapBlockData blockData = DomainManager.Map.GetBlockData(location.AreaId, location.BlockId);
		foreach (var (item2, count) in toRemoveItems)
		{
			character.RemoveInventoryItem(context, item2, count, deleteItem: false);
			DomainManager.Map.AddBlockItem(context, blockData, item2, count);
		}
		DomainManager.Character.LeaveGroup(context, character);
		DomainManager.World.GetInstantNotificationCollection().AddBeastDowngrade(itemKey.ItemType, itemKey.TemplateId);
		DomainManager.Character.RemoveNonIntelligentCharacter(context, character);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		taiwuChar.AddInventoryItem(context, itemKey, 1);
		return itemKey;
	}

	private static bool CheckSpecialCondition_HunterSkill(ProfessionData professionData, int skillIndex)
	{
		HashSet<(Location, int)> result;
		return skillIndex switch
		{
			1 => DomainManager.Extra.TryGetAnimalAttackInRange(DomainManager.Taiwu.GetTaiwu().GetLocation(), 2, isTaiwuVictim: true, out result), 
			2 => DomainManager.Extra.CheckSpecialCondition_HunterSkill2(DataContextManager.GetCurrentThreadDataContext()), 
			3 => CheckGroupCountForConvertToAnimalCharacter() && CheckItem(), 
			_ => true, 
		};
		static bool CheckItem()
		{
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			List<ItemDisplayData> inventoryItems = DomainManager.Character.GetAllInventoryItems(taiwu.GetId());
			return inventoryItems.Select((ItemDisplayData d) => d.Key).Any(IsItemCanConvertToAnimalCharacter);
		}
	}

	public static bool CheckGroupCountForConvertToAnimalCharacter()
	{
		return true;
	}

	public static bool IsItemCanConvertToAnimalCharacter(ItemKey itemKey)
	{
		short subType = ItemTemplateHelper.GetItemSubType(itemKey.ItemType, itemKey.TemplateId);
		return subType == 402;
	}

	internal static int CalcLiteratiSkill2AuthorityCost(SecretInformationItem config, int holderCount)
	{
		return 5000 * config.SortValue * (100 - holderCount * 50 / config.MaxPersonAmount) / 100;
	}

	public static void LiteratiSkill_BroadcastModifiedSecretInformation(DataContext context, int secretInformationId)
	{
		InformationDomain informationDomain = DomainManager.Information;
		SecretInformationItem config = informationDomain.CalcSecretInformationConfig((SecretInformationId)secretInformationId);
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		taiwu.ChangeResource(context, 7, -CalcLiteratiSkill2AuthorityCost(config, informationDomain.CalcSecretInformationKnownCharacterCount((SecretInformationId)secretInformationId)));
		informationDomain.MakeSecretBroadcast(context, (SecretInformationId)secretInformationId, DomainManager.Taiwu.GetTaiwuCharId());
		DomainManager.World.GetInstantNotificationCollection().AddDisseminateSecretInformation(config.TemplateId, secretInformationId);
	}

	public static void LiteratiSkill_AreaBroadcastNormalInformation(DataContext context, NormalInformation normalInformation)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location taiwuLocation = taiwu.GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return;
		}
		int count = 0;
		Span<MapBlockData> areaBlocks = DomainManager.Map.GetAreaBlocks(taiwuLocation.AreaId);
		for (int i = 0; i < areaBlocks.Length; i++)
		{
			MapBlockData block = areaBlocks[i];
			HashSet<int> blockTargets = block.CharacterSet;
			if (blockTargets == null)
			{
				continue;
			}
			EventArgBox argBox = new EventArgBox();
			InformationItem config = Config.Information.Instance[normalInformation.TemplateId];
			foreach (int targetCharId in blockTargets)
			{
				argBox.Clear();
				if (DomainManager.Character.TryGetElement_Objects(targetCharId, out var targetChar))
				{
					sbyte useResultType = EventHelper.GetNormalInformationUseResultType(targetCharId, normalInformation);
					int rate = config.EffectRate[useResultType];
					EventHelper.ChangeFavorabilityOptionalShareInformation(targetChar, taiwu, EventHelper.ClampFavorabilityChangeValue(EventHelper.GetTaiwuFavorabilityHotChangeValue() * rate / 100 * 150 / 100));
					InformationInfoItem info = InformationInfo.Instance.GetItem(config.InfoIds[normalInformation.Level]);
					EventHelper.ChangeAlertnessOnProfessionLiteratiSkill3(targetCharId, normalInformation.Level, info.TemplateId);
				}
				EventHelper.ApplyNormalInformationWithEffectRate(targetCharId, argBox, normalInformation, string.Empty, string.Empty, string.Empty, 150, canChangeAlertness: false);
				count++;
			}
		}
		DomainManager.World.GetInstantNotificationCollection().AddDisseminateInformation(taiwuLocation, count);
	}

	private static bool CheckLiteratiSkillNormalInformationUsable(NormalInformation normalInformation)
	{
		InformationItem config = Config.Information.Instance.GetItem(normalInformation.TemplateId);
		InformationInfoItem info = InformationInfo.Instance.GetItem(config.InfoIds[normalInformation.Level]);
		sbyte type = config.Type;
		bool flag = (uint)type <= 3u;
		bool flag2 = flag && config.IsGeneral;
		bool flag3 = flag2;
		if (flag3)
		{
			sbyte lifeSkillType = info.LifeSkillType;
			bool flag4 = (uint)(lifeSkillType - 12) <= 1u;
			flag3 = !flag4;
		}
		return flag3;
	}

	private static bool CheckSpecialCondition_LiteratiSkill(ProfessionData professionData, int index)
	{
		return index switch
		{
			2 => CheckSpecialCondition_LiteratiSkill_2(professionData), 
			3 => CheckSpecialCondition_LiteratiSkill_3(professionData), 
			_ => true, 
		};
	}

	private static bool CheckSpecialCondition_LiteratiSkill_2(ProfessionData professionData)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		SecretInformationDisplayPackage secrets = DomainManager.Information.GetSecretInformationDisplayPackageFromCharacter(taiwuCharId);
		List<SecretInformationDisplayData> secretInformationDisplayDataList = secrets.SecretInformationDisplayDataList;
		return secretInformationDisplayDataList != null && secretInformationDisplayDataList.Count > 0;
	}

	private static bool CheckSpecialCondition_LiteratiSkill_3(ProfessionData professionData)
	{
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		IList<NormalInformation> infoList = DomainManager.Information.GetCharacterNormalInformation(taiwuCharId).GetList() ?? new List<NormalInformation>();
		return infoList.Any(CheckLiteratiSkillNormalInformationUsable);
	}

	public static void MartialArtistSkill_MakeAreaLearnCombatSkill(DataContext context, ProfessionData professionData, sbyte combatSkillType)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwu.GetLocation();
		if (!location.IsValid())
		{
			return;
		}
		Span<MapBlockData> blocks = DomainManager.Map.GetAreaBlocks(location.AreaId);
		List<short> selectableSkillIds = new List<short>();
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int taiwuCharId = taiwu.GetId();
		int currDate = DomainManager.World.GetCurrDate();
		lifeRecordCollection.AddCombatSkillModel(taiwuCharId, currDate, location, combatSkillType);
		int charCount = 0;
		Span<MapBlockData> span = blocks;
		for (int i = 0; i < span.Length; i++)
		{
			MapBlockData block = span[i];
			if (block.CharacterSet == null)
			{
				continue;
			}
			foreach (int charId in block.CharacterSet)
			{
				if (TryLearnCombatSkill(charId))
				{
					charCount++;
				}
			}
		}
		HashSet<int> taiwuGroupCharIds = DomainManager.Taiwu.GetGroupCharIds().GetCollection();
		foreach (int charId2 in taiwuGroupCharIds)
		{
			if (charId2 != taiwuCharId && TryLearnCombatSkill(charId2))
			{
				charCount++;
			}
		}
		int authorityGain = 1000 + charCount * 100;
		taiwu.ChangeResource(context, 7, authorityGain);
		InstantNotificationCollection instantNotifications = DomainManager.World.GetInstantNotificationCollection();
		if (authorityGain > 0)
		{
			instantNotifications.AddResourceIncreased(taiwuCharId, 7, authorityGain);
		}
		unsafe bool TryLearnCombatSkill(int num)
		{
			GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(num);
			if (character.GetAgeGroup() != 2)
			{
				return false;
			}
			Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> learnedCombatSkills = DomainManager.CombatSkill.GetCharCombatSkills(num);
			sbyte grade = 8;
			selectableSkillIds.Clear();
			foreach (CombatSkillItem combatSkillCfg in (IEnumerable<CombatSkillItem>)Config.CombatSkill.Instance)
			{
				if (combatSkillType == combatSkillCfg.Type && combatSkillCfg.SectId != 0 && combatSkillCfg.Grade <= grade && combatSkillCfg.BookId >= 0 && !learnedCombatSkills.ContainsKey(combatSkillCfg.TemplateId))
				{
					if (combatSkillCfg.Grade < grade)
					{
						grade = combatSkillCfg.Grade;
						selectableSkillIds.Clear();
					}
					selectableSkillIds.Add(combatSkillCfg.TemplateId);
				}
			}
			if (selectableSkillIds.Count == 0)
			{
				return false;
			}
			short selectedTemplateId = selectableSkillIds.GetRandom(context.Random);
			short bookTemplateId = Config.CombatSkill.Instance[selectedTemplateId].BookId;
			SkillBookItem bookCfg = Config.SkillBook.Instance[bookTemplateId];
			CombatSkillShorts combatSkillAttainments = character.GetCombatSkillAttainments();
			CombatSkillShorts combatSkillQualifications = character.GetCombatSkillQualifications();
			Personalities personalities = character.GetPersonalities();
			int successRate = GameData.Domains.Character.Character.GetTaughtNewSkillSuccessRate(bookCfg.Grade, combatSkillQualifications.Items[bookCfg.CombatSkillType], combatSkillAttainments.Items[bookCfg.CombatSkillType], personalities.Items[1]);
			if (!context.Random.CheckPercentProb(successRate))
			{
				return false;
			}
			ItemKey itemKey = DomainManager.Item.CreateSkillBook(context, bookTemplateId, -1, -1, -1, 50);
			character.AddInventoryItem(context, itemKey, 1);
			character.LearnNewCombatSkill(context, selectedTemplateId, 0);
			int favorChange = (grade + 1) * 1000;
			DomainManager.Character.ChangeFavorabilityOptionalRepeatedEvent(context, character, taiwu, favorChange);
			lifeRecordCollection.AddLearnCombatSkill(num, currDate, character.GetLocation(), selectedTemplateId);
			return true;
		}
	}

	private static bool CheckSpecialCondition_MartialArtistSkill(ProfessionData professionData, int index)
	{
		return index switch
		{
			1 => CheckSpecialCondition_MartialArtistSkill_1(professionData), 
			2 => CheckSpecialCondition_MartialArtistSkill_2(professionData), 
			_ => true, 
		};
	}

	private static bool CheckSpecialCondition_MartialArtistSkill_1(ProfessionData professionData)
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return false;
		}
		MapBlockData blockData = DomainManager.Map.GetBlock(taiwuLocation);
		if (!blockData.IsCityTown())
		{
			return false;
		}
		MapBlockData settlementBlock = DomainManager.Map.GetBelongSettlementBlock(taiwuLocation);
		Settlement settlement = DomainManager.Organization.GetSettlementByLocation(settlementBlock.GetLocation());
		return settlement.GetSafety() < settlement.GetMaxSafety();
	}

	private static bool CheckSpecialCondition_MartialArtistSkill_2(ProfessionData professionData)
	{
		Location taiwuLocation = DomainManager.Taiwu.GetTaiwu().GetLocation();
		if (!taiwuLocation.IsValid())
		{
			return false;
		}
		MapBlockData blockData = DomainManager.Map.GetBlock(taiwuLocation);
		if (!blockData.IsCityTown())
		{
			return false;
		}
		MapBlockData settlementBlock = DomainManager.Map.GetBelongSettlementBlock(taiwuLocation);
		Settlement settlement = DomainManager.Organization.GetSettlementByLocation(settlementBlock.GetLocation());
		return settlement.GetSafety() >= 25;
	}

	private static void ExecuteOnClick_MartialArtist(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		if (index == 3)
		{
			ExecuteOnClick_MartialArtist_3(context, professionData, ref arg);
			return;
		}
		throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
	}

	private static void ExecuteOnClick_MartialArtist_3(DataContext context, ProfessionData professionData, ref ProfessionSkillArg professionSkillArg)
	{
		if (professionSkillArg.EffectBlocks == null)
		{
			DomainManager.Extra.MartialArtistSkill3Execute(context, updateData: true);
		}
	}

	private static void MartialArtistSkill_AdvanceMonth(DataContext context)
	{
		DomainManager.Extra.MartialArtistSkill3Execute(context, updateData: false);
	}

	private static void ExecuteOnClick_SavageSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		switch (index)
		{
		case 1:
			ExecuteOnClick_SavageSkill_1(context, professionData);
			break;
		case 3:
			ExecuteOnClick_SavageSkill_3(context, professionData, ref arg);
			break;
		default:
			throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
		}
	}

	internal static IEnumerable<Location> GetSavageSkill_1_EffectRange(Location location)
	{
		if (location.IsValid())
		{
			yield return location;
			MapDomain mapDomain = DomainManager.Map;
			byte areaSize = mapDomain.GetAreaSize(location.AreaId);
			ByteCoordinate origin = ByteCoordinate.IndexToCoordinate(location.BlockId, areaSize);
			if (origin.X > 0)
			{
				yield return new Location(location.AreaId, ByteCoordinate.CoordinateToIndex(new ByteCoordinate((byte)(origin.X - 1), origin.Y), areaSize));
			}
			if (origin.Y > 0)
			{
				yield return new Location(location.AreaId, ByteCoordinate.CoordinateToIndex(new ByteCoordinate(origin.X, (byte)(origin.Y - 1)), areaSize));
			}
			if (origin.X < areaSize - 1)
			{
				yield return new Location(location.AreaId, ByteCoordinate.CoordinateToIndex(new ByteCoordinate((byte)(origin.X + 1), origin.Y), areaSize));
			}
			if (origin.Y < areaSize - 1)
			{
				yield return new Location(location.AreaId, ByteCoordinate.CoordinateToIndex(new ByteCoordinate(origin.X, (byte)(origin.Y + 1)), areaSize));
			}
		}
	}

	private unsafe static void ExecuteOnClick_SavageSkill_1(DataContext context, ProfessionData professionData)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		if (!taiwu.GetLocation().IsValid())
		{
			return;
		}
		MapDomain mapDomain = DomainManager.Map;
		int recoveryValue = 0;
		int recoveryFactor = professionData.GetSeniorityResourceRecoveryFactor();
		InstantNotificationCollection instantNotification = DomainManager.World.GetInstantNotificationCollection();
		instantNotification.AddBlockResourceRecovery(recoveryFactor);
		foreach (Location blockLocation in GetSavageSkill_1_EffectRange(taiwu.GetLocation()))
		{
			MapBlockData blockData = mapDomain.GetBlock(blockLocation);
			if (126 == blockData.TemplateId)
			{
				continue;
			}
			if (DomainManager.Extra.TryGetHeavenlyTreeByLocation(blockData.GetLocation(), out var tree))
			{
				int requirement = DomainManager.Extra.GetHeavenlyTreeRequiredGrowPointById(tree.Id);
				if (requirement >= 0)
				{
					DomainManager.Extra.HeavenlyTreeGrewUp(context, tree.Id, requirement, showUI: false, out var _);
					instantNotification.AddShenTreeGrow();
				}
			}
			for (sbyte resourceType = 0; resourceType < 6; resourceType++)
			{
				short maxResource = blockData.MaxResources.Items[resourceType];
				short currResource = blockData.CurrResources.Items[resourceType];
				short newResource = (short)Math.Min(maxResource, currResource + maxResource * recoveryFactor / 100);
				recoveryValue += newResource - blockData.CurrResources.Items[resourceType];
				blockData.CurrResources.Items[resourceType] = newResource;
			}
			blockData.StopDestroyedByRecover();
			DomainManager.Map.SetBlockData(context, blockData);
		}
		ProfessionFormulaItem formula = ProfessionFormula.Instance[7];
		int addSeniority = formula.Calculate(recoveryValue);
		DomainManager.Extra.ChangeProfessionSeniority(context, 0, addSeniority);
	}

	private static void ExecuteOnClick_SavageSkill_3(DataContext context, ProfessionData professionData, ref ProfessionSkillArg arg)
	{
		ItemKey selectedItem = arg.ItemKey;
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwu.GetLocation();
		MapBlockData block = DomainManager.Map.GetBlock(location);
		using (IEnumerator<KeyValuePair<ItemKeyAndDate, int>> enumerator = block.Items.Where((KeyValuePair<ItemKeyAndDate, int> item) => item.Key.ItemKey == selectedItem).GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				ItemKeyAndDate itemKeyAndDate = enumerator.Current.Key;
				block.RemoveItemByCount(itemKeyAndDate, 1);
				DomainManager.Item.RemoveOwner(itemKeyAndDate.ItemKey, ItemOwnerType.MapBlock, location.GetHashCode());
			}
		}
		DomainManager.Map.SetBlockData(context, block);
		taiwu.AddInventoryItem(context, selectedItem, 1);
		List<ItemDisplayData> itemDisplayDataList = new List<ItemDisplayData> { DomainManager.Item.GetItemDisplayData(selectedItem, DomainManager.Taiwu.GetTaiwu().GetId()) };
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenGetItem_Item, itemDisplayDataList, arg2: false);
	}

	private static void OpenItemSelectFromBlock()
	{
		DomainManager.World.AdvanceDaysInMonth(DomainManager.TaiwuEvent.MainThreadDataContext, GlobalConfig.Instance.SavageSkill3_OpenItemSelectTimeCost);
		List<ItemDisplayData> itemDisplayDataList = new List<ItemDisplayData>();
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwu.GetLocation();
		if (!location.IsValid())
		{
			return;
		}
		MapBlockData block = DomainManager.Map.GetBlock(location);
		Dictionary<ItemKey, int> itemKeyAndCountDict = new Dictionary<ItemKey, int>();
		foreach (KeyValuePair<ItemKeyAndDate, int> item in block.Items)
		{
			if (itemKeyAndCountDict.ContainsKey(item.Key.ItemKey))
			{
				itemKeyAndCountDict[item.Key.ItemKey] += item.Value;
			}
			else
			{
				itemKeyAndCountDict.Add(item.Key.ItemKey, item.Value);
			}
		}
		itemDisplayDataList = DomainManager.Item.GetItemDisplayDataListOptional(itemKeyAndCountDict.Select((KeyValuePair<ItemKey, int> v) => v.Key).ToList(), taiwu.GetId(), -1);
		foreach (ItemDisplayData item2 in itemDisplayDataList)
		{
			item2.Amount = itemKeyAndCountDict[item2.Key];
		}
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenProfessionSkillSpecial, 3, itemDisplayDataList);
	}

	private static bool CheckSpecialCondition_SavageSkill(ProfessionData professionData, int skillIndex)
	{
		return skillIndex switch
		{
			1 => DomainManager.Extra.CheckSpecialCondition_SavageSkill_1(professionData), 
			3 => CheckSpecialCondition_SavageSkill_3(professionData), 
			_ => true, 
		};
	}

	private static bool CheckSpecialCondition_SavageSkill_3(ProfessionData professionData)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Location location = taiwu.GetLocation();
		if (!location.IsValid())
		{
			return false;
		}
		MapBlockData block = DomainManager.Map.GetBlock(location);
		SortedList<ItemKeyAndDate, int> items = block.Items;
		return items != null && items.Count > 0;
	}

	private static void ExecuteOnClick_TaoistMonkSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		if (index == 3)
		{
			ExecuteOnClick_TaoistMonkSkill_3(context, professionData);
			return;
		}
		throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
	}

	private static void ExecuteOnClick_TaoistMonkSkill_3(DataContext context, ProfessionData professionData)
	{
		TaoistMonkSkillsData skillsData = professionData.GetSkillsData<TaoistMonkSkillsData>();
		skillsData.IsTriggeringTribulation = true;
	}

	public static bool TaoistMonkSkill_CheckTribulationSucceed()
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		Dictionary<ItemKey, int> inventoryItems = taiwu.GetInventory().Items;
		int totalAmount = 0;
		foreach (var (itemKey2, amount) in inventoryItems)
		{
			if (itemKey2.ItemType == 12 && itemKey2.TemplateId == 265)
			{
				totalAmount += amount;
			}
		}
		return totalAmount >= 99;
	}

	public static void TaoistMonkSkill_ConfirmTribulationSucceed(DataContext context, ProfessionData professionData)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		List<short> featureIds = taiwu.GetFeatureIds();
		TaoistMonkSkillsData skillsData = professionData.GetSkillsData<TaoistMonkSkillsData>();
		Dictionary<ItemKey, int> inventoryItems = taiwu.GetInventory().Items;
		foreach (var (itemKey2, amount) in inventoryItems)
		{
			if (itemKey2.ItemType == 12 && itemKey2.TemplateId == 265)
			{
				taiwu.RemoveInventoryItem(context, itemKey2, 99, amount == 99);
				break;
			}
		}
		if (featureIds.Contains(225))
		{
			taiwu.RemoveFeature(context, 225);
			taiwu.RemoveFeature(context, 224);
			taiwu.RemoveFeature(context, 223);
			skillsData.SurvivedTribulationCount = 4;
			skillsData.LastAgeIncreaseDate = DomainManager.World.GetCurrDate() - 12 - DomainManager.World.GetCurrMonthInYear() + taiwu.GetBirthMonth();
			DomainManager.Extra.SetProfessionData(context, professionData);
			if (taiwu.GetCurrAge() > 16)
			{
				short leftMaxHealth = taiwu.GetLeftMaxHealth();
				taiwu.SetCurrAge(16, context);
				short leftMaxHealthAfter = taiwu.GetLeftMaxHealth();
				taiwu.ChangeHealth(context, (leftMaxHealthAfter - leftMaxHealth) * 12);
				AvatarData avatar = taiwu.GetAvatar();
				if (avatar.UpdateGrowableElementsShowingAbilities(taiwu))
				{
					taiwu.SetAvatar(avatar, context);
				}
			}
			taiwu.AddFeature(context, 196, removeMutexFeature: true);
		}
		else
		{
			if (taiwu.AddFeature(context, 223))
			{
				skillsData.SurvivedTribulationCount = 1;
			}
			else if (taiwu.AddFeature(context, 224))
			{
				skillsData.SurvivedTribulationCount = 2;
			}
			else if (taiwu.AddFeature(context, 225))
			{
				skillsData.SurvivedTribulationCount = 3;
			}
			DomainManager.Extra.SetProfessionData(context, professionData);
		}
		LifeRecordCollection lifeRecordCollection = DomainManager.LifeRecord.GetLifeRecordCollection();
		int currDate = DomainManager.World.GetCurrDate();
		lifeRecordCollection.AddTribulationSucceeded(taiwu.GetId(), currDate, taiwu.GetLocation());
	}

	[Obsolete]
	public static bool TaoistMonkSkill_CanTriggerTribulation()
	{
		if (!DomainManager.Extra.IsProfessionalSkillUnlocked(5, 3))
		{
			return false;
		}
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		if (taiwu.GetLeftMaxHealth() > 0)
		{
			return false;
		}
		return DomainManager.TaiwuEvent.IsOneShotEventHandled(39);
	}

	public static bool TaoistMonkSkill_HasSurvivedAllTribulation()
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(5);
		TaoistMonkSkillsData skillsData = professionData.GetSkillsData<TaoistMonkSkillsData>();
		return skillsData.HasSurvivedAllTribulation();
	}

	public static bool TaoistMonkSkill_ShouldIncreaseAge()
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(5);
		TaoistMonkSkillsData skillsData = professionData.GetSkillsData<TaoistMonkSkillsData>();
		return skillsData.ShouldIncreaseAge();
	}

	public static void TaoistMonkSkill_UpdateAgeIncreaseDate(DataContext context)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(5);
		TaoistMonkSkillsData skillsData = professionData.GetSkillsData<TaoistMonkSkillsData>();
		skillsData.LastAgeIncreaseDate = DomainManager.World.GetCurrDate();
		DomainManager.Extra.SetProfessionData(context, professionData);
	}

	private static void UnpackCrossArchiveProfession_TaoistMonk(DataContext context)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(5);
		TaoistMonkSkillsData taoistMonkSkillsData = professionData.GetSkillsData<TaoistMonkSkillsData>();
		if (taoistMonkSkillsData.SurvivedTribulationCount <= 0)
		{
			return;
		}
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (taoistMonkSkillsData.HasSurvivedAllTribulation())
		{
			if (taiwuChar.GetCurrAge() > 16)
			{
				taiwuChar.SetCurrAge(16, context);
			}
		}
		else
		{
			for (int i = 0; i < taoistMonkSkillsData.SurvivedTribulationCount; i++)
			{
				short featureId = (short)(223 + i);
				taiwuChar.AddFeature(context, featureId);
			}
		}
		taoistMonkSkillsData.LastAgeIncreaseDate = DomainManager.World.GetCurrDate();
		DomainManager.Extra.SetProfessionData(context, professionData);
	}

	private static void TaoistMonkSkill_ResetSurvivedTribulationCount(DataContext context)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(5);
		TaoistMonkSkillsData skillsData = professionData.GetSkillsData<TaoistMonkSkillsData>();
		skillsData.SurvivedTribulationCount = 0;
		DomainManager.Extra.SetProfessionData(context, professionData);
	}

	private static void TaoistMonkSkill_OnPostAdvanceMonth(DataContext context)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(5);
		TaoistMonkSkillsData skillData = professionData.GetSkillsData<TaoistMonkSkillsData>();
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		if (skillData.SurvivedTribulationCount > 0 && !skillData.HasSurvivedAllTribulation())
		{
			taiwuChar.CreateInventoryItem(context, 12, 265, skillData.SurvivedTribulationCount * 3);
			DomainManager.World.GetInstantNotificationCollection().AddGetItem(taiwuChar.GetId(), 12, 265);
		}
		if (skillData.IsTriggeringTribulation)
		{
			skillData.IsTriggeringTribulation = false;
			MonthlyEventCollection monthlyEventCollection = DomainManager.World.GetMonthlyEventCollection();
			monthlyEventCollection.AddTaiwuTribulation(taiwuChar.GetId(), taiwuChar.GetLocation());
		}
		if (skillData.ShouldIncreaseAge())
		{
			TaoistMonkSkill_UpdateAgeIncreaseDate(context);
		}
	}

	private static bool CheckSpecialCondition_TaoistMonkSkill(ProfessionData professionData, int index)
	{
		if (index == 3)
		{
			return CheckSpecialCondition_TaoistMonkSkill_3(professionData);
		}
		return true;
	}

	private static bool CheckSpecialCondition_TaoistMonkSkill_3(ProfessionData professionData)
	{
		return true;
	}

	public static void TeaTasterSkill_SetActionPointGained(DataContext context, int value)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(16);
		if (professionData.SkillsData is TeaTasterSkillsData skillsData)
		{
			skillsData.ActionPointGained = value;
			DomainManager.Extra.SetProfessionData(context, professionData);
		}
	}

	public static int TeaTasterSkill_GetActionPointGained()
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(16);
		int res = 0;
		if (professionData.SkillsData is TeaTasterSkillsData skillsData)
		{
			res = skillsData.ActionPointGained;
		}
		return res;
	}

	private static void ExecuteOnClick_TeaTasterSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		if (index == 3)
		{
			TasterUltimateResult result = DomainManager.Extra.CastTasterUltimateSkill(context, arg.CharIds, arg.BookIds, isCombatSkill: false);
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenTasterUltimateResult, arg1: false, result);
			return;
		}
		throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
	}

	private static bool CheckSpecialCondition_TeaTasterSkill(ProfessionData professionData, int index)
	{
		if (index == 3)
		{
			return DomainManager.Extra.CheckTasterUltimateSpecialCondition(isCombatSkill: false) == 0;
		}
		return true;
	}

	private static void ExecuteOnClick_TravelerSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		switch (index)
		{
		case 2:
			ExecuteOnClick_TravelerSkill_2(context, professionData, arg.ProfessionTravelerTargetLocation);
			break;
		case 3:
			ExecuteOnClick_TravelerSkill_3(context, professionData);
			break;
		default:
			throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
		}
	}

	private static void ExecuteOnClick_TravelerSkill_2(DataContext context, ProfessionData professionData, Location targetLocation)
	{
		DomainManager.Map.TeleportByTraveler(context, targetLocation.BlockId);
	}

	private static void ExecuteOnClick_TravelerSkill_3(DataContext context, ProfessionData professionData)
	{
		Location location = DomainManager.Taiwu.GetTaiwu().GetLocation();
		DomainManager.Map.BuildTravelerPalace(context, location);
	}

	private static void ExecuteOnClick_TravelingBuddhistMonkSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		if (index == 3)
		{
			TravelingBuddhistMonkSkill3_SetFeature(context, arg.EffectId);
			return;
		}
		throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
	}

	public static void TravelingBuddhistMonkSkill_SetTempleVisited(DataContext context, Location location)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(12);
		TravelingBuddhistMonkSkillsData skillsData = professionData.GetSkillsData<TravelingBuddhistMonkSkillsData>();
		sbyte stateId = DomainManager.Map.GetStateIdByAreaId(location.AreaId);
		skillsData.OfflineSetStateTempleVisited(stateId);
		DomainManager.Extra.SetProfessionData(context, professionData);
		DomainManager.World.GetInstantNotificationCollection().AddVisitTemple(location, 5 - skillsData.GetVisitedTempleCount());
		int addSeniority = ProfessionFormulaImpl.Calculate(81);
		DomainManager.Extra.ChangeProfessionSeniority(context, 12, addSeniority);
	}

	public static bool TravelingBuddhistMonkSkill_CanVisitTemple(Location location)
	{
		if (!IsSkillUnlocked(50))
		{
			return false;
		}
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(12);
		TravelingBuddhistMonkSkillsData skillsData = professionData.GetSkillsData<TravelingBuddhistMonkSkillsData>();
		sbyte stateId = DomainManager.Map.GetStateIdByAreaId(location.AreaId);
		if (skillsData.IsStateTempleVisited(stateId))
		{
			return false;
		}
		Location stateTempleLocation = skillsData.GetStateTempleLocation(stateId);
		return stateTempleLocation.IsValid() && stateTempleLocation.Equals(location);
	}

	public static void TravelingBuddhistMonkSkill_CreateTemples(DataContext context)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(12);
		TravelingBuddhistMonkSkillsData skillsData = professionData.GetSkillsData<TravelingBuddhistMonkSkillsData>();
		skillsData.OfflineClearAllTampleState();
		short taiwuSettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
		Span<short> selectableAreas = stackalloc short[3];
		Span<short> selectableBlocks = stackalloc short[3];
		List<sbyte> indexList = new List<sbyte>(15);
		for (sbyte stateId = 0; stateId < 15; stateId++)
		{
			indexList.Add(stateId);
		}
		CollectionUtils.Shuffle(context.Random, indexList);
		for (int i = 0; i < 5; i++)
		{
			sbyte stateId2 = indexList[i];
			if (skillsData.StateHasTemple(stateId2))
			{
				continue;
			}
			int selectableAreaCount = 0;
			for (int j = 0; j < 3; j++)
			{
				short areaId = (short)(stateId2 * 3 + j);
				MapAreaData mapAreaData = DomainManager.Map.GetElement_Areas(areaId);
				if (!string.IsNullOrEmpty(mapAreaData.GetConfig().TempleName))
				{
					selectableAreas[selectableAreaCount] = areaId;
					selectableAreaCount++;
				}
			}
			int index = context.Random.Next(selectableAreaCount);
			short selectedAreaId = selectableAreas[index];
			MapAreaData selectedAreaData = DomainManager.Map.GetElement_Areas(selectedAreaId);
			int selectableBlockCount = 0;
			SettlementInfo[] settlementInfos = selectedAreaData.SettlementInfos;
			for (int k = 0; k < settlementInfos.Length; k++)
			{
				SettlementInfo settlementInfo = settlementInfos[k];
				if (settlementInfo.SettlementId >= 0 && settlementInfo.SettlementId != taiwuSettlementId)
				{
					selectableBlocks[selectableBlockCount] = settlementInfo.BlockId;
					selectableBlockCount++;
				}
			}
			index = context.Random.Next(selectableBlockCount);
			short selectedBlockId = selectableBlocks[index];
			Location location = new Location(selectedAreaId, selectedBlockId);
			skillsData.OfflineCreateTemple(stateId2, location);
			AdaptableLog.TagInfo("Profession", "Creating temple " + selectedAreaData.GetConfig().TempleName + " at " + location.ToString());
		}
		DomainManager.Extra.SetProfessionData(context, professionData);
	}

	public static List<string> TravelingBuddhistMonkSkill_GetTempleNames()
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(12);
		TravelingBuddhistMonkSkillsData skillsData = professionData.GetSkillsData<TravelingBuddhistMonkSkillsData>();
		List<string> templeNames = new List<string>();
		for (sbyte stateId = 0; stateId < 15; stateId++)
		{
			if (skillsData.StateHasTemple(stateId))
			{
				Location location = skillsData.GetStateTempleLocation(stateId);
				MapAreaData areaData = DomainManager.Map.GetElement_Areas(location.AreaId);
				templeNames.Add(areaData.GetConfig().TempleName);
			}
		}
		return templeNames;
	}

	public static void TravelingBuddhistMonkSkill3_SetFeature(DataContext context, short featureId)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		taiwu.AddFeature(context, featureId, removeMutexFeature: true);
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(12);
		TravelingBuddhistMonkSkillsData skillsData = professionData.GetSkillsData<TravelingBuddhistMonkSkillsData>();
		skillsData.OfflineSetSelectedSkill3FeatureId(featureId);
		DomainManager.Extra.SetProfessionData(context, professionData);
	}

	private static bool CheckSpecialCondition_TravelingBuddhistMonkSkill(ProfessionData professionData, int index)
	{
		if (index == 3)
		{
			return CheckSpecialCondition_TravelingBuddhistMonkSkill_3(professionData);
		}
		return true;
	}

	private static bool CheckSpecialCondition_TravelingBuddhistMonkSkill_3(ProfessionData professionData)
	{
		return true;
	}

	private static bool CheckSpecialCondition_TravelingTaoistMonkSkill(ProfessionData professionData, int index)
	{
		if (index == 3)
		{
			return CheckSpecialCondition_TravelingTaoistMonkSkill_3(professionData);
		}
		return true;
	}

	private static bool CheckSpecialCondition_TravelingTaoistMonkSkill_3(ProfessionData professionData)
	{
		return true;
	}

	private static void ExecuteOnClick_TravelingTaoistMonkSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		if (index == 2)
		{
			TravelingTaoistMonkSkill2(context, professionData, arg);
			return;
		}
		throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
	}

	private static void TravelingTaoistMonkSkill2(DataContext context, ProfessionData professionData, ProfessionSkillArg arg)
	{
		int rightCharId = arg.CharIds.FirstOrDefault();
		GameData.Domains.Character.Character targetChar = DomainManager.Character.GetElement_Objects(rightCharId);
		GameData.Domains.Character.Character leftChar = DomainManager.Character.GetElement_Objects(arg.CharId);
		GameData.Domains.Character.Character taiwuChar = DomainManager.Taiwu.GetTaiwu();
		List<int> leftFeatureIds = arg.BookIds;
		List<short> rightFeatureIds = arg.EffectBlocks;
		int preBadCount = EventHelper.GetBadFeatureCount(targetChar);
		foreach (int id in leftFeatureIds)
		{
			leftChar.RemoveFeature(context, (short)id);
		}
		foreach (short id2 in rightFeatureIds)
		{
			targetChar.RemoveFeature(context, id2);
		}
		foreach (short id3 in rightFeatureIds)
		{
			leftChar.AddFeature(context, id3);
		}
		foreach (int id4 in leftFeatureIds)
		{
			targetChar.AddFeature(context, (short)id4);
		}
		int curBadCount = EventHelper.GetBadFeatureCount(targetChar);
		int difference = curBadCount - preBadCount;
		EventHelper.ChangeFavorabilityOptionalRepeatedEvent(targetChar, taiwuChar, (short)(-difference * ProfessionRelatedConstants.TravelingTaoistMonkSkill2FavorValue));
		int levelSum = 0;
		foreach (short id5 in rightFeatureIds)
		{
			levelSum += Math.Abs(CharacterFeature.Instance[id5].Level);
		}
		int curSeniority = professionData.Seniority;
		int maxSeniority = 3000000;
		int hpCost = levelSum * (9 - 6 * curSeniority / maxSeniority);
		short health = taiwuChar.GetBaseMaxHealth();
		health = (short)Math.Max(health - hpCost, 0);
		int trulyCost = taiwuChar.GetBaseMaxHealth() - health;
		taiwuChar.SetBaseMaxHealth(health, context);
		ProfessionFormulaItem formula = ProfessionFormula.Instance[94];
		int addSeniority = formula.Calculate(trulyCost);
		DomainManager.Extra.ChangeProfessionSeniority(context, 14, addSeniority);
		DomainManager.TaiwuEvent.SetListenerEventActionBoolArg("TravelingTaoistMonkSkill2Executed", "ConchShip_PresetKey_FinishSkillExecute", value: true);
		DomainManager.TaiwuEvent.TriggerListener("TravelingTaoistMonkSkill2Executed", value: true);
	}

	public static int TravelingTaoistMonkSkill1_ExpCost(GameData.Domains.Character.Character targetChar)
	{
		sbyte grade = targetChar.GetInteractionGrade(targetIsTaiwu: true);
		return (grade + 1) * (grade + 1) * 200;
	}

	private static void TravelingTaoistMonkSkill_ClearHealthBonus(DataContext context)
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(14);
		TravelingTaoistMonkSkillsData skillsData = professionData.GetSkillsData<TravelingTaoistMonkSkillsData>();
		skillsData.BonusMaxHealth = 0;
		DomainManager.Extra.SetProfessionData(context, professionData);
	}

	public static short TravelingTaoistMonkSkill_GetMaxHealthBonus()
	{
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(14);
		if (professionData == null)
		{
			return 0;
		}
		TravelingTaoistMonkSkillsData skillsData = professionData.GetSkillsData<TravelingTaoistMonkSkillsData>();
		return skillsData.BonusMaxHealth;
	}

	private static void TravelingTaoistMonkSkill_OnPreAdvanceMonth(DataContext context)
	{
		if (!IsSkillUnlocked(59))
		{
			return;
		}
		ProfessionData professionData = DomainManager.Extra.GetProfessionData(14);
		if (CheckSpecialCondition(professionData, 3))
		{
			GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
			if (taiwu.GetBirthMonth() == DomainManager.World.GetCurrMonthInYear() && !taiwu.IsAgeIncreaseStopped())
			{
				short age = taiwu.GetCurrAge();
				age += 2;
				taiwu.SetCurrAge(age, context);
				TravelingTaoistMonkSkillsData skillsData = professionData.GetSkillsData<TravelingTaoistMonkSkillsData>();
				skillsData.BonusMaxHealth += 36;
				DomainManager.Extra.SetProfessionData(context, professionData);
				short baseMaxHealth = taiwu.GetBaseMaxHealth();
				taiwu.SetBaseMaxHealth(baseMaxHealth, context);
			}
		}
	}

	private static void ExecuteOnClick_WineTasterSkill(DataContext context, ProfessionData professionData, int index, ref ProfessionSkillArg arg)
	{
		if (index == 3)
		{
			TasterUltimateResult result = DomainManager.Extra.CastTasterUltimateSkill(context, arg.CharIds, arg.BookIds, isCombatSkill: true);
			GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.OpenTasterUltimateResult, arg1: true, result);
			return;
		}
		throw new Exception(professionData.GetSkillConfig(index).Name + " is not an executable skill.");
	}

	private static bool CheckSpecialCondition_WineTasterSkill(ProfessionData professionData, int index)
	{
		if (index == 3)
		{
			return DomainManager.Extra.CheckTasterUltimateSpecialCondition(isCombatSkill: true) == 0;
		}
		return true;
	}
}

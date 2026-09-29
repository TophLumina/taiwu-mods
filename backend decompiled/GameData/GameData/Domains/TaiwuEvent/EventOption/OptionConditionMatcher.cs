using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Building;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.Combat;
using GameData.Domains.Information;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Domains.TaiwuEvent.EventHelper;

namespace GameData.Domains.TaiwuEvent.EventOption;

public static class OptionConditionMatcher
{
	public static bool CharacterNotInGroup(GameData.Domains.Character.Character arg0)
	{
		return !DomainManager.Taiwu.GetGroupCharIds().Contains(arg0.GetId());
	}

	public static bool TeamMateLess(int arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetValidGroupCharacterCount(ignoreBaby: true, ignoreChild: false, ignoreTaiwu: true) < arg0;
	}

	public static bool MovePointMore(sbyte arg0)
	{
		return DomainManager.World.GetLeftDaysInCurrMonth() >= arg0;
	}

	public static bool AuthorityMore(int arg0)
	{
		if (DomainManager.Character.TryGetElement_Objects(EventArgBox.TaiwuCharacterId, out var taiwuChar))
		{
			return taiwuChar.GetResource(7) >= arg0;
		}
		return false;
	}

	public static bool MoneyMore(int arg0)
	{
		if (DomainManager.Character.TryGetElement_Objects(EventArgBox.TaiwuCharacterId, out var taiwuChar))
		{
			return taiwuChar.GetResource(6) >= arg0;
		}
		return false;
	}

	public static bool MonthCooldownCount(string arg0, int arg1, sbyte arg2)
	{
		string boxKey = $"{arg0}_{arg1}";
		EventArgBox globalBox = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetGlobalArgBox();
		int logMonth = -1;
		if (globalBox.Get(boxKey, ref logMonth))
		{
			int curMonth = DomainManager.World.GetCurrDate();
			return curMonth - logMonth >= arg2;
		}
		return true;
	}

	public static bool AreaSpiritualDebtMore(MapAreaData arg0, short arg1)
	{
		return DomainManager.Extra.GetAreaSpiritualDebt(arg0.GetAreaId()) >= arg1;
	}

	public static bool FavorAtLeast(int arg0, int arg1, sbyte arg2)
	{
		short favorValue = DomainManager.Character.GetFavorability(arg0, arg1);
		return FavorabilityType.GetFavorabilityType(favorValue) >= arg2;
	}

	public static bool ProfessionFavorAtLeast(int arg0, int arg1)
	{
		short favorValue = DomainManager.Character.GetFavorability(arg0, arg1);
		GameData.Domains.Character.Character character = DomainManager.Character.GetElement_Objects(arg0);
		sbyte behaviorType = character.GetBehaviorType();
		sbyte favorType = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetProfessionFavorabilityType(behaviorType);
		return FavorabilityType.GetFavorabilityType(favorValue) >= favorType;
	}

	public static bool SwornBrotherOrSisterLess(int arg0)
	{
		HashSet<int> swordCharIds = DomainManager.Character.GetRelatedCharIds(EventArgBox.TaiwuCharacterId, 512);
		int aliveCharCount = 0;
		foreach (int charId in swordCharIds)
		{
			if (DomainManager.Character.IsCharacterAlive(charId))
			{
				aliveCharCount++;
			}
		}
		return aliveCharCount < arg0;
	}

	public static bool CharacterFameNegative(int arg0, string arg1)
	{
		EventArgBox box = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSecretInformationParameters(arg0);
		int reactorId = -1;
		box.Get(arg1, ref reactorId);
		sbyte fameReactor = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSecretInformationCharacterFameTypeSnapshot(arg0, reactorId);
		return !FameType.IsNonNegative(fameReactor, includeBothGoodAndBad: false);
	}

	public static bool SecretInformationLoverOf(int arg0, string arg1)
	{
		EventArgBox box = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSecretInformationParameters(arg0);
		int reactorId = -1;
		box.Get(arg1, ref reactorId);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		HashSet<SecretInformationRelationshipType> pastRelationsBetweenTaiwuAndReactor = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckSecretInformationRelationshipWithSnapshot(reactorId, arg0, taiwuCharId, arg0);
		IEnumerable<SecretInformationRelationshipType> union = pastRelationsBetweenTaiwuAndReactor.Intersect(new SecretInformationRelationshipType[1] { SecretInformationRelationshipType.Lover });
		return union.Any();
	}

	public static bool SecretInformationIsVictim(int arg0, string arg1)
	{
		EventArgBox box = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSecretInformationParameters(arg0);
		int reactorId = -1;
		box.Get(arg1, ref reactorId);
		return DomainManager.Taiwu.GetTaiwuCharId() == reactorId;
	}

	public static bool CharacterFamePositive(int arg0, string arg1)
	{
		EventArgBox box = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSecretInformationParameters(arg0);
		int reactorId = -1;
		box.Get(arg1, ref reactorId);
		sbyte fameReactor = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSecretInformationCharacterFameTypeSnapshot(arg0, reactorId);
		return FameType.IsNonNegative(fameReactor);
	}

	public static bool SecretInformationGoodRelationOf(int arg0, string arg1)
	{
		EventArgBox box = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSecretInformationParameters(arg0);
		int reactorId = -1;
		box.Get(arg1, ref reactorId);
		int taiwuCharId = DomainManager.Taiwu.GetTaiwuCharId();
		HashSet<SecretInformationRelationshipType> pastRelationsBetweenTaiwuAndReactor = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckSecretInformationRelationshipWithSnapshot(reactorId, arg0, taiwuCharId, arg0);
		IEnumerable<SecretInformationRelationshipType> union = pastRelationsBetweenTaiwuAndReactor.Intersect(new SecretInformationRelationshipType[1] { SecretInformationRelationshipType.Allied });
		return union.Any();
	}

	public static bool TaiwuIsBehaviorType(sbyte arg0, sbyte arg1, sbyte arg2, sbyte arg3, sbyte arg4)
	{
		sbyte beh = DomainManager.Taiwu.GetTaiwu().GetBehaviorType();
		if (beh == arg0)
		{
			return true;
		}
		if (beh == arg1)
		{
			return true;
		}
		if (beh == arg2)
		{
			return true;
		}
		if (beh == arg3)
		{
			return true;
		}
		if (beh == arg4)
		{
			return true;
		}
		return false;
	}

	public static bool CurrentAreaSpiritualDebtMore(MapAreaData arg0, short arg1)
	{
		return AreaSpiritualDebtMore(arg0, arg1);
	}

	public static bool ConsummateLevelHigherThan(GameData.Domains.Character.Character arg0)
	{
		if (arg0 == null)
		{
			return false;
		}
		return DomainManager.Taiwu.GetTaiwu().GetConsummateLevel() <= arg0.GetConsummateLevel();
	}

	public static bool ExpMore(int arg0)
	{
		return DomainManager.Taiwu.GetTaiwu().GetExp() >= arg0;
	}

	public static bool TeamMateMore(int arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetValidGroupCharacterCount(ignoreBaby: true, ignoreChild: false, ignoreTaiwu: true) >= arg0;
	}

	public static bool DynamicTeammateCountMax(int arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetValidGroupCharacterCount(ignoreBaby: true, ignoreChild: false, ignoreTaiwu: true) < arg0;
	}

	public static bool CharacterNotTaiwuVillager(GameData.Domains.Character.Character arg0)
	{
		return arg0.GetOrganizationInfo().OrgTemplateId != 16;
	}

	public static bool RelationshipNotEnemy(GameData.Domains.Character.Character arg0)
	{
		return !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckHasRelationship(arg0, DomainManager.Taiwu.GetTaiwu(), 32768);
	}

	public static bool ProfessionSkillConditionNotSatisfy(int arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ProfessionSkillConditionNotSatisfy(arg0);
	}

	public static bool ProfessionSeniorityNotSatisfy(int arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.ProfessionSkillSeniorityNotSatisfy(arg0);
	}

	public static bool CharacterDisorderOfQiNotSatisfy(GameData.Domains.Character.Character arg0, int arg1)
	{
		return arg0.GetDisorderOfQi() <= arg1 * 10;
	}

	public static bool TaiwuDisorderOfQiNotSatisfy(int arg0)
	{
		return DomainManager.Taiwu.GetTaiwu().GetDisorderOfQi() <= arg0 * 10;
	}

	public static bool TaiwuHasItemBySubType(int arg0)
	{
		return !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.SelectCharacterItemByGrade(DomainManager.Taiwu.GetTaiwuCharId(), 0, 8, includeTransferable: false, -1, (short)arg0).Equals(ItemKey.Invalid);
	}

	public static bool CharacterNotMonk(GameData.Domains.Character.Character arg0)
	{
		return arg0.GetMonkType() != 2 && arg0.GetMonkType() != 130;
	}

	public static bool CharacterBehaviorTypeNeedSatisfy(GameData.Domains.Character.Character arg0, sbyte arg1, sbyte arg2)
	{
		return arg0.GetBehaviorType() == arg1 || arg0.GetBehaviorType() == arg2;
	}

	public static bool CharacterIsCastellan(GameData.Domains.Character.Character arg0)
	{
		OrganizationInfo organizationInfo = arg0.GetOrganizationInfo();
		sbyte grade = organizationInfo.Grade;
		return grade == 8 && organizationInfo.Principal && organizationInfo.OrgTemplateId >= 21 && organizationInfo.OrgTemplateId <= 35;
	}

	public static bool CharacterPartlyInfected(GameData.Domains.Character.Character arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckRoleInfection(arg0, 1);
	}

	public static bool CharactetNotYixiangAffect(GameData.Domains.Character.Character arg0)
	{
		return !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckCharacterNearYixiang(arg0);
	}

	public static bool CharacterNotLegendaryInfected(GameData.Domains.Character.Character arg0)
	{
		return !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckCharacterIsLegendaryInfected(arg0);
	}

	public static bool CharacterNotXiangshuInfected(GameData.Domains.Character.Character arg0)
	{
		return !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckCharacterIsXiangshuInfected(arg0);
	}

	public static bool DynamicExpMore(int arg0)
	{
		return DomainManager.Taiwu.GetTaiwu().GetExp() >= arg0;
	}

	private unsafe static bool CharacterNeedSickUnsafe(GameData.Domains.Character.Character arg0)
	{
		Injuries injuries = arg0.GetInjuries();
		if (injuries.HasAnyInjury())
		{
			return true;
		}
		if (injuries.HasAnyInjury(isInnerInjury: true))
		{
			return true;
		}
		for (int i = 0; i < 6; i++)
		{
			if (arg0.GetPoisoned().Items[i] > 0)
			{
				return true;
			}
		}
		if (arg0.GetDisorderOfQi() > 0)
		{
			return true;
		}
		short health = arg0.GetHealth();
		short leftMaxHealth = arg0.GetLeftMaxHealth();
		if (leftMaxHealth > health)
		{
			return true;
		}
		return false;
	}

	public static bool CharacterNeedAdult(GameData.Domains.Character.Character arg0)
	{
		return arg0.GetAgeGroup() >= 2;
	}

	public static bool TaiwuCanEat(int arg0)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		EatingItems eatingItems = taiwu.GetEatingItems();
		sbyte currMaxEatingSlotsCount = taiwu.GetCurrMaxEatingSlotsCount();
		sbyte index = eatingItems.GetAvailableEatingSlot(currMaxEatingSlotsCount);
		if (index < 0)
		{
			return false;
		}
		return true;
	}

	public static bool CharacterCanEat(GameData.Domains.Character.Character arg0)
	{
		EatingItems eatingItems = arg0.GetEatingItems();
		sbyte currMaxEatingSlotsCount = arg0.GetCurrMaxEatingSlotsCount();
		sbyte index = eatingItems.GetAvailableEatingSlot(currMaxEatingSlotsCount);
		if (index < 0)
		{
			return false;
		}
		return true;
	}

	public static bool TaiwuHasSutraPavilionEntryPremit()
	{
		Settlement settlement = DomainManager.Organization.GetSettlementByOrgTemplateId(1);
		OrgMemberCollection orgMembers = settlement.GetMembers();
		return AnyApprovedTaiwu(6) || AnyApprovedTaiwu(7) || AnyApprovedTaiwu(8);
		bool AnyApprovedTaiwu(sbyte grade)
		{
			return orgMembers.GetMembers(grade).Any(GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsSectCharApprovedTaiwu);
		}
	}

	public static bool CharacterNeedSick(GameData.Domains.Character.Character arg0)
	{
		return CharacterNeedSickUnsafe(arg0);
	}

	public static bool ResourceMore(sbyte arg0, int arg1)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		return taiwu.GetResource(arg0) >= arg1;
	}

	public static bool TaiwuMonthCooldownCount(string arg0, int arg1, sbyte arg2)
	{
		string boxKey = $"{arg0}_{arg1}";
		EventArgBox globalBox = GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetGlobalArgBox();
		int logMonth = -1;
		if (globalBox.Get(boxKey, ref logMonth))
		{
			int curMonth = DomainManager.World.GetCurrDate();
			return curMonth - logMonth >= arg2;
		}
		return true;
	}

	public static bool CharacterInSect(GameData.Domains.Character.Character arg0)
	{
		return DomainManager.Organization.IsInAnySect(arg0.GetId());
	}

	public static bool DlcFiveLoongJiaoIsNotFostered(int arg0)
	{
		return !DomainManager.Extra.IsJiaoFostered(arg0);
	}

	public static bool SwordTombInformationUsedCountLimit(EventArgBox arg0)
	{
		int taiwuId = DomainManager.Taiwu.GetTaiwuCharId();
		arg0.Get("SwordTombInformation", out NormalInformation normalInformation);
		return DomainManager.Information.GetNormalInformationUsedCount(taiwuId, normalInformation) == 0;
	}

	public static bool SwordTombInformationGiftItem(EventArgBox arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSwordTombInformationGiftItem(arg0) != ItemKey.Invalid;
	}

	public static bool SwordTombInformationGiftCombatSkill(EventArgBox arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetSwordTombInformationGiftCombatSkill(arg0) > -1;
	}

	public static bool SwordTombInformationGiftTeammate(EventArgBox arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsSwordTombInformationGiftCharacterAbleToJoin(arg0);
	}

	public static bool TaiwuGroupHaveAdult(int arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.TaiwuGroupHaveAdult();
	}

	public static bool TaiwuPrisonerHaveInfectedCharacter(int arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.TaiwuPrisonerHaveInfectedCharacter();
	}

	public static bool InteractionOffCooldown(int arg0, short arg1)
	{
		return DomainManager.TaiwuEvent.IsInteractionEventOptionOffCooldown(arg0, arg1);
	}

	public static bool AliveCricketMore(int arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.AbleToCricketBattleWithGivenLimit(arg0);
	}

	public static bool TaiwuCanGetTaught(GameData.Domains.Character.Character arg0)
	{
		return DomainManager.Taiwu.IsTaiwuAbleToGetTaught(arg0);
	}

	public static bool CharacterCanBeRecommended(GameData.Domains.Character.Character arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsCharacterAbleToBeRecommended(arg0.GetId());
	}

	public static bool TaiwuHasNormalCricket(GameData.Domains.Character.Character arg0)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		List<ItemDisplayData> inventoryItems = DomainManager.Character.GetAllInventoryItems(taiwu.GetId());
		foreach (ItemDisplayData item in inventoryItems)
		{
			ItemKey itemKey = item.Key;
			if (itemKey.ItemType == 11 && GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CanIdentifyCricket(itemKey.Id))
			{
				return true;
			}
		}
		return false;
	}

	public static bool TaiwuHasUnNormalCricket(GameData.Domains.Character.Character arg0)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		List<ItemDisplayData> inventoryItems = DomainManager.Character.GetAllInventoryItems(taiwu.GetId());
		foreach (ItemDisplayData item in inventoryItems)
		{
			ItemKey itemKey = item.Key;
			if (itemKey.ItemType == 11 && GameData.Domains.TaiwuEvent.EventHelper.EventHelper.GetItemCurrDurability(itemKey) > 0 && !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsCricketGreat(itemKey) && GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CanUpgradeCricket(itemKey.Id))
			{
				return true;
			}
		}
		return false;
	}

	public static bool CharacterGradeNotSatisfyByProfession(GameData.Domains.Character.Character arg0, int arg1)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckSeniorityIsSatisfyByGradeByProfession(arg0, arg1);
	}

	public static bool TaiwuHealthMore(int arg0)
	{
		return DomainManager.Taiwu.GetTaiwu().GetBaseMaxHealth() >= 1;
	}

	public static bool CharacterHasNormalHealth(GameData.Domains.Character.Character arg0)
	{
		return !arg0.GetImmunityMask().IsImmune(EMarkType.Health);
	}

	public static bool CharacterOnOrganizationBlock(GameData.Domains.Character.Character arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsCharacterAtTargetSectLocation(arg0, arg0.GetOrganizationInfo().SettlementId);
	}

	public static bool TaiwuAndCharacterNotHusbandOrWife(GameData.Domains.Character.Character arg0)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		return !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckHasRelationship(taiwu, arg0, 1024);
	}

	public static bool TaiwuAndCharacterNotSwornBrotherOrSister(GameData.Domains.Character.Character arg0)
	{
		GameData.Domains.Character.Character taiwu = DomainManager.Taiwu.GetTaiwu();
		return !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CheckHasRelationship(taiwu, arg0, 512);
	}

	public static bool CharacterOnOrganizationRange(GameData.Domains.Character.Character arg0)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsCharacterAtOrganizationRange(arg0, arg0.GetOrganizationInfo().SettlementId);
	}

	public static bool CharacterInjuryPoisonDisorderOfQiLess(GameData.Domains.Character.Character arg0, int arg1)
	{
		return GameData.Domains.TaiwuEvent.EventHelper.EventHelper.CharacterInjuryPoisonDisorderOfQiLess(arg0, arg1);
	}

	public static bool CharacterShouldNotDirectFallenInCombat(GameData.Domains.Character.Character arg0, sbyte arg1)
	{
		return !GameData.Domains.TaiwuEvent.EventHelper.EventHelper.IsCharacterDirectFallenInCombat(arg0.GetId(), (CombatType)arg1);
	}

	public static bool StoneRoomCapacityMore(int arg0)
	{
		Location location = DomainManager.Taiwu.GetTaiwuVillageLocation();
		BuildingBlockData blockData = DomainManager.Building.GetBuildingBlockData(44);
		sbyte villageLevel = DomainManager.Building.BuildingBlockLevel(new BuildingBlockKey(location.AreaId, location.BlockId, blockData.BlockIndex));
		int maxCapacity = BuildingScale.DefValue.StoneRoomCapacity.GetLevelEffect(villageLevel);
		return DomainManager.Extra.GetStoneRoomCharList().Count + arg0 <= maxCapacity;
	}

	public static bool CharacterStarFortune(GameData.Domains.Character.Character arg0, int arg1)
	{
		int point = DomainManager.Extra.GetCharacterExtraLegacyPointWorth(arg0.GetId());
		return point >= arg1;
	}

	public static bool InteractionCooldown(int arg0, short arg1)
	{
		return DomainManager.TaiwuEvent.IsInteractionEventOptionOffCooldown(arg0, arg1);
	}

	public static bool CharacterShave(GameData.Domains.Character.Character arg0)
	{
		int appraisalRequirement = (arg0.GetOrganizationInfo().InteractionGrade + 1) * 50 + 50;
		short curAttainment = DomainManager.Taiwu.GetTaiwu().GetLifeSkillAttainment(5);
		return curAttainment >= appraisalRequirement;
	}
}

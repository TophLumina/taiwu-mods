using System;
using System.Collections.Generic;
using Config;
using GameData.Domains.Character.AvatarSystem;
using GameData.Domains.Character.Display;
using GameData.Domains.Character.Relation;
using GameData.Domains.Item;
using GameData.Domains.Organization;
using GameData.Utilities;

namespace GameData.Domains.Character.Filters;

public static class CharacterMatchers
{
	public static bool MatchAll(Character character, List<Predicate<Character>> predicates)
	{
		int i = 0;
		for (int count = predicates.Count; i < count; i++)
		{
			if (!predicates[i](character))
			{
				return false;
			}
		}
		return true;
	}

	public static bool MatchNotCalledByAdventure(Character character)
	{
		return !character.IsActiveExternalRelationState(4uL);
	}

	public static bool MatchHasNoWork(Character character)
	{
		return !character.IsActiveExternalRelationState(1uL) && !character.IsTreasuryGuard();
	}

	public static bool MatchNotAffectedByLegendaryBook(Character character)
	{
		return character.GetLegendaryBookOwnerState() <= 0;
	}

	public static bool MatchCanBeCalledByAdventure(Character character)
	{
		return !character.IsActiveAdvanceMonthStatus(16);
	}

	public static bool MatchNotTaiwuOwnedLegendaryBook(Character character)
	{
		return character.GetId() != DomainManager.Taiwu.GetTaiwuCharId() && character.GetLegendaryBookOwnerState() >= 0;
	}

	public static bool MatchOrganization(Character character, sbyte orgTemplateId)
	{
		return character.GetOrganizationInfo().OrgTemplateId == orgTemplateId;
	}

	public static bool MatchSettlement(Character character, short settlementId)
	{
		return character.GetOrganizationInfo().SettlementId == settlementId;
	}

	public unsafe static bool MatchGoodAtCombatSkillType(Character character, sbyte combatSkillType)
	{
		CombatSkillShorts combatSkillAttainments = character.GetCombatSkillAttainments();
		int ranking = 1;
		for (sbyte index = 0; index < 14; index++)
		{
			if (combatSkillAttainments.Items[combatSkillType] < combatSkillAttainments.Items[index])
			{
				ranking++;
			}
		}
		if (ranking > 3)
		{
			return false;
		}
		ArraySegmentList<short> attackSkills = character.GetCombatSkillEquipment().Attack;
		ArraySegmentList<short>.Enumerator enumerator = attackSkills.GetEnumerator();
		while (enumerator.MoveNext())
		{
			short skillTemplateId = enumerator.Current;
			if (skillTemplateId < 0 || Config.CombatSkill.Instance[skillTemplateId].Type != combatSkillType)
			{
				continue;
			}
			return true;
		}
		return false;
	}

	public unsafe static bool MatchGoodAtLifeSkillType(Character character, sbyte lifeSkillType)
	{
		LifeSkillShorts lifeSkillAttainments = character.GetLifeSkillAttainments();
		int ranking = 1;
		for (sbyte index = 0; index < 14; index++)
		{
			if (lifeSkillAttainments.Items[lifeSkillType] < lifeSkillAttainments.Items[index])
			{
				ranking++;
			}
		}
		if (ranking > 3)
		{
			return false;
		}
		return lifeSkillAttainments.Items[lifeSkillType] >= 100;
	}

	public static bool MatchRealName(Character character, string name)
	{
		var (surname, givenName) = CharacterDomain.GetRealName(character);
		return surname + givenName == name;
	}

	public static bool MatchConsummateLevel(Character character, sbyte minVal, sbyte maxVal)
	{
		sbyte val = character.GetConsummateLevel();
		return val >= minVal && val <= maxVal;
	}

	public static bool MatchGender(Character character, sbyte gender)
	{
		return character.GetGender() == gender;
	}

	public static bool MatchOrganizationType(Character character, sbyte orgTypeMin, sbyte orgTypeMax)
	{
		sbyte orgTemplateId = character.GetOrganizationInfo().OrgTemplateId;
		sbyte organizationType;
		if (Config.Organization.Instance[orgTemplateId].IsSect)
		{
			organizationType = 0;
		}
		else
		{
			switch (orgTemplateId)
			{
			case 21:
			case 22:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 33:
			case 34:
			case 35:
				organizationType = 1;
				break;
			case 36:
			case 37:
			case 38:
				organizationType = 2;
				break;
			case 16:
				organizationType = 3;
				break;
			default:
				return false;
			}
		}
		return organizationType >= orgTypeMin && organizationType <= orgTypeMax;
	}

	public static bool MatchGrade(Character character, sbyte gradeMin, sbyte gradeMax)
	{
		sbyte grade = character.GetOrganizationInfo().Grade;
		return grade >= gradeMin && grade <= gradeMax;
	}

	public static bool MatchDisplayingAge(Character character, int ageMin, int ageMax)
	{
		short displayingAge = character.GetCurrAge();
		return displayingAge >= ageMin && displayingAge <= ageMax;
	}

	public static bool MatchPhysiologicalAge(Character character, int ageMin, int ageMax)
	{
		short physiologicalAge = character.GetPhysiologicalAge();
		return physiologicalAge >= ageMin && physiologicalAge <= ageMax;
	}

	public static bool MatchBehaviorType(Character character, sbyte minBehaviorType, sbyte maxBehaviorType)
	{
		sbyte behaviorType = character.GetBehaviorType();
		return behaviorType >= minBehaviorType && behaviorType <= maxBehaviorType;
	}

	public static bool MatchAttraction(Character character, int minAttraction, int maxAttraction)
	{
		short attraction = character.GetAttraction();
		return attraction >= minAttraction && attraction <= maxAttraction;
	}

	public static bool MatchHappiness(Character character, int minHappiness, int maxHappiness)
	{
		sbyte happiness = character.GetHappiness();
		return happiness >= minHappiness && happiness <= maxHappiness;
	}

	public static bool MatchResource(Character character, sbyte resourceType, int minAmount, int maxAmount)
	{
		int amount = character.GetResource(resourceType);
		return amount >= minAmount && amount <= maxAmount;
	}

	public static bool MatchHaveHair(Character character, int minValue, int maxValue)
	{
		if (minValue != maxValue || maxValue < 0)
		{
			return true;
		}
		AvatarData avatar = character.GetAvatar();
		return avatar.GetGrowableElementShowingState(0) == (maxValue == 1);
	}

	public static bool MatchOrganizationGoodness(Character character, int goodnessMin, int goodnessMax)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		OrganizationItem config = Config.Organization.Instance[orgInfo.OrgTemplateId];
		return config.Goodness >= goodnessMin && config.Goodness <= goodnessMax;
	}

	public static bool MatchLifeSkillAttainment(Character character, sbyte lifeSkillType, int minVal, int maxVal)
	{
		short lifeSkillAttainment = character.GetLifeSkillAttainment(lifeSkillType);
		return lifeSkillAttainment >= minVal && lifeSkillAttainment <= maxVal;
	}

	public static bool MatchCombatSkillAttainment(Character character, sbyte combatSkillType, int minVal, int maxVal)
	{
		short combatSkillAttainment = character.GetCombatSkillAttainment(combatSkillType);
		return combatSkillAttainment >= minVal && combatSkillAttainment <= maxVal;
	}

	public static bool MatchCombatSkillQualificationGrade(Character character, sbyte combatSkillType, int minGrade, int maxGrade)
	{
		short qualificationValue = character.GetCombatSkillQualification(combatSkillType);
		int grade = SharedMethods.GetCharacterSkillGradeByValue(qualificationValue);
		return grade >= minGrade && grade <= maxGrade;
	}

	public static bool MatchCombatSkillBaseQualification(Character character, sbyte combatSkillType, int minGrade, int maxGrade)
	{
		short qualificationValue = character.GetBaseCombatSkillQualifications()[combatSkillType];
		return qualificationValue >= minGrade && qualificationValue <= maxGrade;
	}

	public static bool MatchAnyCombatSkillQualificationGrade(Character character, int minGrade, int maxGrade)
	{
		for (sbyte combatSkillType = 0; combatSkillType < 14; combatSkillType++)
		{
			short qualificationValue = character.GetCombatSkillQualification(combatSkillType);
			int grade = SharedMethods.GetCharacterSkillGradeByValue(qualificationValue);
			if (grade >= minGrade && grade <= maxGrade)
			{
				return true;
			}
		}
		return false;
	}

	public static bool MatchLifeSkillQualificationGrade(Character character, sbyte lifeSkillType, int minGrade, int maxGrade)
	{
		short qualificationValue = character.GetLifeSkillQualification(lifeSkillType);
		int grade = SharedMethods.GetCharacterSkillGradeByValue(qualificationValue);
		return grade >= minGrade && grade <= maxGrade;
	}

	public static bool MatchAnyLifeSkillQualificationGrade(Character character, int minGrade, int maxGrade)
	{
		for (sbyte lifeSkillType = 0; lifeSkillType < 16; lifeSkillType++)
		{
			short qualificationValue = character.GetLifeSkillQualification(lifeSkillType);
			int grade = SharedMethods.GetCharacterSkillGradeByValue(qualificationValue);
			if (grade >= minGrade && grade <= maxGrade)
			{
				return true;
			}
		}
		return false;
	}

	public static bool MatchLovingItemSubType(Character character, int minValue, int maxValue)
	{
		short value = character.GetLovingItemSubType();
		if (minValue >= 0 && value < minValue)
		{
			return false;
		}
		if (maxValue >= 0 && value > maxValue)
		{
			return false;
		}
		return true;
	}

	public static bool MatchHatingItemSubType(Character character, int minValue, int maxValue)
	{
		short value = character.GetHatingItemSubType();
		if (minValue >= 0 && value < minValue)
		{
			return false;
		}
		if (maxValue >= 0 && value > maxValue)
		{
			return false;
		}
		return true;
	}

	public static bool MatchBountySeverity(Character character, sbyte minValue, sbyte maxValue)
	{
		sbyte sectOrgTemplateId;
		SettlementBounty bounty = DomainManager.Organization.GetBounty(character.GetId(), out sectOrgTemplateId);
		if (bounty == null)
		{
			return false;
		}
		return bounty.PunishmentSeverity >= minValue && bounty.PunishmentSeverity <= maxValue;
	}

	public static bool MatchIsMonk(Character character)
	{
		return character.GetMonkType() != 0;
	}

	public static bool MatchOrgMemberAllowMarriage(Character character)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		OrganizationMemberItem orgMemberConfig = OrganizationDomain.GetOrgMemberConfig(orgInfo);
		int result;
		if (orgMemberConfig != null)
		{
			sbyte[] childGrade = orgMemberConfig.ChildGrade;
			if (childGrade != null && childGrade.Length > 0)
			{
				result = (orgInfo.Principal ? 1 : 0);
				goto IL_002b;
			}
		}
		result = 0;
		goto IL_002b;
		IL_002b:
		return (byte)result != 0;
	}

	public static bool MatchCombatPowerRankInSect(Character character, int minRank, int maxRank)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		if (orgInfo.SettlementId < 0)
		{
			return false;
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(orgInfo.SettlementId);
		int ranking = settlement.GetCharacterRanking(character.GetId());
		return ranking >= minRank && ranking <= maxRank;
	}

	public static bool MatchTopThousandCombatPowerRank(Character character, int minRank, int maxRank)
	{
		int ranking = DomainManager.Character.GetTopThousandCharacterRanking(character.GetId());
		return ranking >= minRank && ranking <= maxRank;
	}

	public static bool MatchPrincipal(Character character)
	{
		return character.GetOrganizationInfo().Principal;
	}

	public static bool MatchSettlementLeader(Character character)
	{
		OrganizationInfo orgInfo = character.GetOrganizationInfo();
		return orgInfo.Grade == 8 && orgInfo.Principal;
	}

	public static bool MatchSettlingState(Character character, int minStateTemplateId, int maxStateTemplateId)
	{
		short settlementId = character.GetOrganizationInfo().SettlementId;
		if (settlementId < 0)
		{
			return false;
		}
		Settlement settlement = DomainManager.Organization.GetSettlement(settlementId);
		short areaId = settlement.GetLocation().AreaId;
		sbyte stateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(areaId);
		return stateTemplateId >= minStateTemplateId && stateTemplateId <= maxStateTemplateId;
	}

	public static bool MatchAncestry(Character character, int stateTemplateId)
	{
		short templateId = character.GetTemplateId();
		MapStateItem stateCfg = MapState.Instance[stateTemplateId];
		if (CollectionUtils.Contains(stateCfg.TemplateCharacterIds, templateId))
		{
			return true;
		}
		bool flag = stateCfg.SectID == 11;
		bool flag2 = flag;
		if (flag2)
		{
			bool flag3 = (uint)(templateId - 30) <= 1u;
			flag2 = flag3;
		}
		return flag2;
	}

	public static bool MatchMaritalStatus(Character character, bool isMarried)
	{
		bool hasAliveSpouse = DomainManager.Character.GetAliveSpouse(character.GetId()) >= 0;
		return hasAliveSpouse == isMarried;
	}

	public static bool MatchCompletelyInfected(Character character)
	{
		return character.IsCompletelyInfected();
	}

	public unsafe static bool MatchPreexistenceChar(Character character, int preexistenceCharId)
	{
		PreexistenceCharIds preexistenceCharIds = character.GetPreexistenceCharIds();
		int i = 0;
		for (int count = preexistenceCharIds.Count; i < count; i++)
		{
			if (preexistenceCharIds.CharIds[i] == preexistenceCharId)
			{
				return true;
			}
		}
		return false;
	}

	public static bool MatchRelationTypeId(Character character, Character relatedCharacter, sbyte minId, sbyte maxId)
	{
		if (!DomainManager.Character.TryGetRelation(character.GetId(), relatedCharacter.GetId(), out var relation))
		{
			return minId <= -1;
		}
		sbyte relationTypeId = RelationType.GetTypeId(relation.RelationType);
		return relationTypeId >= minId && relationTypeId <= maxId;
	}

	public static bool MatchHasInventoryItem(Character character, sbyte itemType, short templateId, int expectedAmount)
	{
		Dictionary<ItemKey, int> inventoryItems = character.GetInventory().Items;
		bool itemFound = false;
		foreach (var (itemKey2, amount) in inventoryItems)
		{
			if (itemKey2.ItemType != itemType || itemKey2.TemplateId != templateId)
			{
				continue;
			}
			if (amount < expectedAmount)
			{
				return false;
			}
			itemFound = true;
			break;
		}
		return itemFound;
	}

	public static bool MatchHasEquippedItem(Character character, sbyte itemType, short templateId)
	{
		ItemKey[] equipment = character.GetEquipment();
		for (int i = 0; i < equipment.Length; i++)
		{
			ItemKey itemKey = equipment[i];
			if (itemKey.ItemType == itemType && itemKey.TemplateId == templateId)
			{
				return true;
			}
		}
		return false;
	}

	public static bool MatchAtVisibleAdventureSite(Character character, short adventureTemplateId)
	{
		return false;
	}

	public static bool MatchMonasticTitleOrDisplayName(Character character, string name)
	{
		NameRelatedData nameRelatedData = new NameRelatedData();
		CharacterDomain.GetNameRelatedData(character, ref nameRelatedData);
		var (surname, givenName) = nameRelatedData.GetMonasticTitleOrDisplayNameDetailed(isTaiwu: false, ignoreNickName: true);
		return name == surname + givenName;
	}

	public static bool MatchFavorabilityToTaiwu(Character character, short minValue, short maxValue)
	{
		short favorability = DomainManager.Character.GetFavorability(character.GetId(), DomainManager.Taiwu.GetTaiwuCharId());
		return favorability >= minValue && favorability <= maxValue;
	}

	public static bool CanBeTaiwu(Character character, short minValue, short maxValue)
	{
		return SharedMethods.CanBeTaiwu(character.GetTemplateId());
	}
}

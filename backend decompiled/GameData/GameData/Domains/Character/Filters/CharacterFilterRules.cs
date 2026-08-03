using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Config.ConfigCells.Character;
using GameData.Common;
using GameData.Domains.Character.Creation;
using GameData.Domains.Map;
using GameData.Domains.Organization;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Character.Filters;

public static class CharacterFilterRules
{
	public unsafe static void GetRandomCharacterPropertiesWithRulesId(IRandomSource randomSource, short characterFilterRulesId, ref TemporaryIntelligentCharacterCreationInfo charCreationInfo)
	{
		CharacterFilterRulesItem config = Config.CharacterFilterRules.Instance[characterFilterRulesId];
		sbyte settlingStateTemplateId = (sbyte)(randomSource.Next(15) + 1);
		sbyte gender = -1;
		sbyte organizationType = -1;
		bool? isMonk = null;
		bool? sectOnly = null;
		bool? orgAllowMarriage = null;
		bool? settlementLeader = null;
		bool isGraded = false;
		sbyte orgTypeMaxVal = 3;
		charCreationInfo.OrgInfo = new OrganizationInfo
		{
			OrgTemplateId = -1,
			Grade = (sbyte)randomSource.Next(0, 9),
			Principal = true,
			SettlementId = -1
		};
		charCreationInfo.Resources.Initialize();
		sbyte currXiangshuLevel = DomainManager.World.GetXiangshuLevel();
		foreach (CharacterFilterElement rule in config.RulesList)
		{
			if (rule.ValueMin > rule.ValueMax)
			{
				throw new Exception($"Rule {characterFilterRulesId} Type {rule.PropertyType}: value range error: {rule.ValueMin}, {rule.ValueMax}");
			}
			int value = rule.GetRandomValue(randomSource);
			switch (rule.PropertyType)
			{
			case 0:
				if (isGraded)
				{
					if (rule.PropertySubType == 1)
					{
						charCreationInfo.OrgInfo.Grade = (sbyte)Math.Clamp(charCreationInfo.OrgInfo.Grade, rule.ValueMin + currXiangshuLevel, rule.ValueMax + currXiangshuLevel);
					}
					else
					{
						charCreationInfo.OrgInfo.Grade = (sbyte)Math.Clamp(charCreationInfo.OrgInfo.Grade, rule.ValueMin, rule.ValueMax);
					}
					break;
				}
				if (rule.PropertySubType == 1)
				{
					value += currXiangshuLevel;
				}
				charCreationInfo.OrgInfo.Grade = (sbyte)Math.Clamp(value, 0, 8);
				isGraded = true;
				break;
			case 1:
				if (charCreationInfo.ActualAge.HasValue)
				{
					throw new Exception("ActualAge is being assigned twice for creating temporary intelligent character.");
				}
				charCreationInfo.ActualAge = (short)value;
				break;
			case 2:
				gender = (sbyte)value;
				break;
			case 3:
			{
				(short min, short max) tuple = BehaviorType.Ranges[value];
				short min = tuple.min;
				short max = tuple.max;
				charCreationInfo.Morality = (short)randomSource.Next(min, max + 1);
				break;
			}
			case 4:
				if (charCreationInfo.ActualAge.HasValue)
				{
					throw new Exception("ActualAge is being assigned twice for creating temporary intelligent character.");
				}
				charCreationInfo.ActualAge = (short)value;
				break;
			case 5:
				charCreationInfo.BaseAttraction = (short)value;
				break;
			case 6:
				settlingStateTemplateId = (sbyte)value;
				break;
			case 8:
				charCreationInfo.IsCompletelyInfected = value == 1;
				break;
			case 9:
				sectOnly = rule.ValueMin == 0 && (rule.ValueMax == 0 || rule.ValueMax < 0);
				orgTypeMaxVal = (sbyte)Math.Max(rule.ValueMax, rule.ValueMin);
				organizationType = (sbyte)value;
				break;
			case 10:
				charCreationInfo.Happiness = (sbyte)Math.Clamp(value, -119, 119);
				break;
			case 11:
				isMonk = value == 1;
				break;
			case 12:
				orgAllowMarriage = value == 1;
				break;
			case 16:
				if (rule.PropertySubType == 1)
				{
					value += currXiangshuLevel;
				}
				charCreationInfo.ConsummateLevel = (sbyte)Math.Clamp(value, 0, 127);
				break;
			case 19:
				charCreationInfo.GoodAtLifeSkillType = (sbyte)rule.PropertySubType;
				charCreationInfo.OrgInfo.OrgTemplateId = OrganizationDomain.GetGoodAtLifeSkillTypeSect(randomSource, charCreationInfo.GoodAtLifeSkillType.Value);
				break;
			case 20:
				charCreationInfo.GoodAtCombatSkillType = (sbyte)rule.PropertySubType;
				charCreationInfo.OrgInfo.OrgTemplateId = OrganizationDomain.GetGoodAtCombatSkillTypeSect(randomSource, charCreationInfo.GoodAtCombatSkillType.Value);
				break;
			case 21:
			{
				ref int reference = ref charCreationInfo.Resources.Items[rule.PropertySubType];
				reference += value;
				break;
			}
			case 22:
				if (rule.ValueMin != rule.ValueMax || rule.ValueMax < 0)
				{
					charCreationInfo.HaveHair = -1;
				}
				else
				{
					charCreationInfo.HaveHair = (sbyte)rule.ValueMax;
				}
				break;
			case 23:
			{
				List<int> list = (from pair in Config.Organization.Instance.RefNameMap
					select pair.Value into templateId
					where templateId >= 0 && Config.Organization.Instance[templateId].Goodness >= rule.ValueMin && Config.Organization.Instance[templateId].Goodness <= rule.ValueMax
					select templateId).ToList();
				charCreationInfo.OrgInfo.OrgTemplateId = (sbyte)list.GetRandom(DataContextManager.GetCurrentThreadDataContext().Random);
				break;
			}
			case 29:
				charCreationInfo.LovingItemSubType = (short)value;
				while (charCreationInfo.HatingItemSubType.HasValue && charCreationInfo.HatingItemSubType.Value == charCreationInfo.LovingItemSubType && !rule.IsFixed)
				{
					charCreationInfo.LovingItemSubType = (short)rule.GetRandomValue(randomSource);
				}
				break;
			case 30:
				charCreationInfo.HatingItemSubType = (short)value;
				while (charCreationInfo.LovingItemSubType.HasValue && charCreationInfo.LovingItemSubType == charCreationInfo.HatingItemSubType && !rule.IsFixed)
				{
					charCreationInfo.HatingItemSubType = (short)rule.GetRandomValue(randomSource);
				}
				break;
			case 28:
				charCreationInfo.BountySeverity = (sbyte)value;
				break;
			case 31:
			{
				Settlement settlement = DomainManager.Organization.GetSettlementByLocation(charCreationInfo.Location);
				charCreationInfo.OrgInfo.SettlementId = settlement.GetId();
				charCreationInfo.OrgInfo.OrgTemplateId = settlement.GetOrgTemplateId();
				break;
			}
			case 15:
				settlementLeader = value == 1;
				break;
			case 34:
			{
				ref short[] combatSkillQualifications = ref charCreationInfo.CombatSkillQualifications;
				if (combatSkillQualifications == null)
				{
					combatSkillQualifications = new short[14];
				}
				charCreationInfo.CombatSkillQualifications[rule.PropertySubType] = (short)value;
				break;
			}
			}
		}
		if (settlementLeader.HasValue)
		{
			if (settlementLeader.Value)
			{
				charCreationInfo.OrgInfo.Grade = 8;
				charCreationInfo.OrgInfo.Principal = true;
			}
			else if (charCreationInfo.OrgInfo.Grade == 8)
			{
				charCreationInfo.OrgInfo.Grade = 7;
			}
		}
		if (settlingStateTemplateId < 1)
		{
			if (!charCreationInfo.Location.IsValid())
			{
				throw new Exception($"CharacterFilterRules {characterFilterRulesId} requires a valid location.");
			}
			settlingStateTemplateId = DomainManager.Map.GetStateTemplateIdByAreaId(charCreationInfo.Location.AreaId);
		}
		MapStateItem settlingStateCfg = MapState.Instance[settlingStateTemplateId];
		if (organizationType == -1 && charCreationInfo.OrgInfo.OrgTemplateId < 0)
		{
			organizationType = (sbyte)randomSource.Next(isMonk.HasValue ? 1 : 0, 4);
		}
		if (isMonk.HasValue || orgAllowMarriage == true || gender != -1)
		{
			if (organizationType == 0)
			{
				if (sectOnly != true)
				{
					organizationType = (sbyte)randomSource.Next(1, orgTypeMaxVal + 1);
				}
				else if (settlingStateCfg == null || settlingStateCfg.SectID <= 0 || !OrganizationDomain.MeetGenderRestriction(settlingStateCfg.SectID, gender) || isMonk.HasValue || orgAllowMarriage.HasValue)
				{
					AdaptableLog.Warning($"Invalid filter rule {config.TemplateId}: IsMonk={isMonk}, OrgAllowMarriage={orgAllowMarriage}, Gender={gender}, SectOnly={sectOnly}", appendWarningMessage: true);
				}
			}
		}
		else if (orgAllowMarriage.HasValue)
		{
			throw new Exception("OrgMemberAllowMarriage cannot be used for creating temporary character in current context.");
		}
		switch (organizationType)
		{
		case 0:
			if (charCreationInfo.OrgInfo.OrgTemplateId < 0)
			{
				charCreationInfo.OrgInfo.OrgTemplateId = settlingStateCfg.SectID;
			}
			charCreationInfo.OrgInfo.SettlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(charCreationInfo.OrgInfo.OrgTemplateId);
			break;
		case 1:
			charCreationInfo.OrgInfo.OrgTemplateId = MapArea.Instance[settlingStateCfg.MainAreaID].OrganizationId[0];
			charCreationInfo.OrgInfo.SettlementId = DomainManager.Organization.GetSettlementIdByOrgTemplateId(charCreationInfo.OrgInfo.OrgTemplateId);
			break;
		case 2:
			charCreationInfo.OrgInfo.SettlementId = DomainManager.Map.GetRandomSettlementId((sbyte)(settlingStateTemplateId - 1), randomSource);
			charCreationInfo.OrgInfo.OrgTemplateId = DomainManager.Organization.GetSettlement(charCreationInfo.OrgInfo.SettlementId).GetOrgTemplateId();
			break;
		case 3:
			charCreationInfo.OrgInfo.OrgTemplateId = 16;
			charCreationInfo.OrgInfo.SettlementId = DomainManager.Taiwu.GetTaiwuVillageSettlementId();
			break;
		default:
			if (charCreationInfo.OrgInfo.OrgTemplateId < 0)
			{
				throw new Exception($"Invalid organization type {organizationType}");
			}
			break;
		}
		OrganizationMemberItem orgMemberConfig = OrganizationDomain.GetOrgMemberConfig(charCreationInfo.OrgInfo.OrgTemplateId, charCreationInfo.OrgInfo.Grade);
		sbyte genderRestriction = orgMemberConfig.Gender;
		if (genderRestriction == -1)
		{
			genderRestriction = Config.Organization.Instance[charCreationInfo.OrgInfo.OrgTemplateId].GenderRestriction;
		}
		charCreationInfo.MonkType = orgMemberConfig.MonkType;
		if (gender == -1)
		{
			gender = ((genderRestriction == -1) ? Gender.GetRandom(randomSource) : genderRestriction);
		}
		Tester.Assert(genderRestriction == -1 || genderRestriction == gender);
		charCreationInfo.CharTemplateId = OrganizationDomain.GetCharacterTemplateId(charCreationInfo.OrgInfo.OrgTemplateId, settlingStateTemplateId, gender);
	}

	public static void ToPredicates(short characterFilterRulesId, List<Predicate<Character>> predicates, Location location)
	{
		predicates.Clear();
		predicates.Add(CharacterMatchers.MatchNotCalledByAdventure);
		predicates.Add(CharacterMatchers.MatchCanBeCalledByAdventure);
		predicates.Add(CharacterMatchers.MatchHasNoWork);
		predicates.Add(CharacterMatchers.MatchNotAffectedByLegendaryBook);
		CharacterFilterRulesItem config = Config.CharacterFilterRules.Instance[characterFilterRulesId];
		int curStateTemplateId = (location.IsValid() ? DomainManager.Map.GetStateTemplateIdByAreaId(location.AreaId) : (-1));
		int[] characterMatchers = config.CharacterMatchers;
		if (characterMatchers != null && characterMatchers.Length > 0)
		{
			int adventureId = ((!location.IsValid()) ? (-1) : (DomainManager.Adventure.QueryAdventureInLocation(location)?.Id ?? (-1)));
			if (adventureId >= 0)
			{
				CharacterMatcherArg arg = new CharacterMatcherArg
				{
					AdventureId = adventureId
				};
				int[] characterMatchers2 = config.CharacterMatchers;
				foreach (int matcherId in characterMatchers2)
				{
					predicates.Add((Character character) => CharacterMatcher.Instance[matcherId].Match(character, arg));
				}
			}
			else
			{
				int[] characterMatchers3 = config.CharacterMatchers;
				foreach (int matcherId2 in characterMatchers3)
				{
					predicates.Add((Character character) => CharacterMatcher.Instance[matcherId2].Match(character));
				}
			}
		}
		HashSet<IntPair> propertyTypes = new HashSet<IntPair>();
		foreach (CharacterFilterElement rule in config.RulesList)
		{
			if (!propertyTypes.Add(new IntPair(rule.PropertyType, rule.PropertySubType)))
			{
				throw new Exception($"The same property type {rule.PropertyType} is filtered more than once");
			}
			switch (rule.PropertyType)
			{
			case 0:
			{
				sbyte xiangshuLevel2 = DomainManager.World.GetXiangshuLevel();
				sbyte minVal2 = (sbyte)(rule.ValueMin + ((rule.PropertySubType == 1) ? xiangshuLevel2 : 0));
				sbyte maxVal2 = (sbyte)(rule.ValueMax + ((rule.PropertySubType == 1) ? xiangshuLevel2 : 0));
				predicates.Add((Character character) => CharacterMatchers.MatchGrade(character, minVal2, maxVal2));
				break;
			}
			case 1:
				predicates.Add((Character character) => CharacterMatchers.MatchPhysiologicalAge(character, rule.ValueMin, rule.ValueMax));
				break;
			case 2:
				predicates.Add((Character character) => CharacterMatchers.MatchGender(character, (sbyte)rule.ValueMin));
				break;
			case 3:
				predicates.Add((Character character) => CharacterMatchers.MatchBehaviorType(character, (sbyte)rule.ValueMin, (sbyte)rule.ValueMax));
				break;
			case 4:
				if (propertyTypes.Contains(new IntPair(1, -1)))
				{
					throw new Exception("PhysiologicalAge and DisplayingAge can't be filtered at the same time.");
				}
				predicates.Add((Character character) => CharacterMatchers.MatchDisplayingAge(character, rule.ValueMin, rule.ValueMax));
				break;
			case 5:
				predicates.Add((Character character) => CharacterMatchers.MatchAttraction(character, rule.ValueMin, rule.ValueMax));
				break;
			case 6:
				if (rule.ValueMin >= 0)
				{
					predicates.Add((Character character) => CharacterMatchers.MatchSettlingState(character, rule.ValueMin, rule.ValueMax));
					break;
				}
				if (curStateTemplateId >= 0)
				{
					predicates.Add((Character character) => CharacterMatchers.MatchSettlingState(character, curStateTemplateId, curStateTemplateId));
					break;
				}
				throw new Exception($"CharacterFilterRules {characterFilterRulesId} requires a valid curStateTemplateId.");
			case 7:
				predicates.Add((Character character) => CharacterMatchers.MatchMaritalStatus(character, isMarried: false));
				break;
			case 8:
				if (rule.ValueMin == 1)
				{
					predicates.Add(CharacterMatchers.MatchCompletelyInfected);
					break;
				}
				predicates.Add((Character character) => !CharacterMatchers.MatchCompletelyInfected(character));
				break;
			case 9:
				predicates.Add((Character character) => CharacterMatchers.MatchOrganizationType(character, (sbyte)rule.ValueMin, (sbyte)rule.ValueMax));
				break;
			case 10:
				predicates.Add((Character character) => CharacterMatchers.MatchHappiness(character, (sbyte)rule.ValueMin, (sbyte)rule.ValueMax));
				break;
			case 11:
				if (rule.ValueMin == 1)
				{
					predicates.Add(CharacterMatchers.MatchIsMonk);
					break;
				}
				predicates.Add((Character character) => !CharacterMatchers.MatchIsMonk(character));
				break;
			case 12:
				if (rule.ValueMin == 1)
				{
					predicates.Add(CharacterMatchers.MatchOrgMemberAllowMarriage);
					break;
				}
				predicates.Add((Character character) => !CharacterMatchers.MatchOrgMemberAllowMarriage(character));
				break;
			case 13:
				predicates.Add((Character character) => CharacterMatchers.MatchCombatPowerRankInSect(character, rule.ValueMin, rule.ValueMax));
				break;
			case 14:
				if (rule.ValueMin == 1)
				{
					predicates.Add(CharacterMatchers.MatchPrincipal);
					break;
				}
				predicates.Add((Character character) => !CharacterMatchers.MatchPrincipal(character));
				break;
			case 15:
				if (rule.ValueMin == 1)
				{
					predicates.Add(CharacterMatchers.MatchSettlementLeader);
					break;
				}
				predicates.Add((Character character) => !CharacterMatchers.MatchSettlementLeader(character));
				break;
			case 16:
			{
				sbyte xiangshuLevel = DomainManager.World.GetXiangshuLevel();
				sbyte minVal = (sbyte)(rule.ValueMin + ((rule.PropertySubType == 1) ? xiangshuLevel : 0));
				sbyte maxVal = (sbyte)(rule.ValueMax + ((rule.PropertySubType == 1) ? xiangshuLevel : 0));
				predicates.Add((Character character) => CharacterMatchers.MatchConsummateLevel(character, minVal, maxVal));
				break;
			}
			case 17:
				predicates.Add((Character character) => CharacterMatchers.MatchLifeSkillAttainment(character, (sbyte)rule.PropertySubType, rule.ValueMin, rule.ValueMax));
				break;
			case 18:
				predicates.Add((Character character) => CharacterMatchers.MatchCombatSkillAttainment(character, (sbyte)rule.PropertySubType, rule.ValueMin, rule.ValueMax));
				break;
			case 19:
				if (rule.ValueMin == 1)
				{
					predicates.Add((Character character) => CharacterMatchers.MatchGoodAtLifeSkillType(character, (sbyte)rule.PropertySubType));
				}
				else
				{
					predicates.Add((Character character) => !CharacterMatchers.MatchGoodAtLifeSkillType(character, (sbyte)rule.PropertySubType));
				}
				break;
			case 20:
				if (rule.ValueMin == 1)
				{
					predicates.Add((Character character) => CharacterMatchers.MatchGoodAtCombatSkillType(character, (sbyte)rule.PropertySubType));
				}
				else
				{
					predicates.Add((Character character) => !CharacterMatchers.MatchGoodAtCombatSkillType(character, (sbyte)rule.PropertySubType));
				}
				break;
			case 21:
				predicates.Add((Character character) => CharacterMatchers.MatchResource(character, (sbyte)rule.PropertySubType, rule.ValueMin, rule.ValueMax));
				break;
			case 22:
				predicates.Add((Character character) => CharacterMatchers.MatchHaveHair(character, rule.ValueMin, rule.ValueMax));
				break;
			case 23:
				predicates.Add((Character character) => CharacterMatchers.MatchOrganizationGoodness(character, rule.ValueMin, rule.ValueMax));
				break;
			case 24:
				predicates.Add((Character character) => CharacterMatchers.MatchCombatSkillQualificationGrade(character, (sbyte)rule.PropertySubType, rule.ValueMin, rule.ValueMax));
				break;
			case 25:
				predicates.Add((Character character) => CharacterMatchers.MatchLifeSkillQualificationGrade(character, (sbyte)rule.PropertySubType, rule.ValueMin, rule.ValueMax));
				break;
			case 26:
				predicates.Add((Character character) => CharacterMatchers.MatchAnyCombatSkillQualificationGrade(character, rule.ValueMin, rule.ValueMax));
				break;
			case 27:
				predicates.Add((Character character) => CharacterMatchers.MatchAnyLifeSkillQualificationGrade(character, rule.ValueMin, rule.ValueMax));
				break;
			case 28:
				predicates.Add((Character character) => CharacterMatchers.MatchBountySeverity(character, (sbyte)rule.ValueMin, (sbyte)rule.ValueMax));
				break;
			case 29:
				predicates.Add((Character character) => CharacterMatchers.MatchLovingItemSubType(character, rule.ValueMin, rule.ValueMax));
				break;
			case 30:
				predicates.Add((Character character) => CharacterMatchers.MatchHatingItemSubType(character, rule.ValueMin, rule.ValueMax));
				break;
			case 31:
			{
				Settlement settlement = DomainManager.Organization.GetSettlementByLocation(location);
				predicates.Add((Character character) => settlement.GetId() == character.GetOrganizationInfo().SettlementId == (rule.ValueMin == 1));
				break;
			}
			case 32:
				predicates.Add((Character character) => CharacterMatchers.MatchFavorabilityToTaiwu(character, (short)rule.ValueMin, (short)rule.ValueMax));
				break;
			case 33:
				predicates.Add((Character character) => CharacterMatchers.CanBeTaiwu(character, (short)rule.ValueMin, (short)rule.ValueMax));
				break;
			case 34:
				predicates.Add((Character character) => CharacterMatchers.MatchCombatSkillBaseQualification(character, (sbyte)rule.PropertySubType, rule.ValueMin, rule.ValueMax));
				break;
			}
		}
	}
}

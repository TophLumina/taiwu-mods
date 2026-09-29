using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Character;
using GameData.Domains.World;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

public static class SharedMethods
{
	private static readonly int[] MoneyRelatedTypes = new int[9] { 0, 1, 2, 3, 4, 5, 12, 13, 15 };

	public static bool NeedCostMoreResource
	{
		get
		{
			if (ExternalDataBridge.Context.ChallengeModeData.IsEnabled(EChallengeModeImplement.CostResources))
			{
				return ExternalDataBridge.Context.GetWorldFunctionsStatus(10);
			}
			return false;
		}
	}

	public static short GetQualificationWithSectApprovalBonus(sbyte orgTemplateId, short currQualification, LifeSkillShorts qualifications, out sbyte bonusLifeSkillType)
	{
		bonusLifeSkillType = -1;
		if (orgTemplateId == 0)
		{
			return currQualification;
		}
		foreach (sbyte lifeSkillType in SectApprovingEffect.Instance[orgTemplateId - 1].RequirementSubstitutions)
		{
			if (currQualification < qualifications[lifeSkillType])
			{
				currQualification = qualifications[lifeSkillType];
				bonusLifeSkillType = lifeSkillType;
			}
		}
		return currQualification;
	}

	public static List<IntList> GetLegacyMaxPointAndTimesListByType(WorldCreationInfo creationInfo, Dictionary<short, short> legacyPointTimesDict, short legacyType)
	{
		List<IntList> result = new List<IntList>();
		foreach (LegacyPointItem legacyPoint in (IEnumerable<LegacyPointItem>)LegacyPoint.Instance)
		{
			if (legacyPoint.Type == legacyType && (!legacyPoint.IsHidden || legacyPointTimesDict.GetValueOrDefault(legacyPoint.TemplateId) != 0))
			{
				IntList list = IntList.Create();
				list.Items.Add(legacyPoint.TemplateId);
				list.Items.Add(GetLegacyMaxPoint(creationInfo, legacyPoint));
				if (legacyPointTimesDict.TryGetValue(legacyPoint.TemplateId, out var times))
				{
					list.Items.Add(times);
				}
				else
				{
					list.Items.Add(0);
				}
				result.Add(list);
			}
		}
		return result;
	}

	public static int GetLegacyMaxPoint(WorldCreationInfo creationInfo, LegacyPointItem configData)
	{
		return configData.MaxPoint * GetLegacySettingsPercent(creationInfo, configData) / 100;
	}

	public static int GetLegacySettingsPercent(WorldCreationInfo creationInfo, LegacyPointItem configData)
	{
		int settingsPercent = 100;
		byte[] bonusTypes = configData.BonusTypes;
		foreach (byte creationType in bonusTypes)
		{
			int bonusIndex = GetWorldCreationSetting(creationInfo, creationType);
			if (bonusIndex >= 0)
			{
				short[] bonus = WorldCreation.Instance[creationType].LegacyPointBonus;
				if (bonus.CheckIndex(bonusIndex))
				{
					settingsPercent += bonus[bonusIndex];
				}
				else
				{
					PredefinedLog.Show(19, $"index {bonusIndex} is invalid for creatingType {creationType}");
				}
			}
		}
		return settingsPercent;
	}

	public static int GetWorldCreationSetting(WorldCreationInfo creationInfo, byte worldCreationType)
	{
		int num = worldCreationType switch
		{
			1 => creationInfo.CombatDifficulty, 
			11 => creationInfo.EnemyPracticeLevel, 
			12 => creationInfo.FavorabilityChange, 
			2 => creationInfo.ReadingDifficulty, 
			3 => creationInfo.BreakoutDifficulty, 
			4 => creationInfo.LoopingDifficulty, 
			5 => creationInfo.HereticsAmountType, 
			6 => creationInfo.BossInvasionSpeedType, 
			7 => creationInfo.WorldResourceAmountType, 
			13 => creationInfo.ProfessionUpgrade, 
			14 => creationInfo.LootYield, 
			_ => -1, 
		};
		if (num < 0)
		{
			PredefinedLog.Show(19, $"GetSettingWorldCreationType by {worldCreationType}");
		}
		return num;
	}

	public static int GetLuohanBreakMaxPower(short skillTemplateId, CombatSkillShorts qualifications)
	{
		CombatSkillItem config = Config.CombatSkill.Instance[skillTemplateId];
		short requireQualification = SkillGradeData.Instance[config.Grade].PracticeQualificationRequirement;
		return GlobalConfig.Instance.LuohanMaxPowerBase + config.Grade * GlobalConfig.Instance.LuohanMaxPowerGradeFactor + qualifications[config.Type] / requireQualification * GlobalConfig.Instance.LuohanMaxPowerQualificationFactor;
	}

	public static ResourceInts GetChallengeModeCostResource(LifeSkillShorts lifeSkill, CombatSkillShorts combatSkill)
	{
		ResourceInts result = default(ResourceInts);
		result[0] = lifeSkill[14] / GlobalConfig.Instance.ChallengeCostResourceResourceFactorFood;
		result[1] = lifeSkill[7] / GlobalConfig.Instance.ChallengeCostResourceResourceFactorWood;
		result[2] = lifeSkill[6] / GlobalConfig.Instance.ChallengeCostResourceResourceFactorMetal;
		result[3] = lifeSkill[11] / GlobalConfig.Instance.ChallengeCostResourceResourceFactorJade;
		result[4] = lifeSkill[10] / GlobalConfig.Instance.ChallengeCostResourceResourceFactorFabric;
		result[5] = Math.Max(lifeSkill[8], lifeSkill[9]) / GlobalConfig.Instance.ChallengeCostResourceResourceFactorHerb;
		result[6] = MoneyRelatedTypes.Select((int i) => lifeSkill[i]).Max() / GlobalConfig.Instance.ChallengeCostResourceResourceFactorMoney;
		result[7] = (from i in Enumerable.Range(0, 14)
			select combatSkill[i]).Max() / GlobalConfig.Instance.ChallengeCostResourceResourceFactorAuth;
		return result;
	}
}

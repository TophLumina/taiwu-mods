using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Domains.Character;
using GameData.Domains.World;
using GameData.Utilities;

namespace GameData.Domains.Taiwu;

/// <summary>
/// 前后端共享的静态方法
/// </summary>
public static class SharedMethods
{
	private static readonly int[] MoneyRelatedTypes = new int[9] { 0, 1, 2, 3, 4, 5, 12, 13, 15 };

	/// <summary>
	/// 是否开启玄狱词条 - 入不敷出
	/// </summary>
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

	/// <summary>
	/// 获得通过指定门派加成计算后的取代资质
	/// 返回值等于传入的currQualification时，说明没有被技艺资质取代
	/// </summary>
	/// <param name="orgTemplateId"></param>
	/// <param name="currQualification"></param>
	/// <param name="qualifications"></param>
	/// <param name="bonusLifeSkillType"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 专门UI显示用的接口
	/// 获取大类下每个遗惠id对应的：（id，上限， 已获得次数）
	/// </summary>
	/// <param name="creationInfo"></param>
	/// <param name="legacyPointTimesDict"></param>
	/// <param name="legacyType"></param>
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

	/// <summary>
	/// 获取遗惠点上限值
	/// </summary>
	/// <param name="creationInfo"></param>
	/// <param name="configData"></param>
	/// <returns></returns>
	public static int GetLegacyMaxPoint(WorldCreationInfo creationInfo, LegacyPointItem configData)
	{
		return configData.MaxPoint * GetLegacySettingsPercent(creationInfo, configData) / 100;
	}

	/// <summary>
	/// 获取设置的遗惠加成
	/// </summary>
	/// <param name="creationInfo"></param>
	/// <param name="configData"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取指定世界设置值
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 计算 玄狱词条 - 入不敷出 消耗
	/// </summary>
	/// <param name="lifeSkill"></param>
	/// <param name="combatSkill"></param>
	/// <returns></returns>
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Config;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// map数据域 - 数据模块和表现模块共用的方法
/// </summary>
/// <summary>
/// 角色形象相关前后端共用的方法 - 形象相关
/// </summary>
/// <summary>
/// 角色相关前后端共用的方法
/// </summary>
public static class SharedMethods
{
	/// <summary>
	/// 资质到品级的转换
	/// </summary>
	private static readonly byte[] LifeSkillAttainmentLevel = new byte[9] { 19, 29, 39, 49, 59, 69, 79, 89, 90 };

	/// <summary>
	/// 对技艺和武学基础资质其中一个维度的品阶评价
	/// </summary>
	/// <param name="qualification"></param>
	/// <returns></returns>
	public static int CalcQualificationGrade(short qualification)
	{
		if (qualification >= 100)
		{
			return 8;
		}
		if (qualification >= 90)
		{
			return 7;
		}
		if (qualification >= 80)
		{
			return 6;
		}
		if (qualification >= 70)
		{
			return 5;
		}
		if (qualification >= 60)
		{
			return 4;
		}
		if (qualification >= 50)
		{
			return 3;
		}
		if (qualification >= 40)
		{
			return 2;
		}
		if (qualification >= 30)
		{
			return 1;
		}
		return 0;
	}

	/// <summary>
	/// 获取修行特性的名誉值
	/// </summary>
	/// <param name="featureId"></param>
	/// <param name="isTaiwu"></param>
	/// <param name="charcterOrgInfo"></param>
	/// <returns></returns>
	public static int GetSectFeatureFameBonus(short featureId, bool isTaiwu, OrganizationInfo charcterOrgInfo)
	{
		int value = 0;
		OrganizationItem orgConfig = Config.Organization.Instance.FirstOrDefault((OrganizationItem o) => o.MemberFeature == featureId);
		if (orgConfig == null)
		{
			return value;
		}
		CharacterFeatureItem featureConfig = CharacterFeature.Instance[featureId];
		if (isTaiwu)
		{
			return value + featureConfig.TaiwuFameBonu;
		}
		if (orgConfig.TemplateId == charcterOrgInfo.OrgTemplateId)
		{
			return value + featureConfig.SectFameBonus[charcterOrgInfo.Grade];
		}
		return value + featureConfig.NotSectFameBonu;
	}

	/// <summary>
	/// 获取人物（最终）名誉值
	/// </summary>
	/// <param name="features"></param>
	/// <param name="fameRecords"></param>
	/// <param name="organizationInfo"></param>
	/// <param name="currDate"></param>
	/// <param name="isTaiwu"></param>
	/// <returns>（正向名誉，负向名誉（的绝对值））</returns>
	public static (int good, int bad) GetFame(IEnumerable<short> features, IEnumerable<FameActionRecord> fameRecords, OrganizationInfo organizationInfo, int currDate, bool isTaiwu)
	{
		(int, int, int, int, bool, bool) ret = GetRawFame(features, fameRecords, organizationInfo, currDate, isTaiwu);
		return (good: ret.Item1 * Math.Max(0, ret.Item3) / 100, bad: ret.Item2 * Math.Max(0, ret.Item4) / 100);
	}

	/// <summary>
	/// 获取人物原始名誉值
	/// </summary>
	/// <param name="features"></param>
	/// <param name="fameRecords"></param>
	/// <param name="organizationInfo"></param>
	/// <param name="currDate"></param>
	/// <param name="isTaiwu"></param>
	/// <returns>（正向名誉，负向名誉（的绝对值），正向加成（原始比例，无加成时为100，可能为负），负向加成（原始比例，无加成时为100，可能为负），是否存在正向加成，是否存在负向加成）</returns>
	public static (int good, int bad, int goodCoef, int badCoef, bool hasGood, bool hasBad) GetRawFame(IEnumerable<short> features, IEnumerable<FameActionRecord> fameRecords, OrganizationInfo organizationInfo, int currDate, bool isTaiwu)
	{
		(int, int, int, int, bool, bool) ret = (0, 0, 100, 100, false, false);
		foreach (short feature in features)
		{
			RecordFame(GetSectFeatureFameBonus(feature, isTaiwu, organizationInfo), ref ret.Item1, ref ret.Item2);
		}
		foreach (FameActionRecord record in fameRecords)
		{
			if (record.EndDate > currDate)
			{
				RecordFame(record.Value, ref ret.Item1, ref ret.Item2);
				FameActionItem template = FameAction.Instance[record.Id];
				ret.Item3 += template.PositiveFameBonus;
				ret.Item4 += template.NegativeFameBonus;
				ret.Item5 |= template.PositiveFameBonus != 0;
				ret.Item6 |= template.NegativeFameBonus != 0;
			}
		}
		return ret;
		static void RecordFame(int value, ref int valueGood, ref int valueBad)
		{
			if (value > 0)
			{
				valueGood += value;
			}
			else
			{
				valueBad -= value;
			}
		}
	}

	/// <summary>
	/// 获取角色功法技艺资质的对应等级
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static int GetCharacterSkillGradeByValue(short value)
	{
		int level;
		for (level = 0; level < LifeSkillAttainmentLevel.Length && value > LifeSkillAttainmentLevel[level]; level++)
		{
		}
		return level;
	}

	/// <summary>
	/// 检查templateId对应Npc是否可以修改装备槽
	/// 此处没有检测装备是否可卸除
	/// 正常情况下应该使用三参数的同名方法
	/// </summary>
	/// <param name="templateId">这是Npc的templateId，不是装备的templateId</param>
	/// <param name="slotId"></param>
	/// <returns></returns>
	public static bool CanModifyEquipSlot(short templateId, sbyte slotId)
	{
		bool flag = templateId == -1;
		if (!flag)
		{
			bool flag2 = ((slotId < 0 || slotId > 16) ? true : false);
			flag = flag2;
		}
		if (!flag)
		{
			CharacterItem characterItem = Config.Character.Instance[templateId];
			return characterItem == null || !characterItem.EquipmentLock[slotId];
		}
		return true;
	}

	/// <summary>
	/// 检查templateId对应Npc是否可以修改装备槽中物品
	/// </summary>
	/// <param name="templateId">这是Npc的templateId，不是装备的templateId</param>
	/// <param name="slotId"></param>
	/// <param name="itemKey">待修改的物品</param>
	/// <returns></returns>
	public static bool CanModifyEquipSlot(short templateId, sbyte slotId, ItemKey itemKey)
	{
		if (ItemTemplateHelper.IsDetachable(itemKey.ItemType, itemKey.TemplateId))
		{
			return CanModifyEquipSlot(templateId, slotId);
		}
		return false;
	}

	/// <summary>
	/// 检查templateId对应Npc是否可以传剑
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool CanBeTaiwu(short templateId)
	{
		if (templateId != -1)
		{
			return Config.Character.Instance[templateId]?.CanBeTaiwu ?? true;
		}
		return true;
	}

	/// <summary>
	/// 检查templateId对应Npc是否可以化魂
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool CanBePossessionBody(short templateId)
	{
		if (templateId != -1)
		{
			return Config.Character.Instance[templateId]?.CanBePossessionBody ?? true;
		}
		return true;
	}

	/// <summary>
	/// 检查templateId对应Npc是否可以化魂
	/// </summary>
	/// <param name="templateId"></param>
	/// <returns></returns>
	public static bool CanBePossessionSoul(short templateId)
	{
		if (templateId != -1)
		{
			return Config.Character.Instance[templateId]?.CanBePossessionSoul ?? true;
		}
		return true;
	}

	/// <summary>
	/// 获取是否有能力长出指定的可生长形象部件.
	/// 其逻辑需要与 <see cref="!:GameData.Domains.Character.Character.IsAbleToGrowAvatarElement" /> 方法同步.
	/// </summary>
	/// <param name="growableElementType"><see cref="T:GameData.Domains.Character.AvatarSystem.AvatarGrowableElementType" /></param>
	/// <param name="monkType"><see cref="T:GameData.Domains.Character.MonkType" /></param>
	/// <param name="physiologicalAge"></param>
	/// <param name="gender"></param>
	/// <param name="transgender"></param>
	/// <param name="featureIds"></param>
	/// <returns></returns>
	public static bool IsAbleToGrowAvatarElement(sbyte growableElementType, byte monkType, short physiologicalAge, sbyte gender, bool transgender, List<short> featureIds, int maxHealthMonths = 0)
	{
		return growableElementType switch
		{
			0 => IsAbleToGrowHair(monkType), 
			1 => IsAbleToGrowBeard1(physiologicalAge, gender, transgender, featureIds), 
			2 => IsAbleToGrowBeard2(physiologicalAge, gender, transgender, featureIds), 
			3 => IsAbleToGrowWrinkle1(physiologicalAge, maxHealthMonths), 
			4 => IsAbleToGrowWrinkle2(physiologicalAge, maxHealthMonths), 
			5 => IsAbleToGrowWrinkle3(physiologicalAge, maxHealthMonths), 
			6 => IsAbleToGrowEyebrow(), 
			_ => throw new Exception($"Unsupported AvatarGrowableElementType: {growableElementType}"), 
		};
	}

	/// <summary>
	/// 获取是否有能力长出头发.
	/// 当角色不为门派和尚时, 才能长出头发.
	/// 其逻辑需要与 <see cref="!:GameData.Domains.Character.Character.IsAbleToGrowHair" /> 方法同步.
	/// </summary>
	/// <param name="monkType"><see cref="T:GameData.Domains.Character.MonkType" /></param>
	/// <returns></returns>
	public static bool IsAbleToGrowHair(byte monkType)
	{
		return monkType != 130;
	}

	/// <summary>
	/// 获取是否有能力长出胡须.
	/// 当角色为适龄男性, 且不为异性相, 且不为无根之人, 才能长出胡须.
	/// 其逻辑需要与 <see cref="!:GameData.Domains.Character.Character.IsAbleToGrowBeards" /> 方法同步.
	/// </summary>
	/// <param name="physiologicalAge"></param>
	/// <param name="gender"></param>
	/// <param name="transgender"></param>
	/// <param name="featureIds"></param>
	/// <returns></returns>
	public static (bool beard1, bool beard2) IsAbleToGrowBeards(short physiologicalAge, sbyte gender, bool transgender, List<short> featureIds)
	{
		if (gender != 1 || transgender || featureIds.Contains(168))
		{
			return (beard1: false, beard2: false);
		}
		return (beard1: physiologicalAge >= GlobalConfig.Instance.AgeShowBeard1, beard2: physiologicalAge >= GlobalConfig.Instance.AgeShowBeard2);
	}

	/// <summary>
	/// 获取是否有能力长出上嘴唇胡须.
	/// 当角色为适龄男性, 且不为异性相, 且不为无根之人, 才能长出胡须.
	/// 其逻辑需要与 <see cref="!:GameData.Domains.Character.Character.IsAbleToGrowBeard1" /> 方法同步.
	/// </summary>
	/// <param name="physiologicalAge"></param>
	/// <param name="gender"></param>
	/// <param name="transgender"></param>
	/// <param name="featureIds"></param>
	/// <returns></returns>
	public static bool IsAbleToGrowBeard1(short physiologicalAge, sbyte gender, bool transgender, List<short> featureIds)
	{
		if (gender == 1 && physiologicalAge >= GlobalConfig.Instance.AgeShowBeard1 && !transgender)
		{
			return !featureIds.Contains(168);
		}
		return false;
	}

	/// <summary>
	/// 获取是否有能力长出下嘴唇胡须.
	/// 当角色为适龄男性, 且不为异性相, 且不为无根之人, 才能长出胡须.
	/// 其逻辑需要与 <see cref="!:GameData.Domains.Character.Character.IsAbleToGrowBeard2" /> 方法同步.
	/// </summary>
	/// <param name="physiologicalAge"></param>
	/// <param name="gender"></param>
	/// <param name="transgender"></param>
	/// <param name="featureIds"></param>
	/// <returns></returns>
	public static bool IsAbleToGrowBeard2(short physiologicalAge, sbyte gender, bool transgender, List<short> featureIds)
	{
		if (gender == 1 && physiologicalAge >= GlobalConfig.Instance.AgeShowBeard2 && !transgender)
		{
			return !featureIds.Contains(168);
		}
		return false;
	}

	/// <summary>
	/// 获取是否有能力长出抬头纹.
	/// 其逻辑需要与 <see cref="!:GameData.Domains.Character.Character.IsAbleToGrowWrinkle1" /> 方法同步.
	/// </summary>
	/// <param name="physiologicalAge"></param>
	/// <returns></returns>
	public static bool IsAbleToGrowWrinkle1(short physiologicalAge, int maxHealthMonths = 0)
	{
		if (physiologicalAge < GlobalConfig.Instance.AgeShowWrinkle1)
		{
			return false;
		}
		if (maxHealthMonths > 0)
		{
			return physiologicalAge * 12 * 100 >= maxHealthMonths * GlobalConfig.Instance.AgePercentShowWrinkle1;
		}
		return true;
	}

	/// <summary>
	/// 获取是否有能力长出表情纹.
	/// 其逻辑需要与 <see cref="!:GameData.Domains.Character.Character.IsAbleToGrowWrinkle2" /> 方法同步.
	/// </summary>
	/// <param name="physiologicalAge"></param>
	/// <returns></returns>
	public static bool IsAbleToGrowWrinkle2(short physiologicalAge, int maxHealthMonths = 0)
	{
		if (physiologicalAge < GlobalConfig.Instance.AgeShowWrinkle2)
		{
			return false;
		}
		if (maxHealthMonths > 0)
		{
			return physiologicalAge * 12 * 100 >= maxHealthMonths * GlobalConfig.Instance.AgePercentShowWrinkle2;
		}
		return true;
	}

	/// <summary>
	/// 获取是否有能力长出眼袋纹.
	/// 其逻辑需要与 <see cref="!:GameData.Domains.Character.Character.IsAbleToGrowWrinkle3" /> 方法同步.
	/// </summary>
	/// <param name="physiologicalAge"></param>
	/// <returns></returns>
	public static bool IsAbleToGrowWrinkle3(short physiologicalAge, int maxHealthMonths = 0)
	{
		if (physiologicalAge < GlobalConfig.Instance.AgeShowWrinkle3)
		{
			return false;
		}
		if (maxHealthMonths > 0)
		{
			return physiologicalAge * 12 * 100 >= maxHealthMonths * GlobalConfig.Instance.AgePercentShowWrinkle3;
		}
		return true;
	}

	/// <summary>
	/// 获取是否有能力长出眉毛。
	/// 其逻辑需要与 <see cref="!:GameData.Domains.Character.Character.IsAbleToGrowEyebrow" /> 方法同步.
	/// </summary>
	/// <returns></returns>
	public static bool IsAbleToGrowEyebrow()
	{
		return true;
	}

	/// <summary>
	/// 获取角色的先天命格属性 (五行)
	/// </summary>
	/// <param name="birthMonth">出生月份</param>
	/// <returns><see cref="T:GameData.Domains.CombatSkill.FiveElementsType" /></returns>
	public static sbyte GetInnateFiveElementsType(sbyte birthMonth)
	{
		return Month.Instance[birthMonth].FiveElementsType;
	}

	/// <summary>
	/// 是否免疫指定类型的毒素
	/// </summary>
	/// <param name="poisonType">毒素类型<see cref="T:GameData.Domains.Combat.PoisonType" /></param>
	/// <param name="characterCfg">角色模板</param>
	/// <param name="poisonResists">毒抗类型</param>
	/// <param name="poisonImmunities">额外的毒抗免疫配置</param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static bool HasPoisonImmunity(sbyte poisonType, CharacterItem characterCfg, ref PoisonInts poisonResists, byte poisonImmunities)
	{
		if (!characterCfg.PoisonImmunities[poisonType] && poisonResists.Items[poisonType] < 1000)
		{
			return BitOperation.GetBit(poisonImmunities, poisonType);
		}
		return true;
	}

	/// <summary>
	/// 是否免疫指定类型的毒素
	/// </summary>
	/// <param name="poisonType">毒素类型<see cref="T:GameData.Domains.Combat.PoisonType" /></param>
	/// <param name="characterCfg">角色模板</param>
	/// <param name="poisonResists">毒抗类型</param>
	/// <param name="poisonImmunities">额外的毒抗免疫配置</param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool HasPoisonImmunity(sbyte poisonType, CharacterItem characterCfg, ref int[] poisonResists, byte poisonImmunities)
	{
		if (!characterCfg.PoisonImmunities[poisonType] && poisonResists[poisonType] < 1000)
		{
			return BitOperation.GetBit(poisonImmunities, poisonType);
		}
		return true;
	}

	/// <summary>
	/// 获取指定同道指令对于某特性勋章数是否可用
	/// </summary>
	/// <param name="medalCounts">各特性勋章数量，索引为 <see cref="T:Config.ConfigCells.Character.FeatureMedalType" /></param>
	/// <param name="cmdType">同道指令类型 <see cref="T:Config.TeammateCommand" /></param>
	/// <returns>指定同道指令可用</returns>
	public static bool IsMedalMatchTeammateCommand(IReadOnlyList<int> medalCounts, sbyte cmdType)
	{
		TeammateCommandItem config = TeammateCommand.Instance[cmdType];
		if (config.MedalType < 0)
		{
			return false;
		}
		bool flag;
		switch (config.Type)
		{
		case ETeammateCommandType.Normal:
		case ETeammateCommandType.Advance:
		case ETeammateCommandType.GearMate:
		case ETeammateCommandType.Cricket:
			flag = true;
			break;
		default:
			flag = false;
			break;
		}
		if (!flag)
		{
			return false;
		}
		return medalCounts.GetOrDefault(config.MedalType) >= config.MedalCount;
	}
}

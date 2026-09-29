using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Config;
using GameData.Domains.Item;
using GameData.Utilities;

namespace GameData.Domains.Character;

public static class SharedMethods
{
	private static readonly byte[] LifeSkillAttainmentLevel = new byte[9] { 19, 29, 39, 49, 59, 69, 79, 89, 90 };

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

	public static (int good, int bad) GetFame(IEnumerable<short> features, IEnumerable<FameActionRecord> fameRecords, OrganizationInfo organizationInfo, int currDate, bool isTaiwu)
	{
		(int, int, int, int, bool, bool) ret = GetRawFame(features, fameRecords, organizationInfo, currDate, isTaiwu);
		return (good: ret.Item1 * Math.Max(0, ret.Item3) / 100, bad: ret.Item2 * Math.Max(0, ret.Item4) / 100);
	}

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

	public static int GetCharacterSkillGradeByValue(short value)
	{
		int level;
		for (level = 0; level < LifeSkillAttainmentLevel.Length && value > LifeSkillAttainmentLevel[level]; level++)
		{
		}
		return level;
	}

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

	public static bool CanModifyEquipSlot(short templateId, sbyte slotId, ItemKey itemKey)
	{
		if (ItemTemplateHelper.IsDetachable(itemKey.ItemType, itemKey.TemplateId))
		{
			return CanModifyEquipSlot(templateId, slotId);
		}
		return false;
	}

	public static bool CanBeTaiwu(short templateId)
	{
		if (templateId != -1)
		{
			return Config.Character.Instance[templateId]?.CanBeTaiwu ?? true;
		}
		return true;
	}

	public static bool CanBePossessionBody(short templateId)
	{
		if (templateId != -1)
		{
			return Config.Character.Instance[templateId]?.CanBePossessionBody ?? true;
		}
		return true;
	}

	public static bool CanBePossessionSoul(short templateId)
	{
		if (templateId != -1)
		{
			return Config.Character.Instance[templateId]?.CanBePossessionSoul ?? true;
		}
		return true;
	}

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

	public static bool IsAbleToGrowHair(byte monkType)
	{
		return monkType != 130;
	}

	public static (bool beard1, bool beard2) IsAbleToGrowBeards(short physiologicalAge, sbyte gender, bool transgender, List<short> featureIds)
	{
		if (gender != 1 || transgender || featureIds.Contains(168))
		{
			return (beard1: false, beard2: false);
		}
		return (beard1: physiologicalAge >= GlobalConfig.Instance.AgeShowBeard1, beard2: physiologicalAge >= GlobalConfig.Instance.AgeShowBeard2);
	}

	public static bool IsAbleToGrowBeard1(short physiologicalAge, sbyte gender, bool transgender, List<short> featureIds)
	{
		if (gender == 1 && physiologicalAge >= GlobalConfig.Instance.AgeShowBeard1 && !transgender)
		{
			return !featureIds.Contains(168);
		}
		return false;
	}

	public static bool IsAbleToGrowBeard2(short physiologicalAge, sbyte gender, bool transgender, List<short> featureIds)
	{
		if (gender == 1 && physiologicalAge >= GlobalConfig.Instance.AgeShowBeard2 && !transgender)
		{
			return !featureIds.Contains(168);
		}
		return false;
	}

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

	public static bool IsAbleToGrowEyebrow()
	{
		return true;
	}

	public static sbyte GetInnateFiveElementsType(sbyte birthMonth)
	{
		return Month.Instance[birthMonth].FiveElementsType;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe static bool HasPoisonImmunity(sbyte poisonType, ImmunityMask immunityMask, ref PoisonInts poisonResists)
	{
		if (!immunityMask.IsImmuneToPoison(poisonType))
		{
			return poisonResists.Items[poisonType] >= 1000;
		}
		return true;
	}

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
		case ETeammateCommandType.Chicken:
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

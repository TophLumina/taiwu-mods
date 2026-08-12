using System;
using System.Collections.Generic;
using Config;

namespace GameData.Domains.Character;

/// <summary>
/// 真气加成相关配置辅助工具集
/// </summary>
public static class NeiliAllocationBonusHelper
{
	/// <summary>
	/// 计算功法在所有类型真气加成值（默认 100 真气、100 威力）
	/// </summary>
	/// <param name="config"></param>
	/// <returns></returns>
	public static List<(short propertyId, int value)> CalcDefaultNeiliAllocationBonus(this CombatSkillItem config)
	{
		return config.CalcNeiliAllocationBonus(100, (ECharacterPropertyReferencedType x) => x.CalcNeiliAllocationStepCount(100));
	}

	/// <summary>
	/// 计算功法的所有类型真气加成值
	/// </summary>
	/// <param name="config"></param>
	/// <param name="power"></param>
	/// <param name="stepProvider"></param>
	/// <returns></returns>
	public static List<(short propertyId, int value)> CalcNeiliAllocationBonus(this CombatSkillItem config, int power, Func<ECharacterPropertyReferencedType, int> stepProvider)
	{
		List<(short, int)> addPropertyList = new List<(short, int)>();
		for (ECharacterPropertyReferencedType i = ECharacterPropertyReferencedType.Strength; i < ECharacterPropertyReferencedType.Count; i++)
		{
			int step = stepProvider(i);
			int bonus = config.CalcNeiliAllocationBonus(i, step, power);
			if (bonus > 0)
			{
				addPropertyList.Add(((short)i, bonus));
			}
		}
		return addPropertyList;
	}

	/// <summary>
	/// 计算功法的指定类型真气加成值
	/// </summary>
	/// <param name="config"></param>
	/// <param name="type"></param>
	/// <param name="step"></param>
	/// <param name="power"></param>
	/// <returns></returns>
	public static int CalcNeiliAllocationBonus(this CombatSkillItem config, ECharacterPropertyReferencedType type, int step, int power)
	{
		int valuePerStep = config.GetMapping(type);
		if (valuePerStep <= 0)
		{
			return 0;
		}
		int percent = GlobalConfig.Instance.CombatSkillNeiliAllocationBonusPercent;
		return valuePerStep * step * power * percent / 10000;
	}

	/// <summary>
	/// 计算指定真气时的加成次数
	/// </summary>
	public static int CalcNeiliAllocationStepCount(this ECharacterPropertyReferencedType type, short allNeiliAllocationValue)
	{
		NeiliAllocation allocations = default(NeiliAllocation);
		for (int i = 0; i < 4; i++)
		{
			allocations[i] = allNeiliAllocationValue;
		}
		return type.CalcNeiliAllocationStepCount(allocations, allocations);
	}

	/// <summary>
	/// 计算指定真气时的加成次数
	/// </summary>
	public static int CalcNeiliAllocationStepCount(this ECharacterPropertyReferencedType type, NeiliAllocation allocations, NeiliAllocation allocationEffects)
	{
		int stepCount = 0;
		for (int allocationType = 0; allocationType < 4; allocationType++)
		{
			int stepSize = NeiliAllocationEffect.Instance[allocationType].GetMapping(type);
			if (stepSize > 0)
			{
				short allocation = allocations[allocationType];
				short allocationEffect = allocationEffects[allocationType];
				stepCount += allocation / stepSize + allocationEffect / stepSize;
			}
		}
		return stepCount;
	}

	/// <summary>
	/// 是否攻击值
	/// </summary>
	public static bool IsPenetrate(this ECharacterPropertyReferencedType type)
	{
		if ((uint)(type - 10) <= 1u)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 是否防御值
	/// </summary>
	public static bool IsPenetrateResist(this ECharacterPropertyReferencedType type)
	{
		if ((uint)(type - 16) <= 1u)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 是否命中值
	/// </summary>
	public static bool IsHit(this ECharacterPropertyReferencedType type)
	{
		if ((uint)(type - 6) <= 3u)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 是否化解值
	/// </summary>
	public static bool IsAvoid(this ECharacterPropertyReferencedType type)
	{
		if ((uint)(type - 12) <= 3u)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 是否毒抗值
	/// </summary>
	public static bool IsPoisonResist(this ECharacterPropertyReferencedType type)
	{
		if ((uint)(type - 28) <= 5u)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 尝试转换为毒抗类型
	/// </summary>
	/// <param name="type"></param>
	/// <param name="poisonType"></param>
	/// <returns></returns>
	public static bool TryParsePoisonResist(this ECharacterPropertyReferencedType type, out sbyte poisonType)
	{
		poisonType = type switch
		{
			ECharacterPropertyReferencedType.ResistOfHotPoison => 0, 
			ECharacterPropertyReferencedType.ResistOfGloomyPoison => 1, 
			ECharacterPropertyReferencedType.ResistOfColdPoison => 2, 
			ECharacterPropertyReferencedType.ResistOfRedPoison => 3, 
			ECharacterPropertyReferencedType.ResistOfRottenPoison => 4, 
			ECharacterPropertyReferencedType.ResistOfIllusoryPoison => 5, 
			_ => -1, 
		};
		return poisonType != -1;
	}

	/// <summary>
	/// 是否为主要属性
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	public static bool IsMainAttribute(this ECharacterPropertyReferencedType type)
	{
		if ((uint)type <= 5u)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 是否为次要属性
	/// </summary>
	public static bool IsSubAttribute(this ECharacterPropertyReferencedType type)
	{
		if ((uint)(type - 18) <= 9u)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 某类型是否为技艺造诣
	/// </summary>
	public static bool IsLifeSkillTypeAttainment(this ECharacterPropertyReferencedType type)
	{
		if ((uint)(type - 50) <= 15u)
		{
			return true;
		}
		return false;
	}

	/// <summary>
	/// 获取对应的主属性类型
	/// </summary>
	public static sbyte GetMainAttributeType(this ECharacterPropertyReferencedType type)
	{
		return type switch
		{
			ECharacterPropertyReferencedType.HitRateStrength => 0, 
			ECharacterPropertyReferencedType.HitRateTechnique => 5, 
			ECharacterPropertyReferencedType.HitRateSpeed => 1, 
			ECharacterPropertyReferencedType.HitRateMind => 2, 
			ECharacterPropertyReferencedType.AvoidRateStrength => 0, 
			ECharacterPropertyReferencedType.AvoidRateTechnique => 5, 
			ECharacterPropertyReferencedType.AvoidRateSpeed => 1, 
			ECharacterPropertyReferencedType.AvoidRateMind => 2, 
			ECharacterPropertyReferencedType.PenetrateOfInner => 4, 
			ECharacterPropertyReferencedType.PenetrateOfOuter => 3, 
			ECharacterPropertyReferencedType.PenetrateResistOfInner => 4, 
			ECharacterPropertyReferencedType.PenetrateResistOfOuter => 3, 
			_ => 6, 
		};
	}

	/// <summary>
	/// 获取主属性精纯除数
	/// </summary>
	public static int GetMainAttributeConsummateDivisor(this ECharacterPropertyReferencedType type)
	{
		if (!type.IsHit() && !type.IsAvoid())
		{
			return 4;
		}
		return 6;
	}

	/// <summary>
	/// 获取主属性精纯影响 ID
	/// </summary>
	public static ushort GetMainAttributeConsummateFieldId(this ECharacterPropertyReferencedType type)
	{
		if (type.IsHit())
		{
			return 236;
		}
		if (type.IsAvoid())
		{
			return 237;
		}
		if (!type.IsPenetrate())
		{
			return 239;
		}
		return 238;
	}

	/// <summary>
	/// 尝试转换为主要属性类型
	/// </summary>
	public static bool TryParseMainAttributeType(this ECharacterPropertyReferencedType type, out sbyte mainAttributeType)
	{
		mainAttributeType = type switch
		{
			ECharacterPropertyReferencedType.Strength => 0, 
			ECharacterPropertyReferencedType.Dexterity => 1, 
			ECharacterPropertyReferencedType.Concentration => 2, 
			ECharacterPropertyReferencedType.Vitality => 3, 
			ECharacterPropertyReferencedType.Energy => 4, 
			ECharacterPropertyReferencedType.Intelligence => 5, 
			_ => 6, 
		};
		return mainAttributeType != 6;
	}

	/// <summary>
	/// 尝试转换为武学资质类型
	/// </summary>
	public static bool TryParseCombatSkillQualificationType(this ECharacterPropertyReferencedType type, out sbyte combatSkillType)
	{
		combatSkillType = type switch
		{
			ECharacterPropertyReferencedType.QualificationBlade => 8, 
			ECharacterPropertyReferencedType.QualificationFinger => 4, 
			ECharacterPropertyReferencedType.QualificationLeg => 5, 
			ECharacterPropertyReferencedType.QualificationNeigong => 0, 
			ECharacterPropertyReferencedType.QualificationPolearm => 9, 
			ECharacterPropertyReferencedType.QualificationPosing => 1, 
			ECharacterPropertyReferencedType.QualificationSpecial => 10, 
			ECharacterPropertyReferencedType.QualificationStunt => 2, 
			ECharacterPropertyReferencedType.QualificationSword => 7, 
			ECharacterPropertyReferencedType.QualificationThrow => 6, 
			ECharacterPropertyReferencedType.QualificationWhip => 11, 
			ECharacterPropertyReferencedType.QualificationCombatMusic => 13, 
			ECharacterPropertyReferencedType.QualificationControllableShot => 12, 
			ECharacterPropertyReferencedType.QualificationFistAndPalm => 3, 
			_ => 14, 
		};
		return combatSkillType != 14;
	}

	/// <summary>
	/// 尝试转换为武学资质类型
	/// </summary>
	public static bool TryParseLifeSkillQualificationType(this ECharacterPropertyReferencedType type, out sbyte lifeSkillType)
	{
		lifeSkillType = type switch
		{
			ECharacterPropertyReferencedType.QualificationAppraisal => 5, 
			ECharacterPropertyReferencedType.QualificationBuddhism => 13, 
			ECharacterPropertyReferencedType.QualificationChess => 1, 
			ECharacterPropertyReferencedType.QualificationCooking => 14, 
			ECharacterPropertyReferencedType.QualificationEclectic => 15, 
			ECharacterPropertyReferencedType.QualificationForging => 6, 
			ECharacterPropertyReferencedType.QualificationJade => 11, 
			ECharacterPropertyReferencedType.QualificationMath => 4, 
			ECharacterPropertyReferencedType.QualificationMedicine => 8, 
			ECharacterPropertyReferencedType.QualificationMusic => 0, 
			ECharacterPropertyReferencedType.QualificationPainting => 3, 
			ECharacterPropertyReferencedType.QualificationPoem => 2, 
			ECharacterPropertyReferencedType.QualificationTaoism => 12, 
			ECharacterPropertyReferencedType.QualificationToxicology => 9, 
			ECharacterPropertyReferencedType.QualificationWeaving => 10, 
			ECharacterPropertyReferencedType.QualificationWoodworking => 7, 
			_ => 16, 
		};
		return lifeSkillType != 16;
	}

	/// <summary>
	/// 尝试转换为赋性类型
	/// </summary>
	public static bool TryParsePersonalityType(this ECharacterPropertyReferencedType type, out sbyte personalityType)
	{
		personalityType = type switch
		{
			ECharacterPropertyReferencedType.PersonalityCalm => 0, 
			ECharacterPropertyReferencedType.PersonalityClever => 1, 
			ECharacterPropertyReferencedType.PersonalityEnthusiastic => 2, 
			ECharacterPropertyReferencedType.PersonalityBrave => 3, 
			ECharacterPropertyReferencedType.PersonalityFirm => 4, 
			ECharacterPropertyReferencedType.PersonalityLucky => 5, 
			ECharacterPropertyReferencedType.PersonalityPerceptive => 6, 
			_ => 7, 
		};
		return personalityType != 7;
	}

	/// <summary>
	/// 尝试转换为命中类型
	/// </summary>
	public static bool TryParseHitType(this ECharacterPropertyReferencedType type, out sbyte hitType)
	{
		hitType = type switch
		{
			ECharacterPropertyReferencedType.HitRateStrength => 0, 
			ECharacterPropertyReferencedType.HitRateTechnique => 1, 
			ECharacterPropertyReferencedType.HitRateSpeed => 2, 
			ECharacterPropertyReferencedType.HitRateMind => 3, 
			_ => -1, 
		};
		return hitType != -1;
	}

	/// <summary>
	/// 尝试转换为化解类型
	/// </summary>
	public static bool TryParseAvoidType(this ECharacterPropertyReferencedType type, out sbyte avoidType)
	{
		avoidType = type switch
		{
			ECharacterPropertyReferencedType.AvoidRateStrength => 0, 
			ECharacterPropertyReferencedType.AvoidRateTechnique => 1, 
			ECharacterPropertyReferencedType.AvoidRateSpeed => 2, 
			ECharacterPropertyReferencedType.AvoidRateMind => 3, 
			_ => -1, 
		};
		return avoidType != -1;
	}

	/// <summary>
	/// 尝试转换为攻击类型
	/// </summary>
	public static bool TryParsePenetrateIsInner(this ECharacterPropertyReferencedType type, out bool penetrateIsInner)
	{
		bool num = type.IsPenetrate();
		if (num)
		{
			penetrateIsInner = type == ECharacterPropertyReferencedType.PenetrateOfInner;
			return num;
		}
		penetrateIsInner = false;
		return num;
	}

	/// <summary>
	/// 尝试转换为防御类型
	/// </summary>
	public static bool TryParsePenetrateResistIsInner(this ECharacterPropertyReferencedType type, out bool penetrateResistIsInner)
	{
		bool num = type.IsPenetrateResist();
		if (num)
		{
			penetrateResistIsInner = type == ECharacterPropertyReferencedType.PenetrateResistOfInner;
			return num;
		}
		penetrateResistIsInner = false;
		return num;
	}

	/// <summary>
	/// 获取属性映射值
	/// </summary>
	public static int GetMapping(this NeiliTypeItem config, ECharacterPropertyReferencedType type)
	{
		return type switch
		{
			ECharacterPropertyReferencedType.HitRateStrength => config.HitValues[0], 
			ECharacterPropertyReferencedType.HitRateTechnique => config.HitValues[1], 
			ECharacterPropertyReferencedType.HitRateSpeed => config.HitValues[2], 
			ECharacterPropertyReferencedType.HitRateMind => config.HitValues[3], 
			ECharacterPropertyReferencedType.PenetrateOfOuter => config.Penetrations.Outer, 
			ECharacterPropertyReferencedType.PenetrateOfInner => config.Penetrations.Inner, 
			ECharacterPropertyReferencedType.AvoidRateStrength => config.AvoidValues[0], 
			ECharacterPropertyReferencedType.AvoidRateTechnique => config.AvoidValues[1], 
			ECharacterPropertyReferencedType.AvoidRateSpeed => config.AvoidValues[2], 
			ECharacterPropertyReferencedType.AvoidRateMind => config.AvoidValues[3], 
			ECharacterPropertyReferencedType.PenetrateResistOfOuter => config.PenetrationResists.Outer, 
			ECharacterPropertyReferencedType.PenetrateResistOfInner => config.PenetrationResists.Inner, 
			ECharacterPropertyReferencedType.RecoveryOfStance => config.RecoveryOfStanceAndBreath.Outer, 
			ECharacterPropertyReferencedType.RecoveryOfBreath => config.RecoveryOfStanceAndBreath.Inner, 
			ECharacterPropertyReferencedType.MoveSpeed => config.MoveSpeed, 
			ECharacterPropertyReferencedType.RecoveryOfFlaw => config.RecoveryOfFlaw, 
			ECharacterPropertyReferencedType.CastSpeed => config.CastSpeed, 
			ECharacterPropertyReferencedType.RecoveryOfBlockedAcupoint => config.RecoveryOfBlockedAcupoint, 
			ECharacterPropertyReferencedType.WeaponSwitchSpeed => config.WeaponSwitchSpeed, 
			ECharacterPropertyReferencedType.AttackSpeed => config.AttackSpeed, 
			ECharacterPropertyReferencedType.InnerRatio => config.InnerRatio, 
			ECharacterPropertyReferencedType.RecoveryOfQiDisorder => config.RecoveryOfQiDisorder, 
			ECharacterPropertyReferencedType.ResistOfHotPoison => config.PoisonResists[0], 
			ECharacterPropertyReferencedType.ResistOfGloomyPoison => config.PoisonResists[1], 
			ECharacterPropertyReferencedType.ResistOfColdPoison => config.PoisonResists[2], 
			ECharacterPropertyReferencedType.ResistOfRedPoison => config.PoisonResists[3], 
			ECharacterPropertyReferencedType.ResistOfRottenPoison => config.PoisonResists[4], 
			ECharacterPropertyReferencedType.ResistOfIllusoryPoison => config.PoisonResists[5], 
			_ => 0, 
		};
	}

	/// <summary>
	/// 获取属性映射值
	/// </summary>
	public static int GetMapping(this NeiliAllocationEffectItem config, ECharacterPropertyReferencedType type)
	{
		return type switch
		{
			ECharacterPropertyReferencedType.HitRateStrength => config.HitValues[0], 
			ECharacterPropertyReferencedType.HitRateTechnique => config.HitValues[1], 
			ECharacterPropertyReferencedType.HitRateSpeed => config.HitValues[2], 
			ECharacterPropertyReferencedType.HitRateMind => config.HitValues[3], 
			ECharacterPropertyReferencedType.PenetrateOfOuter => config.Penetrations.Outer, 
			ECharacterPropertyReferencedType.PenetrateOfInner => config.Penetrations.Inner, 
			ECharacterPropertyReferencedType.AvoidRateStrength => config.AvoidValues[0], 
			ECharacterPropertyReferencedType.AvoidRateTechnique => config.AvoidValues[1], 
			ECharacterPropertyReferencedType.AvoidRateSpeed => config.AvoidValues[2], 
			ECharacterPropertyReferencedType.AvoidRateMind => config.AvoidValues[3], 
			ECharacterPropertyReferencedType.PenetrateResistOfOuter => config.PenetrationResists.Outer, 
			ECharacterPropertyReferencedType.PenetrateResistOfInner => config.PenetrationResists.Inner, 
			ECharacterPropertyReferencedType.RecoveryOfStance => config.RecoveryOfStanceAndBreath.Outer, 
			ECharacterPropertyReferencedType.RecoveryOfBreath => config.RecoveryOfStanceAndBreath.Inner, 
			ECharacterPropertyReferencedType.MoveSpeed => config.MoveSpeed, 
			ECharacterPropertyReferencedType.RecoveryOfFlaw => config.RecoveryOfFlaw, 
			ECharacterPropertyReferencedType.CastSpeed => config.CastSpeed, 
			ECharacterPropertyReferencedType.RecoveryOfBlockedAcupoint => config.RecoveryOfBlockedAcupoint, 
			ECharacterPropertyReferencedType.WeaponSwitchSpeed => config.WeaponSwitchSpeed, 
			ECharacterPropertyReferencedType.AttackSpeed => config.AttackSpeed, 
			ECharacterPropertyReferencedType.InnerRatio => config.InnerRatio, 
			ECharacterPropertyReferencedType.RecoveryOfQiDisorder => config.RecoveryOfQiDisorder, 
			ECharacterPropertyReferencedType.ResistOfHotPoison => config.PoisonResists[0], 
			ECharacterPropertyReferencedType.ResistOfGloomyPoison => config.PoisonResists[1], 
			ECharacterPropertyReferencedType.ResistOfColdPoison => config.PoisonResists[2], 
			ECharacterPropertyReferencedType.ResistOfRedPoison => config.PoisonResists[3], 
			ECharacterPropertyReferencedType.ResistOfRottenPoison => config.PoisonResists[4], 
			ECharacterPropertyReferencedType.ResistOfIllusoryPoison => config.PoisonResists[5], 
			_ => 0, 
		};
	}

	/// <summary>
	/// 获取属性映射值
	/// </summary>
	public static int GetMapping(this CombatSkillItem config, ECharacterPropertyReferencedType type)
	{
		return type switch
		{
			ECharacterPropertyReferencedType.HitRateStrength => config.HitValues[0], 
			ECharacterPropertyReferencedType.HitRateTechnique => config.HitValues[1], 
			ECharacterPropertyReferencedType.HitRateSpeed => config.HitValues[2], 
			ECharacterPropertyReferencedType.HitRateMind => config.HitValues[3], 
			ECharacterPropertyReferencedType.PenetrateOfOuter => config.Penetrations.Outer, 
			ECharacterPropertyReferencedType.PenetrateOfInner => config.Penetrations.Inner, 
			ECharacterPropertyReferencedType.AvoidRateStrength => config.AvoidValues[0], 
			ECharacterPropertyReferencedType.AvoidRateTechnique => config.AvoidValues[1], 
			ECharacterPropertyReferencedType.AvoidRateSpeed => config.AvoidValues[2], 
			ECharacterPropertyReferencedType.AvoidRateMind => config.AvoidValues[3], 
			ECharacterPropertyReferencedType.PenetrateResistOfOuter => config.PenetrationResists.Outer, 
			ECharacterPropertyReferencedType.PenetrateResistOfInner => config.PenetrationResists.Inner, 
			ECharacterPropertyReferencedType.RecoveryOfStance => config.RecoveryOfStanceAndBreath.Outer, 
			ECharacterPropertyReferencedType.RecoveryOfBreath => config.RecoveryOfStanceAndBreath.Inner, 
			ECharacterPropertyReferencedType.MoveSpeed => config.MoveSpeed, 
			ECharacterPropertyReferencedType.RecoveryOfFlaw => config.RecoveryOfFlaw, 
			ECharacterPropertyReferencedType.CastSpeed => config.CastSpeed, 
			ECharacterPropertyReferencedType.RecoveryOfBlockedAcupoint => config.RecoveryOfBlockedAcupoint, 
			ECharacterPropertyReferencedType.WeaponSwitchSpeed => config.WeaponSwitchSpeed, 
			ECharacterPropertyReferencedType.AttackSpeed => config.AttackSpeed, 
			ECharacterPropertyReferencedType.InnerRatio => config.InnerRatio, 
			ECharacterPropertyReferencedType.RecoveryOfQiDisorder => config.RecoveryOfQiDisorder, 
			ECharacterPropertyReferencedType.ResistOfHotPoison => config.PoisonResists[0], 
			ECharacterPropertyReferencedType.ResistOfGloomyPoison => config.PoisonResists[1], 
			ECharacterPropertyReferencedType.ResistOfColdPoison => config.PoisonResists[2], 
			ECharacterPropertyReferencedType.ResistOfRedPoison => config.PoisonResists[3], 
			ECharacterPropertyReferencedType.ResistOfRottenPoison => config.PoisonResists[4], 
			ECharacterPropertyReferencedType.ResistOfIllusoryPoison => config.PoisonResists[5], 
			_ => 0, 
		};
	}

	/// <summary>
	/// 获取属性映射值
	/// </summary>
	public static int GetMapping(this SkillBreakPageEffectImplementItem config, ECharacterPropertyReferencedType type)
	{
		return type switch
		{
			ECharacterPropertyReferencedType.HitRateStrength => config.HitValues[0], 
			ECharacterPropertyReferencedType.HitRateTechnique => config.HitValues[1], 
			ECharacterPropertyReferencedType.HitRateSpeed => config.HitValues[2], 
			ECharacterPropertyReferencedType.HitRateMind => config.HitValues[3], 
			ECharacterPropertyReferencedType.PenetrateOfOuter => config.Penetrations.Outer, 
			ECharacterPropertyReferencedType.PenetrateOfInner => config.Penetrations.Inner, 
			ECharacterPropertyReferencedType.AvoidRateStrength => config.AvoidValues[0], 
			ECharacterPropertyReferencedType.AvoidRateTechnique => config.AvoidValues[1], 
			ECharacterPropertyReferencedType.AvoidRateSpeed => config.AvoidValues[2], 
			ECharacterPropertyReferencedType.AvoidRateMind => config.AvoidValues[3], 
			ECharacterPropertyReferencedType.PenetrateResistOfOuter => config.PenetrationResists.Outer, 
			ECharacterPropertyReferencedType.PenetrateResistOfInner => config.PenetrationResists.Inner, 
			ECharacterPropertyReferencedType.RecoveryOfStance => config.RecoveryOfStance, 
			ECharacterPropertyReferencedType.RecoveryOfBreath => config.RecoveryOfBreath, 
			ECharacterPropertyReferencedType.MoveSpeed => config.MoveSpeed, 
			ECharacterPropertyReferencedType.RecoveryOfFlaw => config.RecoveryOfFlaw, 
			ECharacterPropertyReferencedType.CastSpeed => config.CastSpeed, 
			ECharacterPropertyReferencedType.RecoveryOfBlockedAcupoint => config.RecoveryOfAcupoint, 
			ECharacterPropertyReferencedType.WeaponSwitchSpeed => config.SwitchSpeed, 
			ECharacterPropertyReferencedType.AttackSpeed => config.AttackSpeed, 
			ECharacterPropertyReferencedType.InnerRatio => config.InnerRatio, 
			ECharacterPropertyReferencedType.RecoveryOfQiDisorder => config.RecoveryOfQiDisorder, 
			_ => 0, 
		};
	}
}

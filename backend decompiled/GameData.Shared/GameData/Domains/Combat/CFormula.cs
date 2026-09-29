using System;
using System.Runtime.CompilerServices;
using Config;
using GameData.Combat.Math;
using GameData.Domains.Character;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat;

public static class CFormula
{
	public enum EAttackType
	{
		Normal,
		Unlock,
		Spirit,
		Skill,
		MindSkill
	}

	private static int BaseCriticalOdds => GlobalConfig.Instance.BaseCriticalOdds;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcHitOdds(int hitValue, int avoidValue)
	{
		return (int)Math.Clamp((long)hitValue * 100L / Math.Max(avoidValue, 1) / ((hitValue >= avoidValue) ? 1 : 2), 0L, 2147483647L);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcPursueOdds(int weaponFactor, CValuePercent weaponPower, int pursueCount)
	{
		return weaponFactor * weaponPower * (200 - pursueCount * 10 - pursueCount * pursueCount * 5) / 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcCriticalOdds(int hitOdds)
	{
		return 10 + hitOdds / 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcCriticalPercent(int hitOdds)
	{
		return 25 + hitOdds / (50 + BaseCriticalOdds * hitOdds / 10000);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcStrike(int penetrate, int penetrateResist, int penetrateRatio)
	{
		long num = (long)penetrate * 100L;
		penetrateResist = penetrateResist * penetrateRatio / 100 * (150 + Math.Abs(penetrateRatio - 50)) / 200;
		return (int)Math.Clamp(num / Math.Max(penetrateResist, 1) / ((penetrate >= penetrateResist) ? 1 : 2), 0L, 2147483647L);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcDamageValue(long damageValue, long strike, long penetrateRatio, long attackOdds)
	{
		return (int)Math.Clamp(damageValue * penetrateRatio / 100 * (100 + strike * 100 / (100 + attackOdds * strike / 10000)) / 100, 0L, 2147483647L);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcOneDamageValue(int damageValue, int penetrate, int penetrateResist, int penetrateRatio, int attackOdds)
	{
		int attack = FormulaCalcStrike(penetrate, penetrateResist, penetrateRatio);
		return FormulaCalcDamageValue(damageValue, attack, penetrateRatio, attackOdds);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcWeaponArmorFactor(int factor, int attack, int defense)
	{
		if (attack <= defense || factor <= 0)
		{
			return factor;
		}
		return factor - factor * Math.Min(20 + 10 * attack / Math.Max(defense, 1), 100) / 100;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcRopeHitOdds(sbyte baseHitOdds, sbyte requireMarkCount, int totalHit, int totalAvoid, int bonus, int markCount)
	{
		return totalHit * (baseHitOdds + (markCount - requireMarkCount) * baseHitOdds / 2) / totalAvoid * (100 + bonus) / 100;
	}

	public static int CalcBreathRecoverValue(CValuePercent breathRecoverSpeed)
	{
		sbyte baseValue = GlobalConfig.Instance.RecoverBreathBaseValue;
		return baseValue + baseValue * breathRecoverSpeed / 4;
	}

	public static int CalcStanceRecoverValue(CValuePercent stanceRecoverSpeed, int weaponAddValue, sbyte attackPreparePointCost, bool isPursue)
	{
		sbyte recoverStanceBaseValue = GlobalConfig.Instance.RecoverStanceBaseValue;
		int divisor = (isPursue ? GlobalConfig.Instance.RecoverStanceDivisorByWeapon[attackPreparePointCost] : 4);
		return recoverStanceBaseValue + weaponAddValue + weaponAddValue * stanceRecoverSpeed / divisor;
	}

	public static int CalcSkillPrepareSpeed(int skillPrepareSpeed)
	{
		return 60 + MathUtils.Max(skillPrepareSpeed, 0) * 30 / 100;
	}

	public static int CalcAttackStartupOrRecoveryWeaponFrame(int weight, int baseWeight, int baseFrame)
	{
		return baseFrame * (50 + MathUtils.Max(weight, 1) * 50 / MathUtils.Max(baseWeight, 1)) / 100;
	}

	public static int CalcAttackStartupOrRecoveryFrame(int attackSpeed, int weaponFrame)
	{
		CValuePercent factor = GlobalConfig.Instance.AttackSpeedFactor;
		return MathUtils.Max((attackSpeed >= 100) ? (weaponFrame - weaponFrame * attackSpeed * factor / 1000) : (weaponFrame + weaponFrame * (100 - attackSpeed) * factor / 100), 1);
	}

	public static int CalcWeaponCdFrameSpeed(int switchSpeed, int weight)
	{
		int formulaWeight = GlobalConfig.Instance.WeaponCdExtraWeight + weight;
		return 10 + 500 * switchSpeed / 100 / MathUtils.Max(50 + formulaWeight / 10, 1);
	}

	public static int CalcEquipmentMasteryAffectOdds(int baseAffectOdds, int equipmentMastery)
	{
		if (equipmentMastery > 100)
		{
			return baseAffectOdds * (100 + equipmentMastery / 10) / 100;
		}
		return baseAffectOdds * equipmentMastery / 100;
	}

	public static int CalcNeiliAllocationAutoRecoverProgress(int recoveryOfQiDisorder, int currValue, int originValue)
	{
		if (currValue <= originValue)
		{
			return MathUtils.Max((120 + 12 * recoveryOfQiDisorder / 100) * (100 + (200 - currValue * 200 / MathUtils.Max(originValue, 1))) / 100, 1);
		}
		return MathUtils.Max((60 - 6 * recoveryOfQiDisorder / 100) * currValue / MathUtils.Max(originValue, 1), 1);
	}

	public static int CalcMoveCd(int moveSpeed)
	{
		int moveCd = MoveSpecialConstants.MoveCdBase;
		if (moveSpeed < 100)
		{
			return moveCd + MoveSpecialConstants.MoveCdFactor * (33 - moveSpeed / 3) / 100;
		}
		return moveCd - MoveSpecialConstants.MoveCdFactor * moveSpeed / (MoveSpecialConstants.MoveCdDivisorBase + moveSpeed * MoveSpecialConstants.MoveCdDivisorFactor / 100);
	}

	public static int CalcJumpSpeed(int moveSpeed)
	{
		return 100 + 10 * moveSpeed / 100;
	}

	public static int CalcFlawOrAcupointRecoveryValue(int recoverSpeed)
	{
		return GlobalConfig.Instance.FlawOrAcupointReduceBaseTime + recoverSpeed / 2;
	}

	public static OuterAndInnerInts FormulaCalcMixedDamageValue(int damageValue, int attackOdds, sbyte innerRatio, int outerPenetrate, int outerPenetrateResist, int innerPenetrate, int innerPenetrateResist)
	{
		return FormulaCalcMixedDamageValue(damageValue, attackOdds, innerRatio, new OuterAndInnerInts(outerPenetrate, innerPenetrate), new OuterAndInnerInts(outerPenetrateResist, innerPenetrateResist));
	}

	public static OuterAndInnerInts FormulaCalcMixedDamageValue(int damageValue, int attackOdds, sbyte innerRatio, OuterAndInnerInts penetrate, OuterAndInnerInts penetrateResist)
	{
		int outerRatio = 100 - innerRatio;
		int outerDamage = 0;
		if (outerRatio > 0)
		{
			outerDamage = FormulaCalcOneDamageValue(damageValue, penetrate.Outer, penetrateResist.Outer, outerRatio, attackOdds);
		}
		int innerDamage = 0;
		if (innerRatio > 0)
		{
			innerDamage = FormulaCalcOneDamageValue(damageValue, penetrate.Inner, penetrateResist.Inner, innerRatio, attackOdds);
		}
		return new OuterAndInnerInts(outerDamage, innerDamage);
	}

	public static CValuePercentBonus CalcConsummateChangeDamagePercent(sbyte attackerConsummate, sbyte defenderConsummate)
	{
		ConsummateLevelItem attackerConfig = ConsummateLevel.Instance[attackerConsummate];
		ConsummateLevelItem defenderConfig = ConsummateLevel.Instance[defenderConsummate];
		if (attackerConsummate > defenderConsummate)
		{
			return attackerConfig.DamageAddPercent - defenderConfig.DamageAddPercent;
		}
		if (defenderConsummate > attackerConsummate)
		{
			return defenderConfig.DamageDecPercent - attackerConfig.DamageDecPercent;
		}
		return 0;
	}

	public static sbyte CalcFlawOrAcupointLevel(int hitOdds, bool isFlaw)
	{
		short[] oddsList = (isFlaw ? GlobalConfig.Instance.FlawLevelRequireHitOdds : GlobalConfig.Instance.AcupointLevelRequireHitOdds);
		for (int i = oddsList.Length - 1; i >= 0; i--)
		{
			if (hitOdds >= oddsList[i])
			{
				return (sbyte)i;
			}
		}
		return -1;
	}

	public static CValuePercentBonus CalcFlawDamageBonus(int flawCount, int extraFlawCount)
	{
		return (CValuePercentBonus)((flawCount > 0) ? GlobalConfig.Instance.FlawAddDamagePercent : 0) + (CValuePercentBonus)(extraFlawCount * GlobalConfig.Instance.ExtraFlawAddDamagePercent);
	}

	public static int CalcBaseDamageValue(EAttackType type, sbyte attackPointCost)
	{
		switch (type)
		{
		case EAttackType.Normal:
			return GlobalConfig.Instance.BaseAttackDamageValue + GlobalConfig.Instance.AddBaseAttackDamageValue * attackPointCost;
		case EAttackType.Unlock:
			return GlobalConfig.Instance.BaseUnlockDamageValue;
		case EAttackType.Spirit:
			return GlobalConfig.Instance.BaseSpiritDamageValue;
		case EAttackType.Skill:
		case EAttackType.MindSkill:
			return GlobalConfig.Instance.BaseSkillDamageValue;
		default:
			throw new ArgumentOutOfRangeException("type", type, null);
		}
	}

	public static int CalcBaseAttackOdds(EAttackType type)
	{
		return type switch
		{
			EAttackType.Normal => GlobalConfig.Instance.BaseAttackOdds, 
			EAttackType.Unlock => GlobalConfig.Instance.BaseUnlockAttackOdds, 
			EAttackType.Spirit => GlobalConfig.Instance.BaseSpiritAttackOdds, 
			EAttackType.Skill => GlobalConfig.Instance.BaseSkillAttackOdds, 
			EAttackType.MindSkill => GlobalConfig.Instance.BaseMindAttackOdds, 
			_ => throw new ArgumentOutOfRangeException("type", type, null), 
		};
	}

	public static sbyte CalcRopeRequireMinMarkCount(CombatType combatType)
	{
		return combatType switch
		{
			CombatType.Beat => GlobalConfig.Instance.RopeRequireMinMarkCountInBeat, 
			CombatType.Die => GlobalConfig.Instance.RopeRequireMinMarkCountInDie, 
			_ => sbyte.MaxValue, 
		};
	}

	public static sbyte CalcRopeBaseHitOdds(CombatType combatType)
	{
		return combatType switch
		{
			CombatType.Beat => GlobalConfig.Instance.RopeBaseHitOddsInBeat, 
			CombatType.Die => GlobalConfig.Instance.RopeBaseHitOddsInDie, 
			_ => sbyte.MinValue, 
		};
	}

	public static byte CalcMobilityLevel(int mobilityValue)
	{
		if (mobilityValue <= MoveSpecialConstants.MaxMobility * 25 / 100)
		{
			return 0;
		}
		if (mobilityValue < MoveSpecialConstants.MaxMobility * 75 / 100)
		{
			return 1;
		}
		return 2;
	}

	public static int CalcHealInjuryRequireAttainment(int injuryCount)
	{
		if (injuryCount <= 0)
		{
			return 0;
		}
		return GlobalConfig.Instance.HealInjuryAttainment[injuryCount - 1];
	}

	public static CValuePercent CalcHealInjuryValue(int doctorAttainment, int requireAttainment)
	{
		if (doctorAttainment < requireAttainment)
		{
			return 0;
		}
		return 100 + doctorAttainment - requireAttainment;
	}

	public static int CalcHealPoisonRequireAttainment(int poisonLevel)
	{
		if (poisonLevel <= 0)
		{
			return 0;
		}
		return GlobalConfig.Instance.HealPoisonAttainment[poisonLevel - 1];
	}

	public static int CalcHealPoisonValue(int doctorAttainment, int requireAttainment)
	{
		if (doctorAttainment < requireAttainment)
		{
			return 0;
		}
		return doctorAttainment * GlobalConfig.Instance.HealPoisonAttainmentPercent / 100;
	}

	public static int CalcHealQiDisorderRequireAttainment(sbyte qiDisorderLevel)
	{
		if (qiDisorderLevel > 0)
		{
			return GlobalConfig.Instance.HealQiDisorderAttainment[qiDisorderLevel - 1];
		}
		return 0;
	}

	public static int CalcHealQiDisorderValue(int doctorAttainment, int requireAttainment)
	{
		if (doctorAttainment < requireAttainment)
		{
			return 0;
		}
		CValuePercent percent = GlobalConfig.Instance.HealQiDisorderAttainmentPercent;
		return doctorAttainment * percent;
	}

	public static int CalcHealHealthRequireAttainment(EHealthType healthType)
	{
		return healthType switch
		{
			EHealthType.Sick => GlobalConfig.Instance.HealHealthAttainment[0], 
			EHealthType.Weak => GlobalConfig.Instance.HealHealthAttainment[1], 
			EHealthType.CriticallyIll => GlobalConfig.Instance.HealHealthAttainment[2], 
			EHealthType.Dying => GlobalConfig.Instance.HealHealthAttainment[3], 
			EHealthType.Unknown => int.MaxValue, 
			_ => 0, 
		};
	}

	public static int CalcHealHealthValue(int doctorAttainment, int requireAttainment)
	{
		if (doctorAttainment < requireAttainment)
		{
			return 0;
		}
		CValuePercent percent = GlobalConfig.Instance.HealHealthAttainmentPercent;
		return doctorAttainment * percent;
	}

	public static int CalcPartRepairDurabilityValue(sbyte grade, int attainment, int current, int costed)
	{
		short require = GlobalConfig.Instance.RepairAttainments[grade];
		if (current > 0)
		{
			require /= 2;
		}
		CValuePercent repairPercent = attainment * 50 / MathUtils.Max(require, 1);
		return MathUtils.Max(costed * repairPercent, 1);
	}

	public static int CalcMixPoisonAffectCount(int poisonMarkCount)
	{
		return MathUtils.Clamp((poisonMarkCount - 1) / 2, 1, 4);
	}

	public static int CalcMainCharacterWisdomMultiplier(int teammateCharCount)
	{
		return 4 - teammateCharCount;
	}

	public static CValuePercent CalcPowerFactor(int power)
	{
		return power * GlobalConfig.Instance.PowerDamageMax / (power + GlobalConfig.Instance.PowerDamageOffset);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short RandomCalcDisorderOfQiDelta(IRandomSource random, int delta)
	{
		return (short)(delta * random.Next(GlobalConfig.Instance.TeaWineEffectDisorderOfQiDelta[0], GlobalConfig.Instance.TeaWineEffectDisorderOfQiDelta[1] + 1) / 100);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int max, int min) RandomCalcDisorderOfQiRange(int delta)
	{
		int valDec = delta * GlobalConfig.Instance.TeaWineEffectDisorderOfQiDelta[0] / 100;
		int valAdd = delta * GlobalConfig.Instance.TeaWineEffectDisorderOfQiDelta[1] / 100;
		return (max: Math.Max(valAdd, valDec), min: Math.Min(valAdd, valDec));
	}
}

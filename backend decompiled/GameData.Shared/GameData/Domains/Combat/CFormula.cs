using System;
using System.Runtime.CompilerServices;
using Config;
using GameData.Combat.Math;
using GameData.Domains.Character;
using GameData.Utilities;
using Redzen.Random;

namespace GameData.Domains.Combat;

/// <summary>
/// 战斗公式存储类
/// </summary>
public static class CFormula
{
	/// <summary>
	/// 攻击类型
	/// </summary>
	public enum EAttackType
	{
		/// <summary>
		/// 普攻
		/// </summary>
		Normal,
		/// <summary>
		/// 解封
		/// </summary>
		Unlock,
		/// <summary>
		/// 灵性
		/// </summary>
		Spirit,
		/// <summary>
		/// 摧破
		/// </summary>
		Skill,
		/// <summary>
		/// 心神摧破
		/// </summary>
		MindSkill
	}

	/// <inheritdoc cref="F:GlobalConfig.BaseCriticalOdds" />
	private static int BaseCriticalOdds => GlobalConfig.Instance.BaseCriticalOdds;

	/// <summary>
	/// 计算命中概率的公式
	/// </summary>
	/// <param name="hitValue">命中值<see cref="!:GameData.Domains.Character.Character.CalcHitValues" /></param>
	/// <param name="avoidValue">化解值<see cref="!:GameData.Domains.Character.Character.CalcAvoidValues" /></param>
	/// <returns>命中概率</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcHitOdds(int hitValue, int avoidValue)
	{
		return (int)Math.Clamp((long)hitValue * 100L / Math.Max(avoidValue, 1) / ((hitValue >= avoidValue) ? 1 : 2), 0L, 2147483647L);
	}

	/// <summary>
	/// 计算追击概率的公式
	/// </summary>
	/// <param name="weaponFactor">武器追击系数<see cref="!:GameData.Domains.Item.Weapon.GetPursueAttackFactor" /></param>
	/// <param name="weaponPower">武器发挥度<see cref="!:GameData.Domains.Character.CharacterDomain.GetItemPower" /></param>
	/// <param name="pursueCount">追击次数，首次攻击为零，后续每次追击加一<see cref="!:GameData.Domains.Combat.CombatCharacter.PursueAttackCount" /></param>
	/// <returns>追击概率</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcPursueOdds(int weaponFactor, CValuePercent weaponPower, int pursueCount)
	{
		return weaponFactor * weaponPower * (200 - pursueCount * 10 - pursueCount * pursueCount * 5) / 100;
	}

	/// <summary>
	/// 计算暴击概率的公式
	/// </summary>
	/// <param name="hitOdds">命中概率<see cref="M:GameData.Domains.Combat.CFormula.FormulaCalcHitOdds(System.Int32,System.Int32)" /></param>
	/// <returns>暴击概率</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcCriticalOdds(int hitOdds)
	{
		return 10 + hitOdds / 100;
	}

	/// <summary>
	/// 计算暴击加成伤害百分比的公式
	/// </summary>
	/// <param name="hitOdds">命中概率<see cref="M:GameData.Domains.Combat.CFormula.FormulaCalcHitOdds(System.Int32,System.Int32)" /></param>
	/// <returns>暴击加成伤害百分比，直接乘以原始伤害</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcCriticalPercent(int hitOdds)
	{
		return 25 + hitOdds / (50 + BaseCriticalOdds * hitOdds / 10000);
	}

	/// <summary>
	/// 计算打击倍率的公式
	/// </summary>
	/// <param name="penetrate">攻击值（破体/气）<see cref="!:GameData.Domains.Character.Character.CalcPenetrations" /></param>
	/// <param name="penetrateResist">防御值（御体/气）<see cref="!:GameData.Domains.Character.Character.CalcPenetrationResists" /></param>
	/// <param name="penetrateRatio">内外比例分布，内伤为 innerRatio，外伤为 (100 - innerRatio)</param>
	/// <returns>打击倍率，用于后续公式计算伤害</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcStrike(int penetrate, int penetrateResist, int penetrateRatio)
	{
		long num = (long)penetrate * 100L;
		penetrateResist = penetrateResist * penetrateRatio / 100 * (150 + Math.Abs(penetrateRatio - 50)) / 200;
		return (int)Math.Clamp(num / Math.Max(penetrateResist, 1) / ((penetrate >= penetrateResist) ? 1 : 2), 0L, 2147483647L);
	}

	/// <summary>
	/// 计算攻击防御的公式
	/// </summary>
	/// <param name="damageValue">基础伤害值，目前同时计算了破绽增伤与威力成数<see cref="M:GameData.Domains.Combat.CFormula.CalcBaseDamageValue(GameData.Domains.Combat.CFormula.EAttackType,System.SByte)" /></param>
	/// <param name="strike">打击倍率<see cref="M:GameData.Domains.Combat.CFormula.FormulaCalcStrike(System.Int32,System.Int32,System.Int32)" /></param>
	/// <param name="penetrateRatio">内外比例分布，内伤为 innerRatio，外伤为 (100 - innerRatio)</param>
	/// <param name="attackOdds">衰减系数<see cref="M:GameData.Domains.Combat.CFormula.CalcBaseAttackOdds(GameData.Domains.Combat.CFormula.EAttackType)" /></param>
	/// <returns>应用攻防后的伤害值</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcDamageValue(long damageValue, long strike, long penetrateRatio, long attackOdds)
	{
		return (int)Math.Clamp(damageValue * penetrateRatio / 100 * (100 + strike * 100 / (100 + attackOdds * strike / 10000)) / 100, 0L, 2147483647L);
	}

	/// <summary>
	/// 计算伤害的公式
	/// </summary>
	/// <param name="damageValue">基础伤害值，目前同时计算了破绽增伤与威力成数<see cref="M:GameData.Domains.Combat.CFormula.CalcBaseDamageValue(GameData.Domains.Combat.CFormula.EAttackType,System.SByte)" /></param>
	/// <param name="penetrate">攻击值（破体/气）<see cref="!:GameData.Domains.Character.Character.CalcPenetrations" /></param>
	/// <param name="penetrateResist">防御值（御体/气）<see cref="!:GameData.Domains.Character.Character.CalcPenetrationResists" /></param>
	/// <param name="penetrateRatio">内外比例分布，内伤为 innerRatio，外伤为 (100 - innerRatio)</param>
	/// <param name="attackOdds">衰减系数<see cref="M:GameData.Domains.Combat.CFormula.CalcBaseAttackOdds(GameData.Domains.Combat.CFormula.EAttackType)" /></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcOneDamageValue(int damageValue, int penetrate, int penetrateResist, int penetrateRatio, int attackOdds)
	{
		int attack = FormulaCalcStrike(penetrate, penetrateResist, penetrateRatio);
		return FormulaCalcDamageValue(damageValue, attack, penetrateRatio, attackOdds);
	}

	/// <summary>
	/// 武器破甲大于防御坚韧时减少防具加成系数公式
	/// 防具破刃大于武器坚韧时减少武器加成系数公式
	/// </summary>
	/// <param name="factor">基础系数</param>
	/// <param name="attack">破甲/刃</param>
	/// <param name="defense">坚韧</param>
	/// <returns>计算后系数</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcWeaponArmorFactor(int factor, int attack, int defense)
	{
		if (attack <= defense || factor <= 0)
		{
			return factor;
		}
		return factor - factor * Math.Min(20 + 10 * attack / Math.Max(defense, 1), 100) / 100;
	}

	/// <summary>
	/// 计算绑架成功概率
	/// </summary>
	/// <param name="baseHitOdds">基础命中率<see cref="M:GameData.Domains.Combat.CFormula.CalcRopeBaseHitOdds(GameData.Domains.Combat.CombatType)" /></param>
	/// <param name="requireMarkCount">所需最少标记数<see cref="M:GameData.Domains.Combat.CFormula.CalcRopeRequireMinMarkCount(GameData.Domains.Combat.CombatType)" /></param>
	/// <param name="totalHit">发起方总命中</param>
	/// <param name="totalAvoid">作用方总化解</param>
	/// <param name="bonus">装备带来的总加成</param>
	/// <param name="markCount">作用方总伤势标记数</param>
	/// <returns>命中率，不含前置判定规则</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int FormulaCalcRopeHitOdds(sbyte baseHitOdds, sbyte requireMarkCount, int totalHit, int totalAvoid, int bonus, int markCount)
	{
		return totalHit * (baseHitOdds + (markCount - requireMarkCount) * baseHitOdds / 2) / totalAvoid * (100 + bonus) / 100;
	}

	/// <summary>
	/// 计算提气恢复值
	/// </summary>
	/// <param name="breathRecoverSpeed">提气恢复属性<see cref="!:GameData.Domains.Character.Character.CalcRecoveryOfStanceAndBreath" /></param>
	/// <returns>提气恢复值</returns>
	public static int CalcBreathRecoverValue(CValuePercent breathRecoverSpeed)
	{
		sbyte baseValue = GlobalConfig.Instance.RecoverBreathBaseValue;
		return baseValue + baseValue * breathRecoverSpeed / 4;
	}

	/// <summary>
	/// 计算架势恢复值
	/// </summary>
	/// <param name="stanceRecoverSpeed">架势恢复属性<see cref="!:GameData.Domains.Character.Character.CalcRecoveryOfStanceAndBreath" /></param>
	/// <param name="weaponAddValue">武器配置增加的值，含追击与受击系数计算<see cref="!:GameData.Domains.Combat.CombatDomain.CalcNormalAttack" /></param>
	/// <param name="attackPreparePointCost">武器当前消耗的攻势数<see cref="!:GameData.Domains.Item.Weapon.GetAttackPreparePointCost" /></param>
	/// <param name="isPursue">该次恢复是否是追击<see cref="!:GameData.Domains.Combat.CombatCharacter.PursueAttackCount" /></param>
	/// <returns>架势恢复值</returns>
	public static int CalcStanceRecoverValue(CValuePercent stanceRecoverSpeed, int weaponAddValue, sbyte attackPreparePointCost, bool isPursue)
	{
		sbyte recoverStanceBaseValue = GlobalConfig.Instance.RecoverStanceBaseValue;
		int divisor = (isPursue ? GlobalConfig.Instance.RecoverStanceDivisorByWeapon[attackPreparePointCost] : 4);
		return recoverStanceBaseValue + weaponAddValue + weaponAddValue * stanceRecoverSpeed / divisor;
	}

	/// <summary>
	/// 计算施展进度值
	/// </summary>
	/// <param name="skillPrepareSpeed">施展速度属性<see cref="!:GameData.Domains.Character.Character.GetCastSpeed" /></param>
	/// <returns>施展进度值</returns>
	public static int CalcSkillPrepareSpeed(int skillPrepareSpeed)
	{
		return 60 + MathUtils.Max(skillPrepareSpeed, 0) * 30 / 100;
	}

	/// <summary>
	/// 计算重量影响后的基础普攻前后摇帧
	/// </summary>
	/// <param name="weight">兵器当前重量<see cref="!:GameData.Domains.Item.Weapon.GetWeight" /></param>
	/// <param name="baseWeight">兵器配置重量<see cref="!:GameData.Domains.Item.Weapon.GetBaseWeight" /></param>
	/// <param name="baseFrame">配置基础前后摇帧<see cref="F:Config.WeaponItem.BaseStartupFrames" /> <see cref="F:Config.WeaponItem.BaseRecoveryFrames" /></param>
	/// <returns>重量影响后的基础普攻前后摇帧</returns>
	public static int CalcAttackStartupOrRecoveryWeaponFrame(int weight, int baseWeight, int baseFrame)
	{
		return baseFrame * (50 + MathUtils.Max(weight, 1) * 50 / MathUtils.Max(baseWeight, 1)) / 100;
	}

	/// <summary>
	/// 计算普攻前后摇帧
	/// </summary>
	/// <param name="attackSpeed">攻击速度属性<see cref="!:GameData.Domains.Character.Character.GetAttackSpeed" /></param>
	/// <param name="weaponFrame">武器前后摇帧数<see cref="M:GameData.Domains.Combat.CFormula.CalcAttackStartupOrRecoveryWeaponFrame(System.Int32,System.Int32,System.Int32)" /></param>
	/// <returns>普攻前摇帧</returns>
	public static int CalcAttackStartupOrRecoveryFrame(int attackSpeed, int weaponFrame)
	{
		CValuePercent factor = GlobalConfig.Instance.AttackSpeedFactor;
		return MathUtils.Max((attackSpeed >= 100) ? (weaponFrame - weaponFrame * attackSpeed * factor / 1000) : (weaponFrame + weaponFrame * (100 - attackSpeed) * factor / 100), 1);
	}

	/// <summary>
	/// 计算切换武器冷却速度的公式
	/// </summary>
	/// <param name="switchSpeed">武具运用属性<see cref="!:GameData.Domains.Character.Character.GetWeaponSwitchSpeed" /></param>
	/// <param name="weight">武器重量<see cref="!:GameData.Domains.Item.ItemBase.GetWeight" /></param>
	/// <returns>武器冷却恢复量</returns>
	public static int CalcWeaponCdFrameSpeed(int switchSpeed, int weight)
	{
		int formulaWeight = GlobalConfig.Instance.WeaponCdExtraWeight + weight;
		return 10 + 500 * switchSpeed / 100 / MathUtils.Max(50 + formulaWeight / 10, 1);
	}

	/// <summary>
	/// 计算武具效果生效概率
	/// </summary>
	/// <param name="baseAffectOdds">基础生效概率</param>
	/// <param name="equipmentMastery">武具运用属性<see cref="!:GameData.Domains.Character.Character.GetWeaponSwitchSpeed" /></param>
	/// <returns>武具效果生效概率</returns>
	public static int CalcEquipmentMasteryAffectOdds(int baseAffectOdds, int equipmentMastery)
	{
		if (equipmentMastery > 100)
		{
			return baseAffectOdds * (100 + equipmentMastery / 10) / 100;
		}
		return baseAffectOdds * equipmentMastery / 100;
	}

	/// <summary>
	/// 计算调息吐纳属性影响的真气变化进度
	/// </summary>
	/// <param name="recoveryOfQiDisorder">调息吐纳属性<see cref="!:GameData.Domains.Character.Character.GetRecoveryOfQiDisorder" /></param>
	/// <param name="currValue">当前真气值</param>
	/// <param name="originValue">初始真气值</param>
	/// <returns>真气变化进度</returns>
	public static int CalcNeiliAllocationAutoRecoverProgress(int recoveryOfQiDisorder, int currValue, int originValue)
	{
		if (currValue <= originValue)
		{
			return MathUtils.Max((120 + 12 * recoveryOfQiDisorder / 100) * (100 + (200 - currValue * 200 / MathUtils.Max(originValue, 1))) / 100, 1);
		}
		return MathUtils.Max((60 - 6 * recoveryOfQiDisorder / 100) * currValue / MathUtils.Max(originValue, 1), 1);
	}

	/// <summary>
	/// 计算移速影响移动间隔的公式
	/// </summary>
	/// <param name="moveSpeed">移动速度属性<see cref="!:GameData.Domains.Character.Character.CalcMoveSpeed" /></param>
	/// <returns>被影响后的移动间隔</returns>
	public static int CalcMoveCd(int moveSpeed)
	{
		int moveCd = MoveSpecialConstants.MoveCdBase;
		if (moveSpeed < 100)
		{
			return moveCd + MoveSpecialConstants.MoveCdFactor * (33 - moveSpeed / 3) / 100;
		}
		return moveCd - MoveSpecialConstants.MoveCdFactor * moveSpeed / (MoveSpecialConstants.MoveCdDivisorBase + moveSpeed * MoveSpecialConstants.MoveCdDivisorFactor / 100);
	}

	/// <summary>
	/// 计算移速影响蓄力速度的公式
	/// </summary>
	/// <param name="moveSpeed">移动速度属性<see cref="!:GameData.Domains.Character.Character.CalcMoveSpeed" /></param>
	/// <returns>蓄力速度</returns>
	public static int CalcJumpSpeed(int moveSpeed)
	{
		return 100 + 10 * moveSpeed / 100;
	}

	/// <summary>
	/// 计算角色步伐稳健或引气冲关属性影响破绽封穴恢复速度的公式
	/// </summary>
	/// <param name="recoverSpeed">角色步伐稳健或引气冲关</param>
	/// <returns>破绽封穴恢复进度</returns>
	public static int CalcFlawOrAcupointRecoveryValue(int recoverSpeed)
	{
		return GlobalConfig.Instance.FlawOrAcupointReduceBaseTime + recoverSpeed / 2;
	}

	/// <inheritdoc cref="M:GameData.Domains.Combat.CFormula.FormulaCalcMixedDamageValue(System.Int32,System.Int32,System.SByte,GameData.Domains.Character.OuterAndInnerInts,GameData.Domains.Character.OuterAndInnerInts)" />
	public static OuterAndInnerInts FormulaCalcMixedDamageValue(int damageValue, int attackOdds, sbyte innerRatio, int outerPenetrate, int outerPenetrateResist, int innerPenetrate, int innerPenetrateResist)
	{
		return FormulaCalcMixedDamageValue(damageValue, attackOdds, innerRatio, new OuterAndInnerInts(outerPenetrate, innerPenetrate), new OuterAndInnerInts(outerPenetrateResist, innerPenetrateResist));
	}

	/// <summary>
	/// 计算混伤的公式
	/// </summary>
	/// <param name="damageValue">基础伤害<see cref="M:GameData.Domains.Combat.CFormula.CalcBaseDamageValue(GameData.Domains.Combat.CFormula.EAttackType,System.SByte)" /></param>
	/// <param name="attackOdds">衰减系数<see cref="M:GameData.Domains.Combat.CFormula.CalcBaseAttackOdds(GameData.Domains.Combat.CFormula.EAttackType)" /></param>
	/// <param name="innerRatio">内伤比例，100 - 内伤比例 对应外伤比例</param>
	/// <param name="penetrate">破体/气<see cref="!:GameData.Domains.Combat.CombatCharacter.GetPenetrate(CombatContext)" /></param>
	/// <param name="penetrateResist">御体/气<see cref="!:GameData.Domains.Combat.CombatCharacter.GetPenetrateResist(CombatContext)" /></param>
	/// <returns>内外伤害值</returns>
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

	/// <summary>
	/// 计算精纯增减伤害的百分比
	/// </summary>
	/// <param name="attackerConsummate">攻击方精纯</param>
	/// <param name="defenderConsummate">防守方精纯</param>
	/// <returns>百分比加成，直接乘以原始值获取加成后的值</returns>
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

	/// <summary>
	/// 计算破绽或封穴级别
	/// </summary>
	/// <param name="hitOdds">命中率<see cref="M:GameData.Domains.Combat.CFormula.FormulaCalcHitOdds(System.Int32,System.Int32)" /></param>
	/// <param name="isFlaw">命中率阈值使用破绽，否则封穴</param>
	/// <returns>破绽或封穴级别</returns>
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

	/// <summary>
	/// 计算破绽与额外破绽伤害加成系数
	/// </summary>
	/// <param name="flawCount">破绽数<see cref="!:GameData.Domains.Combat.CombatCharacter.GetFlawCount" /></param>
	/// <param name="extraFlawCount">额外破绽数<see cref="F:GameData.Domains.SpecialEffect.AffectedDataHelper.FieldIds.ExtraFlawCount" /></param>
	/// <returns>伤害加成系数</returns>
	public static CValuePercentBonus CalcFlawDamageBonus(int flawCount, int extraFlawCount)
	{
		return (CValuePercentBonus)((flawCount > 0) ? GlobalConfig.Instance.FlawAddDamagePercent : 0) + (CValuePercentBonus)(extraFlawCount * GlobalConfig.Instance.ExtraFlawAddDamagePercent);
	}

	/// <summary>
	/// 计算基础伤害值
	/// </summary>
	/// <param name="type">基础值类型，野兽攻击判定为摧破，心神摧破单列一类</param>
	/// <param name="attackPointCost">武器攻势数<see cref="!:GameData.Domains.Item.Weapon.GetAttackPreparePointCost" /></param>
	/// <returns>基础伤害值</returns>
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

	/// <summary>
	/// 计算伤害衰减系数
	/// </summary>
	/// <param name="type">基础值类型，野兽攻击判定为摧破，心神摧破单列一类</param>
	/// <returns>伤害衰减系数</returns>
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

	/// <summary>
	/// 计算绳子命中所需最少标记数
	/// </summary>
	/// <param name="combatType">战斗类型</param>
	/// <returns>命中所需最少标记数</returns>
	public static sbyte CalcRopeRequireMinMarkCount(CombatType combatType)
	{
		return combatType switch
		{
			CombatType.Beat => GlobalConfig.Instance.RopeRequireMinMarkCountInBeat, 
			CombatType.Die => GlobalConfig.Instance.RopeRequireMinMarkCountInDie, 
			_ => sbyte.MaxValue, 
		};
	}

	/// <summary>
	/// 计算绳子基础命中率
	/// </summary>
	/// <param name="combatType">战斗类型</param>
	/// <returns>基础命中率</returns>
	public static sbyte CalcRopeBaseHitOdds(CombatType combatType)
	{
		return combatType switch
		{
			CombatType.Beat => GlobalConfig.Instance.RopeBaseHitOddsInBeat, 
			CombatType.Die => GlobalConfig.Instance.RopeBaseHitOddsInDie, 
			_ => sbyte.MinValue, 
		};
	}

	/// <summary>
	/// 计算脚力等级 [0,2]
	/// </summary>
	/// <param name="mobilityValue">脚力值</param>
	/// <returns>脚力等级</returns>
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

	/// <summary>
	/// 计算疗伤所需的造诣值
	/// </summary>
	/// <param name="injuryCount">伤势数<see cref="M:GameData.Domains.Character.Injuries.Get(System.SByte,System.Boolean)" /></param>
	/// <returns></returns>
	public static int CalcHealInjuryRequireAttainment(int injuryCount)
	{
		if (injuryCount <= 0)
		{
			return 0;
		}
		return GlobalConfig.Instance.HealInjuryAttainment[injuryCount - 1];
	}

	/// <summary>
	/// 计算疗伤减少的伤势量
	/// </summary>
	/// <param name="doctorAttainment">大夫疗伤造诣<see cref="!:GameData.Domains.Character.Character.CalcHealAttainment" /></param>
	/// <param name="requireAttainment">需求造诣<see cref="M:GameData.Domains.Combat.CFormula.CalcHealInjuryRequireAttainment(System.Int32)" /></param>
	/// <returns>疗伤减少的伤势量</returns>
	public static CValuePercent CalcHealInjuryValue(int doctorAttainment, int requireAttainment)
	{
		if (doctorAttainment < requireAttainment)
		{
			return 0;
		}
		return 100 + doctorAttainment - requireAttainment;
	}

	/// <summary>
	/// 计算驱毒所需的造诣值
	/// </summary>
	/// <param name="poisonLevel">毒素级别<see cref="M:GameData.Domains.Item.PoisonsAndLevels.CalcPoisonedLevel(System.Int32)" /></param>
	/// <returns></returns>
	public static int CalcHealPoisonRequireAttainment(int poisonLevel)
	{
		if (poisonLevel <= 0)
		{
			return 0;
		}
		return GlobalConfig.Instance.HealPoisonAttainment[poisonLevel - 1];
	}

	/// <summary>
	/// 计算驱毒减少的毒素量
	/// </summary>
	/// <param name="doctorAttainment">大夫驱毒造诣<see cref="!:GameData.Domains.Character.Character.CalcHealAttainment" /></param>
	/// <param name="requireAttainment">需求造诣<see cref="M:GameData.Domains.Combat.CFormula.CalcHealPoisonRequireAttainment(System.Int32)" /></param>
	/// <returns>驱毒减少的毒素量</returns>
	public static int CalcHealPoisonValue(int doctorAttainment, int requireAttainment)
	{
		if (doctorAttainment < requireAttainment)
		{
			return 0;
		}
		return doctorAttainment * GlobalConfig.Instance.HealPoisonAttainmentPercent / 100;
	}

	/// <summary>
	/// 计算调息所需的造诣值
	/// </summary>
	/// <param name="qiDisorderLevel">内息紊乱级别<see cref="M:GameData.Domains.Character.DisorderLevelOfQi.GetDisorderLevelOfQi(System.Int16)" /></param>
	/// <returns></returns>
	public static int CalcHealQiDisorderRequireAttainment(sbyte qiDisorderLevel)
	{
		if (qiDisorderLevel > 0)
		{
			return GlobalConfig.Instance.HealQiDisorderAttainment[qiDisorderLevel - 1];
		}
		return 0;
	}

	/// <summary>
	/// 计算调息减少的内息紊乱
	/// </summary>
	/// <param name="doctorAttainment">大夫调息造诣<see cref="!:GameData.Domains.Character.Character.CalcHealAttainment" /></param>
	/// <param name="requireAttainment">需求造诣<see cref="M:GameData.Domains.Combat.CFormula.CalcHealQiDisorderRequireAttainment(System.SByte)" /></param>
	/// <returns>调息减少的内息紊乱</returns>
	public static int CalcHealQiDisorderValue(int doctorAttainment, int requireAttainment)
	{
		if (doctorAttainment < requireAttainment)
		{
			return 0;
		}
		CValuePercent percent = GlobalConfig.Instance.HealQiDisorderAttainmentPercent;
		return doctorAttainment * percent;
	}

	/// <summary>
	/// 计算复元所需的造诣值
	/// </summary>
	/// <param name="healthType">健康类型<see cref="M:GameData.Domains.Character.HealthTypeHelper.CalcType(System.Collections.Generic.IEnumerable{System.Int16},System.Int16,System.Int16)" /></param>
	/// <returns></returns>
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

	/// <summary>
	/// 计算复元恢复的健康值
	/// </summary>
	/// <param name="doctorAttainment">大夫复元造诣<see cref="!:GameData.Domains.Character.Character.CalcHealAttainment" /></param>
	/// <param name="requireAttainment">需求造诣<see cref="M:GameData.Domains.Combat.CFormula.CalcHealHealthRequireAttainment(GameData.Domains.Character.EHealthType)" /></param>
	/// <returns>复元恢复的健康值</returns>
	public static int CalcHealHealthValue(int doctorAttainment, int requireAttainment)
	{
		if (doctorAttainment < requireAttainment)
		{
			return 0;
		}
		CValuePercent percent = GlobalConfig.Instance.HealHealthAttainmentPercent;
		return doctorAttainment * percent;
	}

	/// <summary>
	/// 计算部分修理时恢复的耐久值
	/// </summary>
	/// <param name="grade">装备品阶</param>
	/// <param name="attainment">修理使用的造诣值</param>
	/// <param name="current">当前耐久值</param>
	/// <param name="costed">已消耗的耐久值</param>
	/// <returns></returns>
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

	/// <summary>
	/// 计算混毒可生效次数
	/// </summary>
	/// <param name="poisonMarkCount">三种毒素标记数之和<see cref="F:GameData.Domains.Combat.DefeatMarkCollection.PoisonMarkList" /></param>
	/// <returns>三种毒素对应混毒可发作次数</returns>
	public static int CalcMixPoisonAffectCount(int poisonMarkCount)
	{
		return MathUtils.Clamp((poisonMarkCount - 1) / 2, 1, 4);
	}

	/// <summary>
	/// 计算主战角色机略值系数
	/// </summary>
	/// <param name="teammateCharCount">同道数</param>
	/// <returns>主战角色机略值系数</returns>
	public static int CalcMainCharacterWisdomMultiplier(int teammateCharCount)
	{
		return 4 - teammateCharCount;
	}

	/// <summary>
	/// 计算威力影响系数
	/// </summary>
	public static CValuePercent CalcPowerFactor(int power)
	{
		return power * GlobalConfig.Instance.PowerDamageMax / (power + GlobalConfig.Instance.PowerDamageOffset);
	}

	/// <summary>
	/// 按默认规则随机浮动内息紊乱变化值
	/// 紊乱在增加和减少时，基础的增加量、减少量会先进行 50~150% 的浮动
	/// </summary>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static short RandomCalcDisorderOfQiDelta(IRandomSource random, int delta)
	{
		return (short)(delta * random.Next(GlobalConfig.Instance.TeaWineEffectDisorderOfQiDelta[0], GlobalConfig.Instance.TeaWineEffectDisorderOfQiDelta[1] + 1) / 100);
	}

	/// <summary>
	/// 按默认规则计算内息紊乱变化值浮动范围
	/// </summary>
	/// <param name="delta"></param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int max, int min) RandomCalcDisorderOfQiRange(int delta)
	{
		int valDec = delta * GlobalConfig.Instance.TeaWineEffectDisorderOfQiDelta[0] / 100;
		int valAdd = delta * GlobalConfig.Instance.TeaWineEffectDisorderOfQiDelta[1] / 100;
		return (max: Math.Max(valAdd, valDec), min: Math.Min(valAdd, valDec));
	}
}

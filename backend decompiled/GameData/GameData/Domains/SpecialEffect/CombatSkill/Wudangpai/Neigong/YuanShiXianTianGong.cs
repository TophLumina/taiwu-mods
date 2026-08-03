using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Neigong;

public class YuanShiXianTianGong : CombatSkillEffectBase
{
	private const long DamageToGangqiFactor = 30L;

	private const long GangqiToDamageFactor = 20L;

	private const int GangqiToBreathOrStanceFactor = 1000;

	public YuanShiXianTianGong()
	{
	}

	public YuanShiXianTianGong(CombatSkillKey skillKey)
		: base(skillKey, 4008, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CreateGangqiAfterChangeNeiliAllocation(OnCreateGangqiAfterChangeNeiliAllocation);
		Events.RegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		CreateAffectedData(321, EDataModifyType.Custom, -1);
		CreateAffectedData(318, EDataModifyType.Custom, -1);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CreateGangqiAfterChangeNeiliAllocation(OnCreateGangqiAfterChangeNeiliAllocation);
		Events.UnRegisterHandler_AddDirectDamageValue(OnAddDirectDamageValue);
		base.OnDisable(context);
	}

	private void OnCreateGangqiAfterChangeNeiliAllocation(DataContext context, CombatCharacter character)
	{
		if (character.GetId() == base.CharacterId)
		{
			int value = character.GetNeiliAllocation().Sum();
			if (value > 0)
			{
				character.CreateGangqi(context, value);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnAddDirectDamageValue(DataContext context, int attackerId, int defenderId, sbyte bodyPart, bool isInner, int damageValue, short combatSkillId)
	{
		if (base.CharacterId == (base.IsDirect ? attackerId : defenderId) && (long)damageValue >= 30L)
		{
			int addGangqi = (int)Math.Min((long)damageValue / 30L, 2147483647L);
			if (addGangqi > 0)
			{
				base.CombatChar.ChangeGangqi(context, addGangqi);
				ShowSpecialEffectTipsOnceInFrame(2);
			}
		}
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.CharId != base.CharacterId || base.CombatChar.GetGangqi() <= 0 || dataKey.CustomParam0 == base.CharacterId || dataKey.FieldId != (base.IsDirect ? 318 : 321))
		{
			return dataValue;
		}
		int attackerId = (base.IsDirect ? dataKey.CustomParam0 : base.CharacterId);
		CombatCharacter attacker = DomainManager.Combat.GetElement_CombatCharacterDict(attackerId);
		CombatSkillKey attackerSkillKey = new CombatSkillKey(attacker.GetId(), dataKey.CombatSkillId);
		sbyte innerRatio = (dataKey.IsNormalAttack ? DomainManager.Combat.GetUsingWeaponData(attacker).GetInnerRatio() : DomainManager.CombatSkill.GetElement_CombatSkills(attackerSkillKey).GetCurrInnerRatio());
		int outerRatio = 100 - innerRatio;
		int ratioHalfDiff = Math.Abs(innerRatio - outerRatio) / 2;
		CValuePercent ratioFactor = (base.IsDirect ? (50 + ratioHalfDiff) : (100 - ratioHalfDiff));
		long delta = Math.Min(dataValue * ratioFactor, (long)base.CombatChar.GetGangqi() * 20L);
		if (delta == 0)
		{
			return dataValue;
		}
		ShowSpecialEffectTipsOnceInFrame(1);
		DataContext context = DomainManager.Combat.Context;
		int costGangqi = (int)(delta / 20);
		if (costGangqi > 0)
		{
			DoCostGangqi(context, costGangqi, innerRatio, outerRatio);
		}
		return base.IsDirect ? (dataValue - delta) : (dataValue + delta);
	}

	private void DoCostGangqi(DataContext context, int costGangqi, sbyte innerRatio, int outerRatio)
	{
		base.CombatChar.ChangeGangqi(context, -costGangqi);
		CombatCharacter target = (base.IsDirect ? base.CombatChar : base.EnemyChar);
		int sign = (base.IsDirect ? 1 : (-1));
		CValuePercent changeBreathPercent = innerRatio * costGangqi / 1000;
		if (changeBreathPercent > 0)
		{
			ChangeBreathValue(context, target, target.GetMaxBreathValue() * changeBreathPercent * sign);
		}
		CValuePercent changeStancePercent = outerRatio * costGangqi / 1000;
		if (changeStancePercent > 0)
		{
			ChangeStanceValue(context, target, target.GetMaxStanceValue() * changeStancePercent * sign);
		}
	}
}

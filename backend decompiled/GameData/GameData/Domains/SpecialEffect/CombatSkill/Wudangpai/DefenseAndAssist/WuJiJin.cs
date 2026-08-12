using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.DefenseAndAssist;

public class WuJiJin : DefenseSkillBase
{
	private const sbyte AddDamageUnit = 2;

	private int _addDamage;

	public WuJiJin()
	{
	}

	public WuJiJin(CombatSkillKey skillKey)
		: base(skillKey, 4506)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_addDamage = 0;
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 71, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 250, -1), EDataModifyType.Custom);
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.RegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	public override void OnDisable(DataContext context)
	{
		base.OnDisable(context);
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		Events.UnRegisterHandler_NormalAttackEnd(OnNormalAttackEnd);
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightBack, bool isMind)
	{
		if (isFightBack && attacker == base.CombatChar && hit && base.CanAffect && !base.CombatChar.FightBackWithHit)
		{
			int reducedValue = Math.Abs(base.IsDirect ? ChangeStanceValue(context, base.CurrEnemyChar, -base.CurrEnemyChar.GetStanceValue()) : ChangeBreathValue(context, base.CurrEnemyChar, -base.CurrEnemyChar.GetBreathValue()));
			_addDamage = reducedValue * 100 / (base.IsDirect ? 4000 : 30000) * 2;
			ShowSpecialEffectTips(0);
		}
	}

	private void OnNormalAttackEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex, bool hit, bool isFightBack)
	{
		if (_addDamage != 0 && isFightBack && attacker == base.CombatChar)
		{
			_addDamage = 0;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 71)
		{
			return _addDamage;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return dataValue;
		}
		if (dataKey.FieldId == 250 && dataKey.CustomParam0 != 1)
		{
			return true;
		}
		return dataValue;
	}
}

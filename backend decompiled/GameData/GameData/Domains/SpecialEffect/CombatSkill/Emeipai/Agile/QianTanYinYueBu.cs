using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Agile;

public class QianTanYinYueBu : AgileSkillBase
{
	private int _affectValue;

	private int UnitAffectValue => base.IsDirect ? 10 : 20;

	private int MaxAffectValue => base.IsDirect ? 60 : 120;

	private int AffectDirection => (!base.IsDirect) ? 1 : (-1);

	public QianTanYinYueBu()
	{
	}

	public QianTanYinYueBu(CombatSkillKey skillKey)
		: base(skillKey, 2505)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		if (base.IsDirect)
		{
			CreateAffectedData(319, EDataModifyType.AddPercent, -1);
		}
		else
		{
			CreateAffectedAllEnemyData(319, EDataModifyType.AddPercent, -1);
		}
		Events.RegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackCalcHitEnd(OnNormalAttackCalcHitEnd);
		base.OnDisable(context);
	}

	private void OnNormalAttackCalcHitEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender, int pursueIndex, bool hit, bool isFightback, bool isMind)
	{
		if (base.CombatChar == (base.IsDirect ? attacker : defender) && hit && pursueIndex <= 0)
		{
			_affectValue = Math.Min(_affectValue + UnitAffectValue, MaxAffectValue);
			ShowSpecialEffectTips(0);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId != 319 || !base.CanAffect || !base.IsCurrent)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		return _affectValue * AffectDirection;
	}
}

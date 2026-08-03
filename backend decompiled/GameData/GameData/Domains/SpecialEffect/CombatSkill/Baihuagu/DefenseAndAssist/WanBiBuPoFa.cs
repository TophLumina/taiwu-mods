using System;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.DefenseAndAssist;

public class WanBiBuPoFa : DefenseSkillBase
{
	public WanBiBuPoFa()
	{
	}

	public WanBiBuPoFa(CombatSkillKey skillKey)
		: base(skillKey, 3508)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(114, EDataModifyType.Custom, -1);
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect || dataKey.FieldId != 114)
		{
			return dataValue;
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (damageType != EDamageType.Direct)
		{
			return dataValue;
		}
		bool inner = dataKey.CustomParam1 == 1;
		sbyte bodyPart = (sbyte)dataKey.CustomParam2;
		int existDamage = (inner ? base.CombatChar.GetInnerDamageValue() : base.CombatChar.GetOuterDamageValue())[bodyPart];
		DamageStepCollection stepCollection = base.CombatChar.GetDamageStepCollection();
		int damageStep = (inner ? stepCollection.InnerDamageSteps : stepCollection.OuterDamageSteps)[bodyPart];
		int newMark = CMath.CalcMarkAndLeftDamage((int)Math.Min(dataValue + existDamage, 2147483647L), damageStep).markCount;
		sbyte oldMark = base.CombatChar.GetInjuries().Get(bodyPart, inner);
		long returnValue = CalcReturnValue(dataValue, newMark, oldMark);
		if (dataValue > 0 && returnValue == 0)
		{
			ShowSpecialEffectTips(0);
		}
		return returnValue;
	}

	private long CalcReturnValue(long dataValue, int newMark, int oldMark)
	{
		if (base.IsDirect)
		{
			return (newMark < oldMark) ? dataValue : 0;
		}
		return (newMark > oldMark) ? dataValue : 0;
	}
}

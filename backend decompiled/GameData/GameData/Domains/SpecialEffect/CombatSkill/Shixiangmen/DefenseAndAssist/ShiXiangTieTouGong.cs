using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.DefenseAndAssist;

public class ShiXiangTieTouGong : DefenseSkillBase
{
	private const sbyte RequireInjuryCount = 3;

	public ShiXiangTieTouGong()
	{
	}

	public ShiXiangTieTouGong(CombatSkillKey skillKey)
		: base(skillKey, 6500)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 114, -1), EDataModifyType.Custom);
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (dataKey.CharId != base.CharacterId || damageType != EDamageType.Direct || !base.CanAffect)
		{
			return dataValue;
		}
		bool isInner = dataKey.CustomParam1 == 1;
		sbyte bodyPart = (sbyte)dataKey.CustomParam2;
		if (bodyPart != 2 || isInner == base.IsDirect)
		{
			return dataValue;
		}
		DamageStepCollection damageStepCollection = base.CombatChar.GetDamageStepCollection();
		int originDamageValue = (isInner ? base.CombatChar.GetInnerDamageValue()[bodyPart] : base.CombatChar.GetOuterDamageValue()[bodyPart]);
		int injuryStep = (isInner ? damageStepCollection.InnerDamageSteps[bodyPart] : damageStepCollection.OuterDamageSteps[bodyPart]);
		if (CMath.CalcMarkAndLeftDamage((int)Math.Min(originDamageValue + dataValue, 2147483647L), injuryStep).markCount > 3)
		{
			return dataValue;
		}
		ShowSpecialEffectTips(0);
		return 0L;
	}
}

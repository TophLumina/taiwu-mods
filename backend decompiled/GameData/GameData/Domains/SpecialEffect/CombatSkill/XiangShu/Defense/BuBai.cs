using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class BuBai : DefenseSkillBase
{
	public BuBai()
	{
	}

	public BuBai(CombatSkillKey skillKey)
		: base(skillKey, 16301)
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
		DamageStepCollection damageStepCollection = base.CombatChar.GetDamageStepCollection();
		int originDamageValue = (isInner ? base.CombatChar.GetInnerDamageValue()[bodyPart] : base.CombatChar.GetOuterDamageValue()[bodyPart]);
		int injuryStep = (isInner ? damageStepCollection.InnerDamageSteps[bodyPart] : damageStepCollection.OuterDamageSteps[bodyPart]);
		(int, int) damageResult = CMath.CalcMarkAndLeftDamage((int)Math.Min(originDamageValue + dataValue, 2147483647L), injuryStep);
		if (base.CombatChar.GetInjuries().Get(bodyPart, isInner) + damageResult.Item1 >= 6)
		{
			ShowSpecialEffectTipsOnceInFrame(0);
			return 0L;
		}
		return dataValue;
	}
}

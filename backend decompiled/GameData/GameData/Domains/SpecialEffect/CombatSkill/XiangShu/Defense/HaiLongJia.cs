using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Defense;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Defense;

public class HaiLongJia : DefenseSkillBase
{
	public HaiLongJia()
	{
	}

	public HaiLongJia(CombatSkillKey skillKey)
		: base(skillKey, 16305)
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
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return dataValue;
		}
		int defendTimePercent = base.CombatChar.DefendSkillLeftFrame * 100 / base.CombatChar.DefendSkillTotalFrame;
		if (defendTimePercent > 0)
		{
			int damageUnit = base.CombatChar.GetDamageStepCollection().FatalDamageStep / 10;
			long costTimePercent = Math.Min(dataValue / damageUnit, defendTimePercent);
			base.CombatChar.DefendSkillLeftFrame = (short)Math.Max(0L, base.CombatChar.DefendSkillLeftFrame - base.CombatChar.DefendSkillTotalFrame * costTimePercent / 100);
			ShowSpecialEffectTipsOnceInFrame(0);
			return damageUnit * (dataValue / damageUnit - costTimePercent);
		}
		return dataValue;
	}
}

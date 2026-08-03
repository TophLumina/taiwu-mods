using System;
using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Agile;

public class TieQiaoGong : AgileSkillBase
{
	private const sbyte DirectRequireDistance = 40;

	private const sbyte ReverseRequireDistance = 80;

	private const sbyte ReduceHitOddsUnit = -10;

	public TieQiaoGong()
	{
	}

	public TieQiaoGong(CombatSkillKey skillKey)
		: base(skillKey, 6401)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 107, -1), EDataModifyType.TotalPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return 0;
		}
		short currDistance = DomainManager.Combat.GetCurrentDistance();
		int unit = (base.IsDirect ? ((currDistance - 40) / 10) : ((80 - currDistance) / 10));
		if (unit <= 0)
		{
			return 0;
		}
		if (dataKey.FieldId == 107)
		{
			ShowSpecialEffectTips(0);
			return -10 * (Math.Abs(currDistance - 40) / 10 + 1);
		}
		return 0;
	}
}

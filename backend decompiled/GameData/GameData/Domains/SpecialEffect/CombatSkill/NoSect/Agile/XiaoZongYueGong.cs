using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.Agile;

public class XiaoZongYueGong : AgileSkillBase
{
	private const sbyte NoCostOdds = 50;

	public XiaoZongYueGong()
	{
	}

	public XiaoZongYueGong(CombatSkillKey skillKey)
		: base(skillKey, 200)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 175, -1), EDataModifyType.Custom);
		ShowSpecialEffectTips(0);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId < 0 || !base.CanAffect || !DomainManager.Combat.Context.Random.CheckPercentProb(50))
		{
			return dataValue;
		}
		if (dataKey.FieldId == 175)
		{
			return 0;
		}
		return dataValue;
	}
}

using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Agile;

public class LiuXiang : AgileSkillBase
{
	public LiuXiang()
	{
	}

	public LiuXiang(CombatSkillKey skillKey)
		: base(skillKey, 16203)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 148, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 217, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 215, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 126, -1), EDataModifyType.Custom);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 131, -1), EDataModifyType.Custom);
		ShowSpecialEffectTips(0);
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || !base.CanAffect)
		{
			return dataValue;
		}
		return false;
	}
}

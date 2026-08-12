using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.RandomEnemy;

public class HuanMu : MinionBase
{
	public HuanMu()
	{
	}

	public HuanMu(CombatSkillKey skillKey)
		: base(skillKey, 16002)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 84, -1), EDataModifyType.Add);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !MinionBase.CanAffect)
		{
			return 0;
		}
		if (dataKey.FieldId == 84)
		{
			return base.CurrEnemyChar.GetFlawCount()[dataKey.CustomParam0];
		}
		return 0;
	}
}

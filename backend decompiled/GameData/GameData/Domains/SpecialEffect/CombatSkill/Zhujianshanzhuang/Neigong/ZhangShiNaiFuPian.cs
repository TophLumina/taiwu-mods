using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Neigong;

public class ZhangShiNaiFuPian : CombatSkillEffectBase
{
	private const sbyte DirectAddMaxPower = 30;

	private const sbyte ReverseReduceRequirementPercent = -20;

	public ZhangShiNaiFuPian()
	{
	}

	public ZhangShiNaiFuPian(CombatSkillKey skillKey)
		: base(skillKey, 9001, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 30, -1), EDataModifyType.Add);
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 31, -1), EDataModifyType.Add);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 30)
		{
			return 30;
		}
		if (dataKey.FieldId == 31)
		{
			return -20;
		}
		return 0;
	}
}

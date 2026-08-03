using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Neigong;

public class JiHunShengWeiPian : CombatSkillEffectBase
{
	private const sbyte DirectAddMaxPower = 30;

	private const sbyte ReverseReduceRequirementPercent = -20;

	public JiHunShengWeiPian()
	{
	}

	public JiHunShengWeiPian(CombatSkillKey skillKey)
		: base(skillKey, 9004, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		if (base.IsDirect)
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 27, -1), EDataModifyType.Add);
		}
		else
		{
			AffectDatas.Add(new AffectedDataKey(base.CharacterId, 28, -1), EDataModifyType.Add);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == 27)
		{
			return 30;
		}
		if (dataKey.FieldId == 28)
		{
			return -20;
		}
		return 0;
	}
}

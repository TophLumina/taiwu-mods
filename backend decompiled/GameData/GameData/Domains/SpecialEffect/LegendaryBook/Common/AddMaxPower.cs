using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Common;

public class AddMaxPower : CombatSkillEffectBase
{
	private const sbyte AddMaxPowerValue = 50;

	private const sbyte AddRequirementPercent = 25;

	protected AddMaxPower()
	{
		IsLegendaryBookEffect = true;
	}

	protected AddMaxPower(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
		IsLegendaryBookEffect = true;
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 200, -1), EDataModifyType.Add);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 202, -1), EDataModifyType.Add);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 200)
		{
			return 50;
		}
		if (dataKey.FieldId == 202)
		{
			return 25;
		}
		return 0;
	}
}

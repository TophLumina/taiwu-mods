using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Stunt;

public class ZhouQuan : CombatSkillEffectBase
{
	private const sbyte ChangeKeepFrames = 100;

	private const sbyte ChangePower = -50;

	public ZhouQuan()
	{
		IsLegendaryBookEffect = true;
	}

	public ZhouQuan(CombatSkillKey skillKey)
		: base(skillKey, 40204, -1)
	{
		IsLegendaryBookEffect = true;
	}

	public override void OnEnable(DataContext context)
	{
		AffectDatas = new Dictionary<AffectedDataKey, EDataModifyType>();
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 176, -1), EDataModifyType.AddPercent);
		AffectDatas.Add(new AffectedDataKey(base.CharacterId, 199, -1), EDataModifyType.AddPercent);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 176)
		{
			return 100;
		}
		if (dataKey.FieldId == 199)
		{
			return -50;
		}
		return 0;
	}
}

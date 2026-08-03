using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Posing;

public class YunYong : CombatSkillEffectBase
{
	private const sbyte ChangeMoveCost = -25;

	public YunYong()
	{
		IsLegendaryBookEffect = true;
	}

	public YunYong(CombatSkillKey skillKey)
		: base(skillKey, 40103, -1)
	{
		IsLegendaryBookEffect = true;
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(175, EDataModifyType.TotalPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 175)
		{
			return -25;
		}
		return 0;
	}
}

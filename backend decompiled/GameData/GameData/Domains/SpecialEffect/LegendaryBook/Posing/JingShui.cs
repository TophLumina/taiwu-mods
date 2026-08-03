using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Posing;

public class JingShui : CombatSkillEffectBase
{
	private const sbyte ChangeFrameCost = -25;

	public JingShui()
	{
		IsLegendaryBookEffect = true;
	}

	public JingShui(CombatSkillKey skillKey)
		: base(skillKey, 40104, -1)
	{
		IsLegendaryBookEffect = true;
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(179, EDataModifyType.TotalPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != base.SkillTemplateId)
		{
			return 0;
		}
		if (dataKey.FieldId == 179)
		{
			return -25;
		}
		return 0;
	}
}

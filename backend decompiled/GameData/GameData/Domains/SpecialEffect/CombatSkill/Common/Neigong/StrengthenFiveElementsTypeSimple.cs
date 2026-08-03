using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

public abstract class StrengthenFiveElementsTypeSimple : StrengthenFiveElementsType
{
	protected override int DirectAddPower => 10;

	protected override int ReverseReduceCostPercent => -10;

	protected StrengthenFiveElementsTypeSimple()
	{
	}

	protected StrengthenFiveElementsTypeSimple(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}
}

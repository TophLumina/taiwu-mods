using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Neigong;

public class TianYuanYangQiFa : StrengthenFiveElementsTypeSimple
{
	protected override sbyte FiveElementsType => 2;

	public TianYuanYangQiFa()
	{
	}

	public TianYuanYangQiFa(CombatSkillKey skillKey)
		: base(skillKey, 13001)
	{
	}
}

using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Neigong;

public class ChiXianFa : StrengthenFiveElementsTypeSimple
{
	protected override sbyte FiveElementsType => 1;

	public ChiXianFa()
	{
	}

	public ChiXianFa(CombatSkillKey skillKey)
		: base(skillKey, 12002)
	{
	}
}

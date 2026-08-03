using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Neigong;

public class YaoChiXianYuFa : StrengthenFiveElementsTypeWithBoost
{
	protected override sbyte FiveElementsType => 2;

	protected override byte CostNeiliAllocationType => 1;

	public YaoChiXianYuFa()
	{
	}

	public YaoChiXianYuFa(CombatSkillKey skillKey)
		: base(skillKey, 8006)
	{
	}
}

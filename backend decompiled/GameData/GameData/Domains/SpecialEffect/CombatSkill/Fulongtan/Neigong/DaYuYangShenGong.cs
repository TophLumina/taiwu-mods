using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Neigong;

public class DaYuYangShenGong : StrengthenFiveElementsTypeWithBoost
{
	protected override sbyte FiveElementsType => 3;

	protected override byte CostNeiliAllocationType => 3;

	public DaYuYangShenGong()
	{
	}

	public DaYuYangShenGong(CombatSkillKey skillKey)
		: base(skillKey, 14007)
	{
	}
}

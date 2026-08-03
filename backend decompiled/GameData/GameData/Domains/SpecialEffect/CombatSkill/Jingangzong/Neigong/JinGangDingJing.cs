using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Neigong;

public class JinGangDingJing : StrengthenFiveElementsTypeWithBoost
{
	protected override sbyte FiveElementsType => 0;

	protected override byte CostNeiliAllocationType => 2;

	public JinGangDingJing()
	{
	}

	public JinGangDingJing(CombatSkillKey skillKey)
		: base(skillKey, 11006)
	{
	}
}

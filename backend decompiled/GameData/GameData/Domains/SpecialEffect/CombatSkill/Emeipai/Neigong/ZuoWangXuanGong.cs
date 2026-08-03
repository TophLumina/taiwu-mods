using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Neigong;

public class ZuoWangXuanGong : StrengthenFiveElementsTypeWithBoost
{
	protected override sbyte FiveElementsType => 1;

	protected override byte CostNeiliAllocationType => 1;

	public ZuoWangXuanGong()
	{
	}

	public ZuoWangXuanGong(CombatSkillKey skillKey)
		: base(skillKey, 2006)
	{
	}
}

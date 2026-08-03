using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Neigong;

public class YiSiYiCan : ChangeFiveElementsDirection
{
	protected override sbyte FiveElementsType => 2;

	protected override byte NeiliAllocationType => 1;

	public YiSiYiCan()
	{
	}

	public YiSiYiCan(CombatSkillKey skillKey)
		: base(skillKey, 13005)
	{
	}
}

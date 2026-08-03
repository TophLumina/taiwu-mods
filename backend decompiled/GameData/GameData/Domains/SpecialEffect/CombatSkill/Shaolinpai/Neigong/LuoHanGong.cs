using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Neigong;

public class LuoHanGong : StrengthenFiveElementsTypeSimple
{
	protected override sbyte FiveElementsType => 0;

	public LuoHanGong()
	{
	}

	public LuoHanGong(CombatSkillKey skillKey)
		: base(skillKey, 1001)
	{
	}
}

using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Neigong;

public class XiHuaZhenJing : FiveElementsAddHitAndAvoid
{
	public XiHuaZhenJing()
	{
	}

	public XiHuaZhenJing(CombatSkillKey skillKey)
		: base(skillKey, 8004)
	{
		RequireFiveElementsType = 2;
	}
}

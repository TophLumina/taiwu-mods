using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Neigong;

public class PuXianXinJing : FiveElementsAddHitAndAvoid
{
	public PuXianXinJing()
	{
	}

	public PuXianXinJing(CombatSkillKey skillKey)
		: base(skillKey, 2005)
	{
		RequireFiveElementsType = 1;
	}
}

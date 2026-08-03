using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Neigong;

public class YuGuGong : FiveElementsAddPenetrateAndResist
{
	public YuGuGong()
	{
	}

	public YuGuGong(CombatSkillKey skillKey)
		: base(skillKey, 8001)
	{
		RequireFiveElementsType = 2;
	}
}

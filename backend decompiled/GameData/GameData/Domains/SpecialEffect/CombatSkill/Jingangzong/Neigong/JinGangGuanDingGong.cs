using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Neigong;

public class JinGangGuanDingGong : FiveElementsAddHitAndAvoid
{
	public JinGangGuanDingGong()
	{
	}

	public JinGangGuanDingGong(CombatSkillKey skillKey)
		: base(skillKey, 11004)
	{
		RequireFiveElementsType = 0;
	}
}

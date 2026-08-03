using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Neigong;

public class XiSuiJinJing : FiveElementsAddHitAndAvoid
{
	public XiSuiJinJing()
	{
	}

	public XiSuiJinJing(CombatSkillKey skillKey)
		: base(skillKey, 4004)
	{
		RequireFiveElementsType = 3;
	}
}

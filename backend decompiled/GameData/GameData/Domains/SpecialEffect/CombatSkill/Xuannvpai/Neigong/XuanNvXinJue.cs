using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Neigong;

public class XuanNvXinJue : BaseSectNeigong
{
	public XuanNvXinJue()
	{
	}

	public XuanNvXinJue(CombatSkillKey skillKey)
		: base(skillKey, 8000)
	{
		SectId = 8;
	}
}

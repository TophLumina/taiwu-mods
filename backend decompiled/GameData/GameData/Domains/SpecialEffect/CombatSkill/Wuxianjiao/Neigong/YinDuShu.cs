using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Neigong;

public class YinDuShu : BaseSectNeigong
{
	public YinDuShu()
	{
	}

	public YinDuShu(CombatSkillKey skillKey)
		: base(skillKey, 12000)
	{
		SectId = 12;
	}
}

using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Neigong;

public class JinGangSiJiaXingFa : BaseSectNeigong
{
	public JinGangSiJiaXingFa()
	{
	}

	public JinGangSiJiaXingFa(CombatSkillKey skillKey)
		: base(skillKey, 11000)
	{
		SectId = 11;
	}
}

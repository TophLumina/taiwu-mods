using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Neigong;

public class YangZhiFa : BaseSectNeigong
{
	public YangZhiFa()
	{
	}

	public YangZhiFa(CombatSkillKey skillKey)
		: base(skillKey, 7000)
	{
		SectId = 7;
	}
}

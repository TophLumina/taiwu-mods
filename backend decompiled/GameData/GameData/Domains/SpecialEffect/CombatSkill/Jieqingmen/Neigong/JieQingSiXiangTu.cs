using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Neigong;

public class JieQingSiXiangTu : BaseSectNeigong
{
	public JieQingSiXiangTu()
	{
	}

	public JieQingSiXiangTu(CombatSkillKey skillKey)
		: base(skillKey, 13000)
	{
		SectId = 13;
	}
}

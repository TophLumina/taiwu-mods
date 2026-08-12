using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Neigong;

public class BianTiHuoQiFa : BaseSectNeigong
{
	public BianTiHuoQiFa()
	{
	}

	public BianTiHuoQiFa(CombatSkillKey skillKey)
		: base(skillKey, 14000)
	{
		SectId = 14;
	}
}

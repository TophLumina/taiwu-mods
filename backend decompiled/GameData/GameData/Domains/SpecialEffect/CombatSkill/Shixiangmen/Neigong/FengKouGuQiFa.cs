using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.Neigong;

public class FengKouGuQiFa : BaseSectNeigong
{
	public FengKouGuQiFa()
	{
	}

	public FengKouGuQiFa(CombatSkillKey skillKey)
		: base(skillKey, 6000)
	{
		SectId = 6;
	}
}

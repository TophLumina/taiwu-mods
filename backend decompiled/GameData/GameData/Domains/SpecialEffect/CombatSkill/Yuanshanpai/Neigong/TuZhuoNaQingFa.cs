using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Neigong;

public class TuZhuoNaQingFa : BaseSectNeigong
{
	public TuZhuoNaQingFa()
	{
	}

	public TuZhuoNaQingFa(CombatSkillKey skillKey)
		: base(skillKey, 5000)
	{
		SectId = 5;
	}
}

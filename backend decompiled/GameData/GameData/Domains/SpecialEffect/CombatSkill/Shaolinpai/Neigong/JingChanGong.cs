using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.Neigong;

public class JingChanGong : BaseSectNeigong
{
	public JingChanGong()
	{
	}

	public JingChanGong(CombatSkillKey skillKey)
		: base(skillKey, 1000)
	{
		SectId = 1;
	}
}

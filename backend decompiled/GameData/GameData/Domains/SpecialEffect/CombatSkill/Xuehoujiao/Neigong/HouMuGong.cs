using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Neigong;

public class HouMuGong : BaseSectNeigong
{
	public HouMuGong()
	{
	}

	public HouMuGong(CombatSkillKey skillKey)
		: base(skillKey, 15000)
	{
		SectId = 15;
	}
}

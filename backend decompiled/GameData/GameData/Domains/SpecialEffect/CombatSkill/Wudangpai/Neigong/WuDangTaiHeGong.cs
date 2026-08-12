using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wudangpai.Neigong;

public class WuDangTaiHeGong : BaseSectNeigong
{
	public WuDangTaiHeGong()
	{
	}

	public WuDangTaiHeGong(CombatSkillKey skillKey)
		: base(skillKey, 4000)
	{
		SectId = 4;
	}
}

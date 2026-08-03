using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Neigong;

public class DanTianKaiHeGong : BaseSectNeigong
{
	public DanTianKaiHeGong()
	{
	}

	public DanTianKaiHeGong(CombatSkillKey skillKey)
		: base(skillKey, 2000)
	{
		SectId = 2;
	}
}

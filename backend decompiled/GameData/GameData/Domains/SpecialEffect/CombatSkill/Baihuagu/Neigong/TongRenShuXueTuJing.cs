using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Neigong;

public class TongRenShuXueTuJing : BaseSectNeigong
{
	public TongRenShuXueTuJing()
	{
	}

	public TongRenShuXueTuJing(CombatSkillKey skillKey)
		: base(skillKey, 3000)
	{
		SectId = 3;
	}
}

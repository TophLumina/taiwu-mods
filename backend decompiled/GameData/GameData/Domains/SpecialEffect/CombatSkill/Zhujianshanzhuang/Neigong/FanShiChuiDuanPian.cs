using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.Neigong;

public class FanShiChuiDuanPian : BaseSectNeigong
{
	public FanShiChuiDuanPian()
	{
	}

	public FanShiChuiDuanPian(CombatSkillKey skillKey)
		: base(skillKey, 9000)
	{
		SectId = 9;
	}
}

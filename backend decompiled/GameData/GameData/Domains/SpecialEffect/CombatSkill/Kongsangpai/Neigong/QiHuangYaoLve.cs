using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Neigong;

public class QiHuangYaoLve : BaseSectNeigong
{
	public QiHuangYaoLve()
	{
	}

	public QiHuangYaoLve(CombatSkillKey skillKey)
		: base(skillKey, 10000)
	{
		SectId = 10;
	}
}

using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Agile;

public class ShiZhuangGong : ChangeLegSkillHit
{
	public ShiZhuangGong()
	{
	}

	public ShiZhuangGong(CombatSkillKey skillKey)
		: base(skillKey, 5400)
	{
		BuffHitType = 0;
	}
}

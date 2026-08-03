using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Agile;

public class YouHunGuiBu : ChangeLegSkillHit
{
	public YouHunGuiBu()
	{
	}

	public YouHunGuiBu(CombatSkillKey skillKey)
		: base(skillKey, 15602)
	{
		BuffHitType = 2;
	}
}

using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Agile;

public class WuGuiBu : ChangeAttackHitType
{
	public WuGuiBu()
	{
	}

	public WuGuiBu(CombatSkillKey skillKey)
		: base(skillKey, 7400)
	{
		HitType = 1;
	}
}

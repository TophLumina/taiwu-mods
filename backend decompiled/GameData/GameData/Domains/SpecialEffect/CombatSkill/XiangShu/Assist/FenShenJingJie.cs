using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class FenShenJingJie : AddDamageByHitType
{
	public FenShenJingJie()
	{
	}

	public FenShenJingJie(CombatSkillKey skillKey)
		: base(skillKey, 16408)
	{
		HitType = 2;
	}
}

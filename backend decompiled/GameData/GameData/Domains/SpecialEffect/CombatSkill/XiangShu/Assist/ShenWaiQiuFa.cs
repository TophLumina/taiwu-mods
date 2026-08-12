using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class ShenWaiQiuFa : AddDamageByHitType
{
	public ShenWaiQiuFa()
	{
	}

	public ShenWaiQiuFa(CombatSkillKey skillKey)
		: base(skillKey, 16405)
	{
		HitType = 0;
	}
}

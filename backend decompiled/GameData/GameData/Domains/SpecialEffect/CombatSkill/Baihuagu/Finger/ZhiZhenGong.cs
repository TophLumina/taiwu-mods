using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Finger;

public class ZhiZhenGong : AddHitOrReduceAvoid
{
	public ZhiZhenGong()
	{
	}

	public ZhiZhenGong(CombatSkillKey skillKey)
		: base(skillKey, 3100)
	{
		AffectHitType = 1;
	}
}

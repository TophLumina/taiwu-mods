using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Whip;

public class WuShengBianFa : ReverseNext
{
	public WuShengBianFa()
	{
	}

	public WuShengBianFa(CombatSkillKey skillKey)
		: base(skillKey, 12402)
	{
		AffectSectId = 12;
		AffectSkillType = 11;
	}
}

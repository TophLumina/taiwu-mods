using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Sword;

public class LvRanJianFa : ReduceEnemyTrick
{
	public LvRanJianFa()
	{
	}

	public LvRanJianFa(CombatSkillKey skillKey)
		: base(skillKey, 12300)
	{
		AffectTrickType = 5;
	}
}

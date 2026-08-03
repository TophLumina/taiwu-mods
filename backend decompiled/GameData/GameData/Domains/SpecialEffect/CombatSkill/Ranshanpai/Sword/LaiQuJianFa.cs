using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Sword;

public class LaiQuJianFa : ReduceEnemyTrick
{
	public LaiQuJianFa()
	{
	}

	public LaiQuJianFa(CombatSkillKey skillKey)
		: base(skillKey, 7200)
	{
		AffectTrickType = 4;
	}
}

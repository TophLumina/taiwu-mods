using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Blade;

public class JinGangDaoFa : ReduceEnemyTrick
{
	public JinGangDaoFa()
	{
	}

	public JinGangDaoFa(CombatSkillKey skillKey)
		: base(skillKey, 11200)
	{
		AffectTrickType = 3;
	}
}

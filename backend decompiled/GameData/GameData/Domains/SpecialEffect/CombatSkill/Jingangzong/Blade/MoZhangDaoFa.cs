using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Blade;

public class MoZhangDaoFa : GameData.Domains.SpecialEffect.CombatSkill.Common.Attack.AttackHitType
{
	public MoZhangDaoFa()
	{
	}

	public MoZhangDaoFa(CombatSkillKey skillKey)
		: base(skillKey, 11202)
	{
		AffectHitType = 0;
	}
}

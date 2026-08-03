using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Sword;

public class FuHuaLveYingJian : AddHitOrReduceAvoid
{
	public FuHuaLveYingJian()
	{
	}

	public FuHuaLveYingJian(CombatSkillKey skillKey)
		: base(skillKey, 2300)
	{
		AffectHitType = 2;
	}
}

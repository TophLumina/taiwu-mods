using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Finger;

public class WanHuaLingYueZhi : AttackNeiliFiveElementsType
{
	public WanHuaLingYueZhi()
	{
	}

	public WanHuaLingYueZhi(CombatSkillKey skillKey)
		: base(skillKey, 3106)
	{
		AffectFiveElementsType = 3;
	}
}

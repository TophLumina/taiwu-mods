using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.Sword;

public class ShenChiZhanYaoJian : AttackSkillFiveElementsType
{
	public ShenChiZhanYaoJian()
	{
	}

	public ShenChiZhanYaoJian(CombatSkillKey skillKey)
		: base(skillKey, 12305)
	{
		AffectFiveElementsType = 4;
	}
}

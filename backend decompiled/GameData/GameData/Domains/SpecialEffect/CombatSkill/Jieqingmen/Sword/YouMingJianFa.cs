using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Sword;

public class YouMingJianFa : AttackSkillFiveElementsType
{
	public YouMingJianFa()
	{
	}

	public YouMingJianFa(CombatSkillKey skillKey)
		: base(skillKey, 13205)
	{
		AffectFiveElementsType = 3;
	}
}

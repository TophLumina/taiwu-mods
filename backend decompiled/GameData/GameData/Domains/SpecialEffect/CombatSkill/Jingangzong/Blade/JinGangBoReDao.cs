using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Blade;

public class JinGangBoReDao : AttackSkillFiveElementsType
{
	public JinGangBoReDao()
	{
	}

	public JinGangBoReDao(CombatSkillKey skillKey)
		: base(skillKey, 11205)
	{
		AffectFiveElementsType = 1;
	}
}

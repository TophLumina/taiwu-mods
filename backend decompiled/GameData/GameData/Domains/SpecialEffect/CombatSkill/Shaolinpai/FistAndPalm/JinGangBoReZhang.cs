using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.FistAndPalm;

public class JinGangBoReZhang : AttackNeiliFiveElementsType
{
	public JinGangBoReZhang()
	{
	}

	public JinGangBoReZhang(CombatSkillKey skillKey)
		: base(skillKey, 1106)
	{
		AffectFiveElementsType = 1;
	}
}

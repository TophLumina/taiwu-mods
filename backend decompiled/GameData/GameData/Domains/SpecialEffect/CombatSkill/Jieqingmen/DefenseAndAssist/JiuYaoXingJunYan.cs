using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.DefenseAndAssist;

public class JiuYaoXingJunYan : TrickAddHitOrAvoid
{
	public JiuYaoXingJunYan()
	{
	}

	public JiuYaoXingJunYan(CombatSkillKey skillKey)
		: base(skillKey, 13605)
	{
		RequireTrickTypes = new sbyte[3] { 0, 2, 1 };
	}
}

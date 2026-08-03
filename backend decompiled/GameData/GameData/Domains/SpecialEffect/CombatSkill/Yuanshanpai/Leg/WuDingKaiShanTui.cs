using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Yuanshanpai.Leg;

public class WuDingKaiShanTui : AttackSkillFiveElementsType
{
	public WuDingKaiShanTui()
	{
	}

	public WuDingKaiShanTui(CombatSkillKey skillKey)
		: base(skillKey, 5105)
	{
		AffectFiveElementsType = 2;
	}
}

using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.FistAndPalm;

public class FuSheQianZhenShou : PoisonDisableAgileOrDefense
{
	public FuSheQianZhenShou()
	{
	}

	public FuSheQianZhenShou(CombatSkillKey skillKey)
		: base(skillKey, 12101)
	{
		RequirePoisonType = 5;
	}
}

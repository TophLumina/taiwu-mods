using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XiangShu;

public class RuXuYanXiang : SkillCostNeiliAllocation
{
	public RuXuYanXiang()
	{
	}

	public RuXuYanXiang(CombatSkillKey skillKey)
		: base(skillKey, 17091)
	{
		CostNeiliAllocationPerGrade = 2;
	}
}

using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.XiangShu;

public class XieWangWuZheng : SkillCostNeiliAllocation
{
	public XieWangWuZheng()
	{
	}

	public XieWangWuZheng(CombatSkillKey skillKey)
		: base(skillKey, 17094)
	{
		CostNeiliAllocationPerGrade = 4;
	}
}

using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Throw;

public class JiuLianJinWu : AccumulateNeiliAllocationToStrengthen
{
	public JiuLianJinWu()
	{
	}

	public JiuLianJinWu(CombatSkillKey skillKey)
		: base(skillKey, 14305)
	{
		RequireNeiliAllocationType = 0;
	}
}

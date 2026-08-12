using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.DefenseAndAssist;

public class NuXiangGong : NeiliAllocationChangeInjury
{
	public NuXiangGong()
	{
	}

	public NuXiangGong(CombatSkillKey skillKey)
		: base(skillKey, 14600)
	{
		RequireNeiliAllocationType = 0;
	}
}

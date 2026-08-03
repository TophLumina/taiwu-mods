using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.DefenseAndAssist;

public class EMeiHuBuGong : NeiliAllocationChangeInjury
{
	public EMeiHuBuGong()
	{
	}

	public EMeiHuBuGong(CombatSkillKey skillKey)
		: base(skillKey, 2700)
	{
		RequireNeiliAllocationType = 1;
	}
}

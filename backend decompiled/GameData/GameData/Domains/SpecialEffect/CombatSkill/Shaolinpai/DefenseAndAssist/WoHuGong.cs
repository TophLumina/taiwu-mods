using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.DefenseAndAssist;

public class WoHuGong : NeiliAllocationChangeInjury
{
	public WoHuGong()
	{
	}

	public WoHuGong(CombatSkillKey skillKey)
		: base(skillKey, 1600)
	{
		RequireNeiliAllocationType = 2;
	}
}

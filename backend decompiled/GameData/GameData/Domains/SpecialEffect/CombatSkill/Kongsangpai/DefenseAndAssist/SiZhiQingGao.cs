using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.DefenseAndAssist;

public class SiZhiQingGao : NeiliAllocationChangeInjury
{
	public SiZhiQingGao()
	{
	}

	public SiZhiQingGao(CombatSkillKey skillKey)
		: base(skillKey, 10700)
	{
		RequireNeiliAllocationType = 3;
	}
}

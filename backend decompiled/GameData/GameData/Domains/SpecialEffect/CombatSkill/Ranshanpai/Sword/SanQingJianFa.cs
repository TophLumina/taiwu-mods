using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Sword;

public class SanQingJianFa : AddOrReduceNeiliAllocation
{
	protected override sbyte NeiliAllocationChange => 5;

	public SanQingJianFa()
	{
	}

	public SanQingJianFa(CombatSkillKey skillKey)
		: base(skillKey, 7201)
	{
		AffectNeiliAllocationType = 3;
	}
}

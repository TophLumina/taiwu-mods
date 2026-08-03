using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Throw;

public class LongTuZhu : AddOrReduceNeiliAllocation
{
	protected override sbyte NeiliAllocationChange => 5;

	public LongTuZhu()
	{
	}

	public LongTuZhu(CombatSkillKey skillKey)
		: base(skillKey, 14302)
	{
		AffectNeiliAllocationType = 0;
	}
}

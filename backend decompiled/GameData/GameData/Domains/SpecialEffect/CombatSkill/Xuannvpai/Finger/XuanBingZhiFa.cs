using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Finger;

public class XuanBingZhiFa : AddOrReduceNeiliAllocation
{
	protected override sbyte NeiliAllocationChange => 5;

	public XuanBingZhiFa()
	{
	}

	public XuanBingZhiFa(CombatSkillKey skillKey)
		: base(skillKey, 8201)
	{
		AffectNeiliAllocationType = 1;
	}
}

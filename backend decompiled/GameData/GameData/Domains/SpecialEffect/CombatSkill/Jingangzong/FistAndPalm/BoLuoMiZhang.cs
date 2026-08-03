using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.FistAndPalm;

public class BoLuoMiZhang : AddOrReduceNeiliAllocation
{
	protected override sbyte NeiliAllocationChange => 5;

	public BoLuoMiZhang()
	{
	}

	public BoLuoMiZhang(CombatSkillKey skillKey)
		: base(skillKey, 11102)
	{
		AffectNeiliAllocationType = 2;
	}
}

using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.Special;

public class HuaYingCi : ReduceEnemyNeiliAllocation
{
	protected override byte AffectNeiliAllocationType => 1;

	public HuaYingCi()
	{
	}

	public HuaYingCi(CombatSkillKey skillKey)
		: base(skillKey, 2404)
	{
	}
}

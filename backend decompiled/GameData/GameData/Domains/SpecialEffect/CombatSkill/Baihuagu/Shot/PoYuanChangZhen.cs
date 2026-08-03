using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Shot;

public class PoYuanChangZhen : ReduceEnemyNeiliAllocation
{
	protected override byte AffectNeiliAllocationType => 3;

	public PoYuanChangZhen()
	{
	}

	public PoYuanChangZhen(CombatSkillKey skillKey)
		: base(skillKey, 3204)
	{
	}
}

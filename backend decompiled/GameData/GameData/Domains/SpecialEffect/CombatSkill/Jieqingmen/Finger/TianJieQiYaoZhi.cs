using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Finger;

public class TianJieQiYaoZhi : ReduceEnemyNeiliAllocation
{
	protected override byte AffectNeiliAllocationType => 0;

	public TianJieQiYaoZhi()
	{
	}

	public TianJieQiYaoZhi(CombatSkillKey skillKey)
		: base(skillKey, 13104)
	{
	}
}

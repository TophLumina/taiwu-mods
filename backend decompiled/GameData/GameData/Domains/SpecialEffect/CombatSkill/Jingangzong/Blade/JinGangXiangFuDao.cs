using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Blade;

public class JinGangXiangFuDao : ReduceEnemyNeiliAllocation
{
	protected override byte AffectNeiliAllocationType => 2;

	public JinGangXiangFuDao()
	{
	}

	public JinGangXiangFuDao(CombatSkillKey skillKey)
		: base(skillKey, 11204)
	{
	}
}

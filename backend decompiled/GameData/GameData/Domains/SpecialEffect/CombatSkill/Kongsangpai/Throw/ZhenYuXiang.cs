using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Throw;

public class ZhenYuXiang : PowerUpByPoison
{
	protected override sbyte RequirePoisonType => 0;

	protected override short DirectStateId => 210;

	protected override short ReverseStateId => 211;

	public ZhenYuXiang()
	{
	}

	public ZhenYuXiang(CombatSkillKey skillKey)
		: base(skillKey, 10400)
	{
	}
}

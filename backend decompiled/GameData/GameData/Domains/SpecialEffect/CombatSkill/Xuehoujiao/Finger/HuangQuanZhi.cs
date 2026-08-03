using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Finger;

public class HuangQuanZhi : PowerUpByPoison
{
	protected override sbyte RequirePoisonType => 4;

	protected override short DirectStateId => 218;

	protected override short ReverseStateId => 219;

	public HuangQuanZhi()
	{
	}

	public HuangQuanZhi(CombatSkillKey skillKey)
		: base(skillKey, 15205)
	{
	}
}

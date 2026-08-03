using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.MoNv;

public class LuanCaiYing : AutoAttackAndAddPower
{
	public LuanCaiYing()
	{
	}

	public LuanCaiYing(CombatSkillKey skillKey)
		: base(skillKey, 17005)
	{
		AttackRepeatTimes = 3;
		AddPowerUnit = 20;
	}
}

using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.MoNv;

public class WuSeYing : AutoAttackAndAddPower
{
	public WuSeYing()
	{
	}

	public WuSeYing(CombatSkillKey skillKey)
		: base(skillKey, 17002)
	{
		AttackRepeatTimes = 1;
		AddPowerUnit = 10;
	}
}

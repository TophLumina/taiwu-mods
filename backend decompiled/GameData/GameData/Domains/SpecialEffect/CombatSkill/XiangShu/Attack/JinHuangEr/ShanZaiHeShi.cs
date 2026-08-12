using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JinHuangEr;

public class ShanZaiHeShi : RepeatNormalAttack
{
	public ShanZaiHeShi()
	{
	}

	public ShanZaiHeShi(CombatSkillKey skillKey)
		: base(skillKey, 17033)
	{
		RepeatTimes = 3;
	}
}

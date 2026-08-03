using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JinHuangEr;

public class JinLingPoKong : AddDistanceAndAddInjury
{
	public JinLingPoKong()
	{
	}

	public JinLingPoKong(CombatSkillKey skillKey)
		: base(skillKey, 17035)
	{
	}
}

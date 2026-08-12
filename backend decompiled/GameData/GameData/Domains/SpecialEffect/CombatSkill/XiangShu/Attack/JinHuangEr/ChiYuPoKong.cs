using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JinHuangEr;

public class ChiYuPoKong : AddDistanceAndAddInjury
{
	public ChiYuPoKong()
	{
	}

	public ChiYuPoKong(CombatSkillKey skillKey)
		: base(skillKey, 17032)
	{
	}
}

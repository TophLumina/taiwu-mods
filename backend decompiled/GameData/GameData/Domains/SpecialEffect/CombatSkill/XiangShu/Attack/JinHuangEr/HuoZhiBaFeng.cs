using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JinHuangEr;

public class HuoZhiBaFeng : AddFlaw
{
	public HuoZhiBaFeng()
	{
	}

	public HuoZhiBaFeng(CombatSkillKey skillKey)
		: base(skillKey, 17031)
	{
		FlawCount = 1;
	}
}

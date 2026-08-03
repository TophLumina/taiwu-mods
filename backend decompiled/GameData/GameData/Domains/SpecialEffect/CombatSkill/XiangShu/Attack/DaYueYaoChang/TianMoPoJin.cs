using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.DaYueYaoChang;

public class TianMoPoJin : AddPowerAndAddFlaw
{
	public TianMoPoJin()
	{
	}

	public TianMoPoJin(CombatSkillKey skillKey)
		: base(skillKey, 17015)
	{
		AddPower = 80;
		FlawCount = 6;
	}
}

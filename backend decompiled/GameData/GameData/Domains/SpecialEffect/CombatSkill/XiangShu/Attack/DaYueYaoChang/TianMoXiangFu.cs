using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.DaYueYaoChang;

public class TianMoXiangFu : AddPowerAndAddFlaw
{
	public TianMoXiangFu()
	{
	}

	public TianMoXiangFu(CombatSkillKey skillKey)
		: base(skillKey, 17012)
	{
		AddPower = 40;
		FlawCount = 3;
	}
}

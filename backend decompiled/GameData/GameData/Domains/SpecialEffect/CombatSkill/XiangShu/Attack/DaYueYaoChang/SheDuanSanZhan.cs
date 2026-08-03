using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.DaYueYaoChang;

public class SheDuanSanZhan : AddPowerAndRepeat
{
	public SheDuanSanZhan()
	{
	}

	public SheDuanSanZhan(CombatSkillKey skillKey)
		: base(skillKey, 17014)
	{
		AutoCastReducePower = -20;
	}
}

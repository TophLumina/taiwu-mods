using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.DaYueYaoChang;

public class MieShaSanZhan : AddPowerAndRepeat
{
	public MieShaSanZhan()
	{
	}

	public MieShaSanZhan(CombatSkillKey skillKey)
		: base(skillKey, 17011)
	{
		AutoCastReducePower = -60;
	}
}

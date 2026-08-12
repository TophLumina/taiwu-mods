using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiXiang;

public class WuHunHuaHun : AutoCastAgileAndDefense
{
	public WuHunHuaHun()
	{
	}

	public WuHunHuaHun(CombatSkillKey skillKey)
		: base(skillKey, 17062)
	{
		AddPower = 40;
	}
}

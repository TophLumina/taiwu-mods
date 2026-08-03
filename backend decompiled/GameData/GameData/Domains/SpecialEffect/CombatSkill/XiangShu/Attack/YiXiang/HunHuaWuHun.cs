using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiXiang;

public class HunHuaWuHun : AutoCastAgileAndDefense
{
	public HunHuaWuHun()
	{
	}

	public HunHuaWuHun(CombatSkillKey skillKey)
		: base(skillKey, 17065)
	{
		AddPower = 80;
	}
}

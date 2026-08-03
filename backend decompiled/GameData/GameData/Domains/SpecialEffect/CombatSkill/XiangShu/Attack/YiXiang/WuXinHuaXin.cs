using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiXiang;

public class WuXinHuaXin : ReduceHitOddsAddAcupoint
{
	public WuXinHuaXin()
	{
	}

	public WuXinHuaXin(CombatSkillKey skillKey)
		: base(skillKey, 17060)
	{
		AcupointCount = 2;
	}
}

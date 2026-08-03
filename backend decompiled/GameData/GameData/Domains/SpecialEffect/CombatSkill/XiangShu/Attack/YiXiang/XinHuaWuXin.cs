using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiXiang;

public class XinHuaWuXin : ReduceHitOddsAddAcupoint
{
	public XinHuaWuXin()
	{
	}

	public XinHuaWuXin(CombatSkillKey skillKey)
		: base(skillKey, 17063)
	{
		AcupointCount = 4;
	}
}

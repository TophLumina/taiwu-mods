using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.ShuFang;

public class TianDiXuanYiLing : SilenceSkillAndMinAttribute
{
	public TianDiXuanYiLing()
	{
	}

	public TianDiXuanYiLing(CombatSkillKey skillKey)
		: base(skillKey, 17082)
	{
		SilenceSkillCount = 3;
	}
}

using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.ShuFang;

public class GuiShenXuanYiLing : SilenceSkillAndMinAttribute
{
	public GuiShenXuanYiLing()
	{
	}

	public GuiShenXuanYiLing(CombatSkillKey skillKey)
		: base(skillKey, 17085)
	{
		SilenceSkillCount = 6;
	}
}

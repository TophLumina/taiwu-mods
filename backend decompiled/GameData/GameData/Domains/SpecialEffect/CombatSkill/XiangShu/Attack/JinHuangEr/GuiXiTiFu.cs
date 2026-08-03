using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.JinHuangEr;

public class GuiXiTiFu : RepeatNormalAttack
{
	public GuiXiTiFu()
	{
	}

	public GuiXiTiFu(CombatSkillKey skillKey)
		: base(skillKey, 17030)
	{
		RepeatTimes = 1;
	}
}

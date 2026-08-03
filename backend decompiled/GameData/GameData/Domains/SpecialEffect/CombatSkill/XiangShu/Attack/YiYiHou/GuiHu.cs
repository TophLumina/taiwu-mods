using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Attack.YiYiHou;

public class GuiHu : AddWuTrick
{
	public GuiHu()
	{
	}

	public GuiHu(CombatSkillKey skillKey)
		: base(skillKey, 17043)
	{
		AddTrickCount = 6;
	}
}

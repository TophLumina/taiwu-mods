using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.FistAndPalm;

public class YinFengXieZiShou : PowerUpByPoison
{
	protected override sbyte RequirePoisonType => 1;

	protected override short DirectStateId => 212;

	protected override short ReverseStateId => 213;

	public YinFengXieZiShou()
	{
	}

	public YinFengXieZiShou(CombatSkillKey skillKey)
		: base(skillKey, 12100)
	{
	}
}

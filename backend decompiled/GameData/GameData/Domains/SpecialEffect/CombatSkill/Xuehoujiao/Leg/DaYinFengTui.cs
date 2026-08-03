using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Leg;

public class DaYinFengTui : AddInjuryByPoisonMark
{
	protected override bool AlsoAddAcupoint => true;

	public DaYinFengTui()
	{
	}

	public DaYinFengTui(CombatSkillKey skillKey)
		: base(skillKey, 15305)
	{
		RequirePoisonType = 1;
		IsInnerInjury = true;
	}
}

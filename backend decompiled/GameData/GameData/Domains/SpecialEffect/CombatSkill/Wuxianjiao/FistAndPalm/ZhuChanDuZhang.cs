using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Wuxianjiao.FistAndPalm;

public class ZhuChanDuZhang : AddInjuryByPoisonMark
{
	protected override bool AlsoAddFlaw => true;

	public ZhuChanDuZhang()
	{
	}

	public ZhuChanDuZhang(CombatSkillKey skillKey)
		: base(skillKey, 12105)
	{
		RequirePoisonType = 3;
		IsInnerInjury = false;
	}
}

using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Finger;

public class XuanMingZhi : AddInjuryByPoisonMark
{
	protected override bool AlsoAddAcupoint => true;

	public XuanMingZhi()
	{
	}

	public XuanMingZhi(CombatSkillKey skillKey)
		: base(skillKey, 13105)
	{
		RequirePoisonType = 2;
		IsInnerInjury = true;
	}
}

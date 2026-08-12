using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Throw;

public class HeiShuiDuanChangSan : AddInjuryByPoisonMark
{
	protected override bool AlsoAddFlaw => true;

	public HeiShuiDuanChangSan()
	{
	}

	public HeiShuiDuanChangSan(CombatSkillKey skillKey)
		: base(skillKey, 10405)
	{
		RequirePoisonType = 0;
		IsInnerInjury = false;
	}
}

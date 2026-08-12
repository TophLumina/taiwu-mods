using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shixiangmen.FistAndPalm;

public class TuiShanZhang : AddHitOrReduceAvoid
{
	public TuiShanZhang()
	{
	}

	public TuiShanZhang(CombatSkillKey skillKey)
		: base(skillKey, 6100)
	{
		AffectHitType = 0;
	}
}

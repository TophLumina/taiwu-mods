using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.Music;

public class QiQingQu : AddHitOrReduceAvoid
{
	public QiQingQu()
	{
	}

	public QiQingQu(CombatSkillKey skillKey)
		: base(skillKey, 8300)
	{
		AffectHitType = 3;
	}
}

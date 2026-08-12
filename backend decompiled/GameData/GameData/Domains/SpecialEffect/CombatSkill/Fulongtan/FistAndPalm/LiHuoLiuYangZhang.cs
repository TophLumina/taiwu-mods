using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.FistAndPalm;

public class LiHuoLiuYangZhang : AttackNeiliFiveElementsType
{
	public LiHuoLiuYangZhang()
	{
	}

	public LiHuoLiuYangZhang(CombatSkillKey skillKey)
		: base(skillKey, 14106)
	{
		AffectFiveElementsType = 0;
	}
}

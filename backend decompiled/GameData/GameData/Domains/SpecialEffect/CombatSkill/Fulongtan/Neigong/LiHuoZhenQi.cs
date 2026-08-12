using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Fulongtan.Neigong;

public class LiHuoZhenQi : AddFiveElementsDamage
{
	public LiHuoZhenQi()
	{
	}

	public LiHuoZhenQi(CombatSkillKey skillKey)
		: base(skillKey, 14002)
	{
		RequireSelfFiveElementsType = 3;
		AffectFiveElementsType = (sbyte)((!base.IsDirect) ? 2 : 0);
	}
}

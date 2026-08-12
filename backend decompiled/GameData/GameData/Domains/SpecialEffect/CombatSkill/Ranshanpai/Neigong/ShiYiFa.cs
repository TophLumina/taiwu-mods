using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Ranshanpai.Neigong;

public class ShiYiFa : ReduceFiveElementsDamage
{
	public ShiYiFa()
	{
	}

	public ShiYiFa(CombatSkillKey skillKey)
		: base(skillKey, 7002)
	{
		RequireSelfFiveElementsType = 1;
		AffectFiveElementsType = (sbyte)(base.IsDirect ? 4 : 0);
	}
}

using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Neigong;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Neigong;

public class SanMiHeYingFa : AddFiveElementsDamage
{
	public SanMiHeYingFa()
	{
	}

	public SanMiHeYingFa(CombatSkillKey skillKey)
		: base(skillKey, 11002)
	{
		RequireSelfFiveElementsType = 0;
		AffectFiveElementsType = (sbyte)(base.IsDirect ? 1 : 3);
	}
}

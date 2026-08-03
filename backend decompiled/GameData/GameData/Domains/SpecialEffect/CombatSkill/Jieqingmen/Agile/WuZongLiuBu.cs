using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jieqingmen.Agile;

public class WuZongLiuBu : MakeTricksInterchangeable
{
	public WuZongLiuBu()
	{
	}

	public WuZongLiuBu(CombatSkillKey skillKey)
		: base(skillKey, 13401)
	{
		AffectTrickTypes = new List<sbyte> { 7, 4, 1 };
	}
}

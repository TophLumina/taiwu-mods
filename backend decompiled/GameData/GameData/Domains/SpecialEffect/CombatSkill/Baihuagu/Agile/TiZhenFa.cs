using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Agile;

public class TiZhenFa : MakeTricksInterchangeable
{
	public TiZhenFa()
	{
	}

	public TiZhenFa(CombatSkillKey skillKey)
		: base(skillKey, 3400)
	{
		AffectTrickTypes = new List<sbyte> { 8, 5, 2 };
	}
}

using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Agile;

namespace GameData.Domains.SpecialEffect.CombatSkill.Jingangzong.Agile;

public class DaDingJiao : MakeTricksInterchangeable
{
	public DaDingJiao()
	{
	}

	public DaDingJiao(CombatSkillKey skillKey)
		: base(skillKey, 11501)
	{
		AffectTrickTypes = new List<sbyte> { 6, 3, 0 };
	}
}

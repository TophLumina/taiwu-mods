using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Whip;

public class JiePo : InterruptEnemyCast
{
	public JiePo()
	{
	}

	public JiePo(CombatSkillKey skillKey)
		: base(skillKey, 41103)
	{
	}
}

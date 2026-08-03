using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Leg;

public class JueZhi : ChangePower
{
	public JueZhi()
	{
	}

	public JueZhi(CombatSkillKey skillKey)
		: base(skillKey, 40504)
	{
	}
}

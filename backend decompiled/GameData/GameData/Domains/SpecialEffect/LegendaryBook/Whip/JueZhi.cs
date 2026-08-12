using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Whip;

public class JueZhi : ChangePower
{
	public JueZhi()
	{
	}

	public JueZhi(CombatSkillKey skillKey)
		: base(skillKey, 41104)
	{
	}
}

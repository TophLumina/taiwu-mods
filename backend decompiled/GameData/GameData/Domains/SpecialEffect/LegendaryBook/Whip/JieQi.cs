using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Whip;

public class JieQi : AddDamage
{
	public JieQi()
	{
	}

	public JieQi(CombatSkillKey skillKey)
		: base(skillKey, 41102)
	{
	}

	protected override int GetAddDamagePercent()
	{
		return 180 * (30000 - base.CurrEnemyChar.GetBreathValue()) / 30000;
	}
}

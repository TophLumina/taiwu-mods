using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Finger;

public class SiXue : AddDamage
{
	private const short AddDamageUnit = 20;

	public SiXue()
	{
	}

	public SiXue(CombatSkillKey skillKey)
		: base(skillKey, 40402)
	{
	}

	protected override int GetAddDamagePercent()
	{
		int acupointCount = base.CurrEnemyChar.GetAcupointCount().Sum();
		return 20 * acupointCount;
	}
}

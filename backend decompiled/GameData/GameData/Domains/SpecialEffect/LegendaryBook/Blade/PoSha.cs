using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Blade;

public class PoSha : AddDamage
{
	private const short AddDamageUnit = 20;

	public PoSha()
	{
	}

	public PoSha(CombatSkillKey skillKey)
		: base(skillKey, 40802)
	{
	}

	protected override int GetAddDamagePercent()
	{
		int flawCount = base.CurrEnemyChar.GetFlawCount().Sum();
		return 20 * flawCount;
	}
}

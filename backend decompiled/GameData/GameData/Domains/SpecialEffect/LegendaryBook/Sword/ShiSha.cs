using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Sword;

public class ShiSha : AddDamage
{
	private const short AddDamageUnit = 20;

	public ShiSha()
	{
	}

	public ShiSha(CombatSkillKey skillKey)
		: base(skillKey, 40702)
	{
	}

	protected override int GetAddDamagePercent()
	{
		int trickCount = base.EnemyChar.UsableTrickCount;
		return 20 * (9 - trickCount);
	}
}

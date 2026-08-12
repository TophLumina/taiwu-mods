using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.LegendaryBook.Common;

namespace GameData.Domains.SpecialEffect.LegendaryBook.Leg;

public class XianSha : AddDamage
{
	private const short MaxDamageMobilityPercent = 50;

	public XianSha()
	{
	}

	public XianSha(CombatSkillKey skillKey)
		: base(skillKey, 40502)
	{
	}

	protected override int GetAddDamagePercent()
	{
		int mobilityPercent = base.CurrEnemyChar.GetMobilityValue() * 100 / MoveSpecialConstants.MaxMobility;
		return (mobilityPercent < 50) ? 180 : (180 * (100 - mobilityPercent) / 50);
	}
}

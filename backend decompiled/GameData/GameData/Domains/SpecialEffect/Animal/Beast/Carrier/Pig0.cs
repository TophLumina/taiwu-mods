using GameData.Combat.Math;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Pig0 : PigBase
{
	protected override short CombatStateId => 150;

	protected override CValuePercent AddCriticalOddsPercent => 40;

	public Pig0()
	{
	}

	public Pig0(int charId)
		: base(charId)
	{
	}
}

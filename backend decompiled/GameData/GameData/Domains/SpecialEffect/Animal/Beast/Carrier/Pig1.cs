using GameData.Combat.Math;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Pig1 : PigBase
{
	protected override short CombatStateId => 159;

	protected override CValuePercent AddCriticalOddsPercent => 60;

	public Pig1()
	{
	}

	public Pig1(int charId)
		: base(charId)
	{
	}
}

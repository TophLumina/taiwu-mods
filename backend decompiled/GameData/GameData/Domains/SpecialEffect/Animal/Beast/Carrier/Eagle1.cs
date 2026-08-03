using GameData.Combat.Math;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Eagle1 : EagleBase
{
	protected override short CombatStateId => 158;

	protected override CValuePercent AddCriticalOddsPercent => 60;

	public Eagle1()
	{
	}

	public Eagle1(int charId)
		: base(charId)
	{
	}
}

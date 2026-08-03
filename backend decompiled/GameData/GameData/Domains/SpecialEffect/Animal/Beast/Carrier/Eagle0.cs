using GameData.Combat.Math;

namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Eagle0 : EagleBase
{
	protected override short CombatStateId => 149;

	protected override CValuePercent AddCriticalOddsPercent => 40;

	public Eagle0()
	{
	}

	public Eagle0(int charId)
		: base(charId)
	{
	}
}

namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Bear0 : BearBase
{
	protected override short CombatStateId => 151;

	protected override int AddOrReduceDirectFatalDamagePercent => 25;

	public Bear0()
	{
	}

	public Bear0(int charId)
		: base(charId)
	{
	}
}

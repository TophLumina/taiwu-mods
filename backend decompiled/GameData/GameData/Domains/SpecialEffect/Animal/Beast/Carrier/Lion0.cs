namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Lion0 : LionBase
{
	protected override short CombatStateId => 155;

	protected override int AddOrReduceCostPercent => 25;

	public Lion0()
	{
	}

	public Lion0(int charId)
		: base(charId)
	{
	}
}

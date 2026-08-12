namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Lion1 : LionBase
{
	protected override short CombatStateId => 164;

	protected override int AddOrReduceCostPercent => 40;

	public Lion1()
	{
	}

	public Lion1(int charId)
		: base(charId)
	{
	}
}

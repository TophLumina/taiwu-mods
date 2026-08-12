namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Bull0 : BullBase
{
	protected override short CombatStateId => 152;

	protected override int BouncePowerAddPercent => 25;

	public Bull0()
	{
	}

	public Bull0(int charId)
		: base(charId)
	{
	}
}

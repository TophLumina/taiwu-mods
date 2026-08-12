namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Bull1 : BullBase
{
	protected override short CombatStateId => 161;

	protected override int BouncePowerAddPercent => 40;

	public Bull1()
	{
	}

	public Bull1(int charId)
		: base(charId)
	{
	}
}

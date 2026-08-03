namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Jaguar0 : JaguarBase
{
	protected override short CombatStateId => 154;

	protected override int FightBackPower => 25;

	public Jaguar0()
	{
	}

	public Jaguar0(int charId)
		: base(charId)
	{
	}
}

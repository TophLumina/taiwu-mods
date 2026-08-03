namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Jaguar1 : JaguarBase
{
	protected override short CombatStateId => 163;

	protected override int FightBackPower => 40;

	public Jaguar1()
	{
	}

	public Jaguar1(int charId)
		: base(charId)
	{
	}
}

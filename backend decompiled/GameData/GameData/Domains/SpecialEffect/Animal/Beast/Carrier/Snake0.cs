namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Snake0 : SnakeBase
{
	protected override short CombatStateId => 153;

	protected override int ChangeHealEffect => 25;

	public Snake0()
	{
	}

	public Snake0(int charId)
		: base(charId)
	{
	}
}

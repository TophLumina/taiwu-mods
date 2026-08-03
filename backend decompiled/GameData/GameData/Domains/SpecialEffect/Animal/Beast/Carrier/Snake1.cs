namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Snake1 : SnakeBase
{
	protected override short CombatStateId => 162;

	protected override int ChangeHealEffect => 40;

	public Snake1()
	{
	}

	public Snake1(int charId)
		: base(charId)
	{
	}
}

namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Monkey0 : MonkeyBase
{
	protected override short CombatStateId => 148;

	protected override int PowerAddOrReduceRatio => 25;

	public Monkey0()
	{
	}

	public Monkey0(int charId)
		: base(charId)
	{
	}
}

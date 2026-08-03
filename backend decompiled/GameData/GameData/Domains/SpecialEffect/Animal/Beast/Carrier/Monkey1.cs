namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Monkey1 : MonkeyBase
{
	protected override short CombatStateId => 157;

	protected override int PowerAddOrReduceRatio => 40;

	public Monkey1()
	{
	}

	public Monkey1(int charId)
		: base(charId)
	{
	}
}

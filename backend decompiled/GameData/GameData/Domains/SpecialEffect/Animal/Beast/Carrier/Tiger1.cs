namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Tiger1 : TigerBase
{
	protected override short CombatStateId => 165;

	protected override int AddDamagePercentUnit => 40;

	public Tiger1()
	{
	}

	public Tiger1(int charId)
		: base(charId)
	{
	}
}

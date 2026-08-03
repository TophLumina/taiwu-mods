namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Tiger0 : TigerBase
{
	protected override short CombatStateId => 156;

	protected override int AddDamagePercentUnit => 20;

	public Tiger0()
	{
	}

	public Tiger0(int charId)
		: base(charId)
	{
	}
}

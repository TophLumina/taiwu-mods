namespace GameData.Domains.SpecialEffect.Animal.Beast.Carrier;

public class Bear1 : BearBase
{
	protected override short CombatStateId => 160;

	protected override int AddOrReduceDirectFatalDamagePercent => 40;

	public Bear1()
	{
	}

	public Bear1(int charId)
		: base(charId)
	{
	}
}

namespace GameData.Domains.SpecialEffect.Adventure.EnemyNest;

public class FiveElementsStoneWood : FiveElementsStoneBase
{
	protected override short CombatStateId => 247;

	protected override sbyte StoneFiveElementsType => 1;

	public FiveElementsStoneWood()
	{
	}

	public FiveElementsStoneWood(int charId)
		: base(charId)
	{
	}
}

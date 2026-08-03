namespace GameData.Domains.SpecialEffect.Adventure.EnemyNest;

public class FiveElementsStoneEarth : FiveElementsStoneBase
{
	protected override short CombatStateId => 250;

	protected override sbyte StoneFiveElementsType => 4;

	public FiveElementsStoneEarth()
	{
	}

	public FiveElementsStoneEarth(int charId)
		: base(charId)
	{
	}
}

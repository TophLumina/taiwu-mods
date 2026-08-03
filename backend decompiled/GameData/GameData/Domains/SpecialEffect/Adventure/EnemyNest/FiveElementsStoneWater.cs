namespace GameData.Domains.SpecialEffect.Adventure.EnemyNest;

public class FiveElementsStoneWater : FiveElementsStoneBase
{
	protected override short CombatStateId => 248;

	protected override sbyte StoneFiveElementsType => 2;

	public FiveElementsStoneWater()
	{
	}

	public FiveElementsStoneWater(int charId)
		: base(charId)
	{
	}
}

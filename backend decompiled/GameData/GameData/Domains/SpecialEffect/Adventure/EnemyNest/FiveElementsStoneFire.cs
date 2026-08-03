namespace GameData.Domains.SpecialEffect.Adventure.EnemyNest;

public class FiveElementsStoneFire : FiveElementsStoneBase
{
	protected override short CombatStateId => 249;

	protected override sbyte StoneFiveElementsType => 3;

	public FiveElementsStoneFire()
	{
	}

	public FiveElementsStoneFire(int charId)
		: base(charId)
	{
	}
}

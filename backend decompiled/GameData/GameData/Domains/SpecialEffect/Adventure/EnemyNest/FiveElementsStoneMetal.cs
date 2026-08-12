namespace GameData.Domains.SpecialEffect.Adventure.EnemyNest;

public class FiveElementsStoneMetal : FiveElementsStoneBase
{
	protected override short CombatStateId => 246;

	protected override sbyte StoneFiveElementsType => 0;

	public FiveElementsStoneMetal()
	{
	}

	public FiveElementsStoneMetal(int charId)
		: base(charId)
	{
	}
}

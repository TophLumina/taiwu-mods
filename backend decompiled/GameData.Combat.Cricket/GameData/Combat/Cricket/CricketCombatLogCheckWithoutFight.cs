namespace GameData.Combat.Cricket;

public class CricketCombatLogCheckWithoutFight : CricketCombatLog
{
	public readonly ECricketWithoutFightType WithoutFightType;

	public CricketCombatLogCheckWithoutFight(ECricketWithoutFightType withoutFightType)
		: base(ECricketCombatLogEventType.CheckWithoutFight)
	{
		WithoutFightType = withoutFightType;
	}

	public override string ToString()
	{
		return base.ToString() + $"->{WithoutFightType}";
	}
}

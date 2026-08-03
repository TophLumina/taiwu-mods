namespace GameData.Combat.Cricket;

public abstract class CricketCombatLogRound : CricketCombatLog
{
	public readonly int Round;

	protected CricketCombatLogRound(ECricketCombatLogEventType type, int round)
		: base(type)
	{
		Round = round;
	}

	public override string ToString()
	{
		return base.ToString() + $"->{Round}";
	}
}

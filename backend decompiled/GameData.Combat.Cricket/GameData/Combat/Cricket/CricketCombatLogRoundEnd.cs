namespace GameData.Combat.Cricket;

public class CricketCombatLogRoundEnd : CricketCombatLogRound, ICricketCombatLogCheckedFirst
{
	public bool LeftFirst { get; }

	public CricketCombatLogRoundEnd(int round, bool leftFirst)
		: base(ECricketCombatLogEventType.RoundEnd, round)
	{
		LeftFirst = leftFirst;
	}

	public override string ToString()
	{
		return base.ToString() + $"->{LeftFirst}";
	}
}

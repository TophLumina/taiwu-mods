namespace GameData.Combat.Cricket;

public class CricketCombatLogRoundStart : CricketCombatLogRound
{
	public CricketCombatLogRoundStart(int round)
		: base(ECricketCombatLogEventType.RoundStart, round)
	{
	}
}

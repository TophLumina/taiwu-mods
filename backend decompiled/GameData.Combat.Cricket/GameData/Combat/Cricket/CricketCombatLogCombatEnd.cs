namespace GameData.Combat.Cricket;

public class CricketCombatLogCombatEnd : CricketCombatLog
{
	public readonly bool Win;

	public CricketCombatLogCombatEnd(bool win)
		: base(ECricketCombatLogEventType.CombatEnd)
	{
		Win = win;
	}

	public override string ToString()
	{
		return base.ToString() + $"->{{{Win}}}";
	}
}

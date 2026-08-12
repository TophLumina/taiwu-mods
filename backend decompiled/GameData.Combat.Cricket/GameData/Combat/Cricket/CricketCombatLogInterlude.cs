namespace GameData.Combat.Cricket;

public class CricketCombatLogInterlude : CricketCombatLog, ICricketCombatLogCheckedFirst
{
	public bool LeftFirst { get; }

	public CricketCombatLogInterlude(bool leftFirst)
		: base(ECricketCombatLogEventType.Interlude)
	{
		LeftFirst = leftFirst;
	}

	public override string ToString()
	{
		return base.ToString() + $"->{LeftFirst}";
	}
}

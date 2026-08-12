namespace GameData.Combat.Cricket;

public class CricketCombatLog
{
	public ECricketCombatLogEventType Type { get; }

	public CricketCombatLog(ECricketCombatLogEventType type)
	{
		Type = type;
	}

	public static implicit operator CricketCombatLog(ECricketCombatLogEventType type)
	{
		return new CricketCombatLog(type);
	}

	public override string ToString()
	{
		return $"Log({Type})";
	}
}

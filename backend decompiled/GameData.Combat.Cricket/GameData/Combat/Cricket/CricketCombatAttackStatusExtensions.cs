namespace GameData.Combat.Cricket;

public static class CricketCombatAttackStatusExtensions
{
	public static bool Contains(this ECricketCombatAttackStatus status, ECricketCombatAttackStatus check)
	{
		return (status & check) == check;
	}
}

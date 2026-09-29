namespace GameData.Domains.Combat;

public class CombatStatusType
{
	public const sbyte NotInCombat = 0;

	public const sbyte InCombat = 1;

	public const sbyte SelfFail = 2;

	public const sbyte EnemyFail = 3;

	public const sbyte SelfFlee = 4;

	public const sbyte EnemyFlee = 5;

	public static bool IsWin(bool ally, sbyte statusType)
	{
		if (ally)
		{
			return (statusType == 3 || statusType == 5) ? true : false;
		}
		return (statusType == 2 || statusType == 4) ? true : false;
	}

	public static bool IsCombatOver(sbyte statusType)
	{
		return statusType > 1;
	}
}

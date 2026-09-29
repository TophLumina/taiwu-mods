namespace GameData.Domains.Combat;

public class CombatResultType
{
	public const sbyte PlayerWin = 0;

	public const sbyte EnemyWin = 1;

	public const sbyte PlayerFlee = 2;

	public const sbyte EnemyFlee = 3;

	public const sbyte PlayerDie = 4;

	public const sbyte EnemyDie = 5;

	public static bool IsPlayerWin(sbyte resultType)
	{
		if (resultType != 0 && resultType != 3)
		{
			return resultType == 5;
		}
		return true;
	}
}

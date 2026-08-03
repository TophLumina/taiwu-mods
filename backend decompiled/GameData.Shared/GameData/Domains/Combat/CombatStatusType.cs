namespace GameData.Domains.Combat;

/// <summary>
/// 战斗状态类型
/// </summary>
public class CombatStatusType
{
	/// <summary>
	/// 未开战
	/// </summary>
	public const sbyte NotInCombat = 0;

	/// <summary>
	/// 战斗中
	/// </summary>
	public const sbyte InCombat = 1;

	/// <summary>
	/// 己方战败
	/// </summary>
	public const sbyte SelfFail = 2;

	/// <summary>
	/// 敌方战败
	/// </summary>
	public const sbyte EnemyFail = 3;

	/// <summary>
	/// 己方逃跑
	/// </summary>
	public const sbyte SelfFlee = 4;

	/// <summary>
	/// 敌方逃跑
	/// </summary>
	public const sbyte EnemyFlee = 5;

	/// <summary>
	/// 判定方是否胜利
	/// </summary>
	public static bool IsWin(bool ally, sbyte statusType)
	{
		if (ally)
		{
			return (statusType == 3 || statusType == 5) ? true : false;
		}
		return (statusType == 2 || statusType == 4) ? true : false;
	}

	/// <summary>
	/// 战斗是否已经结束
	/// </summary>
	public static bool IsCombatOver(sbyte statusType)
	{
		return statusType > 1;
	}
}

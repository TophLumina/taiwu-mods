namespace GameData.Domains.Combat;

/// <summary>
/// 战斗结果类型
/// </summary>
public class CombatResultType
{
	/// <summary>
	/// 玩家胜利
	/// </summary>
	public const sbyte PlayerWin = 0;

	/// <summary>
	/// 敌人胜利
	/// </summary>
	public const sbyte EnemyWin = 1;

	/// <summary>
	/// 玩家逃跑
	/// </summary>
	public const sbyte PlayerFlee = 2;

	/// <summary>
	/// 敌人逃跑
	/// </summary>
	public const sbyte EnemyFlee = 3;

	/// <summary>
	/// 玩家死亡
	/// </summary>
	public const sbyte PlayerDie = 4;

	/// <summary>
	/// 敌人死亡
	/// </summary>
	public const sbyte EnemyDie = 5;

	/// <summary>
	/// 是否玩家胜利
	/// </summary>
	public static bool IsPlayerWin(sbyte resultType)
	{
		if (resultType != 0 && resultType != 3)
		{
			return resultType == 5;
		}
		return true;
	}
}

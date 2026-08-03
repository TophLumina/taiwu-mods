namespace GameData.Domains.Combat;

/// <summary>
/// 其它战斗行为类型
/// </summary>
public static class OtherActionType
{
	/// <summary>
	/// 非法值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 疗伤
	/// </summary>
	public const sbyte HealInjury = 0;

	/// <summary>
	/// 驱毒
	/// </summary>
	public const sbyte HealPoison = 1;

	/// <summary>
	/// 逃跑
	/// </summary>
	public const sbyte Flee = 2;

	/// <summary>
	/// 动物攻击
	/// </summary>
	public const sbyte AnimalAttack = 3;

	/// <summary>
	/// 投降
	/// </summary>
	public const sbyte Surrender = 4;

	/// <summary>
	/// 其它战斗行为类型的个数
	/// </summary>
	public const int Count = 5;
}

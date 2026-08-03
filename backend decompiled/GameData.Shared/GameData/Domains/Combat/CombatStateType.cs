namespace GameData.Domains.Combat;

/// <summary>
/// 战斗buff类型
/// </summary>
public class CombatStateType
{
	/// <summary>
	/// 特殊
	/// </summary>
	public const sbyte Special = 0;

	/// <summary>
	/// 增益
	/// </summary>
	public const sbyte Buff = 1;

	/// <summary>
	/// 减益
	/// </summary>
	public const sbyte Debuff = 2;

	/// <summary>
	/// 类型总数
	/// </summary>
	public const sbyte Count = 3;
}

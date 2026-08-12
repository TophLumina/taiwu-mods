namespace GameData.Domains.Item;

/// <summary>
/// 促织战斗赌注类型
/// </summary>
public static class WagerType
{
	/// <summary>
	/// 非法值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 资源
	/// </summary>
	public const sbyte Resource = 0;

	/// <summary>
	/// 物品
	/// </summary>
	public const sbyte Item = 1;

	/// <summary>
	/// 人物
	/// </summary>
	public const sbyte Character = 2;

	/// <summary>
	/// 历练
	/// </summary>
	public const sbyte Exp = 3;
}

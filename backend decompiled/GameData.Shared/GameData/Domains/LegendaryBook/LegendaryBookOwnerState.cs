namespace GameData.Domains.LegendaryBook;

/// <summary>
/// 奇书持有状态
/// </summary>
public static class LegendaryBookOwnerState
{
	/// <summary>
	/// 非法值（未持有）
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 拥有奇书
	/// </summary>
	public const sbyte OwningBook = 0;

	/// <summary>
	/// 奇书入邪
	/// </summary>
	public const sbyte Shocked = 1;

	/// <summary>
	/// 执迷化魔
	/// </summary>
	public const sbyte Insane = 2;

	/// <summary>
	/// 相枢吞噬
	/// </summary>
	public const sbyte Consumed = 3;
}

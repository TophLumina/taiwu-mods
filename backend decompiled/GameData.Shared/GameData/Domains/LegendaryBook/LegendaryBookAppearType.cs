namespace GameData.Domains.LegendaryBook;

/// <summary>
/// 奇书出现方式类型
/// </summary>
public static class LegendaryBookAppearType
{
	/// <summary>
	/// 新奇书出现
	/// </summary>
	public const sbyte NewBook = 0;

	/// <summary>
	/// 持有者被相枢吞噬
	/// </summary>
	public const sbyte OwnerIsConsumed = 1;

	/// <summary>
	/// 持有者死亡
	/// </summary>
	public const sbyte OwnerIsDead = 2;

	/// <summary>
	/// 奇书丢失
	/// </summary>
	public const sbyte BookLost = 3;
}

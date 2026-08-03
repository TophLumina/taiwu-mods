namespace GameData.Domains.Map;

/// <summary>
/// 方位
/// </summary>
public static class Direction
{
	/// <summary>
	/// 无效
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 东
	/// </summary>
	public const sbyte East = 0;

	/// <summary>
	/// 东北
	/// </summary>
	public const sbyte NorthEast = 1;

	/// <summary>
	/// 北
	/// </summary>
	public const sbyte North = 2;

	/// <summary>
	/// 西北
	/// </summary>
	public const sbyte NorthWest = 3;

	/// <summary>
	/// 西
	/// </summary>
	public const sbyte West = 4;

	/// <summary>
	/// 西南
	/// </summary>
	public const sbyte SouthWest = 5;

	/// <summary>
	/// 南
	/// </summary>
	public const sbyte South = 6;

	/// <summary>
	/// 东南
	/// </summary>
	public const sbyte SouthEast = 7;

	/// <summary>
	/// 中部
	/// </summary>
	public const sbyte Center = 8;
}

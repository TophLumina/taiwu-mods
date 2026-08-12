namespace Config.ConfigCells.Character;

/// <summary>
/// 角色的特性勋章 (攻防智星级) 值
/// </summary>
public static class FeatureMedalValue
{
	/// <summary>
	/// 正向加一 (蓝)
	/// </summary>
	public const sbyte Positive = 0;

	/// <summary>
	/// 逆向加一 (红)
	/// </summary>
	public const sbyte Negative = 1;

	/// <summary>
	/// 双向加一 (白)
	/// </summary>
	public const sbyte TwoWayIncrease = 2;

	/// <summary>
	/// 双向减三 (灰)
	/// </summary>
	public const sbyte TwoWayDecrease = 3;
}

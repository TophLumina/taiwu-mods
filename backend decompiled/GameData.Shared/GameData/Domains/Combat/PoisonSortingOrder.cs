namespace GameData.Domains.Combat;

/// <summary>
/// 毒素类型的顺序
/// </summary>
public static class PoisonSortingOrder
{
	/// <summary>
	/// 非法值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 烈毒
	/// </summary>
	public const sbyte Hot = 0;

	/// <summary>
	/// 郁毒
	/// </summary>
	public const sbyte Gloomy = 1;

	/// <summary>
	/// 赤毒
	/// </summary>
	public const sbyte Red = 2;

	/// <summary>
	/// 寒毒
	/// </summary>
	public const sbyte Cold = 3;

	/// <summary>
	/// 腐毒
	/// </summary>
	public const sbyte Rotten = 4;

	/// <summary>
	/// 幻毒
	/// </summary>
	public const sbyte Illusory = 5;

	/// <summary>
	/// 总数
	/// </summary>
	public const sbyte Count = 6;

	/// <summary>
	/// 通过毒素类型获取毒素顺序
	/// </summary>
	/// <param name="type"></param>
	/// <returns></returns>
	public static sbyte GetSortingOrderByType(sbyte type)
	{
		return type switch
		{
			0 => 0, 
			1 => 1, 
			3 => 2, 
			2 => 3, 
			4 => 4, 
			5 => 5, 
			_ => -1, 
		};
	}
}

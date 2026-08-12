using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 毒素类型
/// </summary>
public static class PoisonType
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
	/// 寒毒
	/// </summary>
	public const sbyte Cold = 2;

	/// <summary>
	/// 赤毒
	/// </summary>
	public const sbyte Red = 3;

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
	/// 外伤毒
	/// </summary>
	public static readonly IReadOnlyList<sbyte> OuterPoison = new sbyte[3] { 0, 3, 4 };

	/// <summary>
	/// 内伤毒
	/// </summary>
	public static readonly IReadOnlyList<sbyte> InnerPoison = new sbyte[3] { 1, 2, 5 };

	/// <summary>
	/// 毒素类型属于外伤毒
	/// </summary>
	public static bool IsOuter(sbyte poisonType)
	{
		return OuterPoison.Exist(poisonType);
	}

	/// <summary>
	/// 毒素类型属于内伤毒
	/// </summary>
	public static bool IsInner(sbyte poisonType)
	{
		return InnerPoison.Exist(poisonType);
	}

	/// <summary>
	/// 通过毒素顺序获取毒素类型
	/// </summary>
	/// <param name="order"></param>
	/// <returns></returns>
	public static sbyte GetTypeBySortingOrder(sbyte order)
	{
		return order switch
		{
			0 => 0, 
			1 => 1, 
			2 => 3, 
			3 => 2, 
			4 => 4, 
			5 => 5, 
			_ => -1, 
		};
	}
}

using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public static class PoisonType
{
	public const sbyte Invalid = -1;

	public const sbyte Hot = 0;

	public const sbyte Gloomy = 1;

	public const sbyte Cold = 2;

	public const sbyte Red = 3;

	public const sbyte Rotten = 4;

	public const sbyte Illusory = 5;

	public const sbyte Count = 6;

	public static readonly IReadOnlyList<sbyte> OuterPoison = new sbyte[3] { 0, 3, 4 };

	public static readonly IReadOnlyList<sbyte> InnerPoison = new sbyte[3] { 1, 2, 5 };

	public static bool IsOuter(sbyte poisonType)
	{
		return OuterPoison.Exist(poisonType);
	}

	public static bool IsInner(sbyte poisonType)
	{
		return InnerPoison.Exist(poisonType);
	}

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

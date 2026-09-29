namespace GameData.Domains.Combat;

public static class PoisonSortingOrder
{
	public const sbyte Invalid = -1;

	public const sbyte Hot = 0;

	public const sbyte Gloomy = 1;

	public const sbyte Red = 2;

	public const sbyte Cold = 3;

	public const sbyte Rotten = 4;

	public const sbyte Illusory = 5;

	public const sbyte Count = 6;

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

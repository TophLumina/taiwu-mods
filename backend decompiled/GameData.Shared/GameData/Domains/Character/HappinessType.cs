using System;

namespace GameData.Domains.Character;

public static class HappinessType
{
	public const sbyte Invalid = -1;

	public const sbyte Saddest = 0;

	public const sbyte Painful = 1;

	public const sbyte Depressed = 2;

	public const sbyte Normal = 3;

	public const sbyte Pleased = 4;

	public const sbyte Delighted = 5;

	public const sbyte Happiest = 6;

	public const sbyte MinValue = -119;

	public const sbyte MaxValue = 119;

	public static readonly (sbyte min, sbyte max)[] Ranges = new(sbyte, sbyte)[7]
	{
		(-119, -90),
		(-89, -60),
		(-59, -30),
		(-29, 29),
		(30, 59),
		(60, 89),
		(90, 119)
	};

	public static sbyte GetHappinessType(sbyte happiness)
	{
		return (happiness / 30) switch
		{
			-3 => 0, 
			-2 => 1, 
			-1 => 2, 
			0 => 3, 
			1 => 4, 
			2 => 5, 
			3 => 6, 
			_ => throw new ArgumentOutOfRangeException($"Happiness out of range: {happiness}"), 
		};
	}
}

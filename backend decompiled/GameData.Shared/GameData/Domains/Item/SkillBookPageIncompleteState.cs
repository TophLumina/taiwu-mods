namespace GameData.Domains.Item;

public static class SkillBookPageIncompleteState
{
	public const sbyte Invalid = -1;

	public const sbyte Complete = 0;

	public const sbyte Incomplete = 1;

	public const sbyte Lost = 2;

	public static readonly sbyte[] BaseReadingSpeed = new sbyte[3] { 50, 10, 1 };

	public static readonly sbyte[] ReadingPointCost = new sbyte[3] { 30, 60, 100 };

	public static readonly sbyte[] BaseReadingSuccessRate = new sbyte[3] { 100, 50, 25 };

	public static readonly sbyte[] GearMateReadingSpeed = new sbyte[3] { 100, 40, 10 };
}

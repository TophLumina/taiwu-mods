namespace GameData.Domains.CombatSkill;

public static class FiveElementsType
{
	public const sbyte Metal = 0;

	public const sbyte Wood = 1;

	public const sbyte Water = 2;

	public const sbyte Fire = 3;

	public const sbyte Earth = 4;

	public const sbyte Mix = 5;

	public const int Count = 5;

	public static readonly sbyte[] Countering = new sbyte[5] { 1, 4, 3, 0, 2 };

	public static readonly sbyte[] Countered = new sbyte[5] { 3, 0, 4, 2, 1 };

	public static readonly sbyte[] Producing = new sbyte[5] { 2, 3, 1, 4, 0 };

	public static readonly sbyte[] Produced = new sbyte[5] { 4, 2, 0, 1, 3 };
}

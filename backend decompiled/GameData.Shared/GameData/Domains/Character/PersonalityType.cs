namespace GameData.Domains.Character;

public static class PersonalityType
{
	public const sbyte Invalid = -1;

	public const sbyte Calm = 0;

	public const sbyte Clever = 1;

	public const sbyte Enthusiastic = 2;

	public const sbyte Brave = 3;

	public const sbyte Firm = 4;

	public const sbyte Lucky = 5;

	public const sbyte Perceptive = 6;

	public const int Count = 7;

	public static readonly sbyte[] Countering = new sbyte[5] { 2, 3, 4, 0, 1 };

	public static readonly sbyte[] Countered = new sbyte[5] { 3, 4, 0, 1, 2 };

	public static readonly sbyte[] Producing = new sbyte[5] { 1, 2, 3, 4, 0 };

	public static readonly sbyte[] Produced = new sbyte[5] { 4, 0, 1, 2, 3 };
}

using Redzen.Random;

namespace GameData.Domains.Character;

public static class Gender
{
	public const sbyte Unknown = -1;

	public const sbyte Female = 0;

	public const sbyte Male = 1;

	public const int Count = 2;

	public static sbyte Flip(sbyte gender)
	{
		return (gender != 1) ? ((sbyte)1) : ((sbyte)0);
	}

	public static sbyte GetRandom(IRandomSource random)
	{
		return (sbyte)random.Next(2);
	}
}

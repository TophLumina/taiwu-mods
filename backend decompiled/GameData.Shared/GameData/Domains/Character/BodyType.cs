using Redzen.Random;

namespace GameData.Domains.Character;

public static class BodyType
{
	public const sbyte Unknown = -1;

	public const sbyte Thin = 0;

	public const sbyte Normal = 1;

	public const sbyte Fat = 2;

	public const int Count = 3;

	public static sbyte GetRandom(IRandomSource random)
	{
		return (sbyte)random.Next(3);
	}
}

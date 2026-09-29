using GameData.Utilities;

namespace GameData.Domains.Character;

public static class AttractionType
{
	public const sbyte NonHuman = 0;

	public const sbyte Odious = 1;

	public const sbyte Ugly = 2;

	public const sbyte Normal = 3;

	public const sbyte Outstanding = 4;

	public const sbyte Beautiful = 5;

	public const sbyte Brilliant = 6;

	public const sbyte Stunning = 7;

	public const sbyte Godlike = 8;

	public const short MinValue = 0;

	public const short MaxValue = 900;

	public const short DefaultValue = 450;

	public static sbyte GetAttractionType(short attraction)
	{
		return (sbyte)MathUtils.Clamp(attraction / 100, 0, 8);
	}
}

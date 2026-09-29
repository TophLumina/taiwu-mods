using Redzen.Random;

namespace GameData.Domains.Character.Relation;

public static class FavorabilityType
{
	public const sbyte Unknown = sbyte.MinValue;

	public const sbyte Hateful6 = -6;

	public const sbyte Hateful5 = -5;

	public const sbyte Hateful4 = -4;

	public const sbyte Hateful3 = -3;

	public const sbyte Hateful2 = -2;

	public const sbyte Hateful1 = -1;

	public const sbyte Unfamiliar = 0;

	public const sbyte Favorite1 = 1;

	public const sbyte Favorite2 = 2;

	public const sbyte Favorite3 = 3;

	public const sbyte Favorite4 = 4;

	public const sbyte Favorite5 = 5;

	public const sbyte Favorite6 = 6;

	public const int Count = 13;

	public const short MinValue = -30000;

	public const short MaxValue = 30000;

	public const short DefaultValue = 0;

	public const short BaseInitialValue = 3000;

	public const short TaiwuVillagerBonus = 9000;

	public const short UnknownValue = short.MinValue;

	public static sbyte GetFavorabilityType(short favorability)
	{
		if (favorability == short.MinValue)
		{
			return 0;
		}
		if (favorability >= 6000)
		{
			int type = 1 + (favorability - 6000) / 4000;
			if (type > 6)
			{
				return 6;
			}
			return (sbyte)type;
		}
		if (favorability <= -6000)
		{
			int type2 = -1 + (favorability + 6000) / 4000;
			if (type2 < -6)
			{
				return -6;
			}
			return (sbyte)type2;
		}
		return 0;
	}

	public static (short, short) GetFavorabilityRange(short favorability)
	{
		if (favorability >= -6000 && favorability <= 6000)
		{
			return (-6000, 6000);
		}
		short rangeMin = -30000;
		short rangeMax = (short)(rangeMin + 4000);
		while (rangeMin <= 30000 && (favorability < rangeMin || favorability >= rangeMax))
		{
			rangeMin += 4000;
			rangeMax = (short)(rangeMin + 4000);
			if (rangeMax >= 30000)
			{
				break;
			}
		}
		return (rangeMin, rangeMax);
	}

	public static short GetRandomFavorability(IRandomSource random, sbyte favorabilityType)
	{
		if (favorabilityType != 0)
		{
			int num = ((favorabilityType > 0) ? favorabilityType : (-favorabilityType));
			int minValue = (num - 1) * 4000 + 6000;
			int range = ((num != 6) ? 4000 : 4001);
			int value = minValue + random.Next(range);
			return (short)((favorabilityType > 0) ? value : (-value));
		}
		return (short)random.Next(-5999, 6000);
	}

	public static sbyte ToIndex(sbyte favorabilityType)
	{
		return (sbyte)(favorabilityType - -6);
	}
}

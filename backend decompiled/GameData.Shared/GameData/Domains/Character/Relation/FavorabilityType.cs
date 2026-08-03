using Redzen.Random;

namespace GameData.Domains.Character.Relation;

/// <summary>
/// 好感类型
/// </summary>
public static class FavorabilityType
{
	/// <summary>
	/// 未相识
	/// </summary>
	public const sbyte Unknown = sbyte.MinValue;

	/// <summary>
	/// 血仇
	/// </summary>
	public const sbyte Hateful6 = -6;

	/// <summary>
	/// 痛恨
	/// </summary>
	public const sbyte Hateful5 = -5;

	/// <summary>
	/// 憎恨
	/// </summary>
	public const sbyte Hateful4 = -4;

	/// <summary>
	/// 仇视
	/// </summary>
	public const sbyte Hateful3 = -3;

	/// <summary>
	/// 敌视
	/// </summary>
	public const sbyte Hateful2 = -2;

	/// <summary>
	/// 鄙视
	/// </summary>
	public const sbyte Hateful1 = -1;

	/// <summary>
	/// 陌路
	/// </summary>
	public const sbyte Unfamiliar = 0;

	/// <summary>
	/// 冷淡
	/// </summary>
	public const sbyte Favorite1 = 1;

	/// <summary>
	/// 融洽
	/// </summary>
	public const sbyte Favorite2 = 2;

	/// <summary>
	/// 热忱
	/// </summary>
	public const sbyte Favorite3 = 3;

	/// <summary>
	/// 喜爱
	/// </summary>
	public const sbyte Favorite4 = 4;

	/// <summary>
	/// 亲密
	/// </summary>
	public const sbyte Favorite5 = 5;

	/// <summary>
	/// 不渝
	/// </summary>
	public const sbyte Favorite6 = 6;

	/// <summary>
	/// 好感类型个数
	/// </summary>
	public const int Count = 13;

	/// <summary>
	/// 好感最小值
	/// </summary>
	public const short MinValue = -30000;

	/// <summary>
	/// 好感最大值
	/// </summary>
	public const short MaxValue = 30000;

	/// <summary>
	/// 默认好感
	/// </summary>
	public const short DefaultValue = 0;

	/// <summary>
	/// 基础初始好感
	/// </summary>
	public const short BaseInitialValue = 3000;

	/// <summary>
	/// 太吾村民额外好感
	/// </summary>
	public const short TaiwuVillagerBonus = 9000;

	/// <summary>
	/// 表示未相识的好感度
	/// </summary>
	public const short UnknownValue = short.MinValue;

	/// <summary>
	/// 根据好感度计算好感类型
	/// </summary>
	/// <param name="favorability">
	/// 好感度, 取值范围: [-30000, 30000].
	/// [-30000, -26000]: 血仇, (-26000, -22000]: 痛恨, (-22000, -18000]: 憎恨,
	/// (-18000, -14000]: 仇视, (-14000, -10000]: 敌视, (-10000, -6000]: 鄙视,
	/// (-6000, 6000): 陌路,
	/// [6000, 10000): 冷淡, [10000, 14000): 融洽, [14000, 18000): 热忱,
	/// [18000, 22000): 喜爱, [22000, 26000): 亲密, [26000, 30000]: 不渝.
	/// </param>
	/// <returns></returns>
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

	/// <summary>
	/// 获取当前好感度所处好感度区间范围
	/// </summary>
	/// <param name="favorability"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 通过好感类型获取随机的好感度
	/// </summary>
	/// <param name="random"></param>
	/// <param name="favorabilityType">好感类型, 取值范围 [-6, 6].</param>
	/// <returns></returns>
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

	/// <summary>
	/// 把类型转化为索引 (以便按数组形式存放各类型数据)
	/// </summary>
	/// <param name="favorabilityType"></param>
	/// <returns></returns>
	public static sbyte ToIndex(sbyte favorabilityType)
	{
		return (sbyte)(favorabilityType - -6);
	}
}

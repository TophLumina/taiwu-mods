using System;

namespace GameData.Domains.Character;

/// <summary>
/// 名誉类型
/// </summary>
public static class FameType
{
	/// <summary>
	/// 无效值
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 亦正亦邪
	/// </summary>
	public const sbyte BothGoodAndBad = -2;

	/// <summary>
	/// 妖魔鬼怪
	/// </summary>
	public const sbyte Worst = 0;

	/// <summary>
	/// 千夫所指
	/// </summary>
	public const sbyte Worse = 1;

	/// <summary>
	/// 名声败坏
	/// </summary>
	public const sbyte Bad = 2;

	/// <summary>
	/// 默默无闻 / 亦正亦邪
	/// </summary>
	public const sbyte Normal = 3;

	/// <summary>
	/// 立身扬名
	/// </summary>
	public const sbyte Good = 4;

	/// <summary>
	/// 声驰千里
	/// </summary>
	public const sbyte Better = 5;

	/// <summary>
	/// 誉满天下
	/// </summary>
	public const sbyte Best = 6;

	/// <summary>
	/// 最小值
	/// </summary>
	public const sbyte MinValue = -100;

	/// <summary>
	/// 负面名誉阈值 (小于等于此值即为负面)
	/// </summary>
	public const sbyte BadThresholdValue = -25;

	/// <summary>
	/// 正面名誉阈值 (大于等于此值即为正面)
	/// </summary>
	public const sbyte GoodThresholdValue = 25;

	/// <summary>
	/// 最大值
	/// </summary>
	public const sbyte MaxValue = 100;

	/// <summary>
	/// 计算名誉类型 (不包括亦正亦邪)
	/// </summary>
	/// <param name="fame">
	/// 取值范围 [-100, 100].
	/// [-100, -75]: 妖魔鬼怪, (-75, -50]: 千夫所指, (-50, -25]: 名声败坏,
	/// (-25, 25): 默默无闻 / 亦正亦邪,
	/// [25, 50): 立身扬名, [50, 75): 声驰千里, [75, 100]: 誉满天下.
	/// </param>
	/// <returns></returns>
	public static sbyte GetFameType(sbyte fame)
	{
		switch (fame / 25)
		{
		case -4:
		case -3:
			return 0;
		case -2:
			return 1;
		case -1:
			return 2;
		case 0:
			return 3;
		case 1:
			return 4;
		case 2:
			return 5;
		case 3:
		case 4:
			return 6;
		default:
			throw new ArgumentOutOfRangeException($"Fame out of range: {fame}");
		}
	}

	/// <summary>
	/// 粗略地根据名誉类型计算出名誉值
	/// <para>应该尽量避免使用</para>
	/// </summary>
	public static sbyte CalcFameByFameType(sbyte fameType)
	{
		if ((uint)(fameType - -2) <= 1u)
		{
			fameType = 3;
		}
		return (sbyte)(-100f + 200f * (1f * (float)fameType / 7f));
	}

	/// <summary>
	/// 检查两个名誉类型是否对立。
	/// </summary>
	/// <param name="fameTypeA"></param>
	/// <param name="fameTypeB"></param>
	/// <returns></returns>
	public static bool IsContradictory(sbyte fameTypeA, sbyte fameTypeB)
	{
		return (fameTypeA - 3) * (fameTypeB - 3) < 0;
	}

	/// <summary>
	/// 检查两个名誉类型是否为同类。该方法无法用来判断亦正亦邪，需要在调用前将其随机选取为正或邪。
	/// </summary>
	/// <param name="fameTypeA"></param>
	/// <param name="fameTypeB"></param>
	/// <returns></returns>
	public static bool IsSameSide(sbyte fameTypeA, sbyte fameTypeB)
	{
		if (fameTypeA != fameTypeB)
		{
			return (fameTypeA - 3) * (fameTypeB - 3) > 0;
		}
		return true;
	}

	/// <summary>
	/// 判断指定名誉类型是否为非负面类型（默默无名及以上，包含亦正亦邪）
	/// </summary>
	/// <param name="fameType">名誉类型</param>
	/// <param name="includeBothGoodAndBad">是否包含亦正亦邪</param>
	/// <returns>指定名誉是否为非负面</returns>
	public static bool IsNonNegative(sbyte fameType, bool includeBothGoodAndBad = true)
	{
		if (fameType < 3)
		{
			if (includeBothGoodAndBad)
			{
				return fameType == -2;
			}
			return false;
		}
		return true;
	}

	/// <summary>
	/// 名誉是否会被义士攻击
	/// </summary>
	/// <param name="fameType"></param>
	/// <returns></returns>
	public static bool AttackByRighteous(sbyte fameType)
	{
		if (fameType <= 1)
		{
			return fameType != -2;
		}
		return false;
	}
}

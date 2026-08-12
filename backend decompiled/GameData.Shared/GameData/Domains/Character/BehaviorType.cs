using System;
using Redzen.Random;

namespace GameData.Domains.Character;

/// <summary>
/// 角色的立场类型
/// </summary>
public static class BehaviorType
{
	/// <summary>
	/// 无效
	/// </summary>
	public const sbyte Invalid = -1;

	/// <summary>
	/// 刚正
	/// </summary>
	public const sbyte Just = 0;

	/// <summary>
	/// 仁善
	/// </summary>
	public const sbyte Kind = 1;

	/// <summary>
	/// 中庸
	/// </summary>
	public const sbyte Even = 2;

	/// <summary>
	/// 叛逆
	/// </summary>
	public const sbyte Rebel = 3;

	/// <summary>
	/// 唯我
	/// </summary>
	public const sbyte Egoistic = 4;

	/// <summary>
	/// 角色的立场类型的个数
	/// </summary>
	public const int Count = 5;

	/// <summary>
	/// 最小值
	/// </summary>
	public const short MinValue = -500;

	/// <summary>
	/// 最大值
	/// </summary>
	public const short MaxValue = 500;

	/// <summary>
	/// 未知值
	/// </summary>
	public const short UnknownValue = short.MaxValue;

	private static readonly sbyte[][] ToContradictoryBehaviorType = new sbyte[5][]
	{
		new sbyte[2] { 3, 4 },
		new sbyte[2] { 3, 4 },
		new sbyte[2] { 0, 4 },
		new sbyte[2] { 0, 1 },
		new sbyte[2] { 0, 1 }
	};

	/// <summary>
	/// 事件选项对应引起立场值变化的极限值
	/// </summary>
	private static readonly short[] EventOptionBehaviorValue = new short[5] { 500, 250, 0, -250, -500 };

	/// <summary>
	/// 每个立场类型的取值范围
	/// </summary>
	public static readonly (short min, short max)[] Ranges = new(short, short)[5]
	{
		(375, 500),
		(125, 374),
		(-124, 124),
		(-374, -125),
		(-500, -375)
	};

	/// <summary>
	/// A 立场是否与 B 立场相合
	/// </summary>
	/// <param name="behaviorTypeA"></param>
	/// <param name="behaviorTypeB"></param>
	/// <returns></returns>
	public static bool IsHarmonious(sbyte behaviorTypeA, sbyte behaviorTypeB)
	{
		return behaviorTypeA switch
		{
			0 => behaviorTypeB == 0, 
			1 => (uint)behaviorTypeB <= 1u, 
			2 => behaviorTypeB == 2, 
			3 => (uint)(behaviorTypeB - 3) <= 1u, 
			4 => behaviorTypeB == 4, 
			_ => false, 
		};
	}

	/// <summary>
	/// A 立场是否与 B 立场相冲
	/// </summary>
	/// <param name="behaviorTypeA"></param>
	/// <param name="behaviorTypeB"></param>
	/// <returns></returns>
	public static bool IsConflicting(sbyte behaviorTypeA, sbyte behaviorTypeB)
	{
		switch (behaviorTypeA)
		{
		case 0:
		case 1:
			return (uint)(behaviorTypeB - 3) <= 1u;
		case 2:
			return (behaviorTypeB == 0 || behaviorTypeB == 4) ? true : false;
		case 3:
		case 4:
			return (uint)behaviorTypeB <= 1u;
		default:
			return false;
		}
	}

	/// <summary>
	/// 计算立场类型
	/// </summary>
	/// <param name="morality">
	/// 取值范围 [-500, 500].
	/// [-500, -375]: 唯我, (-375, -125]: 叛逆, (-125, 125): 中庸, [125, 375): 仁善, [375, 500]: 刚正.
	/// </param>
	/// <returns></returns>
	public static sbyte GetBehaviorType(short morality)
	{
		switch (morality / 125)
		{
		case -4:
		case -3:
			return 4;
		case -2:
		case -1:
			return 3;
		case 0:
			return 2;
		case 1:
		case 2:
			return 1;
		case 3:
		case 4:
			return 0;
		default:
			throw new ArgumentOutOfRangeException($"Morality out of range: {morality}");
		}
	}

	/// <summary>
	/// 根据立场类型获取立场中间值
	/// </summary>
	/// <param name="behaviorType"></param>
	/// <returns></returns>
	public static short GetMiddleMoralityByBehaviorType(sbyte behaviorType)
	{
		var (min, max) = Ranges[behaviorType];
		return (short)((min + max) / 2);
	}

	/// <summary>
	/// 检查两个立场是否对立(对方立场是否是自己的立场的对立立场)。
	/// </summary>
	/// <param name="behaviorTypeA"></param>
	/// <param name="behaviorTypeB"></param>
	/// <returns>对立返回 true,否则返回 false</returns>
	public static bool IsContradictory(sbyte behaviorTypeA, sbyte behaviorTypeB)
	{
		if (ToContradictoryBehaviorType[behaviorTypeA][0] != behaviorTypeB)
		{
			return ToContradictoryBehaviorType[behaviorTypeA][1] == behaviorTypeB;
		}
		return true;
	}

	/// <summary>
	/// 检查两个立场是否相近（不包括相同）
	/// </summary>
	/// <param name="behaviorTypeA"></param>
	/// <param name="behaviorTypeB"></param>
	/// <returns></returns>
	public static bool IsClose(sbyte behaviorTypeA, sbyte behaviorTypeB)
	{
		return Math.Abs(behaviorTypeA - behaviorTypeB) == 1;
	}

	/// <summary>
	/// 检查两个立场是否相同或者相近
	/// </summary>
	/// <param name="behaviorTypeA"></param>
	/// <param name="behaviorTypeB"></param>
	/// <returns></returns>
	public static bool IsCloseOrSame(sbyte behaviorTypeA, sbyte behaviorTypeB)
	{
		return Math.Abs(behaviorTypeA - behaviorTypeB) <= 1;
	}

	/// <summary>
	/// 获取所有立场类型, 使用相似度排序, 最相似的排在最前
	/// </summary>
	/// <param name="morality"></param>
	/// <param name="pBehaviorTypes">由调用者申请的内存, 长度为 BehaviorType.Count </param>
	public unsafe static void SortBehaviorTypesBySimilarity(short morality, sbyte* pBehaviorTypes)
	{
		sbyte behaviorType = GetBehaviorType(morality);
		(short min, short max) tuple = Ranges[behaviorType];
		short rangeMin = tuple.min;
		bool closeToGreater = tuple.max - morality >= morality - rangeMin;
		int smaller = behaviorType + 1;
		int greater = behaviorType - 1;
		*pBehaviorTypes = behaviorType;
		int index = 1;
		while (index < 5)
		{
			if (closeToGreater)
			{
				if (greater >= 0)
				{
					pBehaviorTypes[index++] = (sbyte)greater;
				}
				if (smaller < 5)
				{
					pBehaviorTypes[index++] = (sbyte)smaller;
				}
			}
			else
			{
				if (smaller < 5)
				{
					pBehaviorTypes[index++] = (sbyte)smaller;
				}
				if (greater >= 0)
				{
					pBehaviorTypes[index++] = (sbyte)greater;
				}
			}
			smaller++;
			greater--;
		}
	}

	/// <summary>
	/// 获取随机的立场类型
	/// </summary>
	/// <param name="random"></param>
	/// <returns></returns>
	public static sbyte GetRandomBehaviorType(IRandomSource random)
	{
		return (sbyte)random.Next(5);
	}

	/// <summary>
	/// 获得事件选项产生的立场变化量
	/// </summary>
	/// <param name="optionBehaviorType">选项的立场类型</param>
	/// <param name="prevBehaviorValue">变化前的立场值</param>
	/// <returns>立场的变化量</returns>
	public static short GetBehaviorChangeDeltaByEventSelect(sbyte optionBehaviorType, short prevBehaviorValue)
	{
		short limitValue = EventOptionBehaviorValue[optionBehaviorType];
		if ((short)Math.Abs(prevBehaviorValue - limitValue) < 10)
		{
			return (short)(limitValue - prevBehaviorValue);
		}
		return (short)(Math.Sign(limitValue - prevBehaviorValue) * 10);
	}
}

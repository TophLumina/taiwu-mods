using System;
using Redzen.Random;

namespace GameData.Domains.Character;

public static class BehaviorType
{
	public const sbyte Invalid = -1;

	public const sbyte Just = 0;

	public const sbyte Kind = 1;

	public const sbyte Even = 2;

	public const sbyte Rebel = 3;

	public const sbyte Egoistic = 4;

	public const int Count = 5;

	public const short MinValue = -500;

	public const short MaxValue = 500;

	public const short UnknownValue = short.MaxValue;

	private static readonly sbyte[][] ToContradictoryBehaviorType = new sbyte[5][]
	{
		new sbyte[2] { 3, 4 },
		new sbyte[2] { 3, 4 },
		new sbyte[2] { 0, 4 },
		new sbyte[2] { 0, 1 },
		new sbyte[2] { 0, 1 }
	};

	private static readonly short[] EventOptionBehaviorValue = new short[5] { 500, 250, 0, -250, -500 };

	public static readonly (short min, short max)[] Ranges = new(short, short)[5]
	{
		(375, 500),
		(125, 374),
		(-124, 124),
		(-374, -125),
		(-500, -375)
	};

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

	public static short GetMiddleMoralityByBehaviorType(sbyte behaviorType)
	{
		var (min, max) = Ranges[behaviorType];
		return (short)((min + max) / 2);
	}

	public static bool IsContradictory(sbyte behaviorTypeA, sbyte behaviorTypeB)
	{
		if (ToContradictoryBehaviorType[behaviorTypeA][0] != behaviorTypeB)
		{
			return ToContradictoryBehaviorType[behaviorTypeA][1] == behaviorTypeB;
		}
		return true;
	}

	public static bool IsClose(sbyte behaviorTypeA, sbyte behaviorTypeB)
	{
		return Math.Abs(behaviorTypeA - behaviorTypeB) == 1;
	}

	public static bool IsCloseOrSame(sbyte behaviorTypeA, sbyte behaviorTypeB)
	{
		return Math.Abs(behaviorTypeA - behaviorTypeB) <= 1;
	}

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

	public static sbyte GetRandomBehaviorType(IRandomSource random)
	{
		return (sbyte)random.Next(5);
	}

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

using System;

namespace GameData.Domains.Character;

public static class FameType
{
	public const sbyte Invalid = -1;

	public const sbyte BothGoodAndBad = -2;

	public const sbyte Worst = 0;

	public const sbyte Worse = 1;

	public const sbyte Bad = 2;

	public const sbyte Normal = 3;

	public const sbyte Good = 4;

	public const sbyte Better = 5;

	public const sbyte Best = 6;

	public const sbyte MinValue = -100;

	public const sbyte BadThresholdValue = -25;

	public const sbyte GoodThresholdValue = 25;

	public const sbyte MaxValue = 100;

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

	public static sbyte CalcFameByFameType(sbyte fameType)
	{
		if ((uint)(fameType - -2) <= 1u)
		{
			fameType = 3;
		}
		return (sbyte)(-100f + 200f * (1f * (float)fameType / 7f));
	}

	public static bool IsContradictory(sbyte fameTypeA, sbyte fameTypeB)
	{
		return (fameTypeA - 3) * (fameTypeB - 3) < 0;
	}

	public static bool IsSameSide(sbyte fameTypeA, sbyte fameTypeB)
	{
		if (fameTypeA != fameTypeB)
		{
			return (fameTypeA - 3) * (fameTypeB - 3) > 0;
		}
		return true;
	}

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

	public static bool AttackByRighteous(sbyte fameType)
	{
		if (fameType <= 1)
		{
			return fameType != -2;
		}
		return false;
	}
}

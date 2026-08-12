using GameData.Combat.Math.Exceptions;

namespace GameData.Combat.Math;

internal static class CombatMath
{
	public static int Abs(int val)
	{
		if (val >= 0)
		{
			return val;
		}
		return -val;
	}

	public static int Max(int a, int b)
	{
		if (a <= b)
		{
			return b;
		}
		return a;
	}

	public static int Min(int a, int b)
	{
		if (a >= b)
		{
			return b;
		}
		return a;
	}

	public static CValuePercentBonus Min(CValuePercentBonus a, CValuePercentBonus b)
	{
		return Min((int)a, (int)b);
	}

	public static CValuePercentBonus Max(CValuePercentBonus a, CValuePercentBonus b)
	{
		return Max((int)a, (int)b);
	}

	public static int Clamp(int value, int min, int max)
	{
		if (min > max)
		{
			throw new CombatMathException($"Clamp {value} min {min} cannot be greater than max {max}.");
		}
		if (value >= min)
		{
			if (value <= max)
			{
				return value;
			}
			return max;
		}
		return min;
	}

	public static long Clamp(long value, long min, long max)
	{
		if (min > max)
		{
			throw new CombatMathException($"Clamp {value} min {min} cannot be greater than max {max}.");
		}
		if (value >= min)
		{
			if (value <= max)
			{
				return value;
			}
			return max;
		}
		return min;
	}

	public static int CalcGcd(int numerator, int denominator)
	{
		numerator = Abs(numerator);
		denominator = Abs(denominator);
		while (denominator != 0)
		{
			int num = denominator;
			denominator = numerator % denominator;
			numerator = num;
		}
		return numerator;
	}
}

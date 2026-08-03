using System;

namespace GameData.Combat.Math;

public readonly struct CValueFraction
{
	private readonly int _numerator;

	private readonly int _denominator;

	private readonly bool _roundUp;

	public int Gcd => CombatMath.CalcGcd(_numerator, _denominator);

	public CValueFraction(int numerator, int denominator, bool roundUp = false)
	{
		if (denominator == 0)
		{
			throw new DivideByZeroException($"Denominator {denominator} cannot be zero. Numerator: {numerator}");
		}
		_numerator = numerator;
		_denominator = denominator;
		_roundUp = roundUp;
	}

	public static int operator *(int value, CValueFraction fraction)
	{
		return (int)CombatMath.Clamp((long)value * fraction, -2147483648L, 2147483647L);
	}

	public static long operator *(long value, CValueFraction fraction)
	{
		value *= fraction._numerator;
		long result = value / fraction._denominator;
		if (fraction._roundUp)
		{
			result += ((value % fraction._denominator > 0) ? 1 : 0);
		}
		return result;
	}

	public static CValueFraction operator *(CValueFraction a, CValueFraction b)
	{
		int gcdA = a.Gcd;
		int gcdB = b.Gcd;
		int numerator = a._numerator / gcdA * (b._numerator / gcdB);
		int denominator = a._denominator / gcdA * (b._denominator / gcdB);
		return new CValueFraction(numerator, denominator, a._roundUp || b._roundUp);
	}
}

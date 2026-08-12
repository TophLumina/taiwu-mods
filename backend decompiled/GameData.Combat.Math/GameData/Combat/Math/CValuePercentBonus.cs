using System;

namespace GameData.Combat.Math;

public struct CValuePercentBonus : IEquatable<CValuePercentBonus>
{
	private int _percentValue;

	public static implicit operator CValuePercentBonus(int percentValue)
	{
		return new CValuePercentBonus
		{
			_percentValue = percentValue
		};
	}

	public static explicit operator CValuePercent(CValuePercentBonus percentBonus)
	{
		return percentBonus._percentValue + 100;
	}

	public static explicit operator CValuePercentBonus(CValuePercent percent)
	{
		return new CValuePercentBonus
		{
			_percentValue = (int)percent - 100
		};
	}

	public static explicit operator int(CValuePercentBonus percentBonus)
	{
		return percentBonus._percentValue;
	}

	public static long operator *(long value, CValuePercentBonus percentBonus)
	{
		return value * (percentBonus._percentValue + 100) / 100;
	}

	public static int operator *(int value, CValuePercentBonus percentBonus)
	{
		return (int)CombatMath.Clamp((long)value * percentBonus, -2147483648L, 2147483647L);
	}

	public static CValuePercentBonus operator *(CValuePercentBonus lhs, CValuePercentBonus rhs)
	{
		return new CValuePercentBonus
		{
			_percentValue = lhs._percentValue * rhs._percentValue / 100 + lhs._percentValue + rhs._percentValue
		};
	}

	[Obsolete("This operator may be mistaken for multiplying another CValuePercentBonus, use 'percent *= (CValuePercentBonus)ratio' or 'percent *= (CValueMultiplier)ratio instead.'", true)]
	public static CValuePercentBonus operator *(CValuePercentBonus percent, int ratio)
	{
		return new CValuePercentBonus
		{
			_percentValue = percent._percentValue * ratio
		};
	}

	public static CValuePercentBonus operator ^(CValuePercentBonus bonus, CValuePercentBonus ratio)
	{
		return new CValuePercentBonus
		{
			_percentValue = bonus._percentValue * ratio
		};
	}

	public static CValuePercentBonus operator +(CValuePercentBonus lhs, CValuePercentBonus rhs)
	{
		return new CValuePercentBonus
		{
			_percentValue = lhs._percentValue + rhs._percentValue
		};
	}

	public static CValuePercentBonus operator -(CValuePercentBonus lhs, CValuePercentBonus rhs)
	{
		return new CValuePercentBonus
		{
			_percentValue = lhs._percentValue - rhs._percentValue
		};
	}

	public static CValuePercentBonus operator -(CValuePercentBonus bonus)
	{
		return new CValuePercentBonus
		{
			_percentValue = -bonus._percentValue
		};
	}

	public static bool operator >(CValuePercentBonus percent, int value)
	{
		return percent._percentValue > value;
	}

	public static bool operator <(CValuePercentBonus percent, int value)
	{
		return percent._percentValue < value;
	}

	public static bool operator >=(CValuePercentBonus percent, int value)
	{
		return percent._percentValue >= value;
	}

	public static bool operator <=(CValuePercentBonus percent, int value)
	{
		return percent._percentValue <= value;
	}

	public static bool operator >(CValuePercentBonus percent, CValuePercentBonus value)
	{
		return percent._percentValue > value._percentValue;
	}

	public static bool operator <(CValuePercentBonus percent, CValuePercentBonus value)
	{
		return percent._percentValue < value._percentValue;
	}

	public static bool operator >=(CValuePercentBonus percent, CValuePercentBonus value)
	{
		return percent._percentValue >= value._percentValue;
	}

	public static bool operator <=(CValuePercentBonus percent, CValuePercentBonus value)
	{
		return percent._percentValue <= value._percentValue;
	}

	public static bool operator ==(CValuePercentBonus bonus, int value)
	{
		return bonus._percentValue == value;
	}

	public static bool operator !=(CValuePercentBonus bonus, int value)
	{
		return bonus._percentValue != value;
	}

	public CValuePercentBonus Pow(int pow)
	{
		CValuePercentBonus bonus = this;
		for (int i = 1; i < pow; i++)
		{
			bonus *= this;
		}
		return bonus;
	}

	public CValuePercentBonus StaySymbol()
	{
		return new CValuePercentBonus
		{
			_percentValue = CombatMath.Max(_percentValue, -100)
		};
	}

	public bool Equals(CValuePercentBonus other)
	{
		return _percentValue == other._percentValue;
	}

	public override bool Equals(object obj)
	{
		if (obj is CValuePercentBonus other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _percentValue;
	}

	public override string ToString()
	{
		return $"CValuePercentBonus({_percentValue})";
	}
}

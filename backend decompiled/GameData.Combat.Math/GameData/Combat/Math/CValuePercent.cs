using System;

namespace GameData.Combat.Math;

public struct CValuePercent : IEquatable<CValuePercent>
{
	private int _percentValue;

	public static int ParseIntClamp01(int curr, int max)
	{
		return CombatMath.Clamp(ParseInt(curr, max), 0, 100);
	}

	public static int ParseInt(int curr, int max)
	{
		if (max != 0)
		{
			return curr * 100 / max;
		}
		return 0;
	}

	public static int CeilMul(int value, CValuePercent percent)
	{
		int remainder = (((long)value * (long)percent._percentValue % 100 > 0) ? 1 : 0);
		return value * percent + remainder;
	}

	public static CValuePercent Parse(int curr, int max)
	{
		return new CValuePercent
		{
			_percentValue = ParseInt(curr, max)
		};
	}

	public static implicit operator CValuePercent(int percentValue)
	{
		return new CValuePercent
		{
			_percentValue = percentValue
		};
	}

	public static explicit operator int(CValuePercent percent)
	{
		return percent._percentValue;
	}

	public static long operator *(long value, CValuePercent percent)
	{
		return value * percent._percentValue / 100;
	}

	public static int operator *(int value, CValuePercent percent)
	{
		return (int)CombatMath.Clamp((long)value * percent, -2147483648L, 2147483647L);
	}

	public static CValuePercent operator *(CValuePercent lhs, CValuePercent rhs)
	{
		return new CValuePercent
		{
			_percentValue = lhs._percentValue * rhs
		};
	}

	[Obsolete("This operator may be mistaken for multiplying another CValuePercent, use 'percent *= (CValuePercent)ratio' or 'percent *= (CValueMultiplier)ratio instead.'", true)]
	public static CValuePercent operator *(CValuePercent percent, int ratio)
	{
		return new CValuePercent
		{
			_percentValue = percent._percentValue * ratio
		};
	}

	public static CValuePercent operator +(CValuePercent lhs, CValuePercent rhs)
	{
		return new CValuePercent
		{
			_percentValue = lhs._percentValue + rhs._percentValue
		};
	}

	public static CValuePercent operator -(CValuePercent lhs, CValuePercent rhs)
	{
		return new CValuePercent
		{
			_percentValue = lhs._percentValue - rhs._percentValue
		};
	}

	public static CValuePercent operator -(CValuePercent bonus)
	{
		return new CValuePercent
		{
			_percentValue = -bonus._percentValue
		};
	}

	public static bool operator >(CValuePercent percent, int value)
	{
		return percent._percentValue > value;
	}

	public static bool operator <(CValuePercent percent, int value)
	{
		return percent._percentValue < value;
	}

	public static bool operator >=(CValuePercent percent, int value)
	{
		return percent._percentValue >= value;
	}

	public static bool operator <=(CValuePercent percent, int value)
	{
		return percent._percentValue <= value;
	}

	public static bool operator >(CValuePercent percent, CValuePercent value)
	{
		return percent._percentValue > value._percentValue;
	}

	public static bool operator <(CValuePercent percent, CValuePercent value)
	{
		return percent._percentValue < value._percentValue;
	}

	public static bool operator >=(CValuePercent percent, CValuePercent value)
	{
		return percent._percentValue >= value._percentValue;
	}

	public static bool operator <=(CValuePercent percent, CValuePercent value)
	{
		return percent._percentValue <= value._percentValue;
	}

	public static bool operator ==(CValuePercent percent, int value)
	{
		return percent._percentValue == value;
	}

	public static bool operator !=(CValuePercent percent, int value)
	{
		return percent._percentValue != value;
	}

	public bool Equals(CValuePercent other)
	{
		return _percentValue == other._percentValue;
	}

	public override bool Equals(object obj)
	{
		if (obj is CValuePercent other)
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
		return $"CValuePercent({_percentValue})";
	}
}

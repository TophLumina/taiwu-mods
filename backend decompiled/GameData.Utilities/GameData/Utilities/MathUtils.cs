using System;

namespace GameData.Utilities;

public static class MathUtils
{
	public static float CosInterpolate(float startVal, float endVal, float t)
	{
		double tCos = (1.0 - Math.Cos((double)t * Math.PI)) / 2.0;
		return (float)((double)startVal + tCos * (double)(endVal - startVal));
	}

	public static sbyte Clamp(sbyte value, sbyte min, sbyte max)
	{
		if (value < min)
		{
			return min;
		}
		if (value > max)
		{
			return max;
		}
		return value;
	}

	public static byte Clamp(byte value, byte min, byte max)
	{
		if (value < min)
		{
			return min;
		}
		if (value > max)
		{
			return max;
		}
		return value;
	}

	public static short Clamp(short value, short min, short max)
	{
		if (value < min)
		{
			return min;
		}
		if (value > max)
		{
			return max;
		}
		return value;
	}

	public static ushort Clamp(ushort value, ushort min, ushort max)
	{
		if (value < min)
		{
			return min;
		}
		if (value > max)
		{
			return max;
		}
		return value;
	}

	public static int Clamp(int value, int min, int max)
	{
		if (value < min)
		{
			return min;
		}
		if (value > max)
		{
			return max;
		}
		return value;
	}

	public static uint Clamp(uint value, uint min, uint max)
	{
		if (value < min)
		{
			return min;
		}
		if (value > max)
		{
			return max;
		}
		return value;
	}

	public static long Clamp(long value, long min, long max)
	{
		if (value < min)
		{
			return min;
		}
		if (value > max)
		{
			return max;
		}
		return value;
	}

	public static ulong Clamp(ulong value, ulong min, ulong max)
	{
		if (value < min)
		{
			return min;
		}
		if (value > max)
		{
			return max;
		}
		return value;
	}

	public static float Clamp(float value, float min, float max)
	{
		if (value < min)
		{
			return min;
		}
		if (value > max)
		{
			return max;
		}
		return value;
	}

	public static double Clamp(double value, double min, double max)
	{
		if (value < min)
		{
			return min;
		}
		if (value > max)
		{
			return max;
		}
		return value;
	}

	public static int Max(int val1, int val2)
	{
		if (val1 >= val2)
		{
			return val1;
		}
		return val2;
	}

	public static int Min(int val1, int val2)
	{
		if (val1 <= val2)
		{
			return val1;
		}
		return val2;
	}

	public static int Abs(int val)
	{
		if (val >= 0)
		{
			return val;
		}
		return -val;
	}

	public static int GetManhattanDistance(int srcX, int srcY, int destX, int destY, int srcSize = 1)
	{
		if (srcSize > 1)
		{
			if (srcX < destX)
			{
				srcX = Math.Min(srcX + srcSize - 1, destX);
			}
			if (srcY < destY)
			{
				srcY = Math.Min(srcY + srcSize - 1, destY);
			}
		}
		return Math.Abs(srcX - destX) + Math.Abs(srcY - destY);
	}
}

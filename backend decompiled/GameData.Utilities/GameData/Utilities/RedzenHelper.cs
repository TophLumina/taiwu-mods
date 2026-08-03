using System;
using System.Collections.Generic;
using Redzen.Numerics.Distributions.Double;
using Redzen.Random;

namespace GameData.Utilities;

public static class RedzenHelper
{
	public static bool CheckPercentProb(this IRandomSource randomSource, int percentProb)
	{
		if (percentProb > 0)
		{
			return randomSource.Next(100) < percentProb;
		}
		return false;
	}

	public static bool CheckProb(this IRandomSource randomSource, int threshold, int max)
	{
		if (max > 0)
		{
			return randomSource.Next(max) < threshold;
		}
		return false;
	}

	public static T GetRandomElement<T>(this IRandomSource randomSource, T[] array)
	{
		int index = randomSource.Next(array.Length);
		return array[index];
	}

	public static T GetRandomElement<T>(this IRandomSource randomSource, List<T> list)
	{
		int index = randomSource.Next(list.Count);
		return list[index];
	}

	public static int NormalDistribute(IRandomSource randomSource, float mean, float stdDev)
	{
		return (int)Math.Round(ZigguratGaussian.Sample(randomSource, mean, stdDev));
	}

	public static int NormalDistribute(IRandomSource randomSource, float mean, float stdDev, int min, int max)
	{
		int value = (int)Math.Round(ZigguratGaussian.Sample(randomSource, mean, stdDev));
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

	public static float NormalDistribute(IRandomSource randomSource, float mean, float stdDev, float min, float max)
	{
		float value = (float)ZigguratGaussian.Sample(randomSource, mean, stdDev);
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

	public static int SkewDistribute(IRandomSource randomSource, float mean, float stdDev, float skewness, int min = int.MinValue, int max = int.MaxValue)
	{
		Tester.Assert((double)Math.Abs(skewness) > 1.0);
		double floatValue = ZigguratGaussian.Sample(randomSource);
		if (skewness > 0f)
		{
			if (floatValue > 0.0)
			{
				floatValue *= (double)skewness;
			}
		}
		else if (floatValue < 0.0)
		{
			floatValue *= (double)(0f - skewness);
		}
		int intValue = (int)Math.Round((double)mean + floatValue * (double)stdDev);
		if (intValue < min)
		{
			return min;
		}
		if (intValue > max)
		{
			return max;
		}
		return intValue;
	}

	public static int GetNormalDistributedRangedValue(IRandomSource randomSource, int min, int max)
	{
		float span = (float)(max - min) / 2f;
		float mean = (float)min + span;
		float stdDev = span / 2.326348f;
		return NormalDistribute(randomSource, mean, stdDev, min, max);
	}
}

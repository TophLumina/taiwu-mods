using System;
using Redzen.Random;

namespace GameData.Utilities.RandomGenerator;

public class MaxRandomGenerator : IRandomSource
{
	public void Reinitialise(ulong seed)
	{
	}

	public int Next()
	{
		return 2147483646;
	}

	public int Next(int maxValue)
	{
		return maxValue - 1;
	}

	public int Next(int minValue, int maxValue)
	{
		return maxValue - 1;
	}

	public double NextDouble()
	{
		return 1.0;
	}

	public void NextBytes(Span<byte> span)
	{
		span.Fill(byte.MaxValue);
	}

	public int NextInt()
	{
		return int.MaxValue;
	}

	public uint NextUInt()
	{
		return uint.MaxValue;
	}

	public ulong NextULong()
	{
		return ulong.MaxValue;
	}

	public bool NextBool()
	{
		return true;
	}

	public byte NextByte()
	{
		return byte.MaxValue;
	}

	public void NextBytes(byte[] buffer)
	{
		Array.Fill(buffer, byte.MaxValue);
	}

	public float NextFloat()
	{
		return 1f;
	}

	public float NextFloatNonZero()
	{
		return 1f;
	}

	public double NextDoubleNonZero()
	{
		return 1.0;
	}

	public double NextDoubleHighRes()
	{
		return 1.0;
	}
}

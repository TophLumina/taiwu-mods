using System;
using Redzen.Random;

namespace GameData.Utilities.RandomGenerator;

public class MinRandomGenerator : IRandomSource
{
	public void Reinitialise(ulong seed)
	{
	}

	public int Next()
	{
		return 0;
	}

	public int Next(int maxValue)
	{
		return 0;
	}

	public int Next(int minValue, int maxValue)
	{
		return minValue;
	}

	public double NextDouble()
	{
		return 0.0;
	}

	public void NextBytes(Span<byte> span)
	{
		span.Fill(0);
	}

	public int NextInt()
	{
		return 0;
	}

	public uint NextUInt()
	{
		return 0u;
	}

	public ulong NextULong()
	{
		return 0uL;
	}

	public bool NextBool()
	{
		return false;
	}

	public byte NextByte()
	{
		return 0;
	}

	public void NextBytes(byte[] buffer)
	{
		Array.Fill(buffer, (byte)0);
	}

	public float NextFloat()
	{
		return 0f;
	}

	public float NextFloatNonZero()
	{
		return float.Epsilon;
	}

	public double NextDoubleNonZero()
	{
		return double.Epsilon;
	}

	public double NextDoubleHighRes()
	{
		return double.Epsilon;
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Redzen.Random;

namespace GameData.Utilities;

public static class RandomUtils
{
	public static void NextBytes(this IRandomSource random, Span<byte> buffer)
	{
		Span<byte> segment = buffer;
		while (segment.Length >= 8)
		{
			ulong nextUlong = random.NextULong();
			Unsafe.WriteUnaligned(ref MemoryMarshal.GetReference(segment), nextUlong);
			segment = segment.Slice(8);
		}
		for (int i = 0; i < segment.Length; i++)
		{
			segment[i] = random.NextByte();
		}
	}

	public static List<T[]> GenerateRandomWeightCellListCommon<T>(IRandomSource random, IList<T[]> core, int count = 1, sbyte weightIdx = 1) where T : IComparable, IConvertible
	{
		int totalWeight = 0;
		List<(float, float)> aliases = new List<(float, float)>();
		for (int i = 0; i < core.Count; i++)
		{
			T[] cellCore = core[i];
			totalWeight += cellCore[weightIdx].ToInt32(null);
			aliases.Add((1f, -1f));
		}
		float averageWeight = (float)totalWeight / (float)core.Count;
		int sIdx;
		for (sIdx = 0; sIdx < core.Count && core[sIdx][weightIdx].ToSingle(null).CompareTo(averageWeight) >= 0; sIdx++)
		{
		}
		if (sIdx < core.Count)
		{
			int bIdx;
			for (bIdx = 0; bIdx < core.Count && core[bIdx][weightIdx].ToSingle(null).CompareTo(averageWeight) < 0; bIdx++)
			{
			}
			(int, float) small = (sIdx, (float)core[sIdx][weightIdx].ToInt32(null) / averageWeight);
			(int, float) big = (bIdx, (float)core[bIdx][weightIdx].ToInt32(null) / averageWeight);
			while (true)
			{
				aliases[small.Item1] = (small.Item2, big.Item1);
				big = (big.Item1, big.Item2 - (1f - small.Item2));
				if (big.Item2 < 1f)
				{
					small = big;
					for (bIdx++; bIdx < core.Count && core[bIdx][weightIdx].ToSingle(null).CompareTo(averageWeight) < 0; bIdx++)
					{
					}
					if (bIdx >= core.Count)
					{
						break;
					}
					big = (bIdx, (float)core[bIdx][weightIdx].ToInt32(null) / averageWeight);
				}
				else
				{
					for (sIdx++; sIdx < core.Count && core[sIdx][weightIdx].ToSingle(null).CompareTo(averageWeight) >= 0; sIdx++)
					{
					}
					if (sIdx >= core.Count)
					{
						break;
					}
					small = (sIdx, (float)core[sIdx][weightIdx].ToInt32(null) / averageWeight);
				}
			}
		}
		List<T[]> list = new List<T[]>();
		for (int a = 0; a < count; a++)
		{
			float num = random.NextFloat() * (float)core.Count;
			int randomIndex = (int)num;
			(float, float) tuple = aliases[randomIndex];
			if (num - (float)randomIndex > tuple.Item1)
			{
				list.Add(core[(int)tuple.Item2]);
			}
			else
			{
				list.Add(core[randomIndex]);
			}
		}
		return list;
	}

	public static int[] GenerateRandomWeightCell(IRandomSource random, IList<int[]> core, int weightIdx = 1)
	{
		int totalWeight = 0;
		int[] coreWeightMaxCell = null;
		for (int i = 0; i < core.Count; i++)
		{
			int[] cellCore = core[i];
			totalWeight += cellCore[weightIdx];
			if (coreWeightMaxCell == null || coreWeightMaxCell[weightIdx] < cellCore[weightIdx])
			{
				coreWeightMaxCell = cellCore;
			}
		}
		int randWeight = random.Next(0, totalWeight);
		int weightLine = 0;
		for (int i2 = core.Count - 1; i2 >= 0; i2--)
		{
			weightLine += core[i2][weightIdx];
			if (randWeight >= totalWeight - weightLine)
			{
				return core[i2];
			}
		}
		return coreWeightMaxCell;
	}

	public static T[] GenerateRandomWeightCell<T>(IRandomSource random, IList<T[]> core, int weightIdx = 1) where T : IComparable, IConvertible
	{
		int totalWeight = 0;
		T[] coreWeightMaxCell = null;
		for (int i = 0; i < core.Count; i++)
		{
			T[] cellCore = core[i];
			totalWeight += cellCore[weightIdx].ToInt32(null);
			if (coreWeightMaxCell == null || coreWeightMaxCell[weightIdx].CompareTo(cellCore[weightIdx]) < 0)
			{
				coreWeightMaxCell = cellCore;
			}
		}
		int randWeight = random.Next(0, totalWeight);
		int weightLine = 0;
		for (int i2 = core.Count - 1; i2 >= 0; i2--)
		{
			weightLine += core[i2][weightIdx].ToInt32(null);
			if (randWeight >= totalWeight - weightLine)
			{
				return core[i2];
			}
		}
		return coreWeightMaxCell;
	}

	public static T GetRandomResult<T>(IEnumerable<(T, short)> weights, IRandomSource random)
	{
		int totalWeight = 0;
		foreach (var weight in weights)
		{
			totalWeight += weight.Item2;
		}
		int randomValue = random.Next(0, totalWeight);
		foreach (var one in weights)
		{
			randomValue -= one.Item2;
			if (randomValue < 0)
			{
				return one.Item1;
			}
		}
		throw new Exception("Error Params");
	}

	public static (T, V) GetRandomResult<T, V>(IEnumerable<(T, short, V)> weights, IRandomSource random)
	{
		int totalWeight = 0;
		foreach (var weight2 in weights)
		{
			totalWeight += weight2.Item2;
		}
		int randomValue = random.Next(0, totalWeight);
		foreach (var weight in weights)
		{
			randomValue -= weight.Item2;
			if (randomValue < 0)
			{
				return (weight.Item1, weight.Item3);
			}
		}
		throw new Exception("Error Params");
	}

	public static int GetRandomIndex(IReadOnlyList<short> weights, IRandomSource random)
	{
		int totalWeight = 0;
		foreach (short weight in weights)
		{
			totalWeight += weight;
		}
		int randomValue = random.Next(0, totalWeight);
		for (int i = 0; i < weights.Count; i++)
		{
			randomValue -= weights[i];
			if (randomValue < 0)
			{
				return i;
			}
		}
		throw new Exception("Error Params");
	}

	public static int GetRandomIndex(IReadOnlyList<sbyte> weights, IRandomSource random)
	{
		int totalWeight = 0;
		foreach (sbyte weight in weights)
		{
			totalWeight += weight;
		}
		int randomValue = random.Next(0, totalWeight);
		for (int i = 0; i < weights.Count; i++)
		{
			randomValue -= weights[i];
			if (randomValue < 0)
			{
				return i;
			}
		}
		throw new Exception("Error Params");
	}

	public static int GetRandomIndex(IReadOnlyList<int> weights, IRandomSource random)
	{
		int totalWeight = 0;
		foreach (int weight in weights)
		{
			totalWeight += weight;
		}
		int randomValue = random.Next(0, totalWeight);
		for (int i = 0; i < weights.Count; i++)
		{
			randomValue -= weights[i];
			if (randomValue < 0)
			{
				return i;
			}
		}
		throw new Exception("Error Params");
	}

	public static int GetRandomIndex(IReadOnlyList<uint> weights, IRandomSource random)
	{
		uint totalWeight = 0u;
		foreach (uint weight in weights)
		{
			totalWeight += weight;
		}
		if (totalWeight == 0)
		{
			return -1;
		}
		uint tempWeight = 0u;
		uint randomValue = random.NextUInt() % totalWeight;
		for (int i = 0; i < weights.Count; i++)
		{
			tempWeight += weights[i];
			if (tempWeight > randomValue)
			{
				return i;
			}
		}
		return -1;
	}

	public static int GetRandomIndex<T>(IReadOnlyList<T> values, IRandomSource random, Func<T, int> weightSelector)
	{
		int totalWeight = 0;
		foreach (T value in values)
		{
			totalWeight += weightSelector(value);
		}
		int randomValue = random.Next(0, totalWeight);
		for (int i = 0; i < values.Count; i++)
		{
			randomValue -= weightSelector(values[i]);
			if (randomValue < 0)
			{
				return i;
			}
		}
		throw new Exception("Error Params");
	}

	public static int GetRandomIndex(Span<int> weights, IRandomSource random)
	{
		int totalWeight = 0;
		Span<int> span = weights;
		for (int i = 0; i < span.Length; i++)
		{
			int weight = span[i];
			totalWeight += weight;
		}
		int randomValue = random.Next(0, totalWeight);
		for (int j = 0; j < weights.Length; j++)
		{
			randomValue -= weights[j];
			if (randomValue < 0)
			{
				return j;
			}
		}
		throw new Exception("Error Params");
	}

	public static int GetRandomIndex<T>(IReadOnlyList<T> weights, IRandomSource random) where T : ITuple
	{
		int totalWeight = 0;
		T val;
		foreach (T weight2 in weights)
		{
			T weight = weight2;
			ref T reference = ref weight;
			ref T reference2 = ref reference;
			val = default(T);
			if (val == null)
			{
				val = reference2;
				reference2 = ref val;
			}
			int index = reference.Length - 1;
			if (reference2[index] is short val2)
			{
				totalWeight += val2;
				continue;
			}
			throw new Exception("The last element of each tuple must be a short value");
		}
		int randomValue = random.Next(0, totalWeight);
		for (int i = 0; i < weights.Count; i++)
		{
			int num = randomValue;
			val = weights[i];
			ref T reference = ref val;
			randomValue = num - ((reference[reference.Length - 1] is short val3) ? val3 : 0);
			if (randomValue < 0)
			{
				return i;
			}
		}
		throw new Exception("Error Params");
	}

	public static int GetRandomIndex<T>(IReadOnlyList<(T, short)> weights, IRandomSource random)
	{
		int totalWeight = 0;
		foreach (var weight2 in weights)
		{
			totalWeight += weight2.Item2;
		}
		int randomValue = random.Next(0, totalWeight);
		for (int i = 0; i < weights.Count; i++)
		{
			randomValue -= weights[i].Item2;
			if (randomValue < 0)
			{
				return i;
			}
		}
		throw new Exception("Error Params");
	}

	public static void GenerateRandomWeightCellList(IRandomSource random, IList<short[]> core, int count, ref List<short[]> result, int weightIdx = 1)
	{
		GenerateRandomList(count, core.Select((short[] a) => (a: a, a[weightIdx])), random, ref result);
	}

	public static void GenerateRandomList<T>(int count, IEnumerable<(T, short)> paras, IRandomSource random, ref List<T> result)
	{
		result.Clear();
		paras = paras.Where(((T, short) a) => a.Item2 != 0);
		float totalWeight = 0f;
		float totalCount = 0f;
		foreach (var para in paras)
		{
			totalWeight += (float)para.Item2;
		}
		float minWeight = totalWeight / (float)count;
		List<(T, short)> copyParas = new List<(T, short)>(paras);
		while (copyParas.Count > 0 && result.Count < count)
		{
			int idx = random.Next(0, copyParas.Count);
			(T, short) curPara = copyParas[idx];
			copyParas.RemoveAt(idx);
			short curWeight = curPara.Item2;
			totalCount += (float)count * ((float)curWeight / totalWeight);
			int addCount = (int)Math.Round(totalCount) - result.Count;
			if (addCount == 0 && (float)curWeight < minWeight)
			{
				if (RandomCheck(random, (float)curWeight / totalWeight))
				{
					result.Add(curPara.Item1);
				}
			}
			else
			{
				for (int i = 0; i < addCount; i++)
				{
					result.Add(curPara.Item1);
				}
			}
		}
		CollectionUtils.Shuffle(random, result);
	}

	public static bool RandomCheck(IRandomSource random, float rate, float totalRate = 1f)
	{
		return random.Next(0, (int)(totalRate * 1000f) + 1) <= (int)(rate * 1000f);
	}

	public unsafe static void GetRandomUnrepeated(IRandomSource random, int minValue, int maxValue, int* resultIndices, int amount)
	{
		Span<int> resultSpan = new Span<int>(resultIndices, amount);
		resultSpan.Fill(-1);
		int selectedAmount = 0;
		int length = maxValue - minValue + 1;
		while (selectedAmount < amount && selectedAmount < length)
		{
			int index = random.Next(minValue, maxValue + 1);
			if (resultSpan.IndexOf(index) < 0)
			{
				resultSpan[selectedAmount] = index;
				selectedAmount++;
			}
		}
	}

	public static void GetRandomUnrepeated(IRandomSource random, int minValue, int maxValue, Span<int> resultIndices)
	{
		resultIndices.Fill(-1);
		int selectedAmount = 0;
		int length = maxValue - minValue + 1;
		while (selectedAmount < resultIndices.Length && selectedAmount < length)
		{
			int index = random.Next(minValue, maxValue + 1);
			if (resultIndices.IndexOf(index) < 0)
			{
				resultIndices[selectedAmount] = index;
				selectedAmount++;
			}
		}
	}

	public static IEnumerable<T> GetRandomUnrepeated<T>(IRandomSource random, int maxCount, [DisallowNull] IReadOnlyList<T> preferredItems, [AllowNull] IReadOnlyList<T> normalItems = null)
	{
		int preferredCount = Math.Min(maxCount, preferredItems.Count);
		maxCount -= preferredCount;
		for (int i = 0; i < preferredItems.Count; i++)
		{
			if (random.CheckProb(preferredCount, preferredItems.Count - i))
			{
				yield return preferredItems[i];
				preferredCount--;
			}
		}
		if (normalItems == null)
		{
			yield break;
		}
		int normalCount = Math.Min(maxCount - preferredCount, normalItems.Count);
		for (int i = 0; i < normalItems.Count; i++)
		{
			if (random.CheckProb(normalCount, normalItems.Count - i))
			{
				yield return normalItems[i];
				normalCount--;
			}
		}
	}

	public static IEnumerable<T> GetRandomUnrepeatedAndRemove<T>(IRandomSource random, int maxCount, [DisallowNull] IList<T> preferredItems, [AllowNull] IList<T> normalItems = null)
	{
		int preferredCount = Math.Min(maxCount, preferredItems.Count);
		maxCount -= preferredCount;
		for (int i = preferredItems.Count - 1; i >= 0; i--)
		{
			if (random.CheckProb(preferredCount, i + 1))
			{
				yield return preferredItems[i];
				preferredItems.RemoveAt(i);
				preferredCount--;
			}
		}
		if (normalItems == null)
		{
			yield break;
		}
		int normalCount = Math.Min(maxCount - preferredCount, normalItems.Count);
		for (int i = 0; i < normalItems.Count; i++)
		{
			if (random.CheckProb(normalCount, i + 1))
			{
				yield return normalItems[i];
				normalItems.RemoveAt(i);
				normalCount--;
			}
		}
	}

	public static IEnumerable<ulong> GetRandomUnrepeated(IRandomSource random, ulong maxCount)
	{
		switch (maxCount)
		{
		case 1uL:
			yield return 0uL;
			yield break;
		case 0uL:
			yield break;
		}
		ulong modFlag = maxCount | (maxCount >> 1);
		modFlag |= modFlag >> 2;
		modFlag |= modFlag >> 4;
		modFlag |= modFlag >> 8;
		modFlag |= modFlag >> 16;
		modFlag |= modFlag >> 32;
		ulong mul = (1 | ((ulong)((double)modFlag * (random.NextDouble() * 0.3 + 0.2)) << 2)) & modFlag;
		ulong add = (((ulong)((double)maxCount * random.NextDouble()) << 1) | 1) & modFlag;
		ulong scout = (ulong)((double)maxCount * random.NextDouble()) & modFlag;
		if (scout < maxCount)
		{
			yield return scout;
		}
		for (ulong curr = (scout * mul + add) & modFlag; curr != scout; curr = (curr * mul + add) & modFlag)
		{
			if (curr < maxCount)
			{
				yield return curr;
			}
		}
	}

	public static IEnumerable<(int, int)> GetRandomUnrepeatedIntPair(IRandomSource random, int max)
	{
		return GetRandomUnrepeated(random, (ulong)((long)max * (long)(max - 1)) >> 1).Select(DecomposeTriangleNumber);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static (int, int) DecomposeTriangleNumber(ulong index)
	{
		int idA = (int)Math.Sqrt(index * 2);
		int idB = (int)((long)index - (idA * ((long)idA - 1L) >>> 1));
		if (idB < idA)
		{
			return (idB, idA);
		}
		idB -= idA;
		idA++;
		return (idB, idA);
	}

	public static int[] DistributeNIntoKBuckets(IRandomSource random, int n, int k)
	{
		int[] buckets = new int[k];
		for (int i = 0; i < k - 1; i++)
		{
			buckets[i] = random.Next(0, n + 1);
			n -= buckets[i];
		}
		buckets[k - 1] = n;
		return buckets;
	}

	public static void DistributeNIntoKBuckets(IRandomSource random, Span<int> buckets, int k, int n, int m)
	{
		buckets.Fill(0);
		n = Math.Min(n, k * m);
		while (n > 0)
		{
			int i = random.Next(k);
			if (buckets[i] < m)
			{
				buckets[i]++;
				n--;
			}
		}
	}
}

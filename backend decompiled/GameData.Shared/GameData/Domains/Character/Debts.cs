using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

[Obsolete]
public class Debts : ISerializableGameData
{
	public long Equivalent;

	public readonly SortedList<long, int> Nonequivalents;

	private static readonly Queue<(long, int)> OnExchange = new Queue<(long, int)>();

	public Debts()
	{
		Nonequivalents = new SortedList<long, int>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 12 + 12 * Nonequivalents.Count;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(long*)pCurrData = Equivalent;
		pCurrData += 8;
		*(int*)pCurrData = Nonequivalents.Count;
		pCurrData += 4;
		foreach (KeyValuePair<long, int> pair in Nonequivalents)
		{
			long worth = pair.Key;
			int count = pair.Value;
			*(long*)pCurrData = worth;
			pCurrData += 8;
			*(int*)pCurrData = count;
			pCurrData += 4;
		}
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		Nonequivalents.Clear();
		byte* pCurrData = pData;
		Equivalent = *(long*)pCurrData;
		pCurrData += 8;
		int nonequivalentsCount = *(int*)pCurrData;
		pCurrData += 4;
		for (int i = 0; i < nonequivalentsCount; i++)
		{
			long worth = *(long*)pCurrData;
			pCurrData += 8;
			int count = *(int*)pCurrData;
			pCurrData += 4;
			Nonequivalents.Add(worth, count);
		}
		return (int)(pCurrData - pData);
	}

	public static long ItemToWorth(sbyte itemType, short itemTemplateId)
	{
		return ItemTemplateHelper.GetBaseFavorabilityChange(itemType, itemTemplateId) * 10;
	}

	public static long ResourceAmountToWorth(short resourceType, int amount)
	{
		return GlobalConfig.ResourcesWorth[resourceType] * amount;
	}

	public static long ResourceAmountToWorth(ref ResourceInts resources)
	{
		long worth = 0L;
		for (int type = 0; type < 7; type++)
		{
			worth += GlobalConfig.ResourcesWorth[type] * resources.Get(type);
		}
		return worth;
	}

	public static int WorthToResourceAmount(short resourceType, long worth, bool keepRemainder = false)
	{
		worth = Math.Abs(worth);
		sbyte unit = GlobalConfig.ResourcesWorth[resourceType];
		long result = worth / unit;
		long remainder = worth % unit;
		return (int)Math.Min((keepRemainder && remainder > 0) ? (result + 1) : result, 2147483647L);
	}

	public short GetMaxFavorabilityWithDebt()
	{
		return (short)MathUtils.Clamp(30000 - GetTotalWorthLentToTaiwu() / 10, -30000L, 30000L);
	}

	public void LendEquivalentToTaiwu(long worth)
	{
		if (worth <= 0)
		{
			throw new Exception($"Worth must be greater than zero: {worth}");
		}
		Equivalent += worth;
	}

	public void BorrowEquivalentFromTaiwu(long worth)
	{
		if (worth <= 0)
		{
			throw new Exception($"Worth must be greater than zero: {worth}");
		}
		Equivalent -= worth;
	}

	public void LendNonequivalentToTaiwu(long worth, int count = 1)
	{
		if (worth <= 0)
		{
			throw new Exception($"Worth must be greater than zero: {worth}");
		}
		IList<long> keys = Nonequivalents.Keys;
		IList<int> values = Nonequivalents.Values;
		if (Nonequivalents.Count == 0 || Nonequivalents.Keys[0] > 0)
		{
			int index = CollectionUtils.BinarySearch(keys, 0, keys.Count, worth);
			if (index >= 0)
			{
				long key = keys[index];
				Nonequivalents[key] += count;
			}
			else
			{
				Nonequivalents.Add(worth, count);
			}
			return;
		}
		OnExchange.Clear();
		OnExchange.Enqueue((worth, count));
		while (OnExchange.Count > 0)
		{
			(long, int) tuple = OnExchange.Dequeue();
			long currWorth = tuple.Item1;
			int currCount = tuple.Item2;
			long borrowKey = -currWorth;
			int index2 = CollectionUtils.BinarySearch(keys, 0, keys.Count, borrowKey);
			if (index2 < 0)
			{
				index2 = ~index2 - 1;
			}
			if (index2 >= 0 && index2 < Nonequivalents.Count && keys[index2] < 0)
			{
				long key2 = keys[index2];
				int oriCount = values[index2];
				if (oriCount <= currCount)
				{
					Nonequivalents.RemoveAt(index2);
					int remaining = currCount - oriCount;
					if (remaining > 0)
					{
						OnExchange.Enqueue((currWorth, remaining));
					}
				}
				else
				{
					Nonequivalents[key2] = oriCount - currCount;
				}
				if (key2 < borrowKey)
				{
					BorrowEquivalentFromTaiwu((borrowKey - key2) * Math.Min(oriCount, currCount));
				}
			}
			else if (Nonequivalents.ContainsKey(currWorth))
			{
				Nonequivalents[currWorth] += currCount;
			}
			else
			{
				Nonequivalents.Add(currWorth, currCount);
			}
		}
	}

	public bool BorrowNonequivalentFromTaiwu(long worth, int count = 1)
	{
		if (worth <= 0)
		{
			throw new Exception($"Worth must be greater than zero: {worth}");
		}
		IList<long> keys = Nonequivalents.Keys;
		IList<int> values = Nonequivalents.Values;
		long borrowKey = -worth;
		if (Nonequivalents.Count == 0 || Nonequivalents.Keys[Nonequivalents.Count - 1] < 0)
		{
			int index = CollectionUtils.BinarySearch(keys, 0, keys.Count, borrowKey);
			if (index >= 0)
			{
				long key = keys[index];
				Nonequivalents[key] += count;
			}
			else
			{
				Nonequivalents.Add(borrowKey, count);
			}
			return false;
		}
		bool hasRepayNonequivalent = false;
		OnExchange.Clear();
		OnExchange.Enqueue((worth, count));
		while (OnExchange.Count > 0)
		{
			(long, int) tuple = OnExchange.Dequeue();
			long currWorth = tuple.Item1;
			int currCount = tuple.Item2;
			int collectionCount = keys.Count;
			int index2 = CollectionUtils.BinarySearch(keys, 0, collectionCount, currWorth);
			if (index2 < 0)
			{
				index2 = ~index2 - 1;
			}
			if (index2 < collectionCount && index2 >= 0 && keys[index2] > 0)
			{
				hasRepayNonequivalent = true;
				long key2 = keys[index2];
				int oriCount = values[index2];
				if (oriCount > currCount)
				{
					Nonequivalents[key2] = oriCount - currCount;
					if (currWorth > key2)
					{
						OnExchange.Enqueue((currWorth - key2, currCount));
					}
					continue;
				}
				if (currWorth > key2)
				{
					OnExchange.Enqueue((currWorth - key2, oriCount));
				}
				Nonequivalents.RemoveAt(index2);
				if (currCount != oriCount)
				{
					OnExchange.Enqueue((currWorth, currCount - oriCount));
				}
			}
			else
			{
				BorrowEquivalentFromTaiwu(currWorth * currCount);
			}
		}
		return hasRepayNonequivalent;
	}

	public void Clear()
	{
		Equivalent = 0L;
		Nonequivalents.Clear();
	}

	public long GetTotalWorthLentToTaiwu()
	{
		return GetEquivalentWorth() + GetTotalNonEquivalentWorth();
	}

	public long GetEquivalentWorth()
	{
		if (Equivalent < 0)
		{
			return 0L;
		}
		return Equivalent;
	}

	public long GetTotalNonEquivalentWorth()
	{
		long value = 0L;
		foreach (KeyValuePair<long, int> pair in Nonequivalents)
		{
			long worth = pair.Key;
			int count = pair.Value;
			if (worth >= 0)
			{
				value += worth * count;
			}
		}
		return value;
	}

	public long GetFinalNonEquivalentWorth()
	{
		long value = 0L;
		foreach (KeyValuePair<long, int> pair in Nonequivalents)
		{
			long worth = pair.Key;
			int count = pair.Value;
			value += worth * count;
		}
		return value;
	}

	public long GetFinalWorth()
	{
		return Equivalent + GetFinalNonEquivalentWorth();
	}

	public override string ToString()
	{
		string str = Equivalent.ToString();
		if (Nonequivalents.Count <= 0)
		{
			return str;
		}
		foreach (KeyValuePair<long, int> pair in Nonequivalents)
		{
			long worth = pair.Key;
			int count = pair.Value;
			str += $", ({worth}, {count})";
		}
		return str;
	}

	public long GetTotalPositiveNonEquivalentWorth()
	{
		return Nonequivalents.Sum((KeyValuePair<long, int> pair) => (pair.Key > 0) ? (pair.Key * pair.Value) : 0);
	}

	public long GetTotalNegativeNonEquivalentWorth()
	{
		return Nonequivalents.Sum((KeyValuePair<long, int> pair) => (pair.Key < 0) ? (pair.Key * pair.Value) : 0);
	}

	public void CopyDataFrom(Debts otherDebts)
	{
		Equivalent = otherDebts.Equivalent;
		Nonequivalents.Clear();
		foreach (KeyValuePair<long, int> pair in otherDebts.Nonequivalents)
		{
			Nonequivalents.Add(pair.Key, pair.Value);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 角色对太吾的债务
/// 1. 集合中不存在从太吾 借入(-) 非等价物时, 借出 将作为正值直接添加到集合中
/// 2. 集合中不存在向太吾 借出(+) 非等价物时, 借入 将作为负值直接添加到集合中
/// 3. 集合中已存在 借入(-) 时, 借出 将直接抵消绝对值大于本次借出的借入项, 溢出的部分转化为等价物债务. 如果无小于本次借出的项, 则直接添加到集合.
/// 4. 集合中已存在 借出(+) 时, 借入 将抵消小于本次借入的借出项, 循环抵扣, 最后无法再抵扣的部分转化为等价物债务. 
/// </summary>
[Obsolete]
public class Debts : ISerializableGameData
{
	/// <summary>
	/// 等价物债务的好感. (资源价值)
	/// </summary>
	public long Equivalent;

	/// <summary>
	/// 非等价物债务好感. (道具转换成好感)
	/// </summary>
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

	/// <summary>
	/// 将道具的好感变化转换成欠恩失义使用的价值
	/// </summary>
	/// <param name="itemType"></param>
	/// <param name="itemTemplateId"></param>
	/// <returns></returns>
	public static long ItemToWorth(sbyte itemType, short itemTemplateId)
	{
		return ItemTemplateHelper.GetBaseFavorabilityChange(itemType, itemTemplateId) * 10;
	}

	/// <summary>
	/// 将资源转换成欠恩失义使用的价值
	/// </summary>
	/// <param name="resourceType"></param>
	/// <param name="amount"></param>
	/// <returns></returns>
	public static long ResourceAmountToWorth(short resourceType, int amount)
	{
		return GlobalConfig.ResourcesWorth[resourceType] * amount;
	}

	/// <summary>
	/// 将资源转换成欠恩失义使用的价值
	/// </summary>
	/// <returns></returns>
	public static long ResourceAmountToWorth(ref ResourceInts resources)
	{
		long worth = 0L;
		for (int type = 0; type < 7; type++)
		{
			worth += GlobalConfig.ResourcesWorth[type] * resources.Get(type);
		}
		return worth;
	}

	/// <summary>
	/// 将欠恩失义使用的价值转化成资源数量
	/// </summary>
	/// <param name="resourceType"></param>
	/// <param name="worth"></param>
	/// <param name="keepRemainder">是否考虑余数</param>
	/// <returns></returns>
	public static int WorthToResourceAmount(short resourceType, long worth, bool keepRemainder = false)
	{
		worth = Math.Abs(worth);
		sbyte unit = GlobalConfig.ResourcesWorth[resourceType];
		long result = worth / unit;
		long remainder = worth % unit;
		return (int)Math.Min((keepRemainder && remainder > 0) ? (result + 1) : result, 2147483647L);
	}

	/// <summary>
	/// 获取当前债务下的好感最大值
	/// </summary>
	/// <returns></returns>
	public short GetMaxFavorabilityWithDebt()
	{
		return (short)MathUtils.Clamp(30000 - GetTotalWorthLentToTaiwu() / 10, -30000L, 30000L);
	}

	/// <summary>
	/// 借出等价物给太吾
	/// </summary>
	/// <param name="worth">等价物的价值</param>
	public void LendEquivalentToTaiwu(long worth)
	{
		if (worth <= 0)
		{
			throw new Exception($"Worth must be greater than zero: {worth}");
		}
		Equivalent += worth;
	}

	/// <summary>
	/// 从太吾处借入等价物 (太吾还债)
	/// </summary>
	/// <param name="worth">等价物的价值</param>
	public void BorrowEquivalentFromTaiwu(long worth)
	{
		if (worth <= 0)
		{
			throw new Exception($"Worth must be greater than zero: {worth}");
		}
		Equivalent -= worth;
	}

	/// <summary>
	/// 借出非等价物给太吾
	/// </summary>
	/// <param name="worth">单个事物的价值</param>
	/// <param name="count">事物的个数</param>
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

	/// <summary>
	/// 从太吾处借入非等价物 (太吾还债)
	/// </summary>
	/// <param name="worth">单个事物的价值</param>
	/// <param name="count">事物的个数</param>
	/// <returns>是否偿还了非等价物债务，用于商店出售物品时记录便于回购时取消偿还</returns>
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

	/// <summary>
	/// 获取借出给太吾的价值之和
	/// 返回值大于等于零.
	/// </summary>
	/// <returns></returns>
	public long GetTotalWorthLentToTaiwu()
	{
		return GetEquivalentWorth() + GetTotalNonEquivalentWorth();
	}

	/// <summary>
	/// 获取借出给太吾的等价物价值
	/// 返回值大于等于零.
	/// </summary>
	/// <returns></returns>
	public long GetEquivalentWorth()
	{
		if (Equivalent < 0)
		{
			return 0L;
		}
		return Equivalent;
	}

	/// <summary>
	/// 获取借出给太吾的非等价价值总和.
	/// 返回值大于等于零.
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 获取债务的非等价价值总和.
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 获取债务的价值总和.
	/// </summary>
	/// <returns></returns>
	public long GetFinalWorth()
	{
		return Equivalent + GetFinalNonEquivalentWorth();
	}

	/// <inheritdoc />
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

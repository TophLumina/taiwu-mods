using System;
using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Extra;

/// <summary>
/// 卖出时偿还了非等价物债务的物品，用于回购时恢复债务
/// </summary>
[Obsolete]
public class MerchantBuyBackDebt : ISerializableGameData
{
	[SerializableGameDataField]
	public readonly Dictionary<ItemKey, int> Items = new Dictionary<ItemKey, int>();

	public bool Contains(ItemKey key)
	{
		return Items.ContainsKey(key);
	}

	public void AddItem(ItemKey itemKey, int amount)
	{
		if (Items.TryGetValue(itemKey, out var oriAmount))
		{
			Items[itemKey] = oriAmount + amount;
		}
		else
		{
			Items.Add(itemKey, amount);
		}
	}

	public void RemoveItem(ItemKey itemKey, int amount)
	{
		int currAmount = Items[itemKey] - amount;
		if (currAmount > 0)
		{
			Items[itemKey] = currAmount;
			return;
		}
		if (currAmount == 0)
		{
			Items.Remove(itemKey);
			return;
		}
		throw new Exception($"Item amount cannot be negative after removing: {itemKey}, {amount}");
	}

	/// <summary>
	/// 空构造方法用于反序列化
	/// </summary>
	public MerchantBuyBackDebt()
	{
	}

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		return 4 + 12 * Items.Count;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Items.Count;
		pCurrData += 4;
		foreach (KeyValuePair<ItemKey, int> entry in Items)
		{
			pCurrData += entry.Key.Serialize(pCurrData);
			*(int*)pCurrData = entry.Value;
			pCurrData += 4;
		}
		return (int)(pCurrData - pData);
	}

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int itemsCount = *(int*)pCurrData;
		pCurrData += 4;
		Items.Clear();
		for (int i = 0; i < itemsCount; i++)
		{
			ItemKey itemKey = default(ItemKey);
			pCurrData += itemKey.Deserialize(pCurrData);
			int amount = *(int*)pCurrData;
			pCurrData += 4;
			Items.Add(itemKey, amount);
		}
		return (int)(pCurrData - pData);
	}
}

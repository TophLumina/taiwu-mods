using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

public class ItemSourceChange : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte ItemSourceType;

	[SerializableGameDataField]
	public List<ItemKeyAndCount> Items = new List<ItemKeyAndCount>();

	[SerializableGameDataField]
	public Dictionary<ItemKey, int> PriceChanges = new Dictionary<ItemKey, int>();

	public ItemSourceType ItemSourceTypeEnum => (ItemSourceType)ItemSourceType;

	public ItemSourceChange(ItemSourceType type)
	{
		ItemSourceType = (sbyte)type;
	}

	public void AddItem(ItemKey key, int count = 1, int priceChange = 0)
	{
		ChangeItem(key, isAdd: true, count, priceChange);
	}

	public void AddItemList(List<ItemKey> itemList, int priceChange = 0)
	{
		foreach (ItemKey key in itemList)
		{
			AddItem(key, 1, priceChange);
		}
	}

	public void RemoveItem(ItemKey key, int count = 1, int priceChange = 0)
	{
		ChangeItem(key, isAdd: false, count, priceChange);
	}

	public void RemoveItemList(List<ItemKey> itemList, int priceChange = 0)
	{
		foreach (ItemKey key in itemList)
		{
			RemoveItem(key, 1, priceChange);
		}
	}

	private void ChangeItem(ItemKey key, bool isAdd, int count = 1, int priceChange = 0)
	{
		int findIndex = (ItemTemplateHelper.IsMiscResource(key.ItemType, key.TemplateId) ? (-1) : Items.FindIndex((ItemKeyAndCount i) => i.ItemKey.Equals(key)));
		int oldCount = ((findIndex >= 0) ? Items[findIndex].Count : 0);
		int newCount = (isAdd ? (oldCount + count) : (oldCount - count));
		if (newCount == 0)
		{
			if (findIndex >= 0)
			{
				Items.RemoveAt(findIndex);
			}
			PriceChanges.Remove(key);
		}
		else
		{
			if (findIndex < 0)
			{
				Items.Add(new ItemKeyAndCount(key, newCount));
			}
			else
			{
				Items[findIndex] = new ItemKeyAndCount(key, newCount);
			}
			PriceChanges[key] = priceChange;
		}
	}

	public ItemSourceChange()
	{
	}

	public ItemSourceChange(ItemSourceChange other)
	{
		ItemSourceType = other.ItemSourceType;
		Items = ((other.Items == null) ? null : new List<ItemKeyAndCount>(other.Items));
		PriceChanges = ((other.PriceChanges == null) ? null : new Dictionary<ItemKey, int>(other.PriceChanges));
	}

	public void Assign(ItemSourceChange other)
	{
		ItemSourceType = other.ItemSourceType;
		Items = ((other.Items == null) ? null : new List<ItemKeyAndCount>(other.Items));
		PriceChanges = ((other.PriceChanges == null) ? null : new Dictionary<ItemKey, int>(other.PriceChanges));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 1;
		totalSize = ((Items == null) ? (totalSize + 2) : (totalSize + (2 + 12 * Items.Count)));
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(PriceChanges);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)ItemSourceType;
		pCurrData++;
		if (Items != null)
		{
			int elementsCount = Items.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Items[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pCurrData, ref PriceChanges);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ItemSourceType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Items == null)
			{
				Items = new List<ItemKeyAndCount>(elementsCount);
			}
			else
			{
				Items.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ItemKeyAndCount element = default(ItemKeyAndCount);
				pCurrData += element.Deserialize(pCurrData);
				Items.Add(element);
			}
		}
		else
		{
			Items?.Clear();
		}
		pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref PriceChanges);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

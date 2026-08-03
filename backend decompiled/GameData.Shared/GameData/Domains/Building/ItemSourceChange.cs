using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

/// <summary>
/// 物品变化情况
/// </summary>
public class ItemSourceChange : ISerializableGameData
{
	/// <summary>
	/// 物品来源类型
	/// </summary>
	[SerializableGameDataField]
	public sbyte ItemSourceType;

	/// <summary>
	/// 物品变化，正数表示增加，负数表示减少
	/// </summary>
	[SerializableGameDataField]
	public List<ItemKeyAndCount> Items = new List<ItemKeyAndCount>();

	/// <summary>
	/// 物品价格变化，正数表示增加，负数表示减少
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<ItemKey, int> PriceChanges = new Dictionary<ItemKey, int>();

	/// <summary>
	/// 物品来源类型转枚举
	/// </summary>
	public ItemSourceType ItemSourceTypeEnum => (ItemSourceType)ItemSourceType;

	public ItemSourceChange(ItemSourceType type)
	{
		ItemSourceType = (sbyte)type;
	}

	/// <summary>
	/// 增加物品
	/// </summary>
	/// <param name="key"></param>
	/// <param name="count">正值</param>
	/// <param name="priceChange"></param>
	public void AddItem(ItemKey key, int count = 1, int priceChange = 0)
	{
		ChangeItem(key, isAdd: true, count, priceChange);
	}

	/// <summary>
	/// 增加物品
	/// </summary>
	public void AddItemList(List<ItemKey> itemList, int priceChange = 0)
	{
		foreach (ItemKey key in itemList)
		{
			AddItem(key, 1, priceChange);
		}
	}

	/// <summary>
	/// 减少物品
	/// </summary>
	/// <param name="key"></param>
	/// <param name="count">正值</param>
	/// <param name="priceChange"></param>
	public void RemoveItem(ItemKey key, int count = 1, int priceChange = 0)
	{
		ChangeItem(key, isAdd: false, count, priceChange);
	}

	/// <summary>
	/// 增加物品
	/// </summary>
	public void RemoveItemList(List<ItemKey> itemList, int priceChange = 0)
	{
		foreach (ItemKey key in itemList)
		{
			RemoveItem(key, 1, priceChange);
		}
	}

	/// <summary>
	/// 物品数量变化
	/// </summary>
	/// <param name="key"></param>
	/// <param name="isAdd"></param>
	/// <param name="count"></param>
	/// <param name="priceChange"></param>
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

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public ItemSourceChange()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public ItemSourceChange(ItemSourceChange other)
	{
		ItemSourceType = other.ItemSourceType;
		Items = ((other.Items == null) ? null : new List<ItemKeyAndCount>(other.Items));
		PriceChanges = ((other.PriceChanges == null) ? null : new Dictionary<ItemKey, int>(other.PriceChanges));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(ItemSourceChange other)
	{
		ItemSourceType = other.ItemSourceType;
		Items = ((other.Items == null) ? null : new List<ItemKeyAndCount>(other.Items));
		PriceChanges = ((other.PriceChanges == null) ? null : new Dictionary<ItemKey, int>(other.PriceChanges));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

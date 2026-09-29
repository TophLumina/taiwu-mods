using System;
using GameData.Serializer;

namespace GameData.Domains.Item;

[SerializableGameData(NoCopyConstructors = true)]
public struct ItemKeyAndDate(int date, ItemKey itemKey) : ISerializableGameData, IEquatable<ItemKeyAndDate>, IComparable<ItemKeyAndDate>
{
	[SerializableGameDataField]
	public int Date = date;

	[SerializableGameDataField]
	public ItemKey ItemKey = itemKey;

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = Date;
		pCurrData += 4;
		pCurrData += ItemKey.Serialize(pCurrData);
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
		Date = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += ItemKey.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public bool Equals(ItemKeyAndDate other)
	{
		if (Date == other.Date)
		{
			return ItemKey.Equals(other.ItemKey);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is ItemKeyAndDate other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (Date * 397) ^ ItemKey.GetHashCode();
	}

	public int CompareTo(ItemKeyAndDate other)
	{
		int result = Date - other.Date;
		if (result != 0)
		{
			return result;
		}
		return ItemKey.Id - other.ItemKey.Id;
	}
}

using System;
using GameData.Serializer;

namespace GameData.Domains.Item;

/// <summary>
/// 物品索引以及日期
/// </summary>
public struct ItemKeyAndDate : ISerializableGameData, IEquatable<ItemKeyAndDate>, IComparable<ItemKeyAndDate>
{
	/// <summary>
	/// 日期
	/// </summary>
	public int Date;

	/// <summary>
	/// 物品索引
	/// </summary>
	public ItemKey ItemKey;

	/// <summary>
	/// 物品索引以及日期
	/// </summary>
	/// <param name="itemKey"></param>
	/// <param name="date"></param>
	public ItemKeyAndDate(int date, ItemKey itemKey)
	{
		Date = date;
		ItemKey = itemKey;
	}

	public bool IsSerializedSizeFixed()
	{
		return true;
	}

	public unsafe int GetSerializedSize()
	{
		return 4 + sizeof(ItemKey);
	}

	public unsafe int Serialize(byte* pData)
	{
		*(int*)pData = Date;
		*(ItemKey*)(pData + 4) = ItemKey;
		return 4 + sizeof(ItemKey);
	}

	public unsafe int Deserialize(byte* pData)
	{
		Date = *(int*)pData;
		ItemKey = *(ItemKey*)(pData + 4);
		return 4 + sizeof(ItemKey);
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

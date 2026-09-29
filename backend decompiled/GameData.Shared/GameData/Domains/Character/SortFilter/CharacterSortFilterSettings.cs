using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Character.SortFilter;

[SerializableGameData(NotForArchive = true)]
public class CharacterSortFilterSettings : ISerializableGameData
{
	public sbyte FilterType;

	public sbyte FilterSubType;

	public int FilterSubId;

	public int TargetCharId;

	public Location TargetLocation;

	public ItemKey VillagerNeededItem;

	public readonly List<(int type, bool isDescending)> SortOrder;

	public CharacterSortFilterSettings()
	{
		FilterType = -1;
		FilterSubType = -1;
		TargetCharId = -1;
		TargetLocation = Location.Invalid;
		FilterSubId = -1;
		SortOrder = new List<(int, bool)>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12 + TargetLocation.GetSerializedSize() + SortOrder.Count * 5 + VillagerNeededItem.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)FilterType;
		pCurrData++;
		*pCurrData = (byte)FilterSubType;
		pCurrData++;
		*(int*)pCurrData = FilterSubId;
		pCurrData += 4;
		*(int*)pCurrData = TargetCharId;
		pCurrData += 4;
		pCurrData += TargetLocation.Serialize(pCurrData);
		pCurrData += VillagerNeededItem.Serialize(pCurrData);
		*(ushort*)pCurrData = (ushort)SortOrder.Count;
		pCurrData += 2;
		foreach (var pair in SortOrder)
		{
			*(int*)pCurrData = pair.type;
			pCurrData += 4;
			*pCurrData = (pair.isDescending ? ((byte)1) : ((byte)0));
			pCurrData++;
		}
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
		FilterType = (sbyte)(*pCurrData);
		pCurrData++;
		FilterSubType = (sbyte)(*pCurrData);
		pCurrData++;
		FilterSubId = *(int*)pCurrData;
		pCurrData += 4;
		TargetCharId = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += TargetLocation.Deserialize(pCurrData);
		pCurrData += VillagerNeededItem.Deserialize(pCurrData);
		ushort count = *(ushort*)pCurrData;
		pCurrData += 2;
		SortOrder.Clear();
		for (int i = 0; i < count; i++)
		{
			int sortType = *(int*)pCurrData;
			pCurrData += 4;
			bool isDescending = *pCurrData != 0;
			pCurrData++;
			SortOrder.Add((sortType, isDescending));
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

using System;
using System.Collections.Generic;
using GameData.Domains.Taiwu;
using GameData.Serializer;

namespace GameData.Domains.Building;

[SerializableGameData(IsExtensible = true)]
public class BuildingResourceOutputSetting : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort ResourceStorageLegacy = 0;

		public const ushort ItemStorageLegacy = 1;

		public const ushort ResourceStorage = 2;

		public const ushort ItemStorage = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "ResourceStorageLegacy", "ItemStorageLegacy", "ResourceStorage", "ItemStorage" };
	}

	[SerializableGameDataField(FieldIndex = 0)]
	public Dictionary<sbyte, sbyte> ResourceStorageLegacy;

	[SerializableGameDataField(FieldIndex = 1)]
	public Dictionary<sbyte, sbyte> ItemStorageLegacy;

	[SerializableGameDataField(FieldIndex = 2)]
	public TaiwuVillageStorageType ResourceStorage;

	[SerializableGameDataField(FieldIndex = 3)]
	public TaiwuVillageStorageType ItemStorage;

	public static IReadOnlyList<TaiwuVillageStorageType> AllowedResourceStorageTypes = new TaiwuVillageStorageType[2]
	{
		TaiwuVillageStorageType.Inventory,
		TaiwuVillageStorageType.Treasury
	};

	public static IReadOnlyList<TaiwuVillageStorageType> AllowedItemStorageTypes = new TaiwuVillageStorageType[3]
	{
		TaiwuVillageStorageType.Warehouse,
		TaiwuVillageStorageType.Treasury,
		TaiwuVillageStorageType.Stock
	};

	public void Init()
	{
		ResourceStorage = TaiwuVillageStorageType.Inventory;
		ItemStorage = TaiwuVillageStorageType.Warehouse;
	}

	public static ItemSourceType GetItemSourceType(TaiwuVillageStorageType storageType)
	{
		return storageType switch
		{
			TaiwuVillageStorageType.Inventory => ItemSourceType.Inventory, 
			TaiwuVillageStorageType.Warehouse => ItemSourceType.Warehouse, 
			TaiwuVillageStorageType.Treasury => ItemSourceType.Treasury, 
			TaiwuVillageStorageType.Stock => ItemSourceType.Stock, 
			_ => throw new ArgumentOutOfRangeException("storageType", storageType, null), 
		};
	}

	public BuildingResourceOutputSetting()
	{
	}

	public BuildingResourceOutputSetting(BuildingResourceOutputSetting other)
	{
		ResourceStorageLegacy = ((other.ResourceStorageLegacy == null) ? null : new Dictionary<sbyte, sbyte>(other.ResourceStorageLegacy));
		ItemStorageLegacy = ((other.ItemStorageLegacy == null) ? null : new Dictionary<sbyte, sbyte>(other.ItemStorageLegacy));
		ResourceStorage = other.ResourceStorage;
		ItemStorage = other.ItemStorage;
	}

	public void Assign(BuildingResourceOutputSetting other)
	{
		ResourceStorageLegacy = ((other.ResourceStorageLegacy == null) ? null : new Dictionary<sbyte, sbyte>(other.ResourceStorageLegacy));
		ItemStorageLegacy = ((other.ItemStorageLegacy == null) ? null : new Dictionary<sbyte, sbyte>(other.ItemStorageLegacy));
		ResourceStorage = other.ResourceStorage;
		ItemStorage = other.ItemStorage;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(ResourceStorageLegacy);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(ItemStorageLegacy);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 4;
		byte* num = pData + 2;
		byte* num2 = num + SerializationHelper.DictionaryOfBasicTypePair.Serialize(num, ref ResourceStorageLegacy);
		byte* num3 = num2 + SerializationHelper.DictionaryOfBasicTypePair.Serialize(num2, ref ItemStorageLegacy);
		*num3 = (byte)ResourceStorage;
		byte* num4 = num3 + 1;
		*num4 = (byte)ItemStorage;
		int totalSize = (int)(num4 + 1 - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref ResourceStorageLegacy);
		}
		if (num > 1)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref ItemStorageLegacy);
		}
		if (num > 2)
		{
			ResourceStorage = (TaiwuVillageStorageType)(*pCurrData);
			pCurrData++;
		}
		if (num > 3)
		{
			ItemStorage = (TaiwuVillageStorageType)(*pCurrData);
			pCurrData++;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

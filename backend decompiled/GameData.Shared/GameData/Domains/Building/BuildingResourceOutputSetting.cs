using System;
using System.Collections.Generic;
using GameData.Domains.Taiwu;
using GameData.Serializer;

namespace GameData.Domains.Building;

/// <summary>
/// 经营建筑的资源或道具的产出设置
/// </summary>
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

	/// <summary>
	/// 资源存储的位置，key是资源类型，value是TaiwuVillageStorageType，如果有二级页签实际存入存储
	/// 已废弃，单个建筑所有资源产出均共用同个设置
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public Dictionary<sbyte, sbyte> ResourceStorageLegacy;

	/// <summary>
	/// 材料物品存储的位置，key是材料物品的资源类型，value是TaiwuVillageStorageType，如果有二级页签实际存入制造
	/// 已废弃，单个建筑所有材料物品产出均共用同个设置
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public Dictionary<sbyte, sbyte> ItemStorageLegacy;

	/// <summary>
	/// 资源存储的位置
	/// </summary>
	[SerializableGameDataField(FieldIndex = 2)]
	public TaiwuVillageStorageType ResourceStorage;

	/// <summary>
	/// 材料物品存储的位置
	/// </summary>
	[SerializableGameDataField(FieldIndex = 3)]
	public TaiwuVillageStorageType ItemStorage;

	/// <summary>
	/// 可用的资源产出位置
	/// </summary>
	public static IReadOnlyList<TaiwuVillageStorageType> AllowedResourceStorageTypes = new TaiwuVillageStorageType[2]
	{
		TaiwuVillageStorageType.Inventory,
		TaiwuVillageStorageType.Treasury
	};

	/// <summary>
	/// 可用的材料物品产出位置
	/// </summary>
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

	/// <summary>
	/// 根据存储类型获取来源类型
	/// </summary>
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

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public BuildingResourceOutputSetting()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public BuildingResourceOutputSetting(BuildingResourceOutputSetting other)
	{
		ResourceStorageLegacy = ((other.ResourceStorageLegacy == null) ? null : new Dictionary<sbyte, sbyte>(other.ResourceStorageLegacy));
		ItemStorageLegacy = ((other.ItemStorageLegacy == null) ? null : new Dictionary<sbyte, sbyte>(other.ItemStorageLegacy));
		ResourceStorage = other.ResourceStorage;
		ItemStorage = other.ItemStorage;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(BuildingResourceOutputSetting other)
	{
		ResourceStorageLegacy = ((other.ResourceStorageLegacy == null) ? null : new Dictionary<sbyte, sbyte>(other.ResourceStorageLegacy));
		ItemStorageLegacy = ((other.ItemStorageLegacy == null) ? null : new Dictionary<sbyte, sbyte>(other.ItemStorageLegacy));
		ResourceStorage = other.ResourceStorage;
		ItemStorage = other.ItemStorage;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

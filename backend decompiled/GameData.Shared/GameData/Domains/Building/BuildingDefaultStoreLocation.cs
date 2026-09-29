using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Domains.Taiwu;
using GameData.Serializer;

namespace GameData.Domains.Building;

[SerializableGameData(IsExtensible = true)]
public class BuildingDefaultStoreLocation : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Data = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "Data" };
	}

	public const int StoreToInventory = 0;

	public const int StoreToWarehouse = 1;

	public const int StoreToTreasury = 2;

	public const int StoreToGoodsShelf = 3;

	[SerializableGameDataField]
	private Dictionary<int, int> _data = new Dictionary<int, int>();

	public override string ToString()
	{
		return string.Format("{0}({1}) {{ {2} }}", GetType().Name, _data.Count, string.Join(", ", _data.Select((KeyValuePair<int, int> kv) => $"{kv.Key}: {kv.Value}")));
	}

	public ItemSourceType GetMakeType(int fromType)
	{
		return ConvertDataToItemSource(GetMakeData(fromType));
	}

	public int GetMakeData(int data)
	{
		if (data >= 0 || data < -16)
		{
			if (!_data.TryGetValue(data, out data))
			{
				return 1;
			}
			return data;
		}
		if (!_data.TryGetValue(data, out data))
		{
			return 0;
		}
		return data;
	}

	public int SetMakeData(int type, int data)
	{
		return _data[type] = data;
	}

	public static ItemSourceType ConvertDataToItemSource(int data)
	{
		return data switch
		{
			0 => ItemSourceType.Inventory, 
			1 => ItemSourceType.Warehouse, 
			2 => ItemSourceType.Treasury, 
			3 => ItemSourceType.Stock, 
			_ => throw new NotImplementedException($"not supported: {data}"), 
		};
	}

	public static int ConvertItemSourceToData(ItemSourceType data)
	{
		return data switch
		{
			ItemSourceType.Inventory => 0, 
			ItemSourceType.Warehouse => 1, 
			ItemSourceType.Treasury => 2, 
			ItemSourceType.Stock => 3, 
			_ => throw new NotImplementedException($"not supported: {data}"), 
		};
	}

	public BuildingDefaultStoreLocation()
	{
	}

	public BuildingDefaultStoreLocation(BuildingDefaultStoreLocation other)
	{
		_data = ((other._data == null) ? null : new Dictionary<int, int>(other._data));
	}

	public void Assign(BuildingDefaultStoreLocation other)
	{
		_data = ((other._data == null) ? null : new Dictionary<int, int>(other._data));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(_data);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 1;
		byte* num = pData + 2;
		int totalSize = (int)(num + SerializationHelper.DictionaryOfBasicTypePair.Serialize(num, ref _data) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref _data);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

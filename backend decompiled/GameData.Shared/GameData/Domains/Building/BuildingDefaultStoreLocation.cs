using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Domains.Taiwu;
using GameData.Serializer;

namespace GameData.Domains.Building;

/// <summary>
/// 建筑默认的存储类型
/// </summary>
/// <summary>
/// 对于引用类型字段, 构造函数中可以不创建对象, 保留默认的 null 值.
/// 在进行反序列化时, 允许所有引用类型字段都为 null.
/// 但是在序列化时, 要求所有是定长集合的引用字段都已经被创建, 且长度与定义一致. 集合中的引用类型元素若也为定长, 则也必须被创建; 变长的则可以为 null.
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class BuildingDefaultStoreLocation : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Data = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "Data" };
	}

	/// <summary>
	/// 存入行囊
	/// </summary>
	public const int StoreToInventory = 0;

	/// <summary>
	/// 存入私库
	/// </summary>
	public const int StoreToWarehouse = 1;

	/// <summary>
	/// 存入公库
	/// </summary>
	public const int StoreToTreasury = 2;

	/// <summary>
	/// 存入货仓
	/// </summary>
	public const int StoreToGoodsShelf = 3;

	/// <summary>
	/// 数据，存放<see cref="T:GameData.Domains.Building.MakeItemMethod" /> -&gt; 上面定义的StoreTo.
	/// </summary>
	[SerializableGameDataField]
	private Dictionary<int, int> _data = new Dictionary<int, int>();

	public override string ToString()
	{
		return string.Format("{0}({1}) {{ {2} }}", GetType().Name, _data.Count, string.Join(", ", _data.Select((KeyValuePair<int, int> kv) => $"{kv.Key}: {kv.Value}")));
	}

	/// <summary>
	/// 后端读数据
	/// </summary>
	/// <param name="fromType"></param>
	/// <returns></returns>
	public ItemSourceType GetMakeType(int fromType)
	{
		return ConvertDataToItemSource(GetMakeData(fromType));
	}

	/// <summary>
	/// 前端取数据，在此可以设置默认值
	/// </summary>
	/// <param name="data"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 前端存数据
	/// </summary>
	/// <returns></returns>
	public int SetMakeData(int type, int data)
	{
		return _data[type] = data;
	}

	/// <summary>
	/// data到ItemSourceType的转化
	/// </summary>
	/// <param name="data"></param>
	/// <returns></returns>
	/// <exception cref="T:System.NotImplementedException"></exception>
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

	/// <summary>
	/// data到ItemSourceType的转化
	/// </summary>
	/// <param name="data"></param>
	/// <returns></returns>
	/// <exception cref="T:System.NotImplementedException"></exception>
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

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public BuildingDefaultStoreLocation()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public BuildingDefaultStoreLocation(BuildingDefaultStoreLocation other)
	{
		_data = ((other._data == null) ? null : new Dictionary<int, int>(other._data));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(BuildingDefaultStoreLocation other)
	{
		_data = ((other._data == null) ? null : new Dictionary<int, int>(other._data));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

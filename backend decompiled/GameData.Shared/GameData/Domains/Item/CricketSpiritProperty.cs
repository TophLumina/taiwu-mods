using System.Collections.Generic;
using GameData.Combat.Cricket;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item;

/// <summary>
/// 促织灵性属性加成
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class CricketSpiritProperty : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort PropertyAddValues = 0;

		public const ushort GrowthCount = 1;

		public const ushort Count = 2;

		public static readonly string[] FieldId2FieldName = new string[2] { "PropertyAddValues", "GrowthCount" };
	}

	/// <summary>
	/// 属性成长值
	/// </summary>
	[SerializableGameDataField(FieldIndex = 0)]
	public Dictionary<ECricketCombatPropertyType, int> PropertyAddValues;

	/// <summary>
	/// 已成长次数
	/// </summary>
	[SerializableGameDataField(FieldIndex = 1)]
	public int GrowthCount;

	public static implicit operator CricketCore(CricketSpiritProperty property)
	{
		Dictionary<ECricketCombatPropertyType, int> dictionary = property?.PropertyAddValues;
		if (dictionary == null || dictionary.Count <= 0)
		{
			return default(CricketCore);
		}
		CricketCore core = default(CricketCore);
		foreach (ECricketCombatPropertyType propertyType in CricketCombatPropertyTypeHelper.AllProperties)
		{
			core.SetProperty(propertyType, property.PropertyAddValues.GetOrDefault(propertyType));
		}
		return core;
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CricketSpiritProperty()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CricketSpiritProperty(CricketSpiritProperty other)
	{
		PropertyAddValues = ((other.PropertyAddValues == null) ? null : new Dictionary<ECricketCombatPropertyType, int>(other.PropertyAddValues));
		GrowthCount = other.GrowthCount;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CricketSpiritProperty other)
	{
		PropertyAddValues = ((other.PropertyAddValues == null) ? null : new Dictionary<ECricketCombatPropertyType, int>(other.PropertyAddValues));
		GrowthCount = other.GrowthCount;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize += SerializationHelper.DictionaryAsBasicTypePair.GetSerializedSize<ECricketCombatPropertyType, int, sbyte, int, Dictionary<ECricketCombatPropertyType, int>>(PropertyAddValues);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 2;
		byte* num = pData + 2;
		byte* num2 = num + SerializationHelper.DictionaryAsBasicTypePair.Serialize(num, ref PropertyAddValues, (ECricketCombatPropertyType key) => (sbyte)key, (int value) => value);
		*(int*)num2 = GrowthCount;
		int totalSize = (int)(num2 + 4 - pData);
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
			pCurrData += SerializationHelper.DictionaryAsBasicTypePair.Deserialize(pCurrData, ref PropertyAddValues, (sbyte key) => (ECricketCombatPropertyType)key, (int value) => value);
		}
		if (num > 1)
		{
			GrowthCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 匠人数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class CraftSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort WeaponChangeTrickDict = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "WeaponChangeTrickDict" };
	}

	/// <summary>
	/// 武器的初始招式（匠人-独具匠心）
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<ItemKey, ShortList> WeaponOriginTrickDict;

	public void Initialize()
	{
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CraftSkillsData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public CraftSkillsData(CraftSkillsData other)
	{
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(CraftSkillsData other)
	{
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
		totalSize += SerializationHelper.DictionaryOfCustomTypePair.GetSerializedSize(WeaponOriginTrickDict);
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
		int totalSize = (int)(num + SerializationHelper.DictionaryOfCustomTypePair.Serialize(num, ref WeaponOriginTrickDict) - pData);
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
			pCurrData += SerializationHelper.DictionaryOfCustomTypePair.Deserialize(pCurrData, ref WeaponOriginTrickDict);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

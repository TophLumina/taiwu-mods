using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[SerializableGameData(IsExtensible = true)]
public class CraftSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort WeaponChangeTrickDict = 0;

		public const ushort Count = 1;

		public static readonly string[] FieldId2FieldName = new string[1] { "WeaponChangeTrickDict" };
	}

	[SerializableGameDataField]
	public Dictionary<ItemKey, ShortList> WeaponOriginTrickDict;

	public void Initialize()
	{
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}

	public CraftSkillsData()
	{
	}

	public CraftSkillsData(CraftSkillsData other)
	{
	}

	public void Assign(CraftSkillsData other)
	{
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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

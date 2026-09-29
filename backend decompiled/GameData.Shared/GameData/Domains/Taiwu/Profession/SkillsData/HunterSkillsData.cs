using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[SerializableGameData(IsExtensible = true)]
public class HunterSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort UsedCarrierAnimalAttackCount = 0;

		public const ushort AnimalCharIdToItemKey = 1;

		public const ushort AnimalItemKeyToGender = 2;

		public const ushort AnimalCharIdToAttraction = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "UsedCarrierAnimalAttackCount", "AnimalCharIdToItemKey", "AnimalItemKeyToGender", "AnimalCharIdToAttraction" };
	}

	public const int AnimalAttackCostDurability = 30;

	[SerializableGameDataField]
	public sbyte UsedCarrierAnimalAttackCount;

	[SerializableGameDataField]
	public Dictionary<int, ItemKey> AnimalCharIdToItemKey;

	[SerializableGameDataField]
	public Dictionary<ItemKey, sbyte> AnimalItemKeyToGender;

	[SerializableGameDataField]
	public Dictionary<ItemKey, short> AnimalCharIdToAttraction;

	public void Initialize()
	{
		UsedCarrierAnimalAttackCount = 0;
		AnimalCharIdToItemKey?.Clear();
		AnimalItemKeyToGender?.Clear();
		AnimalCharIdToAttraction?.Clear();
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		if (sourceData is ObsoleteHunterSkillsData skillsData)
		{
			UsedCarrierAnimalAttackCount = skillsData.UsedCarrierAnimalAttackCount;
		}
	}

	public HunterSkillsData()
	{
	}

	public HunterSkillsData(HunterSkillsData other)
	{
		UsedCarrierAnimalAttackCount = other.UsedCarrierAnimalAttackCount;
		AnimalCharIdToItemKey = ((other.AnimalCharIdToItemKey == null) ? null : new Dictionary<int, ItemKey>(other.AnimalCharIdToItemKey));
		AnimalItemKeyToGender = ((other.AnimalItemKeyToGender == null) ? null : new Dictionary<ItemKey, sbyte>(other.AnimalItemKeyToGender));
		AnimalCharIdToAttraction = ((other.AnimalCharIdToAttraction == null) ? null : new Dictionary<ItemKey, short>(other.AnimalCharIdToAttraction));
	}

	public void Assign(HunterSkillsData other)
	{
		UsedCarrierAnimalAttackCount = other.UsedCarrierAnimalAttackCount;
		AnimalCharIdToItemKey = ((other.AnimalCharIdToItemKey == null) ? null : new Dictionary<int, ItemKey>(other.AnimalCharIdToItemKey));
		AnimalItemKeyToGender = ((other.AnimalItemKeyToGender == null) ? null : new Dictionary<ItemKey, sbyte>(other.AnimalItemKeyToGender));
		AnimalCharIdToAttraction = ((other.AnimalCharIdToAttraction == null) ? null : new Dictionary<ItemKey, short>(other.AnimalCharIdToAttraction));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 3;
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(AnimalCharIdToItemKey);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(AnimalItemKeyToGender);
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(AnimalCharIdToAttraction);
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
		*num = (byte)UsedCarrierAnimalAttackCount;
		byte* num2 = num + 1;
		byte* num3 = num2 + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(num2, ref AnimalCharIdToItemKey);
		byte* num4 = num3 + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(num3, ref AnimalItemKeyToGender);
		int totalSize = (int)(num4 + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(num4, ref AnimalCharIdToAttraction) - pData);
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
			UsedCarrierAnimalAttackCount = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (num > 1)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref AnimalCharIdToItemKey);
		}
		if (num > 2)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref AnimalItemKeyToGender);
		}
		if (num > 3)
		{
			pCurrData += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pCurrData, ref AnimalCharIdToAttraction);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

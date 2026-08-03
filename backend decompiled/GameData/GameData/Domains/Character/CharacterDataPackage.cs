using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

[SerializableGameData(NotForDisplayModule = true, NoCopyConstructors = true, IsExtensible = true)]
public class CharacterDataPackage : ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort Character = 0;

		public const ushort CombatSkills = 1;

		public const ushort CombatSkillProficiencies = 2;

		public const ushort ItemGroupPackage = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "Character", "CombatSkills", "CombatSkillProficiencies", "ItemGroupPackage" };
	}

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public Character Character;

	[SerializableGameDataField]
	public Dictionary<short, GameData.Domains.CombatSkill.CombatSkill> CombatSkills;

	[SerializableGameDataField]
	public Dictionary<short, int> CombatSkillProficiencies;

	[SerializableGameDataField(SubDataMaxCount = int.MaxValue)]
	public ItemGroupPackage ItemGroupPackage;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2;
		totalSize = ((Character == null) ? (totalSize + 4) : (totalSize + (4 + Character.GetSerializedSize())));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(CombatSkills);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(CombatSkillProficiencies);
		totalSize = ((ItemGroupPackage == null) ? (totalSize + 4) : (totalSize + (4 + ItemGroupPackage.GetSerializedSize())));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 4;
		pCurrData += 2;
		if (Character != null)
		{
			byte* pSubDataCount = pCurrData;
			pCurrData += 4;
			int fieldSize = Character.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= int.MaxValue);
			*(int*)pSubDataCount = fieldSize;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref CombatSkills);
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize(pCurrData, ref CombatSkillProficiencies);
		if (ItemGroupPackage != null)
		{
			byte* pSubDataCount2 = pCurrData;
			pCurrData += 4;
			int fieldSize2 = ItemGroupPackage.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= int.MaxValue);
			*(int*)pSubDataCount2 = fieldSize2;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			int fieldSize = *(int*)pCurrData;
			pCurrData += 4;
			if (fieldSize > 0)
			{
				if (Character == null)
				{
					Character = new Character();
				}
				pCurrData += Character.Deserialize(pCurrData);
			}
			else
			{
				Character = null;
			}
		}
		if (fieldCount > 1)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref CombatSkills);
		}
		if (fieldCount > 2)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref CombatSkillProficiencies);
		}
		if (fieldCount > 3)
		{
			int fieldSize2 = *(int*)pCurrData;
			pCurrData += 4;
			if (fieldSize2 > 0)
			{
				if (ItemGroupPackage == null)
				{
					ItemGroupPackage = new ItemGroupPackage();
				}
				pCurrData += ItemGroupPackage.Deserialize(pCurrData);
			}
			else
			{
				ItemGroupPackage = null;
			}
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

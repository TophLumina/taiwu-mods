using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

public class PossessionPreview : ISerializableGameData
{
	[SerializableGameDataField]
	public byte Result;

	[SerializableGameDataField]
	public int Id;

	[SerializableGameDataField]
	public short Age;

	[SerializableGameDataField]
	public int BirthDate;

	[SerializableGameDataField]
	public short Health;

	[SerializableGameDataField]
	public sbyte Gender;

	[SerializableGameDataField]
	public short BaseMorality;

	[SerializableGameDataField]
	public sbyte Happiness;

	[SerializableGameDataField]
	public sbyte Fame;

	[SerializableGameDataField]
	public Personalities Personalities;

	[SerializableGameDataField]
	public short BirthFeatureId;

	[SerializableGameDataField]
	public List<short> FeatureIds;

	[SerializableGameDataField]
	public MainAttributes BaseMainAttributes;

	[SerializableGameDataField]
	public LifeSkillShorts BaseLifeSkillQualifications;

	[SerializableGameDataField]
	public CombatSkillShorts BaseCombatSkillQualifications;

	[SerializableGameDataField]
	public sbyte ConsummateLevel;

	[SerializableGameDataField]
	public NeiliAllocation NeiliAllocation;

	[SerializableGameDataField]
	public int CurrNeili;

	[SerializableGameDataField]
	public NeiliProportionOfFiveElements BaseNeiliProportionOfFiveElements;

	[SerializableGameDataField]
	public CharacterSamsaraData CharacterSamsaraData;

	public PossessionPreview()
	{
	}

	public PossessionPreview(PossessionPreview other)
	{
		Result = other.Result;
		Id = other.Id;
		Age = other.Age;
		BirthDate = other.BirthDate;
		Health = other.Health;
		Gender = other.Gender;
		BaseMorality = other.BaseMorality;
		Happiness = other.Happiness;
		Fame = other.Fame;
		Personalities = other.Personalities;
		BirthFeatureId = other.BirthFeatureId;
		FeatureIds = ((other.FeatureIds == null) ? null : new List<short>(other.FeatureIds));
		BaseMainAttributes = other.BaseMainAttributes;
		BaseLifeSkillQualifications = other.BaseLifeSkillQualifications;
		BaseCombatSkillQualifications = other.BaseCombatSkillQualifications;
		ConsummateLevel = other.ConsummateLevel;
		NeiliAllocation = other.NeiliAllocation;
		CurrNeili = other.CurrNeili;
		BaseNeiliProportionOfFiveElements = other.BaseNeiliProportionOfFiveElements;
		CharacterSamsaraData = new CharacterSamsaraData(other.CharacterSamsaraData);
	}

	public void Assign(PossessionPreview other)
	{
		Result = other.Result;
		Id = other.Id;
		Age = other.Age;
		BirthDate = other.BirthDate;
		Health = other.Health;
		Gender = other.Gender;
		BaseMorality = other.BaseMorality;
		Happiness = other.Happiness;
		Fame = other.Fame;
		Personalities = other.Personalities;
		BirthFeatureId = other.BirthFeatureId;
		FeatureIds = ((other.FeatureIds == null) ? null : new List<short>(other.FeatureIds));
		BaseMainAttributes = other.BaseMainAttributes;
		BaseLifeSkillQualifications = other.BaseLifeSkillQualifications;
		BaseCombatSkillQualifications = other.BaseCombatSkillQualifications;
		ConsummateLevel = other.ConsummateLevel;
		NeiliAllocation = other.NeiliAllocation;
		CurrNeili = other.CurrNeili;
		BaseNeiliProportionOfFiveElements = other.BaseNeiliProportionOfFiveElements;
		CharacterSamsaraData = new CharacterSamsaraData(other.CharacterSamsaraData);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 121;
		totalSize = ((FeatureIds == null) ? (totalSize + 2) : (totalSize + (2 + 2 * FeatureIds.Count)));
		totalSize = ((CharacterSamsaraData == null) ? (totalSize + 2) : (totalSize + (2 + CharacterSamsaraData.GetSerializedSize())));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = Result;
		pCurrData++;
		*(int*)pCurrData = Id;
		pCurrData += 4;
		*(short*)pCurrData = Age;
		pCurrData += 2;
		*(int*)pCurrData = BirthDate;
		pCurrData += 4;
		*(short*)pCurrData = Health;
		pCurrData += 2;
		*pCurrData = (byte)Gender;
		pCurrData++;
		*(short*)pCurrData = BaseMorality;
		pCurrData += 2;
		*pCurrData = (byte)Happiness;
		pCurrData++;
		*pCurrData = (byte)Fame;
		pCurrData++;
		pCurrData += Personalities.Serialize(pCurrData);
		*(short*)pCurrData = BirthFeatureId;
		pCurrData += 2;
		if (FeatureIds != null)
		{
			int elementsCount = FeatureIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = FeatureIds[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += BaseMainAttributes.Serialize(pCurrData);
		pCurrData += BaseLifeSkillQualifications.Serialize(pCurrData);
		pCurrData += BaseCombatSkillQualifications.Serialize(pCurrData);
		*pCurrData = (byte)ConsummateLevel;
		pCurrData++;
		pCurrData += NeiliAllocation.Serialize(pCurrData);
		*(int*)pCurrData = CurrNeili;
		pCurrData += 4;
		pCurrData += BaseNeiliProportionOfFiveElements.Serialize(pCurrData);
		if (CharacterSamsaraData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CharacterSamsaraData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
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
		Result = *pCurrData;
		pCurrData++;
		Id = *(int*)pCurrData;
		pCurrData += 4;
		Age = *(short*)pCurrData;
		pCurrData += 2;
		BirthDate = *(int*)pCurrData;
		pCurrData += 4;
		Health = *(short*)pCurrData;
		pCurrData += 2;
		Gender = (sbyte)(*pCurrData);
		pCurrData++;
		BaseMorality = *(short*)pCurrData;
		pCurrData += 2;
		Happiness = (sbyte)(*pCurrData);
		pCurrData++;
		Fame = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += Personalities.Deserialize(pCurrData);
		BirthFeatureId = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (FeatureIds == null)
			{
				FeatureIds = new List<short>(elementsCount);
			}
			else
			{
				FeatureIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				FeatureIds.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			FeatureIds?.Clear();
		}
		pCurrData += BaseMainAttributes.Deserialize(pCurrData);
		pCurrData += BaseLifeSkillQualifications.Deserialize(pCurrData);
		pCurrData += BaseCombatSkillQualifications.Deserialize(pCurrData);
		ConsummateLevel = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += NeiliAllocation.Deserialize(pCurrData);
		CurrNeili = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += BaseNeiliProportionOfFiveElements.Deserialize(pCurrData);
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			if (CharacterSamsaraData == null)
			{
				CharacterSamsaraData = new CharacterSamsaraData();
			}
			pCurrData += CharacterSamsaraData.Deserialize(pCurrData);
		}
		else
		{
			CharacterSamsaraData = null;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

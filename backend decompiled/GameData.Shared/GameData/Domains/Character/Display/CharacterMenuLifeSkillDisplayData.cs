using System.Collections.Generic;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class CharacterMenuLifeSkillDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<LifeSkillItem> LearnedLifeSkills;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillQualifications;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField]
	public Dictionary<short, TaiwuLifeSkill> TaiwuLifeSkills = new Dictionary<short, TaiwuLifeSkill>();

	[SerializableGameDataField]
	public Dictionary<short, TaiwuLifeSkill> TaiwuNotLearnLifeSkills = new Dictionary<short, TaiwuLifeSkill>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 64;
		totalSize = ((LearnedLifeSkills == null) ? (totalSize + 2) : (totalSize + (2 + 4 * LearnedLifeSkills.Count)));
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(TaiwuLifeSkills);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(TaiwuNotLearnLifeSkills);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (LearnedLifeSkills != null)
		{
			int elementsCount = LearnedLifeSkills.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += LearnedLifeSkills[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += LifeSkillQualifications.Serialize(pCurrData);
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref TaiwuLifeSkills);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref TaiwuNotLearnLifeSkills);
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (LearnedLifeSkills == null)
			{
				LearnedLifeSkills = new List<LifeSkillItem>(elementsCount);
			}
			else
			{
				LearnedLifeSkills.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				LifeSkillItem element = default(LifeSkillItem);
				pCurrData += element.Deserialize(pCurrData);
				LearnedLifeSkills.Add(element);
			}
		}
		else
		{
			LearnedLifeSkills?.Clear();
		}
		pCurrData += LifeSkillQualifications.Deserialize(pCurrData);
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref TaiwuLifeSkills);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref TaiwuNotLearnLifeSkills);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

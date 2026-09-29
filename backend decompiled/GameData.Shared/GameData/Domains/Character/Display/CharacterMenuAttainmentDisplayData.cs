using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character.Display;

[SerializableGameData(NotRestrictCollectionSerializedSize = true, NoCopyConstructors = true)]
public class CharacterMenuAttainmentDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public short[] CombatSkillAttainmentPanels;

	[SerializableGameDataField]
	public short[] CombatSkillAttainmentPlans;

	[SerializableGameDataField]
	public List<short> LearnedCombatSkills;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillQualifications;

	[SerializableGameDataField]
	public short ActualAge;

	[SerializableGameDataField]
	public sbyte CombatSkillGrowthType;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	[SerializableGameDataField]
	public List<CombatSkillDisplayDataCharacterMenuListItem> LearnedCombatSkillDatasSimple;

	[SerializableGameDataField]
	public int DivinePower;

	[SerializableGameDataField]
	public int GhostTechnique;

	[SerializableGameDataField]
	public List<LifeSkillItem> LearnedLifeSkills;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillQualifications;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField]
	public sbyte LifeSkillGrowthType;

	[SerializableGameDataField]
	public Dictionary<short, TaiwuLifeSkill> TaiwuLifeSkills = new Dictionary<short, TaiwuLifeSkill>();

	[SerializableGameDataField]
	public Dictionary<short, TaiwuLifeSkill> TaiwuNotLearnLifeSkills = new Dictionary<short, TaiwuLifeSkill>();

	[SerializableGameDataField]
	public byte CreationType;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 133;
		totalSize = ((CombatSkillAttainmentPanels == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CombatSkillAttainmentPanels.Length)));
		totalSize = ((CombatSkillAttainmentPlans == null) ? (totalSize + 2) : (totalSize + (2 + 2 * CombatSkillAttainmentPlans.Length)));
		totalSize = ((LearnedCombatSkills == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedCombatSkills.Count)));
		if (LearnedCombatSkillDatasSimple != null)
		{
			totalSize += 2;
			int elementsCount = LearnedCombatSkillDatasSimple.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				CombatSkillDisplayDataCharacterMenuListItem element = LearnedCombatSkillDatasSimple[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
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
		if (CombatSkillAttainmentPanels != null)
		{
			int elementsCount = CombatSkillAttainmentPanels.Length;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = CombatSkillAttainmentPanels[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CombatSkillAttainmentPlans != null)
		{
			int elementsCount2 = CombatSkillAttainmentPlans.Length;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				((short*)pCurrData)[j] = CombatSkillAttainmentPlans[j];
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LearnedCombatSkills != null)
		{
			int elementsCount3 = LearnedCombatSkills.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = LearnedCombatSkills[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += CombatSkillQualifications.Serialize(pCurrData);
		*(short*)pCurrData = ActualAge;
		pCurrData += 2;
		*pCurrData = (byte)CombatSkillGrowthType;
		pCurrData++;
		pCurrData += CombatSkillAttainments.Serialize(pCurrData);
		if (LearnedCombatSkillDatasSimple != null)
		{
			int elementsCount4 = LearnedCombatSkillDatasSimple.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				CombatSkillDisplayDataCharacterMenuListItem element = LearnedCombatSkillDatasSimple[l];
				if (element != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int subDataSize = element.Serialize(pCurrData);
					pCurrData += subDataSize;
					Tester.Assert(subDataSize <= 65535);
					*(ushort*)intPtr = (ushort)subDataSize;
				}
				else
				{
					*(short*)pCurrData = 0;
					pCurrData += 2;
				}
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = DivinePower;
		pCurrData += 4;
		*(int*)pCurrData = GhostTechnique;
		pCurrData += 4;
		if (LearnedLifeSkills != null)
		{
			int elementsCount5 = LearnedLifeSkills.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				pCurrData += LearnedLifeSkills[m].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += LifeSkillQualifications.Serialize(pCurrData);
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		*pCurrData = (byte)LifeSkillGrowthType;
		pCurrData++;
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref TaiwuLifeSkills);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pCurrData, ref TaiwuNotLearnLifeSkills);
		*pCurrData = CreationType;
		pCurrData++;
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
			if (CombatSkillAttainmentPanels == null || CombatSkillAttainmentPanels.Length != elementsCount)
			{
				CombatSkillAttainmentPanels = new short[elementsCount];
			}
			for (int i = 0; i < elementsCount; i++)
			{
				CombatSkillAttainmentPanels[i] = ((short*)pCurrData)[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			CombatSkillAttainmentPanels = null;
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CombatSkillAttainmentPlans == null || CombatSkillAttainmentPlans.Length != elementsCount2)
			{
				CombatSkillAttainmentPlans = new short[elementsCount2];
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				CombatSkillAttainmentPlans[j] = ((short*)pCurrData)[j];
			}
			pCurrData += 2 * elementsCount2;
		}
		else
		{
			CombatSkillAttainmentPlans = null;
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (LearnedCombatSkills == null)
			{
				LearnedCombatSkills = new List<short>(elementsCount3);
			}
			else
			{
				LearnedCombatSkills.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				LearnedCombatSkills.Add(((short*)pCurrData)[k]);
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			LearnedCombatSkills?.Clear();
		}
		pCurrData += CombatSkillQualifications.Deserialize(pCurrData);
		ActualAge = *(short*)pCurrData;
		pCurrData += 2;
		CombatSkillGrowthType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += CombatSkillAttainments.Deserialize(pCurrData);
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (LearnedCombatSkillDatasSimple == null)
			{
				LearnedCombatSkillDatasSimple = new List<CombatSkillDisplayDataCharacterMenuListItem>(elementsCount4);
			}
			else
			{
				LearnedCombatSkillDatasSimple.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					CombatSkillDisplayDataCharacterMenuListItem element = new CombatSkillDisplayDataCharacterMenuListItem();
					pCurrData += element.Deserialize(pCurrData);
					LearnedCombatSkillDatasSimple.Add(element);
				}
				else
				{
					LearnedCombatSkillDatasSimple.Add(null);
				}
			}
		}
		else
		{
			LearnedCombatSkillDatasSimple?.Clear();
		}
		DivinePower = *(int*)pCurrData;
		pCurrData += 4;
		GhostTechnique = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (LearnedLifeSkills == null)
			{
				LearnedLifeSkills = new List<LifeSkillItem>(elementsCount5);
			}
			else
			{
				LearnedLifeSkills.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				LifeSkillItem element2 = default(LifeSkillItem);
				pCurrData += element2.Deserialize(pCurrData);
				LearnedLifeSkills.Add(element2);
			}
		}
		else
		{
			LearnedLifeSkills?.Clear();
		}
		pCurrData += LifeSkillQualifications.Deserialize(pCurrData);
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		LifeSkillGrowthType = (sbyte)(*pCurrData);
		pCurrData++;
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref TaiwuLifeSkills);
		pCurrData += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pCurrData, ref TaiwuNotLearnLifeSkills);
		CreationType = *pCurrData;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

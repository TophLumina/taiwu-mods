using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Character.Display;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class CharacterDisplayDataForPractice : ISerializableGameData
{
	[SerializableGameDataField]
	public int CharId;

	[SerializableGameDataField]
	public int Exp;

	[SerializableGameDataField]
	public short InnerRatio;

	[SerializableGameDataField]
	public short LoopingNeigong;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillAttainments;

	[SerializableGameDataField]
	public CombatSkillShorts CombatSkillQualifications;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillAttainments;

	[SerializableGameDataField]
	public LifeSkillShorts LifeSkillQualifications;

	[SerializableGameDataField]
	public List<short> LearnedCombatSkills;

	[SerializableGameDataField]
	public List<sbyte> LuohanAccessories;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 12;
		totalSize += CombatSkillAttainments.GetSerializedSize();
		totalSize += CombatSkillQualifications.GetSerializedSize();
		totalSize += LifeSkillAttainments.GetSerializedSize();
		totalSize += LifeSkillQualifications.GetSerializedSize();
		totalSize = ((LearnedCombatSkills == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedCombatSkills.Count)));
		totalSize = ((LuohanAccessories == null) ? (totalSize + 2) : (totalSize + (2 + LuohanAccessories.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CharId;
		pCurrData += 4;
		*(int*)pCurrData = Exp;
		pCurrData += 4;
		*(short*)pCurrData = InnerRatio;
		pCurrData += 2;
		*(short*)pCurrData = LoopingNeigong;
		pCurrData += 2;
		pCurrData += CombatSkillAttainments.Serialize(pCurrData);
		pCurrData += CombatSkillQualifications.Serialize(pCurrData);
		pCurrData += LifeSkillAttainments.Serialize(pCurrData);
		pCurrData += LifeSkillQualifications.Serialize(pCurrData);
		if (LearnedCombatSkills != null)
		{
			int elementsCount = LearnedCombatSkills.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				*(short*)pCurrData = LearnedCombatSkills[i];
				pCurrData += 2;
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (LuohanAccessories != null)
		{
			int elementsCount2 = LuohanAccessories.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				*pCurrData = (byte)LuohanAccessories[j];
				pCurrData++;
			}
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
		CharId = *(int*)pCurrData;
		pCurrData += 4;
		Exp = *(int*)pCurrData;
		pCurrData += 4;
		InnerRatio = *(short*)pCurrData;
		pCurrData += 2;
		LoopingNeigong = *(short*)pCurrData;
		pCurrData += 2;
		pCurrData += CombatSkillAttainments.Deserialize(pCurrData);
		pCurrData += CombatSkillQualifications.Deserialize(pCurrData);
		pCurrData += LifeSkillAttainments.Deserialize(pCurrData);
		pCurrData += LifeSkillQualifications.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (LearnedCombatSkills == null)
			{
				LearnedCombatSkills = new List<short>();
			}
			else
			{
				LearnedCombatSkills.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				short element = *(short*)pCurrData;
				pCurrData += 2;
				LearnedCombatSkills.Add(element);
			}
		}
		else
		{
			LearnedCombatSkills?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (LuohanAccessories == null)
			{
				LuohanAccessories = new List<sbyte>();
			}
			else
			{
				LuohanAccessories.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				sbyte element2 = (sbyte)(*pCurrData);
				pCurrData++;
				LuohanAccessories.Add(element2);
			}
		}
		else
		{
			LuohanAccessories?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

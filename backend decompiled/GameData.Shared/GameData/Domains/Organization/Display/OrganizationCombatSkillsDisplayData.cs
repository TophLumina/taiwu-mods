using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Organization.Display;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class OrganizationCombatSkillsDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public sbyte OrganizationTemplateId;

	[SerializableGameDataField]
	public short ApprovingRate;

	[SerializableGameDataField]
	public short ApprovingRateTotal;

	[SerializableGameDataField]
	public short ApprovingRateUpperLimit;

	[SerializableGameDataField]
	public short ApprovingRateUpperLimitBonus;

	[SerializableGameDataField]
	public List<CombatSkillDisplayData> LearnedSkills;

	[SerializableGameDataField]
	public int Duration;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 13;
		if (LearnedSkills != null)
		{
			totalSize += 2;
			for (int i = 0; i < LearnedSkills.Count; i++)
			{
				totalSize = ((LearnedSkills[i] == null) ? (totalSize + 2) : (totalSize + (2 + LearnedSkills[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*pCurrData = (byte)OrganizationTemplateId;
		pCurrData++;
		*(short*)pCurrData = ApprovingRate;
		pCurrData += 2;
		*(short*)pCurrData = ApprovingRateTotal;
		pCurrData += 2;
		*(short*)pCurrData = ApprovingRateUpperLimit;
		pCurrData += 2;
		*(short*)pCurrData = ApprovingRateUpperLimitBonus;
		pCurrData += 2;
		if (LearnedSkills != null)
		{
			int elementsCount = LearnedSkills.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (LearnedSkills[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = LearnedSkills[i].Serialize(pCurrData);
					pCurrData += fieldSize;
					Tester.Assert(fieldSize <= 65535);
					*(ushort*)intPtr = (ushort)fieldSize;
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
		*(int*)pCurrData = Duration;
		pCurrData += 4;
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
		OrganizationTemplateId = (sbyte)(*pCurrData);
		pCurrData++;
		ApprovingRate = *(short*)pCurrData;
		pCurrData += 2;
		ApprovingRateTotal = *(short*)pCurrData;
		pCurrData += 2;
		ApprovingRateUpperLimit = *(short*)pCurrData;
		pCurrData += 2;
		ApprovingRateUpperLimitBonus = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (LearnedSkills == null)
			{
				LearnedSkills = new List<CombatSkillDisplayData>();
			}
			else
			{
				LearnedSkills.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				CombatSkillDisplayData element;
				if (num > 0)
				{
					element = new CombatSkillDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				LearnedSkills.Add(element);
			}
		}
		else
		{
			LearnedSkills?.Clear();
		}
		Duration = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

using System.Collections.Generic;
using GameData.Domains.Taiwu;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.CombatSkill;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class CombatSkillPracticeDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public CombatSkillDisplayData CombatSkillDisplayData;

	[SerializableGameDataField]
	public SkillBreakPlate SkillBreakPlate;

	[SerializableGameDataField]
	public CombatSkillBreakSuccessRateDisplayData CombatSkillBreakSuccessRateDisplayData = new CombatSkillBreakSuccessRateDisplayData();

	[SerializableGameDataField]
	public CombatSkillBreakAvailableStepsDisplayData CombatSkillBreakAvailableStepsDisplayData = new CombatSkillBreakAvailableStepsDisplayData();

	[SerializableGameDataField]
	public List<SkillBreakPlateBonus> Bonuses;

	[SerializableGameDataField]
	public int ReBreakCd;

	[SerializableGameDataField]
	public int DisplayAvailableSteps;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 24;
		totalSize = ((CombatSkillDisplayData == null) ? (totalSize + 2) : (totalSize + (2 + CombatSkillDisplayData.GetSerializedSize())));
		totalSize = ((SkillBreakPlate == null) ? (totalSize + 2) : (totalSize + (2 + SkillBreakPlate.GetSerializedSize())));
		if (Bonuses != null)
		{
			totalSize += 2;
			for (int i = 0; i < Bonuses.Count; i++)
			{
				totalSize += Bonuses[i].GetSerializedSize();
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
		if (CombatSkillDisplayData != null)
		{
			byte* intPtr = pCurrData;
			pCurrData += 2;
			int fieldSize = CombatSkillDisplayData.Serialize(pCurrData);
			pCurrData += fieldSize;
			Tester.Assert(fieldSize <= 65535);
			*(ushort*)intPtr = (ushort)fieldSize;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (SkillBreakPlate != null)
		{
			byte* intPtr2 = pCurrData;
			pCurrData += 2;
			int fieldSize2 = SkillBreakPlate.Serialize(pCurrData);
			pCurrData += fieldSize2;
			Tester.Assert(fieldSize2 <= 65535);
			*(ushort*)intPtr2 = (ushort)fieldSize2;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		pCurrData += CombatSkillBreakSuccessRateDisplayData.Serialize(pCurrData);
		pCurrData += CombatSkillBreakAvailableStepsDisplayData.Serialize(pCurrData);
		if (Bonuses != null)
		{
			int elementsCount = Bonuses.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				int fieldSize3 = Bonuses[i].Serialize(pCurrData);
				pCurrData += fieldSize3;
				Tester.Assert(fieldSize3 <= 65535);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*(int*)pCurrData = ReBreakCd;
		pCurrData += 4;
		*(int*)pCurrData = DisplayAvailableSteps;
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			CombatSkillDisplayData = new CombatSkillDisplayData();
			pCurrData += CombatSkillDisplayData.Deserialize(pCurrData);
		}
		else
		{
			CombatSkillDisplayData = null;
		}
		ushort num2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num2 > 0)
		{
			SkillBreakPlate = new SkillBreakPlate();
			pCurrData += SkillBreakPlate.Deserialize(pCurrData);
		}
		else
		{
			SkillBreakPlate = null;
		}
		CombatSkillBreakSuccessRateDisplayData = new CombatSkillBreakSuccessRateDisplayData();
		pCurrData += CombatSkillBreakSuccessRateDisplayData.Deserialize(pCurrData);
		CombatSkillBreakAvailableStepsDisplayData = new CombatSkillBreakAvailableStepsDisplayData();
		pCurrData += CombatSkillBreakAvailableStepsDisplayData.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Bonuses == null)
			{
				Bonuses = new List<SkillBreakPlateBonus>();
			}
			else
			{
				Bonuses.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				SkillBreakPlateBonus element = default(SkillBreakPlateBonus);
				pCurrData += element.Deserialize(pCurrData);
				Bonuses.Add(element);
			}
		}
		else
		{
			Bonuses?.Clear();
		}
		ReBreakCd = *(int*)pCurrData;
		pCurrData += 4;
		DisplayAvailableSteps = *(int*)pCurrData;
		pCurrData += 4;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

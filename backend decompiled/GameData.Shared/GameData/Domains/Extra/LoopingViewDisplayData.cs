using System.Collections.Generic;
using GameData.Domains.CombatSkill;
using GameData.Domains.Taiwu.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Extra;

[SerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class LoopingViewDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public int CurConcentration;

	[SerializableGameDataField]
	public int MaxConcentration;

	[SerializableGameDataField]
	public int CurrNeili;

	[SerializableGameDataField]
	public short LoopingNeigong = -1;

	[SerializableGameDataField]
	public List<short> LearnedSkillList = new List<short>();

	[SerializableGameDataField]
	public List<CombatSkillDisplayDataCharacterMenuListItem> CombatSkillDisplayDataList = new List<CombatSkillDisplayDataCharacterMenuListItem>();

	[SerializableGameDataField]
	public List<short> ReferenceSkillList = new List<short>();

	[SerializableGameDataField]
	public byte ReferenceSkillSlotUnlockStates;

	[SerializableGameDataField]
	public IntList TaiwuExtraNeiliAllocationProgress;

	[SerializableGameDataField]
	public int ExtraNeiliPerLoopMin;

	[SerializableGameDataField]
	public int ExtraNeiliPerLoopMax;

	[SerializableGameDataField]
	public IntList ExtraNeiliAllocationPerLoop;

	[SerializableGameDataField]
	public TaiwuNeiliProportionDisplayData NeiliData = new TaiwuNeiliProportionDisplayData();

	[SerializableGameDataField]
	public sbyte NeiliType = -1;

	[SerializableGameDataField]
	public List<QiArtStrategyDisplayData> TaiwuQiArtStrategyList = new List<QiArtStrategyDisplayData>();

	[SerializableGameDataField]
	public SByteList AvailableStrategies;

	[SerializableGameDataField]
	public List<short> LoopingEventSkillIdList = new List<short>();

	[SerializableGameDataField]
	public sbyte LoopInLifeSkillCombatCount;

	[SerializableGameDataField]
	public sbyte LoopInCombatCount;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 46;
		totalSize = ((LearnedSkillList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedSkillList.Count)));
		if (CombatSkillDisplayDataList != null)
		{
			totalSize += 2;
			int elementsCount = CombatSkillDisplayDataList.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				CombatSkillDisplayDataCharacterMenuListItem element = CombatSkillDisplayDataList[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		totalSize = ((ReferenceSkillList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * ReferenceSkillList.Count)));
		totalSize += TaiwuExtraNeiliAllocationProgress.GetSerializedSize();
		totalSize += ExtraNeiliAllocationPerLoop.GetSerializedSize();
		totalSize = ((TaiwuQiArtStrategyList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * TaiwuQiArtStrategyList.Count)));
		totalSize += AvailableStrategies.GetSerializedSize();
		totalSize = ((LoopingEventSkillIdList == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LoopingEventSkillIdList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(int*)pCurrData = CurConcentration;
		pCurrData += 4;
		*(int*)pCurrData = MaxConcentration;
		pCurrData += 4;
		*(int*)pCurrData = CurrNeili;
		pCurrData += 4;
		*(short*)pCurrData = LoopingNeigong;
		pCurrData += 2;
		if (LearnedSkillList != null)
		{
			int elementsCount = LearnedSkillList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = LearnedSkillList[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		if (CombatSkillDisplayDataList != null)
		{
			int elementsCount2 = CombatSkillDisplayDataList.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				CombatSkillDisplayDataCharacterMenuListItem element = CombatSkillDisplayDataList[j];
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
		if (ReferenceSkillList != null)
		{
			int elementsCount3 = ReferenceSkillList.Count;
			Tester.Assert(elementsCount3 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount3;
			pCurrData += 2;
			for (int k = 0; k < elementsCount3; k++)
			{
				((short*)pCurrData)[k] = ReferenceSkillList[k];
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = ReferenceSkillSlotUnlockStates;
		pCurrData++;
		int fieldSize = TaiwuExtraNeiliAllocationProgress.Serialize(pCurrData);
		pCurrData += fieldSize;
		Tester.Assert(fieldSize <= 65535);
		*(int*)pCurrData = ExtraNeiliPerLoopMin;
		pCurrData += 4;
		*(int*)pCurrData = ExtraNeiliPerLoopMax;
		pCurrData += 4;
		int fieldSize2 = ExtraNeiliAllocationPerLoop.Serialize(pCurrData);
		pCurrData += fieldSize2;
		Tester.Assert(fieldSize2 <= 65535);
		pCurrData += NeiliData.Serialize(pCurrData);
		*pCurrData = (byte)NeiliType;
		pCurrData++;
		if (TaiwuQiArtStrategyList != null)
		{
			int elementsCount4 = TaiwuQiArtStrategyList.Count;
			Tester.Assert(elementsCount4 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount4;
			pCurrData += 2;
			for (int l = 0; l < elementsCount4; l++)
			{
				pCurrData += TaiwuQiArtStrategyList[l].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int fieldSize3 = AvailableStrategies.Serialize(pCurrData);
		pCurrData += fieldSize3;
		Tester.Assert(fieldSize3 <= 65535);
		if (LoopingEventSkillIdList != null)
		{
			int elementsCount5 = LoopingEventSkillIdList.Count;
			Tester.Assert(elementsCount5 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount5;
			pCurrData += 2;
			for (int m = 0; m < elementsCount5; m++)
			{
				((short*)pCurrData)[m] = LoopingEventSkillIdList[m];
			}
			pCurrData += 2 * elementsCount5;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		*pCurrData = (byte)LoopInLifeSkillCombatCount;
		pCurrData++;
		*pCurrData = (byte)LoopInCombatCount;
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
		CurConcentration = *(int*)pCurrData;
		pCurrData += 4;
		MaxConcentration = *(int*)pCurrData;
		pCurrData += 4;
		CurrNeili = *(int*)pCurrData;
		pCurrData += 4;
		LoopingNeigong = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (LearnedSkillList == null)
			{
				LearnedSkillList = new List<short>(elementsCount);
			}
			else
			{
				LearnedSkillList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				LearnedSkillList.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			LearnedSkillList?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (CombatSkillDisplayDataList == null)
			{
				CombatSkillDisplayDataList = new List<CombatSkillDisplayDataCharacterMenuListItem>(elementsCount2);
			}
			else
			{
				CombatSkillDisplayDataList.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					CombatSkillDisplayDataCharacterMenuListItem element = new CombatSkillDisplayDataCharacterMenuListItem();
					pCurrData += element.Deserialize(pCurrData);
					CombatSkillDisplayDataList.Add(element);
				}
				else
				{
					CombatSkillDisplayDataList.Add(null);
				}
			}
		}
		else
		{
			CombatSkillDisplayDataList?.Clear();
		}
		ushort elementsCount3 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount3 > 0)
		{
			if (ReferenceSkillList == null)
			{
				ReferenceSkillList = new List<short>(elementsCount3);
			}
			else
			{
				ReferenceSkillList.Clear();
			}
			for (int k = 0; k < elementsCount3; k++)
			{
				ReferenceSkillList.Add(((short*)pCurrData)[k]);
			}
			pCurrData += 2 * elementsCount3;
		}
		else
		{
			ReferenceSkillList?.Clear();
		}
		ReferenceSkillSlotUnlockStates = *pCurrData;
		pCurrData++;
		pCurrData += TaiwuExtraNeiliAllocationProgress.Deserialize(pCurrData);
		ExtraNeiliPerLoopMin = *(int*)pCurrData;
		pCurrData += 4;
		ExtraNeiliPerLoopMax = *(int*)pCurrData;
		pCurrData += 4;
		pCurrData += ExtraNeiliAllocationPerLoop.Deserialize(pCurrData);
		if (NeiliData == null)
		{
			NeiliData = new TaiwuNeiliProportionDisplayData();
		}
		pCurrData += NeiliData.Deserialize(pCurrData);
		NeiliType = (sbyte)(*pCurrData);
		pCurrData++;
		ushort elementsCount4 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount4 > 0)
		{
			if (TaiwuQiArtStrategyList == null)
			{
				TaiwuQiArtStrategyList = new List<QiArtStrategyDisplayData>(elementsCount4);
			}
			else
			{
				TaiwuQiArtStrategyList.Clear();
			}
			for (int l = 0; l < elementsCount4; l++)
			{
				QiArtStrategyDisplayData element2 = new QiArtStrategyDisplayData();
				pCurrData += element2.Deserialize(pCurrData);
				TaiwuQiArtStrategyList.Add(element2);
			}
		}
		else
		{
			TaiwuQiArtStrategyList?.Clear();
		}
		pCurrData += AvailableStrategies.Deserialize(pCurrData);
		ushort elementsCount5 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount5 > 0)
		{
			if (LoopingEventSkillIdList == null)
			{
				LoopingEventSkillIdList = new List<short>(elementsCount5);
			}
			else
			{
				LoopingEventSkillIdList.Clear();
			}
			for (int m = 0; m < elementsCount5; m++)
			{
				LoopingEventSkillIdList.Add(((short*)pCurrData)[m]);
			}
			pCurrData += 2 * elementsCount5;
		}
		else
		{
			LoopingEventSkillIdList?.Clear();
		}
		LoopInLifeSkillCombatCount = (sbyte)(*pCurrData);
		pCurrData++;
		LoopInCombatCount = (sbyte)(*pCurrData);
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

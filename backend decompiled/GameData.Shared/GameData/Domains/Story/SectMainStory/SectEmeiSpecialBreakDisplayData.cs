using System.Collections.Generic;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Story.SectMainStory;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class SectEmeiSpecialBreakDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public bool IsAdvanceUnlocked;

	[SerializableGameDataField]
	public Dictionary<short, SectEmeiBreakBonusData> SectEmeiBreakBonusData;

	[SerializableGameDataField]
	public List<short> LearnedCombatSkills;

	[SerializableGameDataField]
	public List<ItemDisplayData> Items;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 1;
		totalSize += 4;
		if (SectEmeiBreakBonusData != null)
		{
			foreach (KeyValuePair<short, SectEmeiBreakBonusData> pair in SectEmeiBreakBonusData)
			{
				totalSize += 2;
				totalSize += pair.Value.GetSerializedSize();
			}
		}
		totalSize = ((LearnedCombatSkills == null) ? (totalSize + 2) : (totalSize + (2 + 2 * LearnedCombatSkills.Count)));
		if (Items != null)
		{
			totalSize += 2;
			for (int i = 0; i < Items.Count; i++)
			{
				totalSize = ((Items[i] == null) ? (totalSize + 2) : (totalSize + (2 + Items[i].GetSerializedSize())));
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
		*pCurrData = (IsAdvanceUnlocked ? ((byte)1) : ((byte)0));
		pCurrData++;
		if (SectEmeiBreakBonusData != null)
		{
			*(int*)pCurrData = SectEmeiBreakBonusData.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, SectEmeiBreakBonusData> pair in SectEmeiBreakBonusData)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				pCurrData += pair.Value.Serialize(pCurrData);
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
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
		if (Items != null)
		{
			int elementsCount2 = Items.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (Items[j] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = Items[j].Serialize(pCurrData);
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
		IsAdvanceUnlocked = *pCurrData != 0;
		pCurrData++;
		int SectEmeiBreakBonusDataElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (SectEmeiBreakBonusDataElementsCount > 0)
		{
			if (SectEmeiBreakBonusData == null)
			{
				SectEmeiBreakBonusData = new Dictionary<short, SectEmeiBreakBonusData>();
			}
			else
			{
				SectEmeiBreakBonusData.Clear();
			}
			for (int i = 0; i < SectEmeiBreakBonusDataElementsCount; i++)
			{
				short key = *(short*)pCurrData;
				pCurrData += 2;
				SectEmeiBreakBonusData value = default(SectEmeiBreakBonusData);
				pCurrData += value.Deserialize(pCurrData);
				SectEmeiBreakBonusData.Add(key, value);
			}
		}
		else
		{
			SectEmeiBreakBonusData?.Clear();
		}
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
			for (int j = 0; j < elementsCount; j++)
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
			if (Items == null)
			{
				Items = new List<ItemDisplayData>();
			}
			else
			{
				Items.Clear();
			}
			for (int k = 0; k < elementsCount2; k++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				ItemDisplayData element2;
				if (num > 0)
				{
					element2 = new ItemDisplayData();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				Items.Add(element2);
			}
		}
		else
		{
			Items?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

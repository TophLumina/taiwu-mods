using System.Collections.Generic;
using GameData.Domains.Character.Display;
using GameData.Serializer;
using GameData.Utilities;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Taiwu.Display;

[AutoGenerateSerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class TaiwuLifeSummaryDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<CharacterDisplayData> TotalTaiwuDisplayDatas;

	[SerializableGameDataField]
	public List<TaiwuLifeSummary> TotalTaiwuLifeSummaries;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (TotalTaiwuDisplayDatas != null)
		{
			totalSize += 2;
			for (int i = 0; i < TotalTaiwuDisplayDatas.Count; i++)
			{
				totalSize = ((TotalTaiwuDisplayDatas[i] == null) ? (totalSize + 2) : (totalSize + (2 + TotalTaiwuDisplayDatas[i].GetSerializedSize())));
			}
		}
		else
		{
			totalSize += 2;
		}
		if (TotalTaiwuLifeSummaries != null)
		{
			totalSize += 2;
			for (int j = 0; j < TotalTaiwuLifeSummaries.Count; j++)
			{
				totalSize = ((TotalTaiwuLifeSummaries[j] == null) ? (totalSize + 2) : (totalSize + (2 + TotalTaiwuLifeSummaries[j].GetSerializedSize())));
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
		if (TotalTaiwuDisplayDatas != null)
		{
			int elementsCount = TotalTaiwuDisplayDatas.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				if (TotalTaiwuDisplayDatas[i] != null)
				{
					byte* intPtr = pCurrData;
					pCurrData += 2;
					int fieldSize = TotalTaiwuDisplayDatas[i].Serialize(pCurrData);
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
		if (TotalTaiwuLifeSummaries != null)
		{
			int elementsCount2 = TotalTaiwuLifeSummaries.Count;
			Tester.Assert(elementsCount2 <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount2;
			pCurrData += 2;
			for (int j = 0; j < elementsCount2; j++)
			{
				if (TotalTaiwuLifeSummaries[j] != null)
				{
					byte* intPtr2 = pCurrData;
					pCurrData += 2;
					int fieldSize2 = TotalTaiwuLifeSummaries[j].Serialize(pCurrData);
					pCurrData += fieldSize2;
					Tester.Assert(fieldSize2 <= 65535);
					*(ushort*)intPtr2 = (ushort)fieldSize2;
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
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (TotalTaiwuDisplayDatas == null)
			{
				TotalTaiwuDisplayDatas = new List<CharacterDisplayData>();
			}
			else
			{
				TotalTaiwuDisplayDatas.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				CharacterDisplayData element;
				if (num > 0)
				{
					element = new CharacterDisplayData();
					pCurrData += element.Deserialize(pCurrData);
				}
				else
				{
					element = null;
				}
				TotalTaiwuDisplayDatas.Add(element);
			}
		}
		else
		{
			TotalTaiwuDisplayDatas?.Clear();
		}
		ushort elementsCount2 = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount2 > 0)
		{
			if (TotalTaiwuLifeSummaries == null)
			{
				TotalTaiwuLifeSummaries = new List<TaiwuLifeSummary>();
			}
			else
			{
				TotalTaiwuLifeSummaries.Clear();
			}
			for (int j = 0; j < elementsCount2; j++)
			{
				ushort num2 = *(ushort*)pCurrData;
				pCurrData += 2;
				TaiwuLifeSummary element2;
				if (num2 > 0)
				{
					element2 = new TaiwuLifeSummary();
					pCurrData += element2.Deserialize(pCurrData);
				}
				else
				{
					element2 = null;
				}
				TotalTaiwuLifeSummaries.Add(element2);
			}
		}
		else
		{
			TotalTaiwuLifeSummaries?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

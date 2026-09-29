using System.Collections.Generic;
using GameData.Domains.Character;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.TaiwuEvent.DisplayEvent;

[SerializableGameData(NotRestrictCollectionSerializedSize = true)]
public class EventSelectFameData : ISerializableGameData
{
	[SerializableGameDataField]
	public List<FameActionRecord> fameActionRecords;

	public EventSelectFameData()
	{
	}

	public EventSelectFameData(EventSelectFameData other)
	{
		fameActionRecords = ((other.fameActionRecords == null) ? null : new List<FameActionRecord>(other.fameActionRecords));
	}

	public void Assign(EventSelectFameData other)
	{
		fameActionRecords = ((other.fameActionRecords == null) ? null : new List<FameActionRecord>(other.fameActionRecords));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((fameActionRecords == null) ? (totalSize + 2) : (totalSize + (2 + 8 * fameActionRecords.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (fameActionRecords != null)
		{
			int elementsCount = fameActionRecords.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += fameActionRecords[i].Serialize(pCurrData);
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
			if (fameActionRecords == null)
			{
				fameActionRecords = new List<FameActionRecord>(elementsCount);
			}
			else
			{
				fameActionRecords.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				FameActionRecord element = default(FameActionRecord);
				pCurrData += element.Deserialize(pCurrData);
				fameActionRecords.Add(element);
			}
		}
		else
		{
			fameActionRecords?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

[SerializableGameData]
public class MindMarkList : ISerializableGameData
{
	[SerializableGameDataField]
	public List<CountdownData> MarkList = new List<CountdownData>();

	public MindMarkList()
	{
	}

	public MindMarkList(MindMarkList other)
	{
		MarkList = ((other.MarkList == null) ? null : new List<CountdownData>(other.MarkList));
	}

	public void Assign(MindMarkList other)
	{
		MarkList = ((other.MarkList == null) ? null : new List<CountdownData>(other.MarkList));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((MarkList == null) ? (totalSize + 2) : (totalSize + (2 + 8 * MarkList.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (MarkList != null)
		{
			int elementsCount = MarkList.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += MarkList[i].Serialize(pCurrData);
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
			if (MarkList == null)
			{
				MarkList = new List<CountdownData>(elementsCount);
			}
			else
			{
				MarkList.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				CountdownData element = default(CountdownData);
				pCurrData += element.Deserialize(pCurrData);
				MarkList.Add(element);
			}
		}
		else
		{
			MarkList?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

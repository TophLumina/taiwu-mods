using System.Collections.Generic;
using GameData.Domains.Item.Display;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Item;

[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class CricketWagerData : ISerializableGameData
{
	[SerializableGameDataField]
	public Wager Wager;

	[SerializableGameDataField]
	public List<ItemDisplayData> Crickets;

	[SerializableGameDataField]
	public long MinWagerValue;

	[SerializableGameDataField]
	public byte PreRandomizedShowCricketIndex;

	public bool IsShowCricket(int index)
	{
		if (PreRandomizedShowCricketIndex != byte.MaxValue)
		{
			return PreRandomizedShowCricketIndex == index;
		}
		return true;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 29;
		if (Crickets != null)
		{
			totalSize += 2;
			int elementsCount = Crickets.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				ItemDisplayData element = Crickets[i];
				totalSize = ((element == null) ? (totalSize + 2) : (totalSize + (2 + element.GetSerializedSize())));
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
		pCurrData += Wager.Serialize(pCurrData);
		if (Crickets != null)
		{
			int elementsCount = Crickets.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				ItemDisplayData element = Crickets[i];
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
		*(long*)pCurrData = MinWagerValue;
		pCurrData += 8;
		*pCurrData = PreRandomizedShowCricketIndex;
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
		pCurrData += Wager.Deserialize(pCurrData);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Crickets == null)
			{
				Crickets = new List<ItemDisplayData>(elementsCount);
			}
			else
			{
				Crickets.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					ItemDisplayData element = new ItemDisplayData();
					pCurrData += element.Deserialize(pCurrData);
					Crickets.Add(element);
				}
				else
				{
					Crickets.Add(null);
				}
			}
		}
		else
		{
			Crickets?.Clear();
		}
		MinWagerValue = *(long*)pCurrData;
		pCurrData += 8;
		PreRandomizedShowCricketIndex = *pCurrData;
		pCurrData++;
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

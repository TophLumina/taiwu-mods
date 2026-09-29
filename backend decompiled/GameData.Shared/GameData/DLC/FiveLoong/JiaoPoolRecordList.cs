using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.DLC.FiveLoong;

public class JiaoPoolRecordList : ISerializableGameData
{
	[SerializableGameDataField]
	public List<JiaoPoolRecord> Collection = new List<JiaoPoolRecord>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		if (Collection != null)
		{
			totalSize += 2;
			int elementsCount = Collection.Count;
			for (int i = 0; i < elementsCount; i++)
			{
				JiaoPoolRecord element = Collection[i];
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
		if (Collection != null)
		{
			int elementsCount = Collection.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				JiaoPoolRecord element = Collection[i];
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
			if (Collection == null)
			{
				Collection = new List<JiaoPoolRecord>(elementsCount);
			}
			else
			{
				Collection.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				ushort num = *(ushort*)pCurrData;
				pCurrData += 2;
				if (num > 0)
				{
					JiaoPoolRecord element = new JiaoPoolRecord();
					pCurrData += element.Deserialize(pCurrData);
					Collection.Add(element);
				}
				else
				{
					Collection.Add(null);
				}
			}
		}
		else
		{
			Collection?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

public struct LongList : ISerializableGameData
{
	public List<long> Items;

	public static LongList Create()
	{
		LongList obj = default(LongList);
		obj.Items = new List<long>();
		return obj;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 4 + 8 * (Items?.Count ?? 0);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Items != null)
		{
			int elementsCount = Items.Count;
			Tester.Assert(elementsCount <= 65535);
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			for (int i = 0; i < elementsCount; i++)
			{
				((long*)pCurrData)[i] = Items[i];
			}
			pCurrData += 8 * elementsCount;
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int elementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (elementsCount > 0)
		{
			if (Items == null)
			{
				Items = new List<long>(elementsCount);
			}
			else
			{
				Items.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				Items.Add(((long*)pCurrData)[i]);
			}
			pCurrData += 8 * elementsCount;
		}
		else
		{
			Items?.Clear();
		}
		return (int)(pCurrData - pData);
	}
}

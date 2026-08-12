using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

public struct SByteList : ISerializableGameData
{
	public List<sbyte> Items;

	public static SByteList Create()
	{
		SByteList obj = default(SByteList);
		obj.Items = new List<sbyte>();
		return obj;
	}

	public SByteList(SByteList other)
	{
		Items = ((other.Items == null) ? null : new List<sbyte>(other.Items));
	}

	public SByteList(IEnumerable<sbyte> items)
	{
		Items = new List<sbyte>();
		if (items != null)
		{
			Items.AddRange(items);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 4 + (Items?.Count ?? 0);
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
				pCurrData[i] = (byte)Items[i];
			}
			pCurrData += elementsCount;
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
				Items = new List<sbyte>(elementsCount);
			}
			else
			{
				Items.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				Items.Add((sbyte)pCurrData[i]);
			}
			pCurrData += elementsCount;
		}
		else
		{
			Items?.Clear();
		}
		return (int)(pCurrData - pData);
	}
}

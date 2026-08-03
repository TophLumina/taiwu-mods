using System.Collections;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

public struct IntList : ISerializableGameData, IGameDataList<int>, IList<int>, ICollection<int>, IEnumerable<int>, IEnumerable, IList, ICollection
{
	public List<int> Items;

	List<int> IGameDataList<int>.InternalList => Items;

	public static IntList Create()
	{
		IntList obj = default(IntList);
		obj.Items = new List<int>();
		return obj;
	}

	public IntList(IEnumerable<int> other)
	{
		Items = ((other == null) ? null : new List<int>(other));
	}

	public IntList(IntList other)
	{
		Items = ((other.Items == null) ? null : new List<int>(other.Items));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 4 + 4 * (Items?.Count ?? 0);
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
				((int*)pCurrData)[i] = Items[i];
			}
			pCurrData += 4 * elementsCount;
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
				Items = new List<int>(elementsCount);
			}
			else
			{
				Items.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				Items.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			Items?.Clear();
		}
		return (int)(pCurrData - pData);
	}
}

using System.Collections;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

public struct ShortList : ISerializableGameData, IGameDataList<short>, IList<short>, ICollection<short>, IEnumerable<short>, IEnumerable, IList, ICollection
{
	public List<short> Items;

	List<short> IGameDataList<short>.InternalList => Items;

	public static ShortList Create()
	{
		ShortList obj = default(ShortList);
		obj.Items = new List<short>();
		return obj;
	}

	public ShortList(ShortList other)
	{
		Items = ((other.Items != null) ? new List<short>(other.Items) : null);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		return 2 + 2 * (Items?.Count ?? 0);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (Items != null)
		{
			int elementsCount = Items.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((short*)pCurrData)[i] = Items[i];
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		return (int)(pCurrData - pData);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (Items == null)
			{
				Items = new List<short>(elementsCount);
			}
			else
			{
				Items.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				Items.Add(((short*)pCurrData)[i]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			Items?.Clear();
		}
		return (int)(pCurrData - pData);
	}
}

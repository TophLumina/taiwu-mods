using System.Collections;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

public struct SerializableList<T> : IReadOnlySerializableList, IGameDataList<T>, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, ISerializableGameData where T : ISerializableGameData, new()
{
	public List<T> Items;

	List<T> IGameDataList<T>.InternalList => Items;

	public static SerializableList<T> Create()
	{
		SerializableList<T> obj = default(SerializableList<T>);
		obj.Items = new List<T>();
		return obj;
	}

	public SerializableList(SerializableList<T> other)
	{
		Items = ((other.Items == null) ? null : new List<T>(other.Items));
	}

	public SerializableList(IEnumerable<T> items)
	{
		Items = new List<T>();
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
		int totalSize = 4;
		if (Items != null)
		{
			for (int i = 0; i < Items.Count; i++)
			{
				totalSize += Items[i].GetSerializedSize();
			}
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
		if (Items != null)
		{
			int elementsCount = Items.Count;
			Tester.Assert(elementsCount <= 65535);
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += Items[i].Serialize(pCurrData);
			}
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
				Items = new List<T>(elementsCount);
			}
			else
			{
				Items.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				T element = new T();
				pCurrData += element.Deserialize(pCurrData);
				Items.Add(element);
			}
		}
		else
		{
			Items?.Clear();
		}
		return (int)(pCurrData - pData);
	}

	int IReadOnlySerializableList.GetCount()
	{
		return Items?.Count ?? 0;
	}

	ISerializableGameData IReadOnlySerializableList.GetElementAt(int index)
	{
		return Items[index];
	}
}

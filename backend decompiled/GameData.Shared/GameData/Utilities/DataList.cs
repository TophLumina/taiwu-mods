using System.Collections;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Utilities;

[SerializableGameData(NotForArchive = true)]
public class DataList<T> : ISerializableGameData, IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IReadOnlyList<T>, IReadOnlyCollection<T> where T : ISerializableGameData, new()
{
	[SerializableGameDataField]
	private List<T> _list;

	private IList<T> ListImplementation => _list ?? (_list = new List<T>());

	public int Count => ListImplementation.Count;

	public bool IsReadOnly => ListImplementation.IsReadOnly;

	public T this[int index]
	{
		get
		{
			return ListImplementation[index];
		}
		set
		{
			ListImplementation[index] = value;
		}
	}

	public DataList()
	{
	}

	public DataList(IEnumerable<T> other)
	{
		_list = ((other == null) ? null : new List<T>(other));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 4;
		List<T> list = _list;
		if (list == null || list.Count <= 0)
		{
			return totalSize;
		}
		foreach (T item in _list)
		{
			totalSize += item.GetSerializedSize();
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
		*(int*)pCurrData = _list?.Count ?? 0;
		pCurrData += 4;
		List<T> list = _list;
		if (list != null && list.Count > 0)
		{
			for (int i = 0; i < _list.Count; i++)
			{
				pCurrData += _list[i].Serialize(pCurrData);
			}
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
		int count = *(int*)pCurrData;
		pCurrData += 4;
		if (count == 0)
		{
			_list?.Clear();
		}
		else
		{
			if (_list == null)
			{
				_list = new List<T>(count);
			}
			for (int i = 0; i < count; i++)
			{
				T data = new T();
				pCurrData += data.Deserialize(pCurrData);
				_list.Add(data);
			}
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public IEnumerator<T> GetEnumerator()
	{
		return ListImplementation.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return ((IEnumerable)ListImplementation).GetEnumerator();
	}

	public void Add(T item)
	{
		ListImplementation.Add(item);
	}

	public void Clear()
	{
		ListImplementation.Clear();
	}

	public bool Contains(T item)
	{
		return ListImplementation.Contains(item);
	}

	public void CopyTo(T[] array, int arrayIndex)
	{
		ListImplementation.CopyTo(array, arrayIndex);
	}

	public bool Remove(T item)
	{
		return ListImplementation.Remove(item);
	}

	public int IndexOf(T item)
	{
		return ListImplementation.IndexOf(item);
	}

	public void Insert(int index, T item)
	{
		ListImplementation.Insert(index, item);
	}

	public void RemoveAt(int index)
	{
		ListImplementation.RemoveAt(index);
	}
}

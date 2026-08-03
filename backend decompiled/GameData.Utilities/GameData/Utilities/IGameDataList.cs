using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GameData.Utilities;

public interface IGameDataList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection
{
	protected List<T> InternalList { get; }

	int ICollection<T>.Count => InternalList?.Count ?? 0;

	bool ICollection<T>.IsReadOnly => false;

	T IList<T>.this[int index]
	{
		get
		{
			return InternalList[index];
		}
		set
		{
			InternalList[index] = value;
		}
	}

	int ICollection.Count => ((ICollection<T>)this).Count;

	bool ICollection.IsSynchronized => false;

	object ICollection.SyncRoot => InternalList;

	bool IList.IsFixedSize => false;

	bool IList.IsReadOnly => false;

	object IList.this[int index]
	{
		get
		{
			return InternalList[index];
		}
		set
		{
			InternalList[index] = (T)value;
		}
	}

	IEnumerator<T> IEnumerable<T>.GetEnumerator()
	{
		List<T>.Enumerator? enumerator = InternalList?.GetEnumerator();
		if (!enumerator.HasValue)
		{
			return Enumerable.Empty<T>().GetEnumerator();
		}
		return enumerator.GetValueOrDefault();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	void ICollection<T>.Add(T item)
	{
		InternalList.Add(item);
	}

	void ICollection<T>.Clear()
	{
		InternalList?.Clear();
	}

	bool ICollection<T>.Contains(T item)
	{
		return InternalList?.Contains(item) ?? false;
	}

	void ICollection<T>.CopyTo(T[] array, int arrayIndex)
	{
		InternalList?.CopyTo(array, arrayIndex);
	}

	bool ICollection<T>.Remove(T item)
	{
		return InternalList?.Remove(item) ?? false;
	}

	int IList<T>.IndexOf(T item)
	{
		return InternalList?.IndexOf(item) ?? (-1);
	}

	void IList<T>.Insert(int index, T item)
	{
		InternalList.Insert(index, item);
	}

	void IList<T>.RemoveAt(int index)
	{
		InternalList.RemoveAt(index);
	}

	void ICollection.CopyTo(Array array, int index)
	{
		CopyTo((T[])array, index);
	}

	int IList.Add(object value)
	{
		Add((T)value);
		return InternalList.Count - 1;
	}

	void IList.Clear()
	{
		((ICollection<T>)this).Clear();
	}

	bool IList.Contains(object value)
	{
		return Contains((T)value);
	}

	int IList.IndexOf(object value)
	{
		return IndexOf((T)value);
	}

	void IList.Insert(int index, object value)
	{
		Insert(index, (T)value);
	}

	void IList.Remove(object value)
	{
		Remove((T)value);
	}

	void IList.RemoveAt(int index)
	{
		((IList<T>)this).RemoveAt(index);
	}
}

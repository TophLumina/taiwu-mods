using System;
using System.Collections;
using System.Collections.Generic;

namespace GameData.Utilities;

public class HashSetAsDictionary<TKey> : IDictionary<TKey, VoidValue>, ICollection<KeyValuePair<TKey, VoidValue>>, IEnumerable<KeyValuePair<TKey, VoidValue>>, IEnumerable where TKey : unmanaged
{
	public struct Enumerator : IEnumerator<KeyValuePair<TKey, VoidValue>>, IEnumerator, IDisposable, IDictionaryEnumerator
	{
		private readonly HashSet<TKey> _collection;

		private HashSet<TKey>.Enumerator _enumerator;

		public KeyValuePair<TKey, VoidValue> Current => new KeyValuePair<TKey, VoidValue>(_enumerator.Current, default(VoidValue));

		object IEnumerator.Current => new KeyValuePair<TKey, VoidValue>(_enumerator.Current, default(VoidValue));

		public object Key => _enumerator.Current;

		public object Value => default(VoidValue);

		public DictionaryEntry Entry => new DictionaryEntry(_enumerator.Current, default(VoidValue));

		internal Enumerator(HashSet<TKey> collection)
		{
			_collection = collection;
			_enumerator = _collection.GetEnumerator();
		}

		public bool MoveNext()
		{
			return _enumerator.MoveNext();
		}

		public void Dispose()
		{
		}

		void IEnumerator.Reset()
		{
			_enumerator = _collection.GetEnumerator();
		}
	}

	public readonly HashSet<TKey> Collection;

	public int Count => Collection.Count;

	public bool IsReadOnly => false;

	public VoidValue this[TKey key]
	{
		get
		{
			return default(VoidValue);
		}
		set
		{
			Collection.Add(key);
		}
	}

	public ICollection<TKey> Keys => Collection;

	public ICollection<VoidValue> Values
	{
		get
		{
			throw new NotImplementedException();
		}
	}

	public HashSetAsDictionary()
	{
		Collection = new HashSet<TKey>();
	}

	public void Add(KeyValuePair<TKey, VoidValue> item)
	{
		Add(item.Key, item.Value);
	}

	public bool Contains(KeyValuePair<TKey, VoidValue> item)
	{
		return Collection.Contains(item.Key);
	}

	public bool Contains(TKey key)
	{
		return Collection.Contains(key);
	}

	public void CopyTo(KeyValuePair<TKey, VoidValue>[] array, int arrayIndex)
	{
		throw new NotImplementedException();
	}

	public bool Remove(KeyValuePair<TKey, VoidValue> item)
	{
		return Collection.Remove(item.Key);
	}

	public void Add(TKey key, VoidValue value)
	{
		Collection.Add(key);
	}

	public bool ContainsKey(TKey key)
	{
		return Collection.Contains(key);
	}

	public bool TryGetValue(TKey key, out VoidValue value)
	{
		value = default(VoidValue);
		return Collection.Contains(key);
	}

	public bool Remove(TKey key)
	{
		return Collection.Remove(key);
	}

	public void Clear()
	{
		Collection.Clear();
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(Collection);
	}

	IEnumerator<KeyValuePair<TKey, VoidValue>> IEnumerable<KeyValuePair<TKey, VoidValue>>.GetEnumerator()
	{
		return new Enumerator(Collection);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(Collection);
	}
}

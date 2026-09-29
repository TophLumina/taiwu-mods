using System;
using System.Collections;
using System.Collections.Generic;

namespace GameData.Domains.Map;

public class AreaBlockCollection : IDictionary<short, MapBlockData>, ICollection<KeyValuePair<short, MapBlockData>>, IEnumerable<KeyValuePair<short, MapBlockData>>, IEnumerable
{
	public struct Enumerator : IEnumerator<KeyValuePair<short, MapBlockData>>, IEnumerator, IDisposable, IDictionaryEnumerator
	{
		private readonly MapBlockData[] _collection;

		private short _blockId;

		private KeyValuePair<short, MapBlockData> _current;

		public KeyValuePair<short, MapBlockData> Current => _current;

		object IEnumerator.Current => _current;

		public object Key => _current.Key;

		public object Value => _current.Value;

		public DictionaryEntry Entry => new DictionaryEntry(_current.Key, _current.Value);

		internal Enumerator(MapBlockData[] collection)
		{
			_collection = collection;
			_blockId = 0;
			_current = default(KeyValuePair<short, MapBlockData>);
		}

		public bool MoveNext()
		{
			if (_collection != null && _blockId < _collection.Length)
			{
				MapBlockData value = _collection[_blockId];
				_current = new KeyValuePair<short, MapBlockData>(_blockId, value);
				_blockId++;
				return true;
			}
			_current = default(KeyValuePair<short, MapBlockData>);
			return false;
		}

		public void Dispose()
		{
		}

		void IEnumerator.Reset()
		{
			_blockId = 0;
			_current = default(KeyValuePair<short, MapBlockData>);
		}
	}

	private MapBlockData[] _collection;

	private List<MapBlockData> _tmpCollection;

	public int Count
	{
		get
		{
			MapBlockData[] collection = _collection;
			if (collection == null)
			{
				return 0;
			}
			return collection.Length;
		}
	}

	public bool IsReadOnly => false;

	public MapBlockData this[short key]
	{
		get
		{
			return _collection[key];
		}
		set
		{
			_collection[key] = value;
		}
	}

	[Obsolete("This method will not be implemented.")]
	public ICollection<short> Keys
	{
		get
		{
			throw new SystemException("Unimplemented interface be invoked. method: Keys");
		}
	}

	[Obsolete("This method will not be implemented. Use GetArray instead.")]
	public ICollection<MapBlockData> Values
	{
		get
		{
			throw new SystemException("Unimplemented interface be invoked. method: Values");
		}
	}

	public void Init(int blockCount)
	{
		_collection = new MapBlockData[blockCount];
	}

	public void ConvertToRegularCollection()
	{
		_collection = ((_tmpCollection == null) ? Array.Empty<MapBlockData>() : _tmpCollection.ToArray());
		_tmpCollection = null;
	}

	public MapBlockData[] GetArray()
	{
		return _collection;
	}

	public MapBlockData FindByTemplateId(short templateId)
	{
		MapBlockData[] collection = _collection;
		foreach (MapBlockData block in collection)
		{
			if (block.TemplateId == templateId)
			{
				return block;
			}
		}
		return null;
	}

	public void Add(KeyValuePair<short, MapBlockData> item)
	{
		Add(item.Key, item.Value);
	}

	public bool Contains(KeyValuePair<short, MapBlockData> item)
	{
		if (item.Key >= 0 && item.Key < _collection.Length)
		{
			return EqualityComparer<MapBlockData>.Default.Equals(_collection[item.Key], item.Value);
		}
		return false;
	}

	[Obsolete("This method will not be implemented.")]
	public void CopyTo(KeyValuePair<short, MapBlockData>[] array, int arrayIndex)
	{
		throw new SystemException("Unimplemented interface be invoked. method: CopyTo");
	}

	[Obsolete("This method will not be implemented.")]
	public bool Remove(KeyValuePair<short, MapBlockData> item)
	{
		throw new SystemException("Unimplemented interface be invoked. method: Remove");
	}

	public void Add(short key, MapBlockData value)
	{
		if (_collection != null)
		{
			_collection[key] = value;
			return;
		}
		if (_tmpCollection == null)
		{
			_tmpCollection = new List<MapBlockData>();
		}
		_tmpCollection.Add(value);
	}

	public bool ContainsKey(short key)
	{
		if (key >= 0)
		{
			return key < _collection.Length;
		}
		return false;
	}

	public bool TryGetValue(short key, out MapBlockData value)
	{
		if (_collection != null && key >= 0 && key < _collection.Length)
		{
			value = _collection[key];
			return true;
		}
		value = null;
		return false;
	}

	public bool Remove(short key)
	{
		_collection[key] = null;
		return false;
	}

	public void Clear()
	{
		_tmpCollection?.Clear();
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(_collection);
	}

	IEnumerator<KeyValuePair<short, MapBlockData>> IEnumerable<KeyValuePair<short, MapBlockData>>.GetEnumerator()
	{
		return new Enumerator(_collection);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(_collection);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using GameData.Utilities;

namespace GameData.Domains.Map;

public class AreaGroupBlockCollection : IDictionary<Location, MapBlockData>, ICollection<KeyValuePair<Location, MapBlockData>>, IEnumerable<KeyValuePair<Location, MapBlockData>>, IEnumerable
{
	public struct Enumerator : IEnumerator<KeyValuePair<Location, MapBlockData>>, IEnumerator, IDisposable, IDictionaryEnumerator
	{
		private readonly AreaBlockCollection[] _collection;

		private short _areaId;

		private short _areaIdOffset;

		private bool _subEnumeratorExists;

		private AreaBlockCollection.Enumerator _subEnumerator;

		private KeyValuePair<Location, MapBlockData> _current;

		public KeyValuePair<Location, MapBlockData> Current => _current;

		object IEnumerator.Current => _current;

		public object Key => _current.Key;

		public object Value => _current.Value;

		public DictionaryEntry Entry => new DictionaryEntry(_current.Key, _current.Value);

		internal Enumerator(AreaBlockCollection[] collection, short areaIdOffset)
		{
			_collection = collection;
			_areaId = areaIdOffset;
			_areaIdOffset = areaIdOffset;
			_subEnumeratorExists = false;
			_subEnumerator = default(AreaBlockCollection.Enumerator);
			_current = default(KeyValuePair<Location, MapBlockData>);
		}

		public bool MoveNext()
		{
			if (_subEnumeratorExists && _subEnumerator.MoveNext())
			{
				KeyValuePair<short, MapBlockData> subCurrent = _subEnumerator.Current;
				_current = new KeyValuePair<Location, MapBlockData>(new Location(_areaId, subCurrent.Key), subCurrent.Value);
				return true;
			}
			short areaId;
			do
			{
				if (_areaId >= _collection.Length)
				{
					_current = default(KeyValuePair<Location, MapBlockData>);
					return false;
				}
				areaId = _areaId;
				AreaBlockCollection subCollection = _collection[areaId - _areaIdOffset];
				_subEnumerator = subCollection.GetEnumerator();
				_subEnumeratorExists = true;
				_areaId++;
			}
			while (!_subEnumerator.MoveNext());
			KeyValuePair<short, MapBlockData> subCurrent2 = _subEnumerator.Current;
			_current = new KeyValuePair<Location, MapBlockData>(new Location(areaId, subCurrent2.Key), subCurrent2.Value);
			return true;
		}

		public void Dispose()
		{
		}

		void IEnumerator.Reset()
		{
			_subEnumerator = default(AreaBlockCollection.Enumerator);
			_subEnumeratorExists = false;
			_current = default(KeyValuePair<Location, MapBlockData>);
			_areaId = _areaIdOffset;
		}
	}

	private short _areaIdOffset;

	private AreaBlockCollection[] _areaBlockCollections;

	public AreaBlockCollection this[short areaId] => _areaBlockCollections[areaId - _areaIdOffset];

	public int Count
	{
		get
		{
			int count = 0;
			AreaBlockCollection[] areaBlockCollections = _areaBlockCollections;
			foreach (AreaBlockCollection entry in areaBlockCollections)
			{
				count += entry.Count;
			}
			return count;
		}
	}

	public bool IsReadOnly => false;

	public MapBlockData this[Location key]
	{
		get
		{
			return _areaBlockCollections[key.AreaId - _areaIdOffset][key.BlockId];
		}
		set
		{
			_areaBlockCollections[key.AreaId - _areaIdOffset][key.BlockId] = value;
		}
	}

	[Obsolete("This method will not be implemented.")]
	public ICollection<Location> Keys
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

	public AreaGroupBlockCollection(short areaIdOffset, int areaCount)
	{
		Init(areaIdOffset, areaCount);
	}

	public void Init(short areaIdOffset, int areaCount)
	{
		_areaIdOffset = areaIdOffset;
		_areaBlockCollections = new AreaBlockCollection[areaCount];
		for (int i = 0; i < _areaBlockCollections.Length; i++)
		{
			_areaBlockCollections[i] = new AreaBlockCollection();
		}
	}

	public void ConvertToRegularCollection()
	{
		AreaBlockCollection[] areaBlockCollections = _areaBlockCollections;
		for (int i = 0; i < areaBlockCollections.Length; i++)
		{
			areaBlockCollections[i].ConvertToRegularCollection();
		}
	}

	public void InitArea(short areaId, int blockCount)
	{
		_areaBlockCollections[areaId - _areaIdOffset].Init(blockCount);
	}

	public Enumerator GetEnumerator()
	{
		return new Enumerator(_areaBlockCollections, _areaIdOffset);
	}

	IEnumerator<KeyValuePair<Location, MapBlockData>> IEnumerable<KeyValuePair<Location, MapBlockData>>.GetEnumerator()
	{
		return new Enumerator(_areaBlockCollections, _areaIdOffset);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new Enumerator(_areaBlockCollections, _areaIdOffset);
	}

	public void Add(KeyValuePair<Location, MapBlockData> item)
	{
		Add(item.Key, item.Value);
	}

	public void Clear()
	{
		AreaBlockCollection[] areaBlockCollections = _areaBlockCollections;
		for (int i = 0; i < areaBlockCollections.Length; i++)
		{
			areaBlockCollections[i].Clear();
		}
	}

	public bool Contains(KeyValuePair<Location, MapBlockData> item)
	{
		if (_areaBlockCollections.CheckIndex(item.Key.AreaId))
		{
			return _areaBlockCollections[item.Key.AreaId].Contains(new KeyValuePair<short, MapBlockData>(item.Key.BlockId, item.Value));
		}
		return false;
	}

	[Obsolete("This method will not be implemented.")]
	public void CopyTo(KeyValuePair<Location, MapBlockData>[] array, int arrayIndex)
	{
		throw new SystemException("Unimplemented interface be invoked. method: CopyTo");
	}

	[Obsolete("This method will not be implemented.")]
	public bool Remove(KeyValuePair<Location, MapBlockData> item)
	{
		throw new SystemException("Unimplemented interface be invoked. method: Remove");
	}

	public void Add(Location key, MapBlockData value)
	{
		_areaBlockCollections[key.AreaId - _areaIdOffset].Add(key.BlockId, value);
	}

	public bool ContainsKey(Location key)
	{
		int index = key.AreaId - _areaIdOffset;
		if (!_areaBlockCollections.CheckIndex(index))
		{
			return false;
		}
		return _areaBlockCollections[index].ContainsKey(key.BlockId);
	}

	public bool Remove(Location key)
	{
		int index = key.AreaId - _areaIdOffset;
		if (!_areaBlockCollections.CheckIndex(index))
		{
			return false;
		}
		return _areaBlockCollections[index].Remove(key.BlockId);
	}

	public bool TryGetValue(Location key, out MapBlockData value)
	{
		int index = key.AreaId - _areaIdOffset;
		if (_areaBlockCollections.CheckIndex(index))
		{
			return _areaBlockCollections[index].TryGetValue(key.BlockId, out value);
		}
		value = null;
		return false;
	}
}

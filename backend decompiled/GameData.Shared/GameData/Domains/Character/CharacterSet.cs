using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

public struct CharacterSet : ISerializableGameData
{
	private static readonly HashSet<int> Empty = new HashSet<int>();

	private static readonly LocalObjectPool<HashSet<int>> LocalObjectPool = new LocalObjectPool<HashSet<int>>(51200, 51200);

	private HashSet<int> _collection;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		if (_collection == null)
		{
			return 4;
		}
		return 4 + 4 * _collection.Count;
	}

	public unsafe int Serialize(byte* pData)
	{
		if (_collection != null)
		{
			byte* pCurrData = pData;
			*(int*)pCurrData = _collection.Count;
			pCurrData += 4;
			foreach (int charId in _collection)
			{
				*(int*)pCurrData = charId;
				pCurrData += 4;
			}
			return (int)(pCurrData - pData);
		}
		*(int*)pData = 0;
		return 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		return Deserialize(pData, usePoolObject: true);
	}

	public unsafe int Deserialize(byte* pData, bool usePoolObject)
	{
		byte* pCurrData = pData;
		int charIdsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (charIdsCount > 0)
		{
			if (_collection == null || _collection.Count == 0)
			{
				_collection = (usePoolObject ? LocalObjectPool.Get() : new HashSet<int>());
			}
			else
			{
				_collection.Clear();
			}
			for (int i = 0; i < charIdsCount; i++)
			{
				int charId = *(int*)pCurrData;
				pCurrData += 4;
				_collection.Add(charId);
			}
		}
		else
		{
			_collection?.Clear();
		}
		return (int)(pCurrData - pData);
	}

	public HashSet<int> GetCollection()
	{
		return _collection ?? Empty;
	}

	public int GetCount()
	{
		return _collection?.Count ?? 0;
	}

	public bool Contains(int charId)
	{
		if (_collection != null)
		{
			return _collection.Contains(charId);
		}
		return false;
	}

	public bool Add(int charId)
	{
		bool modified = false;
		if (_collection == null || _collection.Count == 0)
		{
			_collection = LocalObjectPool.Get();
			modified = true;
		}
		_collection.Add(charId);
		return modified;
	}

	public bool AddRange(IEnumerable<int> charIds)
	{
		bool modified = false;
		if (_collection == null || _collection.Count == 0)
		{
			_collection = LocalObjectPool.Get();
			modified = true;
		}
		_collection.UnionWith(charIds);
		return modified;
	}

	public (bool, bool) Remove(int charId)
	{
		if (_collection != null && _collection.Remove(charId))
		{
			if (_collection.Count <= 0)
			{
				LocalObjectPool.Return(_collection);
				_collection = null;
				return (true, true);
			}
			return (false, true);
		}
		return (false, false);
	}

	public bool Clear()
	{
		if (_collection != null)
		{
			_collection.Clear();
			LocalObjectPool.Return(_collection);
			_collection = null;
			return true;
		}
		return false;
	}
}

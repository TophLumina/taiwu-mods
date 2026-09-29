using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

public struct CharacterList : ISerializableGameData
{
	private static readonly List<int> Empty = new List<int>();

	private static readonly LocalObjectPool<List<int>> LocalObjectPool = new LocalObjectPool<List<int>>(1024, 1024);

	private List<int> _collection;

	public int this[int index]
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		get
		{
			List<int> collection = GetCollection();
			if (index < 0 || index >= collection.Count)
			{
				throw new IndexOutOfRangeException($"index {index} is out of range [0,{collection.Count})");
			}
			return collection[index];
		}
	}

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
			int charsCount = (*(int*)pCurrData = _collection.Count);
			pCurrData += 4;
			for (int i = 0; i < charsCount; i++)
			{
				*(int*)pCurrData = _collection[i];
				pCurrData += 4;
			}
			return (int)(pCurrData - pData);
		}
		*(int*)pData = 0;
		return 4;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		int charIdsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (charIdsCount > 0)
		{
			if (_collection == null)
			{
				_collection = LocalObjectPool.Get();
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

	public List<int> GetCollection()
	{
		return _collection ?? Empty;
	}

	public int GetCount()
	{
		return _collection?.Count ?? 0;
	}

	public int GetRealCount()
	{
		if (_collection == null)
		{
			return 0;
		}
		int count = 0;
		for (int i = 0; i < _collection.Count; i++)
		{
			if (_collection[i] >= 0)
			{
				count++;
			}
		}
		return count;
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
		_collection.AddRange(charIds);
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

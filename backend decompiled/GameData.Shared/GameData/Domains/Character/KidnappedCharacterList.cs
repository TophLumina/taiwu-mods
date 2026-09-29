using System;
using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

public class KidnappedCharacterList : ISerializableGameData
{
	private static readonly List<KidnappedCharacter> Empty = new List<KidnappedCharacter>();

	private static readonly LocalObjectPool<List<KidnappedCharacter>> LocalObjectPool = new LocalObjectPool<List<KidnappedCharacter>>(128, 512);

	private List<KidnappedCharacter> _collection;

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
		return 4 + 20 * _collection.Count;
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
				pCurrData += _collection[i].Serialize(pCurrData);
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
				KidnappedCharacter kidnappedCharacter = new KidnappedCharacter();
				pCurrData += kidnappedCharacter.Deserialize(pCurrData);
				_collection.Add(kidnappedCharacter);
			}
		}
		else
		{
			_collection?.Clear();
		}
		return (int)(pCurrData - pData);
	}

	public List<KidnappedCharacter> GetCollection()
	{
		return _collection ?? Empty;
	}

	public int GetCount()
	{
		return _collection?.Count ?? 0;
	}

	public KidnappedCharacter Get(int index)
	{
		return _collection[index];
	}

	public int IndexOf(int charId)
	{
		if (_collection == null)
		{
			return -1;
		}
		for (int i = 0; i < _collection.Count; i++)
		{
			if (charId == _collection[i].CharId)
			{
				return i;
			}
		}
		return -1;
	}

	public bool Add(KidnappedCharacter kidnappedCharacter)
	{
		bool modified = false;
		if (_collection == null)
		{
			_collection = LocalObjectPool.Get();
			modified = true;
		}
		_collection.Add(kidnappedCharacter);
		return modified;
	}

	public bool Add(int charId, sbyte initialResistance, ItemKey ropeItemKey, int kidnapBeginDate)
	{
		KidnappedCharacter kidnappedCharacter = new KidnappedCharacter(charId, initialResistance, ropeItemKey, kidnapBeginDate);
		return Add(kidnappedCharacter);
	}

	public bool AddRange(IEnumerable<KidnappedCharacter> kidnappedCharacters)
	{
		bool modified = false;
		if (_collection == null)
		{
			_collection = LocalObjectPool.Get();
			modified = true;
		}
		_collection.AddRange(kidnappedCharacters);
		return modified;
	}

	public void RemoveAt(int index)
	{
		if (_collection == null)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		_collection.RemoveAt(index);
		if (_collection.Count <= 0)
		{
			LocalObjectPool.Return(_collection);
			_collection = null;
		}
	}

	public bool Remove(int charId)
	{
		if (_collection == null)
		{
			return false;
		}
		bool charFound = false;
		for (int i = 0; i < _collection.Count; i++)
		{
			if (_collection[i].CharId == charId)
			{
				_collection.RemoveAt(i);
				charFound = true;
				break;
			}
		}
		if (_collection.Count > 0)
		{
			return charFound;
		}
		LocalObjectPool.Return(_collection);
		_collection = null;
		return charFound;
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

using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

public class TrickCollection : ISerializableGameData
{
	private int _nextTrickIndex;

	[SerializableGameDataField]
	private SortedDictionary<int, sbyte> _tricks = new SortedDictionary<int, sbyte>();

	[SerializableGameDataField]
	private List<int> _avoidTricks = new List<int>();

	public IReadOnlyDictionary<int, sbyte> Tricks => _tricks;

	public bool ContainsTrick(sbyte type)
	{
		return _tricks.ContainsKey(type);
	}

	public void ReplaceTrick(int index, sbyte type)
	{
		_tricks[index] = type;
	}

	public void AppendTrick(sbyte type, bool addByAvoid)
	{
		_tricks.Add(_nextTrickIndex, type);
		if (addByAvoid)
		{
			_avoidTricks.Add(_nextTrickIndex);
		}
		_nextTrickIndex++;
	}

	public void RemoveTrick(int trickIndex)
	{
		_tricks.Remove(trickIndex);
		_avoidTricks.Remove(trickIndex);
	}

	public void ClearTricks()
	{
		_tricks.Clear();
		_avoidTricks.Clear();
	}

	public bool IsAvoidTrick(int index)
	{
		return _avoidTricks.Contains(index);
	}

	public void RearrangeTrick(sbyte type)
	{
		List<int> indexes = ObjectPool<List<int>>.Instance.Get();
		List<sbyte> moveTricks = ObjectPool<List<sbyte>>.Instance.Get();
		List<bool> typeIsAvoid = ObjectPool<List<bool>>.Instance.Get();
		List<bool> moveIsAvoid = ObjectPool<List<bool>>.Instance.Get();
		foreach (var (index, trickType) in _tricks)
		{
			indexes.Add(index);
			if (trickType == type)
			{
				typeIsAvoid.Add(_avoidTricks.Contains(index));
				continue;
			}
			moveTricks.Add(trickType);
			moveIsAvoid.Add(_avoidTricks.Contains(index));
		}
		_avoidTricks.Clear();
		for (int i = 0; i < indexes.Count; i++)
		{
			int index2 = indexes[indexes.Count - 1 - i];
			sbyte trick = ((i < moveTricks.Count) ? moveTricks[moveTricks.Count - 1 - i] : type);
			_tricks[index2] = trick;
			if ((i < moveIsAvoid.Count) ? moveIsAvoid[moveIsAvoid.Count - 1 - i] : typeIsAvoid[typeIsAvoid.Count - 1 - (i - moveIsAvoid.Count)])
			{
				_avoidTricks.Add(index2);
			}
		}
		ObjectPool<List<int>>.Instance.Return(indexes);
		ObjectPool<List<sbyte>>.Instance.Return(moveTricks);
		ObjectPool<List<bool>>.Instance.Return(typeIsAvoid);
		ObjectPool<List<bool>>.Instance.Return(moveIsAvoid);
	}

	public TrickCollection()
	{
	}

	public TrickCollection(TrickCollection other)
	{
		_tricks = ((other._tricks == null) ? null : new SortedDictionary<int, sbyte>(other._tricks));
		_avoidTricks = ((other._avoidTricks == null) ? null : new List<int>(other._avoidTricks));
	}

	public void Assign(TrickCollection other)
	{
		_tricks = ((other._tricks == null) ? null : new SortedDictionary<int, sbyte>(other._tricks));
		_avoidTricks = ((other._avoidTricks == null) ? null : new List<int>(other._avoidTricks));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(_tricks);
		totalSize = ((_avoidTricks == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _avoidTricks.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Serialize<int, sbyte, SortedDictionary<int, sbyte>>(pCurrData, ref _tricks);
		if (_avoidTricks != null)
		{
			int elementsCount = _avoidTricks.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _avoidTricks[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
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
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize<int, sbyte, SortedDictionary<int, sbyte>>(pCurrData, ref _tricks);
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_avoidTricks == null)
			{
				_avoidTricks = new List<int>(elementsCount);
			}
			else
			{
				_avoidTricks.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				_avoidTricks.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			_avoidTricks?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Combat;

/// <summary>
/// 蓄式集合
/// </summary>
public class TrickCollection : ISerializableGameData
{
	/// <summary>
	/// 下个蓄式索引
	/// </summary>
	private int _nextTrickIndex;

	/// <summary>
	/// 当前所有蓄式索引
	/// </summary>
	[SerializableGameDataField]
	private SortedDictionary<int, sbyte> _tricks = new SortedDictionary<int, sbyte>();

	/// <summary>
	/// 化解获得的蓄式索引
	/// </summary>
	[SerializableGameDataField]
	private List<int> _avoidTricks = new List<int>();

	/// <inheritdoc cref="F:GameData.Domains.Combat.TrickCollection._tricks" />
	public IReadOnlyDictionary<int, sbyte> Tricks => _tricks;

	/// <summary>
	/// 包含蓄式
	/// </summary>
	public bool ContainsTrick(sbyte type)
	{
		return _tricks.ContainsKey(type);
	}

	/// <summary>
	/// 替换蓄式
	/// </summary>
	public void ReplaceTrick(int index, sbyte type)
	{
		_tricks[index] = type;
	}

	/// <summary>
	/// 添加蓄式
	/// </summary>
	public void AppendTrick(sbyte type, bool addByAvoid)
	{
		_tricks.Add(_nextTrickIndex, type);
		if (addByAvoid)
		{
			_avoidTricks.Add(_nextTrickIndex);
		}
		_nextTrickIndex++;
	}

	/// <summary>
	/// 移除蓄式
	/// </summary>
	public void RemoveTrick(int trickIndex)
	{
		_tricks.Remove(trickIndex);
		_avoidTricks.Remove(trickIndex);
	}

	/// <summary>
	/// 清空蓄式
	/// </summary>
	public void ClearTricks()
	{
		_tricks.Clear();
		_avoidTricks.Clear();
	}

	/// <summary>
	/// 指定位置的蓄式是否为化解得式
	/// </summary>
	public bool IsAvoidTrick(int index)
	{
		return _avoidTricks.Contains(index);
	}

	/// <summary>
	/// 将指定类型的蓄式排至最前
	/// </summary>
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

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TrickCollection()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TrickCollection(TrickCollection other)
	{
		_tricks = ((other._tricks == null) ? null : new SortedDictionary<int, sbyte>(other._tricks));
		_avoidTricks = ((other._avoidTricks == null) ? null : new List<int>(other._avoidTricks));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TrickCollection other)
	{
		_tricks = ((other._tricks == null) ? null : new SortedDictionary<int, sbyte>(other._tricks));
		_avoidTricks = ((other._avoidTricks == null) ? null : new List<int>(other._avoidTricks));
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

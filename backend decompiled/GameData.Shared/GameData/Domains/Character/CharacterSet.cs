using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 通用的角色集合, 本身是值类型.
/// 内部实现了对象池, 从而提升频繁创建和销毁对象的场景, 以及存在大量空集合的场景下的性能.
/// 不再使用某个实例时, 需要手动调用 Clear 方法以归还内部对象到池中.
/// 由于是单值数据, 所以总长不能超过 64KB, 因而可容纳的角色的数量最大约为 16K.
/// </summary>
public struct CharacterSet : ISerializableGameData
{
	private static readonly HashSet<int> Empty = new HashSet<int>();

	/// <summary>
	/// 本地对象池, 归还时必须清空其中的数据
	/// </summary>
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

	/// <summary>
	/// 获取底层角色集合.
	/// 返回值不允许修改.
	/// </summary>
	/// <returns></returns>
	public HashSet<int> GetCollection()
	{
		return _collection ?? Empty;
	}

	/// <summary>
	/// 获取集合中的角色数量
	/// </summary>
	/// <returns></returns>
	public int GetCount()
	{
		return _collection?.Count ?? 0;
	}

	/// <summary>
	/// 查询是否包含指定角色
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
	public bool Contains(int charId)
	{
		if (_collection != null)
		{
			return _collection.Contains(charId);
		}
		return false;
	}

	/// <summary>
	/// 添加指定角色
	/// </summary>
	/// <param name="charId"></param>
	/// <returns>是否创建或删除了集合</returns>
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

	/// <summary>
	/// 将指定集合中的角色全部添加到当前集合
	/// </summary>
	/// <param name="charIds"></param>
	/// <returns>是否创建或删除了集合</returns>
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

	/// <summary>
	/// 移除指定角色
	/// </summary>
	/// <param name="charId"></param>
	/// <returns>(是否创建或删除了集合, 是否找到并移除了指定元素)</returns>
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

	/// <summary>
	/// 清空角色集合.
	/// 不再使用当前实例时, 需要手动调用此方法, 以归还内部对象到池中.
	/// </summary>
	/// <returns>是否创建或删除了集合</returns>
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

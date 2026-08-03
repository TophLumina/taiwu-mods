using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 通用的角色集合, 本身是值类型.
/// 内部实现了对象池, 从而提升频繁创建和销毁对象的场景, 以及存在大量空集合的场景下的性能.
/// 不再使用某个实例时, 需要手动调用 Clear 方法以归还内部对象到池中.
/// 由于是单值数据, 所以总长不能超过 64KB, 因而可容纳的角色的数量最大约为 16K.
/// </summary>
public struct CharacterList : ISerializableGameData
{
	private static readonly List<int> Empty = new List<int>();

	/// <summary>
	/// 本地对象池, 归还时必须清空其中的数据
	/// </summary>
	private static readonly LocalObjectPool<List<int>> LocalObjectPool = new LocalObjectPool<List<int>>(1024, 1024);

	private List<int> _collection;

	/// <summary>
	/// 直接通过 index 安全访问数据的接口.
	/// 主要用于对性能要求不是特别严格的情况 (非过月逻辑中频繁调用或可能每帧多次调用的逻辑皆可)
	/// </summary>
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

	/// <summary>
	/// 获取底层角色集合.
	/// 返回值不允许修改.
	/// </summary>
	/// <returns></returns>
	public List<int> GetCollection()
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
	/// 获取集合中有效角色数量
	/// </summary>
	/// <returns></returns>
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
	/// 将指定集合中的角色全部添加到当前集合的尾部
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
		_collection.AddRange(charIds);
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

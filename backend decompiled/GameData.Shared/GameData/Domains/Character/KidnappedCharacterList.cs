using System;
using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 被劫持的角色集合
/// </summary>
public class KidnappedCharacterList : ISerializableGameData
{
	private static readonly List<KidnappedCharacter> Empty = new List<KidnappedCharacter>();

	/// <summary>
	/// 本地对象池, 归还时必须清空其中的数据
	/// </summary>
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

	/// <summary>
	/// 获取底层被劫持角色集合.
	/// 返回值不允许修改.
	/// </summary>
	/// <returns></returns>
	public List<KidnappedCharacter> GetCollection()
	{
		return _collection ?? Empty;
	}

	/// <summary>
	/// 获取集合中的被劫持角色数量
	/// </summary>
	/// <returns></returns>
	public int GetCount()
	{
		return _collection?.Count ?? 0;
	}

	/// <summary>
	/// 获取指定栏位的被劫持角色，需调用者判断是否为空（等于或超出劫持数量）
	/// </summary>
	public KidnappedCharacter Get(int index)
	{
		return _collection[index];
	}

	/// <summary>
	/// 获取指定被劫持角色在集合中的位置，找不到的情况返回-1
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 添加指定被劫持角色
	/// </summary>
	/// <param name="kidnappedCharacter"></param>
	/// <returns>是否修改了此对象</returns>
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

	/// <summary>
	/// 创建并添加指定被劫持角色
	/// </summary>
	/// <param name="charId">角色Id</param>
	/// <param name="initialResistance">初始抵抗值</param>
	/// <param name="ropeItemKey">绳索</param>
	/// <param name="kidnapBeginDate">劫持日期</param>
	/// <returns></returns>
	public bool Add(int charId, sbyte initialResistance, ItemKey ropeItemKey, int kidnapBeginDate)
	{
		KidnappedCharacter kidnappedCharacter = new KidnappedCharacter(charId, initialResistance, ropeItemKey, kidnapBeginDate);
		return Add(kidnappedCharacter);
	}

	/// <summary>
	/// 将指定集合中的被劫持角色全部添加到当前集合的尾部
	/// </summary>
	/// <param name="kidnappedCharacters"></param>
	/// <returns>是否修改了此对象</returns>
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

	/// <summary>
	/// 移除指定位置的被劫持角色
	/// </summary>
	/// <param name="index">待移除角色所在的栏位序号</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
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

	/// <summary>
	/// 移除指定被劫持角色
	/// </summary>
	/// <param name="charId">待移除角色的Id</param>
	/// <exception cref="T:System.ArgumentOutOfRangeException"></exception>
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

	/// <summary>
	/// 清空被劫持角色集合.
	/// 不再使用当前实例时, 需要手动调用此方法, 以归还内部对象到池中.
	/// </summary>
	/// <returns>是否修改了此对象</returns>
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

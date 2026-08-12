using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 高僧相关数据
/// </summary>
[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteBuddhistMonkSkillsData : IProfessionSkillsData, ISerializableGameData
{
	/// <summary>
	/// 已超度人数
	/// </summary>
	[SerializableGameDataField]
	public int _currSavedSoulsCount;

	/// <summary>
	/// 母亲 ID, 轮回者 ID
	/// </summary>
	[SerializableGameDataField]
	public readonly Dictionary<int, int> _directedSamsaraDict;

	/// <inheritdoc />
	public void Initialize()
	{
		_currSavedSoulsCount = 0;
		_directedSamsaraDict.Clear();
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}

	/// <summary>
	/// 离线添加指定的轮回关系, 同时会清空已超度人数
	/// </summary>
	/// <param name="motherId">投胎到的母亲ID</param>
	/// <param name="reincarnatedCharId">轮回的角色</param>
	public void OfflineAddDirectedSamsara(int motherId, int reincarnatedCharId)
	{
		_directedSamsaraDict.Add(motherId, reincarnatedCharId);
		_currSavedSoulsCount = 0;
	}

	/// <summary>
	/// 获取指定母亲怀胎的轮回角色
	/// </summary>
	/// <param name="motherId"></param>
	/// <returns></returns>
	public int GetDirectedSamsara(int motherId)
	{
		if (!_directedSamsaraDict.TryGetValue(motherId, out var reincarnatedCharId))
		{
			return -1;
		}
		return reincarnatedCharId;
	}

	/// <summary>
	/// 获取指定轮回角色对应的母亲
	/// </summary>
	public int GetDirectedSamsaraMother(int reincarnatedCharId)
	{
		foreach (KeyValuePair<int, int> pair in _directedSamsaraDict)
		{
			if (pair.Value == reincarnatedCharId)
			{
				return pair.Key;
			}
		}
		return -1;
	}

	/// <summary>
	/// 角色是否为被指定的轮回角色
	/// </summary>
	/// <param name="charId"></param>
	/// <returns></returns>
	public bool IsDirectedSamsaraCharacter(int charId)
	{
		return _directedSamsaraDict.ContainsValue(charId);
	}

	/// <summary>
	/// 移除指定母亲怀胎的轮回角色
	/// </summary>
	/// <param name="motherId"></param>
	public bool OfflineRemoveDirectedSamsara(int motherId)
	{
		return _directedSamsaraDict.Remove(motherId);
	}

	/// <summary>
	/// 增加当前已超度人数
	/// </summary>
	public void OfflineAddSavedSoulsCount()
	{
		_currSavedSoulsCount++;
	}

	/// <summary>
	/// 清除当前已超度人数
	/// </summary>
	public void OfflineClearSavedSoulsCount()
	{
		_currSavedSoulsCount = 0;
	}

	/// <summary>
	/// 清除定向轮回
	/// </summary>
	public void OfflineClearDirectedSamsara()
	{
		_directedSamsaraDict.Clear();
	}

	/// <summary>
	/// 获取当前已超度人数
	/// </summary>
	/// <returns></returns>
	public int GetSavedSoulsCount()
	{
		return _currSavedSoulsCount;
	}

	public ObsoleteBuddhistMonkSkillsData()
	{
		_directedSamsaraDict = new Dictionary<int, int>();
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6 + _directedSamsaraDict.Count * 8;
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
		*(int*)pCurrData = _currSavedSoulsCount;
		pCurrData += 4;
		*(ushort*)pCurrData = (ushort)_directedSamsaraDict.Count;
		pCurrData += 2;
		foreach (KeyValuePair<int, int> pair in _directedSamsaraDict)
		{
			*(int*)pCurrData = pair.Key;
			pCurrData += 4;
			*(int*)pCurrData = pair.Value;
			pCurrData += 4;
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
		_currSavedSoulsCount = *(int*)pCurrData;
		pCurrData += 4;
		ushort elementCount = *(ushort*)pCurrData;
		pCurrData += 2;
		for (int i = 0; i < elementCount; i++)
		{
			int motherId = *(int*)pCurrData;
			pCurrData += 4;
			int reincarnatedCharId = *(int*)pCurrData;
			pCurrData += 4;
			_directedSamsaraDict.Add(motherId, reincarnatedCharId);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

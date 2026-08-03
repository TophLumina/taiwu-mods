using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

/// <summary>
/// 高僧相关数据
/// </summary>
[SerializableGameData(IsExtensible = true)]
public class BuddhistMonkSkillsData : IProfessionSkillsData, ISerializableGameData
{
	private static class FieldIds
	{
		public const ushort CurrSavedSoulsCount = 0;

		public const ushort DirectedSamsaraDict = 1;

		public const ushort SamsaraFeatureDict = 2;

		public const ushort SamsaraReplaceAvatar = 3;

		public const ushort Count = 4;

		public static readonly string[] FieldId2FieldName = new string[4] { "CurrSavedSoulsCount", "DirectedSamsaraDict", "SamsaraFeatureDict", "SamsaraReplaceAvatar" };
	}

	/// <summary>
	/// 已超度人数
	/// </summary>
	[SerializableGameDataField]
	private int _currSavedSoulsCount;

	/// <summary>
	/// 母亲 ID, 轮回者 ID
	/// </summary>
	[SerializableGameDataField]
	private Dictionary<int, int> _directedSamsaraDict;

	/// <summary>
	/// 轮回者，获得的特性id
	/// </summary>
	[SerializableGameDataField]
	private Dictionary<int, short> _samsaraFeatureDict;

	/// <summary>
	/// 轮回者，是否继承样貌
	/// </summary>
	[SerializableGameDataField]
	private Dictionary<int, bool> _samsaraReplaceAvatar;

	/// <inheritdoc />
	public void Initialize()
	{
		_currSavedSoulsCount = 0;
		_directedSamsaraDict?.Clear();
		_samsaraFeatureDict?.Clear();
		_samsaraReplaceAvatar?.Clear();
	}

	/// <inheritdoc />
	public void InheritFrom(IProfessionSkillsData sourceData)
	{
		if (!(sourceData is ObsoleteBuddhistMonkSkillsData skillsData))
		{
			return;
		}
		_currSavedSoulsCount = skillsData._currSavedSoulsCount;
		foreach (KeyValuePair<int, int> pair in skillsData._directedSamsaraDict)
		{
			_directedSamsaraDict.TryAdd(pair.Key, pair.Value);
		}
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

	/// <summary>
	/// 记录轮回者获得的特性
	/// </summary>
	/// <param name="reincarnatedCharId"></param>
	/// <param name="featureId"></param>
	public void OfflineAddSamsaraFeature(int reincarnatedCharId, short featureId)
	{
		_samsaraFeatureDict[reincarnatedCharId] = featureId;
	}

	/// <summary>
	/// 获取轮回者获得的特性
	/// </summary>
	/// <param name="reincarnatedCharId"></param>
	/// <param name="featureId"></param>
	/// <returns></returns>
	public bool TryGetSamaraFeature(int reincarnatedCharId, out short featureId)
	{
		return _samsaraFeatureDict.TryGetValue(reincarnatedCharId, out featureId);
	}

	/// <summary>
	/// 移除轮回者获得的特性
	/// </summary>
	/// <param name="reincarnatedCharId"></param>
	/// <returns></returns>
	public bool OfflineRemoveSamsaraFeature(int reincarnatedCharId)
	{
		return _samsaraFeatureDict.Remove(reincarnatedCharId);
	}

	/// <summary>
	/// 记录轮回者是否继承样貌
	/// </summary>
	/// <param name="reincarnatedCharId"></param>
	/// <param name="res"></param>
	public void OfflineAddSamsaraReplaceAvatar(int reincarnatedCharId, bool res)
	{
		_samsaraReplaceAvatar[reincarnatedCharId] = res;
	}

	/// <summary>
	/// 获取轮回者是否继承样貌
	/// </summary>
	/// <param name="reincarnatedCharId"></param>
	/// <param name="res"></param>
	/// <returns></returns>
	public bool TryGetSamaraReplaceAvatar(int reincarnatedCharId, out bool res)
	{
		return _samsaraReplaceAvatar.TryGetValue(reincarnatedCharId, out res);
	}

	/// <summary>
	/// 移除轮回者是否继承样貌
	/// </summary>
	/// <param name="reincarnatedCharId"></param>
	/// <returns></returns>
	public bool OfflineRemoveSamsaraReplaceAvatar(int reincarnatedCharId)
	{
		return _samsaraReplaceAvatar.Remove(reincarnatedCharId);
	}

	public BuddhistMonkSkillsData()
	{
		_directedSamsaraDict = new Dictionary<int, int>();
		_samsaraFeatureDict = new Dictionary<int, short>();
		_samsaraReplaceAvatar = new Dictionary<int, bool>();
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
	public int GetSerializedSize()
	{
		int totalSize = 6;
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(_directedSamsaraDict);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(_samsaraFeatureDict);
		totalSize += SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(_samsaraReplaceAvatar);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		*(short*)pData = 4;
		byte* num = pData + 2;
		*(int*)num = _currSavedSoulsCount;
		byte* num2 = num + 4;
		byte* num3 = num2 + SerializationHelper.DictionaryOfBasicTypePair.Serialize(num2, ref _directedSamsaraDict);
		byte* num4 = num3 + SerializationHelper.DictionaryOfBasicTypePair.Serialize(num3, ref _samsaraFeatureDict);
		int totalSize = (int)(num4 + SerializationHelper.DictionaryOfBasicTypePair.Serialize(num4, ref _samsaraReplaceAvatar) - pData);
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
		ushort num = *(ushort*)pCurrData;
		pCurrData += 2;
		if (num > 0)
		{
			_currSavedSoulsCount = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (num > 1)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref _directedSamsaraDict);
		}
		if (num > 2)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref _samsaraFeatureDict);
		}
		if (num > 3)
		{
			pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref _samsaraReplaceAvatar);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

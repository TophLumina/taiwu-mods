using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

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

	[SerializableGameDataField]
	private int _currSavedSoulsCount;

	[SerializableGameDataField]
	private Dictionary<int, int> _directedSamsaraDict;

	[SerializableGameDataField]
	private Dictionary<int, short> _samsaraFeatureDict;

	[SerializableGameDataField]
	private Dictionary<int, bool> _samsaraReplaceAvatar;

	public void Initialize()
	{
		_currSavedSoulsCount = 0;
		_directedSamsaraDict?.Clear();
		_samsaraFeatureDict?.Clear();
		_samsaraReplaceAvatar?.Clear();
	}

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

	public void OfflineAddDirectedSamsara(int motherId, int reincarnatedCharId)
	{
		_directedSamsaraDict.Add(motherId, reincarnatedCharId);
		_currSavedSoulsCount = 0;
	}

	public int GetDirectedSamsara(int motherId)
	{
		if (!_directedSamsaraDict.TryGetValue(motherId, out var reincarnatedCharId))
		{
			return -1;
		}
		return reincarnatedCharId;
	}

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

	public bool IsDirectedSamsaraCharacter(int charId)
	{
		return _directedSamsaraDict.ContainsValue(charId);
	}

	public bool OfflineRemoveDirectedSamsara(int motherId)
	{
		return _directedSamsaraDict.Remove(motherId);
	}

	public void OfflineAddSavedSoulsCount()
	{
		_currSavedSoulsCount++;
	}

	public void OfflineClearSavedSoulsCount()
	{
		_currSavedSoulsCount = 0;
	}

	public void OfflineClearDirectedSamsara()
	{
		_directedSamsaraDict.Clear();
	}

	public int GetSavedSoulsCount()
	{
		return _currSavedSoulsCount;
	}

	public void OfflineAddSamsaraFeature(int reincarnatedCharId, short featureId)
	{
		_samsaraFeatureDict[reincarnatedCharId] = featureId;
	}

	public bool TryGetSamaraFeature(int reincarnatedCharId, out short featureId)
	{
		return _samsaraFeatureDict.TryGetValue(reincarnatedCharId, out featureId);
	}

	public bool OfflineRemoveSamsaraFeature(int reincarnatedCharId)
	{
		return _samsaraFeatureDict.Remove(reincarnatedCharId);
	}

	public void OfflineAddSamsaraReplaceAvatar(int reincarnatedCharId, bool res)
	{
		_samsaraReplaceAvatar[reincarnatedCharId] = res;
	}

	public bool TryGetSamaraReplaceAvatar(int reincarnatedCharId, out bool res)
	{
		return _samsaraReplaceAvatar.TryGetValue(reincarnatedCharId, out res);
	}

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

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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

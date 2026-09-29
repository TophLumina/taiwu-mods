using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteBuddhistMonkSkillsData : IProfessionSkillsData, ISerializableGameData
{
	[SerializableGameDataField]
	public int _currSavedSoulsCount;

	[SerializableGameDataField]
	public readonly Dictionary<int, int> _directedSamsaraDict;

	public void Initialize()
	{
		_currSavedSoulsCount = 0;
		_directedSamsaraDict.Clear();
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
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

	public ObsoleteBuddhistMonkSkillsData()
	{
		_directedSamsaraDict = new Dictionary<int, int>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 6 + _directedSamsaraDict.Count * 8;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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

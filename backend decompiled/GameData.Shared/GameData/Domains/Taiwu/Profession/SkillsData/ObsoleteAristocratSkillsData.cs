using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Profession.SkillsData;

[Obsolete]
[SerializableGameData(NotForDisplayModule = true)]
public class ObsoleteAristocratSkillsData : IProfessionSkillsData, ISerializableGameData
{
	public readonly Dictionary<int, short> _influencePowerBonus;

	public void Initialize()
	{
		_influencePowerBonus.Clear();
	}

	public void InheritFrom(IProfessionSkillsData sourceData)
	{
	}

	public short OfflineSetInfluencePowerBonus(int targetCharId, short bonus)
	{
		if (!_influencePowerBonus.TryGetValue(targetCharId, out var previousBonus))
		{
			previousBonus = 0;
		}
		_influencePowerBonus[targetCharId] = bonus;
		return previousBonus;
	}

	public bool OfflineRemoveInfluencePowerBonus(int targetCharId)
	{
		return _influencePowerBonus.Remove(targetCharId);
	}

	public short GetPreviousInfluencePowerBonus(int targetCharId)
	{
		if (!_influencePowerBonus.TryGetValue(targetCharId, out var previousBonus))
		{
			return 0;
		}
		return previousBonus;
	}

	public ObsoleteAristocratSkillsData()
	{
		_influencePowerBonus = new Dictionary<int, short>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2 + _influencePowerBonus.Count * 6;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(ushort*)pCurrData = (ushort)_influencePowerBonus.Count;
		pCurrData += 2;
		foreach (KeyValuePair<int, short> pair in _influencePowerBonus)
		{
			*(int*)pCurrData = pair.Key;
			pCurrData += 4;
			*(short*)pCurrData = pair.Value;
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
		ushort elementCount = *(ushort*)pCurrData;
		pCurrData += 2;
		for (int i = 0; i < elementCount; i++)
		{
			int charId = *(int*)pCurrData;
			pCurrData += 4;
			short delta = *(short*)pCurrData;
			pCurrData += 2;
			_influencePowerBonus.Add(charId, delta);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

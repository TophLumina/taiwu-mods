using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Adventure;

public class AreaAdventureData : ISerializableGameData
{
	/// <summary>
	/// 该区域所有的奇遇地点的集合, Key为地点（blockId），Value为奇遇数据（AdventureSiteData） 
	/// </summary>
	[SerializableGameDataField]
	public readonly Dictionary<short, AdventureSiteData> AdventureSites;

	public AreaAdventureData()
	{
		AdventureSites = new Dictionary<short, AdventureSiteData>();
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 2 + AdventureSites.Count * 14;
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = (short)AdventureSites.Count;
		pCurrData += 2;
		foreach (KeyValuePair<short, AdventureSiteData> pair in AdventureSites)
		{
			*(short*)pCurrData = pair.Key;
			pCurrData += 2;
			pCurrData += pair.Value.Serialize(pCurrData);
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
		AdventureSites.Clear();
		byte* pCurrData = pData;
		short count = *(short*)pCurrData;
		pCurrData += 2;
		for (int i = 0; i < count; i++)
		{
			short blockId = *(short*)pCurrData;
			pCurrData += 2;
			AdventureSiteData siteData = new AdventureSiteData();
			pCurrData += siteData.Deserialize(pCurrData);
			AdventureSites.Add(blockId, siteData);
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

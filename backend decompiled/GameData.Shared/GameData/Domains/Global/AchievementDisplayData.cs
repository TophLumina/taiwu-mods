using System.Collections.Generic;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Global;

[AutoGenerateSerializableGameData(NoCopyConstructors = true, NotForArchive = true)]
public class AchievementDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public long LastTimeOpen;

	[SerializableGameDataField]
	public Dictionary<short, long> Achievements;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 8;
		totalSize += 4;
		if (Achievements != null)
		{
			foreach (KeyValuePair<short, long> achievement in Achievements)
			{
				_ = achievement;
				totalSize += 2;
				totalSize += 8;
			}
		}
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(long*)pCurrData = LastTimeOpen;
		pCurrData += 8;
		if (Achievements != null)
		{
			*(int*)pCurrData = Achievements.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, long> pair in Achievements)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				*(long*)pCurrData = pair.Value;
				pCurrData += 8;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
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
		LastTimeOpen = *(long*)pCurrData;
		pCurrData += 8;
		int AchievementsElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (AchievementsElementsCount > 0)
		{
			if (Achievements == null)
			{
				Achievements = new Dictionary<short, long>();
			}
			else
			{
				Achievements.Clear();
			}
			for (int i = 0; i < AchievementsElementsCount; i++)
			{
				short key = *(short*)pCurrData;
				pCurrData += 2;
				long value = *(long*)pCurrData;
				pCurrData += 8;
				Achievements.Add(key, value);
			}
		}
		else
		{
			Achievements?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

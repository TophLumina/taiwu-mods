using System;
using System.Collections.Generic;
using GameData.Serializer;

namespace GameData.Domains.Information;

[SerializableGameData(NotForDisplayModule = true)]
public class SecretInformationDisseminationData : ISerializableGameData
{
	[SerializableGameDataField]
	public readonly IDictionary<int, int> DisseminationCounts;

	public SecretInformationDisseminationData()
	{
		DisseminationCounts = new Dictionary<int, int>();
	}

	public SecretInformationDisseminationData(SecretInformationDisseminationData other)
		: this()
	{
		Assign(other);
	}

	public void Assign(SecretInformationDisseminationData other)
	{
		DisseminationCounts.Clear();
		foreach (KeyValuePair<int, int> pair in other.DisseminationCounts)
		{
			DisseminationCounts.Add(pair.Key, pair.Value);
		}
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((DisseminationCounts == null) ? (totalSize + 4) : (totalSize + (4 + 8 * DisseminationCounts.Count)));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (DisseminationCounts != null)
		{
			int elementsCount = DisseminationCounts.Count;
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			foreach (KeyValuePair<int, int> pair in DisseminationCounts)
			{
				*(int*)pCurrData = pair.Key;
				pCurrData += 4;
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		uint elementsCount = *(uint*)pCurrData;
		pCurrData += 4;
		if (elementsCount != 0)
		{
			if (DisseminationCounts == null)
			{
				throw new NotImplementedException();
			}
			DisseminationCounts.Clear();
			for (int i = 0; i < elementsCount; i++)
			{
				int id = *(int*)pCurrData;
				pCurrData += 4;
				int time = *(int*)pCurrData;
				pCurrData += 4;
				DisseminationCounts.Add(id, time);
			}
		}
		else
		{
			DisseminationCounts?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

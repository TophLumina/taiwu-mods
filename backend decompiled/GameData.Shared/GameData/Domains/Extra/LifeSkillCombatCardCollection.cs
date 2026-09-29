using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Extra;

public struct LifeSkillCombatCardCollection : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<sbyte, int> CardDict;

	public int CountSum => CardDict?.Sum((KeyValuePair<sbyte, int> d) => d.Value) ?? 0;

	public int GetLevelCountSum(int level)
	{
		return CardDict?.Sum((KeyValuePair<sbyte, int> d) => (LifeSkillCombatEffect.Instance[d.Key].Level == level) ? d.Value : 0) ?? 0;
	}

	public LifeSkillCombatCardCollection Clone()
	{
		return new LifeSkillCombatCardCollection
		{
			CardDict = new Dictionary<sbyte, int>(CardDict)
		};
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize = ((CardDict == null) ? (totalSize + 4) : (totalSize + (4 + 5 * CardDict.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CardDict != null)
		{
			int elementsCount = CardDict.Count;
			*(int*)pCurrData = elementsCount;
			pCurrData += 4;
			foreach (KeyValuePair<sbyte, int> pair in CardDict)
			{
				*pCurrData = (byte)pair.Key;
				pCurrData++;
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
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		uint elementsCount = *(uint*)pCurrData;
		pCurrData += 4;
		if (elementsCount != 0)
		{
			if (CardDict == null)
			{
				CardDict = new Dictionary<sbyte, int>();
			}
			else
			{
				CardDict.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				sbyte id = (sbyte)(*pCurrData);
				pCurrData++;
				int time = *(int*)pCurrData;
				pCurrData += 4;
				CardDict.Add(id, time);
			}
		}
		else
		{
			CardDict?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

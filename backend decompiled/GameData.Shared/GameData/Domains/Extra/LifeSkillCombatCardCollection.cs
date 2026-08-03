using System.Collections.Generic;
using System.Linq;
using Config;
using GameData.Serializer;

namespace GameData.Domains.Extra;

/// <summary>
/// 较艺的卡牌数据
/// </summary>
public struct LifeSkillCombatCardCollection : ISerializableGameData
{
	/// <summary>
	/// 卡牌ID-&gt;卡牌数量
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<sbyte, int> CardDict;

	/// <summary>
	/// 卡牌的总数量
	/// </summary>
	public int CountSum => CardDict?.Sum((KeyValuePair<sbyte, int> d) => d.Value) ?? 0;

	/// <summary>
	/// 获取某一个等级的卡牌总数
	/// </summary>
	/// <param name="level"></param>
	/// <returns></returns>
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

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc />
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

	/// <inheritdoc />
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

	/// <inheritdoc />
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

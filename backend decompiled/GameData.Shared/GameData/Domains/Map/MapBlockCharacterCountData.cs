using System.Collections.Generic;
using GameData.Domains.Extra;
using GameData.Serializer;
using SerializableGameDataSourceGenerator;

namespace GameData.Domains.Map;

/// <summary>
/// 地块信息的人物数量数据
/// </summary>
[AutoGenerateSerializableGameData(NoCopyConstructors = true)]
public class MapBlockCharacterCountData : ISerializableGameData
{
	/// <summary>
	/// 人物数量的字典,key是<see cref="T:Config.MapElementDisplayRuleItem.DefKey" />,value是人数
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<short, int> CharacterCountDict;

	[SerializableGameDataField]
	public TreasureExpectResult TreasureExpectResult;

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += 4;
		if (CharacterCountDict != null)
		{
			foreach (KeyValuePair<short, int> item in CharacterCountDict)
			{
				_ = item;
				totalSize += 2;
				totalSize += 4;
			}
		}
		totalSize += TreasureExpectResult.GetSerializedSize();
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (CharacterCountDict != null)
		{
			*(int*)pCurrData = CharacterCountDict.Count;
			pCurrData += 4;
			foreach (KeyValuePair<short, int> pair in CharacterCountDict)
			{
				*(short*)pCurrData = pair.Key;
				pCurrData += 2;
				*(int*)pCurrData = pair.Value;
				pCurrData += 4;
			}
		}
		else
		{
			*(int*)pCurrData = 0;
			pCurrData += 4;
		}
		pCurrData += TreasureExpectResult.Serialize(pCurrData);
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
		int CharacterCountDictElementsCount = *(int*)pCurrData;
		pCurrData += 4;
		if (CharacterCountDictElementsCount > 0)
		{
			if (CharacterCountDict == null)
			{
				CharacterCountDict = new Dictionary<short, int>();
			}
			else
			{
				CharacterCountDict.Clear();
			}
			for (int i = 0; i < CharacterCountDictElementsCount; i++)
			{
				short key = *(short*)pCurrData;
				pCurrData += 2;
				int value = *(int*)pCurrData;
				pCurrData += 4;
				CharacterCountDict.Add(key, value);
			}
		}
		else
		{
			CharacterCountDict?.Clear();
		}
		pCurrData += TreasureExpectResult.Deserialize(pCurrData);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

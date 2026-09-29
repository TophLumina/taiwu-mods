using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display;

[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class CricketCombatTaiwuDisplayData : ISerializableGameData
{
	[SerializableGameDataField]
	public Dictionary<int, ItemDisplayData> TaiwuAllowCrickets = new Dictionary<int, ItemDisplayData>();

	[SerializableGameDataField]
	public Dictionary<int, CricketData> AllCricketData = new Dictionary<int, CricketData>();

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(TaiwuAllowCrickets);
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(AllCricketData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* num = pData + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pData, ref TaiwuAllowCrickets);
		int totalSize = (int)(num + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(num, ref AllCricketData) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* num = pData + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pData, ref TaiwuAllowCrickets);
		int totalSize = (int)(num + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(num, ref AllCricketData) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

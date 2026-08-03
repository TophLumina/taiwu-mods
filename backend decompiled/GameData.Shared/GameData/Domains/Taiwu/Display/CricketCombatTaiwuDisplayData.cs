using System.Collections.Generic;
using GameData.Domains.Item;
using GameData.Domains.Item.Display;
using GameData.Serializer;

namespace GameData.Domains.Taiwu.Display;

/// <summary>
/// 促织决斗太吾显示数据
/// </summary>
[SerializableGameData(NotForArchive = true, NoCopyConstructors = true)]
public class CricketCombatTaiwuDisplayData : ISerializableGameData
{
	/// <summary>
	/// 允许太吾使用的蛐蛐物品数据
	/// 蛐蛐物品 ID -&gt; 蛐蛐数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, ItemDisplayData> TaiwuAllowCrickets = new Dictionary<int, ItemDisplayData>();

	/// <summary>
	/// 所有蛐蛐数据
	/// 蛐蛐物品 ID -&gt; 蛐蛐数据
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<int, CricketData> AllCricketData = new Dictionary<int, CricketData>();

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public CricketCombatTaiwuDisplayData()
	{
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

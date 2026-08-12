using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Serializer;

namespace GameData.Domains.Story.MainStory;

/// <summary>
/// 十二仙缓存数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class TwelveImmortalsCacheData : ISerializableGameData
{
	/// <summary>
	/// 移动消耗乘数
	/// </summary>
	[SerializableGameDataField]
	public Dictionary<Location, int> MoveCostMultiplier = new Dictionary<Location, int>();

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public TwelveImmortalsCacheData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public TwelveImmortalsCacheData(TwelveImmortalsCacheData other)
	{
		MoveCostMultiplier = ((other.MoveCostMultiplier == null) ? null : new Dictionary<Location, int>(other.MoveCostMultiplier));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(TwelveImmortalsCacheData other)
	{
		MoveCostMultiplier = ((other.MoveCostMultiplier == null) ? null : new Dictionary<Location, int>(other.MoveCostMultiplier));
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
		totalSize += SerializationHelper.DictionaryOfCustomTypeBasicTypePair.GetSerializedSize(MoveCostMultiplier);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Serialize(pData, ref MoveCostMultiplier) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfCustomTypeBasicTypePair.Deserialize(pData, ref MoveCostMultiplier) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

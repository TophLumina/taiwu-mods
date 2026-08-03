using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇缓存数据
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class AdventureCacheData : ISerializableGameData
{
	/// <summary>
	/// 所有地区的奇遇缓存数据
	/// </summary>
	[SerializableGameDataField]
	private Dictionary<short, AdventureAreaCacheData> _areaCache = new Dictionary<short, AdventureAreaCacheData>();

	/// <summary>
	/// 后端直接操作的缓存数据，请勿在前端使用
	/// </summary>
	public IDictionary<short, AdventureAreaCacheData> BackendAreaCache => _areaCache;

	/// <summary>
	/// 指定位置是否有任意奇遇或大事件
	/// </summary>
	public bool QueryAnyAdventureOrMajorEvent(Location location)
	{
		return GetCacheData(location)?.AnyAdventureOrMajorEvent ?? false;
	}

	/// <summary>
	/// 获取某个位置上的缓存数据
	/// </summary>
	public AdventureBlockCacheData GetCacheData(Location location)
	{
		return _areaCache?.GetOrDefault(location.AreaId)?.GetCacheData(location.BlockId);
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public AdventureCacheData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public AdventureCacheData(AdventureCacheData other)
	{
		if (other._areaCache != null)
		{
			Dictionary<short, AdventureAreaCacheData> areaCache = other._areaCache;
			int elementsCount = areaCache.Count;
			_areaCache = new Dictionary<short, AdventureAreaCacheData>(elementsCount);
			{
				foreach (KeyValuePair<short, AdventureAreaCacheData> pair in areaCache)
				{
					_areaCache.Add(pair.Key, new AdventureAreaCacheData(pair.Value));
				}
				return;
			}
		}
		_areaCache = null;
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(AdventureCacheData other)
	{
		if (other._areaCache != null)
		{
			Dictionary<short, AdventureAreaCacheData> areaCache = other._areaCache;
			int elementsCount = areaCache.Count;
			_areaCache = new Dictionary<short, AdventureAreaCacheData>(elementsCount);
			{
				foreach (KeyValuePair<short, AdventureAreaCacheData> pair in areaCache)
				{
					_areaCache.Add(pair.Key, new AdventureAreaCacheData(pair.Value));
				}
				return;
			}
		}
		_areaCache = null;
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
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(_areaCache);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pData, ref _areaCache) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pData, ref _areaCache) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

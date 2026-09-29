using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

[SerializableGameData(NotForArchive = true)]
public class AdventureCacheData : ISerializableGameData
{
	[SerializableGameDataField]
	private Dictionary<short, AdventureAreaCacheData> _areaCache = new Dictionary<short, AdventureAreaCacheData>();

	public IDictionary<short, AdventureAreaCacheData> BackendAreaCache => _areaCache;

	public bool QueryAnyAdventureOrMajorEvent(Location location)
	{
		return GetCacheData(location)?.AnyAdventureOrMajorEvent ?? false;
	}

	public AdventureBlockCacheData GetCacheData(Location location)
	{
		return _areaCache?.GetOrDefault(location.AreaId)?.GetCacheData(location.BlockId);
	}

	public AdventureCacheData()
	{
	}

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

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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

	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pData, ref _areaCache) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

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

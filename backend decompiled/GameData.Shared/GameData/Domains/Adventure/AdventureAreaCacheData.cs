using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

[SerializableGameData(NotForArchive = true)]
public class AdventureAreaCacheData : ISerializableGameData
{
	[SerializableGameDataField]
	private Dictionary<short, AdventureBlockCacheData> _blockCache = new Dictionary<short, AdventureBlockCacheData>();

	public IDictionary<short, AdventureBlockCacheData> BackendBlockCache => _blockCache;

	public AdventureBlockCacheData GetCacheData(short blockId)
	{
		return _blockCache?.GetOrDefault(blockId);
	}

	public AdventureAreaCacheData()
	{
	}

	public AdventureAreaCacheData(AdventureAreaCacheData other)
	{
		if (other._blockCache != null)
		{
			Dictionary<short, AdventureBlockCacheData> blockCache = other._blockCache;
			int elementsCount = blockCache.Count;
			_blockCache = new Dictionary<short, AdventureBlockCacheData>(elementsCount);
			{
				foreach (KeyValuePair<short, AdventureBlockCacheData> pair in blockCache)
				{
					_blockCache.Add(pair.Key, new AdventureBlockCacheData(pair.Value));
				}
				return;
			}
		}
		_blockCache = null;
	}

	public void Assign(AdventureAreaCacheData other)
	{
		if (other._blockCache != null)
		{
			Dictionary<short, AdventureBlockCacheData> blockCache = other._blockCache;
			int elementsCount = blockCache.Count;
			_blockCache = new Dictionary<short, AdventureBlockCacheData>(elementsCount);
			{
				foreach (KeyValuePair<short, AdventureBlockCacheData> pair in blockCache)
				{
					_blockCache.Add(pair.Key, new AdventureBlockCacheData(pair.Value));
				}
				return;
			}
		}
		_blockCache = null;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 0;
		totalSize += SerializationHelper.DictionaryOfBasicTypeCustomTypePair.GetSerializedSize(_blockCache);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pData, ref _blockCache) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Deserialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Deserialize(pData, ref _blockCache) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

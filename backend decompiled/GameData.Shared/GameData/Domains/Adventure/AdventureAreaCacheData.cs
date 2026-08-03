using System.Collections.Generic;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇缓存数据 - 单个地区
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class AdventureAreaCacheData : ISerializableGameData
{
	[SerializableGameDataField]
	private Dictionary<short, AdventureBlockCacheData> _blockCache = new Dictionary<short, AdventureBlockCacheData>();

	/// <summary>
	/// 后端直接操作的缓存数据，请勿在前端使用
	/// </summary>
	public IDictionary<short, AdventureBlockCacheData> BackendBlockCache => _blockCache;

	/// <summary>
	/// 获取某个位置上的缓存数据
	/// </summary>
	public AdventureBlockCacheData GetCacheData(short blockId)
	{
		return _blockCache?.GetOrDefault(blockId);
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public AdventureAreaCacheData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
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

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.IsSerializedSizeFixed" />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.GetSerializedSize" />
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

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		int totalSize = (int)(pData + SerializationHelper.DictionaryOfBasicTypeCustomTypePair.Serialize(pData, ref _blockCache) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
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

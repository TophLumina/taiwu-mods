using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

/// <summary>
/// 奇遇缓存数据 - 单个地格
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class AdventureBlockCacheData : ISerializableGameData
{
	/// <summary>
	/// 用于序列化的数据
	/// </summary>
	[SerializableGameDataField]
	private List<int> _runtimeIds;

	/// <summary>
	/// 前端使用的缓存数据
	/// </summary>
	private List<int> _frontendCache;

	/// <summary>
	/// 当前格运行时 ID 列表
	/// </summary>
	public IReadOnlyList<int> RuntimeIds
	{
		get
		{
			IReadOnlyList<int> runtimeIds = _runtimeIds;
			return runtimeIds ?? Array.Empty<int>();
		}
	}

	/// <summary>
	/// 后端直接操作的缓存数据，请勿在前端使用
	/// </summary>
	public List<int> BackendRuntimeIds => _runtimeIds ?? (_runtimeIds = new List<int>());

	/// <summary>
	/// 当前格所有激活的运行时 ID 列表
	/// </summary>
	public IReadOnlyList<int> ActiveRuntimeIds
	{
		get
		{
			IReadOnlyList<int> runtimeIds = RuntimeIds;
			if (runtimeIds == null || runtimeIds.Count <= 0)
			{
				return Array.Empty<int>();
			}
			if (_frontendCache == null)
			{
				_frontendCache = new List<int>();
			}
			_frontendCache.Clear();
			foreach (int runtimeId in RuntimeIds)
			{
				IAdventureRuntime runtime = ExternalDataBridge.Context.GetAny(runtimeId);
				if (runtime != null && runtime.StatusType.IsActive())
				{
					_frontendCache.Add(runtimeId);
				}
			}
			return _frontendCache;
		}
	}

	/// <summary>
	/// 当前地格是否有奇遇
	/// </summary>
	public bool AnyAdventure => RuntimeIds.Any(IsAdventure);

	/// <summary>
	/// 当前地格是否有大事件
	/// </summary>
	public bool AnyMajorEvent => RuntimeIds.Any(IsMajorEvent);

	/// <summary>
	/// 当前地格是否有奇遇或大事件
	/// </summary>
	public bool AnyAdventureOrMajorEvent => RuntimeIds.Count > 0;

	/// <summary>
	/// 首个奇遇 ID
	/// </summary>
	public int AdventureId => RuntimeIds.FirstOrDefault(IsAdventure);

	/// <summary>
	/// 首个大事件 ID
	/// </summary>
	public int MajorEventId => RuntimeIds.FirstOrDefault(IsMajorEvent);

	private static bool IsAdventure(int runtimeId)
	{
		return ExternalDataBridge.Context.GetAny(runtimeId) is AdventureRuntime;
	}

	private static bool IsMajorEvent(int runtimeId)
	{
		return ExternalDataBridge.Context.GetAny(runtimeId) is AdventureMajorEvent;
	}

	/// <summary>
	/// 重置数据
	/// </summary>
	public void Reset()
	{
		_runtimeIds?.Clear();
	}

	/// <summary>
	/// 默认空构造函数, 只用于反序列化.
	/// </summary>
	public AdventureBlockCacheData()
	{
	}

	/// <summary>
	/// 拷贝构造函数
	/// </summary>
	public AdventureBlockCacheData(AdventureBlockCacheData other)
	{
		_runtimeIds = ((other._runtimeIds == null) ? null : new List<int>(other._runtimeIds));
	}

	/// <summary>
	/// 深度拷贝指定对象
	/// </summary>
	public void Assign(AdventureBlockCacheData other)
	{
		_runtimeIds = ((other._runtimeIds == null) ? null : new List<int>(other._runtimeIds));
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
		totalSize = ((_runtimeIds == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _runtimeIds.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Serialize(System.Byte*)" />
	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		if (_runtimeIds != null)
		{
			int elementsCount = _runtimeIds.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				((int*)pCurrData)[i] = _runtimeIds[i];
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc cref="M:GameData.Serializer.ISerializableGameData.Deserialize(System.Byte*)" />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (_runtimeIds == null)
			{
				_runtimeIds = new List<int>(elementsCount);
			}
			else
			{
				_runtimeIds.Clear();
			}
			for (int i = 0; i < elementsCount; i++)
			{
				_runtimeIds.Add(((int*)pCurrData)[i]);
			}
			pCurrData += 4 * elementsCount;
		}
		else
		{
			_runtimeIds?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}

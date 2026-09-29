using System;
using System.Collections.Generic;
using System.Linq;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Adventure;

[SerializableGameData(NotForArchive = true)]
public class AdventureBlockCacheData : ISerializableGameData
{
	[SerializableGameDataField]
	private List<int> _runtimeIds;

	private List<int> _frontendCache;

	public IReadOnlyList<int> RuntimeIds
	{
		get
		{
			IReadOnlyList<int> runtimeIds = _runtimeIds;
			return runtimeIds ?? Array.Empty<int>();
		}
	}

	public List<int> BackendRuntimeIds => _runtimeIds ?? (_runtimeIds = new List<int>());

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

	public bool AnyAdventure => RuntimeIds.Any(IsAdventure);

	public bool AnyMajorEvent => RuntimeIds.Any(IsMajorEvent);

	public bool AnyAdventureOrMajorEvent => RuntimeIds.Count > 0;

	public int AdventureId => RuntimeIds.FirstOrDefault(IsAdventure);

	public int MajorEventId => RuntimeIds.FirstOrDefault(IsMajorEvent);

	private static bool IsAdventure(int runtimeId)
	{
		return ExternalDataBridge.Context.GetAny(runtimeId) is AdventureRuntime;
	}

	private static bool IsMajorEvent(int runtimeId)
	{
		return ExternalDataBridge.Context.GetAny(runtimeId) is AdventureMajorEvent;
	}

	public void Reset()
	{
		_runtimeIds?.Clear();
	}

	public AdventureBlockCacheData()
	{
	}

	public AdventureBlockCacheData(AdventureBlockCacheData other)
	{
		_runtimeIds = ((other._runtimeIds == null) ? null : new List<int>(other._runtimeIds));
	}

	public void Assign(AdventureBlockCacheData other)
	{
		_runtimeIds = ((other._runtimeIds == null) ? null : new List<int>(other._runtimeIds));
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

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

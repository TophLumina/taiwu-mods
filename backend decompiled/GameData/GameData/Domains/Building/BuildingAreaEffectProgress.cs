using System;
using System.Collections.Generic;
using GameData.Domains.Map;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Building;

[SerializableGameData(IsExtensible = true, NoCopyConstructors = true, NotForDisplayModule = true)]
public class BuildingAreaEffectProgress : ISerializableGameData
{
	public static class EffectType
	{
		public const sbyte Animal = 0;

		public const sbyte Cricket = 1;

		public const sbyte Adventure = 2;

		public const int Count = 3;

		public static readonly int[] ProgressThreshold = new int[3] { 60, 180, 360 };

		public static readonly int[] MaxActiveCount = new int[3] { 6, 3, 1 };

		public static readonly EBuildingScaleEffect[] ToBuildingScaleEffect = new EBuildingScaleEffect[3]
		{
			EBuildingScaleEffect.AnimalProgressDelta,
			EBuildingScaleEffect.CricketProgressDelta,
			EBuildingScaleEffect.AdventureProgressDelta
		};
	}

	private static class FieldIds
	{
		public const ushort EffectType = 0;

		public const ushort Progress = 1;

		public const ushort CurrActiveLocations = 2;

		public const ushort Count = 3;

		public static readonly string[] FieldId2FieldName = new string[3] { "EffectType", "Progress", "CurrActiveLocations" };
	}

	[SerializableGameDataField]
	private sbyte _effectType;

	[SerializableGameDataField]
	private int _progress;

	[SerializableGameDataField]
	private List<Location> _currActiveLocations;

	public sbyte Type => _effectType;

	public EBuildingScaleEffect BuildingScaleEffect => EffectType.ToBuildingScaleEffect[_effectType];

	public IReadOnlyList<Location> CurrentActiveLocations
	{
		get
		{
			IReadOnlyList<Location> currActiveLocations = _currActiveLocations;
			return currActiveLocations ?? Array.Empty<Location>();
		}
	}

	public int LocationCount => _currActiveLocations?.Count ?? 0;

	public int Progress => _progress;

	public BuildingAreaEffectProgress(sbyte effectType)
	{
		_effectType = effectType;
	}

	public BuildingAreaEffectProgress()
	{
	}

	public bool RemoveLocation(Location location)
	{
		if (location.IsValid() && _currActiveLocations != null)
		{
			return _currActiveLocations.Remove(location);
		}
		return false;
	}

	public void AddLocation(Location location)
	{
		if (_currActiveLocations == null)
		{
			_currActiveLocations = new List<Location>();
		}
		_currActiveLocations.Add(location);
	}

	public int OfflineSetProgress(int value)
	{
		return _progress = value;
	}

	public int OfflineChangeProgress(int delta)
	{
		int maxCount = EffectType.MaxActiveCount[_effectType];
		int currCount = LocationCount;
		if (currCount >= maxCount)
		{
			return 0;
		}
		_progress += delta;
		int threshold = EffectType.ProgressThreshold[_effectType];
		int activateCount = _progress / threshold;
		if (activateCount <= 0)
		{
			return 0;
		}
		if (currCount + activateCount >= maxCount)
		{
			activateCount = maxCount - currCount;
		}
		_progress %= threshold;
		return activateCount;
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 7;
		totalSize = ((_currActiveLocations == null) ? (totalSize + 2) : (totalSize + (2 + 4 * _currActiveLocations.Count)));
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = 3;
		pCurrData += 2;
		*pCurrData = (byte)_effectType;
		pCurrData++;
		*(int*)pCurrData = _progress;
		pCurrData += 4;
		if (_currActiveLocations != null)
		{
			int elementsCount = _currActiveLocations.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			for (int i = 0; i < elementsCount; i++)
			{
				pCurrData += _currActiveLocations[i].Serialize(pCurrData);
			}
		}
		else
		{
			*(short*)pCurrData = 0;
			pCurrData += 2;
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}

	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		ushort fieldCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (fieldCount > 0)
		{
			_effectType = (sbyte)(*pCurrData);
			pCurrData++;
		}
		if (fieldCount > 1)
		{
			_progress = *(int*)pCurrData;
			pCurrData += 4;
		}
		if (fieldCount > 2)
		{
			ushort elementsCount = *(ushort*)pCurrData;
			pCurrData += 2;
			if (elementsCount > 0)
			{
				if (_currActiveLocations == null)
				{
					_currActiveLocations = new List<Location>(elementsCount);
				}
				else
				{
					_currActiveLocations.Clear();
				}
				for (int i = 0; i < elementsCount; i++)
				{
					Location element = default(Location);
					pCurrData += element.Deserialize(pCurrData);
					_currActiveLocations.Add(element);
				}
			}
			else
			{
				_currActiveLocations?.Clear();
			}
		}
		int totalSize = (int)(pCurrData - pData);
		return (totalSize <= 4) ? totalSize : ((totalSize + 3) / 4 * 4);
	}
}

using System;
using System.Collections.Generic;
using Config;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

public class MapAreaData : ISerializableGameData
{
	public const int RegularAreasCount = 45;

	public const int BrokenAreasCount = 90;

	public const int WorldAreasCount = 135;

	public const int SpecialAreasCount = 6;

	public const int TotalAreasCount = 141;

	public const int BrokenAreasPerState = 6;

	public const short BornAreaId = 135;

	public const short GuideAreaId = 136;

	public const short SecretVillageAreaId = 137;

	public const short BrokenPerformAreaId = 138;

	public const short PastTaiwuVillageAreaId = 139;

	public const short ChaishanAreaId = 140;

	public const int MaxSettlementsCount = 3;

	[SerializableGameDataField]
	private short _templateId;

	[SerializableGameDataField]
	private short _areaIndex;

	[SerializableGameDataField(ArrayElementsCount = 3)]
	public SettlementInfo[] SettlementInfos;

	[SerializableGameDataField]
	public short StationBlockId;

	[SerializableGameDataField]
	public bool Discovered;

	[SerializableGameDataField]
	public bool StationUnlocked;

	[Obsolete("Use DomainManager.Extra._spiritualDebt instead")]
	[SerializableGameDataField]
	public short SpiritualDebt;

	[SerializableGameDataField]
	public HashSet<short> NeighborAreas;

	public static bool IsRegularArea(short areaId)
	{
		if (areaId < 45)
		{
			return areaId >= 0;
		}
		return false;
	}

	public static bool IsNormalArea(short areaId)
	{
		if (areaId >= 45)
		{
			return areaId >= 135;
		}
		return true;
	}

	public static bool IsBrokenArea(short areaId)
	{
		if (areaId >= 45)
		{
			return areaId < 135;
		}
		return false;
	}

	public MapAreaData()
	{
		SettlementInfos = new SettlementInfo[3];
		NeighborAreas = new HashSet<short>();
	}

	public void Init(short templateId, short areaIndex)
	{
		_templateId = templateId;
		_areaIndex = areaIndex;
		StationBlockId = -1;
		SpiritualDebt = 0;
		for (int i = 0; i < 3; i++)
		{
			SettlementInfos[i] = new SettlementInfo(-1, -1, -1, -1);
		}
	}

	public MapAreaData(MapAreaData other)
	{
		_templateId = other._templateId;
		_areaIndex = other._areaIndex;
		SettlementInfo[] item = other.SettlementInfos;
		int elementsCount = item.Length;
		SettlementInfos = new SettlementInfo[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			SettlementInfos[i] = item[i];
		}
		StationBlockId = other.StationBlockId;
		Discovered = other.Discovered;
		StationUnlocked = other.StationUnlocked;
		SpiritualDebt = other.SpiritualDebt;
		NeighborAreas = new HashSet<short>(other.NeighborAreas);
	}

	public void Assign(MapAreaData other)
	{
		_templateId = other._templateId;
		_areaIndex = other._areaIndex;
		SettlementInfo[] item = other.SettlementInfos;
		int elementsCount = item.Length;
		SettlementInfos = new SettlementInfo[elementsCount];
		for (int i = 0; i < elementsCount; i++)
		{
			SettlementInfos[i] = item[i];
		}
		StationBlockId = other.StationBlockId;
		Discovered = other.Discovered;
		StationUnlocked = other.StationUnlocked;
		SpiritualDebt = other.SpiritualDebt;
		NeighborAreas = new HashSet<short>(other.NeighborAreas);
	}

	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	public int GetSerializedSize()
	{
		int totalSize = 34;
		totalSize = ((NeighborAreas == null) ? (totalSize + 2) : (totalSize + (2 + 2 * NeighborAreas.Count)));
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public unsafe int Serialize(byte* pData)
	{
		byte* pCurrData = pData;
		*(short*)pCurrData = _templateId;
		pCurrData += 2;
		*(short*)pCurrData = _areaIndex;
		pCurrData += 2;
		Tester.Assert(SettlementInfos.Length == 3);
		for (int i = 0; i < 3; i++)
		{
			pCurrData += SettlementInfos[i].Serialize(pCurrData);
		}
		*(short*)pCurrData = StationBlockId;
		pCurrData += 2;
		*pCurrData = (Discovered ? ((byte)1) : ((byte)0));
		pCurrData++;
		*pCurrData = (StationUnlocked ? ((byte)1) : ((byte)0));
		pCurrData++;
		*(short*)pCurrData = SpiritualDebt;
		pCurrData += 2;
		if (NeighborAreas != null)
		{
			int elementsCount = NeighborAreas.Count;
			Tester.Assert(elementsCount <= 65535);
			*(ushort*)pCurrData = (ushort)elementsCount;
			pCurrData += 2;
			foreach (short areaId in NeighborAreas)
			{
				*(short*)pCurrData = areaId;
				pCurrData += 2;
			}
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
		_templateId = *(short*)pCurrData;
		pCurrData += 2;
		_areaIndex = *(short*)pCurrData;
		pCurrData += 2;
		if (SettlementInfos == null || SettlementInfos.Length != 3)
		{
			SettlementInfos = new SettlementInfo[3];
		}
		for (int i = 0; i < 3; i++)
		{
			SettlementInfo element = default(SettlementInfo);
			pCurrData += element.Deserialize(pCurrData);
			SettlementInfos[i] = element;
		}
		StationBlockId = *(short*)pCurrData;
		pCurrData += 2;
		Discovered = *pCurrData != 0;
		pCurrData++;
		StationUnlocked = *pCurrData != 0;
		pCurrData++;
		SpiritualDebt = *(short*)pCurrData;
		pCurrData += 2;
		ushort elementsCount = *(ushort*)pCurrData;
		pCurrData += 2;
		if (elementsCount > 0)
		{
			if (NeighborAreas == null)
			{
				NeighborAreas = new HashSet<short>();
			}
			else
			{
				NeighborAreas.Clear();
			}
			for (int j = 0; j < elementsCount; j++)
			{
				NeighborAreas.Add(((short*)pCurrData)[j]);
			}
			pCurrData += 2 * elementsCount;
		}
		else
		{
			NeighborAreas?.Clear();
		}
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	public short GetTemplateId()
	{
		return _templateId;
	}

	public short GetId()
	{
		return _areaIndex;
	}

	public MapAreaItem GetConfig()
	{
		return MapArea.Instance[_templateId];
	}

	public int GetSettlementIndex(short blockId)
	{
		int i = 0;
		for (int count = SettlementInfos.Length; i < count; i++)
		{
			if (SettlementInfos[i].BlockId == blockId)
			{
				return i;
			}
		}
		return -1;
	}

	public short GetAreaId()
	{
		return _areaIndex;
	}
}

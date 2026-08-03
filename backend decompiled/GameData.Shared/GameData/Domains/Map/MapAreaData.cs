using System;
using System.Collections.Generic;
using Config;
using GameData.Serializer;
using GameData.Utilities;

namespace GameData.Domains.Map;

/// <summary>
/// 地图区域数据
/// </summary>
public class MapAreaData : ISerializableGameData
{
	/// <summary>
	/// 常规区域个数
	/// </summary>
	public const int RegularAreasCount = 45;

	/// <summary>
	/// 废弃区域个数
	/// </summary>
	public const int BrokenAreasCount = 90;

	/// <summary>
	/// 世界区域个数 (常规 + 废弃)
	/// </summary>
	public const int WorldAreasCount = 135;

	/// <summary>
	/// 特殊区域个数
	/// </summary>
	public const int SpecialAreasCount = 6;

	/// <summary>
	/// 所有区域个数（世界 + 特殊）
	/// </summary>
	public const int TotalAreasCount = 141;

	/// <summary>
	/// 每个州域废弃区域个数
	/// </summary>
	public const int BrokenAreasPerState = 6;

	/// <summary>
	/// 深谷区域索引
	/// </summary>
	public const short BornAreaId = 135;

	/// <summary>
	/// 引导区域索引
	/// </summary>
	public const short GuideAreaId = 136;

	/// <summary>
	/// 隐秘小村区域索引
	/// </summary>
	public const short SecretVillageAreaId = 137;

	/// <summary>
	/// 毁坏（演出用）区域索引
	/// </summary>
	public const short BrokenPerformAreaId = 138;

	/// <summary>
	/// 过去的太吾村，复制的太吾村地图数据
	/// </summary>
	public const short PastTaiwuVillageAreaId = 139;

	/// <summary>
	/// 柴山
	/// </summary>
	public const short ChaishanAreaId = 140;

	/// <summary>
	/// 区域内最大的定居点数量
	/// </summary>
	public const int MaxSettlementsCount = 3;

	/// <summary>
	/// 区域模板ID [MapArea]
	/// </summary>
	[SerializableGameDataField]
	private short _templateId;

	/// <summary>
	/// 在世界地图区域列表中的索引【0-44:真实世界数据数组位置索引 45-深谷 46-新手引导地图】
	/// </summary>
	[SerializableGameDataField]
	private short _areaIndex;

	/// <summary>
	/// 定居点信息集合
	/// </summary>
	[SerializableGameDataField(ArrayElementsCount = 3)]
	public SettlementInfo[] SettlementInfos;

	/// <summary>
	/// 驿站的地块索引.
	/// 小于 0 表示此区域无驿站.
	/// </summary>
	[SerializableGameDataField]
	public short StationBlockId;

	/// <summary>
	/// 区域是否已被发现
	/// </summary>
	[SerializableGameDataField]
	public bool Discovered;

	/// <summary>
	/// 驿站是否已开通
	/// </summary>
	[SerializableGameDataField]
	public bool StationUnlocked;

	/// <summary>
	/// 恩义值
	/// </summary>
	[Obsolete("Use DomainManager.Extra._spiritualDebt instead")]
	[SerializableGameDataField]
	public short SpiritualDebt;

	/// <summary>
	/// 相邻区域集合
	/// 仅在游戏开始时初始化一次
	/// </summary>
	[SerializableGameDataField]
	public HashSet<short> NeighborAreas;

	/// <summary>
	/// 是否属于常规地区
	/// </summary>
	/// <param name="areaId"></param>
	/// <returns></returns>
	public static bool IsRegularArea(short areaId)
	{
		if (areaId < 45)
		{
			return areaId >= 0;
		}
		return false;
	}

	/// <summary>
	/// 是否属于完整地区（常规 + 特殊）
	/// </summary>
	public static bool IsNormalArea(short areaId)
	{
		if (areaId >= 45)
		{
			return areaId >= 135;
		}
		return true;
	}

	/// <summary>
	/// 是否属于毁坏地区
	/// </summary>
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

	/// <summary>
	/// 设置模板和实例 ID, 以及其他数据的默认值
	/// </summary>
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

	/// <summary>
	/// 获取区域模板 ID
	/// </summary>
	/// <returns></returns>
	public short GetTemplateId()
	{
		return _templateId;
	}

	public short GetId()
	{
		return _areaIndex;
	}

	/// <summary>
	/// 获取区域配置
	/// </summary>
	public MapAreaItem GetConfig()
	{
		return MapArea.Instance[_templateId];
	}

	/// <summary>
	/// 获取指定地块索引的定居点信息.
	/// 大地块的附属地块必须传入所属地块索引.
	/// </summary>
	/// <returns>定居点信息索引, 小于 0 表示该地块不为定居点</returns>
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

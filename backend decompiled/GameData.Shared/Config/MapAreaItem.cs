using System;
using System.Collections.Generic;
using Config.Common;
using Config.ConfigCells;
using GameData.Utilities;

namespace Config;

[Serializable]
public class MapAreaItem : ConfigItem<MapAreaItem, short>
{
	public readonly short TemplateId;

	public readonly sbyte StateID;

	public readonly string Name;

	public readonly string Desc;

	public readonly byte Size;

	public readonly sbyte[] WorldMapPos;

	public readonly AreaTravelRoute[] NeighborAreas;

	public readonly string BigMapIcon;

	public readonly string[] MiniMapIcons;

	public readonly string BlockAtlas;

	public readonly short[] MiniMapPos;

	public readonly byte Fame;

	public readonly byte EnemyAdjust;

	public readonly byte MaxNestUpgradeAmount;

	public readonly List<EnemyNestCreationInfo[]> EnemyNests;

	public readonly List<IntPair> EnemyNestCreationDateRanges;

	public readonly short[] SettlementBlockCore;

	public readonly sbyte[] OrganizationId;

	public readonly short CenterBlock;

	public readonly sbyte StationLocate;

	public readonly string CustomBlockConfig;

	public readonly EMapAreaAreaDirection AreaDirection;

	public readonly List<short[]> DevelopedBlockCore;

	public readonly List<short[]> NormalBlockCore;

	public readonly List<short[]> WildBlockCore;

	public readonly List<short[]> BigBaseBlockCore;

	public readonly List<short[]> SeriesBlockCore;

	public readonly List<short[]> EncircleBlockCore;

	public readonly short[] SceneryBlockCore;

	public readonly string TempleName;

	public readonly string TempleDesc;

	public readonly string[] CaveName;

	public readonly string[] CaveDesc;

	public readonly List<short> LovingItemSubTypes;

	public readonly List<short> HatingItemSubTypes;

	public readonly bool ShowDarkAshStatus;

	public readonly float[] ImagePos;

	public readonly float[] RoadPos;

	public readonly sbyte AreaType;

	public MapAreaItem(short templateId, sbyte stateID, string name, string desc, byte size, sbyte[] worldMapPos, AreaTravelRoute[] neighborAreas, string bigMapIcon, string[] miniMapIcons, string blockAtlas, short[] miniMapPos, byte fame, byte enemyAdjust, byte maxNestUpgradeAmount, List<EnemyNestCreationInfo[]> enemyNests, List<IntPair> enemyNestCreationDateRanges, short[] settlementBlockCore, sbyte[] organizationId, short centerBlock, sbyte stationLocate, string customBlockConfig, EMapAreaAreaDirection areaDirection, List<short[]> developedBlockCore, List<short[]> normalBlockCore, List<short[]> wildBlockCore, List<short[]> bigBaseBlockCore, List<short[]> seriesBlockCore, List<short[]> encircleBlockCore, short[] sceneryBlockCore, string templeName, string templeDesc, string[] caveName, string[] caveDesc, List<short> lovingItemSubTypes, List<short> hatingItemSubTypes, bool showDarkAshStatus, float[] imagePos, float[] roadPos, sbyte areaType)
	{
		TemplateId = templateId;
		StateID = stateID;
		Name = name;
		Desc = desc;
		Size = size;
		WorldMapPos = worldMapPos;
		NeighborAreas = neighborAreas;
		BigMapIcon = bigMapIcon;
		MiniMapIcons = miniMapIcons;
		BlockAtlas = blockAtlas;
		MiniMapPos = miniMapPos;
		Fame = fame;
		EnemyAdjust = enemyAdjust;
		MaxNestUpgradeAmount = maxNestUpgradeAmount;
		EnemyNests = enemyNests;
		EnemyNestCreationDateRanges = enemyNestCreationDateRanges;
		SettlementBlockCore = settlementBlockCore;
		OrganizationId = organizationId;
		CenterBlock = centerBlock;
		StationLocate = stationLocate;
		CustomBlockConfig = customBlockConfig;
		AreaDirection = areaDirection;
		DevelopedBlockCore = developedBlockCore;
		NormalBlockCore = normalBlockCore;
		WildBlockCore = wildBlockCore;
		BigBaseBlockCore = bigBaseBlockCore;
		SeriesBlockCore = seriesBlockCore;
		EncircleBlockCore = encircleBlockCore;
		SceneryBlockCore = sceneryBlockCore;
		TempleName = templeName;
		TempleDesc = templeDesc;
		CaveName = caveName;
		CaveDesc = caveDesc;
		LovingItemSubTypes = lovingItemSubTypes;
		HatingItemSubTypes = hatingItemSubTypes;
		ShowDarkAshStatus = showDarkAshStatus;
		ImagePos = imagePos;
		RoadPos = roadPos;
		AreaType = areaType;
	}

	public MapAreaItem()
	{
		TemplateId = 0;
		StateID = 0;
		Name = null;
		Desc = null;
		Size = 0;
		WorldMapPos = new sbyte[2] { -1, -1 };
		NeighborAreas = new AreaTravelRoute[0];
		BigMapIcon = null;
		MiniMapIcons = new string[4] { "", "", "", "" };
		BlockAtlas = null;
		MiniMapPos = new short[2] { -1, -1 };
		Fame = 0;
		EnemyAdjust = 0;
		MaxNestUpgradeAmount = 5;
		EnemyNests = new List<EnemyNestCreationInfo[]>();
		EnemyNestCreationDateRanges = new List<IntPair>();
		SettlementBlockCore = new short[0];
		OrganizationId = new sbyte[0];
		CenterBlock = 0;
		StationLocate = -1;
		CustomBlockConfig = null;
		AreaDirection = EMapAreaAreaDirection.South;
		DevelopedBlockCore = new List<short[]>
		{
			new short[2] { 39, 33 },
			new short[2] { 40, 33 },
			new short[2] { 41, 33 },
			new short[2] { 42, 33 },
			new short[2] { 43, 33 },
			new short[2] { 44, 33 },
			new short[2] { 45, 33 },
			new short[2] { 46, 33 },
			new short[2] { 47, 33 },
			new short[2] { 48, 33 },
			new short[2] { 49, 33 },
			new short[2] { 50, 33 },
			new short[2] { 51, 33 },
			new short[2] { 52, 33 },
			new short[2] { 53, 33 },
			new short[2] { 54, 33 },
			new short[2] { 55, 33 },
			new short[2] { 56, 33 },
			new short[2] { 109, 10 },
			new short[2] { 110, 10 },
			new short[2] { 111, 10 }
		};
		NormalBlockCore = new List<short[]>
		{
			new short[2] { 57, 33 },
			new short[2] { 58, 33 },
			new short[2] { 59, 33 },
			new short[2] { 63, 33 },
			new short[2] { 64, 33 },
			new short[2] { 65, 33 },
			new short[2] { 69, 33 },
			new short[2] { 70, 33 },
			new short[2] { 71, 33 },
			new short[2] { 75, 33 },
			new short[2] { 76, 33 },
			new short[2] { 77, 33 },
			new short[2] { 81, 33 },
			new short[2] { 82, 33 },
			new short[2] { 83, 33 },
			new short[2] { 87, 33 },
			new short[2] { 88, 33 },
			new short[2] { 89, 33 },
			new short[2] { 112, 30 },
			new short[2] { 113, 30 },
			new short[2] { 114, 30 },
			new short[2] { 124, 30 }
		};
		WildBlockCore = new List<short[]>
		{
			new short[2] { 93, 33 },
			new short[2] { 94, 33 },
			new short[2] { 95, 33 },
			new short[2] { 96, 33 },
			new short[2] { 97, 33 },
			new short[2] { 98, 33 },
			new short[2] { 99, 33 },
			new short[2] { 100, 33 },
			new short[2] { 101, 33 },
			new short[2] { 102, 33 },
			new short[2] { 103, 33 },
			new short[2] { 104, 33 },
			new short[2] { 105, 33 },
			new short[2] { 106, 33 },
			new short[2] { 107, 33 },
			new short[2] { 108, 33 },
			new short[2] { 115, 40 },
			new short[2] { 116, 40 },
			new short[2] { 117, 40 },
			new short[2] { 124, 30 }
		};
		BigBaseBlockCore = new List<short[]>
		{
			new short[2] { 60, 1 },
			new short[2] { 78, 1 },
			new short[2] { 61, 1 },
			new short[2] { 79, 1 },
			new short[2] { 62, 1 },
			new short[2] { 80, 1 }
		};
		SeriesBlockCore = new List<short[]>();
		EncircleBlockCore = new List<short[]>();
		SceneryBlockCore = new short[0];
		TempleName = null;
		TempleDesc = null;
		CaveName = null;
		CaveDesc = null;
		LovingItemSubTypes = new List<short>();
		HatingItemSubTypes = new List<short>();
		ShowDarkAshStatus = true;
		ImagePos = new float[2];
		RoadPos = new float[2];
		AreaType = 0;
	}

	public MapAreaItem(short templateId, MapAreaItem other)
	{
		TemplateId = templateId;
		StateID = other.StateID;
		Name = other.Name;
		Desc = other.Desc;
		Size = other.Size;
		WorldMapPos = other.WorldMapPos;
		NeighborAreas = other.NeighborAreas;
		BigMapIcon = other.BigMapIcon;
		MiniMapIcons = other.MiniMapIcons;
		BlockAtlas = other.BlockAtlas;
		MiniMapPos = other.MiniMapPos;
		Fame = other.Fame;
		EnemyAdjust = other.EnemyAdjust;
		MaxNestUpgradeAmount = other.MaxNestUpgradeAmount;
		EnemyNests = other.EnemyNests;
		EnemyNestCreationDateRanges = other.EnemyNestCreationDateRanges;
		SettlementBlockCore = other.SettlementBlockCore;
		OrganizationId = other.OrganizationId;
		CenterBlock = other.CenterBlock;
		StationLocate = other.StationLocate;
		CustomBlockConfig = other.CustomBlockConfig;
		AreaDirection = other.AreaDirection;
		DevelopedBlockCore = other.DevelopedBlockCore;
		NormalBlockCore = other.NormalBlockCore;
		WildBlockCore = other.WildBlockCore;
		BigBaseBlockCore = other.BigBaseBlockCore;
		SeriesBlockCore = other.SeriesBlockCore;
		EncircleBlockCore = other.EncircleBlockCore;
		SceneryBlockCore = other.SceneryBlockCore;
		TempleName = other.TempleName;
		TempleDesc = other.TempleDesc;
		CaveName = other.CaveName;
		CaveDesc = other.CaveDesc;
		LovingItemSubTypes = other.LovingItemSubTypes;
		HatingItemSubTypes = other.HatingItemSubTypes;
		ShowDarkAshStatus = other.ShowDarkAshStatus;
		ImagePos = other.ImagePos;
		RoadPos = other.RoadPos;
		AreaType = other.AreaType;
	}

	public override int GetTemplateId()
	{
		return TemplateId;
	}

	public override MapAreaItem Duplicate(int templateId)
	{
		return new MapAreaItem((short)templateId, this);
	}
}

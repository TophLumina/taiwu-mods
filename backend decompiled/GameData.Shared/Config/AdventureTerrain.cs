using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class AdventureTerrain : ConfigData<AdventureTerrainItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte NormalStart = 1;

		public const sbyte NormalEnd = 22;
	}

	public static class DefValue
	{
		public static AdventureTerrainItem NormalStart => Instance[(sbyte)1];

		public static AdventureTerrainItem NormalEnd => Instance[(sbyte)22];
	}

	public static AdventureTerrain Instance = new AdventureTerrain();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Img", "FlatImg", "EventBack", "CombatSceneId" };

	internal override int ToInt(sbyte value)
	{
		return value;
	}

	internal override sbyte ToTemplateId(int value)
	{
		return (sbyte)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new AdventureTerrainItem(0, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_0"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_0"), null, null, "[adapt]EventBack_101_4", 0, new List<short> { 0, 0, 0, 0, 0 }));
		_dataArray.Add(new AdventureTerrainItem(1, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_1"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_1"), "adventure_terrain_1", "adventure_terrain_flat_1", "[adapt]EventBack_101_3", 0, new List<short> { 6, 3, 9, 15, 12 }));
		_dataArray.Add(new AdventureTerrainItem(2, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_2"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_2"), "adventure_terrain_2", "adventure_terrain_flat_2", "[adapt]EventBack_101_0", 1, new List<short> { 6, 9, 3, 12, 15 }));
		_dataArray.Add(new AdventureTerrainItem(3, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_3"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_3"), "adventure_terrain_3", "adventure_terrain_flat_3", "[adapt]EventBack_101_13", 2, new List<short> { 9, 3, 6, 15, 12 }));
		_dataArray.Add(new AdventureTerrainItem(4, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_4"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_4"), "adventure_terrain_4", "adventure_terrain_flat_4", "[adapt]EventBack_101_16", 3, new List<short> { 9, 12, 15, 6, 3 }));
		_dataArray.Add(new AdventureTerrainItem(5, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_5"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_5"), "adventure_terrain_5", "adventure_terrain_flat_5", "[adapt]EventBack_101_11", 4, new List<short> { 15, 12, 9, 3, 6 }));
		_dataArray.Add(new AdventureTerrainItem(6, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_6"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_6"), "adventure_terrain_6", "adventure_terrain_flat_6", "[adapt]EventBack_101_14", 5, new List<short> { 9, 15, 3, 12, 6 }));
		_dataArray.Add(new AdventureTerrainItem(7, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_7"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_7"), "adventure_terrain_7", "adventure_terrain_flat_7", "[adapt]EventBack_101_16", 6, new List<short> { 15, 12, 9, 6, 3 }));
		_dataArray.Add(new AdventureTerrainItem(8, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_8"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_8"), "adventure_terrain_8", "adventure_terrain_flat_8", "[adapt]EventBack_101_13", 7, new List<short> { 3, 12, 15, 6, 9 }));
		_dataArray.Add(new AdventureTerrainItem(9, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_9"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_9"), "adventure_terrain_9", "adventure_terrain_flat_9", "[adapt]EventBack_101_14", 8, new List<short> { 6, 12, 15, 9, 3 }));
		_dataArray.Add(new AdventureTerrainItem(10, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_10"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_10"), "adventure_terrain_10", "adventure_terrain_flat_10", "[adapt]EventBack_101_7", 9, new List<short> { 9, 15, 12, 3, 6 }));
		_dataArray.Add(new AdventureTerrainItem(11, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_11"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_11"), "adventure_terrain_11", "adventure_terrain_flat_11", "[adapt]EventBack_101_12", 10, new List<short> { 9, 12, 15, 6, 3 }));
		_dataArray.Add(new AdventureTerrainItem(12, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_12"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_12"), "adventure_terrain_12", "adventure_terrain_flat_12", "[adapt]EventBack_101_12", 11, new List<short> { 6, 3, 12, 9, 15 }));
		_dataArray.Add(new AdventureTerrainItem(13, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_13"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_13"), "adventure_terrain_13", "adventure_terrain_flat_13", "[adapt]EventBack_101_15", 12, new List<short> { 3, 6, 12, 15, 9 }));
		_dataArray.Add(new AdventureTerrainItem(14, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_14"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_14"), "adventure_terrain_14", "adventure_terrain_flat_14", "[adapt]EventBack_101_18", 13, new List<short> { 15, 12, 3, 6, 9 }));
		_dataArray.Add(new AdventureTerrainItem(15, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_15"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_15"), "adventure_terrain_15", "adventure_terrain_flat_15", "[adapt]EventBack_101_1", 14, new List<short> { 9, 15, 12, 3, 6 }));
		_dataArray.Add(new AdventureTerrainItem(16, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_16"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_16"), "adventure_terrain_16", "adventure_terrain_flat_16", "[adapt]EventBack_101_4", 15, new List<short> { 3, 15, 12, 6, 9 }));
		_dataArray.Add(new AdventureTerrainItem(17, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_17"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_17"), "adventure_terrain_17", "adventure_terrain_flat_17", "[adapt]EventBack_101_5", 16, new List<short> { 9, 3, 12, 6, 15 }));
		_dataArray.Add(new AdventureTerrainItem(18, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_18"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_18"), "adventure_terrain_18", "adventure_terrain_flat_18", "[adapt]EventBack_101_5", 17, new List<short> { 15, 3, 6, 12, 9 }));
		_dataArray.Add(new AdventureTerrainItem(19, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_19"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_19"), "adventure_terrain_19", "adventure_terrain_flat_19", "[adapt]EventBack_101_5", 18, new List<short> { 12, 3, 6, 9, 15 }));
		_dataArray.Add(new AdventureTerrainItem(20, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_20"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_20"), "adventure_terrain_20", "adventure_terrain_flat_20", "[adapt]EventBack_101_4", 19, new List<short> { 6, 12, 3, 15, 9 }));
		_dataArray.Add(new AdventureTerrainItem(21, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_21"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_21"), "adventure_terrain_21", "adventure_terrain_flat_21", "[adapt]EventBack_101_4", 20, new List<short> { 15, 3, 6, 9, 12 }));
		_dataArray.Add(new AdventureTerrainItem(22, LocalStringManager.GetConfig("AdventureTerrain_language", "Name_22"), LocalStringManager.GetConfig("AdventureTerrain_language", "Desc_22"), "adventure_terrain_22", "adventure_terrain_flat_22", "[adapt]EventBack_101_5", 21, new List<short> { 9, 6, 3, 15, 12 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<AdventureTerrainItem>(23);
		CreateItems0();
	}
}

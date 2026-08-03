using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapLegend : ConfigData<MapLegendItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// MainLine
		/// </summary>
		public const sbyte MainLine = 0;

		/// <summary>
		/// SectStory
		/// </summary>
		public const sbyte SectStory = 1;

		/// <summary>
		/// LegendaryBook
		/// </summary>
		public const sbyte LegendaryBook = 2;

		/// <summary>
		/// LegendaryConsumed
		/// </summary>
		public const sbyte LegendaryConsumed = 23;

		/// <summary>
		/// Loong
		/// </summary>
		public const sbyte Loong = 3;

		/// <summary>
		/// PurpleBamboo
		/// </summary>
		public const sbyte PurpleBamboo = 4;

		/// <summary>
		/// Infected
		/// </summary>
		public const sbyte Infected = 5;

		/// <summary>
		/// InfectedDemon
		/// </summary>
		public const sbyte InfectedDemon = 17;

		/// <summary>
		/// DreamBack
		/// </summary>
		public const sbyte DreamBack = 6;

		/// <summary>
		/// LoongSon
		/// </summary>
		public const sbyte LoongSon = 7;

		/// <summary>
		/// Adventure
		/// </summary>
		public const sbyte Adventure = 8;

		/// <summary>
		/// QiwenXingtai
		/// </summary>
		public const sbyte QiwenXingtai = 18;

		/// <summary>
		/// QiwenXingtaiCount
		/// </summary>
		public const sbyte QiwenXingtaiCount = 19;

		/// <summary>
		/// Beast
		/// </summary>
		public const sbyte Beast = 20;

		/// <summary>
		/// SwordTomb
		/// </summary>
		public const sbyte SwordTomb = 21;

		/// <summary>
		/// MajorEvent
		/// </summary>
		public const sbyte MajorEvent = 22;

		/// <summary>
		/// Villager
		/// </summary>
		public const sbyte Villager = 9;

		/// <summary>
		/// Farmer
		/// </summary>
		public const sbyte Farmer = 10;

		/// <summary>
		/// Craftman
		/// </summary>
		public const sbyte Craftman = 11;

		/// <summary>
		/// Doctor
		/// </summary>
		public const sbyte Doctor = 12;

		/// <summary>
		/// Merchant
		/// </summary>
		public const sbyte Merchant = 13;

		/// <summary>
		/// Literati
		/// </summary>
		public const sbyte Literati = 14;

		/// <summary>
		/// SwordTombKeeper
		/// </summary>
		public const sbyte SwordTombKeeper = 15;

		/// <summary>
		/// VillageHead
		/// </summary>
		public const sbyte VillageHead = 16;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// MainLine
		/// </summary>
		public static MapLegendItem MainLine => Instance[(sbyte)0];

		/// <summary>
		/// SectStory
		/// </summary>
		public static MapLegendItem SectStory => Instance[(sbyte)1];

		/// <summary>
		/// LegendaryBook
		/// </summary>
		public static MapLegendItem LegendaryBook => Instance[(sbyte)2];

		/// <summary>
		/// LegendaryConsumed
		/// </summary>
		public static MapLegendItem LegendaryConsumed => Instance[(sbyte)23];

		/// <summary>
		/// Loong
		/// </summary>
		public static MapLegendItem Loong => Instance[(sbyte)3];

		/// <summary>
		/// PurpleBamboo
		/// </summary>
		public static MapLegendItem PurpleBamboo => Instance[(sbyte)4];

		/// <summary>
		/// Infected
		/// </summary>
		public static MapLegendItem Infected => Instance[(sbyte)5];

		/// <summary>
		/// InfectedDemon
		/// </summary>
		public static MapLegendItem InfectedDemon => Instance[(sbyte)17];

		/// <summary>
		/// DreamBack
		/// </summary>
		public static MapLegendItem DreamBack => Instance[(sbyte)6];

		/// <summary>
		/// LoongSon
		/// </summary>
		public static MapLegendItem LoongSon => Instance[(sbyte)7];

		/// <summary>
		/// Adventure
		/// </summary>
		public static MapLegendItem Adventure => Instance[(sbyte)8];

		/// <summary>
		/// QiwenXingtai
		/// </summary>
		public static MapLegendItem QiwenXingtai => Instance[(sbyte)18];

		/// <summary>
		/// QiwenXingtaiCount
		/// </summary>
		public static MapLegendItem QiwenXingtaiCount => Instance[(sbyte)19];

		/// <summary>
		/// Beast
		/// </summary>
		public static MapLegendItem Beast => Instance[(sbyte)20];

		/// <summary>
		/// SwordTomb
		/// </summary>
		public static MapLegendItem SwordTomb => Instance[(sbyte)21];

		/// <summary>
		/// MajorEvent
		/// </summary>
		public static MapLegendItem MajorEvent => Instance[(sbyte)22];

		/// <summary>
		/// Villager
		/// </summary>
		public static MapLegendItem Villager => Instance[(sbyte)9];

		/// <summary>
		/// Farmer
		/// </summary>
		public static MapLegendItem Farmer => Instance[(sbyte)10];

		/// <summary>
		/// Craftman
		/// </summary>
		public static MapLegendItem Craftman => Instance[(sbyte)11];

		/// <summary>
		/// Doctor
		/// </summary>
		public static MapLegendItem Doctor => Instance[(sbyte)12];

		/// <summary>
		/// Merchant
		/// </summary>
		public static MapLegendItem Merchant => Instance[(sbyte)13];

		/// <summary>
		/// Literati
		/// </summary>
		public static MapLegendItem Literati => Instance[(sbyte)14];

		/// <summary>
		/// SwordTombKeeper
		/// </summary>
		public static MapLegendItem SwordTombKeeper => Instance[(sbyte)15];

		/// <summary>
		/// VillageHead
		/// </summary>
		public static MapLegendItem VillageHead => Instance[(sbyte)16];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static MapLegend Instance = new MapLegend();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Sprite" };

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
		_dataArray.Add(new MapLegendItem(0, LocalStringManager.GetConfig("MapLegend_language", "Name_0"), LocalStringManager.GetConfig("MapLegend_language", "Desc_0"), "ui9_icon_largemap_legend_base_2", showInAreaMap: true));
		_dataArray.Add(new MapLegendItem(1, LocalStringManager.GetConfig("MapLegend_language", "Name_1"), LocalStringManager.GetConfig("MapLegend_language", "Desc_1"), "ui9_icon_largemap_legend_base_7", showInAreaMap: true));
		_dataArray.Add(new MapLegendItem(2, LocalStringManager.GetConfig("MapLegend_language", "Name_2"), LocalStringManager.GetConfig("MapLegend_language", "Desc_2"), "ui9_icon_largemap_legend_base_3", showInAreaMap: true));
		_dataArray.Add(new MapLegendItem(3, LocalStringManager.GetConfig("MapLegend_language", "Name_3"), LocalStringManager.GetConfig("MapLegend_language", "Desc_3"), "ui9_icon_largemap_legend_base_9", showInAreaMap: true));
		_dataArray.Add(new MapLegendItem(4, LocalStringManager.GetConfig("MapLegend_language", "Name_4"), LocalStringManager.GetConfig("MapLegend_language", "Desc_4"), "ui9_icon_largemap_legend_base_8", showInAreaMap: true));
		_dataArray.Add(new MapLegendItem(5, LocalStringManager.GetConfig("MapLegend_language", "Name_5"), LocalStringManager.GetConfig("MapLegend_language", "Desc_5"), "ui9_icon_largemap_legend_base_6", showInAreaMap: true));
		_dataArray.Add(new MapLegendItem(6, LocalStringManager.GetConfig("MapLegend_language", "Name_6"), LocalStringManager.GetConfig("MapLegend_language", "Desc_6"), "ui9_icon_largemap_legend_base_5", showInAreaMap: true));
		_dataArray.Add(new MapLegendItem(7, LocalStringManager.GetConfig("MapLegend_language", "Name_7"), LocalStringManager.GetConfig("MapLegend_language", "Desc_7"), "ui9_icon_largemap_legend_base_4", showInAreaMap: true));
		_dataArray.Add(new MapLegendItem(8, LocalStringManager.GetConfig("MapLegend_language", "Name_8"), LocalStringManager.GetConfig("MapLegend_language", "Desc_8"), "ui9_icon_largemap_legend_base_1", showInAreaMap: true));
		_dataArray.Add(new MapLegendItem(9, LocalStringManager.GetConfig("MapLegend_language", "Name_9"), LocalStringManager.GetConfig("MapLegend_language", "Desc_9"), "ui9_icon_roletype_0", showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(10, LocalStringManager.GetConfig("MapLegend_language", "Name_10"), LocalStringManager.GetConfig("MapLegend_language", "Desc_10"), "ui9_icon_roletype_1", showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(11, LocalStringManager.GetConfig("MapLegend_language", "Name_11"), LocalStringManager.GetConfig("MapLegend_language", "Desc_11"), "ui9_icon_roletype_2", showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(12, LocalStringManager.GetConfig("MapLegend_language", "Name_12"), LocalStringManager.GetConfig("MapLegend_language", "Desc_12"), "ui9_icon_roletype_3", showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(13, LocalStringManager.GetConfig("MapLegend_language", "Name_13"), LocalStringManager.GetConfig("MapLegend_language", "Desc_13"), "ui9_icon_roletype_4", showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(14, LocalStringManager.GetConfig("MapLegend_language", "Name_14"), LocalStringManager.GetConfig("MapLegend_language", "Desc_14"), "ui9_icon_roletype_5", showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(15, LocalStringManager.GetConfig("MapLegend_language", "Name_15"), LocalStringManager.GetConfig("MapLegend_language", "Desc_15"), "ui9_icon_roletype_6", showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(16, LocalStringManager.GetConfig("MapLegend_language", "Name_16"), LocalStringManager.GetConfig("MapLegend_language", "Desc_16"), "ui9_icon_roletype_7", showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(17, LocalStringManager.GetConfig("MapLegend_language", "Name_17"), LocalStringManager.GetConfig("MapLegend_language", "Desc_17"), "ui9_icon_largemap_legend_base_10", showInAreaMap: true));
		_dataArray.Add(new MapLegendItem(18, LocalStringManager.GetConfig("MapLegend_language", "Name_18"), LocalStringManager.GetConfig("MapLegend_language", "Desc_18"), null, showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(19, LocalStringManager.GetConfig("MapLegend_language", "Name_19"), LocalStringManager.GetConfig("MapLegend_language", "Desc_19"), null, showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(20, LocalStringManager.GetConfig("MapLegend_language", "Name_20"), LocalStringManager.GetConfig("MapLegend_language", "Desc_20"), null, showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(21, LocalStringManager.GetConfig("MapLegend_language", "Name_21"), LocalStringManager.GetConfig("MapLegend_language", "Desc_21"), null, showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(22, LocalStringManager.GetConfig("MapLegend_language", "Name_22"), LocalStringManager.GetConfig("MapLegend_language", "Desc_22"), null, showInAreaMap: false));
		_dataArray.Add(new MapLegendItem(23, LocalStringManager.GetConfig("MapLegend_language", "Name_23"), LocalStringManager.GetConfig("MapLegend_language", "Desc_23"), "ui9_icon_largemap_legend_base_11", showInAreaMap: true));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MapLegendItem>(24);
		CreateItems0();
	}
}

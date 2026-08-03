using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MapState : ConfigData<MapStateItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 无名之地
		/// </summary>
		public const sbyte NoName = 0;

		/// <summary>
		/// 京畿
		/// </summary>
		public const sbyte Jingji = 1;

		/// <summary>
		/// 巴蜀
		/// </summary>
		public const sbyte Bashu = 2;

		/// <summary>
		/// 广南
		/// </summary>
		public const sbyte Guangnan = 3;

		/// <summary>
		/// 荆北
		/// </summary>
		public const sbyte Jingbei = 4;

		/// <summary>
		/// 山西
		/// </summary>
		public const sbyte Shanxi = 5;

		/// <summary>
		/// 广东
		/// </summary>
		public const sbyte Guangdong = 6;

		/// <summary>
		/// 山东
		/// </summary>
		public const sbyte Shandong = 7;

		/// <summary>
		/// 荆南
		/// </summary>
		public const sbyte Jingnan = 8;

		/// <summary>
		/// 福建
		/// </summary>
		public const sbyte Fujian = 9;

		/// <summary>
		/// 辽东
		/// </summary>
		public const sbyte Liaodong = 10;

		/// <summary>
		/// 西域
		/// </summary>
		public const sbyte Xiyu = 11;

		/// <summary>
		/// 云南
		/// </summary>
		public const sbyte Yunnan = 12;

		/// <summary>
		/// 淮南
		/// </summary>
		public const sbyte Huainan = 13;

		/// <summary>
		/// 江南
		/// </summary>
		public const sbyte Jiangnan = 14;

		/// <summary>
		/// 江北
		/// </summary>
		public const sbyte Jiangbei = 15;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 无名之地
		/// </summary>
		public static MapStateItem NoName => Instance[(sbyte)0];

		/// <summary>
		/// 京畿
		/// </summary>
		public static MapStateItem Jingji => Instance[(sbyte)1];

		/// <summary>
		/// 巴蜀
		/// </summary>
		public static MapStateItem Bashu => Instance[(sbyte)2];

		/// <summary>
		/// 广南
		/// </summary>
		public static MapStateItem Guangnan => Instance[(sbyte)3];

		/// <summary>
		/// 荆北
		/// </summary>
		public static MapStateItem Jingbei => Instance[(sbyte)4];

		/// <summary>
		/// 山西
		/// </summary>
		public static MapStateItem Shanxi => Instance[(sbyte)5];

		/// <summary>
		/// 广东
		/// </summary>
		public static MapStateItem Guangdong => Instance[(sbyte)6];

		/// <summary>
		/// 山东
		/// </summary>
		public static MapStateItem Shandong => Instance[(sbyte)7];

		/// <summary>
		/// 荆南
		/// </summary>
		public static MapStateItem Jingnan => Instance[(sbyte)8];

		/// <summary>
		/// 福建
		/// </summary>
		public static MapStateItem Fujian => Instance[(sbyte)9];

		/// <summary>
		/// 辽东
		/// </summary>
		public static MapStateItem Liaodong => Instance[(sbyte)10];

		/// <summary>
		/// 西域
		/// </summary>
		public static MapStateItem Xiyu => Instance[(sbyte)11];

		/// <summary>
		/// 云南
		/// </summary>
		public static MapStateItem Yunnan => Instance[(sbyte)12];

		/// <summary>
		/// 淮南
		/// </summary>
		public static MapStateItem Huainan => Instance[(sbyte)13];

		/// <summary>
		/// 江南
		/// </summary>
		public static MapStateItem Jiangnan => Instance[(sbyte)14];

		/// <summary>
		/// 江北
		/// </summary>
		public static MapStateItem Jiangbei => Instance[(sbyte)15];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static MapState Instance = new MapState();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "MainAreaID", "SectAreaID", "SectID", "CricketAffix", "TemplateCharacterIds", "NeighborStates", "TemplateId", "MiniMap", "Bgm",
		"BirthSound"
	};

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
		_dataArray.Add(new MapStateItem(0, LocalStringManager.GetConfig("MapState_language", "Name_0"), 0, 0, 0, 21, new short[2] { -1, -1 }, new byte[0], new sbyte[0], 0, null, new short[0], new short[0], "main_fushixun", null, new float[2], new float[2]));
		_dataArray.Add(new MapStateItem(1, LocalStringManager.GetConfig("MapState_language", "Name_1"), 1, 16, 1, 6, new short[2] { 0, 1 }, new byte[4] { 0, 1, 2, 3 }, new sbyte[6] { 10, 7, 15, 13, 4, 5 }, 8, "largemap_part_2_map_7", new short[5] { 500, 500, 600, 500, 150 }, new short[5] { 80, 80, 150, 80, 60 }, "state_jingji", "ui_birthplace_shaolinpai", new float[2] { 1039.5f, 1729.5f }, new float[2]));
		_dataArray.Add(new MapStateItem(2, LocalStringManager.GetConfig("MapState_language", "Name_2"), 2, 17, 2, 7, new short[2] { 2, 3 }, new byte[5] { 0, 1, 2, 3, 5 }, new sbyte[5] { 11, 4, 8, 3, 12 }, 12, "largemap_part_2_map_0", new short[5] { 100, 600, 500, 500, 500 }, new short[5] { 40, 150, 80, 80, 80 }, "state_bashu", "ui_birthplace_emeipai", new float[2] { -2250.5f, 220.5f }, new float[2]));
		_dataArray.Add(new MapStateItem(3, LocalStringManager.GetConfig("MapState_language", "Name_3"), 3, 18, 3, 8, new short[2] { 4, 5 }, new byte[5] { 0, 1, 2, 3, 4 }, new sbyte[4] { 12, 2, 8, 6 }, 10, "largemap_part_2_map_3", new short[5] { 500, 125, 500, 650, 500 }, new short[5] { 80, 50, 80, 200, 80 }, "state_guangnan", "ui_birthplace_baihuagu", new float[2] { -1372.5f, -2387.5f }, new float[2]));
		_dataArray.Add(new MapStateItem(4, LocalStringManager.GetConfig("MapState_language", "Name_4"), 4, 19, 4, 9, new short[2] { 6, 7 }, new byte[4] { 0, 1, 2, 3 }, new sbyte[6] { 1, 13, 8, 2, 11, 5 }, 8, "largemap_part_2_map_8", new short[5] { 500, 500, 500, 150, 600 }, new short[5] { 80, 80, 80, 60, 150 }, "state_jinbei", "ui_birthplace_wudangpai", new float[2] { -8.5f, -63.5f }, new float[2]));
		_dataArray.Add(new MapStateItem(5, LocalStringManager.GetConfig("MapState_language", "Name_5"), 5, 20, 5, 10, new short[2] { 8, 9 }, new byte[5] { 0, 1, 2, 3, 5 }, new sbyte[3] { 1, 4, 11 }, 10, "largemap_part_2_map_12", new short[5] { 650, 500, 125, 500, 600 }, new short[5] { 200, 80, 50, 80, 80 }, "state_shanxi", "ui_birthplace_yuanshanpai", new float[2] { 371f, 2114f }, new float[2]));
		_dataArray.Add(new MapStateItem(6, LocalStringManager.GetConfig("MapState_language", "Name_6"), 6, 21, 6, 11, new short[2] { 10, 11 }, new byte[5] { 0, 1, 2, 3, 4 }, new sbyte[4] { 13, 9, 3, 8 }, 8, "largemap_part_2_map_2", new short[5] { 125, 500, 650, 500, 500 }, new short[5] { 50, 80, 200, 80, 80 }, "state_guangdong", "ui_birthplace_shixiangmen", new float[2] { 40f, -2413f }, new float[2]));
		_dataArray.Add(new MapStateItem(7, LocalStringManager.GetConfig("MapState_language", "Name_7"), 7, 22, 7, 12, new short[2] { 12, 13 }, new byte[6] { 0, 1, 2, 3, 4, 5 }, new sbyte[3] { 10, 15, 1 }, 6, "largemap_part_2_map_11", new short[5] { 500, 700, 500, 100, 500 }, new short[5] { 80, 250, 80, 40, 80 }, "state_shandong", "ui_birthplace_ranshanpai", new float[2] { 2541f, 1636f }, new float[2]));
		_dataArray.Add(new MapStateItem(8, LocalStringManager.GetConfig("MapState_language", "Name_8"), 8, 23, 8, 13, new short[2] { 14, 15 }, new byte[5] { 0, 1, 2, 3, 5 }, new sbyte[5] { 4, 13, 6, 3, 2 }, 8, "largemap_part_2_map_9", new short[5] { 500, 500, 500, 700, 125 }, new short[5] { 80, 80, 80, 250, 50 }, "state_jinnan", "ui_birthplace_xuannvpai", new float[2] { -224f, -789f }, new float[2]));
		_dataArray.Add(new MapStateItem(9, LocalStringManager.GetConfig("MapState_language", "Name_9"), 9, 24, 9, 14, new short[2] { 16, 17 }, new byte[5] { 0, 1, 2, 3, 4 }, new sbyte[3] { 14, 6, 13 }, 6, "largemap_part_2_map_1", new short[5] { 500, 150, 700, 500, 500 }, new short[5] { 80, 60, 250, 80, 80 }, "state_fujian", "ui_birthplace_zhujianshanzhuang", new float[2] { 1787f, -2370f }, new float[2]));
		_dataArray.Add(new MapStateItem(10, LocalStringManager.GetConfig("MapState_language", "Name_10"), 10, 25, 10, 15, new short[2] { 18, 19 }, new byte[6] { 0, 1, 2, 3, 4, 5 }, new sbyte[2] { 7, 1 }, 12, "largemap_part_2_map_10", new short[5] { 500, 500, 500, 125, 650 }, new short[5] { 80, 80, 80, 50, 200 }, "state_liaodong", "ui_birthplace_kongsangpai", new float[2] { 3459f, 2518.5f }, new float[2]));
		_dataArray.Add(new MapStateItem(11, LocalStringManager.GetConfig("MapState_language", "Name_11"), 11, 26, 11, 16, new short[2] { 20, 21 }, new byte[5] { 0, 1, 2, 3, 5 }, new sbyte[3] { 5, 4, 2 }, 10, "largemap_part_2_map_13", new short[5] { 700, 500, 100, 500, 500 }, new short[5] { 250, 80, 40, 80, 80 }, "state_xiyu", "ui_birthplace_jingangzong", new float[2] { -1888.5f, 2240.5f }, new float[2]));
		_dataArray.Add(new MapStateItem(12, LocalStringManager.GetConfig("MapState_language", "Name_12"), 12, 27, 12, 17, new short[2] { 22, 23 }, new byte[5] { 0, 1, 2, 3, 5 }, new sbyte[2] { 2, 3 }, 12, "largemap_part_2_map_14", new short[5] { 500, 650, 500, 500, 100 }, new short[5] { 80, 200, 80, 80, 40 }, "state_yunnan", "ui_birthplace_wuxianjiao", new float[2] { -3347f, -1102f }, new float[2]));
		_dataArray.Add(new MapStateItem(13, LocalStringManager.GetConfig("MapState_language", "Name_13"), 13, 28, 13, 18, new short[2] { 24, 25 }, new byte[4] { 0, 1, 2, 3 }, new sbyte[7] { 1, 15, 14, 9, 6, 8, 4 }, 8, "largemap_part_2_map_4", new short[5] { 500, 100, 500, 600, 500 }, new short[5] { 80, 40, 80, 150, 80 }, "state_huainan", "ui_birthplace_jieqingmen", new float[2] { 1268.5f, -845.5f }, new float[2]));
		_dataArray.Add(new MapStateItem(14, LocalStringManager.GetConfig("MapState_language", "Name_14"), 14, 29, 14, 19, new short[2] { 26, 27 }, new byte[5] { 0, 1, 2, 3, 4 }, new sbyte[3] { 15, 9, 13 }, 6, "largemap_part_2_map_6", new short[5] { 600, 500, 150, 500, 500 }, new short[5] { 150, 80, 60, 80, 80 }, "state_jiangnan", "ui_birthplace_fulongtan", new float[2] { 2514.5f, -974.5f }, new float[2]));
		_dataArray.Add(new MapStateItem(15, LocalStringManager.GetConfig("MapState_language", "Name_15"), 15, 30, 15, 20, new short[2] { 28, 29 }, new byte[5] { 0, 1, 2, 3, 4 }, new sbyte[4] { 7, 1, 13, 14 }, 6, "largemap_part_2_map_5", new short[5] { 150, 500, 500, 500, 700 }, new short[5] { 60, 80, 80, 80, 250 }, "state_jiangbei", "ui_birthplace_xuehoujiao", new float[2] { 2271.5f, 309f }, new float[2]));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MapStateItem>(16);
		CreateItems0();
	}
}

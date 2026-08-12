using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Jiao : ConfigData<JiaoItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 白蛟
		/// </summary>
		public const short JiaoWhite = 0;

		/// <summary>
		/// 黑蛟
		/// </summary>
		public const short JiaoBlack = 1;

		/// <summary>
		/// 青蛟
		/// </summary>
		public const short JiaoGreen = 2;

		/// <summary>
		/// 赤蛟
		/// </summary>
		public const short JiaoRed = 3;

		/// <summary>
		/// 黄蛟
		/// </summary>
		public const short JiaoYellow = 4;

		/// <summary>
		/// 白黑蛟
		/// </summary>
		public const short JiaoWB = 5;

		/// <summary>
		/// 白青蛟
		/// </summary>
		public const short JiaoWG = 6;

		/// <summary>
		/// 白赤蛟
		/// </summary>
		public const short JiaoWR = 7;

		/// <summary>
		/// 白黄蛟
		/// </summary>
		public const short JiaoWY = 8;

		/// <summary>
		/// 黑青蛟
		/// </summary>
		public const short JiaoBG = 9;

		/// <summary>
		/// 黑赤蛟
		/// </summary>
		public const short JiaoBR = 10;

		/// <summary>
		/// 黑黄蛟
		/// </summary>
		public const short JiaoBY = 11;

		/// <summary>
		/// 青赤蛟
		/// </summary>
		public const short JiaoGR = 12;

		/// <summary>
		/// 青黄蛟
		/// </summary>
		public const short JiaoGY = 13;

		/// <summary>
		/// 赤黄蛟
		/// </summary>
		public const short JiaoRY = 14;

		/// <summary>
		/// 白黑青蛟
		/// </summary>
		public const short JiaoWBG = 15;

		/// <summary>
		/// 白黑赤蛟
		/// </summary>
		public const short JiaoWBR = 16;

		/// <summary>
		/// 白黑黄蛟
		/// </summary>
		public const short JiaoWBY = 17;

		/// <summary>
		/// 白青赤蛟
		/// </summary>
		public const short JiaoWGR = 18;

		/// <summary>
		/// 白青黄蛟
		/// </summary>
		public const short JiaoWGY = 19;

		/// <summary>
		/// 白赤黄蛟
		/// </summary>
		public const short JiaoWRY = 20;

		/// <summary>
		/// 黑青赤蛟
		/// </summary>
		public const short JiaoBGR = 21;

		/// <summary>
		/// 黑青黄蛟
		/// </summary>
		public const short JiaoBGY = 22;

		/// <summary>
		/// 黑赤黄蛟
		/// </summary>
		public const short JiaoBRY = 23;

		/// <summary>
		/// 青赤黄蛟
		/// </summary>
		public const short JiaoGRY = 24;

		/// <summary>
		/// 白黑青赤蛟
		/// </summary>
		public const short JiaoWBGR = 25;

		/// <summary>
		/// 白黑青黄蛟
		/// </summary>
		public const short JiaoWBGY = 26;

		/// <summary>
		/// 白黑赤黄蛟
		/// </summary>
		public const short JiaoWBRY = 27;

		/// <summary>
		/// 白青赤黄蛟
		/// </summary>
		public const short JiaoWGRY = 28;

		/// <summary>
		/// 黑青赤黄蛟
		/// </summary>
		public const short JiaoBGRY = 29;

		/// <summary>
		/// 白青赤黄黑蛟
		/// </summary>
		public const short JiaoWGRYB = 30;

		/// <summary>
		/// 囚牛
		/// </summary>
		public const short Qiuniu = 31;

		/// <summary>
		/// 睚眦
		/// </summary>
		public const short Yazi = 32;

		/// <summary>
		/// 嘲风
		/// </summary>
		public const short Chaofeng = 33;

		/// <summary>
		/// 蒲牢
		/// </summary>
		public const short Pulao = 34;

		/// <summary>
		/// 狻猊
		/// </summary>
		public const short Suanni = 35;

		/// <summary>
		/// 霸下
		/// </summary>
		public const short Baxia = 36;

		/// <summary>
		/// 狴犴
		/// </summary>
		public const short Bian = 37;

		/// <summary>
		/// 负屃
		/// </summary>
		public const short Fuxi = 38;

		/// <summary>
		/// 螭吻
		/// </summary>
		public const short Chiwen = 39;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 白蛟
		/// </summary>
		public static JiaoItem JiaoWhite => Instance[(short)0];

		/// <summary>
		/// 黑蛟
		/// </summary>
		public static JiaoItem JiaoBlack => Instance[(short)1];

		/// <summary>
		/// 青蛟
		/// </summary>
		public static JiaoItem JiaoGreen => Instance[(short)2];

		/// <summary>
		/// 赤蛟
		/// </summary>
		public static JiaoItem JiaoRed => Instance[(short)3];

		/// <summary>
		/// 黄蛟
		/// </summary>
		public static JiaoItem JiaoYellow => Instance[(short)4];

		/// <summary>
		/// 白黑蛟
		/// </summary>
		public static JiaoItem JiaoWB => Instance[(short)5];

		/// <summary>
		/// 白青蛟
		/// </summary>
		public static JiaoItem JiaoWG => Instance[(short)6];

		/// <summary>
		/// 白赤蛟
		/// </summary>
		public static JiaoItem JiaoWR => Instance[(short)7];

		/// <summary>
		/// 白黄蛟
		/// </summary>
		public static JiaoItem JiaoWY => Instance[(short)8];

		/// <summary>
		/// 黑青蛟
		/// </summary>
		public static JiaoItem JiaoBG => Instance[(short)9];

		/// <summary>
		/// 黑赤蛟
		/// </summary>
		public static JiaoItem JiaoBR => Instance[(short)10];

		/// <summary>
		/// 黑黄蛟
		/// </summary>
		public static JiaoItem JiaoBY => Instance[(short)11];

		/// <summary>
		/// 青赤蛟
		/// </summary>
		public static JiaoItem JiaoGR => Instance[(short)12];

		/// <summary>
		/// 青黄蛟
		/// </summary>
		public static JiaoItem JiaoGY => Instance[(short)13];

		/// <summary>
		/// 赤黄蛟
		/// </summary>
		public static JiaoItem JiaoRY => Instance[(short)14];

		/// <summary>
		/// 白黑青蛟
		/// </summary>
		public static JiaoItem JiaoWBG => Instance[(short)15];

		/// <summary>
		/// 白黑赤蛟
		/// </summary>
		public static JiaoItem JiaoWBR => Instance[(short)16];

		/// <summary>
		/// 白黑黄蛟
		/// </summary>
		public static JiaoItem JiaoWBY => Instance[(short)17];

		/// <summary>
		/// 白青赤蛟
		/// </summary>
		public static JiaoItem JiaoWGR => Instance[(short)18];

		/// <summary>
		/// 白青黄蛟
		/// </summary>
		public static JiaoItem JiaoWGY => Instance[(short)19];

		/// <summary>
		/// 白赤黄蛟
		/// </summary>
		public static JiaoItem JiaoWRY => Instance[(short)20];

		/// <summary>
		/// 黑青赤蛟
		/// </summary>
		public static JiaoItem JiaoBGR => Instance[(short)21];

		/// <summary>
		/// 黑青黄蛟
		/// </summary>
		public static JiaoItem JiaoBGY => Instance[(short)22];

		/// <summary>
		/// 黑赤黄蛟
		/// </summary>
		public static JiaoItem JiaoBRY => Instance[(short)23];

		/// <summary>
		/// 青赤黄蛟
		/// </summary>
		public static JiaoItem JiaoGRY => Instance[(short)24];

		/// <summary>
		/// 白黑青赤蛟
		/// </summary>
		public static JiaoItem JiaoWBGR => Instance[(short)25];

		/// <summary>
		/// 白黑青黄蛟
		/// </summary>
		public static JiaoItem JiaoWBGY => Instance[(short)26];

		/// <summary>
		/// 白黑赤黄蛟
		/// </summary>
		public static JiaoItem JiaoWBRY => Instance[(short)27];

		/// <summary>
		/// 白青赤黄蛟
		/// </summary>
		public static JiaoItem JiaoWGRY => Instance[(short)28];

		/// <summary>
		/// 黑青赤黄蛟
		/// </summary>
		public static JiaoItem JiaoBGRY => Instance[(short)29];

		/// <summary>
		/// 白青赤黄黑蛟
		/// </summary>
		public static JiaoItem JiaoWGRYB => Instance[(short)30];

		/// <summary>
		/// 囚牛
		/// </summary>
		public static JiaoItem Qiuniu => Instance[(short)31];

		/// <summary>
		/// 睚眦
		/// </summary>
		public static JiaoItem Yazi => Instance[(short)32];

		/// <summary>
		/// 嘲风
		/// </summary>
		public static JiaoItem Chaofeng => Instance[(short)33];

		/// <summary>
		/// 蒲牢
		/// </summary>
		public static JiaoItem Pulao => Instance[(short)34];

		/// <summary>
		/// 狻猊
		/// </summary>
		public static JiaoItem Suanni => Instance[(short)35];

		/// <summary>
		/// 霸下
		/// </summary>
		public static JiaoItem Baxia => Instance[(short)36];

		/// <summary>
		/// 狴犴
		/// </summary>
		public static JiaoItem Bian => Instance[(short)37];

		/// <summary>
		/// 负屃
		/// </summary>
		public static JiaoItem Fuxi => Instance[(short)38];

		/// <summary>
		/// 螭吻
		/// </summary>
		public static JiaoItem Chiwen => Instance[(short)39];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static Jiao Instance = new Jiao();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "AdvantageProperty", "IndexOfCharacterTemplate", "IndexOfCarrierTemplate", "IndexOfAnimalTemplate", "EggMaterial", "TeenagerMaterial", "TemplateId", "ShadowImage", "BellowSound" };

	internal override int ToInt(short value)
	{
		return value;
	}

	internal override short ToTemplateId(int value)
	{
		return (short)value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new JiaoItem(0, LocalStringManager.GetConfig("Jiao_language", "Name_0"), 2, 150, 500, 40, 0, 0, 0, 0, 0, 4650, 9300, 10, 4200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai" }, 256, 46, 39, 278, 309, null, null));
		_dataArray.Add(new JiaoItem(1, LocalStringManager.GetConfig("Jiao_language", "Name_1"), 2, 150, 500, 0, 0, 2, 0, 0, 0, 4650, 9300, 10, 4200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_hei" }, 257, 47, 40, 279, 310, null, null));
		_dataArray.Add(new JiaoItem(2, LocalStringManager.GetConfig("Jiao_language", "Name_2"), 2, 150, 500, 0, 0, 0, 60, 0, 0, 4650, 9300, 10, 4200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_qing" }, 258, 48, 41, 280, 311, null, null));
		_dataArray.Add(new JiaoItem(3, LocalStringManager.GetConfig("Jiao_language", "Name_3"), 2, 150, 500, 0, 0, 0, 0, 60, 30, 4650, 9300, 10, 4200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_hong" }, 259, 49, 42, 281, 312, null, null));
		_dataArray.Add(new JiaoItem(4, LocalStringManager.GetConfig("Jiao_language", "Name_4"), 2, 150, 500, 0, 12000, 0, 0, 0, 0, 4650, 9300, 10, 4200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_huang" }, 260, 50, 43, 282, 313, null, null));
		_dataArray.Add(new JiaoItem(5, LocalStringManager.GetConfig("Jiao_language", "Name_5"), 3, 200, 1500, 40, 0, 2, 0, 0, 0, 8400, 16800, 12, 5400, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_hei" }, 261, 51, 44, 283, 314, null, null));
		_dataArray.Add(new JiaoItem(6, LocalStringManager.GetConfig("Jiao_language", "Name_6"), 3, 200, 1500, 40, 0, 0, 60, 0, 0, 8400, 16800, 12, 5400, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_qing" }, 262, 52, 45, 284, 315, null, null));
		_dataArray.Add(new JiaoItem(7, LocalStringManager.GetConfig("Jiao_language", "Name_7"), 3, 200, 1500, 40, 0, 0, 0, 60, 30, 8400, 16800, 12, 5400, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_hong" }, 263, 53, 46, 285, 316, null, null));
		_dataArray.Add(new JiaoItem(8, LocalStringManager.GetConfig("Jiao_language", "Name_8"), 3, 200, 1500, 40, 12000, 0, 0, 0, 0, 8400, 16800, 12, 5400, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_huang" }, 264, 54, 47, 286, 317, null, null));
		_dataArray.Add(new JiaoItem(9, LocalStringManager.GetConfig("Jiao_language", "Name_9"), 3, 200, 1500, 0, 0, 2, 60, 0, 0, 8400, 16800, 12, 5400, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_qing" }, 265, 55, 48, 287, 318, null, null));
		_dataArray.Add(new JiaoItem(10, LocalStringManager.GetConfig("Jiao_language", "Name_10"), 3, 200, 1500, 0, 0, 2, 0, 60, 30, 8400, 16800, 12, 5400, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_hong" }, 266, 56, 49, 288, 319, null, null));
		_dataArray.Add(new JiaoItem(11, LocalStringManager.GetConfig("Jiao_language", "Name_11"), 3, 200, 1500, 0, 12000, 2, 0, 0, 0, 8400, 16800, 12, 5400, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_huang" }, 267, 57, 50, 289, 320, null, null));
		_dataArray.Add(new JiaoItem(12, LocalStringManager.GetConfig("Jiao_language", "Name_12"), 3, 200, 1500, 0, 0, 0, 60, 60, 30, 8400, 16800, 12, 5400, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_qing", "eff_building_jiaopool_wuse_3_hong" }, 268, 58, 51, 290, 321, null, null));
		_dataArray.Add(new JiaoItem(13, LocalStringManager.GetConfig("Jiao_language", "Name_13"), 3, 200, 1500, 0, 12000, 0, 60, 0, 0, 8400, 16800, 12, 5400, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_qing", "eff_building_jiaopool_wuse_3_huang" }, 269, 59, 52, 291, 322, null, null));
		_dataArray.Add(new JiaoItem(14, LocalStringManager.GetConfig("Jiao_language", "Name_14"), 3, 200, 1500, 0, 12000, 0, 0, 60, 30, 8400, 16800, 12, 5400, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_hong", "eff_building_jiaopool_wuse_3_huang" }, 270, 60, 53, 292, 323, null, null));
		_dataArray.Add(new JiaoItem(15, LocalStringManager.GetConfig("Jiao_language", "Name_15"), 4, 300, 2500, 40, 0, 2, 60, 0, 0, 13800, 27600, 14, 7200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_qing" }, 271, 61, 54, 293, 324, null, null));
		_dataArray.Add(new JiaoItem(16, LocalStringManager.GetConfig("Jiao_language", "Name_16"), 4, 300, 2500, 40, 0, 2, 0, 60, 30, 13800, 27600, 14, 7200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_hong" }, 272, 62, 55, 294, 325, null, null));
		_dataArray.Add(new JiaoItem(17, LocalStringManager.GetConfig("Jiao_language", "Name_17"), 4, 300, 2500, 40, 12000, 2, 0, 0, 0, 13800, 27600, 14, 7200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_huang" }, 273, 63, 56, 295, 326, null, null));
		_dataArray.Add(new JiaoItem(18, LocalStringManager.GetConfig("Jiao_language", "Name_18"), 4, 300, 2500, 40, 0, 0, 60, 60, 30, 13800, 27600, 14, 7200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_qing", "eff_building_jiaopool_wuse_3_hong" }, 274, 64, 57, 296, 327, null, null));
		_dataArray.Add(new JiaoItem(19, LocalStringManager.GetConfig("Jiao_language", "Name_19"), 4, 300, 2500, 40, 12000, 0, 60, 0, 0, 13800, 27600, 14, 7200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_qing", "eff_building_jiaopool_wuse_3_huang" }, 275, 65, 58, 297, 328, null, null));
		_dataArray.Add(new JiaoItem(20, LocalStringManager.GetConfig("Jiao_language", "Name_20"), 4, 300, 2500, 40, 12000, 0, 0, 60, 30, 13800, 27600, 14, 7200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_hong", "eff_building_jiaopool_wuse_3_huang" }, 276, 66, 59, 298, 329, null, null));
		_dataArray.Add(new JiaoItem(21, LocalStringManager.GetConfig("Jiao_language", "Name_21"), 4, 300, 2500, 0, 0, 2, 60, 60, 30, 13800, 27600, 14, 7200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_qing", "eff_building_jiaopool_wuse_3_hong" }, 277, 67, 60, 299, 330, null, null));
		_dataArray.Add(new JiaoItem(22, LocalStringManager.GetConfig("Jiao_language", "Name_22"), 4, 300, 2500, 0, 12000, 2, 60, 0, 0, 13800, 27600, 14, 7200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_qing", "eff_building_jiaopool_wuse_3_huang" }, 278, 68, 61, 300, 331, null, null));
		_dataArray.Add(new JiaoItem(23, LocalStringManager.GetConfig("Jiao_language", "Name_23"), 4, 300, 2500, 0, 12000, 2, 0, 60, 30, 13800, 27600, 14, 7200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_hong", "eff_building_jiaopool_wuse_3_huang" }, 279, 69, 62, 301, 332, null, null));
		_dataArray.Add(new JiaoItem(24, LocalStringManager.GetConfig("Jiao_language", "Name_24"), 4, 300, 2500, 0, 12000, 0, 60, 60, 30, 13800, 27600, 14, 7200, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_qing", "eff_building_jiaopool_wuse_3_hong", "eff_building_jiaopool_wuse_3_huang" }, 280, 70, 63, 302, 333, null, null));
		_dataArray.Add(new JiaoItem(25, LocalStringManager.GetConfig("Jiao_language", "Name_25"), 5, 400, 3500, 40, 0, 2, 60, 60, 30, 21150, 42300, 16, 9000, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_qing", "eff_building_jiaopool_wuse_3_hong" }, 281, 71, 64, 303, 334, null, null));
		_dataArray.Add(new JiaoItem(26, LocalStringManager.GetConfig("Jiao_language", "Name_26"), 5, 400, 3500, 40, 12000, 2, 60, 0, 0, 21150, 42300, 16, 9000, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_qing", "eff_building_jiaopool_wuse_3_huang" }, 282, 72, 65, 304, 335, null, null));
		_dataArray.Add(new JiaoItem(27, LocalStringManager.GetConfig("Jiao_language", "Name_27"), 5, 400, 3500, 40, 12000, 2, 0, 60, 30, 21150, 42300, 16, 9000, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_hong", "eff_building_jiaopool_wuse_3_huang" }, 283, 73, 66, 305, 336, null, null));
		_dataArray.Add(new JiaoItem(28, LocalStringManager.GetConfig("Jiao_language", "Name_28"), 5, 400, 3500, 40, 12000, 0, 60, 60, 30, 21150, 42300, 16, 9000, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_qing", "eff_building_jiaopool_wuse_3_hong", "eff_building_jiaopool_wuse_3_huang" }, 284, 74, 67, 306, 337, null, null));
		_dataArray.Add(new JiaoItem(29, LocalStringManager.GetConfig("Jiao_language", "Name_29"), 5, 400, 3500, 0, 12000, 2, 60, 60, 30, 21150, 42300, 16, 9000, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_qing", "eff_building_jiaopool_wuse_3_hong", "eff_building_jiaopool_wuse_3_huang" }, 285, 75, 68, 307, 338, null, null));
		_dataArray.Add(new JiaoItem(30, LocalStringManager.GetConfig("Jiao_language", "Name_30"), 5, 450, 4500, 40, 12000, 2, 60, 60, 30, 30750, 61500, 18, 10800, 8, -1, 0, 0, new List<string> { "eff_building_jiaopool_wuse_3_bai", "eff_building_jiaopool_wuse_3_hei", "eff_building_jiaopool_wuse_3_qing", "eff_building_jiaopool_wuse_3_hong", "eff_building_jiaopool_wuse_3_huang" }, 286, 76, 69, 308, 339, null, null));
		_dataArray.Add(new JiaoItem(31, LocalStringManager.GetConfig("Jiao_language", "Name_31"), -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 54, 0, 8, 7, 54, 30, new List<string> { "" }, 287, 77, 70, -1, -1, "NpcFace_shadow_qiuniu", "ui_building_jiaochi_hualong_chuxian_qiuniu"));
		_dataArray.Add(new JiaoItem(32, LocalStringManager.GetConfig("Jiao_language", "Name_32"), -1, -1, -1, 0, 0, 18, 0, 0, 0, 0, 0, 0, 0, 8, 4, 18, 30, new List<string> { "" }, 288, 78, 71, -1, -1, "NpcFace_shadow_yazi", "ui_building_jiaochi_hualong_chuxian_yazi"));
		_dataArray.Add(new JiaoItem(33, LocalStringManager.GetConfig("Jiao_language", "Name_33"), -1, -1, -1, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 90, 20, new List<string> { "" }, 289, 79, 72, -1, -1, "NpcFace_shadow_chaofeng", "ui_building_jiaochi_hualong_chuxian_chaofeng"));
		_dataArray.Add(new JiaoItem(34, LocalStringManager.GetConfig("Jiao_language", "Name_34"), -1, -1, -1, 0, 0, 0, 200, 0, 0, 0, 0, 0, 0, 8, 2, 200, 30, new List<string> { "" }, 290, 80, 73, -1, -1, "NpcFace_shadow_pulao", "ui_building_jiaochi_hualong_chuxian_pulao"));
		_dataArray.Add(new JiaoItem(35, LocalStringManager.GetConfig("Jiao_language", "Name_35"), -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 184500, 0, 0, 8, 6, 184500, 60, new List<string> { "" }, 291, 81, 74, -1, -1, "NpcFace_shadow_suanni", "ui_building_jiaochi_hualong_chuxian_suanni"));
		_dataArray.Add(new JiaoItem(36, LocalStringManager.GetConfig("Jiao_language", "Name_36"), -1, -1, -1, 0, 30000, 0, 0, 0, 0, 0, 0, 0, 0, 8, 1, 30000, 30, new List<string> { "" }, 292, 82, 75, -1, -1, "NpcFace_shadow_baxia", "ui_building_jiaochi_hualong_chuxian_baxia"));
		_dataArray.Add(new JiaoItem(37, LocalStringManager.GetConfig("Jiao_language", "Name_37"), -1, -1, -1, 0, 0, 0, 0, 200, 0, 0, 0, 0, 0, 8, 3, 200, 20, new List<string> { "" }, 293, 83, 76, -1, -1, "NpcFace_shadow_bian", "ui_building_jiaochi_hualong_chuxian_bian"));
		_dataArray.Add(new JiaoItem(38, LocalStringManager.GetConfig("Jiao_language", "Name_38"), -1, -1, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 32400, 8, 8, 32400, 60, new List<string> { "" }, 294, 84, 77, -1, -1, "NpcFace_shadow_fuxi", "ui_building_jiaochi_hualong_chuxian_loong"));
		_dataArray.Add(new JiaoItem(39, LocalStringManager.GetConfig("Jiao_language", "Name_39"), -1, -1, -1, 0, 0, 0, 0, 0, 80, 0, 0, 0, 0, 8, 5, 80, 30, new List<string> { "" }, 295, 85, 78, -1, -1, "NpcFace_shadow_chiwen", "ui_building_jiaochi_hualong_chuxian_chiwen"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<JiaoItem>(40);
		CreateItems0();
	}
}

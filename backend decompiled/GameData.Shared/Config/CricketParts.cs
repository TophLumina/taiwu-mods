using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CricketParts : ConfigData<CricketPartsItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 呆物
		/// </summary>
		public const short Trash = 0;

		/// <summary>
		/// 绣花针
		/// </summary>
		public const short XiuHuaZhen = 1;

		/// <summary>
		/// 两头枪
		/// </summary>
		public const short LiangTouQiang = 2;

		/// <summary>
		/// 吹铃
		/// </summary>
		public const short ChuiLing = 3;

		/// <summary>
		/// 跑马黄
		/// </summary>
		public const short PaoMaHuang = 4;

		/// <summary>
		/// 玉锄头
		/// </summary>
		public const short YuChuTou = 5;

		/// <summary>
		/// 披袍轩甲
		/// </summary>
		public const short PiPaoXuanJia = 6;

		/// <summary>
		/// 反生名
		/// </summary>
		public const short FanShengMing = 7;

		/// <summary>
		/// 朱砂额
		/// </summary>
		public const short ZhuShaE = 8;

		/// <summary>
		/// 头陀
		/// </summary>
		public const short TouTuo = 9;

		/// <summary>
		/// 铁弹子
		/// </summary>
		public const short TieDanZi = 10;

		/// <summary>
		/// 赤须
		/// </summary>
		public const short ChiXu = 11;

		/// <summary>
		/// 玉尾
		/// </summary>
		public const short YuWei = 12;

		/// <summary>
		/// 油纸灯
		/// </summary>
		public const short YouZhiDeng = 13;

		/// <summary>
		/// 真三色
		/// </summary>
		public const short ZhenSanSe = 14;

		/// <summary>
		/// 草三段
		/// </summary>
		public const short CaoSanDuan = 15;

		/// <summary>
		/// 真紫黄
		/// </summary>
		public const short ZhenZiHuang = 16;

		/// <summary>
		/// 梅花翅
		/// </summary>
		public const short MeiHuaChi = 17;

		/// <summary>
		/// 天蓝青
		/// </summary>
		public const short TianLanQing = 18;

		/// <summary>
		/// 三段锦
		/// </summary>
		public const short SanDuanJin = 19;

		/// <summary>
		/// 三太子
		/// </summary>
		public const short SanTaiZi = 20;

		/// <summary>
		/// 八败
		/// </summary>
		public const short BaBai = 21;

		/// <summary>
		/// 真青
		/// </summary>
		public const short RealCyan = 22;

		/// <summary>
		/// 真黄
		/// </summary>
		public const short RealYellow = 23;

		/// <summary>
		/// 真紫
		/// </summary>
		public const short RealPurple = 24;

		/// <summary>
		/// 真红
		/// </summary>
		public const short RealRed = 25;

		/// <summary>
		/// 真乌
		/// </summary>
		public const short RealBlack = 26;

		/// <summary>
		/// 真白
		/// </summary>
		public const short RealWhite = 27;

		/// <summary>
		/// 尖头
		/// </summary>
		public const short SharpHead = 31;

		/// <summary>
		/// 圆翅
		/// </summary>
		public const short RoundWings = 46;

		/// <summary>
		/// 芝麻牙
		/// </summary>
		public const short SesameTeeth = 70;

		/// <summary>
		/// 正红
		/// </summary>
		public const short Red = 127;

		/// <summary>
		/// 正黑
		/// </summary>
		public const short Black = 133;

		/// <summary>
		/// 正白
		/// </summary>
		public const short White = 139;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 呆物
		/// </summary>
		public static CricketPartsItem Trash => Instance[(short)0];

		/// <summary>
		/// 绣花针
		/// </summary>
		public static CricketPartsItem XiuHuaZhen => Instance[(short)1];

		/// <summary>
		/// 两头枪
		/// </summary>
		public static CricketPartsItem LiangTouQiang => Instance[(short)2];

		/// <summary>
		/// 吹铃
		/// </summary>
		public static CricketPartsItem ChuiLing => Instance[(short)3];

		/// <summary>
		/// 跑马黄
		/// </summary>
		public static CricketPartsItem PaoMaHuang => Instance[(short)4];

		/// <summary>
		/// 玉锄头
		/// </summary>
		public static CricketPartsItem YuChuTou => Instance[(short)5];

		/// <summary>
		/// 披袍轩甲
		/// </summary>
		public static CricketPartsItem PiPaoXuanJia => Instance[(short)6];

		/// <summary>
		/// 反生名
		/// </summary>
		public static CricketPartsItem FanShengMing => Instance[(short)7];

		/// <summary>
		/// 朱砂额
		/// </summary>
		public static CricketPartsItem ZhuShaE => Instance[(short)8];

		/// <summary>
		/// 头陀
		/// </summary>
		public static CricketPartsItem TouTuo => Instance[(short)9];

		/// <summary>
		/// 铁弹子
		/// </summary>
		public static CricketPartsItem TieDanZi => Instance[(short)10];

		/// <summary>
		/// 赤须
		/// </summary>
		public static CricketPartsItem ChiXu => Instance[(short)11];

		/// <summary>
		/// 玉尾
		/// </summary>
		public static CricketPartsItem YuWei => Instance[(short)12];

		/// <summary>
		/// 油纸灯
		/// </summary>
		public static CricketPartsItem YouZhiDeng => Instance[(short)13];

		/// <summary>
		/// 真三色
		/// </summary>
		public static CricketPartsItem ZhenSanSe => Instance[(short)14];

		/// <summary>
		/// 草三段
		/// </summary>
		public static CricketPartsItem CaoSanDuan => Instance[(short)15];

		/// <summary>
		/// 真紫黄
		/// </summary>
		public static CricketPartsItem ZhenZiHuang => Instance[(short)16];

		/// <summary>
		/// 梅花翅
		/// </summary>
		public static CricketPartsItem MeiHuaChi => Instance[(short)17];

		/// <summary>
		/// 天蓝青
		/// </summary>
		public static CricketPartsItem TianLanQing => Instance[(short)18];

		/// <summary>
		/// 三段锦
		/// </summary>
		public static CricketPartsItem SanDuanJin => Instance[(short)19];

		/// <summary>
		/// 三太子
		/// </summary>
		public static CricketPartsItem SanTaiZi => Instance[(short)20];

		/// <summary>
		/// 八败
		/// </summary>
		public static CricketPartsItem BaBai => Instance[(short)21];

		/// <summary>
		/// 真青
		/// </summary>
		public static CricketPartsItem RealCyan => Instance[(short)22];

		/// <summary>
		/// 真黄
		/// </summary>
		public static CricketPartsItem RealYellow => Instance[(short)23];

		/// <summary>
		/// 真紫
		/// </summary>
		public static CricketPartsItem RealPurple => Instance[(short)24];

		/// <summary>
		/// 真红
		/// </summary>
		public static CricketPartsItem RealRed => Instance[(short)25];

		/// <summary>
		/// 真乌
		/// </summary>
		public static CricketPartsItem RealBlack => Instance[(short)26];

		/// <summary>
		/// 真白
		/// </summary>
		public static CricketPartsItem RealWhite => Instance[(short)27];

		/// <summary>
		/// 尖头
		/// </summary>
		public static CricketPartsItem SharpHead => Instance[(short)31];

		/// <summary>
		/// 圆翅
		/// </summary>
		public static CricketPartsItem RoundWings => Instance[(short)46];

		/// <summary>
		/// 芝麻牙
		/// </summary>
		public static CricketPartsItem SesameTeeth => Instance[(short)70];

		/// <summary>
		/// 正红
		/// </summary>
		public static CricketPartsItem Red => Instance[(short)127];

		/// <summary>
		/// 正黑
		/// </summary>
		public static CricketPartsItem Black => Instance[(short)133];

		/// <summary>
		/// 正白
		/// </summary>
		public static CricketPartsItem White => Instance[(short)139];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CricketParts Instance = new CricketParts();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "NameAtSecond", "Desc", "CricketPolymorphEvent", "Affix", "Skill", "CharacterMale", "CharacterFemale", "TemplateId", "Icon",
		"Color", "Taste", "PoetryTexture", "NameTexture"
	};

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
		_dataArray.Add(new CricketPartsItem(0, LocalStringManager.GetConfig("CricketParts_language", "Name_0"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_0"), ECricketPartsType.Trash, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_0"), 0, 0, 0, 1, 600, 2, 15, 150, 50, 30, 0, mustSuccessLoud: false, 0, 0, 8, null, 0, 20, 20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 968, 969, 10, 0, "ui9_tex_catchcricket_sucess_poetry_0", 0, "ui9_tex_catchcricket_name_0"));
		_dataArray.Add(new CricketPartsItem(1, LocalStringManager.GetConfig("CricketParts_language", "Name_1"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_1"), ECricketPartsType.King, "ui9_icon_cricket_2", LocalStringManager.GetConfig("CricketParts_language", "Desc_1"), 1, 8, 0, 6, 10800, 18, 30750, 30750, 0, 75, 28, mustSuccessLoud: true, 1, 0, -70, null, 2, 40, 50, 1, 1, 1, 85, 45, -10, 0, 0, 50, 1, 970, 971, 100, 0, "ui9_tex_catchcricket_sucess_poetry_1", 0, "ui9_tex_catchcricket_name_1"));
		_dataArray.Add(new CricketPartsItem(2, LocalStringManager.GetConfig("CricketParts_language", "Name_2"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_2"), ECricketPartsType.King, "ui9_icon_cricket_4", LocalStringManager.GetConfig("CricketParts_language", "Desc_2"), 2, 8, 0, 10, 10800, 18, 30750, 30750, 30, 95, 28, mustSuccessLoud: true, 1, 0, -70, null, 3, 110, 110, 7, 13, 7, 20, 8, 15, 0, 0, 100, 2, 972, 973, 100, 0, "ui9_tex_catchcricket_sucess_poetry_2", 0, "ui9_tex_catchcricket_name_2"));
		_dataArray.Add(new CricketPartsItem(3, LocalStringManager.GetConfig("CricketParts_language", "Name_3"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_3"), ECricketPartsType.King, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_3"), 3, 8, 0, 7, 10800, 18, 30750, 30750, -20, 150, 28, mustSuccessLoud: true, 1, 0, -70, null, 0, 80, 70, 22, 5, 6, 40, 5, 0, 0, 0, 40, 3, 974, 975, 100, 0, "ui9_tex_catchcricket_sucess_poetry_3", 0, "ui9_tex_catchcricket_name_3"));
		_dataArray.Add(new CricketPartsItem(4, LocalStringManager.GetConfig("CricketParts_language", "Name_4"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_4"), ECricketPartsType.King, "ui9_icon_cricket_4", LocalStringManager.GetConfig("CricketParts_language", "Desc_4"), 4, 8, 0, 12, 10800, 18, 30750, 30750, 50, 105, 28, mustSuccessLoud: true, 1, 0, -70, null, 3, 140, 150, 4, 7, 4, 55, 5, -5, 55, 10, 120, 4, 976, 977, 100, 0, "ui9_tex_catchcricket_sucess_poetry_4", 0, "ui9_tex_catchcricket_name_4"));
		_dataArray.Add(new CricketPartsItem(5, LocalStringManager.GetConfig("CricketParts_language", "Name_5"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_5"), ECricketPartsType.King, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_5"), 5, 8, 0, 10, 10800, 18, 30750, 30750, 60, 120, 14, mustSuccessLoud: true, 2, 0, -80, null, 0, 120, 120, 9, 12, 13, 25, 10, 10, 30, 8, 45, 5, 978, 979, 100, 0, "ui9_tex_catchcricket_sucess_poetry_5", 0, "ui9_tex_catchcricket_name_5"));
		_dataArray.Add(new CricketPartsItem(6, LocalStringManager.GetConfig("CricketParts_language", "Name_6"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_6"), ECricketPartsType.King, "ui9_icon_cricket_3", LocalStringManager.GetConfig("CricketParts_language", "Desc_6"), 6, 8, 0, 15, 10800, 18, 30750, 30750, 90, 110, 14, mustSuccessLoud: true, 2, 0, -80, null, 4, 280, 200, 6, 6, 6, 0, 0, 20, 80, 5, 70, 6, 980, 981, 100, 0, "ui9_tex_catchcricket_sucess_poetry_6", 0, "ui9_tex_catchcricket_name_6"));
		_dataArray.Add(new CricketPartsItem(7, LocalStringManager.GetConfig("CricketParts_language", "Name_7"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_7"), ECricketPartsType.King, "ui9_icon_cricket_2", LocalStringManager.GetConfig("CricketParts_language", "Desc_7"), 7, 8, 0, 9, 10800, 18, 30750, 30750, 35, 100, 14, mustSuccessLoud: true, 2, 0, -80, null, 2, 90, 90, 7, 11, 9, 65, 12, -15, 0, 0, 95, 7, 982, 983, 100, 0, "ui9_tex_catchcricket_sucess_poetry_7", 0, "ui9_tex_catchcricket_name_7"));
		_dataArray.Add(new CricketPartsItem(8, LocalStringManager.GetConfig("CricketParts_language", "Name_8"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_8"), ECricketPartsType.King, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_8"), 8, 8, 0, 10, 10800, 18, 30750, 30750, 55, 110, 14, mustSuccessLoud: true, 2, 0, -80, null, 0, 140, 100, 8, 9, 13, 30, 18, 0, 30, 8, 40, 8, 984, 985, 100, 0, "ui9_tex_catchcricket_sucess_poetry_8", 0, "ui9_tex_catchcricket_name_8"));
		_dataArray.Add(new CricketPartsItem(9, LocalStringManager.GetConfig("CricketParts_language", "Name_9"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_9"), ECricketPartsType.King, "ui9_icon_cricket_1", LocalStringManager.GetConfig("CricketParts_language", "Desc_9"), 9, 8, 0, 12, 10800, 18, 30750, 30750, 75, 0, 7, mustSuccessLoud: true, 3, 0, -90, null, 1, 180, 160, 6, 16, 10, 20, 10, 10, 45, 18, 45, 9, 986, 987, 100, 0, "ui9_tex_catchcricket_sucess_poetry_9", 0, "ui9_tex_catchcricket_name_9"));
		_dataArray.Add(new CricketPartsItem(10, LocalStringManager.GetConfig("CricketParts_language", "Name_10"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_10"), ECricketPartsType.King, "ui9_icon_cricket_1", LocalStringManager.GetConfig("CricketParts_language", "Desc_10"), 10, 8, 0, 10, 10800, 18, 30750, 30750, 80, 90, 7, mustSuccessLoud: true, 3, 0, -90, null, 1, 170, 170, 5, 24, 8, 0, 0, 30, 35, 10, 65, 10, 988, 989, 100, 0, "ui9_tex_catchcricket_sucess_poetry_10", 0, "ui9_tex_catchcricket_name_10"));
		_dataArray.Add(new CricketPartsItem(11, LocalStringManager.GetConfig("CricketParts_language", "Name_11"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_11"), ECricketPartsType.King, "ui9_icon_cricket_5", LocalStringManager.GetConfig("CricketParts_language", "Desc_11"), 11, 8, 0, 10, 10800, 18, 30750, 30750, 70, 130, 7, mustSuccessLoud: true, 3, 0, -90, null, 5, 190, 130, 8, 10, 10, 35, 18, 5, 30, 8, 50, 11, 990, 991, 100, 0, "ui9_tex_catchcricket_sucess_poetry_11", 0, "ui9_tex_catchcricket_name_11"));
		_dataArray.Add(new CricketPartsItem(12, LocalStringManager.GetConfig("CricketParts_language", "Name_12"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_12"), ECricketPartsType.King, "ui9_icon_cricket_3", LocalStringManager.GetConfig("CricketParts_language", "Desc_12"), 12, 8, 0, 8, 10800, 18, 30750, 30750, 45, 105, 7, mustSuccessLoud: true, 3, 0, -90, null, 4, 90, 90, 4, 3, 24, 40, 24, 0, 0, 0, 40, 12, 992, 993, 100, 0, "ui9_tex_catchcricket_sucess_poetry_12", 0, "ui9_tex_catchcricket_name_12"));
		_dataArray.Add(new CricketPartsItem(13, LocalStringManager.GetConfig("CricketParts_language", "Name_13"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_13"), ECricketPartsType.King, "ui9_icon_cricket_4", LocalStringManager.GetConfig("CricketParts_language", "Desc_13"), 13, 8, 0, 12, 10800, 18, 30750, 30750, 75, 135, 6, mustSuccessLoud: true, 3, 0, -100, null, 3, 180, 120, 8, 15, 15, 25, 8, 10, 60, 8, 75, 13, 994, 995, 100, 0, "ui9_tex_catchcricket_sucess_poetry_13", 0, "ui9_tex_catchcricket_name_13"));
		_dataArray.Add(new CricketPartsItem(14, LocalStringManager.GetConfig("CricketParts_language", "Name_14"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_14"), ECricketPartsType.King, "ui9_icon_cricket_5", LocalStringManager.GetConfig("CricketParts_language", "Desc_14"), 14, 8, 0, 12, 10800, 18, 30750, 30750, 85, 145, 6, mustSuccessLoud: true, 2, 0, -100, null, 5, 220, 180, 13, 10, 12, 20, 10, 0, 45, 10, 40, 14, 996, 997, 100, 0, "ui9_tex_catchcricket_sucess_poetry_14", 0, "ui9_tex_catchcricket_name_14"));
		_dataArray.Add(new CricketPartsItem(15, LocalStringManager.GetConfig("CricketParts_language", "Name_15"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_15"), ECricketPartsType.King, "ui9_icon_cricket_2", LocalStringManager.GetConfig("CricketParts_language", "Desc_15"), 15, 8, 0, 10, 10800, 18, 30750, 30750, 65, 130, 6, mustSuccessLoud: true, 2, 0, -100, null, 2, 150, 200, 10, 9, 11, 45, 14, 0, 25, 15, 55, 15, 998, 999, 100, 0, "ui9_tex_catchcricket_sucess_poetry_15", 0, "ui9_tex_catchcricket_name_15"));
		_dataArray.Add(new CricketPartsItem(16, LocalStringManager.GetConfig("CricketParts_language", "Name_16"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_16"), ECricketPartsType.King, "ui9_icon_cricket_4", LocalStringManager.GetConfig("CricketParts_language", "Desc_16"), 16, 8, 0, 12, 10800, 18, 30750, 30750, 60, 150, 6, mustSuccessLoud: true, 2, 0, -100, null, 3, 160, 190, 11, 12, 10, 25, 20, 20, 20, 20, 45, 16, 1000, 1001, 100, 0, "ui9_tex_catchcricket_sucess_poetry_16", 0, "ui9_tex_catchcricket_name_16"));
		_dataArray.Add(new CricketPartsItem(17, LocalStringManager.GetConfig("CricketParts_language", "Name_17"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_17"), ECricketPartsType.King, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_17"), 17, 8, 0, 7, 10800, 18, 30750, 30750, 0, 160, 5, mustSuccessLoud: true, 2, 0, -110, null, 0, 90, 140, 24, 1, 14, 70, 10, -20, 0, 0, 80, 17, 1002, 1003, 100, 0, "ui9_tex_catchcricket_sucess_poetry_17", 0, "ui9_tex_catchcricket_name_17"));
		_dataArray.Add(new CricketPartsItem(18, LocalStringManager.GetConfig("CricketParts_language", "Name_18"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_18"), ECricketPartsType.King, "ui9_icon_cricket_5", LocalStringManager.GetConfig("CricketParts_language", "Desc_18"), 18, 8, 0, 15, 10800, 18, 30750, 30750, 80, 155, 4, mustSuccessLoud: true, 1, 0, -120, null, 5, 290, 290, 12, 11, 13, 35, 15, 0, 35, 15, 45, 18, 1004, 1005, 100, 0, "ui9_tex_catchcricket_sucess_poetry_18", 0, "ui9_tex_catchcricket_name_18"));
		_dataArray.Add(new CricketPartsItem(19, LocalStringManager.GetConfig("CricketParts_language", "Name_19"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_19"), ECricketPartsType.King, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_19"), 19, 8, 0, 10, 10800, 18, 30750, 30750, 55, 145, 3, mustSuccessLoud: true, 1, 0, -130, null, 0, 150, 150, 20, 20, 20, 50, 20, 0, 30, 10, 50, 19, 1006, 1007, 100, 0, "ui9_tex_catchcricket_sucess_poetry_19", 0, "ui9_tex_catchcricket_name_19"));
		_dataArray.Add(new CricketPartsItem(20, LocalStringManager.GetConfig("CricketParts_language", "Name_20"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_20"), ECricketPartsType.King, "ui9_icon_cricket_2", LocalStringManager.GetConfig("CricketParts_language", "Desc_20"), 20, 8, 0, 9, 10800, 18, 30750, 30750, 70, 125, 2, mustSuccessLoud: true, 1, 0, -140, null, 2, 80, 460, 8, 7, 9, 65, 10, 15, 75, 50, 85, 20, 1008, 1009, 100, 0, "ui9_tex_catchcricket_sucess_poetry_20", 0, "ui9_tex_catchcricket_name_20"));
		_dataArray.Add(new CricketPartsItem(21, LocalStringManager.GetConfig("CricketParts_language", "Name_21"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_21"), ECricketPartsType.King, "ui9_icon_cricket_1", LocalStringManager.GetConfig("CricketParts_language", "Desc_21"), 21, 8, 0, 12, 10800, 18, 30750, 30750, 100, 110, 1, mustSuccessLoud: true, 1, 0, -150, null, 1, 180, 800, 1, 1, 1, 95, 1, -55, 95, 25, 800, 21, 1010, 1011, 100, 0, "ui9_tex_catchcricket_sucess_poetry_21", 0, "ui9_tex_catchcricket_name_21"));
		_dataArray.Add(new CricketPartsItem(22, LocalStringManager.GetConfig("CricketParts_language", "Name_22"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_22"), ECricketPartsType.RealColor, "ui9_icon_cricket_5", LocalStringManager.GetConfig("CricketParts_language", "Desc_22"), 0, 7, 0, 10, 9000, 16, 21150, 21150, 80, 125, 1, mustSuccessLoud: true, 0, 0, -60, null, 5, 200, 150, 10, 11, 12, 15, 5, 15, 35, 10, 65, -1, -1, -1, 80, 0, "ui9_tex_catchcricket_sucess_poetry_22", 0, "ui9_tex_catchcricket_name_22"));
		_dataArray.Add(new CricketPartsItem(23, LocalStringManager.GetConfig("CricketParts_language", "Name_23"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_23"), ECricketPartsType.RealColor, "ui9_icon_cricket_4", LocalStringManager.GetConfig("CricketParts_language", "Desc_23"), 0, 7, 0, 10, 9000, 16, 21150, 21150, 70, 120, 1, mustSuccessLoud: true, 0, 0, -60, null, 3, 150, 200, 9, 13, 10, 25, 8, 10, 30, 12, 45, -1, -1, -1, 80, 0, "ui9_tex_catchcricket_sucess_poetry_23", 0, "ui9_tex_catchcricket_name_23"));
		_dataArray.Add(new CricketPartsItem(24, LocalStringManager.GetConfig("CricketParts_language", "Name_24"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_24"), ECricketPartsType.RealColor, "ui9_icon_cricket_3", LocalStringManager.GetConfig("CricketParts_language", "Desc_24"), 0, 7, 0, 10, 9000, 16, 21150, 21150, 60, 115, 1, mustSuccessLoud: true, 0, 0, -60, null, 4, 140, 140, 11, 8, 11, 35, 10, 5, 25, 15, 50, -1, -1, -1, 80, 0, "ui9_tex_catchcricket_sucess_poetry_24", 0, "ui9_tex_catchcricket_name_24"));
		_dataArray.Add(new CricketPartsItem(25, LocalStringManager.GetConfig("CricketParts_language", "Name_25"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_25"), ECricketPartsType.RealColor, "ui9_icon_cricket_2", LocalStringManager.GetConfig("CricketParts_language", "Desc_25"), 0, 7, 0, 10, 9000, 16, 21150, 21150, 50, 110, 2, mustSuccessLoud: true, 0, 0, -60, null, 2, 100, 100, 6, 6, 15, 50, 14, -5, 0, 0, 55, -1, -1, -1, 80, 0, "ui9_tex_catchcricket_sucess_poetry_25", 0, "ui9_tex_catchcricket_name_25"));
		_dataArray.Add(new CricketPartsItem(26, LocalStringManager.GetConfig("CricketParts_language", "Name_26"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_26"), ECricketPartsType.RealColor, "ui9_icon_cricket_1", LocalStringManager.GetConfig("CricketParts_language", "Desc_26"), 0, 7, 0, 10, 9000, 16, 21150, 21150, 40, 105, 2, mustSuccessLoud: true, 0, 0, -60, null, 1, 130, 90, 7, 15, 9, 20, 5, 5, 50, 8, 80, -1, -1, -1, 80, 0, "ui9_tex_catchcricket_sucess_poetry_26", 0, "ui9_tex_catchcricket_name_26"));
		_dataArray.Add(new CricketPartsItem(27, LocalStringManager.GetConfig("CricketParts_language", "Name_27"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_27"), ECricketPartsType.RealColor, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_27"), 0, 7, 0, 10, 9000, 16, 21150, 21150, 30, 100, 2, mustSuccessLoud: true, 0, 0, -60, null, 0, 90, 130, 15, 4, 8, 45, 12, -10, 0, 0, 60, -1, -1, -1, 80, 0, "ui9_tex_catchcricket_sucess_poetry_27", 0, "ui9_tex_catchcricket_name_27"));
		_dataArray.Add(new CricketPartsItem(28, LocalStringManager.GetConfig("CricketParts_language", "Name_28"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_28"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_28"), 0, 0, 3, 4, 600, 2, 150, 150, 5, 5, 92, mustSuccessLoud: false, 0, 0, 8, null, -1, 10, 10, 0, 1, 0, 0, 0, 0, 0, 0, 9, -1, -1, -1, 5, 1, "ui9_tex_catchcricket_sucess_poetry_28", 1, "ui9_tex_catchcricket_name_28"));
		_dataArray.Add(new CricketPartsItem(29, LocalStringManager.GetConfig("CricketParts_language", "Name_29"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_29"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_29"), 0, 0, 3, 4, 600, 2, 150, 150, 5, 5, 84, mustSuccessLoud: false, 0, 0, 8, null, -1, 10, 10, 0, 1, 0, 0, 0, 0, 0, 0, 12, -1, -1, -1, 5, 1, "ui9_tex_catchcricket_sucess_poetry_29", 1, "ui9_tex_catchcricket_name_29"));
		_dataArray.Add(new CricketPartsItem(30, LocalStringManager.GetConfig("CricketParts_language", "Name_30"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_30"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_30"), 0, 0, 3, 4, 600, 2, 150, 150, 5, 5, 76, mustSuccessLoud: false, 0, 0, 8, null, -1, 10, 10, 0, 1, 0, 0, 0, 0, 0, 0, 15, -1, -1, -1, 5, 1, "ui9_tex_catchcricket_sucess_poetry_30", 1, "ui9_tex_catchcricket_name_30"));
		_dataArray.Add(new CricketPartsItem(31, LocalStringManager.GetConfig("CricketParts_language", "Name_31"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_31"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_31"), 0, 1, 3, 4, 1200, 4, 300, 300, 10, 10, 68, mustSuccessLoud: false, 0, 0, 4, null, -1, 20, 10, 0, 2, 0, 0, 0, 0, 0, 0, 18, -1, -1, -1, 10, 1, "ui9_tex_catchcricket_sucess_poetry_31", 1, "ui9_tex_catchcricket_name_31"));
		_dataArray.Add(new CricketPartsItem(32, LocalStringManager.GetConfig("CricketParts_language", "Name_32"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_32"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_32"), 0, 1, 3, 4, 1200, 4, 300, 300, 10, 10, 60, mustSuccessLoud: false, 0, 0, 4, null, -1, 20, 10, 0, 2, 0, 0, 0, 0, 0, 0, 21, -1, -1, -1, 10, 1, "ui9_tex_catchcricket_sucess_poetry_32", 1, "ui9_tex_catchcricket_name_32"));
		_dataArray.Add(new CricketPartsItem(33, LocalStringManager.GetConfig("CricketParts_language", "Name_33"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_33"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_33"), 0, 1, 3, 4, 1200, 4, 300, 300, 10, 10, 52, mustSuccessLoud: false, 0, 0, 4, null, -1, 20, 10, 0, 2, 0, 0, 0, 0, 0, 0, 24, -1, -1, -1, 10, 1, "ui9_tex_catchcricket_sucess_poetry_33", 1, "ui9_tex_catchcricket_name_33"));
		_dataArray.Add(new CricketPartsItem(34, LocalStringManager.GetConfig("CricketParts_language", "Name_34"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_34"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_34"), 0, 2, 3, 5, 1800, 6, 900, 900, 15, 15, 44, mustSuccessLoud: false, 0, 0, 4, null, -1, 20, 20, 0, 3, 0, 0, 0, 0, 0, 0, 27, -1, -1, -1, 15, 1, "ui9_tex_catchcricket_sucess_poetry_34", 1, "ui9_tex_catchcricket_name_34"));
		_dataArray.Add(new CricketPartsItem(35, LocalStringManager.GetConfig("CricketParts_language", "Name_35"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_35"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_35"), 0, 2, 3, 5, 1800, 6, 900, 900, 15, 15, 36, mustSuccessLoud: false, 0, 0, 4, null, -1, 20, 20, 0, 3, 0, 0, 0, 0, 0, 0, 30, -1, -1, -1, 15, 1, "ui9_tex_catchcricket_sucess_poetry_35", 1, "ui9_tex_catchcricket_name_35"));
		_dataArray.Add(new CricketPartsItem(36, LocalStringManager.GetConfig("CricketParts_language", "Name_36"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_36"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_36"), 0, 2, 3, 5, 1800, 6, 900, 900, 15, 15, 28, mustSuccessLoud: false, 0, 0, 4, null, -1, 20, 20, 0, 3, 0, 0, 0, 0, 0, 0, 33, -1, -1, -1, 15, 1, "ui9_tex_catchcricket_sucess_poetry_36", 1, "ui9_tex_catchcricket_name_36"));
		_dataArray.Add(new CricketPartsItem(37, LocalStringManager.GetConfig("CricketParts_language", "Name_37"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_37"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_37"), 0, 3, 1, 5, 3000, 8, 2250, 2250, 20, 20, 20, mustSuccessLoud: false, 0, 0, 4, null, -1, 30, 20, 0, 4, 0, 0, 0, 0, 0, 0, 36, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_37", 1, "ui9_tex_catchcricket_name_37"));
		_dataArray.Add(new CricketPartsItem(38, LocalStringManager.GetConfig("CricketParts_language", "Name_38"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_38"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_38"), 0, 3, 1, 5, 3000, 8, 2250, 2250, 20, 20, 16, mustSuccessLoud: false, 0, 0, 4, null, -1, 30, 20, 0, 4, 0, 0, 0, 0, 0, 0, 39, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_38", 1, "ui9_tex_catchcricket_name_38"));
		_dataArray.Add(new CricketPartsItem(39, LocalStringManager.GetConfig("CricketParts_language", "Name_39"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_39"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_39"), 0, 3, 1, 5, 3000, 8, 2250, 2250, 20, 20, 12, mustSuccessLoud: false, 0, 0, 4, null, -1, 30, 20, 0, 4, 0, 0, 0, 0, 0, 0, 42, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_39", 1, "ui9_tex_catchcricket_name_39"));
		_dataArray.Add(new CricketPartsItem(40, LocalStringManager.GetConfig("CricketParts_language", "Name_40"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_40"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_40"), 0, 4, 1, 6, 4200, 10, 4650, 4650, 25, 25, 8, mustSuccessLoud: false, 0, 0, 8, null, -1, 30, 30, 0, 5, 0, 0, 0, 0, 0, 0, 45, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_40", 1, "ui9_tex_catchcricket_name_40"));
		_dataArray.Add(new CricketPartsItem(41, LocalStringManager.GetConfig("CricketParts_language", "Name_41"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_41"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_41"), 0, 4, 1, 6, 4200, 10, 4650, 4650, 25, 25, 6, mustSuccessLoud: false, 0, 0, 8, null, -1, 30, 30, 0, 5, 0, 0, 0, 0, 0, 0, 48, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_41", 1, "ui9_tex_catchcricket_name_41"));
		_dataArray.Add(new CricketPartsItem(42, LocalStringManager.GetConfig("CricketParts_language", "Name_42"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_42"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_42"), 0, 5, 1, 6, 5400, 12, 8400, 8400, 30, 30, 4, mustSuccessLoud: false, 0, 0, 12, null, -1, 40, 40, 0, 6, 0, 0, 0, 0, 0, 0, 51, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_42", 1, "ui9_tex_catchcricket_name_42"));
		_dataArray.Add(new CricketPartsItem(43, LocalStringManager.GetConfig("CricketParts_language", "Name_43"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_43"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_43"), 0, 5, 1, 6, 5400, 12, 8400, 8400, 30, 30, 3, mustSuccessLoud: false, 0, 0, 12, null, -1, 40, 40, 0, 7, 0, 0, 0, 0, 0, 0, 54, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_43", 1, "ui9_tex_catchcricket_name_43"));
		_dataArray.Add(new CricketPartsItem(44, LocalStringManager.GetConfig("CricketParts_language", "Name_44"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_44"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_44"), 0, 6, 1, 7, 7200, 14, 13800, 13800, 35, 35, 2, mustSuccessLoud: false, 0, 0, 16, null, -1, 50, 50, 0, 8, 0, 0, 0, 0, 0, 0, 57, -1, -1, -1, 35, 1, "ui9_tex_catchcricket_sucess_poetry_44", 1, "ui9_tex_catchcricket_name_44"));
		_dataArray.Add(new CricketPartsItem(45, LocalStringManager.GetConfig("CricketParts_language", "Name_45"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_45"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_45"), 0, 6, 1, 7, 7200, 14, 13800, 13800, 35, 35, 1, mustSuccessLoud: false, 0, 0, 16, null, -1, 50, 50, 0, 9, 0, 0, 0, 0, 0, 0, 60, -1, -1, -1, 35, 1, "ui9_tex_catchcricket_sucess_poetry_45", 1, "ui9_tex_catchcricket_name_45"));
		_dataArray.Add(new CricketPartsItem(46, LocalStringManager.GetConfig("CricketParts_language", "Name_46"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_46"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_46"), 0, 0, 3, 4, 600, 2, 150, 150, 5, 5, 92, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 1, 0, 0, 0, 0, 0, 5, 1, 0, -1, -1, -1, 5, 1, "ui9_tex_catchcricket_sucess_poetry_46", 1, "ui9_tex_catchcricket_name_46"));
		_dataArray.Add(new CricketPartsItem(47, LocalStringManager.GetConfig("CricketParts_language", "Name_47"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_47"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_47"), 0, 0, 3, 4, 600, 2, 150, 150, 5, 5, 84, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 1, 0, 0, 0, 0, 0, 7, 1, 0, -1, -1, -1, 5, 1, "ui9_tex_catchcricket_sucess_poetry_47", 1, "ui9_tex_catchcricket_name_47"));
		_dataArray.Add(new CricketPartsItem(48, LocalStringManager.GetConfig("CricketParts_language", "Name_48"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_48"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_48"), 0, 0, 3, 4, 600, 2, 150, 150, 5, 5, 76, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 1, 0, 0, 0, 0, 0, 9, 1, 0, -1, -1, -1, 5, 1, "ui9_tex_catchcricket_sucess_poetry_48", 1, "ui9_tex_catchcricket_name_48"));
		_dataArray.Add(new CricketPartsItem(49, LocalStringManager.GetConfig("CricketParts_language", "Name_49"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_49"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_49"), 0, 1, 3, 4, 1200, 4, 300, 300, 10, 10, 68, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 2, 0, 0, 0, 0, 0, 11, 2, 0, -1, -1, -1, 10, 1, "ui9_tex_catchcricket_sucess_poetry_49", 1, "ui9_tex_catchcricket_name_49"));
		_dataArray.Add(new CricketPartsItem(50, LocalStringManager.GetConfig("CricketParts_language", "Name_50"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_50"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_50"), 0, 1, 3, 4, 1200, 4, 300, 300, 10, 10, 60, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 2, 0, 0, 0, 0, 0, 13, 2, 0, -1, -1, -1, 10, 1, "ui9_tex_catchcricket_sucess_poetry_50", 1, "ui9_tex_catchcricket_name_50"));
		_dataArray.Add(new CricketPartsItem(51, LocalStringManager.GetConfig("CricketParts_language", "Name_51"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_51"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_51"), 0, 1, 3, 4, 1200, 4, 300, 300, 40, -10, 52, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 2, 0, 0, 0, 0, 0, 15, 2, 0, -1, -1, -1, 10, 1, "ui9_tex_catchcricket_sucess_poetry_51", 1, "ui9_tex_catchcricket_name_51"));
		_dataArray.Add(new CricketPartsItem(52, LocalStringManager.GetConfig("CricketParts_language", "Name_52"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_52"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_52"), 0, 2, 1, 5, 1800, 6, 900, 900, 15, 15, 44, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 3, 0, 0, 0, 0, 0, 17, 3, 0, -1, -1, -1, 15, 1, "ui9_tex_catchcricket_sucess_poetry_52", 1, "ui9_tex_catchcricket_name_52"));
		_dataArray.Add(new CricketPartsItem(53, LocalStringManager.GetConfig("CricketParts_language", "Name_53"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_53"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_53"), 0, 2, 1, 5, 1800, 6, 900, 900, 50, -20, 36, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 3, 0, 0, 0, 0, 0, 19, 3, 0, -1, -1, -1, 15, 1, "ui9_tex_catchcricket_sucess_poetry_53", 1, "ui9_tex_catchcricket_name_53"));
		_dataArray.Add(new CricketPartsItem(54, LocalStringManager.GetConfig("CricketParts_language", "Name_54"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_54"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_54"), 0, 2, 1, 5, 1800, 6, 900, 900, 15, 15, 28, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 3, 0, 0, 0, 0, 0, 21, 3, 0, -1, -1, -1, 15, 1, "ui9_tex_catchcricket_sucess_poetry_54", 1, "ui9_tex_catchcricket_name_54"));
		_dataArray.Add(new CricketPartsItem(55, LocalStringManager.GetConfig("CricketParts_language", "Name_55"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_55"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_55"), 0, 3, 3, 5, 3000, 8, 2250, 2250, 20, 20, 20, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 4, 0, 0, 0, 0, 0, 23, 4, 0, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_55", 1, "ui9_tex_catchcricket_name_55"));
		_dataArray.Add(new CricketPartsItem(56, LocalStringManager.GetConfig("CricketParts_language", "Name_56"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_56"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_56"), 0, 3, 3, 5, 3000, 8, 2250, 2250, 20, 20, 16, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 4, 0, 0, 0, 0, 0, 25, 4, 0, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_56", 1, "ui9_tex_catchcricket_name_56"));
		_dataArray.Add(new CricketPartsItem(57, LocalStringManager.GetConfig("CricketParts_language", "Name_57"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_57"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_57"), 0, 3, 3, 5, 3000, 8, 2250, 2250, 20, 20, 12, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 4, 0, 0, 0, 0, 0, 27, 4, 0, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_57", 1, "ui9_tex_catchcricket_name_57"));
		_dataArray.Add(new CricketPartsItem(58, LocalStringManager.GetConfig("CricketParts_language", "Name_58"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_58"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_58"), 0, 4, 1, 6, 4200, 10, 4650, 4650, -20, 35, 8, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 5, 0, 0, 0, 0, 0, 30, 5, 0, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_58", 1, "ui9_tex_catchcricket_name_58"));
		_dataArray.Add(new CricketPartsItem(59, LocalStringManager.GetConfig("CricketParts_language", "Name_59"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_59"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_59"), 0, 4, 1, 6, 4200, 10, 4650, 4650, 25, 25, 6, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 5, 0, 0, 0, 0, 0, 32, 5, 0, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_59", 1, "ui9_tex_catchcricket_name_59"));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CricketPartsItem(60, LocalStringManager.GetConfig("CricketParts_language", "Name_60"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_60"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_60"), 0, 5, 1, 6, 5400, 12, 8400, 8400, 30, 30, 4, mustSuccessLoud: false, 0, 0, 12, null, -1, 0, 0, 6, 0, 0, 0, 0, 0, 34, 6, 0, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_60", 1, "ui9_tex_catchcricket_name_60"));
		_dataArray.Add(new CricketPartsItem(61, LocalStringManager.GetConfig("CricketParts_language", "Name_61"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_61"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_61"), 0, 5, 1, 6, 5400, 12, 8400, 8400, 30, 30, 3, mustSuccessLoud: false, 0, 0, 12, null, -1, 0, 0, 7, 0, 0, 0, 0, 0, 36, 6, 0, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_61", 1, "ui9_tex_catchcricket_name_61"));
		_dataArray.Add(new CricketPartsItem(62, LocalStringManager.GetConfig("CricketParts_language", "Name_62"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_62"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_62"), 0, 6, 1, 7, 7200, 14, 13800, 13800, 35, 35, 2, mustSuccessLoud: false, 0, 0, 16, null, -1, 0, 0, 8, 0, 0, 0, 0, 0, 38, 7, 0, -1, -1, -1, 35, 1, "ui9_tex_catchcricket_sucess_poetry_62", 1, "ui9_tex_catchcricket_name_62"));
		_dataArray.Add(new CricketPartsItem(63, LocalStringManager.GetConfig("CricketParts_language", "Name_63"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_63"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_63"), 0, 6, 1, 7, 7200, 14, 13800, 13800, 35, 35, 1, mustSuccessLoud: false, 0, 0, 16, null, -1, 0, 0, 9, 0, 0, 0, 0, 0, 40, 7, 0, -1, -1, -1, 35, 1, "ui9_tex_catchcricket_sucess_poetry_63", 1, "ui9_tex_catchcricket_name_63"));
		_dataArray.Add(new CricketPartsItem(64, LocalStringManager.GetConfig("CricketParts_language", "Name_64"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_64"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_64"), 0, 0, 3, 4, 600, 2, 150, 150, 5, 5, 92, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 0, 0, 1, 5, 1, -3, 0, 0, 0, -1, -1, -1, 5, 1, "ui9_tex_catchcricket_sucess_poetry_64", 1, "ui9_tex_catchcricket_name_64"));
		_dataArray.Add(new CricketPartsItem(65, LocalStringManager.GetConfig("CricketParts_language", "Name_65"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_65"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_65"), 0, 0, 3, 4, 600, 2, 150, 150, 5, 5, 84, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 0, 0, 1, 7, 1, -4, 0, 0, 0, -1, -1, -1, 5, 1, "ui9_tex_catchcricket_sucess_poetry_65", 1, "ui9_tex_catchcricket_name_65"));
		_dataArray.Add(new CricketPartsItem(66, LocalStringManager.GetConfig("CricketParts_language", "Name_66"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_66"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_66"), 0, 0, 3, 4, 600, 2, 150, 150, 5, 5, 76, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 0, 0, 1, 9, 1, -5, 0, 0, 0, -1, -1, -1, 5, 1, "ui9_tex_catchcricket_sucess_poetry_66", 1, "ui9_tex_catchcricket_name_66"));
		_dataArray.Add(new CricketPartsItem(67, LocalStringManager.GetConfig("CricketParts_language", "Name_67"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_67"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_67"), 0, 1, 3, 4, 1200, 4, 300, 300, 10, 10, 68, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 0, 2, 11, 2, -6, 0, 0, 0, -1, -1, -1, 10, 1, "ui9_tex_catchcricket_sucess_poetry_67", 1, "ui9_tex_catchcricket_name_67"));
		_dataArray.Add(new CricketPartsItem(68, LocalStringManager.GetConfig("CricketParts_language", "Name_68"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_68"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_68"), 0, 1, 3, 4, 1200, 4, 300, 300, 10, 10, 60, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 0, 2, 13, 2, -7, 0, 0, 0, -1, -1, -1, 10, 1, "ui9_tex_catchcricket_sucess_poetry_68", 1, "ui9_tex_catchcricket_name_68"));
		_dataArray.Add(new CricketPartsItem(69, LocalStringManager.GetConfig("CricketParts_language", "Name_69"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_69"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_69"), 0, 1, 3, 4, 1200, 4, 300, 300, 10, 10, 52, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 0, 2, 15, 2, -8, 0, 0, 0, -1, -1, -1, 10, 1, "ui9_tex_catchcricket_sucess_poetry_69", 1, "ui9_tex_catchcricket_name_69"));
		_dataArray.Add(new CricketPartsItem(70, LocalStringManager.GetConfig("CricketParts_language", "Name_70"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_70"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_70"), 0, 2, 1, 5, 1800, 6, 900, 900, 15, 15, 44, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 0, 3, 17, 3, -9, 0, 0, 0, -1, -1, -1, 15, 1, "ui9_tex_catchcricket_sucess_poetry_70", 1, "ui9_tex_catchcricket_name_70"));
		_dataArray.Add(new CricketPartsItem(71, LocalStringManager.GetConfig("CricketParts_language", "Name_71"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_71"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_71"), 0, 2, 1, 5, 1800, 6, 900, 900, 15, 15, 36, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 0, 3, 19, 3, -10, 0, 0, 0, -1, -1, -1, 15, 1, "ui9_tex_catchcricket_sucess_poetry_71", 1, "ui9_tex_catchcricket_name_71"));
		_dataArray.Add(new CricketPartsItem(72, LocalStringManager.GetConfig("CricketParts_language", "Name_72"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_72"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_72"), 0, 2, 3, 5, 1800, 6, 900, 900, 15, 15, 28, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 0, 3, 21, 3, -11, 0, 0, 0, -1, -1, -1, 15, 1, "ui9_tex_catchcricket_sucess_poetry_72", 1, "ui9_tex_catchcricket_name_72"));
		_dataArray.Add(new CricketPartsItem(73, LocalStringManager.GetConfig("CricketParts_language", "Name_73"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_73"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_73"), 0, 3, 1, 5, 3000, 8, 2250, 2250, 20, 20, 20, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 0, 4, 23, 4, -12, 0, 0, 0, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_73", 1, "ui9_tex_catchcricket_name_73"));
		_dataArray.Add(new CricketPartsItem(74, LocalStringManager.GetConfig("CricketParts_language", "Name_74"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_74"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_74"), 0, 3, 1, 5, 3000, 8, 2250, 2250, 20, 20, 16, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 0, 4, 25, 4, -13, 0, 0, 0, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_74", 1, "ui9_tex_catchcricket_name_74"));
		_dataArray.Add(new CricketPartsItem(75, LocalStringManager.GetConfig("CricketParts_language", "Name_75"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_75"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_75"), 0, 3, 1, 5, 3000, 8, 2250, 2250, 20, 20, 12, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 0, 4, 27, 4, -14, 0, 0, 0, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_75", 1, "ui9_tex_catchcricket_name_75"));
		_dataArray.Add(new CricketPartsItem(76, LocalStringManager.GetConfig("CricketParts_language", "Name_76"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_76"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_76"), 0, 4, 1, 6, 4200, 10, 4650, 4650, 25, 25, 8, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 0, 0, 5, 30, 5, -15, 0, 0, 0, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_76", 1, "ui9_tex_catchcricket_name_76"));
		_dataArray.Add(new CricketPartsItem(77, LocalStringManager.GetConfig("CricketParts_language", "Name_77"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_77"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_77"), 0, 4, 1, 6, 4200, 10, 4650, 4650, 25, 25, 6, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 0, 0, 5, 32, 5, -16, 0, 0, 0, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_77", 1, "ui9_tex_catchcricket_name_77"));
		_dataArray.Add(new CricketPartsItem(78, LocalStringManager.GetConfig("CricketParts_language", "Name_78"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_78"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_78"), 0, 5, 1, 6, 5400, 12, 8400, 8400, 30, 30, 4, mustSuccessLoud: false, 0, 0, 12, null, -1, 0, 0, 0, 0, 6, 34, 6, -17, 0, 0, 0, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_78", 1, "ui9_tex_catchcricket_name_78"));
		_dataArray.Add(new CricketPartsItem(79, LocalStringManager.GetConfig("CricketParts_language", "Name_79"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_79"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_79"), 0, 5, 1, 6, 5400, 12, 8400, 8400, 30, 30, 3, mustSuccessLoud: false, 0, 0, 12, null, -1, 0, 0, 0, 0, 7, 36, 6, -18, 0, 0, 0, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_79", 1, "ui9_tex_catchcricket_name_79"));
		_dataArray.Add(new CricketPartsItem(80, LocalStringManager.GetConfig("CricketParts_language", "Name_80"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_80"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_80"), 0, 6, 1, 7, 7200, 14, 13800, 13800, 35, 35, 2, mustSuccessLoud: false, 0, 0, 16, null, -1, 0, 0, 0, 0, 8, 38, 7, -19, 0, 0, 0, -1, -1, -1, 35, 1, "ui9_tex_catchcricket_sucess_poetry_80", 1, "ui9_tex_catchcricket_name_80"));
		_dataArray.Add(new CricketPartsItem(81, LocalStringManager.GetConfig("CricketParts_language", "Name_81"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_81"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_81"), 0, 6, 1, 7, 7200, 14, 13800, 13800, 35, 35, 1, mustSuccessLoud: false, 0, 0, 16, null, -1, 0, 0, 0, 0, 9, 40, 7, -20, 0, 0, 0, -1, -1, -1, 35, 1, "ui9_tex_catchcricket_sucess_poetry_81", 1, "ui9_tex_catchcricket_name_81"));
		_dataArray.Add(new CricketPartsItem(82, LocalStringManager.GetConfig("CricketParts_language", "Name_82"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_82"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_82"), 0, 3, 3, 4, 3000, 8, 2250, 2250, 20, 20, 8, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 0, 0, 15, 3, -5, 15, 3, 25, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_82", 1, "ui9_tex_catchcricket_name_82"));
		_dataArray.Add(new CricketPartsItem(83, LocalStringManager.GetConfig("CricketParts_language", "Name_83"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_83"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_83"), 0, 4, 1, 5, 4200, 10, 4650, 4650, 25, 25, 4, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 0, 0, 0, 20, 4, -5, 20, 4, 30, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_83", 1, "ui9_tex_catchcricket_name_83"));
		_dataArray.Add(new CricketPartsItem(84, LocalStringManager.GetConfig("CricketParts_language", "Name_84"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_84"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_84"), 0, 5, 1, 5, 5400, 12, 8400, 8400, 30, 30, 2, mustSuccessLoud: false, 0, 0, 12, null, -1, 0, 0, 0, 0, 0, 25, 5, -5, 25, 5, 35, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_84", 1, "ui9_tex_catchcricket_name_84"));
		_dataArray.Add(new CricketPartsItem(85, LocalStringManager.GetConfig("CricketParts_language", "Name_85"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_85"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_85"), 0, 3, 3, 5, 3000, 8, 2250, 2250, 20, 20, 8, mustSuccessLoud: false, 0, 0, 4, null, -1, 10, 10, 2, 2, 2, 0, 0, 0, 0, 0, 0, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_85", 1, "ui9_tex_catchcricket_name_85"));
		_dataArray.Add(new CricketPartsItem(86, LocalStringManager.GetConfig("CricketParts_language", "Name_86"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_86"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_86"), 0, 4, 1, 6, 4200, 10, 4650, 4650, 25, 25, 4, mustSuccessLoud: false, 0, 0, 8, null, -1, 20, 20, 3, 3, 3, 0, 0, 0, 0, 0, 0, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_86", 1, "ui9_tex_catchcricket_name_86"));
		_dataArray.Add(new CricketPartsItem(87, LocalStringManager.GetConfig("CricketParts_language", "Name_87"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_87"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_87"), 0, 5, 1, 6, 5400, 12, 8400, 8400, 30, 30, 2, mustSuccessLoud: false, 0, 0, 12, null, -1, 30, 30, 4, 4, 4, 0, 0, 0, 0, 0, 0, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_87", 1, "ui9_tex_catchcricket_name_87"));
		_dataArray.Add(new CricketPartsItem(88, LocalStringManager.GetConfig("CricketParts_language", "Name_88"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_88"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_88"), 0, 3, 3, 4, 3000, 8, 2250, 2250, 30, 20, 8, mustSuccessLoud: false, 0, 0, 4, null, -1, 50, 0, 0, 0, 0, 0, 0, 0, 30, 4, 0, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_88", 1, "ui9_tex_catchcricket_name_88"));
		_dataArray.Add(new CricketPartsItem(89, LocalStringManager.GetConfig("CricketParts_language", "Name_89"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_89"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_89"), 0, 4, 1, 5, 4200, 10, 4650, 4650, 35, 25, 4, mustSuccessLoud: false, 0, 0, 8, null, -1, 60, 0, 0, 0, 0, 0, 0, 0, 35, 5, 0, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_89", 1, "ui9_tex_catchcricket_name_89"));
		_dataArray.Add(new CricketPartsItem(90, LocalStringManager.GetConfig("CricketParts_language", "Name_90"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_90"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_90"), 0, 5, 1, 5, 5400, 12, 8400, 8400, 40, 30, 2, mustSuccessLoud: false, 0, 0, 12, null, -1, 70, 0, 0, 0, 0, 0, 0, 0, 40, 6, 0, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_90", 1, "ui9_tex_catchcricket_name_90"));
		_dataArray.Add(new CricketPartsItem(91, LocalStringManager.GetConfig("CricketParts_language", "Name_91"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_91"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_91"), 0, 3, 1, 4, 3000, 8, 2250, 2250, 20, 20, 8, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 50, 0, 0, 0, 30, 4, -20, 0, 0, 0, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_91", 1, "ui9_tex_catchcricket_name_91"));
		_dataArray.Add(new CricketPartsItem(92, LocalStringManager.GetConfig("CricketParts_language", "Name_92"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_92"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_92"), 0, 4, 1, 5, 4200, 10, 4650, 4650, 25, 25, 4, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 60, 0, 0, 0, 35, 5, -20, 0, 0, 0, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_92", 1, "ui9_tex_catchcricket_name_92"));
		_dataArray.Add(new CricketPartsItem(93, LocalStringManager.GetConfig("CricketParts_language", "Name_93"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_93"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_93"), 0, 5, 1, 5, 5400, 12, 8400, 8400, 30, 30, 2, mustSuccessLoud: false, 0, 0, 12, null, -1, 0, 70, 0, 0, 0, 40, 6, -20, 0, 0, 0, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_93", 1, "ui9_tex_catchcricket_name_93"));
		_dataArray.Add(new CricketPartsItem(94, LocalStringManager.GetConfig("CricketParts_language", "Name_94"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_94"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_94"), 0, 3, 3, 6, 3000, 8, 2250, 2250, 25, 20, 8, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 0, 0, 0, 0, 0, 35, 7, 0, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_94", 1, "ui9_tex_catchcricket_name_94"));
		_dataArray.Add(new CricketPartsItem(95, LocalStringManager.GetConfig("CricketParts_language", "Name_95"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_95"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_95"), 0, 4, 3, 7, 4200, 10, 4650, 4650, 30, 25, 4, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 0, 0, 0, 0, 0, 0, 40, 8, 0, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_95", 1, "ui9_tex_catchcricket_name_95"));
		_dataArray.Add(new CricketPartsItem(96, LocalStringManager.GetConfig("CricketParts_language", "Name_96"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_96"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_96"), 0, 5, 3, 7, 5400, 12, 8400, 8400, 35, 30, 2, mustSuccessLoud: false, 0, 0, 12, null, -1, 0, 0, 0, 0, 0, 0, 0, 0, 45, 9, 0, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_96", 1, "ui9_tex_catchcricket_name_96"));
		_dataArray.Add(new CricketPartsItem(97, LocalStringManager.GetConfig("CricketParts_language", "Name_97"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_97"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_97"), 0, 3, 1, 5, 3000, 8, 2250, 2250, 20, 20, 8, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 50, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_97", 1, "ui9_tex_catchcricket_name_97"));
		_dataArray.Add(new CricketPartsItem(98, LocalStringManager.GetConfig("CricketParts_language", "Name_98"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_98"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_98"), 0, 4, 1, 6, 4200, 10, 4650, 4650, 25, 25, 4, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 55, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_98", 1, "ui9_tex_catchcricket_name_98"));
		_dataArray.Add(new CricketPartsItem(99, LocalStringManager.GetConfig("CricketParts_language", "Name_99"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_99"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_99"), 0, 5, 1, 6, 5400, 12, 8400, 8400, 30, 30, 2, mustSuccessLoud: false, 0, 0, 12, null, -1, 0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 60, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_99", 1, "ui9_tex_catchcricket_name_99"));
		_dataArray.Add(new CricketPartsItem(100, LocalStringManager.GetConfig("CricketParts_language", "Name_100"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_100"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_100"), 0, 3, 3, 4, 3000, 8, 2250, 2250, 20, 20, 8, mustSuccessLoud: false, 0, 0, 4, null, -1, 0, 0, 0, 0, 0, 35, 7, -25, 0, 0, 0, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_100", 1, "ui9_tex_catchcricket_name_100"));
		_dataArray.Add(new CricketPartsItem(101, LocalStringManager.GetConfig("CricketParts_language", "Name_101"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_101"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_101"), 0, 4, 1, 5, 4200, 10, 4650, 4650, 25, 25, 4, mustSuccessLoud: false, 0, 0, 8, null, -1, 0, 0, 0, 0, 0, 40, 8, -25, 0, 0, 0, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_101", 1, "ui9_tex_catchcricket_name_101"));
		_dataArray.Add(new CricketPartsItem(102, LocalStringManager.GetConfig("CricketParts_language", "Name_102"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_102"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_102"), 0, 5, 1, 5, 5400, 12, 8400, 8400, 30, 30, 2, mustSuccessLoud: false, 0, 0, 12, null, -1, 0, 0, 0, 0, 0, 45, 9, -25, 0, 0, 0, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_102", 1, "ui9_tex_catchcricket_name_102"));
		_dataArray.Add(new CricketPartsItem(103, LocalStringManager.GetConfig("CricketParts_language", "Name_103"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_103"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_103"), 0, 3, 3, 6, 3000, 8, 2250, 2250, 30, 20, 8, mustSuccessLoud: false, 0, 0, 4, null, -1, 50, 50, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, 20, 1, "ui9_tex_catchcricket_sucess_poetry_103", 1, "ui9_tex_catchcricket_name_103"));
		_dataArray.Add(new CricketPartsItem(104, LocalStringManager.GetConfig("CricketParts_language", "Name_104"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_104"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_104"), 0, 4, 3, 7, 4200, 10, 4650, 4650, 35, 25, 4, mustSuccessLoud: false, 0, 0, 8, null, -1, 70, 70, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, 25, 1, "ui9_tex_catchcricket_sucess_poetry_104", 1, "ui9_tex_catchcricket_name_104"));
		_dataArray.Add(new CricketPartsItem(105, LocalStringManager.GetConfig("CricketParts_language", "Name_105"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_105"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_105"), 0, 5, 1, 7, 5400, 12, 8400, 8400, 50, -20, 2, mustSuccessLoud: false, 0, 0, 12, null, -1, 90, 90, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, -1, 30, 1, "ui9_tex_catchcricket_sucess_poetry_105", 1, "ui9_tex_catchcricket_name_105"));
		_dataArray.Add(new CricketPartsItem(106, LocalStringManager.GetConfig("CricketParts_language", "Name_106"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_106"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_106"), 0, 6, 1, 8, 7200, 14, 13800, 13800, 25, 45, 1, mustSuccessLoud: false, 0, 0, 16, null, -1, 0, 0, 12, 0, 0, 0, 0, 0, 35, 5, 0, -1, -1, -1, 35, 1, "ui9_tex_catchcricket_sucess_poetry_106", 1, "ui9_tex_catchcricket_name_106"));
		_dataArray.Add(new CricketPartsItem(107, LocalStringManager.GetConfig("CricketParts_language", "Name_107"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_107"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_107"), 0, 6, 1, 8, 7200, 14, 13800, 13800, 35, 35, 1, mustSuccessLoud: false, 0, 0, 16, null, -1, 60, 60, 0, 12, 0, 0, 0, 0, 0, 0, 50, -1, -1, -1, 35, 1, "ui9_tex_catchcricket_sucess_poetry_107", 1, "ui9_tex_catchcricket_name_107"));
		_dataArray.Add(new CricketPartsItem(108, LocalStringManager.GetConfig("CricketParts_language", "Name_108"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_108"), ECricketPartsType.Parts, null, LocalStringManager.GetConfig("CricketParts_language", "Desc_108"), 0, 6, 1, 8, 7200, 14, 13800, 13800, 35, 35, 1, mustSuccessLoud: false, 0, 0, 16, null, -1, 0, 0, 0, 0, 12, 35, 5, -15, 0, 0, 0, -1, -1, -1, 35, 1, "ui9_tex_catchcricket_sucess_poetry_108", 1, "ui9_tex_catchcricket_name_108"));
		_dataArray.Add(new CricketPartsItem(109, LocalStringManager.GetConfig("CricketParts_language", "Name_109"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_109"), ECricketPartsType.Cyan, "ui9_icon_cricket_5", LocalStringManager.GetConfig("CricketParts_language", "Desc_109"), 0, 5, 2, 4, 5400, 12, 8400, 8400, 50, 50, 24, mustSuccessLoud: false, 0, 22, 16, "84b8af", 5, 150, 80, 2, 3, 4, 5, 5, 10, 25, 5, 15, -1, -1, -1, 30, 1, null, 0, "ui9_tex_catchcricket_name_109"));
		_dataArray.Add(new CricketPartsItem(110, LocalStringManager.GetConfig("CricketParts_language", "Name_110"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_110"), ECricketPartsType.Cyan, "ui9_icon_cricket_5", LocalStringManager.GetConfig("CricketParts_language", "Desc_110"), 0, 5, 2, 4, 5400, 12, 8400, 8400, 50, 50, 16, mustSuccessLoud: false, 0, 24, 16, "a4d0bc", 5, 130, 100, 3, 4, 5, 8, 4, 10, 25, 4, 20, -1, -1, -1, 30, 1, null, 0, "ui9_tex_catchcricket_name_110"));
		_dataArray.Add(new CricketPartsItem(111, LocalStringManager.GetConfig("CricketParts_language", "Name_111"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_111"), ECricketPartsType.Cyan, "ui9_icon_cricket_5", LocalStringManager.GetConfig("CricketParts_language", "Desc_111"), 0, 5, 2, 4, 5400, 12, 8400, 8400, 50, 50, 8, mustSuccessLoud: false, 0, 26, 16, "b3dad8", 5, 140, 90, 5, 4, 5, 7, 4, 10, 20, 5, 20, -1, -1, -1, 30, 1, null, 0, "ui9_tex_catchcricket_name_111"));
		_dataArray.Add(new CricketPartsItem(112, LocalStringManager.GetConfig("CricketParts_language", "Name_112"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_112"), ECricketPartsType.Cyan, "ui9_icon_cricket_5", LocalStringManager.GetConfig("CricketParts_language", "Desc_112"), 0, 5, 2, 5, 5400, 12, 8400, 8400, 50, 50, 4, mustSuccessLoud: false, 0, 28, 16, "7da598", 5, 150, 80, 5, 6, 6, 6, 5, 10, 25, 7, 20, -1, -1, -1, 30, 1, null, 0, "ui9_tex_catchcricket_name_112"));
		_dataArray.Add(new CricketPartsItem(113, LocalStringManager.GetConfig("CricketParts_language", "Name_113"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_113"), ECricketPartsType.Cyan, "ui9_icon_cricket_5", LocalStringManager.GetConfig("CricketParts_language", "Desc_113"), 0, 5, 2, 5, 5400, 12, 8400, 8400, 50, 50, 2, mustSuccessLoud: false, 0, 30, 16, "647f9e", 5, 160, 100, 5, 6, 6, 7, 6, 10, 25, 8, 15, -1, -1, -1, 30, 1, null, 0, "ui9_tex_catchcricket_name_113"));
		_dataArray.Add(new CricketPartsItem(114, LocalStringManager.GetConfig("CricketParts_language", "Name_114"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_114"), ECricketPartsType.Cyan, "ui9_icon_cricket_5", LocalStringManager.GetConfig("CricketParts_language", "Desc_114"), 0, 5, 2, 5, 5400, 12, 8400, 8400, 50, 50, 1, mustSuccessLoud: false, 0, 32, 16, "5a8aa7", 5, 150, 120, 6, 6, 7, 9, 6, 10, 20, 7, 20, -1, -1, -1, 30, 1, null, 0, "ui9_tex_catchcricket_name_114"));
		_dataArray.Add(new CricketPartsItem(115, LocalStringManager.GetConfig("CricketParts_language", "Name_115"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_115"), ECricketPartsType.Yellow, "ui9_icon_cricket_4", LocalStringManager.GetConfig("CricketParts_language", "Desc_115"), 0, 4, 2, 4, 4200, 10, 4650, 4650, 40, 40, 24, mustSuccessLoud: false, 0, 20, 12, "c8a353", 3, 100, 160, 1, 4, 2, 15, 5, 0, 15, 5, 30, -1, -1, -1, 25, 1, null, 0, "ui9_tex_catchcricket_name_115"));
		_dataArray.Add(new CricketPartsItem(116, LocalStringManager.GetConfig("CricketParts_language", "Name_116"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_116"), ECricketPartsType.Yellow, "ui9_icon_cricket_4", LocalStringManager.GetConfig("CricketParts_language", "Desc_116"), 0, 4, 2, 4, 4200, 10, 4650, 4650, 40, 40, 16, mustSuccessLoud: false, 0, 22, 12, "ceb882", 3, 90, 120, 3, 7, 3, 18, 7, 0, 10, 6, 35, -1, -1, -1, 25, 1, null, 0, "ui9_tex_catchcricket_name_116"));
		_dataArray.Add(new CricketPartsItem(117, LocalStringManager.GetConfig("CricketParts_language", "Name_117"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_117"), ECricketPartsType.Yellow, "ui9_icon_cricket_4", LocalStringManager.GetConfig("CricketParts_language", "Desc_117"), 0, 4, 2, 4, 4200, 10, 4650, 4650, 40, 40, 8, mustSuccessLoud: false, 0, 24, 12, "966e3a", 3, 100, 140, 2, 6, 5, 10, 6, 0, 15, 8, 35, -1, -1, -1, 25, 1, null, 0, "ui9_tex_catchcricket_name_117"));
		_dataArray.Add(new CricketPartsItem(118, LocalStringManager.GetConfig("CricketParts_language", "Name_118"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_118"), ECricketPartsType.Yellow, "ui9_icon_cricket_4", LocalStringManager.GetConfig("CricketParts_language", "Desc_118"), 0, 4, 2, 5, 4200, 10, 4650, 4650, 40, 40, 4, mustSuccessLoud: false, 0, 26, 12, "e5d8a6", 3, 90, 160, 4, 7, 5, 15, 5, 0, 10, 6, 30, -1, -1, -1, 25, 1, null, 0, "ui9_tex_catchcricket_name_118"));
		_dataArray.Add(new CricketPartsItem(119, LocalStringManager.GetConfig("CricketParts_language", "Name_119"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_119"), ECricketPartsType.Yellow, "ui9_icon_cricket_4", LocalStringManager.GetConfig("CricketParts_language", "Desc_119"), 0, 4, 2, 5, 4200, 10, 4650, 4650, 40, 40, 2, mustSuccessLoud: false, 0, 28, 12, "57431f", 3, 110, 160, 3, 8, 6, 15, 6, 0, 18, 7, 30, -1, -1, -1, 25, 1, null, 0, "ui9_tex_catchcricket_name_119"));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new CricketPartsItem(120, LocalStringManager.GetConfig("CricketParts_language", "Name_120"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_120"), ECricketPartsType.Yellow, "ui9_icon_cricket_4", LocalStringManager.GetConfig("CricketParts_language", "Desc_120"), 0, 4, 2, 5, 4200, 10, 4650, 4650, 40, 40, 1, mustSuccessLoud: false, 0, 30, 12, "bfae65", 3, 120, 170, 4, 9, 5, 18, 7, 0, 15, 7, 35, -1, -1, -1, 25, 1, null, 0, "ui9_tex_catchcricket_name_120"));
		_dataArray.Add(new CricketPartsItem(121, LocalStringManager.GetConfig("CricketParts_language", "Name_121"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_121"), ECricketPartsType.Purple, "ui9_icon_cricket_3", LocalStringManager.GetConfig("CricketParts_language", "Desc_121"), 0, 3, 2, 4, 3000, 8, 2250, 2250, 30, 30, 24, mustSuccessLoud: false, 0, 16, 8, "7d638b", 4, 70, 70, 4, 2, 3, 25, 6, -10, 10, 8, 35, -1, -1, -1, 20, 1, null, 0, "ui9_tex_catchcricket_name_121"));
		_dataArray.Add(new CricketPartsItem(122, LocalStringManager.GetConfig("CricketParts_language", "Name_122"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_122"), ECricketPartsType.Purple, "ui9_icon_cricket_3", LocalStringManager.GetConfig("CricketParts_language", "Desc_122"), 0, 3, 2, 4, 3000, 8, 2250, 2250, 30, 30, 16, mustSuccessLoud: false, 0, 18, 8, "948299", 4, 60, 70, 4, 2, 4, 30, 7, -10, 10, 7, 35, -1, -1, -1, 20, 1, null, 0, "ui9_tex_catchcricket_name_122"));
		_dataArray.Add(new CricketPartsItem(123, LocalStringManager.GetConfig("CricketParts_language", "Name_123"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_123"), ECricketPartsType.Purple, "ui9_icon_cricket_3", LocalStringManager.GetConfig("CricketParts_language", "Desc_123"), 0, 3, 2, 4, 3000, 8, 2250, 2250, 30, 30, 8, mustSuccessLoud: false, 0, 20, 8, "685177", 4, 80, 80, 5, 2, 5, 20, 5, -10, 15, 10, 30, -1, -1, -1, 20, 1, null, 0, "ui9_tex_catchcricket_name_123"));
		_dataArray.Add(new CricketPartsItem(124, LocalStringManager.GetConfig("CricketParts_language", "Name_124"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_124"), ECricketPartsType.Purple, "ui9_icon_cricket_3", LocalStringManager.GetConfig("CricketParts_language", "Desc_124"), 0, 3, 2, 5, 3000, 8, 2250, 2250, 30, 30, 4, mustSuccessLoud: false, 0, 22, 8, "4d2c52", 4, 90, 80, 5, 3, 5, 25, 6, -10, 12, 12, 30, -1, -1, -1, 20, 1, null, 0, "ui9_tex_catchcricket_name_124"));
		_dataArray.Add(new CricketPartsItem(125, LocalStringManager.GetConfig("CricketParts_language", "Name_125"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_125"), ECricketPartsType.Purple, "ui9_icon_cricket_3", LocalStringManager.GetConfig("CricketParts_language", "Desc_125"), 0, 3, 2, 5, 3000, 8, 2250, 2250, 30, 30, 2, mustSuccessLoud: false, 0, 24, 8, "833557", 4, 70, 70, 6, 4, 6, 30, 8, -10, 15, 10, 35, -1, -1, -1, 20, 1, null, 0, "ui9_tex_catchcricket_name_125"));
		_dataArray.Add(new CricketPartsItem(126, LocalStringManager.GetConfig("CricketParts_language", "Name_126"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_126"), ECricketPartsType.Purple, "ui9_icon_cricket_3", LocalStringManager.GetConfig("CricketParts_language", "Desc_126"), 0, 3, 2, 5, 3000, 8, 2250, 2250, 30, 30, 1, mustSuccessLoud: false, 0, 26, 8, "d294d3", 4, 80, 80, 7, 5, 6, 30, 7, -10, 12, 12, 35, -1, -1, -1, 20, 1, null, 0, "ui9_tex_catchcricket_name_126"));
		_dataArray.Add(new CricketPartsItem(127, LocalStringManager.GetConfig("CricketParts_language", "Name_127"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_127"), ECricketPartsType.Red, "ui9_icon_cricket_2", LocalStringManager.GetConfig("CricketParts_language", "Desc_127"), 0, 2, 2, 4, 1800, 6, 900, 900, 20, 20, 24, mustSuccessLoud: false, 0, 12, 4, "9d4143", 2, 50, 50, 2, 2, 5, 35, 7, -10, 0, 0, 30, -1, -1, -1, 15, 1, null, 0, "ui9_tex_catchcricket_name_127"));
		_dataArray.Add(new CricketPartsItem(128, LocalStringManager.GetConfig("CricketParts_language", "Name_128"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_128"), ECricketPartsType.Red, "ui9_icon_cricket_2", LocalStringManager.GetConfig("CricketParts_language", "Desc_128"), 0, 2, 2, 4, 1800, 6, 900, 900, 20, 20, 16, mustSuccessLoud: false, 0, 14, 4, "b87681", 2, 50, 60, 3, 3, 5, 40, 7, -10, 0, 0, 25, -1, -1, -1, 15, 1, null, 0, "ui9_tex_catchcricket_name_128"));
		_dataArray.Add(new CricketPartsItem(129, LocalStringManager.GetConfig("CricketParts_language", "Name_129"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_129"), ECricketPartsType.Red, "ui9_icon_cricket_2", LocalStringManager.GetConfig("CricketParts_language", "Desc_129"), 0, 2, 2, 4, 1800, 6, 900, 900, 20, 20, 8, mustSuccessLoud: false, 0, 16, 4, "874a58", 2, 60, 60, 2, 4, 6, 40, 9, -10, 0, 0, 30, -1, -1, -1, 15, 1, null, 0, "ui9_tex_catchcricket_name_129"));
		_dataArray.Add(new CricketPartsItem(130, LocalStringManager.GetConfig("CricketParts_language", "Name_130"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_130"), ECricketPartsType.Red, "ui9_icon_cricket_2", LocalStringManager.GetConfig("CricketParts_language", "Desc_130"), 0, 2, 2, 5, 1800, 6, 900, 900, 20, 20, 4, mustSuccessLoud: false, 0, 18, 4, "b85f4f", 2, 70, 60, 4, 5, 7, 35, 7, -10, 0, 0, 25, -1, -1, -1, 15, 1, null, 0, "ui9_tex_catchcricket_name_130"));
		_dataArray.Add(new CricketPartsItem(131, LocalStringManager.GetConfig("CricketParts_language", "Name_131"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_131"), ECricketPartsType.Red, "ui9_icon_cricket_2", LocalStringManager.GetConfig("CricketParts_language", "Desc_131"), 0, 2, 2, 5, 1800, 6, 900, 900, 20, 20, 2, mustSuccessLoud: false, 0, 20, 4, "ac544d", 2, 60, 50, 5, 4, 8, 35, 9, -10, 0, 0, 30, -1, -1, -1, 15, 1, null, 0, "ui9_tex_catchcricket_name_131"));
		_dataArray.Add(new CricketPartsItem(132, LocalStringManager.GetConfig("CricketParts_language", "Name_132"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_132"), ECricketPartsType.Red, "ui9_icon_cricket_2", LocalStringManager.GetConfig("CricketParts_language", "Desc_132"), 0, 2, 2, 5, 1800, 6, 900, 900, 20, 20, 1, mustSuccessLoud: false, 0, 22, 4, "c95955", 2, 60, 70, 4, 4, 9, 45, 9, -10, 0, 0, 30, -1, -1, -1, 15, 1, null, 0, "ui9_tex_catchcricket_name_132"));
		_dataArray.Add(new CricketPartsItem(133, LocalStringManager.GetConfig("CricketParts_language", "Name_133"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_133"), ECricketPartsType.Black, "ui9_icon_cricket_1", LocalStringManager.GetConfig("CricketParts_language", "Desc_133"), 0, 1, 2, 4, 1200, 4, 300, 300, 10, 10, 24, mustSuccessLoud: false, 0, 8, 4, "333333", 1, 70, 60, 1, 4, 1, 10, 3, 5, 20, 5, 55, -1, -1, -1, 10, 1, null, 0, "ui9_tex_catchcricket_name_133"));
		_dataArray.Add(new CricketPartsItem(134, LocalStringManager.GetConfig("CricketParts_language", "Name_134"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_134"), ECricketPartsType.Black, "ui9_icon_cricket_1", LocalStringManager.GetConfig("CricketParts_language", "Desc_134"), 0, 1, 2, 4, 1200, 4, 300, 300, 10, 10, 16, mustSuccessLoud: false, 0, 10, 4, "6b6b6b", 1, 60, 40, 2, 5, 2, 8, 3, 5, 25, 6, 60, -1, -1, -1, 10, 1, null, 0, "ui9_tex_catchcricket_name_134"));
		_dataArray.Add(new CricketPartsItem(135, LocalStringManager.GetConfig("CricketParts_language", "Name_135"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_135"), ECricketPartsType.Black, "ui9_icon_cricket_1", LocalStringManager.GetConfig("CricketParts_language", "Desc_135"), 0, 1, 2, 4, 1200, 4, 300, 300, 10, 10, 8, mustSuccessLoud: false, 0, 12, 4, "4d4b42", 1, 80, 60, 1, 6, 2, 10, 4, 5, 25, 7, 55, -1, -1, -1, 10, 1, null, 0, "ui9_tex_catchcricket_name_135"));
		_dataArray.Add(new CricketPartsItem(136, LocalStringManager.GetConfig("CricketParts_language", "Name_136"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_136"), ECricketPartsType.Black, "ui9_icon_cricket_1", LocalStringManager.GetConfig("CricketParts_language", "Desc_136"), 0, 1, 2, 5, 1200, 4, 300, 300, 10, 10, 4, mustSuccessLoud: false, 0, 14, 4, "4a4b48", 1, 90, 50, 2, 7, 4, 8, 4, 5, 20, 6, 55, -1, -1, -1, 10, 1, null, 0, "ui9_tex_catchcricket_name_136"));
		_dataArray.Add(new CricketPartsItem(137, LocalStringManager.GetConfig("CricketParts_language", "Name_137"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_137"), ECricketPartsType.Black, "ui9_icon_cricket_1", LocalStringManager.GetConfig("CricketParts_language", "Desc_137"), 0, 1, 2, 5, 1200, 4, 300, 300, 10, 10, 2, mustSuccessLoud: false, 0, 16, 4, "525254", 1, 90, 70, 1, 8, 4, 10, 4, 5, 25, 8, 60, -1, -1, -1, 10, 1, null, 0, "ui9_tex_catchcricket_name_137"));
		_dataArray.Add(new CricketPartsItem(138, LocalStringManager.GetConfig("CricketParts_language", "Name_138"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_138"), ECricketPartsType.Black, "ui9_icon_cricket_1", LocalStringManager.GetConfig("CricketParts_language", "Desc_138"), 0, 1, 2, 5, 1200, 4, 300, 300, 10, 10, 1, mustSuccessLoud: false, 0, 18, 4, "404040", 1, 80, 70, 2, 9, 4, 12, 4, 5, 30, 10, 60, -1, -1, -1, 10, 1, null, 0, "ui9_tex_catchcricket_name_138"));
		_dataArray.Add(new CricketPartsItem(139, LocalStringManager.GetConfig("CricketParts_language", "Name_139"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_139"), ECricketPartsType.White, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_139"), 0, 0, 2, 4, 600, 2, 150, 150, 0, 0, 24, mustSuccessLoud: false, 0, 6, 8, "dfdfdf", 0, 40, 30, 3, 1, 2, 35, 5, -10, 0, 0, 30, -1, -1, -1, 5, 1, null, 0, "ui9_tex_catchcricket_name_139"));
		_dataArray.Add(new CricketPartsItem(140, LocalStringManager.GetConfig("CricketParts_language", "Name_140"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_140"), ECricketPartsType.White, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_140"), 0, 0, 2, 4, 600, 2, 150, 150, 0, 0, 16, mustSuccessLoud: false, 0, 8, 8, "b6b4a8", 0, 50, 40, 4, 2, 2, 30, 6, -10, 0, 0, 25, -1, -1, -1, 5, 1, null, 0, "ui9_tex_catchcricket_name_140"));
		_dataArray.Add(new CricketPartsItem(141, LocalStringManager.GetConfig("CricketParts_language", "Name_141"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_141"), ECricketPartsType.White, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_141"), 0, 0, 2, 4, 600, 2, 150, 150, 0, 0, 8, mustSuccessLoud: false, 0, 10, 8, "cccbc4", 0, 40, 50, 5, 2, 2, 35, 6, -10, 0, 0, 35, -1, -1, -1, 5, 1, null, 0, "ui9_tex_catchcricket_name_141"));
		_dataArray.Add(new CricketPartsItem(142, LocalStringManager.GetConfig("CricketParts_language", "Name_142"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_142"), ECricketPartsType.White, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_142"), 0, 0, 2, 5, 600, 2, 150, 150, 0, 0, 4, mustSuccessLoud: false, 0, 12, 8, "d3c6b3", 0, 50, 40, 6, 1, 3, 35, 7, -10, 0, 0, 30, -1, -1, -1, 5, 1, null, 0, "ui9_tex_catchcricket_name_142"));
		_dataArray.Add(new CricketPartsItem(143, LocalStringManager.GetConfig("CricketParts_language", "Name_143"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_143"), ECricketPartsType.White, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_143"), 0, 0, 2, 5, 600, 2, 150, 150, 0, 0, 2, mustSuccessLoud: false, 0, 14, 8, "d9ebef", 0, 40, 50, 8, 2, 2, 40, 7, -10, 0, 0, 35, -1, -1, -1, 5, 1, null, 0, "ui9_tex_catchcricket_name_143"));
		_dataArray.Add(new CricketPartsItem(144, LocalStringManager.GetConfig("CricketParts_language", "Name_144"), LocalStringManager.GetConfig("CricketParts_language", "NameAtSecond_144"), ECricketPartsType.White, "ui9_icon_cricket_0", LocalStringManager.GetConfig("CricketParts_language", "Desc_144"), 0, 0, 2, 5, 600, 2, 150, 150, 0, 0, 1, mustSuccessLoud: false, 0, 16, 8, "d6d8c1", 0, 50, 40, 9, 2, 4, 35, 8, -10, 0, 0, 30, -1, -1, -1, 5, 1, null, 0, "ui9_tex_catchcricket_name_144"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CricketPartsItem>(145);
		CreateItems0();
		CreateItems1();
		CreateItems2();
	}
}

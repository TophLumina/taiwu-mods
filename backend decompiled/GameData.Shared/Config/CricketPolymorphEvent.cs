using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CricketPolymorphEvent : ConfigData<CricketPolymorphEventItem, short>
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
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 呆物
		/// </summary>
		public static CricketPolymorphEventItem Trash => Instance[(short)0];

		/// <summary>
		/// 绣花针
		/// </summary>
		public static CricketPolymorphEventItem XiuHuaZhen => Instance[(short)1];

		/// <summary>
		/// 两头枪
		/// </summary>
		public static CricketPolymorphEventItem LiangTouQiang => Instance[(short)2];

		/// <summary>
		/// 吹铃
		/// </summary>
		public static CricketPolymorphEventItem ChuiLing => Instance[(short)3];

		/// <summary>
		/// 跑马黄
		/// </summary>
		public static CricketPolymorphEventItem PaoMaHuang => Instance[(short)4];

		/// <summary>
		/// 玉锄头
		/// </summary>
		public static CricketPolymorphEventItem YuChuTou => Instance[(short)5];

		/// <summary>
		/// 披袍轩甲
		/// </summary>
		public static CricketPolymorphEventItem PiPaoXuanJia => Instance[(short)6];

		/// <summary>
		/// 反生名
		/// </summary>
		public static CricketPolymorphEventItem FanShengMing => Instance[(short)7];

		/// <summary>
		/// 朱砂额
		/// </summary>
		public static CricketPolymorphEventItem ZhuShaE => Instance[(short)8];

		/// <summary>
		/// 头陀
		/// </summary>
		public static CricketPolymorphEventItem TouTuo => Instance[(short)9];

		/// <summary>
		/// 铁弹子
		/// </summary>
		public static CricketPolymorphEventItem TieDanZi => Instance[(short)10];

		/// <summary>
		/// 赤须
		/// </summary>
		public static CricketPolymorphEventItem ChiXu => Instance[(short)11];

		/// <summary>
		/// 玉尾
		/// </summary>
		public static CricketPolymorphEventItem YuWei => Instance[(short)12];

		/// <summary>
		/// 油纸灯
		/// </summary>
		public static CricketPolymorphEventItem YouZhiDeng => Instance[(short)13];

		/// <summary>
		/// 真三色
		/// </summary>
		public static CricketPolymorphEventItem ZhenSanSe => Instance[(short)14];

		/// <summary>
		/// 草三段
		/// </summary>
		public static CricketPolymorphEventItem CaoSanDuan => Instance[(short)15];

		/// <summary>
		/// 真紫黄
		/// </summary>
		public static CricketPolymorphEventItem ZhenZiHuang => Instance[(short)16];

		/// <summary>
		/// 梅花翅
		/// </summary>
		public static CricketPolymorphEventItem MeiHuaChi => Instance[(short)17];

		/// <summary>
		/// 天蓝青
		/// </summary>
		public static CricketPolymorphEventItem TianLanQing => Instance[(short)18];

		/// <summary>
		/// 三段锦
		/// </summary>
		public static CricketPolymorphEventItem SanDuanJin => Instance[(short)19];

		/// <summary>
		/// 三太子
		/// </summary>
		public static CricketPolymorphEventItem SanTaiZi => Instance[(short)20];

		/// <summary>
		/// 八败
		/// </summary>
		public static CricketPolymorphEventItem BaBai => Instance[(short)21];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static CricketPolymorphEvent Instance = new CricketPolymorphEvent();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"ContentEvent02", "ContentEventFirstMeet03", "ContentEventFirstMeet03Option", "ContentEventFirstMeet04", "ContentEventFirstMeet05", "ContentEventFirstMeet06", "ContentEventMeetAgain03", "ContentEventMeetAgain04", "ContentEventRevive03", "ContentEventRevive04",
		"ContentEventName07", "TemplateId"
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
		_dataArray.Add(new CricketPolymorphEventItem(0, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_0"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_0"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_0"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_0"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_0"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_0"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_0"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_0"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_0"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_0"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_0")));
		_dataArray.Add(new CricketPolymorphEventItem(1, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_1"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_1"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_1"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_1"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_1"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_1"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_1"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_1"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_1"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_1"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_1")));
		_dataArray.Add(new CricketPolymorphEventItem(2, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_2"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_2"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_2"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_2"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_2"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_2"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_2"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_2"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_2"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_2"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_2")));
		_dataArray.Add(new CricketPolymorphEventItem(3, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_3"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_3"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_3"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_3"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_3"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_3"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_3"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_3"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_3"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_3"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_3")));
		_dataArray.Add(new CricketPolymorphEventItem(4, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_4"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_4"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_4"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_4"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_4"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_4"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_4"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_4"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_4"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_4"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_4")));
		_dataArray.Add(new CricketPolymorphEventItem(5, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_5"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_5"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_5"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_5"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_5"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_5"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_5"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_5"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_5"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_5"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_5")));
		_dataArray.Add(new CricketPolymorphEventItem(6, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_6"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_6"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_6"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_6"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_6"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_6"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_6"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_6"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_6"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_6"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_6")));
		_dataArray.Add(new CricketPolymorphEventItem(7, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_7"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_7"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_7"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_7"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_7"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_7"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_7"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_7"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_7"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_7"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_7")));
		_dataArray.Add(new CricketPolymorphEventItem(8, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_8"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_8"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_8"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_8"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_8"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_8"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_8"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_8"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_8"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_8"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_8")));
		_dataArray.Add(new CricketPolymorphEventItem(9, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_9"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_9"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_9"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_9"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_9"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_9"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_9"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_9"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_9"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_9"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_9")));
		_dataArray.Add(new CricketPolymorphEventItem(10, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_10"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_10"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_10"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_10"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_10"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_10"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_10"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_10"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_10"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_10"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_10")));
		_dataArray.Add(new CricketPolymorphEventItem(11, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_11"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_11"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_11"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_11"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_11"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_11"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_11"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_11"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_11"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_11"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_11")));
		_dataArray.Add(new CricketPolymorphEventItem(12, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_12"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_12"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_12"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_12"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_12"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_12"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_12"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_12"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_12"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_12"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_12")));
		_dataArray.Add(new CricketPolymorphEventItem(13, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_13"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_13"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_13"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_13"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_13"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_13"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_13"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_13"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_13"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_13"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_13")));
		_dataArray.Add(new CricketPolymorphEventItem(14, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_14"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_14"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_14"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_14"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_14"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_14"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_14"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_14"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_14"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_14"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_14")));
		_dataArray.Add(new CricketPolymorphEventItem(15, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_15"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_15"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_15"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_15"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_15"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_15"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_15"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_15"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_15"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_15"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_15")));
		_dataArray.Add(new CricketPolymorphEventItem(16, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_16"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_16"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_16"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_16"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_16"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_16"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_16"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_16"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_16"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_16"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_16")));
		_dataArray.Add(new CricketPolymorphEventItem(17, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_17"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_17"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_17"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_17"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_17"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_17"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_17"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_17"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_17"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_17"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_17")));
		_dataArray.Add(new CricketPolymorphEventItem(18, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_18"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_18"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_18"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_18"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_18"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_18"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_18"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_18"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_18"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_18"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_18")));
		_dataArray.Add(new CricketPolymorphEventItem(19, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_19"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_19"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_19"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_19"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_19"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_19"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_19"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_19"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_19"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_19"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_19")));
		_dataArray.Add(new CricketPolymorphEventItem(20, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_20"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_20"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_20"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_20"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_20"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_20"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_20"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_20"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_20"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_20"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_20")));
		_dataArray.Add(new CricketPolymorphEventItem(21, LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEvent02_21"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03_21"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet03Option_21"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet04_21"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet05_21"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventFirstMeet06_21"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain03_21"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventMeetAgain04_21"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive03_21"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventRevive04_21"), LocalStringManager.GetConfig("CricketPolymorphEvent_language", "ContentEventName07_21")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CricketPolymorphEventItem>(22);
		CreateItems0();
	}
}

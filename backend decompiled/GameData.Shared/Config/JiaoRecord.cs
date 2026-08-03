using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class JiaoRecord : ConfigData<JiaoRecordItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 蛟卵孵化
		/// </summary>
		public const short Incubate = 0;

		/// <summary>
		/// 养育方针成长
		/// </summary>
		public const short Grow = 1;

		/// <summary>
		/// 群鱼相戏
		/// </summary>
		public const short PlayWithFish = 2;

		/// <summary>
		/// 水嬉竞渡
		/// </summary>
		public const short PlayWithBoat = 3;

		/// <summary>
		/// 搏龙斗凤
		/// </summary>
		public const short PlayWithLongFeng = 4;

		/// <summary>
		/// 扬锣捣鼓
		/// </summary>
		public const short PlayInstrument = 5;

		/// <summary>
		/// 横姿笔墨
		/// </summary>
		public const short Paint = 6;

		/// <summary>
		/// 赠予珍宝
		/// </summary>
		public const short GiveTreasure = 7;

		/// <summary>
		/// 赠予雅物
		/// </summary>
		public const short GiveCraft = 8;

		/// <summary>
		/// 且歌且舞
		/// </summary>
		public const short DanceWithMusic = 9;

		/// <summary>
		/// 闲谈陪伴
		/// </summary>
		public const short Chat = 10;

		/// <summary>
		/// 随机成长
		/// </summary>
		public const short RandomGrow = 11;

		/// <summary>
		/// 身长增加
		/// </summary>
		public const short HeightGrow = 12;

		/// <summary>
		/// 体重增加
		/// </summary>
		public const short WeightGrow = 13;

		/// <summary>
		/// 寿命增加
		/// </summary>
		public const short LifeGrow = 14;

		/// <summary>
		/// 蛟龙逃脱
		/// </summary>
		public const short Escape = 15;

		/// <summary>
		/// 驯服属性减少
		/// </summary>
		public const short TameBad = 16;

		/// <summary>
		/// 驯服属性增加
		/// </summary>
		public const short TameGood = 17;

		/// <summary>
		/// 蛟龙成年
		/// </summary>
		public const short BecomeAdult = 18;

		/// <summary>
		/// 开始繁育
		/// </summary>
		public const short StartBreeding = 19;

		/// <summary>
		/// 繁育完成
		/// </summary>
		public const short FinishBreeding = 20;

		/// <summary>
		/// 礼物属性随机成长
		/// </summary>
		public const short RandomGrowGift = 21;

		/// <summary>
		/// 驯服礼物属性减少
		/// </summary>
		public const short TameBadGift = 22;

		/// <summary>
		/// 驯服礼物属性增加
		/// </summary>
		public const short TameGoodGift = 23;

		/// <summary>
		/// 养育方针礼物属性
		/// </summary>
		public const short GrowGift = 24;

		/// <summary>
		/// 养育方针百分号数值
		/// </summary>
		public const short GrowPercent = 25;

		/// <summary>
		/// 随机成长百分号数值
		/// </summary>
		public const short RandomGrowPercent = 26;

		/// <summary>
		/// 驯服属性减少百分号数值
		/// </summary>
		public const short TameBadPercent = 27;

		/// <summary>
		/// 驯服属性增加百分号数值
		/// </summary>
		public const short TameGoodPercent = 28;

		/// <summary>
		/// 养育方针浮点数
		/// </summary>
		public const short GrowFloat = 29;

		/// <summary>
		/// 随机成长浮点数
		/// </summary>
		public const short RandomGrowFloat = 30;

		/// <summary>
		/// 驯服属性减少浮点数
		/// </summary>
		public const short TameBadFloat = 31;

		/// <summary>
		/// 驯服属性增加浮点数
		/// </summary>
		public const short TameGoodFloat = 32;

		/// <summary>
		/// 彩帛戏乐
		/// </summary>
		public const short PlayWithFabric = 33;

		/// <summary>
		/// 养育方针百分号数值减少
		/// </summary>
		public const short GrowPercentDecrease = 34;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 蛟卵孵化
		/// </summary>
		public static JiaoRecordItem Incubate => Instance[(short)0];

		/// <summary>
		/// 养育方针成长
		/// </summary>
		public static JiaoRecordItem Grow => Instance[(short)1];

		/// <summary>
		/// 群鱼相戏
		/// </summary>
		public static JiaoRecordItem PlayWithFish => Instance[(short)2];

		/// <summary>
		/// 水嬉竞渡
		/// </summary>
		public static JiaoRecordItem PlayWithBoat => Instance[(short)3];

		/// <summary>
		/// 搏龙斗凤
		/// </summary>
		public static JiaoRecordItem PlayWithLongFeng => Instance[(short)4];

		/// <summary>
		/// 扬锣捣鼓
		/// </summary>
		public static JiaoRecordItem PlayInstrument => Instance[(short)5];

		/// <summary>
		/// 横姿笔墨
		/// </summary>
		public static JiaoRecordItem Paint => Instance[(short)6];

		/// <summary>
		/// 赠予珍宝
		/// </summary>
		public static JiaoRecordItem GiveTreasure => Instance[(short)7];

		/// <summary>
		/// 赠予雅物
		/// </summary>
		public static JiaoRecordItem GiveCraft => Instance[(short)8];

		/// <summary>
		/// 且歌且舞
		/// </summary>
		public static JiaoRecordItem DanceWithMusic => Instance[(short)9];

		/// <summary>
		/// 闲谈陪伴
		/// </summary>
		public static JiaoRecordItem Chat => Instance[(short)10];

		/// <summary>
		/// 随机成长
		/// </summary>
		public static JiaoRecordItem RandomGrow => Instance[(short)11];

		/// <summary>
		/// 身长增加
		/// </summary>
		public static JiaoRecordItem HeightGrow => Instance[(short)12];

		/// <summary>
		/// 体重增加
		/// </summary>
		public static JiaoRecordItem WeightGrow => Instance[(short)13];

		/// <summary>
		/// 寿命增加
		/// </summary>
		public static JiaoRecordItem LifeGrow => Instance[(short)14];

		/// <summary>
		/// 蛟龙逃脱
		/// </summary>
		public static JiaoRecordItem Escape => Instance[(short)15];

		/// <summary>
		/// 驯服属性减少
		/// </summary>
		public static JiaoRecordItem TameBad => Instance[(short)16];

		/// <summary>
		/// 驯服属性增加
		/// </summary>
		public static JiaoRecordItem TameGood => Instance[(short)17];

		/// <summary>
		/// 蛟龙成年
		/// </summary>
		public static JiaoRecordItem BecomeAdult => Instance[(short)18];

		/// <summary>
		/// 开始繁育
		/// </summary>
		public static JiaoRecordItem StartBreeding => Instance[(short)19];

		/// <summary>
		/// 繁育完成
		/// </summary>
		public static JiaoRecordItem FinishBreeding => Instance[(short)20];

		/// <summary>
		/// 礼物属性随机成长
		/// </summary>
		public static JiaoRecordItem RandomGrowGift => Instance[(short)21];

		/// <summary>
		/// 驯服礼物属性减少
		/// </summary>
		public static JiaoRecordItem TameBadGift => Instance[(short)22];

		/// <summary>
		/// 驯服礼物属性增加
		/// </summary>
		public static JiaoRecordItem TameGoodGift => Instance[(short)23];

		/// <summary>
		/// 养育方针礼物属性
		/// </summary>
		public static JiaoRecordItem GrowGift => Instance[(short)24];

		/// <summary>
		/// 养育方针百分号数值
		/// </summary>
		public static JiaoRecordItem GrowPercent => Instance[(short)25];

		/// <summary>
		/// 随机成长百分号数值
		/// </summary>
		public static JiaoRecordItem RandomGrowPercent => Instance[(short)26];

		/// <summary>
		/// 驯服属性减少百分号数值
		/// </summary>
		public static JiaoRecordItem TameBadPercent => Instance[(short)27];

		/// <summary>
		/// 驯服属性增加百分号数值
		/// </summary>
		public static JiaoRecordItem TameGoodPercent => Instance[(short)28];

		/// <summary>
		/// 养育方针浮点数
		/// </summary>
		public static JiaoRecordItem GrowFloat => Instance[(short)29];

		/// <summary>
		/// 随机成长浮点数
		/// </summary>
		public static JiaoRecordItem RandomGrowFloat => Instance[(short)30];

		/// <summary>
		/// 驯服属性减少浮点数
		/// </summary>
		public static JiaoRecordItem TameBadFloat => Instance[(short)31];

		/// <summary>
		/// 驯服属性增加浮点数
		/// </summary>
		public static JiaoRecordItem TameGoodFloat => Instance[(short)32];

		/// <summary>
		/// 彩帛戏乐
		/// </summary>
		public static JiaoRecordItem PlayWithFabric => Instance[(short)33];

		/// <summary>
		/// 养育方针百分号数值减少
		/// </summary>
		public static JiaoRecordItem GrowPercentDecrease => Instance[(short)34];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static JiaoRecord Instance = new JiaoRecord();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Parameters" };

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
		_dataArray.Add(new JiaoRecordItem(0, LocalStringManager.GetConfig("JiaoRecord_language", "Name_0"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_0"), new string[4] { "Jiao1Name", "JiaoEggName", "", "" }));
		_dataArray.Add(new JiaoRecordItem(1, LocalStringManager.GetConfig("JiaoRecord_language", "Name_1"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_1"), new string[4] { "Jiao1Name", "Nurturance", "PropertyType", "Integer" }));
		_dataArray.Add(new JiaoRecordItem(2, LocalStringManager.GetConfig("JiaoRecord_language", "Name_2"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_2"), new string[4] { "Jiao1Name", "Float", "", "" }));
		_dataArray.Add(new JiaoRecordItem(3, LocalStringManager.GetConfig("JiaoRecord_language", "Name_3"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_3"), new string[4] { "Jiao1Name", "Integer", "", "" }));
		_dataArray.Add(new JiaoRecordItem(4, LocalStringManager.GetConfig("JiaoRecord_language", "Name_4"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_4"), new string[4] { "Jiao1Name", "Integer", "", "" }));
		_dataArray.Add(new JiaoRecordItem(5, LocalStringManager.GetConfig("JiaoRecord_language", "Name_5"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_5"), new string[4] { "Jiao1Name", "Integer", "", "" }));
		_dataArray.Add(new JiaoRecordItem(6, LocalStringManager.GetConfig("JiaoRecord_language", "Name_6"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_6"), new string[4] { "Jiao1Name", "Integer", "", "" }));
		_dataArray.Add(new JiaoRecordItem(7, LocalStringManager.GetConfig("JiaoRecord_language", "Name_7"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_7"), new string[4] { "Jiao1Name", "", "", "" }));
		_dataArray.Add(new JiaoRecordItem(8, LocalStringManager.GetConfig("JiaoRecord_language", "Name_8"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_8"), new string[4] { "Jiao1Name", "", "", "" }));
		_dataArray.Add(new JiaoRecordItem(9, LocalStringManager.GetConfig("JiaoRecord_language", "Name_9"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_9"), new string[4] { "Jiao1Name", "", "", "" }));
		_dataArray.Add(new JiaoRecordItem(10, LocalStringManager.GetConfig("JiaoRecord_language", "Name_10"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_10"), new string[4] { "Jiao1Name", "", "", "" }));
		_dataArray.Add(new JiaoRecordItem(11, LocalStringManager.GetConfig("JiaoRecord_language", "Name_11"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_11"), new string[4] { "Jiao1Name", "PropertyType", "Integer", "" }));
		_dataArray.Add(new JiaoRecordItem(12, LocalStringManager.GetConfig("JiaoRecord_language", "Name_12"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_12"), new string[4] { "Jiao1Name", "Integer", "", "" }));
		_dataArray.Add(new JiaoRecordItem(13, LocalStringManager.GetConfig("JiaoRecord_language", "Name_13"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_13"), new string[4] { "Jiao1Name", "Integer", "", "" }));
		_dataArray.Add(new JiaoRecordItem(14, LocalStringManager.GetConfig("JiaoRecord_language", "Name_14"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_14"), new string[4] { "Jiao1Name", "Integer", "", "" }));
		_dataArray.Add(new JiaoRecordItem(15, LocalStringManager.GetConfig("JiaoRecord_language", "Name_15"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_15"), new string[4] { "Jiao1Name", "", "", "" }));
		_dataArray.Add(new JiaoRecordItem(16, LocalStringManager.GetConfig("JiaoRecord_language", "Name_16"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_16"), new string[4] { "Jiao1Name", "PropertyType", "Integer", "" }));
		_dataArray.Add(new JiaoRecordItem(17, LocalStringManager.GetConfig("JiaoRecord_language", "Name_17"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_17"), new string[4] { "Jiao1Name", "PropertyType", "Integer", "" }));
		_dataArray.Add(new JiaoRecordItem(18, LocalStringManager.GetConfig("JiaoRecord_language", "Name_18"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_18"), new string[4] { "Jiao1Name", "", "", "" }));
		_dataArray.Add(new JiaoRecordItem(19, LocalStringManager.GetConfig("JiaoRecord_language", "Name_19"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_19"), new string[4] { "Jiao1Name", "Jiao2Name", "", "" }));
		_dataArray.Add(new JiaoRecordItem(20, LocalStringManager.GetConfig("JiaoRecord_language", "Name_20"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_20"), new string[4] { "Jiao1Name", "Jiao2Name", "JiaoEggName", "" }));
		_dataArray.Add(new JiaoRecordItem(21, LocalStringManager.GetConfig("JiaoRecord_language", "Name_21"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_21"), null));
		_dataArray.Add(new JiaoRecordItem(22, LocalStringManager.GetConfig("JiaoRecord_language", "Name_22"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_22"), new string[4] { "Jiao1Name", "PropertyType", "", "" }));
		_dataArray.Add(new JiaoRecordItem(23, LocalStringManager.GetConfig("JiaoRecord_language", "Name_23"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_23"), new string[4] { "Jiao1Name", "PropertyType", "", "" }));
		_dataArray.Add(new JiaoRecordItem(24, LocalStringManager.GetConfig("JiaoRecord_language", "Name_24"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_24"), new string[4] { "Jiao1Name", "Nurturance", "PropertyType", "" }));
		_dataArray.Add(new JiaoRecordItem(25, LocalStringManager.GetConfig("JiaoRecord_language", "Name_25"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_25"), new string[4] { "Jiao1Name", "Nurturance", "PropertyType", "Integer" }));
		_dataArray.Add(new JiaoRecordItem(26, LocalStringManager.GetConfig("JiaoRecord_language", "Name_26"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_26"), new string[4] { "Jiao1Name", "PropertyType", "Integer", "" }));
		_dataArray.Add(new JiaoRecordItem(27, LocalStringManager.GetConfig("JiaoRecord_language", "Name_27"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_27"), new string[4] { "Jiao1Name", "PropertyType", "Integer", "" }));
		_dataArray.Add(new JiaoRecordItem(28, LocalStringManager.GetConfig("JiaoRecord_language", "Name_28"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_28"), new string[4] { "Jiao1Name", "PropertyType", "Integer", "" }));
		_dataArray.Add(new JiaoRecordItem(29, LocalStringManager.GetConfig("JiaoRecord_language", "Name_29"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_29"), new string[4] { "Jiao1Name", "Nurturance", "PropertyType", "Float" }));
		_dataArray.Add(new JiaoRecordItem(30, LocalStringManager.GetConfig("JiaoRecord_language", "Name_30"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_30"), new string[4] { "Jiao1Name", "PropertyType", "Float", "" }));
		_dataArray.Add(new JiaoRecordItem(31, LocalStringManager.GetConfig("JiaoRecord_language", "Name_31"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_31"), new string[4] { "Jiao1Name", "PropertyType", "Float", "" }));
		_dataArray.Add(new JiaoRecordItem(32, LocalStringManager.GetConfig("JiaoRecord_language", "Name_32"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_32"), new string[4] { "Jiao1Name", "PropertyType", "Float", "" }));
		_dataArray.Add(new JiaoRecordItem(33, LocalStringManager.GetConfig("JiaoRecord_language", "Name_33"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_33"), new string[4] { "Jiao1Name", "Integer", "", "" }));
		_dataArray.Add(new JiaoRecordItem(34, LocalStringManager.GetConfig("JiaoRecord_language", "Name_34"), LocalStringManager.GetConfig("JiaoRecord_language", "Desc_34"), new string[4] { "Jiao1Name", "Nurturance", "PropertyType", "Integer" }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<JiaoRecordItem>(35);
		CreateItems0();
	}
}

using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class JiaoRecord : ConfigData<JiaoRecordItem, short>
{
	public static class DefKey
	{
		public const short Incubate = 0;

		public const short Grow = 1;

		public const short PlayWithFish = 2;

		public const short PlayWithBoat = 3;

		public const short PlayWithLongFeng = 4;

		public const short PlayInstrument = 5;

		public const short Paint = 6;

		public const short GiveTreasure = 7;

		public const short GiveCraft = 8;

		public const short DanceWithMusic = 9;

		public const short Chat = 10;

		public const short RandomGrow = 11;

		public const short HeightGrow = 12;

		public const short WeightGrow = 13;

		public const short LifeGrow = 14;

		public const short Escape = 15;

		public const short TameBad = 16;

		public const short TameGood = 17;

		public const short BecomeAdult = 18;

		public const short StartBreeding = 19;

		public const short FinishBreeding = 20;

		public const short RandomGrowGift = 21;

		public const short TameBadGift = 22;

		public const short TameGoodGift = 23;

		public const short GrowGift = 24;

		public const short GrowPercent = 25;

		public const short RandomGrowPercent = 26;

		public const short TameBadPercent = 27;

		public const short TameGoodPercent = 28;

		public const short GrowFloat = 29;

		public const short RandomGrowFloat = 30;

		public const short TameBadFloat = 31;

		public const short TameGoodFloat = 32;

		public const short PlayWithFabric = 33;

		public const short GrowPercentDecrease = 34;
	}

	public static class DefValue
	{
		public static JiaoRecordItem Incubate => Instance[(short)0];

		public static JiaoRecordItem Grow => Instance[(short)1];

		public static JiaoRecordItem PlayWithFish => Instance[(short)2];

		public static JiaoRecordItem PlayWithBoat => Instance[(short)3];

		public static JiaoRecordItem PlayWithLongFeng => Instance[(short)4];

		public static JiaoRecordItem PlayInstrument => Instance[(short)5];

		public static JiaoRecordItem Paint => Instance[(short)6];

		public static JiaoRecordItem GiveTreasure => Instance[(short)7];

		public static JiaoRecordItem GiveCraft => Instance[(short)8];

		public static JiaoRecordItem DanceWithMusic => Instance[(short)9];

		public static JiaoRecordItem Chat => Instance[(short)10];

		public static JiaoRecordItem RandomGrow => Instance[(short)11];

		public static JiaoRecordItem HeightGrow => Instance[(short)12];

		public static JiaoRecordItem WeightGrow => Instance[(short)13];

		public static JiaoRecordItem LifeGrow => Instance[(short)14];

		public static JiaoRecordItem Escape => Instance[(short)15];

		public static JiaoRecordItem TameBad => Instance[(short)16];

		public static JiaoRecordItem TameGood => Instance[(short)17];

		public static JiaoRecordItem BecomeAdult => Instance[(short)18];

		public static JiaoRecordItem StartBreeding => Instance[(short)19];

		public static JiaoRecordItem FinishBreeding => Instance[(short)20];

		public static JiaoRecordItem RandomGrowGift => Instance[(short)21];

		public static JiaoRecordItem TameBadGift => Instance[(short)22];

		public static JiaoRecordItem TameGoodGift => Instance[(short)23];

		public static JiaoRecordItem GrowGift => Instance[(short)24];

		public static JiaoRecordItem GrowPercent => Instance[(short)25];

		public static JiaoRecordItem RandomGrowPercent => Instance[(short)26];

		public static JiaoRecordItem TameBadPercent => Instance[(short)27];

		public static JiaoRecordItem TameGoodPercent => Instance[(short)28];

		public static JiaoRecordItem GrowFloat => Instance[(short)29];

		public static JiaoRecordItem RandomGrowFloat => Instance[(short)30];

		public static JiaoRecordItem TameBadFloat => Instance[(short)31];

		public static JiaoRecordItem TameGoodFloat => Instance[(short)32];

		public static JiaoRecordItem PlayWithFabric => Instance[(short)33];

		public static JiaoRecordItem GrowPercentDecrease => Instance[(short)34];
	}

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

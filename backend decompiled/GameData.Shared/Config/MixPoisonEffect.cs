using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MixPoisonEffect : ConfigData<MixPoisonEffectItem, sbyte>
{
	public static class DefKey
	{
		public const sbyte MixPoisonEffect034 = 0;

		public const sbyte MixPoisonEffect045 = 1;

		public const sbyte MixPoisonEffect014 = 2;

		public const sbyte MixPoisonEffect024 = 3;

		public const sbyte MixPoisonEffect345 = 4;

		public const sbyte MixPoisonEffect134 = 5;

		public const sbyte MixPoisonEffect234 = 6;

		public const sbyte MixPoisonEffect035 = 7;

		public const sbyte MixPoisonEffect013 = 8;

		public const sbyte MixPoisonEffect023 = 9;

		public const sbyte MixPoisonEffect125 = 10;

		public const sbyte MixPoisonEffect124 = 11;

		public const sbyte MixPoisonEffect012 = 12;

		public const sbyte MixPoisonEffect123 = 13;

		public const sbyte MixPoisonEffect245 = 14;

		public const sbyte MixPoisonEffect025 = 15;

		public const sbyte MixPoisonEffect235 = 16;

		public const sbyte MixPoisonEffect145 = 17;

		public const sbyte MixPoisonEffect015 = 18;

		public const sbyte MixPoisonEffect135 = 19;
	}

	public static class DefValue
	{
		public static MixPoisonEffectItem MixPoisonEffect034 => Instance[(sbyte)0];

		public static MixPoisonEffectItem MixPoisonEffect045 => Instance[(sbyte)1];

		public static MixPoisonEffectItem MixPoisonEffect014 => Instance[(sbyte)2];

		public static MixPoisonEffectItem MixPoisonEffect024 => Instance[(sbyte)3];

		public static MixPoisonEffectItem MixPoisonEffect345 => Instance[(sbyte)4];

		public static MixPoisonEffectItem MixPoisonEffect134 => Instance[(sbyte)5];

		public static MixPoisonEffectItem MixPoisonEffect234 => Instance[(sbyte)6];

		public static MixPoisonEffectItem MixPoisonEffect035 => Instance[(sbyte)7];

		public static MixPoisonEffectItem MixPoisonEffect013 => Instance[(sbyte)8];

		public static MixPoisonEffectItem MixPoisonEffect023 => Instance[(sbyte)9];

		public static MixPoisonEffectItem MixPoisonEffect125 => Instance[(sbyte)10];

		public static MixPoisonEffectItem MixPoisonEffect124 => Instance[(sbyte)11];

		public static MixPoisonEffectItem MixPoisonEffect012 => Instance[(sbyte)12];

		public static MixPoisonEffectItem MixPoisonEffect123 => Instance[(sbyte)13];

		public static MixPoisonEffectItem MixPoisonEffect245 => Instance[(sbyte)14];

		public static MixPoisonEffectItem MixPoisonEffect025 => Instance[(sbyte)15];

		public static MixPoisonEffectItem MixPoisonEffect235 => Instance[(sbyte)16];

		public static MixPoisonEffectItem MixPoisonEffect145 => Instance[(sbyte)17];

		public static MixPoisonEffectItem MixPoisonEffect015 => Instance[(sbyte)18];

		public static MixPoisonEffectItem MixPoisonEffect135 => Instance[(sbyte)19];
	}

	public static MixPoisonEffect Instance = new MixPoisonEffect();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "ShortDesc", "MedicineId", "EffectId", "HasPoisonTypes", "AffectPoisonTypes", "LifeRecord", "TemplateId" };

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
		_dataArray.Add(new MixPoisonEffectItem(0, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_0"), 404, 1642, new sbyte[3] { 0, 3, 4 }, new sbyte[2] { 0, 3 }, instantEffect: false, 608));
		_dataArray.Add(new MixPoisonEffectItem(1, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_1"), 405, 1643, new sbyte[3] { 0, 4, 5 }, new sbyte[1], instantEffect: true, 609));
		_dataArray.Add(new MixPoisonEffectItem(2, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_2"), 406, 1644, new sbyte[3] { 0, 1, 4 }, new sbyte[2] { 0, 1 }, instantEffect: false, 610));
		_dataArray.Add(new MixPoisonEffectItem(3, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_3"), 407, 1645, new sbyte[3] { 0, 2, 4 }, new sbyte[2] { 0, 2 }, instantEffect: true, 611));
		_dataArray.Add(new MixPoisonEffectItem(4, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_4"), 408, 1646, new sbyte[3] { 3, 4, 5 }, new sbyte[1] { 3 }, instantEffect: true, 612));
		_dataArray.Add(new MixPoisonEffectItem(5, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_5"), 409, 1647, new sbyte[3] { 1, 3, 4 }, new sbyte[2] { 1, 3 }, instantEffect: true, 613));
		_dataArray.Add(new MixPoisonEffectItem(6, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_6"), 410, 1648, new sbyte[3] { 3, 2, 4 }, new sbyte[2] { 3, 2 }, instantEffect: false, 614));
		_dataArray.Add(new MixPoisonEffectItem(7, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_7"), 411, 1649, new sbyte[3] { 0, 3, 5 }, new sbyte[2] { 0, 3 }, instantEffect: false, 615));
		_dataArray.Add(new MixPoisonEffectItem(8, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_8"), 412, 1650, new sbyte[3] { 0, 1, 3 }, new sbyte[3] { 0, 1, 3 }, instantEffect: false, 616));
		_dataArray.Add(new MixPoisonEffectItem(9, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_9"), 413, 1651, new sbyte[3] { 0, 3, 2 }, new sbyte[3] { 0, 3, 2 }, instantEffect: false, 617));
		_dataArray.Add(new MixPoisonEffectItem(10, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_10"), 414, 1652, new sbyte[3] { 1, 2, 5 }, new sbyte[2] { 1, 2 }, instantEffect: true, 618));
		_dataArray.Add(new MixPoisonEffectItem(11, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_11"), 415, 1653, new sbyte[3] { 1, 2, 4 }, new sbyte[2] { 1, 2 }, instantEffect: false, 619));
		_dataArray.Add(new MixPoisonEffectItem(12, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_12"), 416, 1654, new sbyte[3] { 0, 1, 2 }, new sbyte[3] { 0, 1, 2 }, instantEffect: false, 620));
		_dataArray.Add(new MixPoisonEffectItem(13, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_13"), 417, 1655, new sbyte[3] { 1, 3, 2 }, new sbyte[3] { 1, 3, 2 }, instantEffect: false, 621));
		_dataArray.Add(new MixPoisonEffectItem(14, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_14"), 418, 1656, new sbyte[3] { 2, 4, 5 }, new sbyte[1] { 2 }, instantEffect: true, 622));
		_dataArray.Add(new MixPoisonEffectItem(15, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_15"), 419, 1657, new sbyte[3] { 0, 2, 5 }, new sbyte[2] { 0, 2 }, instantEffect: true, 623));
		_dataArray.Add(new MixPoisonEffectItem(16, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_16"), 420, 1658, new sbyte[3] { 3, 2, 5 }, new sbyte[2] { 3, 2 }, instantEffect: false, 624));
		_dataArray.Add(new MixPoisonEffectItem(17, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_17"), 421, 1659, new sbyte[3] { 1, 4, 5 }, new sbyte[1] { 1 }, instantEffect: true, 625));
		_dataArray.Add(new MixPoisonEffectItem(18, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_18"), 422, 1660, new sbyte[3] { 0, 1, 5 }, new sbyte[2] { 0, 1 }, instantEffect: false, 626));
		_dataArray.Add(new MixPoisonEffectItem(19, LocalStringManager.GetConfig("MixPoisonEffect_language", "ShortDesc_19"), 423, 1661, new sbyte[3] { 1, 3, 5 }, new sbyte[2] { 1, 3 }, instantEffect: true, 627));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MixPoisonEffectItem>(20);
		CreateItems0();
	}
}

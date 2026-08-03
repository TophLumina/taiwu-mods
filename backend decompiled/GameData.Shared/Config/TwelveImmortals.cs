using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TwelveImmortals : ConfigData<TwelveImmortalsItem, sbyte>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 九嫣
		/// </summary>
		public const sbyte Jiuyan = 1;

		/// <summary>
		/// 夜华夫人
		/// </summary>
		public const sbyte YehuaFuren = 2;

		/// <summary>
		/// 素瑕
		/// </summary>
		public const sbyte Suxia = 4;

		/// <summary>
		/// 活骨师
		/// </summary>
		public const sbyte HuoguShi = 8;

		/// <summary>
		/// 幽宵
		/// </summary>
		public const sbyte Youxiao = 11;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 九嫣
		/// </summary>
		public static TwelveImmortalsItem Jiuyan => Instance[(sbyte)1];

		/// <summary>
		/// 夜华夫人
		/// </summary>
		public static TwelveImmortalsItem YehuaFuren => Instance[(sbyte)2];

		/// <summary>
		/// 素瑕
		/// </summary>
		public static TwelveImmortalsItem Suxia => Instance[(sbyte)4];

		/// <summary>
		/// 活骨师
		/// </summary>
		public static TwelveImmortalsItem HuoguShi => Instance[(sbyte)8];

		/// <summary>
		/// 幽宵
		/// </summary>
		public static TwelveImmortalsItem Youxiao => Instance[(sbyte)11];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TwelveImmortals Instance = new TwelveImmortals();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Character", "CombatSkill", "MapState", "TreasureDesc", "TreasureState1", "TreasureState0", "TreasureName", "TemplateId", "ImpactRange", "Group" };

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
		_dataArray.Add(new TwelveImmortalsItem(0, 1075, 924, 4, 2, 0, LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureDesc_0"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState1_0"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState0_0"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureName_0")));
		_dataArray.Add(new TwelveImmortalsItem(1, 1076, 925, 3, 14, 0, LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureDesc_1"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState1_1"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState0_1"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureName_1")));
		_dataArray.Add(new TwelveImmortalsItem(2, 1077, 926, 5, 10, 0, LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureDesc_2"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState1_2"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState0_2"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureName_2")));
		_dataArray.Add(new TwelveImmortalsItem(3, 1078, 927, 6, 8, 0, LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureDesc_3"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState1_3"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState0_3"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureName_3")));
		_dataArray.Add(new TwelveImmortalsItem(4, 1079, 928, 4, 12, 1, LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureDesc_4"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState1_4"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState0_4"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureName_4")));
		_dataArray.Add(new TwelveImmortalsItem(5, 1080, 929, 6, 11, 1, LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureDesc_5"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState1_5"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState0_5"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureName_5")));
		_dataArray.Add(new TwelveImmortalsItem(6, 1081, 930, 4, 1, 1, LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureDesc_6"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState1_6"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState0_6"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureName_6")));
		_dataArray.Add(new TwelveImmortalsItem(7, 1082, 931, 3, 13, 1, LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureDesc_7"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState1_7"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState0_7"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureName_7")));
		_dataArray.Add(new TwelveImmortalsItem(8, 1083, 932, 6, 3, 2, LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureDesc_8"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState1_8"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState0_8"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureName_8")));
		_dataArray.Add(new TwelveImmortalsItem(9, 1084, 933, 4, 7, 2, LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureDesc_9"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState1_9"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState0_9"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureName_9")));
		_dataArray.Add(new TwelveImmortalsItem(10, 1085, 934, 4, 6, 2, LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureDesc_10"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState1_10"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState0_10"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureName_10")));
		_dataArray.Add(new TwelveImmortalsItem(11, 1086, 935, 5, 15, 2, LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureDesc_11"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState1_11"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureState0_11"), LocalStringManager.GetConfig("TwelveImmortals_language", "TreasureName_11")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TwelveImmortalsItem>(12);
		CreateItems0();
	}
}

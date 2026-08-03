using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleActionRecord : ConfigData<VillagerRoleActionRecordItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 采撷累备资源
		/// </summary>
		public const short FarmerAutoCollectResource = 0;

		/// <summary>
		/// 采撷累备引子
		/// </summary>
		public const short FarmerAutoCollectMaterial = 1;

		/// <summary>
		/// 采集资源
		/// </summary>
		public const short FarmerCollectResource = 2;

		/// <summary>
		/// 迁移资源
		/// </summary>
		public const short FarmerMigrate = 3;

		/// <summary>
		/// 举炊备膳
		/// </summary>
		public const short FarmerCraft = 4;

		/// <summary>
		/// 修理物品
		/// </summary>
		public const short CraftsmanRepair = 5;

		/// <summary>
		/// 巧手匠心
		/// </summary>
		public const short CraftsmanRefine = 6;

		/// <summary>
		/// 制造物品
		/// </summary>
		public const short CraftsmanCraft = 7;

		/// <summary>
		/// 悬壶济世数量
		/// </summary>
		public const short DoctorAutoCureAmount = 8;

		/// <summary>
		/// 悬壶济世威望
		/// </summary>
		public const short DoctorAutoCureAuthoriy = 9;

		/// <summary>
		/// 义诊扶危数量
		/// </summary>
		public const short DoctorCureAmount = 10;

		/// <summary>
		/// 义诊扶危恩义
		/// </summary>
		public const short DoctorCureSpiritualDebt = 11;

		/// <summary>
		/// 制药炼毒
		/// </summary>
		public const short DoctorCraft = 12;

		/// <summary>
		/// 筹算损益
		/// </summary>
		public const short MerchantEarn = 13;

		/// <summary>
		/// 经商行贾买
		/// </summary>
		public const short MerchantBuy = 14;

		/// <summary>
		/// 经商行贾卖
		/// </summary>
		public const short MerchantSell = 15;

		/// <summary>
		/// 试才献艺增加
		/// </summary>
		public const short LiteratiAutoIncrease = 16;

		/// <summary>
		/// 试才献艺减少
		/// </summary>
		public const short LiteratiAutoDecrease = 17;

		/// <summary>
		/// 江湖游艺增加文化
		/// </summary>
		public const short LiteratiIncreaseCulture = 18;

		/// <summary>
		/// 江湖游艺增加安定
		/// </summary>
		public const short LiteratiIncreaseSafety = 19;

		/// <summary>
		/// 江湖游艺减少文化
		/// </summary>
		public const short LiteratiDecreaseCulture = 20;

		/// <summary>
		/// 江湖游艺减少安定
		/// </summary>
		public const short LiteratiDecreaseSafety = 21;

		/// <summary>
		/// 采茶取酒
		/// </summary>
		public const short LiteratiCraft = 22;

		/// <summary>
		/// 行侠仗义
		/// </summary>
		public const short KeeperFight = 23;

		/// <summary>
		/// 驻守剑冢收集
		/// </summary>
		public const short KeeperCollect = 24;

		/// <summary>
		/// 驻守剑冢受伤
		/// </summary>
		public const short KeeperHurt = 25;

		/// <summary>
		/// 人情世故增加
		/// </summary>
		public const short HeadIncrease = 26;

		/// <summary>
		/// 人情世故减少
		/// </summary>
		public const short HeadDecrease = 27;

		/// <summary>
		/// 访驻周旋数量
		/// </summary>
		public const short HeadAmount = 28;

		/// <summary>
		/// 访驻周旋消耗
		/// </summary>
		public const short HeadConsume = 29;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 采撷累备资源
		/// </summary>
		public static VillagerRoleActionRecordItem FarmerAutoCollectResource => Instance[(short)0];

		/// <summary>
		/// 采撷累备引子
		/// </summary>
		public static VillagerRoleActionRecordItem FarmerAutoCollectMaterial => Instance[(short)1];

		/// <summary>
		/// 采集资源
		/// </summary>
		public static VillagerRoleActionRecordItem FarmerCollectResource => Instance[(short)2];

		/// <summary>
		/// 迁移资源
		/// </summary>
		public static VillagerRoleActionRecordItem FarmerMigrate => Instance[(short)3];

		/// <summary>
		/// 举炊备膳
		/// </summary>
		public static VillagerRoleActionRecordItem FarmerCraft => Instance[(short)4];

		/// <summary>
		/// 修理物品
		/// </summary>
		public static VillagerRoleActionRecordItem CraftsmanRepair => Instance[(short)5];

		/// <summary>
		/// 巧手匠心
		/// </summary>
		public static VillagerRoleActionRecordItem CraftsmanRefine => Instance[(short)6];

		/// <summary>
		/// 制造物品
		/// </summary>
		public static VillagerRoleActionRecordItem CraftsmanCraft => Instance[(short)7];

		/// <summary>
		/// 悬壶济世数量
		/// </summary>
		public static VillagerRoleActionRecordItem DoctorAutoCureAmount => Instance[(short)8];

		/// <summary>
		/// 悬壶济世威望
		/// </summary>
		public static VillagerRoleActionRecordItem DoctorAutoCureAuthoriy => Instance[(short)9];

		/// <summary>
		/// 义诊扶危数量
		/// </summary>
		public static VillagerRoleActionRecordItem DoctorCureAmount => Instance[(short)10];

		/// <summary>
		/// 义诊扶危恩义
		/// </summary>
		public static VillagerRoleActionRecordItem DoctorCureSpiritualDebt => Instance[(short)11];

		/// <summary>
		/// 制药炼毒
		/// </summary>
		public static VillagerRoleActionRecordItem DoctorCraft => Instance[(short)12];

		/// <summary>
		/// 筹算损益
		/// </summary>
		public static VillagerRoleActionRecordItem MerchantEarn => Instance[(short)13];

		/// <summary>
		/// 经商行贾买
		/// </summary>
		public static VillagerRoleActionRecordItem MerchantBuy => Instance[(short)14];

		/// <summary>
		/// 经商行贾卖
		/// </summary>
		public static VillagerRoleActionRecordItem MerchantSell => Instance[(short)15];

		/// <summary>
		/// 试才献艺增加
		/// </summary>
		public static VillagerRoleActionRecordItem LiteratiAutoIncrease => Instance[(short)16];

		/// <summary>
		/// 试才献艺减少
		/// </summary>
		public static VillagerRoleActionRecordItem LiteratiAutoDecrease => Instance[(short)17];

		/// <summary>
		/// 江湖游艺增加文化
		/// </summary>
		public static VillagerRoleActionRecordItem LiteratiIncreaseCulture => Instance[(short)18];

		/// <summary>
		/// 江湖游艺增加安定
		/// </summary>
		public static VillagerRoleActionRecordItem LiteratiIncreaseSafety => Instance[(short)19];

		/// <summary>
		/// 江湖游艺减少文化
		/// </summary>
		public static VillagerRoleActionRecordItem LiteratiDecreaseCulture => Instance[(short)20];

		/// <summary>
		/// 江湖游艺减少安定
		/// </summary>
		public static VillagerRoleActionRecordItem LiteratiDecreaseSafety => Instance[(short)21];

		/// <summary>
		/// 采茶取酒
		/// </summary>
		public static VillagerRoleActionRecordItem LiteratiCraft => Instance[(short)22];

		/// <summary>
		/// 行侠仗义
		/// </summary>
		public static VillagerRoleActionRecordItem KeeperFight => Instance[(short)23];

		/// <summary>
		/// 驻守剑冢收集
		/// </summary>
		public static VillagerRoleActionRecordItem KeeperCollect => Instance[(short)24];

		/// <summary>
		/// 驻守剑冢受伤
		/// </summary>
		public static VillagerRoleActionRecordItem KeeperHurt => Instance[(short)25];

		/// <summary>
		/// 人情世故增加
		/// </summary>
		public static VillagerRoleActionRecordItem HeadIncrease => Instance[(short)26];

		/// <summary>
		/// 人情世故减少
		/// </summary>
		public static VillagerRoleActionRecordItem HeadDecrease => Instance[(short)27];

		/// <summary>
		/// 访驻周旋数量
		/// </summary>
		public static VillagerRoleActionRecordItem HeadAmount => Instance[(short)28];

		/// <summary>
		/// 访驻周旋消耗
		/// </summary>
		public static VillagerRoleActionRecordItem HeadConsume => Instance[(short)29];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static VillagerRoleActionRecord Instance = new VillagerRoleActionRecord();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "VillagerRoleAutoAction", "VillagerRoleArrangement", "TemplateId", "Icon" };

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
		_dataArray.Add(new VillagerRoleActionRecordItem(0, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_0"), null, 0, -1));
		_dataArray.Add(new VillagerRoleActionRecordItem(1, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_1"), null, 0, -1));
		_dataArray.Add(new VillagerRoleActionRecordItem(2, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_2"), null, -1, 1));
		_dataArray.Add(new VillagerRoleActionRecordItem(3, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_3"), null, -1, 2));
		_dataArray.Add(new VillagerRoleActionRecordItem(4, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_4"), null, -1, 0));
		_dataArray.Add(new VillagerRoleActionRecordItem(5, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_5"), null, 1, -1));
		_dataArray.Add(new VillagerRoleActionRecordItem(6, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_6"), null, 2, -1));
		_dataArray.Add(new VillagerRoleActionRecordItem(7, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_7"), null, -1, 4));
		_dataArray.Add(new VillagerRoleActionRecordItem(8, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_8"), null, 4, -1));
		_dataArray.Add(new VillagerRoleActionRecordItem(9, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_9"), "ui9_icon_resource_bar_7", 4, -1));
		_dataArray.Add(new VillagerRoleActionRecordItem(10, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_10"), null, -1, 6));
		_dataArray.Add(new VillagerRoleActionRecordItem(11, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_11"), "ui9_icon_resource_bar_10", -1, 6));
		_dataArray.Add(new VillagerRoleActionRecordItem(12, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_12"), null, -1, 5));
		_dataArray.Add(new VillagerRoleActionRecordItem(13, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_13"), "ui9_icon_resource_bar_6", 5, -1));
		_dataArray.Add(new VillagerRoleActionRecordItem(14, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_14"), null, -1, 8));
		_dataArray.Add(new VillagerRoleActionRecordItem(15, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_15"), "ui9_icon_resource_bar_6", -1, 8));
		_dataArray.Add(new VillagerRoleActionRecordItem(16, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_16"), null, 6, -1));
		_dataArray.Add(new VillagerRoleActionRecordItem(17, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_17"), null, 6, -1));
		_dataArray.Add(new VillagerRoleActionRecordItem(18, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_18"), null, -1, 11));
		_dataArray.Add(new VillagerRoleActionRecordItem(19, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_19"), null, -1, 11));
		_dataArray.Add(new VillagerRoleActionRecordItem(20, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_20"), null, -1, 11));
		_dataArray.Add(new VillagerRoleActionRecordItem(21, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_21"), null, -1, 11));
		_dataArray.Add(new VillagerRoleActionRecordItem(22, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_22"), null, -1, 10));
		_dataArray.Add(new VillagerRoleActionRecordItem(23, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_23"), null, 7, -1));
		_dataArray.Add(new VillagerRoleActionRecordItem(24, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_24"), null, -1, 13));
		_dataArray.Add(new VillagerRoleActionRecordItem(25, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_25"), null, -1, 13));
		_dataArray.Add(new VillagerRoleActionRecordItem(26, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_26"), null, 8, -1));
		_dataArray.Add(new VillagerRoleActionRecordItem(27, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_27"), null, 8, -1));
		_dataArray.Add(new VillagerRoleActionRecordItem(28, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_28"), null, -1, 15));
		_dataArray.Add(new VillagerRoleActionRecordItem(29, LocalStringManager.GetConfig("VillagerRoleActionRecord_language", "Name_29"), "ui9_icon_resource_bar_7", -1, 15));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<VillagerRoleActionRecordItem>(30);
		CreateItems0();
	}
}

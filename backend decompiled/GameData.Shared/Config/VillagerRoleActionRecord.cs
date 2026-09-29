using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleActionRecord : ConfigData<VillagerRoleActionRecordItem, short>
{
	public static class DefKey
	{
		public const short FarmerAutoCollectResource = 0;

		public const short FarmerAutoCollectMaterial = 1;

		public const short FarmerCollectResource = 2;

		public const short FarmerMigrate = 3;

		public const short FarmerCraft = 4;

		public const short CraftsmanRepair = 5;

		public const short CraftsmanRefine = 6;

		public const short CraftsmanCraft = 7;

		public const short DoctorAutoCureAmount = 8;

		public const short DoctorAutoCureAuthoriy = 9;

		public const short DoctorCureAmount = 10;

		public const short DoctorCureSpiritualDebt = 11;

		public const short DoctorCraft = 12;

		public const short MerchantEarn = 13;

		public const short MerchantBuy = 14;

		public const short MerchantSell = 15;

		public const short LiteratiAutoIncrease = 16;

		public const short LiteratiAutoDecrease = 17;

		public const short LiteratiIncreaseCulture = 18;

		public const short LiteratiIncreaseSafety = 19;

		public const short LiteratiDecreaseCulture = 20;

		public const short LiteratiDecreaseSafety = 21;

		public const short LiteratiCraft = 22;

		public const short KeeperFight = 23;

		public const short KeeperCollect = 24;

		public const short KeeperHurt = 25;

		public const short HeadIncrease = 26;

		public const short HeadDecrease = 27;

		public const short HeadAmount = 28;

		public const short HeadConsume = 29;
	}

	public static class DefValue
	{
		public static VillagerRoleActionRecordItem FarmerAutoCollectResource => Instance[(short)0];

		public static VillagerRoleActionRecordItem FarmerAutoCollectMaterial => Instance[(short)1];

		public static VillagerRoleActionRecordItem FarmerCollectResource => Instance[(short)2];

		public static VillagerRoleActionRecordItem FarmerMigrate => Instance[(short)3];

		public static VillagerRoleActionRecordItem FarmerCraft => Instance[(short)4];

		public static VillagerRoleActionRecordItem CraftsmanRepair => Instance[(short)5];

		public static VillagerRoleActionRecordItem CraftsmanRefine => Instance[(short)6];

		public static VillagerRoleActionRecordItem CraftsmanCraft => Instance[(short)7];

		public static VillagerRoleActionRecordItem DoctorAutoCureAmount => Instance[(short)8];

		public static VillagerRoleActionRecordItem DoctorAutoCureAuthoriy => Instance[(short)9];

		public static VillagerRoleActionRecordItem DoctorCureAmount => Instance[(short)10];

		public static VillagerRoleActionRecordItem DoctorCureSpiritualDebt => Instance[(short)11];

		public static VillagerRoleActionRecordItem DoctorCraft => Instance[(short)12];

		public static VillagerRoleActionRecordItem MerchantEarn => Instance[(short)13];

		public static VillagerRoleActionRecordItem MerchantBuy => Instance[(short)14];

		public static VillagerRoleActionRecordItem MerchantSell => Instance[(short)15];

		public static VillagerRoleActionRecordItem LiteratiAutoIncrease => Instance[(short)16];

		public static VillagerRoleActionRecordItem LiteratiAutoDecrease => Instance[(short)17];

		public static VillagerRoleActionRecordItem LiteratiIncreaseCulture => Instance[(short)18];

		public static VillagerRoleActionRecordItem LiteratiIncreaseSafety => Instance[(short)19];

		public static VillagerRoleActionRecordItem LiteratiDecreaseCulture => Instance[(short)20];

		public static VillagerRoleActionRecordItem LiteratiDecreaseSafety => Instance[(short)21];

		public static VillagerRoleActionRecordItem LiteratiCraft => Instance[(short)22];

		public static VillagerRoleActionRecordItem KeeperFight => Instance[(short)23];

		public static VillagerRoleActionRecordItem KeeperCollect => Instance[(short)24];

		public static VillagerRoleActionRecordItem KeeperHurt => Instance[(short)25];

		public static VillagerRoleActionRecordItem HeadIncrease => Instance[(short)26];

		public static VillagerRoleActionRecordItem HeadDecrease => Instance[(short)27];

		public static VillagerRoleActionRecordItem HeadAmount => Instance[(short)28];

		public static VillagerRoleActionRecordItem HeadConsume => Instance[(short)29];
	}

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

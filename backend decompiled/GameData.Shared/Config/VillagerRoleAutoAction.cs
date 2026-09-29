using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class VillagerRoleAutoAction : ConfigData<VillagerRoleAutoActionItem, short>
{
	public static class DefKey
	{
		public const short FarmerAutoCollectResource = 0;

		public const short CraftsmanRepairItems = 1;

		public const short CraftsmanGetMaterial = 2;

		public const short CraftsmanImproveMaterial = 3;

		public const short DoctorCureOthers = 4;

		public const short MerchantCollectMoney = 5;

		public const short LiteratiEntertainOthers = 6;

		public const short SwordTombKeeperFightHeretics = 7;

		public const short VillageHeadBuildRelationships = 8;

		public const short VillageChangeRelationships = 9;
	}

	public static class DefValue
	{
		public static VillagerRoleAutoActionItem FarmerAutoCollectResource => Instance[(short)0];

		public static VillagerRoleAutoActionItem CraftsmanRepairItems => Instance[(short)1];

		public static VillagerRoleAutoActionItem CraftsmanGetMaterial => Instance[(short)2];

		public static VillagerRoleAutoActionItem CraftsmanImproveMaterial => Instance[(short)3];

		public static VillagerRoleAutoActionItem DoctorCureOthers => Instance[(short)4];

		public static VillagerRoleAutoActionItem MerchantCollectMoney => Instance[(short)5];

		public static VillagerRoleAutoActionItem LiteratiEntertainOthers => Instance[(short)6];

		public static VillagerRoleAutoActionItem SwordTombKeeperFightHeretics => Instance[(short)7];

		public static VillagerRoleAutoActionItem VillageHeadBuildRelationships => Instance[(short)8];

		public static VillagerRoleAutoActionItem VillageChangeRelationships => Instance[(short)9];
	}

	public static VillagerRoleAutoAction Instance = new VillagerRoleAutoAction();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"VillagerRole", "ShortName", "Name", "Desc", "DescName", "DescShort", "DescContent", "TemplateId", "DisplayIcon", "DisplayIcon2",
		"Illustration"
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
		_dataArray.Add(new VillagerRoleAutoActionItem(0, 0, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "ShortName_0"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Name_0"), null, null, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Desc_0"), unlockByChicken: false, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescName_0"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescShort_0"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescContent_0"), "ui9_back_villagerrole_Illustration_0_4"));
		_dataArray.Add(new VillagerRoleAutoActionItem(1, 1, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "ShortName_1"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Name_1"), null, null, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Desc_1"), unlockByChicken: false, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescName_1"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescShort_1"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescContent_1"), "ui9_back_villagerrole_Illustration_1_1"));
		_dataArray.Add(new VillagerRoleAutoActionItem(2, 1, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "ShortName_2"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Name_2"), null, null, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Desc_2"), unlockByChicken: false, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescName_2"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescShort_2"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescContent_2"), "ui9_back_villagerrole_Illustration_1_2"));
		_dataArray.Add(new VillagerRoleAutoActionItem(3, 1, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "ShortName_3"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Name_3"), null, null, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Desc_3"), unlockByChicken: true, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescName_3"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescShort_3"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescContent_3"), "ui9_back_villagerrole_Illustration_1_3"));
		_dataArray.Add(new VillagerRoleAutoActionItem(4, 2, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "ShortName_4"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Name_4"), null, null, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Desc_4"), unlockByChicken: false, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescName_4"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescShort_4"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescContent_4"), "ui9_back_villagerrole_Illustration_2_3"));
		_dataArray.Add(new VillagerRoleAutoActionItem(5, 3, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "ShortName_5"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Name_5"), null, null, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Desc_5"), unlockByChicken: false, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescName_5"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescShort_5"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescContent_5"), "ui9_back_villagerrole_Illustration_3_2"));
		_dataArray.Add(new VillagerRoleAutoActionItem(6, 4, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "ShortName_6"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Name_6"), null, null, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Desc_6"), unlockByChicken: false, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescName_6"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescShort_6"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescContent_6"), "ui9_back_villagerrole_Illustration_4_3"));
		_dataArray.Add(new VillagerRoleAutoActionItem(7, 5, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "ShortName_7"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Name_7"), null, null, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Desc_7"), unlockByChicken: false, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescName_7"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescShort_7"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescContent_7"), "ui9_back_villagerrole_Illustration_5_2"));
		_dataArray.Add(new VillagerRoleAutoActionItem(8, 6, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "ShortName_8"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Name_8"), null, null, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Desc_8"), unlockByChicken: false, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescName_8"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescShort_8"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescContent_8"), "ui9_back_villagerrole_Illustration_6_1"));
		_dataArray.Add(new VillagerRoleAutoActionItem(9, 6, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "ShortName_9"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Name_9"), null, null, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "Desc_9"), unlockByChicken: true, LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescName_9"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescShort_9"), LocalStringManager.GetConfig("VillagerRoleAutoAction_language", "DescContent_9"), "ui9_back_villagerrole_Illustration_6_2"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<VillagerRoleAutoActionItem>(10);
		CreateItems0();
	}
}

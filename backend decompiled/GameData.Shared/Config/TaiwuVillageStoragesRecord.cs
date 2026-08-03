using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class TaiwuVillageStoragesRecord : ConfigData<TaiwuVillageStoragesRecordItem, short>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// TakeItem
		/// </summary>
		public const short TakeItem = 0;

		/// <summary>
		/// StorageItem
		/// </summary>
		public const short StorageItem = 1;

		/// <summary>
		/// StorageResources
		/// </summary>
		public const short StorageResources = 2;

		/// <summary>
		/// TakeResources
		/// </summary>
		public const short TakeResources = 3;

		/// <summary>
		/// GatherResources
		/// </summary>
		public const short GatherResources = 4;

		/// <summary>
		/// MigrateResources
		/// </summary>
		public const short MigrateResources = 5;

		/// <summary>
		/// CookingIngredient
		/// </summary>
		public const short CookingIngredient = 6;

		/// <summary>
		/// VillagerMakingItem
		/// </summary>
		public const short VillagerMakingItem = 7;

		/// <summary>
		/// VillagerRepairItem
		/// </summary>
		public const short VillagerRepairItem = 8;

		/// <summary>
		/// VillagerDisassembleItem0
		/// </summary>
		public const short VillagerDisassembleItem0 = 9;

		/// <summary>
		/// VillagerDisassembleItem1
		/// </summary>
		public const short VillagerDisassembleItem1 = 10;

		/// <summary>
		/// VillagerRefiningMedicine
		/// </summary>
		public const short VillagerRefiningMedicine = 11;

		/// <summary>
		/// VillagerDetoxify0
		/// </summary>
		public const short VillagerDetoxify0 = 12;

		/// <summary>
		/// VillagerDetoxify1
		/// </summary>
		public const short VillagerDetoxify1 = 13;

		/// <summary>
		/// VillagerEnvenomedItem
		/// </summary>
		public const short VillagerEnvenomedItem = 14;

		/// <summary>
		/// VillagerCure
		/// </summary>
		public const short VillagerCure = 15;

		/// <summary>
		/// VillagerSoldItem
		/// </summary>
		public const short VillagerSoldItem = 16;

		/// <summary>
		/// VillagerBuyItem
		/// </summary>
		public const short VillagerBuyItem = 17;

		/// <summary>
		/// OperatingBuilding
		/// </summary>
		public const short OperatingBuilding = 18;

		/// <summary>
		/// ClearRecord
		/// </summary>
		public const short ClearRecord = 19;

		/// <summary>
		/// EnvenomedItemOverload
		/// </summary>
		public const short EnvenomedItemOverload = 20;

		/// <summary>
		/// DetoxifyItemOverload
		/// </summary>
		public const short DetoxifyItemOverload = 21;

		/// <summary>
		/// GatherResourcesToTreasury
		/// </summary>
		public const short GatherResourcesToTreasury = 22;

		/// <summary>
		/// GatherResourcesToStockStorageGoodsShelf
		/// </summary>
		public const short GatherResourcesToStockStorageGoodsShelf = 23;

		/// <summary>
		/// GatherResourcesToFoodStorage
		/// </summary>
		public const short GatherResourcesToFoodStorage = 24;

		/// <summary>
		/// GatherResourcesToMedicineStorage
		/// </summary>
		public const short GatherResourcesToMedicineStorage = 25;

		/// <summary>
		/// GatherResourcesToCraftStorage
		/// </summary>
		public const short GatherResourcesToCraftStorage = 26;

		/// <summary>
		/// GatherResourcesToCraftStorageToDisassemble
		/// </summary>
		public const short GatherResourcesToCraftStorageToDisassemble = 27;

		/// <summary>
		/// LoseOverloadResources
		/// </summary>
		public const short LoseOverloadResources = 28;

		/// <summary>
		/// LoseOverloadWarehouseItems
		/// </summary>
		public const short LoseOverloadWarehouseItems = 29;

		/// <summary>
		/// VillagerGetRefineItem
		/// </summary>
		public const short VillagerGetRefineItem = 30;

		/// <summary>
		/// VillagerUpgradeRefineItem
		/// </summary>
		public const short VillagerUpgradeRefineItem = 31;

		/// <summary>
		/// VillagerEarnMoney
		/// </summary>
		public const short VillagerEarnMoney = 32;

		/// <summary>
		/// VillagerEnemyDrop
		/// </summary>
		public const short VillagerEnemyDropItem = 33;

		/// <summary>
		/// VillagerEnemyDropResources
		/// </summary>
		public const short VillagerEnemyDropResources = 34;

		/// <summary>
		/// VillagerMakeHarvest
		/// </summary>
		public const short VillagerMakeHarvest = 35;

		/// <summary>
		/// OutsiderMakeHarvest
		/// </summary>
		public const short OutsiderMakeHarvest = 36;

		/// <summary>
		/// VillagerMakeHarvest1
		/// </summary>
		public const short VillagerMakeHarvest1 = 37;

		/// <summary>
		/// OutsiderMakeHarvest1
		/// </summary>
		public const short OutsiderMakeHarvest1 = 38;

		/// <summary>
		/// VillagerMakeHarvest2
		/// </summary>
		public const short VillagerMakeHarvest2 = 39;

		/// <summary>
		/// OutsiderMakeHarvest2
		/// </summary>
		public const short OutsiderMakeHarvest2 = 40;

		/// <summary>
		/// VillagerUpgradeRefineItem1
		/// </summary>
		public const short VillagerUpgradeRefineItem1 = 41;

		/// <summary>
		/// VillagerDonateLegacy
		/// </summary>
		public const short VillagerDonateLegacy = 42;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// TakeItem
		/// </summary>
		public static TaiwuVillageStoragesRecordItem TakeItem => Instance[(short)0];

		/// <summary>
		/// StorageItem
		/// </summary>
		public static TaiwuVillageStoragesRecordItem StorageItem => Instance[(short)1];

		/// <summary>
		/// StorageResources
		/// </summary>
		public static TaiwuVillageStoragesRecordItem StorageResources => Instance[(short)2];

		/// <summary>
		/// TakeResources
		/// </summary>
		public static TaiwuVillageStoragesRecordItem TakeResources => Instance[(short)3];

		/// <summary>
		/// GatherResources
		/// </summary>
		public static TaiwuVillageStoragesRecordItem GatherResources => Instance[(short)4];

		/// <summary>
		/// MigrateResources
		/// </summary>
		public static TaiwuVillageStoragesRecordItem MigrateResources => Instance[(short)5];

		/// <summary>
		/// CookingIngredient
		/// </summary>
		public static TaiwuVillageStoragesRecordItem CookingIngredient => Instance[(short)6];

		/// <summary>
		/// VillagerMakingItem
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerMakingItem => Instance[(short)7];

		/// <summary>
		/// VillagerRepairItem
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerRepairItem => Instance[(short)8];

		/// <summary>
		/// VillagerDisassembleItem0
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerDisassembleItem0 => Instance[(short)9];

		/// <summary>
		/// VillagerDisassembleItem1
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerDisassembleItem1 => Instance[(short)10];

		/// <summary>
		/// VillagerRefiningMedicine
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerRefiningMedicine => Instance[(short)11];

		/// <summary>
		/// VillagerDetoxify0
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerDetoxify0 => Instance[(short)12];

		/// <summary>
		/// VillagerDetoxify1
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerDetoxify1 => Instance[(short)13];

		/// <summary>
		/// VillagerEnvenomedItem
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerEnvenomedItem => Instance[(short)14];

		/// <summary>
		/// VillagerCure
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerCure => Instance[(short)15];

		/// <summary>
		/// VillagerSoldItem
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerSoldItem => Instance[(short)16];

		/// <summary>
		/// VillagerBuyItem
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerBuyItem => Instance[(short)17];

		/// <summary>
		/// OperatingBuilding
		/// </summary>
		public static TaiwuVillageStoragesRecordItem OperatingBuilding => Instance[(short)18];

		/// <summary>
		/// ClearRecord
		/// </summary>
		public static TaiwuVillageStoragesRecordItem ClearRecord => Instance[(short)19];

		/// <summary>
		/// EnvenomedItemOverload
		/// </summary>
		public static TaiwuVillageStoragesRecordItem EnvenomedItemOverload => Instance[(short)20];

		/// <summary>
		/// DetoxifyItemOverload
		/// </summary>
		public static TaiwuVillageStoragesRecordItem DetoxifyItemOverload => Instance[(short)21];

		/// <summary>
		/// GatherResourcesToTreasury
		/// </summary>
		public static TaiwuVillageStoragesRecordItem GatherResourcesToTreasury => Instance[(short)22];

		/// <summary>
		/// GatherResourcesToStockStorageGoodsShelf
		/// </summary>
		public static TaiwuVillageStoragesRecordItem GatherResourcesToStockStorageGoodsShelf => Instance[(short)23];

		/// <summary>
		/// GatherResourcesToFoodStorage
		/// </summary>
		public static TaiwuVillageStoragesRecordItem GatherResourcesToFoodStorage => Instance[(short)24];

		/// <summary>
		/// GatherResourcesToMedicineStorage
		/// </summary>
		public static TaiwuVillageStoragesRecordItem GatherResourcesToMedicineStorage => Instance[(short)25];

		/// <summary>
		/// GatherResourcesToCraftStorage
		/// </summary>
		public static TaiwuVillageStoragesRecordItem GatherResourcesToCraftStorage => Instance[(short)26];

		/// <summary>
		/// GatherResourcesToCraftStorageToDisassemble
		/// </summary>
		public static TaiwuVillageStoragesRecordItem GatherResourcesToCraftStorageToDisassemble => Instance[(short)27];

		/// <summary>
		/// LoseOverloadResources
		/// </summary>
		public static TaiwuVillageStoragesRecordItem LoseOverloadResources => Instance[(short)28];

		/// <summary>
		/// LoseOverloadWarehouseItems
		/// </summary>
		public static TaiwuVillageStoragesRecordItem LoseOverloadWarehouseItems => Instance[(short)29];

		/// <summary>
		/// VillagerGetRefineItem
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerGetRefineItem => Instance[(short)30];

		/// <summary>
		/// VillagerUpgradeRefineItem
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerUpgradeRefineItem => Instance[(short)31];

		/// <summary>
		/// VillagerEarnMoney
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerEarnMoney => Instance[(short)32];

		/// <summary>
		/// VillagerEnemyDrop
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerEnemyDropItem => Instance[(short)33];

		/// <summary>
		/// VillagerEnemyDropResources
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerEnemyDropResources => Instance[(short)34];

		/// <summary>
		/// VillagerMakeHarvest
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerMakeHarvest => Instance[(short)35];

		/// <summary>
		/// OutsiderMakeHarvest
		/// </summary>
		public static TaiwuVillageStoragesRecordItem OutsiderMakeHarvest => Instance[(short)36];

		/// <summary>
		/// VillagerMakeHarvest1
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerMakeHarvest1 => Instance[(short)37];

		/// <summary>
		/// OutsiderMakeHarvest1
		/// </summary>
		public static TaiwuVillageStoragesRecordItem OutsiderMakeHarvest1 => Instance[(short)38];

		/// <summary>
		/// VillagerMakeHarvest2
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerMakeHarvest2 => Instance[(short)39];

		/// <summary>
		/// OutsiderMakeHarvest2
		/// </summary>
		public static TaiwuVillageStoragesRecordItem OutsiderMakeHarvest2 => Instance[(short)40];

		/// <summary>
		/// VillagerUpgradeRefineItem1
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerUpgradeRefineItem1 => Instance[(short)41];

		/// <summary>
		/// VillagerDonateLegacy
		/// </summary>
		public static TaiwuVillageStoragesRecordItem VillagerDonateLegacy => Instance[(short)42];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static TaiwuVillageStoragesRecord Instance = new TaiwuVillageStoragesRecord();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId" };

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
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(0, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_0"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_0"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(1, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_1"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_1"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(2, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_2"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_2"), new string[6] { "Character", "Integer", "Resource", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(3, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_3"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_3"), new string[6] { "Character", "Integer", "Resource", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(4, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_4"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_4"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(5, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_5"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_5"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(6, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_6"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_6"), new string[6] { "Character", "Item", "Item", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(7, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_7"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_7"), new string[6] { "Character", "Item", "Item", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(8, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_8"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_8"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(9, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_9"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_9"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(10, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_10"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_10"), new string[6] { "Character", "Item", "Item", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(11, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_11"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_11"), new string[6] { "Character", "Item", "Item", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(12, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_12"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_12"), new string[6] { "Character", "Item", "Item", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(13, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_13"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_13"), new string[6] { "Character", "Item", "Item", "Item", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(14, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_14"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_14"), new string[6] { "Character", "Item", "Item", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(15, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_15"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_15"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(16, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_16"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_16"), new string[6] { "Character", "Item", "Integer", "Resource", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(17, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_17"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_17"), new string[6] { "Character", "Integer", "Resource", "Item", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(18, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_18"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_18"), new string[6] { "Item", "Building", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(19, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_19"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_19"), new string[6] { "", "", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(20, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_20"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_20"), new string[6] { "Character", "Item", "Item", "Item", "Item", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(21, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_21"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_21"), new string[6] { "Character", "Item", "Item", "Item", "Item", "Item" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(22, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_22"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_22"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(23, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_23"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_23"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(24, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_24"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_24"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(25, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_25"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_25"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(26, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_26"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_26"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(27, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_27"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_27"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(28, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_28"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_28"), new string[6] { "Resource", "Integer", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(29, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_29"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_29"), new string[6] { "Item", "", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(30, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_30"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_30"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(31, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_31"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_31"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(32, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_32"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_32"), new string[6] { "Character", "Character", "Resource", "Integer", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(33, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_33"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_33"), new string[6] { "Character", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(34, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_34"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_34"), new string[6] { "Character", "Resource", "Integer", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(35, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_35"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_35"), new string[6] { "Building", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(36, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_36"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_36"), new string[6] { "Character", "Settlement", "Item", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(37, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_37"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_37"), new string[6] { "Building", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(38, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_38"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_38"), new string[6] { "Character", "Settlement", "Item", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(39, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_39"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_39"), new string[6] { "Building", "Item", "", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(40, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_40"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_40"), new string[6] { "Character", "Settlement", "Item", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(41, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_41"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_41"), new string[6] { "Character", "Item", "Item", "", "", "" }));
		_dataArray.Add(new TaiwuVillageStoragesRecordItem(42, LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Name_42"), LocalStringManager.GetConfig("TaiwuVillageStoragesRecord_language", "Desc_42"), new string[6] { "Character", "Item", "", "", "", "" }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<TaiwuVillageStoragesRecordItem>(43);
		CreateItems0();
	}
}

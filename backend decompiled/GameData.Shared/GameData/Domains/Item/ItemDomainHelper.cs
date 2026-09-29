using System.Collections.Generic;

namespace GameData.Domains.Item;

public static class ItemDomainHelper
{
	public static class DataIds
	{
		public const ushort Weapons = 0;

		public const ushort Armors = 1;

		public const ushort Accessories = 2;

		public const ushort Clothing = 3;

		public const ushort Carriers = 4;

		public const ushort Materials = 5;

		public const ushort CraftTools = 6;

		public const ushort Foods = 7;

		public const ushort Medicines = 8;

		public const ushort TeaWines = 9;

		public const ushort SkillBooks = 10;

		public const ushort Crickets = 11;

		public const ushort Misc = 12;

		public const ushort NextItemId = 13;

		public const ushort StackableItems = 14;

		public const ushort PoisonItems = 15;

		public const ushort RefinedItems = 16;

		public const ushort EmptyHandKey = 17;

		public const ushort BranchKey = 18;

		public const ushort StoneKey = 19;

		public const ushort ExternEquipmentEffects = 20;

		public const ushort MysteryData = 21;

		public const ushort MedicineExtraAddPercent = 22;
	}

	public static class MethodIds
	{
		public const ushort IdentifyPoisons = 0;

		public const ushort CatchCricket = 1;

		public const ushort GetCricketData = 2;

		public const ushort SetCricketRecord = 3;

		public const ushort AddCricketInjury = 4;

		public const ushort GetWeaponTricks = 5;

		public const ushort GetCricketCombatRecords = 6;

		public const ushort GetItemDisplayData = 7;

		public const ushort GetItemDisplayDataList = 8;

		public const ushort GetSkillBookPagesInfo = 9;

		public const ushort GetValue = 10;

		public const ushort GetPrice = 11;

		public const ushort DisassembleItem = 12;

		public const ushort DiscardItem = 13;

		public const ushort GetRepairableItems = 14;

		public const ushort GetDisassemblableItems = 15;

		public const ushort ChangeDurability = 16;

		public const ushort ChangePoisonIdentified = 17;

		public const ushort DiscardItemList = 18;

		public const ushort DisassembleItemList = 19;

		public const ushort SetCricketBattleConfig = 20;

		public const ushort GetCricketDataList = 21;

		public const ushort GetWeaponAttackRange = 22;

		public const ushort GetCricketsAliveState = 23;

		public const ushort ModifyCombatSkillBookPageNormal = 24;

		public const ushort ModifyCombatSkillBookPageOutline = 25;

		public const ushort GetTaiwuInventoryCombatSkillBooks = 26;

		public const ushort GetItemDisplayDataListOptional = 27;

		public const ushort GetSkillBookPageDisplayDataList = 28;

		public const ushort GetEmptyToolKey = 29;

		public const ushort GetItemDisplayDataListOptionalFromInventory = 30;

		public const ushort SettlementCricketWager = 31;

		public const ushort GmCmd_StartCricketCombat = 32;

		public const ushort SettlementCricketWagerByGiveUp = 33;

		public const ushort MakeCricketRebirth = 34;

		public const ushort GetRepairItemNeedResourceCount = 35;

		public const ushort SetCombatSkillBookPage = 36;

		public const ushort GetWeaponPrepareFrame = 37;

		public const ushort GmCmd_ChangeAllMysteryCompatibility = 38;

		public const ushort GmCmd_ChangeAllCricketSpirit = 39;

		public const ushort SetCricketName = 40;

		public const ushort DiscardItemInventory = 41;
	}

	public const ushort DataCount = 23;

	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "Weapons", 0 },
		{ "Armors", 1 },
		{ "Accessories", 2 },
		{ "Clothing", 3 },
		{ "Carriers", 4 },
		{ "Materials", 5 },
		{ "CraftTools", 6 },
		{ "Foods", 7 },
		{ "Medicines", 8 },
		{ "TeaWines", 9 },
		{ "SkillBooks", 10 },
		{ "Crickets", 11 },
		{ "Misc", 12 },
		{ "NextItemId", 13 },
		{ "StackableItems", 14 },
		{ "PoisonItems", 15 },
		{ "RefinedItems", 16 },
		{ "EmptyHandKey", 17 },
		{ "BranchKey", 18 },
		{ "StoneKey", 19 },
		{ "ExternEquipmentEffects", 20 },
		{ "MysteryData", 21 },
		{ "MedicineExtraAddPercent", 22 }
	};

	public static readonly string[] DataId2FieldName = new string[23]
	{
		"Weapons", "Armors", "Accessories", "Clothing", "Carriers", "Materials", "CraftTools", "Foods", "Medicines", "TeaWines",
		"SkillBooks", "Crickets", "Misc", "NextItemId", "StackableItems", "PoisonItems", "RefinedItems", "EmptyHandKey", "BranchKey", "StoneKey",
		"ExternEquipmentEffects", "MysteryData", "MedicineExtraAddPercent"
	};

	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[23][]
	{
		WeaponHelper.FieldId2FieldName,
		ArmorHelper.FieldId2FieldName,
		AccessoryHelper.FieldId2FieldName,
		ClothingHelper.FieldId2FieldName,
		CarrierHelper.FieldId2FieldName,
		MaterialHelper.FieldId2FieldName,
		CraftToolHelper.FieldId2FieldName,
		FoodHelper.FieldId2FieldName,
		MedicineHelper.FieldId2FieldName,
		TeaWineHelper.FieldId2FieldName,
		SkillBookHelper.FieldId2FieldName,
		CricketHelper.FieldId2FieldName,
		MiscHelper.FieldId2FieldName,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null,
		null
	};

	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "IdentifyPoisons", 0 },
		{ "CatchCricket", 1 },
		{ "GetCricketData", 2 },
		{ "SetCricketRecord", 3 },
		{ "AddCricketInjury", 4 },
		{ "GetWeaponTricks", 5 },
		{ "GetCricketCombatRecords", 6 },
		{ "GetItemDisplayData", 7 },
		{ "GetItemDisplayDataList", 8 },
		{ "GetSkillBookPagesInfo", 9 },
		{ "GetValue", 10 },
		{ "GetPrice", 11 },
		{ "DisassembleItem", 12 },
		{ "DiscardItem", 13 },
		{ "GetRepairableItems", 14 },
		{ "GetDisassemblableItems", 15 },
		{ "ChangeDurability", 16 },
		{ "ChangePoisonIdentified", 17 },
		{ "DiscardItemList", 18 },
		{ "DisassembleItemList", 19 },
		{ "SetCricketBattleConfig", 20 },
		{ "GetCricketDataList", 21 },
		{ "GetWeaponAttackRange", 22 },
		{ "GetCricketsAliveState", 23 },
		{ "ModifyCombatSkillBookPageNormal", 24 },
		{ "ModifyCombatSkillBookPageOutline", 25 },
		{ "GetTaiwuInventoryCombatSkillBooks", 26 },
		{ "GetItemDisplayDataListOptional", 27 },
		{ "GetSkillBookPageDisplayDataList", 28 },
		{ "GetEmptyToolKey", 29 },
		{ "GetItemDisplayDataListOptionalFromInventory", 30 },
		{ "SettlementCricketWager", 31 },
		{ "GmCmd_StartCricketCombat", 32 },
		{ "SettlementCricketWagerByGiveUp", 33 },
		{ "MakeCricketRebirth", 34 },
		{ "GetRepairItemNeedResourceCount", 35 },
		{ "SetCombatSkillBookPage", 36 },
		{ "GetWeaponPrepareFrame", 37 },
		{ "GmCmd_ChangeAllMysteryCompatibility", 38 },
		{ "GmCmd_ChangeAllCricketSpirit", 39 },
		{ "SetCricketName", 40 },
		{ "DiscardItemInventory", 41 }
	};

	public static readonly string[] MethodId2MethodName = new string[42]
	{
		"IdentifyPoisons", "CatchCricket", "GetCricketData", "SetCricketRecord", "AddCricketInjury", "GetWeaponTricks", "GetCricketCombatRecords", "GetItemDisplayData", "GetItemDisplayDataList", "GetSkillBookPagesInfo",
		"GetValue", "GetPrice", "DisassembleItem", "DiscardItem", "GetRepairableItems", "GetDisassemblableItems", "ChangeDurability", "ChangePoisonIdentified", "DiscardItemList", "DisassembleItemList",
		"SetCricketBattleConfig", "GetCricketDataList", "GetWeaponAttackRange", "GetCricketsAliveState", "ModifyCombatSkillBookPageNormal", "ModifyCombatSkillBookPageOutline", "GetTaiwuInventoryCombatSkillBooks", "GetItemDisplayDataListOptional", "GetSkillBookPageDisplayDataList", "GetEmptyToolKey",
		"GetItemDisplayDataListOptionalFromInventory", "SettlementCricketWager", "GmCmd_StartCricketCombat", "SettlementCricketWagerByGiveUp", "MakeCricketRebirth", "GetRepairItemNeedResourceCount", "SetCombatSkillBookPage", "GetWeaponPrepareFrame", "GmCmd_ChangeAllMysteryCompatibility", "GmCmd_ChangeAllCricketSpirit",
		"SetCricketName", "DiscardItemInventory"
	};
}

using System.Collections.Generic;

namespace GameData.Domains.Building;

public static class BuildingDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort BuildingAreas = 0;

		public const ushort BuildingBlocks = 1;

		public const ushort TaiwuBuildingAreas = 2;

		public const ushort CollectBuildingResourceType = 3;

		public const ushort BuildingOperatorDict = 4;

		public const ushort CustomBuildingName = 5;

		public const ushort NewCompleteOperationBuildings = 6;

		public const ushort Chicken = 7;

		public const ushort MakeItemDict = 8;

		public const ushort Residences = 9;

		public const ushort ComfortableHouses = 10;

		public const ushort Homeless = 11;

		public const ushort SamsaraPlatformAddMainAttributes = 12;

		public const ushort SamsaraPlatformAddCombatSkillQualifications = 13;

		public const ushort SamsaraPlatformAddLifeSkillQualifications = 14;

		public const ushort SamsaraPlatformSlots = 15;

		public const ushort SamsaraPlatformBornDict = 16;

		public const ushort CollectBuildingEarningsData = 17;

		public const ushort ShopManagerDict = 18;

		public const ushort TeaHorseCaravanData = 19;

		public const ushort ShrineBuyTimes = 20;

		public const ushort LocationMarkHashSet = 21;

		public const ushort ComfortableHousesAutoCheckInType = 22;

		public const ushort LockedResidences = 23;

		public const ushort LockedComfortableHouses = 24;

		public const ushort ShopManagerUpgradeQualificationDict = 25;

		public const ushort FeatherValue = 26;

		public const ushort TeaHorseCaravanEventCollection = 27;

		public const ushort NewlyCreatedBuildingIndexes = 28;

		public const ushort MakeItemDataDict = 29;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort SetShopManager = 0;

		public const ushort SetCollectBuildingResourceType = 1;

		public const ushort ClearBuildingBlockEarningsData = 2;

		public const ushort GetBuildingEarningData = 3;

		public const ushort GetBuildingOperatesData = 4;

		public const ushort GetBuildingBuildPeopleAttainments = 5;

		public const ushort AcceptBuildingBlockCollectEarning = 6;

		public const ushort AcceptBuildingBlockCollectEarningQuick = 7;

		public const ushort AcceptBuildingBlockRecruitPeople = 8;

		public const ushort AcceptBuildingBlockRecruitPeopleQuick = 9;

		public const ushort ShopBuildingSoldItemReceive = 10;

		public const ushort ShopBuildingSoldItemReceiveQuick = 11;

		public const ushort QuickCollectShopItem = 12;

		public const ushort QuickCollectShopItemCount = 13;

		public const ushort QuickCollectShopSoldItem = 14;

		public const ushort QuickCollectShopSoldItemCount = 15;

		public const ushort QuickRecruitPeople = 16;

		public const ushort QuickRecruitPeopleCount = 17;

		public const ushort QuickCollectBuildingEarn = 18;

		public const ushort QuickCollectBuildingEarnCount = 19;

		public const ushort AddFixBook = 20;

		public const ushort ChangeFixBook = 21;

		public const ushort ReceiveFixBook = 22;

		public const ushort GetFixBookProgress = 23;

		public const ushort SetTeaHorseCaravanState = 24;

		public const ushort ExchangeItemToReplenishment = 25;

		public const ushort StartSearchReplenishment = 26;

		public const ushort QuickGetExchangeItem = 27;

		public const ushort GetShrineDisplayData = 28;

		public const ushort TeachSkill = 29;

		public const ushort CricketCollectionAdd = 30;

		public const ushort CricketCollectionRemove = 31;

		public const ushort GetCollectionCrickets = 32;

		public const ushort GetCollectionJars = 33;

		public const ushort GetCollectionCricketRegen = 34;

		public const ushort GetAuthorityGain = 35;

		public const ushort GmCmd_BuildImmediately = 36;

		public const ushort GmCmd_RemoveBuildingImmediately = 37;

		public const ushort StartMakeItem = 38;

		public const ushort CheckMakeCondition = 39;

		public const ushort GetMakeItems = 40;

		public const ushort GetMakingItemData = 41;

		public const ushort CheckRepairConditionIsMeet = 42;

		public const ushort AddItemPoison = 43;

		public const ushort CheckAddPoisonCondition = 44;

		public const ushort RemoveItemPoison = 45;

		public const ushort CheckRemovePoisonCondition = 46;

		public const ushort Build = 47;

		public const ushort Remove = 48;

		public const ushort SetStopOperation = 49;

		public const ushort SetOperator = 50;

		public const ushort Repair = 51;

		public const ushort ConfirmPlanBuilding = 52;

		public const ushort AddToResidence = 53;

		public const ushort RemoveFromResidence = 54;

		public const ushort ReplaceCharacterInResidence = 55;

		public const ushort ReplaceCharacterInComfortableHouse = 56;

		public const ushort AddToComfortableHouse = 57;

		public const ushort RemoveFromComfortableHouse = 58;

		public const ushort QuickFillResidence = 59;

		public const ushort GetCharsInResidence = 60;

		public const ushort GetAllResidents = 61;

		public const ushort GetCharsInComfortableHouse = 62;

		public const ushort GetHomeless = 63;

		public const ushort GetSamsaraPlatformCharList = 64;

		public const ushort SetSamsaraPlatformChar = 65;

		public const ushort SamsaraPlatformReborn = 66;

		public const ushort GetBuildingAreaData = 67;

		public const ushort GetBuildingBlockList = 68;

		public const ushort GetBuildingBlockData = 69;

		public const ushort SetBuildingCustomName = 70;

		public const ushort GetEmptyBlockCount = 71;

		public const ushort AddChicken = 72;

		public const ushort RemoveChicken = 73;

		public const ushort RemoveAllChicken = 74;

		public const ushort MoveChicken = 75;

		public const ushort TransferChicken = 76;

		public const ushort GetSettlementChickenList = 77;

		public const ushort GetChickenData = 78;

		public const ushort InitMapBlockChicken = 79;

		public const ushort IsHaveChickenKing = 80;

		public const ushort RemoveAllFormResidence = 81;

		public const ushort GetBuildingAttainment = 82;

		public const ushort CalcResourceOutputCount = 83;

		public const ushort DealInfectedPeople = 84;

		public const ushort QuickCollectSingleShopItem = 85;

		public const ushort QuickCollectSingleShopSoldItem = 86;

		public const ushort QuickRecruitSingleBuildingPeople = 87;

		public const ushort QuickFillComfortableHouse = 88;

		public const ushort RemoveAllFromComfortableHouse = 89;

		public const ushort SortedComfortableHousePeople = 90;

		public const ushort GetMakeResult = 91;

		public const ushort GetSutraReadingRoomBuffValue = 92;

		public const ushort SetBuildingAutoWork = 93;

		public const ushort GetBuildingIsAutoWork = 94;

		public const ushort ShopBuildingMultiChangeSoldItem = 95;

		public const ushort RepairItemList = 96;

		public const ushort SetBuildingAutoSold = 97;

		public const ushort GetBuildingIsAutoSold = 98;

		public const ushort GetXiangshuIdInKungfuRoom = 99;

		public const ushort RepairItemOptional = 100;

		public const ushort SetNickNameByChickenId = 101;

		public const ushort GetSettlementChickenDataList = 102;

		public const ushort SetTeaHorseCaravanWeather = 103;

		public const ushort GetComfortableIsAutoCheckIn = 104;

		public const ushort GetResidenceIsAutoCheckIn = 105;

		public const ushort SetComfortableAutoCheckIn = 106;

		public const ushort SetResidenceAutoCheckIn = 107;

		public const ushort GmCmd_AddLegacyBuilding = 108;

		public const ushort SetUnlockedWorkingVillagers = 109;

		public const ushort WeaveClothingItem = 110;

		public const ushort GmCmd_GetChickenData = 111;

		public const ushort GetPossessionPreview = 112;

		public const ushort TrySwapSoulCeremony = 113;

		public const ushort GetBackTeaHorseCarryItem = 114;

		public const ushort AddItemToTeaHorseCarryItem = 115;

		public const ushort SetTemporaryPossessionCharacterAvatar = 116;

		public const ushort GetSwapSoulCeremonyBodyCharIdList = 117;

		public const ushort GetBuildingShopManagerAutoArrangeSorted = 118;

		public const ushort SectMainStoryJingangClickMonkSoulBtn = 119;

		public const ushort RejectBuildingBlockRecruitPeople = 120;

		public const ushort RejectBuildingBlockRecruitPeopleQuick = 121;

		public const ushort GetShopManagementYieldTipsData = 122;

		public const ushort CalculateBuildingManageHarvestSuccessRate = 123;

		public const ushort GetOrCreateShopEventCollection = 124;

		public const ushort GetSamsaraPlatformRecord = 125;

		public const ushort GetSwapSoulCeremonySoulCharIdList = 126;

		public const ushort CricketCollectionBatchAddCricketJar = 127;

		public const ushort CricketCollectionBatchAddCricket = 128;

		public const ushort CricketCollectionBatchRemoveJar = 129;

		public const ushort CricketCollectionBatchRemoveCricket = 130;

		public const ushort GetCricketOrJarFromSourceStorage = 131;

		public const ushort SmartOperateCricketOrJarCollection = 132;

		public const ushort GetBatchButtonEnableState = 133;

		public const ushort CalculateBuildingManageHarvestSuccessRates = 134;

		public const ushort UnsetFulongChicken = 135;

		public const ushort SetFulongChicken = 136;

		public const ushort GetChickenDataList = 137;

		public const ushort GetChickenNicknameList = 138;

		public const ushort GetSettlementChickenIdList = 139;

		public const ushort GetChickensNicknameByLocation = 140;

		public const ushort AllChickenInTaiwuVillage = 141;

		public const ushort GetVillagerRoleExtraEffectUnlockState = 142;

		public const ushort ClickChickenMap = 143;

		public const ushort ClickChickenSign = 144;

		public const ushort SetBuildingResourceOutputSetting = 145;

		public const ushort GetBuildingResourceOutputSetting = 146;

		public const ushort GetBuildingExceptionData = 147;

		public const ushort AllDependBuildingAvailable = 148;

		public const ushort PracticingCombatSkillInPracticeRoom = 149;

		public const ushort HasShopManagerLeader = 150;

		public const ushort QuickArrangeShopManager = 151;

		public const ushort QuickArrangeBuildOperator = 152;

		public const ushort ShopBuildingCanTeach = 153;

		public const ushort GetOperationLeftTime = 154;

		public const ushort GetBuildingOperationLeftTime = 155;

		public const ushort GetShopBuildingTeachBookData = 156;

		public const ushort CalcExtraTaiwuGroupMaxCountByStrategyRoom = 157;

		public const ushort GetTaiwuCanFixBookItemDataList = 158;

		public const ushort GetResidenceInfo = 159;

		public const ushort GetTaiwuVillageResourceBlockEffect = 160;

		public const ushort GetTaiwuLocationResourceBlockEffect = 161;

		public const ushort GetTaiwuVillageResourceBlockEffectInfo = 162;

		public const ushort CanQuickArrangeShopManager = 163;

		public const ushort GetBuildingFormulaContextBridge = 164;

		public const ushort GetBuildingEffectForMake = 165;

		public const ushort GmCmd_BuildingCollectPerform = 166;

		public const ushort GmCmd_BeatMinionPerform = 167;

		public const ushort GetStoreLocation = 168;

		public const ushort SetStoreLocation = 169;

		public const ushort GetFeastTargetCharList = 170;

		public const ushort TryShowNotifications = 171;

		public const ushort QuickRemoveShopSoldItem = 172;

		public const ushort QuickAddShopSoldItem = 173;

		public const ushort CalcTaiwuVillagerInfoDisplayData = 174;

		public const ushort CalcTaiwuVillagerEfficiencyInBuilding = 175;

		public const ushort QuickGetSpecificExchangeItem = 176;

		public const ushort AddLocationMark = 177;

		public const ushort RemoveLocationMark = 178;

		public const ushort RequestUnlockedWorkingVillagers = 179;

		public const ushort SetBuildingArrangementSetting = 180;

		public const ushort UpgradeResourceBuilding = 181;

		public const ushort UpgradeSlotBuilding = 182;

		public const ushort UnlockBuildingLevelSlot = 183;

		public const ushort SetBuildingSoldItemSetting = 184;

		public const ushort GetPuppetPageDisplayData = 185;

		public const ushort QuickRepairAllBuilding = 186;

		public const ushort CalcQuickRepairAllBuildingCostMoney = 187;

		public const ushort GetBuildingFunctionData = 188;

		public const ushort GetTaiwuVillageBuildingAreaData = 189;

		public const ushort GetAllPawnShopItem = 190;

		public const ushort GetTaiwuVillageBlockEffectInfo = 191;

		public const ushort GetTaiwuVillageShopData = 192;

		public const ushort GetBuildingEarningDisplayData = 193;

		public const ushort GetBuildingManageDisplayData = 194;

		public const ushort GetUnlockedFeastTypeList = 195;

		public const ushort GetReversedSamsaraRecord = 196;

		public const ushort GetLockedComfortableHouseCharacters = 197;

		public const ushort GetLockedResidenceCharacters = 198;

		public const ushort UnlockComfortableHouseCharacter = 199;

		public const ushort LockComfortableHouseCharacter = 200;

		public const ushort UnlockResidenceCharacter = 201;

		public const ushort SetComfortableAutoCheckInType = 202;

		public const ushort LockResidenceCharacter = 203;

		public const ushort SetNextTeaHorseCaravanEvent = 204;

		public const ushort GetLockedInComfortableHouseIds = 205;

		public const ushort GetLockedInResidenceIds = 206;

		public const ushort GetReversedBlockShopEvent = 207;

		public const ushort PluckAllChickenFeathers = 208;

		public const ushort IsAllChickensCanPluck = 209;

		public const ushort GetCharacterChickenFeatures = 210;

		public const ushort GetChickensByPersonalityType = 211;

		public const ushort GetCurrentFeatherValue = 212;

		public const ushort CanCultivateFeather = 213;

		public const ushort GetChickenPluckFeatherDisplayData = 214;

		public const ushort IsFeatherSystemUnlocked = 215;

		public const ushort UnlockFeatherSystem = 216;

		public const ushort PluckChickenFeather = 217;

		public const ushort CanUseChickenFeather = 218;

		public const ushort UseChickenFeather = 219;

		public const ushort CanPluckFeatherInVillage = 220;

		public const ushort CultivateFeather = 221;

		public const ushort GetCanPluckFeatherChickenIds = 222;

		public const ushort GetSamsaraPlatformBonusAttributes = 223;

		public const ushort GetSamsaraPlatformCharDisplayData = 224;

		public const ushort QuickAssignChicken = 225;

		public const ushort GetCricketCollectionDisplayData = 226;

		public const ushort GetBuildingMakeDisplayData = 227;

		public const ushort CheckRefineCondition = 228;

		public const ushort RefineItem = 229;

		public const ushort GetCraftManDisplayDataForCharacter = 230;

		public const ushort GetCraftManDisplayDataForBuilding = 231;

		public const ushort GetTeaHorseCaravanEvent = 232;

		public const ushort TriggerCultivateFeatherEvent = 233;

		public const ushort GetTeaHorseCaravanData = 234;

		public const ushort QuickDiscardExchangeItem = 235;

		public const ushort GetTaiwuVillageBuildingDataForVillagerRole = 236;

		public const ushort IsAnyChickensCanPluck = 237;

		public const ushort FeedChicken = 238;

		public const ushort GetBuildingBlockEffect = 239;

		public const ushort ClearNewlyCreatedBuildingIndex = 240;

		public const ushort GetNewlyCreatedBuildingIndex = 241;

		public const ushort GetQuickCollectResourceAmount = 242;

		public const ushort RepairItemsOptional = 243;

		public const ushort AnyBuildingEarnCountMax = 244;

		public const ushort GetOperationAddProgress = 245;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 30;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "BuildingAreas", 0 },
		{ "BuildingBlocks", 1 },
		{ "TaiwuBuildingAreas", 2 },
		{ "CollectBuildingResourceType", 3 },
		{ "BuildingOperatorDict", 4 },
		{ "CustomBuildingName", 5 },
		{ "NewCompleteOperationBuildings", 6 },
		{ "Chicken", 7 },
		{ "MakeItemDict", 8 },
		{ "Residences", 9 },
		{ "ComfortableHouses", 10 },
		{ "Homeless", 11 },
		{ "SamsaraPlatformAddMainAttributes", 12 },
		{ "SamsaraPlatformAddCombatSkillQualifications", 13 },
		{ "SamsaraPlatformAddLifeSkillQualifications", 14 },
		{ "SamsaraPlatformSlots", 15 },
		{ "SamsaraPlatformBornDict", 16 },
		{ "CollectBuildingEarningsData", 17 },
		{ "ShopManagerDict", 18 },
		{ "TeaHorseCaravanData", 19 },
		{ "ShrineBuyTimes", 20 },
		{ "LocationMarkHashSet", 21 },
		{ "ComfortableHousesAutoCheckInType", 22 },
		{ "LockedResidences", 23 },
		{ "LockedComfortableHouses", 24 },
		{ "ShopManagerUpgradeQualificationDict", 25 },
		{ "FeatherValue", 26 },
		{ "TeaHorseCaravanEventCollection", 27 },
		{ "NewlyCreatedBuildingIndexes", 28 },
		{ "MakeItemDataDict", 29 }
	};

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[30]
	{
		"BuildingAreas", "BuildingBlocks", "TaiwuBuildingAreas", "CollectBuildingResourceType", "BuildingOperatorDict", "CustomBuildingName", "NewCompleteOperationBuildings", "Chicken", "MakeItemDict", "Residences",
		"ComfortableHouses", "Homeless", "SamsaraPlatformAddMainAttributes", "SamsaraPlatformAddCombatSkillQualifications", "SamsaraPlatformAddLifeSkillQualifications", "SamsaraPlatformSlots", "SamsaraPlatformBornDict", "CollectBuildingEarningsData", "ShopManagerDict", "TeaHorseCaravanData",
		"ShrineBuyTimes", "LocationMarkHashSet", "ComfortableHousesAutoCheckInType", "LockedResidences", "LockedComfortableHouses", "ShopManagerUpgradeQualificationDict", "FeatherValue", "TeaHorseCaravanEventCollection", "NewlyCreatedBuildingIndexes", "MakeItemDataDict"
	};

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[30][];

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "SetShopManager", 0 },
		{ "SetCollectBuildingResourceType", 1 },
		{ "ClearBuildingBlockEarningsData", 2 },
		{ "GetBuildingEarningData", 3 },
		{ "GetBuildingOperatesData", 4 },
		{ "GetBuildingBuildPeopleAttainments", 5 },
		{ "AcceptBuildingBlockCollectEarning", 6 },
		{ "AcceptBuildingBlockCollectEarningQuick", 7 },
		{ "AcceptBuildingBlockRecruitPeople", 8 },
		{ "AcceptBuildingBlockRecruitPeopleQuick", 9 },
		{ "ShopBuildingSoldItemReceive", 10 },
		{ "ShopBuildingSoldItemReceiveQuick", 11 },
		{ "QuickCollectShopItem", 12 },
		{ "QuickCollectShopItemCount", 13 },
		{ "QuickCollectShopSoldItem", 14 },
		{ "QuickCollectShopSoldItemCount", 15 },
		{ "QuickRecruitPeople", 16 },
		{ "QuickRecruitPeopleCount", 17 },
		{ "QuickCollectBuildingEarn", 18 },
		{ "QuickCollectBuildingEarnCount", 19 },
		{ "AddFixBook", 20 },
		{ "ChangeFixBook", 21 },
		{ "ReceiveFixBook", 22 },
		{ "GetFixBookProgress", 23 },
		{ "SetTeaHorseCaravanState", 24 },
		{ "ExchangeItemToReplenishment", 25 },
		{ "StartSearchReplenishment", 26 },
		{ "QuickGetExchangeItem", 27 },
		{ "GetShrineDisplayData", 28 },
		{ "TeachSkill", 29 },
		{ "CricketCollectionAdd", 30 },
		{ "CricketCollectionRemove", 31 },
		{ "GetCollectionCrickets", 32 },
		{ "GetCollectionJars", 33 },
		{ "GetCollectionCricketRegen", 34 },
		{ "GetAuthorityGain", 35 },
		{ "GmCmd_BuildImmediately", 36 },
		{ "GmCmd_RemoveBuildingImmediately", 37 },
		{ "StartMakeItem", 38 },
		{ "CheckMakeCondition", 39 },
		{ "GetMakeItems", 40 },
		{ "GetMakingItemData", 41 },
		{ "CheckRepairConditionIsMeet", 42 },
		{ "AddItemPoison", 43 },
		{ "CheckAddPoisonCondition", 44 },
		{ "RemoveItemPoison", 45 },
		{ "CheckRemovePoisonCondition", 46 },
		{ "Build", 47 },
		{ "Remove", 48 },
		{ "SetStopOperation", 49 },
		{ "SetOperator", 50 },
		{ "Repair", 51 },
		{ "ConfirmPlanBuilding", 52 },
		{ "AddToResidence", 53 },
		{ "RemoveFromResidence", 54 },
		{ "ReplaceCharacterInResidence", 55 },
		{ "ReplaceCharacterInComfortableHouse", 56 },
		{ "AddToComfortableHouse", 57 },
		{ "RemoveFromComfortableHouse", 58 },
		{ "QuickFillResidence", 59 },
		{ "GetCharsInResidence", 60 },
		{ "GetAllResidents", 61 },
		{ "GetCharsInComfortableHouse", 62 },
		{ "GetHomeless", 63 },
		{ "GetSamsaraPlatformCharList", 64 },
		{ "SetSamsaraPlatformChar", 65 },
		{ "SamsaraPlatformReborn", 66 },
		{ "GetBuildingAreaData", 67 },
		{ "GetBuildingBlockList", 68 },
		{ "GetBuildingBlockData", 69 },
		{ "SetBuildingCustomName", 70 },
		{ "GetEmptyBlockCount", 71 },
		{ "AddChicken", 72 },
		{ "RemoveChicken", 73 },
		{ "RemoveAllChicken", 74 },
		{ "MoveChicken", 75 },
		{ "TransferChicken", 76 },
		{ "GetSettlementChickenList", 77 },
		{ "GetChickenData", 78 },
		{ "InitMapBlockChicken", 79 },
		{ "IsHaveChickenKing", 80 },
		{ "RemoveAllFormResidence", 81 },
		{ "GetBuildingAttainment", 82 },
		{ "CalcResourceOutputCount", 83 },
		{ "DealInfectedPeople", 84 },
		{ "QuickCollectSingleShopItem", 85 },
		{ "QuickCollectSingleShopSoldItem", 86 },
		{ "QuickRecruitSingleBuildingPeople", 87 },
		{ "QuickFillComfortableHouse", 88 },
		{ "RemoveAllFromComfortableHouse", 89 },
		{ "SortedComfortableHousePeople", 90 },
		{ "GetMakeResult", 91 },
		{ "GetSutraReadingRoomBuffValue", 92 },
		{ "SetBuildingAutoWork", 93 },
		{ "GetBuildingIsAutoWork", 94 },
		{ "ShopBuildingMultiChangeSoldItem", 95 },
		{ "RepairItemList", 96 },
		{ "SetBuildingAutoSold", 97 },
		{ "GetBuildingIsAutoSold", 98 },
		{ "GetXiangshuIdInKungfuRoom", 99 },
		{ "RepairItemOptional", 100 },
		{ "SetNickNameByChickenId", 101 },
		{ "GetSettlementChickenDataList", 102 },
		{ "SetTeaHorseCaravanWeather", 103 },
		{ "GetComfortableIsAutoCheckIn", 104 },
		{ "GetResidenceIsAutoCheckIn", 105 },
		{ "SetComfortableAutoCheckIn", 106 },
		{ "SetResidenceAutoCheckIn", 107 },
		{ "GmCmd_AddLegacyBuilding", 108 },
		{ "SetUnlockedWorkingVillagers", 109 },
		{ "WeaveClothingItem", 110 },
		{ "GmCmd_GetChickenData", 111 },
		{ "GetPossessionPreview", 112 },
		{ "TrySwapSoulCeremony", 113 },
		{ "GetBackTeaHorseCarryItem", 114 },
		{ "AddItemToTeaHorseCarryItem", 115 },
		{ "SetTemporaryPossessionCharacterAvatar", 116 },
		{ "GetSwapSoulCeremonyBodyCharIdList", 117 },
		{ "GetBuildingShopManagerAutoArrangeSorted", 118 },
		{ "SectMainStoryJingangClickMonkSoulBtn", 119 },
		{ "RejectBuildingBlockRecruitPeople", 120 },
		{ "RejectBuildingBlockRecruitPeopleQuick", 121 },
		{ "GetShopManagementYieldTipsData", 122 },
		{ "CalculateBuildingManageHarvestSuccessRate", 123 },
		{ "GetOrCreateShopEventCollection", 124 },
		{ "GetSamsaraPlatformRecord", 125 },
		{ "GetSwapSoulCeremonySoulCharIdList", 126 },
		{ "CricketCollectionBatchAddCricketJar", 127 },
		{ "CricketCollectionBatchAddCricket", 128 },
		{ "CricketCollectionBatchRemoveJar", 129 },
		{ "CricketCollectionBatchRemoveCricket", 130 },
		{ "GetCricketOrJarFromSourceStorage", 131 },
		{ "SmartOperateCricketOrJarCollection", 132 },
		{ "GetBatchButtonEnableState", 133 },
		{ "CalculateBuildingManageHarvestSuccessRates", 134 },
		{ "UnsetFulongChicken", 135 },
		{ "SetFulongChicken", 136 },
		{ "GetChickenDataList", 137 },
		{ "GetChickenNicknameList", 138 },
		{ "GetSettlementChickenIdList", 139 },
		{ "GetChickensNicknameByLocation", 140 },
		{ "AllChickenInTaiwuVillage", 141 },
		{ "GetVillagerRoleExtraEffectUnlockState", 142 },
		{ "ClickChickenMap", 143 },
		{ "ClickChickenSign", 144 },
		{ "SetBuildingResourceOutputSetting", 145 },
		{ "GetBuildingResourceOutputSetting", 146 },
		{ "GetBuildingExceptionData", 147 },
		{ "AllDependBuildingAvailable", 148 },
		{ "PracticingCombatSkillInPracticeRoom", 149 },
		{ "HasShopManagerLeader", 150 },
		{ "QuickArrangeShopManager", 151 },
		{ "QuickArrangeBuildOperator", 152 },
		{ "ShopBuildingCanTeach", 153 },
		{ "GetOperationLeftTime", 154 },
		{ "GetBuildingOperationLeftTime", 155 },
		{ "GetShopBuildingTeachBookData", 156 },
		{ "CalcExtraTaiwuGroupMaxCountByStrategyRoom", 157 },
		{ "GetTaiwuCanFixBookItemDataList", 158 },
		{ "GetResidenceInfo", 159 },
		{ "GetTaiwuVillageResourceBlockEffect", 160 },
		{ "GetTaiwuLocationResourceBlockEffect", 161 },
		{ "GetTaiwuVillageResourceBlockEffectInfo", 162 },
		{ "CanQuickArrangeShopManager", 163 },
		{ "GetBuildingFormulaContextBridge", 164 },
		{ "GetBuildingEffectForMake", 165 },
		{ "GmCmd_BuildingCollectPerform", 166 },
		{ "GmCmd_BeatMinionPerform", 167 },
		{ "GetStoreLocation", 168 },
		{ "SetStoreLocation", 169 },
		{ "GetFeastTargetCharList", 170 },
		{ "TryShowNotifications", 171 },
		{ "QuickRemoveShopSoldItem", 172 },
		{ "QuickAddShopSoldItem", 173 },
		{ "CalcTaiwuVillagerInfoDisplayData", 174 },
		{ "CalcTaiwuVillagerEfficiencyInBuilding", 175 },
		{ "QuickGetSpecificExchangeItem", 176 },
		{ "AddLocationMark", 177 },
		{ "RemoveLocationMark", 178 },
		{ "RequestUnlockedWorkingVillagers", 179 },
		{ "SetBuildingArrangementSetting", 180 },
		{ "UpgradeResourceBuilding", 181 },
		{ "UpgradeSlotBuilding", 182 },
		{ "UnlockBuildingLevelSlot", 183 },
		{ "SetBuildingSoldItemSetting", 184 },
		{ "GetPuppetPageDisplayData", 185 },
		{ "QuickRepairAllBuilding", 186 },
		{ "CalcQuickRepairAllBuildingCostMoney", 187 },
		{ "GetBuildingFunctionData", 188 },
		{ "GetTaiwuVillageBuildingAreaData", 189 },
		{ "GetAllPawnShopItem", 190 },
		{ "GetTaiwuVillageBlockEffectInfo", 191 },
		{ "GetTaiwuVillageShopData", 192 },
		{ "GetBuildingEarningDisplayData", 193 },
		{ "GetBuildingManageDisplayData", 194 },
		{ "GetUnlockedFeastTypeList", 195 },
		{ "GetReversedSamsaraRecord", 196 },
		{ "GetLockedComfortableHouseCharacters", 197 },
		{ "GetLockedResidenceCharacters", 198 },
		{ "UnlockComfortableHouseCharacter", 199 },
		{ "LockComfortableHouseCharacter", 200 },
		{ "UnlockResidenceCharacter", 201 },
		{ "SetComfortableAutoCheckInType", 202 },
		{ "LockResidenceCharacter", 203 },
		{ "SetNextTeaHorseCaravanEvent", 204 },
		{ "GetLockedInComfortableHouseIds", 205 },
		{ "GetLockedInResidenceIds", 206 },
		{ "GetReversedBlockShopEvent", 207 },
		{ "PluckAllChickenFeathers", 208 },
		{ "IsAllChickensCanPluck", 209 },
		{ "GetCharacterChickenFeatures", 210 },
		{ "GetChickensByPersonalityType", 211 },
		{ "GetCurrentFeatherValue", 212 },
		{ "CanCultivateFeather", 213 },
		{ "GetChickenPluckFeatherDisplayData", 214 },
		{ "IsFeatherSystemUnlocked", 215 },
		{ "UnlockFeatherSystem", 216 },
		{ "PluckChickenFeather", 217 },
		{ "CanUseChickenFeather", 218 },
		{ "UseChickenFeather", 219 },
		{ "CanPluckFeatherInVillage", 220 },
		{ "CultivateFeather", 221 },
		{ "GetCanPluckFeatherChickenIds", 222 },
		{ "GetSamsaraPlatformBonusAttributes", 223 },
		{ "GetSamsaraPlatformCharDisplayData", 224 },
		{ "QuickAssignChicken", 225 },
		{ "GetCricketCollectionDisplayData", 226 },
		{ "GetBuildingMakeDisplayData", 227 },
		{ "CheckRefineCondition", 228 },
		{ "RefineItem", 229 },
		{ "GetCraftManDisplayDataForCharacter", 230 },
		{ "GetCraftManDisplayDataForBuilding", 231 },
		{ "GetTeaHorseCaravanEvent", 232 },
		{ "TriggerCultivateFeatherEvent", 233 },
		{ "GetTeaHorseCaravanData", 234 },
		{ "QuickDiscardExchangeItem", 235 },
		{ "GetTaiwuVillageBuildingDataForVillagerRole", 236 },
		{ "IsAnyChickensCanPluck", 237 },
		{ "FeedChicken", 238 },
		{ "GetBuildingBlockEffect", 239 },
		{ "ClearNewlyCreatedBuildingIndex", 240 },
		{ "GetNewlyCreatedBuildingIndex", 241 },
		{ "GetQuickCollectResourceAmount", 242 },
		{ "RepairItemsOptional", 243 },
		{ "AnyBuildingEarnCountMax", 244 },
		{ "GetOperationAddProgress", 245 }
	};

	public static readonly string[] MethodId2MethodName = new string[246]
	{
		"SetShopManager", "SetCollectBuildingResourceType", "ClearBuildingBlockEarningsData", "GetBuildingEarningData", "GetBuildingOperatesData", "GetBuildingBuildPeopleAttainments", "AcceptBuildingBlockCollectEarning", "AcceptBuildingBlockCollectEarningQuick", "AcceptBuildingBlockRecruitPeople", "AcceptBuildingBlockRecruitPeopleQuick",
		"ShopBuildingSoldItemReceive", "ShopBuildingSoldItemReceiveQuick", "QuickCollectShopItem", "QuickCollectShopItemCount", "QuickCollectShopSoldItem", "QuickCollectShopSoldItemCount", "QuickRecruitPeople", "QuickRecruitPeopleCount", "QuickCollectBuildingEarn", "QuickCollectBuildingEarnCount",
		"AddFixBook", "ChangeFixBook", "ReceiveFixBook", "GetFixBookProgress", "SetTeaHorseCaravanState", "ExchangeItemToReplenishment", "StartSearchReplenishment", "QuickGetExchangeItem", "GetShrineDisplayData", "TeachSkill",
		"CricketCollectionAdd", "CricketCollectionRemove", "GetCollectionCrickets", "GetCollectionJars", "GetCollectionCricketRegen", "GetAuthorityGain", "GmCmd_BuildImmediately", "GmCmd_RemoveBuildingImmediately", "StartMakeItem", "CheckMakeCondition",
		"GetMakeItems", "GetMakingItemData", "CheckRepairConditionIsMeet", "AddItemPoison", "CheckAddPoisonCondition", "RemoveItemPoison", "CheckRemovePoisonCondition", "Build", "Remove", "SetStopOperation",
		"SetOperator", "Repair", "ConfirmPlanBuilding", "AddToResidence", "RemoveFromResidence", "ReplaceCharacterInResidence", "ReplaceCharacterInComfortableHouse", "AddToComfortableHouse", "RemoveFromComfortableHouse", "QuickFillResidence",
		"GetCharsInResidence", "GetAllResidents", "GetCharsInComfortableHouse", "GetHomeless", "GetSamsaraPlatformCharList", "SetSamsaraPlatformChar", "SamsaraPlatformReborn", "GetBuildingAreaData", "GetBuildingBlockList", "GetBuildingBlockData",
		"SetBuildingCustomName", "GetEmptyBlockCount", "AddChicken", "RemoveChicken", "RemoveAllChicken", "MoveChicken", "TransferChicken", "GetSettlementChickenList", "GetChickenData", "InitMapBlockChicken",
		"IsHaveChickenKing", "RemoveAllFormResidence", "GetBuildingAttainment", "CalcResourceOutputCount", "DealInfectedPeople", "QuickCollectSingleShopItem", "QuickCollectSingleShopSoldItem", "QuickRecruitSingleBuildingPeople", "QuickFillComfortableHouse", "RemoveAllFromComfortableHouse",
		"SortedComfortableHousePeople", "GetMakeResult", "GetSutraReadingRoomBuffValue", "SetBuildingAutoWork", "GetBuildingIsAutoWork", "ShopBuildingMultiChangeSoldItem", "RepairItemList", "SetBuildingAutoSold", "GetBuildingIsAutoSold", "GetXiangshuIdInKungfuRoom",
		"RepairItemOptional", "SetNickNameByChickenId", "GetSettlementChickenDataList", "SetTeaHorseCaravanWeather", "GetComfortableIsAutoCheckIn", "GetResidenceIsAutoCheckIn", "SetComfortableAutoCheckIn", "SetResidenceAutoCheckIn", "GmCmd_AddLegacyBuilding", "SetUnlockedWorkingVillagers",
		"WeaveClothingItem", "GmCmd_GetChickenData", "GetPossessionPreview", "TrySwapSoulCeremony", "GetBackTeaHorseCarryItem", "AddItemToTeaHorseCarryItem", "SetTemporaryPossessionCharacterAvatar", "GetSwapSoulCeremonyBodyCharIdList", "GetBuildingShopManagerAutoArrangeSorted", "SectMainStoryJingangClickMonkSoulBtn",
		"RejectBuildingBlockRecruitPeople", "RejectBuildingBlockRecruitPeopleQuick", "GetShopManagementYieldTipsData", "CalculateBuildingManageHarvestSuccessRate", "GetOrCreateShopEventCollection", "GetSamsaraPlatformRecord", "GetSwapSoulCeremonySoulCharIdList", "CricketCollectionBatchAddCricketJar", "CricketCollectionBatchAddCricket", "CricketCollectionBatchRemoveJar",
		"CricketCollectionBatchRemoveCricket", "GetCricketOrJarFromSourceStorage", "SmartOperateCricketOrJarCollection", "GetBatchButtonEnableState", "CalculateBuildingManageHarvestSuccessRates", "UnsetFulongChicken", "SetFulongChicken", "GetChickenDataList", "GetChickenNicknameList", "GetSettlementChickenIdList",
		"GetChickensNicknameByLocation", "AllChickenInTaiwuVillage", "GetVillagerRoleExtraEffectUnlockState", "ClickChickenMap", "ClickChickenSign", "SetBuildingResourceOutputSetting", "GetBuildingResourceOutputSetting", "GetBuildingExceptionData", "AllDependBuildingAvailable", "PracticingCombatSkillInPracticeRoom",
		"HasShopManagerLeader", "QuickArrangeShopManager", "QuickArrangeBuildOperator", "ShopBuildingCanTeach", "GetOperationLeftTime", "GetBuildingOperationLeftTime", "GetShopBuildingTeachBookData", "CalcExtraTaiwuGroupMaxCountByStrategyRoom", "GetTaiwuCanFixBookItemDataList", "GetResidenceInfo",
		"GetTaiwuVillageResourceBlockEffect", "GetTaiwuLocationResourceBlockEffect", "GetTaiwuVillageResourceBlockEffectInfo", "CanQuickArrangeShopManager", "GetBuildingFormulaContextBridge", "GetBuildingEffectForMake", "GmCmd_BuildingCollectPerform", "GmCmd_BeatMinionPerform", "GetStoreLocation", "SetStoreLocation",
		"GetFeastTargetCharList", "TryShowNotifications", "QuickRemoveShopSoldItem", "QuickAddShopSoldItem", "CalcTaiwuVillagerInfoDisplayData", "CalcTaiwuVillagerEfficiencyInBuilding", "QuickGetSpecificExchangeItem", "AddLocationMark", "RemoveLocationMark", "RequestUnlockedWorkingVillagers",
		"SetBuildingArrangementSetting", "UpgradeResourceBuilding", "UpgradeSlotBuilding", "UnlockBuildingLevelSlot", "SetBuildingSoldItemSetting", "GetPuppetPageDisplayData", "QuickRepairAllBuilding", "CalcQuickRepairAllBuildingCostMoney", "GetBuildingFunctionData", "GetTaiwuVillageBuildingAreaData",
		"GetAllPawnShopItem", "GetTaiwuVillageBlockEffectInfo", "GetTaiwuVillageShopData", "GetBuildingEarningDisplayData", "GetBuildingManageDisplayData", "GetUnlockedFeastTypeList", "GetReversedSamsaraRecord", "GetLockedComfortableHouseCharacters", "GetLockedResidenceCharacters", "UnlockComfortableHouseCharacter",
		"LockComfortableHouseCharacter", "UnlockResidenceCharacter", "SetComfortableAutoCheckInType", "LockResidenceCharacter", "SetNextTeaHorseCaravanEvent", "GetLockedInComfortableHouseIds", "GetLockedInResidenceIds", "GetReversedBlockShopEvent", "PluckAllChickenFeathers", "IsAllChickensCanPluck",
		"GetCharacterChickenFeatures", "GetChickensByPersonalityType", "GetCurrentFeatherValue", "CanCultivateFeather", "GetChickenPluckFeatherDisplayData", "IsFeatherSystemUnlocked", "UnlockFeatherSystem", "PluckChickenFeather", "CanUseChickenFeather", "UseChickenFeather",
		"CanPluckFeatherInVillage", "CultivateFeather", "GetCanPluckFeatherChickenIds", "GetSamsaraPlatformBonusAttributes", "GetSamsaraPlatformCharDisplayData", "QuickAssignChicken", "GetCricketCollectionDisplayData", "GetBuildingMakeDisplayData", "CheckRefineCondition", "RefineItem",
		"GetCraftManDisplayDataForCharacter", "GetCraftManDisplayDataForBuilding", "GetTeaHorseCaravanEvent", "TriggerCultivateFeatherEvent", "GetTeaHorseCaravanData", "QuickDiscardExchangeItem", "GetTaiwuVillageBuildingDataForVillagerRole", "IsAnyChickensCanPluck", "FeedChicken", "GetBuildingBlockEffect",
		"ClearNewlyCreatedBuildingIndex", "GetNewlyCreatedBuildingIndex", "GetQuickCollectResourceAmount", "RepairItemsOptional", "AnyBuildingEarnCountMax", "GetOperationAddProgress"
	};
}

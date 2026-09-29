using System.Collections.Generic;

namespace GameData.Domains.Taiwu;

public static class TaiwuDomainHelper
{
	public static class DataIds
	{
		public const ushort TaiwuCharId = 0;

		public const ushort TaiwuGenerationsCount = 1;

		public const ushort CricketLuckPoint = 2;

		public const ushort PreviousTaiwuIds = 3;

		public const ushort NeedToEscape = 4;

		public const ushort ReceivedItems = 5;

		public const ushort ReceivedCharacters = 6;

		public const ushort WarehouseMaxLoad = 7;

		public const ushort WarehouseCurrLoad = 8;

		public const ushort BuildingSpaceLimit = 9;

		public const ushort BuildingSpaceCurr = 10;

		public const ushort BuildingSpaceExtraAdd = 11;

		public const ushort ProsperousConstruction = 12;

		public const ushort CombatSkills = 13;

		public const ushort LifeSkills = 14;

		public const ushort CombatSkillPlans = 15;

		public const ushort CurrCombatSkillPlanId = 16;

		public const ushort CurrLifeSkillAttainmentPanelPlanIndex = 17;

		public const ushort TeachTaiwuLifeSkillDict = 18;

		public const ushort TeachTaiwuCombatSkillDict = 19;

		public const ushort CombatSkillAttainmentPanelPlans = 20;

		public const ushort CurrCombatSkillAttainmentPanelPlanIds = 21;

		public const ushort MoveTimeCostPercent = 22;

		public const ushort WeaponInnerRatios = 23;

		public const ushort WeaponCurrInnerRatios = 24;

		public const ushort Appointments = 25;

		public const ushort BabyBonusMainAttributes = 26;

		public const ushort BabyBonusLifeSkillQualifications = 27;

		public const ushort BabyBonusCombatSkillQualifications = 28;

		public const ushort EquipmentsPlans = 29;

		public const ushort CurrEquipmentPlanId = 30;

		public const ushort GroupCharIds = 31;

		public const ushort CombatGroupCharIds = 32;

		public const ushort TaiwuGroupMaxCount = 33;

		public const ushort LegacyPointDict = 34;

		public const ushort LegacyPoint = 35;

		public const ushort AvailableLegacyList = 36;

		public const ushort LegacyPassingState = 37;

		public const ushort SuccessorCandidates = 38;

		public const ushort StateNewCharacterLegacyGrowingGrades = 39;

		public const ushort NotLearnCombatSkillReadingProgress = 40;

		public const ushort NotLearnLifeSkillReadingProgress = 41;

		public const ushort ReadingBooks = 42;

		public const ushort CurReadingBook = 43;

		public const ushort ReferenceBooks = 44;

		public const ushort ReferenceBookSlotUnlockStates = 45;

		public const ushort ReadingEventTriggered = 46;

		public const ushort ReadInCombatCount = 47;

		public const ushort HealingOuterInjuryRestriction = 48;

		public const ushort HealingInnerInjuryRestriction = 49;

		public const ushort NeiliAllocationTypeRestriction = 50;

		public const ushort VisitedSettlements = 51;

		public const ushort TaiwuVillageSettlementId = 52;

		public const ushort VillagerWork = 53;

		public const ushort VillagerWorkLocations = 54;

		public const ushort MaterialResourceMaxCount = 55;

		public const ushort ResourceChange = 56;

		public const ushort WorkLocationMaxCount = 57;

		public const ushort TotalVillagerCount = 58;

		public const ushort TotalAdultVillagerCount = 59;

		public const ushort AvailableVillagerCount = 60;

		public const ushort IsTaiwuDieOfCombatWithXiangshu = 61;

		public const ushort OverweightSanctionPercent = 62;

		public const ushort ReferenceSkillSlotUnlockStates = 63;

		public const ushort TaiwuGroupWorstInjuries = 64;

		public const ushort TotalResources = 65;

		public const ushort TaiwuSpecialGroup = 66;

		public const ushort TaiwuGearMateGroup = 67;

		public const ushort CanBreakOut = 68;

		public const ushort TroughMaxLoad = 69;

		public const ushort TroughCurrLoad = 70;

		public const ushort ClothingDurability = 71;

		public const ushort TaiwuCharIdForJixi = 72;

		public const ushort TaiwuCharIdForCloseFriend = 73;

		public const ushort TaiwuCharIdForJixiIsMerge = 74;

		public const ushort OwnedClothingSet = 75;

		public const ushort ClothingDisplayModifications = 76;

		public const ushort WeaveClothingDisplaySetting = 77;

		public const ushort TaiwuPropertyPermanentBonuses = 78;

		public const ushort SelectedUniqueLegacies = 79;

		public const ushort LegacyPointTimesDict = 80;

		public const ushort VillagerSkillLegacyPointDict = 81;

		public const ushort ManualChangeEquipGroupCharIds = 82;

		public const ushort GroupCharacterEquipmentRecord = 83;

		public const ushort FavoriteCombatSkills = 84;

		public const ushort ShouldExpandPracticePanel = 85;

		public const ushort ConsummateLevelOnNeiliPage = 86;

		public const ushort CombatResultSelectAllItem = 87;

		public const ushort Treasury = 88;

		public const ushort Stock = 89;

		public const ushort Trough = 90;

		public const ushort Warehouse = 91;

		public const ushort TaiwuVillageStoragesRecordCollection = 92;

		public const ushort LuohanBreak = 93;

		public const ushort NextBreakoutStepBaseBonus = 94;

		public const ushort NextBreakoutSuccessRateBonus = 95;

		public const ushort LockedItemSet = 96;

		public const ushort LifeSkillStrategyPlans = 97;

		public const ushort CricketBettingAutoBet = 98;

		public const ushort CricketPreset = 99;

		public const ushort UnlockScrollList = 100;

		public const ushort VillagerWorkLocationCount = 101;

		public const ushort CanCollectDangerousResource = 102;

		public const ushort PrevTaiwuLifeSummaries = 103;

		public const ushort CurrTaiwuLifeSummary = 104;

		public const ushort CricketPolymorphs = 105;

		public const ushort CricketRoomData = 106;

		public const ushort MainOperationOrder = 107;

		public const ushort HideSkeletonEquipSlots = 108;

		public const ushort SelectedBottomShortcut = 109;

		public const ushort WeaponInnerRatiosById = 110;

		public const ushort WeaponInnerRatiosByTemplateId = 111;

		public const ushort ItemAutoOperationSettingData = 112;

		public const ushort UnlockedDebateStrategyList = 113;

		public const ushort CombatSkillBreakPlates = 114;

		public const ushort CombatSkillBreakPresets = 115;

		public const ushort CombatSkillConflicts = 116;

		public const ushort SpecifyClothingTemplateId = 117;

		public const ushort SelectedLifeSkillStrategyPlanIndex = 118;

		public const ushort FarmerAutoWorkConfig = 119;

		public const ushort LegacyPointDictNew = 120;
	}

	public static class MethodIds
	{
		public const ushort GetAllVisitedSettlements = 0;

		public const ushort SetVillagerCollectResourceWork = 1;

		public const ushort SetVillagerCollectTributeWork = 2;

		public const ushort SetVillagerKeepGraveWork = 3;

		public const ushort SetVillagerIdleWork = 4;

		public const ushort StopVillagerWork = 5;

		public const ushort StopVillagerCollectResourceWork = 6;

		public const ushort GetCollectResourceWorkDataList = 7;

		public const ushort ExpelVillager = 8;

		public const ushort GetVillagerStatusDisplayDataList = 9;

		public const ushort GetAllVillagersStatus = 10;

		public const ushort GetAllVillagersAvailableForWork = 11;

		public const ushort CalcResourceChangeByVillageWork = 12;

		public const ushort CalcResourceChangeByBuildingEarn = 13;

		public const ushort CalcResourceChangeByBuildingMaintain = 14;

		public const ushort GetAllWarehouseItems = 15;

		public const ushort GetWarehouseItemsBySubType = 16;

		public const ushort SwitchEquipmentPlan = 17;

		public const ushort GmCmd_AddResource = 18;

		public const ushort GmCmd_AddLegacyPoint = 19;

		public const ushort GmCmd_AddExp = 20;

		public const ushort GmCmd_SetTaiwuCombatSkillActiveState = 21;

		public const ushort JoinGroup = 22;

		public const ushort LeaveGroup = 23;

		public const ushort CompletePassingLegacy = 24;

		public const ushort SelectLegacy = 25;

		public const ushort FindSuccessorCandidates = 26;

		public const ushort ConfirmChosenSuccessor = 27;

		public const ushort SetReferenceBook = 28;

		public const ushort SetReadingBook = 29;

		public const ushort GetCurReadingStrategies = 30;

		public const ushort SetReadingStrategy = 31;

		public const ushort ClearPageStrategy = 32;

		public const ushort GetRandomSelectableStrategies = 33;

		public const ushort CheckNotInInventoryBooks = 34;

		public const ushort GetTotalReadingProgress = 35;

		public const ushort GetCurrReadingEventBonusRate = 36;

		public const ushort GetCurrReadingEfficiency = 37;

		public const ushort WarehouseAdd = 38;

		public const ushort WarehouseRemove = 39;

		public const ushort PutItemIntoWarehouse = 40;

		public const ushort TakeOutItemFromWarehouse = 41;

		public const ushort CanTransferItemToWarehouse = 42;

		public const ushort CalcBuildingResourceOutput = 43;

		public const ushort TransferAllItems = 44;

		public const ushort SelectCombatSkillAttainmentPanelPlan = 45;

		public const ushort GetGenericGridAllocation = 46;

		public const ushort AllocateGenericGrid = 47;

		public const ushort DeallocateGenericGrid = 48;

		public const ushort UpdateCombatSkillPlan = 49;

		public const ushort GetBreakPlateData = 50;

		public const ushort EnterSkillBreakPlate = 51;

		public const ushort ClearBreakPlate = 52;

		public const ushort SelectSkillBreakGrid = 53;

		public const ushort EscapeToAdjacentBlock = 54;

		public const ushort GetCanOperateItemDisplayDataInVillage = 55;

		public const ushort PutItemListIntoWarehouse = 56;

		public const ushort WarehouseAddList = 57;

		public const ushort TakeOutItemListFromWarehouse = 58;

		public const ushort WarehouseRemoveList = 59;

		public const ushort GetTaiwuAllItems = 60;

		public const ushort TransferItem = 61;

		public const ushort GetAllTroughItems = 62;

		public const ushort TransferItemList = 63;

		public const ushort GetAllTreasuryItems = 64;

		public const ushort GetTotalReadingProgressList = 65;

		public const ushort CalcResourceChangeByAutoExpand = 66;

		public const ushort CalcAutoExpandNotSatisfyIndex = 67;

		public const ushort GetRefBonusSpeed = 68;

		public const ushort FindTaiwuBuilding = 69;

		public const ushort ChoosyGetMaterial = 70;

		public const ushort GetCannotOperateItemDisplayDataInInventory = 71;

		public const ushort GetInventoryOverloadedGroupCharNames = 72;

		public const ushort SetAutoAllocateNeiliToMax = 73;

		public const ushort MasteredSkillWillChangePlan = 74;

		public const ushort GetVillagersForWork = 75;

		public const ushort GetSeverelyInjuredGroupCharNames = 76;

		public const ushort GetItemCount = 77;

		public const ushort GetTaiwuVillagerMapBlockData = 78;

		public const ushort StopVillagerWorkOptional = 79;

		public const ushort GetLegacyMaxPointByType = 80;

		public const ushort GetCurrReadingBanByWug = 81;

		public const ushort GmCmd_MarkAllCarrierFullTamePoint = 82;

		public const ushort GetSelectMapBlockHasMerchantId = 83;

		public const ushort ActiveReadOnce = 84;

		public const ushort ActiveNeigongLoopingOnce = 85;

		public const ushort AppendCombatSkillPlan = 86;

		public const ushort CopyCombatSkillPlan = 87;

		public const ushort ClearCombatSkillPlan = 88;

		public const ushort DeleteCombatSkillPlan = 89;

		public const ushort GetLegacyMaxPointAndTimesListByType = 90;

		public const ushort SetQiArtStrategy = 91;

		public const ushort GetCurrentBookAvailableReadingStrategies = 92;

		public const ushort GetLoopingNeigongQiArtStrategies = 93;

		public const ushort SetReferenceCombatSkillAt = 94;

		public const ushort GetLoopingNeigongQiArtStrategyDisplayDatas = 95;

		public const ushort GetLoopingNeigongAvailableQiArtStrategies = 96;

		public const ushort ClearCurrentLoopingNeigongEvent = 97;

		public const ushort SetTaiwuLoopingNeigong = 98;

		public const ushort DeleteTaiwuFeature = 99;

		public const ushort GmCmd_TaiwuActiveLoopingApply = 100;

		public const ushort GetIsFollowingNpcListMax = 101;

		public const ushort GetFollowingNpcListMaxCount = 102;

		public const ushort GmCmd_FollowRandomNpc = 103;

		public const ushort TaiwuFollowNpc = 104;

		public const ushort TaiwuUnfollowNpc = 105;

		public const ushort SetFollowingNpcNickName = 106;

		public const ushort GetFollowingNpcNickName = 107;

		public const ushort GetFollowingNpcNickNameId = 108;

		public const ushort GetVillagerRoleCharacterDisplayDataList = 109;

		public const ushort GetVillagerRoleCharacterDisplayData = 110;

		public const ushort BatchSetVillagerRole = 111;

		public const ushort DispatchVillagerArrangement = 112;

		public const ushort RecallVillager = 113;

		public const ushort AssignTargetItem = 114;

		public const ushort GetVillagerRoleDisplayData = 115;

		public const ushort AssignArrangementIncreaseOrDecrease = 116;

		public const ushort GetAllVillagerRoleDisplayData = 117;

		public const ushort GetAllItems = 118;

		public const ushort TransferResource = 119;

		public const ushort GetVillagerRoleTipsDisplayData = 120;

		public const ushort SetVillagerRole = 121;

		public const ushort SetVillagerMigrateWork = 122;

		public const ushort GetVillagerRoleNpcNickName = 123;

		public const ushort SetVillagerRoleNickName = 124;

		public const ushort GetVillagersAvailableForVillagerRole = 125;

		public const ushort GetAllResources = 126;

		public const ushort GetAllSwordTombDisplayDataForDispatch = 127;

		public const ushort GetVillagerRoleCharacterSlimDisplayData = 128;

		public const ushort GetAllWarehouseItemsExcludeValueZero = 129;

		public const ushort GmCmd_FillLegacyPoint = 130;

		public const ushort GetVillagerRoleExecuteFixedActionFailReasons = 131;

		public const ushort SetMerchantType = 132;

		public const ushort GetMerchantType = 133;

		public const ushort GetProfessionTipDisplayData = 134;

		public const ushort GetExpByRereading = 135;

		public const ushort EnterMerchant = 136;

		public const ushort GetReadingResult = 137;

		public const ushort GetVillagerTreasuryNeed = 138;

		public const ushort GetTreasuryNeededItemList = 139;

		public const ushort GetDyingGroupCharNames = 140;

		public const ushort GetBreakBaseCostExp = 141;

		public const ushort SetBonusRelation = 142;

		public const ushort SetBonusExp = 143;

		public const ushort SetBonusItem = 144;

		public const ushort SetActivePage = 145;

		public const ushort GetAvailableRelationBonuses = 146;

		public const ushort GetVillagerCollectStorageType = 147;

		public const ushort SetVillagerCollectStorageType = 148;

		public const ushort ClearBonus = 149;

		public const ushort TaiwuAddFeature = 150;

		public const ushort GetRandomLegaciesInGroup = 151;

		public const ushort GetGroupBabyCount = 152;

		public const ushort GetStrategyRoomLevel = 153;

		public const ushort SetBonusFriend = 154;

		public const ushort GmCmd_ShowUnlockedDebateStrategy = 155;

		public const ushort GmCmd_ChangeGamePoint = 156;

		public const ushort GmCmd_SetForceAiBribery = 157;

		public const ushort DebateGameOver = 158;

		public const ushort DebateGameSetTaiwuAi = 159;

		public const ushort DebateGameMakeMove = 160;

		public const ushort DebateGameNextState = 161;

		public const ushort DebateGamePickSpectators = 162;

		public const ushort DebateGameInitialize = 163;

		public const ushort DebateGameCastStrategy = 164;

		public const ushort GmCmd_GetDebateStrategyCard = 165;

		public const ushort GmCmd_ChangeStrategyPoint = 166;

		public const ushort GmCmd_ChangeBases = 167;

		public const ushort GetNewUnlockedDebateStrategyList = 168;

		public const ushort GmCmd_ChangePressure = 169;

		public const ushort DebateGameSetTaiwuSelectedCardTypes = 170;

		public const ushort DebateGameGetTaiwuSelectedCardTypes = 171;

		public const ushort GmCmd_AddAiOwnedCard = 172;

		public const ushort GmCmd_EmptyAiOwnedCard = 173;

		public const ushort DebateGameTryForceWin = 174;

		public const ushort SetVillagerDevelopWork = 175;

		public const ushort GetVillagerRoleCharacterDisplayDataOnPanel = 176;

		public const ushort GetIsTaiwuFirstByLuck = 177;

		public const ushort GmCmd_AddNodeEffect = 178;

		public const ushort GetVillagerFarmerMigrateResourceSuccessRateBonus = 179;

		public const ushort GetVillagerRoleHeadTotalAuthorityCost = 180;

		public const ushort GetAllChildAvailableForWork = 181;

		public const ushort GetTaiwuVillageSpaceLimitInfo = 182;

		public const ushort GetGroupNeiliConflictingCharDataList = 183;

		public const ushort DebateGameResetCards = 184;

		public const ushort DebateGameRemoveCards = 185;

		public const ushort SetLastCricketPlan = 186;

		public const ushort RequestValidCricketPlan = 187;

		public const ushort SetCricketPlan = 188;

		public const ushort ClearCricketPlan = 189;

		public const ushort GetLastCricketPlan = 190;

		public const ushort GetAiBriberyDataOnPrepareLifeSkillCombat = 191;

		public const ushort SwapSkillBreakGrid = 192;

		public const ushort GetAllItemsForSelect = 193;

		public const ushort GetAllCharacterPropertyBonusData = 194;

		public const ushort RequestCurrEquipmentPlanId = 195;

		public const ushort RemoveManualChangeEquipGroupChar = 196;

		public const ushort AddManualChangeEquipGroupChar = 197;

		public const ushort RequestManualChangeEquipGroupCharIds = 198;

		public const ushort RequestHideSkeletonEquipSlots = 199;

		public const ushort GetSkillBreakBonusSelectDisplayData = 200;

		public const ushort GetEnterSkillBreakPlateInfo = 201;

		public const ushort RemoveFavoriteCombatSkill = 202;

		public const ushort AddFavoriteCombatSkill = 203;

		public const ushort RequestReadingAndLooping = 204;

		public const ushort RequestTaiwuResourceDisplayData = 205;

		public const ushort SetExpandPracticePanel = 206;

		public const ushort GetExpandPracticePanel = 207;

		public const ushort GetVillagersAvailableForWorkDisplayData = 208;

		public const ushort SetConsummateLevelOnNeiliPage = 209;

		public const ushort GetVillagersAvailableForTreeClearEnemy = 210;

		public const ushort SetCombatResultSelectAllItem = 211;

		public const ushort GetReadingResultPreview = 212;

		public const ushort AddStockItem = 213;

		public const ushort GetTaiwuVillageStoragesRecordCollection = 214;

		public const ushort GetExchangeDisplayData = 215;

		public const ushort ConfirmExchange = 216;

		public const ushort GetTreasuryNeededItemDataList = 217;

		public const ushort GetShopDisplayData = 218;

		public const ushort ConfirmShopExchange = 219;

		public const ushort GetLoopingViewDisplayData = 220;

		public const ushort RequestLegacyDisplayData = 221;

		public const ushort SelectLegacies = 222;

		public const ushort RequestFollowingCharacterList = 223;

		public const ushort SetLuohanBreak = 224;

		public const ushort GetAllDishes = 225;

		public const ushort GetLoopReadCountDisplayData = 226;

		public const ushort ExpelVillagers = 227;

		public const ushort GetVillagerRoleCharacterDisplayDataRolePage = 228;

		public const ushort GetChangeWeaponTrickDisplayData = 229;

		public const ushort SetItemLocked = 230;

		public const ushort SetItemListLocked = 231;

		public const ushort GetReversedTaiwuVillageStoragesRecordCollection = 232;

		public const ushort RequestLifeSkillStrategyPlans = 233;

		public const ushort SetLifeSkillStrategyPlansElement = 234;

		public const ushort GetLifeSkillCombatBeginDisplayData = 235;

		public const ushort DebateGameTryForceWinInCombatBegin = 236;

		public const ushort LearnProfessionSkill = 237;

		public const ushort GetCricketCombatTaiwuDisplayData = 238;

		public const ushort RequestTravelerSkillsDisplayData = 239;

		public const ushort SetCricketBettingAutoBet = 240;

		public const ushort GetTotalVillagerMaintenance = 241;

		public const ushort GetUnlockScrollListForDisplay = 242;

		public const ushort UpdateUnlockScrollList = 243;

		public const ushort GetSkillBreakPlateSkillInfo = 244;

		public const ushort SetFarmerMigrateWork = 245;

		public const ushort SetFarmerCollectResourceWork = 246;

		public const ushort GetTaiwuVillagerRoleDisplayData = 247;

		public const ushort GetTaiwuItemMultiplyOperationDisplayData = 248;

		public const ushort GmCmd_GenerateCricketPolymorph = 249;

		public const ushort PutMaterialToCricketRoom = 250;

		public const ushort TakeMaterialFromCricketRoom = 251;

		public const ushort ChangeLegacyPointWhilePassingLegacy = 252;

		public const ushort GetVillagersForWorkDisplayData = 253;

		public const ushort RequestFollowingCharacter = 254;

		public const ushort FeedingCricket = 255;

		public const ushort CricketRoomPolymorphReturn = 256;

		public const ushort CricketRoomWishingCricket = 257;

		public const ushort GmCmd_GenerateCricketWishing = 258;

		public const ushort CricketWishingCricketReturnLuckPoint = 259;

		public const ushort GetTaiwuLifeSummaryDisplayData = 260;

		public const ushort GetTotalTaiwuLifeSummaryInfo = 261;

		public const ushort SetMainOperationOrder = 262;

		public const ushort RequestMainOperationOrder = 263;

		public const ushort RemoveHideSkeletonEquipSlot = 264;

		public const ushort AddHideSkeletonEquipSlot = 265;

		public const ushort RequestTaiwuEquipWithoutHideForSkeleton = 266;

		public const ushort RequestTaiwuNeiliProportionDisplayData = 267;

		public const ushort SetActiveShortCut = 268;

		public const ushort RequestActiveShortCut = 269;

		public const ushort RecordLifeSummary = 270;

		public const ushort TaiwuInventoryHasItem = 271;

		public const ushort GetWineTasterBonusPercentage = 272;

		public const ushort HasSectItem = 273;

		public const ushort ChangeCombatSkillBreakPlate = 274;

		public const ushort GetCombatSkillBreakPreset = 275;

		public const ushort AddCricketPlan = 276;

		public const ushort CloneCricketPlan = 277;

		public const ushort DeleteCricketPlan = 278;

		public const ushort GetCricketPlanCount = 279;

		public const ushort GetVillagerListClassArray = 280;

		public const ushort GetVillagerClassesDict = 281;

		public const ushort GetTreasuryItemNeededCharDict = 282;

		public const ushort TransferItemInventory = 283;

		public const ushort SetSelectedLifeSkillStrategyPlanIndex = 284;

		public const ushort GetRepairPlan = 285;

		public const ushort SetCricketPolymorphPlan = 286;

		public const ushort GetCricketPlanData = 287;

		public const ushort GetPreviewReadingEfficiency = 288;

		public const ushort RequestShortCutOperationLevelData = 289;

		public const ushort GetFarmerMigrateWorkStatus = 290;

		public const ushort SetFarmerMigrateWorkStatus = 291;
	}

	public const ushort DataCount = 121;

	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "TaiwuCharId", 0 },
		{ "TaiwuGenerationsCount", 1 },
		{ "CricketLuckPoint", 2 },
		{ "PreviousTaiwuIds", 3 },
		{ "NeedToEscape", 4 },
		{ "ReceivedItems", 5 },
		{ "ReceivedCharacters", 6 },
		{ "WarehouseMaxLoad", 7 },
		{ "WarehouseCurrLoad", 8 },
		{ "BuildingSpaceLimit", 9 },
		{ "BuildingSpaceCurr", 10 },
		{ "BuildingSpaceExtraAdd", 11 },
		{ "ProsperousConstruction", 12 },
		{ "CombatSkills", 13 },
		{ "LifeSkills", 14 },
		{ "CombatSkillPlans", 15 },
		{ "CurrCombatSkillPlanId", 16 },
		{ "CurrLifeSkillAttainmentPanelPlanIndex", 17 },
		{ "TeachTaiwuLifeSkillDict", 18 },
		{ "TeachTaiwuCombatSkillDict", 19 },
		{ "CombatSkillAttainmentPanelPlans", 20 },
		{ "CurrCombatSkillAttainmentPanelPlanIds", 21 },
		{ "MoveTimeCostPercent", 22 },
		{ "WeaponInnerRatios", 23 },
		{ "WeaponCurrInnerRatios", 24 },
		{ "Appointments", 25 },
		{ "BabyBonusMainAttributes", 26 },
		{ "BabyBonusLifeSkillQualifications", 27 },
		{ "BabyBonusCombatSkillQualifications", 28 },
		{ "EquipmentsPlans", 29 },
		{ "CurrEquipmentPlanId", 30 },
		{ "GroupCharIds", 31 },
		{ "CombatGroupCharIds", 32 },
		{ "TaiwuGroupMaxCount", 33 },
		{ "LegacyPointDict", 34 },
		{ "LegacyPoint", 35 },
		{ "AvailableLegacyList", 36 },
		{ "LegacyPassingState", 37 },
		{ "SuccessorCandidates", 38 },
		{ "StateNewCharacterLegacyGrowingGrades", 39 },
		{ "NotLearnCombatSkillReadingProgress", 40 },
		{ "NotLearnLifeSkillReadingProgress", 41 },
		{ "ReadingBooks", 42 },
		{ "CurReadingBook", 43 },
		{ "ReferenceBooks", 44 },
		{ "ReferenceBookSlotUnlockStates", 45 },
		{ "ReadingEventTriggered", 46 },
		{ "ReadInCombatCount", 47 },
		{ "HealingOuterInjuryRestriction", 48 },
		{ "HealingInnerInjuryRestriction", 49 },
		{ "NeiliAllocationTypeRestriction", 50 },
		{ "VisitedSettlements", 51 },
		{ "TaiwuVillageSettlementId", 52 },
		{ "VillagerWork", 53 },
		{ "VillagerWorkLocations", 54 },
		{ "MaterialResourceMaxCount", 55 },
		{ "ResourceChange", 56 },
		{ "WorkLocationMaxCount", 57 },
		{ "TotalVillagerCount", 58 },
		{ "TotalAdultVillagerCount", 59 },
		{ "AvailableVillagerCount", 60 },
		{ "IsTaiwuDieOfCombatWithXiangshu", 61 },
		{ "OverweightSanctionPercent", 62 },
		{ "ReferenceSkillSlotUnlockStates", 63 },
		{ "TaiwuGroupWorstInjuries", 64 },
		{ "TotalResources", 65 },
		{ "TaiwuSpecialGroup", 66 },
		{ "TaiwuGearMateGroup", 67 },
		{ "CanBreakOut", 68 },
		{ "TroughMaxLoad", 69 },
		{ "TroughCurrLoad", 70 },
		{ "ClothingDurability", 71 },
		{ "TaiwuCharIdForJixi", 72 },
		{ "TaiwuCharIdForCloseFriend", 73 },
		{ "TaiwuCharIdForJixiIsMerge", 74 },
		{ "OwnedClothingSet", 75 },
		{ "ClothingDisplayModifications", 76 },
		{ "WeaveClothingDisplaySetting", 77 },
		{ "TaiwuPropertyPermanentBonuses", 78 },
		{ "SelectedUniqueLegacies", 79 },
		{ "LegacyPointTimesDict", 80 },
		{ "VillagerSkillLegacyPointDict", 81 },
		{ "ManualChangeEquipGroupCharIds", 82 },
		{ "GroupCharacterEquipmentRecord", 83 },
		{ "FavoriteCombatSkills", 84 },
		{ "ShouldExpandPracticePanel", 85 },
		{ "ConsummateLevelOnNeiliPage", 86 },
		{ "CombatResultSelectAllItem", 87 },
		{ "Treasury", 88 },
		{ "Stock", 89 },
		{ "Trough", 90 },
		{ "Warehouse", 91 },
		{ "TaiwuVillageStoragesRecordCollection", 92 },
		{ "LuohanBreak", 93 },
		{ "NextBreakoutStepBaseBonus", 94 },
		{ "NextBreakoutSuccessRateBonus", 95 },
		{ "LockedItemSet", 96 },
		{ "LifeSkillStrategyPlans", 97 },
		{ "CricketBettingAutoBet", 98 },
		{ "CricketPreset", 99 },
		{ "UnlockScrollList", 100 },
		{ "VillagerWorkLocationCount", 101 },
		{ "CanCollectDangerousResource", 102 },
		{ "PrevTaiwuLifeSummaries", 103 },
		{ "CurrTaiwuLifeSummary", 104 },
		{ "CricketPolymorphs", 105 },
		{ "CricketRoomData", 106 },
		{ "MainOperationOrder", 107 },
		{ "HideSkeletonEquipSlots", 108 },
		{ "SelectedBottomShortcut", 109 },
		{ "WeaponInnerRatiosById", 110 },
		{ "WeaponInnerRatiosByTemplateId", 111 },
		{ "ItemAutoOperationSettingData", 112 },
		{ "UnlockedDebateStrategyList", 113 },
		{ "CombatSkillBreakPlates", 114 },
		{ "CombatSkillBreakPresets", 115 },
		{ "CombatSkillConflicts", 116 },
		{ "SpecifyClothingTemplateId", 117 },
		{ "SelectedLifeSkillStrategyPlanIndex", 118 },
		{ "FarmerAutoWorkConfig", 119 },
		{ "LegacyPointDictNew", 120 }
	};

	public static readonly string[] DataId2FieldName = new string[121]
	{
		"TaiwuCharId", "TaiwuGenerationsCount", "CricketLuckPoint", "PreviousTaiwuIds", "NeedToEscape", "ReceivedItems", "ReceivedCharacters", "WarehouseMaxLoad", "WarehouseCurrLoad", "BuildingSpaceLimit",
		"BuildingSpaceCurr", "BuildingSpaceExtraAdd", "ProsperousConstruction", "CombatSkills", "LifeSkills", "CombatSkillPlans", "CurrCombatSkillPlanId", "CurrLifeSkillAttainmentPanelPlanIndex", "TeachTaiwuLifeSkillDict", "TeachTaiwuCombatSkillDict",
		"CombatSkillAttainmentPanelPlans", "CurrCombatSkillAttainmentPanelPlanIds", "MoveTimeCostPercent", "WeaponInnerRatios", "WeaponCurrInnerRatios", "Appointments", "BabyBonusMainAttributes", "BabyBonusLifeSkillQualifications", "BabyBonusCombatSkillQualifications", "EquipmentsPlans",
		"CurrEquipmentPlanId", "GroupCharIds", "CombatGroupCharIds", "TaiwuGroupMaxCount", "LegacyPointDict", "LegacyPoint", "AvailableLegacyList", "LegacyPassingState", "SuccessorCandidates", "StateNewCharacterLegacyGrowingGrades",
		"NotLearnCombatSkillReadingProgress", "NotLearnLifeSkillReadingProgress", "ReadingBooks", "CurReadingBook", "ReferenceBooks", "ReferenceBookSlotUnlockStates", "ReadingEventTriggered", "ReadInCombatCount", "HealingOuterInjuryRestriction", "HealingInnerInjuryRestriction",
		"NeiliAllocationTypeRestriction", "VisitedSettlements", "TaiwuVillageSettlementId", "VillagerWork", "VillagerWorkLocations", "MaterialResourceMaxCount", "ResourceChange", "WorkLocationMaxCount", "TotalVillagerCount", "TotalAdultVillagerCount",
		"AvailableVillagerCount", "IsTaiwuDieOfCombatWithXiangshu", "OverweightSanctionPercent", "ReferenceSkillSlotUnlockStates", "TaiwuGroupWorstInjuries", "TotalResources", "TaiwuSpecialGroup", "TaiwuGearMateGroup", "CanBreakOut", "TroughMaxLoad",
		"TroughCurrLoad", "ClothingDurability", "TaiwuCharIdForJixi", "TaiwuCharIdForCloseFriend", "TaiwuCharIdForJixiIsMerge", "OwnedClothingSet", "ClothingDisplayModifications", "WeaveClothingDisplaySetting", "TaiwuPropertyPermanentBonuses", "SelectedUniqueLegacies",
		"LegacyPointTimesDict", "VillagerSkillLegacyPointDict", "ManualChangeEquipGroupCharIds", "GroupCharacterEquipmentRecord", "FavoriteCombatSkills", "ShouldExpandPracticePanel", "ConsummateLevelOnNeiliPage", "CombatResultSelectAllItem", "Treasury", "Stock",
		"Trough", "Warehouse", "TaiwuVillageStoragesRecordCollection", "LuohanBreak", "NextBreakoutStepBaseBonus", "NextBreakoutSuccessRateBonus", "LockedItemSet", "LifeSkillStrategyPlans", "CricketBettingAutoBet", "CricketPreset",
		"UnlockScrollList", "VillagerWorkLocationCount", "CanCollectDangerousResource", "PrevTaiwuLifeSummaries", "CurrTaiwuLifeSummary", "CricketPolymorphs", "CricketRoomData", "MainOperationOrder", "HideSkeletonEquipSlots", "SelectedBottomShortcut",
		"WeaponInnerRatiosById", "WeaponInnerRatiosByTemplateId", "ItemAutoOperationSettingData", "UnlockedDebateStrategyList", "CombatSkillBreakPlates", "CombatSkillBreakPresets", "CombatSkillConflicts", "SpecifyClothingTemplateId", "SelectedLifeSkillStrategyPlanIndex", "FarmerAutoWorkConfig",
		"LegacyPointDictNew"
	};

	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[121][];

	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "GetAllVisitedSettlements", 0 },
		{ "SetVillagerCollectResourceWork", 1 },
		{ "SetVillagerCollectTributeWork", 2 },
		{ "SetVillagerKeepGraveWork", 3 },
		{ "SetVillagerIdleWork", 4 },
		{ "StopVillagerWork", 5 },
		{ "StopVillagerCollectResourceWork", 6 },
		{ "GetCollectResourceWorkDataList", 7 },
		{ "ExpelVillager", 8 },
		{ "GetVillagerStatusDisplayDataList", 9 },
		{ "GetAllVillagersStatus", 10 },
		{ "GetAllVillagersAvailableForWork", 11 },
		{ "CalcResourceChangeByVillageWork", 12 },
		{ "CalcResourceChangeByBuildingEarn", 13 },
		{ "CalcResourceChangeByBuildingMaintain", 14 },
		{ "GetAllWarehouseItems", 15 },
		{ "GetWarehouseItemsBySubType", 16 },
		{ "SwitchEquipmentPlan", 17 },
		{ "GmCmd_AddResource", 18 },
		{ "GmCmd_AddLegacyPoint", 19 },
		{ "GmCmd_AddExp", 20 },
		{ "GmCmd_SetTaiwuCombatSkillActiveState", 21 },
		{ "JoinGroup", 22 },
		{ "LeaveGroup", 23 },
		{ "CompletePassingLegacy", 24 },
		{ "SelectLegacy", 25 },
		{ "FindSuccessorCandidates", 26 },
		{ "ConfirmChosenSuccessor", 27 },
		{ "SetReferenceBook", 28 },
		{ "SetReadingBook", 29 },
		{ "GetCurReadingStrategies", 30 },
		{ "SetReadingStrategy", 31 },
		{ "ClearPageStrategy", 32 },
		{ "GetRandomSelectableStrategies", 33 },
		{ "CheckNotInInventoryBooks", 34 },
		{ "GetTotalReadingProgress", 35 },
		{ "GetCurrReadingEventBonusRate", 36 },
		{ "GetCurrReadingEfficiency", 37 },
		{ "WarehouseAdd", 38 },
		{ "WarehouseRemove", 39 },
		{ "PutItemIntoWarehouse", 40 },
		{ "TakeOutItemFromWarehouse", 41 },
		{ "CanTransferItemToWarehouse", 42 },
		{ "CalcBuildingResourceOutput", 43 },
		{ "TransferAllItems", 44 },
		{ "SelectCombatSkillAttainmentPanelPlan", 45 },
		{ "GetGenericGridAllocation", 46 },
		{ "AllocateGenericGrid", 47 },
		{ "DeallocateGenericGrid", 48 },
		{ "UpdateCombatSkillPlan", 49 },
		{ "GetBreakPlateData", 50 },
		{ "EnterSkillBreakPlate", 51 },
		{ "ClearBreakPlate", 52 },
		{ "SelectSkillBreakGrid", 53 },
		{ "EscapeToAdjacentBlock", 54 },
		{ "GetCanOperateItemDisplayDataInVillage", 55 },
		{ "PutItemListIntoWarehouse", 56 },
		{ "WarehouseAddList", 57 },
		{ "TakeOutItemListFromWarehouse", 58 },
		{ "WarehouseRemoveList", 59 },
		{ "GetTaiwuAllItems", 60 },
		{ "TransferItem", 61 },
		{ "GetAllTroughItems", 62 },
		{ "TransferItemList", 63 },
		{ "GetAllTreasuryItems", 64 },
		{ "GetTotalReadingProgressList", 65 },
		{ "CalcResourceChangeByAutoExpand", 66 },
		{ "CalcAutoExpandNotSatisfyIndex", 67 },
		{ "GetRefBonusSpeed", 68 },
		{ "FindTaiwuBuilding", 69 },
		{ "ChoosyGetMaterial", 70 },
		{ "GetCannotOperateItemDisplayDataInInventory", 71 },
		{ "GetInventoryOverloadedGroupCharNames", 72 },
		{ "SetAutoAllocateNeiliToMax", 73 },
		{ "MasteredSkillWillChangePlan", 74 },
		{ "GetVillagersForWork", 75 },
		{ "GetSeverelyInjuredGroupCharNames", 76 },
		{ "GetItemCount", 77 },
		{ "GetTaiwuVillagerMapBlockData", 78 },
		{ "StopVillagerWorkOptional", 79 },
		{ "GetLegacyMaxPointByType", 80 },
		{ "GetCurrReadingBanByWug", 81 },
		{ "GmCmd_MarkAllCarrierFullTamePoint", 82 },
		{ "GetSelectMapBlockHasMerchantId", 83 },
		{ "ActiveReadOnce", 84 },
		{ "ActiveNeigongLoopingOnce", 85 },
		{ "AppendCombatSkillPlan", 86 },
		{ "CopyCombatSkillPlan", 87 },
		{ "ClearCombatSkillPlan", 88 },
		{ "DeleteCombatSkillPlan", 89 },
		{ "GetLegacyMaxPointAndTimesListByType", 90 },
		{ "SetQiArtStrategy", 91 },
		{ "GetCurrentBookAvailableReadingStrategies", 92 },
		{ "GetLoopingNeigongQiArtStrategies", 93 },
		{ "SetReferenceCombatSkillAt", 94 },
		{ "GetLoopingNeigongQiArtStrategyDisplayDatas", 95 },
		{ "GetLoopingNeigongAvailableQiArtStrategies", 96 },
		{ "ClearCurrentLoopingNeigongEvent", 97 },
		{ "SetTaiwuLoopingNeigong", 98 },
		{ "DeleteTaiwuFeature", 99 },
		{ "GmCmd_TaiwuActiveLoopingApply", 100 },
		{ "GetIsFollowingNpcListMax", 101 },
		{ "GetFollowingNpcListMaxCount", 102 },
		{ "GmCmd_FollowRandomNpc", 103 },
		{ "TaiwuFollowNpc", 104 },
		{ "TaiwuUnfollowNpc", 105 },
		{ "SetFollowingNpcNickName", 106 },
		{ "GetFollowingNpcNickName", 107 },
		{ "GetFollowingNpcNickNameId", 108 },
		{ "GetVillagerRoleCharacterDisplayDataList", 109 },
		{ "GetVillagerRoleCharacterDisplayData", 110 },
		{ "BatchSetVillagerRole", 111 },
		{ "DispatchVillagerArrangement", 112 },
		{ "RecallVillager", 113 },
		{ "AssignTargetItem", 114 },
		{ "GetVillagerRoleDisplayData", 115 },
		{ "AssignArrangementIncreaseOrDecrease", 116 },
		{ "GetAllVillagerRoleDisplayData", 117 },
		{ "GetAllItems", 118 },
		{ "TransferResource", 119 },
		{ "GetVillagerRoleTipsDisplayData", 120 },
		{ "SetVillagerRole", 121 },
		{ "SetVillagerMigrateWork", 122 },
		{ "GetVillagerRoleNpcNickName", 123 },
		{ "SetVillagerRoleNickName", 124 },
		{ "GetVillagersAvailableForVillagerRole", 125 },
		{ "GetAllResources", 126 },
		{ "GetAllSwordTombDisplayDataForDispatch", 127 },
		{ "GetVillagerRoleCharacterSlimDisplayData", 128 },
		{ "GetAllWarehouseItemsExcludeValueZero", 129 },
		{ "GmCmd_FillLegacyPoint", 130 },
		{ "GetVillagerRoleExecuteFixedActionFailReasons", 131 },
		{ "SetMerchantType", 132 },
		{ "GetMerchantType", 133 },
		{ "GetProfessionTipDisplayData", 134 },
		{ "GetExpByRereading", 135 },
		{ "EnterMerchant", 136 },
		{ "GetReadingResult", 137 },
		{ "GetVillagerTreasuryNeed", 138 },
		{ "GetTreasuryNeededItemList", 139 },
		{ "GetDyingGroupCharNames", 140 },
		{ "GetBreakBaseCostExp", 141 },
		{ "SetBonusRelation", 142 },
		{ "SetBonusExp", 143 },
		{ "SetBonusItem", 144 },
		{ "SetActivePage", 145 },
		{ "GetAvailableRelationBonuses", 146 },
		{ "GetVillagerCollectStorageType", 147 },
		{ "SetVillagerCollectStorageType", 148 },
		{ "ClearBonus", 149 },
		{ "TaiwuAddFeature", 150 },
		{ "GetRandomLegaciesInGroup", 151 },
		{ "GetGroupBabyCount", 152 },
		{ "GetStrategyRoomLevel", 153 },
		{ "SetBonusFriend", 154 },
		{ "GmCmd_ShowUnlockedDebateStrategy", 155 },
		{ "GmCmd_ChangeGamePoint", 156 },
		{ "GmCmd_SetForceAiBribery", 157 },
		{ "DebateGameOver", 158 },
		{ "DebateGameSetTaiwuAi", 159 },
		{ "DebateGameMakeMove", 160 },
		{ "DebateGameNextState", 161 },
		{ "DebateGamePickSpectators", 162 },
		{ "DebateGameInitialize", 163 },
		{ "DebateGameCastStrategy", 164 },
		{ "GmCmd_GetDebateStrategyCard", 165 },
		{ "GmCmd_ChangeStrategyPoint", 166 },
		{ "GmCmd_ChangeBases", 167 },
		{ "GetNewUnlockedDebateStrategyList", 168 },
		{ "GmCmd_ChangePressure", 169 },
		{ "DebateGameSetTaiwuSelectedCardTypes", 170 },
		{ "DebateGameGetTaiwuSelectedCardTypes", 171 },
		{ "GmCmd_AddAiOwnedCard", 172 },
		{ "GmCmd_EmptyAiOwnedCard", 173 },
		{ "DebateGameTryForceWin", 174 },
		{ "SetVillagerDevelopWork", 175 },
		{ "GetVillagerRoleCharacterDisplayDataOnPanel", 176 },
		{ "GetIsTaiwuFirstByLuck", 177 },
		{ "GmCmd_AddNodeEffect", 178 },
		{ "GetVillagerFarmerMigrateResourceSuccessRateBonus", 179 },
		{ "GetVillagerRoleHeadTotalAuthorityCost", 180 },
		{ "GetAllChildAvailableForWork", 181 },
		{ "GetTaiwuVillageSpaceLimitInfo", 182 },
		{ "GetGroupNeiliConflictingCharDataList", 183 },
		{ "DebateGameResetCards", 184 },
		{ "DebateGameRemoveCards", 185 },
		{ "SetLastCricketPlan", 186 },
		{ "RequestValidCricketPlan", 187 },
		{ "SetCricketPlan", 188 },
		{ "ClearCricketPlan", 189 },
		{ "GetLastCricketPlan", 190 },
		{ "GetAiBriberyDataOnPrepareLifeSkillCombat", 191 },
		{ "SwapSkillBreakGrid", 192 },
		{ "GetAllItemsForSelect", 193 },
		{ "GetAllCharacterPropertyBonusData", 194 },
		{ "RequestCurrEquipmentPlanId", 195 },
		{ "RemoveManualChangeEquipGroupChar", 196 },
		{ "AddManualChangeEquipGroupChar", 197 },
		{ "RequestManualChangeEquipGroupCharIds", 198 },
		{ "RequestHideSkeletonEquipSlots", 199 },
		{ "GetSkillBreakBonusSelectDisplayData", 200 },
		{ "GetEnterSkillBreakPlateInfo", 201 },
		{ "RemoveFavoriteCombatSkill", 202 },
		{ "AddFavoriteCombatSkill", 203 },
		{ "RequestReadingAndLooping", 204 },
		{ "RequestTaiwuResourceDisplayData", 205 },
		{ "SetExpandPracticePanel", 206 },
		{ "GetExpandPracticePanel", 207 },
		{ "GetVillagersAvailableForWorkDisplayData", 208 },
		{ "SetConsummateLevelOnNeiliPage", 209 },
		{ "GetVillagersAvailableForTreeClearEnemy", 210 },
		{ "SetCombatResultSelectAllItem", 211 },
		{ "GetReadingResultPreview", 212 },
		{ "AddStockItem", 213 },
		{ "GetTaiwuVillageStoragesRecordCollection", 214 },
		{ "GetExchangeDisplayData", 215 },
		{ "ConfirmExchange", 216 },
		{ "GetTreasuryNeededItemDataList", 217 },
		{ "GetShopDisplayData", 218 },
		{ "ConfirmShopExchange", 219 },
		{ "GetLoopingViewDisplayData", 220 },
		{ "RequestLegacyDisplayData", 221 },
		{ "SelectLegacies", 222 },
		{ "RequestFollowingCharacterList", 223 },
		{ "SetLuohanBreak", 224 },
		{ "GetAllDishes", 225 },
		{ "GetLoopReadCountDisplayData", 226 },
		{ "ExpelVillagers", 227 },
		{ "GetVillagerRoleCharacterDisplayDataRolePage", 228 },
		{ "GetChangeWeaponTrickDisplayData", 229 },
		{ "SetItemLocked", 230 },
		{ "SetItemListLocked", 231 },
		{ "GetReversedTaiwuVillageStoragesRecordCollection", 232 },
		{ "RequestLifeSkillStrategyPlans", 233 },
		{ "SetLifeSkillStrategyPlansElement", 234 },
		{ "GetLifeSkillCombatBeginDisplayData", 235 },
		{ "DebateGameTryForceWinInCombatBegin", 236 },
		{ "LearnProfessionSkill", 237 },
		{ "GetCricketCombatTaiwuDisplayData", 238 },
		{ "RequestTravelerSkillsDisplayData", 239 },
		{ "SetCricketBettingAutoBet", 240 },
		{ "GetTotalVillagerMaintenance", 241 },
		{ "GetUnlockScrollListForDisplay", 242 },
		{ "UpdateUnlockScrollList", 243 },
		{ "GetSkillBreakPlateSkillInfo", 244 },
		{ "SetFarmerMigrateWork", 245 },
		{ "SetFarmerCollectResourceWork", 246 },
		{ "GetTaiwuVillagerRoleDisplayData", 247 },
		{ "GetTaiwuItemMultiplyOperationDisplayData", 248 },
		{ "GmCmd_GenerateCricketPolymorph", 249 },
		{ "PutMaterialToCricketRoom", 250 },
		{ "TakeMaterialFromCricketRoom", 251 },
		{ "ChangeLegacyPointWhilePassingLegacy", 252 },
		{ "GetVillagersForWorkDisplayData", 253 },
		{ "RequestFollowingCharacter", 254 },
		{ "FeedingCricket", 255 },
		{ "CricketRoomPolymorphReturn", 256 },
		{ "CricketRoomWishingCricket", 257 },
		{ "GmCmd_GenerateCricketWishing", 258 },
		{ "CricketWishingCricketReturnLuckPoint", 259 },
		{ "GetTaiwuLifeSummaryDisplayData", 260 },
		{ "GetTotalTaiwuLifeSummaryInfo", 261 },
		{ "SetMainOperationOrder", 262 },
		{ "RequestMainOperationOrder", 263 },
		{ "RemoveHideSkeletonEquipSlot", 264 },
		{ "AddHideSkeletonEquipSlot", 265 },
		{ "RequestTaiwuEquipWithoutHideForSkeleton", 266 },
		{ "RequestTaiwuNeiliProportionDisplayData", 267 },
		{ "SetActiveShortCut", 268 },
		{ "RequestActiveShortCut", 269 },
		{ "RecordLifeSummary", 270 },
		{ "TaiwuInventoryHasItem", 271 },
		{ "GetWineTasterBonusPercentage", 272 },
		{ "HasSectItem", 273 },
		{ "ChangeCombatSkillBreakPlate", 274 },
		{ "GetCombatSkillBreakPreset", 275 },
		{ "AddCricketPlan", 276 },
		{ "CloneCricketPlan", 277 },
		{ "DeleteCricketPlan", 278 },
		{ "GetCricketPlanCount", 279 },
		{ "GetVillagerListClassArray", 280 },
		{ "GetVillagerClassesDict", 281 },
		{ "GetTreasuryItemNeededCharDict", 282 },
		{ "TransferItemInventory", 283 },
		{ "SetSelectedLifeSkillStrategyPlanIndex", 284 },
		{ "GetRepairPlan", 285 },
		{ "SetCricketPolymorphPlan", 286 },
		{ "GetCricketPlanData", 287 },
		{ "GetPreviewReadingEfficiency", 288 },
		{ "RequestShortCutOperationLevelData", 289 },
		{ "GetFarmerMigrateWorkStatus", 290 },
		{ "SetFarmerMigrateWorkStatus", 291 }
	};

	public static readonly string[] MethodId2MethodName = new string[292]
	{
		"GetAllVisitedSettlements", "SetVillagerCollectResourceWork", "SetVillagerCollectTributeWork", "SetVillagerKeepGraveWork", "SetVillagerIdleWork", "StopVillagerWork", "StopVillagerCollectResourceWork", "GetCollectResourceWorkDataList", "ExpelVillager", "GetVillagerStatusDisplayDataList",
		"GetAllVillagersStatus", "GetAllVillagersAvailableForWork", "CalcResourceChangeByVillageWork", "CalcResourceChangeByBuildingEarn", "CalcResourceChangeByBuildingMaintain", "GetAllWarehouseItems", "GetWarehouseItemsBySubType", "SwitchEquipmentPlan", "GmCmd_AddResource", "GmCmd_AddLegacyPoint",
		"GmCmd_AddExp", "GmCmd_SetTaiwuCombatSkillActiveState", "JoinGroup", "LeaveGroup", "CompletePassingLegacy", "SelectLegacy", "FindSuccessorCandidates", "ConfirmChosenSuccessor", "SetReferenceBook", "SetReadingBook",
		"GetCurReadingStrategies", "SetReadingStrategy", "ClearPageStrategy", "GetRandomSelectableStrategies", "CheckNotInInventoryBooks", "GetTotalReadingProgress", "GetCurrReadingEventBonusRate", "GetCurrReadingEfficiency", "WarehouseAdd", "WarehouseRemove",
		"PutItemIntoWarehouse", "TakeOutItemFromWarehouse", "CanTransferItemToWarehouse", "CalcBuildingResourceOutput", "TransferAllItems", "SelectCombatSkillAttainmentPanelPlan", "GetGenericGridAllocation", "AllocateGenericGrid", "DeallocateGenericGrid", "UpdateCombatSkillPlan",
		"GetBreakPlateData", "EnterSkillBreakPlate", "ClearBreakPlate", "SelectSkillBreakGrid", "EscapeToAdjacentBlock", "GetCanOperateItemDisplayDataInVillage", "PutItemListIntoWarehouse", "WarehouseAddList", "TakeOutItemListFromWarehouse", "WarehouseRemoveList",
		"GetTaiwuAllItems", "TransferItem", "GetAllTroughItems", "TransferItemList", "GetAllTreasuryItems", "GetTotalReadingProgressList", "CalcResourceChangeByAutoExpand", "CalcAutoExpandNotSatisfyIndex", "GetRefBonusSpeed", "FindTaiwuBuilding",
		"ChoosyGetMaterial", "GetCannotOperateItemDisplayDataInInventory", "GetInventoryOverloadedGroupCharNames", "SetAutoAllocateNeiliToMax", "MasteredSkillWillChangePlan", "GetVillagersForWork", "GetSeverelyInjuredGroupCharNames", "GetItemCount", "GetTaiwuVillagerMapBlockData", "StopVillagerWorkOptional",
		"GetLegacyMaxPointByType", "GetCurrReadingBanByWug", "GmCmd_MarkAllCarrierFullTamePoint", "GetSelectMapBlockHasMerchantId", "ActiveReadOnce", "ActiveNeigongLoopingOnce", "AppendCombatSkillPlan", "CopyCombatSkillPlan", "ClearCombatSkillPlan", "DeleteCombatSkillPlan",
		"GetLegacyMaxPointAndTimesListByType", "SetQiArtStrategy", "GetCurrentBookAvailableReadingStrategies", "GetLoopingNeigongQiArtStrategies", "SetReferenceCombatSkillAt", "GetLoopingNeigongQiArtStrategyDisplayDatas", "GetLoopingNeigongAvailableQiArtStrategies", "ClearCurrentLoopingNeigongEvent", "SetTaiwuLoopingNeigong", "DeleteTaiwuFeature",
		"GmCmd_TaiwuActiveLoopingApply", "GetIsFollowingNpcListMax", "GetFollowingNpcListMaxCount", "GmCmd_FollowRandomNpc", "TaiwuFollowNpc", "TaiwuUnfollowNpc", "SetFollowingNpcNickName", "GetFollowingNpcNickName", "GetFollowingNpcNickNameId", "GetVillagerRoleCharacterDisplayDataList",
		"GetVillagerRoleCharacterDisplayData", "BatchSetVillagerRole", "DispatchVillagerArrangement", "RecallVillager", "AssignTargetItem", "GetVillagerRoleDisplayData", "AssignArrangementIncreaseOrDecrease", "GetAllVillagerRoleDisplayData", "GetAllItems", "TransferResource",
		"GetVillagerRoleTipsDisplayData", "SetVillagerRole", "SetVillagerMigrateWork", "GetVillagerRoleNpcNickName", "SetVillagerRoleNickName", "GetVillagersAvailableForVillagerRole", "GetAllResources", "GetAllSwordTombDisplayDataForDispatch", "GetVillagerRoleCharacterSlimDisplayData", "GetAllWarehouseItemsExcludeValueZero",
		"GmCmd_FillLegacyPoint", "GetVillagerRoleExecuteFixedActionFailReasons", "SetMerchantType", "GetMerchantType", "GetProfessionTipDisplayData", "GetExpByRereading", "EnterMerchant", "GetReadingResult", "GetVillagerTreasuryNeed", "GetTreasuryNeededItemList",
		"GetDyingGroupCharNames", "GetBreakBaseCostExp", "SetBonusRelation", "SetBonusExp", "SetBonusItem", "SetActivePage", "GetAvailableRelationBonuses", "GetVillagerCollectStorageType", "SetVillagerCollectStorageType", "ClearBonus",
		"TaiwuAddFeature", "GetRandomLegaciesInGroup", "GetGroupBabyCount", "GetStrategyRoomLevel", "SetBonusFriend", "GmCmd_ShowUnlockedDebateStrategy", "GmCmd_ChangeGamePoint", "GmCmd_SetForceAiBribery", "DebateGameOver", "DebateGameSetTaiwuAi",
		"DebateGameMakeMove", "DebateGameNextState", "DebateGamePickSpectators", "DebateGameInitialize", "DebateGameCastStrategy", "GmCmd_GetDebateStrategyCard", "GmCmd_ChangeStrategyPoint", "GmCmd_ChangeBases", "GetNewUnlockedDebateStrategyList", "GmCmd_ChangePressure",
		"DebateGameSetTaiwuSelectedCardTypes", "DebateGameGetTaiwuSelectedCardTypes", "GmCmd_AddAiOwnedCard", "GmCmd_EmptyAiOwnedCard", "DebateGameTryForceWin", "SetVillagerDevelopWork", "GetVillagerRoleCharacterDisplayDataOnPanel", "GetIsTaiwuFirstByLuck", "GmCmd_AddNodeEffect", "GetVillagerFarmerMigrateResourceSuccessRateBonus",
		"GetVillagerRoleHeadTotalAuthorityCost", "GetAllChildAvailableForWork", "GetTaiwuVillageSpaceLimitInfo", "GetGroupNeiliConflictingCharDataList", "DebateGameResetCards", "DebateGameRemoveCards", "SetLastCricketPlan", "RequestValidCricketPlan", "SetCricketPlan", "ClearCricketPlan",
		"GetLastCricketPlan", "GetAiBriberyDataOnPrepareLifeSkillCombat", "SwapSkillBreakGrid", "GetAllItemsForSelect", "GetAllCharacterPropertyBonusData", "RequestCurrEquipmentPlanId", "RemoveManualChangeEquipGroupChar", "AddManualChangeEquipGroupChar", "RequestManualChangeEquipGroupCharIds", "RequestHideSkeletonEquipSlots",
		"GetSkillBreakBonusSelectDisplayData", "GetEnterSkillBreakPlateInfo", "RemoveFavoriteCombatSkill", "AddFavoriteCombatSkill", "RequestReadingAndLooping", "RequestTaiwuResourceDisplayData", "SetExpandPracticePanel", "GetExpandPracticePanel", "GetVillagersAvailableForWorkDisplayData", "SetConsummateLevelOnNeiliPage",
		"GetVillagersAvailableForTreeClearEnemy", "SetCombatResultSelectAllItem", "GetReadingResultPreview", "AddStockItem", "GetTaiwuVillageStoragesRecordCollection", "GetExchangeDisplayData", "ConfirmExchange", "GetTreasuryNeededItemDataList", "GetShopDisplayData", "ConfirmShopExchange",
		"GetLoopingViewDisplayData", "RequestLegacyDisplayData", "SelectLegacies", "RequestFollowingCharacterList", "SetLuohanBreak", "GetAllDishes", "GetLoopReadCountDisplayData", "ExpelVillagers", "GetVillagerRoleCharacterDisplayDataRolePage", "GetChangeWeaponTrickDisplayData",
		"SetItemLocked", "SetItemListLocked", "GetReversedTaiwuVillageStoragesRecordCollection", "RequestLifeSkillStrategyPlans", "SetLifeSkillStrategyPlansElement", "GetLifeSkillCombatBeginDisplayData", "DebateGameTryForceWinInCombatBegin", "LearnProfessionSkill", "GetCricketCombatTaiwuDisplayData", "RequestTravelerSkillsDisplayData",
		"SetCricketBettingAutoBet", "GetTotalVillagerMaintenance", "GetUnlockScrollListForDisplay", "UpdateUnlockScrollList", "GetSkillBreakPlateSkillInfo", "SetFarmerMigrateWork", "SetFarmerCollectResourceWork", "GetTaiwuVillagerRoleDisplayData", "GetTaiwuItemMultiplyOperationDisplayData", "GmCmd_GenerateCricketPolymorph",
		"PutMaterialToCricketRoom", "TakeMaterialFromCricketRoom", "ChangeLegacyPointWhilePassingLegacy", "GetVillagersForWorkDisplayData", "RequestFollowingCharacter", "FeedingCricket", "CricketRoomPolymorphReturn", "CricketRoomWishingCricket", "GmCmd_GenerateCricketWishing", "CricketWishingCricketReturnLuckPoint",
		"GetTaiwuLifeSummaryDisplayData", "GetTotalTaiwuLifeSummaryInfo", "SetMainOperationOrder", "RequestMainOperationOrder", "RemoveHideSkeletonEquipSlot", "AddHideSkeletonEquipSlot", "RequestTaiwuEquipWithoutHideForSkeleton", "RequestTaiwuNeiliProportionDisplayData", "SetActiveShortCut", "RequestActiveShortCut",
		"RecordLifeSummary", "TaiwuInventoryHasItem", "GetWineTasterBonusPercentage", "HasSectItem", "ChangeCombatSkillBreakPlate", "GetCombatSkillBreakPreset", "AddCricketPlan", "CloneCricketPlan", "DeleteCricketPlan", "GetCricketPlanCount",
		"GetVillagerListClassArray", "GetVillagerClassesDict", "GetTreasuryItemNeededCharDict", "TransferItemInventory", "SetSelectedLifeSkillStrategyPlanIndex", "GetRepairPlan", "SetCricketPolymorphPlan", "GetCricketPlanData", "GetPreviewReadingEfficiency", "RequestShortCutOperationLevelData",
		"GetFarmerMigrateWorkStatus", "SetFarmerMigrateWorkStatus"
	};
}

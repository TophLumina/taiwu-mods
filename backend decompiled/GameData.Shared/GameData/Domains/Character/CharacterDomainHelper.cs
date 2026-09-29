using System.Collections.Generic;

namespace GameData.Domains.Character;

public static class CharacterDomainHelper
{
	public static class DataIds
	{
		public const ushort Objects = 0;

		public const ushort NextObjectId = 1;

		public const ushort DeadCharacters = 2;

		public const ushort DeadCharDeletionStates = 3;

		public const ushort RecentDeadCharacters = 4;

		public const ushort WaitingReincarnationChars = 5;

		public const ushort Graves = 6;

		public const ushort PregnantStates = 7;

		public const ushort PregnancyLockEndDates = 8;

		public const ushort UnguardedChars = 9;

		public const ushort KidnappedChars = 10;

		public const ushort Relations = 11;

		public const ushort ActualBloodParents = 12;

		public const ushort CharacterGroups = 13;

		public const ushort JoinGroupDates = 14;

		public const ushort SoldLibrarySkillBooks = 15;

		public const ushort AvatarElementGrowthProgress = 16;

		public const ushort TargetedForAssassination = 17;

		public const ushort PrioritizedActions = 18;

		public const ushort CrossAreaMoveInfos = 19;

		public const ushort OngoingVengeances = 20;

		public const ushort PregeneratedCityTownGuards = 21;

		public const ushort PregeneratedRandomEnemies = 22;

		public const ushort ForceRebelLocation = 23;

		public const ushort ForceKindLocation = 24;

		public const ushort AvoidDeathCharId = 25;

		public const ushort SubscriberOrders = 26;

		public const ushort OutterWorldCharacter = 27;

		public const ushort CharacterProfessions = 28;

		public const ushort CharacterPrioritizedActionCooldowns = 29;

		public const ushort FollowMovementCharacters = 30;

		public const ushort CharacterAiActionCooldowns = 31;

		public const ushort CharacterAiActionRestrictions = 32;

		public const ushort CharacterSpecialGroup = 33;

		public const ushort CharacterAiActionSuccessRateAdjusts = 34;

		public const ushort PregeneratedFixedEnemies = 35;

		public const ushort MixedPoisonEffectTriggerDates = 36;

		public const ushort CharacterAvatarSnapshot = 37;

		public const ushort CharacterDarkAshCounterData = 38;

		public const ushort FuyuFaith = 39;

		public const ushort CharacterTemporaryFeatures = 40;

		public const ushort CharacterExtraTitles = 41;

		public const ushort RemovedSpecialRelations = 42;

		public const ushort Alertness = 43;

		public const ushort TemporaryIntelligentCharIds = 44;

		public const ushort UsedCombatResources = 45;

		public const ushort XiangshuInfectedDemonsPenetrationsBonus = 46;

		public const ushort XiangshuInfectedDemonsPenetrationResistsBonus = 47;

		public const ushort TemporaryEnemyCharIds = 48;

		public const ushort CharacterCreationMetas = 49;

		public const ushort ActionPlanningDataDict = 50;

		public const ushort TwelveImmortalsData = 51;

		public const ushort TwelveImmortalsCache = 52;

		public const ushort PlanningActionSettings = 53;

		public const ushort PlanningGoalSettings = 54;

		public const ushort AdventureCallCharacterCooldown = 55;
	}

	public static class MethodIds
	{
		public const ushort CreateProtagonist = 0;

		public const ushort GetRelatedCharactersForRelations = 1;

		public const ushort TryCreateRelation = 2;

		public const ushort GetGenealogy = 3;

		public const ushort GenerateRandomHanName = 4;

		public const ushort GenerateRandomZangName = 5;

		public const ushort GenerateRandomChildName = 6;

		public const ushort GetNameRelatedDataList = 7;

		public const ushort GetNameRelatedData = 8;

		public const ushort GetNameAndLifeRelatedDataList = 9;

		public const ushort GetNameAndLifeRelatedData = 10;

		public const ushort GetFavorability = 11;

		public const ushort GmCmd_GetAllGroupMembers = 12;

		public const ushort GmCmd_GenerateRandomRefinedItemToCharacter = 13;

		public const ushort GmCmd_ChangeInjury = 14;

		public const ushort GmCmd_ChangePoisonByType = 15;

		public const ushort GmCmd_ForgetCombatSkill = 16;

		public const ushort GmCmd_RevokeCombatSkill = 17;

		public const ushort GmCmd_SetLearnedLifeSkills = 18;

		public const ushort GmCmd_GetCricket = 19;

		public const ushort GmCmd_AddRelation = 20;

		public const ushort GetGroupSet = 21;

		public const ushort TransferResourcesWithDebt = 22;

		public const ushort TransferInventoryItemWithDebt = 23;

		public const ushort ChangeEquipment = 24;

		public const ushort CreateInventoryItem = 25;

		public const ushort GetInventoryItems = 26;

		public const ushort GetAllInventoryItems = 27;

		public const ushort GetInventoryItemAmount = 28;

		public const ushort GetAllEquipmentItems = 29;

		public const ushort GetInventoryItemDisplayData = 30;

		public const ushort InventoryContainsItem = 31;

		public const ushort AddEatingItem = 32;

		public const ushort GetCurrMaxEatingSlotsCount = 33;

		public const ushort MerchantHasNewGoods = 34;

		public const ushort AddKidnappedCharacter = 35;

		public const ushort TransferKidnappedCharacters = 36;

		public const ushort ChangeKidnappedCharacterRope = 37;

		public const ushort GetKidnapMaxSlotCount = 38;

		public const ushort TransferKidnappedCharacter = 39;

		public const ushort RemoveKidnappedCharacter = 40;

		public const ushort GetDisplayingAge = 41;

		public const ushort GetMainAttributesRecoveries = 42;

		public const ushort GetInscriptionStatus = 43;

		public const ushort GetCharacterBirthDate = 44;

		public const ushort GetMaxWorthCanBeLentToTaiwu = 45;

		public const ushort CheckFavorabilityBeforeTransferring = 46;

		public const ushort GetClothingDisplayId = 47;

		public const ushort GetCharacterDisplayDataList = 48;

		public const ushort GetCharacterLifeSkillAttainmentList = 49;

		public const ushort GetTaiwuRelatedGraveDisplayDataList = 50;

		public const ushort GetGraveDisplayDataList = 51;

		public const ushort GetCharacterDisplayDataListForRelations = 52;

		public const ushort GetSomeoneKidnapCharacters = 53;

		public const ushort GetCharacterAttributeDisplayData = 54;

		public const ushort GetCharacterSamsaraData = 55;

		public const ushort GetEquipmentCompareData = 56;

		public const ushort GetGroupCharDisplayDataList = 57;

		public const ushort GetDefeatMarkCountList = 58;

		public const ushort GetFeatureMedalValue = 59;

		public const ushort GetFeatureMedalValueList = 60;

		public const ushort GetFixedCharacterIdByTemplateId = 61;

		public const ushort GmCmd_SimulateNpcCombat = 62;

		public const ushort GmCmd_GetAllCharacterName = 63;

		public const ushort GmCmd_ChangeFavorability = 64;

		public const ushort GmCmd_ClearFameActionRecords = 65;

		public const ushort GmCmd_RecordFameAction = 66;

		public const ushort GmCmd_CreateRandomIntelligentCharacters = 67;

		public const ushort GmCmd_ForceChangeOrganization = 68;

		public const ushort GmCmd_ForceChangeGrade = 69;

		public const ushort GmCmd_Die = 70;

		public const ushort GmCmd_GetAliveCharByPreexistenceChar = 71;

		public const ushort GmCmd_LogCharacterSamsaraInfo = 72;

		public const ushort GmCmd_EditExtraNeiliAllocation = 73;

		public const ushort GmCmd_MakeCharacterKidnapped = 74;

		public const ushort GmCmd_MoveIntelligentCharacter = 75;

		public const ushort GmCmd_RandomizeRelationShipsInSettlement = 76;

		public const ushort GmCmd_MakeCharacterHaveSex = 77;

		public const ushort GmCmd_GetCharacterPregnancyLockEndDates = 78;

		public const ushort GmCmd_GetCharacterActualBloodParents = 79;

		public const ushort CharacterShaveAvatar = 80;

		public const ushort AllocateNeili = 81;

		public const ushort DeallocateNeili = 82;

		public const ushort GetChangeOfQiDisorder = 83;

		public const ushort GetUsableCombatResources = 84;

		public const ushort GetCombatSkillSlotCounts = 85;

		public const ushort SetCombatSkillSlot = 86;

		public const ushort GetCombatSkillAttainment = 87;

		public const ushort GetAllCombatSkillAttainment = 88;

		public const ushort GetLifeSkillAttainment = 89;

		public const ushort GetAllLifeSkillAttainment = 90;

		public const ushort LearnCombatSkill = 91;

		public const ushort LearnLifeSkill = 92;

		public const ushort TryGetDeadCharacter = 93;

		public const ushort GetTitles = 94;

		public const ushort GetHighestGradeCombatSkillById = 95;

		public const ushort GetLeftMaxHealth = 96;

		public const ushort GetHealthRecovery = 97;

		public const ushort GetAvatarRelatedDataList = 98;

		public const ushort GetAvatarData = 99;

		public const ushort TransferInventoryItemListWithDebt = 100;

		public const ushort GetFameType = 101;

		public const ushort GetAvatarRelatedData = 102;

		public const ushort GetCharacterListWisdomCount = 103;

		public const ushort SortCharacterListByMaxCombatSkill = 104;

		public const ushort GetCharacterMaxCombatSkillAttainment = 105;

		public const ushort GetItemPowerInfo = 106;

		public const ushort CalcMaxFavorabilityToTaiwuById = 107;

		public const ushort CheckDebtChange = 108;

		public const ushort GetCharacterWisdomCountById = 109;

		public const ushort TransferInventoryItemFromAToB = 110;

		public const ushort GmCmd_SetCurReadingEvent = 111;

		public const ushort GmCmd_AddFeature = 112;

		public const ushort GmCmd_SetFeatures = 113;

		public const ushort GmCmd_RemoveFeature = 114;

		public const ushort GmCmd_RemoveRelation = 115;

		public const ushort IsReclusive = 116;

		public const ushort GetInventoryEquipment = 117;

		public const ushort GetFilteredCharacterCounts = 118;

		public const ushort ClearCharacterSortFilter = 119;

		public const ushort UpdateSortFilterSettings = 120;

		public const ushort InitializeCharacterSortFilter = 121;

		public const ushort FindNameInCurrentSortFilter = 122;

		public const ushort GetCharacterDisplayDataListForUltimateSelect = 123;

		public const ushort GetMaxSortingTypeCharIds = 124;

		public const ushort GmCmd_SetCurrNeili = 125;

		public const ushort GmCmd_AddPoisonedInventoryItem = 126;

		public const ushort GmCmd_AddPoisonedEatingItem = 127;

		public const ushort GmCmd_SetCharBaseNeiliProportionOfFiveElements = 128;

		public const ushort GetRelationBetweenCharacters = 129;

		public const ushort GetInventoryItemsByItemType = 130;

		public const ushort GetCharacterDisplayData = 131;

		public const ushort UnequipAllCombatSkills = 132;

		public const ushort AutoEquipCombatSkills = 133;

		public const ushort GmCmd_AddCharacterExtraTitle = 134;

		public const ushort TryAddAndApplyOneWayRelation = 135;

		public const ushort MoveFuyuHiltLocation = 136;

		public const ushort TryRemoveOneWayRelation = 137;

		public const ushort GetCharacterLoveAndHateItemInfo = 138;

		public const ushort IsTemporaryIntelligentCharacter = 139;

		public const ushort GetMixedPoisonTypeRelatedMarkCountArray = 140;

		public const ushort SimulateEatingEffect = 141;

		public const ushort GetCharacterDisplayDataForTooltip = 142;

		public const ushort GmCmd_SetCurLoopingEvent = 143;

		public const ushort GetHealthType = 144;

		public const ushort GetCharacterLocationDisplayData = 145;

		public const ushort GetCharacterDisplayDataForMapBlock = 146;

		public const ushort GetCharacterWisdomList = 147;

		public const ushort GetOrCreateSwordTombCharacterIdForNormalInformation = 148;

		public const ushort GetAllInventoryItemsExcludeValueZero = 149;

		public const ushort GetAddConsummateLevelRequiredMonth = 150;

		public const ushort GmCmd_ResetHairGrowth = 151;

		public const ushort GetAllItemsByAreaId = 152;

		public const ushort SetCombatSkillPlanLock = 153;

		public const ushort AppendCombatSkillPlan = 154;

		public const ushort DuplicateCurrentCombatSkillPlan = 155;

		public const ushort UpdateCombatSkillPlan = 156;

		public const ushort GetCurrentPlanIdAndPlanCount = 157;

		public const ushort DeleteCombatSkillPlan = 158;

		public const ushort IsInteractedWithTaiwu = 159;

		public const ushort IsNeiliAllocationLocked = 160;

		public const ushort AllocateGenericGrid = 161;

		public const ushort DeallocateGenericGrid = 162;

		public const ushort IsCombatSkillEquipmentLocked = 163;

		public const ushort AutoAllocateNeili = 164;

		public const ushort AutoSetCombatSkillAttainmentPanels = 165;

		public const ushort AutoEquipItems = 166;

		public const ushort SetCombatSkillAttainmentLock = 167;

		public const ushort IsCombatSkillAttainmentLocked = 168;

		public const ushort GetGenericGridAllocation = 169;

		public const ushort SetNeiliAllocationLock = 170;

		public const ushort RemoveEquippedCombatSkill = 171;

		public const ushort AddEquippedCombatSkill = 172;

		public const ushort GetCombatSkillExtraSlotCounts = 173;

		public const ushort GetCharacterAllBodyPartExists = 174;

		public const ushort GmCmd_ChangeCharDisorderOfQi = 175;

		public const ushort GenerateRandomName = 176;

		public const ushort GetCharacterDisplayDataListForRelationsWithRelationType = 177;

		public const ushort GetPhysiologicalAge = 178;

		public const ushort GetPhysiologicalAgeAffector = 179;

		public const ushort GetKidnappedCharacterDisplayData = 180;

		public const ushort IsCarrierDurabilityRunningOut = 181;

		public const ushort GmCmd_ForceChangeOrganizationByName = 182;

		public const ushort GetAvailableFeature = 183;

		public const ushort GetEquipmentCompare = 184;

		public const ushort GetCharacterTableDisplayData = 185;

		public const ushort GetCharacterTableDisplayDataList = 186;

		public const ushort GetCharacterTableDisplayDataListWithNeedItem = 187;

		public const ushort TryGetGraveDisplayDataList = 188;

		public const ushort GetDeadCharacterDisplayDataForTooltip = 189;

		public const ushort GmCmd_DriveWugKing = 190;

		public const ushort GetCharacterCurrentProfession = 191;

		public const ushort GmCmd_SetCharacterCurrProfessionSeniority = 192;

		public const ushort GetCharacterTemporaryFeaturesExpireDate = 193;

		public const ushort GetExtraNeiliAllocationProgress = 194;

		public const ushort GetCharacterMenuInfoDisplayData = 195;

		public const ushort GetAttributeWithDelta = 196;

		public const ushort GetAttributeDelta = 197;

		public const ushort GetCharacterMenuLifeSkillDisplayData = 198;

		public const ushort GetEquipLoad = 199;

		public const ushort GetCharacterDisplayDataForNeiliPage = 200;

		public const ushort GetCharacterInjuryDisplayData = 201;

		public const ushort GetCharacterMenuAttainmentDisplayData = 202;

		public const ushort GetKidnapMenuDisplayData = 203;

		public const ushort GetPersonalities = 204;

		public const ushort GetCharacterDisplayDataForPractice = 205;

		public const ushort GetCharacterUsingMedicineDisplayData = 206;

		public const ushort GetCharacterItemsDisplayData = 207;

		public const ushort GetViewCharacterMenuDisplayData = 208;

		public const ushort GetCharacterDisplayDataForGeneralScrollListBatch = 209;

		public const ushort GetYuanshanSelectDataList = 210;

		public const ushort GetVillagerCharDisplayDataList = 211;

		public const ushort GetCharacterDisplayDataForBaihuaLifeLink = 212;

		public const ushort GetAlertnessValue = 213;

		public const ushort SetAlertnessValue = 214;

		public const ushort GetAlertnessData = 215;

		public const ushort GetTransferItemPreviewDisplayData = 216;

		public const ushort GetAllRanshanReadBooksData = 217;

		public const ushort GetCharacterOverviewEatingDisplayData = 218;

		public const ushort GetEquipmentKeys = 219;

		public const ushort GetCharDisplayDataListAsVillager = 220;

		public const ushort GetPreviewLeftMaxHealth = 221;

		public const ushort GetGraveDisplayDataListForSelection = 222;

		public const ushort GetCharacterDisplayDataForBeggarUltimate = 223;

		public const ushort GetAvatarRelatedDataListIncludeDead = 224;

		public const ushort GetFixedCharacterName = 225;

		public const ushort GetCharacterDisplayDataForGuard = 226;

		public const ushort SimulateProfessionDoctorSkill0 = 227;

		public const ushort GetCharacterDivinePower = 228;

		public const ushort GetCharacterGhostTechnique = 229;

		public const ushort PreviewAllocateNeili = 230;

		public const ushort GetCharacterDisplayDataForTasterUltimate = 231;

		public const ushort GmCmd_ChangeXiangshuInfection = 232;

		public const ushort TransferInventoryItemInventoryWithDebt = 233;

		public const ushort GetActionPlanningDsiplayData = 234;

		public const ushort GetCharacterProfessionList = 235;

		public const ushort GetCarrierMaxProperty = 236;

		public const ushort GmCmd_ClearCharacterActionPlanningData = 237;

		public const ushort GmCmd_ClearAllActionPlanningData = 238;

		public const ushort GmCmd_TaiwuMeetAll = 239;

		public const ushort GetFeatureDynamicFactor = 240;

		public const ushort GetCharacterDisplayDataForMapBlockIncludingDead = 241;

		public const ushort TryGetCharacterDeadData = 242;

		public const ushort GmCmd_CreateInventoryItem = 243;

		public const ushort IsFeatureBeIgnored = 244;
	}

	public const ushort DataCount = 56;

	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "Objects", 0 },
		{ "NextObjectId", 1 },
		{ "DeadCharacters", 2 },
		{ "DeadCharDeletionStates", 3 },
		{ "RecentDeadCharacters", 4 },
		{ "WaitingReincarnationChars", 5 },
		{ "Graves", 6 },
		{ "PregnantStates", 7 },
		{ "PregnancyLockEndDates", 8 },
		{ "UnguardedChars", 9 },
		{ "KidnappedChars", 10 },
		{ "Relations", 11 },
		{ "ActualBloodParents", 12 },
		{ "CharacterGroups", 13 },
		{ "JoinGroupDates", 14 },
		{ "SoldLibrarySkillBooks", 15 },
		{ "AvatarElementGrowthProgress", 16 },
		{ "TargetedForAssassination", 17 },
		{ "PrioritizedActions", 18 },
		{ "CrossAreaMoveInfos", 19 },
		{ "OngoingVengeances", 20 },
		{ "PregeneratedCityTownGuards", 21 },
		{ "PregeneratedRandomEnemies", 22 },
		{ "ForceRebelLocation", 23 },
		{ "ForceKindLocation", 24 },
		{ "AvoidDeathCharId", 25 },
		{ "SubscriberOrders", 26 },
		{ "OutterWorldCharacter", 27 },
		{ "CharacterProfessions", 28 },
		{ "CharacterPrioritizedActionCooldowns", 29 },
		{ "FollowMovementCharacters", 30 },
		{ "CharacterAiActionCooldowns", 31 },
		{ "CharacterAiActionRestrictions", 32 },
		{ "CharacterSpecialGroup", 33 },
		{ "CharacterAiActionSuccessRateAdjusts", 34 },
		{ "PregeneratedFixedEnemies", 35 },
		{ "MixedPoisonEffectTriggerDates", 36 },
		{ "CharacterAvatarSnapshot", 37 },
		{ "CharacterDarkAshCounterData", 38 },
		{ "FuyuFaith", 39 },
		{ "CharacterTemporaryFeatures", 40 },
		{ "CharacterExtraTitles", 41 },
		{ "RemovedSpecialRelations", 42 },
		{ "Alertness", 43 },
		{ "TemporaryIntelligentCharIds", 44 },
		{ "UsedCombatResources", 45 },
		{ "XiangshuInfectedDemonsPenetrationsBonus", 46 },
		{ "XiangshuInfectedDemonsPenetrationResistsBonus", 47 },
		{ "TemporaryEnemyCharIds", 48 },
		{ "CharacterCreationMetas", 49 },
		{ "ActionPlanningDataDict", 50 },
		{ "TwelveImmortalsData", 51 },
		{ "TwelveImmortalsCache", 52 },
		{ "PlanningActionSettings", 53 },
		{ "PlanningGoalSettings", 54 },
		{ "AdventureCallCharacterCooldown", 55 }
	};

	public static readonly string[] DataId2FieldName = new string[56]
	{
		"Objects", "NextObjectId", "DeadCharacters", "DeadCharDeletionStates", "RecentDeadCharacters", "WaitingReincarnationChars", "Graves", "PregnantStates", "PregnancyLockEndDates", "UnguardedChars",
		"KidnappedChars", "Relations", "ActualBloodParents", "CharacterGroups", "JoinGroupDates", "SoldLibrarySkillBooks", "AvatarElementGrowthProgress", "TargetedForAssassination", "PrioritizedActions", "CrossAreaMoveInfos",
		"OngoingVengeances", "PregeneratedCityTownGuards", "PregeneratedRandomEnemies", "ForceRebelLocation", "ForceKindLocation", "AvoidDeathCharId", "SubscriberOrders", "OutterWorldCharacter", "CharacterProfessions", "CharacterPrioritizedActionCooldowns",
		"FollowMovementCharacters", "CharacterAiActionCooldowns", "CharacterAiActionRestrictions", "CharacterSpecialGroup", "CharacterAiActionSuccessRateAdjusts", "PregeneratedFixedEnemies", "MixedPoisonEffectTriggerDates", "CharacterAvatarSnapshot", "CharacterDarkAshCounterData", "FuyuFaith",
		"CharacterTemporaryFeatures", "CharacterExtraTitles", "RemovedSpecialRelations", "Alertness", "TemporaryIntelligentCharIds", "UsedCombatResources", "XiangshuInfectedDemonsPenetrationsBonus", "XiangshuInfectedDemonsPenetrationResistsBonus", "TemporaryEnemyCharIds", "CharacterCreationMetas",
		"ActionPlanningDataDict", "TwelveImmortalsData", "TwelveImmortalsCache", "PlanningActionSettings", "PlanningGoalSettings", "AdventureCallCharacterCooldown"
	};

	public static readonly string[][] DataId2ObjectFieldId2FieldName;

	public static readonly Dictionary<string, ushort> MethodName2MethodId;

	public static readonly string[] MethodId2MethodName;

	static CharacterDomainHelper()
	{
		string[][] array = new string[56][];
		array[0] = CharacterHelper.FieldId2FieldName;
		array[6] = GraveHelper.FieldId2FieldName;
		DataId2ObjectFieldId2FieldName = array;
		MethodName2MethodId = new Dictionary<string, ushort>
		{
			{ "CreateProtagonist", 0 },
			{ "GetRelatedCharactersForRelations", 1 },
			{ "TryCreateRelation", 2 },
			{ "GetGenealogy", 3 },
			{ "GenerateRandomHanName", 4 },
			{ "GenerateRandomZangName", 5 },
			{ "GenerateRandomChildName", 6 },
			{ "GetNameRelatedDataList", 7 },
			{ "GetNameRelatedData", 8 },
			{ "GetNameAndLifeRelatedDataList", 9 },
			{ "GetNameAndLifeRelatedData", 10 },
			{ "GetFavorability", 11 },
			{ "GmCmd_GetAllGroupMembers", 12 },
			{ "GmCmd_GenerateRandomRefinedItemToCharacter", 13 },
			{ "GmCmd_ChangeInjury", 14 },
			{ "GmCmd_ChangePoisonByType", 15 },
			{ "GmCmd_ForgetCombatSkill", 16 },
			{ "GmCmd_RevokeCombatSkill", 17 },
			{ "GmCmd_SetLearnedLifeSkills", 18 },
			{ "GmCmd_GetCricket", 19 },
			{ "GmCmd_AddRelation", 20 },
			{ "GetGroupSet", 21 },
			{ "TransferResourcesWithDebt", 22 },
			{ "TransferInventoryItemWithDebt", 23 },
			{ "ChangeEquipment", 24 },
			{ "CreateInventoryItem", 25 },
			{ "GetInventoryItems", 26 },
			{ "GetAllInventoryItems", 27 },
			{ "GetInventoryItemAmount", 28 },
			{ "GetAllEquipmentItems", 29 },
			{ "GetInventoryItemDisplayData", 30 },
			{ "InventoryContainsItem", 31 },
			{ "AddEatingItem", 32 },
			{ "GetCurrMaxEatingSlotsCount", 33 },
			{ "MerchantHasNewGoods", 34 },
			{ "AddKidnappedCharacter", 35 },
			{ "TransferKidnappedCharacters", 36 },
			{ "ChangeKidnappedCharacterRope", 37 },
			{ "GetKidnapMaxSlotCount", 38 },
			{ "TransferKidnappedCharacter", 39 },
			{ "RemoveKidnappedCharacter", 40 },
			{ "GetDisplayingAge", 41 },
			{ "GetMainAttributesRecoveries", 42 },
			{ "GetInscriptionStatus", 43 },
			{ "GetCharacterBirthDate", 44 },
			{ "GetMaxWorthCanBeLentToTaiwu", 45 },
			{ "CheckFavorabilityBeforeTransferring", 46 },
			{ "GetClothingDisplayId", 47 },
			{ "GetCharacterDisplayDataList", 48 },
			{ "GetCharacterLifeSkillAttainmentList", 49 },
			{ "GetTaiwuRelatedGraveDisplayDataList", 50 },
			{ "GetGraveDisplayDataList", 51 },
			{ "GetCharacterDisplayDataListForRelations", 52 },
			{ "GetSomeoneKidnapCharacters", 53 },
			{ "GetCharacterAttributeDisplayData", 54 },
			{ "GetCharacterSamsaraData", 55 },
			{ "GetEquipmentCompareData", 56 },
			{ "GetGroupCharDisplayDataList", 57 },
			{ "GetDefeatMarkCountList", 58 },
			{ "GetFeatureMedalValue", 59 },
			{ "GetFeatureMedalValueList", 60 },
			{ "GetFixedCharacterIdByTemplateId", 61 },
			{ "GmCmd_SimulateNpcCombat", 62 },
			{ "GmCmd_GetAllCharacterName", 63 },
			{ "GmCmd_ChangeFavorability", 64 },
			{ "GmCmd_ClearFameActionRecords", 65 },
			{ "GmCmd_RecordFameAction", 66 },
			{ "GmCmd_CreateRandomIntelligentCharacters", 67 },
			{ "GmCmd_ForceChangeOrganization", 68 },
			{ "GmCmd_ForceChangeGrade", 69 },
			{ "GmCmd_Die", 70 },
			{ "GmCmd_GetAliveCharByPreexistenceChar", 71 },
			{ "GmCmd_LogCharacterSamsaraInfo", 72 },
			{ "GmCmd_EditExtraNeiliAllocation", 73 },
			{ "GmCmd_MakeCharacterKidnapped", 74 },
			{ "GmCmd_MoveIntelligentCharacter", 75 },
			{ "GmCmd_RandomizeRelationShipsInSettlement", 76 },
			{ "GmCmd_MakeCharacterHaveSex", 77 },
			{ "GmCmd_GetCharacterPregnancyLockEndDates", 78 },
			{ "GmCmd_GetCharacterActualBloodParents", 79 },
			{ "CharacterShaveAvatar", 80 },
			{ "AllocateNeili", 81 },
			{ "DeallocateNeili", 82 },
			{ "GetChangeOfQiDisorder", 83 },
			{ "GetUsableCombatResources", 84 },
			{ "GetCombatSkillSlotCounts", 85 },
			{ "SetCombatSkillSlot", 86 },
			{ "GetCombatSkillAttainment", 87 },
			{ "GetAllCombatSkillAttainment", 88 },
			{ "GetLifeSkillAttainment", 89 },
			{ "GetAllLifeSkillAttainment", 90 },
			{ "LearnCombatSkill", 91 },
			{ "LearnLifeSkill", 92 },
			{ "TryGetDeadCharacter", 93 },
			{ "GetTitles", 94 },
			{ "GetHighestGradeCombatSkillById", 95 },
			{ "GetLeftMaxHealth", 96 },
			{ "GetHealthRecovery", 97 },
			{ "GetAvatarRelatedDataList", 98 },
			{ "GetAvatarData", 99 },
			{ "TransferInventoryItemListWithDebt", 100 },
			{ "GetFameType", 101 },
			{ "GetAvatarRelatedData", 102 },
			{ "GetCharacterListWisdomCount", 103 },
			{ "SortCharacterListByMaxCombatSkill", 104 },
			{ "GetCharacterMaxCombatSkillAttainment", 105 },
			{ "GetItemPowerInfo", 106 },
			{ "CalcMaxFavorabilityToTaiwuById", 107 },
			{ "CheckDebtChange", 108 },
			{ "GetCharacterWisdomCountById", 109 },
			{ "TransferInventoryItemFromAToB", 110 },
			{ "GmCmd_SetCurReadingEvent", 111 },
			{ "GmCmd_AddFeature", 112 },
			{ "GmCmd_SetFeatures", 113 },
			{ "GmCmd_RemoveFeature", 114 },
			{ "GmCmd_RemoveRelation", 115 },
			{ "IsReclusive", 116 },
			{ "GetInventoryEquipment", 117 },
			{ "GetFilteredCharacterCounts", 118 },
			{ "ClearCharacterSortFilter", 119 },
			{ "UpdateSortFilterSettings", 120 },
			{ "InitializeCharacterSortFilter", 121 },
			{ "FindNameInCurrentSortFilter", 122 },
			{ "GetCharacterDisplayDataListForUltimateSelect", 123 },
			{ "GetMaxSortingTypeCharIds", 124 },
			{ "GmCmd_SetCurrNeili", 125 },
			{ "GmCmd_AddPoisonedInventoryItem", 126 },
			{ "GmCmd_AddPoisonedEatingItem", 127 },
			{ "GmCmd_SetCharBaseNeiliProportionOfFiveElements", 128 },
			{ "GetRelationBetweenCharacters", 129 },
			{ "GetInventoryItemsByItemType", 130 },
			{ "GetCharacterDisplayData", 131 },
			{ "UnequipAllCombatSkills", 132 },
			{ "AutoEquipCombatSkills", 133 },
			{ "GmCmd_AddCharacterExtraTitle", 134 },
			{ "TryAddAndApplyOneWayRelation", 135 },
			{ "MoveFuyuHiltLocation", 136 },
			{ "TryRemoveOneWayRelation", 137 },
			{ "GetCharacterLoveAndHateItemInfo", 138 },
			{ "IsTemporaryIntelligentCharacter", 139 },
			{ "GetMixedPoisonTypeRelatedMarkCountArray", 140 },
			{ "SimulateEatingEffect", 141 },
			{ "GetCharacterDisplayDataForTooltip", 142 },
			{ "GmCmd_SetCurLoopingEvent", 143 },
			{ "GetHealthType", 144 },
			{ "GetCharacterLocationDisplayData", 145 },
			{ "GetCharacterDisplayDataForMapBlock", 146 },
			{ "GetCharacterWisdomList", 147 },
			{ "GetOrCreateSwordTombCharacterIdForNormalInformation", 148 },
			{ "GetAllInventoryItemsExcludeValueZero", 149 },
			{ "GetAddConsummateLevelRequiredMonth", 150 },
			{ "GmCmd_ResetHairGrowth", 151 },
			{ "GetAllItemsByAreaId", 152 },
			{ "SetCombatSkillPlanLock", 153 },
			{ "AppendCombatSkillPlan", 154 },
			{ "DuplicateCurrentCombatSkillPlan", 155 },
			{ "UpdateCombatSkillPlan", 156 },
			{ "GetCurrentPlanIdAndPlanCount", 157 },
			{ "DeleteCombatSkillPlan", 158 },
			{ "IsInteractedWithTaiwu", 159 },
			{ "IsNeiliAllocationLocked", 160 },
			{ "AllocateGenericGrid", 161 },
			{ "DeallocateGenericGrid", 162 },
			{ "IsCombatSkillEquipmentLocked", 163 },
			{ "AutoAllocateNeili", 164 },
			{ "AutoSetCombatSkillAttainmentPanels", 165 },
			{ "AutoEquipItems", 166 },
			{ "SetCombatSkillAttainmentLock", 167 },
			{ "IsCombatSkillAttainmentLocked", 168 },
			{ "GetGenericGridAllocation", 169 },
			{ "SetNeiliAllocationLock", 170 },
			{ "RemoveEquippedCombatSkill", 171 },
			{ "AddEquippedCombatSkill", 172 },
			{ "GetCombatSkillExtraSlotCounts", 173 },
			{ "GetCharacterAllBodyPartExists", 174 },
			{ "GmCmd_ChangeCharDisorderOfQi", 175 },
			{ "GenerateRandomName", 176 },
			{ "GetCharacterDisplayDataListForRelationsWithRelationType", 177 },
			{ "GetPhysiologicalAge", 178 },
			{ "GetPhysiologicalAgeAffector", 179 },
			{ "GetKidnappedCharacterDisplayData", 180 },
			{ "IsCarrierDurabilityRunningOut", 181 },
			{ "GmCmd_ForceChangeOrganizationByName", 182 },
			{ "GetAvailableFeature", 183 },
			{ "GetEquipmentCompare", 184 },
			{ "GetCharacterTableDisplayData", 185 },
			{ "GetCharacterTableDisplayDataList", 186 },
			{ "GetCharacterTableDisplayDataListWithNeedItem", 187 },
			{ "TryGetGraveDisplayDataList", 188 },
			{ "GetDeadCharacterDisplayDataForTooltip", 189 },
			{ "GmCmd_DriveWugKing", 190 },
			{ "GetCharacterCurrentProfession", 191 },
			{ "GmCmd_SetCharacterCurrProfessionSeniority", 192 },
			{ "GetCharacterTemporaryFeaturesExpireDate", 193 },
			{ "GetExtraNeiliAllocationProgress", 194 },
			{ "GetCharacterMenuInfoDisplayData", 195 },
			{ "GetAttributeWithDelta", 196 },
			{ "GetAttributeDelta", 197 },
			{ "GetCharacterMenuLifeSkillDisplayData", 198 },
			{ "GetEquipLoad", 199 },
			{ "GetCharacterDisplayDataForNeiliPage", 200 },
			{ "GetCharacterInjuryDisplayData", 201 },
			{ "GetCharacterMenuAttainmentDisplayData", 202 },
			{ "GetKidnapMenuDisplayData", 203 },
			{ "GetPersonalities", 204 },
			{ "GetCharacterDisplayDataForPractice", 205 },
			{ "GetCharacterUsingMedicineDisplayData", 206 },
			{ "GetCharacterItemsDisplayData", 207 },
			{ "GetViewCharacterMenuDisplayData", 208 },
			{ "GetCharacterDisplayDataForGeneralScrollListBatch", 209 },
			{ "GetYuanshanSelectDataList", 210 },
			{ "GetVillagerCharDisplayDataList", 211 },
			{ "GetCharacterDisplayDataForBaihuaLifeLink", 212 },
			{ "GetAlertnessValue", 213 },
			{ "SetAlertnessValue", 214 },
			{ "GetAlertnessData", 215 },
			{ "GetTransferItemPreviewDisplayData", 216 },
			{ "GetAllRanshanReadBooksData", 217 },
			{ "GetCharacterOverviewEatingDisplayData", 218 },
			{ "GetEquipmentKeys", 219 },
			{ "GetCharDisplayDataListAsVillager", 220 },
			{ "GetPreviewLeftMaxHealth", 221 },
			{ "GetGraveDisplayDataListForSelection", 222 },
			{ "GetCharacterDisplayDataForBeggarUltimate", 223 },
			{ "GetAvatarRelatedDataListIncludeDead", 224 },
			{ "GetFixedCharacterName", 225 },
			{ "GetCharacterDisplayDataForGuard", 226 },
			{ "SimulateProfessionDoctorSkill0", 227 },
			{ "GetCharacterDivinePower", 228 },
			{ "GetCharacterGhostTechnique", 229 },
			{ "PreviewAllocateNeili", 230 },
			{ "GetCharacterDisplayDataForTasterUltimate", 231 },
			{ "GmCmd_ChangeXiangshuInfection", 232 },
			{ "TransferInventoryItemInventoryWithDebt", 233 },
			{ "GetActionPlanningDsiplayData", 234 },
			{ "GetCharacterProfessionList", 235 },
			{ "GetCarrierMaxProperty", 236 },
			{ "GmCmd_ClearCharacterActionPlanningData", 237 },
			{ "GmCmd_ClearAllActionPlanningData", 238 },
			{ "GmCmd_TaiwuMeetAll", 239 },
			{ "GetFeatureDynamicFactor", 240 },
			{ "GetCharacterDisplayDataForMapBlockIncludingDead", 241 },
			{ "TryGetCharacterDeadData", 242 },
			{ "GmCmd_CreateInventoryItem", 243 },
			{ "IsFeatureBeIgnored", 244 }
		};
		MethodId2MethodName = new string[245]
		{
			"CreateProtagonist", "GetRelatedCharactersForRelations", "TryCreateRelation", "GetGenealogy", "GenerateRandomHanName", "GenerateRandomZangName", "GenerateRandomChildName", "GetNameRelatedDataList", "GetNameRelatedData", "GetNameAndLifeRelatedDataList",
			"GetNameAndLifeRelatedData", "GetFavorability", "GmCmd_GetAllGroupMembers", "GmCmd_GenerateRandomRefinedItemToCharacter", "GmCmd_ChangeInjury", "GmCmd_ChangePoisonByType", "GmCmd_ForgetCombatSkill", "GmCmd_RevokeCombatSkill", "GmCmd_SetLearnedLifeSkills", "GmCmd_GetCricket",
			"GmCmd_AddRelation", "GetGroupSet", "TransferResourcesWithDebt", "TransferInventoryItemWithDebt", "ChangeEquipment", "CreateInventoryItem", "GetInventoryItems", "GetAllInventoryItems", "GetInventoryItemAmount", "GetAllEquipmentItems",
			"GetInventoryItemDisplayData", "InventoryContainsItem", "AddEatingItem", "GetCurrMaxEatingSlotsCount", "MerchantHasNewGoods", "AddKidnappedCharacter", "TransferKidnappedCharacters", "ChangeKidnappedCharacterRope", "GetKidnapMaxSlotCount", "TransferKidnappedCharacter",
			"RemoveKidnappedCharacter", "GetDisplayingAge", "GetMainAttributesRecoveries", "GetInscriptionStatus", "GetCharacterBirthDate", "GetMaxWorthCanBeLentToTaiwu", "CheckFavorabilityBeforeTransferring", "GetClothingDisplayId", "GetCharacterDisplayDataList", "GetCharacterLifeSkillAttainmentList",
			"GetTaiwuRelatedGraveDisplayDataList", "GetGraveDisplayDataList", "GetCharacterDisplayDataListForRelations", "GetSomeoneKidnapCharacters", "GetCharacterAttributeDisplayData", "GetCharacterSamsaraData", "GetEquipmentCompareData", "GetGroupCharDisplayDataList", "GetDefeatMarkCountList", "GetFeatureMedalValue",
			"GetFeatureMedalValueList", "GetFixedCharacterIdByTemplateId", "GmCmd_SimulateNpcCombat", "GmCmd_GetAllCharacterName", "GmCmd_ChangeFavorability", "GmCmd_ClearFameActionRecords", "GmCmd_RecordFameAction", "GmCmd_CreateRandomIntelligentCharacters", "GmCmd_ForceChangeOrganization", "GmCmd_ForceChangeGrade",
			"GmCmd_Die", "GmCmd_GetAliveCharByPreexistenceChar", "GmCmd_LogCharacterSamsaraInfo", "GmCmd_EditExtraNeiliAllocation", "GmCmd_MakeCharacterKidnapped", "GmCmd_MoveIntelligentCharacter", "GmCmd_RandomizeRelationShipsInSettlement", "GmCmd_MakeCharacterHaveSex", "GmCmd_GetCharacterPregnancyLockEndDates", "GmCmd_GetCharacterActualBloodParents",
			"CharacterShaveAvatar", "AllocateNeili", "DeallocateNeili", "GetChangeOfQiDisorder", "GetUsableCombatResources", "GetCombatSkillSlotCounts", "SetCombatSkillSlot", "GetCombatSkillAttainment", "GetAllCombatSkillAttainment", "GetLifeSkillAttainment",
			"GetAllLifeSkillAttainment", "LearnCombatSkill", "LearnLifeSkill", "TryGetDeadCharacter", "GetTitles", "GetHighestGradeCombatSkillById", "GetLeftMaxHealth", "GetHealthRecovery", "GetAvatarRelatedDataList", "GetAvatarData",
			"TransferInventoryItemListWithDebt", "GetFameType", "GetAvatarRelatedData", "GetCharacterListWisdomCount", "SortCharacterListByMaxCombatSkill", "GetCharacterMaxCombatSkillAttainment", "GetItemPowerInfo", "CalcMaxFavorabilityToTaiwuById", "CheckDebtChange", "GetCharacterWisdomCountById",
			"TransferInventoryItemFromAToB", "GmCmd_SetCurReadingEvent", "GmCmd_AddFeature", "GmCmd_SetFeatures", "GmCmd_RemoveFeature", "GmCmd_RemoveRelation", "IsReclusive", "GetInventoryEquipment", "GetFilteredCharacterCounts", "ClearCharacterSortFilter",
			"UpdateSortFilterSettings", "InitializeCharacterSortFilter", "FindNameInCurrentSortFilter", "GetCharacterDisplayDataListForUltimateSelect", "GetMaxSortingTypeCharIds", "GmCmd_SetCurrNeili", "GmCmd_AddPoisonedInventoryItem", "GmCmd_AddPoisonedEatingItem", "GmCmd_SetCharBaseNeiliProportionOfFiveElements", "GetRelationBetweenCharacters",
			"GetInventoryItemsByItemType", "GetCharacterDisplayData", "UnequipAllCombatSkills", "AutoEquipCombatSkills", "GmCmd_AddCharacterExtraTitle", "TryAddAndApplyOneWayRelation", "MoveFuyuHiltLocation", "TryRemoveOneWayRelation", "GetCharacterLoveAndHateItemInfo", "IsTemporaryIntelligentCharacter",
			"GetMixedPoisonTypeRelatedMarkCountArray", "SimulateEatingEffect", "GetCharacterDisplayDataForTooltip", "GmCmd_SetCurLoopingEvent", "GetHealthType", "GetCharacterLocationDisplayData", "GetCharacterDisplayDataForMapBlock", "GetCharacterWisdomList", "GetOrCreateSwordTombCharacterIdForNormalInformation", "GetAllInventoryItemsExcludeValueZero",
			"GetAddConsummateLevelRequiredMonth", "GmCmd_ResetHairGrowth", "GetAllItemsByAreaId", "SetCombatSkillPlanLock", "AppendCombatSkillPlan", "DuplicateCurrentCombatSkillPlan", "UpdateCombatSkillPlan", "GetCurrentPlanIdAndPlanCount", "DeleteCombatSkillPlan", "IsInteractedWithTaiwu",
			"IsNeiliAllocationLocked", "AllocateGenericGrid", "DeallocateGenericGrid", "IsCombatSkillEquipmentLocked", "AutoAllocateNeili", "AutoSetCombatSkillAttainmentPanels", "AutoEquipItems", "SetCombatSkillAttainmentLock", "IsCombatSkillAttainmentLocked", "GetGenericGridAllocation",
			"SetNeiliAllocationLock", "RemoveEquippedCombatSkill", "AddEquippedCombatSkill", "GetCombatSkillExtraSlotCounts", "GetCharacterAllBodyPartExists", "GmCmd_ChangeCharDisorderOfQi", "GenerateRandomName", "GetCharacterDisplayDataListForRelationsWithRelationType", "GetPhysiologicalAge", "GetPhysiologicalAgeAffector",
			"GetKidnappedCharacterDisplayData", "IsCarrierDurabilityRunningOut", "GmCmd_ForceChangeOrganizationByName", "GetAvailableFeature", "GetEquipmentCompare", "GetCharacterTableDisplayData", "GetCharacterTableDisplayDataList", "GetCharacterTableDisplayDataListWithNeedItem", "TryGetGraveDisplayDataList", "GetDeadCharacterDisplayDataForTooltip",
			"GmCmd_DriveWugKing", "GetCharacterCurrentProfession", "GmCmd_SetCharacterCurrProfessionSeniority", "GetCharacterTemporaryFeaturesExpireDate", "GetExtraNeiliAllocationProgress", "GetCharacterMenuInfoDisplayData", "GetAttributeWithDelta", "GetAttributeDelta", "GetCharacterMenuLifeSkillDisplayData", "GetEquipLoad",
			"GetCharacterDisplayDataForNeiliPage", "GetCharacterInjuryDisplayData", "GetCharacterMenuAttainmentDisplayData", "GetKidnapMenuDisplayData", "GetPersonalities", "GetCharacterDisplayDataForPractice", "GetCharacterUsingMedicineDisplayData", "GetCharacterItemsDisplayData", "GetViewCharacterMenuDisplayData", "GetCharacterDisplayDataForGeneralScrollListBatch",
			"GetYuanshanSelectDataList", "GetVillagerCharDisplayDataList", "GetCharacterDisplayDataForBaihuaLifeLink", "GetAlertnessValue", "SetAlertnessValue", "GetAlertnessData", "GetTransferItemPreviewDisplayData", "GetAllRanshanReadBooksData", "GetCharacterOverviewEatingDisplayData", "GetEquipmentKeys",
			"GetCharDisplayDataListAsVillager", "GetPreviewLeftMaxHealth", "GetGraveDisplayDataListForSelection", "GetCharacterDisplayDataForBeggarUltimate", "GetAvatarRelatedDataListIncludeDead", "GetFixedCharacterName", "GetCharacterDisplayDataForGuard", "SimulateProfessionDoctorSkill0", "GetCharacterDivinePower", "GetCharacterGhostTechnique",
			"PreviewAllocateNeili", "GetCharacterDisplayDataForTasterUltimate", "GmCmd_ChangeXiangshuInfection", "TransferInventoryItemInventoryWithDebt", "GetActionPlanningDsiplayData", "GetCharacterProfessionList", "GetCarrierMaxProperty", "GmCmd_ClearCharacterActionPlanningData", "GmCmd_ClearAllActionPlanningData", "GmCmd_TaiwuMeetAll",
			"GetFeatureDynamicFactor", "GetCharacterDisplayDataForMapBlockIncludingDead", "TryGetCharacterDeadData", "GmCmd_CreateInventoryItem", "IsFeatureBeIgnored"
		};
	}
}

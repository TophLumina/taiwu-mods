using System.Collections.Generic;

namespace GameData.Domains.Extra;

public static class ExtraDomainHelper
{
	/// <summary>
	/// 数据域所辖数据
	/// </summary>
	public static class DataIds
	{
		public const ushort ExchangedSpecialWeaponList = 0;

		public const ushort CaravanStayDays = 1;

		public const ushort MerchantCharToType = 2;

		public const ushort StationInited = 3;

		public const ushort StoneRoomCharList = 4;

		public const ushort CombatSkillOrderPlans = 5;

		public const ushort AutoWorkBlockIndexList = 6;

		public const ushort AutoSoldBlockIndexList = 7;

		public const ushort SecretInformationBroadcastNotifyList = 8;

		public const ushort XiangshuIdInKungfuPracticeRoom = 9;

		public const ushort ReadingEventBookIdList = 10;

		public const ushort ClearedSkillPlateStepInfo = 11;

		public const ushort TravelingEventCollection = 12;

		public const ushort DlcArgBox = 13;

		public const ushort PrevTriggeredTravelingEvents = 14;

		public const ushort GainsInTravel = 15;

		public const ushort LifeSkillCombatCardDict = 16;

		public const ushort LifeSkillCombatUsedCardDict = 17;

		public const ushort LifeSkillCombatReadBookPageDict = 18;

		public const ushort LifeSkillCombatNewCardDict = 19;

		public const ushort SecretInformationBroadcastNotifyExtraList = 20;

		public const ushort CharTeammateCommandDict = 21;

		public const ushort NicknameDict = 22;

		public const ushort LegendaryBookBreakPlateCounts = 23;

		public const ushort LegendaryBookWeaponSlot = 24;

		public const ushort LegendaryBookWeaponEffectId = 25;

		public const ushort LegendaryBookSkillSlot = 26;

		public const ushort LegendaryBookSkillEffectId = 27;

		public const ushort LegendaryBookBonusCountYin = 28;

		public const ushort LegendaryBookBonusCountYang = 29;

		public const ushort CombatSkillBreakPlateLastClearTimeList = 30;

		public const ushort CombatSkillCurrBreakPlateIndex = 31;

		public const ushort LoveDataDict = 32;

		public const ushort PreviousLoverSet = 33;

		public const ushort ConfessLoveFailedSet = 34;

		public const ushort LoveTokenDataDict = 35;

		public const ushort SavedSouls = 36;

		public const ushort CricketIsSmart = 37;

		public const ushort CricketIsIdentified = 38;

		public const ushort TaiwuInteractionCooldowns = 39;

		public const ushort CharacterCustomDisplayNames = 40;

		public const ushort SectMainStoryEventArgBoxes = 41;

		public const ushort VoiceWeaponInnerRatio = 42;

		public const ushort SectXuehouBloodLightLocations = 43;

		public const ushort BrokenAreaMaterials = 44;

		public const ushort SectWudangFairylandData = 45;

		public const ushort TreasureMaterialFailedTimes = 46;

		public const ushort TaiwuMaxNeiliAllocation = 47;

		public const ushort CharacterMasteredCombatSkills = 48;

		public const ushort MasteredCombatSkillPlans = 49;

		public const ushort CombatSkillBreakPlateLastForceBreakoutStepsCount = 50;

		public const ushort AutoCheckInComfortableList = 51;

		public const ushort AutoCheckInResidenceList = 52;

		public const ushort LegaciesBuildingTemplateIdList = 53;

		public const ushort IsDreamBack = 54;

		public const ushort AbridgedDreamBackCharacters = 55;

		public const ushort UnlockedWorkingVillagers = 56;

		public const ushort DreamBackLifeRecords = 57;

		public const ushort ActionPointCurrMonth = 58;

		public const ushort AdvancedTeammateCommandDict = 59;

		public const ushort ReadInLifeSkillCombatCount = 60;

		public const ushort SectWudangHeavenlyTreeList = 61;

		public const ushort SectWudangLingBaoDark = 62;

		public const ushort SectWudangLingBaoLight = 63;

		public const ushort ShixiangBarbarianMasterIdList = 64;

		public const ushort InformationSettings = 65;

		public const ushort SectXuannvUnlockedMusicList = 66;

		public const ushort SectXuannvPlayerPlayMode = 67;

		public const ushort SectXuannvPlayerMusicId = 68;

		public const ushort SectXuannvPlayerIsEnabled = 69;

		public const ushort MirrorCharacters = 70;

		public const ushort SectEmeiBloodLocations = 71;

		public const ushort CharacterPoisonImmunities = 72;

		public const ushort SectXuannvEvaluatedMusicList = 73;

		public const ushort CombatSkillJumpThreshold = 74;

		public const ushort DreamBackUnlockStates = 75;

		public const ushort DreamBackArchiveBackup = 76;

		public const ushort OverwrittenTaiwu = 77;

		public const ushort DreamBackLocationData = 78;

		public const ushort ConflictCombatSkills = 79;

		public const ushort CharacterRevealedHobbies = 80;

		public const ushort FinalDateBeforeDreamBack = 81;

		public const ushort DreamBackTaiwu = 82;

		public const ushort ConflictEffectWrappers = 83;

		public const ushort DreamBackGlobalEventArgBox = 84;

		public const ushort DreamBackDlcEventArgBox = 85;

		public const ushort DreamBackSectMainStoryEventArgBox = 86;

		public const ushort DejaVuEventCharacters = 87;

		public const ushort TaiwuAddOneWayRelationCoolDown = 88;

		public const ushort CarrierTamePoint = 89;

		public const ushort DreamBackPreviousTaiwuCharIds = 90;

		public const ushort DlcArgBoxes = 91;

		public const ushort JiaoPools = 92;

		public const ushort Jiaos = 93;

		public const ushort ChildrenOfLoong = 94;

		public const ushort FiveLoongDict = 95;

		public const ushort JiaoPoolRecords = 96;

		public const ushort DlcEntries = 97;

		public const ushort JiaoPoolStatus = 98;

		public const ushort ChoosyRemainUpgradeRateDict = 99;

		public const ushort ChoosyRemainUpgradeCountDict = 100;

		public const ushort BuildingMoneyPrestigeSuccessRateCompensation = 101;

		public const ushort EmptyToolKey = 102;

		public const ushort SectWuxianWugJugPoisons = 103;

		public const ushort CricketCollectionDataList = 104;

		public const ushort RecruitCharacterDataLists = 105;

		public const ushort SectJingangPossessionCharacters = 106;

		public const ushort CricketExtraAge = 107;

		public const ushort EnemyNestInitializationDates = 108;

		public const ushort SecretInformationShopCharacterData = 109;

		public const ushort NextAnimalId = 110;

		public const ushort Animals = 111;

		public const ushort BookStrategiesExpireTime = 112;

		public const ushort UnlockedCombatSkillPlanCount = 113;

		public const ushort ActiveLoopingProgress = 114;

		public const ushort ActiveReadingProgress = 115;

		public const ushort SectRanshanThreeCorpses = 116;

		public const ushort SectBaihuaLifeLinkData = 117;

		public const ushort SamsaraPlatformRecordCollection = 118;

		public const ushort AvailableReadingStrategyMap = 119;

		public const ushort ReferenceSkillList = 120;

		public const ushort AvailableQiArtStrategyMap = 121;

		public const ushort LoopingEventSkillIdList = 122;

		public const ushort QiArtStrategyMap = 123;

		public const ushort QiArtStrategyExpireTimeMap = 124;

		public const ushort LoopInLifeSkillCombatCount = 125;

		public const ushort LoopInCombatCount = 126;

		public const ushort MonthlyNotificationSortingGroups = 127;

		public const ushort FollowingNpcList = 128;

		public const ushort FollowingNickNameMap = 129;

		public const ushort MerchantOverFavorDataArray = 130;

		public const ushort ChangedTeammateCharIds = 131;

		public const ushort SectFulongOrgMemberChickens = 132;

		public const ushort SectFulongInFlameAreas = 133;

		public const ushort SectFulongOutLaws = 134;

		public const ushort VillagerRoles = 135;

		public const ushort SectFulongLoseFeatherChickens = 136;

		public const ushort FullPoisonEffects = 137;

		public const ushort ItemPriceFluctuation = 138;

		public const ushort VillagerRoleNickNameMap = 139;

		public const ushort VillagerRoleMaxUnlockCounts = 140;

		public const ushort BuildingResourceOutputSettings = 141;

		public const ushort BlockRecoveryUnlockDates = 142;

		public const ushort CharacterConsummateLevelProgresses = 143;

		public const ushort TaiwuWantedFirstInteractOrganizationMember = 144;

		public const ushort AreaSpiritualDebt = 145;

		public const ushort TaiwuProfessions = 146;

		public const ushort TaiwuProfessionSkillSlots = 147;

		public const ushort CricketPlaceExtraData = 148;

		public const ushort BranchMerchantData = 149;

		public const ushort CharacterCombatSkillConfigurations = 150;

		public const ushort CharacterEquippedCombatSkills = 151;

		public const ushort InteractedCharacterList = 152;

		public const ushort SectZhujianGearMates = 153;

		public const ushort TriggeredAddSeniorityPoints = 154;

		public const ushort TaiwuGiftItems = 155;

		public const ushort SectZhujianThiefList = 156;

		public const ushort CaravanExtraDataDict = 157;

		public const ushort ProtectCaravanTime = 158;

		public const ushort SectZhujianAreaMerchantTypeDict = 159;

		public const ushort MerchantExtraGoods = 160;

		public const ushort SectStorySpecialMerchant = 161;

		public const ushort IsExtraProfessionSkillUnlocked = 162;

		public const ushort IsDirectTraveling = 163;

		public const ushort KidnappedTravelData = 164;

		public const ushort VillagerLastInfluencePowerGrade = 165;

		public const ushort VillagerTreasuryNeeds = 166;

		public const ushort CharacterSkillBreakBonuses = 167;

		public const ushort CombatSkillProficiencies = 168;

		public const ushort SkillBreakPlates = 169;

		public const ushort CombatSkillBreakPlateList = 170;

		public const ushort SectShaolinDemonSlayerData = 171;

		public const ushort KongsangCharacterFeaturePoisonedProb = 172;

		public const ushort PickupDict = 173;

		public const ushort TaiwuSelectedDebateCardType = 174;

		public const ushort VillagerRoleRecords = 175;

		public const ushort VillagerRoleAutoActionStates = 176;

		public const ushort BuildingArrangementSettingPresetData = 177;

		public const ushort BuildingArtisanOrders = 178;

		public const ushort TaiwuVillagerPotentialData = 179;

		public const ushort NpcArtisanOrders = 180;

		public const ushort ShopVillagerQualificationImprove = 181;

		public const ushort HasGetShuiHuoYingQiGongSkillBookByArchiveFix = 182;

		public const ushort FarmerAutoCollectStorageType = 183;

		public const ushort WoodenXiangshuAvatarSelectedFeatures = 184;

		public const ushort BuildingAreaEffectProgresses = 185;

		public const ushort KilledByYufuCharactersBinary = 186;

		public const ushort DyingCharacters = 187;

		public const ushort ProficiencyEnoughSkills = 188;

		public const ushort SectYuanshanThreeVitals = 189;

		public const ushort DreamBackGenealogy = 190;

		public const ushort ResourceBlockExtraData = 191;

		public const ushort UnlockedFeastTypes = 192;

		public const ushort Feasts = 193;

		public const ushort SettlementLayeredTreasuries = 194;

		public const ushort BuildingDefaultStoreLocation = 195;

		public const ushort TaiwuVillageVowOrgTemplateCrossArchiveDict = 196;

		public const ushort ChapterJieqingGameState = 197;

		public const ushort CurrJieqingGameState = 198;

		public const ushort SectJieqingExtraLegacyPoints = 199;

		public const ushort SectJieqingNpcExtraLegacyPoints = 200;

		public const ushort MainUiCustomButtonList = 201;

		public const ushort CustomMapBlockCharInfoList = 202;

		public const ushort CustomMapBlockCharButtonList = 203;

		public const ushort TaiwuVisitedAreas = 204;

		public const ushort JixiData = 205;

		public const ushort SectXuannvFavoriteMusicList = 206;

		public const ushort SectXuannvPlayerIsPlaying = 207;
	}

	/// <summary>
	/// 数据域中的方法
	/// </summary>
	public static class MethodIds
	{
		public const ushort SetCombatSkillOrderPlan = 0;

		public const ushort AddLocationMark = 1;

		public const ushort RemoveLocationMark = 2;

		public const ushort AddReadingEventBookId = 3;

		public const ushort RemoveReadingEventBookId = 4;

		public const ushort GetAllLifeSkillCombatUsedCard = 5;

		public const ushort GetAllLifeSkillCombatCard = 6;

		public const ushort SetLifeSkillCombatUsedCard = 7;

		public const ushort GetCharacterLifeSkillCombatUsedCard = 8;

		public const ushort GetLifeSkillCombatUsedCard = 9;

		public const ushort GetAllLifeSkillCombatNewCard = 10;

		public const ushort SetLifeSkillCombatCardNotNew = 11;

		public const ushort GetCharTeammateCommands = 12;

		public const ushort SetLegendaryBookWeaponSlot = 13;

		public const ushort SetLegendaryBookSkillSlot = 14;

		public const ushort UnlockLegendaryBookBreakPlate = 15;

		public const ushort UnlockLegendaryBookBonus = 16;

		public const ushort EnterUnlockBreakPlateCombat = 17;

		public const ushort ExecuteActiveProfessionSkill = 18;

		public const ushort IsProfessionalSkillUnlocked = 19;

		public const ushort CanExecuteProfessionSkill = 20;

		public const ushort SetProfessionTestSetting = 21;

		public const ushort GetCharacterCustomDisplayName = 22;

		public const ushort GetTianJieFuLuCount = 23;

		public const ushort GmCmd_GenerateTreasure = 24;

		public const ushort FindTreasure = 25;

		public const ushort CheckSpecialCondition = 26;

		public const ushort ConfirmExecuteSkill = 27;

		public const ushort FindTreasureExpect = 28;

		public const ushort UnlockAllProfessionSkills = 29;

		public const ushort SetProfessionSeniorityTarget = 30;

		public const ushort GmCmd_Profession_SetBuddhistMonkSavedSoulCount = 31;

		public const ushort GmCmd_Profession_SetTempleVisited = 32;

		public const ushort InitAiLifeSkillCombatUsedCard = 33;

		public const ushort GmCmd_Profession_RecoverHunterCarrierAttackCount = 34;

		public const ushort GetBlockMerchantTypes = 35;

		public const ushort GetCharacterMasteredCombatSkills = 36;

		public const ushort AddCharacterMasteredCombatSkill = 37;

		public const ushort RemoveCharacterMasteredCombatSkill = 38;

		public const ushort InvokeFindExtraTreasureEvent = 39;

		public const ushort SetAdvancedTeammateCommands = 40;

		public const ushort CancelAdvancedTeammateCommands = 41;

		public const ushort GetAllHeavenlyTrees = 42;

		public const ushort GetHeavenlyTreeNearBlocks = 43;

		public const ushort GetInformationSettings = 44;

		public const ushort GetPoisonImmunities = 45;

		public const ushort GetDreamBackTaiwuRelatedCharactersForRelations = 46;

		public const ushort GetDreamBackTaiwuGenealogy = 47;

		public const ushort GetCharacterDisplayDataListForDreamBackRelations = 48;

		public const ushort GetDreamBackLifeRecordByDate = 49;

		public const ushort GetNameAndLifeRelatedDataListForDreamBack = 50;

		public const ushort IsCharacterHatingItemRevealed = 51;

		public const ushort IsCharacterLovingItemRevealed = 52;

		public const ushort IsCharacterHobbyRevealed = 53;

		public const ushort SetCharacterRevealedHobbies = 54;

		public const ushort GetConflictCombatSkill = 55;

		public const ushort GetAllDreamBackLifeRecords = 56;

		public const ushort GetDreamBackTaiwuBirthAndEndDates = 57;

		public const ushort IsCurrentTaiwuOverwrittenByDreamBack = 58;

		public const ushort ApplyConflictCombatSkillResult = 59;

		public const ushort HaveConflictCombatSkill = 60;

		public const ushort AddTaiwuOneWayRelationCoolDown = 61;

		public const ushort IsTaiwuAbleToAddOneWayRelation = 62;

		public const ushort GetTaiwuAddOneWayRelationCoolDown = 63;

		public const ushort FeedCarrier = 64;

		public const ushort GetCarrierTamePoint = 65;

		public const ushort GetDreamBackCharacterDisplayDataList = 66;

		public const ushort GetCarrierMaxTamePoint = 67;

		public const ushort GetCurrMaxJiaoPoolCount = 68;

		public const ushort GmCmd_FindFiveLoongLocation = 69;

		public const ushort GetJiaoPoolBlockStyle = 70;

		public const ushort SetJiaoPoolBlockStyle = 71;

		public const ushort GetChildrenOfLoongById = 72;

		public const ushort GetJiaoPoolList = 73;

		public const ushort GetJiaoById = 74;

		public const ushort GetJiaoPoolAllJiaoData = 75;

		public const ushort PutJiaoInPool = 76;

		public const ushort PutAnotherJiaoInPool = 77;

		public const ushort PutJiaoOutOfPool = 78;

		public const ushort ChangeNurturance = 79;

		public const ushort ChangeJiaoName = 80;

		public const ushort DisableJiaoPool = 81;

		public const ushort EnableJiaoPool = 82;

		public const ushort GetJiaoLoongNameRelatedDataList = 83;

		public const ushort GetAllJiaoForPool = 84;

		public const ushort GetAllJiaoForEvolve = 85;

		public const ushort GetJiaoByItemKey = 86;

		public const ushort GetJiaosByItemKeys = 87;

		public const ushort GetChildrenOfLoongByItemKey = 88;

		public const ushort PutEggIntoPool = 89;

		public const ushort JiaoPoolInteract = 90;

		public const ushort GmCmd_AddJiao = 91;

		public const ushort GmCmd_PutJiaoInFirstPool = 92;

		public const ushort GmCmd_AddChildOfLoong = 93;

		public const ushort JiaoEvolveToChildOfLoong = 94;

		public const ushort GetJiaoEvolutionChoice = 95;

		public const ushort ResetJiaoPoolStatus = 96;

		public const ushort GetAllAdultJiao = 97;

		public const ushort GetAllEvolvingJiao = 98;

		public const ushort GetJiaoTemplateIdByCarrierTemplateId = 99;

		public const ushort CalcResourceChangeByJiaoPool = 100;

		public const ushort IsOwnedChildrenOfLoong = 101;

		public const ushort GetNextRandomChildrenOfLoong = 102;

		public const ushort GmCmd_AddFleeCarrier = 103;

		public const ushort GetIsJiaoPoolOpen = 104;

		public const ushort FillJiaoRecordArgumentCollection = 105;

		public const ushort GetJiaoEvolutionPageStatus = 106;

		public const ushort GetIsBabysittingMode = 107;

		public const ushort SetIsBabysittingMode = 108;

		public const ushort GetFiveLoongDictCount = 109;

		public const ushort GetJiaoLoongNameRelatedData = 110;

		public const ushort IsJiaoAbleToPet = 111;

		public const ushort PetJiao = 112;

		public const ushort JiaoPoolPetJiao = 113;

		public const ushort GetTaiwuAddOneWayRelationResultCode = 114;

		public const ushort RequestRecruitCharacterData = 115;

		public const ushort GmCmd_AddThreeCorpses = 116;

		public const ushort ApplyRanshanThreeCorpsesLegendaryBookKeepingResult = 117;

		public const ushort GetItemListForRanshanTreeCorpsesLegendaryBookKeeping = 118;

		public const ushort GmCmd_AddDisplayEventLegendaryBookKeeping = 119;

		public const ushort SetRanshanThreeCorpsesCharacterTarget = 120;

		public const ushort GetBookStrategiesExpireTime = 121;

		public const ushort SetMonthlyNotificationSortingGroup = 122;

		public const ushort SetCharTeammateCommandsManual = 123;

		public const ushort GetCharAdvancedTeammateCommands = 124;

		public const ushort IsStoneRoomFull = 125;

		public const ushort ExtinguishFulongInFlameArea = 126;

		public const ushort TriggerFulongInFlameAreaMine = 127;

		public const ushort ApplyFulongInFlameAreaFullyExtinguished = 128;

		public const ushort GmCmd_GenerateFulongFlameArea = 129;

		public const ushort HunterSkill_AnimalCharacterToItem = 130;

		public const ushort ConfirmProfessionSkillsEquipment = 131;

		public const ushort GmCmd_CastTasterUltimateOnCurrentBlock = 132;

		public const ushort EatTianJieFuLu = 133;

		public const ushort CheckAristocratUltimateSpecialCondition = 134;

		public const ushort CheckBeggarUltimateSpecialCondition = 135;

		public const ushort CheckTasterUltimateSpecialCondition = 136;

		public const ushort GM_GetFriendOrFamilySendGift = 137;

		public const ushort GmCmd_CreateGearMate = 138;

		public const ushort GetGearMateRepairEffect = 139;

		public const ushort RepairGearMate = 140;

		public const ushort GetGearMateRepairRequirement = 141;

		public const ushort GetGearMateAvailableRepairCount = 142;

		public const ushort GetGearMateRepairRequirementDisplayDatas = 143;

		public const ushort UpgradeGearMate = 144;

		public const ushort GetCharacterConsummateLevelProgress = 145;

		public const ushort GetMartialArtistCreateGoodRandomEnemyAndBadRandomEnemyCount = 146;

		public const ushort GetGearMateById = 147;

		public const ushort CheckSpecialCondition_SavageSkill_1 = 148;

		public const ushort GetMerchantExtraGoods = 149;

		public const ushort SetProfessionExtraSeniority = 150;

		public const ushort CanShowProfessionSkillUnlocked = 151;

		public const ushort GetGearMateBreakoutCombatSkillBanReasonList = 152;

		public const ushort SetDukeSkill3Crickets = 153;

		public const ushort GetAllSkillBooksGearMateCanRead = 154;

		public const ushort CanIdentifyCricket = 155;

		public const ushort CanUpgradeCricket = 156;

		public const ushort CanConvertToAnimalCharacter = 157;

		public const ushort GetJiaoLoongDisplayDataByItemKey = 158;

		public const ushort GmCmd_SetCharacterProficiencies = 159;

		public const ushort GmCmd_CreateRandomEnemyAroundHeavenlyTree = 160;

		public const ushort GmCmd_ShowUnlockedProfessionSkill = 161;

		public const ushort SetVillagerRoleAutoActionState = 162;

		public const ushort ChangeBuildingArrangementSettingPresetData = 163;

		public const ushort AddMaterialToArtisanOrder = 164;

		public const ushort GetArtisanOrderProductionPool = 165;

		public const ushort SetArtisanOrderProductionType = 166;

		public const ushort SetArtisanOrderStorageType = 167;

		public const ushort GetNpcArtisanOrder = 168;

		public const ushort InterceptArtisanOrder = 169;

		public const ushort GetBuildingArtisanOrder = 170;

		public const ushort CreateArtisanOrder = 171;

		public const ushort GetProductionPoolPreview = 172;

		public const ushort ArtisanOrderDebate = 173;

		public const ushort GetArtisanOrderMaterialPreview = 174;

		public const ushort GetArtisanOrderCanProduceItemSubType = 175;

		public const ushort SetFarmerAutoCollectStorageType = 176;

		public const ushort UpdateWoodenXiangshuAvatarSelectedFeatures = 177;

		public const ushort GmCmd_GetBuildingAreaEffectProgresses = 178;

		public const ushort GmCmd_SetBuildingAreaEffectProgresses = 179;

		public const ushort GmCmd_ReleaseAllKilledByLongYufuCharacters = 180;

		public const ushort GmCmd_RecordKilledByLongYufuCharacter = 181;

		public const ushort GmCmd_VitalInfectionInOut = 182;

		public const ushort CheckSpecialCondition_HunterSkill2 = 183;

		public const ushort GetThreeVitalsCharDataList = 184;

		public const ushort GmCmd_InitThreeVitals = 185;

		public const ushort GetThreeVitalsTargetCharDataList = 186;

		public const ushort TransferInfectionBetweenVitalAndCharacter = 187;

		public const ushort SetVitalInPrison = 188;

		public const ushort GetBuildingArtisanOrderAfterUpdate = 189;

		public const ushort GetCanSelectThreeVitalsDisplayData = 190;

		public const ushort AreVitalsDemon = 191;

		public const ushort GetOppositeThreeVitalsCharDataList = 192;

		public const ushort SetVitalHasPlayedComeAnim = 193;

		public const ushort GetResourceBlockProducingCoreCooldown = 194;

		public const ushort FeastAddDish = 195;

		public const ushort FeastSetAutoRefill = 196;

		public const ushort GetFeast = 197;

		public const ushort FeastRemoveDish = 198;

		public const ushort FeastReceiveGift = 199;

		public const ushort AddResourceItemToArtisanOrder = 200;

		public const ushort IsFeastException = 201;

		public const ushort UseFeastThanksLetter = 202;

		public const ushort FeastQuickRefill = 203;

		public const ushort FeastSetTargetType = 204;

		public const ushort GetSectExtraLegacyBuildingStates = 205;

		public const ushort SetJieqingGameData = 206;

		public const ushort ConsumeExtraLegacyPoint = 207;

		public const ushort IsSectBuiltExtraLegacyBuilding = 208;

		public const ushort InitJieqingGameData = 209;

		public const ushort RemoveSectExtraLegacyBuilding = 210;

		public const ushort BuildExtraLegacyBuilding = 211;

		public const ushort GetCharacterExtraLegacyPointWorth = 212;

		public const ushort GetExtraLegacyPointCharacterCountOnBlock = 213;

		public const ushort GetSectExtraLegacyBuildingCounts = 214;

		public const ushort SaveMainUiCustomButtons = 215;

		public const ushort SetMapBlockCharCustomInfoList = 216;

		public const ushort SetMapBlockCharCustomButtonList = 217;

		public const ushort GetAreaCharacterJieQingSignAmount = 218;

		public const ushort CheckLocationHasBeggerSkill1 = 219;

		public const ushort SetJixiDrainNeili = 220;

		public const ushort SetJixiTarget = 221;

		public const ushort TaiwuTransferNeiliAllocToJixi = 222;

		public const ushort JixiTransferNeiliAllocToTaiwu = 223;

		public const ushort SetJixiDrainType = 224;

		public const ushort GetJixiSpecialInteractDisplayData = 225;

		public const ushort InitJixiSpecialInteractData = 226;

		public const ushort JixiRescueTaiwu = 227;

		public const ushort GetCharacterExtraLegacyPointWorthCalculated = 228;

		public const ushort GetSectRanshanThreeCorpsesData = 229;

		public const ushort SetTaiwuTransformFiveElementsTarget = 230;

		public const ushort SetTaiwuTargetFiveElementsType = 231;

		public const ushort GetSectYuanshanThreeVitalsData = 232;

		public const ushort RequestAllRecruitCharacterData = 233;

		public const ushort GetTipLegendaryBookDisplayData = 234;

		public const ushort GetSectMembersWorthExtraLegacyPoint = 235;

		public const ushort GetCharacterExtraLegacyPointWorthForMapBlock = 236;

		public const ushort GmCmd_SetSectMainStoryArgBoxInt = 237;

		public const ushort GmCmd_GetSectMainStoryArgBoxBool = 238;

		public const ushort GmCmd_GetSectMainStoryArgBoxInt = 239;

		public const ushort GmCmd_SetSectMainStoryArgBoxBool = 240;
	}

	/// <summary>
	/// 数据域所辖数据的个数
	/// </summary>
	public const ushort DataCount = 208;

	/// <summary>
	/// 通过字段名获取数据 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> FieldName2DataId = new Dictionary<string, ushort>
	{
		{ "ExchangedSpecialWeaponList", 0 },
		{ "CaravanStayDays", 1 },
		{ "MerchantCharToType", 2 },
		{ "StationInited", 3 },
		{ "StoneRoomCharList", 4 },
		{ "CombatSkillOrderPlans", 5 },
		{ "AutoWorkBlockIndexList", 6 },
		{ "AutoSoldBlockIndexList", 7 },
		{ "SecretInformationBroadcastNotifyList", 8 },
		{ "XiangshuIdInKungfuPracticeRoom", 9 },
		{ "ReadingEventBookIdList", 10 },
		{ "ClearedSkillPlateStepInfo", 11 },
		{ "TravelingEventCollection", 12 },
		{ "DlcArgBox", 13 },
		{ "PrevTriggeredTravelingEvents", 14 },
		{ "GainsInTravel", 15 },
		{ "LifeSkillCombatCardDict", 16 },
		{ "LifeSkillCombatUsedCardDict", 17 },
		{ "LifeSkillCombatReadBookPageDict", 18 },
		{ "LifeSkillCombatNewCardDict", 19 },
		{ "SecretInformationBroadcastNotifyExtraList", 20 },
		{ "CharTeammateCommandDict", 21 },
		{ "NicknameDict", 22 },
		{ "LegendaryBookBreakPlateCounts", 23 },
		{ "LegendaryBookWeaponSlot", 24 },
		{ "LegendaryBookWeaponEffectId", 25 },
		{ "LegendaryBookSkillSlot", 26 },
		{ "LegendaryBookSkillEffectId", 27 },
		{ "LegendaryBookBonusCountYin", 28 },
		{ "LegendaryBookBonusCountYang", 29 },
		{ "CombatSkillBreakPlateLastClearTimeList", 30 },
		{ "CombatSkillCurrBreakPlateIndex", 31 },
		{ "LoveDataDict", 32 },
		{ "PreviousLoverSet", 33 },
		{ "ConfessLoveFailedSet", 34 },
		{ "LoveTokenDataDict", 35 },
		{ "SavedSouls", 36 },
		{ "CricketIsSmart", 37 },
		{ "CricketIsIdentified", 38 },
		{ "TaiwuInteractionCooldowns", 39 },
		{ "CharacterCustomDisplayNames", 40 },
		{ "SectMainStoryEventArgBoxes", 41 },
		{ "VoiceWeaponInnerRatio", 42 },
		{ "SectXuehouBloodLightLocations", 43 },
		{ "BrokenAreaMaterials", 44 },
		{ "SectWudangFairylandData", 45 },
		{ "TreasureMaterialFailedTimes", 46 },
		{ "TaiwuMaxNeiliAllocation", 47 },
		{ "CharacterMasteredCombatSkills", 48 },
		{ "MasteredCombatSkillPlans", 49 },
		{ "CombatSkillBreakPlateLastForceBreakoutStepsCount", 50 },
		{ "AutoCheckInComfortableList", 51 },
		{ "AutoCheckInResidenceList", 52 },
		{ "LegaciesBuildingTemplateIdList", 53 },
		{ "IsDreamBack", 54 },
		{ "AbridgedDreamBackCharacters", 55 },
		{ "UnlockedWorkingVillagers", 56 },
		{ "DreamBackLifeRecords", 57 },
		{ "ActionPointCurrMonth", 58 },
		{ "AdvancedTeammateCommandDict", 59 },
		{ "ReadInLifeSkillCombatCount", 60 },
		{ "SectWudangHeavenlyTreeList", 61 },
		{ "SectWudangLingBaoDark", 62 },
		{ "SectWudangLingBaoLight", 63 },
		{ "ShixiangBarbarianMasterIdList", 64 },
		{ "InformationSettings", 65 },
		{ "SectXuannvUnlockedMusicList", 66 },
		{ "SectXuannvPlayerPlayMode", 67 },
		{ "SectXuannvPlayerMusicId", 68 },
		{ "SectXuannvPlayerIsEnabled", 69 },
		{ "MirrorCharacters", 70 },
		{ "SectEmeiBloodLocations", 71 },
		{ "CharacterPoisonImmunities", 72 },
		{ "SectXuannvEvaluatedMusicList", 73 },
		{ "CombatSkillJumpThreshold", 74 },
		{ "DreamBackUnlockStates", 75 },
		{ "DreamBackArchiveBackup", 76 },
		{ "OverwrittenTaiwu", 77 },
		{ "DreamBackLocationData", 78 },
		{ "ConflictCombatSkills", 79 },
		{ "CharacterRevealedHobbies", 80 },
		{ "FinalDateBeforeDreamBack", 81 },
		{ "DreamBackTaiwu", 82 },
		{ "ConflictEffectWrappers", 83 },
		{ "DreamBackGlobalEventArgBox", 84 },
		{ "DreamBackDlcEventArgBox", 85 },
		{ "DreamBackSectMainStoryEventArgBox", 86 },
		{ "DejaVuEventCharacters", 87 },
		{ "TaiwuAddOneWayRelationCoolDown", 88 },
		{ "CarrierTamePoint", 89 },
		{ "DreamBackPreviousTaiwuCharIds", 90 },
		{ "DlcArgBoxes", 91 },
		{ "JiaoPools", 92 },
		{ "Jiaos", 93 },
		{ "ChildrenOfLoong", 94 },
		{ "FiveLoongDict", 95 },
		{ "JiaoPoolRecords", 96 },
		{ "DlcEntries", 97 },
		{ "JiaoPoolStatus", 98 },
		{ "ChoosyRemainUpgradeRateDict", 99 },
		{ "ChoosyRemainUpgradeCountDict", 100 },
		{ "BuildingMoneyPrestigeSuccessRateCompensation", 101 },
		{ "EmptyToolKey", 102 },
		{ "SectWuxianWugJugPoisons", 103 },
		{ "CricketCollectionDataList", 104 },
		{ "RecruitCharacterDataLists", 105 },
		{ "SectJingangPossessionCharacters", 106 },
		{ "CricketExtraAge", 107 },
		{ "EnemyNestInitializationDates", 108 },
		{ "SecretInformationShopCharacterData", 109 },
		{ "NextAnimalId", 110 },
		{ "Animals", 111 },
		{ "BookStrategiesExpireTime", 112 },
		{ "UnlockedCombatSkillPlanCount", 113 },
		{ "ActiveLoopingProgress", 114 },
		{ "ActiveReadingProgress", 115 },
		{ "SectRanshanThreeCorpses", 116 },
		{ "SectBaihuaLifeLinkData", 117 },
		{ "SamsaraPlatformRecordCollection", 118 },
		{ "AvailableReadingStrategyMap", 119 },
		{ "ReferenceSkillList", 120 },
		{ "AvailableQiArtStrategyMap", 121 },
		{ "LoopingEventSkillIdList", 122 },
		{ "QiArtStrategyMap", 123 },
		{ "QiArtStrategyExpireTimeMap", 124 },
		{ "LoopInLifeSkillCombatCount", 125 },
		{ "LoopInCombatCount", 126 },
		{ "MonthlyNotificationSortingGroups", 127 },
		{ "FollowingNpcList", 128 },
		{ "FollowingNickNameMap", 129 },
		{ "MerchantOverFavorDataArray", 130 },
		{ "ChangedTeammateCharIds", 131 },
		{ "SectFulongOrgMemberChickens", 132 },
		{ "SectFulongInFlameAreas", 133 },
		{ "SectFulongOutLaws", 134 },
		{ "VillagerRoles", 135 },
		{ "SectFulongLoseFeatherChickens", 136 },
		{ "FullPoisonEffects", 137 },
		{ "ItemPriceFluctuation", 138 },
		{ "VillagerRoleNickNameMap", 139 },
		{ "VillagerRoleMaxUnlockCounts", 140 },
		{ "BuildingResourceOutputSettings", 141 },
		{ "BlockRecoveryUnlockDates", 142 },
		{ "CharacterConsummateLevelProgresses", 143 },
		{ "TaiwuWantedFirstInteractOrganizationMember", 144 },
		{ "AreaSpiritualDebt", 145 },
		{ "TaiwuProfessions", 146 },
		{ "TaiwuProfessionSkillSlots", 147 },
		{ "CricketPlaceExtraData", 148 },
		{ "BranchMerchantData", 149 },
		{ "CharacterCombatSkillConfigurations", 150 },
		{ "CharacterEquippedCombatSkills", 151 },
		{ "InteractedCharacterList", 152 },
		{ "SectZhujianGearMates", 153 },
		{ "TriggeredAddSeniorityPoints", 154 },
		{ "TaiwuGiftItems", 155 },
		{ "SectZhujianThiefList", 156 },
		{ "CaravanExtraDataDict", 157 },
		{ "ProtectCaravanTime", 158 },
		{ "SectZhujianAreaMerchantTypeDict", 159 },
		{ "MerchantExtraGoods", 160 },
		{ "SectStorySpecialMerchant", 161 },
		{ "IsExtraProfessionSkillUnlocked", 162 },
		{ "IsDirectTraveling", 163 },
		{ "KidnappedTravelData", 164 },
		{ "VillagerLastInfluencePowerGrade", 165 },
		{ "VillagerTreasuryNeeds", 166 },
		{ "CharacterSkillBreakBonuses", 167 },
		{ "CombatSkillProficiencies", 168 },
		{ "SkillBreakPlates", 169 },
		{ "CombatSkillBreakPlateList", 170 },
		{ "SectShaolinDemonSlayerData", 171 },
		{ "KongsangCharacterFeaturePoisonedProb", 172 },
		{ "PickupDict", 173 },
		{ "TaiwuSelectedDebateCardType", 174 },
		{ "VillagerRoleRecords", 175 },
		{ "VillagerRoleAutoActionStates", 176 },
		{ "BuildingArrangementSettingPresetData", 177 },
		{ "BuildingArtisanOrders", 178 },
		{ "TaiwuVillagerPotentialData", 179 },
		{ "NpcArtisanOrders", 180 },
		{ "ShopVillagerQualificationImprove", 181 },
		{ "HasGetShuiHuoYingQiGongSkillBookByArchiveFix", 182 },
		{ "FarmerAutoCollectStorageType", 183 },
		{ "WoodenXiangshuAvatarSelectedFeatures", 184 },
		{ "BuildingAreaEffectProgresses", 185 },
		{ "KilledByYufuCharactersBinary", 186 },
		{ "DyingCharacters", 187 },
		{ "ProficiencyEnoughSkills", 188 },
		{ "SectYuanshanThreeVitals", 189 },
		{ "DreamBackGenealogy", 190 },
		{ "ResourceBlockExtraData", 191 },
		{ "UnlockedFeastTypes", 192 },
		{ "Feasts", 193 },
		{ "SettlementLayeredTreasuries", 194 },
		{ "BuildingDefaultStoreLocation", 195 },
		{ "TaiwuVillageVowOrgTemplateCrossArchiveDict", 196 },
		{ "ChapterJieqingGameState", 197 },
		{ "CurrJieqingGameState", 198 },
		{ "SectJieqingExtraLegacyPoints", 199 },
		{ "SectJieqingNpcExtraLegacyPoints", 200 },
		{ "MainUiCustomButtonList", 201 },
		{ "CustomMapBlockCharInfoList", 202 },
		{ "CustomMapBlockCharButtonList", 203 },
		{ "TaiwuVisitedAreas", 204 },
		{ "JixiData", 205 },
		{ "SectXuannvFavoriteMusicList", 206 },
		{ "SectXuannvPlayerIsPlaying", 207 }
	};

	/// <summary>
	/// 通过数据 ID 获取对应的字段名.
	/// 字段名不一定要与字段的真实名称完全一致, 只要保证正反对应关系就行.
	/// </summary>
	public static readonly string[] DataId2FieldName = new string[208]
	{
		"ExchangedSpecialWeaponList", "CaravanStayDays", "MerchantCharToType", "StationInited", "StoneRoomCharList", "CombatSkillOrderPlans", "AutoWorkBlockIndexList", "AutoSoldBlockIndexList", "SecretInformationBroadcastNotifyList", "XiangshuIdInKungfuPracticeRoom",
		"ReadingEventBookIdList", "ClearedSkillPlateStepInfo", "TravelingEventCollection", "DlcArgBox", "PrevTriggeredTravelingEvents", "GainsInTravel", "LifeSkillCombatCardDict", "LifeSkillCombatUsedCardDict", "LifeSkillCombatReadBookPageDict", "LifeSkillCombatNewCardDict",
		"SecretInformationBroadcastNotifyExtraList", "CharTeammateCommandDict", "NicknameDict", "LegendaryBookBreakPlateCounts", "LegendaryBookWeaponSlot", "LegendaryBookWeaponEffectId", "LegendaryBookSkillSlot", "LegendaryBookSkillEffectId", "LegendaryBookBonusCountYin", "LegendaryBookBonusCountYang",
		"CombatSkillBreakPlateLastClearTimeList", "CombatSkillCurrBreakPlateIndex", "LoveDataDict", "PreviousLoverSet", "ConfessLoveFailedSet", "LoveTokenDataDict", "SavedSouls", "CricketIsSmart", "CricketIsIdentified", "TaiwuInteractionCooldowns",
		"CharacterCustomDisplayNames", "SectMainStoryEventArgBoxes", "VoiceWeaponInnerRatio", "SectXuehouBloodLightLocations", "BrokenAreaMaterials", "SectWudangFairylandData", "TreasureMaterialFailedTimes", "TaiwuMaxNeiliAllocation", "CharacterMasteredCombatSkills", "MasteredCombatSkillPlans",
		"CombatSkillBreakPlateLastForceBreakoutStepsCount", "AutoCheckInComfortableList", "AutoCheckInResidenceList", "LegaciesBuildingTemplateIdList", "IsDreamBack", "AbridgedDreamBackCharacters", "UnlockedWorkingVillagers", "DreamBackLifeRecords", "ActionPointCurrMonth", "AdvancedTeammateCommandDict",
		"ReadInLifeSkillCombatCount", "SectWudangHeavenlyTreeList", "SectWudangLingBaoDark", "SectWudangLingBaoLight", "ShixiangBarbarianMasterIdList", "InformationSettings", "SectXuannvUnlockedMusicList", "SectXuannvPlayerPlayMode", "SectXuannvPlayerMusicId", "SectXuannvPlayerIsEnabled",
		"MirrorCharacters", "SectEmeiBloodLocations", "CharacterPoisonImmunities", "SectXuannvEvaluatedMusicList", "CombatSkillJumpThreshold", "DreamBackUnlockStates", "DreamBackArchiveBackup", "OverwrittenTaiwu", "DreamBackLocationData", "ConflictCombatSkills",
		"CharacterRevealedHobbies", "FinalDateBeforeDreamBack", "DreamBackTaiwu", "ConflictEffectWrappers", "DreamBackGlobalEventArgBox", "DreamBackDlcEventArgBox", "DreamBackSectMainStoryEventArgBox", "DejaVuEventCharacters", "TaiwuAddOneWayRelationCoolDown", "CarrierTamePoint",
		"DreamBackPreviousTaiwuCharIds", "DlcArgBoxes", "JiaoPools", "Jiaos", "ChildrenOfLoong", "FiveLoongDict", "JiaoPoolRecords", "DlcEntries", "JiaoPoolStatus", "ChoosyRemainUpgradeRateDict",
		"ChoosyRemainUpgradeCountDict", "BuildingMoneyPrestigeSuccessRateCompensation", "EmptyToolKey", "SectWuxianWugJugPoisons", "CricketCollectionDataList", "RecruitCharacterDataLists", "SectJingangPossessionCharacters", "CricketExtraAge", "EnemyNestInitializationDates", "SecretInformationShopCharacterData",
		"NextAnimalId", "Animals", "BookStrategiesExpireTime", "UnlockedCombatSkillPlanCount", "ActiveLoopingProgress", "ActiveReadingProgress", "SectRanshanThreeCorpses", "SectBaihuaLifeLinkData", "SamsaraPlatformRecordCollection", "AvailableReadingStrategyMap",
		"ReferenceSkillList", "AvailableQiArtStrategyMap", "LoopingEventSkillIdList", "QiArtStrategyMap", "QiArtStrategyExpireTimeMap", "LoopInLifeSkillCombatCount", "LoopInCombatCount", "MonthlyNotificationSortingGroups", "FollowingNpcList", "FollowingNickNameMap",
		"MerchantOverFavorDataArray", "ChangedTeammateCharIds", "SectFulongOrgMemberChickens", "SectFulongInFlameAreas", "SectFulongOutLaws", "VillagerRoles", "SectFulongLoseFeatherChickens", "FullPoisonEffects", "ItemPriceFluctuation", "VillagerRoleNickNameMap",
		"VillagerRoleMaxUnlockCounts", "BuildingResourceOutputSettings", "BlockRecoveryUnlockDates", "CharacterConsummateLevelProgresses", "TaiwuWantedFirstInteractOrganizationMember", "AreaSpiritualDebt", "TaiwuProfessions", "TaiwuProfessionSkillSlots", "CricketPlaceExtraData", "BranchMerchantData",
		"CharacterCombatSkillConfigurations", "CharacterEquippedCombatSkills", "InteractedCharacterList", "SectZhujianGearMates", "TriggeredAddSeniorityPoints", "TaiwuGiftItems", "SectZhujianThiefList", "CaravanExtraDataDict", "ProtectCaravanTime", "SectZhujianAreaMerchantTypeDict",
		"MerchantExtraGoods", "SectStorySpecialMerchant", "IsExtraProfessionSkillUnlocked", "IsDirectTraveling", "KidnappedTravelData", "VillagerLastInfluencePowerGrade", "VillagerTreasuryNeeds", "CharacterSkillBreakBonuses", "CombatSkillProficiencies", "SkillBreakPlates",
		"CombatSkillBreakPlateList", "SectShaolinDemonSlayerData", "KongsangCharacterFeaturePoisonedProb", "PickupDict", "TaiwuSelectedDebateCardType", "VillagerRoleRecords", "VillagerRoleAutoActionStates", "BuildingArrangementSettingPresetData", "BuildingArtisanOrders", "TaiwuVillagerPotentialData",
		"NpcArtisanOrders", "ShopVillagerQualificationImprove", "HasGetShuiHuoYingQiGongSkillBookByArchiveFix", "FarmerAutoCollectStorageType", "WoodenXiangshuAvatarSelectedFeatures", "BuildingAreaEffectProgresses", "KilledByYufuCharactersBinary", "DyingCharacters", "ProficiencyEnoughSkills", "SectYuanshanThreeVitals",
		"DreamBackGenealogy", "ResourceBlockExtraData", "UnlockedFeastTypes", "Feasts", "SettlementLayeredTreasuries", "BuildingDefaultStoreLocation", "TaiwuVillageVowOrgTemplateCrossArchiveDict", "ChapterJieqingGameState", "CurrJieqingGameState", "SectJieqingExtraLegacyPoints",
		"SectJieqingNpcExtraLegacyPoints", "MainUiCustomButtonList", "CustomMapBlockCharInfoList", "CustomMapBlockCharButtonList", "TaiwuVisitedAreas", "JixiData", "SectXuannvFavoriteMusicList", "SectXuannvPlayerIsPlaying"
	};

	/// <summary>
	/// DataId -&gt; 集合对象内的 FieldId -&gt; FieldName
	/// </summary>
	public static readonly string[][] DataId2ObjectFieldId2FieldName = new string[208][];

	/// <summary>
	/// 通过数据域方法名获取数据域方法 ID
	/// </summary>
	public static readonly Dictionary<string, ushort> MethodName2MethodId = new Dictionary<string, ushort>
	{
		{ "SetCombatSkillOrderPlan", 0 },
		{ "AddLocationMark", 1 },
		{ "RemoveLocationMark", 2 },
		{ "AddReadingEventBookId", 3 },
		{ "RemoveReadingEventBookId", 4 },
		{ "GetAllLifeSkillCombatUsedCard", 5 },
		{ "GetAllLifeSkillCombatCard", 6 },
		{ "SetLifeSkillCombatUsedCard", 7 },
		{ "GetCharacterLifeSkillCombatUsedCard", 8 },
		{ "GetLifeSkillCombatUsedCard", 9 },
		{ "GetAllLifeSkillCombatNewCard", 10 },
		{ "SetLifeSkillCombatCardNotNew", 11 },
		{ "GetCharTeammateCommands", 12 },
		{ "SetLegendaryBookWeaponSlot", 13 },
		{ "SetLegendaryBookSkillSlot", 14 },
		{ "UnlockLegendaryBookBreakPlate", 15 },
		{ "UnlockLegendaryBookBonus", 16 },
		{ "EnterUnlockBreakPlateCombat", 17 },
		{ "ExecuteActiveProfessionSkill", 18 },
		{ "IsProfessionalSkillUnlocked", 19 },
		{ "CanExecuteProfessionSkill", 20 },
		{ "SetProfessionTestSetting", 21 },
		{ "GetCharacterCustomDisplayName", 22 },
		{ "GetTianJieFuLuCount", 23 },
		{ "GmCmd_GenerateTreasure", 24 },
		{ "FindTreasure", 25 },
		{ "CheckSpecialCondition", 26 },
		{ "ConfirmExecuteSkill", 27 },
		{ "FindTreasureExpect", 28 },
		{ "UnlockAllProfessionSkills", 29 },
		{ "SetProfessionSeniorityTarget", 30 },
		{ "GmCmd_Profession_SetBuddhistMonkSavedSoulCount", 31 },
		{ "GmCmd_Profession_SetTempleVisited", 32 },
		{ "InitAiLifeSkillCombatUsedCard", 33 },
		{ "GmCmd_Profession_RecoverHunterCarrierAttackCount", 34 },
		{ "GetBlockMerchantTypes", 35 },
		{ "GetCharacterMasteredCombatSkills", 36 },
		{ "AddCharacterMasteredCombatSkill", 37 },
		{ "RemoveCharacterMasteredCombatSkill", 38 },
		{ "InvokeFindExtraTreasureEvent", 39 },
		{ "SetAdvancedTeammateCommands", 40 },
		{ "CancelAdvancedTeammateCommands", 41 },
		{ "GetAllHeavenlyTrees", 42 },
		{ "GetHeavenlyTreeNearBlocks", 43 },
		{ "GetInformationSettings", 44 },
		{ "GetPoisonImmunities", 45 },
		{ "GetDreamBackTaiwuRelatedCharactersForRelations", 46 },
		{ "GetDreamBackTaiwuGenealogy", 47 },
		{ "GetCharacterDisplayDataListForDreamBackRelations", 48 },
		{ "GetDreamBackLifeRecordByDate", 49 },
		{ "GetNameAndLifeRelatedDataListForDreamBack", 50 },
		{ "IsCharacterHatingItemRevealed", 51 },
		{ "IsCharacterLovingItemRevealed", 52 },
		{ "IsCharacterHobbyRevealed", 53 },
		{ "SetCharacterRevealedHobbies", 54 },
		{ "GetConflictCombatSkill", 55 },
		{ "GetAllDreamBackLifeRecords", 56 },
		{ "GetDreamBackTaiwuBirthAndEndDates", 57 },
		{ "IsCurrentTaiwuOverwrittenByDreamBack", 58 },
		{ "ApplyConflictCombatSkillResult", 59 },
		{ "HaveConflictCombatSkill", 60 },
		{ "AddTaiwuOneWayRelationCoolDown", 61 },
		{ "IsTaiwuAbleToAddOneWayRelation", 62 },
		{ "GetTaiwuAddOneWayRelationCoolDown", 63 },
		{ "FeedCarrier", 64 },
		{ "GetCarrierTamePoint", 65 },
		{ "GetDreamBackCharacterDisplayDataList", 66 },
		{ "GetCarrierMaxTamePoint", 67 },
		{ "GetCurrMaxJiaoPoolCount", 68 },
		{ "GmCmd_FindFiveLoongLocation", 69 },
		{ "GetJiaoPoolBlockStyle", 70 },
		{ "SetJiaoPoolBlockStyle", 71 },
		{ "GetChildrenOfLoongById", 72 },
		{ "GetJiaoPoolList", 73 },
		{ "GetJiaoById", 74 },
		{ "GetJiaoPoolAllJiaoData", 75 },
		{ "PutJiaoInPool", 76 },
		{ "PutAnotherJiaoInPool", 77 },
		{ "PutJiaoOutOfPool", 78 },
		{ "ChangeNurturance", 79 },
		{ "ChangeJiaoName", 80 },
		{ "DisableJiaoPool", 81 },
		{ "EnableJiaoPool", 82 },
		{ "GetJiaoLoongNameRelatedDataList", 83 },
		{ "GetAllJiaoForPool", 84 },
		{ "GetAllJiaoForEvolve", 85 },
		{ "GetJiaoByItemKey", 86 },
		{ "GetJiaosByItemKeys", 87 },
		{ "GetChildrenOfLoongByItemKey", 88 },
		{ "PutEggIntoPool", 89 },
		{ "JiaoPoolInteract", 90 },
		{ "GmCmd_AddJiao", 91 },
		{ "GmCmd_PutJiaoInFirstPool", 92 },
		{ "GmCmd_AddChildOfLoong", 93 },
		{ "JiaoEvolveToChildOfLoong", 94 },
		{ "GetJiaoEvolutionChoice", 95 },
		{ "ResetJiaoPoolStatus", 96 },
		{ "GetAllAdultJiao", 97 },
		{ "GetAllEvolvingJiao", 98 },
		{ "GetJiaoTemplateIdByCarrierTemplateId", 99 },
		{ "CalcResourceChangeByJiaoPool", 100 },
		{ "IsOwnedChildrenOfLoong", 101 },
		{ "GetNextRandomChildrenOfLoong", 102 },
		{ "GmCmd_AddFleeCarrier", 103 },
		{ "GetIsJiaoPoolOpen", 104 },
		{ "FillJiaoRecordArgumentCollection", 105 },
		{ "GetJiaoEvolutionPageStatus", 106 },
		{ "GetIsBabysittingMode", 107 },
		{ "SetIsBabysittingMode", 108 },
		{ "GetFiveLoongDictCount", 109 },
		{ "GetJiaoLoongNameRelatedData", 110 },
		{ "IsJiaoAbleToPet", 111 },
		{ "PetJiao", 112 },
		{ "JiaoPoolPetJiao", 113 },
		{ "GetTaiwuAddOneWayRelationResultCode", 114 },
		{ "RequestRecruitCharacterData", 115 },
		{ "GmCmd_AddThreeCorpses", 116 },
		{ "ApplyRanshanThreeCorpsesLegendaryBookKeepingResult", 117 },
		{ "GetItemListForRanshanTreeCorpsesLegendaryBookKeeping", 118 },
		{ "GmCmd_AddDisplayEventLegendaryBookKeeping", 119 },
		{ "SetRanshanThreeCorpsesCharacterTarget", 120 },
		{ "GetBookStrategiesExpireTime", 121 },
		{ "SetMonthlyNotificationSortingGroup", 122 },
		{ "SetCharTeammateCommandsManual", 123 },
		{ "GetCharAdvancedTeammateCommands", 124 },
		{ "IsStoneRoomFull", 125 },
		{ "ExtinguishFulongInFlameArea", 126 },
		{ "TriggerFulongInFlameAreaMine", 127 },
		{ "ApplyFulongInFlameAreaFullyExtinguished", 128 },
		{ "GmCmd_GenerateFulongFlameArea", 129 },
		{ "HunterSkill_AnimalCharacterToItem", 130 },
		{ "ConfirmProfessionSkillsEquipment", 131 },
		{ "GmCmd_CastTasterUltimateOnCurrentBlock", 132 },
		{ "EatTianJieFuLu", 133 },
		{ "CheckAristocratUltimateSpecialCondition", 134 },
		{ "CheckBeggarUltimateSpecialCondition", 135 },
		{ "CheckTasterUltimateSpecialCondition", 136 },
		{ "GM_GetFriendOrFamilySendGift", 137 },
		{ "GmCmd_CreateGearMate", 138 },
		{ "GetGearMateRepairEffect", 139 },
		{ "RepairGearMate", 140 },
		{ "GetGearMateRepairRequirement", 141 },
		{ "GetGearMateAvailableRepairCount", 142 },
		{ "GetGearMateRepairRequirementDisplayDatas", 143 },
		{ "UpgradeGearMate", 144 },
		{ "GetCharacterConsummateLevelProgress", 145 },
		{ "GetMartialArtistCreateGoodRandomEnemyAndBadRandomEnemyCount", 146 },
		{ "GetGearMateById", 147 },
		{ "CheckSpecialCondition_SavageSkill_1", 148 },
		{ "GetMerchantExtraGoods", 149 },
		{ "SetProfessionExtraSeniority", 150 },
		{ "CanShowProfessionSkillUnlocked", 151 },
		{ "GetGearMateBreakoutCombatSkillBanReasonList", 152 },
		{ "SetDukeSkill3Crickets", 153 },
		{ "GetAllSkillBooksGearMateCanRead", 154 },
		{ "CanIdentifyCricket", 155 },
		{ "CanUpgradeCricket", 156 },
		{ "CanConvertToAnimalCharacter", 157 },
		{ "GetJiaoLoongDisplayDataByItemKey", 158 },
		{ "GmCmd_SetCharacterProficiencies", 159 },
		{ "GmCmd_CreateRandomEnemyAroundHeavenlyTree", 160 },
		{ "GmCmd_ShowUnlockedProfessionSkill", 161 },
		{ "SetVillagerRoleAutoActionState", 162 },
		{ "ChangeBuildingArrangementSettingPresetData", 163 },
		{ "AddMaterialToArtisanOrder", 164 },
		{ "GetArtisanOrderProductionPool", 165 },
		{ "SetArtisanOrderProductionType", 166 },
		{ "SetArtisanOrderStorageType", 167 },
		{ "GetNpcArtisanOrder", 168 },
		{ "InterceptArtisanOrder", 169 },
		{ "GetBuildingArtisanOrder", 170 },
		{ "CreateArtisanOrder", 171 },
		{ "GetProductionPoolPreview", 172 },
		{ "ArtisanOrderDebate", 173 },
		{ "GetArtisanOrderMaterialPreview", 174 },
		{ "GetArtisanOrderCanProduceItemSubType", 175 },
		{ "SetFarmerAutoCollectStorageType", 176 },
		{ "UpdateWoodenXiangshuAvatarSelectedFeatures", 177 },
		{ "GmCmd_GetBuildingAreaEffectProgresses", 178 },
		{ "GmCmd_SetBuildingAreaEffectProgresses", 179 },
		{ "GmCmd_ReleaseAllKilledByLongYufuCharacters", 180 },
		{ "GmCmd_RecordKilledByLongYufuCharacter", 181 },
		{ "GmCmd_VitalInfectionInOut", 182 },
		{ "CheckSpecialCondition_HunterSkill2", 183 },
		{ "GetThreeVitalsCharDataList", 184 },
		{ "GmCmd_InitThreeVitals", 185 },
		{ "GetThreeVitalsTargetCharDataList", 186 },
		{ "TransferInfectionBetweenVitalAndCharacter", 187 },
		{ "SetVitalInPrison", 188 },
		{ "GetBuildingArtisanOrderAfterUpdate", 189 },
		{ "GetCanSelectThreeVitalsDisplayData", 190 },
		{ "AreVitalsDemon", 191 },
		{ "GetOppositeThreeVitalsCharDataList", 192 },
		{ "SetVitalHasPlayedComeAnim", 193 },
		{ "GetResourceBlockProducingCoreCooldown", 194 },
		{ "FeastAddDish", 195 },
		{ "FeastSetAutoRefill", 196 },
		{ "GetFeast", 197 },
		{ "FeastRemoveDish", 198 },
		{ "FeastReceiveGift", 199 },
		{ "AddResourceItemToArtisanOrder", 200 },
		{ "IsFeastException", 201 },
		{ "UseFeastThanksLetter", 202 },
		{ "FeastQuickRefill", 203 },
		{ "FeastSetTargetType", 204 },
		{ "GetSectExtraLegacyBuildingStates", 205 },
		{ "SetJieqingGameData", 206 },
		{ "ConsumeExtraLegacyPoint", 207 },
		{ "IsSectBuiltExtraLegacyBuilding", 208 },
		{ "InitJieqingGameData", 209 },
		{ "RemoveSectExtraLegacyBuilding", 210 },
		{ "BuildExtraLegacyBuilding", 211 },
		{ "GetCharacterExtraLegacyPointWorth", 212 },
		{ "GetExtraLegacyPointCharacterCountOnBlock", 213 },
		{ "GetSectExtraLegacyBuildingCounts", 214 },
		{ "SaveMainUiCustomButtons", 215 },
		{ "SetMapBlockCharCustomInfoList", 216 },
		{ "SetMapBlockCharCustomButtonList", 217 },
		{ "GetAreaCharacterJieQingSignAmount", 218 },
		{ "CheckLocationHasBeggerSkill1", 219 },
		{ "SetJixiDrainNeili", 220 },
		{ "SetJixiTarget", 221 },
		{ "TaiwuTransferNeiliAllocToJixi", 222 },
		{ "JixiTransferNeiliAllocToTaiwu", 223 },
		{ "SetJixiDrainType", 224 },
		{ "GetJixiSpecialInteractDisplayData", 225 },
		{ "InitJixiSpecialInteractData", 226 },
		{ "JixiRescueTaiwu", 227 },
		{ "GetCharacterExtraLegacyPointWorthCalculated", 228 },
		{ "GetSectRanshanThreeCorpsesData", 229 },
		{ "SetTaiwuTransformFiveElementsTarget", 230 },
		{ "SetTaiwuTargetFiveElementsType", 231 },
		{ "GetSectYuanshanThreeVitalsData", 232 },
		{ "RequestAllRecruitCharacterData", 233 },
		{ "GetTipLegendaryBookDisplayData", 234 },
		{ "GetSectMembersWorthExtraLegacyPoint", 235 },
		{ "GetCharacterExtraLegacyPointWorthForMapBlock", 236 },
		{ "GmCmd_SetSectMainStoryArgBoxInt", 237 },
		{ "GmCmd_GetSectMainStoryArgBoxBool", 238 },
		{ "GmCmd_GetSectMainStoryArgBoxInt", 239 },
		{ "GmCmd_SetSectMainStoryArgBoxBool", 240 }
	};

	public static readonly string[] MethodId2MethodName = new string[241]
	{
		"SetCombatSkillOrderPlan", "AddLocationMark", "RemoveLocationMark", "AddReadingEventBookId", "RemoveReadingEventBookId", "GetAllLifeSkillCombatUsedCard", "GetAllLifeSkillCombatCard", "SetLifeSkillCombatUsedCard", "GetCharacterLifeSkillCombatUsedCard", "GetLifeSkillCombatUsedCard",
		"GetAllLifeSkillCombatNewCard", "SetLifeSkillCombatCardNotNew", "GetCharTeammateCommands", "SetLegendaryBookWeaponSlot", "SetLegendaryBookSkillSlot", "UnlockLegendaryBookBreakPlate", "UnlockLegendaryBookBonus", "EnterUnlockBreakPlateCombat", "ExecuteActiveProfessionSkill", "IsProfessionalSkillUnlocked",
		"CanExecuteProfessionSkill", "SetProfessionTestSetting", "GetCharacterCustomDisplayName", "GetTianJieFuLuCount", "GmCmd_GenerateTreasure", "FindTreasure", "CheckSpecialCondition", "ConfirmExecuteSkill", "FindTreasureExpect", "UnlockAllProfessionSkills",
		"SetProfessionSeniorityTarget", "GmCmd_Profession_SetBuddhistMonkSavedSoulCount", "GmCmd_Profession_SetTempleVisited", "InitAiLifeSkillCombatUsedCard", "GmCmd_Profession_RecoverHunterCarrierAttackCount", "GetBlockMerchantTypes", "GetCharacterMasteredCombatSkills", "AddCharacterMasteredCombatSkill", "RemoveCharacterMasteredCombatSkill", "InvokeFindExtraTreasureEvent",
		"SetAdvancedTeammateCommands", "CancelAdvancedTeammateCommands", "GetAllHeavenlyTrees", "GetHeavenlyTreeNearBlocks", "GetInformationSettings", "GetPoisonImmunities", "GetDreamBackTaiwuRelatedCharactersForRelations", "GetDreamBackTaiwuGenealogy", "GetCharacterDisplayDataListForDreamBackRelations", "GetDreamBackLifeRecordByDate",
		"GetNameAndLifeRelatedDataListForDreamBack", "IsCharacterHatingItemRevealed", "IsCharacterLovingItemRevealed", "IsCharacterHobbyRevealed", "SetCharacterRevealedHobbies", "GetConflictCombatSkill", "GetAllDreamBackLifeRecords", "GetDreamBackTaiwuBirthAndEndDates", "IsCurrentTaiwuOverwrittenByDreamBack", "ApplyConflictCombatSkillResult",
		"HaveConflictCombatSkill", "AddTaiwuOneWayRelationCoolDown", "IsTaiwuAbleToAddOneWayRelation", "GetTaiwuAddOneWayRelationCoolDown", "FeedCarrier", "GetCarrierTamePoint", "GetDreamBackCharacterDisplayDataList", "GetCarrierMaxTamePoint", "GetCurrMaxJiaoPoolCount", "GmCmd_FindFiveLoongLocation",
		"GetJiaoPoolBlockStyle", "SetJiaoPoolBlockStyle", "GetChildrenOfLoongById", "GetJiaoPoolList", "GetJiaoById", "GetJiaoPoolAllJiaoData", "PutJiaoInPool", "PutAnotherJiaoInPool", "PutJiaoOutOfPool", "ChangeNurturance",
		"ChangeJiaoName", "DisableJiaoPool", "EnableJiaoPool", "GetJiaoLoongNameRelatedDataList", "GetAllJiaoForPool", "GetAllJiaoForEvolve", "GetJiaoByItemKey", "GetJiaosByItemKeys", "GetChildrenOfLoongByItemKey", "PutEggIntoPool",
		"JiaoPoolInteract", "GmCmd_AddJiao", "GmCmd_PutJiaoInFirstPool", "GmCmd_AddChildOfLoong", "JiaoEvolveToChildOfLoong", "GetJiaoEvolutionChoice", "ResetJiaoPoolStatus", "GetAllAdultJiao", "GetAllEvolvingJiao", "GetJiaoTemplateIdByCarrierTemplateId",
		"CalcResourceChangeByJiaoPool", "IsOwnedChildrenOfLoong", "GetNextRandomChildrenOfLoong", "GmCmd_AddFleeCarrier", "GetIsJiaoPoolOpen", "FillJiaoRecordArgumentCollection", "GetJiaoEvolutionPageStatus", "GetIsBabysittingMode", "SetIsBabysittingMode", "GetFiveLoongDictCount",
		"GetJiaoLoongNameRelatedData", "IsJiaoAbleToPet", "PetJiao", "JiaoPoolPetJiao", "GetTaiwuAddOneWayRelationResultCode", "RequestRecruitCharacterData", "GmCmd_AddThreeCorpses", "ApplyRanshanThreeCorpsesLegendaryBookKeepingResult", "GetItemListForRanshanTreeCorpsesLegendaryBookKeeping", "GmCmd_AddDisplayEventLegendaryBookKeeping",
		"SetRanshanThreeCorpsesCharacterTarget", "GetBookStrategiesExpireTime", "SetMonthlyNotificationSortingGroup", "SetCharTeammateCommandsManual", "GetCharAdvancedTeammateCommands", "IsStoneRoomFull", "ExtinguishFulongInFlameArea", "TriggerFulongInFlameAreaMine", "ApplyFulongInFlameAreaFullyExtinguished", "GmCmd_GenerateFulongFlameArea",
		"HunterSkill_AnimalCharacterToItem", "ConfirmProfessionSkillsEquipment", "GmCmd_CastTasterUltimateOnCurrentBlock", "EatTianJieFuLu", "CheckAristocratUltimateSpecialCondition", "CheckBeggarUltimateSpecialCondition", "CheckTasterUltimateSpecialCondition", "GM_GetFriendOrFamilySendGift", "GmCmd_CreateGearMate", "GetGearMateRepairEffect",
		"RepairGearMate", "GetGearMateRepairRequirement", "GetGearMateAvailableRepairCount", "GetGearMateRepairRequirementDisplayDatas", "UpgradeGearMate", "GetCharacterConsummateLevelProgress", "GetMartialArtistCreateGoodRandomEnemyAndBadRandomEnemyCount", "GetGearMateById", "CheckSpecialCondition_SavageSkill_1", "GetMerchantExtraGoods",
		"SetProfessionExtraSeniority", "CanShowProfessionSkillUnlocked", "GetGearMateBreakoutCombatSkillBanReasonList", "SetDukeSkill3Crickets", "GetAllSkillBooksGearMateCanRead", "CanIdentifyCricket", "CanUpgradeCricket", "CanConvertToAnimalCharacter", "GetJiaoLoongDisplayDataByItemKey", "GmCmd_SetCharacterProficiencies",
		"GmCmd_CreateRandomEnemyAroundHeavenlyTree", "GmCmd_ShowUnlockedProfessionSkill", "SetVillagerRoleAutoActionState", "ChangeBuildingArrangementSettingPresetData", "AddMaterialToArtisanOrder", "GetArtisanOrderProductionPool", "SetArtisanOrderProductionType", "SetArtisanOrderStorageType", "GetNpcArtisanOrder", "InterceptArtisanOrder",
		"GetBuildingArtisanOrder", "CreateArtisanOrder", "GetProductionPoolPreview", "ArtisanOrderDebate", "GetArtisanOrderMaterialPreview", "GetArtisanOrderCanProduceItemSubType", "SetFarmerAutoCollectStorageType", "UpdateWoodenXiangshuAvatarSelectedFeatures", "GmCmd_GetBuildingAreaEffectProgresses", "GmCmd_SetBuildingAreaEffectProgresses",
		"GmCmd_ReleaseAllKilledByLongYufuCharacters", "GmCmd_RecordKilledByLongYufuCharacter", "GmCmd_VitalInfectionInOut", "CheckSpecialCondition_HunterSkill2", "GetThreeVitalsCharDataList", "GmCmd_InitThreeVitals", "GetThreeVitalsTargetCharDataList", "TransferInfectionBetweenVitalAndCharacter", "SetVitalInPrison", "GetBuildingArtisanOrderAfterUpdate",
		"GetCanSelectThreeVitalsDisplayData", "AreVitalsDemon", "GetOppositeThreeVitalsCharDataList", "SetVitalHasPlayedComeAnim", "GetResourceBlockProducingCoreCooldown", "FeastAddDish", "FeastSetAutoRefill", "GetFeast", "FeastRemoveDish", "FeastReceiveGift",
		"AddResourceItemToArtisanOrder", "IsFeastException", "UseFeastThanksLetter", "FeastQuickRefill", "FeastSetTargetType", "GetSectExtraLegacyBuildingStates", "SetJieqingGameData", "ConsumeExtraLegacyPoint", "IsSectBuiltExtraLegacyBuilding", "InitJieqingGameData",
		"RemoveSectExtraLegacyBuilding", "BuildExtraLegacyBuilding", "GetCharacterExtraLegacyPointWorth", "GetExtraLegacyPointCharacterCountOnBlock", "GetSectExtraLegacyBuildingCounts", "SaveMainUiCustomButtons", "SetMapBlockCharCustomInfoList", "SetMapBlockCharCustomButtonList", "GetAreaCharacterJieQingSignAmount", "CheckLocationHasBeggerSkill1",
		"SetJixiDrainNeili", "SetJixiTarget", "TaiwuTransferNeiliAllocToJixi", "JixiTransferNeiliAllocToTaiwu", "SetJixiDrainType", "GetJixiSpecialInteractDisplayData", "InitJixiSpecialInteractData", "JixiRescueTaiwu", "GetCharacterExtraLegacyPointWorthCalculated", "GetSectRanshanThreeCorpsesData",
		"SetTaiwuTransformFiveElementsTarget", "SetTaiwuTargetFiveElementsType", "GetSectYuanshanThreeVitalsData", "RequestAllRecruitCharacterData", "GetTipLegendaryBookDisplayData", "GetSectMembersWorthExtraLegacyPoint", "GetCharacterExtraLegacyPointWorthForMapBlock", "GmCmd_SetSectMainStoryArgBoxInt", "GmCmd_GetSectMainStoryArgBoxBool", "GmCmd_GetSectMainStoryArgBoxInt",
		"GmCmd_SetSectMainStoryArgBoxBool"
	};
}

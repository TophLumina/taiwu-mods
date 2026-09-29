using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventFunction : ConfigData<EventFunctionItem, int>
{
	public static class DefKey
	{
		public const int If = 0;

		public const int Else = 1;

		public const int ElseIf = 2;

		public const int Loop = 3;

		public const int Break = 4;

		public const int End = 5;

		public const int Continue = 6;

		public const int Label = 7;

		public const int Jump = 8;

		public const int Return = 9;

		public const int Assign = 10;

		public const int Random = 11;

		public const int CheckProb = 12;

		public const int GetRandomUnrepeated = 767;

		public const int EventTransition = 13;

		public const int OptionInjection = 94;

		public const int InjectAllOptions = 420;

		public const int ExecuteGlobalScript = 91;

		public const int SaveSectMainStoryValue = 101;

		public const int ReadSectMainStoryValue = 102;

		public const int SaveGlobalValue = 485;

		public const int ReadGlobalValue = 486;

		public const int SaveDlcValue = 903;

		public const int ReadDlcValue = 904;

		public const int GetListLength = 215;

		public const int GetListElement = 216;

		public const int GetLocalLanguageString = 568;

		public const int SetListenerWithActionName = 640;

		public const int Log = 14;

		public const int Comment = 15;

		public const int PlayAudio = 16;

		public const int PerformCutscene = 482;

		public const int SetEventCgTexture = 611;

		public const int SetEventCgTextureByName = 614;

		public const int ShowEventCgTextureInPictureShowPage = 680;

		public const int PlayTutorialVideo = 603;

		public const int BackToTutorialChapterMenu = 637;

		public const int BackToMainMenu = 661;

		public const int ScreenShake = 17;

		public const int SpecifyEventBackground = 197;

		public const int BlackMask = 483;

		public const int SetObtainPopupEnabled = 829;

		public const int CloseCharacterMenu = 832;

		public const int OpenEmeiCombatSkillSpecialBreak = 187;

		public const int SpecifyCurrMainAttribute = 18;

		public const int ChangeCurrMainAttribute = 19;

		public const int SpecifyInjury = 20;

		public const int ChangeInjury = 21;

		public const int ClearInjuries = 22;

		public const int SpecifyPoisoned = 23;

		public const int ChangePoisoned = 24;

		public const int ClearPoisons = 25;

		public const int SpecifyDisorderOfQi = 26;

		public const int ChangeDisorderOfQi = 27;

		public const int SpecifyHealth = 28;

		public const int ChangeHealth = 29;

		public const int SpecifyHappiness = 30;

		public const int ChangeHappiness = 31;

		public const int GetHappiness = 570;

		public const int SpecifyFavorabilities = 32;

		public const int ChangeFavorability = 33;

		public const int AddFeature = 34;

		public const int RemoveFeature = 35;

		public const int AddKidnappedCharacter = 36;

		public const int RemoveKidnappedCharacter = 37;

		public const int AddTaiwuPropertyPermanentBonus = 585;

		public const int JoinGroup = 38;

		public const int LeaveGroup = 39;

		public const int KillCharacter = 40;

		public const int TakeRandomDamage = 189;

		public const int AddInventoryItem = 41;

		public const int RemoveInventoryItem = 65;

		public const int TransferInventoryItem = 42;

		public const int AddWarehouseItem = 744;

		public const int SpecifyCharacterResource = 129;

		public const int ChangeCharacterResource = 66;

		public const int GetCharacterResource = 679;

		public const int TransferCharacterResource = 130;

		public const int ChangeCharBaseCombatSkillQualification = 43;

		public const int ChangeCharBaseLifeSkillQualification = 44;

		public const int SpecifyBaseCombatSkillQualification = 789;

		public const int SpecifyBaseLifeSkillQualification = 790;

		public const int LearnCombatSkill = 45;

		public const int LearnLifeSkill = 46;

		public const int AddLegacyPoint = 47;

		public const int ExpelTaiwuVillager = 48;

		public const int MakeAppointment = 49;

		public const int RemoveAppointment = 50;

		public const int AdvanceDays = 51;

		public const int ChangeMainStoryLineProgress = 52;

		public const int SetWorldFunctionsStatus = 53;

		public const int ResetWorldFunctionStatus = 849;

		public const int ChangeSpiritualDebt = 54;

		public const int ChangeSettlementSafety = 55;

		public const int ChangeSettlementCulture = 56;

		public const int GetSettlementLeader = 860;

		public const int SetBlockAndViewRangeVisible = 57;

		public const int SetSectAllowLearning = 58;

		public const int SetSectFunctionStatus = 325;

		public const int JoinOrganization = 59;

		public const int SetSectCharApprovedTaiwu = 60;

		public const int SetSectSpiritualDebtInteractionOccurred = 226;

		public const int ChangeMerchantFavorability = 61;

		public const int CreateItem = 62;

		public const int CreateCricket = 63;

		public const int CreateCricketByGrade = 836;

		public const int CreateCombatSkillBook = 556;

		public const int ReadAllBookPages = 558;

		public const int SetEquipmentEffectId = 408;

		public const int GetCharacterFavorability = 111;

		public const int GetCharacterBehaviorType = 566;

		public const int SetCharCombatSkillPracticeLevel = 64;

		public const int CreateAdventureSite = 67;

		public const int CreateConfigMonthlyAction = 145;

		public const int CreateEnemyCharacter = 92;

		public const int CreateEventActor = 93;

		public const int SetEventActor = 940;

		public const int GetFixedCharacter = 99;

		public const int GetIntelligentCharacterByFilter = 114;

		public const int MoveCharacter = 100;

		public const int StartCombat = 89;

		public const int StartNpcCombat = 778;

		public const int StartCombatWithSpecialTeammate = 841;

		public const int TriggerExtraTask = 68;

		public const int FinishExtraTask = 69;

		public const int FinishExtraTaskChain = 70;

		public const int TriggerSectMainStoryEndingCountDown = 115;

		public const int SetSectMainStoryEnding = 116;

		public const int GetTemplateIdOfFixedCharacterCombatWith = 113;

		public const int SetCharacterFollowTaiwu = 117;

		public const int CancelCharacterFollowTaiwu = 120;

		public const int StartLifeSkillCombat = 118;

		public const int ExitAdventure = 124;

		public const int GetAdventureCharacter = 143;

		public const int GetAdventureCharacterCount = 144;

		public const int FinishAdventureEvent = 125;

		public const int SelectAdventureBranch = 126;

		public const int GenerateAdventureMap = 119;

		public const int GetRandomInventoryItem = 440;

		public const int GetInventoryItem = 850;

		public const int CheckInventoryItem = 702;

		public const int GetStealActionPhase = 441;

		public const int GetPoisonActionPhase = 540;

		public const int GetPlotHarmActionPhase = 541;

		public const int HandlePoisonAction = 542;

		public const int HandlePlotHarmAction = 543;

		public const int CheckHarmfulActionPhase = 442;

		public const int FilterCharacterItem = 127;

		public const int FilterMapBlockInRange = 167;

		public const int FilterMapBlockOnEdge = 698;

		public const int RegisterToSelectItemSubTypes = 132;

		public const int RegisterToSelectItemTemplateIds = 133;

		public const int RegisterToExcludeItemTemplateIds = 134;

		public const int RegisterToSelectItemGrade = 534;

		public const int RegisterToSelectItemGroup = 559;

		public const int RegisterToSelectItemResourceType = 703;

		public const int RegisterToExcludeItemResourceType = 704;

		public const int FilterCharacterItemByRegister = 135;

		public const int CharacterTeachTaiwuProfession = 147;

		public const int RegisterSettlementMemberFeature = 227;

		public const int AddBuilding = 149;

		public const int SectStoryZhujianCreateCatchableThief = 139;

		public const int SectStoryZhujianCreateGearMate = 150;

		public const int SectStoryZhujianAddAreaMerchantType = 151;

		public const int SectStoryZhujianRemoveAreaMerchantType = 152;

		public const int SectStoryEmeiSetMemberInsaneState = 188;

		public const int GetMapBlockSettlement = 243;

		public const int GetOtherSmallSettlement = 154;

		public const int GetSectSettlement = 481;

		public const int GetRandomSettlementInState = 192;

		public const int GetSettlementListInState = 217;

		public const int GetCharacterCurrentMapBlock = 198;

		public const int GetCharacterSettlement = 263;

		public const int GetSettlementMapBlock = 199;

		public const int GetCharacterCurrentMapArea = 261;

		public const int GetSettlementMapArea = 262;

		public const int CreateMerchantRandomItem = 153;

		public const int GetCurrentEvent = 437;

		public const int TriggerLegacyPassingEvent = 156;

		public const int StartSetCharacterGivenName = 164;

		public const int FinishSetCharacterGivenName = 165;

		public const int CheckExpression = 71;

		public const int CheckAnd = 109;

		public const int CheckOr = 110;

		public const int CheckListElement = 218;

		public const int CheckWorldFunctionStatus = 155;

		public const int CheckMainStoryProgress = 72;

		public const int CheckGlobalArgBox = 423;

		public const int CheckDlcArgBox = 907;

		public const int CheckTask = 73;

		public const int CheckTaskFinished = 586;

		public const int CheckTaskChain = 74;

		public const int CheckXiangshuLevel = 75;

		public const int CheckFixedCharacterTemplate = 128;

		public const int TryGetFixedCharacter = 515;

		public const int CheckCharacterCurrMainAttribute = 76;

		public const int CheckCharacterMainAttribute = 77;

		public const int CheckCharacterLifeSkillQualification = 78;

		public const int CheckCharacterLifeSkillAttainment = 79;

		public const int CheckCharacterCombatSkillQualification = 80;

		public const int CheckCharacterCombatSkillAttainment = 81;

		public const int GetCharacterCombatSkillAttainment = 577;

		public const int CheckCharacterPersonality = 82;

		public const int CheckCharacterBehaviorType = 107;

		public const int CheckCharacterMorality = 108;

		public const int ChangeCharacterMorality = 571;

		public const int SetCharacterBehaviorType = 572;

		public const int CheckCharacterCurrAge = 160;

		public const int CheckCharacterActualAge = 161;

		public const int CheckCharacterAgeGroup = 162;

		public const int CheckCharacterGender = 203;

		public const int CheckCharacterResource = 83;

		public const int CheckCharacterFeature = 84;

		public const int CheckCharacterCurrentProfession = 140;

		public const int CheckCharacterSeniorityPercent = 141;

		public const int CheckCharacterInventoryByTemplate = 85;

		public const int CheckCharacterOnSettlementBlock = 86;

		public const int CheckCharacterInSettlementInfluenceRange = 87;

		public const int CheckCharacterInMapState = 95;

		public const int CheckCharacterInMapArea = 96;

		public const int CheckCharacterInBrokenArea = 520;

		public const int CheckCharacterInMapBlockRange = 168;

		public const int CheckCharacterOnMapBlockTemplate = 638;

		public const int CheckCharacterOnAnySettlement = 97;

		public const int CheckCharacterInAnySettlementInfluenceRange = 98;

		public const int CheckCharacterInSettlementArea = 194;

		public const int CheckCharacterFavorability = 88;

		public const int CheckCharacterFavorabilityType = 142;

		public const int CheckCharacterGrade = 103;

		public const int GetCharacterGrade = 573;

		public const int CheckCharacterSettlement = 104;

		public const int CheckCharacterHasItem = 121;

		public const int CheckCharacterMerchantType = 122;

		public const int CheckCharacterReadLifeSkillPageCount = 131;

		public const int CheckCharacterNeiliTypeConflictCombatSkill = 567;

		public const int CheckPreviousCombatResult = 90;

		public const int CheckPreviousCombatType = 473;

		public const int CheckSectFunctionStatus = 326;

		public const int CheckSectCanTeach = 674;

		public const int CheckSettlementInMapState = 105;

		public const int CheckSettlementInMapArea = 106;

		public const int CheckSettlementTreasuryAlertTime = 768;

		public const int CheckAreaSpiritualDebt = 112;

		public const int CheckAreaHasAdventure = 204;

		public const int CheckAreaHasMajorEvent = 787;

		public const int CheckAreaHasAdultGraveOfTargetOrganization = 517;

		public const int CheckSectMainStoryValueExists = 123;

		public const int CheckMapBlockByMatcher = 769;

		public const int CheckItemType = 136;

		public const int CheckItemSubType = 137;

		public const int CheckItemTemplate = 138;

		public const int TryGetCharacterCurrentProfession = 146;

		public const int CheckCharacterPassMatcher = 213;

		public const int CheckCharacterCanTeachTaiwuProfession = 148;

		public const int CheckCharacterCanTeachTaiwuProfessionSkillUnlock = 163;

		public const int CheckCharacterConsummateLevel = 157;

		public const int CheckIsDreamBack = 158;

		public const int CheckCharacterAlive = 159;

		public const int CheckCharacterOnValidLocation = 516;

		public const int CheckCharacterIntelligent = 716;

		public const int CreateFixedSkillBook = 166;

		public const int CheckAdventureParameterCount = 169;

		public const int CheckCurrentAdventure = 421;

		public const int CheckMovePoint = 170;

		public const int ChangeActionPoint = 717;

		public const int CheckCurrMonth = 171;

		public const int CheckCharacterKidnapSpecificGender = 172;

		public const int CheckCharacterKidnapSpecificAgeGroup = 173;

		public const int CheckCharacterKidnapSpecificId = 174;

		public const int CheckCharacterTeammateSpecificIdGender = 175;

		public const int CheckCharacterTeammateSpecificIdAgeGroup = 176;

		public const int CheckCharacterTeammateSpecificIdId = 177;

		public const int CheckCharacterExp = 178;

		public const int CheckCharacterReadCombatSkillPageCount = 179;

		public const int CheckCharacterCombatSkillBreakout = 180;

		public const int CheckSettlementApprovingRate = 190;

		public const int AddMaxApprovingRateBonus = 535;

		public const int CheckSettlementApprovingRateUpperLimit = 560;

		public const int CheckStateHasSettlementType = 193;

		public const int CheckAdventureTemplate = 202;

		public const int CheckAdventurePerMoveCount = 181;

		public const int CheckAdventurePerCostMovePoint = 182;

		public const int CheckAdventureElementVisible = 183;

		public const int SwitchEmeiBlood = 184;

		public const int CheckAdventureCharacterGroup = 185;

		public const int CheckAdventureElementGroup = 186;

		public const int GetCharacterConsummateLevel = 191;

		public const int OpenYuanshanMiniGame = 195;

		public const int ProcessYuanshanMiniGameResults = 196;

		public const int SpecifyXiangshuInfectionValue = 200;

		public const int ChangeXiangshuInfectionValue = 201;

		public const int SetCharacterMarriageStyleOne = 205;

		public const int SetCharacterMarriageStyleTwo = 206;

		public const int IsVitalInPrison = 207;

		public const int SetVitalInPrison = 208;

		public const int PlayVitalAnim = 209;

		public const int GetCharacterBySettlementGradeAndAge = 210;

		public const int AreVitalsDemon = 211;

		public const int GetCurrentVitalIndex = 212;

		public const int InitThreeVitals = 214;

		public const int CheckAdventureParameter = 219;

		public const int SetAdventureParameter = 220;

		public const int ChangeAdventureParameter = 221;

		public const int CheckAdventureParameterStartWith = 222;

		public const int SetAdventureParameterStartWith = 223;

		public const int ChangeAdventureParameterStartWith = 224;

		public const int AdventureCheckProb = 225;

		public const int CheckAdventureElementCount = 228;

		public const int CheckAdventureElementTagCount = 229;

		public const int GetAdventureElementTagCount = 372;

		public const int CheckAdventureParameterIsMax = 230;

		public const int CheckAdventureParameterIsMin = 231;

		public const int CheckAdventureElementInElement = 232;

		public const int CheckAdventureTaiwuInElement = 233;

		public const int CheckAdventureTaiwuInBlockGroup = 234;

		public const int AdventureCreateItem = 235;

		public const int AdventureRemoveItem = 236;

		public const int AdventureConsumeItem = 474;

		public const int AdventureCheckUseItem = 237;

		public const int AddJieqingMaskCharId = 238;

		public const int RemoveJieqingMaskCharId = 239;

		public const int AdventureSetAutoDeleteDate = 240;

		public const int AdventureExit = 241;

		public const int AdventureExitNotReset = 687;

		public const int AdventureCreateAndEnter = 718;

		public const int AdventureExitResetCharacterState = 688;

		public const int AdventureExitResetElementParameter = 689;

		public const int AdventureExitResetElementBlockIndex = 690;

		public const int AdventureExitInterruptAllActions = 691;

		public const int AdventureExitResetTaiwuBuff = 692;

		public const int DestroyEnemyNest = 242;

		public const int SectMainStoryUnlockUI = 244;

		public const int CheckAdventureElementVisibleWithTag = 245;

		public const int CheckAdventureElementGroupWithTag = 246;

		public const int CheckAdventureElementInElementWithTag = 247;

		public const int CheckAdventureTaiwuInElementWithTag = 248;

		public const int GetCurrentFaith = 249;

		public const int GetFaithLevel = 250;

		public const int GetFuyuFaithTime = 251;

		public const int OpenFuyuFaithPanel = 252;

		public const int OpenFuyuGiftPanel = 253;

		public const int ApplyFuyuFaith = 254;

		public const int ReadSelectResultCount = 255;

		public const int TryGetMaxAcceptableFuyuFaith = 256;

		public const int CheckTaiwuHasFuyuFaith = 257;

		public const int CheckCharacterFuyuFaith = 258;

		public const int AdventureElementFillByGroup = 259;

		public const int AdventureElementFillByElement = 260;

		public const int AdventureDelete = 264;

		public const int AdventureDeleteNew = 811;

		public const int CheckAdventureElementParameter = 265;

		public const int SetAdventureElementParameter = 266;

		public const int ChangeAdventureElementParameter = 267;

		public const int AdventureChangeElementCountAtTaiwuLocation = 268;

		public const int AdventureChangeElementCountAtTaiwuLocationBig = 774;

		public const int AdventureClearElementAtTaiwuLocation = 269;

		public const int AdventureClearElement = 270;

		public const int AdventureDeleteElement = 271;

		public const int AdventureDeleteElementByElement = 272;

		public const int AdventureDeleteElementByElementGroup = 273;

		public const int CheckAdventureElementHaveElement = 274;

		public const int GetMovePointValue = 275;

		public const int CheckAdventureElementCombatPowerIsMax = 276;

		public const int AdventureElementSimulateCombat = 277;

		public const int AdventureCheckHasItem = 278;

		public const int AdventureSaveElementCharacterId = 279;

		public const int AdventureCreateElementRandom = 280;

		public const int AdventureTaiwuRandomMove = 281;

		public const int AdventureDeleteCurrElement = 282;

		public const int AdventurePlayDeleteElementAnim = 484;

		public const int ClearDisorderOfQi = 283;

		public const int RecoverHealth = 284;

		public const int AdventureSaveElementTimeCosted = 285;

		public const int AdventureCheckIsSpecifyElement = 286;

		public const int AdventureGetParameterValue = 287;

		public const int AdventureGetElementParameterValue = 288;

		public const int AdventureGetItemCount = 289;

		public const int AdventureCompareCombatPowerWithElementAtSameBlock = 290;

		public const int AdventureCompareCombatPowerWithElementTagAtSameBlock = 291;

		public const int AdventureCompareCombatPowerWithElement = 292;

		public const int AdventureCompareCombatPowerWithElementTag = 293;

		public const int AdventureCheckElementSameLocation = 294;

		public const int AdventureCheckElementSameLocationWithTag = 295;

		public const int AdventureCheckTwoElementSameLocation = 598;

		public const int AdventureCheckIsSpecifyTagElement = 296;

		public const int AdventureChangeElementCount = 297;

		public const int CheckJieQingInteractUnlock = 298;

		public const int JieQingInteractConfirmKill = 299;

		public const int CharacterStarFortuneEnough = 300;

		public const int AdventureSaveElementById = 301;

		public const int AdventureSaveElementByTag = 302;

		public const int AdventureSaveElementByTagGlobal = 303;

		public const int MajorEventExitAndDelete = 304;

		public const int MajorEventExitAndDeleteAndInvokeOther = 374;

		public const int MajorEventExitAndDeleteNew = 812;

		public const int MajorEventSetSkipFinishAnim = 856;

		public const int AdventureSetTaiwuViewType = 305;

		public const int AdventureCheckViewType = 306;

		public const int AdventureCheckElementInRange = 307;

		public const int AdventureCheckElementInRangeWithTag = 308;

		public const int AdventureCreateElementAtGroup = 309;

		public const int AdventureCreateElementInheritCharacter = 310;

		public const int AdventureParameterStartProgress = 311;

		public const int AdventureElementParameterStartProgress = 312;

		public const int AdventureElementMoveToTaiwuNearby = 313;

		public const int AdventureGetElementCountInRange = 314;

		public const int CharacterGetAvailableEatingSlotsCount = 315;

		public const int CheckCharacterAvailableEatingSlotsCount = 578;

		public const int CharacterAddEatingItem = 316;

		public const int ClearCharacterEatingItemByIndex = 809;

		public const int ClearCharacterEatingItem = 810;

		public const int MedicineExtraAddPercent = 544;

		public const int CharacterChangeCurrNeili = 317;

		public const int CharacterSetCurrNeili = 318;

		public const int CharacterCheckNeiliType = 319;

		public const int GetRandomItemTemplateByGrade = 320;

		public const int ItemAddPoisonRandom = 321;

		public const int CharacterHaveInjury = 322;

		public const int CharacterHavePoison = 323;

		public const int TaiwuHealCharacter = 324;

		public const int RandomSuccessorActive = 327;

		public const int GetSectMainStoryEnding = 328;

		public const int OpenModifyBook = 329;

		public const int GetSectMapBlock = 330;

		public const int CheckWuxianWugJugPoison = 331;

		public const int GetCurrDate = 332;

		public const int StartShavingAction = 333;

		public const int AdventureElementParameterStartProgressWithTag = 334;

		public const int RemoveInventoryItemByTemplateId = 335;

		public const int SelectFilterCharacterAgeGroup = 336;

		public const int CheckAdventureElementInProgress = 337;

		public const int AdventureElementSimulateCombatWithTag = 338;

		public const int CheckPreviousSimulateCombatResult = 339;

		public const int AdventureCreateElementAtGroupWithTag = 340;

		public const int CheckSectMainStoryEnding = 341;

		public const int GetTaiwuGroupList = 342;

		public const int CreateIntList = 343;

		public const int AddToIntList = 344;

		public const int SelectCharacter = 345;

		public const int SelectCharacterWithFilter = 621;

		public const int CheckAdventureElementInTaiwuBigBlockWithTag = 346;

		public const int CheckAdventureElementInBigBlockWithTag = 347;

		public const int CheckItemValid = 348;

		public const int CheckAdventureElementParameterInProgress = 349;

		public const int CheckGotoOutterWorldCoolDown = 350;

		public const int AdventureGetElementDistanceToTaiwu = 351;

		public const int AdventureCheckViewTypeToElement = 352;

		public const int MajorEventCreate = 353;

		public const int MajorEventCreateAndEnter = 780;

		public const int GetSettlementRandomMapBlock = 354;

		public const int SetBlackSnakeName = 355;

		public const int AdventureParameterStopProgress = 356;

		public const int AdventureElementParameterStopProgress = 357;

		public const int AdventureCheckElementDistanceToGroupBlock = 358;

		public const int ReduceRandomDamage = 359;

		public const int EditCharBaseNeiliProportionOfFiveElements = 360;

		public const int GetCharacterFiveElements = 782;

		public const int AdventureCheckElementAtResetTarget = 361;

		public const int GetJixiCharacter = 362;

		public const int CopyFixedCharacterName = 363;

		public const int CreateIntelligentCharacterWithQualificationBonusWithReturn = 364;

		public const int AdventureSaveElementAtTaiwuBigBlock = 365;

		public const int AdventureSaveElementAtTaiwuBlock = 366;

		public const int AdventureSaveElementAtElementBigBlock = 367;

		public const int RemoveItemPoison = 368;

		public const int TryGetJixiCharacter = 369;

		public const int DisableFixedCharacterAiMove = 373;

		public const int CheckLovingItemSubType = 375;

		public const int CheckHatingItemSubType = 376;

		public const int GetCharacterFavorabilityType = 377;

		public const int AdventureGetCurrentCharIds = 370;

		public const int AdventureGetCharIds = 371;

		public const int AdventureCheckElementDistanceToTaiwu = 378;

		public const int AdventureConvertElementCharJoinGroup = 379;

		public const int AdventureCreateRandomEnemyBindElement = 380;

		public const int CheckAdventureParameterInProgress = 381;

		public const int CheckAdventureInProgress = 382;

		public const int CheckJixiCanFollow = 383;

		public const int DeallocateNeili = 384;

		public const int AllocateNeili = 385;

		public const int CharacterGetCurrNeili = 386;

		public const int AdventureCheckElementDistanceToResetTarget = 387;

		public const int GearMateJoinGroup = 388;

		public const int GearMateLeaveGroup = 389;

		public const int CheckUsedFuyuSwordInCombat = 390;

		public const int AdventureElementRandomMove = 391;

		public const int CheckAdventureElementInBlockGroupBigBlockWithTag = 392;

		public const int AdventureElementSimulateCombatById = 393;

		public const int TemporarilyChangeExtraNeiliAllocation = 394;

		public const int CharacterRevertAllTemporaryModifications = 395;

		public const int AddExtraNeiliAllocationProgressToGainExtraNeiliAllocation = 699;

		public const int OpenDriveWugKingUi = 396;

		public const int SetCommonOptionAvailable = 397;

		public const int BanCommonOption = 513;

		public const int CheckItemPoisoned = 398;

		public const int CheckEventActorTemplate = 399;

		public const int CheckCharacterEatingWugKing = 400;

		public const int AddItemPoison = 401;

		public const int AddNormalInformation = 569;

		public const int AdventureChangeElementValueWithSpecificTag = 402;

		public const int AdventureMoveElementToElementNearById = 403;

		public const int AdventureMoveElementToElementNearByKey = 404;

		public const int AdventureMoveElementToGroup = 405;

		public const int GetCharacterPersonalityType = 406;

		public const int GetCharacterLifeSkillAttainment = 407;

		public const int CreateRandomEnemyWithGender = 409;

		public const int AdventureElementAlertAnim = 410;

		public const int AdventureBlockChangeIcon = 411;

		public const int AdventureGroupChangeIcon = 719;

		public const int AdventureElementShowHideEffect = 412;

		public const int AdventureGroupEffect = 413;

		public const int AddInstantNotificationNoArgument = 414;

		public const int AddInstantNotificationArgumentOneCharacter = 415;

		public const int AddInstantNotificationArgumentTwoCharacter = 416;

		public const int AddInstantNotificationArgumentThreeCharacter = 417;

		public const int AddMonthlyEventNoArgument = 580;

		public const int AddMonthlyNotificationNoArgument = 581;

		public const int AddMonthlyEventArgumentOneCharacter = 720;

		public const int WorldMapTaiwuRandomMove = 418;

		public const int CreateGearMate = 419;

		public const int CheckCorpsesCharacterGoodEnding = 422;

		public const int CheckValueExist = 424;

		public const int AddListToIntList = 425;

		public const int CheckCharacterInjuryCount = 426;

		public const int AdventureQueryTaiwuActionId = 427;

		public const int AdventureQueryElementActionId = 428;

		public const int AdventureChangeAction = 429;

		public const int AdventureElementStartActionWithTaiwu = 430;

		public const int AdventureElementStartActionWithElement = 431;

		public const int AdventureCheckFinishedActionKey = 432;

		public const int AdventureGetFinishedActionElement = 433;

		public const int AdventureElementsStartActionWithTaiwu = 434;

		public const int AdventureElementsStartAction = 435;

		public const int AdventureRemoveViewCloud = 436;

		public const int AdventureGetElementListByTag = 438;

		public const int AdventureGetElementListByCoreId = 439;

		public const int MajorEventGetNodeReward = 443;

		public const int ChangeMusicStatus = 444;

		public const int ChangeSoundStatus = 445;

		public const int CheckTotalMonth = 446;

		public const int CheckJixiFollowing = 447;

		public const int AdventureCheckElementInRangeWithTagForTaiwu = 448;

		public const int RemoveAllAdventureByCoreId = 927;

		public const int CheckCharacterHasItemType = 449;

		public const int RemoveAllMajorEventByCoreId = 450;

		public const int SetJixiGrow = 451;

		public const int AdventureAddElementItem = 452;

		public const int AdventureRemoveElementItem = 453;

		public const int AdventureSelectElementItem = 454;

		public const int AdventureCheckElementItem = 455;

		public const int AdventureHalfItemToTaiwu = 775;

		public const int CheckDisorderOfQi = 456;

		public const int ResetMartialArtTournament = 457;

		public const int OnLegendaryBookAdventureActivated = 458;

		public const int OnLegendaryBookAdventureRemoved = 459;

		public const int SetRanshanThreeCorpseFollowing = 460;

		public const int AdventureAddElementItemPoison = 461;

		public const int AdventureTransferItemToCharacter = 462;

		public const int AdventureTaiwuShowDialog = 463;

		public const int AdventureElementShowDialog = 464;

		public const int AdventureTaiwuAtBlockByElementId = 465;

		public const int AdventureTaiwuAtBlockByElementCoreId = 466;

		public const int AdventureTaiwuAtBlockByElementTags = 467;

		public const int AdventureTaiwuDistanceToElementById = 468;

		public const int AdventureTaiwuDistanceToElementByCoreId = 469;

		public const int AdventureTaiwuDistanceToElementByTags = 470;

		public const int AdventureCheckElementItemSubType = 471;

		public const int AdventureSelectElementRandomItemBySubType = 472;

		public const int QuerySettlementSect = 475;

		public const int GenerateSectComplementCombatSkillBookByGrade = 476;

		public const int GenerateMatchItem = 675;

		public const int SelectItemFromList = 477;

		public const int RemoveItemFromList = 478;

		public const int AddItemToList = 479;

		public const int AddItemListToList = 676;

		public const int DeleteAllItemFromList = 480;

		public const int AdventureFindElementByCharacterId = 487;

		public const int CheckTaiwuChickenCount = 488;

		public const int RemoveArgBoxValue = 489;

		public const int ClearArgBoxValue = 490;

		public const int AdventureFindElementMeetCondition = 491;

		public const int AdventureFindElementAtLocationByTags = 492;

		public const int CanStartRelationHusbandOrWife = 493;

		public const int GetTaiwuKidnappedCharacterList = 494;

		public const int AdventureGetElementKidnappedCharacterList = 495;

		public const int AdventureStartCricketCombat = 496;

		public const int AdventureSaveElementBlockIndex = 497;

		public const int AdventureSaveTaiwuBlockIndex = 498;

		public const int AdventureCheckElementBindCharacter = 499;

		public const int AdventureGetBlockListByGroup = 500;

		public const int AdventureCheckTaiwuAtBlock = 501;

		public const int AdventureGetElementBigBlockList = 502;

		public const int AdventureGetTaiwuBigBlockList = 503;

		public const int AdventureGetBlockElementList = 504;

		public const int AdventureCameraMoveToBlock = 505;

		public const int AdventureDelayAction = 776;

		public const int AdventureElementMoveToBlock = 506;

		public const int AdventureCheckElementAtBlockById = 507;

		public const int AdventureCheckElementAtBlockByCoreId = 508;

		public const int AdventureCheckElementAtBlockByTag = 509;

		public const int AdventureElementDirectionalMove = 510;

		public const int AdventureElementDirectionalMoveNew = 777;

		public const int CheckAdventureElementDirectionalPassable = 511;

		public const int AddAudioCommand = 512;

		public const int ChangeMusicStatusWithFade = 514;

		public const int AdventureElementParametricDirectionalMove = 518;

		public const int CheckAdventureElementParametricDirectionalPassable = 519;

		public const int CheckAdventureTaiwuDirectionalPassable = 521;

		public const int CheckAdventureTaiwuDirectionalElementCount = 522;

		public const int AdventureChangeElementCountAtTaiwuDirectionalBlock = 523;

		public const int AdventureSaveElementByIdAtTaiwuDirectionalBlock = 524;

		public const int ChangeCharacterExp = 525;

		public const int CheckTaiwuHaveReadingBook = 604;

		public const int GetTaiwuReadingBook = 605;

		public const int TaiwuReadingBook = 526;

		public const int TaiwuAddReadingEvent = 527;

		public const int AdventureShowHideCloudByViewAtGroup = 528;

		public const int AdventureHideCloudAtGroup = 529;

		public const int ShowExchangePanel = 530;

		public const int SaveCharacterCombatSkill = 531;

		public const int ChangeTaiwuCombatSkillProficiency = 532;

		public const int TeachCombatSkill = 533;

		public const int GetCombatPower = 536;

		public const int GetItemGrade = 537;

		public const int CheckItemGrade = 538;

		public const int HasRelation = 539;

		public const int AddOneWayRelationType = 861;

		public const int AddRelation = 955;

		public const int RemoveRelation = 956;

		public const int AdventureGetElementsInAction = 545;

		public const int AdventureGetElementsInActionWithElement = 546;

		public const int SetInteractionCooldown = 547;

		public const int CheckInteractionCooldown = 548;

		public const int SetInteractionMonthCooldown = 834;

		public const int CheckInteractionMonthCooldown = 835;

		public const int AdventureTaiwuDirectionalMove = 549;

		public const int AdventureTaiwuDirectionalMoveNew = 783;

		public const int AdventureConsumeActionPoint = 550;

		public const int AdventureSaveTaiwuPreAndCurBlockIndex = 551;

		public const int AdventureSetTaiwuToBlockIndex = 552;

		public const int CheckItemGradeByOperator = 553;

		public const int AdventureCreateElementRandomAtBigBlock = 554;

		public const int CharacterCheckNeiliTypePercent = 555;

		public const int AdventureInteractCaravan = 557;

		public const int ResetTransactionData = 889;

		public const int AdventureElementAnyFollowTarget = 561;

		public const int SetAdventureElementFollowTargetBlock = 562;

		public const int SetAdventureElementFollowTargetElement = 563;

		public const int ClearAdventureElementFollowTarget = 564;

		public const int AdventureSaveElementCurBlockIndex = 565;

		public const int AdventureSetGroupBlockCloud = 574;

		public const int AdventureSetBlockCloud = 575;

		public const int AdventureSetBlockListCloud = 576;

		public const int AdventureGetBlockListAroundElement = 579;

		public const int QueryAdventureCountInWorld = 844;

		public const int AdventureGenerate = 582;

		public const int AdventureGenerateNotCallCharacter = 822;

		public const int AdventureFillPresetCharacter = 838;

		public const int CreateFixedCharacterGrave = 583;

		public const int TeleportMoveTaiwuToBlock = 584;

		public const int SetNextSwordTombAdventureCooldown = 587;

		public const int RemoveSwordTombFromLocation = 588;

		public const int GetDefeatSwordTombCount = 589;

		public const int GetAdventureElementFollowTargetBlock = 590;

		public const int GetAdventureElementFollowTargetElement = 591;

		public const int AdventureElementArrivedTarget = 592;

		public const int StartInformationSelect = 593;

		public const int FinishInformationSelect = 594;

		public const int ApplyNormalInformation = 595;

		public const int GetRandomItemTemplate = 596;

		public const int ClearRegisterItemFilter = 597;

		public const int GetSectCombatSkillBookByGrade = 599;

		public const int SaveXiangshuLevel = 600;

		public const int AddTaiwuBreakoutStepBase = 601;

		public const int AddTaiwuBreakoutBaseSuccessRate = 602;

		public const int MajorEventSetAtmosphereType = 606;

		public const int MajorEventUnsetAtmosphereType = 607;

		public const int GetLastSwordTombLocation = 608;

		public const int ActivateSwordTombAtLocation = 609;

		public const int ActivateRemainingSwordTombs = 615;

		public const int DeactivateAllSwordTombAdventure = 610;

		public const int MakeSectCharactersApproveTaiwuInWulinConference = 612;

		public const int YufuKillTopTenRankingCharacters = 613;

		public const int SaveWorld = 616;

		public const int MakeWorldChaos = 617;

		public const int MakeTaiwuVillageAreaGraduallyBroken = 618;

		public const int CheckCharacterCarrierGrade = 619;

		public const int CheckInventoryItemOperationType = 620;

		public const int AdventureCreateElementAtAllBlock = 622;

		public const int AdventureTeleportMoveTaiwuToBlock = 623;

		public const int AdventureGetElementListAtBlockByTag = 624;

		public const int CheckCharacterEquipItemTemplate = 625;

		public const int SetCarrierTamePoint = 626;

		public const int GetHighestOrLowestHappinessCharacter = 627;

		public const int CreateChickenKingToTaiwuVillage = 628;

		public const int RemoveElementFromList = 629;

		public const int GetSwordTombAdventureMaxMonthCount = 630;

		public const int StartCommonSelectCharacterFeature = 631;

		public const int TrySetListValue = 632;

		public const int SortListValueReturnIndexList = 633;

		public const int CreateTeammateWithXiangshuCloth = 634;

		public const int SetTutorialFunctionStatus = 635;

		public const int SetAllTutorialFunctionStatuses = 646;

		public const int CheckCurrentTutorialChapter = 636;

		public const int CheckAdventureBlcokIsInCloud = 639;

		public const int SettlementHasBuilding = 641;

		public const int CheckCharacterLoopingNeigong = 642;

		public const int HuanxingUnlockFuyuPower = 643;

		public const int SetCharacterInvincibleInCombat = 851;

		public const int CheckAdventureElementDirectionalElementCount = 644;

		public const int TutorialRemoveBuildingAreaBambooHouse = 645;

		public const int GetMapBlockByCoordinate = 647;

		public const int ClearMapBlockCurrResources = 648;

		public const int SetMapBlockCurrResource = 649;

		public const int FillMapBlockCurrResourceByType = 650;

		public const int SetForceCollectResourceItem = 651;

		public const int SetForceCollectResourceAmount = 652;

		public const int TutorialUnlockProfessionSkill = 653;

		public const int TryGetEventTriggerParameter = 654;

		public const int CheckProfessionSkill = 655;

		public const int AdventureCreateBlockList = 656;

		public const int AdventureBlockListAddElement = 657;

		public const int AdventureBlockListSetEffect = 658;

		public const int AdventureBlockSetEffect = 686;

		public const int AdventureSetGlobalEffect = 659;

		public const int ChangeCharacterRelationBecomeHusbandOrWife = 660;

		public const int LoadDreamBackArchive = 662;

		public const int SaveArchiveForDreamBack = 712;

		public const int CheckHasDreamBackArchive = 663;

		public const int CheckAdventureBlcokElementCount = 664;

		public const int PrepareSectMembersAndTaiwuVillagersForSpiritualWanderPlace = 665;

		public const int SetXiangshuMinionsSurroundTaiwuVillage = 666;

		public const int GetLastXiangshuAvatar = 667;

		public const int GetLeaderInMaxApprovingRateSectByGoodness = 668;

		public const int AdventureCreateElementRandomAtGroup = 673;

		public const int AdventureGetTaiwuLocationElementListByTag = 669;

		public const int AdventureSaveNearestElementByTag = 670;

		public const int AdventureCheckBlockHaveElement = 671;

		public const int AdventureStopElementActionByTag = 672;

		public const int GetCharacterInventoryItemCount = 677;

		public const int GetMartialArtTournamentReward = 678;

		public const int SetHideAllTeammates = 681;

		public const int GetCharacterAttraction = 682;

		public const int CheckCharacterAttraction = 683;

		public const int GetCharacterCurrMainAttribute = 684;

		public const int CreateEnemyCharacterByConsummateLevel = 685;

		public const int TriggerCricketCatch = 693;

		public const int AdventureGetElementListAroundElement = 694;

		public const int GetRangeBetweenElement = 695;

		public const int AdventureSaveAllElementLocation = 696;

		public const int AdventureSaveElementLocation = 697;

		public const int AdventureStartSelectElement = 700;

		public const int AdventureIsActive = 890;

		public const int TriggeredGuidingChapter = 701;

		public const int GenerateEnemiesInBornArea = 705;

		public const int CheckBlockHasCricket = 706;

		public const int GenerateCricketPlaceNearTaiwu = 707;

		public const int SetCricketAtTaiwuLocationFake = 708;

		public const int OpenMonthNotifyForStartCricketContent = 709;

		public const int TaiwuRecordLifeSummary = 710;

		public const int RequestSetStat = 711;

		public const int CreateMissNingOfTaiwuVillage = 713;

		public const int StartShowSwordTombCreate = 714;

		public const int ApplyHelpSectInStory = 715;

		public const int ChangeBlockTemplate = 721;

		public const int OpenLegacyActivateDisplay = 722;

		public const int SetTaiwuVillageShowShrine = 723;

		public const int SetTaiwuAsLeaderOfTaiwuVillage = 724;

		public const int SetFirstSwordTombFinished = 725;

		public const int HideAllMapBlockCharacters = 726;

		public const int CreateAllSwordTombAdventure = 727;

		public const int CreateEightSwordTombAdventure = 933;

		public const int TaiwuGroupFull = 728;

		public const int CharacterJoinTaiwu = 729;

		public const int CricketPolymorphReturnByDead = 730;

		public const int CheckCricketPolymorphState = 731;

		public const int CricketPolymorph = 732;

		public const int CricketPolymorphEffect = 824;

		public const int CheckCricketColorId = 733;

		public const int GetOrCreateFirstXiangshuAvatarForStory = 734;

		public const int CreateBreakTombXiangshuAvatar = 735;

		public const int GetLegendaryBookItem = 736;

		public const int GetSwordFragmentTemplateByCharacter = 737;

		public const int SetEventRoleAlternativeName = 738;

		public const int StartSetCharacterName = 739;

		public const int FinishSetCharacterName = 740;

		public const int CheckXiangshuAvatarTaskStatus = 741;

		public const int ChangeMusicVolume = 742;

		public const int PlayMusicForCount = 743;

		public const int AutoEquipItems = 745;

		public const int AutoEquipCombatSkills = 746;

		public const int AutoAllocateNeili = 747;

		public const int ChangeEquipment = 781;

		public const int SwordTombInvasion = 748;

		public const int TryGetBlockXiangshuAvatar = 749;

		public const int CheckCharacterIsAnySectMember = 750;

		public const int CheckDefeatSwordTombCount = 751;

		public const int CheckSectMainStoryTriggerConditions = 752;

		public const int CharacterRestoreAllStatus = 753;

		public const int IsExorcismNeedToBeDisabled = 754;

		public const int SetExorcismEnabled = 755;

		public const int GetExorcismEnabled = 756;

		public const int CheckCharacterIsXiangshuAvatar = 757;

		public const int GetXiangshuAvatarIdByCharacter = 758;

		public const int MarkTaiwuDieOfCombatWithXiangshuAttacking = 759;

		public const int SetXiangshuDisplayStatus = 760;

		public const int BlockHasNormalHeavenlyTree = 761;

		public const int GetSwordTombInformation = 762;

		public const int StartSelectFilteredCharacters = 763;

		public const int AnySelectableFilteredCharacter = 764;

		public const int ClearAreaCricket = 765;

		public const int SetNextSwordTombCountDownDate = 766;

		public const int DeepValleyToSmallVillage = 770;

		public const int SmallVillageToBrokenArea = 771;

		public const int BrokenAreaToTaiwuVillageArea = 772;

		public const int DeepValleyToTaiwuVillageArea = 773;

		public const int TravelToPastTaiwuVillageArea = 813;

		public const int BackFromPastTaiwuVillageArea = 820;

		public const int GenerateMainStoryXiangshuMinion = 848;

		public const int GenerateChapter9XiangshuMinion = 842;

		public const int CheckChapter9TaiwuEscapeXiangshuMinionRange = 843;

		public const int CharacterMakeLove = 779;

		public const int EventTriggerParameterIsBuildingBlockTemplate = 784;

		public const int CheckSectSpiritualDebtInteractionOccurred = 785;

		public const int AddFuyuFaith = 786;

		public const int SwordFragmentUnlockSkill = 788;

		public const int TaiwuHaveCheatOnSecretInformation = 791;

		public const int ShowUnlockSkillSlotAnim = 792;

		public const int SetAreaStoryWeather = 793;

		public const int AddCharacterExtraTitle = 794;

		public const int SelectCharacterCricket = 795;

		public const int StartCricketCombat = 796;

		public const int StartCricketCombatWithConfig = 797;

		public const int GetSimulateCricketBattleResult = 798;

		public const int ClearCricketItemShow = 799;

		public const int GetItemCurrDurability = 800;

		public const int SetItemCurrDurability = 801;

		public const int GetItemMaxDurability = 802;

		public const int CheckCricketWinsCount = 803;

		public const int CheckCharCricketCount = 804;

		public const int CheckCricketAlive = 805;

		public const int AdjustCricketExtraAge = 806;

		public const int BuyCricketStart = 807;

		public const int BuyCricketOption = 808;

		public const int EventSetItemList = 837;

		public const int SetCoverCricketJarGradeList = 840;

		public const int CreateNoMindGuy = 814;

		public const int GetCharFame = 815;

		public const int GetCharPositiveFameValue = 816;

		public const int GetCharNegativeFameValue = 817;

		public const int CompareCharFame = 818;

		public const int SetIconPlateIsUnlocked = 819;

		public const int SetUnknownDateDisplay = 821;

		public const int ReleaseNoMindGuys = 823;

		public const int GetNoMindGuyList = 825;

		public const int BanNormalAttackInTutorial = 826;

		public const int BanMoveInTutorial = 827;

		public const int BanEnemyAiInTutorial = 828;

		public const int GenerateEnemyNestMinion = 830;

		public const int ComplementEnemyNestMinion = 831;

		public const int ClearEnemyNestMinion = 855;

		public const int ClearResourceDisasterStatus = 895;

		public const int ClearElopeWithLoveStatus = 883;

		public const int ClearSwordTombStatus = 887;

		public const int GetThreeVitalsBetray = 833;

		public const int HealAllDefeatMark = 839;

		public const int GetMainStoryEndingLine = 938;

		public const int CurrAliveTwelveImmortalsTotalCount = 845;

		public const int GenerateTwelveImmortals = 846;

		public const int IsTwelveImmortalsMember = 847;

		public const int SetDivineFlameIsUnlocked = 852;

		public const int SetNpcFollowTaiwu = 853;

		public const int SetNoMindGuyFollowTaiwu = 854;

		public const int CreateThreeWayDemon = 857;

		public const int TaiwuSetClothing = 858;

		public const int TeleportToTaiwuVillage = 859;

		public const int EventClearListeningEvent = 862;

		public const int TaiwuKillTwelveImmortals = 863;

		public const int AssisterKillTwelveImmortals = 864;

		public const int SetTwelveImmortalsAssistState = 870;

		public const int CharacterInSuxiaImpactRange = 865;

		public const int MoveCharacterAwaySuxiaImpactRange = 866;

		public const int LearnTwelveImmortalsCombatSkill = 867;

		public const int MakeChaishanBroken = 868;

		public const int RestoreAllAreaDestroyedBlocks = 869;

		public const int CreateEmeiGuidance = 871;

		public const int ClearEmeiGuidance = 872;

		public const int GuideEmeiCharacter = 873;

		public const int GetCharacterEmeiGuidanceType = 874;

		public const int GetCharacterEmeiGuidanceChanged = 875;

		public const int GetCharacterEmeiGuidanceNotch = 876;

		public const int GetCharacterEmeiGuidanceByType = 877;

		public const int CheckCharacterFavorabilityTypeForExchangeBook = 878;

		public const int EmeiInteractionOneCheck = 879;

		public const int EmeiInteractionTwoCheck = 880;

		public const int EmeiInteractionOneAdd = 881;

		public const int EmeiInteractionTwoAdd = 882;

		public const int IsCricketPolymorph = 884;

		public const int ActiveAdventureOrMajorEventInTaiwuBlock = 885;

		public const int UpdateFixedCharacterMonthlyMovement = 886;

		public const int CheckCharacterAlertnessForTeach = 888;

		public const int IsCharacterFollowingTaiwu = 891;

		public const int IsProfessionSkillEquipped = 892;

		public const int AddFuyuFaithBySecure = 893;

		public const int AddTianjiefuluBySecure = 894;

		public const int CheckSettlementHasChicken = 896;

		public const int CheckFirstMartialArtTournamentHostSect = 897;

		public const int CheckCharacterCombatSkillRatio50 = 898;

		public const int AdventureRemoveElementAndHandleBoundCharacterByInstanceId = 899;

		public const int GetChickenDisplayName = 900;

		public const int CreateXiangshuTower = 901;

		public const int ConvertFixedCharacter = 902;

		public const int ConvertRandomEnemy = 943;

		public const int ShowXiangshuLevelChanged = 920;

		public const int RemoveAllSwordTomb = 905;

		public const int RemoveAllSwordTombAdventure = 928;

		public const int CheckHasSwordTomb = 921;

		public const int SmarterChickenSetKingMonthlyEventInvoked = 906;

		public const int SmarterChickenReturn = 908;

		public const int CheckSmarterChickenState = 909;

		public const int SmarterChickenBecomeCharacter = 910;

		public const int PagodaofTheFallenCreateTwelveImmortals = 911;

		public const int TaiwuAsXiangshuEntered = 912;

		public const int TaiwuAsXiangshuGetUndefeatedAvatarTemplateId = 913;

		public const int DefeatFiveLoong = 961;

		public const int ConvertFiveLoongToCarrier = 914;

		public const int ConvertFiveLoongCarrierToHuman = 917;

		public const int ConvertFiveLoongHuman = 918;

		public const int FreeFiveLoongCarrier = 930;

		public const int GetFiveLoongCharacterCreated = 915;

		public const int GetFiveLoongState = 916;

		public const int GetLoongByEnemyId = 937;

		public const int IsItemKeyLoongCarrier = 922;

		public const int GotJiaoEgg = 923;

		public const int GotLoongScale = 936;

		public const int HaveDefeatFiveLoong = 924;

		public const int CharacterIsLoong = 949;

		public const int GetFiveLoongCharacter = 942;

		public const int GetLoongEnemyTemplateId = 944;

		public const int GetLoongEnemyTemplateIdByItemKey = 946;

		public const int CanTameLoong = 939;

		public const int CheckDlcInstalled = 919;

		public const int AdoptChicken = 925;

		public const int CreateChickenEventActor = 966;

		public const int IsEscapedChicken = 926;

		public const int CharacterIsChicken = 959;

		public const int TaiwuAsXiangshuDeleteCharacter = 929;

		public const int AddTwelveImmortalsFeature = 931;

		public const int AddTwelveImmortalsFeatureForTwelveImmortals = 957;

		public const int ChangeProfessionSeniority = 932;

		public const int SetTaiwuAsXiangshuTwelveImmortalsStatus = 934;

		public const int ClearBlockEnemies = 935;

		public const int TaiwuAsXiangshuWipeOut = 941;

		public const int StartUnlockTaiwuStation = 945;

		public const int AddTaiwuVillageStoneClaimed = 951;

		public const int AdventureRemoveElementsAndHandleBoundCharactersByCoreId = 947;

		public const int AdventureRemoveElementsAndHandleBoundCharactersByTag = 948;

		public const int OpenTaiwuAsXiangshuTowerFinalLayer = 950;

		public const int ApplyMonthlyEventAnimalTamingResult = 952;

		public const int JumpToMonthlyEventAnimalTamingEvent = 953;

		public const int StartMonthlyEventAnimalTamingEventCombat = 954;

		public const int CheckExtraTaskFinished = 958;

		public const int ChickenPolymorphEffect = 960;

		public const int IsConvertToIntelligentConfig = 962;

		public const int CharacterHasSpecialAvatar = 963;

		public const int ReserveThreeRealmsPowerPerformance = 964;

		public const int ShowNewFunctionUnlock = 965;

		public const int GetIsQuickStartGame = 967;

		public const int OpenDreamBackItemSelect = 968;

		public const int ConfirmDreamBackItemSelect = 969;
	}

	public static class DefValue
	{
		public static EventFunctionItem If => Instance[0];

		public static EventFunctionItem Else => Instance[1];

		public static EventFunctionItem ElseIf => Instance[2];

		public static EventFunctionItem Loop => Instance[3];

		public static EventFunctionItem Break => Instance[4];

		public static EventFunctionItem End => Instance[5];

		public static EventFunctionItem Continue => Instance[6];

		public static EventFunctionItem Label => Instance[7];

		public static EventFunctionItem Jump => Instance[8];

		public static EventFunctionItem Return => Instance[9];

		public static EventFunctionItem Assign => Instance[10];

		public static EventFunctionItem Random => Instance[11];

		public static EventFunctionItem CheckProb => Instance[12];

		public static EventFunctionItem GetRandomUnrepeated => Instance[767];

		public static EventFunctionItem EventTransition => Instance[13];

		public static EventFunctionItem OptionInjection => Instance[94];

		public static EventFunctionItem InjectAllOptions => Instance[420];

		public static EventFunctionItem ExecuteGlobalScript => Instance[91];

		public static EventFunctionItem SaveSectMainStoryValue => Instance[101];

		public static EventFunctionItem ReadSectMainStoryValue => Instance[102];

		public static EventFunctionItem SaveGlobalValue => Instance[485];

		public static EventFunctionItem ReadGlobalValue => Instance[486];

		public static EventFunctionItem SaveDlcValue => Instance[903];

		public static EventFunctionItem ReadDlcValue => Instance[904];

		public static EventFunctionItem GetListLength => Instance[215];

		public static EventFunctionItem GetListElement => Instance[216];

		public static EventFunctionItem GetLocalLanguageString => Instance[568];

		public static EventFunctionItem SetListenerWithActionName => Instance[640];

		public static EventFunctionItem Log => Instance[14];

		public static EventFunctionItem Comment => Instance[15];

		public static EventFunctionItem PlayAudio => Instance[16];

		public static EventFunctionItem PerformCutscene => Instance[482];

		public static EventFunctionItem SetEventCgTexture => Instance[611];

		public static EventFunctionItem SetEventCgTextureByName => Instance[614];

		public static EventFunctionItem ShowEventCgTextureInPictureShowPage => Instance[680];

		public static EventFunctionItem PlayTutorialVideo => Instance[603];

		public static EventFunctionItem BackToTutorialChapterMenu => Instance[637];

		public static EventFunctionItem BackToMainMenu => Instance[661];

		public static EventFunctionItem ScreenShake => Instance[17];

		public static EventFunctionItem SpecifyEventBackground => Instance[197];

		public static EventFunctionItem BlackMask => Instance[483];

		public static EventFunctionItem SetObtainPopupEnabled => Instance[829];

		public static EventFunctionItem CloseCharacterMenu => Instance[832];

		public static EventFunctionItem OpenEmeiCombatSkillSpecialBreak => Instance[187];

		public static EventFunctionItem SpecifyCurrMainAttribute => Instance[18];

		public static EventFunctionItem ChangeCurrMainAttribute => Instance[19];

		public static EventFunctionItem SpecifyInjury => Instance[20];

		public static EventFunctionItem ChangeInjury => Instance[21];

		public static EventFunctionItem ClearInjuries => Instance[22];

		public static EventFunctionItem SpecifyPoisoned => Instance[23];

		public static EventFunctionItem ChangePoisoned => Instance[24];

		public static EventFunctionItem ClearPoisons => Instance[25];

		public static EventFunctionItem SpecifyDisorderOfQi => Instance[26];

		public static EventFunctionItem ChangeDisorderOfQi => Instance[27];

		public static EventFunctionItem SpecifyHealth => Instance[28];

		public static EventFunctionItem ChangeHealth => Instance[29];

		public static EventFunctionItem SpecifyHappiness => Instance[30];

		public static EventFunctionItem ChangeHappiness => Instance[31];

		public static EventFunctionItem GetHappiness => Instance[570];

		public static EventFunctionItem SpecifyFavorabilities => Instance[32];

		public static EventFunctionItem ChangeFavorability => Instance[33];

		public static EventFunctionItem AddFeature => Instance[34];

		public static EventFunctionItem RemoveFeature => Instance[35];

		public static EventFunctionItem AddKidnappedCharacter => Instance[36];

		public static EventFunctionItem RemoveKidnappedCharacter => Instance[37];

		public static EventFunctionItem AddTaiwuPropertyPermanentBonus => Instance[585];

		public static EventFunctionItem JoinGroup => Instance[38];

		public static EventFunctionItem LeaveGroup => Instance[39];

		public static EventFunctionItem KillCharacter => Instance[40];

		public static EventFunctionItem TakeRandomDamage => Instance[189];

		public static EventFunctionItem AddInventoryItem => Instance[41];

		public static EventFunctionItem RemoveInventoryItem => Instance[65];

		public static EventFunctionItem TransferInventoryItem => Instance[42];

		public static EventFunctionItem AddWarehouseItem => Instance[744];

		public static EventFunctionItem SpecifyCharacterResource => Instance[129];

		public static EventFunctionItem ChangeCharacterResource => Instance[66];

		public static EventFunctionItem GetCharacterResource => Instance[679];

		public static EventFunctionItem TransferCharacterResource => Instance[130];

		public static EventFunctionItem ChangeCharBaseCombatSkillQualification => Instance[43];

		public static EventFunctionItem ChangeCharBaseLifeSkillQualification => Instance[44];

		public static EventFunctionItem SpecifyBaseCombatSkillQualification => Instance[789];

		public static EventFunctionItem SpecifyBaseLifeSkillQualification => Instance[790];

		public static EventFunctionItem LearnCombatSkill => Instance[45];

		public static EventFunctionItem LearnLifeSkill => Instance[46];

		public static EventFunctionItem AddLegacyPoint => Instance[47];

		public static EventFunctionItem ExpelTaiwuVillager => Instance[48];

		public static EventFunctionItem MakeAppointment => Instance[49];

		public static EventFunctionItem RemoveAppointment => Instance[50];

		public static EventFunctionItem AdvanceDays => Instance[51];

		public static EventFunctionItem ChangeMainStoryLineProgress => Instance[52];

		public static EventFunctionItem SetWorldFunctionsStatus => Instance[53];

		public static EventFunctionItem ResetWorldFunctionStatus => Instance[849];

		public static EventFunctionItem ChangeSpiritualDebt => Instance[54];

		public static EventFunctionItem ChangeSettlementSafety => Instance[55];

		public static EventFunctionItem ChangeSettlementCulture => Instance[56];

		public static EventFunctionItem GetSettlementLeader => Instance[860];

		public static EventFunctionItem SetBlockAndViewRangeVisible => Instance[57];

		public static EventFunctionItem SetSectAllowLearning => Instance[58];

		public static EventFunctionItem SetSectFunctionStatus => Instance[325];

		public static EventFunctionItem JoinOrganization => Instance[59];

		public static EventFunctionItem SetSectCharApprovedTaiwu => Instance[60];

		public static EventFunctionItem SetSectSpiritualDebtInteractionOccurred => Instance[226];

		public static EventFunctionItem ChangeMerchantFavorability => Instance[61];

		public static EventFunctionItem CreateItem => Instance[62];

		public static EventFunctionItem CreateCricket => Instance[63];

		public static EventFunctionItem CreateCricketByGrade => Instance[836];

		public static EventFunctionItem CreateCombatSkillBook => Instance[556];

		public static EventFunctionItem ReadAllBookPages => Instance[558];

		public static EventFunctionItem SetEquipmentEffectId => Instance[408];

		public static EventFunctionItem GetCharacterFavorability => Instance[111];

		public static EventFunctionItem GetCharacterBehaviorType => Instance[566];

		public static EventFunctionItem SetCharCombatSkillPracticeLevel => Instance[64];

		public static EventFunctionItem CreateAdventureSite => Instance[67];

		public static EventFunctionItem CreateConfigMonthlyAction => Instance[145];

		public static EventFunctionItem CreateEnemyCharacter => Instance[92];

		public static EventFunctionItem CreateEventActor => Instance[93];

		public static EventFunctionItem SetEventActor => Instance[940];

		public static EventFunctionItem GetFixedCharacter => Instance[99];

		public static EventFunctionItem GetIntelligentCharacterByFilter => Instance[114];

		public static EventFunctionItem MoveCharacter => Instance[100];

		public static EventFunctionItem StartCombat => Instance[89];

		public static EventFunctionItem StartNpcCombat => Instance[778];

		public static EventFunctionItem StartCombatWithSpecialTeammate => Instance[841];

		public static EventFunctionItem TriggerExtraTask => Instance[68];

		public static EventFunctionItem FinishExtraTask => Instance[69];

		public static EventFunctionItem FinishExtraTaskChain => Instance[70];

		public static EventFunctionItem TriggerSectMainStoryEndingCountDown => Instance[115];

		public static EventFunctionItem SetSectMainStoryEnding => Instance[116];

		public static EventFunctionItem GetTemplateIdOfFixedCharacterCombatWith => Instance[113];

		public static EventFunctionItem SetCharacterFollowTaiwu => Instance[117];

		public static EventFunctionItem CancelCharacterFollowTaiwu => Instance[120];

		public static EventFunctionItem StartLifeSkillCombat => Instance[118];

		public static EventFunctionItem ExitAdventure => Instance[124];

		public static EventFunctionItem GetAdventureCharacter => Instance[143];

		public static EventFunctionItem GetAdventureCharacterCount => Instance[144];

		public static EventFunctionItem FinishAdventureEvent => Instance[125];

		public static EventFunctionItem SelectAdventureBranch => Instance[126];

		public static EventFunctionItem GenerateAdventureMap => Instance[119];

		public static EventFunctionItem GetRandomInventoryItem => Instance[440];

		public static EventFunctionItem GetInventoryItem => Instance[850];

		public static EventFunctionItem CheckInventoryItem => Instance[702];

		public static EventFunctionItem GetStealActionPhase => Instance[441];

		public static EventFunctionItem GetPoisonActionPhase => Instance[540];

		public static EventFunctionItem GetPlotHarmActionPhase => Instance[541];

		public static EventFunctionItem HandlePoisonAction => Instance[542];

		public static EventFunctionItem HandlePlotHarmAction => Instance[543];

		public static EventFunctionItem CheckHarmfulActionPhase => Instance[442];

		public static EventFunctionItem FilterCharacterItem => Instance[127];

		public static EventFunctionItem FilterMapBlockInRange => Instance[167];

		public static EventFunctionItem FilterMapBlockOnEdge => Instance[698];

		public static EventFunctionItem RegisterToSelectItemSubTypes => Instance[132];

		public static EventFunctionItem RegisterToSelectItemTemplateIds => Instance[133];

		public static EventFunctionItem RegisterToExcludeItemTemplateIds => Instance[134];

		public static EventFunctionItem RegisterToSelectItemGrade => Instance[534];

		public static EventFunctionItem RegisterToSelectItemGroup => Instance[559];

		public static EventFunctionItem RegisterToSelectItemResourceType => Instance[703];

		public static EventFunctionItem RegisterToExcludeItemResourceType => Instance[704];

		public static EventFunctionItem FilterCharacterItemByRegister => Instance[135];

		public static EventFunctionItem CharacterTeachTaiwuProfession => Instance[147];

		public static EventFunctionItem RegisterSettlementMemberFeature => Instance[227];

		public static EventFunctionItem AddBuilding => Instance[149];

		public static EventFunctionItem SectStoryZhujianCreateCatchableThief => Instance[139];

		public static EventFunctionItem SectStoryZhujianCreateGearMate => Instance[150];

		public static EventFunctionItem SectStoryZhujianAddAreaMerchantType => Instance[151];

		public static EventFunctionItem SectStoryZhujianRemoveAreaMerchantType => Instance[152];

		public static EventFunctionItem SectStoryEmeiSetMemberInsaneState => Instance[188];

		public static EventFunctionItem GetMapBlockSettlement => Instance[243];

		public static EventFunctionItem GetOtherSmallSettlement => Instance[154];

		public static EventFunctionItem GetSectSettlement => Instance[481];

		public static EventFunctionItem GetRandomSettlementInState => Instance[192];

		public static EventFunctionItem GetSettlementListInState => Instance[217];

		public static EventFunctionItem GetCharacterCurrentMapBlock => Instance[198];

		public static EventFunctionItem GetCharacterSettlement => Instance[263];

		public static EventFunctionItem GetSettlementMapBlock => Instance[199];

		public static EventFunctionItem GetCharacterCurrentMapArea => Instance[261];

		public static EventFunctionItem GetSettlementMapArea => Instance[262];

		public static EventFunctionItem CreateMerchantRandomItem => Instance[153];

		public static EventFunctionItem GetCurrentEvent => Instance[437];

		public static EventFunctionItem TriggerLegacyPassingEvent => Instance[156];

		public static EventFunctionItem StartSetCharacterGivenName => Instance[164];

		public static EventFunctionItem FinishSetCharacterGivenName => Instance[165];

		public static EventFunctionItem CheckExpression => Instance[71];

		public static EventFunctionItem CheckAnd => Instance[109];

		public static EventFunctionItem CheckOr => Instance[110];

		public static EventFunctionItem CheckListElement => Instance[218];

		public static EventFunctionItem CheckWorldFunctionStatus => Instance[155];

		public static EventFunctionItem CheckMainStoryProgress => Instance[72];

		public static EventFunctionItem CheckGlobalArgBox => Instance[423];

		public static EventFunctionItem CheckDlcArgBox => Instance[907];

		public static EventFunctionItem CheckTask => Instance[73];

		public static EventFunctionItem CheckTaskFinished => Instance[586];

		public static EventFunctionItem CheckTaskChain => Instance[74];

		public static EventFunctionItem CheckXiangshuLevel => Instance[75];

		public static EventFunctionItem CheckFixedCharacterTemplate => Instance[128];

		public static EventFunctionItem TryGetFixedCharacter => Instance[515];

		public static EventFunctionItem CheckCharacterCurrMainAttribute => Instance[76];

		public static EventFunctionItem CheckCharacterMainAttribute => Instance[77];

		public static EventFunctionItem CheckCharacterLifeSkillQualification => Instance[78];

		public static EventFunctionItem CheckCharacterLifeSkillAttainment => Instance[79];

		public static EventFunctionItem CheckCharacterCombatSkillQualification => Instance[80];

		public static EventFunctionItem CheckCharacterCombatSkillAttainment => Instance[81];

		public static EventFunctionItem GetCharacterCombatSkillAttainment => Instance[577];

		public static EventFunctionItem CheckCharacterPersonality => Instance[82];

		public static EventFunctionItem CheckCharacterBehaviorType => Instance[107];

		public static EventFunctionItem CheckCharacterMorality => Instance[108];

		public static EventFunctionItem ChangeCharacterMorality => Instance[571];

		public static EventFunctionItem SetCharacterBehaviorType => Instance[572];

		public static EventFunctionItem CheckCharacterCurrAge => Instance[160];

		public static EventFunctionItem CheckCharacterActualAge => Instance[161];

		public static EventFunctionItem CheckCharacterAgeGroup => Instance[162];

		public static EventFunctionItem CheckCharacterGender => Instance[203];

		public static EventFunctionItem CheckCharacterResource => Instance[83];

		public static EventFunctionItem CheckCharacterFeature => Instance[84];

		public static EventFunctionItem CheckCharacterCurrentProfession => Instance[140];

		public static EventFunctionItem CheckCharacterSeniorityPercent => Instance[141];

		public static EventFunctionItem CheckCharacterInventoryByTemplate => Instance[85];

		public static EventFunctionItem CheckCharacterOnSettlementBlock => Instance[86];

		public static EventFunctionItem CheckCharacterInSettlementInfluenceRange => Instance[87];

		public static EventFunctionItem CheckCharacterInMapState => Instance[95];

		public static EventFunctionItem CheckCharacterInMapArea => Instance[96];

		public static EventFunctionItem CheckCharacterInBrokenArea => Instance[520];

		public static EventFunctionItem CheckCharacterInMapBlockRange => Instance[168];

		public static EventFunctionItem CheckCharacterOnMapBlockTemplate => Instance[638];

		public static EventFunctionItem CheckCharacterOnAnySettlement => Instance[97];

		public static EventFunctionItem CheckCharacterInAnySettlementInfluenceRange => Instance[98];

		public static EventFunctionItem CheckCharacterInSettlementArea => Instance[194];

		public static EventFunctionItem CheckCharacterFavorability => Instance[88];

		public static EventFunctionItem CheckCharacterFavorabilityType => Instance[142];

		public static EventFunctionItem CheckCharacterGrade => Instance[103];

		public static EventFunctionItem GetCharacterGrade => Instance[573];

		public static EventFunctionItem CheckCharacterSettlement => Instance[104];

		public static EventFunctionItem CheckCharacterHasItem => Instance[121];

		public static EventFunctionItem CheckCharacterMerchantType => Instance[122];

		public static EventFunctionItem CheckCharacterReadLifeSkillPageCount => Instance[131];

		public static EventFunctionItem CheckCharacterNeiliTypeConflictCombatSkill => Instance[567];

		public static EventFunctionItem CheckPreviousCombatResult => Instance[90];

		public static EventFunctionItem CheckPreviousCombatType => Instance[473];

		public static EventFunctionItem CheckSectFunctionStatus => Instance[326];

		public static EventFunctionItem CheckSectCanTeach => Instance[674];

		public static EventFunctionItem CheckSettlementInMapState => Instance[105];

		public static EventFunctionItem CheckSettlementInMapArea => Instance[106];

		public static EventFunctionItem CheckSettlementTreasuryAlertTime => Instance[768];

		public static EventFunctionItem CheckAreaSpiritualDebt => Instance[112];

		public static EventFunctionItem CheckAreaHasAdventure => Instance[204];

		public static EventFunctionItem CheckAreaHasMajorEvent => Instance[787];

		public static EventFunctionItem CheckAreaHasAdultGraveOfTargetOrganization => Instance[517];

		public static EventFunctionItem CheckSectMainStoryValueExists => Instance[123];

		public static EventFunctionItem CheckMapBlockByMatcher => Instance[769];

		public static EventFunctionItem CheckItemType => Instance[136];

		public static EventFunctionItem CheckItemSubType => Instance[137];

		public static EventFunctionItem CheckItemTemplate => Instance[138];

		public static EventFunctionItem TryGetCharacterCurrentProfession => Instance[146];

		public static EventFunctionItem CheckCharacterPassMatcher => Instance[213];

		public static EventFunctionItem CheckCharacterCanTeachTaiwuProfession => Instance[148];

		public static EventFunctionItem CheckCharacterCanTeachTaiwuProfessionSkillUnlock => Instance[163];

		public static EventFunctionItem CheckCharacterConsummateLevel => Instance[157];

		public static EventFunctionItem CheckIsDreamBack => Instance[158];

		public static EventFunctionItem CheckCharacterAlive => Instance[159];

		public static EventFunctionItem CheckCharacterOnValidLocation => Instance[516];

		public static EventFunctionItem CheckCharacterIntelligent => Instance[716];

		public static EventFunctionItem CreateFixedSkillBook => Instance[166];

		public static EventFunctionItem CheckAdventureParameterCount => Instance[169];

		public static EventFunctionItem CheckCurrentAdventure => Instance[421];

		public static EventFunctionItem CheckMovePoint => Instance[170];

		public static EventFunctionItem ChangeActionPoint => Instance[717];

		public static EventFunctionItem CheckCurrMonth => Instance[171];

		public static EventFunctionItem CheckCharacterKidnapSpecificGender => Instance[172];

		public static EventFunctionItem CheckCharacterKidnapSpecificAgeGroup => Instance[173];

		public static EventFunctionItem CheckCharacterKidnapSpecificId => Instance[174];

		public static EventFunctionItem CheckCharacterTeammateSpecificIdGender => Instance[175];

		public static EventFunctionItem CheckCharacterTeammateSpecificIdAgeGroup => Instance[176];

		public static EventFunctionItem CheckCharacterTeammateSpecificIdId => Instance[177];

		public static EventFunctionItem CheckCharacterExp => Instance[178];

		public static EventFunctionItem CheckCharacterReadCombatSkillPageCount => Instance[179];

		public static EventFunctionItem CheckCharacterCombatSkillBreakout => Instance[180];

		public static EventFunctionItem CheckSettlementApprovingRate => Instance[190];

		public static EventFunctionItem AddMaxApprovingRateBonus => Instance[535];

		public static EventFunctionItem CheckSettlementApprovingRateUpperLimit => Instance[560];

		public static EventFunctionItem CheckStateHasSettlementType => Instance[193];

		public static EventFunctionItem CheckAdventureTemplate => Instance[202];

		public static EventFunctionItem CheckAdventurePerMoveCount => Instance[181];

		public static EventFunctionItem CheckAdventurePerCostMovePoint => Instance[182];

		public static EventFunctionItem CheckAdventureElementVisible => Instance[183];

		public static EventFunctionItem SwitchEmeiBlood => Instance[184];

		public static EventFunctionItem CheckAdventureCharacterGroup => Instance[185];

		public static EventFunctionItem CheckAdventureElementGroup => Instance[186];

		public static EventFunctionItem GetCharacterConsummateLevel => Instance[191];

		public static EventFunctionItem OpenYuanshanMiniGame => Instance[195];

		public static EventFunctionItem ProcessYuanshanMiniGameResults => Instance[196];

		public static EventFunctionItem SpecifyXiangshuInfectionValue => Instance[200];

		public static EventFunctionItem ChangeXiangshuInfectionValue => Instance[201];

		public static EventFunctionItem SetCharacterMarriageStyleOne => Instance[205];

		public static EventFunctionItem SetCharacterMarriageStyleTwo => Instance[206];

		public static EventFunctionItem IsVitalInPrison => Instance[207];

		public static EventFunctionItem SetVitalInPrison => Instance[208];

		public static EventFunctionItem PlayVitalAnim => Instance[209];

		public static EventFunctionItem GetCharacterBySettlementGradeAndAge => Instance[210];

		public static EventFunctionItem AreVitalsDemon => Instance[211];

		public static EventFunctionItem GetCurrentVitalIndex => Instance[212];

		public static EventFunctionItem InitThreeVitals => Instance[214];

		public static EventFunctionItem CheckAdventureParameter => Instance[219];

		public static EventFunctionItem SetAdventureParameter => Instance[220];

		public static EventFunctionItem ChangeAdventureParameter => Instance[221];

		public static EventFunctionItem CheckAdventureParameterStartWith => Instance[222];

		public static EventFunctionItem SetAdventureParameterStartWith => Instance[223];

		public static EventFunctionItem ChangeAdventureParameterStartWith => Instance[224];

		public static EventFunctionItem AdventureCheckProb => Instance[225];

		public static EventFunctionItem CheckAdventureElementCount => Instance[228];

		public static EventFunctionItem CheckAdventureElementTagCount => Instance[229];

		public static EventFunctionItem GetAdventureElementTagCount => Instance[372];

		public static EventFunctionItem CheckAdventureParameterIsMax => Instance[230];

		public static EventFunctionItem CheckAdventureParameterIsMin => Instance[231];

		public static EventFunctionItem CheckAdventureElementInElement => Instance[232];

		public static EventFunctionItem CheckAdventureTaiwuInElement => Instance[233];

		public static EventFunctionItem CheckAdventureTaiwuInBlockGroup => Instance[234];

		public static EventFunctionItem AdventureCreateItem => Instance[235];

		public static EventFunctionItem AdventureRemoveItem => Instance[236];

		public static EventFunctionItem AdventureConsumeItem => Instance[474];

		public static EventFunctionItem AdventureCheckUseItem => Instance[237];

		public static EventFunctionItem AddJieqingMaskCharId => Instance[238];

		public static EventFunctionItem RemoveJieqingMaskCharId => Instance[239];

		public static EventFunctionItem AdventureSetAutoDeleteDate => Instance[240];

		public static EventFunctionItem AdventureExit => Instance[241];

		public static EventFunctionItem AdventureExitNotReset => Instance[687];

		public static EventFunctionItem AdventureCreateAndEnter => Instance[718];

		public static EventFunctionItem AdventureExitResetCharacterState => Instance[688];

		public static EventFunctionItem AdventureExitResetElementParameter => Instance[689];

		public static EventFunctionItem AdventureExitResetElementBlockIndex => Instance[690];

		public static EventFunctionItem AdventureExitInterruptAllActions => Instance[691];

		public static EventFunctionItem AdventureExitResetTaiwuBuff => Instance[692];

		public static EventFunctionItem DestroyEnemyNest => Instance[242];

		public static EventFunctionItem SectMainStoryUnlockUI => Instance[244];

		public static EventFunctionItem CheckAdventureElementVisibleWithTag => Instance[245];

		public static EventFunctionItem CheckAdventureElementGroupWithTag => Instance[246];

		public static EventFunctionItem CheckAdventureElementInElementWithTag => Instance[247];

		public static EventFunctionItem CheckAdventureTaiwuInElementWithTag => Instance[248];

		public static EventFunctionItem GetCurrentFaith => Instance[249];

		public static EventFunctionItem GetFaithLevel => Instance[250];

		public static EventFunctionItem GetFuyuFaithTime => Instance[251];

		public static EventFunctionItem OpenFuyuFaithPanel => Instance[252];

		public static EventFunctionItem OpenFuyuGiftPanel => Instance[253];

		public static EventFunctionItem ApplyFuyuFaith => Instance[254];

		public static EventFunctionItem ReadSelectResultCount => Instance[255];

		public static EventFunctionItem TryGetMaxAcceptableFuyuFaith => Instance[256];

		public static EventFunctionItem CheckTaiwuHasFuyuFaith => Instance[257];

		public static EventFunctionItem CheckCharacterFuyuFaith => Instance[258];

		public static EventFunctionItem AdventureElementFillByGroup => Instance[259];

		public static EventFunctionItem AdventureElementFillByElement => Instance[260];

		public static EventFunctionItem AdventureDelete => Instance[264];

		public static EventFunctionItem AdventureDeleteNew => Instance[811];

		public static EventFunctionItem CheckAdventureElementParameter => Instance[265];

		public static EventFunctionItem SetAdventureElementParameter => Instance[266];

		public static EventFunctionItem ChangeAdventureElementParameter => Instance[267];

		public static EventFunctionItem AdventureChangeElementCountAtTaiwuLocation => Instance[268];

		public static EventFunctionItem AdventureChangeElementCountAtTaiwuLocationBig => Instance[774];

		public static EventFunctionItem AdventureClearElementAtTaiwuLocation => Instance[269];

		public static EventFunctionItem AdventureClearElement => Instance[270];

		public static EventFunctionItem AdventureDeleteElement => Instance[271];

		public static EventFunctionItem AdventureDeleteElementByElement => Instance[272];

		public static EventFunctionItem AdventureDeleteElementByElementGroup => Instance[273];

		public static EventFunctionItem CheckAdventureElementHaveElement => Instance[274];

		public static EventFunctionItem GetMovePointValue => Instance[275];

		public static EventFunctionItem CheckAdventureElementCombatPowerIsMax => Instance[276];

		public static EventFunctionItem AdventureElementSimulateCombat => Instance[277];

		public static EventFunctionItem AdventureCheckHasItem => Instance[278];

		public static EventFunctionItem AdventureSaveElementCharacterId => Instance[279];

		public static EventFunctionItem AdventureCreateElementRandom => Instance[280];

		public static EventFunctionItem AdventureTaiwuRandomMove => Instance[281];

		public static EventFunctionItem AdventureDeleteCurrElement => Instance[282];

		public static EventFunctionItem AdventurePlayDeleteElementAnim => Instance[484];

		public static EventFunctionItem ClearDisorderOfQi => Instance[283];

		public static EventFunctionItem RecoverHealth => Instance[284];

		public static EventFunctionItem AdventureSaveElementTimeCosted => Instance[285];

		public static EventFunctionItem AdventureCheckIsSpecifyElement => Instance[286];

		public static EventFunctionItem AdventureGetParameterValue => Instance[287];

		public static EventFunctionItem AdventureGetElementParameterValue => Instance[288];

		public static EventFunctionItem AdventureGetItemCount => Instance[289];

		public static EventFunctionItem AdventureCompareCombatPowerWithElementAtSameBlock => Instance[290];

		public static EventFunctionItem AdventureCompareCombatPowerWithElementTagAtSameBlock => Instance[291];

		public static EventFunctionItem AdventureCompareCombatPowerWithElement => Instance[292];

		public static EventFunctionItem AdventureCompareCombatPowerWithElementTag => Instance[293];

		public static EventFunctionItem AdventureCheckElementSameLocation => Instance[294];

		public static EventFunctionItem AdventureCheckElementSameLocationWithTag => Instance[295];

		public static EventFunctionItem AdventureCheckTwoElementSameLocation => Instance[598];

		public static EventFunctionItem AdventureCheckIsSpecifyTagElement => Instance[296];

		public static EventFunctionItem AdventureChangeElementCount => Instance[297];

		public static EventFunctionItem CheckJieQingInteractUnlock => Instance[298];

		public static EventFunctionItem JieQingInteractConfirmKill => Instance[299];

		public static EventFunctionItem CharacterStarFortuneEnough => Instance[300];

		public static EventFunctionItem AdventureSaveElementById => Instance[301];

		public static EventFunctionItem AdventureSaveElementByTag => Instance[302];

		public static EventFunctionItem AdventureSaveElementByTagGlobal => Instance[303];

		public static EventFunctionItem MajorEventExitAndDelete => Instance[304];

		public static EventFunctionItem MajorEventExitAndDeleteAndInvokeOther => Instance[374];

		public static EventFunctionItem MajorEventExitAndDeleteNew => Instance[812];

		public static EventFunctionItem MajorEventSetSkipFinishAnim => Instance[856];

		public static EventFunctionItem AdventureSetTaiwuViewType => Instance[305];

		public static EventFunctionItem AdventureCheckViewType => Instance[306];

		public static EventFunctionItem AdventureCheckElementInRange => Instance[307];

		public static EventFunctionItem AdventureCheckElementInRangeWithTag => Instance[308];

		public static EventFunctionItem AdventureCreateElementAtGroup => Instance[309];

		public static EventFunctionItem AdventureCreateElementInheritCharacter => Instance[310];

		public static EventFunctionItem AdventureParameterStartProgress => Instance[311];

		public static EventFunctionItem AdventureElementParameterStartProgress => Instance[312];

		public static EventFunctionItem AdventureElementMoveToTaiwuNearby => Instance[313];

		public static EventFunctionItem AdventureGetElementCountInRange => Instance[314];

		public static EventFunctionItem CharacterGetAvailableEatingSlotsCount => Instance[315];

		public static EventFunctionItem CheckCharacterAvailableEatingSlotsCount => Instance[578];

		public static EventFunctionItem CharacterAddEatingItem => Instance[316];

		public static EventFunctionItem ClearCharacterEatingItemByIndex => Instance[809];

		public static EventFunctionItem ClearCharacterEatingItem => Instance[810];

		public static EventFunctionItem MedicineExtraAddPercent => Instance[544];

		public static EventFunctionItem CharacterChangeCurrNeili => Instance[317];

		public static EventFunctionItem CharacterSetCurrNeili => Instance[318];

		public static EventFunctionItem CharacterCheckNeiliType => Instance[319];

		public static EventFunctionItem GetRandomItemTemplateByGrade => Instance[320];

		public static EventFunctionItem ItemAddPoisonRandom => Instance[321];

		public static EventFunctionItem CharacterHaveInjury => Instance[322];

		public static EventFunctionItem CharacterHavePoison => Instance[323];

		public static EventFunctionItem TaiwuHealCharacter => Instance[324];

		public static EventFunctionItem RandomSuccessorActive => Instance[327];

		public static EventFunctionItem GetSectMainStoryEnding => Instance[328];

		public static EventFunctionItem OpenModifyBook => Instance[329];

		public static EventFunctionItem GetSectMapBlock => Instance[330];

		public static EventFunctionItem CheckWuxianWugJugPoison => Instance[331];

		public static EventFunctionItem GetCurrDate => Instance[332];

		public static EventFunctionItem StartShavingAction => Instance[333];

		public static EventFunctionItem AdventureElementParameterStartProgressWithTag => Instance[334];

		public static EventFunctionItem RemoveInventoryItemByTemplateId => Instance[335];

		public static EventFunctionItem SelectFilterCharacterAgeGroup => Instance[336];

		public static EventFunctionItem CheckAdventureElementInProgress => Instance[337];

		public static EventFunctionItem AdventureElementSimulateCombatWithTag => Instance[338];

		public static EventFunctionItem CheckPreviousSimulateCombatResult => Instance[339];

		public static EventFunctionItem AdventureCreateElementAtGroupWithTag => Instance[340];

		public static EventFunctionItem CheckSectMainStoryEnding => Instance[341];

		public static EventFunctionItem GetTaiwuGroupList => Instance[342];

		public static EventFunctionItem CreateIntList => Instance[343];

		public static EventFunctionItem AddToIntList => Instance[344];

		public static EventFunctionItem SelectCharacter => Instance[345];

		public static EventFunctionItem SelectCharacterWithFilter => Instance[621];

		public static EventFunctionItem CheckAdventureElementInTaiwuBigBlockWithTag => Instance[346];

		public static EventFunctionItem CheckAdventureElementInBigBlockWithTag => Instance[347];

		public static EventFunctionItem CheckItemValid => Instance[348];

		public static EventFunctionItem CheckAdventureElementParameterInProgress => Instance[349];

		public static EventFunctionItem CheckGotoOutterWorldCoolDown => Instance[350];

		public static EventFunctionItem AdventureGetElementDistanceToTaiwu => Instance[351];

		public static EventFunctionItem AdventureCheckViewTypeToElement => Instance[352];

		public static EventFunctionItem MajorEventCreate => Instance[353];

		public static EventFunctionItem MajorEventCreateAndEnter => Instance[780];

		public static EventFunctionItem GetSettlementRandomMapBlock => Instance[354];

		public static EventFunctionItem SetBlackSnakeName => Instance[355];

		public static EventFunctionItem AdventureParameterStopProgress => Instance[356];

		public static EventFunctionItem AdventureElementParameterStopProgress => Instance[357];

		public static EventFunctionItem AdventureCheckElementDistanceToGroupBlock => Instance[358];

		public static EventFunctionItem ReduceRandomDamage => Instance[359];

		public static EventFunctionItem EditCharBaseNeiliProportionOfFiveElements => Instance[360];

		public static EventFunctionItem GetCharacterFiveElements => Instance[782];

		public static EventFunctionItem AdventureCheckElementAtResetTarget => Instance[361];

		public static EventFunctionItem GetJixiCharacter => Instance[362];

		public static EventFunctionItem CopyFixedCharacterName => Instance[363];

		public static EventFunctionItem CreateIntelligentCharacterWithQualificationBonusWithReturn => Instance[364];

		public static EventFunctionItem AdventureSaveElementAtTaiwuBigBlock => Instance[365];

		public static EventFunctionItem AdventureSaveElementAtTaiwuBlock => Instance[366];

		public static EventFunctionItem AdventureSaveElementAtElementBigBlock => Instance[367];

		public static EventFunctionItem RemoveItemPoison => Instance[368];

		public static EventFunctionItem TryGetJixiCharacter => Instance[369];

		public static EventFunctionItem DisableFixedCharacterAiMove => Instance[373];

		public static EventFunctionItem CheckLovingItemSubType => Instance[375];

		public static EventFunctionItem CheckHatingItemSubType => Instance[376];

		public static EventFunctionItem GetCharacterFavorabilityType => Instance[377];

		public static EventFunctionItem AdventureGetCurrentCharIds => Instance[370];

		public static EventFunctionItem AdventureGetCharIds => Instance[371];

		public static EventFunctionItem AdventureCheckElementDistanceToTaiwu => Instance[378];

		public static EventFunctionItem AdventureConvertElementCharJoinGroup => Instance[379];

		public static EventFunctionItem AdventureCreateRandomEnemyBindElement => Instance[380];

		public static EventFunctionItem CheckAdventureParameterInProgress => Instance[381];

		public static EventFunctionItem CheckAdventureInProgress => Instance[382];

		public static EventFunctionItem CheckJixiCanFollow => Instance[383];

		public static EventFunctionItem DeallocateNeili => Instance[384];

		public static EventFunctionItem AllocateNeili => Instance[385];

		public static EventFunctionItem CharacterGetCurrNeili => Instance[386];

		public static EventFunctionItem AdventureCheckElementDistanceToResetTarget => Instance[387];

		public static EventFunctionItem GearMateJoinGroup => Instance[388];

		public static EventFunctionItem GearMateLeaveGroup => Instance[389];

		public static EventFunctionItem CheckUsedFuyuSwordInCombat => Instance[390];

		public static EventFunctionItem AdventureElementRandomMove => Instance[391];

		public static EventFunctionItem CheckAdventureElementInBlockGroupBigBlockWithTag => Instance[392];

		public static EventFunctionItem AdventureElementSimulateCombatById => Instance[393];

		public static EventFunctionItem TemporarilyChangeExtraNeiliAllocation => Instance[394];

		public static EventFunctionItem CharacterRevertAllTemporaryModifications => Instance[395];

		public static EventFunctionItem AddExtraNeiliAllocationProgressToGainExtraNeiliAllocation => Instance[699];

		public static EventFunctionItem OpenDriveWugKingUi => Instance[396];

		public static EventFunctionItem SetCommonOptionAvailable => Instance[397];

		public static EventFunctionItem BanCommonOption => Instance[513];

		public static EventFunctionItem CheckItemPoisoned => Instance[398];

		public static EventFunctionItem CheckEventActorTemplate => Instance[399];

		public static EventFunctionItem CheckCharacterEatingWugKing => Instance[400];

		public static EventFunctionItem AddItemPoison => Instance[401];

		public static EventFunctionItem AddNormalInformation => Instance[569];

		public static EventFunctionItem AdventureChangeElementValueWithSpecificTag => Instance[402];

		public static EventFunctionItem AdventureMoveElementToElementNearById => Instance[403];

		public static EventFunctionItem AdventureMoveElementToElementNearByKey => Instance[404];

		public static EventFunctionItem AdventureMoveElementToGroup => Instance[405];

		public static EventFunctionItem GetCharacterPersonalityType => Instance[406];

		public static EventFunctionItem GetCharacterLifeSkillAttainment => Instance[407];

		public static EventFunctionItem CreateRandomEnemyWithGender => Instance[409];

		public static EventFunctionItem AdventureElementAlertAnim => Instance[410];

		public static EventFunctionItem AdventureBlockChangeIcon => Instance[411];

		public static EventFunctionItem AdventureGroupChangeIcon => Instance[719];

		public static EventFunctionItem AdventureElementShowHideEffect => Instance[412];

		public static EventFunctionItem AdventureGroupEffect => Instance[413];

		public static EventFunctionItem AddInstantNotificationNoArgument => Instance[414];

		public static EventFunctionItem AddInstantNotificationArgumentOneCharacter => Instance[415];

		public static EventFunctionItem AddInstantNotificationArgumentTwoCharacter => Instance[416];

		public static EventFunctionItem AddInstantNotificationArgumentThreeCharacter => Instance[417];

		public static EventFunctionItem AddMonthlyEventNoArgument => Instance[580];

		public static EventFunctionItem AddMonthlyNotificationNoArgument => Instance[581];

		public static EventFunctionItem AddMonthlyEventArgumentOneCharacter => Instance[720];

		public static EventFunctionItem WorldMapTaiwuRandomMove => Instance[418];

		public static EventFunctionItem CreateGearMate => Instance[419];

		public static EventFunctionItem CheckCorpsesCharacterGoodEnding => Instance[422];

		public static EventFunctionItem CheckValueExist => Instance[424];

		public static EventFunctionItem AddListToIntList => Instance[425];

		public static EventFunctionItem CheckCharacterInjuryCount => Instance[426];

		public static EventFunctionItem AdventureQueryTaiwuActionId => Instance[427];

		public static EventFunctionItem AdventureQueryElementActionId => Instance[428];

		public static EventFunctionItem AdventureChangeAction => Instance[429];

		public static EventFunctionItem AdventureElementStartActionWithTaiwu => Instance[430];

		public static EventFunctionItem AdventureElementStartActionWithElement => Instance[431];

		public static EventFunctionItem AdventureCheckFinishedActionKey => Instance[432];

		public static EventFunctionItem AdventureGetFinishedActionElement => Instance[433];

		public static EventFunctionItem AdventureElementsStartActionWithTaiwu => Instance[434];

		public static EventFunctionItem AdventureElementsStartAction => Instance[435];

		public static EventFunctionItem AdventureRemoveViewCloud => Instance[436];

		public static EventFunctionItem AdventureGetElementListByTag => Instance[438];

		public static EventFunctionItem AdventureGetElementListByCoreId => Instance[439];

		public static EventFunctionItem MajorEventGetNodeReward => Instance[443];

		public static EventFunctionItem ChangeMusicStatus => Instance[444];

		public static EventFunctionItem ChangeSoundStatus => Instance[445];

		public static EventFunctionItem CheckTotalMonth => Instance[446];

		public static EventFunctionItem CheckJixiFollowing => Instance[447];

		public static EventFunctionItem AdventureCheckElementInRangeWithTagForTaiwu => Instance[448];

		public static EventFunctionItem RemoveAllAdventureByCoreId => Instance[927];

		public static EventFunctionItem CheckCharacterHasItemType => Instance[449];

		public static EventFunctionItem RemoveAllMajorEventByCoreId => Instance[450];

		public static EventFunctionItem SetJixiGrow => Instance[451];

		public static EventFunctionItem AdventureAddElementItem => Instance[452];

		public static EventFunctionItem AdventureRemoveElementItem => Instance[453];

		public static EventFunctionItem AdventureSelectElementItem => Instance[454];

		public static EventFunctionItem AdventureCheckElementItem => Instance[455];

		public static EventFunctionItem AdventureHalfItemToTaiwu => Instance[775];

		public static EventFunctionItem CheckDisorderOfQi => Instance[456];

		public static EventFunctionItem ResetMartialArtTournament => Instance[457];

		public static EventFunctionItem OnLegendaryBookAdventureActivated => Instance[458];

		public static EventFunctionItem OnLegendaryBookAdventureRemoved => Instance[459];

		public static EventFunctionItem SetRanshanThreeCorpseFollowing => Instance[460];

		public static EventFunctionItem AdventureAddElementItemPoison => Instance[461];

		public static EventFunctionItem AdventureTransferItemToCharacter => Instance[462];

		public static EventFunctionItem AdventureTaiwuShowDialog => Instance[463];

		public static EventFunctionItem AdventureElementShowDialog => Instance[464];

		public static EventFunctionItem AdventureTaiwuAtBlockByElementId => Instance[465];

		public static EventFunctionItem AdventureTaiwuAtBlockByElementCoreId => Instance[466];

		public static EventFunctionItem AdventureTaiwuAtBlockByElementTags => Instance[467];

		public static EventFunctionItem AdventureTaiwuDistanceToElementById => Instance[468];

		public static EventFunctionItem AdventureTaiwuDistanceToElementByCoreId => Instance[469];

		public static EventFunctionItem AdventureTaiwuDistanceToElementByTags => Instance[470];

		public static EventFunctionItem AdventureCheckElementItemSubType => Instance[471];

		public static EventFunctionItem AdventureSelectElementRandomItemBySubType => Instance[472];

		public static EventFunctionItem QuerySettlementSect => Instance[475];

		public static EventFunctionItem GenerateSectComplementCombatSkillBookByGrade => Instance[476];

		public static EventFunctionItem GenerateMatchItem => Instance[675];

		public static EventFunctionItem SelectItemFromList => Instance[477];

		public static EventFunctionItem RemoveItemFromList => Instance[478];

		public static EventFunctionItem AddItemToList => Instance[479];

		public static EventFunctionItem AddItemListToList => Instance[676];

		public static EventFunctionItem DeleteAllItemFromList => Instance[480];

		public static EventFunctionItem AdventureFindElementByCharacterId => Instance[487];

		public static EventFunctionItem CheckTaiwuChickenCount => Instance[488];

		public static EventFunctionItem RemoveArgBoxValue => Instance[489];

		public static EventFunctionItem ClearArgBoxValue => Instance[490];

		public static EventFunctionItem AdventureFindElementMeetCondition => Instance[491];

		public static EventFunctionItem AdventureFindElementAtLocationByTags => Instance[492];

		public static EventFunctionItem CanStartRelationHusbandOrWife => Instance[493];

		public static EventFunctionItem GetTaiwuKidnappedCharacterList => Instance[494];

		public static EventFunctionItem AdventureGetElementKidnappedCharacterList => Instance[495];

		public static EventFunctionItem AdventureStartCricketCombat => Instance[496];

		public static EventFunctionItem AdventureSaveElementBlockIndex => Instance[497];

		public static EventFunctionItem AdventureSaveTaiwuBlockIndex => Instance[498];

		public static EventFunctionItem AdventureCheckElementBindCharacter => Instance[499];

		public static EventFunctionItem AdventureGetBlockListByGroup => Instance[500];

		public static EventFunctionItem AdventureCheckTaiwuAtBlock => Instance[501];

		public static EventFunctionItem AdventureGetElementBigBlockList => Instance[502];

		public static EventFunctionItem AdventureGetTaiwuBigBlockList => Instance[503];

		public static EventFunctionItem AdventureGetBlockElementList => Instance[504];

		public static EventFunctionItem AdventureCameraMoveToBlock => Instance[505];

		public static EventFunctionItem AdventureDelayAction => Instance[776];

		public static EventFunctionItem AdventureElementMoveToBlock => Instance[506];

		public static EventFunctionItem AdventureCheckElementAtBlockById => Instance[507];

		public static EventFunctionItem AdventureCheckElementAtBlockByCoreId => Instance[508];

		public static EventFunctionItem AdventureCheckElementAtBlockByTag => Instance[509];

		public static EventFunctionItem AdventureElementDirectionalMove => Instance[510];

		public static EventFunctionItem AdventureElementDirectionalMoveNew => Instance[777];

		public static EventFunctionItem CheckAdventureElementDirectionalPassable => Instance[511];

		public static EventFunctionItem AddAudioCommand => Instance[512];

		public static EventFunctionItem ChangeMusicStatusWithFade => Instance[514];

		public static EventFunctionItem AdventureElementParametricDirectionalMove => Instance[518];

		public static EventFunctionItem CheckAdventureElementParametricDirectionalPassable => Instance[519];

		public static EventFunctionItem CheckAdventureTaiwuDirectionalPassable => Instance[521];

		public static EventFunctionItem CheckAdventureTaiwuDirectionalElementCount => Instance[522];

		public static EventFunctionItem AdventureChangeElementCountAtTaiwuDirectionalBlock => Instance[523];

		public static EventFunctionItem AdventureSaveElementByIdAtTaiwuDirectionalBlock => Instance[524];

		public static EventFunctionItem ChangeCharacterExp => Instance[525];

		public static EventFunctionItem CheckTaiwuHaveReadingBook => Instance[604];

		public static EventFunctionItem GetTaiwuReadingBook => Instance[605];

		public static EventFunctionItem TaiwuReadingBook => Instance[526];

		public static EventFunctionItem TaiwuAddReadingEvent => Instance[527];

		public static EventFunctionItem AdventureShowHideCloudByViewAtGroup => Instance[528];

		public static EventFunctionItem AdventureHideCloudAtGroup => Instance[529];

		public static EventFunctionItem ShowExchangePanel => Instance[530];

		public static EventFunctionItem SaveCharacterCombatSkill => Instance[531];

		public static EventFunctionItem ChangeTaiwuCombatSkillProficiency => Instance[532];

		public static EventFunctionItem TeachCombatSkill => Instance[533];

		public static EventFunctionItem GetCombatPower => Instance[536];

		public static EventFunctionItem GetItemGrade => Instance[537];

		public static EventFunctionItem CheckItemGrade => Instance[538];

		public static EventFunctionItem HasRelation => Instance[539];

		public static EventFunctionItem AddOneWayRelationType => Instance[861];

		public static EventFunctionItem AddRelation => Instance[955];

		public static EventFunctionItem RemoveRelation => Instance[956];

		public static EventFunctionItem AdventureGetElementsInAction => Instance[545];

		public static EventFunctionItem AdventureGetElementsInActionWithElement => Instance[546];

		public static EventFunctionItem SetInteractionCooldown => Instance[547];

		public static EventFunctionItem CheckInteractionCooldown => Instance[548];

		public static EventFunctionItem SetInteractionMonthCooldown => Instance[834];

		public static EventFunctionItem CheckInteractionMonthCooldown => Instance[835];

		public static EventFunctionItem AdventureTaiwuDirectionalMove => Instance[549];

		public static EventFunctionItem AdventureTaiwuDirectionalMoveNew => Instance[783];

		public static EventFunctionItem AdventureConsumeActionPoint => Instance[550];

		public static EventFunctionItem AdventureSaveTaiwuPreAndCurBlockIndex => Instance[551];

		public static EventFunctionItem AdventureSetTaiwuToBlockIndex => Instance[552];

		public static EventFunctionItem CheckItemGradeByOperator => Instance[553];

		public static EventFunctionItem AdventureCreateElementRandomAtBigBlock => Instance[554];

		public static EventFunctionItem CharacterCheckNeiliTypePercent => Instance[555];

		public static EventFunctionItem AdventureInteractCaravan => Instance[557];

		public static EventFunctionItem ResetTransactionData => Instance[889];

		public static EventFunctionItem AdventureElementAnyFollowTarget => Instance[561];

		public static EventFunctionItem SetAdventureElementFollowTargetBlock => Instance[562];

		public static EventFunctionItem SetAdventureElementFollowTargetElement => Instance[563];

		public static EventFunctionItem ClearAdventureElementFollowTarget => Instance[564];

		public static EventFunctionItem AdventureSaveElementCurBlockIndex => Instance[565];

		public static EventFunctionItem AdventureSetGroupBlockCloud => Instance[574];

		public static EventFunctionItem AdventureSetBlockCloud => Instance[575];

		public static EventFunctionItem AdventureSetBlockListCloud => Instance[576];

		public static EventFunctionItem AdventureGetBlockListAroundElement => Instance[579];

		public static EventFunctionItem QueryAdventureCountInWorld => Instance[844];

		public static EventFunctionItem AdventureGenerate => Instance[582];

		public static EventFunctionItem AdventureGenerateNotCallCharacter => Instance[822];

		public static EventFunctionItem AdventureFillPresetCharacter => Instance[838];

		public static EventFunctionItem CreateFixedCharacterGrave => Instance[583];

		public static EventFunctionItem TeleportMoveTaiwuToBlock => Instance[584];

		public static EventFunctionItem SetNextSwordTombAdventureCooldown => Instance[587];

		public static EventFunctionItem RemoveSwordTombFromLocation => Instance[588];

		public static EventFunctionItem GetDefeatSwordTombCount => Instance[589];

		public static EventFunctionItem GetAdventureElementFollowTargetBlock => Instance[590];

		public static EventFunctionItem GetAdventureElementFollowTargetElement => Instance[591];

		public static EventFunctionItem AdventureElementArrivedTarget => Instance[592];

		public static EventFunctionItem StartInformationSelect => Instance[593];

		public static EventFunctionItem FinishInformationSelect => Instance[594];

		public static EventFunctionItem ApplyNormalInformation => Instance[595];

		public static EventFunctionItem GetRandomItemTemplate => Instance[596];

		public static EventFunctionItem ClearRegisterItemFilter => Instance[597];

		public static EventFunctionItem GetSectCombatSkillBookByGrade => Instance[599];

		public static EventFunctionItem SaveXiangshuLevel => Instance[600];

		public static EventFunctionItem AddTaiwuBreakoutStepBase => Instance[601];

		public static EventFunctionItem AddTaiwuBreakoutBaseSuccessRate => Instance[602];

		public static EventFunctionItem MajorEventSetAtmosphereType => Instance[606];

		public static EventFunctionItem MajorEventUnsetAtmosphereType => Instance[607];

		public static EventFunctionItem GetLastSwordTombLocation => Instance[608];

		public static EventFunctionItem ActivateSwordTombAtLocation => Instance[609];

		public static EventFunctionItem ActivateRemainingSwordTombs => Instance[615];

		public static EventFunctionItem DeactivateAllSwordTombAdventure => Instance[610];

		public static EventFunctionItem MakeSectCharactersApproveTaiwuInWulinConference => Instance[612];

		public static EventFunctionItem YufuKillTopTenRankingCharacters => Instance[613];

		public static EventFunctionItem SaveWorld => Instance[616];

		public static EventFunctionItem MakeWorldChaos => Instance[617];

		public static EventFunctionItem MakeTaiwuVillageAreaGraduallyBroken => Instance[618];

		public static EventFunctionItem CheckCharacterCarrierGrade => Instance[619];

		public static EventFunctionItem CheckInventoryItemOperationType => Instance[620];

		public static EventFunctionItem AdventureCreateElementAtAllBlock => Instance[622];

		public static EventFunctionItem AdventureTeleportMoveTaiwuToBlock => Instance[623];

		public static EventFunctionItem AdventureGetElementListAtBlockByTag => Instance[624];

		public static EventFunctionItem CheckCharacterEquipItemTemplate => Instance[625];

		public static EventFunctionItem SetCarrierTamePoint => Instance[626];

		public static EventFunctionItem GetHighestOrLowestHappinessCharacter => Instance[627];

		public static EventFunctionItem CreateChickenKingToTaiwuVillage => Instance[628];

		public static EventFunctionItem RemoveElementFromList => Instance[629];

		public static EventFunctionItem GetSwordTombAdventureMaxMonthCount => Instance[630];

		public static EventFunctionItem StartCommonSelectCharacterFeature => Instance[631];

		public static EventFunctionItem TrySetListValue => Instance[632];

		public static EventFunctionItem SortListValueReturnIndexList => Instance[633];

		public static EventFunctionItem CreateTeammateWithXiangshuCloth => Instance[634];

		public static EventFunctionItem SetTutorialFunctionStatus => Instance[635];

		public static EventFunctionItem SetAllTutorialFunctionStatuses => Instance[646];

		public static EventFunctionItem CheckCurrentTutorialChapter => Instance[636];

		public static EventFunctionItem CheckAdventureBlcokIsInCloud => Instance[639];

		public static EventFunctionItem SettlementHasBuilding => Instance[641];

		public static EventFunctionItem CheckCharacterLoopingNeigong => Instance[642];

		public static EventFunctionItem HuanxingUnlockFuyuPower => Instance[643];

		public static EventFunctionItem SetCharacterInvincibleInCombat => Instance[851];

		public static EventFunctionItem CheckAdventureElementDirectionalElementCount => Instance[644];

		public static EventFunctionItem TutorialRemoveBuildingAreaBambooHouse => Instance[645];

		public static EventFunctionItem GetMapBlockByCoordinate => Instance[647];

		public static EventFunctionItem ClearMapBlockCurrResources => Instance[648];

		public static EventFunctionItem SetMapBlockCurrResource => Instance[649];

		public static EventFunctionItem FillMapBlockCurrResourceByType => Instance[650];

		public static EventFunctionItem SetForceCollectResourceItem => Instance[651];

		public static EventFunctionItem SetForceCollectResourceAmount => Instance[652];

		public static EventFunctionItem TutorialUnlockProfessionSkill => Instance[653];

		public static EventFunctionItem TryGetEventTriggerParameter => Instance[654];

		public static EventFunctionItem CheckProfessionSkill => Instance[655];

		public static EventFunctionItem AdventureCreateBlockList => Instance[656];

		public static EventFunctionItem AdventureBlockListAddElement => Instance[657];

		public static EventFunctionItem AdventureBlockListSetEffect => Instance[658];

		public static EventFunctionItem AdventureBlockSetEffect => Instance[686];

		public static EventFunctionItem AdventureSetGlobalEffect => Instance[659];

		public static EventFunctionItem ChangeCharacterRelationBecomeHusbandOrWife => Instance[660];

		public static EventFunctionItem LoadDreamBackArchive => Instance[662];

		public static EventFunctionItem SaveArchiveForDreamBack => Instance[712];

		public static EventFunctionItem CheckHasDreamBackArchive => Instance[663];

		public static EventFunctionItem CheckAdventureBlcokElementCount => Instance[664];

		public static EventFunctionItem PrepareSectMembersAndTaiwuVillagersForSpiritualWanderPlace => Instance[665];

		public static EventFunctionItem SetXiangshuMinionsSurroundTaiwuVillage => Instance[666];

		public static EventFunctionItem GetLastXiangshuAvatar => Instance[667];

		public static EventFunctionItem GetLeaderInMaxApprovingRateSectByGoodness => Instance[668];

		public static EventFunctionItem AdventureCreateElementRandomAtGroup => Instance[673];

		public static EventFunctionItem AdventureGetTaiwuLocationElementListByTag => Instance[669];

		public static EventFunctionItem AdventureSaveNearestElementByTag => Instance[670];

		public static EventFunctionItem AdventureCheckBlockHaveElement => Instance[671];

		public static EventFunctionItem AdventureStopElementActionByTag => Instance[672];

		public static EventFunctionItem GetCharacterInventoryItemCount => Instance[677];

		public static EventFunctionItem GetMartialArtTournamentReward => Instance[678];

		public static EventFunctionItem SetHideAllTeammates => Instance[681];

		public static EventFunctionItem GetCharacterAttraction => Instance[682];

		public static EventFunctionItem CheckCharacterAttraction => Instance[683];

		public static EventFunctionItem GetCharacterCurrMainAttribute => Instance[684];

		public static EventFunctionItem CreateEnemyCharacterByConsummateLevel => Instance[685];

		public static EventFunctionItem TriggerCricketCatch => Instance[693];

		public static EventFunctionItem AdventureGetElementListAroundElement => Instance[694];

		public static EventFunctionItem GetRangeBetweenElement => Instance[695];

		public static EventFunctionItem AdventureSaveAllElementLocation => Instance[696];

		public static EventFunctionItem AdventureSaveElementLocation => Instance[697];

		public static EventFunctionItem AdventureStartSelectElement => Instance[700];

		public static EventFunctionItem AdventureIsActive => Instance[890];

		public static EventFunctionItem TriggeredGuidingChapter => Instance[701];

		public static EventFunctionItem GenerateEnemiesInBornArea => Instance[705];

		public static EventFunctionItem CheckBlockHasCricket => Instance[706];

		public static EventFunctionItem GenerateCricketPlaceNearTaiwu => Instance[707];

		public static EventFunctionItem SetCricketAtTaiwuLocationFake => Instance[708];

		public static EventFunctionItem OpenMonthNotifyForStartCricketContent => Instance[709];

		public static EventFunctionItem TaiwuRecordLifeSummary => Instance[710];

		public static EventFunctionItem RequestSetStat => Instance[711];

		public static EventFunctionItem CreateMissNingOfTaiwuVillage => Instance[713];

		public static EventFunctionItem StartShowSwordTombCreate => Instance[714];

		public static EventFunctionItem ApplyHelpSectInStory => Instance[715];

		public static EventFunctionItem ChangeBlockTemplate => Instance[721];

		public static EventFunctionItem OpenLegacyActivateDisplay => Instance[722];

		public static EventFunctionItem SetTaiwuVillageShowShrine => Instance[723];

		public static EventFunctionItem SetTaiwuAsLeaderOfTaiwuVillage => Instance[724];

		public static EventFunctionItem SetFirstSwordTombFinished => Instance[725];

		public static EventFunctionItem HideAllMapBlockCharacters => Instance[726];

		public static EventFunctionItem CreateAllSwordTombAdventure => Instance[727];

		public static EventFunctionItem CreateEightSwordTombAdventure => Instance[933];

		public static EventFunctionItem TaiwuGroupFull => Instance[728];

		public static EventFunctionItem CharacterJoinTaiwu => Instance[729];

		public static EventFunctionItem CricketPolymorphReturnByDead => Instance[730];

		public static EventFunctionItem CheckCricketPolymorphState => Instance[731];

		public static EventFunctionItem CricketPolymorph => Instance[732];

		public static EventFunctionItem CricketPolymorphEffect => Instance[824];

		public static EventFunctionItem CheckCricketColorId => Instance[733];

		public static EventFunctionItem GetOrCreateFirstXiangshuAvatarForStory => Instance[734];

		public static EventFunctionItem CreateBreakTombXiangshuAvatar => Instance[735];

		public static EventFunctionItem GetLegendaryBookItem => Instance[736];

		public static EventFunctionItem GetSwordFragmentTemplateByCharacter => Instance[737];

		public static EventFunctionItem SetEventRoleAlternativeName => Instance[738];

		public static EventFunctionItem StartSetCharacterName => Instance[739];

		public static EventFunctionItem FinishSetCharacterName => Instance[740];

		public static EventFunctionItem CheckXiangshuAvatarTaskStatus => Instance[741];

		public static EventFunctionItem ChangeMusicVolume => Instance[742];

		public static EventFunctionItem PlayMusicForCount => Instance[743];

		public static EventFunctionItem AutoEquipItems => Instance[745];

		public static EventFunctionItem AutoEquipCombatSkills => Instance[746];

		public static EventFunctionItem AutoAllocateNeili => Instance[747];

		public static EventFunctionItem ChangeEquipment => Instance[781];

		public static EventFunctionItem SwordTombInvasion => Instance[748];

		public static EventFunctionItem TryGetBlockXiangshuAvatar => Instance[749];

		public static EventFunctionItem CheckCharacterIsAnySectMember => Instance[750];

		public static EventFunctionItem CheckDefeatSwordTombCount => Instance[751];

		public static EventFunctionItem CheckSectMainStoryTriggerConditions => Instance[752];

		public static EventFunctionItem CharacterRestoreAllStatus => Instance[753];

		public static EventFunctionItem IsExorcismNeedToBeDisabled => Instance[754];

		public static EventFunctionItem SetExorcismEnabled => Instance[755];

		public static EventFunctionItem GetExorcismEnabled => Instance[756];

		public static EventFunctionItem CheckCharacterIsXiangshuAvatar => Instance[757];

		public static EventFunctionItem GetXiangshuAvatarIdByCharacter => Instance[758];

		public static EventFunctionItem MarkTaiwuDieOfCombatWithXiangshuAttacking => Instance[759];

		public static EventFunctionItem SetXiangshuDisplayStatus => Instance[760];

		public static EventFunctionItem BlockHasNormalHeavenlyTree => Instance[761];

		public static EventFunctionItem GetSwordTombInformation => Instance[762];

		public static EventFunctionItem StartSelectFilteredCharacters => Instance[763];

		public static EventFunctionItem AnySelectableFilteredCharacter => Instance[764];

		public static EventFunctionItem ClearAreaCricket => Instance[765];

		public static EventFunctionItem SetNextSwordTombCountDownDate => Instance[766];

		public static EventFunctionItem DeepValleyToSmallVillage => Instance[770];

		public static EventFunctionItem SmallVillageToBrokenArea => Instance[771];

		public static EventFunctionItem BrokenAreaToTaiwuVillageArea => Instance[772];

		public static EventFunctionItem DeepValleyToTaiwuVillageArea => Instance[773];

		public static EventFunctionItem TravelToPastTaiwuVillageArea => Instance[813];

		public static EventFunctionItem BackFromPastTaiwuVillageArea => Instance[820];

		public static EventFunctionItem GenerateMainStoryXiangshuMinion => Instance[848];

		public static EventFunctionItem GenerateChapter9XiangshuMinion => Instance[842];

		public static EventFunctionItem CheckChapter9TaiwuEscapeXiangshuMinionRange => Instance[843];

		public static EventFunctionItem CharacterMakeLove => Instance[779];

		public static EventFunctionItem EventTriggerParameterIsBuildingBlockTemplate => Instance[784];

		public static EventFunctionItem CheckSectSpiritualDebtInteractionOccurred => Instance[785];

		public static EventFunctionItem AddFuyuFaith => Instance[786];

		public static EventFunctionItem SwordFragmentUnlockSkill => Instance[788];

		public static EventFunctionItem TaiwuHaveCheatOnSecretInformation => Instance[791];

		public static EventFunctionItem ShowUnlockSkillSlotAnim => Instance[792];

		public static EventFunctionItem SetAreaStoryWeather => Instance[793];

		public static EventFunctionItem AddCharacterExtraTitle => Instance[794];

		public static EventFunctionItem SelectCharacterCricket => Instance[795];

		public static EventFunctionItem StartCricketCombat => Instance[796];

		public static EventFunctionItem StartCricketCombatWithConfig => Instance[797];

		public static EventFunctionItem GetSimulateCricketBattleResult => Instance[798];

		public static EventFunctionItem ClearCricketItemShow => Instance[799];

		public static EventFunctionItem GetItemCurrDurability => Instance[800];

		public static EventFunctionItem SetItemCurrDurability => Instance[801];

		public static EventFunctionItem GetItemMaxDurability => Instance[802];

		public static EventFunctionItem CheckCricketWinsCount => Instance[803];

		public static EventFunctionItem CheckCharCricketCount => Instance[804];

		public static EventFunctionItem CheckCricketAlive => Instance[805];

		public static EventFunctionItem AdjustCricketExtraAge => Instance[806];

		public static EventFunctionItem BuyCricketStart => Instance[807];

		public static EventFunctionItem BuyCricketOption => Instance[808];

		public static EventFunctionItem EventSetItemList => Instance[837];

		public static EventFunctionItem SetCoverCricketJarGradeList => Instance[840];

		public static EventFunctionItem CreateNoMindGuy => Instance[814];

		public static EventFunctionItem GetCharFame => Instance[815];

		public static EventFunctionItem GetCharPositiveFameValue => Instance[816];

		public static EventFunctionItem GetCharNegativeFameValue => Instance[817];

		public static EventFunctionItem CompareCharFame => Instance[818];

		public static EventFunctionItem SetIconPlateIsUnlocked => Instance[819];

		public static EventFunctionItem SetUnknownDateDisplay => Instance[821];

		public static EventFunctionItem ReleaseNoMindGuys => Instance[823];

		public static EventFunctionItem GetNoMindGuyList => Instance[825];

		public static EventFunctionItem BanNormalAttackInTutorial => Instance[826];

		public static EventFunctionItem BanMoveInTutorial => Instance[827];

		public static EventFunctionItem BanEnemyAiInTutorial => Instance[828];

		public static EventFunctionItem GenerateEnemyNestMinion => Instance[830];

		public static EventFunctionItem ComplementEnemyNestMinion => Instance[831];

		public static EventFunctionItem ClearEnemyNestMinion => Instance[855];

		public static EventFunctionItem ClearResourceDisasterStatus => Instance[895];

		public static EventFunctionItem ClearElopeWithLoveStatus => Instance[883];

		public static EventFunctionItem ClearSwordTombStatus => Instance[887];

		public static EventFunctionItem GetThreeVitalsBetray => Instance[833];

		public static EventFunctionItem HealAllDefeatMark => Instance[839];

		public static EventFunctionItem GetMainStoryEndingLine => Instance[938];

		public static EventFunctionItem CurrAliveTwelveImmortalsTotalCount => Instance[845];

		public static EventFunctionItem GenerateTwelveImmortals => Instance[846];

		public static EventFunctionItem IsTwelveImmortalsMember => Instance[847];

		public static EventFunctionItem SetDivineFlameIsUnlocked => Instance[852];

		public static EventFunctionItem SetNpcFollowTaiwu => Instance[853];

		public static EventFunctionItem SetNoMindGuyFollowTaiwu => Instance[854];

		public static EventFunctionItem CreateThreeWayDemon => Instance[857];

		public static EventFunctionItem TaiwuSetClothing => Instance[858];

		public static EventFunctionItem TeleportToTaiwuVillage => Instance[859];

		public static EventFunctionItem EventClearListeningEvent => Instance[862];

		public static EventFunctionItem TaiwuKillTwelveImmortals => Instance[863];

		public static EventFunctionItem AssisterKillTwelveImmortals => Instance[864];

		public static EventFunctionItem SetTwelveImmortalsAssistState => Instance[870];

		public static EventFunctionItem CharacterInSuxiaImpactRange => Instance[865];

		public static EventFunctionItem MoveCharacterAwaySuxiaImpactRange => Instance[866];

		public static EventFunctionItem LearnTwelveImmortalsCombatSkill => Instance[867];

		public static EventFunctionItem MakeChaishanBroken => Instance[868];

		public static EventFunctionItem RestoreAllAreaDestroyedBlocks => Instance[869];

		public static EventFunctionItem CreateEmeiGuidance => Instance[871];

		public static EventFunctionItem ClearEmeiGuidance => Instance[872];

		public static EventFunctionItem GuideEmeiCharacter => Instance[873];

		public static EventFunctionItem GetCharacterEmeiGuidanceType => Instance[874];

		public static EventFunctionItem GetCharacterEmeiGuidanceChanged => Instance[875];

		public static EventFunctionItem GetCharacterEmeiGuidanceNotch => Instance[876];

		public static EventFunctionItem GetCharacterEmeiGuidanceByType => Instance[877];

		public static EventFunctionItem CheckCharacterFavorabilityTypeForExchangeBook => Instance[878];

		public static EventFunctionItem EmeiInteractionOneCheck => Instance[879];

		public static EventFunctionItem EmeiInteractionTwoCheck => Instance[880];

		public static EventFunctionItem EmeiInteractionOneAdd => Instance[881];

		public static EventFunctionItem EmeiInteractionTwoAdd => Instance[882];

		public static EventFunctionItem IsCricketPolymorph => Instance[884];

		public static EventFunctionItem ActiveAdventureOrMajorEventInTaiwuBlock => Instance[885];

		public static EventFunctionItem UpdateFixedCharacterMonthlyMovement => Instance[886];

		public static EventFunctionItem CheckCharacterAlertnessForTeach => Instance[888];

		public static EventFunctionItem IsCharacterFollowingTaiwu => Instance[891];

		public static EventFunctionItem IsProfessionSkillEquipped => Instance[892];

		public static EventFunctionItem AddFuyuFaithBySecure => Instance[893];

		public static EventFunctionItem AddTianjiefuluBySecure => Instance[894];

		public static EventFunctionItem CheckSettlementHasChicken => Instance[896];

		public static EventFunctionItem CheckFirstMartialArtTournamentHostSect => Instance[897];

		public static EventFunctionItem CheckCharacterCombatSkillRatio50 => Instance[898];

		public static EventFunctionItem AdventureRemoveElementAndHandleBoundCharacterByInstanceId => Instance[899];

		public static EventFunctionItem GetChickenDisplayName => Instance[900];

		public static EventFunctionItem CreateXiangshuTower => Instance[901];

		public static EventFunctionItem ConvertFixedCharacter => Instance[902];

		public static EventFunctionItem ConvertRandomEnemy => Instance[943];

		public static EventFunctionItem ShowXiangshuLevelChanged => Instance[920];

		public static EventFunctionItem RemoveAllSwordTomb => Instance[905];

		public static EventFunctionItem RemoveAllSwordTombAdventure => Instance[928];

		public static EventFunctionItem CheckHasSwordTomb => Instance[921];

		public static EventFunctionItem SmarterChickenSetKingMonthlyEventInvoked => Instance[906];

		public static EventFunctionItem SmarterChickenReturn => Instance[908];

		public static EventFunctionItem CheckSmarterChickenState => Instance[909];

		public static EventFunctionItem SmarterChickenBecomeCharacter => Instance[910];

		public static EventFunctionItem PagodaofTheFallenCreateTwelveImmortals => Instance[911];

		public static EventFunctionItem TaiwuAsXiangshuEntered => Instance[912];

		public static EventFunctionItem TaiwuAsXiangshuGetUndefeatedAvatarTemplateId => Instance[913];

		public static EventFunctionItem DefeatFiveLoong => Instance[961];

		public static EventFunctionItem ConvertFiveLoongToCarrier => Instance[914];

		public static EventFunctionItem ConvertFiveLoongCarrierToHuman => Instance[917];

		public static EventFunctionItem ConvertFiveLoongHuman => Instance[918];

		public static EventFunctionItem FreeFiveLoongCarrier => Instance[930];

		public static EventFunctionItem GetFiveLoongCharacterCreated => Instance[915];

		public static EventFunctionItem GetFiveLoongState => Instance[916];

		public static EventFunctionItem GetLoongByEnemyId => Instance[937];

		public static EventFunctionItem IsItemKeyLoongCarrier => Instance[922];

		public static EventFunctionItem GotJiaoEgg => Instance[923];

		public static EventFunctionItem GotLoongScale => Instance[936];

		public static EventFunctionItem HaveDefeatFiveLoong => Instance[924];

		public static EventFunctionItem CharacterIsLoong => Instance[949];

		public static EventFunctionItem GetFiveLoongCharacter => Instance[942];

		public static EventFunctionItem GetLoongEnemyTemplateId => Instance[944];

		public static EventFunctionItem GetLoongEnemyTemplateIdByItemKey => Instance[946];

		public static EventFunctionItem CanTameLoong => Instance[939];

		public static EventFunctionItem CheckDlcInstalled => Instance[919];

		public static EventFunctionItem AdoptChicken => Instance[925];

		public static EventFunctionItem CreateChickenEventActor => Instance[966];

		public static EventFunctionItem IsEscapedChicken => Instance[926];

		public static EventFunctionItem CharacterIsChicken => Instance[959];

		public static EventFunctionItem TaiwuAsXiangshuDeleteCharacter => Instance[929];

		public static EventFunctionItem AddTwelveImmortalsFeature => Instance[931];

		public static EventFunctionItem AddTwelveImmortalsFeatureForTwelveImmortals => Instance[957];

		public static EventFunctionItem ChangeProfessionSeniority => Instance[932];

		public static EventFunctionItem SetTaiwuAsXiangshuTwelveImmortalsStatus => Instance[934];

		public static EventFunctionItem ClearBlockEnemies => Instance[935];

		public static EventFunctionItem TaiwuAsXiangshuWipeOut => Instance[941];

		public static EventFunctionItem StartUnlockTaiwuStation => Instance[945];

		public static EventFunctionItem AddTaiwuVillageStoneClaimed => Instance[951];

		public static EventFunctionItem AdventureRemoveElementsAndHandleBoundCharactersByCoreId => Instance[947];

		public static EventFunctionItem AdventureRemoveElementsAndHandleBoundCharactersByTag => Instance[948];

		public static EventFunctionItem OpenTaiwuAsXiangshuTowerFinalLayer => Instance[950];

		public static EventFunctionItem ApplyMonthlyEventAnimalTamingResult => Instance[952];

		public static EventFunctionItem JumpToMonthlyEventAnimalTamingEvent => Instance[953];

		public static EventFunctionItem StartMonthlyEventAnimalTamingEventCombat => Instance[954];

		public static EventFunctionItem CheckExtraTaskFinished => Instance[958];

		public static EventFunctionItem ChickenPolymorphEffect => Instance[960];

		public static EventFunctionItem IsConvertToIntelligentConfig => Instance[962];

		public static EventFunctionItem CharacterHasSpecialAvatar => Instance[963];

		public static EventFunctionItem ReserveThreeRealmsPowerPerformance => Instance[964];

		public static EventFunctionItem ShowNewFunctionUnlock => Instance[965];

		public static EventFunctionItem GetIsQuickStartGame => Instance[967];

		public static EventFunctionItem OpenDreamBackItemSelect => Instance[968];

		public static EventFunctionItem ConfirmDreamBackItemSelect => Instance[969];
	}

	public static EventFunction Instance = new EventFunction();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "ParameterTypes", "ParameterNames", "ReturnValue", "FollowUp", "RequiredPreviousCommands", "InGameHint", "TemplateId" };

	internal override int ToInt(int value)
	{
		return value;
	}

	internal override int ToTemplateId(int value)
	{
		return value;
	}

	private void CreateItems0()
	{
		_dataArray.Add(new EventFunctionItem(0, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_0"), LocalStringManager.GetConfig("EventFunction_language", "Desc_0"), new int[1] { 72 }, new string[0], -1, indentNext: true, 5, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_0")));
		_dataArray.Add(new EventFunctionItem(1, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_1"), LocalStringManager.GetConfig("EventFunction_language", "Desc_1"), new int[0], new string[0], -1, indentNext: true, -1, canCreateManually: true, new List<int> { 0, 2 }, allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_1")));
		_dataArray.Add(new EventFunctionItem(2, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_2"), LocalStringManager.GetConfig("EventFunction_language", "Desc_2"), new int[1] { 72 }, new string[0], -1, indentNext: true, -1, canCreateManually: true, new List<int> { 0, 2 }, allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_2")));
		_dataArray.Add(new EventFunctionItem(3, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_3"), LocalStringManager.GetConfig("EventFunction_language", "Desc_3"), new int[0], new string[0], -1, indentNext: true, 5, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_3")));
		_dataArray.Add(new EventFunctionItem(4, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_4"), LocalStringManager.GetConfig("EventFunction_language", "Desc_4"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_4")));
		_dataArray.Add(new EventFunctionItem(5, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_5"), LocalStringManager.GetConfig("EventFunction_language", "Desc_5"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: false, new List<int> { 0, 1, 2, 3, 109, 110 }, allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_5")));
		_dataArray.Add(new EventFunctionItem(6, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_6"), LocalStringManager.GetConfig("EventFunction_language", "Desc_6"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_6")));
		_dataArray.Add(new EventFunctionItem(7, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_7"), LocalStringManager.GetConfig("EventFunction_language", "Desc_7"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_7_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_7")));
		_dataArray.Add(new EventFunctionItem(8, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_8"), LocalStringManager.GetConfig("EventFunction_language", "Desc_8"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_8_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_8")));
		_dataArray.Add(new EventFunctionItem(9, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_9"), LocalStringManager.GetConfig("EventFunction_language", "Desc_9"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_9")));
		_dataArray.Add(new EventFunctionItem(10, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_10"), LocalStringManager.GetConfig("EventFunction_language", "Desc_10"), new int[1], new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_10_0") }, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_10")));
		_dataArray.Add(new EventFunctionItem(11, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_11"), LocalStringManager.GetConfig("EventFunction_language", "Desc_11"), new int[2] { 1, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_11_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_11_1")
		}, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_11")));
		_dataArray.Add(new EventFunctionItem(12, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_12"), LocalStringManager.GetConfig("EventFunction_language", "Desc_12"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_12_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_12")));
		_dataArray.Add(new EventFunctionItem(13, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_13"), LocalStringManager.GetConfig("EventFunction_language", "Desc_13"), new int[1] { 5 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_13_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_13")));
		_dataArray.Add(new EventFunctionItem(14, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_14"), LocalStringManager.GetConfig("EventFunction_language", "Desc_14"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_14_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_14")));
		_dataArray.Add(new EventFunctionItem(15, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_15"), LocalStringManager.GetConfig("EventFunction_language", "Desc_15"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_15_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_15")));
		_dataArray.Add(new EventFunctionItem(16, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_16"), LocalStringManager.GetConfig("EventFunction_language", "Desc_16"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_16_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_16")));
		_dataArray.Add(new EventFunctionItem(17, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_17"), LocalStringManager.GetConfig("EventFunction_language", "Desc_17"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_17")));
		_dataArray.Add(new EventFunctionItem(18, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_18"), LocalStringManager.GetConfig("EventFunction_language", "Desc_18"), new int[3] { 6, 19, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_18_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_18_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_18_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_18")));
		_dataArray.Add(new EventFunctionItem(19, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_19"), LocalStringManager.GetConfig("EventFunction_language", "Desc_19"), new int[3] { 6, 19, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_19_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_19_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_19_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_19")));
		_dataArray.Add(new EventFunctionItem(20, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_20"), LocalStringManager.GetConfig("EventFunction_language", "Desc_20"), new int[4] { 6, 14, 3, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_20_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_20_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_20_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_20_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_20")));
		_dataArray.Add(new EventFunctionItem(21, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_21"), LocalStringManager.GetConfig("EventFunction_language", "Desc_21"), new int[4] { 6, 14, 3, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_21_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_21_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_21_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_21_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_21")));
		_dataArray.Add(new EventFunctionItem(22, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_22"), LocalStringManager.GetConfig("EventFunction_language", "Desc_22"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_22")));
		_dataArray.Add(new EventFunctionItem(23, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_23"), LocalStringManager.GetConfig("EventFunction_language", "Desc_23"), new int[4] { 6, 15, 1, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_23_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_23_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_23_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_23_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_23")));
		_dataArray.Add(new EventFunctionItem(24, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_24"), LocalStringManager.GetConfig("EventFunction_language", "Desc_24"), new int[4] { 6, 15, 1, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_24_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_24_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_24_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_24_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_24")));
		_dataArray.Add(new EventFunctionItem(25, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_25"), LocalStringManager.GetConfig("EventFunction_language", "Desc_25"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_25")));
		_dataArray.Add(new EventFunctionItem(26, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_26"), LocalStringManager.GetConfig("EventFunction_language", "Desc_26"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_26_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_26_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_26")));
		_dataArray.Add(new EventFunctionItem(27, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_27"), LocalStringManager.GetConfig("EventFunction_language", "Desc_27"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_27_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_27_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_27")));
		_dataArray.Add(new EventFunctionItem(28, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_28"), LocalStringManager.GetConfig("EventFunction_language", "Desc_28"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_28_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_28_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_28")));
		_dataArray.Add(new EventFunctionItem(29, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_29"), LocalStringManager.GetConfig("EventFunction_language", "Desc_29"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_29_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_29_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_29")));
		_dataArray.Add(new EventFunctionItem(30, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_30"), LocalStringManager.GetConfig("EventFunction_language", "Desc_30"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_30_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_30_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_30")));
		_dataArray.Add(new EventFunctionItem(31, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_31"), LocalStringManager.GetConfig("EventFunction_language", "Desc_31"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_31_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_31_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_31")));
		_dataArray.Add(new EventFunctionItem(32, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_32"), LocalStringManager.GetConfig("EventFunction_language", "Desc_32"), new int[4] { 6, 6, 1, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_32_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_32_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_32_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_32_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_32")));
		_dataArray.Add(new EventFunctionItem(33, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_33"), LocalStringManager.GetConfig("EventFunction_language", "Desc_33"), new int[4] { 6, 6, 1, 63 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_33")));
		_dataArray.Add(new EventFunctionItem(34, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_34"), LocalStringManager.GetConfig("EventFunction_language", "Desc_34"), new int[3] { 6, 29, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_34_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_34_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_34_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_34")));
		_dataArray.Add(new EventFunctionItem(35, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_35"), LocalStringManager.GetConfig("EventFunction_language", "Desc_35"), new int[2] { 6, 29 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_35")));
		_dataArray.Add(new EventFunctionItem(36, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_36"), LocalStringManager.GetConfig("EventFunction_language", "Desc_36"), new int[3] { 6, 6, 7 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_36_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_36_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_36_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_36")));
		_dataArray.Add(new EventFunctionItem(37, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_37"), LocalStringManager.GetConfig("EventFunction_language", "Desc_37"), new int[3] { 6, 6, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_37_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_37_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_37_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_37")));
		_dataArray.Add(new EventFunctionItem(38, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_38"), LocalStringManager.GetConfig("EventFunction_language", "Desc_38"), new int[2] { 6, 6 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_38_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_38_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_38")));
		_dataArray.Add(new EventFunctionItem(39, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_39"), LocalStringManager.GetConfig("EventFunction_language", "Desc_39"), new int[2] { 6, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_39_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_39_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_39")));
		_dataArray.Add(new EventFunctionItem(40, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_40"), LocalStringManager.GetConfig("EventFunction_language", "Desc_40"), new int[3] { 6, 6, 31 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_40_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_40_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_40_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_40")));
		_dataArray.Add(new EventFunctionItem(41, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_41"), LocalStringManager.GetConfig("EventFunction_language", "Desc_41"), new int[3] { 6, 7, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_41")));
		_dataArray.Add(new EventFunctionItem(42, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_42"), LocalStringManager.GetConfig("EventFunction_language", "Desc_42"), new int[5] { 6, 6, 7, 1, 3 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_42_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_42_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_42_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_42_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_42_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_42")));
		_dataArray.Add(new EventFunctionItem(43, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_43"), LocalStringManager.GetConfig("EventFunction_language", "Desc_43"), new int[3] { 6, 24, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_43_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_43_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_43_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_43")));
		_dataArray.Add(new EventFunctionItem(44, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_44"), LocalStringManager.GetConfig("EventFunction_language", "Desc_44"), new int[3] { 6, 25, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_44_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_44_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_44_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_44")));
		_dataArray.Add(new EventFunctionItem(45, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_45"), LocalStringManager.GetConfig("EventFunction_language", "Desc_45"), new int[2] { 6, 35 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_45")));
		_dataArray.Add(new EventFunctionItem(46, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_46"), LocalStringManager.GetConfig("EventFunction_language", "Desc_46"), new int[2] { 6, 36 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_46")));
		_dataArray.Add(new EventFunctionItem(47, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_47"), LocalStringManager.GetConfig("EventFunction_language", "Desc_47"), new int[1] { 30 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_47")));
		_dataArray.Add(new EventFunctionItem(48, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_48"), LocalStringManager.GetConfig("EventFunction_language", "Desc_48"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_48")));
		_dataArray.Add(new EventFunctionItem(49, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_49"), LocalStringManager.GetConfig("EventFunction_language", "Desc_49"), new int[2] { 6, 10 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_49")));
		_dataArray.Add(new EventFunctionItem(50, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_50"), LocalStringManager.GetConfig("EventFunction_language", "Desc_50"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_50")));
		_dataArray.Add(new EventFunctionItem(51, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_51"), LocalStringManager.GetConfig("EventFunction_language", "Desc_51"), new int[1] { 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_51")));
		_dataArray.Add(new EventFunctionItem(52, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_52"), LocalStringManager.GetConfig("EventFunction_language", "Desc_52"), new int[1] { 32 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_52")));
		_dataArray.Add(new EventFunctionItem(53, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_53"), LocalStringManager.GetConfig("EventFunction_language", "Desc_53"), new int[1] { 33 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_53")));
		_dataArray.Add(new EventFunctionItem(54, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_54"), LocalStringManager.GetConfig("EventFunction_language", "Desc_54"), new int[2] { 12, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_54")));
		_dataArray.Add(new EventFunctionItem(55, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_55"), LocalStringManager.GetConfig("EventFunction_language", "Desc_55"), new int[2] { 10, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_55")));
		_dataArray.Add(new EventFunctionItem(56, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_56"), LocalStringManager.GetConfig("EventFunction_language", "Desc_56"), new int[2] { 10, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_56")));
		_dataArray.Add(new EventFunctionItem(57, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_57"), LocalStringManager.GetConfig("EventFunction_language", "Desc_57"), new int[1] { 9 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_57")));
		_dataArray.Add(new EventFunctionItem(58, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_58"), LocalStringManager.GetConfig("EventFunction_language", "Desc_58"), new int[1] { 11 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_58")));
		_dataArray.Add(new EventFunctionItem(59, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_59"), LocalStringManager.GetConfig("EventFunction_language", "Desc_59"), new int[3] { 6, 10, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_59_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_59_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_59_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_59")));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new EventFunctionItem(60, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_60"), LocalStringManager.GetConfig("EventFunction_language", "Desc_60"), new int[2] { 6, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_60_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_60_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_60")));
		_dataArray.Add(new EventFunctionItem(61, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_61"), LocalStringManager.GetConfig("EventFunction_language", "Desc_61"), new int[2] { 37, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_61_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_61_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_61")));
		_dataArray.Add(new EventFunctionItem(62, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_62"), LocalStringManager.GetConfig("EventFunction_language", "Desc_62"), new int[1] { 8 }, new string[0], 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_62")));
		_dataArray.Add(new EventFunctionItem(63, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_63"), LocalStringManager.GetConfig("EventFunction_language", "Desc_63"), new int[2] { 34, 34 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_63_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_63_1")
		}, 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_63")));
		_dataArray.Add(new EventFunctionItem(64, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_64"), LocalStringManager.GetConfig("EventFunction_language", "Desc_64"), new int[3] { 6, 35, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_64_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_64_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_64_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_64")));
		_dataArray.Add(new EventFunctionItem(65, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_65"), LocalStringManager.GetConfig("EventFunction_language", "Desc_65"), new int[4] { 6, 7, 1, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_65_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_65_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_65_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_65_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_65")));
		_dataArray.Add(new EventFunctionItem(66, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_66"), LocalStringManager.GetConfig("EventFunction_language", "Desc_66"), new int[3] { 6, 21, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_66_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_66_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_66_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_66")));
		_dataArray.Add(new EventFunctionItem(67, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_67"), LocalStringManager.GetConfig("EventFunction_language", "Desc_67"), new int[2] { 40, 9 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_67")));
		_dataArray.Add(new EventFunctionItem(68, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_68"), LocalStringManager.GetConfig("EventFunction_language", "Desc_68"), new int[2] { 39, 38 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_68")));
		_dataArray.Add(new EventFunctionItem(69, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_69"), LocalStringManager.GetConfig("EventFunction_language", "Desc_69"), new int[2] { 39, 38 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_69")));
		_dataArray.Add(new EventFunctionItem(70, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_70"), LocalStringManager.GetConfig("EventFunction_language", "Desc_70"), new int[1] { 39 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_70")));
		_dataArray.Add(new EventFunctionItem(71, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_71"), LocalStringManager.GetConfig("EventFunction_language", "Desc_71"), new int[1] { 3 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_71")));
		_dataArray.Add(new EventFunctionItem(72, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_72"), LocalStringManager.GetConfig("EventFunction_language", "Desc_72"), new int[2] { 41, 32 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_72")));
		_dataArray.Add(new EventFunctionItem(73, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_73"), LocalStringManager.GetConfig("EventFunction_language", "Desc_73"), new int[1] { 38 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_73")));
		_dataArray.Add(new EventFunctionItem(74, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_74"), LocalStringManager.GetConfig("EventFunction_language", "Desc_74"), new int[1] { 39 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_74")));
		_dataArray.Add(new EventFunctionItem(75, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_75"), LocalStringManager.GetConfig("EventFunction_language", "Desc_75"), new int[2] { 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_75")));
		_dataArray.Add(new EventFunctionItem(76, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_76"), LocalStringManager.GetConfig("EventFunction_language", "Desc_76"), new int[4] { 6, 19, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_76")));
		_dataArray.Add(new EventFunctionItem(77, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_77"), LocalStringManager.GetConfig("EventFunction_language", "Desc_77"), new int[4] { 6, 19, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_77")));
		_dataArray.Add(new EventFunctionItem(78, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_78"), LocalStringManager.GetConfig("EventFunction_language", "Desc_78"), new int[4] { 6, 25, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_78")));
		_dataArray.Add(new EventFunctionItem(79, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_79"), LocalStringManager.GetConfig("EventFunction_language", "Desc_79"), new int[4] { 6, 25, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_79")));
		_dataArray.Add(new EventFunctionItem(80, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_80"), LocalStringManager.GetConfig("EventFunction_language", "Desc_80"), new int[4] { 6, 24, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_80")));
		_dataArray.Add(new EventFunctionItem(81, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_81"), LocalStringManager.GetConfig("EventFunction_language", "Desc_81"), new int[4] { 6, 24, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_81")));
		_dataArray.Add(new EventFunctionItem(82, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_82"), LocalStringManager.GetConfig("EventFunction_language", "Desc_82"), new int[4] { 6, 18, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_82")));
		_dataArray.Add(new EventFunctionItem(83, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_83"), LocalStringManager.GetConfig("EventFunction_language", "Desc_83"), new int[4] { 6, 21, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_83")));
		_dataArray.Add(new EventFunctionItem(84, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_84"), LocalStringManager.GetConfig("EventFunction_language", "Desc_84"), new int[2] { 6, 29 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_84")));
		_dataArray.Add(new EventFunctionItem(85, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_85"), LocalStringManager.GetConfig("EventFunction_language", "Desc_85"), new int[2] { 6, 8 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_85")));
		_dataArray.Add(new EventFunctionItem(86, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_86"), LocalStringManager.GetConfig("EventFunction_language", "Desc_86"), new int[2] { 6, 10 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_86")));
		_dataArray.Add(new EventFunctionItem(87, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_87"), LocalStringManager.GetConfig("EventFunction_language", "Desc_87"), new int[2] { 6, 10 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_87")));
		_dataArray.Add(new EventFunctionItem(88, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_88"), LocalStringManager.GetConfig("EventFunction_language", "Desc_88"), new int[4] { 6, 6, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_88")));
		_dataArray.Add(new EventFunctionItem(89, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_89"), LocalStringManager.GetConfig("EventFunction_language", "Desc_89"), new int[4] { 6, 42, 5, 3 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_89_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_89_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_89_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_89_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_89_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_89")));
		_dataArray.Add(new EventFunctionItem(90, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_90"), LocalStringManager.GetConfig("EventFunction_language", "Desc_90"), new int[1] { 43 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_90")));
		_dataArray.Add(new EventFunctionItem(91, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_91"), LocalStringManager.GetConfig("EventFunction_language", "Desc_91"), new int[1] { 48 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_91_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_91")));
		_dataArray.Add(new EventFunctionItem(92, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_92"), LocalStringManager.GetConfig("EventFunction_language", "Desc_92"), new int[2] { 45, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_92_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_92_1")
		}, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_92")));
		_dataArray.Add(new EventFunctionItem(93, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_93"), LocalStringManager.GetConfig("EventFunction_language", "Desc_93"), new int[1] { 44 }, new string[0], 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_93")));
		_dataArray.Add(new EventFunctionItem(94, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_94"), LocalStringManager.GetConfig("EventFunction_language", "Desc_94"), new int[2] { 1, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_94_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_94_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_94")));
		_dataArray.Add(new EventFunctionItem(95, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_95"), LocalStringManager.GetConfig("EventFunction_language", "Desc_95"), new int[2] { 6, 47 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_95")));
		_dataArray.Add(new EventFunctionItem(96, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_96"), LocalStringManager.GetConfig("EventFunction_language", "Desc_96"), new int[2] { 6, 12 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_96")));
		_dataArray.Add(new EventFunctionItem(97, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_97"), LocalStringManager.GetConfig("EventFunction_language", "Desc_97"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_97")));
		_dataArray.Add(new EventFunctionItem(98, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_98"), LocalStringManager.GetConfig("EventFunction_language", "Desc_98"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_98")));
		_dataArray.Add(new EventFunctionItem(99, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_99"), LocalStringManager.GetConfig("EventFunction_language", "Desc_99"), new int[1] { 46 }, new string[0], 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_99")));
		_dataArray.Add(new EventFunctionItem(100, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_100"), LocalStringManager.GetConfig("EventFunction_language", "Desc_100"), new int[2] { 6, 9 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_100")));
		_dataArray.Add(new EventFunctionItem(101, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_101"), LocalStringManager.GetConfig("EventFunction_language", "Desc_101"), new int[3] { 11, 89, 0 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_101_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_101_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_101_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_101")));
		_dataArray.Add(new EventFunctionItem(102, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_102"), LocalStringManager.GetConfig("EventFunction_language", "Desc_102"), new int[2] { 11, 89 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_102_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_102_1")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_102")));
		_dataArray.Add(new EventFunctionItem(103, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_103"), LocalStringManager.GetConfig("EventFunction_language", "Desc_103"), new int[3] { 6, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_103")));
		_dataArray.Add(new EventFunctionItem(104, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_104"), LocalStringManager.GetConfig("EventFunction_language", "Desc_104"), new int[2] { 6, 10 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_104")));
		_dataArray.Add(new EventFunctionItem(105, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_105"), LocalStringManager.GetConfig("EventFunction_language", "Desc_105"), new int[2] { 10, 47 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_105")));
		_dataArray.Add(new EventFunctionItem(106, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_106"), LocalStringManager.GetConfig("EventFunction_language", "Desc_106"), new int[2] { 10, 12 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_106")));
		_dataArray.Add(new EventFunctionItem(107, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_107"), LocalStringManager.GetConfig("EventFunction_language", "Desc_107"), new int[2] { 6, 17 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_107")));
		_dataArray.Add(new EventFunctionItem(108, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_108"), LocalStringManager.GetConfig("EventFunction_language", "Desc_108"), new int[3] { 6, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_108")));
		_dataArray.Add(new EventFunctionItem(109, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_109"), LocalStringManager.GetConfig("EventFunction_language", "Desc_109"), new int[0], new string[0], 3, indentNext: true, 5, canCreateManually: true, new List<int>(), allowedInCondition: true, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_109")));
		_dataArray.Add(new EventFunctionItem(110, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_110"), LocalStringManager.GetConfig("EventFunction_language", "Desc_110"), new int[0], new string[0], 3, indentNext: true, 5, canCreateManually: true, new List<int>(), allowedInCondition: true, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_110")));
		_dataArray.Add(new EventFunctionItem(111, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_111"), LocalStringManager.GetConfig("EventFunction_language", "Desc_111"), new int[2] { 6, 6 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_111_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_111_1")
		}, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_111")));
		_dataArray.Add(new EventFunctionItem(112, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_112"), LocalStringManager.GetConfig("EventFunction_language", "Desc_112"), new int[3] { 12, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_112")));
		_dataArray.Add(new EventFunctionItem(113, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_113"), LocalStringManager.GetConfig("EventFunction_language", "Desc_113"), new int[3] { 6, 1, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_113_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_113_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_113_2")
		}, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_113")));
		_dataArray.Add(new EventFunctionItem(114, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_114"), LocalStringManager.GetConfig("EventFunction_language", "Desc_114"), new int[4] { 50, 12, 49, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_114_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_114_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_114_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_114_3")
		}, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_114")));
		_dataArray.Add(new EventFunctionItem(115, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_115"), LocalStringManager.GetConfig("EventFunction_language", "Desc_115"), new int[2] { 11, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_115_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_115_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_115")));
		_dataArray.Add(new EventFunctionItem(116, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_116"), LocalStringManager.GetConfig("EventFunction_language", "Desc_116"), new int[5] { 11, 3, 1, 3, 5 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_116_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_116_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_116_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_116_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_116_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_116")));
		_dataArray.Add(new EventFunctionItem(117, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_117"), LocalStringManager.GetConfig("EventFunction_language", "Desc_117"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_117_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_117_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_117")));
		_dataArray.Add(new EventFunctionItem(118, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_118"), LocalStringManager.GetConfig("EventFunction_language", "Desc_118"), new int[5] { 6, 5, 3, 3, 25 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_118_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_118_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_118_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_118_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_118_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_118")));
		_dataArray.Add(new EventFunctionItem(119, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_119"), LocalStringManager.GetConfig("EventFunction_language", "Desc_119"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_119_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_119")));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new EventFunctionItem(120, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_120"), LocalStringManager.GetConfig("EventFunction_language", "Desc_120"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_120")));
		_dataArray.Add(new EventFunctionItem(121, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_121"), LocalStringManager.GetConfig("EventFunction_language", "Desc_121"), new int[2] { 6, 8 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_121")));
		_dataArray.Add(new EventFunctionItem(122, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_122"), LocalStringManager.GetConfig("EventFunction_language", "Desc_122"), new int[2] { 6, 37 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_122")));
		_dataArray.Add(new EventFunctionItem(123, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_123"), LocalStringManager.GetConfig("EventFunction_language", "Desc_123"), new int[3] { 11, 89, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_123_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_123_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_123_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_123")));
		_dataArray.Add(new EventFunctionItem(124, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_124"), LocalStringManager.GetConfig("EventFunction_language", "Desc_124"), new int[2] { 3, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_124_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_124_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_124")));
		_dataArray.Add(new EventFunctionItem(125, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_125"), LocalStringManager.GetConfig("EventFunction_language", "Desc_125"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_125")));
		_dataArray.Add(new EventFunctionItem(126, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_126"), LocalStringManager.GetConfig("EventFunction_language", "Desc_126"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_126_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_126")));
		_dataArray.Add(new EventFunctionItem(127, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_127"), LocalStringManager.GetConfig("EventFunction_language", "Desc_127"), new int[5] { 6, 4, 22, 23, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_127_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_127_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_127_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_127")));
		_dataArray.Add(new EventFunctionItem(128, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_128"), LocalStringManager.GetConfig("EventFunction_language", "Desc_128"), new int[2] { 6, 46 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_128")));
		_dataArray.Add(new EventFunctionItem(129, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_129"), LocalStringManager.GetConfig("EventFunction_language", "Desc_129"), new int[3] { 6, 21, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_129_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_129_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_129_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_129")));
		_dataArray.Add(new EventFunctionItem(130, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_130"), LocalStringManager.GetConfig("EventFunction_language", "Desc_130"), new int[5] { 6, 6, 21, 1, 3 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_130_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_130_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_130_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_130_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_130_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_130")));
		_dataArray.Add(new EventFunctionItem(131, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_131"), LocalStringManager.GetConfig("EventFunction_language", "Desc_131"), new int[4] { 6, 51, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_131")));
		_dataArray.Add(new EventFunctionItem(132, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_132"), LocalStringManager.GetConfig("EventFunction_language", "Desc_132"), new int[1] { 23 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_132_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_132")));
		_dataArray.Add(new EventFunctionItem(133, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_133"), LocalStringManager.GetConfig("EventFunction_language", "Desc_133"), new int[1] { 8 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_133_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_133")));
		_dataArray.Add(new EventFunctionItem(134, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_134"), LocalStringManager.GetConfig("EventFunction_language", "Desc_134"), new int[1] { 8 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_134_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_134")));
		_dataArray.Add(new EventFunctionItem(135, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_135"), LocalStringManager.GetConfig("EventFunction_language", "Desc_135"), new int[3] { 6, 4, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_135_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_135_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_135_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_135")));
		_dataArray.Add(new EventFunctionItem(136, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_136"), LocalStringManager.GetConfig("EventFunction_language", "Desc_136"), new int[2] { 7, 22 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_136")));
		_dataArray.Add(new EventFunctionItem(137, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_137"), LocalStringManager.GetConfig("EventFunction_language", "Desc_137"), new int[2] { 7, 23 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_137")));
		_dataArray.Add(new EventFunctionItem(138, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_138"), LocalStringManager.GetConfig("EventFunction_language", "Desc_138"), new int[2] { 7, 8 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_138")));
		_dataArray.Add(new EventFunctionItem(139, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_139"), LocalStringManager.GetConfig("EventFunction_language", "Desc_139"), new int[1] { 12 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_139")));
		_dataArray.Add(new EventFunctionItem(140, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_140"), LocalStringManager.GetConfig("EventFunction_language", "Desc_140"), new int[2] { 6, 52 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_140")));
		_dataArray.Add(new EventFunctionItem(141, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_141"), LocalStringManager.GetConfig("EventFunction_language", "Desc_141"), new int[4] { 6, 52, 41, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_141_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_141_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_141_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_141_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_141")));
		_dataArray.Add(new EventFunctionItem(142, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_142"), LocalStringManager.GetConfig("EventFunction_language", "Desc_142"), new int[4] { 6, 6, 41, 53 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_142")));
		_dataArray.Add(new EventFunctionItem(143, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_143"), LocalStringManager.GetConfig("EventFunction_language", "Desc_143"), new int[3] { 3, 1, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_143_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_143_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_143_2")
		}, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_143")));
		_dataArray.Add(new EventFunctionItem(144, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_144"), LocalStringManager.GetConfig("EventFunction_language", "Desc_144"), new int[2] { 3, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_144_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_144_1")
		}, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_144")));
		_dataArray.Add(new EventFunctionItem(145, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_145"), LocalStringManager.GetConfig("EventFunction_language", "Desc_145"), new int[2] { 54, 12 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_145_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_145_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_145")));
		_dataArray.Add(new EventFunctionItem(146, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_146"), LocalStringManager.GetConfig("EventFunction_language", "Desc_146"), new int[2] { 6, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_146_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_146_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_146")));
		_dataArray.Add(new EventFunctionItem(147, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_147"), LocalStringManager.GetConfig("EventFunction_language", "Desc_147"), new int[2] { 6, 52 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_147")));
		_dataArray.Add(new EventFunctionItem(148, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_148"), LocalStringManager.GetConfig("EventFunction_language", "Desc_148"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_148")));
		_dataArray.Add(new EventFunctionItem(149, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_149"), LocalStringManager.GetConfig("EventFunction_language", "Desc_149"), new int[4] { 55, 10, 3, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_149_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_149_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_149_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_149_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_149")));
		_dataArray.Add(new EventFunctionItem(150, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_150"), LocalStringManager.GetConfig("EventFunction_language", "Desc_150"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_150")));
		_dataArray.Add(new EventFunctionItem(151, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_151"), LocalStringManager.GetConfig("EventFunction_language", "Desc_151"), new int[2] { 12, 37 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_151_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_151_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_151")));
		_dataArray.Add(new EventFunctionItem(152, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_152"), LocalStringManager.GetConfig("EventFunction_language", "Desc_152"), new int[1] { 12 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_152_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_152")));
		_dataArray.Add(new EventFunctionItem(153, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_153"), LocalStringManager.GetConfig("EventFunction_language", "Desc_153"), new int[1] { 56 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_153_0") }, 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_153")));
		_dataArray.Add(new EventFunctionItem(154, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_154"), LocalStringManager.GetConfig("EventFunction_language", "Desc_154"), new int[2] { 12, 10 }, new string[0], 10, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_154")));
		_dataArray.Add(new EventFunctionItem(155, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_155"), LocalStringManager.GetConfig("EventFunction_language", "Desc_155"), new int[1] { 33 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_155")));
		_dataArray.Add(new EventFunctionItem(156, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_156"), LocalStringManager.GetConfig("EventFunction_language", "Desc_156"), new int[2] { 3, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_156_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_156_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_156")));
		_dataArray.Add(new EventFunctionItem(157, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_157"), LocalStringManager.GetConfig("EventFunction_language", "Desc_157"), new int[3] { 6, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_157")));
		_dataArray.Add(new EventFunctionItem(158, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_158"), LocalStringManager.GetConfig("EventFunction_language", "Desc_158"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_158")));
		_dataArray.Add(new EventFunctionItem(159, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_159"), LocalStringManager.GetConfig("EventFunction_language", "Desc_159"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_159")));
		_dataArray.Add(new EventFunctionItem(160, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_160"), LocalStringManager.GetConfig("EventFunction_language", "Desc_160"), new int[3] { 6, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_160")));
		_dataArray.Add(new EventFunctionItem(161, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_161"), LocalStringManager.GetConfig("EventFunction_language", "Desc_161"), new int[3] { 6, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_161")));
		_dataArray.Add(new EventFunctionItem(162, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_162"), LocalStringManager.GetConfig("EventFunction_language", "Desc_162"), new int[3] { 6, 41, 57 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_162")));
		_dataArray.Add(new EventFunctionItem(163, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_163"), LocalStringManager.GetConfig("EventFunction_language", "Desc_163"), new int[2] { 6, 52 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_163")));
		_dataArray.Add(new EventFunctionItem(164, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_164"), LocalStringManager.GetConfig("EventFunction_language", "Desc_164"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_164_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_164_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_164")));
		_dataArray.Add(new EventFunctionItem(165, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_165"), LocalStringManager.GetConfig("EventFunction_language", "Desc_165"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_165")));
		_dataArray.Add(new EventFunctionItem(166, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_166"), LocalStringManager.GetConfig("EventFunction_language", "Desc_166"), new int[1] { 8 }, new string[0], 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_166")));
		_dataArray.Add(new EventFunctionItem(167, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_167"), LocalStringManager.GetConfig("EventFunction_language", "Desc_167"), new int[4] { 9, 1, 1, 58 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_167_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_167_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_167_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_167_3")
		}, 9, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_167")));
		_dataArray.Add(new EventFunctionItem(168, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_168"), LocalStringManager.GetConfig("EventFunction_language", "Desc_168"), new int[3] { 6, 9, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_168_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_168_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_168_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_168")));
		_dataArray.Add(new EventFunctionItem(169, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_169"), LocalStringManager.GetConfig("EventFunction_language", "Desc_169"), new int[2] { 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_169")));
		_dataArray.Add(new EventFunctionItem(170, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_170"), LocalStringManager.GetConfig("EventFunction_language", "Desc_170"), new int[2] { 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_170")));
		_dataArray.Add(new EventFunctionItem(171, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_171"), LocalStringManager.GetConfig("EventFunction_language", "Desc_171"), new int[2] { 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_171")));
		_dataArray.Add(new EventFunctionItem(172, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_172"), LocalStringManager.GetConfig("EventFunction_language", "Desc_172"), new int[2] { 6, 20 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_172")));
		_dataArray.Add(new EventFunctionItem(173, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_173"), LocalStringManager.GetConfig("EventFunction_language", "Desc_173"), new int[2] { 6, 57 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_173")));
		_dataArray.Add(new EventFunctionItem(174, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_174"), LocalStringManager.GetConfig("EventFunction_language", "Desc_174"), new int[2] { 6, 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_174")));
		_dataArray.Add(new EventFunctionItem(175, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_175"), LocalStringManager.GetConfig("EventFunction_language", "Desc_175"), new int[2] { 6, 20 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_175")));
		_dataArray.Add(new EventFunctionItem(176, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_176"), LocalStringManager.GetConfig("EventFunction_language", "Desc_176"), new int[2] { 6, 57 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_176")));
		_dataArray.Add(new EventFunctionItem(177, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_177"), LocalStringManager.GetConfig("EventFunction_language", "Desc_177"), new int[2] { 6, 69 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_177")));
		_dataArray.Add(new EventFunctionItem(178, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_178"), LocalStringManager.GetConfig("EventFunction_language", "Desc_178"), new int[3] { 6, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_178")));
		_dataArray.Add(new EventFunctionItem(179, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_179"), LocalStringManager.GetConfig("EventFunction_language", "Desc_179"), new int[4] { 6, 35, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_179")));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new EventFunctionItem(180, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_180"), LocalStringManager.GetConfig("EventFunction_language", "Desc_180"), new int[2] { 6, 35 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_180")));
		_dataArray.Add(new EventFunctionItem(181, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_181"), LocalStringManager.GetConfig("EventFunction_language", "Desc_181"), new int[1] { 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_181")));
		_dataArray.Add(new EventFunctionItem(182, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_182"), LocalStringManager.GetConfig("EventFunction_language", "Desc_182"), new int[1] { 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_182")));
		_dataArray.Add(new EventFunctionItem(183, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_183"), LocalStringManager.GetConfig("EventFunction_language", "Desc_183"), new int[1] { 82 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_183_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_183")));
		_dataArray.Add(new EventFunctionItem(184, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_184"), LocalStringManager.GetConfig("EventFunction_language", "Desc_184"), new int[2] { 9, 3 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_184")));
		_dataArray.Add(new EventFunctionItem(185, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_185"), LocalStringManager.GetConfig("EventFunction_language", "Desc_185"), new int[2] { 6, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_185")));
		_dataArray.Add(new EventFunctionItem(186, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_186"), LocalStringManager.GetConfig("EventFunction_language", "Desc_186"), new int[3] { 61, 3, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_186_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_186_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_186_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_186")));
		_dataArray.Add(new EventFunctionItem(187, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_187"), LocalStringManager.GetConfig("EventFunction_language", "Desc_187"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_187_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_187")));
		_dataArray.Add(new EventFunctionItem(188, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_188"), LocalStringManager.GetConfig("EventFunction_language", "Desc_188"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_188_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_188")));
		_dataArray.Add(new EventFunctionItem(189, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_189"), LocalStringManager.GetConfig("EventFunction_language", "Desc_189"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_189_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_189_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_189")));
		_dataArray.Add(new EventFunctionItem(190, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_190"), LocalStringManager.GetConfig("EventFunction_language", "Desc_190"), new int[3] { 10, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_190")));
		_dataArray.Add(new EventFunctionItem(191, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_191"), LocalStringManager.GetConfig("EventFunction_language", "Desc_191"), new int[1] { 6 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_191")));
		_dataArray.Add(new EventFunctionItem(192, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_192"), LocalStringManager.GetConfig("EventFunction_language", "Desc_192"), new int[2] { 47, 59 }, new string[0], 10, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_192")));
		_dataArray.Add(new EventFunctionItem(193, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_193"), LocalStringManager.GetConfig("EventFunction_language", "Desc_193"), new int[2] { 47, 59 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_193")));
		_dataArray.Add(new EventFunctionItem(194, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_194"), LocalStringManager.GetConfig("EventFunction_language", "Desc_194"), new int[2] { 6, 10 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_194")));
		_dataArray.Add(new EventFunctionItem(195, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_195"), LocalStringManager.GetConfig("EventFunction_language", "Desc_195"), new int[2] { 5, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_195_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_195_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_195")));
		_dataArray.Add(new EventFunctionItem(196, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_196"), LocalStringManager.GetConfig("EventFunction_language", "Desc_196"), new int[0], new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_196")));
		_dataArray.Add(new EventFunctionItem(197, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_197"), LocalStringManager.GetConfig("EventFunction_language", "Desc_197"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_197_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_197")));
		_dataArray.Add(new EventFunctionItem(198, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_198"), LocalStringManager.GetConfig("EventFunction_language", "Desc_198"), new int[1] { 6 }, new string[0], 9, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_198")));
		_dataArray.Add(new EventFunctionItem(199, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_199"), LocalStringManager.GetConfig("EventFunction_language", "Desc_199"), new int[1] { 10 }, new string[0], 9, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_199")));
		_dataArray.Add(new EventFunctionItem(200, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_200"), LocalStringManager.GetConfig("EventFunction_language", "Desc_200"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_200_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_200_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_200")));
		_dataArray.Add(new EventFunctionItem(201, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_201"), LocalStringManager.GetConfig("EventFunction_language", "Desc_201"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_201_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_201_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_201")));
		_dataArray.Add(new EventFunctionItem(202, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_202"), LocalStringManager.GetConfig("EventFunction_language", "Desc_202"), new int[2] { 40, 40 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_202")));
		_dataArray.Add(new EventFunctionItem(203, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_203"), LocalStringManager.GetConfig("EventFunction_language", "Desc_203"), new int[2] { 6, 20 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_203")));
		_dataArray.Add(new EventFunctionItem(204, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_204"), LocalStringManager.GetConfig("EventFunction_language", "Desc_204"), new int[2] { 12, 81 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_204")));
		_dataArray.Add(new EventFunctionItem(205, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_205"), LocalStringManager.GetConfig("EventFunction_language", "Desc_205"), new int[2] { 6, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_205_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_205_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_205")));
		_dataArray.Add(new EventFunctionItem(206, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_206"), LocalStringManager.GetConfig("EventFunction_language", "Desc_206"), new int[2] { 6, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_206_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_206_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_206")));
		_dataArray.Add(new EventFunctionItem(207, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_207"), LocalStringManager.GetConfig("EventFunction_language", "Desc_207"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_207_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_207")));
		_dataArray.Add(new EventFunctionItem(208, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_208"), LocalStringManager.GetConfig("EventFunction_language", "Desc_208"), new int[2] { 1, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_208_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_208_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_208")));
		_dataArray.Add(new EventFunctionItem(209, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_209"), LocalStringManager.GetConfig("EventFunction_language", "Desc_209"), new int[2] { 1, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_209_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_209_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_209")));
		_dataArray.Add(new EventFunctionItem(210, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_210"), LocalStringManager.GetConfig("EventFunction_language", "Desc_210"), new int[5] { 10, 13, 13, 57, 57 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_210_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_210_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_210_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_210_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_210_4")
		}, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_210")));
		_dataArray.Add(new EventFunctionItem(211, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_211"), LocalStringManager.GetConfig("EventFunction_language", "Desc_211"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_211")));
		_dataArray.Add(new EventFunctionItem(212, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_212"), LocalStringManager.GetConfig("EventFunction_language", "Desc_212"), new int[0], new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_212")));
		_dataArray.Add(new EventFunctionItem(213, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_213"), LocalStringManager.GetConfig("EventFunction_language", "Desc_213"), new int[2] { 6, 60 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_213")));
		_dataArray.Add(new EventFunctionItem(214, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_214"), LocalStringManager.GetConfig("EventFunction_language", "Desc_214"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_214")));
		_dataArray.Add(new EventFunctionItem(215, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_215"), LocalStringManager.GetConfig("EventFunction_language", "Desc_215"), new int[1], new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_215_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_215")));
		_dataArray.Add(new EventFunctionItem(216, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_216"), LocalStringManager.GetConfig("EventFunction_language", "Desc_216"), new int[2] { 0, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_216_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_216_1")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_216")));
		_dataArray.Add(new EventFunctionItem(217, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_217"), LocalStringManager.GetConfig("EventFunction_language", "Desc_217"), new int[2] { 47, 59 }, new string[0], 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_217")));
		_dataArray.Add(new EventFunctionItem(218, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_218"), LocalStringManager.GetConfig("EventFunction_language", "Desc_218"), new int[3] { 0, 1, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_218_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_218_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_218_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_218")));
		_dataArray.Add(new EventFunctionItem(219, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_219"), LocalStringManager.GetConfig("EventFunction_language", "Desc_219"), new int[3] { 4, 41, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_219_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_219_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_219_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_219")));
		_dataArray.Add(new EventFunctionItem(220, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_220"), LocalStringManager.GetConfig("EventFunction_language", "Desc_220"), new int[2] { 4, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_220_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_220_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_220")));
		_dataArray.Add(new EventFunctionItem(221, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_221"), LocalStringManager.GetConfig("EventFunction_language", "Desc_221"), new int[2] { 4, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_221_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_221_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_221")));
		_dataArray.Add(new EventFunctionItem(222, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_222"), LocalStringManager.GetConfig("EventFunction_language", "Desc_222"), new int[4] { 4, 41, 1, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_222_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_222_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_222_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_222_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_222")));
		_dataArray.Add(new EventFunctionItem(223, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_223"), LocalStringManager.GetConfig("EventFunction_language", "Desc_223"), new int[2] { 4, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_223_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_223_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_223")));
		_dataArray.Add(new EventFunctionItem(224, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_224"), LocalStringManager.GetConfig("EventFunction_language", "Desc_224"), new int[2] { 4, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_224_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_224_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_224")));
		_dataArray.Add(new EventFunctionItem(225, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_225"), LocalStringManager.GetConfig("EventFunction_language", "Desc_225"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_225_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_225")));
		_dataArray.Add(new EventFunctionItem(226, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_226"), LocalStringManager.GetConfig("EventFunction_language", "Desc_226"), new int[2] { 11, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_226_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_226_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_226")));
		_dataArray.Add(new EventFunctionItem(227, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_227"), LocalStringManager.GetConfig("EventFunction_language", "Desc_227"), new int[4] { 10, 29, 13, 13 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_227_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_227_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_227_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_227_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_227")));
		_dataArray.Add(new EventFunctionItem(228, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_228"), LocalStringManager.GetConfig("EventFunction_language", "Desc_228"), new int[3] { 61, 41, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_228_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_228_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_228_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_228")));
		_dataArray.Add(new EventFunctionItem(229, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_229"), LocalStringManager.GetConfig("EventFunction_language", "Desc_229"), new int[5] { 4, 41, 1, 3, 73 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_229_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_229_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_229_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_229_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_229_4")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_229")));
		_dataArray.Add(new EventFunctionItem(230, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_230"), LocalStringManager.GetConfig("EventFunction_language", "Desc_230"), new int[3] { 4, 4, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_230_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_230_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_230_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_230")));
		_dataArray.Add(new EventFunctionItem(231, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_231"), LocalStringManager.GetConfig("EventFunction_language", "Desc_231"), new int[3] { 4, 4, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_231_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_231_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_231_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_231")));
		_dataArray.Add(new EventFunctionItem(232, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_232"), LocalStringManager.GetConfig("EventFunction_language", "Desc_232"), new int[3] { 61, 3, 61 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_232_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_232_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_232_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_232")));
		_dataArray.Add(new EventFunctionItem(233, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_233"), LocalStringManager.GetConfig("EventFunction_language", "Desc_233"), new int[1] { 61 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_233_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_233")));
		_dataArray.Add(new EventFunctionItem(234, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_234"), LocalStringManager.GetConfig("EventFunction_language", "Desc_234"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_234_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_234")));
		_dataArray.Add(new EventFunctionItem(235, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_235"), LocalStringManager.GetConfig("EventFunction_language", "Desc_235"), new int[2] { 8, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_235_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_235_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_235")));
		_dataArray.Add(new EventFunctionItem(236, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_236"), LocalStringManager.GetConfig("EventFunction_language", "Desc_236"), new int[1] { 8 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_236")));
		_dataArray.Add(new EventFunctionItem(237, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_237"), LocalStringManager.GetConfig("EventFunction_language", "Desc_237"), new int[1] { 8 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_237")));
		_dataArray.Add(new EventFunctionItem(238, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_238"), LocalStringManager.GetConfig("EventFunction_language", "Desc_238"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_238")));
		_dataArray.Add(new EventFunctionItem(239, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_239"), LocalStringManager.GetConfig("EventFunction_language", "Desc_239"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_239")));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new EventFunctionItem(240, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_240"), LocalStringManager.GetConfig("EventFunction_language", "Desc_240"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_240_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_240")));
		_dataArray.Add(new EventFunctionItem(241, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_241"), LocalStringManager.GetConfig("EventFunction_language", "Desc_241"), new int[1] { 5 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_241_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_241")));
		_dataArray.Add(new EventFunctionItem(242, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_242"), LocalStringManager.GetConfig("EventFunction_language", "Desc_242"), new int[2] { 64, 17 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_242")));
		_dataArray.Add(new EventFunctionItem(243, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_243"), LocalStringManager.GetConfig("EventFunction_language", "Desc_243"), new int[1] { 9 }, new string[0], 10, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_243")));
		_dataArray.Add(new EventFunctionItem(244, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_244"), LocalStringManager.GetConfig("EventFunction_language", "Desc_244"), new int[2] { 11, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_244_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_244_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_244")));
		_dataArray.Add(new EventFunctionItem(245, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_245"), LocalStringManager.GetConfig("EventFunction_language", "Desc_245"), new int[3] { 4, 3, 73 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_245_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_245_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_245_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_245")));
		_dataArray.Add(new EventFunctionItem(246, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_246"), LocalStringManager.GetConfig("EventFunction_language", "Desc_246"), new int[5] { 4, 1, 3, 3, 73 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_246_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_246_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_246_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_246_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_246_4")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_246")));
		_dataArray.Add(new EventFunctionItem(247, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_247"), LocalStringManager.GetConfig("EventFunction_language", "Desc_247"), new int[5] { 4, 61, 3, 3, 73 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_247_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_247_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_247_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_247_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_247_4")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_247")));
		_dataArray.Add(new EventFunctionItem(248, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_248"), LocalStringManager.GetConfig("EventFunction_language", "Desc_248"), new int[3] { 4, 3, 73 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_248_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_248_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_248_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_248")));
		_dataArray.Add(new EventFunctionItem(249, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_249"), LocalStringManager.GetConfig("EventFunction_language", "Desc_249"), new int[0], new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_249")));
		_dataArray.Add(new EventFunctionItem(250, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_250"), LocalStringManager.GetConfig("EventFunction_language", "Desc_250"), new int[6] { 6, 1, 4, 4, 4, 4 }, new string[6]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_250_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_250_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_250_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_250_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_250_4"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_250_5")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_250")));
		_dataArray.Add(new EventFunctionItem(251, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_251"), LocalStringManager.GetConfig("EventFunction_language", "Desc_251"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_251_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_251")));
		_dataArray.Add(new EventFunctionItem(252, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_252"), LocalStringManager.GetConfig("EventFunction_language", "Desc_252"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_252_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_252")));
		_dataArray.Add(new EventFunctionItem(253, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_253"), LocalStringManager.GetConfig("EventFunction_language", "Desc_253"), new int[3] { 6, 1, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_253_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_253_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_253_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_253")));
		_dataArray.Add(new EventFunctionItem(254, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_254"), LocalStringManager.GetConfig("EventFunction_language", "Desc_254"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_254_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_254_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_254")));
		_dataArray.Add(new EventFunctionItem(255, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_255"), LocalStringManager.GetConfig("EventFunction_language", "Desc_255"), new int[0], new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_255")));
		_dataArray.Add(new EventFunctionItem(256, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_256"), LocalStringManager.GetConfig("EventFunction_language", "Desc_256"), new int[2] { 6, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_256_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_256_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_256")));
		_dataArray.Add(new EventFunctionItem(257, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_257"), LocalStringManager.GetConfig("EventFunction_language", "Desc_257"), new int[2] { 41, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_257_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_257_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_257")));
		_dataArray.Add(new EventFunctionItem(258, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_258"), LocalStringManager.GetConfig("EventFunction_language", "Desc_258"), new int[3] { 6, 41, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_258_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_258_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_258_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_258")));
		_dataArray.Add(new EventFunctionItem(259, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_259"), LocalStringManager.GetConfig("EventFunction_language", "Desc_259"), new int[4] { 61, 1, 1, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_259_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_259_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_259_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_259_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_259")));
		_dataArray.Add(new EventFunctionItem(260, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_260"), LocalStringManager.GetConfig("EventFunction_language", "Desc_260"), new int[5] { 61, 4, 73, 1, 1 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_260_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_260_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_260_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_260_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_260_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_260")));
		_dataArray.Add(new EventFunctionItem(261, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_261"), LocalStringManager.GetConfig("EventFunction_language", "Desc_261"), new int[1] { 6 }, new string[0], 12, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_261")));
		_dataArray.Add(new EventFunctionItem(262, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_262"), LocalStringManager.GetConfig("EventFunction_language", "Desc_262"), new int[1] { 10 }, new string[0], 12, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_262")));
		_dataArray.Add(new EventFunctionItem(263, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_263"), LocalStringManager.GetConfig("EventFunction_language", "Desc_263"), new int[1] { 6 }, new string[0], 10, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_263")));
		_dataArray.Add(new EventFunctionItem(264, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_264"), LocalStringManager.GetConfig("EventFunction_language", "Desc_264"), new int[2] { 3, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_264_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_264_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_264")));
		_dataArray.Add(new EventFunctionItem(265, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_265"), LocalStringManager.GetConfig("EventFunction_language", "Desc_265"), new int[4] { 82, 4, 41, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_265_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_265_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_265_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_265_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_265")));
		_dataArray.Add(new EventFunctionItem(266, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_266"), LocalStringManager.GetConfig("EventFunction_language", "Desc_266"), new int[3] { 82, 4, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_266_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_266_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_266_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_266")));
		_dataArray.Add(new EventFunctionItem(267, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_267"), LocalStringManager.GetConfig("EventFunction_language", "Desc_267"), new int[3] { 82, 4, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_267_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_267_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_267_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_267")));
		_dataArray.Add(new EventFunctionItem(268, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_268"), LocalStringManager.GetConfig("EventFunction_language", "Desc_268"), new int[2] { 61, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_268_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_268_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_268")));
		_dataArray.Add(new EventFunctionItem(269, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_269"), LocalStringManager.GetConfig("EventFunction_language", "Desc_269"), new int[1] { 61 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_269_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_269")));
		_dataArray.Add(new EventFunctionItem(270, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_270"), LocalStringManager.GetConfig("EventFunction_language", "Desc_270"), new int[1] { 61 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_270_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_270")));
		_dataArray.Add(new EventFunctionItem(271, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_271"), LocalStringManager.GetConfig("EventFunction_language", "Desc_271"), new int[3] { 61, 1, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_271_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_271_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_271_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_271")));
		_dataArray.Add(new EventFunctionItem(272, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_272"), LocalStringManager.GetConfig("EventFunction_language", "Desc_272"), new int[5] { 61, 61, 1, 3, 3 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_272_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_272_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_272_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_272_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_272_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_272")));
		_dataArray.Add(new EventFunctionItem(273, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_273"), LocalStringManager.GetConfig("EventFunction_language", "Desc_273"), new int[4] { 61, 61, 1, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_273_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_273_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_273_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_273_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_273")));
		_dataArray.Add(new EventFunctionItem(274, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_274"), LocalStringManager.GetConfig("EventFunction_language", "Desc_274"), new int[2] { 82, 61 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_274_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_274_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_274")));
		_dataArray.Add(new EventFunctionItem(275, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_275"), LocalStringManager.GetConfig("EventFunction_language", "Desc_275"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_275_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_275")));
		_dataArray.Add(new EventFunctionItem(276, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_276"), LocalStringManager.GetConfig("EventFunction_language", "Desc_276"), new int[4] { 82, 4, 3, 73 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_276_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_276_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_276_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_276_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_276")));
		_dataArray.Add(new EventFunctionItem(277, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_277"), LocalStringManager.GetConfig("EventFunction_language", "Desc_277"), new int[2] { 82, 61 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_277_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_277_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_277")));
		_dataArray.Add(new EventFunctionItem(278, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_278"), LocalStringManager.GetConfig("EventFunction_language", "Desc_278"), new int[2] { 8, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_278_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_278_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_278")));
		_dataArray.Add(new EventFunctionItem(279, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_279"), LocalStringManager.GetConfig("EventFunction_language", "Desc_279"), new int[2] { 82, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_279_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_279_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_279")));
		_dataArray.Add(new EventFunctionItem(280, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_280"), LocalStringManager.GetConfig("EventFunction_language", "Desc_280"), new int[2] { 61, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_280_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_280_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_280")));
		_dataArray.Add(new EventFunctionItem(281, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_281"), LocalStringManager.GetConfig("EventFunction_language", "Desc_281"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_281")));
		_dataArray.Add(new EventFunctionItem(282, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_282"), LocalStringManager.GetConfig("EventFunction_language", "Desc_282"), new int[2] { 82, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_282_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_282_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_282")));
		_dataArray.Add(new EventFunctionItem(283, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_283"), LocalStringManager.GetConfig("EventFunction_language", "Desc_283"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_283")));
		_dataArray.Add(new EventFunctionItem(284, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_284"), LocalStringManager.GetConfig("EventFunction_language", "Desc_284"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_284")));
		_dataArray.Add(new EventFunctionItem(285, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_285"), LocalStringManager.GetConfig("EventFunction_language", "Desc_285"), new int[3] { 82, 4, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_285_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_285_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_285_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_285")));
		_dataArray.Add(new EventFunctionItem(286, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_286"), LocalStringManager.GetConfig("EventFunction_language", "Desc_286"), new int[2] { 82, 61 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_286_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_286_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_286")));
		_dataArray.Add(new EventFunctionItem(287, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_287"), LocalStringManager.GetConfig("EventFunction_language", "Desc_287"), new int[2] { 4, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_287_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_287_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_287")));
		_dataArray.Add(new EventFunctionItem(288, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_288"), LocalStringManager.GetConfig("EventFunction_language", "Desc_288"), new int[3] { 82, 4, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_288_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_288_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_288_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_288")));
		_dataArray.Add(new EventFunctionItem(289, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_289"), LocalStringManager.GetConfig("EventFunction_language", "Desc_289"), new int[2] { 8, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_289_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_289_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_289")));
		_dataArray.Add(new EventFunctionItem(290, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_290"), LocalStringManager.GetConfig("EventFunction_language", "Desc_290"), new int[3] { 82, 61, 41 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_290_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_290_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_290_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_290")));
		_dataArray.Add(new EventFunctionItem(291, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_291"), LocalStringManager.GetConfig("EventFunction_language", "Desc_291"), new int[5] { 82, 4, 41, 3, 73 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_291_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_291_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_291_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_291_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_291_4")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_291")));
		_dataArray.Add(new EventFunctionItem(292, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_292"), LocalStringManager.GetConfig("EventFunction_language", "Desc_292"), new int[3] { 82, 61, 41 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_292_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_292_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_292_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_292")));
		_dataArray.Add(new EventFunctionItem(293, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_293"), LocalStringManager.GetConfig("EventFunction_language", "Desc_293"), new int[5] { 82, 4, 41, 3, 73 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_293_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_293_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_293_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_293_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_293_4")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_293")));
		_dataArray.Add(new EventFunctionItem(294, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_294"), LocalStringManager.GetConfig("EventFunction_language", "Desc_294"), new int[2] { 82, 61 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_294_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_294_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_294")));
		_dataArray.Add(new EventFunctionItem(295, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_295"), LocalStringManager.GetConfig("EventFunction_language", "Desc_295"), new int[4] { 82, 4, 3, 73 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_295_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_295_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_295_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_295_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_295")));
		_dataArray.Add(new EventFunctionItem(296, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_296"), LocalStringManager.GetConfig("EventFunction_language", "Desc_296"), new int[3] { 82, 4, 73 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_296_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_296_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_296_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_296")));
		_dataArray.Add(new EventFunctionItem(297, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_297"), LocalStringManager.GetConfig("EventFunction_language", "Desc_297"), new int[3] { 82, 61, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_297_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_297_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_297_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_297")));
		_dataArray.Add(new EventFunctionItem(298, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_298"), LocalStringManager.GetConfig("EventFunction_language", "Desc_298"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_298")));
		_dataArray.Add(new EventFunctionItem(299, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_299"), LocalStringManager.GetConfig("EventFunction_language", "Desc_299"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_299_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_299")));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new EventFunctionItem(300, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_300"), LocalStringManager.GetConfig("EventFunction_language", "Desc_300"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_300_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_300")));
		_dataArray.Add(new EventFunctionItem(301, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_301"), LocalStringManager.GetConfig("EventFunction_language", "Desc_301"), new int[3] { 61, 4, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_301_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_301_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_301_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_301")));
		_dataArray.Add(new EventFunctionItem(302, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_302"), LocalStringManager.GetConfig("EventFunction_language", "Desc_302"), new int[5] { 82, 4, 4, 3, 73 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_302_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_302_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_302_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_302_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_302_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_302")));
		_dataArray.Add(new EventFunctionItem(303, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_303"), LocalStringManager.GetConfig("EventFunction_language", "Desc_303"), new int[4] { 4, 4, 3, 73 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_303_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_303_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_303_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_303_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_303")));
		_dataArray.Add(new EventFunctionItem(304, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_304"), LocalStringManager.GetConfig("EventFunction_language", "Desc_304"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_304_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_304")));
		_dataArray.Add(new EventFunctionItem(305, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_305"), LocalStringManager.GetConfig("EventFunction_language", "Desc_305"), new int[2] { 66, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_305_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_305_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_305")));
		_dataArray.Add(new EventFunctionItem(306, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_306"), LocalStringManager.GetConfig("EventFunction_language", "Desc_306"), new int[3] { 66, 41, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_306_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_306_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_306_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_306")));
		_dataArray.Add(new EventFunctionItem(307, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_307"), LocalStringManager.GetConfig("EventFunction_language", "Desc_307"), new int[4] { 82, 61, 1, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_307_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_307_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_307_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_307_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_307")));
		_dataArray.Add(new EventFunctionItem(308, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_308"), LocalStringManager.GetConfig("EventFunction_language", "Desc_308"), new int[5] { 82, 4, 1, 3, 73 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_308_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_308_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_308_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_308_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_308_4")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_308")));
		_dataArray.Add(new EventFunctionItem(309, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_309"), LocalStringManager.GetConfig("EventFunction_language", "Desc_309"), new int[5] { 61, 1, 1, 1, 3 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_309_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_309_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_309_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_309_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_309_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_309")));
		_dataArray.Add(new EventFunctionItem(310, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_310"), LocalStringManager.GetConfig("EventFunction_language", "Desc_310"), new int[3] { 82, 61, 45 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_310_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_310_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_310_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_310")));
		_dataArray.Add(new EventFunctionItem(311, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_311"), LocalStringManager.GetConfig("EventFunction_language", "Desc_311"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_311_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_311")));
		_dataArray.Add(new EventFunctionItem(312, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_312"), LocalStringManager.GetConfig("EventFunction_language", "Desc_312"), new int[2] { 82, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_312_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_312_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_312")));
		_dataArray.Add(new EventFunctionItem(313, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_313"), LocalStringManager.GetConfig("EventFunction_language", "Desc_313"), new int[2] { 82, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_313_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_313_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_313")));
		_dataArray.Add(new EventFunctionItem(314, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_314"), LocalStringManager.GetConfig("EventFunction_language", "Desc_314"), new int[5] { 82, 1, 4, 3, 73 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_314_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_314_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_314_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_314_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_314_4")
		}, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_314")));
		_dataArray.Add(new EventFunctionItem(315, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_315"), LocalStringManager.GetConfig("EventFunction_language", "Desc_315"), new int[1] { 6 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_315")));
		_dataArray.Add(new EventFunctionItem(316, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_316"), LocalStringManager.GetConfig("EventFunction_language", "Desc_316"), new int[3] { 6, 7, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_316_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_316_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_316_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_316")));
		_dataArray.Add(new EventFunctionItem(317, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_317"), LocalStringManager.GetConfig("EventFunction_language", "Desc_317"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_317_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_317_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_317")));
		_dataArray.Add(new EventFunctionItem(318, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_318"), LocalStringManager.GetConfig("EventFunction_language", "Desc_318"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_318_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_318_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_318")));
		_dataArray.Add(new EventFunctionItem(319, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_319"), LocalStringManager.GetConfig("EventFunction_language", "Desc_319"), new int[2] { 6, 28 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_319")));
		_dataArray.Add(new EventFunctionItem(320, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_320"), LocalStringManager.GetConfig("EventFunction_language", "Desc_320"), new int[2] { 23, 13 }, new string[0], 8, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_320")));
		_dataArray.Add(new EventFunctionItem(321, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_321"), LocalStringManager.GetConfig("EventFunction_language", "Desc_321"), new int[2] { 7, 13 }, new string[0], 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_321")));
		_dataArray.Add(new EventFunctionItem(322, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_322"), LocalStringManager.GetConfig("EventFunction_language", "Desc_322"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_322")));
		_dataArray.Add(new EventFunctionItem(323, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_323"), LocalStringManager.GetConfig("EventFunction_language", "Desc_323"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_323")));
		_dataArray.Add(new EventFunctionItem(324, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_324"), LocalStringManager.GetConfig("EventFunction_language", "Desc_324"), new int[2] { 6, 5 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_324")));
		_dataArray.Add(new EventFunctionItem(325, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_325"), LocalStringManager.GetConfig("EventFunction_language", "Desc_325"), new int[3] { 11, 67, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_325_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_325_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_325_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_325")));
		_dataArray.Add(new EventFunctionItem(326, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_326"), LocalStringManager.GetConfig("EventFunction_language", "Desc_326"), new int[2] { 11, 67 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_326")));
		_dataArray.Add(new EventFunctionItem(327, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_327"), LocalStringManager.GetConfig("EventFunction_language", "Desc_327"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_327")));
		_dataArray.Add(new EventFunctionItem(328, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_328"), LocalStringManager.GetConfig("EventFunction_language", "Desc_328"), new int[1] { 11 }, new string[0], 68, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_328")));
		_dataArray.Add(new EventFunctionItem(329, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_329"), LocalStringManager.GetConfig("EventFunction_language", "Desc_329"), new int[1] { 5 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_329_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_329")));
		_dataArray.Add(new EventFunctionItem(330, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_330"), LocalStringManager.GetConfig("EventFunction_language", "Desc_330"), new int[2] { 11, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_330_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_330_1")
		}, 9, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_330")));
		_dataArray.Add(new EventFunctionItem(331, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_331"), LocalStringManager.GetConfig("EventFunction_language", "Desc_331"), new int[2] { 41, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_331_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_331_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_331")));
		_dataArray.Add(new EventFunctionItem(332, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_332"), LocalStringManager.GetConfig("EventFunction_language", "Desc_332"), new int[0], new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_332")));
		_dataArray.Add(new EventFunctionItem(333, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_333"), LocalStringManager.GetConfig("EventFunction_language", "Desc_333"), new int[3] { 6, 6, 5 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_333_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_333_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_333_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_333")));
		_dataArray.Add(new EventFunctionItem(334, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_334"), LocalStringManager.GetConfig("EventFunction_language", "Desc_334"), new int[4] { 4, 4, 3, 73 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_334_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_334_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_334_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_334_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_334")));
		_dataArray.Add(new EventFunctionItem(335, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_335"), LocalStringManager.GetConfig("EventFunction_language", "Desc_335"), new int[4] { 6, 8, 1, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_335_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_335_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_335_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_335_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_335")));
		_dataArray.Add(new EventFunctionItem(336, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_336"), LocalStringManager.GetConfig("EventFunction_language", "Desc_336"), new int[3] { 41, 57, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_336_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_336_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_336_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_336")));
		_dataArray.Add(new EventFunctionItem(337, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_337"), LocalStringManager.GetConfig("EventFunction_language", "Desc_337"), new int[1] { 82 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_337_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_337")));
		_dataArray.Add(new EventFunctionItem(338, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_338"), LocalStringManager.GetConfig("EventFunction_language", "Desc_338"), new int[4] { 82, 4, 3, 73 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_338_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_338_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_338_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_338_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_338")));
		_dataArray.Add(new EventFunctionItem(339, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_339"), LocalStringManager.GetConfig("EventFunction_language", "Desc_339"), new int[1] { 70 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_339_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_339")));
		_dataArray.Add(new EventFunctionItem(340, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_340"), LocalStringManager.GetConfig("EventFunction_language", "Desc_340"), new int[6] { 4, 1, 1, 1, 3, 73 }, new string[6]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_340_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_340_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_340_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_340_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_340_4"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_340_5")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_340")));
		_dataArray.Add(new EventFunctionItem(341, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_341"), LocalStringManager.GetConfig("EventFunction_language", "Desc_341"), new int[2] { 11, 68 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_341")));
		_dataArray.Add(new EventFunctionItem(342, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_342"), LocalStringManager.GetConfig("EventFunction_language", "Desc_342"), new int[3] { 3, 3, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_342_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_342_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_342_2")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_342")));
		_dataArray.Add(new EventFunctionItem(343, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_343"), LocalStringManager.GetConfig("EventFunction_language", "Desc_343"), new int[0], new string[0], 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_343")));
		_dataArray.Add(new EventFunctionItem(344, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_344"), LocalStringManager.GetConfig("EventFunction_language", "Desc_344"), new int[3] { 0, 1, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_344_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_344_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_344_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_344")));
		_dataArray.Add(new EventFunctionItem(345, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_345"), LocalStringManager.GetConfig("EventFunction_language", "Desc_345"), new int[2] { 0, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_345_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_345_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_345")));
		_dataArray.Add(new EventFunctionItem(346, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_346"), LocalStringManager.GetConfig("EventFunction_language", "Desc_346"), new int[4] { 4, 3, 3, 73 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_346_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_346_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_346_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_346_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_346")));
		_dataArray.Add(new EventFunctionItem(347, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_347"), LocalStringManager.GetConfig("EventFunction_language", "Desc_347"), new int[5] { 82, 4, 3, 3, 73 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_347_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_347_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_347_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_347_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_347_4")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_347")));
		_dataArray.Add(new EventFunctionItem(348, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_348"), LocalStringManager.GetConfig("EventFunction_language", "Desc_348"), new int[1] { 7 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_348")));
		_dataArray.Add(new EventFunctionItem(349, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_349"), LocalStringManager.GetConfig("EventFunction_language", "Desc_349"), new int[2] { 82, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_349_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_349_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_349")));
		_dataArray.Add(new EventFunctionItem(350, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_350"), LocalStringManager.GetConfig("EventFunction_language", "Desc_350"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_350")));
		_dataArray.Add(new EventFunctionItem(351, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_351"), LocalStringManager.GetConfig("EventFunction_language", "Desc_351"), new int[1] { 82 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_351_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_351")));
		_dataArray.Add(new EventFunctionItem(352, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_352"), LocalStringManager.GetConfig("EventFunction_language", "Desc_352"), new int[3] { 82, 41, 66 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_352_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_352_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_352_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_352")));
		_dataArray.Add(new EventFunctionItem(353, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_353"), LocalStringManager.GetConfig("EventFunction_language", "Desc_353"), new int[2] { 9, 71 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_353")));
		_dataArray.Add(new EventFunctionItem(354, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_354"), LocalStringManager.GetConfig("EventFunction_language", "Desc_354"), new int[1] { 10 }, new string[0], 9, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_354")));
		_dataArray.Add(new EventFunctionItem(355, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_355"), LocalStringManager.GetConfig("EventFunction_language", "Desc_355"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_355")));
		_dataArray.Add(new EventFunctionItem(356, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_356"), LocalStringManager.GetConfig("EventFunction_language", "Desc_356"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_356")));
		_dataArray.Add(new EventFunctionItem(357, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_357"), LocalStringManager.GetConfig("EventFunction_language", "Desc_357"), new int[1] { 82 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_357_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_357")));
		_dataArray.Add(new EventFunctionItem(358, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_358"), LocalStringManager.GetConfig("EventFunction_language", "Desc_358"), new int[5] { 82, 1, 41, 1, 3 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_358_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_358_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_358_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_358_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_358_4")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_358")));
		_dataArray.Add(new EventFunctionItem(359, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_359"), LocalStringManager.GetConfig("EventFunction_language", "Desc_359"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_359_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_359_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_359")));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new EventFunctionItem(360, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_360"), LocalStringManager.GetConfig("EventFunction_language", "Desc_360"), new int[6] { 6, 1, 1, 1, 1, 1 }, new string[6]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_360_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_360_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_360_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_360_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_360_4"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_360_5")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_360")));
		_dataArray.Add(new EventFunctionItem(361, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_361"), LocalStringManager.GetConfig("EventFunction_language", "Desc_361"), new int[1] { 82 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_361_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_361")));
		_dataArray.Add(new EventFunctionItem(362, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_362"), LocalStringManager.GetConfig("EventFunction_language", "Desc_362"), new int[0], new string[0], 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_362")));
		_dataArray.Add(new EventFunctionItem(363, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_363"), LocalStringManager.GetConfig("EventFunction_language", "Desc_363"), new int[2] { 46, 46 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_363_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_363_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_363")));
		_dataArray.Add(new EventFunctionItem(364, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_364"), LocalStringManager.GetConfig("EventFunction_language", "Desc_364"), new int[4] { 20, 3, 3, 4 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_364_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_364_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_364_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_364_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_364")));
		_dataArray.Add(new EventFunctionItem(365, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_365"), LocalStringManager.GetConfig("EventFunction_language", "Desc_365"), new int[4] { 4, 4, 3, 73 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_365_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_365_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_365_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_365_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_365")));
		_dataArray.Add(new EventFunctionItem(366, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_366"), LocalStringManager.GetConfig("EventFunction_language", "Desc_366"), new int[4] { 4, 4, 3, 73 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_366_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_366_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_366_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_366_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_366")));
		_dataArray.Add(new EventFunctionItem(367, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_367"), LocalStringManager.GetConfig("EventFunction_language", "Desc_367"), new int[5] { 1, 4, 4, 3, 73 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_367_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_367_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_367_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_367_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_367_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_367")));
		_dataArray.Add(new EventFunctionItem(368, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_368"), LocalStringManager.GetConfig("EventFunction_language", "Desc_368"), new int[3] { 6, 7, 7 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_368_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_368_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_368_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_368")));
		_dataArray.Add(new EventFunctionItem(369, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_369"), LocalStringManager.GetConfig("EventFunction_language", "Desc_369"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_369_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_369")));
		_dataArray.Add(new EventFunctionItem(370, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_370"), LocalStringManager.GetConfig("EventFunction_language", "Desc_370"), new int[3] { 4, 73, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_370_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_370_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_370_2")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_370")));
		_dataArray.Add(new EventFunctionItem(371, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_371"), LocalStringManager.GetConfig("EventFunction_language", "Desc_371"), new int[5] { 4, 73, 3, 1, 1 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_371_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_371_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_371_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_371_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_371_4")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_371")));
		_dataArray.Add(new EventFunctionItem(372, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_372"), LocalStringManager.GetConfig("EventFunction_language", "Desc_372"), new int[3] { 4, 3, 73 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_372_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_372_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_372_2")
		}, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_372")));
		_dataArray.Add(new EventFunctionItem(373, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_373"), LocalStringManager.GetConfig("EventFunction_language", "Desc_373"), new int[2] { 46, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_373_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_373_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_373")));
		_dataArray.Add(new EventFunctionItem(374, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_374"), LocalStringManager.GetConfig("EventFunction_language", "Desc_374"), new int[2] { 5, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_374_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_374_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_374")));
		_dataArray.Add(new EventFunctionItem(375, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_375"), LocalStringManager.GetConfig("EventFunction_language", "Desc_375"), new int[2] { 6, 23 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_375")));
		_dataArray.Add(new EventFunctionItem(376, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_376"), LocalStringManager.GetConfig("EventFunction_language", "Desc_376"), new int[2] { 6, 23 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_376")));
		_dataArray.Add(new EventFunctionItem(377, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_377"), LocalStringManager.GetConfig("EventFunction_language", "Desc_377"), new int[2] { 6, 6 }, new string[0], 53, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_377")));
		_dataArray.Add(new EventFunctionItem(378, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_378"), LocalStringManager.GetConfig("EventFunction_language", "Desc_378"), new int[3] { 82, 41, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_378_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_378_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_378_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_378")));
		_dataArray.Add(new EventFunctionItem(379, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_379"), LocalStringManager.GetConfig("EventFunction_language", "Desc_379"), new int[3] { 6, 3, 5 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_379_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_379_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_379_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_379")));
		_dataArray.Add(new EventFunctionItem(380, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_380"), LocalStringManager.GetConfig("EventFunction_language", "Desc_380"), new int[3] { 82, 74, 75 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_380_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_380_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_380_2")
		}, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_380")));
		_dataArray.Add(new EventFunctionItem(381, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_381"), LocalStringManager.GetConfig("EventFunction_language", "Desc_381"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_381_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_381")));
		_dataArray.Add(new EventFunctionItem(382, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_382"), LocalStringManager.GetConfig("EventFunction_language", "Desc_382"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_382")));
		_dataArray.Add(new EventFunctionItem(383, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_383"), LocalStringManager.GetConfig("EventFunction_language", "Desc_383"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_383")));
		_dataArray.Add(new EventFunctionItem(384, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_384"), LocalStringManager.GetConfig("EventFunction_language", "Desc_384"), new int[2] { 6, 76 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_384")));
		_dataArray.Add(new EventFunctionItem(385, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_385"), LocalStringManager.GetConfig("EventFunction_language", "Desc_385"), new int[2] { 6, 76 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_385")));
		_dataArray.Add(new EventFunctionItem(386, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_386"), LocalStringManager.GetConfig("EventFunction_language", "Desc_386"), new int[1] { 6 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_386")));
		_dataArray.Add(new EventFunctionItem(387, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_387"), LocalStringManager.GetConfig("EventFunction_language", "Desc_387"), new int[3] { 82, 41, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_387_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_387_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_387_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_387")));
		_dataArray.Add(new EventFunctionItem(388, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_388"), LocalStringManager.GetConfig("EventFunction_language", "Desc_388"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_388")));
		_dataArray.Add(new EventFunctionItem(389, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_389"), LocalStringManager.GetConfig("EventFunction_language", "Desc_389"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_389")));
		_dataArray.Add(new EventFunctionItem(390, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_390"), LocalStringManager.GetConfig("EventFunction_language", "Desc_390"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_390")));
		_dataArray.Add(new EventFunctionItem(391, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_391"), LocalStringManager.GetConfig("EventFunction_language", "Desc_391"), new int[1] { 82 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_391_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_391")));
		_dataArray.Add(new EventFunctionItem(392, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_392"), LocalStringManager.GetConfig("EventFunction_language", "Desc_392"), new int[5] { 4, 1, 3, 3, 73 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_392_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_392_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_392_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_392_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_392_4")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_392")));
		_dataArray.Add(new EventFunctionItem(393, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_393"), LocalStringManager.GetConfig("EventFunction_language", "Desc_393"), new int[2] { 82, 82 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_393_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_393_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_393")));
		_dataArray.Add(new EventFunctionItem(394, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_394"), LocalStringManager.GetConfig("EventFunction_language", "Desc_394"), new int[3] { 6, 76, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_394_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_394_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_394_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_394")));
		_dataArray.Add(new EventFunctionItem(395, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_395"), LocalStringManager.GetConfig("EventFunction_language", "Desc_395"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_395")));
		_dataArray.Add(new EventFunctionItem(396, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_396"), LocalStringManager.GetConfig("EventFunction_language", "Desc_396"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_396_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_396")));
		_dataArray.Add(new EventFunctionItem(397, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_397"), LocalStringManager.GetConfig("EventFunction_language", "Desc_397"), new int[1] { 77 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_397")));
		_dataArray.Add(new EventFunctionItem(398, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_398"), LocalStringManager.GetConfig("EventFunction_language", "Desc_398"), new int[2] { 7, 15 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_398_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_398_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_398")));
		_dataArray.Add(new EventFunctionItem(399, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_399"), LocalStringManager.GetConfig("EventFunction_language", "Desc_399"), new int[2] { 0, 44 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_399_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_399_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_399")));
		_dataArray.Add(new EventFunctionItem(400, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_400"), LocalStringManager.GetConfig("EventFunction_language", "Desc_400"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_400_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_400")));
		_dataArray.Add(new EventFunctionItem(401, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_401"), LocalStringManager.GetConfig("EventFunction_language", "Desc_401"), new int[2] { 7, 7 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_401_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_401_1")
		}, 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_401")));
		_dataArray.Add(new EventFunctionItem(402, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_402"), LocalStringManager.GetConfig("EventFunction_language", "Desc_402"), new int[4] { 4, 4, 73, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_402_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_402_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_402_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_402_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_402")));
		_dataArray.Add(new EventFunctionItem(403, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_403"), LocalStringManager.GetConfig("EventFunction_language", "Desc_403"), new int[3] { 82, 61, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_403_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_403_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_403_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_403")));
		_dataArray.Add(new EventFunctionItem(404, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_404"), LocalStringManager.GetConfig("EventFunction_language", "Desc_404"), new int[3] { 82, 82, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_404_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_404_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_404_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_404")));
		_dataArray.Add(new EventFunctionItem(405, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_405"), LocalStringManager.GetConfig("EventFunction_language", "Desc_405"), new int[3] { 82, 1, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_405_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_405_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_405_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_405")));
		_dataArray.Add(new EventFunctionItem(406, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_406"), LocalStringManager.GetConfig("EventFunction_language", "Desc_406"), new int[2] { 6, 18 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_406_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_406_1")
		}, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_406")));
		_dataArray.Add(new EventFunctionItem(407, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_407"), LocalStringManager.GetConfig("EventFunction_language", "Desc_407"), new int[2] { 6, 25 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_407_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_407_1")
		}, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_407")));
		_dataArray.Add(new EventFunctionItem(408, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_408"), LocalStringManager.GetConfig("EventFunction_language", "Desc_408"), new int[2] { 7, 79 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_408")));
		_dataArray.Add(new EventFunctionItem(409, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_409"), LocalStringManager.GetConfig("EventFunction_language", "Desc_409"), new int[2] { 69, 20 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_409_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_409_1")
		}, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_409")));
		_dataArray.Add(new EventFunctionItem(410, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_410"), LocalStringManager.GetConfig("EventFunction_language", "Desc_410"), new int[1] { 82 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_410_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_410")));
		_dataArray.Add(new EventFunctionItem(411, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_411"), LocalStringManager.GetConfig("EventFunction_language", "Desc_411"), new int[2] { 4, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_411_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_411_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_411")));
		_dataArray.Add(new EventFunctionItem(412, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_412"), LocalStringManager.GetConfig("EventFunction_language", "Desc_412"), new int[2] { 82, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_412_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_412_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_412")));
		_dataArray.Add(new EventFunctionItem(413, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_413"), LocalStringManager.GetConfig("EventFunction_language", "Desc_413"), new int[2] { 1, 109 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_413_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_413_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_413")));
		_dataArray.Add(new EventFunctionItem(414, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_414"), LocalStringManager.GetConfig("EventFunction_language", "Desc_414"), new int[1] { 80 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_414")));
		_dataArray.Add(new EventFunctionItem(415, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_415"), LocalStringManager.GetConfig("EventFunction_language", "Desc_415"), new int[2] { 80, 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_415")));
		_dataArray.Add(new EventFunctionItem(416, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_416"), LocalStringManager.GetConfig("EventFunction_language", "Desc_416"), new int[3] { 80, 6, 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_416")));
		_dataArray.Add(new EventFunctionItem(417, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_417"), LocalStringManager.GetConfig("EventFunction_language", "Desc_417"), new int[4] { 80, 6, 6, 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_417")));
		_dataArray.Add(new EventFunctionItem(418, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_418"), LocalStringManager.GetConfig("EventFunction_language", "Desc_418"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_418")));
		_dataArray.Add(new EventFunctionItem(419, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_419"), LocalStringManager.GetConfig("EventFunction_language", "Desc_419"), new int[1] { 69 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_419_0") }, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_419")));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new EventFunctionItem(420, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_420"), LocalStringManager.GetConfig("EventFunction_language", "Desc_420"), new int[2] { 5, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_420_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_420_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_420")));
		_dataArray.Add(new EventFunctionItem(421, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_421"), LocalStringManager.GetConfig("EventFunction_language", "Desc_421"), new int[1] { 81 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_421")));
		_dataArray.Add(new EventFunctionItem(422, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_422"), LocalStringManager.GetConfig("EventFunction_language", "Desc_422"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_422_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_422")));
		_dataArray.Add(new EventFunctionItem(423, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_423"), LocalStringManager.GetConfig("EventFunction_language", "Desc_423"), new int[2] { 4, 4 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_423")));
		_dataArray.Add(new EventFunctionItem(424, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_424"), LocalStringManager.GetConfig("EventFunction_language", "Desc_424"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_424_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_424")));
		_dataArray.Add(new EventFunctionItem(425, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_425"), LocalStringManager.GetConfig("EventFunction_language", "Desc_425"), new int[3] { 0, 0, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_425_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_425_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_425_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_425")));
		_dataArray.Add(new EventFunctionItem(426, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_426"), LocalStringManager.GetConfig("EventFunction_language", "Desc_426"), new int[3] { 6, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_426")));
		_dataArray.Add(new EventFunctionItem(427, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_427"), LocalStringManager.GetConfig("EventFunction_language", "Desc_427"), new int[0], new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_427")));
		_dataArray.Add(new EventFunctionItem(428, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_428"), LocalStringManager.GetConfig("EventFunction_language", "Desc_428"), new int[1] { 82 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_428_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_428")));
		_dataArray.Add(new EventFunctionItem(429, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_429"), LocalStringManager.GetConfig("EventFunction_language", "Desc_429"), new int[2] { 1, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_429_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_429_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_429")));
		_dataArray.Add(new EventFunctionItem(430, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_430"), LocalStringManager.GetConfig("EventFunction_language", "Desc_430"), new int[2] { 82, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_430_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_430_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_430")));
		_dataArray.Add(new EventFunctionItem(431, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_431"), LocalStringManager.GetConfig("EventFunction_language", "Desc_431"), new int[3] { 82, 82, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_431_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_431_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_431_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_431")));
		_dataArray.Add(new EventFunctionItem(432, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_432"), LocalStringManager.GetConfig("EventFunction_language", "Desc_432"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_432_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_432")));
		_dataArray.Add(new EventFunctionItem(433, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_433"), LocalStringManager.GetConfig("EventFunction_language", "Desc_433"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_433_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_433")));
		_dataArray.Add(new EventFunctionItem(434, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_434"), LocalStringManager.GetConfig("EventFunction_language", "Desc_434"), new int[2] { 0, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_434_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_434_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_434")));
		_dataArray.Add(new EventFunctionItem(435, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_435"), LocalStringManager.GetConfig("EventFunction_language", "Desc_435"), new int[2] { 0, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_435_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_435_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_435")));
		_dataArray.Add(new EventFunctionItem(436, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_436"), LocalStringManager.GetConfig("EventFunction_language", "Desc_436"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_436_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_436")));
		_dataArray.Add(new EventFunctionItem(437, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_437"), LocalStringManager.GetConfig("EventFunction_language", "Desc_437"), new int[0], new string[0], 5, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_437")));
		_dataArray.Add(new EventFunctionItem(438, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_438"), LocalStringManager.GetConfig("EventFunction_language", "Desc_438"), new int[3] { 4, 73, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_438_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_438_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_438_2")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_438")));
		_dataArray.Add(new EventFunctionItem(439, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_439"), LocalStringManager.GetConfig("EventFunction_language", "Desc_439"), new int[2] { 61, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_439_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_439_1")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_439")));
		_dataArray.Add(new EventFunctionItem(440, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_440"), LocalStringManager.GetConfig("EventFunction_language", "Desc_440"), new int[4] { 6, 22, 23, 13 }, new string[0], 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_440")));
		_dataArray.Add(new EventFunctionItem(441, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_441"), LocalStringManager.GetConfig("EventFunction_language", "Desc_441"), new int[3] { 6, 6, 7 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_441_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_441_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_441_2")
		}, 83, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_441")));
		_dataArray.Add(new EventFunctionItem(442, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_442"), LocalStringManager.GetConfig("EventFunction_language", "Desc_442"), new int[3] { 0, 41, 83 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_442")));
		_dataArray.Add(new EventFunctionItem(443, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_443"), LocalStringManager.GetConfig("EventFunction_language", "Desc_443"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_443_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_443")));
		_dataArray.Add(new EventFunctionItem(444, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_444"), LocalStringManager.GetConfig("EventFunction_language", "Desc_444"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_444_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_444")));
		_dataArray.Add(new EventFunctionItem(445, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_445"), LocalStringManager.GetConfig("EventFunction_language", "Desc_445"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_445_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_445")));
		_dataArray.Add(new EventFunctionItem(446, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_446"), LocalStringManager.GetConfig("EventFunction_language", "Desc_446"), new int[2] { 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_446")));
		_dataArray.Add(new EventFunctionItem(447, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_447"), LocalStringManager.GetConfig("EventFunction_language", "Desc_447"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_447")));
		_dataArray.Add(new EventFunctionItem(448, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_448"), LocalStringManager.GetConfig("EventFunction_language", "Desc_448"), new int[4] { 4, 1, 3, 73 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_448_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_448_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_448_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_448_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_448")));
		_dataArray.Add(new EventFunctionItem(449, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_449"), LocalStringManager.GetConfig("EventFunction_language", "Desc_449"), new int[2] { 6, 22 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_449")));
		_dataArray.Add(new EventFunctionItem(450, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_450"), LocalStringManager.GetConfig("EventFunction_language", "Desc_450"), new int[1] { 71 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_450_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_450")));
		_dataArray.Add(new EventFunctionItem(451, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_451"), LocalStringManager.GetConfig("EventFunction_language", "Desc_451"), new int[1] { 69 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_451_0") }, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_451")));
		_dataArray.Add(new EventFunctionItem(452, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_452"), LocalStringManager.GetConfig("EventFunction_language", "Desc_452"), new int[2] { 82, 7 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_452_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_452_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_452")));
		_dataArray.Add(new EventFunctionItem(453, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_453"), LocalStringManager.GetConfig("EventFunction_language", "Desc_453"), new int[2] { 82, 7 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_453_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_453_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_453")));
		_dataArray.Add(new EventFunctionItem(454, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_454"), LocalStringManager.GetConfig("EventFunction_language", "Desc_454"), new int[2] { 82, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_454_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_454_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_454")));
		_dataArray.Add(new EventFunctionItem(455, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_455"), LocalStringManager.GetConfig("EventFunction_language", "Desc_455"), new int[2] { 82, 8 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_455_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_455_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_455")));
		_dataArray.Add(new EventFunctionItem(456, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_456"), LocalStringManager.GetConfig("EventFunction_language", "Desc_456"), new int[3] { 6, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_456")));
		_dataArray.Add(new EventFunctionItem(457, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_457"), LocalStringManager.GetConfig("EventFunction_language", "Desc_457"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_457_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_457")));
		_dataArray.Add(new EventFunctionItem(458, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_458"), LocalStringManager.GetConfig("EventFunction_language", "Desc_458"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_458")));
		_dataArray.Add(new EventFunctionItem(459, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_459"), LocalStringManager.GetConfig("EventFunction_language", "Desc_459"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_459")));
		_dataArray.Add(new EventFunctionItem(460, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_460"), LocalStringManager.GetConfig("EventFunction_language", "Desc_460"), new int[2] { 6, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_460_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_460_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_460")));
		_dataArray.Add(new EventFunctionItem(461, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_461"), LocalStringManager.GetConfig("EventFunction_language", "Desc_461"), new int[3] { 82, 7, 7 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_461_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_461_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_461_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_461")));
		_dataArray.Add(new EventFunctionItem(462, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_462"), LocalStringManager.GetConfig("EventFunction_language", "Desc_462"), new int[3] { 82, 7, 6 }, new string[0], 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_462")));
		_dataArray.Add(new EventFunctionItem(463, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_463"), LocalStringManager.GetConfig("EventFunction_language", "Desc_463"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_463_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_463")));
		_dataArray.Add(new EventFunctionItem(464, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_464"), LocalStringManager.GetConfig("EventFunction_language", "Desc_464"), new int[2] { 82, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_464_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_464_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_464")));
		_dataArray.Add(new EventFunctionItem(465, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_465"), LocalStringManager.GetConfig("EventFunction_language", "Desc_465"), new int[1] { 82 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_465")));
		_dataArray.Add(new EventFunctionItem(466, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_466"), LocalStringManager.GetConfig("EventFunction_language", "Desc_466"), new int[2] { 61, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_466_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_466_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_466")));
		_dataArray.Add(new EventFunctionItem(467, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_467"), LocalStringManager.GetConfig("EventFunction_language", "Desc_467"), new int[3] { 4, 73, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_467_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_467_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_467_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_467")));
		_dataArray.Add(new EventFunctionItem(468, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_468"), LocalStringManager.GetConfig("EventFunction_language", "Desc_468"), new int[3] { 82, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_468")));
		_dataArray.Add(new EventFunctionItem(469, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_469"), LocalStringManager.GetConfig("EventFunction_language", "Desc_469"), new int[4] { 61, 41, 1, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_469_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_469_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_469_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_469_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_469")));
		_dataArray.Add(new EventFunctionItem(470, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_470"), LocalStringManager.GetConfig("EventFunction_language", "Desc_470"), new int[5] { 4, 73, 41, 1, 3 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_470_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_470_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_470_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_470_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_470_4")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_470")));
		_dataArray.Add(new EventFunctionItem(471, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_471"), LocalStringManager.GetConfig("EventFunction_language", "Desc_471"), new int[2] { 82, 23 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_471")));
		_dataArray.Add(new EventFunctionItem(472, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_472"), LocalStringManager.GetConfig("EventFunction_language", "Desc_472"), new int[2] { 82, 23 }, new string[0], 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_472")));
		_dataArray.Add(new EventFunctionItem(473, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_473"), LocalStringManager.GetConfig("EventFunction_language", "Desc_473"), new int[1] { 84 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_473")));
		_dataArray.Add(new EventFunctionItem(474, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_474"), LocalStringManager.GetConfig("EventFunction_language", "Desc_474"), new int[2] { 8, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_474_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_474_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_474")));
		_dataArray.Add(new EventFunctionItem(475, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_475"), LocalStringManager.GetConfig("EventFunction_language", "Desc_475"), new int[1] { 10 }, new string[0], 11, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_475")));
		_dataArray.Add(new EventFunctionItem(476, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_476"), LocalStringManager.GetConfig("EventFunction_language", "Desc_476"), new int[2] { 11, 13 }, new string[0], 85, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_476")));
		_dataArray.Add(new EventFunctionItem(477, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_477"), LocalStringManager.GetConfig("EventFunction_language", "Desc_477"), new int[2] { 85, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_477_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_477_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_477")));
		_dataArray.Add(new EventFunctionItem(478, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_478"), LocalStringManager.GetConfig("EventFunction_language", "Desc_478"), new int[2] { 85, 7 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_478")));
		_dataArray.Add(new EventFunctionItem(479, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_479"), LocalStringManager.GetConfig("EventFunction_language", "Desc_479"), new int[2] { 85, 7 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_479")));
	}

	private void CreateItems8()
	{
		_dataArray.Add(new EventFunctionItem(480, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_480"), LocalStringManager.GetConfig("EventFunction_language", "Desc_480"), new int[1] { 85 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_480")));
		_dataArray.Add(new EventFunctionItem(481, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_481"), LocalStringManager.GetConfig("EventFunction_language", "Desc_481"), new int[1] { 11 }, new string[0], 10, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_481")));
		_dataArray.Add(new EventFunctionItem(482, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_482"), LocalStringManager.GetConfig("EventFunction_language", "Desc_482"), new int[2] { 86, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_482_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_482_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_482")));
		_dataArray.Add(new EventFunctionItem(483, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_483"), LocalStringManager.GetConfig("EventFunction_language", "Desc_483"), new int[4] { 3, 2, 3, 5 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_483_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_483_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_483_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_483_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_483")));
		_dataArray.Add(new EventFunctionItem(484, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_484"), LocalStringManager.GetConfig("EventFunction_language", "Desc_484"), new int[1] { 82 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_484")));
		_dataArray.Add(new EventFunctionItem(485, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_485"), LocalStringManager.GetConfig("EventFunction_language", "Desc_485"), new int[2] { 4, 0 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_485_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_485_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_485")));
		_dataArray.Add(new EventFunctionItem(486, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_486"), LocalStringManager.GetConfig("EventFunction_language", "Desc_486"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_486_0") }, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_486")));
		_dataArray.Add(new EventFunctionItem(487, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_487"), LocalStringManager.GetConfig("EventFunction_language", "Desc_487"), new int[2] { 6, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_487_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_487_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_487")));
		_dataArray.Add(new EventFunctionItem(488, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_488"), LocalStringManager.GetConfig("EventFunction_language", "Desc_488"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_488_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_488")));
		_dataArray.Add(new EventFunctionItem(489, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_489"), LocalStringManager.GetConfig("EventFunction_language", "Desc_489"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_489_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_489")));
		_dataArray.Add(new EventFunctionItem(490, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_490"), LocalStringManager.GetConfig("EventFunction_language", "Desc_490"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_490")));
		_dataArray.Add(new EventFunctionItem(491, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_491"), LocalStringManager.GetConfig("EventFunction_language", "Desc_491"), new int[5] { 61, 4, 41, 1, 3 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_491_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_491_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_491_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_491_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_491_4")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_491")));
		_dataArray.Add(new EventFunctionItem(492, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_492"), LocalStringManager.GetConfig("EventFunction_language", "Desc_492"), new int[4] { 82, 4, 73, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_492_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_492_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_492_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_492_3")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_492")));
		_dataArray.Add(new EventFunctionItem(493, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_493"), LocalStringManager.GetConfig("EventFunction_language", "Desc_493"), new int[2] { 6, 6 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_493_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_493_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_493")));
		_dataArray.Add(new EventFunctionItem(494, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_494"), LocalStringManager.GetConfig("EventFunction_language", "Desc_494"), new int[0], new string[0], 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_494")));
		_dataArray.Add(new EventFunctionItem(495, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_495"), LocalStringManager.GetConfig("EventFunction_language", "Desc_495"), new int[1] { 82 }, new string[0], 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_495")));
		_dataArray.Add(new EventFunctionItem(496, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_496"), LocalStringManager.GetConfig("EventFunction_language", "Desc_496"), new int[2] { 82, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_496_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_496_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_496")));
		_dataArray.Add(new EventFunctionItem(497, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_497"), LocalStringManager.GetConfig("EventFunction_language", "Desc_497"), new int[4] { 82, 4, 1, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_497_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_497_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_497_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_497_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_497")));
		_dataArray.Add(new EventFunctionItem(498, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_498"), LocalStringManager.GetConfig("EventFunction_language", "Desc_498"), new int[3] { 4, 1, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_498_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_498_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_498_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_498")));
		_dataArray.Add(new EventFunctionItem(499, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_499"), LocalStringManager.GetConfig("EventFunction_language", "Desc_499"), new int[1] { 61 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_499")));
		_dataArray.Add(new EventFunctionItem(500, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_500"), LocalStringManager.GetConfig("EventFunction_language", "Desc_500"), new int[1] { 1 }, new string[0], 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_500")));
		_dataArray.Add(new EventFunctionItem(501, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_501"), LocalStringManager.GetConfig("EventFunction_language", "Desc_501"), new int[1] { 87 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_501")));
		_dataArray.Add(new EventFunctionItem(502, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_502"), LocalStringManager.GetConfig("EventFunction_language", "Desc_502"), new int[1] { 82 }, new string[0], 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_502")));
		_dataArray.Add(new EventFunctionItem(503, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_503"), LocalStringManager.GetConfig("EventFunction_language", "Desc_503"), new int[0], new string[0], 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_503")));
		_dataArray.Add(new EventFunctionItem(504, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_504"), LocalStringManager.GetConfig("EventFunction_language", "Desc_504"), new int[2] { 87, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_504_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_504_1")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_504")));
		_dataArray.Add(new EventFunctionItem(505, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_505"), LocalStringManager.GetConfig("EventFunction_language", "Desc_505"), new int[5] { 87, 3, 2, 2, 5 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_505_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_505_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_505_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_505_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_505_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_505")));
		_dataArray.Add(new EventFunctionItem(506, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_506"), LocalStringManager.GetConfig("EventFunction_language", "Desc_506"), new int[2] { 82, 87 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_506")));
		_dataArray.Add(new EventFunctionItem(507, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_507"), LocalStringManager.GetConfig("EventFunction_language", "Desc_507"), new int[2] { 82, 87 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_507")));
		_dataArray.Add(new EventFunctionItem(508, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_508"), LocalStringManager.GetConfig("EventFunction_language", "Desc_508"), new int[3] { 61, 87, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_508_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_508_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_508_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_508")));
		_dataArray.Add(new EventFunctionItem(509, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_509"), LocalStringManager.GetConfig("EventFunction_language", "Desc_509"), new int[5] { 87, 4, 73, 3, 3 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_509_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_509_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_509_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_509_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_509_4")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_509")));
		_dataArray.Add(new EventFunctionItem(510, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_510"), LocalStringManager.GetConfig("EventFunction_language", "Desc_510"), new int[3] { 82, 1, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_510_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_510_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_510_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_510")));
		_dataArray.Add(new EventFunctionItem(511, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_511"), LocalStringManager.GetConfig("EventFunction_language", "Desc_511"), new int[3] { 82, 1, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_511_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_511_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_511_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_511")));
		_dataArray.Add(new EventFunctionItem(512, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_512"), LocalStringManager.GetConfig("EventFunction_language", "Desc_512"), new int[2] { 4, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_512_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_512_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_512")));
		_dataArray.Add(new EventFunctionItem(513, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_513"), LocalStringManager.GetConfig("EventFunction_language", "Desc_513"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_513_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_513")));
		_dataArray.Add(new EventFunctionItem(514, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_514"), LocalStringManager.GetConfig("EventFunction_language", "Desc_514"), new int[4] { 4, 3, 3, 2 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_514_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_514_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_514_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_514_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_514")));
		_dataArray.Add(new EventFunctionItem(515, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_515"), LocalStringManager.GetConfig("EventFunction_language", "Desc_515"), new int[2] { 46, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_515_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_515_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_515")));
		_dataArray.Add(new EventFunctionItem(516, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_516"), LocalStringManager.GetConfig("EventFunction_language", "Desc_516"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_516")));
		_dataArray.Add(new EventFunctionItem(517, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_517"), LocalStringManager.GetConfig("EventFunction_language", "Desc_517"), new int[2] { 12, 10 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_517")));
		_dataArray.Add(new EventFunctionItem(518, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_518"), LocalStringManager.GetConfig("EventFunction_language", "Desc_518"), new int[3] { 82, 4, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_518_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_518_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_518_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_518")));
		_dataArray.Add(new EventFunctionItem(519, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_519"), LocalStringManager.GetConfig("EventFunction_language", "Desc_519"), new int[3] { 82, 4, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_519_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_519_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_519_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_519")));
		_dataArray.Add(new EventFunctionItem(520, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_520"), LocalStringManager.GetConfig("EventFunction_language", "Desc_520"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_520")));
		_dataArray.Add(new EventFunctionItem(521, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_521"), LocalStringManager.GetConfig("EventFunction_language", "Desc_521"), new int[2] { 1, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_521_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_521_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_521")));
		_dataArray.Add(new EventFunctionItem(522, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_522"), LocalStringManager.GetConfig("EventFunction_language", "Desc_522"), new int[6] { 1, 1, 61, 41, 1, 3 }, new string[6]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_522_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_522_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_522_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_522_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_522_4"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_522_5")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_522")));
		_dataArray.Add(new EventFunctionItem(523, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_523"), LocalStringManager.GetConfig("EventFunction_language", "Desc_523"), new int[4] { 1, 1, 61, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_523_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_523_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_523_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_523_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_523")));
		_dataArray.Add(new EventFunctionItem(524, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_524"), LocalStringManager.GetConfig("EventFunction_language", "Desc_524"), new int[5] { 1, 1, 61, 4, 3 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_524_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_524_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_524_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_524_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_524_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_524")));
		_dataArray.Add(new EventFunctionItem(525, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_525"), LocalStringManager.GetConfig("EventFunction_language", "Desc_525"), new int[2] { 6, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_525")));
		_dataArray.Add(new EventFunctionItem(526, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_526"), LocalStringManager.GetConfig("EventFunction_language", "Desc_526"), new int[3] { 7, 1, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_526_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_526_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_526_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_526")));
		_dataArray.Add(new EventFunctionItem(527, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_527"), LocalStringManager.GetConfig("EventFunction_language", "Desc_527"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_527")));
		_dataArray.Add(new EventFunctionItem(528, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_528"), LocalStringManager.GetConfig("EventFunction_language", "Desc_528"), new int[2] { 3, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_528_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_528_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_528")));
		_dataArray.Add(new EventFunctionItem(529, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_529"), LocalStringManager.GetConfig("EventFunction_language", "Desc_529"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_529_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_529")));
		_dataArray.Add(new EventFunctionItem(530, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_530"), LocalStringManager.GetConfig("EventFunction_language", "Desc_530"), new int[2] { 6, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_530_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_530_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_530")));
		_dataArray.Add(new EventFunctionItem(531, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_531"), LocalStringManager.GetConfig("EventFunction_language", "Desc_531"), new int[4] { 6, 24, 13, 4 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_531_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_531_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_531_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_531_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_531")));
		_dataArray.Add(new EventFunctionItem(532, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_532"), LocalStringManager.GetConfig("EventFunction_language", "Desc_532"), new int[2] { 35, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_532")));
		_dataArray.Add(new EventFunctionItem(533, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_533"), LocalStringManager.GetConfig("EventFunction_language", "Desc_533"), new int[3] { 6, 6, 35 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_533_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_533_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_533_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_533")));
		_dataArray.Add(new EventFunctionItem(534, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_534"), LocalStringManager.GetConfig("EventFunction_language", "Desc_534"), new int[1] { 13 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_534")));
		_dataArray.Add(new EventFunctionItem(535, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_535"), LocalStringManager.GetConfig("EventFunction_language", "Desc_535"), new int[3] { 10, 1, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_535_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_535_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_535_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_535")));
		_dataArray.Add(new EventFunctionItem(536, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_536"), LocalStringManager.GetConfig("EventFunction_language", "Desc_536"), new int[1] { 6 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_536")));
		_dataArray.Add(new EventFunctionItem(537, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_537"), LocalStringManager.GetConfig("EventFunction_language", "Desc_537"), new int[1] { 7 }, new string[0], 13, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_537")));
		_dataArray.Add(new EventFunctionItem(538, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_538"), LocalStringManager.GetConfig("EventFunction_language", "Desc_538"), new int[2] { 7, 13 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_538")));
		_dataArray.Add(new EventFunctionItem(539, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_539"), LocalStringManager.GetConfig("EventFunction_language", "Desc_539"), new int[3] { 6, 6, 88 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_539")));
	}

	private void CreateItems9()
	{
		_dataArray.Add(new EventFunctionItem(540, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_540"), LocalStringManager.GetConfig("EventFunction_language", "Desc_540"), new int[2] { 6, 6 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_540_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_540_1")
		}, 83, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_540")));
		_dataArray.Add(new EventFunctionItem(541, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_541"), LocalStringManager.GetConfig("EventFunction_language", "Desc_541"), new int[2] { 6, 6 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_541_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_541_1")
		}, 83, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_541")));
		_dataArray.Add(new EventFunctionItem(542, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_542"), LocalStringManager.GetConfig("EventFunction_language", "Desc_542"), new int[2] { 6, 6 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_542_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_542_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_542")));
		_dataArray.Add(new EventFunctionItem(543, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_543"), LocalStringManager.GetConfig("EventFunction_language", "Desc_543"), new int[2] { 6, 6 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_543_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_543_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_543")));
		_dataArray.Add(new EventFunctionItem(544, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_544"), LocalStringManager.GetConfig("EventFunction_language", "Desc_544"), new int[2] { 7, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_544_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_544_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_544")));
		_dataArray.Add(new EventFunctionItem(545, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_545"), LocalStringManager.GetConfig("EventFunction_language", "Desc_545"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_545_0") }, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_545")));
		_dataArray.Add(new EventFunctionItem(546, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_546"), LocalStringManager.GetConfig("EventFunction_language", "Desc_546"), new int[2] { 82, 4 }, new string[0], 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_546")));
		_dataArray.Add(new EventFunctionItem(547, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_547"), LocalStringManager.GetConfig("EventFunction_language", "Desc_547"), new int[2] { 6, 90 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_547")));
		_dataArray.Add(new EventFunctionItem(548, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_548"), LocalStringManager.GetConfig("EventFunction_language", "Desc_548"), new int[2] { 6, 90 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_548")));
		_dataArray.Add(new EventFunctionItem(549, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_549"), LocalStringManager.GetConfig("EventFunction_language", "Desc_549"), new int[2] { 1, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_549_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_549_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_549")));
		_dataArray.Add(new EventFunctionItem(550, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_550"), LocalStringManager.GetConfig("EventFunction_language", "Desc_550"), new int[1] { 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_550")));
		_dataArray.Add(new EventFunctionItem(551, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_551"), LocalStringManager.GetConfig("EventFunction_language", "Desc_551"), new int[4] { 4, 4, 4, 4 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_551_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_551_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_551_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_551_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_551")));
		_dataArray.Add(new EventFunctionItem(552, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_552"), LocalStringManager.GetConfig("EventFunction_language", "Desc_552"), new int[2] { 1, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_552_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_552_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_552")));
		_dataArray.Add(new EventFunctionItem(553, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_553"), LocalStringManager.GetConfig("EventFunction_language", "Desc_553"), new int[3] { 7, 41, 13 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_553_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_553_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_553_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_553")));
		_dataArray.Add(new EventFunctionItem(554, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_554"), LocalStringManager.GetConfig("EventFunction_language", "Desc_554"), new int[4] { 61, 1, 1, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_554_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_554_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_554_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_554_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_554")));
		_dataArray.Add(new EventFunctionItem(555, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_555"), LocalStringManager.GetConfig("EventFunction_language", "Desc_555"), new int[4] { 6, 28, 41, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_555_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_555_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_555_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_555_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_555")));
		_dataArray.Add(new EventFunctionItem(556, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_556"), LocalStringManager.GetConfig("EventFunction_language", "Desc_556"), new int[5] { 8, 17, 1, 1, 1 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_556_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_556_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_556_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_556_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_556_4")
		}, 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_556")));
		_dataArray.Add(new EventFunctionItem(557, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_557"), LocalStringManager.GetConfig("EventFunction_language", "Desc_557"), new int[3] { 6, 56, 5 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_557_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_557_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_557_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_557")));
		_dataArray.Add(new EventFunctionItem(558, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_558"), LocalStringManager.GetConfig("EventFunction_language", "Desc_558"), new int[2] { 6, 7 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_558")));
		_dataArray.Add(new EventFunctionItem(559, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_559"), LocalStringManager.GetConfig("EventFunction_language", "Desc_559"), new int[1] { 8 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_559_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_559")));
		_dataArray.Add(new EventFunctionItem(560, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_560"), LocalStringManager.GetConfig("EventFunction_language", "Desc_560"), new int[3] { 10, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_560")));
		_dataArray.Add(new EventFunctionItem(561, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_561"), LocalStringManager.GetConfig("EventFunction_language", "Desc_561"), new int[1] { 82 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_561")));
		_dataArray.Add(new EventFunctionItem(562, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_562"), LocalStringManager.GetConfig("EventFunction_language", "Desc_562"), new int[2] { 82, 87 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_562")));
		_dataArray.Add(new EventFunctionItem(563, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_563"), LocalStringManager.GetConfig("EventFunction_language", "Desc_563"), new int[2] { 82, 82 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_563")));
		_dataArray.Add(new EventFunctionItem(564, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_564"), LocalStringManager.GetConfig("EventFunction_language", "Desc_564"), new int[1] { 82 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_564")));
		_dataArray.Add(new EventFunctionItem(565, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_565"), LocalStringManager.GetConfig("EventFunction_language", "Desc_565"), new int[3] { 82, 4, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_565_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_565_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_565_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_565")));
		_dataArray.Add(new EventFunctionItem(566, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_566"), LocalStringManager.GetConfig("EventFunction_language", "Desc_566"), new int[1] { 6 }, new string[0], 17, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_566")));
		_dataArray.Add(new EventFunctionItem(567, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_567"), LocalStringManager.GetConfig("EventFunction_language", "Desc_567"), new int[2] { 6, 35 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_567")));
		_dataArray.Add(new EventFunctionItem(568, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_568"), LocalStringManager.GetConfig("EventFunction_language", "Desc_568"), new int[1] { 91 }, new string[0], 4, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_568")));
		_dataArray.Add(new EventFunctionItem(569, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_569"), LocalStringManager.GetConfig("EventFunction_language", "Desc_569"), new int[3] { 6, 92, 13 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_569")));
		_dataArray.Add(new EventFunctionItem(570, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_570"), LocalStringManager.GetConfig("EventFunction_language", "Desc_570"), new int[1] { 6 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_570")));
		_dataArray.Add(new EventFunctionItem(571, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_571"), LocalStringManager.GetConfig("EventFunction_language", "Desc_571"), new int[2] { 6, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_571")));
		_dataArray.Add(new EventFunctionItem(572, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_572"), LocalStringManager.GetConfig("EventFunction_language", "Desc_572"), new int[2] { 6, 17 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_572")));
		_dataArray.Add(new EventFunctionItem(573, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_573"), LocalStringManager.GetConfig("EventFunction_language", "Desc_573"), new int[1] { 6 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_573")));
		_dataArray.Add(new EventFunctionItem(574, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_574"), LocalStringManager.GetConfig("EventFunction_language", "Desc_574"), new int[2] { 1, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_574_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_574_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_574")));
		_dataArray.Add(new EventFunctionItem(575, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_575"), LocalStringManager.GetConfig("EventFunction_language", "Desc_575"), new int[2] { 87, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_575_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_575_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_575")));
		_dataArray.Add(new EventFunctionItem(576, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_576"), LocalStringManager.GetConfig("EventFunction_language", "Desc_576"), new int[2] { 0, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_576_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_576_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_576")));
		_dataArray.Add(new EventFunctionItem(577, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_577"), LocalStringManager.GetConfig("EventFunction_language", "Desc_577"), new int[2] { 6, 24 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_577")));
		_dataArray.Add(new EventFunctionItem(578, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_578"), LocalStringManager.GetConfig("EventFunction_language", "Desc_578"), new int[3] { 6, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_578")));
		_dataArray.Add(new EventFunctionItem(579, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_579"), LocalStringManager.GetConfig("EventFunction_language", "Desc_579"), new int[2] { 82, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_579_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_579_1")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_579")));
		_dataArray.Add(new EventFunctionItem(580, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_580"), LocalStringManager.GetConfig("EventFunction_language", "Desc_580"), new int[1] { 93 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_580")));
		_dataArray.Add(new EventFunctionItem(581, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_581"), LocalStringManager.GetConfig("EventFunction_language", "Desc_581"), new int[1] { 94 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_581")));
		_dataArray.Add(new EventFunctionItem(582, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_582"), LocalStringManager.GetConfig("EventFunction_language", "Desc_582"), new int[2] { 9, 81 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_582")));
		_dataArray.Add(new EventFunctionItem(583, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_583"), LocalStringManager.GetConfig("EventFunction_language", "Desc_583"), new int[4] { 46, 9, 95, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_583_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_583_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_583_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_583_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_583")));
		_dataArray.Add(new EventFunctionItem(584, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_584"), LocalStringManager.GetConfig("EventFunction_language", "Desc_584"), new int[1] { 9 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_584")));
		_dataArray.Add(new EventFunctionItem(585, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_585"), LocalStringManager.GetConfig("EventFunction_language", "Desc_585"), new int[3] { 96, 97, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_585")));
		_dataArray.Add(new EventFunctionItem(586, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_586"), LocalStringManager.GetConfig("EventFunction_language", "Desc_586"), new int[1] { 38 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_586")));
		_dataArray.Add(new EventFunctionItem(587, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_587"), LocalStringManager.GetConfig("EventFunction_language", "Desc_587"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_587")));
		_dataArray.Add(new EventFunctionItem(588, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_588"), LocalStringManager.GetConfig("EventFunction_language", "Desc_588"), new int[1] { 9 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_588")));
		_dataArray.Add(new EventFunctionItem(589, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_589"), LocalStringManager.GetConfig("EventFunction_language", "Desc_589"), new int[0], new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_589")));
		_dataArray.Add(new EventFunctionItem(590, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_590"), LocalStringManager.GetConfig("EventFunction_language", "Desc_590"), new int[2] { 82, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_590_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_590_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_590")));
		_dataArray.Add(new EventFunctionItem(591, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_591"), LocalStringManager.GetConfig("EventFunction_language", "Desc_591"), new int[2] { 82, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_591_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_591_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_591")));
		_dataArray.Add(new EventFunctionItem(592, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_592"), LocalStringManager.GetConfig("EventFunction_language", "Desc_592"), new int[1] { 82 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_592")));
		_dataArray.Add(new EventFunctionItem(593, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_593"), LocalStringManager.GetConfig("EventFunction_language", "Desc_593"), new int[3] { 6, 4, 99 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_593_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_593_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_593_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_593")));
		_dataArray.Add(new EventFunctionItem(594, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_594"), LocalStringManager.GetConfig("EventFunction_language", "Desc_594"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_594_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_594")));
		_dataArray.Add(new EventFunctionItem(595, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_595"), LocalStringManager.GetConfig("EventFunction_language", "Desc_595"), new int[5] { 6, 98, 4, 4, 4 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_595_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_595_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_595_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_595_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_595_4")
		}, 4, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_595")));
		_dataArray.Add(new EventFunctionItem(596, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_596"), LocalStringManager.GetConfig("EventFunction_language", "Desc_596"), new int[0], new string[0], 8, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_596")));
		_dataArray.Add(new EventFunctionItem(597, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_597"), LocalStringManager.GetConfig("EventFunction_language", "Desc_597"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_597")));
		_dataArray.Add(new EventFunctionItem(598, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_598"), LocalStringManager.GetConfig("EventFunction_language", "Desc_598"), new int[2] { 82, 82 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_598_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_598_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_598")));
		_dataArray.Add(new EventFunctionItem(599, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_599"), LocalStringManager.GetConfig("EventFunction_language", "Desc_599"), new int[2] { 10, 13 }, new string[0], 8, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_599")));
	}

	private void CreateItems10()
	{
		_dataArray.Add(new EventFunctionItem(600, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_600"), LocalStringManager.GetConfig("EventFunction_language", "Desc_600"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_600_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_600")));
		_dataArray.Add(new EventFunctionItem(601, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_601"), LocalStringManager.GetConfig("EventFunction_language", "Desc_601"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_601_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_601")));
		_dataArray.Add(new EventFunctionItem(602, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_602"), LocalStringManager.GetConfig("EventFunction_language", "Desc_602"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_602_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_602")));
		_dataArray.Add(new EventFunctionItem(603, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_603"), LocalStringManager.GetConfig("EventFunction_language", "Desc_603"), new int[1] { 100 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_603")));
		_dataArray.Add(new EventFunctionItem(604, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_604"), LocalStringManager.GetConfig("EventFunction_language", "Desc_604"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_604")));
		_dataArray.Add(new EventFunctionItem(605, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_605"), LocalStringManager.GetConfig("EventFunction_language", "Desc_605"), new int[0], new string[0], 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_605")));
		_dataArray.Add(new EventFunctionItem(606, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_606"), LocalStringManager.GetConfig("EventFunction_language", "Desc_606"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_606_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_606")));
		_dataArray.Add(new EventFunctionItem(607, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_607"), LocalStringManager.GetConfig("EventFunction_language", "Desc_607"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_607")));
		_dataArray.Add(new EventFunctionItem(608, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_608"), LocalStringManager.GetConfig("EventFunction_language", "Desc_608"), new int[0], new string[0], 9, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_608")));
		_dataArray.Add(new EventFunctionItem(609, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_609"), LocalStringManager.GetConfig("EventFunction_language", "Desc_609"), new int[2] { 9, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_609_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_609_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_609")));
		_dataArray.Add(new EventFunctionItem(610, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_610"), LocalStringManager.GetConfig("EventFunction_language", "Desc_610"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_610")));
		_dataArray.Add(new EventFunctionItem(611, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_611"), LocalStringManager.GetConfig("EventFunction_language", "Desc_611"), new int[1] { 101 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_611")));
		_dataArray.Add(new EventFunctionItem(612, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_612"), LocalStringManager.GetConfig("EventFunction_language", "Desc_612"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_612")));
		_dataArray.Add(new EventFunctionItem(613, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_613"), LocalStringManager.GetConfig("EventFunction_language", "Desc_613"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_613_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_613")));
		_dataArray.Add(new EventFunctionItem(614, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_614"), LocalStringManager.GetConfig("EventFunction_language", "Desc_614"), new int[2] { 4, 2 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_614_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_614_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_614")));
		_dataArray.Add(new EventFunctionItem(615, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_615"), LocalStringManager.GetConfig("EventFunction_language", "Desc_615"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_615_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_615")));
		_dataArray.Add(new EventFunctionItem(616, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_616"), LocalStringManager.GetConfig("EventFunction_language", "Desc_616"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_616")));
		_dataArray.Add(new EventFunctionItem(617, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_617"), LocalStringManager.GetConfig("EventFunction_language", "Desc_617"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_617")));
		_dataArray.Add(new EventFunctionItem(618, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_618"), LocalStringManager.GetConfig("EventFunction_language", "Desc_618"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_618")));
		_dataArray.Add(new EventFunctionItem(619, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_619"), LocalStringManager.GetConfig("EventFunction_language", "Desc_619"), new int[3] { 6, 41, 13 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_619_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_619_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_619_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_619")));
		_dataArray.Add(new EventFunctionItem(620, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_620"), LocalStringManager.GetConfig("EventFunction_language", "Desc_620"), new int[1] { 102 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_620")));
		_dataArray.Add(new EventFunctionItem(621, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_621"), LocalStringManager.GetConfig("EventFunction_language", "Desc_621"), new int[3] { 0, 50, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_621_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_621_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_621_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_621")));
		_dataArray.Add(new EventFunctionItem(622, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_622"), LocalStringManager.GetConfig("EventFunction_language", "Desc_622"), new int[2] { 61, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_622_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_622_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_622")));
		_dataArray.Add(new EventFunctionItem(623, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_623"), LocalStringManager.GetConfig("EventFunction_language", "Desc_623"), new int[1] { 87 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_623")));
		_dataArray.Add(new EventFunctionItem(624, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_624"), LocalStringManager.GetConfig("EventFunction_language", "Desc_624"), new int[4] { 87, 4, 73, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_624_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_624_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_624_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_624_3")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_624")));
		_dataArray.Add(new EventFunctionItem(625, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_625"), LocalStringManager.GetConfig("EventFunction_language", "Desc_625"), new int[2] { 6, 8 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_625")));
		_dataArray.Add(new EventFunctionItem(626, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_626"), LocalStringManager.GetConfig("EventFunction_language", "Desc_626"), new int[2] { 7, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_626")));
		_dataArray.Add(new EventFunctionItem(627, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_627"), LocalStringManager.GetConfig("EventFunction_language", "Desc_627"), new int[2] { 0, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_627_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_627_1")
		}, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_627")));
		_dataArray.Add(new EventFunctionItem(628, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_628"), LocalStringManager.GetConfig("EventFunction_language", "Desc_628"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_628")));
		_dataArray.Add(new EventFunctionItem(629, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_629"), LocalStringManager.GetConfig("EventFunction_language", "Desc_629"), new int[2] { 0, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_629")));
		_dataArray.Add(new EventFunctionItem(630, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_630"), LocalStringManager.GetConfig("EventFunction_language", "Desc_630"), new int[0], new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_630")));
		_dataArray.Add(new EventFunctionItem(631, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_631"), LocalStringManager.GetConfig("EventFunction_language", "Desc_631"), new int[5] { 0, 5, 4, 4, 4 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_631_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_631_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_631_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_631_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_631_4")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_631")));
		_dataArray.Add(new EventFunctionItem(632, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_632"), LocalStringManager.GetConfig("EventFunction_language", "Desc_632"), new int[3] { 0, 1, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_632_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_632_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_632")));
		_dataArray.Add(new EventFunctionItem(633, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_633"), LocalStringManager.GetConfig("EventFunction_language", "Desc_633"), new int[2] { 0, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_633_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_633_1")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_633")));
		_dataArray.Add(new EventFunctionItem(634, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_634"), LocalStringManager.GetConfig("EventFunction_language", "Desc_634"), new int[2] { 13, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_634_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_634_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_634")));
		_dataArray.Add(new EventFunctionItem(635, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_635"), LocalStringManager.GetConfig("EventFunction_language", "Desc_635"), new int[2] { 103, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_635_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_635_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_635")));
		_dataArray.Add(new EventFunctionItem(636, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_636"), LocalStringManager.GetConfig("EventFunction_language", "Desc_636"), new int[1] { 104 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_636")));
		_dataArray.Add(new EventFunctionItem(637, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_637"), LocalStringManager.GetConfig("EventFunction_language", "Desc_637"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_637_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_637")));
		_dataArray.Add(new EventFunctionItem(638, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_638"), LocalStringManager.GetConfig("EventFunction_language", "Desc_638"), new int[2] { 6, 105 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_638")));
		_dataArray.Add(new EventFunctionItem(639, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_639"), LocalStringManager.GetConfig("EventFunction_language", "Desc_639"), new int[1] { 87 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_639")));
		_dataArray.Add(new EventFunctionItem(640, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_640"), LocalStringManager.GetConfig("EventFunction_language", "Desc_640"), new int[2] { 106, 5 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_640")));
		_dataArray.Add(new EventFunctionItem(641, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_641"), LocalStringManager.GetConfig("EventFunction_language", "Desc_641"), new int[3] { 10, 55, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_641_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_641_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_641_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_641")));
		_dataArray.Add(new EventFunctionItem(642, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_642"), LocalStringManager.GetConfig("EventFunction_language", "Desc_642"), new int[2] { 6, 35 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_642")));
		_dataArray.Add(new EventFunctionItem(643, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_643"), LocalStringManager.GetConfig("EventFunction_language", "Desc_643"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_643")));
		_dataArray.Add(new EventFunctionItem(644, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_644"), LocalStringManager.GetConfig("EventFunction_language", "Desc_644"), new int[7] { 82, 1, 1, 61, 41, 1, 3 }, new string[7]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_644_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_644_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_644_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_644_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_644_4"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_644_5"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_644_6")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_644")));
		_dataArray.Add(new EventFunctionItem(645, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_645"), LocalStringManager.GetConfig("EventFunction_language", "Desc_645"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_645")));
		_dataArray.Add(new EventFunctionItem(646, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_646"), LocalStringManager.GetConfig("EventFunction_language", "Desc_646"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_646_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_646")));
		_dataArray.Add(new EventFunctionItem(647, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_647"), LocalStringManager.GetConfig("EventFunction_language", "Desc_647"), new int[3] { 12, 1, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_647_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_647_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_647_2")
		}, 9, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_647")));
		_dataArray.Add(new EventFunctionItem(648, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_648"), LocalStringManager.GetConfig("EventFunction_language", "Desc_648"), new int[1] { 9 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_648")));
		_dataArray.Add(new EventFunctionItem(649, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_649"), LocalStringManager.GetConfig("EventFunction_language", "Desc_649"), new int[3] { 9, 21, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_649")));
		_dataArray.Add(new EventFunctionItem(650, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_650"), LocalStringManager.GetConfig("EventFunction_language", "Desc_650"), new int[2] { 9, 21 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_650")));
		_dataArray.Add(new EventFunctionItem(651, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_651"), LocalStringManager.GetConfig("EventFunction_language", "Desc_651"), new int[2] { 21, 8 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_651")));
		_dataArray.Add(new EventFunctionItem(652, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_652"), LocalStringManager.GetConfig("EventFunction_language", "Desc_652"), new int[2] { 21, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_652")));
		_dataArray.Add(new EventFunctionItem(653, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_653"), LocalStringManager.GetConfig("EventFunction_language", "Desc_653"), new int[1] { 107 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_653")));
		_dataArray.Add(new EventFunctionItem(654, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_654"), LocalStringManager.GetConfig("EventFunction_language", "Desc_654"), new int[2] { 108, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_654_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_654_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_654")));
		_dataArray.Add(new EventFunctionItem(655, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_655"), LocalStringManager.GetConfig("EventFunction_language", "Desc_655"), new int[2] { 0, 107 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_655")));
		_dataArray.Add(new EventFunctionItem(656, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_656"), LocalStringManager.GetConfig("EventFunction_language", "Desc_656"), new int[0], new string[0], 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_656")));
		_dataArray.Add(new EventFunctionItem(657, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_657"), LocalStringManager.GetConfig("EventFunction_language", "Desc_657"), new int[2] { 0, 87 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_657")));
		_dataArray.Add(new EventFunctionItem(658, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_658"), LocalStringManager.GetConfig("EventFunction_language", "Desc_658"), new int[2] { 0, 109 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_658_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_658_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_658")));
		_dataArray.Add(new EventFunctionItem(659, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_659"), LocalStringManager.GetConfig("EventFunction_language", "Desc_659"), new int[1] { 110 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_659")));
	}

	private void CreateItems11()
	{
		_dataArray.Add(new EventFunctionItem(660, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_660"), LocalStringManager.GetConfig("EventFunction_language", "Desc_660"), new int[3] { 6, 6, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_660_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_660_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_660_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_660")));
		_dataArray.Add(new EventFunctionItem(661, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_661"), LocalStringManager.GetConfig("EventFunction_language", "Desc_661"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_661")));
		_dataArray.Add(new EventFunctionItem(662, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_662"), LocalStringManager.GetConfig("EventFunction_language", "Desc_662"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_662")));
		_dataArray.Add(new EventFunctionItem(663, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_663"), LocalStringManager.GetConfig("EventFunction_language", "Desc_663"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_663")));
		_dataArray.Add(new EventFunctionItem(664, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_664"), LocalStringManager.GetConfig("EventFunction_language", "Desc_664"), new int[7] { 1, 1, 1, 61, 41, 1, 3 }, new string[7]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_664_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_664_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_664_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_664_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_664_4"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_664_5"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_664_6")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_664")));
		_dataArray.Add(new EventFunctionItem(665, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_665"), LocalStringManager.GetConfig("EventFunction_language", "Desc_665"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_665")));
		_dataArray.Add(new EventFunctionItem(666, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_666"), LocalStringManager.GetConfig("EventFunction_language", "Desc_666"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_666_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_666")));
		_dataArray.Add(new EventFunctionItem(667, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_667"), LocalStringManager.GetConfig("EventFunction_language", "Desc_667"), new int[0], new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_667")));
		_dataArray.Add(new EventFunctionItem(668, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_668"), LocalStringManager.GetConfig("EventFunction_language", "Desc_668"), new int[1] { 111 }, new string[0], 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_668")));
		_dataArray.Add(new EventFunctionItem(669, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_669"), LocalStringManager.GetConfig("EventFunction_language", "Desc_669"), new int[4] { 3, 4, 73, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_669_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_669_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_669_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_669_3")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_669")));
		_dataArray.Add(new EventFunctionItem(670, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_670"), LocalStringManager.GetConfig("EventFunction_language", "Desc_670"), new int[5] { 82, 4, 4, 73, 3 }, new string[5]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_670_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_670_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_670_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_670_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_670_4")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_670")));
		_dataArray.Add(new EventFunctionItem(671, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_671"), LocalStringManager.GetConfig("EventFunction_language", "Desc_671"), new int[1] { 61 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_671")));
		_dataArray.Add(new EventFunctionItem(672, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_672"), LocalStringManager.GetConfig("EventFunction_language", "Desc_672"), new int[3] { 4, 73, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_672_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_672_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_672_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_672")));
		_dataArray.Add(new EventFunctionItem(673, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_673"), LocalStringManager.GetConfig("EventFunction_language", "Desc_673"), new int[7] { 1, 61, 1, 3, 4, 3, 73 }, new string[7]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_673_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_673_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_673_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_673_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_673_4"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_673_5"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_673_6")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_673")));
		_dataArray.Add(new EventFunctionItem(674, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_674"), LocalStringManager.GetConfig("EventFunction_language", "Desc_674"), new int[1] { 11 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_674")));
		_dataArray.Add(new EventFunctionItem(675, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_675"), LocalStringManager.GetConfig("EventFunction_language", "Desc_675"), new int[0], new string[0], 85, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_675")));
		_dataArray.Add(new EventFunctionItem(676, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_676"), LocalStringManager.GetConfig("EventFunction_language", "Desc_676"), new int[2] { 85, 85 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_676")));
		_dataArray.Add(new EventFunctionItem(677, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_677"), LocalStringManager.GetConfig("EventFunction_language", "Desc_677"), new int[2] { 6, 8 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_677")));
		_dataArray.Add(new EventFunctionItem(678, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_678"), LocalStringManager.GetConfig("EventFunction_language", "Desc_678"), new int[1] { 11 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_678")));
		_dataArray.Add(new EventFunctionItem(679, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_679"), LocalStringManager.GetConfig("EventFunction_language", "Desc_679"), new int[2] { 6, 21 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_679_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_679_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_679_2")
		}, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_679")));
		_dataArray.Add(new EventFunctionItem(680, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_680"), LocalStringManager.GetConfig("EventFunction_language", "Desc_680"), new int[2] { 101, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_680_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_680_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_680")));
		_dataArray.Add(new EventFunctionItem(681, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_681"), LocalStringManager.GetConfig("EventFunction_language", "Desc_681"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_681_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_681")));
		_dataArray.Add(new EventFunctionItem(682, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_682"), LocalStringManager.GetConfig("EventFunction_language", "Desc_682"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_682_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_682")));
		_dataArray.Add(new EventFunctionItem(683, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_683"), LocalStringManager.GetConfig("EventFunction_language", "Desc_683"), new int[3] { 6, 41, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_683_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_683_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_683_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_683")));
		_dataArray.Add(new EventFunctionItem(684, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_684"), LocalStringManager.GetConfig("EventFunction_language", "Desc_684"), new int[2] { 6, 19 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_684")));
		_dataArray.Add(new EventFunctionItem(685, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_685"), LocalStringManager.GetConfig("EventFunction_language", "Desc_685"), new int[2] { 45, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_685_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_685_1")
		}, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_685")));
		_dataArray.Add(new EventFunctionItem(686, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_686"), LocalStringManager.GetConfig("EventFunction_language", "Desc_686"), new int[2] { 87, 109 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_686_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_686_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_686")));
		_dataArray.Add(new EventFunctionItem(687, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_687"), LocalStringManager.GetConfig("EventFunction_language", "Desc_687"), new int[1] { 5 }, new string[6]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_687_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_687_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_687_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_687_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_687_4"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_687_5")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_687")));
		_dataArray.Add(new EventFunctionItem(688, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_688"), LocalStringManager.GetConfig("EventFunction_language", "Desc_688"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_688")));
		_dataArray.Add(new EventFunctionItem(689, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_689"), LocalStringManager.GetConfig("EventFunction_language", "Desc_689"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_689")));
		_dataArray.Add(new EventFunctionItem(690, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_690"), LocalStringManager.GetConfig("EventFunction_language", "Desc_690"), new int[1], new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_690_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_690")));
		_dataArray.Add(new EventFunctionItem(691, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_691"), LocalStringManager.GetConfig("EventFunction_language", "Desc_691"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_691")));
		_dataArray.Add(new EventFunctionItem(692, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_692"), LocalStringManager.GetConfig("EventFunction_language", "Desc_692"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_692")));
		_dataArray.Add(new EventFunctionItem(693, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_693"), LocalStringManager.GetConfig("EventFunction_language", "Desc_693"), new int[1] { 5 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_693_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_693")));
		_dataArray.Add(new EventFunctionItem(694, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_694"), LocalStringManager.GetConfig("EventFunction_language", "Desc_694"), new int[2] { 82, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_694_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_694_1")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_694")));
		_dataArray.Add(new EventFunctionItem(695, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_695"), LocalStringManager.GetConfig("EventFunction_language", "Desc_695"), new int[2] { 82, 82 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_695")));
		_dataArray.Add(new EventFunctionItem(696, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_696"), LocalStringManager.GetConfig("EventFunction_language", "Desc_696"), new int[1] { 4 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_696")));
		_dataArray.Add(new EventFunctionItem(697, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_697"), LocalStringManager.GetConfig("EventFunction_language", "Desc_697"), new int[2] { 82, 4 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_697")));
		_dataArray.Add(new EventFunctionItem(698, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_698"), LocalStringManager.GetConfig("EventFunction_language", "Desc_698"), new int[2] { 12, 58 }, new string[0], 9, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_698")));
		_dataArray.Add(new EventFunctionItem(699, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_699"), LocalStringManager.GetConfig("EventFunction_language", "Desc_699"), new int[3] { 6, 76, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_699_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_699_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_699_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_699")));
		_dataArray.Add(new EventFunctionItem(700, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_700"), LocalStringManager.GetConfig("EventFunction_language", "Desc_700"), new int[4] { 87, 1, 4, 5 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_700_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_700_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_700_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_700_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_700")));
		_dataArray.Add(new EventFunctionItem(701, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_701"), LocalStringManager.GetConfig("EventFunction_language", "Desc_701"), new int[1] { 114 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_701")));
		_dataArray.Add(new EventFunctionItem(702, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_702"), LocalStringManager.GetConfig("EventFunction_language", "Desc_702"), new int[2] { 6, 7 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_702")));
		_dataArray.Add(new EventFunctionItem(703, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_703"), LocalStringManager.GetConfig("EventFunction_language", "Desc_703"), new int[1] { 21 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_703")));
		_dataArray.Add(new EventFunctionItem(704, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_704"), LocalStringManager.GetConfig("EventFunction_language", "Desc_704"), new int[1] { 21 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_704")));
		_dataArray.Add(new EventFunctionItem(705, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_705"), LocalStringManager.GetConfig("EventFunction_language", "Desc_705"), new int[2] { 1, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_705_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_705_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_705")));
		_dataArray.Add(new EventFunctionItem(706, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_706"), LocalStringManager.GetConfig("EventFunction_language", "Desc_706"), new int[1] { 9 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_706")));
		_dataArray.Add(new EventFunctionItem(707, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_707"), LocalStringManager.GetConfig("EventFunction_language", "Desc_707"), new int[4] { 1, 1, 1, 1 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_707_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_707_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_707_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_707_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_707")));
		_dataArray.Add(new EventFunctionItem(708, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_708"), LocalStringManager.GetConfig("EventFunction_language", "Desc_708"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_708")));
		_dataArray.Add(new EventFunctionItem(709, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_709"), LocalStringManager.GetConfig("EventFunction_language", "Desc_709"), new int[1] { 5 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_709")));
		_dataArray.Add(new EventFunctionItem(710, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_710"), LocalStringManager.GetConfig("EventFunction_language", "Desc_710"), new int[2] { 115, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_710_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_710_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_710")));
		_dataArray.Add(new EventFunctionItem(711, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_711"), LocalStringManager.GetConfig("EventFunction_language", "Desc_711"), new int[2] { 116, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_711_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_711_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_711")));
		_dataArray.Add(new EventFunctionItem(712, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_712"), LocalStringManager.GetConfig("EventFunction_language", "Desc_712"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_712")));
		_dataArray.Add(new EventFunctionItem(713, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_713"), LocalStringManager.GetConfig("EventFunction_language", "Desc_713"), new int[0], new string[0], 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_713")));
		_dataArray.Add(new EventFunctionItem(714, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_714"), LocalStringManager.GetConfig("EventFunction_language", "Desc_714"), new int[1] { 5 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_714_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_714")));
		_dataArray.Add(new EventFunctionItem(715, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_715"), LocalStringManager.GetConfig("EventFunction_language", "Desc_715"), new int[2] { 6, 6 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_715_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_715_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_715")));
		_dataArray.Add(new EventFunctionItem(716, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_716"), LocalStringManager.GetConfig("EventFunction_language", "Desc_716"), new int[2] { 6, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_716_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_716_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_716")));
		_dataArray.Add(new EventFunctionItem(717, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_717"), LocalStringManager.GetConfig("EventFunction_language", "Desc_717"), new int[1] { 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_717")));
		_dataArray.Add(new EventFunctionItem(718, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_718"), LocalStringManager.GetConfig("EventFunction_language", "Desc_718"), new int[1] { 81 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_718")));
		_dataArray.Add(new EventFunctionItem(719, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_719"), LocalStringManager.GetConfig("EventFunction_language", "Desc_719"), new int[2] { 1, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_719_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_719_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_719")));
	}

	private void CreateItems12()
	{
		_dataArray.Add(new EventFunctionItem(720, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_720"), LocalStringManager.GetConfig("EventFunction_language", "Desc_720"), new int[2] { 93, 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_720")));
		_dataArray.Add(new EventFunctionItem(721, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_721"), LocalStringManager.GetConfig("EventFunction_language", "Desc_721"), new int[2] { 9, 105 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_721")));
		_dataArray.Add(new EventFunctionItem(722, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_722"), LocalStringManager.GetConfig("EventFunction_language", "Desc_722"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_722")));
		_dataArray.Add(new EventFunctionItem(723, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_723"), LocalStringManager.GetConfig("EventFunction_language", "Desc_723"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_723_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_723")));
		_dataArray.Add(new EventFunctionItem(724, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_724"), LocalStringManager.GetConfig("EventFunction_language", "Desc_724"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_724")));
		_dataArray.Add(new EventFunctionItem(725, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_725"), LocalStringManager.GetConfig("EventFunction_language", "Desc_725"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_725")));
		_dataArray.Add(new EventFunctionItem(726, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_726"), LocalStringManager.GetConfig("EventFunction_language", "Desc_726"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_726_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_726")));
		_dataArray.Add(new EventFunctionItem(727, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_727"), LocalStringManager.GetConfig("EventFunction_language", "Desc_727"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_727")));
		_dataArray.Add(new EventFunctionItem(728, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_728"), LocalStringManager.GetConfig("EventFunction_language", "Desc_728"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_728")));
		_dataArray.Add(new EventFunctionItem(729, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_729"), LocalStringManager.GetConfig("EventFunction_language", "Desc_729"), new int[3] { 6, 3, 5 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_729_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_729_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_729_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_729")));
		_dataArray.Add(new EventFunctionItem(730, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_730"), LocalStringManager.GetConfig("EventFunction_language", "Desc_730"), new int[1] { 6 }, new string[0], 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_730")));
		_dataArray.Add(new EventFunctionItem(731, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_731"), LocalStringManager.GetConfig("EventFunction_language", "Desc_731"), new int[2] { 7, 117 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_731")));
		_dataArray.Add(new EventFunctionItem(732, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_732"), LocalStringManager.GetConfig("EventFunction_language", "Desc_732"), new int[2] { 7, 20 }, new string[0], 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_732")));
		_dataArray.Add(new EventFunctionItem(733, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_733"), LocalStringManager.GetConfig("EventFunction_language", "Desc_733"), new int[2] { 7, 34 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_733")));
		_dataArray.Add(new EventFunctionItem(734, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_734"), LocalStringManager.GetConfig("EventFunction_language", "Desc_734"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_734_0") }, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_734")));
		_dataArray.Add(new EventFunctionItem(735, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_735"), LocalStringManager.GetConfig("EventFunction_language", "Desc_735"), new int[0], new string[0], 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_735")));
		_dataArray.Add(new EventFunctionItem(736, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_736"), LocalStringManager.GetConfig("EventFunction_language", "Desc_736"), new int[1] { 24 }, new string[0], 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_736")));
		_dataArray.Add(new EventFunctionItem(737, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_737"), LocalStringManager.GetConfig("EventFunction_language", "Desc_737"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_737_0") }, 8, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_737")));
		_dataArray.Add(new EventFunctionItem(738, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_738"), LocalStringManager.GetConfig("EventFunction_language", "Desc_738"), new int[2] { 3, 91 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_738_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_738_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_738")));
		_dataArray.Add(new EventFunctionItem(739, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_739"), LocalStringManager.GetConfig("EventFunction_language", "Desc_739"), new int[3] { 6, 1, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_739_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_739_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_739_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_739")));
		_dataArray.Add(new EventFunctionItem(740, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_740"), LocalStringManager.GetConfig("EventFunction_language", "Desc_740"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_740")));
		_dataArray.Add(new EventFunctionItem(741, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_741"), LocalStringManager.GetConfig("EventFunction_language", "Desc_741"), new int[2] { 118, 119 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_741")));
		_dataArray.Add(new EventFunctionItem(742, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_742"), LocalStringManager.GetConfig("EventFunction_language", "Desc_742"), new int[2] { 1, 2 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_742_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_742_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_742")));
		_dataArray.Add(new EventFunctionItem(743, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_743"), LocalStringManager.GetConfig("EventFunction_language", "Desc_743"), new int[3] { 4, 1, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_743_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_743_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_743_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_743")));
		_dataArray.Add(new EventFunctionItem(744, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_744"), LocalStringManager.GetConfig("EventFunction_language", "Desc_744"), new int[2] { 7, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_744")));
		_dataArray.Add(new EventFunctionItem(745, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_745"), LocalStringManager.GetConfig("EventFunction_language", "Desc_745"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_745")));
		_dataArray.Add(new EventFunctionItem(746, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_746"), LocalStringManager.GetConfig("EventFunction_language", "Desc_746"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_746")));
		_dataArray.Add(new EventFunctionItem(747, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_747"), LocalStringManager.GetConfig("EventFunction_language", "Desc_747"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_747")));
		_dataArray.Add(new EventFunctionItem(748, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_748"), LocalStringManager.GetConfig("EventFunction_language", "Desc_748"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_748")));
		_dataArray.Add(new EventFunctionItem(749, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_749"), LocalStringManager.GetConfig("EventFunction_language", "Desc_749"), new int[2] { 9, 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_749_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_749")));
		_dataArray.Add(new EventFunctionItem(750, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_750"), LocalStringManager.GetConfig("EventFunction_language", "Desc_750"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_750")));
		_dataArray.Add(new EventFunctionItem(751, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_751"), LocalStringManager.GetConfig("EventFunction_language", "Desc_751"), new int[2] { 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_751")));
		_dataArray.Add(new EventFunctionItem(752, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_752"), LocalStringManager.GetConfig("EventFunction_language", "Desc_752"), new int[1] { 11 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_752")));
		_dataArray.Add(new EventFunctionItem(753, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_753"), LocalStringManager.GetConfig("EventFunction_language", "Desc_753"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_753")));
		_dataArray.Add(new EventFunctionItem(754, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_754"), LocalStringManager.GetConfig("EventFunction_language", "Desc_754"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_754")));
		_dataArray.Add(new EventFunctionItem(755, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_755"), LocalStringManager.GetConfig("EventFunction_language", "Desc_755"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_755_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_755")));
		_dataArray.Add(new EventFunctionItem(756, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_756"), LocalStringManager.GetConfig("EventFunction_language", "Desc_756"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_756")));
		_dataArray.Add(new EventFunctionItem(757, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_757"), LocalStringManager.GetConfig("EventFunction_language", "Desc_757"), new int[2] { 6, 118 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_757")));
		_dataArray.Add(new EventFunctionItem(758, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_758"), LocalStringManager.GetConfig("EventFunction_language", "Desc_758"), new int[1] { 6 }, new string[0], 118, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_758")));
		_dataArray.Add(new EventFunctionItem(759, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_759"), LocalStringManager.GetConfig("EventFunction_language", "Desc_759"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_759")));
		_dataArray.Add(new EventFunctionItem(760, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_760"), LocalStringManager.GetConfig("EventFunction_language", "Desc_760"), new int[2] { 118, 120 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_760")));
		_dataArray.Add(new EventFunctionItem(761, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_761"), LocalStringManager.GetConfig("EventFunction_language", "Desc_761"), new int[1] { 9 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_761")));
		_dataArray.Add(new EventFunctionItem(762, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_762"), LocalStringManager.GetConfig("EventFunction_language", "Desc_762"), new int[2] { 121, 118 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_762")));
		_dataArray.Add(new EventFunctionItem(763, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_763"), LocalStringManager.GetConfig("EventFunction_language", "Desc_763"), new int[3] { 122, 60, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_763_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_763_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_763_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_763")));
		_dataArray.Add(new EventFunctionItem(764, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_764"), LocalStringManager.GetConfig("EventFunction_language", "Desc_764"), new int[2] { 122, 60 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_764")));
		_dataArray.Add(new EventFunctionItem(765, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_765"), LocalStringManager.GetConfig("EventFunction_language", "Desc_765"), new int[1] { 12 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_765")));
		_dataArray.Add(new EventFunctionItem(766, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_766"), LocalStringManager.GetConfig("EventFunction_language", "Desc_766"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_766")));
		_dataArray.Add(new EventFunctionItem(767, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_767"), LocalStringManager.GetConfig("EventFunction_language", "Desc_767"), new int[3] { 1, 1, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_767_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_767_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_767_2")
		}, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_767")));
		_dataArray.Add(new EventFunctionItem(768, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_768"), LocalStringManager.GetConfig("EventFunction_language", "Desc_768"), new int[3] { 10, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_768")));
		_dataArray.Add(new EventFunctionItem(769, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_769"), LocalStringManager.GetConfig("EventFunction_language", "Desc_769"), new int[2] { 9, 58 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_769")));
		_dataArray.Add(new EventFunctionItem(770, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_770"), LocalStringManager.GetConfig("EventFunction_language", "Desc_770"), new int[1] { 5 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_770")));
		_dataArray.Add(new EventFunctionItem(771, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_771"), LocalStringManager.GetConfig("EventFunction_language", "Desc_771"), new int[1] { 5 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_771")));
		_dataArray.Add(new EventFunctionItem(772, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_772"), LocalStringManager.GetConfig("EventFunction_language", "Desc_772"), new int[1] { 5 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_772")));
		_dataArray.Add(new EventFunctionItem(773, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_773"), LocalStringManager.GetConfig("EventFunction_language", "Desc_773"), new int[1] { 5 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_773")));
		_dataArray.Add(new EventFunctionItem(774, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_774"), LocalStringManager.GetConfig("EventFunction_language", "Desc_774"), new int[2] { 61, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_774_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_774_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_774")));
		_dataArray.Add(new EventFunctionItem(775, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_775"), LocalStringManager.GetConfig("EventFunction_language", "Desc_775"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_775_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_775")));
		_dataArray.Add(new EventFunctionItem(776, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_776"), LocalStringManager.GetConfig("EventFunction_language", "Desc_776"), new int[2] { 2, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_776_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_776_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_776")));
		_dataArray.Add(new EventFunctionItem(777, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_777"), LocalStringManager.GetConfig("EventFunction_language", "Desc_777"), new int[4] { 82, 1, 1, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_777_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_777_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_777_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_777_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_777")));
		_dataArray.Add(new EventFunctionItem(778, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_778"), LocalStringManager.GetConfig("EventFunction_language", "Desc_778"), new int[5] { 6, 6, 42, 5, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_778_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_778_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_778_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_778_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_778")));
		_dataArray.Add(new EventFunctionItem(779, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_779"), LocalStringManager.GetConfig("EventFunction_language", "Desc_779"), new int[2] { 6, 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_779")));
	}

	private void CreateItems13()
	{
		_dataArray.Add(new EventFunctionItem(780, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_780"), LocalStringManager.GetConfig("EventFunction_language", "Desc_780"), new int[2] { 71, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_780_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_780_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_780")));
		_dataArray.Add(new EventFunctionItem(781, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_781"), LocalStringManager.GetConfig("EventFunction_language", "Desc_781"), new int[3] { 6, 26, 7 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_781")));
		_dataArray.Add(new EventFunctionItem(782, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_782"), LocalStringManager.GetConfig("EventFunction_language", "Desc_782"), new int[2] { 6, 28 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_782")));
		_dataArray.Add(new EventFunctionItem(783, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_783"), LocalStringManager.GetConfig("EventFunction_language", "Desc_783"), new int[3] { 1, 1, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_783_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_783_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_783_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_783")));
		_dataArray.Add(new EventFunctionItem(784, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_784"), LocalStringManager.GetConfig("EventFunction_language", "Desc_784"), new int[2] { 108, 55 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_784")));
		_dataArray.Add(new EventFunctionItem(785, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_785"), LocalStringManager.GetConfig("EventFunction_language", "Desc_785"), new int[1] { 11 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_785")));
		_dataArray.Add(new EventFunctionItem(786, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_786"), LocalStringManager.GetConfig("EventFunction_language", "Desc_786"), new int[1] { 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_786")));
		_dataArray.Add(new EventFunctionItem(787, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_787"), LocalStringManager.GetConfig("EventFunction_language", "Desc_787"), new int[2] { 12, 71 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_787")));
		_dataArray.Add(new EventFunctionItem(788, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_788"), LocalStringManager.GetConfig("EventFunction_language", "Desc_788"), new int[1] { 118 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_788_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_788")));
		_dataArray.Add(new EventFunctionItem(789, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_789"), LocalStringManager.GetConfig("EventFunction_language", "Desc_789"), new int[3] { 6, 24, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_789_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_789_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_789_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_789")));
		_dataArray.Add(new EventFunctionItem(790, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_790"), LocalStringManager.GetConfig("EventFunction_language", "Desc_790"), new int[3] { 6, 25, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_790_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_790_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_790_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_790")));
		_dataArray.Add(new EventFunctionItem(791, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_791"), LocalStringManager.GetConfig("EventFunction_language", "Desc_791"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_791")));
		_dataArray.Add(new EventFunctionItem(792, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_792"), LocalStringManager.GetConfig("EventFunction_language", "Desc_792"), new int[4] { 27, 1, 1, 4 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_792_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_792_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_792_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_792_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_792")));
		_dataArray.Add(new EventFunctionItem(793, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_793"), LocalStringManager.GetConfig("EventFunction_language", "Desc_793"), new int[2] { 12, 123 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_793")));
		_dataArray.Add(new EventFunctionItem(794, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_794"), LocalStringManager.GetConfig("EventFunction_language", "Desc_794"), new int[3] { 6, 124, 1 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_794_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_794_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_794_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_794")));
		_dataArray.Add(new EventFunctionItem(795, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_795"), LocalStringManager.GetConfig("EventFunction_language", "Desc_795"), new int[4] { 6, 41, 1, 4 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_795_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_795_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_795_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_795_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_795")));
		_dataArray.Add(new EventFunctionItem(796, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_796"), LocalStringManager.GetConfig("EventFunction_language", "Desc_796"), new int[2] { 6, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_796_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_796_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_796")));
		_dataArray.Add(new EventFunctionItem(797, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_797"), LocalStringManager.GetConfig("EventFunction_language", "Desc_797"), new int[6] { 6, 3, 3, 13, 13, 5 }, new string[6]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_797_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_797_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_797_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_797_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_797_4"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_797_5")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_797")));
		_dataArray.Add(new EventFunctionItem(798, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_798"), LocalStringManager.GetConfig("EventFunction_language", "Desc_798"), new int[2] { 6, 6 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_798_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_798_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_798")));
		_dataArray.Add(new EventFunctionItem(799, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_799"), LocalStringManager.GetConfig("EventFunction_language", "Desc_799"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_799")));
		_dataArray.Add(new EventFunctionItem(800, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_800"), LocalStringManager.GetConfig("EventFunction_language", "Desc_800"), new int[1] { 7 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_800")));
		_dataArray.Add(new EventFunctionItem(801, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_801"), LocalStringManager.GetConfig("EventFunction_language", "Desc_801"), new int[2] { 7, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_801_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_801_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_801")));
		_dataArray.Add(new EventFunctionItem(802, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_802"), LocalStringManager.GetConfig("EventFunction_language", "Desc_802"), new int[1] { 7 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_802")));
		_dataArray.Add(new EventFunctionItem(803, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_803"), LocalStringManager.GetConfig("EventFunction_language", "Desc_803"), new int[3] { 7, 41, 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_803")));
		_dataArray.Add(new EventFunctionItem(804, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_804"), LocalStringManager.GetConfig("EventFunction_language", "Desc_804"), new int[4] { 6, 3, 41, 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_804_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_804")));
		_dataArray.Add(new EventFunctionItem(805, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_805"), LocalStringManager.GetConfig("EventFunction_language", "Desc_805"), new int[1] { 7 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_805")));
		_dataArray.Add(new EventFunctionItem(806, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_806"), LocalStringManager.GetConfig("EventFunction_language", "Desc_806"), new int[2] { 7, 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_806_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_806")));
		_dataArray.Add(new EventFunctionItem(807, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_807"), LocalStringManager.GetConfig("EventFunction_language", "Desc_807"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_807")));
		_dataArray.Add(new EventFunctionItem(808, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_808"), LocalStringManager.GetConfig("EventFunction_language", "Desc_808"), new int[1] { 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_808")));
		_dataArray.Add(new EventFunctionItem(809, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_809"), LocalStringManager.GetConfig("EventFunction_language", "Desc_809"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_809_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_809_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_809")));
		_dataArray.Add(new EventFunctionItem(810, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_810"), LocalStringManager.GetConfig("EventFunction_language", "Desc_810"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_810")));
		_dataArray.Add(new EventFunctionItem(811, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_811"), LocalStringManager.GetConfig("EventFunction_language", "Desc_811"), new int[3] { 3, 5, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_811_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_811_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_811_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_811")));
		_dataArray.Add(new EventFunctionItem(812, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_812"), LocalStringManager.GetConfig("EventFunction_language", "Desc_812"), new int[3] { 5, 3, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_812_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_812_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_812_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_812")));
		_dataArray.Add(new EventFunctionItem(813, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_813"), LocalStringManager.GetConfig("EventFunction_language", "Desc_813"), new int[1] { 5 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_813")));
		_dataArray.Add(new EventFunctionItem(814, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_814"), LocalStringManager.GetConfig("EventFunction_language", "Desc_814"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_814_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_814")));
		_dataArray.Add(new EventFunctionItem(815, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_815"), LocalStringManager.GetConfig("EventFunction_language", "Desc_815"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_815_0") }, 125, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_815")));
		_dataArray.Add(new EventFunctionItem(816, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_816"), LocalStringManager.GetConfig("EventFunction_language", "Desc_816"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_816_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_816")));
		_dataArray.Add(new EventFunctionItem(817, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_817"), LocalStringManager.GetConfig("EventFunction_language", "Desc_817"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_817_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_817")));
		_dataArray.Add(new EventFunctionItem(818, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_818"), LocalStringManager.GetConfig("EventFunction_language", "Desc_818"), new int[4] { 6, 41, 125, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_818_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_818_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_818_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_818_3")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_818")));
		_dataArray.Add(new EventFunctionItem(819, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_819"), LocalStringManager.GetConfig("EventFunction_language", "Desc_819"), new int[1] { 3 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_819")));
		_dataArray.Add(new EventFunctionItem(820, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_820"), LocalStringManager.GetConfig("EventFunction_language", "Desc_820"), new int[1] { 5 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_820")));
		_dataArray.Add(new EventFunctionItem(821, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_821"), LocalStringManager.GetConfig("EventFunction_language", "Desc_821"), new int[2] { 3, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_821_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_821_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_821")));
		_dataArray.Add(new EventFunctionItem(822, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_822"), LocalStringManager.GetConfig("EventFunction_language", "Desc_822"), new int[2] { 9, 81 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_822")));
		_dataArray.Add(new EventFunctionItem(823, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_823"), LocalStringManager.GetConfig("EventFunction_language", "Desc_823"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_823_0") }, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_823")));
		_dataArray.Add(new EventFunctionItem(824, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_824"), LocalStringManager.GetConfig("EventFunction_language", "Desc_824"), new int[3] { 7, 6, 5 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_824_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_824_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_824_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_824")));
		_dataArray.Add(new EventFunctionItem(825, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_825"), LocalStringManager.GetConfig("EventFunction_language", "Desc_825"), new int[0], new string[0], 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_825")));
		_dataArray.Add(new EventFunctionItem(826, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_826"), LocalStringManager.GetConfig("EventFunction_language", "Desc_826"), new int[2] { 6, 3 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_826")));
		_dataArray.Add(new EventFunctionItem(827, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_827"), LocalStringManager.GetConfig("EventFunction_language", "Desc_827"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_827")));
		_dataArray.Add(new EventFunctionItem(828, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_828"), LocalStringManager.GetConfig("EventFunction_language", "Desc_828"), new int[1] { 3 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_828")));
		_dataArray.Add(new EventFunctionItem(829, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_829"), LocalStringManager.GetConfig("EventFunction_language", "Desc_829"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_829_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_829")));
		_dataArray.Add(new EventFunctionItem(830, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_830"), LocalStringManager.GetConfig("EventFunction_language", "Desc_830"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_830")));
		_dataArray.Add(new EventFunctionItem(831, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_831"), LocalStringManager.GetConfig("EventFunction_language", "Desc_831"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_831")));
		_dataArray.Add(new EventFunctionItem(832, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_832"), LocalStringManager.GetConfig("EventFunction_language", "Desc_832"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_832")));
		_dataArray.Add(new EventFunctionItem(833, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_833"), LocalStringManager.GetConfig("EventFunction_language", "Desc_833"), new int[1] { 1 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_833")));
		_dataArray.Add(new EventFunctionItem(834, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_834"), LocalStringManager.GetConfig("EventFunction_language", "Desc_834"), new int[3] { 6, 90, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_834")));
		_dataArray.Add(new EventFunctionItem(835, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_835"), LocalStringManager.GetConfig("EventFunction_language", "Desc_835"), new int[2] { 6, 90 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_835")));
		_dataArray.Add(new EventFunctionItem(836, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_836"), LocalStringManager.GetConfig("EventFunction_language", "Desc_836"), new int[1] { 13 }, new string[0], 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_836")));
		_dataArray.Add(new EventFunctionItem(837, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_837"), LocalStringManager.GetConfig("EventFunction_language", "Desc_837"), new int[5] { 3, 7, 7, 7, 6 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_837_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_837_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_837")));
		_dataArray.Add(new EventFunctionItem(838, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_838"), LocalStringManager.GetConfig("EventFunction_language", "Desc_838"), new int[3] { 9, 6, 4 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_838_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_838_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_838_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_838")));
		_dataArray.Add(new EventFunctionItem(839, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_839"), LocalStringManager.GetConfig("EventFunction_language", "Desc_839"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_839_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_839")));
	}

	private void CreateItems14()
	{
		_dataArray.Add(new EventFunctionItem(840, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_840"), LocalStringManager.GetConfig("EventFunction_language", "Desc_840"), new int[3] { 1, 1, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_840")));
		_dataArray.Add(new EventFunctionItem(841, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_841"), LocalStringManager.GetConfig("EventFunction_language", "Desc_841"), new int[5] { 6, 6, 42, 5, 3 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_841_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_841_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_841_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_841_3")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_841")));
		_dataArray.Add(new EventFunctionItem(842, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_842"), LocalStringManager.GetConfig("EventFunction_language", "Desc_842"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_842")));
		_dataArray.Add(new EventFunctionItem(843, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_843"), LocalStringManager.GetConfig("EventFunction_language", "Desc_843"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_843")));
		_dataArray.Add(new EventFunctionItem(844, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_844"), LocalStringManager.GetConfig("EventFunction_language", "Desc_844"), new int[1] { 81 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_844")));
		_dataArray.Add(new EventFunctionItem(845, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_845"), LocalStringManager.GetConfig("EventFunction_language", "Desc_845"), new int[0], new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_845")));
		_dataArray.Add(new EventFunctionItem(846, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_846"), LocalStringManager.GetConfig("EventFunction_language", "Desc_846"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_846_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_846")));
		_dataArray.Add(new EventFunctionItem(847, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_847"), LocalStringManager.GetConfig("EventFunction_language", "Desc_847"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_847")));
		_dataArray.Add(new EventFunctionItem(848, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_848"), LocalStringManager.GetConfig("EventFunction_language", "Desc_848"), new int[2] { 9, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_848_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_848_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_848")));
		_dataArray.Add(new EventFunctionItem(849, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_849"), LocalStringManager.GetConfig("EventFunction_language", "Desc_849"), new int[1] { 33 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_849")));
		_dataArray.Add(new EventFunctionItem(850, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_850"), LocalStringManager.GetConfig("EventFunction_language", "Desc_850"), new int[2] { 6, 8 }, new string[0], 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_850")));
		_dataArray.Add(new EventFunctionItem(851, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_851"), LocalStringManager.GetConfig("EventFunction_language", "Desc_851"), new int[2] { 6, 3 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_851")));
		_dataArray.Add(new EventFunctionItem(852, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_852"), LocalStringManager.GetConfig("EventFunction_language", "Desc_852"), new int[1] { 3 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_852")));
		_dataArray.Add(new EventFunctionItem(853, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_853"), LocalStringManager.GetConfig("EventFunction_language", "Desc_853"), new int[2] { 6, 1 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_853_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_853_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_853")));
		_dataArray.Add(new EventFunctionItem(854, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_854"), LocalStringManager.GetConfig("EventFunction_language", "Desc_854"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_854_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_854")));
		_dataArray.Add(new EventFunctionItem(855, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_855"), LocalStringManager.GetConfig("EventFunction_language", "Desc_855"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_855")));
		_dataArray.Add(new EventFunctionItem(856, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_856"), LocalStringManager.GetConfig("EventFunction_language", "Desc_856"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_856")));
		_dataArray.Add(new EventFunctionItem(857, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_857"), LocalStringManager.GetConfig("EventFunction_language", "Desc_857"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_857")));
		_dataArray.Add(new EventFunctionItem(858, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_858"), LocalStringManager.GetConfig("EventFunction_language", "Desc_858"), new int[1] { 126 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_858")));
		_dataArray.Add(new EventFunctionItem(859, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_859"), LocalStringManager.GetConfig("EventFunction_language", "Desc_859"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_859")));
		_dataArray.Add(new EventFunctionItem(860, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_860"), LocalStringManager.GetConfig("EventFunction_language", "Desc_860"), new int[2] { 10, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_860_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_860_1")
		}, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_860")));
		_dataArray.Add(new EventFunctionItem(861, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_861"), LocalStringManager.GetConfig("EventFunction_language", "Desc_861"), new int[3] { 6, 6, 127 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_861_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_861_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_861_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_861")));
		_dataArray.Add(new EventFunctionItem(862, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_862"), LocalStringManager.GetConfig("EventFunction_language", "Desc_862"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_862")));
		_dataArray.Add(new EventFunctionItem(863, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_863"), LocalStringManager.GetConfig("EventFunction_language", "Desc_863"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_863")));
		_dataArray.Add(new EventFunctionItem(864, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_864"), LocalStringManager.GetConfig("EventFunction_language", "Desc_864"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_864")));
		_dataArray.Add(new EventFunctionItem(865, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_865"), LocalStringManager.GetConfig("EventFunction_language", "Desc_865"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_865")));
		_dataArray.Add(new EventFunctionItem(866, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_866"), LocalStringManager.GetConfig("EventFunction_language", "Desc_866"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_866")));
		_dataArray.Add(new EventFunctionItem(867, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_867"), LocalStringManager.GetConfig("EventFunction_language", "Desc_867"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_867_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_867")));
		_dataArray.Add(new EventFunctionItem(868, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_868"), LocalStringManager.GetConfig("EventFunction_language", "Desc_868"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_868")));
		_dataArray.Add(new EventFunctionItem(869, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_869"), LocalStringManager.GetConfig("EventFunction_language", "Desc_869"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_869")));
		_dataArray.Add(new EventFunctionItem(870, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_870"), LocalStringManager.GetConfig("EventFunction_language", "Desc_870"), new int[2] { 6, 129 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_870")));
		_dataArray.Add(new EventFunctionItem(871, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_871"), LocalStringManager.GetConfig("EventFunction_language", "Desc_871"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_871")));
		_dataArray.Add(new EventFunctionItem(872, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_872"), LocalStringManager.GetConfig("EventFunction_language", "Desc_872"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_872")));
		_dataArray.Add(new EventFunctionItem(873, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_873"), LocalStringManager.GetConfig("EventFunction_language", "Desc_873"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_873_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_873")));
		_dataArray.Add(new EventFunctionItem(874, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_874"), LocalStringManager.GetConfig("EventFunction_language", "Desc_874"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_874_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_874")));
		_dataArray.Add(new EventFunctionItem(875, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_875"), LocalStringManager.GetConfig("EventFunction_language", "Desc_875"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_875_0") }, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_875")));
		_dataArray.Add(new EventFunctionItem(876, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_876"), LocalStringManager.GetConfig("EventFunction_language", "Desc_876"), new int[1] { 6 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_876_0") }, 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_876")));
		_dataArray.Add(new EventFunctionItem(877, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_877"), LocalStringManager.GetConfig("EventFunction_language", "Desc_877"), new int[1] { 1 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_877_0") }, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_877")));
		_dataArray.Add(new EventFunctionItem(878, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_878"), LocalStringManager.GetConfig("EventFunction_language", "Desc_878"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_878")));
		_dataArray.Add(new EventFunctionItem(879, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_879"), LocalStringManager.GetConfig("EventFunction_language", "Desc_879"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_879")));
		_dataArray.Add(new EventFunctionItem(880, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_880"), LocalStringManager.GetConfig("EventFunction_language", "Desc_880"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_880")));
		_dataArray.Add(new EventFunctionItem(881, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_881"), LocalStringManager.GetConfig("EventFunction_language", "Desc_881"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_881")));
		_dataArray.Add(new EventFunctionItem(882, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_882"), LocalStringManager.GetConfig("EventFunction_language", "Desc_882"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_882")));
		_dataArray.Add(new EventFunctionItem(883, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_883"), LocalStringManager.GetConfig("EventFunction_language", "Desc_883"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_883")));
		_dataArray.Add(new EventFunctionItem(884, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_884"), LocalStringManager.GetConfig("EventFunction_language", "Desc_884"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_884")));
		_dataArray.Add(new EventFunctionItem(885, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_885"), LocalStringManager.GetConfig("EventFunction_language", "Desc_885"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_885")));
		_dataArray.Add(new EventFunctionItem(886, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_886"), LocalStringManager.GetConfig("EventFunction_language", "Desc_886"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_886")));
		_dataArray.Add(new EventFunctionItem(887, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_887"), LocalStringManager.GetConfig("EventFunction_language", "Desc_887"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_887")));
		_dataArray.Add(new EventFunctionItem(888, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_888"), LocalStringManager.GetConfig("EventFunction_language", "Desc_888"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_888")));
		_dataArray.Add(new EventFunctionItem(889, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_889"), LocalStringManager.GetConfig("EventFunction_language", "Desc_889"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_889")));
		_dataArray.Add(new EventFunctionItem(890, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_890"), LocalStringManager.GetConfig("EventFunction_language", "Desc_890"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_890")));
		_dataArray.Add(new EventFunctionItem(891, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_891"), LocalStringManager.GetConfig("EventFunction_language", "Desc_891"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_891")));
		_dataArray.Add(new EventFunctionItem(892, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_892"), LocalStringManager.GetConfig("EventFunction_language", "Desc_892"), new int[1] { 107 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_892")));
		_dataArray.Add(new EventFunctionItem(893, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_893"), LocalStringManager.GetConfig("EventFunction_language", "Desc_893"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_893")));
		_dataArray.Add(new EventFunctionItem(894, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_894"), LocalStringManager.GetConfig("EventFunction_language", "Desc_894"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_894")));
		_dataArray.Add(new EventFunctionItem(895, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_895"), LocalStringManager.GetConfig("EventFunction_language", "Desc_895"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_895")));
		_dataArray.Add(new EventFunctionItem(896, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_896"), LocalStringManager.GetConfig("EventFunction_language", "Desc_896"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_896")));
		_dataArray.Add(new EventFunctionItem(897, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_897"), LocalStringManager.GetConfig("EventFunction_language", "Desc_897"), new int[1] { 11 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_897")));
		_dataArray.Add(new EventFunctionItem(898, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_898"), LocalStringManager.GetConfig("EventFunction_language", "Desc_898"), new int[3] { 6, 3, 35 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_898_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_898_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_898_2")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_898")));
		_dataArray.Add(new EventFunctionItem(899, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_899"), LocalStringManager.GetConfig("EventFunction_language", "Desc_899"), new int[1] { 82 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_899_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_899")));
	}

	private void CreateItems15()
	{
		_dataArray.Add(new EventFunctionItem(900, EEventFunctionType.DataRtrieval, LocalStringManager.GetConfig("EventFunction_language", "Name_900"), LocalStringManager.GetConfig("EventFunction_language", "Desc_900"), new int[1] { 130 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_900_0") }, 4, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_900")));
		_dataArray.Add(new EventFunctionItem(901, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_901"), LocalStringManager.GetConfig("EventFunction_language", "Desc_901"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_901")));
		_dataArray.Add(new EventFunctionItem(902, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_902"), LocalStringManager.GetConfig("EventFunction_language", "Desc_902"), new int[2] { 6, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_902_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_902_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_902")));
		_dataArray.Add(new EventFunctionItem(903, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_903"), LocalStringManager.GetConfig("EventFunction_language", "Desc_903"), new int[3] { 131, 132, 0 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_903_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_903_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_903_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_903")));
		_dataArray.Add(new EventFunctionItem(904, EEventFunctionType.Basic, LocalStringManager.GetConfig("EventFunction_language", "Name_904"), LocalStringManager.GetConfig("EventFunction_language", "Desc_904"), new int[2] { 131, 132 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_904_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_904_1")
		}, 0, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_904")));
		_dataArray.Add(new EventFunctionItem(905, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_905"), LocalStringManager.GetConfig("EventFunction_language", "Desc_905"), new int[1] { 5 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_905_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_905")));
		_dataArray.Add(new EventFunctionItem(906, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_906"), LocalStringManager.GetConfig("EventFunction_language", "Desc_906"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_906")));
		_dataArray.Add(new EventFunctionItem(907, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_907"), LocalStringManager.GetConfig("EventFunction_language", "Desc_907"), new int[3] { 131, 132, 4 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_907")));
		_dataArray.Add(new EventFunctionItem(908, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_908"), LocalStringManager.GetConfig("EventFunction_language", "Desc_908"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_908")));
		_dataArray.Add(new EventFunctionItem(909, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_909"), LocalStringManager.GetConfig("EventFunction_language", "Desc_909"), new int[2] { 18, 117 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_909")));
		_dataArray.Add(new EventFunctionItem(910, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_910"), LocalStringManager.GetConfig("EventFunction_language", "Desc_910"), new int[2] { 18, 20 }, new string[0], 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_910")));
		_dataArray.Add(new EventFunctionItem(911, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_911"), LocalStringManager.GetConfig("EventFunction_language", "Desc_911"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_911")));
		_dataArray.Add(new EventFunctionItem(912, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_912"), LocalStringManager.GetConfig("EventFunction_language", "Desc_912"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_912")));
		_dataArray.Add(new EventFunctionItem(913, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_913"), LocalStringManager.GetConfig("EventFunction_language", "Desc_913"), new int[0], new string[0], 46, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_913")));
		_dataArray.Add(new EventFunctionItem(914, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_914"), LocalStringManager.GetConfig("EventFunction_language", "Desc_914"), new int[2] { 45, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_914_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_914_1")
		}, 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_914")));
		_dataArray.Add(new EventFunctionItem(915, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_915"), LocalStringManager.GetConfig("EventFunction_language", "Desc_915"), new int[1] { 45 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_915")));
		_dataArray.Add(new EventFunctionItem(916, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_916"), LocalStringManager.GetConfig("EventFunction_language", "Desc_916"), new int[1] { 45 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_916")));
		_dataArray.Add(new EventFunctionItem(917, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_917"), LocalStringManager.GetConfig("EventFunction_language", "Desc_917"), new int[4] { 7, 20, 3, 5 }, new string[4]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_917_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_917_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_917_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_917_3")
		}, 6, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_917")));
		_dataArray.Add(new EventFunctionItem(918, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_918"), LocalStringManager.GetConfig("EventFunction_language", "Desc_918"), new int[3] { 6, 3, 3 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_918_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_918_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_918_2")
		}, 7, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_918")));
		_dataArray.Add(new EventFunctionItem(919, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_919"), LocalStringManager.GetConfig("EventFunction_language", "Desc_919"), new int[1] { 131 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_919")));
		_dataArray.Add(new EventFunctionItem(920, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_920"), LocalStringManager.GetConfig("EventFunction_language", "Desc_920"), new int[1] { 5 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_920_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_920")));
		_dataArray.Add(new EventFunctionItem(921, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_921"), LocalStringManager.GetConfig("EventFunction_language", "Desc_921"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_921")));
		_dataArray.Add(new EventFunctionItem(922, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_922"), LocalStringManager.GetConfig("EventFunction_language", "Desc_922"), new int[1] { 7 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_922")));
		_dataArray.Add(new EventFunctionItem(923, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_923"), LocalStringManager.GetConfig("EventFunction_language", "Desc_923"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_923")));
		_dataArray.Add(new EventFunctionItem(924, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_924"), LocalStringManager.GetConfig("EventFunction_language", "Desc_924"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_924")));
		_dataArray.Add(new EventFunctionItem(925, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_925"), LocalStringManager.GetConfig("EventFunction_language", "Desc_925"), new int[2] { 130, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_925_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_925_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_925")));
		_dataArray.Add(new EventFunctionItem(926, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_926"), LocalStringManager.GetConfig("EventFunction_language", "Desc_926"), new int[1] { 130 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_926")));
		_dataArray.Add(new EventFunctionItem(927, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_927"), LocalStringManager.GetConfig("EventFunction_language", "Desc_927"), new int[1] { 81 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_927")));
		_dataArray.Add(new EventFunctionItem(928, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_928"), LocalStringManager.GetConfig("EventFunction_language", "Desc_928"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_928")));
		_dataArray.Add(new EventFunctionItem(929, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_929"), LocalStringManager.GetConfig("EventFunction_language", "Desc_929"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_929")));
		_dataArray.Add(new EventFunctionItem(930, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_930"), LocalStringManager.GetConfig("EventFunction_language", "Desc_930"), new int[1] { 7 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_930")));
		_dataArray.Add(new EventFunctionItem(931, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_931"), LocalStringManager.GetConfig("EventFunction_language", "Desc_931"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_931")));
		_dataArray.Add(new EventFunctionItem(932, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_932"), LocalStringManager.GetConfig("EventFunction_language", "Desc_932"), new int[2] { 52, 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_932")));
		_dataArray.Add(new EventFunctionItem(933, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_933"), LocalStringManager.GetConfig("EventFunction_language", "Desc_933"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: false, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_933")));
		_dataArray.Add(new EventFunctionItem(934, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_934"), LocalStringManager.GetConfig("EventFunction_language", "Desc_934"), new int[2] { 134, 133 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_934")));
		_dataArray.Add(new EventFunctionItem(935, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_935"), LocalStringManager.GetConfig("EventFunction_language", "Desc_935"), new int[1] { 9 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_935")));
		_dataArray.Add(new EventFunctionItem(936, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_936"), LocalStringManager.GetConfig("EventFunction_language", "Desc_936"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_936")));
		_dataArray.Add(new EventFunctionItem(937, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_937"), LocalStringManager.GetConfig("EventFunction_language", "Desc_937"), new int[1] { 45 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_937")));
		_dataArray.Add(new EventFunctionItem(938, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_938"), LocalStringManager.GetConfig("EventFunction_language", "Desc_938"), new int[0], new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_938")));
		_dataArray.Add(new EventFunctionItem(939, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_939"), LocalStringManager.GetConfig("EventFunction_language", "Desc_939"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_939")));
		_dataArray.Add(new EventFunctionItem(940, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_940"), LocalStringManager.GetConfig("EventFunction_language", "Desc_940"), new int[2] { 4, 3 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_940_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_940_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_940")));
		_dataArray.Add(new EventFunctionItem(941, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_941"), LocalStringManager.GetConfig("EventFunction_language", "Desc_941"), new int[1] { 3 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_941_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_941")));
		_dataArray.Add(new EventFunctionItem(942, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_942"), LocalStringManager.GetConfig("EventFunction_language", "Desc_942"), new int[2] { 45, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_942_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_942_1")
		}, 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_942")));
		_dataArray.Add(new EventFunctionItem(943, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_943"), LocalStringManager.GetConfig("EventFunction_language", "Desc_943"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_943")));
		_dataArray.Add(new EventFunctionItem(944, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_944"), LocalStringManager.GetConfig("EventFunction_language", "Desc_944"), new int[1] { 6 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_944")));
		_dataArray.Add(new EventFunctionItem(945, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_945"), LocalStringManager.GetConfig("EventFunction_language", "Desc_945"), new int[1] { 5 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_945")));
		_dataArray.Add(new EventFunctionItem(946, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_946"), LocalStringManager.GetConfig("EventFunction_language", "Desc_946"), new int[1] { 7 }, new string[0], 1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_946")));
		_dataArray.Add(new EventFunctionItem(947, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_947"), LocalStringManager.GetConfig("EventFunction_language", "Desc_947"), new int[1] { 61 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_947_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_947")));
		_dataArray.Add(new EventFunctionItem(948, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_948"), LocalStringManager.GetConfig("EventFunction_language", "Desc_948"), new int[1] { 62 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_948_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_948")));
		_dataArray.Add(new EventFunctionItem(949, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_949"), LocalStringManager.GetConfig("EventFunction_language", "Desc_949"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_949")));
		_dataArray.Add(new EventFunctionItem(950, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_950"), LocalStringManager.GetConfig("EventFunction_language", "Desc_950"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_950")));
		_dataArray.Add(new EventFunctionItem(951, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_951"), LocalStringManager.GetConfig("EventFunction_language", "Desc_951"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_951")));
		_dataArray.Add(new EventFunctionItem(952, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_952"), LocalStringManager.GetConfig("EventFunction_language", "Desc_952"), new int[1] { 1 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_952")));
		_dataArray.Add(new EventFunctionItem(953, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_953"), LocalStringManager.GetConfig("EventFunction_language", "Desc_953"), new int[7] { 5, 5, 5, 5, 5, 5, 5 }, new string[7]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_953_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_953_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_953_2"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_953_3"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_953_4"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_953_5"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_953_6")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_953")));
		_dataArray.Add(new EventFunctionItem(954, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_954"), LocalStringManager.GetConfig("EventFunction_language", "Desc_954"), new int[2] { 5, 42 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_954_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_954_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_954")));
		_dataArray.Add(new EventFunctionItem(955, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_955"), LocalStringManager.GetConfig("EventFunction_language", "Desc_955"), new int[3] { 6, 6, 88 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_955_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_955_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_955_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_955")));
		_dataArray.Add(new EventFunctionItem(956, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_956"), LocalStringManager.GetConfig("EventFunction_language", "Desc_956"), new int[3] { 6, 6, 88 }, new string[3]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_956_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_956_1"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_956_2")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_956")));
		_dataArray.Add(new EventFunctionItem(957, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_957"), LocalStringManager.GetConfig("EventFunction_language", "Desc_957"), new int[1] { 6 }, new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_957")));
		_dataArray.Add(new EventFunctionItem(958, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_958"), LocalStringManager.GetConfig("EventFunction_language", "Desc_958"), new int[1] { 38 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_958")));
		_dataArray.Add(new EventFunctionItem(959, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_959"), LocalStringManager.GetConfig("EventFunction_language", "Desc_959"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_959")));
	}

	private void CreateItems16()
	{
		_dataArray.Add(new EventFunctionItem(960, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_960"), LocalStringManager.GetConfig("EventFunction_language", "Desc_960"), new int[2] { 46, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_960_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_960_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_960")));
		_dataArray.Add(new EventFunctionItem(961, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_961"), LocalStringManager.GetConfig("EventFunction_language", "Desc_961"), new int[2] { 45, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_961_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_961_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_961")));
		_dataArray.Add(new EventFunctionItem(962, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_962"), LocalStringManager.GetConfig("EventFunction_language", "Desc_962"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_962")));
		_dataArray.Add(new EventFunctionItem(963, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_963"), LocalStringManager.GetConfig("EventFunction_language", "Desc_963"), new int[1] { 6 }, new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_963")));
		_dataArray.Add(new EventFunctionItem(964, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_964"), LocalStringManager.GetConfig("EventFunction_language", "Desc_964"), new int[2] { 135, 133 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_964_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_964_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_964")));
		_dataArray.Add(new EventFunctionItem(965, EEventFunctionType.UI, LocalStringManager.GetConfig("EventFunction_language", "Name_965"), LocalStringManager.GetConfig("EventFunction_language", "Desc_965"), new int[2] { 136, 5 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_965_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_965_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: true, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_965")));
		_dataArray.Add(new EventFunctionItem(966, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_966"), LocalStringManager.GetConfig("EventFunction_language", "Desc_966"), new int[2] { 130, 4 }, new string[2]
		{
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_966_0"),
			LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_966_1")
		}, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_966")));
		_dataArray.Add(new EventFunctionItem(967, EEventFunctionType.Condition, LocalStringManager.GetConfig("EventFunction_language", "Name_967"), LocalStringManager.GetConfig("EventFunction_language", "Desc_967"), new int[0], new string[0], 3, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_967")));
		_dataArray.Add(new EventFunctionItem(968, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_968"), LocalStringManager.GetConfig("EventFunction_language", "Desc_968"), new int[1] { 4 }, new string[1] { LocalStringManager.GetConfig("EventFunction_language", "ParameterNames_968_0") }, -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_968")));
		_dataArray.Add(new EventFunctionItem(969, EEventFunctionType.Behavior, LocalStringManager.GetConfig("EventFunction_language", "Name_969"), LocalStringManager.GetConfig("EventFunction_language", "Desc_969"), new int[0], new string[0], -1, indentNext: false, -1, canCreateManually: true, new List<int>(), allowedInCondition: false, isTransition: false, allowExternalUsage: true, LocalStringManager.GetConfig("EventFunction_language", "InGameHint_969")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventFunctionItem>(970);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
		CreateItems7();
		CreateItems8();
		CreateItems9();
		CreateItems10();
		CreateItems11();
		CreateItems12();
		CreateItems13();
		CreateItems14();
		CreateItems15();
		CreateItems16();
	}
}

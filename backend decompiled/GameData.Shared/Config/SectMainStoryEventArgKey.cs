using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class SectMainStoryEventArgKey : ConfigData<SectMainStoryEventArgKeyItem, int>, IEventArgumentCollectionFormatter
{
	public static class DefKey
	{
		public const int IsKillLiaoWuming = 0;

		public const int IsKilledByLiaoWuming = 1;

		public const int LiaoWumingQuestStartDate = 2;

		public const int LiaoWumingGetPoison = 3;

		public const int TheNameGivePoisonToLiaoWuming = 4;

		public const int KongsangAdventureCountDown = 5;

		public const int GetKongsangInformation1 = 6;

		public const int GetKongsangInformation2 = 7;

		public const int InteractWithLiaoWumingAi2 = 8;

		public const int KongsangAcceptTaskTaiwuId = 9;

		public const int KongsangFirstPassingLegacyTaiwuId = 10;

		public const int KongsangFirstPassingLegacyDialogTriggered = 11;

		public const int KongsangSecondPassingLegacyDialogCharId = 12;

		public const int KongsangStoryPartOneTriggered = 13;

		public const int KongsangPart3TaiwuId = 14;

		public const int FirstTryPoisonIsFailure = 15;

		public const int SecondTryPoisonIsFailure = 16;

		public const int ThirdTryPoisonIsFailure = 17;

		public const int TripodVesselOfMedicineAreaId = 18;

		public const int ActingHeadActorData = 19;

		public const int KongsangSectLeaderId = 20;

		public const int BeforePoisonTest0EventTriggered = 21;

		public const int BeforePoisonTest0EventFirstTriggered = 22;

		public const int BeforePoisonTest1EventTriggered = 23;

		public const int MissionUnacceptedEventTriggeredSameMonth = 24;

		public const int KongsangTargetFoundEventTriggered = 25;

		public const int XuehouStoryPartOneTriggered = 26;

		public const int StillAtYangzhou = 27;

		public const int FirstGotBellTime = 28;

		public const int MeetSkeletonWithBellExtraProb = 29;

		public const int XuehouGraveDiggingEventTriggered = 30;

		public const int DefeatXuehouOldManTime = 31;

		public const int GiveBellToXuehouOldManTime = 32;

		public const int XuehouOldManGraveDisappearTriggered = 33;

		public const int XuehouOldManCharacterId = 34;

		public const int OldManZombieInteractTriggered = 35;

		public const int AwakeJixiTaiwuId = 36;

		public const int AwakeJixiTaiwuGender = 37;

		public const int AwakeJixiAndPassLegacy = 38;

		public const int PassXuehouAdventure1Time = 39;

		public const int XuehouEmptyCaveTriggered = 40;

		public const int XuehouFindPeopleTriggered = 41;

		public const int XuehouComingTime = 42;

		public const int XuehouComingTriggeredCount = 43;

		public const int JixiArrivedTaiwuDate = 44;

		public const int JixiArrivedTaiwuMonthlyEventTriggeredCount = 45;

		public const int JixiAdventureOnePassDate = 46;

		public const int JixiAdventureTwoPassDate = 47;

		public const int JixiAdventureThreePassDate = 48;

		public const int JixiAdventureOneStartDate = 49;

		public const int JixiAdventureTwoStartDate = 50;

		public const int JixiAdventureThreeStartDate = 51;

		public const int JixiAdventureFourStartDate = 52;

		public const int ProtectedJixiEventTriggered = 53;

		public const int JixiFeedChickenEventTriggered = 54;

		public const int JixiHarmVillagerEventTriggered = 55;

		public const int HaveJixiTruthClueCount = 56;

		public const int HaveJixiFalseClueCount = 57;

		public const int JixiWaitingMonthKey = 58;

		public const int JixiStayAtGraveMonthKey = 59;

		public const int JixiKilledCountKey = 60;

		public const int CombatWithUltimateZombieTriggered = 61;

		public const int JixiLegacyPassFirstTalkTriggered = 62;

		public const int JixiSoulTransformFirstTalkTriggered = 63;

		public const int PassLegacyMonthlyNotificationTriggered = 64;

		public const int NeedTriggerPassLegacyMonthlyNotification = 65;

		public const int XuehouOldManHasBell = 66;

		public const int JixiHasAntiqueJadeBat = 67;

		public const int JixiHasAntiqueJadeFox = 68;

		public const int JixiHasAntiqueJadeButterfly = 69;

		public const int JixiFavorite1TalkTriggered = 70;

		public const int JixiFavorite2TalkTriggered = 71;

		public const int JixiFavorite3TalkTriggered = 72;

		public const int JixiFavorite4TalkTriggered = 73;

		public const int JixiFavorite5TalkTriggered = 74;

		public const int JixiLikeKillTalkTriggered = 75;

		public const int JixiPassLegacyTalkTriggered = 76;

		public const int JixiKillEnemyTalkTriggered = 77;

		public const int JixiKilledEnemy = 78;

		public const int JixiFollowOpen = 79;

		public const int XuehouSelectFreeJixi = 80;

		public const int XuehouGraveDiggingNormalTriggerTime = 81;

		public const int JixiAnimalTalkOpen = 82;

		public const int XuannvStoryTriggerFirstTrack = 83;

		public const int XuannvStoryPartOneTriggered = 84;

		public const int XuannvStoryTaiwuCharId = 85;

		public const int XuannvStoryPartOneIsReceivingLetter = 86;

		public const int XuannvStoryPartOneLetterCountA = 87;

		public const int XuannvStoryPartOneLetterCountB = 88;

		public const int XuannvStoryPartOneLetterCountC = 89;

		public const int XuannvStoryPartOneOptionMarkKey = 90;

		public const int XuannvStoryPartOneLegendaryDoctor = 91;

		public const int XuannvStoryPartOneWaitSecretGuestEvent = 92;

		public const int XuannvStoryPartOneSecretGuestActorKey = 93;

		public const int XuannvStoryPartOneGuessGenderKey = 94;

		public const int XuannvStoryPartOneOptionInjectFlag = 95;

		public const int XuannvStoryPartOneNoneSectNpcInquireSecretGuest1 = 96;

		public const int XuannvStoryPartOneNoneSectNpcInquireSecretGuest2 = 97;

		public const int XuannvStoryPartOneNoneSectNpcInquireSecretGuest3 = 98;

		public const int XuannvStoryPartTwoOptionInjectFlag = 99;

		public const int XuannvStoryPartTwoCombatSkillType = 100;

		public const int XuannvStoryPartThreeLearningSkill = 101;

		public const int XuannvStoryPartThreeLearningSkillId0 = 102;

		public const int XuannvStoryPartThreeLearningSkillId1 = 103;

		public const int XuannvStoryPartThreeLearningSkillId2 = 104;

		public const int XuannvStoryPartTwoRefuseToHelpCount = 105;

		public const int XuannvStoryPartThreeSearchLoverCount = 106;

		public const int XuannvStoryPartThreeSearchLoverSecondTakeLoverDate = 107;

		public const int XuannvStoryPartThreeLoverReincarnateSettlementId1 = 108;

		public const int XuannvStoryPartThreeLoverReincarnateSettlementId2 = 109;

		public const int XuannvStoryPartThreeLoverReincarnateSettlementId3 = 110;

		public const int XuannvStoryPartThreeLoverReincarnateLocation = 111;

		public const int XuannvStoryPartThreeWaitLoverNameKey = 112;

		public const int XuannvStoryMonthlyEventWithSisterTriggered = 113;

		public const int XuannvStoryPartThreeHasTalkToShiWeizhi = 114;

		public const int XuannvStoryPartThreeActorSisterOfShiWeizhi = 115;

		public const int XuannvStoryPartThreeGirlGodIllusion = 116;

		public const int XuannvStoryOptionReadFlag1 = 117;

		public const int XuannvStoryOptionReadFlag2 = 118;

		public const int XuannvStoryOptionReadFlag3 = 119;

		public const int XuannvStoryOptionReadFlag4 = 120;

		public const int XuannvStoryHeYouyuanCharId = 121;

		public const int XuannvStorySecretReincarnationNpcCharId = 122;

		public const int XuannvStoryIsJunerAtXuannvSect = 123;

		public const int XuannvStoryMusicUnlock10FirstFlag = 124;

		public const int XuannvStoryMusicUnlock40FirstFlag = 125;

		public const int XuannvStoryMusicUnlock45MusicWeaponFlag = 126;

		public const int XuannvLastDateOfAdventureIllusionOfMirror = 127;

		public const int ShaolinMythinLowMemberTalked = 128;

		public const int ShaolinMythinMiddleMemberTalked = 129;

		public const int ShaolinStatueReturnTriggered = 130;

		public const int ShaolinMonthlyEventNotEnoughDate = 131;

		public const int DamoDreamMeetTaiwuId = 132;

		public const int ShaolinCombatSkillType = 133;

		public const int ShaolinLearnedAny = 134;

		public const int ShaolinDamoFightTimes = 135;

		public const int ShaolinDamoFightWinDate = 136;

		public const int ShaolinStudyForBodhidharmaChallenge = 137;

		public const int ShaolinDamoTrialTriggered = 138;

		public const int ShaolinDamoFightTriggered = 139;

		public const int ShaolinDamoVisitTimes = 140;

		public const int ShaolinReadingMaxGradeSutra = 141;

		public const int ShaolinSutraPavilionGuardDate = 142;

		public const int ShaolinDamoLearnedFightTimes = 143;

		public const int ShaolinComprehendedTheZen = 144;

		public const int ShaolinMeditationInteractionFinished = 145;

		public const int ShaolinInteractionChangeTip1Triggered = 146;

		public const int ShaolinInteractionChangeTip2Triggered = 147;

		public const int WudangSkillReverseBreakCount = 148;

		public const int CombatWithTaoistMonkDate = 149;

		public const int CombatWithTaoistMonkTaiwuName = 150;

		public const int AtLastCombatWithTaoistMonkTaiwuName = 151;

		public const int BlackSnakeCustomName = 152;

		public const int GiveTaoistTreasureCount = 153;

		public const int GiveTaoistTreasureItemKey = 154;

		public const int WudangChatEventTriggeredCount = 155;

		public const int WudangSankeFighted = 156;

		public const int WudangFrontEventTriggered = 157;

		public const int LastEventSloppyTaoistMonkFavor = 158;

		public const int GetExtraSeedCount = 159;

		public const int FinishFairylandStoryCount = 160;

		public const int TriggeredFailureEvent = 161;

		public const int WudangKillRandomEnemyTriggered = 162;

		public const int GivenMonkSnakeItemKey = 163;

		public const int GivenMonkSnakeList = 164;

		public const int WudangEasterEggTriggered = 165;

		public const int WudangHeavenlyTreeSeedTalkTriggered = 166;

		public const int WudangFairylandTalkTriggered = 167;

		public const int WudangTortoiseSnakeTalkTriggered = 168;

		public const int WudangEmperorTalkTriggered = 169;

		public const int MeetImmortalEventCount = 170;

		public const int CollectHeavenlyTreeSeedFirstTriggered = 171;

		public const int YuanshanDemonOutOfJail = 172;

		public const int TaiwuReleasedYuanshanDemon = 173;

		public const int YuanshanLeaderFirmDate = 174;

		public const int YuanshanDemonDormantDate = 175;

		public const int MythInYuanshanTriggeredDate = 176;

		public const int YuanshanInteractionTriggeredCount = 177;

		public const int YuanshanThoughtsTriggeredCount = 178;

		public const int YuanshanThoughtsInteractable = 179;

		public const int YuanshanLobbyTalkInteractable = 180;

		public const int YuanshanDemonPower = 181;

		public const int KilledYuanshanDemonCount = 182;

		public const int YuanshanCaelumDemonDefeatedTaiwu = 183;

		public const int YuanshanTerraDemonDefeatedTaiwu = 184;

		public const int YuanshanAnthropDemonDefeatedTaiwu = 185;

		public const int YuanshanDemonMeetTaiwuCharId = 186;

		public const int YuanshanDemonLast = 187;

		public const int YuanshanToFightDemon = 188;

		public const int YuanshanMiniGameStage = 189;

		public const int AreVitalsDemon = 190;

		public const int ShixiangAdventureAppearDate = 191;

		public const int ShixiangFirstLetterDate = 192;

		public const int ShixiangLetterCount = 193;

		public const int ShixiangToFightEnemy = 194;

		public const int MockShixiangEventTriggeredSettlementId = 195;

		public const int MockShixiangEventTriggered = 196;

		public const int MockShixiangEventCount = 197;

		public const int ShixiangStoryPartOneTriggered = 198;

		public const int ShixiangAdventureWon = 199;

		public const int TaiwuKillBarbarianMasterCount = 200;

		public const int ShixiangKillBarbarianMasterCount = 201;

		public const int TaiwuKillBarbarianMasterCount2 = 202;

		public const int ShixiangKillBarbarianMasterCount2 = 203;

		public const int ArriveLotusMountainEventTriggered = 204;

		public const int ArriveShixiangEventTriggered = 205;

		public const int StartFightShixiangTraitorsDate = 206;

		public const int FailFinishKillTraitorOnTime = 207;

		public const int SelectGoodEnd = 208;

		public const int LeikunAvatarData = 209;

		public const int KilledByLeiKunTaiwuName = 210;

		public const int ShixiangAdventureLiteratiCharId = 211;

		public const int EmeiSelectGoodEndCount = 212;

		public const int EmeiSelectBadEndCount = 213;

		public const int EmeiFourthSelectResult = 214;

		public const int WhiteApeBlockId = 215;

		public const int WhiteApeBlockIdTmpSave = 216;

		public const int HomocideCase0Time = 217;

		public const int HomocideCase1Time = 218;

		public const int HomocideCase0Triggered = 219;

		public const int HomocideCase1Triggered = 220;

		public const int HomocideCase2Triggered = 221;

		public const int EmeiRoleJia = 222;

		public const int EmeiRoleYi = 223;

		public const int EmeiRoleBing = 224;

		public const int EmeiRoleDing = 225;

		public const int EmeiRoleWu = 226;

		public const int EmeiRoleSi = 227;

		public const int EmeiRoleGeng = 228;

		public const int EmeiRoleXin = 229;

		public const int TaiwuJumpCliffInjuryType = 230;

		public const int EmeiKillEachOtherStage = 231;

		public const int EmeiHomocideCasesInteractionCount = 232;

		public const int EmeiEmeiHomocideCasesInteractionIds = 233;

		public const int FirstClickWhiteGibbonDate = 234;

		public const int SecondClickWhiteGibbonDate = 235;

		public const int ThirdClickWhiteGibbonDate = 236;

		public const int FourthClickWhiteGibbonDate = 237;

		public const int FifthClickWhiteGibbonDate = 238;

		public const int SixthClickWhiteGibbonDate = 239;

		public const int EmeiOptionReclusiveElderVisible = 240;

		public const int EmeiOptionWhoIsOrthodoxVisible = 241;

		public const int EmeiLeaderOriginalLocation = 242;

		public const int EmeiLeaderOriginalId = 243;

		public const int EmeiAdventureTwoAppearDate = 244;

		public const int EmeiEnterAdventureTwo = 245;

		public const int EmeiPassAdventureTwoTaiwuId = 246;

		public const int EmeiAdventureTwoPathEventTriggerCount = 247;

		public const int EmeiSelectGiveUpTrace = 248;

		public const int EmeiDefeatShiHoujiu = 249;

		public const int EmeiWhiteGibbonFollowOpen = 250;

		public const int EmeiShiHoujiuFollowOpen = 251;

		public const int EmeiBreakBonusRefreshTimes = 252;

		public const int EmeiBreakBonusSaved = 253;

		public const int EmeiBreakBonusTemplateIds = 254;

		public const int EmeiBreakBonusExtraPoints = 255;

		public const int EmeiGiveInShiHoujiu = 256;

		public const int WuxianPrologueWugEventRecord = 257;

		public const int WuxianPrologueTaiwuId = 258;

		public const int WuxianPrologueAddedWug = 259;

		public const int WuxianPrologueWugAttacked = 260;

		public const int WuxianChapter1VisitCount = 261;

		public const int WuxianChapter1Wish1 = 262;

		public const int WuxianChapter1Wish2 = 263;

		public const int WuxianChapter1Wish3 = 264;

		public const int WuxianChapter1WishCount = 265;

		public const int WuxianChapter1WishComeTrueCount = 266;

		public const int WuxianChapter1Refused = 267;

		public const int WuxianChapter1RanXinduLocation = 268;

		public const int WuxianChapter2Adventure1Selection = 269;

		public const int WuxianChapter2Adventure2Selection = 270;

		public const int WuxianChapter3AbleToStart = 271;

		public const int WuxianChapter3MailReceivedCount = 272;

		public const int WuxianChapter4AdventureComplete = 273;

		public const int WuxianChapter4FinalBossBeaten = 274;

		public const int WuxianChapter4HappyEndingEventDate = 275;

		public const int WuxianChapter4EndingEventTriggered = 276;

		public const int WuxianPassLegacyEventTriggered = 277;

		public const int JingangMonkMurderedTriggeredDate = 278;

		public const int JingangAfterMonkMurderedTriggeredMoveCount = 279;

		public const int JingangGiveVillagerFood = 280;

		public const int JingangGiveVillagerFoodEventTriggered = 281;

		public const int JingangGiveVillagerFoodActorData = 282;

		public const int JingangGiveVillagerMoney = 283;

		public const int JingangGiveVillagerMoneyEventTriggered = 284;

		public const int JingangGiveVillagerMoneyActorData = 285;

		public const int JingangGiveVillagerPromise = 286;

		public const int JingangGiveVillagerPromiseEventTriggered = 287;

		public const int JingangGiveVillagerHelp = 288;

		public const int JingangGiveVillagerHelpEventTriggered = 289;

		public const int JingangGiveVillagerHelpActorData = 290;

		public const int JingangPersuadeVillagerCount = 291;

		public const int JingangTriggeredPeopleSufferingCount = 292;

		public const int JingangTriggeredInteractionVillagers = 293;

		public const int JingangTriggerMonthlyEventVillagerSuffer = 294;

		public const int JingangMonthlyEventVillagerEscapeTriggered = 295;

		public const int JingangAdventureNearestSettlementId = 296;

		public const int JingangSecInfoSpreadingSelectCombat = 297;

		public const int JingangCreateCentralPlainsMonkTaiwuAreaId = 298;

		public const int JingangKnowSecInfoIdList = 299;

		public const int JingangSpreadSecInfoTotalCount = 300;

		public const int JingangMonkSoulEnterDreamCount = 301;

		public const int JingangSamsaraMonkSoulDreamTalkCount = 302;

		public const int JingangSecInfoMetaDataId = 303;

		public const int JingangSecInfoOccurenceId = 304;

		public const int JingangTalkedCentralPlainsMonkId = 305;

		public const int JingangSamsaraMonkSoulTalked = 306;

		public const int JingangSamsaraMonkSoulTalkSelectBehavior = 307;

		public const int JingangAttackDate = 308;

		public const int JingangFamousFakeMonkDate = 309;

		public const int JingangPrayDate = 310;

		public const int JingangLettersFromJingangDate = 311;

		public const int JingangFameDistributionDate = 312;

		public const int JingangPietyCount = 313;

		public const int JingangSelectHelpWestMonk = 314;

		public const int JingangSecInfoSpreadingSelectBetray = 315;

		public const int JingangHelpMonkEndSelectOption = 316;

		public const int JingangMonkSoulBtnDisappear = 317;

		public const int JingangDefeatShmashanaAdhipati = 318;

		public const int JingangMonkReincarnationTriggered = 319;

		public const int JingangMonkGhostVanishesTriggered = 320;

		public const int JingangEndPartOneRefuseGiveSutra = 321;

		public const int JingangWesternBuddhistMonkTalkOneTriggered = 322;

		public const int JingangWesternBuddhistMonkTalkTwoTriggered = 323;

		public const int JingangWesternBuddhistMonkTalkThreeTriggered = 324;

		public const int JingangWesternBuddhistMonkPassLegacyTaiwuId = 325;

		public const int JingangImpersonatorBuddhistMonkPassLegacyTaiwuId = 326;

		public const int JingangStillAtJingang = 327;

		public const int JingangFinishSecondSpreadSutra = 328;

		public const int JingangTriggeredChapter1Patch = 329;

		public const int JingangMonkSoulResolveDreamCount = 330;

		public const int JingangMonkSoulResolveDreamChatCount = 331;

		public const int JingangGiveFakeBook = 332;

		public const int JingangHelpSect = 333;

		public const int RanshanSpecialInteractionToggle = 334;

		public const int RanshanChapter1MonthlyEventTriggeredCount = 335;

		public const int RanshanChapter1MonthlyEventTriggeredDate = 336;

		public const int RanshanChapter2TeachStartDate = 337;

		public const int RanshanChapter2HuajuCombatPlayDecision = 338;

		public const int RanshanChapter2XuanzhiCombatPlayDecision = 339;

		public const int RanshanChapter2YingjiaoCombatPlayDecision = 340;

		public const int RanshanChapter2HuajuCombatPlayDate = 341;

		public const int RanshanChapter2XuanzhiCombatPlayDate = 342;

		public const int RanshanChapter2YingjiaoCombatPlayDate = 343;

		public const int RanshanChapter2YingjiaoSelection1 = 344;

		public const int RanshanChapter2YingjiaoSelection2 = 345;

		public const int RanshanSanZongBiWuCountDown = 346;

		public const int RanshanChapter3WillingToBeImmortal = 347;

		public const int BaihuaVillageSettlementIdSelection = 348;

		public const int BaihuaEndenmicTriggered = 349;

		public const int BaihuaDreamAboutPastFirstTriggered = 350;

		public const int BaihuaLeukorpusArrivedEventTriggered = 351;

		public const int BaihuaMelanpsycheArrivedEventTriggered = 352;

		public const int BaihuaSelectDenounceSuperstitious = 353;

		public const int BaihuaAdventureFourAppearDate = 354;

		public const int BaihuaAnonymTaiwuIsMale = 355;

		public const int BaihuaDreamAboutPastLastTriggered = 356;

		public const int BaihuaDreamAboutPastLastDate = 357;

		public const int BaihuaLeMeMeetTaiwuId = 358;

		public const int BaihuaLeukoKillsMonthEventTriggered = 359;

		public const int BaihuaLeukoKillsMonthEventSettlementId = 360;

		public const int BaihuaLeukoKillsMonthEventSettlementIdLock = 361;

		public const int BaihuaLeukoKillsInteractOpen = 362;

		public const int BaihuaLeukoKillsCalledCharIds = 363;

		public const int BaihuaLeukoKillsFiveElementsType = 364;

		public const int BaihuaLeukoKillsOptionSelectDate = 365;

		public const int BaihuaLeukoKillsCombatWin = 366;

		public const int BaihuaMelanoKillsMonthEventTriggered = 367;

		public const int BaihuaMelanoKillsMonthEventSettlementId = 368;

		public const int BaihuaMelanoKillsMonthEventSettlementIdLock = 369;

		public const int BaihuaMelanoKillsInteractOpen = 370;

		public const int BaihuaMelanoKillsCalledCharIds = 371;

		public const int BaihuaMelanoKillsFiveElementsType = 372;

		public const int BaihuaMelanoKillsOptionSelectDate = 373;

		public const int BaihuaMelanoKillsCombatWin = 374;

		public const int BaihuaSpecialDebuffIntList = 375;

		public const int BaihuaCureSpecialDebuffIntList = 376;

		public const int BaihuaAnimalsBackDate = 377;

		public const int BaihuaLeukoAssistedMelano = 378;

		public const int BaihuaMelanoAssistedLeuko = 379;

		public const int BaihuaManicLowDate = 380;

		public const int BaihuaManicHighDate = 381;

		public const int BaihuaTriggerFinaleTaskDate = 382;

		public const int BaihuaBaiLuFirstInteractTriggered = 383;

		public const int BaihuaXuanXiaoFirstInteractTriggered = 384;

		public const int BaihuaAdventureFinialWinSect = 385;

		public const int BaihuaLeukoDialogNotTriggered = 386;

		public const int BaihuaMelanoDialogNotTriggered = 387;

		public const int BaihuaLeukoPlayCount = 388;

		public const int BaihuaMelanoPlayCount = 389;

		public const int BaihuaLMPlayCount = 390;

		public const int BaihuaLMNewsTalkedCharIds = 391;

		public const int BaihuaLMTransferAnimalDate = 392;

		public const int BaihuaFixedLMFavor = 393;

		public const int FulongDisasterStart = 394;

		public const int FulongDisasterMonthlyEventTriggered = 395;

		public const int FulongDisasterStartProb = 396;

		public const int FulongFireFightingGuideTriggered = 397;

		public const int FulongAdventureOneCountDown = 398;

		public const int FulongAdventureThreeCountDown = 399;

		public const int FulongAdventureStartTime = 400;

		public const int FulongAdventureTwoTaiwuId = 401;

		public const int FulongShadowEventTriggeredCount = 402;

		public const int FulongShadowEventOneTriggered = 403;

		public const int FulongShadowEventTwoTriggered = 404;

		public const int FulongReudhLazuliChatMysteryOpen = 405;

		public const int FulongReudhLazuliChatMysteryCount = 406;

		public const int FulongReudhLazuliAI2 = 407;

		public const int FulongTravelWithLazuliWorldViewTriggered = 408;

		public const int FulongSpecialInteractOpen = 409;

		public const int FulongTravelWithLazuliCityTriggered = 410;

		public const int FulongTravelWithLazuliTaiwuVillageTriggered = 411;

		public const int FulongTravelWithLazuliSectTriggered = 412;

		public const int FulongTravelWithLazuliTownTriggered = 413;

		public const int FulongTravelWithLazuliStockadeTriggered = 414;

		public const int FulongTravelWithLazuliVillageTriggered = 415;

		public const int FulongTravelWithLazuliXiangshuMinionTriggered = 416;

		public const int FulongTravelWithLazuliAnimalTriggered = 417;

		public const int FulongTravelWithLazuliRandomEnemyTriggered = 418;

		public const int FulongTravelWithLazuliMonvTalkTriggered = 419;

		public const int FulongTravelWithLazuliMoveCount = 420;

		public const int FulongChickenKingLetterMoveCount = 421;

		public const int FulongTravelWithLazuliMoveAreaId = 422;

		public const int FulongTravelWithLazuliChicken1 = 423;

		public const int FulongTravelWithLazuliChicken2 = 424;

		public const int FulongTravelWithLazuliFinished = 425;

		public const int FulongLazuliIsFriend = 426;

		public const int FulongSelectFalling = 427;

		public const int FulongSelectFallingDate = 428;

		public const int FulongReudhLazuliFeatherFollowOpen = 429;

		public const int FulongMessengerAppearTime = 430;

		public const int FulongLoseChickenFeatherInteractionSettlements = 431;

		public const int FulongLazuliLetterTriggered = 432;

		public const int FulongLazuliLetterEventA = 433;

		public const int FulongLazuliLetterEventB = 434;

		public const int FulongLazuliLetterEventC = 435;

		public const int FulongPutOutFireCount = 436;

		public const int FulongFireStartTime = 437;

		public const int FulongPutOutFire = 438;

		public const int FulongPutOutFireOnce = 439;

		public const int FulongChickenFeatherLackCount = 440;

		public const int FulongLazuliFindFlowerDialogLevel = 441;

		public const int FulongStayWithLazuliTaskTriggerDate = 442;

		public const int FulongMessengerIdList = 443;

		public const int FulongChickenKingLeaveHome = 444;

		public const int FulongChickenFeatherDropList = 445;

		public const int ZhujianCatchThiefTimes = 446;

		public const int EmeiStrangerTriggerDate = 447;

		public const int EmeiInteractionOneTriggeredList = 448;

		public const int EmeiInteractionTwoTriggeredList = 449;

		public const int EmeiFirstMonthlyEventTriggered = 450;

		public const int XuehouKillJixi = 451;
	}

	public static class DefValue
	{
		public static SectMainStoryEventArgKeyItem IsKillLiaoWuming => Instance[0];

		public static SectMainStoryEventArgKeyItem IsKilledByLiaoWuming => Instance[1];

		public static SectMainStoryEventArgKeyItem LiaoWumingQuestStartDate => Instance[2];

		public static SectMainStoryEventArgKeyItem LiaoWumingGetPoison => Instance[3];

		public static SectMainStoryEventArgKeyItem TheNameGivePoisonToLiaoWuming => Instance[4];

		public static SectMainStoryEventArgKeyItem KongsangAdventureCountDown => Instance[5];

		public static SectMainStoryEventArgKeyItem GetKongsangInformation1 => Instance[6];

		public static SectMainStoryEventArgKeyItem GetKongsangInformation2 => Instance[7];

		public static SectMainStoryEventArgKeyItem InteractWithLiaoWumingAi2 => Instance[8];

		public static SectMainStoryEventArgKeyItem KongsangAcceptTaskTaiwuId => Instance[9];

		public static SectMainStoryEventArgKeyItem KongsangFirstPassingLegacyTaiwuId => Instance[10];

		public static SectMainStoryEventArgKeyItem KongsangFirstPassingLegacyDialogTriggered => Instance[11];

		public static SectMainStoryEventArgKeyItem KongsangSecondPassingLegacyDialogCharId => Instance[12];

		public static SectMainStoryEventArgKeyItem KongsangStoryPartOneTriggered => Instance[13];

		public static SectMainStoryEventArgKeyItem KongsangPart3TaiwuId => Instance[14];

		public static SectMainStoryEventArgKeyItem FirstTryPoisonIsFailure => Instance[15];

		public static SectMainStoryEventArgKeyItem SecondTryPoisonIsFailure => Instance[16];

		public static SectMainStoryEventArgKeyItem ThirdTryPoisonIsFailure => Instance[17];

		public static SectMainStoryEventArgKeyItem TripodVesselOfMedicineAreaId => Instance[18];

		public static SectMainStoryEventArgKeyItem ActingHeadActorData => Instance[19];

		public static SectMainStoryEventArgKeyItem KongsangSectLeaderId => Instance[20];

		public static SectMainStoryEventArgKeyItem BeforePoisonTest0EventTriggered => Instance[21];

		public static SectMainStoryEventArgKeyItem BeforePoisonTest0EventFirstTriggered => Instance[22];

		public static SectMainStoryEventArgKeyItem BeforePoisonTest1EventTriggered => Instance[23];

		public static SectMainStoryEventArgKeyItem MissionUnacceptedEventTriggeredSameMonth => Instance[24];

		public static SectMainStoryEventArgKeyItem KongsangTargetFoundEventTriggered => Instance[25];

		public static SectMainStoryEventArgKeyItem XuehouStoryPartOneTriggered => Instance[26];

		public static SectMainStoryEventArgKeyItem StillAtYangzhou => Instance[27];

		public static SectMainStoryEventArgKeyItem FirstGotBellTime => Instance[28];

		public static SectMainStoryEventArgKeyItem MeetSkeletonWithBellExtraProb => Instance[29];

		public static SectMainStoryEventArgKeyItem XuehouGraveDiggingEventTriggered => Instance[30];

		public static SectMainStoryEventArgKeyItem DefeatXuehouOldManTime => Instance[31];

		public static SectMainStoryEventArgKeyItem GiveBellToXuehouOldManTime => Instance[32];

		public static SectMainStoryEventArgKeyItem XuehouOldManGraveDisappearTriggered => Instance[33];

		public static SectMainStoryEventArgKeyItem XuehouOldManCharacterId => Instance[34];

		public static SectMainStoryEventArgKeyItem OldManZombieInteractTriggered => Instance[35];

		public static SectMainStoryEventArgKeyItem AwakeJixiTaiwuId => Instance[36];

		public static SectMainStoryEventArgKeyItem AwakeJixiTaiwuGender => Instance[37];

		public static SectMainStoryEventArgKeyItem AwakeJixiAndPassLegacy => Instance[38];

		public static SectMainStoryEventArgKeyItem PassXuehouAdventure1Time => Instance[39];

		public static SectMainStoryEventArgKeyItem XuehouEmptyCaveTriggered => Instance[40];

		public static SectMainStoryEventArgKeyItem XuehouFindPeopleTriggered => Instance[41];

		public static SectMainStoryEventArgKeyItem XuehouComingTime => Instance[42];

		public static SectMainStoryEventArgKeyItem XuehouComingTriggeredCount => Instance[43];

		public static SectMainStoryEventArgKeyItem JixiArrivedTaiwuDate => Instance[44];

		public static SectMainStoryEventArgKeyItem JixiArrivedTaiwuMonthlyEventTriggeredCount => Instance[45];

		public static SectMainStoryEventArgKeyItem JixiAdventureOnePassDate => Instance[46];

		public static SectMainStoryEventArgKeyItem JixiAdventureTwoPassDate => Instance[47];

		public static SectMainStoryEventArgKeyItem JixiAdventureThreePassDate => Instance[48];

		public static SectMainStoryEventArgKeyItem JixiAdventureOneStartDate => Instance[49];

		public static SectMainStoryEventArgKeyItem JixiAdventureTwoStartDate => Instance[50];

		public static SectMainStoryEventArgKeyItem JixiAdventureThreeStartDate => Instance[51];

		public static SectMainStoryEventArgKeyItem JixiAdventureFourStartDate => Instance[52];

		public static SectMainStoryEventArgKeyItem ProtectedJixiEventTriggered => Instance[53];

		public static SectMainStoryEventArgKeyItem JixiFeedChickenEventTriggered => Instance[54];

		public static SectMainStoryEventArgKeyItem JixiHarmVillagerEventTriggered => Instance[55];

		public static SectMainStoryEventArgKeyItem HaveJixiTruthClueCount => Instance[56];

		public static SectMainStoryEventArgKeyItem HaveJixiFalseClueCount => Instance[57];

		public static SectMainStoryEventArgKeyItem JixiWaitingMonthKey => Instance[58];

		public static SectMainStoryEventArgKeyItem JixiStayAtGraveMonthKey => Instance[59];

		public static SectMainStoryEventArgKeyItem JixiKilledCountKey => Instance[60];

		public static SectMainStoryEventArgKeyItem CombatWithUltimateZombieTriggered => Instance[61];

		public static SectMainStoryEventArgKeyItem JixiLegacyPassFirstTalkTriggered => Instance[62];

		public static SectMainStoryEventArgKeyItem JixiSoulTransformFirstTalkTriggered => Instance[63];

		public static SectMainStoryEventArgKeyItem PassLegacyMonthlyNotificationTriggered => Instance[64];

		public static SectMainStoryEventArgKeyItem NeedTriggerPassLegacyMonthlyNotification => Instance[65];

		public static SectMainStoryEventArgKeyItem XuehouOldManHasBell => Instance[66];

		public static SectMainStoryEventArgKeyItem JixiHasAntiqueJadeBat => Instance[67];

		public static SectMainStoryEventArgKeyItem JixiHasAntiqueJadeFox => Instance[68];

		public static SectMainStoryEventArgKeyItem JixiHasAntiqueJadeButterfly => Instance[69];

		public static SectMainStoryEventArgKeyItem JixiFavorite1TalkTriggered => Instance[70];

		public static SectMainStoryEventArgKeyItem JixiFavorite2TalkTriggered => Instance[71];

		public static SectMainStoryEventArgKeyItem JixiFavorite3TalkTriggered => Instance[72];

		public static SectMainStoryEventArgKeyItem JixiFavorite4TalkTriggered => Instance[73];

		public static SectMainStoryEventArgKeyItem JixiFavorite5TalkTriggered => Instance[74];

		public static SectMainStoryEventArgKeyItem JixiLikeKillTalkTriggered => Instance[75];

		public static SectMainStoryEventArgKeyItem JixiPassLegacyTalkTriggered => Instance[76];

		public static SectMainStoryEventArgKeyItem JixiKillEnemyTalkTriggered => Instance[77];

		public static SectMainStoryEventArgKeyItem JixiKilledEnemy => Instance[78];

		public static SectMainStoryEventArgKeyItem JixiFollowOpen => Instance[79];

		public static SectMainStoryEventArgKeyItem XuehouSelectFreeJixi => Instance[80];

		public static SectMainStoryEventArgKeyItem XuehouGraveDiggingNormalTriggerTime => Instance[81];

		public static SectMainStoryEventArgKeyItem JixiAnimalTalkOpen => Instance[82];

		public static SectMainStoryEventArgKeyItem XuannvStoryTriggerFirstTrack => Instance[83];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneTriggered => Instance[84];

		public static SectMainStoryEventArgKeyItem XuannvStoryTaiwuCharId => Instance[85];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneIsReceivingLetter => Instance[86];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneLetterCountA => Instance[87];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneLetterCountB => Instance[88];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneLetterCountC => Instance[89];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneOptionMarkKey => Instance[90];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneLegendaryDoctor => Instance[91];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneWaitSecretGuestEvent => Instance[92];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneSecretGuestActorKey => Instance[93];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneGuessGenderKey => Instance[94];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneOptionInjectFlag => Instance[95];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneNoneSectNpcInquireSecretGuest1 => Instance[96];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneNoneSectNpcInquireSecretGuest2 => Instance[97];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartOneNoneSectNpcInquireSecretGuest3 => Instance[98];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartTwoOptionInjectFlag => Instance[99];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartTwoCombatSkillType => Instance[100];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLearningSkill => Instance[101];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLearningSkillId0 => Instance[102];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLearningSkillId1 => Instance[103];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLearningSkillId2 => Instance[104];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartTwoRefuseToHelpCount => Instance[105];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeSearchLoverCount => Instance[106];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeSearchLoverSecondTakeLoverDate => Instance[107];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLoverReincarnateSettlementId1 => Instance[108];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLoverReincarnateSettlementId2 => Instance[109];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLoverReincarnateSettlementId3 => Instance[110];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeLoverReincarnateLocation => Instance[111];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeWaitLoverNameKey => Instance[112];

		public static SectMainStoryEventArgKeyItem XuannvStoryMonthlyEventWithSisterTriggered => Instance[113];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeHasTalkToShiWeizhi => Instance[114];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeActorSisterOfShiWeizhi => Instance[115];

		public static SectMainStoryEventArgKeyItem XuannvStoryPartThreeGirlGodIllusion => Instance[116];

		public static SectMainStoryEventArgKeyItem XuannvStoryOptionReadFlag1 => Instance[117];

		public static SectMainStoryEventArgKeyItem XuannvStoryOptionReadFlag2 => Instance[118];

		public static SectMainStoryEventArgKeyItem XuannvStoryOptionReadFlag3 => Instance[119];

		public static SectMainStoryEventArgKeyItem XuannvStoryOptionReadFlag4 => Instance[120];

		public static SectMainStoryEventArgKeyItem XuannvStoryHeYouyuanCharId => Instance[121];

		public static SectMainStoryEventArgKeyItem XuannvStorySecretReincarnationNpcCharId => Instance[122];

		public static SectMainStoryEventArgKeyItem XuannvStoryIsJunerAtXuannvSect => Instance[123];

		public static SectMainStoryEventArgKeyItem XuannvStoryMusicUnlock10FirstFlag => Instance[124];

		public static SectMainStoryEventArgKeyItem XuannvStoryMusicUnlock40FirstFlag => Instance[125];

		public static SectMainStoryEventArgKeyItem XuannvStoryMusicUnlock45MusicWeaponFlag => Instance[126];

		public static SectMainStoryEventArgKeyItem XuannvLastDateOfAdventureIllusionOfMirror => Instance[127];

		public static SectMainStoryEventArgKeyItem ShaolinMythinLowMemberTalked => Instance[128];

		public static SectMainStoryEventArgKeyItem ShaolinMythinMiddleMemberTalked => Instance[129];

		public static SectMainStoryEventArgKeyItem ShaolinStatueReturnTriggered => Instance[130];

		public static SectMainStoryEventArgKeyItem ShaolinMonthlyEventNotEnoughDate => Instance[131];

		public static SectMainStoryEventArgKeyItem DamoDreamMeetTaiwuId => Instance[132];

		public static SectMainStoryEventArgKeyItem ShaolinCombatSkillType => Instance[133];

		public static SectMainStoryEventArgKeyItem ShaolinLearnedAny => Instance[134];

		public static SectMainStoryEventArgKeyItem ShaolinDamoFightTimes => Instance[135];

		public static SectMainStoryEventArgKeyItem ShaolinDamoFightWinDate => Instance[136];

		public static SectMainStoryEventArgKeyItem ShaolinStudyForBodhidharmaChallenge => Instance[137];

		public static SectMainStoryEventArgKeyItem ShaolinDamoTrialTriggered => Instance[138];

		public static SectMainStoryEventArgKeyItem ShaolinDamoFightTriggered => Instance[139];

		public static SectMainStoryEventArgKeyItem ShaolinDamoVisitTimes => Instance[140];

		public static SectMainStoryEventArgKeyItem ShaolinReadingMaxGradeSutra => Instance[141];

		public static SectMainStoryEventArgKeyItem ShaolinSutraPavilionGuardDate => Instance[142];

		public static SectMainStoryEventArgKeyItem ShaolinDamoLearnedFightTimes => Instance[143];

		public static SectMainStoryEventArgKeyItem ShaolinComprehendedTheZen => Instance[144];

		public static SectMainStoryEventArgKeyItem ShaolinMeditationInteractionFinished => Instance[145];

		public static SectMainStoryEventArgKeyItem ShaolinInteractionChangeTip1Triggered => Instance[146];

		public static SectMainStoryEventArgKeyItem ShaolinInteractionChangeTip2Triggered => Instance[147];

		public static SectMainStoryEventArgKeyItem WudangSkillReverseBreakCount => Instance[148];

		public static SectMainStoryEventArgKeyItem CombatWithTaoistMonkDate => Instance[149];

		public static SectMainStoryEventArgKeyItem CombatWithTaoistMonkTaiwuName => Instance[150];

		public static SectMainStoryEventArgKeyItem AtLastCombatWithTaoistMonkTaiwuName => Instance[151];

		public static SectMainStoryEventArgKeyItem BlackSnakeCustomName => Instance[152];

		public static SectMainStoryEventArgKeyItem GiveTaoistTreasureCount => Instance[153];

		public static SectMainStoryEventArgKeyItem GiveTaoistTreasureItemKey => Instance[154];

		public static SectMainStoryEventArgKeyItem WudangChatEventTriggeredCount => Instance[155];

		public static SectMainStoryEventArgKeyItem WudangSankeFighted => Instance[156];

		public static SectMainStoryEventArgKeyItem WudangFrontEventTriggered => Instance[157];

		public static SectMainStoryEventArgKeyItem LastEventSloppyTaoistMonkFavor => Instance[158];

		public static SectMainStoryEventArgKeyItem GetExtraSeedCount => Instance[159];

		public static SectMainStoryEventArgKeyItem FinishFairylandStoryCount => Instance[160];

		public static SectMainStoryEventArgKeyItem TriggeredFailureEvent => Instance[161];

		public static SectMainStoryEventArgKeyItem WudangKillRandomEnemyTriggered => Instance[162];

		public static SectMainStoryEventArgKeyItem GivenMonkSnakeItemKey => Instance[163];

		public static SectMainStoryEventArgKeyItem GivenMonkSnakeList => Instance[164];

		public static SectMainStoryEventArgKeyItem WudangEasterEggTriggered => Instance[165];

		public static SectMainStoryEventArgKeyItem WudangHeavenlyTreeSeedTalkTriggered => Instance[166];

		public static SectMainStoryEventArgKeyItem WudangFairylandTalkTriggered => Instance[167];

		public static SectMainStoryEventArgKeyItem WudangTortoiseSnakeTalkTriggered => Instance[168];

		public static SectMainStoryEventArgKeyItem WudangEmperorTalkTriggered => Instance[169];

		public static SectMainStoryEventArgKeyItem MeetImmortalEventCount => Instance[170];

		public static SectMainStoryEventArgKeyItem CollectHeavenlyTreeSeedFirstTriggered => Instance[171];

		public static SectMainStoryEventArgKeyItem YuanshanDemonOutOfJail => Instance[172];

		public static SectMainStoryEventArgKeyItem TaiwuReleasedYuanshanDemon => Instance[173];

		public static SectMainStoryEventArgKeyItem YuanshanLeaderFirmDate => Instance[174];

		public static SectMainStoryEventArgKeyItem YuanshanDemonDormantDate => Instance[175];

		public static SectMainStoryEventArgKeyItem MythInYuanshanTriggeredDate => Instance[176];

		public static SectMainStoryEventArgKeyItem YuanshanInteractionTriggeredCount => Instance[177];

		public static SectMainStoryEventArgKeyItem YuanshanThoughtsTriggeredCount => Instance[178];

		public static SectMainStoryEventArgKeyItem YuanshanThoughtsInteractable => Instance[179];

		public static SectMainStoryEventArgKeyItem YuanshanLobbyTalkInteractable => Instance[180];

		public static SectMainStoryEventArgKeyItem YuanshanDemonPower => Instance[181];

		public static SectMainStoryEventArgKeyItem KilledYuanshanDemonCount => Instance[182];

		public static SectMainStoryEventArgKeyItem YuanshanCaelumDemonDefeatedTaiwu => Instance[183];

		public static SectMainStoryEventArgKeyItem YuanshanTerraDemonDefeatedTaiwu => Instance[184];

		public static SectMainStoryEventArgKeyItem YuanshanAnthropDemonDefeatedTaiwu => Instance[185];

		public static SectMainStoryEventArgKeyItem YuanshanDemonMeetTaiwuCharId => Instance[186];

		public static SectMainStoryEventArgKeyItem YuanshanDemonLast => Instance[187];

		public static SectMainStoryEventArgKeyItem YuanshanToFightDemon => Instance[188];

		public static SectMainStoryEventArgKeyItem YuanshanMiniGameStage => Instance[189];

		public static SectMainStoryEventArgKeyItem AreVitalsDemon => Instance[190];

		public static SectMainStoryEventArgKeyItem ShixiangAdventureAppearDate => Instance[191];

		public static SectMainStoryEventArgKeyItem ShixiangFirstLetterDate => Instance[192];

		public static SectMainStoryEventArgKeyItem ShixiangLetterCount => Instance[193];

		public static SectMainStoryEventArgKeyItem ShixiangToFightEnemy => Instance[194];

		public static SectMainStoryEventArgKeyItem MockShixiangEventTriggeredSettlementId => Instance[195];

		public static SectMainStoryEventArgKeyItem MockShixiangEventTriggered => Instance[196];

		public static SectMainStoryEventArgKeyItem MockShixiangEventCount => Instance[197];

		public static SectMainStoryEventArgKeyItem ShixiangStoryPartOneTriggered => Instance[198];

		public static SectMainStoryEventArgKeyItem ShixiangAdventureWon => Instance[199];

		public static SectMainStoryEventArgKeyItem TaiwuKillBarbarianMasterCount => Instance[200];

		public static SectMainStoryEventArgKeyItem ShixiangKillBarbarianMasterCount => Instance[201];

		public static SectMainStoryEventArgKeyItem TaiwuKillBarbarianMasterCount2 => Instance[202];

		public static SectMainStoryEventArgKeyItem ShixiangKillBarbarianMasterCount2 => Instance[203];

		public static SectMainStoryEventArgKeyItem ArriveLotusMountainEventTriggered => Instance[204];

		public static SectMainStoryEventArgKeyItem ArriveShixiangEventTriggered => Instance[205];

		public static SectMainStoryEventArgKeyItem StartFightShixiangTraitorsDate => Instance[206];

		public static SectMainStoryEventArgKeyItem FailFinishKillTraitorOnTime => Instance[207];

		public static SectMainStoryEventArgKeyItem SelectGoodEnd => Instance[208];

		public static SectMainStoryEventArgKeyItem LeikunAvatarData => Instance[209];

		public static SectMainStoryEventArgKeyItem KilledByLeiKunTaiwuName => Instance[210];

		public static SectMainStoryEventArgKeyItem ShixiangAdventureLiteratiCharId => Instance[211];

		public static SectMainStoryEventArgKeyItem EmeiSelectGoodEndCount => Instance[212];

		public static SectMainStoryEventArgKeyItem EmeiSelectBadEndCount => Instance[213];

		public static SectMainStoryEventArgKeyItem EmeiFourthSelectResult => Instance[214];

		public static SectMainStoryEventArgKeyItem WhiteApeBlockId => Instance[215];

		public static SectMainStoryEventArgKeyItem WhiteApeBlockIdTmpSave => Instance[216];

		public static SectMainStoryEventArgKeyItem HomocideCase0Time => Instance[217];

		public static SectMainStoryEventArgKeyItem HomocideCase1Time => Instance[218];

		public static SectMainStoryEventArgKeyItem HomocideCase0Triggered => Instance[219];

		public static SectMainStoryEventArgKeyItem HomocideCase1Triggered => Instance[220];

		public static SectMainStoryEventArgKeyItem HomocideCase2Triggered => Instance[221];

		public static SectMainStoryEventArgKeyItem EmeiRoleJia => Instance[222];

		public static SectMainStoryEventArgKeyItem EmeiRoleYi => Instance[223];

		public static SectMainStoryEventArgKeyItem EmeiRoleBing => Instance[224];

		public static SectMainStoryEventArgKeyItem EmeiRoleDing => Instance[225];

		public static SectMainStoryEventArgKeyItem EmeiRoleWu => Instance[226];

		public static SectMainStoryEventArgKeyItem EmeiRoleSi => Instance[227];

		public static SectMainStoryEventArgKeyItem EmeiRoleGeng => Instance[228];

		public static SectMainStoryEventArgKeyItem EmeiRoleXin => Instance[229];

		public static SectMainStoryEventArgKeyItem TaiwuJumpCliffInjuryType => Instance[230];

		public static SectMainStoryEventArgKeyItem EmeiKillEachOtherStage => Instance[231];

		public static SectMainStoryEventArgKeyItem EmeiHomocideCasesInteractionCount => Instance[232];

		public static SectMainStoryEventArgKeyItem EmeiEmeiHomocideCasesInteractionIds => Instance[233];

		public static SectMainStoryEventArgKeyItem FirstClickWhiteGibbonDate => Instance[234];

		public static SectMainStoryEventArgKeyItem SecondClickWhiteGibbonDate => Instance[235];

		public static SectMainStoryEventArgKeyItem ThirdClickWhiteGibbonDate => Instance[236];

		public static SectMainStoryEventArgKeyItem FourthClickWhiteGibbonDate => Instance[237];

		public static SectMainStoryEventArgKeyItem FifthClickWhiteGibbonDate => Instance[238];

		public static SectMainStoryEventArgKeyItem SixthClickWhiteGibbonDate => Instance[239];

		public static SectMainStoryEventArgKeyItem EmeiOptionReclusiveElderVisible => Instance[240];

		public static SectMainStoryEventArgKeyItem EmeiOptionWhoIsOrthodoxVisible => Instance[241];

		public static SectMainStoryEventArgKeyItem EmeiLeaderOriginalLocation => Instance[242];

		public static SectMainStoryEventArgKeyItem EmeiLeaderOriginalId => Instance[243];

		public static SectMainStoryEventArgKeyItem EmeiAdventureTwoAppearDate => Instance[244];

		public static SectMainStoryEventArgKeyItem EmeiEnterAdventureTwo => Instance[245];

		public static SectMainStoryEventArgKeyItem EmeiPassAdventureTwoTaiwuId => Instance[246];

		public static SectMainStoryEventArgKeyItem EmeiAdventureTwoPathEventTriggerCount => Instance[247];

		public static SectMainStoryEventArgKeyItem EmeiSelectGiveUpTrace => Instance[248];

		public static SectMainStoryEventArgKeyItem EmeiDefeatShiHoujiu => Instance[249];

		public static SectMainStoryEventArgKeyItem EmeiWhiteGibbonFollowOpen => Instance[250];

		public static SectMainStoryEventArgKeyItem EmeiShiHoujiuFollowOpen => Instance[251];

		public static SectMainStoryEventArgKeyItem EmeiBreakBonusRefreshTimes => Instance[252];

		public static SectMainStoryEventArgKeyItem EmeiBreakBonusSaved => Instance[253];

		public static SectMainStoryEventArgKeyItem EmeiBreakBonusTemplateIds => Instance[254];

		public static SectMainStoryEventArgKeyItem EmeiBreakBonusExtraPoints => Instance[255];

		public static SectMainStoryEventArgKeyItem EmeiGiveInShiHoujiu => Instance[256];

		public static SectMainStoryEventArgKeyItem WuxianPrologueWugEventRecord => Instance[257];

		public static SectMainStoryEventArgKeyItem WuxianPrologueTaiwuId => Instance[258];

		public static SectMainStoryEventArgKeyItem WuxianPrologueAddedWug => Instance[259];

		public static SectMainStoryEventArgKeyItem WuxianPrologueWugAttacked => Instance[260];

		public static SectMainStoryEventArgKeyItem WuxianChapter1VisitCount => Instance[261];

		public static SectMainStoryEventArgKeyItem WuxianChapter1Wish1 => Instance[262];

		public static SectMainStoryEventArgKeyItem WuxianChapter1Wish2 => Instance[263];

		public static SectMainStoryEventArgKeyItem WuxianChapter1Wish3 => Instance[264];

		public static SectMainStoryEventArgKeyItem WuxianChapter1WishCount => Instance[265];

		public static SectMainStoryEventArgKeyItem WuxianChapter1WishComeTrueCount => Instance[266];

		public static SectMainStoryEventArgKeyItem WuxianChapter1Refused => Instance[267];

		public static SectMainStoryEventArgKeyItem WuxianChapter1RanXinduLocation => Instance[268];

		public static SectMainStoryEventArgKeyItem WuxianChapter2Adventure1Selection => Instance[269];

		public static SectMainStoryEventArgKeyItem WuxianChapter2Adventure2Selection => Instance[270];

		public static SectMainStoryEventArgKeyItem WuxianChapter3AbleToStart => Instance[271];

		public static SectMainStoryEventArgKeyItem WuxianChapter3MailReceivedCount => Instance[272];

		public static SectMainStoryEventArgKeyItem WuxianChapter4AdventureComplete => Instance[273];

		public static SectMainStoryEventArgKeyItem WuxianChapter4FinalBossBeaten => Instance[274];

		public static SectMainStoryEventArgKeyItem WuxianChapter4HappyEndingEventDate => Instance[275];

		public static SectMainStoryEventArgKeyItem WuxianChapter4EndingEventTriggered => Instance[276];

		public static SectMainStoryEventArgKeyItem WuxianPassLegacyEventTriggered => Instance[277];

		public static SectMainStoryEventArgKeyItem JingangMonkMurderedTriggeredDate => Instance[278];

		public static SectMainStoryEventArgKeyItem JingangAfterMonkMurderedTriggeredMoveCount => Instance[279];

		public static SectMainStoryEventArgKeyItem JingangGiveVillagerFood => Instance[280];

		public static SectMainStoryEventArgKeyItem JingangGiveVillagerFoodEventTriggered => Instance[281];

		public static SectMainStoryEventArgKeyItem JingangGiveVillagerFoodActorData => Instance[282];

		public static SectMainStoryEventArgKeyItem JingangGiveVillagerMoney => Instance[283];

		public static SectMainStoryEventArgKeyItem JingangGiveVillagerMoneyEventTriggered => Instance[284];

		public static SectMainStoryEventArgKeyItem JingangGiveVillagerMoneyActorData => Instance[285];

		public static SectMainStoryEventArgKeyItem JingangGiveVillagerPromise => Instance[286];

		public static SectMainStoryEventArgKeyItem JingangGiveVillagerPromiseEventTriggered => Instance[287];

		public static SectMainStoryEventArgKeyItem JingangGiveVillagerHelp => Instance[288];

		public static SectMainStoryEventArgKeyItem JingangGiveVillagerHelpEventTriggered => Instance[289];

		public static SectMainStoryEventArgKeyItem JingangGiveVillagerHelpActorData => Instance[290];

		public static SectMainStoryEventArgKeyItem JingangPersuadeVillagerCount => Instance[291];

		public static SectMainStoryEventArgKeyItem JingangTriggeredPeopleSufferingCount => Instance[292];

		public static SectMainStoryEventArgKeyItem JingangTriggeredInteractionVillagers => Instance[293];

		public static SectMainStoryEventArgKeyItem JingangTriggerMonthlyEventVillagerSuffer => Instance[294];

		public static SectMainStoryEventArgKeyItem JingangMonthlyEventVillagerEscapeTriggered => Instance[295];

		public static SectMainStoryEventArgKeyItem JingangAdventureNearestSettlementId => Instance[296];

		public static SectMainStoryEventArgKeyItem JingangSecInfoSpreadingSelectCombat => Instance[297];

		public static SectMainStoryEventArgKeyItem JingangCreateCentralPlainsMonkTaiwuAreaId => Instance[298];

		public static SectMainStoryEventArgKeyItem JingangKnowSecInfoIdList => Instance[299];

		public static SectMainStoryEventArgKeyItem JingangSpreadSecInfoTotalCount => Instance[300];

		public static SectMainStoryEventArgKeyItem JingangMonkSoulEnterDreamCount => Instance[301];

		public static SectMainStoryEventArgKeyItem JingangSamsaraMonkSoulDreamTalkCount => Instance[302];

		public static SectMainStoryEventArgKeyItem JingangSecInfoMetaDataId => Instance[303];

		public static SectMainStoryEventArgKeyItem JingangSecInfoOccurenceId => Instance[304];

		public static SectMainStoryEventArgKeyItem JingangTalkedCentralPlainsMonkId => Instance[305];

		public static SectMainStoryEventArgKeyItem JingangSamsaraMonkSoulTalked => Instance[306];

		public static SectMainStoryEventArgKeyItem JingangSamsaraMonkSoulTalkSelectBehavior => Instance[307];

		public static SectMainStoryEventArgKeyItem JingangAttackDate => Instance[308];

		public static SectMainStoryEventArgKeyItem JingangFamousFakeMonkDate => Instance[309];

		public static SectMainStoryEventArgKeyItem JingangPrayDate => Instance[310];

		public static SectMainStoryEventArgKeyItem JingangLettersFromJingangDate => Instance[311];

		public static SectMainStoryEventArgKeyItem JingangFameDistributionDate => Instance[312];

		public static SectMainStoryEventArgKeyItem JingangPietyCount => Instance[313];

		public static SectMainStoryEventArgKeyItem JingangSelectHelpWestMonk => Instance[314];

		public static SectMainStoryEventArgKeyItem JingangSecInfoSpreadingSelectBetray => Instance[315];

		public static SectMainStoryEventArgKeyItem JingangHelpMonkEndSelectOption => Instance[316];

		public static SectMainStoryEventArgKeyItem JingangMonkSoulBtnDisappear => Instance[317];

		public static SectMainStoryEventArgKeyItem JingangDefeatShmashanaAdhipati => Instance[318];

		public static SectMainStoryEventArgKeyItem JingangMonkReincarnationTriggered => Instance[319];

		public static SectMainStoryEventArgKeyItem JingangMonkGhostVanishesTriggered => Instance[320];

		public static SectMainStoryEventArgKeyItem JingangEndPartOneRefuseGiveSutra => Instance[321];

		public static SectMainStoryEventArgKeyItem JingangWesternBuddhistMonkTalkOneTriggered => Instance[322];

		public static SectMainStoryEventArgKeyItem JingangWesternBuddhistMonkTalkTwoTriggered => Instance[323];

		public static SectMainStoryEventArgKeyItem JingangWesternBuddhistMonkTalkThreeTriggered => Instance[324];

		public static SectMainStoryEventArgKeyItem JingangWesternBuddhistMonkPassLegacyTaiwuId => Instance[325];

		public static SectMainStoryEventArgKeyItem JingangImpersonatorBuddhistMonkPassLegacyTaiwuId => Instance[326];

		public static SectMainStoryEventArgKeyItem JingangStillAtJingang => Instance[327];

		public static SectMainStoryEventArgKeyItem JingangFinishSecondSpreadSutra => Instance[328];

		public static SectMainStoryEventArgKeyItem JingangTriggeredChapter1Patch => Instance[329];

		public static SectMainStoryEventArgKeyItem JingangMonkSoulResolveDreamCount => Instance[330];

		public static SectMainStoryEventArgKeyItem JingangMonkSoulResolveDreamChatCount => Instance[331];

		public static SectMainStoryEventArgKeyItem JingangGiveFakeBook => Instance[332];

		public static SectMainStoryEventArgKeyItem JingangHelpSect => Instance[333];

		public static SectMainStoryEventArgKeyItem RanshanSpecialInteractionToggle => Instance[334];

		public static SectMainStoryEventArgKeyItem RanshanChapter1MonthlyEventTriggeredCount => Instance[335];

		public static SectMainStoryEventArgKeyItem RanshanChapter1MonthlyEventTriggeredDate => Instance[336];

		public static SectMainStoryEventArgKeyItem RanshanChapter2TeachStartDate => Instance[337];

		public static SectMainStoryEventArgKeyItem RanshanChapter2HuajuCombatPlayDecision => Instance[338];

		public static SectMainStoryEventArgKeyItem RanshanChapter2XuanzhiCombatPlayDecision => Instance[339];

		public static SectMainStoryEventArgKeyItem RanshanChapter2YingjiaoCombatPlayDecision => Instance[340];

		public static SectMainStoryEventArgKeyItem RanshanChapter2HuajuCombatPlayDate => Instance[341];

		public static SectMainStoryEventArgKeyItem RanshanChapter2XuanzhiCombatPlayDate => Instance[342];

		public static SectMainStoryEventArgKeyItem RanshanChapter2YingjiaoCombatPlayDate => Instance[343];

		public static SectMainStoryEventArgKeyItem RanshanChapter2YingjiaoSelection1 => Instance[344];

		public static SectMainStoryEventArgKeyItem RanshanChapter2YingjiaoSelection2 => Instance[345];

		public static SectMainStoryEventArgKeyItem RanshanSanZongBiWuCountDown => Instance[346];

		public static SectMainStoryEventArgKeyItem RanshanChapter3WillingToBeImmortal => Instance[347];

		public static SectMainStoryEventArgKeyItem BaihuaVillageSettlementIdSelection => Instance[348];

		public static SectMainStoryEventArgKeyItem BaihuaEndenmicTriggered => Instance[349];

		public static SectMainStoryEventArgKeyItem BaihuaDreamAboutPastFirstTriggered => Instance[350];

		public static SectMainStoryEventArgKeyItem BaihuaLeukorpusArrivedEventTriggered => Instance[351];

		public static SectMainStoryEventArgKeyItem BaihuaMelanpsycheArrivedEventTriggered => Instance[352];

		public static SectMainStoryEventArgKeyItem BaihuaSelectDenounceSuperstitious => Instance[353];

		public static SectMainStoryEventArgKeyItem BaihuaAdventureFourAppearDate => Instance[354];

		public static SectMainStoryEventArgKeyItem BaihuaAnonymTaiwuIsMale => Instance[355];

		public static SectMainStoryEventArgKeyItem BaihuaDreamAboutPastLastTriggered => Instance[356];

		public static SectMainStoryEventArgKeyItem BaihuaDreamAboutPastLastDate => Instance[357];

		public static SectMainStoryEventArgKeyItem BaihuaLeMeMeetTaiwuId => Instance[358];

		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsMonthEventTriggered => Instance[359];

		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsMonthEventSettlementId => Instance[360];

		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsMonthEventSettlementIdLock => Instance[361];

		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsInteractOpen => Instance[362];

		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsCalledCharIds => Instance[363];

		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsFiveElementsType => Instance[364];

		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsOptionSelectDate => Instance[365];

		public static SectMainStoryEventArgKeyItem BaihuaLeukoKillsCombatWin => Instance[366];

		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsMonthEventTriggered => Instance[367];

		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsMonthEventSettlementId => Instance[368];

		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsMonthEventSettlementIdLock => Instance[369];

		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsInteractOpen => Instance[370];

		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsCalledCharIds => Instance[371];

		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsFiveElementsType => Instance[372];

		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsOptionSelectDate => Instance[373];

		public static SectMainStoryEventArgKeyItem BaihuaMelanoKillsCombatWin => Instance[374];

		public static SectMainStoryEventArgKeyItem BaihuaSpecialDebuffIntList => Instance[375];

		public static SectMainStoryEventArgKeyItem BaihuaCureSpecialDebuffIntList => Instance[376];

		public static SectMainStoryEventArgKeyItem BaihuaAnimalsBackDate => Instance[377];

		public static SectMainStoryEventArgKeyItem BaihuaLeukoAssistedMelano => Instance[378];

		public static SectMainStoryEventArgKeyItem BaihuaMelanoAssistedLeuko => Instance[379];

		public static SectMainStoryEventArgKeyItem BaihuaManicLowDate => Instance[380];

		public static SectMainStoryEventArgKeyItem BaihuaManicHighDate => Instance[381];

		public static SectMainStoryEventArgKeyItem BaihuaTriggerFinaleTaskDate => Instance[382];

		public static SectMainStoryEventArgKeyItem BaihuaBaiLuFirstInteractTriggered => Instance[383];

		public static SectMainStoryEventArgKeyItem BaihuaXuanXiaoFirstInteractTriggered => Instance[384];

		public static SectMainStoryEventArgKeyItem BaihuaAdventureFinialWinSect => Instance[385];

		public static SectMainStoryEventArgKeyItem BaihuaLeukoDialogNotTriggered => Instance[386];

		public static SectMainStoryEventArgKeyItem BaihuaMelanoDialogNotTriggered => Instance[387];

		public static SectMainStoryEventArgKeyItem BaihuaLeukoPlayCount => Instance[388];

		public static SectMainStoryEventArgKeyItem BaihuaMelanoPlayCount => Instance[389];

		public static SectMainStoryEventArgKeyItem BaihuaLMPlayCount => Instance[390];

		public static SectMainStoryEventArgKeyItem BaihuaLMNewsTalkedCharIds => Instance[391];

		public static SectMainStoryEventArgKeyItem BaihuaLMTransferAnimalDate => Instance[392];

		public static SectMainStoryEventArgKeyItem BaihuaFixedLMFavor => Instance[393];

		public static SectMainStoryEventArgKeyItem FulongDisasterStart => Instance[394];

		public static SectMainStoryEventArgKeyItem FulongDisasterMonthlyEventTriggered => Instance[395];

		public static SectMainStoryEventArgKeyItem FulongDisasterStartProb => Instance[396];

		public static SectMainStoryEventArgKeyItem FulongFireFightingGuideTriggered => Instance[397];

		public static SectMainStoryEventArgKeyItem FulongAdventureOneCountDown => Instance[398];

		public static SectMainStoryEventArgKeyItem FulongAdventureThreeCountDown => Instance[399];

		public static SectMainStoryEventArgKeyItem FulongAdventureStartTime => Instance[400];

		public static SectMainStoryEventArgKeyItem FulongAdventureTwoTaiwuId => Instance[401];

		public static SectMainStoryEventArgKeyItem FulongShadowEventTriggeredCount => Instance[402];

		public static SectMainStoryEventArgKeyItem FulongShadowEventOneTriggered => Instance[403];

		public static SectMainStoryEventArgKeyItem FulongShadowEventTwoTriggered => Instance[404];

		public static SectMainStoryEventArgKeyItem FulongReudhLazuliChatMysteryOpen => Instance[405];

		public static SectMainStoryEventArgKeyItem FulongReudhLazuliChatMysteryCount => Instance[406];

		public static SectMainStoryEventArgKeyItem FulongReudhLazuliAI2 => Instance[407];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliWorldViewTriggered => Instance[408];

		public static SectMainStoryEventArgKeyItem FulongSpecialInteractOpen => Instance[409];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliCityTriggered => Instance[410];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliTaiwuVillageTriggered => Instance[411];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliSectTriggered => Instance[412];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliTownTriggered => Instance[413];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliStockadeTriggered => Instance[414];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliVillageTriggered => Instance[415];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliXiangshuMinionTriggered => Instance[416];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliAnimalTriggered => Instance[417];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliRandomEnemyTriggered => Instance[418];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliMonvTalkTriggered => Instance[419];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliMoveCount => Instance[420];

		public static SectMainStoryEventArgKeyItem FulongChickenKingLetterMoveCount => Instance[421];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliMoveAreaId => Instance[422];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliChicken1 => Instance[423];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliChicken2 => Instance[424];

		public static SectMainStoryEventArgKeyItem FulongTravelWithLazuliFinished => Instance[425];

		public static SectMainStoryEventArgKeyItem FulongLazuliIsFriend => Instance[426];

		public static SectMainStoryEventArgKeyItem FulongSelectFalling => Instance[427];

		public static SectMainStoryEventArgKeyItem FulongSelectFallingDate => Instance[428];

		public static SectMainStoryEventArgKeyItem FulongReudhLazuliFeatherFollowOpen => Instance[429];

		public static SectMainStoryEventArgKeyItem FulongMessengerAppearTime => Instance[430];

		public static SectMainStoryEventArgKeyItem FulongLoseChickenFeatherInteractionSettlements => Instance[431];

		public static SectMainStoryEventArgKeyItem FulongLazuliLetterTriggered => Instance[432];

		public static SectMainStoryEventArgKeyItem FulongLazuliLetterEventA => Instance[433];

		public static SectMainStoryEventArgKeyItem FulongLazuliLetterEventB => Instance[434];

		public static SectMainStoryEventArgKeyItem FulongLazuliLetterEventC => Instance[435];

		public static SectMainStoryEventArgKeyItem FulongPutOutFireCount => Instance[436];

		public static SectMainStoryEventArgKeyItem FulongFireStartTime => Instance[437];

		public static SectMainStoryEventArgKeyItem FulongPutOutFire => Instance[438];

		public static SectMainStoryEventArgKeyItem FulongPutOutFireOnce => Instance[439];

		public static SectMainStoryEventArgKeyItem FulongChickenFeatherLackCount => Instance[440];

		public static SectMainStoryEventArgKeyItem FulongLazuliFindFlowerDialogLevel => Instance[441];

		public static SectMainStoryEventArgKeyItem FulongStayWithLazuliTaskTriggerDate => Instance[442];

		public static SectMainStoryEventArgKeyItem FulongMessengerIdList => Instance[443];

		public static SectMainStoryEventArgKeyItem FulongChickenKingLeaveHome => Instance[444];

		public static SectMainStoryEventArgKeyItem FulongChickenFeatherDropList => Instance[445];

		public static SectMainStoryEventArgKeyItem ZhujianCatchThiefTimes => Instance[446];

		public static SectMainStoryEventArgKeyItem EmeiStrangerTriggerDate => Instance[447];

		public static SectMainStoryEventArgKeyItem EmeiInteractionOneTriggeredList => Instance[448];

		public static SectMainStoryEventArgKeyItem EmeiInteractionTwoTriggeredList => Instance[449];

		public static SectMainStoryEventArgKeyItem EmeiFirstMonthlyEventTriggered => Instance[450];

		public static SectMainStoryEventArgKeyItem XuehouKillJixi => Instance[451];
	}

	public static SectMainStoryEventArgKey Instance = new SectMainStoryEventArgKey();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Sect", "TemplateId", "ArgBoxKey" };

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
		_dataArray.Add(new SectMainStoryEventArgKeyItem(0, 10, "ConchShip_PresetKey_IsKillLiaoWuming"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(1, 10, "ConchShip_PresetKey_IsKilledByLiaoWuming"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(2, 10, "ConchShip_PresetKey_LiaoWumingQuestStartDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(3, 10, "ConchShip_PresetKey_LiaoWumingGetPoison"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(4, 10, "ConchShip_PresetKey_TheNameGivePoisonToLiaoWuming"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(5, 10, "ConchShip_PresetKey_KongsangAdventureCountDown"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(6, 10, "ConchShip_PresetKey_GetKongsangInformation1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(7, 10, "ConchShip_PresetKey_GetKongsangInformation2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(8, 10, "ConchShip_PresetKey_InteractWithLiaoWumingAi2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(9, 10, "ConchShip_PresetKey_KongsangAcceptTaskTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(10, 10, "ConchShip_PresetKey_KongsangFirstPassingLegacyTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(11, 10, "ConchShip_PresetKey_KongsangFirstPassingLegacyDialogTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(12, 10, "ConchShip_PresetKey_KongsangSecondPassingLegacyDialogCharId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(13, 10, "ConchShip_PresetKey_KongsangStoryParyOneTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(14, 10, "ConchShip_PresetKey_KongsangPart3TaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(15, 10, "ConchShip_PresetKey_FirstTryPoisonIsFailure"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(16, 10, "ConchShip_PresetKey_SecondTryPoisonIsFailure"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(17, 10, "ConchShip_PresetKey_ThirdTryPoisonIsFailure"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(18, 10, "ConchShip_PresetKey_TripodVesselOfMedicineAreaId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(19, 10, "ConchShip_PresetKey_ActingHeadActorData"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(20, 10, "ConchShip_PresetKey_KongsangSectLeaderId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(21, 10, "ConchShip_PresetKey_BeforePoisonTest0EventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(22, 10, "ConchShip_PresetKey_BeforePoisonTest0EventFirstTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(23, 10, "ConchShip_PresetKey_BeforePoisonTest1EventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(24, 10, "ConchShip_PresetKey_MissionUnacceptedEventTriggeredSameMonth"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(25, 10, "ConchShip_PresetKey_KongsangTargetFoundEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(26, 15, "ConchShip_PresetKey_XuehouStoryPartOneTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(27, 15, "ConchShip_PresetKey_StillAtYangzhou"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(28, 15, "ConchShip_PresetKey_FirstGotBellTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(29, 15, "ConchShip_PresetKey_MeetSkeletonWithBellExtraProb"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(30, 15, "ConchShip_PresetKey_XuehouGraveDiggingEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(31, 15, "ConchShip_PresetKey_DefeatXuehouOldManTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(32, 15, "ConchShip_PresetKey_GiveBellToXuehouOldManTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(33, 15, "ConchShip_PresetKey_XuehouOldManGraveDisappearTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(34, 15, "ConchShip_PresetKey_XuehouOldManCharacterId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(35, 15, "ConchShip_PresetKey_OldManZombieInteractTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(36, 15, "ConchShip_PresetKey_AwakeJixiTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(37, 15, "ConchShip_PresetKey_AwakeJixiTaiwuGender"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(38, 15, "ConchShip_PresetKey_AwakeJixiAndPassLegacy"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(39, 15, "ConchShip_PresetKey_PassXuehouAdventure1Time"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(40, 15, "ConchShip_PresetKey_XuehouEmptyCaveTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(41, 15, "ConchShip_PresetKey_XuehouFindPeopleTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(42, 15, "ConchShip_PresetKey_XuehouComingTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(43, 15, "ConchShip_PresetKey_XuehouComingTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(44, 15, "ConchShip_PresetKey_JixiArrivedTaiwuDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(45, 15, "ConchShip_PresetKey_JixiArrivedTaiwuMonthlyEventTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(46, 15, "ConchShip_PresetKey_JixiAdventureOnePassDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(47, 15, "ConchShip_PresetKey_JixiAdventureTwoPassDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(48, 15, "ConchShip_PresetKey_JixiAdventureThreePassDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(49, 15, "ConchShip_PresetKey_JixiAdventureOneStartDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(50, 15, "ConchShip_PresetKey_JixiAdventureTwoStartDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(51, 15, "ConchShip_PresetKey_JixiAdventureThreeStartDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(52, 15, "ConchShip_PresetKey_JixiAdventureFourStartDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(53, 15, "ConchShip_PresetKey_ProtectedJixiTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(54, 15, "ConchShip_PresetKey_JixiFeedChickenEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(55, 15, "ConchShip_PresetKey_JixiHarmvillagerEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(56, 15, "ConchShip_PresetKey_HaveJixiTruthClueCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(57, 15, "ConchShip_PresetKey_HaveJixiFalseClueCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(58, 15, "ConchShip_PresetKey_SectStory_Xuehou_Jixi_WaitingMonth"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(59, 15, "ConchShip_PresetKey_SectStory_Xuehou_Jixi_StayAtGraveMonthKey"));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(60, 15, "ConchShip_PresetKey_SectStory_Xuehou_Jixi_KilledCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(61, 15, "ConchShip_PresetKey_CombatWithUltimateZombieTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(62, 15, "ConchShip_PresetKey_JixiLegacyPassFirstTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(63, 15, "ConchShip_PresetKey_JixiSoulTransformFirstTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(64, 15, "ConchShip_PresetKey_PassLegacyMonthlyNotificationTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(65, 15, "ConchShip_PresetKey_NeedTriggerPassLegacyMonthlyNotification"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(66, 15, "ConchShip_PresetKey_XuehouOldManHasBell"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(67, 15, "ConchShip_PresetKey_JixiHasAntiqueJadeBat"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(68, 15, "ConchShip_PresetKey_JixiHasAntiqueJadeFox"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(69, 15, "ConchShip_PresetKey_JixiHasAntiqueJadeButterfly"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(70, 15, "ConchShip_PresetKey_JixiFavorite1TalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(71, 15, "ConchShip_PresetKey_JixiFavorite2TalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(72, 15, "ConchShip_PresetKey_JixiFavorite3TalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(73, 15, "ConchShip_PresetKey_JixiFavorite4TalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(74, 15, "ConchShip_PresetKey_JixiFavorite5TalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(75, 15, "ConchShip_PresetKey_JixiFavorite6TalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(76, 15, "ConchShip_PresetKey_JixiPassLegacyTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(77, 15, "ConchShip_PresetKey_JixiKillEnemyTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(78, 15, "ConchShip_PresetKey_JixiKilledEnemy"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(79, 15, "ConchShip_PresetKey_JixiFollowOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(80, 15, "ConchShip_PresetKey_XuehouSelectFreeJixi"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(81, 15, "ConchShip_PresetKey_XuehouGraveDiggingNormalTriggerTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(82, 15, "ConchShip_PresetKey_JixiAnimalTalkOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(83, 8, "ConchShip_PresetKey_XuannvStoryTriggerFirstTrack"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(84, 8, "ConchShip_PresetKey_XuannvStoryPartOneTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(85, 8, "ConchShip_PresetKey_XuannStory_TaiwuCharId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(86, 8, "ConchShip_PresetKey_XuannStoryPartOneReceivingLetter"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(87, 8, "ConchShip_PresetKey_XuannStoryPartOneLetter_CountA"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(88, 8, "ConchShip_PresetKey_XuannStoryPartOneLetter_CountB"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(89, 8, "ConchShip_PresetKey_XuannStoryPartOneLetter_CountC"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(90, 8, "ConchShip_PresetKey_XuannStoryPartOne_OptionMarkKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(91, 8, "ConchShip_PresetKey_XuannStoryPartOne_LegendaryDoctor"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(92, 8, "ConchShip_PresetKey_XuannStoryPartOne_WaitSecretGuestEvent"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(93, 8, "ConchShip_PresetKey_XuannStoryPartOne_SecretGuest_ActorKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(94, 8, "ConchShip_PresetKey_XuannStoryPartOne_GuessGenderKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(95, 8, "ConchShip_PresetKey_XuannvStoryPartOne_OptionInject"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(96, 8, "ConchShip_PresetKey_Xuannv_NoneSectNpcInquireSecretGuest1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(97, 8, "ConchShip_PresetKey_Xuannv_NoneSectNpcInquireSecretGuest2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(98, 8, "ConchShip_PresetKey_Xuannv_NoneSectNpcInquireSecretGuest3"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(99, 8, "ConchShip_PresetKey_XuannvPartTwo_OptionInject"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(100, 8, "ConchShip_PresetKey_XuannvPartTwo_SelectedCombatSkillType"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(101, 8, "ConchShip_PresetKey_XuannvPartThree_LearningSkill"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(102, 8, "ConchShip_PresetKey_XuannvPartThree_LearningSkillId_0"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(103, 8, "ConchShip_PresetKey_XuannvPartThree_LearningSkillId_1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(104, 8, "ConchShip_PresetKey_XuannvPartThree_LearningSkillId_2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(105, 8, "ConchShip_PresetKey_Xuannv_PartTwoRefuseToHelpCountKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(106, 8, "ConchShip_PresetKey_Xuannv_PartThreeSearchLoverCountKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(107, 8, "ConchShip_PresetKey_Xuannv_PartThree_TakeLoverDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(108, 8, "ConchShip_PresetKey_Xuannv_PartThree_LoverReincarnateLocation1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(109, 8, "ConchShip_PresetKey_Xuannv_PartThree_LoverReincarnateLocation2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(110, 8, "ConchShip_PresetKey_Xuannv_PartThree_LoverReincarnateLocation3"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(111, 8, "ConchShip_PresetKey_Xuannv_LoverReincarnateLocation"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(112, 8, "ConchShip_PresetKey_Xuannv_WaitLoverNameKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(113, 8, "ConchShip_PresetKey_Xuannv_MonthlyEventTrigger_WithSister"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(114, 8, "ConchShip_PresetKey_Xuannv_PartThree_HasTalkToShiWeizhi"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(115, 8, "ConchShip_PresetKey_Xuannv_PartThree_ActorSisterOfShiWeizhi"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(116, 8, "ConchShip_PresetKey_Xuannv_PartThree_GirlGodIllusion"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(117, 8, "ConchShip_PresetKey_XuannvStory_OptionReadFlag_1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(118, 8, "ConchShip_PresetKey_XuannvStory_OptionReadFlag_2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(119, 8, "ConchShip_PresetKey_XuannvStory_OptionReadFlag_3"));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(120, 8, "ConchShip_PresetKey_XuannvStory_OptionReadFlag_41"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(121, 8, "ConchShip_PresetKey_XuannvStory_HeYouyuan_CharId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(122, 8, "ConchShip_PresetKey_XuannvStory_SecretReincarnationNPC_CharId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(123, 8, "ConchShip_PresetKey_XuannvStory_IsJunerAtXuannvSect"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(124, 8, "ConchShip_PresetKey_XuannvStory_MusicUnlock10_FirstFlag"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(125, 8, "ConchShip_PresetKey_XuannvStory_MusicUnlock40_FirstFlag"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(126, 8, "ConchShip_PresetKey_XuannvStory_MusicUnlock45_WeaponFlag"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(127, 8, "ConchShip_PresetKey_XuannvStory_PartThree_LastDateOfAdventureIllusionOfMirror"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(128, 1, "ConchShip_PresetKey_ShaolinMythinLowMemberTalked"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(129, 1, "ConchShip_PresetKey_ShaolinMythinMiddleMemberTalked"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(130, 1, "ConchShip_PresetKey_ShaolinStatueReturnTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(131, 1, "ConchShip_PresetKey_ShaolinMonthlyEventNotEnoughDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(132, 1, "ConchShip_PresetKey_DamoDreamMeetTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(133, 1, "ConchShip_PresetKey_ShaolinCombatSkillType"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(134, 1, "ConchShip_PresetKey_ShaolinLearnedAny"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(135, 1, "ConchShip_PresetKey_ShaolinDamoFightTimes"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(136, 1, "ConchShip_PresetKey_ShaolinDamoFightWinDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(137, 1, "ConchShip_PresetKey_StudyForBodhidharmaChallenge"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(138, 1, "ConchShip_PresetKey_ShaolinDamoTrialTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(139, 1, "ConchShip_PresetKey_ShaolinDamoFightTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(140, 1, "ConchShip_PresetKey_ShaolinDamoVisitTimes"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(141, 1, "ConchShip_PresetKey_ShaolinReadingMaxGradeSutra"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(142, 1, "ConchShip_PresetKey_ShaolinSutraPavilionGuardDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(143, 1, "ConchShip_PresetKey_ShaolinDamoLearnedFightTimes"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(144, 1, "ConchShip_PresetKey_ShaolinComprehendedTheZen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(145, 1, "ConchShip_PresetKey_ShaolinMeditationInteractionFinished"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(146, 1, "ConchShip_PresetKey_ShaolinInteractionChangeTip1Triggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(147, 1, "ConchShip_PresetKey_ShaolinInteractionChangeTip2Triggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(148, 4, "ConchShip_PresetKey_WudangSkillReverseBreakCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(149, 4, "ConchShip_PresetKey_CombatWithTaoistMonkDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(150, 4, "ConchShip_PresetKey_CombatWithTaoistMonkTaiwuName"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(151, 4, "ConchShip_PresetKey_AtLastCombatWithTaoistMonkTaiwuName"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(152, 4, "ConchShip_PresetKey_BlackSnakeCustomName"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(153, 4, "ConchShip_PresetKey_GiveTaoistTreasureCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(154, 4, "ConchShip_PresetKey_GiveTaoistTreasureItemKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(155, 4, "ConchShip_PresetKey_WudangChatEventTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(156, 4, "ConchShip_PresetKey_WudangSankeFighted"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(157, 4, "ConchShip_PresetKey_WudangFrontEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(158, 4, "ConchShip_PresetKey_LastEventSloppyTaoistMonkFavor"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(159, 4, "ConchShip_PresetKey_GetExtraSeedCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(160, 4, "ConchShip_PresetKey_FinishFairylandStoryCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(161, 4, "ConchShip_PresetKey_TriggeredFailureEvent"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(162, 4, "ConchShip_PresetKey_WudangKillRandomEnemyTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(163, 4, "ConchShip_PresetKey_GivenMonkSnakeItemKey"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(164, 4, "ConchShip_PresetKey_GivenMonkSnakeList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(165, 4, "ConchShip_PresetKey_WudangEasterEggTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(166, 4, "ConchShip_PresetKey_WudangHeavenlyTreeSeedTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(167, 4, "ConchShip_PresetKey_WudangFairylandTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(168, 4, "ConchShip_PresetKey_WudangTortoiseSnakeTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(169, 4, "ConchShip_PresetKey_WudangEmperorTalkTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(170, 4, "ConchShip_PresetKey_MeetImmortalEventCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(171, 4, "ConchShip_PresetKey_CollectHeavenlyTreeSeedFirstTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(172, 5, "ConchShip_PresetKey_YuanshanDemonOutOfJail"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(173, 5, "ConchShip_PresetKey_TaiwuReleasedYuanshanDemon"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(174, 5, "ConchShip_PresetKey_YuanshanLeaderFirmDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(175, 5, "ConchShip_PresetKey_YuanshanDemonDormantDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(176, 5, "ConchShip_PresetKey_MythInYuanshanTriggeredDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(177, 5, "ConchShip_PresetKey_YuanshanInteractionTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(178, 5, "ConchShip_PresetKey_YuanshanThoughtsTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(179, 5, "ConchShip_PresetKey_YuanshanThoughtsInteractable"));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(180, 5, "ConchShip_PresetKey_YuanshanLobbyTalkInteractable"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(181, 5, "ConchShip_PresetKey_YuanshanDemonPower"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(182, 5, "ConchShip_PresetKey_KilledYuanshanDemonCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(183, 5, "ConchShip_PresetKey_YuanshanCaelumDemonDefeatedTaiwu"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(184, 5, "ConchShip_PresetKey_YuanshanTerraDemonDefeatedTaiwu"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(185, 5, "ConchShip_PresetKey_YuanshanAnthropDemonDefeatedTaiwu"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(186, 5, "ConchShip_PresetKey_YuanshanDemonMeetTaiwuCharId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(187, 5, "ConchShip_PresetKey_YuanshanDemonLast"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(188, 5, "ConchShip_PresetKey_YuanshanToFightDemon"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(189, 5, "YuanshanMiniGameStage"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(190, 5, "Adventure"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(191, 6, "ConchShip_PresetKey_ShixiangAdventureAppearDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(192, 6, "ConchShip_PresetKey_ShixiangFirstLetterDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(193, 6, "ConchShip_PresetKey_ShixiangLetterCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(194, 6, "ConchShip_PresetKey_ShixiangToFightEnemy"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(195, 6, "ConchShip_PresetKey_MockShixiangEventTriggeredSettlementId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(196, 6, "ConchShip_PresetKey_MockShixiangEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(197, 6, "ConchShip_PresetKey_MockShixiangEventCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(198, 6, "ConchShip_PresetKey_ShixiangStoryPartOneTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(199, 6, "ConchShip_PresetKey_ShixiangAdventureWon"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(200, 6, "ConchShip_PresetKey_TaiwuKillBarbarianMasterCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(201, 6, "ConchShip_PresetKey_ShixiangKillBarbarianMasterCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(202, 6, "ConchShip_PresetKey_TaiwuKillBarbarianMasterCount2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(203, 6, "ConchShip_PresetKey_ShixiangKillBarbarianMasterCount2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(204, 6, "ConchShip_PresetKey_ArriveLotusMountainEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(205, 6, "ConchShip_PresetKey_ArriveShixiangEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(206, 6, "ConchShip_PresetKey_StartFightShixiangTraitorsDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(207, 6, "ConchShip_PresetKey_FailFinishKillTraitorOnTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(208, 6, "ConchShip_PresetKey_SelectGoodEnd"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(209, 6, "ConchShip_PresetKey_LeikunAvatarData"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(210, 6, "ConchShip_PresetKey_KilledByLeiKunTaiwuName"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(211, 6, "ConchShip_PresetKey_ShixiangAdventureLiteratiCharId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(212, 2, "ConchShip_PresetKey_EmeiSelectGoodEndCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(213, 2, "ConchShip_PresetKey_EmeiSelectBadEndCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(214, 2, "ConchShip_PresetKey_EmeiFourthSelectResult"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(215, 2, "ConchShip_PresetKey_WhiteApeBlockId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(216, 2, "ConchShip_PresetKey_WhiteApeBlockIdTmpSave"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(217, 2, "ConchShip_PresetKey_HomocideCase0Time"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(218, 2, "ConchShip_PresetKey_HomocideCase1Time"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(219, 2, "ConchShip_PresetKey_HomocideCase0Triggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(220, 2, "ConchShip_PresetKey_HomocideCase1Triggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(221, 2, "ConchShip_PresetKey_HomocideCase2Triggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(222, 2, "ConchShip_PresetKey_EmeiRoleJia"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(223, 2, "ConchShip_PresetKey_EmeiRoleYi"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(224, 2, "ConchShip_PresetKey_EmeiRoleBing"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(225, 2, "ConchShip_PresetKey_EmeiRoleDing"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(226, 2, "ConchShip_PresetKey_EmeiRoleWu"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(227, 2, "ConchShip_PresetKey_EmeiRoleSi"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(228, 2, "ConchShip_PresetKey_EmeiRoleGeng"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(229, 2, "ConchShip_PresetKey_EmeiRoleXin"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(230, 2, "ConchShip_PresetKey_TaiwuJumpCliffInjuryType"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(231, 2, "ConchShip_PresetKey_EmeiKillEachOtherStage"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(232, 2, "ConchShip_PresetKey_EmeiHomocideCasesInteractionCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(233, 2, "ConchShip_PresetKey_EmeiEmeiHomocideCasesInteractionIds"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(234, 2, "ConchShip_PresetKey_FirstClickWhiteGibbonDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(235, 2, "ConchShip_PresetKey_SecondClickWhiteGibbonDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(236, 2, "ConchShip_PresetKey_ThirdClickWhiteGibbonDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(237, 2, "ConchShip_PresetKey_FourthClickWhiteGibbonDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(238, 2, "ConchShip_PresetKey_FifthClickWhiteGibbonDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(239, 2, "ConchShip_PresetKey_SixthClickWhiteGibbonDate"));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(240, 2, "ConchShip_PresetKey_EmeiOptionReclusiveElderVisible"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(241, 2, "ConchShip_PresetKey_EmeiOptionWhoIsOrthodoxVisible"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(242, 2, "ConchShip_PresetKey_EmeiLeaderOriginalLocation"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(243, 2, "ConchShip_PresetKey_EmeiLeaderOriginalId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(244, 2, "ConchShip_PresetKey_EmeiAdventureTwoAppearDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(245, 2, "ConchShip_PresetKey_EmeiEnterAdventureTwo"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(246, 2, "ConchShip_PresetKey_EmeiPassAdventureTwoTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(247, 2, "ConchShip_PresetKey_EmeiAdventureTwoPathEventTriggerCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(248, 2, "ConchShip_PresetKey_EmeiSelectGiveUpTrace"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(249, 2, "ConchShip_PresetKey_EmeiDefeatShiHoujiu"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(250, 2, "ConchShip_PresetKey_EmeiWhiteGibbonFollowOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(251, 2, "ConchShip_PresetKey_EmeiShiHoujiuFollowOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(252, 2, "ConchShip_PresetKey_EmeiBreakBonusRefreshTimes"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(253, 2, "ConchShip_PresetKey_EmeiBreakBonusSaved"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(254, 2, "ConchShip_PresetKey_EmeiBreakBonusTemplateIds"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(255, 2, "ConchShip_PresetKey_EmeiBreakBonusExtraPoints"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(256, 2, "ConchShip_PresetKey_EmeiGiveInShiHoujiu"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(257, 12, "ConchShip_PresetKey_Wuxian_Prologue_WugEventRecord"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(258, 12, "ConchShip_PresetKey_Wuxian_Prologue_TaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(259, 12, "ConchShip_PresetKey_Wuxian_Prologue_AddedWug"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(260, 12, "ConchShip_PresetKey_Wuxian_Prologue_WugAttacked"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(261, 12, "ConchShip_PresetKey_Wuxian_Chapter1_VisitCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(262, 12, "ConchShip_PresetKey_Wuxian_Chapter1_Wish1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(263, 12, "ConchShip_PresetKey_Wuxian_Chapter1_Wish2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(264, 12, "ConchShip_PresetKey_Wuxian_Chapter1_Wish3"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(265, 12, "ConchShip_PresetKey_Wuxian_Chapter1_WuxianChapter1WishCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(266, 12, "ConchShip_PresetKey_Wuxian_Chapter1_WishComeTrueCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(267, 12, "ConchShip_PresetKey_Wuxian_Chapter1_Refused"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(268, 12, "ConchShip_PresetKey_Wuxian_Chapter1_RanXinduLocation"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(269, 12, "ConchShip_PresetKey_Wuxian_Chapter2_Adventure1Selection"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(270, 12, "ConchShip_PresetKey_Wuxian_Chapter2_Adventure2Selection"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(271, 12, "ConchShip_PresetKey_Wuxian_Chapter3_AbleToStart"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(272, 12, "ConchShip_PresetKey_Wuxian_Chapter3_MailReceivedCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(273, 12, "ConchShip_PresetKey_Wuxian_Chapter4_AdventureComplete"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(274, 12, "ConchShip_PresetKey_Wuxian_Chapter4_FinalBossBeaten"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(275, 12, "ConchShip_PresetKey_Wuxian_Chapter4_HappyEndingEventDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(276, 12, "ConchShip_PresetKey_Wuxian_Chapter4_EndingEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(277, 12, "ConchShip_PresetKey_Wuxian_PassLegacyEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(278, 11, "ConchShip_PresetKey_JingangMonkMurderedTriggeredDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(279, 11, "ConchShip_PresetKey_JingangAfterMonkMurderedTriggeredMoveCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(280, 11, "ConchShip_PresetKey_JingangGiveVillagerFood"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(281, 11, "ConchShip_PresetKey_JingangGiveVillagerFoodEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(282, 11, "ConchShip_PresetKey_JingangGiveVillagerFoodActorData"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(283, 11, "ConchShip_PresetKey_JingangGiveVillagerMoney"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(284, 11, "ConchShip_PresetKey_JingangGiveVillagerMoneyEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(285, 11, "ConchShip_PresetKey_JingangGiveVillagerMoneyActorData"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(286, 11, "ConchShip_PresetKey_JingangGiveVillagerPromise"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(287, 11, "ConchShip_PresetKey_JingangGiveVillagerPromiseEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(288, 11, "ConchShip_PresetKey_JingangGiveVillagerHelp"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(289, 11, "ConchShip_PresetKey_JingangGiveVillagerHelpEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(290, 11, "ConchShip_PresetKey_JingangGiveVillagerHelpActorData"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(291, 11, "ConchShip_PresetKey_JingangPersuadeVillagerCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(292, 11, "ConchShip_PresetKey_JingangTriggeredPeopleSufferingCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(293, 11, "ConchShip_PresetKey_JingangTriggeredInteractionVillagers"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(294, 11, "ConchShip_PresetKey_JingangTriggerMonthlyEventVillagerSuffer"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(295, 11, "ConchShip_PresetKey_JingangMonthlyEventVillagerEscapeTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(296, 11, "ConchShip_PresetKey_JingangAdventureNearestSettlementId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(297, 11, "ConchShip_PresetKey_JingangSecInfoSpreadingSelectCombat"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(298, 11, "ConchShip_PresetKey_JingangCreateCentralPlainsMonkTaiwuAreaId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(299, 11, "ConchShip_PresetKey_JingangKnowSecInfoIdList"));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(300, 11, "ConchShip_PresetKey_JingangSpreadSecInfoTotalCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(301, 11, "ConchShip_PresetKey_JingangMonkSoulEnterDreamCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(302, 11, "ConchShip_PresetKey_JingangSamsaraMonkSoulDreamTalkCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(303, 11, "ConchShip_PresetKey_JingangSecInfoMetaDataId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(304, 11, "ConchShip_PresetKey_JingangSecInfoOccurenceId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(305, 11, "ConchShip_PresetKey_JingangTalkedCentralPlainsMonkId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(306, 11, "ConchShip_PresetKey_JingangSamsaraMonkSoulTalked"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(307, 11, "ConchShip_PresetKey_JingangSamsaraMonkSoulTalkSelectBehavior"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(308, 11, "ConchShip_PresetKey_JingangAttackDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(309, 11, "ConchShip_PresetKey_JingangFamousFakeMonkDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(310, 11, "ConchShip_PresetKey_JingangPrayDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(311, 11, "ConchShip_PresetKey_JingangLettersFromJingangDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(312, 11, "ConchShip_PresetKey_JingangFameDistributionDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(313, 11, "ConchShip_PresetKey_JingangPietyCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(314, 11, "ConchShip_PresetKey_JingangSelectHelpWestMonk"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(315, 11, "ConchShip_PresetKey_JingangSecInfoSpreadingSelectBetray"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(316, 11, "ConchShip_PresetKey_JingangHelpMonkEndSelectOption"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(317, 11, "ConchShip_PresetKey_JingangMonkSoulBtnDisappear"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(318, 11, "ConchShip_PresetKey_JingangDefeatShmashanaAdhipati"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(319, 11, "ConchShip_PresetKey_JingangSoulTransformOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(320, 11, "ConchShip_PresetKey_JingangMonkGhostVanishesTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(321, 11, "ConchShip_PresetKey_JingangEndPartOneRefuseGiveSutra"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(322, 11, "ConchShip_PresetKey_JingangWesternBuddhistMonkTalkOneTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(323, 11, "ConchShip_PresetKey_JingangWesternBuddhistMonkTalkTwoTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(324, 11, "ConchShip_PresetKey_JingangWesternBuddhistMonkTalkThreeTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(325, 11, "ConchShip_PresetKey_JingangWesternBuddhistMonkPassLegacyTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(326, 11, "ConchShip_PresetKey_JingangImpersonatorBuddhistMonkPassLegacyTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(327, 11, "ConchShip_PresetKey_JingangStillAtJingang"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(328, 11, "ConchShip_PresetKey_JingangFinishSecondSpreadSutra"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(329, 11, "ConchShip_PresetKey_JingangTriggeredChapter1Patch"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(330, 11, "ConchShip_PresetKey_JingangMonkSoulResolveDreamCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(331, 11, "ConchShip_PresetKey_JingangMonkSoulResolveDreamChatCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(332, 11, "ConchShip_PresetKey_JingangGiveFakeBook"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(333, 11, "ConchShip_PresetKey_JingangHelpSect"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(334, 7, "ConchShip_PresetKey_Ranshan_SpecialInteractionToggle"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(335, 7, "ConchShip_PresetKey_Ranshan_Chapter1_MonthlyEventTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(336, 7, "ConchShip_PresetKey_Ranshan_Chapter1_MonthlyEventTriggeredDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(337, 7, "ConchShip_PresetKey_Ranshan_Chapter2_TeachStartDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(338, 7, "ConchShip_PresetKey_Ranshan_Chapter2_HuajuCombatPlayDecision"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(339, 7, "ConchShip_PresetKey_Ranshan_Chapter2_XuanzhiCombatPlayDecision"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(340, 7, "ConchShip_PresetKey_Ranshan_Chapter2_YingjiaoCombatPlayDecision"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(341, 7, "ConchShip_PresetKey_Ranshan_Chapter2_HuajuCombatPlayDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(342, 7, "ConchShip_PresetKey_Ranshan_Chapter2_XuanzhiCombatPlayDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(343, 7, "ConchShip_PresetKey_Ranshan_Chapter2_YingjiaoCombatPlayDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(344, 7, "ConchShip_PresetKey_Ranshan_Chapter2_YingjiaoSelection1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(345, 7, "ConchShip_PresetKey_Ranshan_Chapter2_YingjiaoSelection2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(346, 7, "ConchShip_PresetKey_SanZongBiWuCountDown"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(347, 7, "ConchShip_PresetKey_Ranshan_Chapter3_WillingToBeImmortal"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(348, 3, "ConchShip_PresetKey_BaihuaVillageSettlementIdSelection"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(349, 3, "ConchShip_PresetKey_BaihuaEndenmicTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(350, 3, "ConchShip_PresetKey_BaihuaDreamAboutPastFirstTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(351, 3, "ConchShip_PresetKey_BaihuaLeukorpusArrivedEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(352, 3, "ConchShip_PresetKey_BaihuaMelanpsycheArrivedEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(353, 3, "ConchShip_PresetKey_BaihuaSelectDenounceSuperstitious"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(354, 3, "ConchShip_PresetKey_BaihuaAdventureFourAppearDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(355, 3, "ConchShip_PresetKey_BaihuaAnonymTaiwuIsMale"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(356, 3, "ConchShip_PresetKey_BaihuaDreamAboutPastLastTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(357, 3, "ConchShip_PresetKey_BaihuaDreamAboutPastLastDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(358, 3, "ConchShip_PresetKey_BaihuaLeMeMeetTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(359, 3, "ConchShip_PresetKey_BaihuaLeukoKillsMonthEventTriggered"));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(360, 3, "ConchShip_PresetKey_BaihuaLeukoKillsMonthEventSettlementId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(361, 3, "ConchShip_PresetKey_BaihuaLeukoKillsMonthEventSettlementIdLock"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(362, 3, "ConchShip_PresetKey_BaihuaLeukoKillsInteractOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(363, 3, "ConchShip_PresetKey_BaihuaLeukoKillsCalledCharIds"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(364, 3, "ConchShip_PresetKey_BaihuaLeukoKillsFiveElementsType"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(365, 3, "ConchShipEventArgBoxKey_PresetKey_BaihuaLeukoKillsOptionSelectDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(366, 3, "ConchShip_PresetKey_BaihuaLeukoKillsCombatWin"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(367, 3, "ConchShip_PresetKey_BaihuaMelanoKillsMonthEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(368, 3, "ConchShip_PresetKey_BaihuaMelanoKillsMonthEventSettlementId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(369, 3, "ConchShip_PresetKey_BaihuaMelanoKillsMonthEventSettlementIdLock"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(370, 3, "ConchShip_PresetKey_BaihuaMelanoKillsInteractOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(371, 3, "ConchShip_PresetKey_BaihuaMelanoKillsCalledCharIds"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(372, 3, "ConchShip_PresetKey_BaihuaMelanoKillsFiveElementsType"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(373, 3, "ConchShip_PresetKey_BaihuaMelanoKillsOptionSelectDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(374, 3, "ConchShip_PresetKey_BaihuaMelanoKillsCombatWin"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(375, 3, "ConchShip_PresetKey_BaihuaSpecialDebuffIntList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(376, 3, "ConchShip_PresetKey_BaihuaCureSpecialDebuffIntList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(377, 3, "ConchShip_PresetKey_BaihuaAnimalsBackDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(378, 3, "ConchShip_PresetKey_BaihuaLeukoAssistedMelano"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(379, 3, "ConchShip_PresetKey_BaihuaMelanoAssistedLeuko"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(380, 3, "ConchShip_PresetKey_BaihuaManicLowDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(381, 3, "ConchShip_PresetKey_BaihuaManicHighDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(382, 3, "ConchShip_PresetKey_BaihuaTriggerFinaleTaskDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(383, 3, "ConchShip_PresetKey_BaihuaBaiLuFirstInteractTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(384, 3, "ConchShip_PresetKey_BaihuaXuanXiaoFirstInteractTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(385, 3, "ConchShip_PresetKey_BaihuaAdventureFinialWinSect"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(386, 3, "ConchShip_PresetKey_BaihuaLeukoDialogNotTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(387, 3, "ConchShip_PresetKey_BaihuaMelanoDialogNotTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(388, 3, "ConchShip_PresetKey_BaihuaLeukoPlayCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(389, 3, "ConchShip_PresetKey_BaihuaMelanoPlayCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(390, 3, "ConchShip_PresetKey_BaihuaLMPlayCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(391, 3, "ConchShip_PresetKey_BaihuaLMNewsTalkedCharIds"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(392, 3, "ConchShip_PresetKey_BaihuaLMTransferAnimalDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(393, 3, "ConchShip_PresetKey_BaihuaFixedLMFavor"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(394, 14, "ConchShip_PresetKey_FulongDisasterStart"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(395, 14, "ConchShip_PresetKey_FulongDisasterMonthlyEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(396, 14, "ConchShip_PresetKey_FulongDisasterStartProb"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(397, 14, "ConchShip_PresetKey_FulongFireFightingGuideTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(398, 14, "ConchShip_PresetKey_FulongAdventureOneCountDown"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(399, 14, "ConchShip_PresetKey_FulongAdventureThreeCountDown"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(400, 14, "ConchShip_PresetKey_FulongAdventureStartTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(401, 14, "ConchShip_PresetKey_FulongAdventureTwoTaiwuId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(402, 14, "ConchShip_PresetKey_FulongShadowEventTriggeredCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(403, 14, "ConchShip_PresetKey_FulongShadowEventOneTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(404, 14, "ConchShip_PresetKey_FulongShadowEventTwoTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(405, 14, "ConchShip_PresetKey_FulongReudhLazuliChatMysteryOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(406, 14, "ConchShip_PresetKey_FulongReudhLazuliChatMysteryCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(407, 14, "ConchShip_PresetKey_FulongReudhLazuliAI2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(408, 14, "ConchShip_PresetKey_FulongTravelWithLazuliWorldViewTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(409, 14, "ConchShip_PresetKey_FulongSpecialInteractOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(410, 14, "ConchShip_PresetKey_FulongTravelWithLazuliCityTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(411, 14, "ConchShip_PresetKey_FulongTravelWithLazuliTaiwuVillageTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(412, 14, "ConchShip_PresetKey_FulongTravelWithLazuliSectTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(413, 14, "ConchShip_PresetKey_FulongTravelWithLazuliTownTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(414, 14, "ConchShip_PresetKey_FulongTravelWithLazuliStockadeTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(415, 14, "ConchShip_PresetKey_FulongTravelWithLazuliVillageTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(416, 14, "ConchShip_PresetKey_FulongTravelWithLazuliXiangshuMinionTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(417, 14, "ConchShip_PresetKey_FulongTravelWithLazuliAnimalTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(418, 14, "ConchShip_PresetKey_FulongTravelWithLazuliRandomEnemyTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(419, 14, "ConchShip_PresetKey_FulongTravelWithLazuliMonvTalkTriggered"));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new SectMainStoryEventArgKeyItem(420, 14, "ConchShip_PresetKey_FulongTravelWithLazuliMoveCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(421, 14, "ConchShip_PresetKey_FulongChickenKingLetterMoveCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(422, 14, "ConchShip_PresetKey_FulongTravelWithLazuliMoveAreaId"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(423, 14, "ConchShip_PresetKey_FulongTravelWithLazuliChicken1"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(424, 14, "ConchShip_PresetKey_FulongTravelWithLazuliChicken2"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(425, 14, "ConchShip_PresetKey_FulongTravelWithLazuliFinished"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(426, 14, "ConchShip_PresetKey_FulongLazuliIsFriend"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(427, 14, "ConchShip_PresetKey_FulongSelectFalling"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(428, 14, "ConchShip_PresetKey_FulongSelectFallingDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(429, 14, "ConchShip_PresetKey_FulongReudhLazuliFeatherFollowOpen"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(430, 14, "ConchShip_PresetKey_FulongMessengerAppearTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(431, 14, "ConchShip_PresetKey_FulongLoseChickenFeatherInteractionSettlements"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(432, 14, "ConchShip_PresetKey_FulongLazuliLetterTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(433, 14, "ConchShip_PresetKey_FulongLazuliLetterEventA"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(434, 14, "ConchShip_PresetKey_FulongLazuliLetterEventB"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(435, 14, "ConchShip_PresetKey_FulongLazuliLetterEventC"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(436, 14, "ConchShip_PresetKey_FulongPutOutFireCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(437, 14, "ConchShip_PresetKey_FulongFireStartTime"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(438, 14, "ConchShip_PresetKey_FulongPutOutFire"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(439, 14, "ConchShip_PresetKey_FulongPutOutFireOnce"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(440, 14, "ConchShip_PresetKey_FulongChickenFeatherLackCount"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(441, 14, "ConchShip_PresetKey_FulongLazuliFindFlowerDialogLevel"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(442, 14, "ConchShip_PresetKey_FulongStayWithLazuliTaskTriggerDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(443, 14, "ConchShip_PresetKey_FulongMessengerIdList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(444, 14, "ConchShip_PresetKey_FulongChickenKingLeaveHome"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(445, 14, "ConchShip_PresetKey_FulongChickenFeatherDropList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(446, 9, "ConchShip_PresetKey_ZhujianCatchThiefTimes"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(447, 2, "ConchShip_PresetKey_StrangerTriggerDate"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(448, 2, "ConchShip_PresetKey_EmeiInteractionOneTriggeredList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(449, 2, "ConchShip_PresetKey_EmeiInteractionTwoTriggeredList"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(450, 2, "ConchShip_PresetKey_EmeiFirstMonthlyEventTriggered"));
		_dataArray.Add(new SectMainStoryEventArgKeyItem(451, 15, "ConchShip_PresetKey_XuehouKillJixi"));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<SectMainStoryEventArgKeyItem>(452);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
		CreateItems7();
	}

	public int ToTemplateId(string str)
	{
		foreach (SectMainStoryEventArgKeyItem item in (IEnumerable<SectMainStoryEventArgKeyItem>)this)
		{
			if (item.ArgBoxKey == str)
			{
				return item.TemplateId;
			}
		}
		return -1;
	}

	public string ToArgString(int templateId)
	{
		return GetItem(templateId)?.ArgBoxKey;
	}
}

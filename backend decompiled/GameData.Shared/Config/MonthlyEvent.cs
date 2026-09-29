using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class MonthlyEvent : ConfigData<MonthlyEventItem, short>
{
	public static class DefKey
	{
		public const short ReadingEvent = 0;

		public const short TaiwuDeath = 1;

		public const short AreaTotallyDestoryed = 2;

		public const short TaiwuInfected = 3;

		public const short TaiwuInfectedPartially = 4;

		public const short RandomEnemyAttack = 5;

		public const short RandomAnimalAttack = 6;

		public const short RandomRighteousAttack = 7;

		public const short InfectedCharacterAttack = 8;

		public const short HumanSkeletonAttack = 9;

		public const short CricketInDream = 10;

		public const short GiveBirthToCricketTaiwu = 11;

		public const short GiveBirthToCricketWife = 12;

		public const short PrenatalEducationTaiwu = 13;

		public const short AbortionTaiwu = 14;

		public const short LoseFetusWife = 15;

		public const short MotherFetusBothDieTaiwu = 16;

		public const short MotherFetusBothDieWife = 17;

		public const short DystociaLoseFetusTaiwu = 18;

		public const short DystociaLoseFetusWife = 19;

		public const short HaveChildBoyTaiwu = 20;

		public const short HaveChildGirlTaiwu = 21;

		public const short HaveChildBoyWife = 22;

		public const short HaveChildGirlWife = 23;

		public const short DystociaButHaveChildBoyTaiwu = 24;

		public const short DystociaButHaveChildGirlTaiwu = 25;

		public const short DystociaButHaveChildBoyWife = 26;

		public const short DystociaButHaveChildGirlWife = 27;

		public const short DystociaAndHaveChildBoyTaiwu = 28;

		public const short DystociaAndHaveChildGirlTaiwu = 29;

		public const short DystociaAndHaveChildBoyWife = 30;

		public const short DystociaAndHaveChildGirlWife = 31;

		public const short AbandonedBabyInVilliage = 32;

		public const short ChildZhuazhou = 33;

		public const short TeachChild = 34;

		public const short ReachAdulthood = 35;

		public const short CaptiveHaveChild = 36;

		public const short CaptiveBecomeEnemy = 37;

		public const short GroupGetMarried = 38;

		public const short SpringMarket = 39;

		public const short SummerTownCompetition = 40;

		public const short AutumnCricketContest = 41;

		public const short WinterLifeCompetition = 42;

		public const short MakeEnemy = 43;

		public const short SeverEnemy = 44;

		public const short Adore = 45;

		public const short Confess = 46;

		public const short Breakup = 47;

		public const short ProposeMarriage = 48;

		public const short BecomeFriend = 49;

		public const short SeverFriendship = 50;

		public const short BecomeSwornBrotherOrSister = 51;

		public const short SeverSwornBrotherhood = 52;

		public const short GetAdoptedByFather = 53;

		public const short GetAdoptedByMother = 54;

		public const short AdoptSon = 55;

		public const short AdoptDaughter = 56;

		public const short Die = 57;

		public const short EscapeFromPrison = 58;

		public const short AppointmentCancelled = 59;

		public const short RevengeAttack = 60;

		public const short AskProtectByRevengeAttack = 61;

		public const short CatchEnemyPoison = 62;

		public const short EnemyPoisonAndEscape = 63;

		public const short CatchEnemyPlotHarm = 64;

		public const short EnemyPlotHarmAndEscape = 65;

		public const short RequestHealOuterInjuryByItem = 66;

		public const short RequestHealOuterInjuryByResource = 67;

		public const short RequestHealInnerInjuryByItem = 68;

		public const short RequestHealInnerInjuryByResource = 69;

		public const short RequestHealPoisonByItem = 70;

		public const short RequestHealPoisonByResource = 71;

		public const short RequestHealth = 72;

		public const short RequestHealDisorderOfQi = 73;

		public const short RequestNeili = 74;

		public const short RequestKillWug = 75;

		public const short RequestFood = 76;

		public const short RequestTeaWine = 77;

		public const short RequestResource = 78;

		public const short RequestItem = 79;

		public const short RequestRepairItem = 80;

		public const short RequestAddPoisonToItem = 81;

		public const short RequestInstructionOnLifeSkill = 82;

		public const short RequestInstructionOnCombatSkill = 83;

		public const short RequestInstructionOnReadingLifeSkill = 84;

		public const short RequestInstructionOnReadingCombatSkill = 85;

		public const short RequestInstructionOnBreakout = 86;

		public const short RequestPlayCombat = 87;

		public const short RequestNormalCombat = 88;

		public const short RequestLifeSkillBattle = 89;

		public const short RequestCricketBattle = 90;

		public const short RescueKidnappedCharacterSecretlyButBeCaught = 91;

		public const short RescueKidnappedCharacterSecretlyAndEscape = 92;

		public const short RescueKidnappedCharacterWithWit = 93;

		public const short RescueKidnappedCharacterWithForce = 94;

		public const short StealResourceButBeCaught = 95;

		public const short StealResourceAndEscape = 96;

		public const short ScamResource = 97;

		public const short RobResource = 98;

		public const short StealItemButBeCaught = 99;

		public const short StealItemAndEscape = 100;

		public const short ScamItem = 101;

		public const short RobItem = 102;

		public const short StealLifeSkillButBeCaught = 103;

		public const short StealLifeSkillAndEscape = 104;

		public const short ScamLifeSkill = 105;

		public const short StealCombatSkillButBeCaught = 106;

		public const short StealCombatSkillAndEscape = 107;

		public const short ScamCombatSkill = 108;

		public const short AdviseExtendFavours = 109;

		public const short AdviseWinPeopleSupport = 110;

		public const short AdviseMerchantFavor = 111;

		public const short AdviseTeaWine = 112;

		public const short AdviseSales = 113;

		public const short AdviseHealInjury = 114;

		public const short AdviseHealPoison = 115;

		public const short AdviseRepairItem = 116;

		public const short AdviseBarb = 117;

		public const short AskForMoney = 118;

		public const short WulinConferenceTaiwuAbsent = 119;

		public const short WulinConferenceAskForHelp = 120;

		public const short TaiwuVillageBeDestoryed = 121;

		public const short ForeverLoverBePunished = 122;

		public const short VillageWoodenManByMonv = 123;

		public const short VillageWoodenManByDayueYaochang = 124;

		public const short VillageWoodenManByJiuhan = 125;

		public const short VillageWoodenManByJinHuanger = 126;

		public const short VillageWoodenManByYiYihou = 127;

		public const short VillageWoodenManByWeiQi = 128;

		public const short VillageWoodenManByYixiang = 129;

		public const short VillageWoodenManByXuefeng = 130;

		public const short VillageWoodenManByShuFang = 131;

		public const short TaiwuNotAttendingWedding = 132;

		public const short TaiwuAlreadyMarried = 133;

		public const short ChallengeForLegendaryBook = 134;

		public const short RequestLegendaryBook = 135;

		public const short ExchangeLegendaryBookByMoney = 136;

		public const short ExchangeLegendaryBookByAuthority = 137;

		public const short ExchangeLegendaryBookByExperience = 138;

		public const short StealLegendaryBookAndEscape = 139;

		public const short StealLegendaryBookGotCaught = 140;

		public const short ScamLegendaryBook = 141;

		public const short RobLegendaryBook = 142;

		public const short LegendaryBookShockedAttack = 143;

		public const short LegendaryBookInsaneAttack = 144;

		public const short LegendaryBookConsumedAttack = 145;

		public const short SwordTombGetStronger = 146;

		public const short SwordTombBackToNormal = 147;

		public const short FightForNewLegendaryBook = 148;

		public const short FightForLegendaryBookAbandoned = 149;

		public const short FightForLegendaryBookOwnerDie = 150;

		public const short FightForLegendaryBookOwnerConsumed = 151;

		public const short DateWithLoverEveryday = 152;

		public const short HappyBirthdayTaiwu = 153;

		public const short LoveAnniversary = 154;

		public const short NeglectedLover = 155;

		public const short LoverBecomeJealous = 156;

		public const short LoversBecomeJealousAndViolent = 157;

		public const short PregnancyWithLover = 158;

		public const short BeggerSkill2TargetUnavailable = 159;

		public const short BeggarSkill2TargetBrought = 160;

		public const short BeggarSkill2TargetDeadAndMissing = 161;

		public const short BeggarSkill2TargetDead = 162;

		public const short BeggarSkill2TargetNoneExistent = 163;

		public const short TaiwuTribulation = 164;

		public const short TaiwuComingSuccess = 165;

		public const short TaiwuComingDefeated = 166;

		public const short TaiwuFreeAndunFettered = 167;

		public const short SectMainStoryXuehouGraveDigging = 172;

		public const short SectMainStoryXuehouGraveDiggingNormal = 173;

		public const short SectMainStoryXuehouStrangeDeath = 174;

		public const short SectMainStoryXuehouOldManAppears = 175;

		public const short SectMainStoryXuehouOldManReturns = 176;

		public const short SectMainStoryXuehouOnBloodBlock = 177;

		public const short SectMainStoryXuehouOldManAttacks = 178;

		public const short SectMainStoryXuehouHarmoniousTaiwu = 179;

		public const short SectMainStoryXuehouFeedJixi = 180;

		public const short SectMainStoryXuehouMythInVillage = 181;

		public const short SectMainStoryXuehouProtectJixi = 182;

		public const short SectMainStoryXuehouJixiAskForFood = 183;

		public const short SectMainStoryXuehouJixiFeedChicken = 184;

		public const short SectMainStoryXuehouJixiKills = 185;

		public const short SectMainStoryXuehouVillageWork = 186;

		public const short SectMainStoryXuehouFinale = 187;

		public const short SectMainStoryShaolinTowerFalling = 190;

		public const short SectMainStoryShaolinLearning = 193;

		public const short SectMainStoryShaolinNotEnough = 194;

		public const short SectMainStoryShaolinChallenge = 195;

		public const short SectMainStoryShaolinEndChallenge = 196;

		public const short SectMainStoryShaolinNeverLearnChallenge = 197;

		public const short SectMainStoryXuannvPrologue = 200;

		public const short SectMainStoryYuanshanInfectedCharacterAttack = 210;

		public const short SectMainStoryYuanshanDisciplesInfected = 211;

		public const short SectMainStoryYuanshanLastMonsterAppear = 212;

		public const short SectMainStoryYuanshanProsperous = 213;

		public const short SectMainStoryShixiangDuel = 217;

		public const short SectMainStoryJingangPeopleSuffering = 219;

		public const short SectMainStoryJingangAttack = 220;

		public const short SectMainStoryJingangMonkMurdered = 221;

		public const short SectMainStoryJingangExorcism = 222;

		public const short SectMainStoryJingangGhostAppears = 223;

		public const short SectMainStoryWuxianPoisonousWug = 227;

		public const short SectMainStoryWuxianProsperous = 228;

		public const short SectMainStoryWuxianFailing0 = 229;

		public const short SectMainStoryWuxianFailing1 = 230;

		public const short SectMainStoryWuxianStrangeThings = 231;

		public const short SectMainStoryWuxianPoison = 232;

		public const short SectMainStoryWuxianAssault = 233;

		public const short SectMainStoryEmeiProsperous = 234;

		public const short SectMainStoryEmeiFailing = 235;

		public const short SectMainStoryJieqingProsperous = 236;

		public const short SectMainStoryJieqingFailing = 237;

		public const short SectMainStoryXuehouEmptyGrave = 238;

		public const short SectMainStoryXuehouLookingForTaiwu = 239;

		public const short SectMainStoryXuehouComing = 240;

		public const short SectMainStoryRanshanPaperCraneFromYufuFaction = 241;

		public const short SectMainStoryRanshanPaperCraneFromShenjianFaction = 242;

		public const short SectMainStoryRanshanPaperCraneFromYinyangFaction = 243;

		public const short SectMainStoryRanshanProsperous = 244;

		public const short SectMainStoryRanshanFailing = 245;

		public const short SectMainStoryShaolinDreamOfReadingSutra = 246;

		public const short SectMainStoryShaolinDreamOfNewTaiwu = 247;

		public const short SectMainStoryShaolinEnlightenment = 248;

		public const short SectMainStoryShaolinNotEnoughCommon = 249;

		public const short SectMainStoryShixiangRequestBook = 250;

		public const short SectMainStoryShixiangRequestLifeSkill = 251;

		public const short SectMainStoryShixiangGoodNews = 252;

		public const short SectMainStoryShaolinChallengeCommon = 254;

		public const short SectMainStoryShaolinEndChallengeCommon = 255;

		public const short SectMainStoryShaolinNeverLearnChallengeCommon = 256;

		public const short SectMainStoryShixiangLetterFrom2 = 257;

		public const short SectMainStoryShixiangGoodNews2 = 258;

		public const short SectMainStoryShixiangEnemyAttack2 = 259;

		public const short SectMainStoryShixiangStrange = 260;

		public const short SectMainStoryWudangProtectHeavenlyTree = 262;

		public const short SectMainStoryWudangHeavenlyTreeDestroyed = 263;

		public const short SectMainStoryWudangMeetingImmortal = 265;

		public const short SectMainStoryWudangGuardHeavenlyTree = 266;

		public const short SectMainStoryWudangHeavenlyTreeDestroyed2 = 276;

		public const short MirrorCreatedImpostureXiangshuInfected = 277;

		public const short SectMainStoryWudangProtectHeavenlyTree2 = 278;

		public const short CrossArchiveReunionWithAcquaintance = 279;

		public const short TeachCombatSkill = 280;

		public const short Pregnant = 281;

		public const short TamingCarriers = 282;

		public const short FiveLoongLetterFromTaiwuVillage = 283;

		public const short JiaoGrowold = 284;

		public const short DLCLoongRidingEffectQiuniu = 285;

		public const short DLCLoongRidingEffectYazi = 286;

		public const short DLCLoongRidingEffectChaofeng = 287;

		public const short DLCLoongRidingEffectPulao = 288;

		public const short DLCLoongRidingEffectSuanni = 289;

		public const short DLCLoongRidingEffectBaxia = 290;

		public const short DLCLoongRidingEffectBian = 291;

		public const short DLCLoongRidingEffectFuxi = 292;

		public const short DLCLoongRidingEffectChiwen = 293;

		public const short MinionLoongAttack = 294;

		public const short DLCLoongJiaoGrowUp = 295;

		public const short SectMainStoryWuxianGiftsReceived = 296;

		public const short SectMainStoryJingangVisitorsArrive = 297;

		public const short SectMainStoryJingangLettersFromJingang = 298;

		public const short SectMainStoryJingangPiety = 299;

		public const short SectMainStoryJingangRitualsInDream = 301;

		public const short SectMainStoryJingangReincarnation = 304;

		public const short SectMainStoryJingangGhostVanishes = 305;

		public const short SectMainStoryWuxianMiaoWoman = 306;

		public const short SectMainStoryRanshanDragonGate = 307;

		public const short SectMainStoryRanshanMessage = 308;

		public const short SectMainStoryRanshanAfterQinglang = 309;

		public const short SectMainStoryRanshanSanshiLeave = 310;

		public const short SectMainStoryBaihuaEndenmic = 311;

		public const short SectMainStoryBaihuaDreamAboutPastLast = 313;

		public const short SectMainStoryBaihuaLeukoKills = 317;

		public const short MerchantVisit = 318;

		public const short ToRepayKindness = 319;

		public const short SectMainStoryBaihuaAmbushLeuko = 320;

		public const short SectMainStoryBaihuaMelanoKills = 321;

		public const short SectMainStoryBaihuaAmbushMelano = 322;

		public const short SectMainStoryBaihuaManicAttack = 325;

		public const short SectMainStoryBaihuaAnonymReturns = 326;

		public const short SectMainStoryBaihuaMelanoPlay = 328;

		public const short SectMainStoryBaihuaLeukoPlay = 329;

		public const short SectMainStoryBaihuaLeukoMelanoPlay = 330;

		public const short SectMainStoryFulongDiasterAppear = 331;

		public const short SectMainStoryFulongLazuliLetter = 333;

		public const short HuntCriminal = 336;

		public const short SentenceCompleted = 337;

		public const short SectMainStoryFulongRobTaiwu = 338;

		public const short SectMainStoryFulongInterfereRobbery = 339;

		public const short SectMainStoryFulongProtect = 340;

		public const short SectMainStoryFulongFireFighting = 341;

		public const short AdviseHealDisorderOfQi = 343;

		public const short AdviseHealHealth = 344;

		public const short TaiWuVillagerClothing = 345;

		public const short HuntCriminalTaiwu = 346;

		public const short SectMainStoryZhujianHeir = 347;

		public const short SectMainStoryZhujianFailing = 352;

		public const short JieQingPunishmentAssassin = 353;

		public const short TaiwuBeHuntedHunterDie = 354;

		public const short WardOffXiangshuProtection = 355;

		public const short ProfessionDukeReceiveCricket = 356;

		public const short CricketInDreamTaiwuPartnerPregnant = 357;

		public const short SectMainStoryShaolinDharmaCave = 358;

		public const short TaiwuVillageStoneClaimed = 359;

		public const short TaiwuVillagerAdoptOrphan = 360;

		public const short NormalHeavenlyTreeDestroyed = 363;

		public const short NormalGuardHeavenlyTree = 364;

		public const short BackFromOuterWorlds = 374;

		public const short AiLongDistanceMarriageAskAdvice = 378;

		public const short DLCYearOfHorseCloth = 393;

		public const short Bequest = 394;

		public const short MainStoryTianmuPeopleRemoveItem = 395;

		public const short MainStoryImmortalXuSeekSacrifice = 396;

		public const short MainStoryHeavenlyDarkFire = 397;

		public const short MainStoryWuxiaoSpiritSection0 = 398;

		public const short MainStoryWuxiaoSpiritSection1 = 399;

		public const short MainStoryWuxiaoSpiritSection2 = 400;

		public const short MainStoryThreeWorldDevilAppear = 401;

		public const short MainStoryThreeWorldDevilFire = 402;

		public const short MainStoryThreeWorldDevilBlood = 403;

		public const short MainStoryThreeWorldDevilMelee = 404;

		public const short MainStoryImmortalXuStolen = 405;

		public const short DLCTransmogrifyingCricketToHumanbeing = 406;

		public const short DLCTransmogrifyingHumanbeingToCricket = 407;

		public const short SectMainStoryJieqingBloodBeiDou = 408;

		public const short SectMainStoryJieqingMessage = 409;

		public const short SectMainStoryJieqingSmashPearl = 410;

		public const short SectMainStoryJieqingRecovery = 411;

		public const short SectMainStoryJieqingAssassination = 412;

		public const short DLCGiftFromConchShip1 = 413;

		public const short DLCGiftFromConchShip2 = 414;

		public const short DLCHappyNewYear2024 = 415;

		public const short DLCYearOfSnakeCloth = 416;

		public const short MainStoryLineIronPlateMonkInvestigate = 417;

		public const short MainStoryLineIronPlateItemReceived = 418;

		public const short MainStoryLineEvilDemonBlood = 419;

		public const short MainStoryLineEvilMohaMind = 420;

		public const short MainStoryLineEvilBloodAdv = 421;

		public const short MainStoryLineDivineflameFuxietie = 422;

		public const short MainStoryLineDivineflameJielongpo = 423;

		public const short MainStoryLineDivineflameDaxuanning = 424;

		public const short MainStoryLineDivineflameQiumomu = 425;

		public const short MainStoryLineDivineflameFenshenlian = 426;

		public const short MainStoryLineDivineflameRongchenyin = 427;

		public const short MainStoryLineDivineflameFenghuangjian = 428;

		public const short MainStoryLineDivineflameGuishenxia = 429;

		public const short MainStoryLineDivineflameMonvyi = 430;

		public const short SectMainStoryEmeiUpgradeRumors = 431;

		public const short SectMainStoryEmeiUpgradeStudy = 432;

		public const short SectMainStoryEmeiUpgradeAchieve = 433;

		public const short MakeLoveWithTaiwu = 434;

		public const short SwordFragmentUnlockSkillMonvGood = 435;

		public const short SwordFragmentUnlockSkillMonvBad = 436;

		public const short SwordFragmentUnlockSkillDayueYaochangGood = 437;

		public const short SwordFragmentUnlockSkillDayueYaochangBad = 438;

		public const short SwordFragmentUnlockSkillJiuhanGood = 439;

		public const short SwordFragmentUnlockSkillJiuhanBad = 440;

		public const short SwordFragmentUnlockSkillJinHuangerGood = 441;

		public const short SwordFragmentUnlockSkillJinHuangerBad = 442;

		public const short SwordFragmentUnlockSkillYiYihouGood = 443;

		public const short SwordFragmentUnlockSkillYiYihouBad = 444;

		public const short SwordFragmentUnlockSkillWeiQiGood = 445;

		public const short SwordFragmentUnlockSkillWeiQiBad = 446;

		public const short SwordFragmentUnlockSkillYixiangGood = 447;

		public const short SwordFragmentUnlockSkillYixiangBad = 448;

		public const short SwordFragmentUnlockSkillXuefengGood = 449;

		public const short SwordFragmentUnlockSkillXuefengBad = 450;

		public const short SwordFragmentUnlockSkillShuFangGood = 451;

		public const short SwordFragmentUnlockSkillShuFangBad = 452;

		public const short MainStoryMessagefromtheAvatar = 453;

		public const short MainStoryTidingsonSwiftBlades = 454;

		public const short MainStoryMessagefromanOldFriend = 455;

		public const short MainStoryTidingsfromanOldFriend = 456;

		public const short MainStoryMessagefromWunian = 457;

		public const short MainStoryTidingsoftheMind = 458;

		public const short MainStoryStirringoftheSwordHilt = 459;

		public const short MainStoryMoonlitPurpleDust = 460;

		public const short MainStoryMidnightUpheaval = 461;

		public const short MainStoryStrangeFireScorchestheSky = 462;

		public const short SectMainStoryJieQingUpgradeYuchan = 463;

		public const short SectMainStoryJieQingUpgradeXingYun = 464;

		public const short XiangshuAvatarAttack = 465;

		public const short SectMainStoryEmeiBeginning = 466;

		public const short SectMainStoryEmeiMidnight = 467;

		public const short SectMainStoryEmeiSecretLetter = 468;

		public const short SectMainStoryEmeiUrgentLetter = 469;

		public const short SectMainStoryEmeiFruitsGift = 470;

		public const short SectMainStoryEmeiAppreciateofEmei = 471;

		public const short SectMainStoryEmeiFarewell = 472;

		public const short MainStoryImmortalChiHongZi = 473;

		public const short MainStoryImmortalPoJinShangRen = 474;

		public const short MainStoryImmortalBaJiuJianYin = 475;

		public const short MainStoryImmortalZhenDanShengNv = 476;

		public const short DLCGreenHillsRemain = 477;

		public const short DLCEightYearsOneJourney = 478;

		public const short MainStoryImmortalHuoGuShi = 479;

		public const short WulinConferenceGift = 480;

		public const short DLCSmarterChickenKingBecomeHuman = 481;

		public const short DLCTransmogrifyingHumanToChicken = 482;

		public const short DLCAdoptChicken = 483;

		public const short DLCTameLoongPolymorphReturn = 484;

		public const short TaiwuAsXiangshuSkill0 = 485;

		public const short TaiwuAsXiangshuLittleMonkGift = 486;
	}

	public static class DefValue
	{
		public static MonthlyEventItem ReadingEvent => Instance[(short)0];

		public static MonthlyEventItem TaiwuDeath => Instance[(short)1];

		public static MonthlyEventItem AreaTotallyDestoryed => Instance[(short)2];

		public static MonthlyEventItem TaiwuInfected => Instance[(short)3];

		public static MonthlyEventItem TaiwuInfectedPartially => Instance[(short)4];

		public static MonthlyEventItem RandomEnemyAttack => Instance[(short)5];

		public static MonthlyEventItem RandomAnimalAttack => Instance[(short)6];

		public static MonthlyEventItem RandomRighteousAttack => Instance[(short)7];

		public static MonthlyEventItem InfectedCharacterAttack => Instance[(short)8];

		public static MonthlyEventItem HumanSkeletonAttack => Instance[(short)9];

		public static MonthlyEventItem CricketInDream => Instance[(short)10];

		public static MonthlyEventItem GiveBirthToCricketTaiwu => Instance[(short)11];

		public static MonthlyEventItem GiveBirthToCricketWife => Instance[(short)12];

		public static MonthlyEventItem PrenatalEducationTaiwu => Instance[(short)13];

		public static MonthlyEventItem AbortionTaiwu => Instance[(short)14];

		public static MonthlyEventItem LoseFetusWife => Instance[(short)15];

		public static MonthlyEventItem MotherFetusBothDieTaiwu => Instance[(short)16];

		public static MonthlyEventItem MotherFetusBothDieWife => Instance[(short)17];

		public static MonthlyEventItem DystociaLoseFetusTaiwu => Instance[(short)18];

		public static MonthlyEventItem DystociaLoseFetusWife => Instance[(short)19];

		public static MonthlyEventItem HaveChildBoyTaiwu => Instance[(short)20];

		public static MonthlyEventItem HaveChildGirlTaiwu => Instance[(short)21];

		public static MonthlyEventItem HaveChildBoyWife => Instance[(short)22];

		public static MonthlyEventItem HaveChildGirlWife => Instance[(short)23];

		public static MonthlyEventItem DystociaButHaveChildBoyTaiwu => Instance[(short)24];

		public static MonthlyEventItem DystociaButHaveChildGirlTaiwu => Instance[(short)25];

		public static MonthlyEventItem DystociaButHaveChildBoyWife => Instance[(short)26];

		public static MonthlyEventItem DystociaButHaveChildGirlWife => Instance[(short)27];

		public static MonthlyEventItem DystociaAndHaveChildBoyTaiwu => Instance[(short)28];

		public static MonthlyEventItem DystociaAndHaveChildGirlTaiwu => Instance[(short)29];

		public static MonthlyEventItem DystociaAndHaveChildBoyWife => Instance[(short)30];

		public static MonthlyEventItem DystociaAndHaveChildGirlWife => Instance[(short)31];

		public static MonthlyEventItem AbandonedBabyInVilliage => Instance[(short)32];

		public static MonthlyEventItem ChildZhuazhou => Instance[(short)33];

		public static MonthlyEventItem TeachChild => Instance[(short)34];

		public static MonthlyEventItem ReachAdulthood => Instance[(short)35];

		public static MonthlyEventItem CaptiveHaveChild => Instance[(short)36];

		public static MonthlyEventItem CaptiveBecomeEnemy => Instance[(short)37];

		public static MonthlyEventItem GroupGetMarried => Instance[(short)38];

		public static MonthlyEventItem SpringMarket => Instance[(short)39];

		public static MonthlyEventItem SummerTownCompetition => Instance[(short)40];

		public static MonthlyEventItem AutumnCricketContest => Instance[(short)41];

		public static MonthlyEventItem WinterLifeCompetition => Instance[(short)42];

		public static MonthlyEventItem MakeEnemy => Instance[(short)43];

		public static MonthlyEventItem SeverEnemy => Instance[(short)44];

		public static MonthlyEventItem Adore => Instance[(short)45];

		public static MonthlyEventItem Confess => Instance[(short)46];

		public static MonthlyEventItem Breakup => Instance[(short)47];

		public static MonthlyEventItem ProposeMarriage => Instance[(short)48];

		public static MonthlyEventItem BecomeFriend => Instance[(short)49];

		public static MonthlyEventItem SeverFriendship => Instance[(short)50];

		public static MonthlyEventItem BecomeSwornBrotherOrSister => Instance[(short)51];

		public static MonthlyEventItem SeverSwornBrotherhood => Instance[(short)52];

		public static MonthlyEventItem GetAdoptedByFather => Instance[(short)53];

		public static MonthlyEventItem GetAdoptedByMother => Instance[(short)54];

		public static MonthlyEventItem AdoptSon => Instance[(short)55];

		public static MonthlyEventItem AdoptDaughter => Instance[(short)56];

		public static MonthlyEventItem Die => Instance[(short)57];

		public static MonthlyEventItem EscapeFromPrison => Instance[(short)58];

		public static MonthlyEventItem AppointmentCancelled => Instance[(short)59];

		public static MonthlyEventItem RevengeAttack => Instance[(short)60];

		public static MonthlyEventItem AskProtectByRevengeAttack => Instance[(short)61];

		public static MonthlyEventItem CatchEnemyPoison => Instance[(short)62];

		public static MonthlyEventItem EnemyPoisonAndEscape => Instance[(short)63];

		public static MonthlyEventItem CatchEnemyPlotHarm => Instance[(short)64];

		public static MonthlyEventItem EnemyPlotHarmAndEscape => Instance[(short)65];

		public static MonthlyEventItem RequestHealOuterInjuryByItem => Instance[(short)66];

		public static MonthlyEventItem RequestHealOuterInjuryByResource => Instance[(short)67];

		public static MonthlyEventItem RequestHealInnerInjuryByItem => Instance[(short)68];

		public static MonthlyEventItem RequestHealInnerInjuryByResource => Instance[(short)69];

		public static MonthlyEventItem RequestHealPoisonByItem => Instance[(short)70];

		public static MonthlyEventItem RequestHealPoisonByResource => Instance[(short)71];

		public static MonthlyEventItem RequestHealth => Instance[(short)72];

		public static MonthlyEventItem RequestHealDisorderOfQi => Instance[(short)73];

		public static MonthlyEventItem RequestNeili => Instance[(short)74];

		public static MonthlyEventItem RequestKillWug => Instance[(short)75];

		public static MonthlyEventItem RequestFood => Instance[(short)76];

		public static MonthlyEventItem RequestTeaWine => Instance[(short)77];

		public static MonthlyEventItem RequestResource => Instance[(short)78];

		public static MonthlyEventItem RequestItem => Instance[(short)79];

		public static MonthlyEventItem RequestRepairItem => Instance[(short)80];

		public static MonthlyEventItem RequestAddPoisonToItem => Instance[(short)81];

		public static MonthlyEventItem RequestInstructionOnLifeSkill => Instance[(short)82];

		public static MonthlyEventItem RequestInstructionOnCombatSkill => Instance[(short)83];

		public static MonthlyEventItem RequestInstructionOnReadingLifeSkill => Instance[(short)84];

		public static MonthlyEventItem RequestInstructionOnReadingCombatSkill => Instance[(short)85];

		public static MonthlyEventItem RequestInstructionOnBreakout => Instance[(short)86];

		public static MonthlyEventItem RequestPlayCombat => Instance[(short)87];

		public static MonthlyEventItem RequestNormalCombat => Instance[(short)88];

		public static MonthlyEventItem RequestLifeSkillBattle => Instance[(short)89];

		public static MonthlyEventItem RequestCricketBattle => Instance[(short)90];

		public static MonthlyEventItem RescueKidnappedCharacterSecretlyButBeCaught => Instance[(short)91];

		public static MonthlyEventItem RescueKidnappedCharacterSecretlyAndEscape => Instance[(short)92];

		public static MonthlyEventItem RescueKidnappedCharacterWithWit => Instance[(short)93];

		public static MonthlyEventItem RescueKidnappedCharacterWithForce => Instance[(short)94];

		public static MonthlyEventItem StealResourceButBeCaught => Instance[(short)95];

		public static MonthlyEventItem StealResourceAndEscape => Instance[(short)96];

		public static MonthlyEventItem ScamResource => Instance[(short)97];

		public static MonthlyEventItem RobResource => Instance[(short)98];

		public static MonthlyEventItem StealItemButBeCaught => Instance[(short)99];

		public static MonthlyEventItem StealItemAndEscape => Instance[(short)100];

		public static MonthlyEventItem ScamItem => Instance[(short)101];

		public static MonthlyEventItem RobItem => Instance[(short)102];

		public static MonthlyEventItem StealLifeSkillButBeCaught => Instance[(short)103];

		public static MonthlyEventItem StealLifeSkillAndEscape => Instance[(short)104];

		public static MonthlyEventItem ScamLifeSkill => Instance[(short)105];

		public static MonthlyEventItem StealCombatSkillButBeCaught => Instance[(short)106];

		public static MonthlyEventItem StealCombatSkillAndEscape => Instance[(short)107];

		public static MonthlyEventItem ScamCombatSkill => Instance[(short)108];

		public static MonthlyEventItem AdviseExtendFavours => Instance[(short)109];

		public static MonthlyEventItem AdviseWinPeopleSupport => Instance[(short)110];

		public static MonthlyEventItem AdviseMerchantFavor => Instance[(short)111];

		public static MonthlyEventItem AdviseTeaWine => Instance[(short)112];

		public static MonthlyEventItem AdviseSales => Instance[(short)113];

		public static MonthlyEventItem AdviseHealInjury => Instance[(short)114];

		public static MonthlyEventItem AdviseHealPoison => Instance[(short)115];

		public static MonthlyEventItem AdviseRepairItem => Instance[(short)116];

		public static MonthlyEventItem AdviseBarb => Instance[(short)117];

		public static MonthlyEventItem AskForMoney => Instance[(short)118];

		public static MonthlyEventItem WulinConferenceTaiwuAbsent => Instance[(short)119];

		public static MonthlyEventItem WulinConferenceAskForHelp => Instance[(short)120];

		public static MonthlyEventItem TaiwuVillageBeDestoryed => Instance[(short)121];

		public static MonthlyEventItem ForeverLoverBePunished => Instance[(short)122];

		public static MonthlyEventItem VillageWoodenManByMonv => Instance[(short)123];

		public static MonthlyEventItem VillageWoodenManByDayueYaochang => Instance[(short)124];

		public static MonthlyEventItem VillageWoodenManByJiuhan => Instance[(short)125];

		public static MonthlyEventItem VillageWoodenManByJinHuanger => Instance[(short)126];

		public static MonthlyEventItem VillageWoodenManByYiYihou => Instance[(short)127];

		public static MonthlyEventItem VillageWoodenManByWeiQi => Instance[(short)128];

		public static MonthlyEventItem VillageWoodenManByYixiang => Instance[(short)129];

		public static MonthlyEventItem VillageWoodenManByXuefeng => Instance[(short)130];

		public static MonthlyEventItem VillageWoodenManByShuFang => Instance[(short)131];

		public static MonthlyEventItem TaiwuNotAttendingWedding => Instance[(short)132];

		public static MonthlyEventItem TaiwuAlreadyMarried => Instance[(short)133];

		public static MonthlyEventItem ChallengeForLegendaryBook => Instance[(short)134];

		public static MonthlyEventItem RequestLegendaryBook => Instance[(short)135];

		public static MonthlyEventItem ExchangeLegendaryBookByMoney => Instance[(short)136];

		public static MonthlyEventItem ExchangeLegendaryBookByAuthority => Instance[(short)137];

		public static MonthlyEventItem ExchangeLegendaryBookByExperience => Instance[(short)138];

		public static MonthlyEventItem StealLegendaryBookAndEscape => Instance[(short)139];

		public static MonthlyEventItem StealLegendaryBookGotCaught => Instance[(short)140];

		public static MonthlyEventItem ScamLegendaryBook => Instance[(short)141];

		public static MonthlyEventItem RobLegendaryBook => Instance[(short)142];

		public static MonthlyEventItem LegendaryBookShockedAttack => Instance[(short)143];

		public static MonthlyEventItem LegendaryBookInsaneAttack => Instance[(short)144];

		public static MonthlyEventItem LegendaryBookConsumedAttack => Instance[(short)145];

		public static MonthlyEventItem SwordTombGetStronger => Instance[(short)146];

		public static MonthlyEventItem SwordTombBackToNormal => Instance[(short)147];

		public static MonthlyEventItem FightForNewLegendaryBook => Instance[(short)148];

		public static MonthlyEventItem FightForLegendaryBookAbandoned => Instance[(short)149];

		public static MonthlyEventItem FightForLegendaryBookOwnerDie => Instance[(short)150];

		public static MonthlyEventItem FightForLegendaryBookOwnerConsumed => Instance[(short)151];

		public static MonthlyEventItem DateWithLoverEveryday => Instance[(short)152];

		public static MonthlyEventItem HappyBirthdayTaiwu => Instance[(short)153];

		public static MonthlyEventItem LoveAnniversary => Instance[(short)154];

		public static MonthlyEventItem NeglectedLover => Instance[(short)155];

		public static MonthlyEventItem LoverBecomeJealous => Instance[(short)156];

		public static MonthlyEventItem LoversBecomeJealousAndViolent => Instance[(short)157];

		public static MonthlyEventItem PregnancyWithLover => Instance[(short)158];

		public static MonthlyEventItem BeggerSkill2TargetUnavailable => Instance[(short)159];

		public static MonthlyEventItem BeggarSkill2TargetBrought => Instance[(short)160];

		public static MonthlyEventItem BeggarSkill2TargetDeadAndMissing => Instance[(short)161];

		public static MonthlyEventItem BeggarSkill2TargetDead => Instance[(short)162];

		public static MonthlyEventItem BeggarSkill2TargetNoneExistent => Instance[(short)163];

		public static MonthlyEventItem TaiwuTribulation => Instance[(short)164];

		public static MonthlyEventItem TaiwuComingSuccess => Instance[(short)165];

		public static MonthlyEventItem TaiwuComingDefeated => Instance[(short)166];

		public static MonthlyEventItem TaiwuFreeAndunFettered => Instance[(short)167];

		public static MonthlyEventItem SectMainStoryXuehouGraveDigging => Instance[(short)172];

		public static MonthlyEventItem SectMainStoryXuehouGraveDiggingNormal => Instance[(short)173];

		public static MonthlyEventItem SectMainStoryXuehouStrangeDeath => Instance[(short)174];

		public static MonthlyEventItem SectMainStoryXuehouOldManAppears => Instance[(short)175];

		public static MonthlyEventItem SectMainStoryXuehouOldManReturns => Instance[(short)176];

		public static MonthlyEventItem SectMainStoryXuehouOnBloodBlock => Instance[(short)177];

		public static MonthlyEventItem SectMainStoryXuehouOldManAttacks => Instance[(short)178];

		public static MonthlyEventItem SectMainStoryXuehouHarmoniousTaiwu => Instance[(short)179];

		public static MonthlyEventItem SectMainStoryXuehouFeedJixi => Instance[(short)180];

		public static MonthlyEventItem SectMainStoryXuehouMythInVillage => Instance[(short)181];

		public static MonthlyEventItem SectMainStoryXuehouProtectJixi => Instance[(short)182];

		public static MonthlyEventItem SectMainStoryXuehouJixiAskForFood => Instance[(short)183];

		public static MonthlyEventItem SectMainStoryXuehouJixiFeedChicken => Instance[(short)184];

		public static MonthlyEventItem SectMainStoryXuehouJixiKills => Instance[(short)185];

		public static MonthlyEventItem SectMainStoryXuehouVillageWork => Instance[(short)186];

		public static MonthlyEventItem SectMainStoryXuehouFinale => Instance[(short)187];

		public static MonthlyEventItem SectMainStoryShaolinTowerFalling => Instance[(short)190];

		public static MonthlyEventItem SectMainStoryShaolinLearning => Instance[(short)193];

		public static MonthlyEventItem SectMainStoryShaolinNotEnough => Instance[(short)194];

		public static MonthlyEventItem SectMainStoryShaolinChallenge => Instance[(short)195];

		public static MonthlyEventItem SectMainStoryShaolinEndChallenge => Instance[(short)196];

		public static MonthlyEventItem SectMainStoryShaolinNeverLearnChallenge => Instance[(short)197];

		public static MonthlyEventItem SectMainStoryXuannvPrologue => Instance[(short)200];

		public static MonthlyEventItem SectMainStoryYuanshanInfectedCharacterAttack => Instance[(short)210];

		public static MonthlyEventItem SectMainStoryYuanshanDisciplesInfected => Instance[(short)211];

		public static MonthlyEventItem SectMainStoryYuanshanLastMonsterAppear => Instance[(short)212];

		public static MonthlyEventItem SectMainStoryYuanshanProsperous => Instance[(short)213];

		public static MonthlyEventItem SectMainStoryShixiangDuel => Instance[(short)217];

		public static MonthlyEventItem SectMainStoryJingangPeopleSuffering => Instance[(short)219];

		public static MonthlyEventItem SectMainStoryJingangAttack => Instance[(short)220];

		public static MonthlyEventItem SectMainStoryJingangMonkMurdered => Instance[(short)221];

		public static MonthlyEventItem SectMainStoryJingangExorcism => Instance[(short)222];

		public static MonthlyEventItem SectMainStoryJingangGhostAppears => Instance[(short)223];

		public static MonthlyEventItem SectMainStoryWuxianPoisonousWug => Instance[(short)227];

		public static MonthlyEventItem SectMainStoryWuxianProsperous => Instance[(short)228];

		public static MonthlyEventItem SectMainStoryWuxianFailing0 => Instance[(short)229];

		public static MonthlyEventItem SectMainStoryWuxianFailing1 => Instance[(short)230];

		public static MonthlyEventItem SectMainStoryWuxianStrangeThings => Instance[(short)231];

		public static MonthlyEventItem SectMainStoryWuxianPoison => Instance[(short)232];

		public static MonthlyEventItem SectMainStoryWuxianAssault => Instance[(short)233];

		public static MonthlyEventItem SectMainStoryEmeiProsperous => Instance[(short)234];

		public static MonthlyEventItem SectMainStoryEmeiFailing => Instance[(short)235];

		public static MonthlyEventItem SectMainStoryJieqingProsperous => Instance[(short)236];

		public static MonthlyEventItem SectMainStoryJieqingFailing => Instance[(short)237];

		public static MonthlyEventItem SectMainStoryXuehouEmptyGrave => Instance[(short)238];

		public static MonthlyEventItem SectMainStoryXuehouLookingForTaiwu => Instance[(short)239];

		public static MonthlyEventItem SectMainStoryXuehouComing => Instance[(short)240];

		public static MonthlyEventItem SectMainStoryRanshanPaperCraneFromYufuFaction => Instance[(short)241];

		public static MonthlyEventItem SectMainStoryRanshanPaperCraneFromShenjianFaction => Instance[(short)242];

		public static MonthlyEventItem SectMainStoryRanshanPaperCraneFromYinyangFaction => Instance[(short)243];

		public static MonthlyEventItem SectMainStoryRanshanProsperous => Instance[(short)244];

		public static MonthlyEventItem SectMainStoryRanshanFailing => Instance[(short)245];

		public static MonthlyEventItem SectMainStoryShaolinDreamOfReadingSutra => Instance[(short)246];

		public static MonthlyEventItem SectMainStoryShaolinDreamOfNewTaiwu => Instance[(short)247];

		public static MonthlyEventItem SectMainStoryShaolinEnlightenment => Instance[(short)248];

		public static MonthlyEventItem SectMainStoryShaolinNotEnoughCommon => Instance[(short)249];

		public static MonthlyEventItem SectMainStoryShixiangRequestBook => Instance[(short)250];

		public static MonthlyEventItem SectMainStoryShixiangRequestLifeSkill => Instance[(short)251];

		public static MonthlyEventItem SectMainStoryShixiangGoodNews => Instance[(short)252];

		public static MonthlyEventItem SectMainStoryShaolinChallengeCommon => Instance[(short)254];

		public static MonthlyEventItem SectMainStoryShaolinEndChallengeCommon => Instance[(short)255];

		public static MonthlyEventItem SectMainStoryShaolinNeverLearnChallengeCommon => Instance[(short)256];

		public static MonthlyEventItem SectMainStoryShixiangLetterFrom2 => Instance[(short)257];

		public static MonthlyEventItem SectMainStoryShixiangGoodNews2 => Instance[(short)258];

		public static MonthlyEventItem SectMainStoryShixiangEnemyAttack2 => Instance[(short)259];

		public static MonthlyEventItem SectMainStoryShixiangStrange => Instance[(short)260];

		public static MonthlyEventItem SectMainStoryWudangProtectHeavenlyTree => Instance[(short)262];

		public static MonthlyEventItem SectMainStoryWudangHeavenlyTreeDestroyed => Instance[(short)263];

		public static MonthlyEventItem SectMainStoryWudangMeetingImmortal => Instance[(short)265];

		public static MonthlyEventItem SectMainStoryWudangGuardHeavenlyTree => Instance[(short)266];

		public static MonthlyEventItem SectMainStoryWudangHeavenlyTreeDestroyed2 => Instance[(short)276];

		public static MonthlyEventItem MirrorCreatedImpostureXiangshuInfected => Instance[(short)277];

		public static MonthlyEventItem SectMainStoryWudangProtectHeavenlyTree2 => Instance[(short)278];

		public static MonthlyEventItem CrossArchiveReunionWithAcquaintance => Instance[(short)279];

		public static MonthlyEventItem TeachCombatSkill => Instance[(short)280];

		public static MonthlyEventItem Pregnant => Instance[(short)281];

		public static MonthlyEventItem TamingCarriers => Instance[(short)282];

		public static MonthlyEventItem FiveLoongLetterFromTaiwuVillage => Instance[(short)283];

		public static MonthlyEventItem JiaoGrowold => Instance[(short)284];

		public static MonthlyEventItem DLCLoongRidingEffectQiuniu => Instance[(short)285];

		public static MonthlyEventItem DLCLoongRidingEffectYazi => Instance[(short)286];

		public static MonthlyEventItem DLCLoongRidingEffectChaofeng => Instance[(short)287];

		public static MonthlyEventItem DLCLoongRidingEffectPulao => Instance[(short)288];

		public static MonthlyEventItem DLCLoongRidingEffectSuanni => Instance[(short)289];

		public static MonthlyEventItem DLCLoongRidingEffectBaxia => Instance[(short)290];

		public static MonthlyEventItem DLCLoongRidingEffectBian => Instance[(short)291];

		public static MonthlyEventItem DLCLoongRidingEffectFuxi => Instance[(short)292];

		public static MonthlyEventItem DLCLoongRidingEffectChiwen => Instance[(short)293];

		public static MonthlyEventItem MinionLoongAttack => Instance[(short)294];

		public static MonthlyEventItem DLCLoongJiaoGrowUp => Instance[(short)295];

		public static MonthlyEventItem SectMainStoryWuxianGiftsReceived => Instance[(short)296];

		public static MonthlyEventItem SectMainStoryJingangVisitorsArrive => Instance[(short)297];

		public static MonthlyEventItem SectMainStoryJingangLettersFromJingang => Instance[(short)298];

		public static MonthlyEventItem SectMainStoryJingangPiety => Instance[(short)299];

		public static MonthlyEventItem SectMainStoryJingangRitualsInDream => Instance[(short)301];

		public static MonthlyEventItem SectMainStoryJingangReincarnation => Instance[(short)304];

		public static MonthlyEventItem SectMainStoryJingangGhostVanishes => Instance[(short)305];

		public static MonthlyEventItem SectMainStoryWuxianMiaoWoman => Instance[(short)306];

		public static MonthlyEventItem SectMainStoryRanshanDragonGate => Instance[(short)307];

		public static MonthlyEventItem SectMainStoryRanshanMessage => Instance[(short)308];

		public static MonthlyEventItem SectMainStoryRanshanAfterQinglang => Instance[(short)309];

		public static MonthlyEventItem SectMainStoryRanshanSanshiLeave => Instance[(short)310];

		public static MonthlyEventItem SectMainStoryBaihuaEndenmic => Instance[(short)311];

		public static MonthlyEventItem SectMainStoryBaihuaDreamAboutPastLast => Instance[(short)313];

		public static MonthlyEventItem SectMainStoryBaihuaLeukoKills => Instance[(short)317];

		public static MonthlyEventItem MerchantVisit => Instance[(short)318];

		public static MonthlyEventItem ToRepayKindness => Instance[(short)319];

		public static MonthlyEventItem SectMainStoryBaihuaAmbushLeuko => Instance[(short)320];

		public static MonthlyEventItem SectMainStoryBaihuaMelanoKills => Instance[(short)321];

		public static MonthlyEventItem SectMainStoryBaihuaAmbushMelano => Instance[(short)322];

		public static MonthlyEventItem SectMainStoryBaihuaManicAttack => Instance[(short)325];

		public static MonthlyEventItem SectMainStoryBaihuaAnonymReturns => Instance[(short)326];

		public static MonthlyEventItem SectMainStoryBaihuaMelanoPlay => Instance[(short)328];

		public static MonthlyEventItem SectMainStoryBaihuaLeukoPlay => Instance[(short)329];

		public static MonthlyEventItem SectMainStoryBaihuaLeukoMelanoPlay => Instance[(short)330];

		public static MonthlyEventItem SectMainStoryFulongDiasterAppear => Instance[(short)331];

		public static MonthlyEventItem SectMainStoryFulongLazuliLetter => Instance[(short)333];

		public static MonthlyEventItem HuntCriminal => Instance[(short)336];

		public static MonthlyEventItem SentenceCompleted => Instance[(short)337];

		public static MonthlyEventItem SectMainStoryFulongRobTaiwu => Instance[(short)338];

		public static MonthlyEventItem SectMainStoryFulongInterfereRobbery => Instance[(short)339];

		public static MonthlyEventItem SectMainStoryFulongProtect => Instance[(short)340];

		public static MonthlyEventItem SectMainStoryFulongFireFighting => Instance[(short)341];

		public static MonthlyEventItem AdviseHealDisorderOfQi => Instance[(short)343];

		public static MonthlyEventItem AdviseHealHealth => Instance[(short)344];

		public static MonthlyEventItem TaiWuVillagerClothing => Instance[(short)345];

		public static MonthlyEventItem HuntCriminalTaiwu => Instance[(short)346];

		public static MonthlyEventItem SectMainStoryZhujianHeir => Instance[(short)347];

		public static MonthlyEventItem SectMainStoryZhujianFailing => Instance[(short)352];

		public static MonthlyEventItem JieQingPunishmentAssassin => Instance[(short)353];

		public static MonthlyEventItem TaiwuBeHuntedHunterDie => Instance[(short)354];

		public static MonthlyEventItem WardOffXiangshuProtection => Instance[(short)355];

		public static MonthlyEventItem ProfessionDukeReceiveCricket => Instance[(short)356];

		public static MonthlyEventItem CricketInDreamTaiwuPartnerPregnant => Instance[(short)357];

		public static MonthlyEventItem SectMainStoryShaolinDharmaCave => Instance[(short)358];

		public static MonthlyEventItem TaiwuVillageStoneClaimed => Instance[(short)359];

		public static MonthlyEventItem TaiwuVillagerAdoptOrphan => Instance[(short)360];

		public static MonthlyEventItem NormalHeavenlyTreeDestroyed => Instance[(short)363];

		public static MonthlyEventItem NormalGuardHeavenlyTree => Instance[(short)364];

		public static MonthlyEventItem BackFromOuterWorlds => Instance[(short)374];

		public static MonthlyEventItem AiLongDistanceMarriageAskAdvice => Instance[(short)378];

		public static MonthlyEventItem DLCYearOfHorseCloth => Instance[(short)393];

		public static MonthlyEventItem Bequest => Instance[(short)394];

		public static MonthlyEventItem MainStoryTianmuPeopleRemoveItem => Instance[(short)395];

		public static MonthlyEventItem MainStoryImmortalXuSeekSacrifice => Instance[(short)396];

		public static MonthlyEventItem MainStoryHeavenlyDarkFire => Instance[(short)397];

		public static MonthlyEventItem MainStoryWuxiaoSpiritSection0 => Instance[(short)398];

		public static MonthlyEventItem MainStoryWuxiaoSpiritSection1 => Instance[(short)399];

		public static MonthlyEventItem MainStoryWuxiaoSpiritSection2 => Instance[(short)400];

		public static MonthlyEventItem MainStoryThreeWorldDevilAppear => Instance[(short)401];

		public static MonthlyEventItem MainStoryThreeWorldDevilFire => Instance[(short)402];

		public static MonthlyEventItem MainStoryThreeWorldDevilBlood => Instance[(short)403];

		public static MonthlyEventItem MainStoryThreeWorldDevilMelee => Instance[(short)404];

		public static MonthlyEventItem MainStoryImmortalXuStolen => Instance[(short)405];

		public static MonthlyEventItem DLCTransmogrifyingCricketToHumanbeing => Instance[(short)406];

		public static MonthlyEventItem DLCTransmogrifyingHumanbeingToCricket => Instance[(short)407];

		public static MonthlyEventItem SectMainStoryJieqingBloodBeiDou => Instance[(short)408];

		public static MonthlyEventItem SectMainStoryJieqingMessage => Instance[(short)409];

		public static MonthlyEventItem SectMainStoryJieqingSmashPearl => Instance[(short)410];

		public static MonthlyEventItem SectMainStoryJieqingRecovery => Instance[(short)411];

		public static MonthlyEventItem SectMainStoryJieqingAssassination => Instance[(short)412];

		public static MonthlyEventItem DLCGiftFromConchShip1 => Instance[(short)413];

		public static MonthlyEventItem DLCGiftFromConchShip2 => Instance[(short)414];

		public static MonthlyEventItem DLCHappyNewYear2024 => Instance[(short)415];

		public static MonthlyEventItem DLCYearOfSnakeCloth => Instance[(short)416];

		public static MonthlyEventItem MainStoryLineIronPlateMonkInvestigate => Instance[(short)417];

		public static MonthlyEventItem MainStoryLineIronPlateItemReceived => Instance[(short)418];

		public static MonthlyEventItem MainStoryLineEvilDemonBlood => Instance[(short)419];

		public static MonthlyEventItem MainStoryLineEvilMohaMind => Instance[(short)420];

		public static MonthlyEventItem MainStoryLineEvilBloodAdv => Instance[(short)421];

		public static MonthlyEventItem MainStoryLineDivineflameFuxietie => Instance[(short)422];

		public static MonthlyEventItem MainStoryLineDivineflameJielongpo => Instance[(short)423];

		public static MonthlyEventItem MainStoryLineDivineflameDaxuanning => Instance[(short)424];

		public static MonthlyEventItem MainStoryLineDivineflameQiumomu => Instance[(short)425];

		public static MonthlyEventItem MainStoryLineDivineflameFenshenlian => Instance[(short)426];

		public static MonthlyEventItem MainStoryLineDivineflameRongchenyin => Instance[(short)427];

		public static MonthlyEventItem MainStoryLineDivineflameFenghuangjian => Instance[(short)428];

		public static MonthlyEventItem MainStoryLineDivineflameGuishenxia => Instance[(short)429];

		public static MonthlyEventItem MainStoryLineDivineflameMonvyi => Instance[(short)430];

		public static MonthlyEventItem SectMainStoryEmeiUpgradeRumors => Instance[(short)431];

		public static MonthlyEventItem SectMainStoryEmeiUpgradeStudy => Instance[(short)432];

		public static MonthlyEventItem SectMainStoryEmeiUpgradeAchieve => Instance[(short)433];

		public static MonthlyEventItem MakeLoveWithTaiwu => Instance[(short)434];

		public static MonthlyEventItem SwordFragmentUnlockSkillMonvGood => Instance[(short)435];

		public static MonthlyEventItem SwordFragmentUnlockSkillMonvBad => Instance[(short)436];

		public static MonthlyEventItem SwordFragmentUnlockSkillDayueYaochangGood => Instance[(short)437];

		public static MonthlyEventItem SwordFragmentUnlockSkillDayueYaochangBad => Instance[(short)438];

		public static MonthlyEventItem SwordFragmentUnlockSkillJiuhanGood => Instance[(short)439];

		public static MonthlyEventItem SwordFragmentUnlockSkillJiuhanBad => Instance[(short)440];

		public static MonthlyEventItem SwordFragmentUnlockSkillJinHuangerGood => Instance[(short)441];

		public static MonthlyEventItem SwordFragmentUnlockSkillJinHuangerBad => Instance[(short)442];

		public static MonthlyEventItem SwordFragmentUnlockSkillYiYihouGood => Instance[(short)443];

		public static MonthlyEventItem SwordFragmentUnlockSkillYiYihouBad => Instance[(short)444];

		public static MonthlyEventItem SwordFragmentUnlockSkillWeiQiGood => Instance[(short)445];

		public static MonthlyEventItem SwordFragmentUnlockSkillWeiQiBad => Instance[(short)446];

		public static MonthlyEventItem SwordFragmentUnlockSkillYixiangGood => Instance[(short)447];

		public static MonthlyEventItem SwordFragmentUnlockSkillYixiangBad => Instance[(short)448];

		public static MonthlyEventItem SwordFragmentUnlockSkillXuefengGood => Instance[(short)449];

		public static MonthlyEventItem SwordFragmentUnlockSkillXuefengBad => Instance[(short)450];

		public static MonthlyEventItem SwordFragmentUnlockSkillShuFangGood => Instance[(short)451];

		public static MonthlyEventItem SwordFragmentUnlockSkillShuFangBad => Instance[(short)452];

		public static MonthlyEventItem MainStoryMessagefromtheAvatar => Instance[(short)453];

		public static MonthlyEventItem MainStoryTidingsonSwiftBlades => Instance[(short)454];

		public static MonthlyEventItem MainStoryMessagefromanOldFriend => Instance[(short)455];

		public static MonthlyEventItem MainStoryTidingsfromanOldFriend => Instance[(short)456];

		public static MonthlyEventItem MainStoryMessagefromWunian => Instance[(short)457];

		public static MonthlyEventItem MainStoryTidingsoftheMind => Instance[(short)458];

		public static MonthlyEventItem MainStoryStirringoftheSwordHilt => Instance[(short)459];

		public static MonthlyEventItem MainStoryMoonlitPurpleDust => Instance[(short)460];

		public static MonthlyEventItem MainStoryMidnightUpheaval => Instance[(short)461];

		public static MonthlyEventItem MainStoryStrangeFireScorchestheSky => Instance[(short)462];

		public static MonthlyEventItem SectMainStoryJieQingUpgradeYuchan => Instance[(short)463];

		public static MonthlyEventItem SectMainStoryJieQingUpgradeXingYun => Instance[(short)464];

		public static MonthlyEventItem XiangshuAvatarAttack => Instance[(short)465];

		public static MonthlyEventItem SectMainStoryEmeiBeginning => Instance[(short)466];

		public static MonthlyEventItem SectMainStoryEmeiMidnight => Instance[(short)467];

		public static MonthlyEventItem SectMainStoryEmeiSecretLetter => Instance[(short)468];

		public static MonthlyEventItem SectMainStoryEmeiUrgentLetter => Instance[(short)469];

		public static MonthlyEventItem SectMainStoryEmeiFruitsGift => Instance[(short)470];

		public static MonthlyEventItem SectMainStoryEmeiAppreciateofEmei => Instance[(short)471];

		public static MonthlyEventItem SectMainStoryEmeiFarewell => Instance[(short)472];

		public static MonthlyEventItem MainStoryImmortalChiHongZi => Instance[(short)473];

		public static MonthlyEventItem MainStoryImmortalPoJinShangRen => Instance[(short)474];

		public static MonthlyEventItem MainStoryImmortalBaJiuJianYin => Instance[(short)475];

		public static MonthlyEventItem MainStoryImmortalZhenDanShengNv => Instance[(short)476];

		public static MonthlyEventItem DLCGreenHillsRemain => Instance[(short)477];

		public static MonthlyEventItem DLCEightYearsOneJourney => Instance[(short)478];

		public static MonthlyEventItem MainStoryImmortalHuoGuShi => Instance[(short)479];

		public static MonthlyEventItem WulinConferenceGift => Instance[(short)480];

		public static MonthlyEventItem DLCSmarterChickenKingBecomeHuman => Instance[(short)481];

		public static MonthlyEventItem DLCTransmogrifyingHumanToChicken => Instance[(short)482];

		public static MonthlyEventItem DLCAdoptChicken => Instance[(short)483];

		public static MonthlyEventItem DLCTameLoongPolymorphReturn => Instance[(short)484];

		public static MonthlyEventItem TaiwuAsXiangshuSkill0 => Instance[(short)485];

		public static MonthlyEventItem TaiwuAsXiangshuLittleMonkGift => Instance[(short)486];
	}

	public static MonthlyEvent Instance = new MonthlyEvent();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "TemplateId", "Event", "Icon", "MergeableParameters", "AutoTriggerArguments" };

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
		_dataArray.Add(new MonthlyEventItem(0, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_0"), EMonthlyEventType.NormalEvent, null, "sp_monthlyevent_2", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_0"), new string[7] { "ItemKey", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(1, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_1"), EMonthlyEventType.LockedEvent, "24b66f5e-cd47-486c-ad8f-6e069bd8dd71", "sp_monthlyevent_0", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_1"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(2, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_2"), EMonthlyEventType.LockedEvent, "84d406db-8da7-4128-b52b-92ede33eff20", "sp_monthlyevent_0", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_2"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(3, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_3"), EMonthlyEventType.LockedEvent, "24b66f5e-cd47-486c-ad8f-6e069bd8dd71", "sp_monthlyevent_1", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_3"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(4, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_4"), EMonthlyEventType.SpecialEvent, "ffdda15e-c734-4bd3-842f-cb1e0170f4ca", "sp_monthlyevent_5", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_4"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(5, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_5"), EMonthlyEventType.SpecialEvent, "1e7e65eb-7889-49a8-a88c-0fb53b2bce08", "sp_monthlyevent_3", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_5"), new string[7] { "Location", "CharacterTemplate", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: false, 0u));
		_dataArray.Add(new MonthlyEventItem(6, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_6"), EMonthlyEventType.SpecialEvent, "31f73af4-dfe0-4780-891b-af84e2112024", "sp_monthlyevent_86", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_6"), new string[7] { "Location", "CharacterTemplate", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: false, 0u));
		_dataArray.Add(new MonthlyEventItem(7, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_7"), EMonthlyEventType.SpecialEvent, "6839f74d-a797-4057-9d3c-54526c75b17c", "sp_monthlyevent_4", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_7"), new string[7] { "Location", "CharacterTemplate", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: false, 0u));
		_dataArray.Add(new MonthlyEventItem(8, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_8"), EMonthlyEventType.SpecialEvent, "35d08ee0-3f8b-4100-957a-b9a601ed400b", "sp_monthlyevent_88", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_8"), new string[7] { "Location", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: false, 0u));
		_dataArray.Add(new MonthlyEventItem(9, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_9"), EMonthlyEventType.SpecialEvent, "b741c428-7bab-4856-b6cf-d55b2ad78d93", "sp_monthlyevent_88", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_9"), new string[7] { "Location", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: false, 0u));
		_dataArray.Add(new MonthlyEventItem(10, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_10"), EMonthlyEventType.NormalEvent, "8556787a-6a5f-413e-a2f6-56ed2d4330f1", "sp_monthlyevent_6", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_10"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(11, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_11"), EMonthlyEventType.NormalEvent, "eea2f834-8d4d-456c-bd4e-eb41f9554011", "sp_monthlyevent_7", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_11"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(12, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_12"), EMonthlyEventType.NormalEvent, "a5d13b65-9503-496d-bea2-4f89196ca6f7", "sp_monthlyevent_8", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_12"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(13, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_13"), EMonthlyEventType.NormalEvent, "a73cc160-a95d-42c3-b986-a0353df434f0", "sp_monthlyevent_83", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_13"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(14, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_14"), EMonthlyEventType.NormalEvent, "b2d104a6-b1ea-4cbb-8043-54d8da07176c", "sp_monthlyevent_9", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_14"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(15, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_15"), EMonthlyEventType.NormalEvent, "be5c842e-d69f-40e3-961d-b49ba7186fc2", "sp_monthlyevent_9", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_15"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(16, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_16"), EMonthlyEventType.LockedEvent, "c6a8fff1-8d8e-4f14-91b8-3bf49bdd1a29", "sp_monthlyevent_10", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_16"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(17, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_17"), EMonthlyEventType.NormalEvent, "1f5bbc25-26db-46cc-bd85-54833cf2367a", "sp_monthlyevent_10", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_17"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(18, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_18"), EMonthlyEventType.NormalEvent, "7c8b6585-2d4a-4ae6-a0f8-a2228486271c", "sp_monthlyevent_9", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_18"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(19, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_19"), EMonthlyEventType.NormalEvent, "26c12b8e-2808-43d7-a00e-af970cb459bf", "sp_monthlyevent_9", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_19"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(20, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_20"), EMonthlyEventType.NormalEvent, "a86f7e1e-921b-42b8-9555-dec674e2df25", "sp_monthlyevent_11", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_20"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(21, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_21"), EMonthlyEventType.NormalEvent, "2425d411-1f0b-4482-b610-89ef5a7db33f", "sp_monthlyevent_12", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_21"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(22, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_22"), EMonthlyEventType.NormalEvent, "699239c9-8293-4b21-b479-daf07983156e", "sp_monthlyevent_11", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_22"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(23, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_23"), EMonthlyEventType.NormalEvent, "1612d6ee-f4fe-4ce1-9174-4fe434a8225a", "sp_monthlyevent_12", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_23"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(24, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_24"), EMonthlyEventType.LockedEvent, "4a3a0d8a-3140-400f-b444-f9ecb209cfba", "sp_monthlyevent_13", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_24"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(25, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_25"), EMonthlyEventType.LockedEvent, "2a0e5ea0-8418-4cc3-ba47-20bd9b2c5707", "sp_monthlyevent_13", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_25"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(26, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_26"), EMonthlyEventType.NormalEvent, "2c353211-ec1c-49dd-94cc-b396821348de", "sp_monthlyevent_13", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_26"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(27, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_27"), EMonthlyEventType.NormalEvent, "ac07bc64-eb8b-4214-92e4-15a63b77af40", "sp_monthlyevent_13", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_27"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(28, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_28"), EMonthlyEventType.NormalEvent, "a572973e-af1e-4ff8-8e12-884b28671281", "sp_monthlyevent_11", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_28"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(29, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_29"), EMonthlyEventType.NormalEvent, "fd9e4d4d-c8c1-4858-880b-7d6cb01f959b", "sp_monthlyevent_12", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_29"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(30, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_30"), EMonthlyEventType.NormalEvent, "78513fac-0ba8-4c46-b892-26d8d1dc79f3", "sp_monthlyevent_11", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_30"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(31, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_31"), EMonthlyEventType.NormalEvent, "a224107b-2909-4f02-882e-a84f2cad38ee", "sp_monthlyevent_12", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_31"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(32, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_32"), EMonthlyEventType.NormalEvent, "8812d517-ca0a-4f9d-83e8-936376ae11c4", "sp_monthlyevent_14", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_32"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(33, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_33"), EMonthlyEventType.NormalEvent, "3da0ed73-3abe-47c4-9990-91beeca7e831", "sp_monthlyevent_15", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_33"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(34, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_34"), EMonthlyEventType.NormalEvent, "90f67007-3c35-4b12-990e-66babdd88fed", "sp_monthlyevent_16", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_34"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(35, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_35"), EMonthlyEventType.NormalEvent, "e7921be6-80b9-41e1-90e4-956461e282ba", "sp_monthlyevent_17", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_35"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(36, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_36"), EMonthlyEventType.NormalEvent, "2c295340-baa0-44a6-a8f4-858a959b2fb9", "sp_monthlyevent_18", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_36"), new string[7] { "Character", "Character", "Character", "Character", "Character", "Character", "Character" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(37, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_37"), EMonthlyEventType.NormalEvent, "ffe2e080-8c18-4e8c-9073-e78d04fa061b", "sp_monthlyevent_19", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_37"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(38, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_38"), EMonthlyEventType.NormalEvent, "e1f06054-115f-48d6-b8c2-eeb8f62bafe0", "sp_monthlyevent_20", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_38"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(39, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_39"), EMonthlyEventType.NormalEvent, "e859cd22-0fae-4356-8ae3-903c7bc82972", "sp_monthlyevent_21", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_39"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(40, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_40"), EMonthlyEventType.NormalEvent, "4fbe0a50-be4f-42fd-9341-7b8498bae3e1", "sp_monthlyevent_22", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_40"), new string[7] { "Location", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(41, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_41"), EMonthlyEventType.NormalEvent, "80f68c9a-9506-4814-9215-5e8dd2698719", "sp_monthlyevent_23", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_41"), new string[7] { "Location", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(42, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_42"), EMonthlyEventType.NormalEvent, "8d3de6a1-1d88-4bfa-99be-6722ed08b8f3", "sp_monthlyevent_24", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_42"), new string[7] { "LifeSkill", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(43, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_43"), EMonthlyEventType.NormalEvent, "471ea810-7be4-454c-8375-d6f2477a93ac", "sp_monthlyevent_25", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_43"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(44, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_44"), EMonthlyEventType.NormalEvent, "b335cd4b-0ce3-4882-a5bb-f2d2ad699b11", "sp_monthlyevent_26", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_44"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(45, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_45"), EMonthlyEventType.NormalEvent, "11ce2ba2-5abc-4f9e-9fbc-8892f03cd8f6", "sp_monthlyevent_27", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_45"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(46, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_46"), EMonthlyEventType.NormalEvent, "8ce2db54-994d-4790-bfe3-6cedd7473277", "sp_monthlyevent_28", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_46"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(47, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_47"), EMonthlyEventType.NormalEvent, "63a3c0e9-cf75-4c03-9453-48841d3e9fa9", "sp_monthlyevent_29", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_47"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(48, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_48"), EMonthlyEventType.NormalEvent, "9c81352d-b715-4554-85fc-50322fe428f6", "sp_monthlyevent_30", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_48"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(49, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_49"), EMonthlyEventType.NormalEvent, "a546e498-7128-49df-ab14-09a6474cbc66", "sp_monthlyevent_31", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_49"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(50, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_50"), EMonthlyEventType.NormalEvent, "abce40cd-8b67-41a6-8015-d927d6f6ef3b", "sp_monthlyevent_32", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_50"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(51, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_51"), EMonthlyEventType.NormalEvent, "9ba8de0b-1ffa-4083-9024-d349ec65cad3", "sp_monthlyevent_33", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_51"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(52, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_52"), EMonthlyEventType.NormalEvent, "9836cfcf-3ff9-4724-b7d1-be307fee808b", "sp_monthlyevent_34", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_52"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(53, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_53"), EMonthlyEventType.NormalEvent, "f81b923a-110d-4956-8fab-802650fb5afd", "sp_monthlyevent_35", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_53"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(54, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_54"), EMonthlyEventType.NormalEvent, "135e6b5f-afb8-4bbe-a50f-0e040a8ba52a", "sp_monthlyevent_36", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_54"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(55, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_55"), EMonthlyEventType.NormalEvent, "940bdcc2-59f8-483b-86e9-d80ced06fd40", "sp_monthlyevent_37", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_55"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(56, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_56"), EMonthlyEventType.NormalEvent, "6a905b7f-80e2-49dd-9539-a7e79f57454d", "sp_monthlyevent_38", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_56"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(57, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_57"), EMonthlyEventType.NormalEvent, "20eec777-8c29-45d1-9acc-7474942ab49c", "sp_monthlyevent_39", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_57"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(58, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_58"), EMonthlyEventType.NormalEvent, "cb6c9034-4da1-4d27-8b32-4ce6034d75d2", "sp_monthlyevent_40", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_58"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(59, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_59"), EMonthlyEventType.NormalEvent, "e7dfbf0a-8fec-4e33-b4f7-2fc93a9799f1", "sp_monthlyevent_41", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_59"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new MonthlyEventItem(60, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_60"), EMonthlyEventType.SpecialEvent, "98c52d02-36aa-4293-9d40-5573f3322dac", "sp_monthlyevent_42", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_60"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(61, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_61"), EMonthlyEventType.NormalEvent, "17093897-d8d9-4d7d-86ed-229cc4e85afd", "sp_monthlyevent_43", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_61"), new string[7] { "Character", "Location", "Character", "Character", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(62, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_62"), EMonthlyEventType.NormalEvent, "79ab2055-ccab-41b9-af31-c9e5918a7893", "sp_monthlyevent_44", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_62"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(63, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_63"), EMonthlyEventType.NormalEvent, "4f418b2e-be18-4c1a-aa3a-306fcf929357", "sp_monthlyevent_44", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_63"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(64, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_64"), EMonthlyEventType.NormalEvent, "60d93b13-33b6-4be7-9a3b-7253275a2696", "sp_monthlyevent_45", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_64"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(65, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_65"), EMonthlyEventType.NormalEvent, "b1e95ac4-0d8e-4b9e-954e-0ccd7c5e7c41", "sp_monthlyevent_45", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_65"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(66, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_66"), EMonthlyEventType.NormalEvent, "3af56371-f736-4aa9-ae9b-c3c98ba0f4b0", "sp_monthlyevent_46", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_66"), new string[7] { "Character", "Location", "Character", "ItemKey", "BodyPartType", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(67, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_67"), EMonthlyEventType.NormalEvent, "d58fceec-2d53-4532-9893-d834db626b35", "sp_monthlyevent_46", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_67"), new string[7] { "Character", "Location", "Character", "Integer", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(68, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_68"), EMonthlyEventType.NormalEvent, "3f335f54-d401-4951-9b9e-61c82c7d5bbc", "sp_monthlyevent_46", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_68"), new string[7] { "Character", "Location", "Character", "ItemKey", "BodyPartType", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(69, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_69"), EMonthlyEventType.NormalEvent, "3c71d6c1-f5a0-4e20-9eca-280dde1b2f84", "sp_monthlyevent_46", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_69"), new string[7] { "Character", "Location", "Character", "Integer", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(70, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_70"), EMonthlyEventType.NormalEvent, "1deadcc9-cca4-4091-8276-5f3a8b136fe0", "sp_monthlyevent_47", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_70"), new string[7] { "Character", "Location", "Character", "ItemKey", "PoisonType", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(71, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_71"), EMonthlyEventType.NormalEvent, "d799f11c-7ff7-4f9e-83a6-192753411e7b", "sp_monthlyevent_47", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_71"), new string[7] { "Character", "Location", "Character", "Integer", "PoisonType", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(72, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_72"), EMonthlyEventType.NormalEvent, "66fe331f-7bb2-422b-9a3e-892859eedb55", "sp_monthlyevent_48", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_72"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(73, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_73"), EMonthlyEventType.NormalEvent, "03b005e1-e0c6-4726-abc7-4e3121116049", "sp_monthlyevent_48", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_73"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(74, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_74"), EMonthlyEventType.NormalEvent, "d2e80cb3-4c6f-471d-83f9-422bbcab2d7f", "sp_monthlyevent_48", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_74"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(75, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_75"), EMonthlyEventType.NormalEvent, "d7ec7e02-ee62-4137-a8cb-a4961ec28bb0", "sp_monthlyevent_47", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_75"), new string[7] { "Character", "Location", "Character", "ItemKey", "ItemKey", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(76, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_76"), EMonthlyEventType.NormalEvent, "560cee7d-3955-4650-8fbf-cf66e80a321d", "sp_monthlyevent_49", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_76"), new string[7] { "Character", "Location", "Character", "ItemKey", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(77, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_77"), EMonthlyEventType.NormalEvent, "e6a1795d-e1a1-46af-b977-f821fc1441f5", "sp_monthlyevent_49", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_77"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(78, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_78"), EMonthlyEventType.NormalEvent, "16bddd08-6083-4c11-9342-78922ed19b6b", "sp_monthlyevent_49", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_78"), new string[7] { "Character", "Location", "Character", "Integer", "Resource", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(79, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_79"), EMonthlyEventType.NormalEvent, "7ac0429a-a48f-4adb-be4b-4cb767d978e4", "sp_monthlyevent_49", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_79"), new string[7] { "Character", "Location", "Character", "ItemKey", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(80, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_80"), EMonthlyEventType.NormalEvent, "a61df3c7-c29b-4a81-b4c8-da7651c931e8", "sp_monthlyevent_50", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_80"), new string[7] { "Character", "Location", "Character", "ItemKey", "ItemKey", "Integer", "Resource" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(81, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_81"), EMonthlyEventType.NormalEvent, "7386d3bc-3ebe-4603-b771-1f61f7a166b2", "sp_monthlyevent_50", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_81"), new string[7] { "Character", "Location", "Character", "ItemKey", "ItemKey", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(82, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_82"), EMonthlyEventType.NormalEvent, "cbb59e89-a125-42ab-8692-e522c44a0bc8", "sp_monthlyevent_51", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_82"), new string[7] { "Character", "Location", "Character", "Item", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(83, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_83"), EMonthlyEventType.NormalEvent, "eb7f0c2a-60f9-4221-97e5-662d513620c1", "sp_monthlyevent_51", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_83"), new string[7] { "Character", "Location", "Character", "Item", "Integer", "Integer", "Integer" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(84, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_84"), EMonthlyEventType.NormalEvent, "1735b4a9-4ece-4ff9-83f3-fa005cfa33e8", "sp_monthlyevent_52", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_84"), new string[7] { "Character", "Location", "Character", "ItemKey", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(85, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_85"), EMonthlyEventType.NormalEvent, "9804522b-8380-4950-9996-f15a8387d802", "sp_monthlyevent_53", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_85"), new string[7] { "Character", "Location", "Character", "ItemKey", "Integer", "Integer", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(86, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_86"), EMonthlyEventType.NormalEvent, "6c91f53d-6eb8-43e5-812d-e1838cab5c57", "sp_monthlyevent_84", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_86"), new string[7] { "Character", "Location", "Character", "CombatSkill", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(87, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_87"), EMonthlyEventType.NormalEvent, "c485c693-5ff0-45ec-933c-62c75a045fee", "sp_monthlyevent_54", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_87"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(88, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_88"), EMonthlyEventType.NormalEvent, "7d52876b-b8e7-421c-a4a7-a93916431aa3", "sp_monthlyevent_55", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_88"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(89, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_89"), EMonthlyEventType.NormalEvent, "c2019d63-3dc0-481c-9a9d-8f11afdea032", "sp_monthlyevent_56", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_89"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(90, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_90"), EMonthlyEventType.NormalEvent, "79c5748c-aac6-4e77-b32d-32bfd59be5f5", "sp_monthlyevent_57", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_90"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(91, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_91"), EMonthlyEventType.NormalEvent, "24dd3ebb-4d21-492c-95e8-f7bd68c720ce", "sp_monthlyevent_58", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_91"), new string[7] { "Character", "Location", "Character", "Character", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(92, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_92"), EMonthlyEventType.NormalEvent, "6ea53aad-a7a9-42d4-b604-4cb449cc307b", "sp_monthlyevent_59", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_92"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(93, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_93"), EMonthlyEventType.SpecialEvent, "e81ef0d1-64ac-466d-9c12-730c0da1c6e7", "sp_monthlyevent_60", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_93"), new string[7] { "Character", "Location", "Character", "Character", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(94, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_94"), EMonthlyEventType.SpecialEvent, "202a620d-cee9-4df1-a48d-08a0a12e1dcc", "sp_monthlyevent_61", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_94"), new string[7] { "Character", "Location", "Character", "Character", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(95, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_95"), EMonthlyEventType.NormalEvent, "7862ad2f-0d39-4f35-bf68-ed9817cf9d3b", "sp_monthlyevent_62", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_95"), new string[7] { "Character", "Location", "Character", "Resource", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(96, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_96"), EMonthlyEventType.NormalEvent, "2e6e8d8e-1b7e-4826-8a88-c7d548a56281", "sp_monthlyevent_63", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_96"), new string[7] { "Character", "Location", "Character", "Resource", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(97, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_97"), EMonthlyEventType.SpecialEvent, "217e62da-2a6a-4496-905d-9722a84e4a38", "sp_monthlyevent_65", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_97"), new string[7] { "Character", "Location", "Character", "Resource", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(98, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_98"), EMonthlyEventType.SpecialEvent, "5392cdf7-2f52-4c14-9416-3025676d9dcc", "sp_monthlyevent_64", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_98"), new string[7] { "Character", "Location", "Character", "Resource", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(99, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_99"), EMonthlyEventType.NormalEvent, "7c4b526f-e634-4cac-94af-e64ae059910f", "sp_monthlyevent_62", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_99"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(100, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_100"), EMonthlyEventType.NormalEvent, "369a71c6-319a-4427-8729-df9fba616682", "sp_monthlyevent_63", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_100"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(101, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_101"), EMonthlyEventType.SpecialEvent, "32e1edf9-4c1c-4adf-819b-a3009e650a32", "sp_monthlyevent_65", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_101"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(102, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_102"), EMonthlyEventType.SpecialEvent, "f3341e73-d607-4d0d-b3c1-ed4c5ccd0e74", "sp_monthlyevent_64", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_102"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(103, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_103"), EMonthlyEventType.NormalEvent, "3abe4e48-fab7-4619-bfc9-656c06dead27", "sp_monthlyevent_66", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_103"), new string[7] { "Character", "Location", "Character", "Item", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(104, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_104"), EMonthlyEventType.NormalEvent, "266de680-6160-4a10-af71-678481915019", "sp_monthlyevent_67", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_104"), new string[7] { "Character", "Location", "Character", "Item", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(105, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_105"), EMonthlyEventType.SpecialEvent, "e8912b09-71bd-4254-93b2-ed6266f5f8fa", "sp_monthlyevent_68", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_105"), new string[7] { "Character", "Location", "Character", "Item", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(106, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_106"), EMonthlyEventType.NormalEvent, "e4df3573-eaa7-4bec-a7f0-b528e2078d0f", "sp_monthlyevent_69", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_106"), new string[7] { "Character", "Location", "Character", "Item", "Integer", "Integer", "Integer" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(107, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_107"), EMonthlyEventType.NormalEvent, "9fc43b8f-11cd-434a-b324-6a7ad2c45bd5", "sp_monthlyevent_70", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_107"), new string[7] { "Character", "Location", "Character", "Item", "Integer", "Integer", "Integer" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(108, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_108"), EMonthlyEventType.SpecialEvent, "514e2102-26fb-4fe8-9a79-48e919c5acaa", "sp_monthlyevent_71", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_108"), new string[7] { "Character", "Location", "Character", "Item", "Integer", "Integer", "Integer" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(109, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_109"), EMonthlyEventType.NormalEvent, "eb338657-9fec-4129-bbbe-3e4390606d7e", "sp_monthlyevent_72", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_109"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(110, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_110"), EMonthlyEventType.NormalEvent, "657c9c77-5690-4e32-bbfc-245b44489374", "sp_monthlyevent_73", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_110"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(111, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_111"), EMonthlyEventType.NormalEvent, "dec0683d-fade-4a91-94b7-125cf2394aab", "sp_monthlyevent_74", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_111"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(112, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_112"), EMonthlyEventType.NormalEvent, "13a9669f-1e5b-4519-99df-1123c41b0132", "sp_monthlyevent_75", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_112"), new string[7] { "Character", "Location", "Character", "ItemKey", "ItemKey", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(113, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_113"), EMonthlyEventType.NormalEvent, "c86ac53a-cc8b-4208-bed6-366ac194572d", "sp_monthlyevent_76", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_113"), new string[7] { "Character", "Location", "Character", "ItemKey", "Integer", "Integer", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(114, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_114"), EMonthlyEventType.NormalEvent, "08d64ad1-2df9-4155-bcd4-bf7b8c367d58", "sp_monthlyevent_77", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_114"), new string[7] { "Character", "Location", "Character", "Integer", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(115, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_115"), EMonthlyEventType.NormalEvent, "55854256-94d7-4227-8ca2-ff074dcc9d1f", "sp_monthlyevent_77", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_115"), new string[7] { "Character", "Location", "Character", "Integer", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(116, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_116"), EMonthlyEventType.NormalEvent, "fdcb8aaf-ff9f-4bcb-981c-4e4f7c8d7648", "sp_monthlyevent_78", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_116"), new string[7] { "Character", "Location", "Character", "ItemKey", "ItemKey", "Resource", "Integer" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(117, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_117"), EMonthlyEventType.NormalEvent, "99aca42c-8d46-499e-88b3-843f790c4c4c", "sp_monthlyevent_79", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_117"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(118, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_118"), EMonthlyEventType.NormalEvent, "2a523b5e-2660-45bd-a684-acfd42dcd604", "sp_monthlyevent_80", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_118"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(119, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_119"), EMonthlyEventType.NormalEvent, "cf1dca5b-7d9f-4e76-8d10-e2e59a24053b", "sp_monthlyevent_81", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_119"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new MonthlyEventItem(120, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_120"), EMonthlyEventType.NormalEvent, "d66412f3-357e-4ab4-bc29-707c391f1114", "sp_monthlyevent_82", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_120"), new string[7] { "Settlement", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(121, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_121"), EMonthlyEventType.LockedEvent, "cce87696-5bc6-4006-80a0-e4df96277208", "sp_monthlyevent_85", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_121"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(122, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_122"), EMonthlyEventType.NormalEvent, "3b78ef2e-89b5-48b3-bd48-94d8aa6a11e7", "sp_monthlyevent_87", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_122"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(123, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_123"), EMonthlyEventType.NormalEvent, "83d6b576-3458-4c2e-a2d9-8d7c0c0cc6a5", "sp_monthlyevent_89", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_123"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(124, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_124"), EMonthlyEventType.NormalEvent, "0940e147-8e6f-40be-be38-246081334f67", "sp_monthlyevent_89", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_124"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(125, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_125"), EMonthlyEventType.NormalEvent, "c8743e2b-29e1-434f-b0a5-61c9c7e47879", "sp_monthlyevent_89", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_125"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(126, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_126"), EMonthlyEventType.NormalEvent, "9c76da25-c084-499b-bb1a-30b25376edf6", "sp_monthlyevent_89", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_126"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(127, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_127"), EMonthlyEventType.NormalEvent, "bf5d6073-4ebe-4808-8f7c-e6514320f8ca", "sp_monthlyevent_89", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_127"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(128, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_128"), EMonthlyEventType.NormalEvent, "c7ce95b6-7e99-4873-9670-d7364b263615", "sp_monthlyevent_89", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_128"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(129, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_129"), EMonthlyEventType.NormalEvent, "2eb7d4aa-ee04-42e1-97e7-86351308d20d", "sp_monthlyevent_89", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_129"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(130, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_130"), EMonthlyEventType.NormalEvent, "f4cd2829-71b3-4d74-b618-242800ab1274", "sp_monthlyevent_89", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_130"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(131, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_131"), EMonthlyEventType.NormalEvent, "399fb669-fae9-41f1-a69a-57d040b54199", "sp_monthlyevent_89", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_131"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(132, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_132"), EMonthlyEventType.NormalEvent, "0555df77-0f9a-4ec0-ad45-882b4c579ecd", "sp_monthlyevent_90", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_132"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(133, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_133"), EMonthlyEventType.NormalEvent, "7bcdde30-708e-4e10-8d55-7befc82e5e1b", "sp_monthlyevent_90", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_133"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(134, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_134"), EMonthlyEventType.SpecialEvent, "d5eed465-57c2-471d-be63-c731173581e5", "sp_monthlyevent_96", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_134"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(135, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_135"), EMonthlyEventType.NormalEvent, "885a4366-a3e4-4687-8f53-fde6e9eee1e8", "sp_monthlyevent_98", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_135"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(136, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_136"), EMonthlyEventType.NormalEvent, "e16be2e5-0112-467d-b91f-1e60e94fffb4", "sp_monthlyevent_95", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_136"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(137, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_137"), EMonthlyEventType.NormalEvent, "92bcf2b1-3711-4336-aa6a-28b63f7d188f", "sp_monthlyevent_95", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_137"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(138, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_138"), EMonthlyEventType.NormalEvent, "cbacdd62-ff8d-4e6f-8655-5d924b40daef", "sp_monthlyevent_95", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_138"), new string[7] { "Character", "Location", "Character", "ItemKey", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(139, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_139"), EMonthlyEventType.NormalEvent, "24a28e9b-0d14-41d1-8c67-ef2f96ec5f72", "sp_monthlyevent_97", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_139"), new string[7] { "Character", "Location", "Character", "ItemKey", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(140, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_140"), EMonthlyEventType.NormalEvent, "8a56b164-7115-4c7f-bf5e-d0cabe2e63ad", "sp_monthlyevent_97", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_140"), new string[7] { "Character", "Location", "Character", "ItemKey", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(141, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_141"), EMonthlyEventType.SpecialEvent, "e5d3f23a-7468-461e-ae95-b873ec052b86", "sp_monthlyevent_92", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_141"), new string[7] { "Character", "Location", "Character", "ItemKey", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(142, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_142"), EMonthlyEventType.SpecialEvent, "6b98acdc-46d3-4604-add5-f17ff20cad41", "sp_monthlyevent_91", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_142"), new string[7] { "Character", "Location", "Character", "ItemKey", "Integer", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(143, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_143"), EMonthlyEventType.SpecialEvent, "bea538e6-21ea-49c4-b82b-8e9934cef884", "sp_monthlyevent_99", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_143"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(144, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_144"), EMonthlyEventType.SpecialEvent, "030aaeef-e59e-4add-a8ce-e34254430cb9", "sp_monthlyevent_99", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_144"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(145, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_145"), EMonthlyEventType.SpecialEvent, "70d9be73-bcff-4e02-a470-55b40827a685", "sp_monthlyevent_99", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_145"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(146, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_146"), EMonthlyEventType.NormalEvent, "0e77f1c4-3e7f-4b51-a437-9706a2627e21", "sp_monthlyevent_94", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_146"), new string[7] { "ItemKey", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(147, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_147"), EMonthlyEventType.NormalEvent, "255ce011-b2bb-44bc-9dc7-7c7f8b869a63", "sp_monthlyevent_93", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_147"), new string[7] { "ItemKey", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(148, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_148"), EMonthlyEventType.NormalEvent, "5f5bbf2e-96d7-4766-9f27-e558a4a6de6b", "sp_monthlyevent_100", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_148"), new string[7] { "Location", "ItemKey", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(149, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_149"), EMonthlyEventType.NormalEvent, "5e6309b0-b489-4302-868b-16c67f33b726", "sp_monthlyevent_100", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_149"), new string[7] { "Character", "Location", "ItemKey", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(150, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_150"), EMonthlyEventType.NormalEvent, "74f2ea8b-1258-4d67-98fe-7e2a68dd0c90", "sp_monthlyevent_100", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_150"), new string[7] { "Character", "Location", "ItemKey", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(151, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_151"), EMonthlyEventType.NormalEvent, "a2195715-ad40-45d6-8786-356fe4f68a59", "sp_monthlyevent_100", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_151"), new string[7] { "Character", "Location", "ItemKey", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(152, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_152"), EMonthlyEventType.NormalEvent, "b987500e-a0a2-4c7b-9cfd-968fd422d09a", "sp_monthlyevent_83", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_152"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(153, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_153"), EMonthlyEventType.NormalEvent, "66ef6731-20e3-4439-ae76-d353485ba95a", "sp_monthlyevent_83", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_153"), new string[7] { "Character", "Month", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(154, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_154"), EMonthlyEventType.NormalEvent, "33c8f19d-edd3-4f0f-a578-7ac855328edc", "sp_monthlyevent_83", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_154"), new string[7] { "Character", "Character", "Integer", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(155, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_155"), EMonthlyEventType.NormalEvent, "4799bea8-5be9-4c06-9db9-8972c6803c26", "sp_monthlyevent_83", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_155"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(156, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_156"), EMonthlyEventType.SpecialEvent, "849c544c-c42f-42bc-a8b0-aa8166f25aa4", "sp_monthlyevent_83", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_156"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(157, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_157"), EMonthlyEventType.SpecialEvent, "50791f39-a584-4077-855c-712f7a9aebd0", "sp_monthlyevent_83", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_157"), new string[7] { "Character", "Character", "Character", "Character", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(158, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_158"), EMonthlyEventType.NormalEvent, "ed865595-294f-4f01-a8b5-05471ddb7fbc", "sp_monthlyevent_83", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_158"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(159, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_159"), EMonthlyEventType.SpecialEvent, "27b43a01-08a1-43a5-9db6-9d763e98df92", "sp_monthlyevent_102", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_159"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(160, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_160"), EMonthlyEventType.SpecialEvent, "51909004-b87d-43a8-8314-c4c2b16069e4", "sp_monthlyevent_102", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_160"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(161, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_161"), EMonthlyEventType.SpecialEvent, "60d5fd24-78a0-4c69-8464-6045b69e4c3c", "sp_monthlyevent_102", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_161"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(162, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_162"), EMonthlyEventType.SpecialEvent, "b2c38eb6-111e-4af1-9e0a-161f48eaaa0f", "sp_monthlyevent_102", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_162"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(163, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_163"), EMonthlyEventType.SpecialEvent, "f519f090-9b64-478d-976b-d076a4642b08", "sp_monthlyevent_102", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_163"), new string[7] { "Text", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(164, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_164"), EMonthlyEventType.LockedEvent, "29104798-3e21-4b86-a0b7-623a4595435b", "sp_monthlyevent_101", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_164"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(165, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_165"), EMonthlyEventType.NormalEvent, "922803b9-05b1-4e0a-ae1e-a131a9a02a03", "sp_monthlyevent_104", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_165"), new string[7] { "Character", "Character", "Location", "Character", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(166, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_166"), EMonthlyEventType.NormalEvent, "41bc794d-cf11-429d-b9f8-70cc50004cc4", "sp_monthlyevent_105", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_166"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(167, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_167"), EMonthlyEventType.SpecialEvent, "b9011e4f-7c31-43c5-b84d-3b5ce32bdaf3", "sp_monthlyevent_106", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_167"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(168, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_168"), EMonthlyEventType.SpecialEvent, "0568abcc-847a-4b57-a1d4-e65f0fe4dd67", "sp_monthlyevent_112", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_168"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(169, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_169"), EMonthlyEventType.SpecialEvent, "6b55253d-f236-4de3-a3bf-f6073edeb39c", "sp_monthlyevent_111", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_169"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(170, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_170"), EMonthlyEventType.SpecialEvent, "45ef8b55-17b8-4329-9076-14510b775434", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_170"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(171, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_171"), EMonthlyEventType.SpecialEvent, "28651c0f-ef75-46fe-bdc5-df0818a21fe1", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_171"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(172, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_172"), EMonthlyEventType.SpecialEvent, "c1c1d957-f0d2-4d57-8094-21ff8060db0c", "sp_monthlyevent_127", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_172"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(173, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_173"), EMonthlyEventType.NormalEvent, "c1c1d957-f0d2-4d57-8094-21ff8060db0c", "sp_monthlyevent_127", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_173"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(174, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_174"), EMonthlyEventType.SpecialEvent, "d8878cc0-c603-4a29-b02a-d29706c24673", "sp_monthlyevent_127", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_174"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(175, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_175"), EMonthlyEventType.SpecialEvent, "e385827e-842e-455f-b53e-69526114a43e", "sp_monthlyevent_113", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_175"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(176, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_176"), EMonthlyEventType.SpecialEvent, "90e3fba9-635b-47e6-b855-52f44bf0fb08", "sp_monthlyevent_114", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_176"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(177, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_177"), EMonthlyEventType.SpecialEvent, "da6711cd-34e9-4e9e-b69a-1f157a42127e", "sp_monthlyevent_115", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_177"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(178, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_178"), EMonthlyEventType.SpecialEvent, "2a7bd0ce-5501-4903-895d-b12ab055f9f1", "sp_monthlyevent_116", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_178"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(179, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_179"), EMonthlyEventType.SpecialEvent, "8cc2a127-f3fb-47a7-b532-d7c720aadcbb", "sp_monthlyevent_117", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_179"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new MonthlyEventItem(180, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_180"), EMonthlyEventType.SpecialEvent, "5a31b540-169d-4d0c-9f9c-1a0e916c1b90", "sp_monthlyevent_118", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_180"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(181, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_181"), EMonthlyEventType.SpecialEvent, "aa41ddfb-7486-4936-a4e0-95de149e0866", "sp_monthlyevent_119", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_181"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(182, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_182"), EMonthlyEventType.SpecialEvent, "0c0d8040-e32a-4c9b-89e8-d2a66deb77ad", "sp_monthlyevent_120", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_182"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(183, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_183"), EMonthlyEventType.SpecialEvent, "78902930-82c0-45ca-a8cf-d8b69fe45b9e", "sp_monthlyevent_121", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_183"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(184, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_184"), EMonthlyEventType.SpecialEvent, "68208a24-c2ee-4aee-baab-af39b8d520a6", "sp_monthlyevent_122", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_184"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(185, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_185"), EMonthlyEventType.SpecialEvent, "a7fd1ac2-dd4e-4bb2-b3ef-6c5c58d8ec54", "sp_monthlyevent_123", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_185"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(186, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_186"), EMonthlyEventType.SpecialEvent, "1f55792d-0cee-4fe4-8cfc-9bd14cc8bc0f", "sp_monthlyevent_124", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_186"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(187, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_187"), EMonthlyEventType.SpecialEvent, "dcad7254-ec58-4cc2-9137-d03ac4e13f02", "sp_monthlyevent_125", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_187"), new string[7] { "", "", "", "", "", "", "" }, null, 15, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(188, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_188"), EMonthlyEventType.SpecialEvent, "067d958c-97b8-4f83-bcbe-7ecabe60e4cb", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_188"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(189, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_189"), EMonthlyEventType.SpecialEvent, "71808dbc-54e0-44b6-8294-0552e255d74c", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_189"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(190, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_190"), EMonthlyEventType.SpecialEvent, "08f5d9e1-7129-434c-ae5c-8e93a821cb73", "sp_monthlyevent_129", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_190"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(191, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_191"), EMonthlyEventType.SpecialEvent, "60d1ec84-bbb4-4ea6-8166-958256cff1cc", "sp_monthlyevent_130", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_191"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(192, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_192"), EMonthlyEventType.SpecialEvent, "3347bc78-93b7-4c5f-9b06-c6a216e6947c", "sp_monthlyevent_131", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_192"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(193, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_193"), EMonthlyEventType.SpecialEvent, "fcfce344-8973-47e7-809a-7c68cad15500", "sp_monthlyevent_131", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_193"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(194, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_194"), EMonthlyEventType.NormalEvent, "fd31d2eb-bdfd-4ee1-932d-ee4aa9da6ed1", "sp_monthlyevent_132", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_194"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(195, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_195"), EMonthlyEventType.NormalEvent, "2e13b2da-b596-4fd5-a0a6-2621887e9d7f", "sp_monthlyevent_133", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_195"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(196, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_196"), EMonthlyEventType.NormalEvent, "6847842a-bd1e-4794-a939-263d2f7a144e", "sp_monthlyevent_134", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_196"), new string[7] { "", "", "", "", "", "", "" }, null, 15, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(197, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_197"), EMonthlyEventType.NormalEvent, "bea0d4a5-9bf8-4cff-8169-2512213ff7b4", "sp_monthlyevent_134", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_197"), new string[7] { "", "", "", "", "", "", "" }, null, 15, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(198, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_198"), EMonthlyEventType.SpecialEvent, "57fae04a-a3e9-4a27-af66-07e0987482dd", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_198"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(199, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_199"), EMonthlyEventType.SpecialEvent, "5ad8be88-9798-4595-bbfe-905a0c60a0a9", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_199"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(200, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_200"), EMonthlyEventType.SpecialEvent, "b3df5518-fcbb-4407-ae57-ab49fba4dd95", "sp_monthlyevent_152", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_200"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(201, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_201"), EMonthlyEventType.SpecialEvent, "a17b887c-9028-409d-ba61-ea34c72fd978", "sp_monthlyevent_153", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_201"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(202, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_202"), EMonthlyEventType.SpecialEvent, "989bf6bb-ae10-40da-9eb7-f13dc2d8ecbc", "sp_monthlyevent_154", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_202"), new string[7] { "Character", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(203, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_203"), EMonthlyEventType.SpecialEvent, "84c837c7-504c-455b-b65f-aa9d6d162354", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_203"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(204, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_204"), EMonthlyEventType.SpecialEvent, "3e7ba69b-59b4-40ed-afd4-42c8efef5090", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_204"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(205, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_205"), EMonthlyEventType.NormalEvent, "03546449-7d1a-453e-8676-32b4eecbb76a", "sp_monthlyevent_149", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_205"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(206, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_206"), EMonthlyEventType.SpecialEvent, "af960b8f-513f-4f89-af10-a07e6180a707", "sp_monthlyevent_147", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_206"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(207, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_207"), EMonthlyEventType.NormalEvent, "70bebdd1-a192-4175-bf4a-51e4bc9b91a2", "sp_monthlyevent_151", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_207"), new string[7] { "Location", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(208, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_208"), EMonthlyEventType.SpecialEvent, "2a78b810-5146-4ca3-b867-2650b453d1de", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_208"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(209, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_209"), EMonthlyEventType.SpecialEvent, "4e19e07c-13fb-4118-92f1-122f1d234cc0", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_209"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(210, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_210"), EMonthlyEventType.SpecialEvent, "926bcace-f1b1-4b3d-8872-d51defaf8cfc", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_210"), new string[7] { "Location", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(211, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_211"), EMonthlyEventType.SpecialEvent, "d96e9f5a-04d3-444a-816d-c4df7fb26a0a", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_211"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(212, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_212"), EMonthlyEventType.SpecialEvent, "fed84ccf-8d37-4c68-b593-2ee460c3adca", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_212"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(213, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_213"), EMonthlyEventType.SpecialEvent, "83c11763-4c6c-414d-ab16-5f15e091faa2", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_213"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(214, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_214"), EMonthlyEventType.SpecialEvent, "2367b03a-7001-4cea-b8d0-6dd401b2199e", "sp_monthlyevent_137", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_214"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(215, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_215"), EMonthlyEventType.SpecialEvent, "2ad527af-f91d-46d3-a9a5-882c60089d4c", "sp_monthlyevent_138", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_215"), new string[7] { "Location", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(216, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_216"), EMonthlyEventType.SpecialEvent, "0e74c5a1-e79a-4449-9067-d7530be59840", "sp_monthlyevent_139", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_216"), new string[7] { "Location", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(217, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_217"), EMonthlyEventType.NormalEvent, "2f802ef3-8e97-4f61-a991-88f5fbe3bf44", "sp_monthlyevent_140", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_217"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(218, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_218"), EMonthlyEventType.SpecialEvent, "f30fe1fc-bd13-45cf-b290-4e470f5820c6", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_218"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(219, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_219"), EMonthlyEventType.SpecialEvent, "c598abbf-c486-4ecb-be6f-123b6a29b712", null, LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_219"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(220, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_220"), EMonthlyEventType.SpecialEvent, "f75577f5-d198-4e4a-8467-f7cffc7c63cc", "sp_monthlyevent_183", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_220"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(221, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_221"), EMonthlyEventType.SpecialEvent, "676bffe7-07b2-409d-873e-3055fda6abd8", "sp_monthlyevent_179", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_221"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(222, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_222"), EMonthlyEventType.SpecialEvent, "ed39ab40-2295-4a0b-b0fb-4ed6865b5091", null, LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_222"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(223, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_223"), EMonthlyEventType.SpecialEvent, "fe50e807-84d5-4da3-b8fd-e56d04ff3ff7", "sp_monthlyevent_180", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_223"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(224, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_224"), EMonthlyEventType.NormalEvent, "5c8591ab-b9b4-44ce-bc6d-a1cc6c5d9c75", "sp_monthlyevent_181", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_224"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(225, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_225"), EMonthlyEventType.SpecialEvent, "437cce36-d3c1-481c-af00-75edcf125fcb", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_225"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(226, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_226"), EMonthlyEventType.SpecialEvent, "b5c4c984-0587-4da0-b292-1f20548dbd95", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_226"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(227, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_227"), EMonthlyEventType.SpecialEvent, "aaf1e541-cd5d-4778-85d9-2326a95a2ca5", "sp_monthlyevent_193", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_227"), new string[7] { "Character", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(228, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_228"), EMonthlyEventType.SpecialEvent, "5f0a82a3-2731-4ce3-b4d3-862cc68697ed", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_228"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(229, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_229"), EMonthlyEventType.SpecialEvent, "6b8df43e-efc2-4aa2-a7eb-49fcf02d73d5", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_229"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(230, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_230"), EMonthlyEventType.SpecialEvent, "c10c1a24-dafe-491a-9eea-64b08123539b", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_230"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(231, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_231"), EMonthlyEventType.SpecialEvent, "a9db6b16-b367-44b1-9b76-80892ed1f173", "sp_monthlyevent_195", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_231"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(232, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_232"), EMonthlyEventType.SpecialEvent, null, "sp_monthlyevent_196", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_232"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(233, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_233"), EMonthlyEventType.NormalEvent, "3f76f33a-8abc-4879-ad6b-c651aa52398a", "sp_monthlyevent_196", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_233"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(234, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_234"), EMonthlyEventType.SpecialEvent, "2746de35-3335-4ee2-82ab-501ac340cccc", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_234"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(235, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_235"), EMonthlyEventType.SpecialEvent, "40656ea6-96ca-4b22-9f86-96ef6ae4a15c", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_235"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(236, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_236"), EMonthlyEventType.SpecialEvent, "22deaa19-d549-49f4-b7f7-8bcc1f0e641c", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_236"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(237, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_237"), EMonthlyEventType.SpecialEvent, "c19e6756-c231-4c22-bb92-14ce813bec71", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_237"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(238, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_238"), EMonthlyEventType.NormalEvent, "fe479d84-2400-4751-9f3a-99af9e2b9f88", "sp_monthlyevent_126", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_238"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(239, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_239"), EMonthlyEventType.SpecialEvent, "65c3a6ab-3443-4da9-b9f1-ab35e514cef3", "sp_monthlyevent_127", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_239"), new string[7] { "Character", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new MonthlyEventItem(240, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_240"), EMonthlyEventType.SpecialEvent, "40e09cf5-15c9-4c41-961a-26003ba91e07", "sp_monthlyevent_128", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_240"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(241, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_241"), EMonthlyEventType.SpecialEvent, "85b0efd1-4674-4a9a-8c75-2266726ec428", "sp_monthlyevent_201", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_241"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(242, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_242"), EMonthlyEventType.SpecialEvent, "c973d8d3-3bf1-4b7d-9f0b-e1cdd0e90947", "sp_monthlyevent_202", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_242"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(243, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_243"), EMonthlyEventType.SpecialEvent, "f653a3a1-3481-433c-9413-cef06235dd8a", "sp_monthlyevent_203", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_243"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(244, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_244"), EMonthlyEventType.SpecialEvent, "6a39447f-793d-4b27-b7e9-568824a42a77", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_244"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(245, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_245"), EMonthlyEventType.SpecialEvent, "96c45490-928f-49e0-afc8-2072c8d0ddf7", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_245"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(246, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_246"), EMonthlyEventType.SpecialEvent, "20a4c183-a9ee-4381-865a-798fcb3d557b", "sp_monthlyevent_131", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_246"), new string[7] { "", "", "", "", "", "", "" }, null, 15, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(247, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_247"), EMonthlyEventType.SpecialEvent, "fa0acdb4-0250-4991-b953-1ac00bc6122c", "sp_monthlyevent_131", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_247"), new string[7] { "", "", "", "", "", "", "" }, null, 15, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(248, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_248"), EMonthlyEventType.SpecialEvent, "3b261a2c-eea8-4a2a-af07-4be334a00837", "sp_monthlyevent_136", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_248"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(249, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_249"), EMonthlyEventType.NormalEvent, "fd31d2eb-bdfd-4ee1-932d-ee4aa9da6ed1", "sp_monthlyevent_132", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_249"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(250, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_250"), EMonthlyEventType.NormalEvent, "2ff827bb-2f5e-494e-9d42-ee6838f3ac61", "sp_monthlyevent_140", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_250"), new string[7] { "Character", "Location", "ItemKey", "Character", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(251, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_251"), EMonthlyEventType.NormalEvent, "a86a19e6-e10a-4ea2-94fa-318f97418e0e", "sp_monthlyevent_140", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_251"), new string[7] { "Character", "Location", "ItemKey", "Character", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(252, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_252"), EMonthlyEventType.NormalEvent, "c16f1945-aa6b-4e2f-8278-daad37c08ab3", "sp_monthlyevent_141", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_252"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(253, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_253"), EMonthlyEventType.SpecialEvent, "b719c0b9-8f69-409e-a20a-6c16f0f8056a", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_253"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(254, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_254"), EMonthlyEventType.NormalEvent, "2e13b2da-b596-4fd5-a0a6-2621887e9d7f", "sp_monthlyevent_133", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_254"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(255, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_255"), EMonthlyEventType.NormalEvent, "6847842a-bd1e-4794-a939-263d2f7a144e", "sp_monthlyevent_134", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_255"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(256, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_256"), EMonthlyEventType.NormalEvent, "bea0d4a5-9bf8-4cff-8169-2512213ff7b4", "sp_monthlyevent_134", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_256"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(257, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_257"), EMonthlyEventType.SpecialEvent, "956394bd-b511-41cc-ab62-d037470ec1c8", "sp_monthlyevent_138", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_257"), new string[7] { "Character", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(258, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_258"), EMonthlyEventType.NormalEvent, "038f7b78-93dc-4b64-81de-bdfd9d8979bd", "sp_monthlyevent_141", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_258"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(259, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_259"), EMonthlyEventType.SpecialEvent, "38e13a25-c1db-4850-a71a-91f84a0a9509", "sp_monthlyevent_142", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_259"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(260, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_260"), EMonthlyEventType.SpecialEvent, "c0e7e5e5-d4db-4499-b2bf-2de32038ddd0", "sp_monthlyevent_143", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_260"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(261, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_261"), EMonthlyEventType.SpecialEvent, "dad2487c-6534-4130-a2da-aec5784fa83d", "sp_monthlyevent_141", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_261"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(262, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_262"), EMonthlyEventType.NormalEvent, "f87e13e8-96e5-4590-a979-312530279465", "sp_monthlyevent_145", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_262"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(263, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_263"), EMonthlyEventType.NormalEvent, "45870f83-4919-4241-b15b-a3f6e644ec47", "sp_monthlyevent_146", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_263"), new string[7] { "Location", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(264, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_264"), EMonthlyEventType.SpecialEvent, "72431c90-738c-4944-8832-c6b8148c14e2", "sp_monthlyevent_147", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_264"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(265, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_265"), EMonthlyEventType.SpecialEvent, "ee6f37d3-32e0-47e3-9c25-d082ee1240cd", "sp_monthlyevent_148", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_265"), new string[7] { "Character", "Location", "Character", "Location", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(266, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_266"), EMonthlyEventType.SpecialEvent, "0f499b42-2aba-4987-a60b-a00d5e75b84e", "sp_monthlyevent_145", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_266"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(267, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_267"), EMonthlyEventType.SpecialEvent, "6dea23a6-af77-4a03-b41b-d8ff0308252a", "sp_monthlyevent_147", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_267"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(268, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_268"), EMonthlyEventType.SpecialEvent, "290e09c4-e3f3-4891-8d99-780fbcf36c15", "sp_monthlyevent_155", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_268"), new string[7] { "Character", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(269, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_269"), EMonthlyEventType.SpecialEvent, "6b9402df-12b2-400d-9132-b294b2bda8c3", "sp_monthlyevent_156", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_269"), new string[7] { "Character", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(270, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_270"), EMonthlyEventType.SpecialEvent, "2f1aad09-e04e-41e6-84b9-0639980ade8b", "sp_monthlyevent_157", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_270"), new string[7] { "Character", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(271, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_271"), EMonthlyEventType.NormalEvent, "18cdf205-9302-4054-baed-a1ac6a541f53", "sp_monthlyevent_158", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_271"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(272, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_272"), EMonthlyEventType.SpecialEvent, "82826966-26b7-4b56-829e-80851430fc25", "sp_monthlyevent_154", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_272"), new string[7] { "Character", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(273, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_273"), EMonthlyEventType.SpecialEvent, "0177e00a-f900-457a-abd3-ac7bffd3cbcf", "sp_monthlyevent_159", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_273"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(274, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_274"), EMonthlyEventType.SpecialEvent, "610b431a-a4a3-46e7-9119-9a6f34e42858", "sp_monthlyevent_160", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_274"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 100, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(275, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_275"), EMonthlyEventType.SpecialEvent, "56f6b54f-2e83-46eb-8798-d263d542a61c", "sp_monthlyevent_153", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_275"), new string[7] { "Character", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(276, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_276"), EMonthlyEventType.NormalEvent, "7f06e8eb-e8c2-4364-ab5d-b4425ba5b7a5", "sp_monthlyevent_161", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_276"), new string[7] { "Location", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(277, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_277"), EMonthlyEventType.SpecialEvent, "1d97e2a9-ff13-4f07-81de-a9ae167f1f5d", "sp_monthlyevent_162", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_277"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 15, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(278, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_278"), EMonthlyEventType.NormalEvent, "78442db8-b67b-4bff-a01b-18a59907eca4", "sp_monthlyevent_248", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_278"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(279, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_279"), EMonthlyEventType.SpecialEvent, "b2f60857-1468-4241-9884-5f3533e0194d", "sp_monthlyevent_163", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_279"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(280, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_280"), EMonthlyEventType.NormalEvent, "54a700fe-f097-4cec-a5cd-9cbb68587524", "sp_monthlyevent_164", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_280"), new string[7] { "Character", "Location", "Character", "CombatSkill", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(281, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_281"), EMonthlyEventType.NormalEvent, "11211fd5-8cfd-4113-a948-f5e587cdea1a", "sp_monthlyevent_165", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_281"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(282, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_282"), EMonthlyEventType.SpecialEvent, "1a53cd4f-b022-46ff-915c-0da6a6044a41", "sp_monthlyevent_166", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_282"), new string[7] { "CharacterTemplate", "Location", "ItemKey", "Location", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(283, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_283"), EMonthlyEventType.SpecialEvent, "583308f4-2ade-4ec5-831e-dcfca90d4e98", "sp_monthlyevent_167", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_283"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(284, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_284"), EMonthlyEventType.NormalEvent, "8e36522c-c6df-4516-a478-724a06cc3fec", "sp_monthlyevent_168", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_284"), new string[7] { "Location", "JiaoLoong", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(285, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_285"), EMonthlyEventType.NormalEvent, "02c1b765-7d54-4c3a-a3ab-7718e2e20092", "sp_monthlyevent_169", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_285"), new string[7] { "Character", "JiaoLoong", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(286, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_286"), EMonthlyEventType.NormalEvent, "11dcfeeb-4c76-41cf-b08a-8fc907457706", "sp_monthlyevent_170", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_286"), new string[7] { "Character", "JiaoLoong", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(287, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_287"), EMonthlyEventType.NormalEvent, "4991f260-4991-4f1e-9cec-681d8202a71c", "sp_monthlyevent_171", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_287"), new string[7] { "Character", "JiaoLoong", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(288, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_288"), EMonthlyEventType.NormalEvent, "8248d3a2-4688-4c38-a09a-e4ddd3a28e69", "sp_monthlyevent_172", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_288"), new string[7] { "Character", "JiaoLoong", "Cricket", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(289, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_289"), EMonthlyEventType.NormalEvent, "a3fb0a88-1cee-4b52-b587-676af7a2c0cc", "sp_monthlyevent_173", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_289"), new string[7] { "Character", "JiaoLoong", "Item", "Integer", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(290, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_290"), EMonthlyEventType.NormalEvent, "843fefb2-3dae-47e6-897a-8d343c5c8f89", "sp_monthlyevent_174", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_290"), new string[7] { "Character", "JiaoLoong", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(291, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_291"), EMonthlyEventType.NormalEvent, "919d1214-b3ae-46e0-84a0-21898e812138", "sp_monthlyevent_175", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_291"), new string[7] { "Character", "JiaoLoong", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(292, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_292"), EMonthlyEventType.NormalEvent, "d774a0d8-62c5-4691-88b9-51ff3c981c29", "sp_monthlyevent_176", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_292"), new string[7] { "Character", "JiaoLoong", "Item", "Integer", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(293, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_293"), EMonthlyEventType.NormalEvent, "c7a6bef9-8418-4ff4-9554-99826ad85792", "sp_monthlyevent_177", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_293"), new string[7] { "Character", "JiaoLoong", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(294, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_294"), EMonthlyEventType.SpecialEvent, "6be0d9de-1e17-49b6-a25b-bf0b162d30fb", "sp_monthlyevent_178", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_294"), new string[7] { "Character", "Location", "CharacterTemplate", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(295, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_295"), EMonthlyEventType.SpecialEvent, "0db9a1eb-1206-4de6-bd06-dad4fc294af2", "sp_monthlyevent_168", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_295"), new string[7] { "Location", "JiaoLoong", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(296, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_296"), EMonthlyEventType.SpecialEvent, "99b77a8f-0bd2-409b-a647-c2c11a10cd6c", "sp_monthlyevent_194", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_296"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(297, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_297"), EMonthlyEventType.SpecialEvent, "076691a0-9b1a-4d8a-a2e7-81802d55744f", "sp_monthlyevent_182", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_297"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(298, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_298"), EMonthlyEventType.NormalEvent, "35edba36-194a-47dd-8198-17f1fcb48855", "sp_monthlyevent_184", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_298"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(299, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_299"), EMonthlyEventType.SpecialEvent, "fc5dd1ce-07bb-41c9-a49c-28317470f30a", "sp_monthlyevent_185", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_299"), new string[7] { "Character", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new MonthlyEventItem(300, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_300"), EMonthlyEventType.SpecialEvent, "f0c3de42-c5b1-41e4-8a65-d0c1b03c2be5", "sp_monthlyevent_191", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_300"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(301, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_301"), EMonthlyEventType.SpecialEvent, "cef4e4b5-6f81-4da1-937e-ffe0dbb837b8", "sp_monthlyevent_186", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_301"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(302, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_302"), EMonthlyEventType.SpecialEvent, "b48ad5b0-cdde-488f-8ced-a589e9b5d065", "sp_monthlyevent_192", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_302"), new string[7] { "Character", "", "", "", "", "", "" }, null, 15, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(303, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_303"), EMonthlyEventType.SpecialEvent, "38eb8243-00ca-4b34-b9aa-6f37142fc360", "sp_monthlyevent_190", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_303"), new string[7] { "", "", "", "", "", "", "" }, null, 2, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(304, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_304"), EMonthlyEventType.SpecialEvent, "5110afaa-5b5f-4a8f-ab7a-affe2142b541", "sp_monthlyevent_187", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_304"), new string[7] { "Character", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(305, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_305"), EMonthlyEventType.SpecialEvent, "5381846f-e1e6-4720-9601-6aadd02313ec", "sp_monthlyevent_189", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_305"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(306, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_306"), EMonthlyEventType.SpecialEvent, "90e11369-75ee-45d7-a1ea-752432cfc7d9", "sp_monthlyevent_197", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_306"), new string[7] { "Location", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(307, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_307"), EMonthlyEventType.SpecialEvent, "e0bdd40f-b647-4534-b11e-efee1d634c9f", "sp_monthlyevent_198", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_307"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(308, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_308"), EMonthlyEventType.NormalEvent, "c55bb515-e8bd-4d7b-b8f4-40ef920ed614", "sp_monthlyevent_199", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_308"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(309, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_309"), EMonthlyEventType.SpecialEvent, "6b84caac-74c7-4761-b334-edea12fdb200", "sp_monthlyevent_200", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_309"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(310, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_310"), EMonthlyEventType.SpecialEvent, "6121c37a-f66a-421c-84dc-687ed3da8568", "sp_monthlyevent_204", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_310"), new string[7] { "Character", "", "", "", "", "", "" }, null, 15, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(311, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_311"), EMonthlyEventType.SpecialEvent, "c3a4819a-d6c5-41a8-a1a7-9fc32e33f6b2", "sp_monthlyevent_207", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_311"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(312, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_312"), EMonthlyEventType.SpecialEvent, "28d549b7-455b-4c36-af78-0503c0ffb10a", "sp_monthlyevent_208", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_312"), new string[7] { "Character", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(313, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_313"), EMonthlyEventType.SpecialEvent, "bf5b18e1-1f00-49be-80e2-643bd140244b", "sp_monthlyevent_208", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_313"), new string[7] { "Character", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(314, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_314"), EMonthlyEventType.SpecialEvent, "846051d7-ad0b-4bcb-a30b-6cebb0c1dd3d", "sp_monthlyevent_209", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_314"), new string[7] { "Character", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(315, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_315"), EMonthlyEventType.SpecialEvent, "913fed24-2151-4a4a-98ad-9f2521346617", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_315"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(316, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_316"), EMonthlyEventType.SpecialEvent, "5c2dc280-8ef4-4db0-a257-c51aacd26988", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_316"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(317, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_317"), EMonthlyEventType.SpecialEvent, "9bef300e-ef1e-469f-bbc6-51150d229421", "sp_monthlyevent_222", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_317"), new string[7] { "Location", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(318, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_318"), EMonthlyEventType.SpecialEvent, "1e31b702-bf2f-4b0a-98b3-aee867a030a5", "sp_monthlyevent_211", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_318"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(319, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_319"), EMonthlyEventType.SpecialEvent, "0a9a6fc4-c89c-4fd3-b9c9-617bec8d5fcd", "sp_monthlyevent_224", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_319"), new string[7] { "Location", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(320, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_320"), EMonthlyEventType.SpecialEvent, "8404e31c-de4d-4e12-9348-58b3ac3281a9", "sp_monthlyevent_212", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_320"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(321, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_321"), EMonthlyEventType.SpecialEvent, "0423001e-3c3b-444c-8489-316577f0eede", "sp_monthlyevent_223", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_321"), new string[7] { "Location", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(322, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_322"), EMonthlyEventType.SpecialEvent, "a8d1cbf3-fa48-4531-be5e-7a5b18328b95", "sp_monthlyevent_213", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_322"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(323, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_323"), EMonthlyEventType.SpecialEvent, "6b485099-1127-463c-9c03-15e5ce447c77", "sp_monthlyevent_214", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_323"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(324, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_324"), EMonthlyEventType.SpecialEvent, "1eeb6a45-7b08-444e-aaee-90058e390433", "sp_monthlyevent_215", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_324"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(325, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_325"), EMonthlyEventType.SpecialEvent, "0fc236fd-a4b8-46aa-a79c-548590829b8b", "sp_monthlyevent_216", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_325"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(326, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_326"), EMonthlyEventType.SpecialEvent, "930e3d91-1359-429e-89fe-5f51d30c64b7", "sp_monthlyevent_217", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_326"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(327, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_327"), EMonthlyEventType.SpecialEvent, "c8c22efb-45d9-43aa-a5d2-0205d7d67d07", "sp_monthlyevent_218", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_327"), new string[7] { "Location", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(328, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_328"), EMonthlyEventType.SpecialEvent, "e263db09-a1bf-4c67-9523-68120b08a2d9", "sp_monthlyevent_219", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_328"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(329, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_329"), EMonthlyEventType.SpecialEvent, "0bfac0cb-d58e-4407-be7c-c9ebe6a2a6f4", "sp_monthlyevent_220", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_329"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(330, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_330"), EMonthlyEventType.NormalEvent, "770e03ff-41d1-4cf2-b708-b51139e8ebb7", "sp_monthlyevent_221", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_330"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(331, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_331"), EMonthlyEventType.SpecialEvent, "b70eadf1-eb09-495c-a79a-87afdf0afe3e", "sp_monthlyevent_227", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_331"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(332, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_332"), EMonthlyEventType.SpecialEvent, "3d9ad75c-b824-41a9-9a6a-4713f7577aed", "sp_monthlyevent_228", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_332"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(333, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_333"), EMonthlyEventType.SpecialEvent, "1ead611e-b08e-459d-8080-5d4b7cbaa6e8", "sp_monthlyevent_229", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_333"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(334, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_334"), EMonthlyEventType.SpecialEvent, "4f3f231f-8ecd-4a92-95c7-4aa20c45521c", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_334"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(335, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_335"), EMonthlyEventType.SpecialEvent, "57202af8-fe7c-4eb4-a138-597a4885033d", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_335"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(336, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_336"), EMonthlyEventType.SpecialEvent, "4181db5d-146e-4041-a2b8-a67b51e3c784", "sp_monthlyevent_225", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_336"), new string[7] { "Character", "Character", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(337, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_337"), EMonthlyEventType.SpecialEvent, "045159b3-1dcb-41b1-90cb-e2dc87584fee", "sp_monthlyevent_226", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_337"), new string[7] { "Character", "Settlement", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(338, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_338"), EMonthlyEventType.SpecialEvent, "8cb7e0f9-b760-4371-a22a-3fcd6511a485", "sp_monthlyevent_230", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_338"), new string[7] { "Location", "Character", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(339, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_339"), EMonthlyEventType.NormalEvent, "5aa1a3db-2ce4-4b2f-89ce-71af8a9d7344", "sp_monthlyevent_230", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_339"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(340, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_340"), EMonthlyEventType.NormalEvent, "c260de56-3539-4f31-b483-cfd007694f21", "sp_monthlyevent_231", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_340"), new string[7] { "Character", "Location", "Character", "Character", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(341, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_341"), EMonthlyEventType.NormalEvent, "ab430470-0b26-4741-980b-f3e7c6ad9829", "sp_monthlyevent_232", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_341"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(342, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_342"), EMonthlyEventType.NormalEvent, "ff47d62e-9266-48cd-892f-84c6cfd194f5", "sp_monthlyevent_234", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_342"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(343, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_343"), EMonthlyEventType.NormalEvent, "293b9c34-011f-4a84-b5d4-d98f6ab37b64", "sp_monthlyevent_77", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_343"), new string[7] { "Character", "Location", "Character", "Integer", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(344, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_344"), EMonthlyEventType.NormalEvent, "128ba978-1862-41d5-94e6-88ed537586d8", "sp_monthlyevent_77", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_344"), new string[7] { "Character", "Location", "Character", "Integer", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(345, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_345"), EMonthlyEventType.SpecialEvent, "eb3b3430-7a82-4c95-b132-b97f03927302", "sp_monthlyevent_235", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_345"), new string[7] { "OrgGrade", "Item", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(346, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_346"), EMonthlyEventType.SpecialEvent, "d742c92c-470a-496c-8b4a-eccddcc8baee", "sp_monthlyevent_225", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_346"), new string[7] { "Character", "Character", "Location", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(347, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_347"), EMonthlyEventType.SpecialEvent, "312200ad-cd01-4017-b72b-5553f53acfa0", "sp_monthlyevent_237", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_347"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 2, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(348, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_348"), EMonthlyEventType.SpecialEvent, "ab6e5243-7190-46d5-b705-2e0b9d5f2928", "sp_monthlyevent_238", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_348"), new string[7] { "Character", "", "", "", "", "", "" }, null, 2, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(349, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_349"), EMonthlyEventType.SpecialEvent, "44e9bb3d-ef56-48e1-964d-f88a5d6b1362", "sp_monthlyevent_239", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_349"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 2, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(350, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_350"), EMonthlyEventType.SpecialEvent, "a7ba8c41-b982-4a94-b38e-f5b5591121ad", "sp_monthlyevent_240", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_350"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 2, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(351, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_351"), EMonthlyEventType.SpecialEvent, "ea10b5f6-2949-4f98-b357-29f2138c0e02", "sp_monthlyevent_109", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_351"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(352, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_352"), EMonthlyEventType.SpecialEvent, "0961ceb0-22a9-4f8d-8fb0-473a5428e807", "sp_monthlyevent_110", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_352"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(353, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_353"), EMonthlyEventType.SpecialEvent, "90d1b5bf-647e-4bf9-95b2-1eb27c839383", "sp_monthlyevent_236", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_353"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(354, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_354"), EMonthlyEventType.SpecialEvent, "cf762b69-2903-443a-a81c-35b6795a48c1", "sp_monthlyevent_241", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_354"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(355, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_355"), EMonthlyEventType.SpecialEvent, "0a5307c0-cf82-49d2-939f-decb93bc8e80", "sp_monthlyevent_242", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_355"), new string[7] { "Character", "Integer", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(356, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_356"), EMonthlyEventType.SpecialEvent, "bee8d7e8-96a4-425f-a7ae-8849fbd27d73", "sp_monthlyevent_243", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_356"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(357, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_357"), EMonthlyEventType.NormalEvent, "82c1d4f9-e47c-4c09-8ed8-2fb3c72e30a4", "sp_monthlyevent_6", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_357"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(358, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_358"), EMonthlyEventType.SpecialEvent, "07fcefdf-5ccd-41fb-bac6-7544cc5602e4", "sp_monthlyevent_135", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_358"), new string[7] { "Character", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(359, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_359"), EMonthlyEventType.NormalEvent, "11b71084-0d5e-4f1b-aec0-e2e2a73ecc78", "sp_monthlyevent_244", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_359"), new string[7] { "Character", "Settlement", "Settlement", "Integer", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new MonthlyEventItem(360, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_360"), EMonthlyEventType.NormalEvent, "35dbcaf7-a830-419e-9fea-2b2cf88b8bfb", "sp_monthlyevent_14", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_360"), new string[7] { "Character", "Character", "Integer", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(361, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_361"), EMonthlyEventType.SpecialEvent, "b854baa1-4de8-4f4d-8916-be69d94935ba", "sp_monthlyevent_245", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_361"), new string[7] { "Character", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(362, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_362"), EMonthlyEventType.SpecialEvent, "51b5d1fd-1ab8-4470-9e39-abf5e16a99aa", "sp_monthlyevent_246", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_362"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(363, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_363"), EMonthlyEventType.NormalEvent, "45870f83-4919-4241-b15b-a3f6e644ec47", "sp_monthlyevent_247", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_363"), new string[7] { "Location", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(364, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_364"), EMonthlyEventType.SpecialEvent, "0f499b42-2aba-4987-a60b-a00d5e75b84e", "sp_monthlyevent_248", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_364"), new string[7] { "Character", "Location", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(365, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_365"), EMonthlyEventType.SpecialEvent, "7717d608-aff7-4f66-8a89-1442351471bb", "sp_monthlyevent_249", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_365"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(366, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_366"), EMonthlyEventType.SpecialEvent, "3cd8b3be-2d87-404e-961e-ef1853f362ec", "sp_monthlyevent_253", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_366"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(367, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_367"), EMonthlyEventType.SpecialEvent, "93e54782-ff9f-45a8-83b2-3bf34d859189", "sp_monthlyevent_254", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_367"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(368, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_368"), EMonthlyEventType.NormalEvent, "04ca1b04-8e7b-4341-bdda-df1dd0f9b4dd", "sp_monthlyevent_262", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_368"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(369, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_369"), EMonthlyEventType.SpecialEvent, "c75b4df3-37b5-4b5b-84a5-17a4a4629cdb", "sp_monthlyevent_265", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_369"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(370, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_370"), EMonthlyEventType.SpecialEvent, "c4885f82-4587-4722-a3c6-a64740a076e3", "sp_monthlyevent_266", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_370"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(371, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_371"), EMonthlyEventType.SpecialEvent, "43b9b8d0-a26d-4b15-857e-427f38090b60", "sp_monthlyevent_268", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_371"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(372, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_372"), EMonthlyEventType.SpecialEvent, "3bfad54d-33d0-4bb8-912e-ce55b9ae2c37", "sp_monthlyevent_269", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_372"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(373, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_373"), EMonthlyEventType.NormalEvent, "94a925be-ee96-4238-b299-f1838de50a74", "sp_monthlyevent_267", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_373"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 30, 3, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(374, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_374"), EMonthlyEventType.SpecialEvent, "5e07f19a-8260-4a6d-ae47-b2363ce2a8c4", "sp_monthlyevent_270", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_374"), new string[7] { "Character", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(375, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_375"), EMonthlyEventType.NormalEvent, "8d2eaf39-e803-4e31-b936-88c4d3c0d7a4", "sp_monthlyevent_251", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_375"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(376, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_376"), EMonthlyEventType.NormalEvent, "66c87f4f-1674-44be-982e-6cb53b11dd6e", "sp_monthlyevent_252", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_376"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(377, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_377"), EMonthlyEventType.NormalEvent, "f7738aa4-e6bb-42b9-970f-65f5fa8caa9a", "sp_monthlyevent_251", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_377"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(378, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_378"), EMonthlyEventType.NormalEvent, "861cf963-dace-4203-abfd-f5b702a179c4", "sp_monthlyevent_275", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_378"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(379, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_379"), EMonthlyEventType.SpecialEvent, "8d4fd6c7-9622-41a5-9f6c-8d52d16f077f", "sp_monthlyevent_272", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_379"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(380, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_380"), EMonthlyEventType.SpecialEvent, "80b1d2f3-a0f4-4369-8548-815f90578012", "sp_monthlyevent_263", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_380"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(381, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_381"), EMonthlyEventType.SpecialEvent, "6f4733ff-5112-4caf-9e75-a713e992edfc", "sp_monthlyevent_264", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_381"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(382, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_382"), EMonthlyEventType.SpecialEvent, "a1e0cfcd-7bb8-46e0-af45-8f068c37f48a", "sp_monthlyevent_250", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_382"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(383, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_383"), EMonthlyEventType.NormalEvent, "0e12e8d5-595c-4cf7-ad6e-f8db69d5cbb1", "sp_monthlyevent_199", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_383"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(384, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_384"), EMonthlyEventType.SpecialEvent, "9093d64c-b86d-4d7b-a401-d47423ef40d7", "sp_monthlyevent_271", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_384"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(385, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_385"), EMonthlyEventType.SpecialEvent, "90d82569-41b6-4e4e-9c89-511d0a663fc5", "sp_monthlyevent_200", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_385"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(386, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_386"), EMonthlyEventType.NormalEvent, "5f64f539-8f01-4339-9fa5-50ca4b8c12a9", "sp_monthlyevent_260", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_386"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(387, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_387"), EMonthlyEventType.NormalEvent, "1b60bd1f-81e9-4e8c-b071-ea3c39f95841", "sp_monthlyevent_261", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_387"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(388, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_388"), EMonthlyEventType.NormalEvent, "d7c301c2-28b5-4193-a757-4134c7308aca", "sp_monthlyevent_258", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_388"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(389, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_389"), EMonthlyEventType.SpecialEvent, "c64ef6a1-31d7-4675-a3fa-18fed993a8e9", "sp_monthlyevent_259", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_389"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(390, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_390"), EMonthlyEventType.NormalEvent, "6bdab49e-effd-4494-8980-75ee3936c9ed", "sp_monthlyevent_257", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_390"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(391, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_391"), EMonthlyEventType.NormalEvent, "39a8edfe-6da8-48e4-ba2d-6698f79ea1a9", "sp_monthlyevent_255", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_391"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(392, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_392"), EMonthlyEventType.NormalEvent, "f20ac1e5-dcc4-4d1a-b1ff-1257e6c4b65b", "sp_monthlyevent_256", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_392"), new string[7] { "", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(393, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_393"), EMonthlyEventType.NormalEvent, "4c525bbc-0cda-4fba-a413-ed21e071224a", "sp_monthlyevent_276", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_393"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(394, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_394"), EMonthlyEventType.NormalEvent, "00f15b2f-f022-415c-8bbc-974b62b5c731", "sp_monthlyevent_302", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_394"), new string[7] { "Character", "Location", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(395, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_395"), EMonthlyEventType.SpecialEvent, "b376ad01-17c0-4b86-88f9-65bda8a59dd6", "sp_monthlyevent_400", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_395"), new string[7] { "Character", "", "", "", "", "", "" }, null, 1, node: false, 0, 0, null, allowByEventFunction: true, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(396, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_396"), EMonthlyEventType.NormalEvent, "8ab5fa85-a29f-40a9-ba5d-1222b833517b", "sp_monthlyevent_401", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_396"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(397, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_397"), EMonthlyEventType.NormalEvent, "7500e798-17fa-4c8d-a659-ee38aed40e85", "sp_monthlyevent_402", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_397"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(398, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_398"), EMonthlyEventType.NormalEvent, "57457dd5-1207-4445-8029-1de2c3568dd5", "sp_monthlyevent_403", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_398"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(399, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_399"), EMonthlyEventType.NormalEvent, "6ae729e2-2a8e-4cd9-862b-d7f98906556a", "sp_monthlyevent_403", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_399"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(400, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_400"), EMonthlyEventType.NormalEvent, "8e85412f-612c-4cf1-afda-0e40127d8095", "sp_monthlyevent_403", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_400"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(401, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_401"), EMonthlyEventType.SpecialEvent, "2563c817-6487-4887-933d-28a24cbb79af", "sp_monthlyevent_404", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_401"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(402, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_402"), EMonthlyEventType.SpecialEvent, "754cddba-a47e-4d4f-87c7-df3aa1a7db90", "sp_monthlyevent_405", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_402"), new string[7] { "Location", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(403, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_403"), EMonthlyEventType.SpecialEvent, "64414d03-ca11-44ce-bb54-4d278751c269", "sp_monthlyevent_406", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_403"), new string[7] { "Location", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(404, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_404"), EMonthlyEventType.SpecialEvent, "d107f930-c790-4994-8fd7-585c65d91eb9", "sp_monthlyevent_407", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_404"), new string[7] { "Location", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(405, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_405"), EMonthlyEventType.SpecialEvent, "048708bc-d9c0-4d96-a5fb-3a2afb67c4b1", "sp_monthlyevent_408", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_405"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(406, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_406"), EMonthlyEventType.NormalEvent, "75df1f92-1c4d-4657-bb89-94adbc30df59", "sp_monthlyevent_339", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_406"), new string[7] { "Cricket", "ItemKey", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(407, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_407"), EMonthlyEventType.SpecialEvent, "d5a09f17-e854-44e3-a7df-aced32db04b0", "sp_monthlyevent_410", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_407"), new string[7] { "Character", "Cricket", "Character", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(408, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_408"), EMonthlyEventType.SpecialEvent, "df95ee05-11c7-4833-ba77-ea92d72132a2", "sp_monthlyevent_303", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_408"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(409, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_409"), EMonthlyEventType.SpecialEvent, "e864ce92-956b-48c4-b151-ac3bc9b0ba36", "sp_monthlyevent_251", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_409"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(410, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_410"), EMonthlyEventType.SpecialEvent, "00f84f77-6235-446b-b487-a8a65e5e1ebe", "sp_monthlyevent_304", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_410"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(411, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_411"), EMonthlyEventType.SpecialEvent, "1b4fc7cd-014f-4733-8bc0-1fa450fe9dcd", "sp_monthlyevent_305", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_411"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(412, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_412"), EMonthlyEventType.SpecialEvent, "41eb899b-95fb-4762-a248-9981681e0019", "sp_monthlyevent_306", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_412"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(413, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_413"), EMonthlyEventType.NormalEvent, "1ae5ffc2-f43e-48da-961e-f1dd4a5359bb", "sp_monthlyevent_279", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_413"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(414, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_414"), EMonthlyEventType.NormalEvent, "b168ba4c-748b-42b4-a570-7a9324872d53", "sp_monthlyevent_280", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_414"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(415, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_415"), EMonthlyEventType.NormalEvent, "d7d21946-5459-4b85-9656-c950d337838a", "sp_monthlyevent_278", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_415"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(416, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_416"), EMonthlyEventType.NormalEvent, "ca46b04a-3067-46ad-a547-de3191a5babf", "sp_monthlyevent_277", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_416"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(417, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_417"), EMonthlyEventType.SpecialEvent, "783afcfd-6537-4b40-b1ac-bab48ec78fd3", "sp_monthlyevent_284", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_417"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(418, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_418"), EMonthlyEventType.SpecialEvent, "fcc0b529-a066-405a-ae37-427fd1347080", "sp_monthlyevent_285", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_418"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(419, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_419"), EMonthlyEventType.SpecialEvent, "d6df742c-4c41-41a7-b81f-a5b2cd314578", "sp_monthlyevent_281", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_419"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new MonthlyEventItem(420, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_420"), EMonthlyEventType.NormalEvent, "71221a46-347b-4ab3-b676-e733552cbd88", "sp_monthlyevent_283", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_420"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(421, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_421"), EMonthlyEventType.NormalEvent, "b38ab968-0d95-43d1-9d47-a2723ec41d85", "sp_monthlyevent_282", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_421"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(422, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_422"), EMonthlyEventType.NormalEvent, "cfa70d54-9665-44ed-9808-6ea0f76b0c78", "sp_monthlyevent_289", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_422"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(423, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_423"), EMonthlyEventType.NormalEvent, "6a66f37e-d5d2-4360-88a9-65ddc5919504", "sp_monthlyevent_290", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_423"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(424, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_424"), EMonthlyEventType.NormalEvent, "6c16d7ef-ff41-40ab-a550-5bc3c6800dd0", "sp_monthlyevent_291", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_424"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(425, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_425"), EMonthlyEventType.NormalEvent, "c5ba4903-f2d7-4a2c-81ee-29c9b407fe04", "sp_monthlyevent_292", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_425"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(426, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_426"), EMonthlyEventType.NormalEvent, "4af50620-2da9-4c15-a5ba-2160930aea53", "sp_monthlyevent_293", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_426"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(427, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_427"), EMonthlyEventType.NormalEvent, "727cb2c7-6813-439d-a728-91fce80ff801", "sp_monthlyevent_294", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_427"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(428, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_428"), EMonthlyEventType.NormalEvent, "28ac040c-51ac-4639-b4c8-9611d8a13ee7", "sp_monthlyevent_295", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_428"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(429, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_429"), EMonthlyEventType.NormalEvent, "508bc995-cc29-44df-87ab-9711101349cc", "sp_monthlyevent_296", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_429"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(430, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_430"), EMonthlyEventType.NormalEvent, "db533aed-31fa-4691-bf35-90dbd05bbcb4", "sp_monthlyevent_297", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_430"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(431, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_431"), EMonthlyEventType.NormalEvent, "073072d7-9878-455a-81dd-65f3ed9cd824", "sp_monthlyevent_288", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_431"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(432, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_432"), EMonthlyEventType.SpecialEvent, "ca72de3b-cceb-4b5f-8064-837d6aacc83f", "sp_monthlyevent_287", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_432"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(433, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_433"), EMonthlyEventType.SpecialEvent, "c76232f6-91c0-4426-a480-c57ffbc4af8c", "sp_monthlyevent_286", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_433"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, new string[1] { "RoleTaiwu" }, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(434, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_434"), EMonthlyEventType.NormalEvent, "193e8c2e-1c08-420d-9dd0-9a09a0eee1d3", "sp_monthlyevent_299", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_434"), new string[7] { "Character", "Location", "Integer", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(435, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_435"), EMonthlyEventType.SpecialEvent, "95fad450-18b0-418d-a4fc-7c2af954d8f1", "sp_monthlyevent_307", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_435"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(436, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_436"), EMonthlyEventType.SpecialEvent, "d9f9c493-525a-4b2a-9043-e829c81f6351", "sp_monthlyevent_308", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_436"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(437, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_437"), EMonthlyEventType.SpecialEvent, "25e21fa8-6532-4258-9b15-2581780458bd", "sp_monthlyevent_309", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_437"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(438, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_438"), EMonthlyEventType.SpecialEvent, "37a4dd4e-67ff-49f5-80b6-4f6247987fc2", "sp_monthlyevent_310", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_438"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(439, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_439"), EMonthlyEventType.SpecialEvent, "dfb910b3-1347-4e45-8c1f-71ca28eec09e", "sp_monthlyevent_311", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_439"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(440, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_440"), EMonthlyEventType.SpecialEvent, "2d0241a2-b83b-4e1e-973c-d3b3c4d1b80b", "sp_monthlyevent_312", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_440"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(441, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_441"), EMonthlyEventType.SpecialEvent, "e5b1dc59-ef7e-4021-8f72-04529a849353", "sp_monthlyevent_313", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_441"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(442, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_442"), EMonthlyEventType.SpecialEvent, "3f444e89-54fe-4ac3-8577-8d562a331705", "sp_monthlyevent_314", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_442"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(443, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_443"), EMonthlyEventType.SpecialEvent, "11c47cfa-8151-40ec-8c60-917606fa4a9c", "sp_monthlyevent_315", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_443"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(444, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_444"), EMonthlyEventType.SpecialEvent, "7e70da16-5ae1-4b89-8494-ece8592a1b68", "sp_monthlyevent_316", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_444"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(445, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_445"), EMonthlyEventType.SpecialEvent, "0cf97222-9913-4490-8d78-cd8090d67f0b", "sp_monthlyevent_317", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_445"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(446, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_446"), EMonthlyEventType.SpecialEvent, "ccaf504d-882a-4b65-9ed7-fcbe9d6456cd", "sp_monthlyevent_318", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_446"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(447, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_447"), EMonthlyEventType.SpecialEvent, "32189e35-bf0f-4718-bfe6-7f387569e2ae", "sp_monthlyevent_319", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_447"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(448, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_448"), EMonthlyEventType.SpecialEvent, "01b3ddda-e0b2-4c8b-948c-4507229a262a", "sp_monthlyevent_320", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_448"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(449, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_449"), EMonthlyEventType.SpecialEvent, "21e983e7-af72-4789-880a-d86dca16af37", "sp_monthlyevent_321", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_449"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(450, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_450"), EMonthlyEventType.SpecialEvent, "089f691e-34cb-4db2-be56-a63c5b4a5558", "sp_monthlyevent_322", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_450"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(451, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_451"), EMonthlyEventType.SpecialEvent, "42359edc-a013-4aaf-a7a6-35ce09b60ed5", "sp_monthlyevent_323", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_451"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(452, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_452"), EMonthlyEventType.SpecialEvent, "6fd1914c-99b2-423a-baeb-199c4f9a18ef", "sp_monthlyevent_324", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_452"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(453, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_453"), EMonthlyEventType.SpecialEvent, "71768bfe-630c-4d89-a59a-9d1fba5b2483", "sp_monthlyevent_330", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_453"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(454, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_454"), EMonthlyEventType.SpecialEvent, "add6a761-09b0-42dc-9418-46e485c902f9", "sp_monthlyevent_333", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_454"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(455, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_455"), EMonthlyEventType.SpecialEvent, "181f83fa-9290-4488-8f8f-42970b29de20", "sp_monthlyevent_332", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_455"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(456, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_456"), EMonthlyEventType.SpecialEvent, "2c493f32-894b-42ab-a8f3-d29968998c0c", "sp_monthlyevent_331", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_456"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(457, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_457"), EMonthlyEventType.SpecialEvent, "92f24cba-207e-4404-a35b-7282ac216841", "sp_monthlyevent_334", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_457"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(458, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_458"), EMonthlyEventType.SpecialEvent, "35f2cd40-dc81-42fe-97a7-4ed5dc986fb0", "sp_monthlyevent_335", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_458"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(459, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_459"), EMonthlyEventType.SpecialEvent, null, null, LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_459"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(460, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_460"), EMonthlyEventType.SpecialEvent, "ee1b6934-e487-425f-a48a-aee8beccb7ad", "sp_monthlyevent_336", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_460"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(461, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_461"), EMonthlyEventType.SpecialEvent, "417802c9-3f5c-42a2-b6be-80b90315f0c4", "sp_monthlyevent_337", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_461"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(462, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_462"), EMonthlyEventType.SpecialEvent, "bc629427-0ddc-41b4-a514-4051a1c229bb", "sp_monthlyevent_338", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_462"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(463, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_463"), EMonthlyEventType.NormalEvent, "d9ad221e-007e-455b-8cbd-6815f3ee1ef8", "sp_monthlyevent_329", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_463"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(464, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_464"), EMonthlyEventType.SpecialEvent, "6220450f-8422-4ed9-8429-670f16a8af5b", "sp_monthlyevent_329", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_464"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(465, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_465"), EMonthlyEventType.SpecialEvent, "45e14fc7-a3a4-4047-83b7-4539a0447efc", "sp_monthlyevent_298", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_465"), new string[7] { "SwordTomb", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(466, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_466"), EMonthlyEventType.SpecialEvent, "b7cf3cd2-8974-4656-b198-d972e0071c61", "sp_monthlyevent_411", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_466"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(467, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_467"), EMonthlyEventType.SpecialEvent, "5989ddc3-b90f-4424-84e7-f429bd36bbe6", "sp_monthlyevent_412", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_467"), new string[7] { "", "", "", "", "", "", "" }, null, 10, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(468, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_468"), EMonthlyEventType.SpecialEvent, "834e5c91-0a63-407e-ad3b-10a985e2ecb0", "sp_monthlyevent_413", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_468"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(469, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_469"), EMonthlyEventType.SpecialEvent, "91ee8490-d829-4b6f-b0cb-5e50f04b26a8", "sp_monthlyevent_413", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_469"), new string[7] { "", "", "", "", "", "", "" }, null, 5, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(470, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_470"), EMonthlyEventType.SpecialEvent, "4ff86c7a-e226-4281-8258-998cd6f0caf7", "sp_monthlyevent_414", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_470"), new string[7] { "Character", "", "", "", "", "", "" }, null, 3, node: false, 50, 0, new string[1] { "RoleTaiwu" }, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(471, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_471"), EMonthlyEventType.SpecialEvent, "86572435-f138-42c7-a272-605a18525340", "sp_monthlyevent_415", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_471"), new string[7] { "", "", "", "", "", "", "" }, null, 3, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(472, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_472"), EMonthlyEventType.SpecialEvent, "cc935baf-42ff-4c6f-b020-404b0aa8a218", "sp_monthlyevent_416", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_472"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(473, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_473"), EMonthlyEventType.NormalEvent, "dfcecb89-dd6d-436d-92fb-e3bbf861e6d8", "sp_monthlyevent_325", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_473"), new string[7] { "Character", "Character", "Location", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(474, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_474"), EMonthlyEventType.SpecialEvent, "3f58831b-c7c0-4bae-a80f-f7ab0cf987b6", "sp_monthlyevent_326", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_474"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(475, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_475"), EMonthlyEventType.SpecialEvent, "6b45b3f7-818b-435d-b63e-853c213f7a64", "sp_monthlyevent_327", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_475"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(476, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_476"), EMonthlyEventType.NormalEvent, "794d7193-fdc0-4477-9135-07fe9ae766f3", "sp_monthlyevent_328", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_476"), new string[7] { "Character", "Character", "Location", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(477, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_477"), EMonthlyEventType.NormalEvent, "d6f71a46-b457-4df2-876c-fd112fe07bd0", "sp_monthlyevent_301", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_477"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(478, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_478"), EMonthlyEventType.NormalEvent, "7f9147c3-ea22-400b-b623-b97a3c165d70", "sp_monthlyevent_409", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_478"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(479, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_479"), EMonthlyEventType.SpecialEvent, "ae435dbf-e7d5-42fa-86b1-482237da54db", "sp_monthlyevent_417", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_479"), new string[7] { "Character", "Character", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
	}

	private void CreateItems8()
	{
		_dataArray.Add(new MonthlyEventItem(480, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_480"), EMonthlyEventType.SpecialEvent, "462ea81a-4b62-4a4e-adde-6930316da1d9", "sp_monthlyevent_82", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_480"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 100, 0, new string[1] { "RoleTaiwu" }, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(481, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_481"), EMonthlyEventType.NormalEvent, "83c5916f-387c-4ee0-8801-2f6f219c5e4e", "sp_monthlyevent_420", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_481"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(482, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_482"), EMonthlyEventType.SpecialEvent, "6b212de5-24ff-4f51-a5dd-8d3e3fb4ccf9", "sp_monthlyevent_421", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_482"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(483, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_483"), EMonthlyEventType.SpecialEvent, "68b7b34f-2ed2-4ad9-8eed-3f910b435d62", "sp_monthlyevent_422", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_483"), new string[7] { "Settlement", "Chicken", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(484, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_484"), EMonthlyEventType.SpecialEvent, "5c365aac-d79a-4b43-9ce4-64410257f4bb", "sp_monthlyevent_423", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_484"), new string[7] { "Character", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(485, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_485"), EMonthlyEventType.NormalEvent, "e731d2ab-c791-4541-bcbe-4bcc3ced2346", "sp_monthlyevent_419", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_485"), new string[7] { "Location", "", "", "", "", "", "" }, null, 0, node: false, 0, 0, null, allowByEventFunction: false, allowInAdventure: true, 0u));
		_dataArray.Add(new MonthlyEventItem(486, LocalStringManager.GetConfig("MonthlyEvent_language", "Name_486"), EMonthlyEventType.NormalEvent, "03b6783a-38ce-4d60-8fdb-6272e4d7f527", "sp_monthlyevent_424", LocalStringManager.GetConfig("MonthlyEvent_language", "Desc_486"), new string[7] { "", "", "", "", "", "", "" }, null, 0, node: false, 100, 0, null, allowByEventFunction: true, allowInAdventure: true, 5093790u));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MonthlyEventItem>(487);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
		CreateItems7();
		CreateItems8();
	}
}

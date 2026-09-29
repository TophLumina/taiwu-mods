using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class LifeRecord : ConfigData<LifeRecordItem, short>
{
	public static class DefKey
	{
		public const short Die = 0;

		public const short XiangshuPartiallyInfected = 1;

		public const short XiangshuCompletelyInfected = 2;

		public const short MotherLoseFetus = 3;

		public const short FatherLoseFetus = 4;

		public const short AbandonChild = 5;

		public const short ChildGetAbandoned = 6;

		public const short GiveBirthToCricket = 7;

		public const short GiveBirthToBoy = 8;

		public const short GiveBirthToGirl = 9;

		public const short BecomeFatherToNewBornBoy = 10;

		public const short BecomeFatherToNewBornGirl = 11;

		public const short BuildGrave = 12;

		public const short MonkBreakRule = 13;

		public const short KidnappedCharacterEscaped = 14;

		public const short EscapeFromKidnapping = 15;

		public const short ReadBookSucceed = 16;

		public const short ReadBookFail = 17;

		public const short BreakoutSucceed = 18;

		public const short BreakoutFail = 19;

		public const short LearnCombatSkill = 20;

		public const short LearnLifeSkill = 21;

		public const short RepairItem = 22;

		public const short AddPoisonToItem = 23;

		public const short LoseOverloadingResource = 24;

		public const short LoseOverloadingItem = 25;

		public const short MakeEnemy = 26;

		public const short SeverEnemy = 27;

		public const short BeMadeEnemy = 28;

		public const short SeveredEnemy = 29;

		public const short Adore = 30;

		public const short LoveAtFirstSight = 31;

		public const short ConfessLoveSucceed = 32;

		public const short ConfessLoveFail = 33;

		public const short AcceptConfessLove = 34;

		public const short RefuseConfessLove = 35;

		public const short BreakupMutually = 36;

		public const short DumpLover = 37;

		public const short GetDumppedByLover = 38;

		public const short ProposeMarriageSucceed = 39;

		public const short ProposeMarriageFail = 40;

		public const short RefuseMarriageProposal = 41;

		public const short BecomeFriend = 42;

		public const short SeverFriendship = 43;

		public const short BecomeSwornBrotherOrSister = 44;

		public const short SeverSwornBrotherhood = 45;

		public const short GetAdoptedByFather = 46;

		public const short GetAdoptedByMother = 47;

		public const short AdoptSon = 48;

		public const short AdoptDaughter = 49;

		public const short CreateFaction = 50;

		public const short JoinFaction = 51;

		public const short LeaveFaction = 52;

		public const short FactionRecruitSucceed = 53;

		public const short FactionRecruitFail = 54;

		public const short AgreeToJoinFaction = 55;

		public const short RefuseToJoinFaction = 56;

		public const short DecideToJoinSect = 57;

		public const short DecideToFullfillAppointment = 58;

		public const short DecideToProtect = 59;

		public const short DecideToRescue = 60;

		public const short DecideToMourn = 61;

		public const short DecideToVisit = 62;

		public const short DecideToFindLostItem = 63;

		public const short DecideToFindSpecialMaterial = 64;

		public const short DecideToRevenge = 65;

		public const short DecideToParticipateAdventure = 66;

		public const short JoinSectFail = 67;

		public const short JoinSectSucceed = 68;

		public const short CanNoLongerFullFillAppointment = 69;

		public const short WaitForAppointment = 70;

		public const short FullFillAppointment = 71;

		public const short FinishProtection = 72;

		public const short OfferProtection = 73;

		public const short FinishRescue = 74;

		public const short FinishMourning = 75;

		public const short MaintainGrave = 76;

		public const short UpgradeGrave = 77;

		public const short FinishVisit = 78;

		public const short FinishFIndingLostItem = 79;

		public const short FinishFIndingSpecialMaterial = 80;

		public const short FindLostItemSucceed = 81;

		public const short FindLostItemFail = 82;

		public const short FindSpecialMaterialSucceed = 83;

		public const short FinishTakingRevenge = 84;

		public const short MajorVictoryInCombat = 85;

		public const short MajorFailureInCombat = 86;

		public const short VictoryInCombat = 87;

		public const short FailureInCombat = 88;

		public const short EnemyEscape = 89;

		public const short LoseAndEscape = 90;

		public const short KillInPublic = 91;

		public const short KillInPrivate = 92;

		public const short KidnapInPublic = 93;

		public const short KidnapInPrivate = 94;

		public const short ReleaseLoser = 95;

		public const short GetKidnappedInPublic = 96;

		public const short GetKidnappedInPrivate = 97;

		public const short GetReleasedByWinner = 98;

		public const short AgreeToProtect = 99;

		public const short RefuseToProtect = 100;

		public const short FinishAdventure = 101;

		public const short RequestHealOuterInjuryItemSucceed = 102;

		public const short RequestHealInnerInjuryItemSucceed = 103;

		public const short RequestDetoxPoisonItemSucceed = 104;

		public const short RequestHealthItemSucceed = 105;

		public const short RequestHealDisorderOfQiItemSucceed = 106;

		public const short RequestNeiliSucceed = 107;

		public const short RequestKillWugSucceed = 108;

		public const short RequestFoodSucceed = 109;

		public const short RequestTeaWineSucceed = 110;

		public const short RequestResourceSucceed = 111;

		public const short RequestItemSucceed = 112;

		public const short RequestRepairItemSucceed = 113;

		public const short RequestAddPoisonToItemSucceed = 114;

		public const short RequestInstructionOnLifeSkillSucceed = 115;

		public const short RequestInstructionOnCombatSkillSucceed = 116;

		public const short RequestInstructionOnLifeSkillFailToLearn = 117;

		public const short RequestInstructionOnCombatSkillFailToLearn = 118;

		public const short RequestInstructionOnReadingSucceed = 119;

		public const short RequestInstructionOnBreakoutSucceed = 120;

		public const short RequestHealOuterInjuryItemFail = 121;

		public const short RequestHealInnerInjuryItemFail = 122;

		public const short RequestDetoxPoisonItemFail = 123;

		public const short RequestHealthItemFail = 124;

		public const short RequestHealDisorderOfQiItemFail = 125;

		public const short RequestNeiliFail = 126;

		public const short RequestKillWugFail = 127;

		public const short RequestFoodFail = 128;

		public const short RequestTeaWineFail = 129;

		public const short RequestResourceFail = 130;

		public const short RequestItemFail = 131;

		public const short RequestRepairItemFail = 132;

		public const short RequestAddPoisonToItemFail = 133;

		public const short RequestInstructionOnLifeSkillFail = 134;

		public const short RequestInstructionOnCombatSkillFail = 135;

		public const short RequestInstructionOnReadingFail = 136;

		public const short RequestInstructionOnBreakoutFail = 137;

		public const short AcceptRequestHealOuterInjuryItem = 138;

		public const short AcceptRequestHealInnerInjuryItem = 139;

		public const short AcceptRequestDetoxPoisonItem = 140;

		public const short AcceptRequestHealthItem = 141;

		public const short AcceptRequestHealDisorderOfQiItem = 142;

		public const short AcceptRequestNeili = 143;

		public const short AcceptRequestKillWug = 144;

		public const short AcceptRequestFood = 145;

		public const short AcceptRequestTeaWine = 146;

		public const short AcceptRequestResource = 147;

		public const short AcceptRequestItem = 148;

		public const short AcceptRequestRepairItem = 149;

		public const short AcceptRequestAddPoisonToItem = 150;

		public const short AcceptRequestInstructionOnLifeSkill = 151;

		public const short AcceptRequestInstructionOnCombatSkill = 152;

		public const short AcceptRequestInstructionOnLifeSkillButFail = 153;

		public const short AcceptRequestInstructionOnCombatSkillButFail = 154;

		public const short AcceptRequestInstructionOnReading = 155;

		public const short AcceptRequestInstructionOnBreakout = 156;

		public const short RefuseRequestHealOuterInjuryItem = 157;

		public const short RefuseRequestHealInnerInjuryItem = 158;

		public const short RefuseRequestDetoxPoisonItem = 159;

		public const short RefuseRequestHealthItem = 160;

		public const short RefuseRequestHealDisorderOfQiItem = 161;

		public const short RefuseRequestNeili = 162;

		public const short RefuseRequestKillWug = 163;

		public const short RefuseRequestFood = 164;

		public const short RefuseRequestTeaWine = 165;

		public const short RefuseRequestResource = 166;

		public const short RefuseRequestItem = 167;

		public const short RefuseRequestRepairItem = 168;

		public const short RefuseRequestAddPoisonToItem = 169;

		public const short RefuseRequestInstructionOnLifeSkill = 170;

		public const short RefuseRequestInstructionOnCombatSkill = 171;

		public const short RefuseRequestInstructionOnReading = 172;

		public const short RefuseRequestInstructionOnBreakout = 173;

		public const short RescueKidnappedCharacterSecretlyFail1 = 174;

		public const short RescueKidnappedCharacterSecretlyFail2 = 175;

		public const short RescueKidnappedCharacterSecretlyFail3 = 176;

		public const short RescueKidnappedCharacterSecretlyFail4 = 177;

		public const short RescueKidnappedCharacterSecretlySucceed = 178;

		public const short RescueKidnappedCharacterSecretlySucceedAndEscaped = 179;

		public const short KidnappedCharacterGetRescuedSecretly = 180;

		public const short RescueKidnappedCharacterWithWitFail1 = 181;

		public const short RescueKidnappedCharacterWithWitFail2 = 182;

		public const short RescueKidnappedCharacterWithWitFail3 = 183;

		public const short RescueKidnappedCharacterWithWitFail4 = 184;

		public const short RescueKidnappedCharacterWithWitSucceed = 185;

		public const short RescueKidnappedCharacterWithWitSucceedAndEscaped = 186;

		public const short KidnappedCharacterGetRescuedWithWit = 187;

		public const short RescueKidnappedCharacterWithForceFail1 = 188;

		public const short RescueKidnappedCharacterWithForceFail2 = 189;

		public const short RescueKidnappedCharacterWithForceFail3 = 190;

		public const short RescueKidnappedCharacterWithForceFail4 = 191;

		public const short RescueKidnappedCharacterWithForceSucceed = 192;

		public const short RescueKidnappedCharacterWithForceSucceedAndEscaped = 193;

		public const short KidnappedCharacterGetRescuedWithForce = 194;

		public const short PoisonEnemyFail1 = 195;

		public const short PoisonEnemyFail2 = 196;

		public const short PoisonEnemyFail3 = 197;

		public const short PoisonEnemyFail4 = 198;

		public const short PoisonEnemySucceed = 199;

		public const short PoisonEnemySucceedAndEscaped = 200;

		public const short GetPoisonedByEnemySucceed = 201;

		public const short PlotHarmEnemyFail1 = 202;

		public const short PlotHarmEnemyFail2 = 203;

		public const short PlotHarmEnemyFail3 = 204;

		public const short PlotHarmEnemyFail4 = 205;

		public const short PlotHarmEnemySucceed = 206;

		public const short PlotHarmEnemySucceedAndEscaped = 207;

		public const short GetPlottedAgainstSucceed = 208;

		public const short StealResourceFail1 = 209;

		public const short StealResourceFail2 = 210;

		public const short StealResourceFail3 = 211;

		public const short StealResourceFail4 = 212;

		public const short StealResourceSucceed = 213;

		public const short StealResourceSucceedAndEscaped = 214;

		public const short StealResourceFailAndBeatenUp = 215;

		public const short ResourceGetStolenSucceed = 216;

		public const short BeatUpResourceStealer = 217;

		public const short ScamResourceFail1 = 218;

		public const short ScamResourceFail2 = 219;

		public const short ScamResourceFail3 = 220;

		public const short ScamResourceFail4 = 221;

		public const short ScamResourceSucceed = 222;

		public const short ScamResourceSucceedAndEscaped = 223;

		public const short ScamResourceFailAndBeatenUp = 224;

		public const short ResourceGetScammedSucceed = 225;

		public const short BeatUpResourceScammer = 226;

		public const short RobResourceFail1 = 227;

		public const short RobResourceFail2 = 228;

		public const short RobResourceFail3 = 229;

		public const short RobResourceFail4 = 230;

		public const short RobResourceSucceed = 231;

		public const short RobResourceSucceedAndEscaped = 232;

		public const short RobResourceFailAndBeatenUp = 233;

		public const short ResourceGetRobbedSucceed = 234;

		public const short BeatUpResourceRobber = 235;

		public const short StealItemFail1 = 236;

		public const short StealItemFail2 = 237;

		public const short StealItemFail3 = 238;

		public const short StealItemFail4 = 239;

		public const short StealItemSucceed = 240;

		public const short StealItemSucceedAndEscaped = 241;

		public const short StealItemSucceedAndBeatenUp = 242;

		public const short ItemGetStolenSucceed = 243;

		public const short BeatUpItemStealer = 244;

		public const short ScamItemFail1 = 245;

		public const short ScamItemFail2 = 246;

		public const short ScamItemFail3 = 247;

		public const short ScamItemFail4 = 248;

		public const short ScamItemSucceed = 249;

		public const short ScamItemSucceedAndEscaped = 250;

		public const short ScamItemFailAndBeatenUp = 251;

		public const short ItemGetScammedSucceed = 252;

		public const short BeatUpItemScammer = 253;

		public const short RobItemFail1 = 254;

		public const short RobItemFail2 = 255;

		public const short RobItemFail3 = 256;

		public const short RobItemFail4 = 257;

		public const short RobItemSucceed = 258;

		public const short RobItemSucceedAndEscaped = 259;

		public const short RobItemFailAndBeatenUp = 260;

		public const short ItemGetRobbedSucceed = 261;

		public const short BeatUpItemRobber = 262;

		public const short RobResourceFromGraveSucceed = 263;

		public const short RobResourceFromGraveFail = 264;

		public const short RobItemFromGraveSucceed = 265;

		public const short RobItemFromGraveFail = 266;

		public const short StealLifeSkillFail1 = 267;

		public const short StealLifeSkillFail2 = 268;

		public const short StealLifeSkillFail3 = 269;

		public const short StealLifeSkillFail4 = 270;

		public const short StealLifeSkillSucceed = 271;

		public const short StealLifeSkillSucceedAndEscaped = 272;

		public const short LifeSkillGetStolenSucceed = 273;

		public const short ScamLifeSkillFail1 = 274;

		public const short ScamLifeSkillFail2 = 275;

		public const short ScamLifeSkillFail3 = 276;

		public const short ScamLifeSkillFail4 = 277;

		public const short ScamLifeSkillSucceed = 278;

		public const short ScamLifeSkillSucceedAndEscaped = 279;

		public const short LifeSkillGetScammedSucceed = 280;

		public const short StealCombatSkillFail1 = 281;

		public const short StealCombatSkillFail2 = 282;

		public const short StealCombatSkillFail3 = 283;

		public const short StealCombatSkillFail4 = 284;

		public const short StealCombatSkillSucceed = 285;

		public const short StealCombatSkillSucceedAndEscaped = 286;

		public const short CombatSkillGetStolenSucceed = 287;

		public const short ScamCombatSkillFail1 = 288;

		public const short ScamCombatSkillFail2 = 289;

		public const short ScamCombatSkillFail3 = 290;

		public const short ScamCombatSkillFail4 = 291;

		public const short ScamCombatSkillSucceed = 292;

		public const short ScamCombatSkillSucceedAndEscaped = 293;

		public const short CombatSkillGetScammedSucceed = 294;

		public const short LifeSkillBattleWin = 295;

		public const short LifeSkillBattleLose = 296;

		public const short ExchangeResource = 297;

		public const short GiveResource = 298;

		public const short PurchaseItem = 299;

		public const short SellItem = 300;

		public const short GiveItem = 301;

		public const short GivePoisonousItem = 302;

		public const short GetResourceAsGift = 303;

		public const short GetItemAsGift = 304;

		public const short RefusePoisonousGift = 305;

		public const short InstructLifeSkill = 306;

		public const short InstructCombatSkill = 307;

		public const short LearnLifeSkillWithInstructionSucceed = 308;

		public const short LearnLifeSkillWithInstructionFail = 309;

		public const short LearnCombatSkillWithInstructionSucceed = 310;

		public const short LearnCombatSkillWithInstructionFail = 311;

		public const short InviteToDrinkSucceed = 312;

		public const short InviteToDrinkFail = 313;

		public const short SellSucceed = 314;

		public const short SellFail = 315;

		public const short CureSucceed = 316;

		public const short RepairItemSucceed = 317;

		public const short BarbSucceed = 318;

		public const short BarbMistake = 319;

		public const short BarbFail = 320;

		public const short AskForMoneySucceed = 321;

		public const short AskForMoneyFail = 322;

		public const short EntertainWithMusic = 323;

		public const short EntertainWithChess = 324;

		public const short EntertainWithPoem = 325;

		public const short EntertainWithPainting = 326;

		public const short AcceptInviteToDrink = 327;

		public const short RefuseInviteToDrink = 328;

		public const short AcceptSell = 329;

		public const short RefuseSell = 330;

		public const short AcceptCure = 331;

		public const short AcceptRepairItem = 332;

		public const short GetBarbSucceed = 333;

		public const short GetBarbMistake = 334;

		public const short GetBarbFail = 335;

		public const short AcceptAskForMoney = 336;

		public const short RefuseAskForMoney = 337;

		public const short AcceptEntertainWithMusic = 338;

		public const short AcceptEntertainWithChess = 339;

		public const short AcceptEntertainWithPoem = 340;

		public const short AcceptEntertainWithPainting = 341;

		public const short MakeItem = 342;

		public const short TaoismAwakeningSucceed = 343;

		public const short TaoismAwakeningFail = 344;

		public const short BuddismAwakeningSucceed = 345;

		public const short BuddismAwakeningFail = 346;

		public const short TaoismGetAwakenedSucceed = 347;

		public const short TaoismGetAwakenedFail = 348;

		public const short BuddismGetAwakenedSucceed = 349;

		public const short BuddismGetAwakenedFail = 350;

		public const short CollectTeaWineSucceed = 351;

		public const short CollectTeaWineFail = 352;

		public const short DivinationSucceed = 353;

		public const short DivinationFail = 354;

		public const short CricketBattleWin = 355;

		public const short CricketBattleLose = 356;

		public const short MakeLoveLegal = 1401;

		public const short MakeLoveIllegal = 357;

		public const short RapeFail = 358;

		public const short RapeSucceed = 359;

		public const short ReleaseKidnappedCharacter = 360;

		public const short GetRapedFail = 361;

		public const short GetRapedSucceed = 362;

		public const short GetReleasedByKidnapper = 363;

		public const short MerchantGetNewProduct = 364;

		public const short UnexpectedResourceGain = 365;

		public const short UnexpectedItemGain = 366;

		public const short UnexpectedSkillBookGain = 367;

		public const short UnexpectedHealthCure = 368;

		public const short UnexpectedOuterInjuryCure = 369;

		public const short UnexpectedInnerInjuryCure = 370;

		public const short UnexpectedPoisonCure = 371;

		public const short UnexpectedDisorderOfQiCure = 372;

		public const short UnexpectedResourceLose = 373;

		public const short UnexpectedItemLose = 374;

		public const short UnexpectedSkillBookLose = 375;

		public const short UnexpectedHealthHarm = 376;

		public const short UnexpectedOuterInjuryHarm = 377;

		public const short UnexpectedInnerInjuryHarm = 378;

		public const short UnexpectedPoisonHarm = 379;

		public const short UnexpectedDisorderOfQiHarm = 380;

		public const short KillHereticRandomEnemy = 381;

		public const short KillRighteousRandomEnemy = 382;

		public const short DefeatedByHereticRandomEnemy = 383;

		public const short DefeatedByRighteousRandomEnemy = 384;

		public const short MonvBad = 385;

		public const short DayueYaochangBad = 386;

		public const short JinHuangerBad = 387;

		public const short YiyihouBad = 388;

		public const short WeiQiBad = 389;

		public const short YixiangBad = 390;

		public const short ShufangBad = 391;

		public const short JixiBad = 392;

		public const short MonvGood = 393;

		public const short DayueYaochangGood = 394;

		public const short JinHuangerGood = 395;

		public const short YiyihouGood = 396;

		public const short WeiQiGood = 397;

		public const short YixiangGood = 398;

		public const short XuefengGood = 399;

		public const short ShufangGood = 400;

		public const short PregnantWithSamsara0 = 401;

		public const short PregnantWithSamsara1 = 402;

		public const short PregnantWithSamsara2 = 403;

		public const short PregnantWithSamsara3 = 404;

		public const short PregnantWithSamsara4 = 405;

		public const short PregnantWithSamsara5 = 406;

		public const short GainAuthority = 407;

		public const short SectPunishNormal = 408;

		public const short SectPunishElope = 409;

		public const short ExpelVillager = 410;

		public const short SavedFromInfection = 411;

		public const short ChangeGrade = 412;

		public const short AutoChangeGrade = 1414;

		public const short ExpelledByTaiwu = 413;

		public const short InsteadSectPunishElope = 414;

		public const short AvoidSectPunishElope = 415;

		public const short JoinJoustForSpouse = 416;

		public const short GetHusbandByJoustForSpouse = 417;

		public const short GetWifeByJoustForSpouse = 418;

		public const short NoHusbandByJoustForSpouse = 419;

		public const short SectCompetitionBeWinner = 420;

		public const short SectCompetitionBeParticipant = 421;

		public const short SectCompetitionBeHost = 422;

		public const short WulinConferenceBeParticipant = 423;

		public const short WulinConferenceBeWinner = 424;

		public const short WulinConferenceBeWinnerButTaiwu = 425;

		public const short WulinConferenceBeHost = 426;

		public const short WulinConferenceBeKilledByYufu = 427;

		public const short WulinConferenceDonation = 428;

		public const short BeAttackedAndDieByWuYingLing = 429;

		public const short NaturalDisasterGiveDeath = 430;

		public const short NaturalDisasterHappen = 431;

		public const short NaturalDisasterButSurvive = 432;

		public const short NormalInformationChangeLovingItemSubType = 433;

		public const short NormalInformationChangeHatingItemSubType = 434;

		public const short NormalInformationChangeIdealSect = 435;

		public const short NormalInformationChangeBaseMorality = 436;

		public const short NormalInformationChangeLifeSkillTypeInterest = 437;

		public const short RobGraveEncounterSkeleton = 438;

		public const short RobGraveFailed = 439;

		public const short SectPunishLevelLowest = 440;

		public const short PrincipalSectPunishLevelMiddle = 441;

		public const short PrincipalSectPunishLevelHighest = 442;

		public const short NonPrincipalSectPunishLevelLowest = 443;

		public const short NonPrincipalSectPunishLevelHighest = 444;

		public const short BecomeSwornSiblingByThreatened = 445;

		public const short MarriedByThreatened = 446;

		public const short GetAdoptedFatherByThreatened = 447;

		public const short GetAdoptedMotherByThreatened = 448;

		public const short GetAdoptedSonByThreatened = 449;

		public const short GetAdoptedDaughterByThreatened = 450;

		public const short AddMentorByThreatened = 451;

		public const short SeverSwornSiblingByThreatened = 452;

		public const short DivorceByThreatened = 453;

		public const short SeverMentorByThreatened = 454;

		public const short SeverAdoptiveFatherByThreatened = 455;

		public const short SeverAdoptiveMotherByThreatened = 456;

		public const short SeverAdoptiveSonByThreatened = 457;

		public const short SeverAdoptiveDaughterByThreatened = 458;

		public const short GetThreatenedAdoptiveFather = 459;

		public const short GetThreatenedAdoptiveMother = 460;

		public const short GetThreatenedAdoptiveSon = 461;

		public const short GetThreatenedAdoptiveDaughter = 462;

		public const short ApproveTaiwuByThreatened = 463;

		public const short FourSeasonsAdventureBeParticipant = 464;

		public const short FourSeasonsAdventureBeWinner = 465;

		public const short EndAdored = 466;

		public const short GetMentor = 467;

		public const short GetMentee = 468;

		public const short SeverAdoptiveParent = 469;

		public const short SeverAdoptiveChild = 470;

		public const short SeverMentor = 471;

		public const short SeverMentee = 472;

		public const short Divorce = 473;

		public const short ThreatenSucceed = 474;

		public const short AdmonishSucceed = 475;

		public const short ChangeBehaviorTypeByAdmonishedGood = 476;

		public const short ReduceDebtByAdmonished = 477;

		public const short ReduceDebtByThreatened = 478;

		public const short ChangeBehaviorTypeByAdmonishedBad = 479;

		public const short GainLegendaryBook = 480;

		public const short BoostedByLegendaryBooks = 481;

		public const short ActCrazy = 482;

		public const short LegendaryBookShocked = 483;

		public const short LegendaryBookInsane = 484;

		public const short LegendaryBookConsumed = 485;

		public const short DecideToContestForLegendaryBook = 486;

		public const short FinishContestForLegendaryBook = 487;

		public const short LegendaryBookChallengeWin = 488;

		public const short LegendaryBookChallengeLose = 489;

		public const short AcceptLegendaryBookChallengeWin = 490;

		public const short AcceptLegendaryBookChallengeLose = 491;

		public const short AcceptLegendaryBookChallengeEscape = 492;

		public const short LegendaryBookChallengeEscaped = 493;

		public const short LegendaryBookChallengeSelfEscaped = 494;

		public const short AcceptLegendaryBookChallengeEnemyEscaped = 495;

		public const short RefuseRequestLegendaryBookChallenge = 496;

		public const short RequestLegendaryBookChallengeFail = 497;

		public const short AcceptRequestLegendaryBook = 498;

		public const short RequestLegendaryBookSucceed = 499;

		public const short RequestLegendaryBookFail = 500;

		public const short RefuseRequestLegendaryBook = 501;

		public const short AcceptRequestExchangeLegendaryBook = 502;

		public const short RequestExchangeLegendaryBookSucceed = 503;

		public const short RefuseRequestExchangeLegendaryBook = 504;

		public const short RequestExchangeLegendaryBookFail = 505;

		public const short GiveLegendaryBookFail = 506;

		public const short RefuseGiveLegendaryBook = 507;

		public const short DefeatLegendaryBookInsaneJust = 508;

		public const short DefeatLegendaryBookInsaneKind = 509;

		public const short DefeatLegendaryBookInsaneEven = 510;

		public const short DefeatLegendaryBookInsaneRebel = 511;

		public const short DefeatLegendaryBookInsaneEgoistic = 512;

		public const short LegendaryBookInsaneDefeatedJust = 513;

		public const short LegendaryBookInsaneDefeatedKind = 514;

		public const short LegendaryBookInsaneDefeatedEven = 515;

		public const short LegendaryBookInsaneDefeatedRebel = 516;

		public const short LegendaryBookInsaneDefeatedEgoistic = 517;

		public const short ShockedInsaneEscaped = 518;

		public const short ReleaseShockedInsane = 519;

		public const short UnderAttackEscaped = 520;

		public const short ReleaseUnderAttack = 521;

		public const short DefeatConsumed = 522;

		public const short BeDefetedByConsumed = 523;

		public const short AcceptRequestExchangeLegendaryBookByExp = 524;

		public const short RequestExchangeLegendaryBookSucceedByExp = 525;

		public const short ResignPositionToStudyLegendaryBook = 526;

		public const short SoundOutLoverMind = 527;

		public const short SoundOutMind = 528;

		public const short RedeemMindSucceed = 529;

		public const short RedeemMindFail = 530;

		public const short AcceptRedeemMind = 531;

		public const short RefuseRedeemMind = 532;

		public const short FirstDateWithLover = 533;

		public const short FirstDateWithTaiwu = 534;

		public const short SelectLoverToken = 535;

		public const short SelectLoverToken2 = 536;

		public const short DateWithLover = 537;

		public const short DateWithLover2 = 538;

		public const short TillDeathDoUsPart = 539;

		public const short CelebrateBirthday = 540;

		public const short CelebrateSelfBirthday = 541;

		public const short CelebrateAnniversary = 542;

		public const short BeCaughtCheating = 543;

		public const short CaughtCheating = 544;

		public const short PregnancyWithWife = 545;

		public const short PregnancyWithHusband = 546;

		public const short TeaTasting = 547;

		public const short TeaTastingLifeSkillBattleWin = 548;

		public const short TeaTastingLifeSkillBattleLose = 549;

		public const short TeaTastingDisorderOfQi = 550;

		public const short WineTasting = 551;

		public const short WineTastingLifeSkillBattleWin = 552;

		public const short WineTastingLifeSkillBattleLose = 553;

		public const short WineTastingDisorderOfQi = 554;

		public const short FirstNameChanged = 555;

		public const short LifeSkillModel = 556;

		public const short CombatSkillModel = 557;

		public const short PromoteReputation = 558;

		public const short ReputationPromoted = 559;

		public const short CapabilityCultivated = 560;

		public const short BroughtToTaiwuByBeggars = 561;

		public const short DiscardRevengeForCivilianSkill = 562;

		public const short CivilianSkillDissolveResentment = 563;

		public const short PersuadeWithdrawlFromOrganization = 564;

		public const short WithdrawlFromOrganization = 565;

		public const short FreeMedicalConsultation = 566;

		public const short OfferTreasures = 567;

		public const short ReceiveOfferedTreasures = 568;

		public const short ForcefulPurchase = 569;

		public const short ForcefulSale = 570;

		public const short BegForMoney = 571;

		public const short AbsurdlyForceToLeave = 572;

		public const short AbsurdlyForcedToLeave = 573;

		public const short DiagnoseWithMedicine = 574;

		public const short DiagnosedWithMedicine = 575;

		public const short DiagnoseWithNonMedicine = 576;

		public const short DiagnosedWithWrongMedicine = 577;

		public const short ExtendLifeSpan = 578;

		public const short LifeSpanExtended = 579;

		public const short PersuadeToBecomeMonk = 580;

		public const short BecomeMonkPersuaded = 581;

		public const short FailToPersuadeToBecomeMonk = 582;

		public const short ExpiateDeadSouls = 583;

		public const short ExociseXiangshuInfectionVictoryInCombat = 584;

		public const short BecomeExociseXiangshuInfectionVictoryInCombat = 585;

		public const short ExociseXiangshuInfectionVictoryInCombatDefeated = 586;

		public const short TribulationSucceeded = 587;

		public const short TribulationFailed = 588;

		public const short TribulationCanceled = 589;

		public const short TribulationContinued = 590;

		public const short GuidingEvilToGoodSucceed = 591;

		public const short GuidingEvilGoodSucceed = 592;

		public const short GuidingEvilToGoodFail = 593;

		public const short VisitBuddhismTemples = 594;

		public const short EpiphanyThruVisitTemples = 595;

		public const short EpiphanyThruVisitTemplesCombatSkill = 596;

		public const short EpiphanyThruVisitTemplesLifeSkill = 597;

		public const short EpiphanyThruVisitTemplesExperience = 598;

		public const short DivineUnexpectedGain = 599;

		public const short DivineUnexpectedHarm = 600;

		public const short ExchangeFates = 601;

		public const short BecomeExchangeFates = 602;

		public const short ImmortalityGained = 603;

		public const short ImmortalityLost = 604;

		public const short ImmortalityRegained = 605;

		public const short TaiwuReincarnation = 606;

		public const short TaiwuReincarnationPregnancy = 607;

		public const short MixPoisonHotRedRotten = 608;

		public const short MixPoisonHotRottenIllusory = 609;

		public const short MixPoisonHotRottenGloomy = 610;

		public const short MixPoisonHotRottenCold = 611;

		public const short MixPoisonRedRottenIllusory = 612;

		public const short MixPoisonRedRottenGloomy = 613;

		public const short MixPoisonRedRottenCold = 614;

		public const short MixPoisonHotRedIllusory = 615;

		public const short MixPoisonHotRedGloomy = 616;

		public const short MixPoisonHotRedCold = 617;

		public const short MixPoisonGloomyColdIllusory = 618;

		public const short MixPoisonRottenGloomyCold = 619;

		public const short MixPoisonHotGloomyCold = 620;

		public const short MixPoisonRedGloomyCold = 621;

		public const short MixPoisonRottenColdIllusory = 622;

		public const short MixPoisonHotColdIllusory = 623;

		public const short MixPoisonRedColdIllusory = 624;

		public const short MixPoisonRottenGloomyIllusory = 625;

		public const short MixPoisonHotGloomyIllusory = 626;

		public const short MixPoisonRedGloomyIllusory = 627;

		public const short DiggingXiangshuMinionCombatLost = 628;

		public const short DiggingXiangshuMinionCombatWon = 629;

		public const short SectMainStoryXuehouJixiKills = 630;

		public const short SectMainStoryWudangTreasure = 631;

		public const short SectMainStoryXuannvJoinOrg = 632;

		public const short SectMainStoryYuanshanGetAbsorbed = 633;

		public const short SectMainStoryYuanshanResistSucceed = 634;

		public const short SectMainStoryYuanshanResistOrdinary = 635;

		public const short SectMainStoryYuanshanResistFailed = 636;

		public const short SectMainStoryXuehouZombieKills = 637;

		public const short SectMainStoryShixiangSkillEnemy = 638;

		public const short SectMainStoryWuxianMethysis0 = 639;

		public const short SectMainStoryWuxianPoison = 640;

		public const short SectMainStoryWuxianAssault = 641;

		public const short SectMainStoryWuxianMethysis1 = 642;

		public const short SectMainStoryEmeiInfighting = 643;

		public const short SectMainStoryJieqingAssassin = 644;

		public const short WulinConferencePraiseAndGifts = 645;

		public const short NormalInformationChangeIdealSectNegative = 646;

		public const short SectMainStoryXuehouJixiRescueTaiwu = 647;

		public const short SectMainStoryRanshanJoinThreeFactionCompetetion = 648;

		public const short SectMainStoryRanshanThreeFactionCompetetionWin = 649;

		public const short SectMainStoryRanshanThreeFactionCompetetionLose = 650;

		public const short GainExpByStroll = 651;

		public const short GainExpByReadingOldBook = 652;

		public const short PunishedAlongsideSpouse = 653;

		public const short DecideToAdoptFoundling = 654;

		public const short AdoptFoundlingFail = 655;

		public const short AdoptFoundlingSucceed = 656;

		public const short FoundlingGetAdopted = 657;

		public const short ClaimFoundlingSucceed = 658;

		public const short FoundlingGetClaimed = 659;

		public const short SectMainStoryWudangVillagerKilled = 660;

		public const short SectMainStoryShixiangFallIll = 661;

		public const short KillAnimal = 662;

		public const short DefeatedByAnimal = 663;

		public const short EnterEnemyNest = 664;

		public const short DieFromEnemyNest = 665;

		public const short EscapeFromEnemyNest = 666;

		public const short GetSecretSpreadInVeryHighProbability = 667;

		public const short GetSecretSpreadInHighProbability = 668;

		public const short GetSecretSpreadInLowProbability = 669;

		public const short GetSecretSpreadInVeryLowProbability = 670;

		public const short SpreadSecretFail = 671;

		public const short SpreadSecretSuccess = 672;

		public const short HeardSecretSpreadInVeryHighProbability = 673;

		public const short HeardSecretSpreadInHighProbability = 674;

		public const short HeardSecretSpreadInLowProbability = 675;

		public const short HeardSecretSpreadInVeryLowProbability = 676;

		public const short RequestKeepSecretFail = 677;

		public const short RequestKeepSecretSuccess = 678;

		public const short BeRequestedToKeepSecret = 679;

		public const short ThreadNeedleMatchFail = 680;

		public const short ThreadNeedleSeparateFail = 681;

		public const short ThreadNeedleMatchSuccess = 682;

		public const short ThreadNeedleSeparateSuccess = 683;

		public const short ThreadNeedleBeMatched1 = 684;

		public const short ThreadNeedleBeSeparated1 = 685;

		public const short ThreadNeedleBeMatched2 = 686;

		public const short ThreadNeedleBeSeparated2 = 687;

		public const short SpreadSecretKnown = 688;

		public const short SectMainStoryXuannvBirthOfMirrorCreatedImposture = 689;

		public const short EscapeFromEnemyNestBySelf = 690;

		public const short SaveFromInfection = 691;

		public const short SaveFromEnemyNest = 692;

		public const short SaveFromEnemyNestFailed = 693;

		public const short TameCarrierSucceed = 694;

		public const short TameCarrierFail = 695;

		public const short ReleaseCarrier = 696;

		public const short DLCLoongRidingEffectQiuniuAudience = 697;

		public const short DLCLoongRidingEffectQiuniu = 698;

		public const short DLCLoongRidingEffectYazi = 699;

		public const short DLCLoongRidingEffectChaofeng = 700;

		public const short DLCLoongRidingEffectPulao = 701;

		public const short DLCLoongRidingEffectSuanni = 702;

		public const short DLCLoongRidingEffectBaxia = 703;

		public const short DLCLoongRidingEffectBian = 704;

		public const short DLCLoongRidingEffectFuxi = 705;

		public const short DLCLoongRidingEffectChiwen = 706;

		public const short DefeatLoong = 707;

		public const short DefeatedByLoong = 708;

		public const short DLCLoongRidingEffectYazi2 = 709;

		public const short DieFromAge = 710;

		public const short DieFromPoorHealth = 711;

		public const short KilledInPublic = 712;

		public const short KilledInPrivate = 713;

		public const short KilledAfterXiangshuInfected = 714;

		public const short Assassinated = 715;

		public const short KilledByXiangshu = 716;

		public const short PurchaseItem1 = 717;

		public const short SellItem1 = 718;

		public const short CleanBodyReincarnationSuccess = 719;

		public const short CleanBodyReincarnationFail = 720;

		public const short EvilBodyReincarnationSuccess = 721;

		public const short EvilBodyReincarnationFail = 722;

		public const short WugKingForestSpiritBecomeEnemy = 723;

		public const short SecretMakeEnemy = 724;

		public const short SecretBeMadeEnemy = 725;

		public const short CleanBodyDefeatAnimal = 726;

		public const short EvilBodyDefeatAnimal = 727;

		public const short CleanBodyDefeatHereticRandomEnemy = 728;

		public const short EvilBodyDefeatHereticRandomEnemy = 729;

		public const short CleanBodyDefeatRighteousRandomEnemy = 730;

		public const short EvilBodyDefeatRighteousRandomEnemy = 731;

		public const short WuxianParanoiaAdded = 732;

		public const short WuxianParanoiaAttack = 733;

		public const short WuxianParanoiaErased = 734;

		public const short WugKingRedEyeLoseItem = 735;

		public const short WugForestSpiritReduceFavorability = 736;

		public const short WugKingForestSpiritBeBecomeEnemy = 737;

		public const short WugKingBlackBloodChangeDisorderOfQi = 738;

		public const short WugDevilInsideXiangshuInfection = 739;

		public const short WugCorpseWormChangeHealth = 740;

		public const short WugKingIceSilkwormLoseNeili = 741;

		public const short WugKingGoldenSilkwormEatGrownWug = 742;

		public const short WugAzureMarrowAddPoison = 743;

		public const short WugAzureMarrowAddWug = 744;

		public const short WugAzureMarrowBeAddWug = 745;

		public const short WuxianParanoiaErased2 = 746;

		public const short WuxianDecreasedMood = 747;

		public const short WuxianDecreasedFavorability = 748;

		public const short WuxianQiDecline = 749;

		public const short WuxianPoisoning = 750;

		public const short WuxianLoseItem = 751;

		public const short WugDevilInsideChangeHappiness = 752;

		public const short WugRedEyeChangeToGrown = 753;

		public const short WugForestSpiritChangeToGrown = 754;

		public const short WugBlackBloodChangeToGrown = 755;

		public const short WugDevilInsideChangeToGrown = 756;

		public const short WugCorpseWormChangeToGrown = 757;

		public const short WugCorpseWormBeChangeToGrown = 758;

		public const short WugIceSilkwormChangeToGrown = 759;

		public const short WugGoldenSilkwormChangeToGrown = 760;

		public const short WugAzureMarrowChangeToGrown = 761;

		public const short WugAzureMarrowBeChangeToGrown = 762;

		public const short ManageLearnLifeSkillSuccess = 763;

		public const short ManageLearnCombatSkillSuccess = 764;

		public const short ManageLearnLifeSkillFail = 765;

		public const short ManageLearnCombatSkillFail = 766;

		public const short ManageLifeSkillAbilityUp = 767;

		public const short ManageCombatSkillAbilityUp = 768;

		public const short SmallVillagerXiangshuCompletelyInfected = 769;

		public const short SmallVillagerSavedFromInfection = 770;

		public const short SmallVillagerSaveFromInfection = 771;

		public const short StorageResourceToTreasury = 772;

		public const short StorageItemToTreasury = 773;

		public const short TakeResourceFromTreasury = 774;

		public const short TakeItemFromTreasury = 775;

		public const short TaiwuStorageResourceToTreasury = 776;

		public const short TaiwuStorageItemToTreasury = 777;

		public const short TaiwuTakeResourceFromTreasury = 778;

		public const short TaiwuTakeItemFromTreasury = 779;

		public const short DecideToGuardTreasury = 780;

		public const short FinishGuardingTreasury = 781;

		public const short IntrudeTreasuryCancelSupportMakeEnemy = 782;

		public const short IntrudeTreasuryBeCancelSupportMakeEnemy = 783;

		public const short IntrudeTreasuryCancelSupport = 784;

		public const short IntrudeTreasuryBeCancelSupport = 785;

		public const short IntrudeTreasuryMakeEnemyOthers = 786;

		public const short IntrudeTreasuryBeMakeEnemyOthers = 787;

		public const short IntrudeTreasuryLostMorale = 788;

		public const short IntrudeTreasuryBeLostMorale = 789;

		public const short IntrudeTreasuryBeLostMorale2 = 790;

		public const short PlunderTreasuryCancelSupportMakeEnemy = 791;

		public const short PlunderTreasuryBeCancelSupportMakeEnemy = 792;

		public const short PlunderTreasuryCancelSupport = 793;

		public const short PlunderTreasuryBeCancelSupport = 794;

		public const short PlunderTreasuryMakeEnemyOthers = 795;

		public const short PlunderTreasuryBeMakeEnemyOthers = 796;

		public const short PlunderTreasuryLostMorale = 797;

		public const short PlunderTreasuryBeLostMorale = 798;

		public const short PlunderTreasuryBeLostMorale2 = 799;

		public const short DonateTreasuryProvideSupport = 800;

		public const short DonateTreasuryBeProvideSupport = 801;

		public const short DonateTreasuryGetMorale = 802;

		public const short DonateTreasuryBeGetMorale = 803;

		public const short DonateTreasuryGetMorale2 = 804;

		public const short TreasuryDistributeResource = 805;

		public const short TreasuryDistributeItem = 806;

		public const short PoisonEnemyFail12 = 807;

		public const short PoisonEnemyFail22 = 808;

		public const short PoisonEnemyFail32 = 809;

		public const short PoisonEnemyFail42 = 810;

		public const short PoisonEnemySucceed2 = 811;

		public const short PoisonEnemySucceedAndEscaped2 = 812;

		public const short GetPoisonedByEnemySucceed2 = 813;

		public const short PlotHarmEnemyFail12 = 814;

		public const short PlotHarmEnemyFail22 = 815;

		public const short PlotHarmEnemyFail32 = 816;

		public const short PlotHarmEnemyFail42 = 817;

		public const short PlotHarmEnemySucceed2 = 818;

		public const short PlotHarmEnemySucceedAndEscaped2 = 819;

		public const short GetPlottedAgainstSucceed2 = 820;

		public const short SectMainStoryBaihuaManiaLow = 821;

		public const short SectMainStoryBaihuaManiaHigh = 822;

		public const short SectMainStoryBaihuaManiaAttack = 823;

		public const short SectMainStoryBaihuaManiaAttacked = 824;

		public const short SectMainStoryBaihuaManiaCure = 825;

		public const short SectMainStoryBaihuaManiaCured = 826;

		public const short GiveUpLegendaryBookSuccessHuaJu = 827;

		public const short GiveUpLegendaryBookSuccessXuanZhi = 828;

		public const short GiveUpLegendaryBookSuccessYingJiao = 829;

		public const short SecretMakeEnemy2 = 830;

		public const short SecretBeMadeEnemy2 = 831;

		public const short DecideToHuntFugitive = 832;

		public const short FinishHuntFugitive = 833;

		public const short DecideToEscapePunishment = 834;

		public const short FinishEscapePunishment = 835;

		public const short DecideToSeekAsylum = 836;

		public const short FinishSeekAsylum = 837;

		public const short SeekAsylumSuccess = 838;

		public const short DecideToEscortPrisoner = 839;

		public const short EscortPrisonerSucceed = 840;

		public const short ImprisonedShaoLin = 841;

		public const short ImprisonedEmei1 = 842;

		public const short ImprisonedEmei2 = 843;

		public const short ImprisonedBaihua = 844;

		public const short ImprisonedWudang = 845;

		public const short ImprisonedYuanshan = 846;

		public const short ImprisonedShingXiang = 847;

		public const short ImprisonedRanShan = 848;

		public const short ImprisonedXuanNv = 849;

		public const short ImprisonedZhuJian = 850;

		public const short ImprisonedKongSang = 851;

		public const short ImprisonedJinGang = 852;

		public const short ImprisonedWuXian = 853;

		public const short ImprisonedJieQing1 = 854;

		public const short ImprisonedJieQing2 = 855;

		public const short ImprisonedFuLong = 856;

		public const short ImprisonedXueHou = 857;

		public const short IntrudePrisonCancelSupportMakeEnemyNpc = 858;

		public const short IntrudePrisonCancelSupportMakeEnemyTaiwu = 859;

		public const short IntrudePrisonCancelSupportNpc = 860;

		public const short IntrudePrisonCancelSupportTaiwu = 861;

		public const short IntrudePrisonMakeEnemyOthersNpc = 862;

		public const short IntrudePrisonMakeEnemyOthersTaiwu = 863;

		public const short RequestTheReleaseOfTheCriminalNpc = 864;

		public const short RequestTheReleaseOfTheCriminalTaiwu = 865;

		public const short ImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityNpc = 866;

		public const short ImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityTaiwu = 867;

		public const short ImprisonedXiangshuInfectedIncreaseFavorabilityNpc = 868;

		public const short ImprisonedXiangshuInfectedIncreaseFavorabilityTaiwu = 869;

		public const short ImprisonedXiangshuInfectedNpc = 870;

		public const short ImprisonedXiangshuInfectedTaiwu = 871;

		public const short RobbedFromPrisonNpc = 872;

		public const short PrisonBreakIntrudePrisonCancelSupportMakeEnemyNpc = 873;

		public const short PrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu = 874;

		public const short PrisonBreakIntrudePrisonCancelSupportNpc = 875;

		public const short PrisonBreakIntrudePrisonCancelSupportTaiwu = 876;

		public const short PrisonBreakIntrudePrisonMakeEnemyOthersNpc = 877;

		public const short PrisonBreakIntrudePrisonMakeEnemyOthersTaiwu = 878;

		public const short ResistArrestIntrudePrisonCancelSupportMakeEnemyNpc = 879;

		public const short ResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu = 880;

		public const short ResistArresPrisonBreakIntrudePrisonCancelSupportNpc = 881;

		public const short ResistArresPrisonBreakIntrudePrisonCancelSupportTaiwu = 882;

		public const short ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpc = 883;

		public const short ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwu = 884;

		public const short ArrestFailedCaptor = 885;

		public const short ArrestFailedCriminal = 886;

		public const short ResistArresEngageInBattleTaiwu = 887;

		public const short ArrestedSuccessfullyCaptor = 888;

		public const short ArrestedSuccessfullyCriminal = 889;

		public const short ReceiveCriminalsCaptor = 890;

		public const short ReceiveCriminalsTaiwu = 891;

		public const short ReceiveCriminalsCriminal = 892;

		public const short BuyHandOverTheCriminalCaptor = 893;

		public const short BuyHandOverTheCriminalTaiwu = 894;

		public const short LifeSkillBattleHandOverTheCriminalCaptor = 895;

		public const short LifeSkillBattleHandOverTheCriminalTaiwu = 896;

		public const short LifeSkillBattleLoseHandOverTheCriminalCaptor = 897;

		public const short LifeSkillBattleLoseHandOverTheCriminalTaiwu = 898;

		public const short VictoryInCombatHandOverTheCriminalCaptor = 899;

		public const short VictoryInCombatHandOverTheCriminalTaiwu = 900;

		public const short FailureInCombatHandOverTheCriminalCaptor = 901;

		public const short FailureInCombatHandOverTheCriminalTaiwu = 902;

		public const short SectMainStoryFulongFightSucceed = 903;

		public const short SectMainStoryFulongFightFail = 904;

		public const short SectMainStoryFulongRobbery = 905;

		public const short SectMainStoryFulongRobberKilledByTaiwu = 906;

		public const short SectMainStoryFulongProtect = 907;

		public const short HonestSectPunishLevel1 = 908;

		public const short HonestSectPunishLevel2 = 909;

		public const short HonestSectPunishLevel3 = 910;

		public const short HonestSectPunishLevel4 = 911;

		public const short HonestSectPunishLevel5 = 912;

		public const short HonestSectPunishTogetherWithSpouseLevel5 = 913;

		public const short ArrestedSectPunishLevel1 = 914;

		public const short ArrestedSectPunishLevel2 = 915;

		public const short ArrestedSectPunishLevel3 = 916;

		public const short ArrestedSectPunishLevel4 = 917;

		public const short ArrestedSectPunishLevel5 = 918;

		public const short ArrestedSectPunishTogetherWithSpouseLevel5 = 919;

		public const short BeImplicatedSectPunishLevel5 = 920;

		public const short BeReleasedUponCompletionOfASentence = 921;

		public const short PrisonBreak = 922;

		public const short SendingToPrison1Taiwu = 923;

		public const short SendingToPrison2Taiwu = 924;

		public const short SendingToPrisonCriminal = 925;

		public const short SentToPrisonTaiwu = 926;

		public const short SentToPrisonCriminal = 927;

		public const short CatchCriminalsWinTaiwu = 928;

		public const short CatchCriminalsWinCriminal = 929;

		public const short CatchCriminalsFailedTaiwu = 930;

		public const short CatchCriminalsFailedCriminal = 931;

		public const short BuyHandOverTheCriminalCaptorByExp = 932;

		public const short BuyHandOverTheCriminalTaiwuByExp = 933;

		public const short SendingToPrison1TaiwuByExp = 934;

		public const short VillagerMigrateResources = 935;

		public const short VillagerCookingIngredient = 936;

		public const short VillagerMakingItem = 937;

		public const short VillagerRepairItem0 = 938;

		public const short VillagerRepairItem1 = 939;

		public const short VillagerDisassembleItem0 = 940;

		public const short VillagerDisassembleItem1 = 941;

		public const short VillagerRefiningMedicine = 942;

		public const short VillagerDetoxify0 = 943;

		public const short VillagerDetoxify1 = 944;

		public const short VillagerEnvenomedItem = 945;

		public const short VillagerSoldItem = 946;

		public const short VillagerBuyItem = 947;

		public const short VillagerSeverEnemy = 948;

		public const short VillagerEmotionUp = 949;

		public const short VillagerMakeFriends = 950;

		public const short VillagerGetMarried = 951;

		public const short VillagerBecomeBrothers = 952;

		public const short VillagerAdopt = 953;

		public const short VillagerTreatment0 = 954;

		public const short VillagerTreatment1 = 955;

		public const short VillagerBeTreatment0 = 956;

		public const short VillagerBeTreatment1 = 957;

		public const short XiangshuInfectedPrisonTaiwuVillage = 958;

		public const short XiangshuInfectedPrisonSettlement = 959;

		public const short VillagerBeRepairItem1 = 960;

		public const short TaiwuVillagerTakeItem = 961;

		public const short TaiwuVillagerStorageItem = 962;

		public const short TaiwuVillagerStorageResources = 963;

		public const short TaiwuVillagerTakeResources = 964;

		public const short LiteratiEntertainingUp = 965;

		public const short LiteratiEntertainingDown = 966;

		public const short LiteratiBuildingRelationshipUp = 967;

		public const short LiteratiBuildingRelationshipDown = 968;

		public const short LiteratiSpreadingInfluenceUp = 969;

		public const short LiteratiSpreadingInfluenceDown = 970;

		public const short SwordTombKeeperBuildingRelationshipUp = 971;

		public const short SwordTombKeeperBuildingRelationshipDown = 972;

		public const short SwordTombKeeperSpreadingInfluenceUp = 973;

		public const short SwordTombKeeperSpreadingInfluenceDown = 974;

		public const short InquireSwordTomb = 975;

		public const short GuardingSwordTomb = 976;

		public const short VillagerPrioritizedActions = 977;

		public const short VillagerPrioritizedActionsStop = 978;

		public const short EnvenomedItemOverload = 979;

		public const short DetoxifyItemOverload = 980;

		public const short VillagerEnvenomedItemOverload = 981;

		public const short VillagerDetoxifyItemOverload = 982;

		public const short VillagerCookingIngredientFailed0 = 983;

		public const short VillagerCookingIngredientFailed1 = 984;

		public const short VillagerMakingItemFailed0 = 985;

		public const short VillagerMakingItemFailed1 = 986;

		public const short VillagerRepairFailed = 987;

		public const short VillagerDisassembleItemFailed = 988;

		public const short VillagerRefiningMedicineFailed0 = 989;

		public const short VillagerRefiningMedicineFailed1 = 990;

		public const short VillagerAddPoisonToItemFailed = 991;

		public const short VillagerDetoxItemFailed = 992;

		public const short VillagerDistanceFailed0 = 993;

		public const short VillagerDistanceFailed1 = 994;

		public const short VillagerDistanceFailed2 = 995;

		public const short VillagerAttainmentsFailed = 996;

		public const short TaiwuPunishmentTongyong = 997;

		public const short TaiwuPunishmentShaolin = 998;

		public const short TaiwuPunishmentEmei = 999;

		public const short TaiwuPunishmentBaihua = 1000;

		public const short TaiwuPunishmentWudang = 1001;

		public const short TaiwuPunishmentYuanshan = 1002;

		public const short TaiwuPunishmentShingXiang = 1003;

		public const short TaiwuPunishmentRanShan = 1004;

		public const short TaiwuPunishmentXuanNv = 1005;

		public const short TaiwuPunishmentZhuJian = 1006;

		public const short TaiwuPunishmentKongSang = 1007;

		public const short TaiwuPunishmentJinGang = 1008;

		public const short TaiwuPunishmentWuXian = 1009;

		public const short TaiwuPunishmentJieQing = 1010;

		public const short TaiwuPunishmentFuLong = 1011;

		public const short TaiwuPunishmentXueHou = 1012;

		public const short SectPunishLevel5Expel = 1013;

		public const short BeImplicatedSectPunishLevel5New = 1014;

		public const short BeImplicatedSectPunishLevel5Expel = 1015;

		public const short ResistArrestIntrudePrisonCancelSupportMakeEnemyNpcGuard = 1016;

		public const short ResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwuWanted = 1017;

		public const short ResistArresPrisonBreakIntrudePrisonCancelSupportNpcGuard = 1018;

		public const short ResistArresPrisonBreakIntrudePrisonCancelSupportTaiwuWanted = 1019;

		public const short ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpcGuard = 1020;

		public const short ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwuWanted = 1021;

		public const short ForgiveForCivilianSkill = 1022;

		public const short BeggarEatSomeoneFood = 1023;

		public const short SomeoneFoodEatedByBeggar = 1024;

		public const short AristocratReleasePrisoner = 1025;

		public const short PrisonerBeReleaseByAristocrat = 1026;

		public const short JieQingPunishmentAssassinSetOut = 1027;

		public const short JieQingPunishmentAssassinSucceed = 1028;

		public const short JieQingPunishmentAssassinBeSucceed = 1029;

		public const short JieQingPunishmentAssassinFailed = 1030;

		public const short JieQingPunishmentAssassinBeFailed = 1031;

		public const short JieQingPunishmentAssassinGiveUp = 1032;

		public const short ExociseXiangshuInfectionVictoryInCombatDie = 1033;

		public const short BecomeExociseXiangshuInfectionVictoryInCombatDie = 1034;

		public const short ArrestFailedTaiwu = 1035;

		public const short ArrestedSuccessfullyTaiwu = 1036;

		public const short LifeSkillBattleLoseAndTheArrestFailedCaptor = 1037;

		public const short LifeSkillBattleWinAndAvoidArrestTaiwu = 1038;

		public const short LifeSkillBattleWinAndSuccessfulArrestCaptor = 1039;

		public const short LifeSkillBattleLoseAndWasArrestedTaiwu = 1040;

		public const short FailedArrestForBriberyCaptorByAuthority = 1041;

		public const short BribeSucceededInAvoidingArrestTaiwuByAuthority = 1042;

		public const short FailedArrestForBriberyCaptorByExp = 1043;

		public const short BribeSucceededInAvoidingArrestTaiwuByExp = 1044;

		public const short FailedArrestForBriberyCaptorByMoney = 1045;

		public const short BribeSucceededInAvoidingArrestTaiwuByMoney = 1046;

		public const short SubmitToCaptureMeeklyTaiwu = 1047;

		public const short SubmitToCaptureMeeklyCaptor = 1048;

		public const short NormalInformationChangeProfession = 1049;

		public const short FeedTheAnimal = 1050;

		public const short ProfessionDoctorLifeTransition = 1051;

		public const short ProfessionDoctorLifeTransitionTaiwu = 1052;

		public const short CombatSkillKeyPointComprehensionByExp = 1053;

		public const short CombatSkillKeyPointComprehensionByItems = 1054;

		public const short CombatSkillKeyPointComprehensionByLoveRelationship = 1055;

		public const short CombatSkillKeyPointComprehensionByHatredRelationship = 1056;

		public const short SpiritualDebtKongsangPoisoned = 1057;

		public const short MartialArtistSkill3NPCItemDropCaseA = 1058;

		public const short MartialArtistSkill3NPCItemDropCaseB = 1059;

		public const short SectPunishElopeSucceedJust = 1060;

		public const short SectPunishElopeSucceedKind = 1061;

		public const short SectPunishElopeSucceedEven = 1062;

		public const short SectPunishElopeSucceed = 1063;

		public const short VillagerGetRefineItem = 1064;

		public const short VillagerUpgradeRefineItem = 1065;

		public const short VillagerTreatmentTaiwu = 1066;

		public const short VillagerReduceXiangshuInfect = 1067;

		public const short VillagerEarnMoney = 1068;

		public const short VillagerBeEarnedMoney = 1069;

		public const short VillagerBeSoldItem = 1070;

		public const short VillagerBePurchasedItem = 1071;

		public const short VillagerGetMerchantFavorability = 1072;

		public const short VillagerGetMerchantFavorabilityTaiwu = 1073;

		public const short LiteratiBeEntertainedUp = 1074;

		public const short LiteratiBeEntertainedDown = 1075;

		public const short LiteratiSpreadingInfluenceCultureUp = 1076;

		public const short LiteratiSpreadingInfluenceCultureDown = 1077;

		public const short LiteratiSpreadingInfluenceSafetyUp = 1078;

		public const short LiteratiSpreadingInfluenceSafetyDown = 1079;

		public const short LiteratiConnectRelationshipUp = 1080;

		public const short LiteratiConnectRelationshipDown = 1081;

		public const short LiteratiConnectRelationshipUpTaiwu = 1082;

		public const short LiteratiConnectRelationshipDownTaiwu = 1083;

		public const short LiteratiBeConnectedRelationshipUp = 1084;

		public const short LiteratiBeConnectedRelationshipDown = 1085;

		public const short GuardingSwordTombXiangshuInfectUp = 1086;

		public const short GuardingSwordTombSucceed = 1087;

		public const short VillagerMakeEnemy = 1088;

		public const short VillagerConfessLoveSucceed = 1089;

		public const short OrderProduct = 1090;

		public const short ReceiveProduct = 1091;

		public const short BeOrderProduct = 1092;

		public const short BeReceiveProduct = 1093;

		public const short CaptureOrder = 1094;

		public const short BeCaptureOrder = 1095;

		public const short CaptureOrderIntermediator = 1096;

		public const short OrderProductForOthers = 1097;

		public const short BeOrderProductForOthers = 1098;

		public const short DeliveredOrderProduct = 1099;

		public const short BeDeliveredOrderProduct = 1100;

		public const short AcquisitionDiscard = 1101;

		public const short ShopBuildingBaseDevelopLifeSkill = 1102;

		public const short ShopBuildingBaseDevelopCombatSkill = 1103;

		public const short ShopBuildingPersonalityDevelopLifeSkill = 1104;

		public const short ShopBuildingPersonalityDevelopCombatSkill = 1105;

		public const short ShopBuildingLeaderDevelopLifeSkill = 1106;

		public const short ShopBuildingLeaderDevelopCombatSkill = 1107;

		public const short ShopBuildingLearnLifeSkill = 1108;

		public const short ShopBuildingLearnCombatSkill = 1109;

		public const short JoinTaiwuVillageAfterTaiwuVillageStoneClaimed = 1110;

		public const short TaiwuVillagerFinishedReading = 1111;

		public const short TaiwuVillagerSalaryReceived = 1112;

		public const short ChangeGradeDrop = 1113;

		public const short FarmerCollectMaterial = 1114;

		public const short JoinOrganization = 1115;

		public const short BreakAwayOrganization = 1116;

		public const short ChangeOrganization = 1117;

		public const short VillagerFavorabilityUp = 1118;

		public const short VillagerFavorabilityDown = 1119;

		public const short VillagerFavorabilityUpPerson = 1120;

		public const short VillagerFavorabilityDownPerson = 1121;

		public const short TeamUpProtection = 1122;

		public const short TeamUpRescue = 1123;

		public const short TeamUpMourn = 1124;

		public const short TeamUpVisitFriendOrFamily = 1125;

		public const short TeamUpFindTreasure = 1126;

		public const short TeamUpFindSpecialMaterial = 1127;

		public const short TeamUpTakeRevenge = 1128;

		public const short TeamUpContestForLegendaryBook = 1129;

		public const short TeamUpEscapeFromPrison = 1130;

		public const short TeamUpSeekAsylum = 1131;

		public const short GetInfected = 1132;

		public const short DieByInfected = 1133;

		public const short InheritLegacy = 1134;

		public const short Banquet_1 = 1135;

		public const short Banquet_2 = 1136;

		public const short Banquet_3 = 1137;

		public const short Banquet_4 = 1138;

		public const short Banquet_5 = 1139;

		public const short Banquet_6 = 1140;

		public const short Banquet_7 = 1141;

		public const short Banquet_8 = 1142;

		public const short Banquet_9 = 1143;

		public const short Banquet_10 = 1144;

		public const short SectMainStoryWudangInjured = 1145;

		public const short ExtendDarkAshTime = 1146;

		public const short AdoreInMarriage = 1147;

		public const short SameAreaDistantMarriage = 1148;

		public const short SameStateDistantMarriage = 1149;

		public const short DifferentStateDistantMarriage = 1150;

		public const short GoToOuterWorlds = 1151;

		public const short BackFromOuterWorlds = 1152;

		public const short SectMainStoryXuehouJixiDrainNeili = 1153;

		public const short SectMainStoryXuehouTaiwuTransferFiveElements = 1154;

		public const short AlertnessUpBySecretInformation = 1155;

		public const short AlertnessDownBySecretInformation = 1156;

		public const short ConsummateLevelIncreased = 1157;

		public const short CombatSkillQualificationGrowthGuaranteed = 1158;

		public const short CombatSkillQualificationGrowthPersonality = 1159;

		public const short CombatSkillQualificationGrowthMentor = 1160;

		public const short LifeSkillQualificationGrowthGuaranteed = 1161;

		public const short LifeSkillQualificationGrowthPersonality = 1162;

		public const short LifeSkillQualificationGrowthMentor = 1163;

		public const short IdentityActionHelpCivilians = 1164;

		public const short IdentityActionHelpCiviliansTarget = 1205;

		public const short IdentityActionFightHeretics = 1165;

		public const short IdentityActionFightHereticsTarget = 1206;

		public const short IdentityActionShaolin0 = 1166;

		public const short IdentityActionShaolin0Target = 1207;

		public const short IdentityActionShaolin1 = 1167;

		public const short IdentityActionShaolin2 = 1168;

		public const short IdentityActionShaolin2Target = 1208;

		public const short IdentityActionShaolin3 = 1169;

		public const short IdentityActionShaolin4 = 1170;

		public const short IdentityActionShaolin4Target = 1375;

		public const short IdentityActionShaolin5 = 1171;

		public const short IdentityActionShaolin5Target = 1376;

		public const short IdentityActionShaolin6 = 1172;

		public const short IdentityActionEmei0 = 1173;

		public const short IdentityActionEmei0Target = 1380;

		public const short IdentityActionEmei1 = 1174;

		public const short IdentityActionEmei4 = 1175;

		public const short IdentityActionEmei4Target = 1209;

		public const short IdentityActionEmei5 = 1176;

		public const short IdentityActionEmei6 = 1177;

		public const short IdentityActionEmei6Target = 1210;

		public const short IdentityActionBaihua0 = 1178;

		public const short IdentityActionBaihua0Target = 1211;

		public const short IdentityActionBaihua1 = 1179;

		public const short IdentityActionBaihua2 = 1180;

		public const short IdentityActionBaihua3 = 1181;

		public const short IdentityActionBaihua3Target = 1212;

		public const short IdentityActionBaihua5 = 1183;

		public const short IdentityActionBaihua5Target = 1213;

		public const short IdentityActionWudang5 = 1188;

		public const short IdentityActionYuanshan1 = 1191;

		public const short IdentityActionYuanshan1Target = 1218;

		public const short IdentityActionYuanshan3 = 1193;

		public const short IdentityActionYuanshan3Target = 1219;

		public const short IdentityActionYuanshan6 = 1195;

		public const short IdentityActionYuanshan6Target = 1384;

		public const short IdentityActionShixiang0 = 1196;

		public const short IdentityActionShixiang1 = 1197;

		public const short IdentityActionShixiang2 = 1198;

		public const short IdentityActionShixiang3 = 1199;

		public const short IdentityActionShixiang4 = 1200;

		public const short IdentityActionShixiang5 = 1201;

		public const short IdentityActionShixiang5Target = 1221;

		public const short IdentityActionShixiang6 = 1202;

		public const short IdentityActionShixiang6Target = 1222;

		public const short IdentityActionShixiang7 = 1203;

		public const short IdentityActionShixiang7Target = 1223;

		public const short IdentityActionShixiang8 = 1204;

		public const short IdentityActionShixiang8Target = 1224;

		public const short IdentityActionRanShan1 = 1225;

		public const short IdentityActionRanShan1Target = 1226;

		public const short IdentityActionRanShan2 = 1227;

		public const short IdentityActionRanShan2Target = 1228;

		public const short IdentityActionRanShan3 = 1229;

		public const short IdentityActionRanShan4 = 1230;

		public const short IdentityActionRanShan5 = 1231;

		public const short IdentityActionRanShan6 = 1232;

		public const short IdentityActionRanShan7 = 1233;

		public const short IdentityActionRanShan7Target = 1234;

		public const short IdentityActionRanShan8 = 1235;

		public const short IdentityActionRanShan8Target = 1236;

		public const short IdentityActionXuanNv1 = 1237;

		public const short IdentityActionXuanNv1Target = 1238;

		public const short IdentityActionXuanNv2 = 1239;

		public const short IdentityActionXuanNv2Target = 1388;

		public const short IdentityActionXuanNv3 = 1240;

		public const short IdentityActionXuanNv3Audience = 1389;

		public const short IdentityActionXuanNv4 = 1241;

		public const short IdentityActionXuanNv4Target = 1242;

		public const short IdentityActionXuanNv5 = 1243;

		public const short IdentityActionXuanNv5Target = 1244;

		public const short IdentityActionXuanNv6 = 1245;

		public const short IdentityActionXuanNv7 = 1246;

		public const short IdentityActionZhuJian1 = 1247;

		public const short IdentityActionZhuJian1Target = 1248;

		public const short IdentityActionZhuJian2 = 1249;

		public const short IdentityActionZhuJian3 = 1250;

		public const short IdentityActionZhuJian4 = 1251;

		public const short IdentityActionZhuJian5 = 1252;

		public const short IdentityActionZhuJian8 = 1377;

		public const short IdentityActionKongSang1 = 1256;

		public const short IdentityActionKongSang1Target = 1257;

		public const short IdentityActionKongSang2 = 1258;

		public const short IdentityActionKongSang3 = 1259;

		public const short IdentityActionKongSang4A = 1260;

		public const short IdentityActionKongSang4B = 1261;

		public const short IdentityActionKongSang5A = 1262;

		public const short IdentityActionKongSang5B = 1263;

		public const short IdentityActionKongSang6 = 1264;

		public const short IdentityActionKongSang6Target = 1265;

		public const short IdentityActionKongSang7 = 1266;

		public const short IdentityActionKongSang7Target = 1267;

		public const short IdentityActionKongSang8A = 1268;

		public const short IdentityActionKongSang8ATarget = 1390;

		public const short IdentityActionKongSang8B = 1269;

		public const short IdentityActionKongSang9A = 1270;

		public const short IdentityActionKongSang9ATarget = 1391;

		public const short IdentityActionKongSang9B = 1271;

		public const short IdentityActionKongSang10 = 1272;

		public const short IdentityActionKongSang10Target = 1273;

		public const short IdentityActionJingGangZong2Steal = 1277;

		public const short IdentityActionJingGangZong2Rob = 1278;

		public const short IdentityActionJingGangZong2Scam = 1279;

		public const short IdentityActionJingGangZong3 = 1280;

		public const short IdentityActionJingGangZong4 = 1281;

		public const short IdentityActionJingGangZong4Target = 1282;

		public const short IdentityActionJingGangZong5 = 1283;

		public const short IdentityActionJingGangZong5Target = 1284;

		public const short IdentityActionJingGangZong6 = 1285;

		public const short IdentityActionJingGangZong6Target = 1286;

		public const short IdentityActionJingGangZong7 = 1287;

		public const short IdentityActionWuXian1 = 1288;

		public const short IdentityActionWuXian2 = 1289;

		public const short IdentityActionWuXian2Target = 1290;

		public const short IdentityActionWuXian3 = 1291;

		public const short IdentityActionWuXian3Target = 1292;

		public const short IdentityActionWuXian4 = 1293;

		public const short IdentityActionWuXian4Target = 1378;

		public const short IdentityActionWuXian5 = 1294;

		public const short IdentityActionWuXian6 = 1295;

		public const short IdentityActionJieQing1A = 1296;

		public const short IdentityActionJieQing1B = 1297;

		public const short IdentityActionJieQing2 = 1298;

		public const short IdentityActionJieQing2Target = 1392;

		public const short IdentityActionJieQing3 = 1299;

		public const short IdentityActionJieQing4 = 1300;

		public const short IdentityActionJieQing5 = 1301;

		public const short IdentityActionJieQing6A = 1302;

		public const short IdentityActionJieQing6B = 1303;

		public const short IdentityActionJieQing7 = 1304;

		public const short IdentityActionJieQing7Target = 1381;

		public const short IdentityActionJieQing8 = 1305;

		public const short IdentityActionFuLong2 = 1308;

		public const short IdentityActionFuLong6 = 1314;

		public const short IdentityActionXveHou2StealA = 1317;

		public const short IdentityActionXveHou2StealB = 1318;

		public const short IdentityActionXveHou3RobA = 1319;

		public const short IdentityActionXveHou3RobB = 1320;

		public const short IdentityActionXveHou4ScamA = 1321;

		public const short IdentityActionXveHou4ScamB = 1322;

		public const short IdentityActionXveHou5 = 1323;

		public const short IdentityActionXveHou6 = 1324;

		public const short IdentityActionXveHou7 = 1325;

		public const short IdentityActionXveHou7Target = 1326;

		public const short IdentityActionChengZhen1 = 1330;

		public const short IdentityActionChengZhen1TargetA = 1331;

		public const short IdentityActionChengZhen1TargetB = 1332;

		public const short IdentityActionChengZhen2 = 1333;

		public const short IdentityActionChengZhen2TargetA = 1334;

		public const short IdentityActionChengZhen2TargetB = 1335;

		public const short IdentityActionChengZhen3 = 1336;

		public const short IdentityActionChengZhen4 = 1337;

		public const short IdentityActionChengZhen5 = 1338;

		public const short IdentityActionChengZhen6 = 1339;

		public const short IdentityActionChengZhen6Target = 1340;

		public const short IdentityActionChengZhen7 = 1341;

		public const short IdentityActionChengZhen7Target = 1342;

		public const short IdentityActionChengZhen8 = 1343;

		public const short IdentityActionChengZhen8Target = 1344;

		public const short IdentityActionChengZhen9 = 1345;

		public const short IdentityActionChengZhen9Target = 1346;

		public const short IdentityActionChengZhen10 = 1347;

		public const short IdentityActionChengZhen10TargetA = 1348;

		public const short IdentityActionChengZhen10TargetB = 1349;

		public const short IdentityActionChengZhen11 = 1350;

		public const short IdentityActionChengZhen12 = 1351;

		public const short IdentityActionChengZhen13 = 1352;

		public const short IdentityActionChengZhen13Target = 1353;

		public const short IdentityActionChengZhen14 = 1354;

		public const short IdentityActionChengZhen15 = 1355;

		public const short IdentityActionChengZhen16 = 1356;

		public const short IdentityActionChengZhen16Target = 1357;

		public const short IdentityActionChengZhen17 = 1358;

		public const short IdentityActionChengZhen18 = 1359;

		public const short IdentityActionChengZhen19 = 1360;

		public const short IdentityActionChengZhen20 = 1361;

		public const short IdentityActionChengZhen21 = 1362;

		public const short IdentityActionChengZhen22 = 1363;

		public const short BehaviorTypeAction1 = 1364;

		public const short BehaviorTypeAction1Target = 1402;

		public const short BehaviorTypeAction2 = 1365;

		public const short BehaviorTypeAction2Target = 1403;

		public const short BehaviorTypeAction3 = 1366;

		public const short BehaviorTypeAction4 = 1367;

		public const short BehaviorTypeAction5 = 1368;

		public const short BehaviorTypeAction6 = 1369;

		public const short CherryPickResource = 1370;

		public const short IdentityActionCaptureCricket1 = 1373;

		public const short DLCLoongRidingEffectBaxia02 = 1374;

		public const short WeiQiBadOther = 1386;

		public const short WeiQiGoodOther = 1387;

		public const short TwelveImmortalsEffectAdored = 1393;

		public const short TwelveImmortalsEffectEnemy = 1394;

		public const short TwelveImmortalsEffectSuxia = 1395;

		public const short TwelveImmortalsEffectBecomeMoTian = 1396;

		public const short TwelveImmortalsEffectBeAttackByMoTian = 1397;

		public const short TwelveImmortalsEffectBeAttackByJiao = 1398;

		public const short TwelveImmortalsEffectBeAttackByMirror = 1399;

		public const short TwelveImmortalsEffectBeAttackBySkeletonDemon = 1400;

		public const short DemonHeirRevenge = 1404;

		public const short DefeatDemonHeir = 1405;

		public const short BeDefetedByDemonHeir = 1406;

		public const short DemonHeirDefeatTaiwu = 1407;

		public const short DemonHeirRebirth1 = 1408;

		public const short DemonHeirRebirth2 = 1409;

		public const short DLCCricketTurnToCricketForm = 1410;

		public const short DLCCricketRetranmogrifyToHuman = 1411;

		public const short DecideToParticipateNewAdventure = 1412;

		public const short LeaveNewAdventure = 1413;

		public const short DLCChickenRetranmogrifyToHuman = 1415;

		public const short DLCChickenTurnToChickenForm = 1416;

		public const short DLCLoongRetranmogrifyToHuman = 1417;

		public const short DLCLoongTurnToLoongForm = 1418;

		public const short XiangshuSkill0NPCEvilCase = 1419;

		public const short XiangshuSkill0TaiwuEvilCase = 1420;

		public const short XiangshuSkill1NPCEvilCorruption = 1421;

		public const short XiangshuSkill1TaiwuEvilCorruption = 1422;

		public const short XiangshuSkill0NPCItemDropCase = 1423;

		public const short XiangshuSkill2TaiwuItemDropCase = 1424;

		public const short RequestHealInjurySucceedByRes = 1425;

		public const short RequestDetoxPoisonSucceedByRes = 1426;

		public const short RequestHealthSucceedByRes = 1427;

		public const short RequestHealDisorderOfQiSucceedByRes = 1428;

		public const short RequestHealInjuryFailByRes = 1429;

		public const short RequestDetoxPoisonFailByRes = 1430;

		public const short RequestHealthFailByRes = 1431;

		public const short RequestHealDisorderOfQiFailByRes = 1432;

		public const short AcceptRequestHealInjuryByRes = 1433;

		public const short AcceptRequestDetoxPoisonByRes = 1434;

		public const short AcceptRequestHealthByRes = 1435;

		public const short AcceptRequestHealDisorderOfQiByRes = 1436;

		public const short RefuseRequestHealInjuryByRes = 1437;

		public const short RefuseRequestDetoxPoisonByRes = 1438;

		public const short RefuseRequestHealthByRes = 1439;

		public const short RefuseRequestHealDisorderOfQiByRes = 1440;
	}

	public static class DefValue
	{
		public static LifeRecordItem Die => Instance[(short)0];

		public static LifeRecordItem XiangshuPartiallyInfected => Instance[(short)1];

		public static LifeRecordItem XiangshuCompletelyInfected => Instance[(short)2];

		public static LifeRecordItem MotherLoseFetus => Instance[(short)3];

		public static LifeRecordItem FatherLoseFetus => Instance[(short)4];

		public static LifeRecordItem AbandonChild => Instance[(short)5];

		public static LifeRecordItem ChildGetAbandoned => Instance[(short)6];

		public static LifeRecordItem GiveBirthToCricket => Instance[(short)7];

		public static LifeRecordItem GiveBirthToBoy => Instance[(short)8];

		public static LifeRecordItem GiveBirthToGirl => Instance[(short)9];

		public static LifeRecordItem BecomeFatherToNewBornBoy => Instance[(short)10];

		public static LifeRecordItem BecomeFatherToNewBornGirl => Instance[(short)11];

		public static LifeRecordItem BuildGrave => Instance[(short)12];

		public static LifeRecordItem MonkBreakRule => Instance[(short)13];

		public static LifeRecordItem KidnappedCharacterEscaped => Instance[(short)14];

		public static LifeRecordItem EscapeFromKidnapping => Instance[(short)15];

		public static LifeRecordItem ReadBookSucceed => Instance[(short)16];

		public static LifeRecordItem ReadBookFail => Instance[(short)17];

		public static LifeRecordItem BreakoutSucceed => Instance[(short)18];

		public static LifeRecordItem BreakoutFail => Instance[(short)19];

		public static LifeRecordItem LearnCombatSkill => Instance[(short)20];

		public static LifeRecordItem LearnLifeSkill => Instance[(short)21];

		public static LifeRecordItem RepairItem => Instance[(short)22];

		public static LifeRecordItem AddPoisonToItem => Instance[(short)23];

		public static LifeRecordItem LoseOverloadingResource => Instance[(short)24];

		public static LifeRecordItem LoseOverloadingItem => Instance[(short)25];

		public static LifeRecordItem MakeEnemy => Instance[(short)26];

		public static LifeRecordItem SeverEnemy => Instance[(short)27];

		public static LifeRecordItem BeMadeEnemy => Instance[(short)28];

		public static LifeRecordItem SeveredEnemy => Instance[(short)29];

		public static LifeRecordItem Adore => Instance[(short)30];

		public static LifeRecordItem LoveAtFirstSight => Instance[(short)31];

		public static LifeRecordItem ConfessLoveSucceed => Instance[(short)32];

		public static LifeRecordItem ConfessLoveFail => Instance[(short)33];

		public static LifeRecordItem AcceptConfessLove => Instance[(short)34];

		public static LifeRecordItem RefuseConfessLove => Instance[(short)35];

		public static LifeRecordItem BreakupMutually => Instance[(short)36];

		public static LifeRecordItem DumpLover => Instance[(short)37];

		public static LifeRecordItem GetDumppedByLover => Instance[(short)38];

		public static LifeRecordItem ProposeMarriageSucceed => Instance[(short)39];

		public static LifeRecordItem ProposeMarriageFail => Instance[(short)40];

		public static LifeRecordItem RefuseMarriageProposal => Instance[(short)41];

		public static LifeRecordItem BecomeFriend => Instance[(short)42];

		public static LifeRecordItem SeverFriendship => Instance[(short)43];

		public static LifeRecordItem BecomeSwornBrotherOrSister => Instance[(short)44];

		public static LifeRecordItem SeverSwornBrotherhood => Instance[(short)45];

		public static LifeRecordItem GetAdoptedByFather => Instance[(short)46];

		public static LifeRecordItem GetAdoptedByMother => Instance[(short)47];

		public static LifeRecordItem AdoptSon => Instance[(short)48];

		public static LifeRecordItem AdoptDaughter => Instance[(short)49];

		public static LifeRecordItem CreateFaction => Instance[(short)50];

		public static LifeRecordItem JoinFaction => Instance[(short)51];

		public static LifeRecordItem LeaveFaction => Instance[(short)52];

		public static LifeRecordItem FactionRecruitSucceed => Instance[(short)53];

		public static LifeRecordItem FactionRecruitFail => Instance[(short)54];

		public static LifeRecordItem AgreeToJoinFaction => Instance[(short)55];

		public static LifeRecordItem RefuseToJoinFaction => Instance[(short)56];

		public static LifeRecordItem DecideToJoinSect => Instance[(short)57];

		public static LifeRecordItem DecideToFullfillAppointment => Instance[(short)58];

		public static LifeRecordItem DecideToProtect => Instance[(short)59];

		public static LifeRecordItem DecideToRescue => Instance[(short)60];

		public static LifeRecordItem DecideToMourn => Instance[(short)61];

		public static LifeRecordItem DecideToVisit => Instance[(short)62];

		public static LifeRecordItem DecideToFindLostItem => Instance[(short)63];

		public static LifeRecordItem DecideToFindSpecialMaterial => Instance[(short)64];

		public static LifeRecordItem DecideToRevenge => Instance[(short)65];

		public static LifeRecordItem DecideToParticipateAdventure => Instance[(short)66];

		public static LifeRecordItem JoinSectFail => Instance[(short)67];

		public static LifeRecordItem JoinSectSucceed => Instance[(short)68];

		public static LifeRecordItem CanNoLongerFullFillAppointment => Instance[(short)69];

		public static LifeRecordItem WaitForAppointment => Instance[(short)70];

		public static LifeRecordItem FullFillAppointment => Instance[(short)71];

		public static LifeRecordItem FinishProtection => Instance[(short)72];

		public static LifeRecordItem OfferProtection => Instance[(short)73];

		public static LifeRecordItem FinishRescue => Instance[(short)74];

		public static LifeRecordItem FinishMourning => Instance[(short)75];

		public static LifeRecordItem MaintainGrave => Instance[(short)76];

		public static LifeRecordItem UpgradeGrave => Instance[(short)77];

		public static LifeRecordItem FinishVisit => Instance[(short)78];

		public static LifeRecordItem FinishFIndingLostItem => Instance[(short)79];

		public static LifeRecordItem FinishFIndingSpecialMaterial => Instance[(short)80];

		public static LifeRecordItem FindLostItemSucceed => Instance[(short)81];

		public static LifeRecordItem FindLostItemFail => Instance[(short)82];

		public static LifeRecordItem FindSpecialMaterialSucceed => Instance[(short)83];

		public static LifeRecordItem FinishTakingRevenge => Instance[(short)84];

		public static LifeRecordItem MajorVictoryInCombat => Instance[(short)85];

		public static LifeRecordItem MajorFailureInCombat => Instance[(short)86];

		public static LifeRecordItem VictoryInCombat => Instance[(short)87];

		public static LifeRecordItem FailureInCombat => Instance[(short)88];

		public static LifeRecordItem EnemyEscape => Instance[(short)89];

		public static LifeRecordItem LoseAndEscape => Instance[(short)90];

		public static LifeRecordItem KillInPublic => Instance[(short)91];

		public static LifeRecordItem KillInPrivate => Instance[(short)92];

		public static LifeRecordItem KidnapInPublic => Instance[(short)93];

		public static LifeRecordItem KidnapInPrivate => Instance[(short)94];

		public static LifeRecordItem ReleaseLoser => Instance[(short)95];

		public static LifeRecordItem GetKidnappedInPublic => Instance[(short)96];

		public static LifeRecordItem GetKidnappedInPrivate => Instance[(short)97];

		public static LifeRecordItem GetReleasedByWinner => Instance[(short)98];

		public static LifeRecordItem AgreeToProtect => Instance[(short)99];

		public static LifeRecordItem RefuseToProtect => Instance[(short)100];

		public static LifeRecordItem FinishAdventure => Instance[(short)101];

		public static LifeRecordItem RequestHealOuterInjuryItemSucceed => Instance[(short)102];

		public static LifeRecordItem RequestHealInnerInjuryItemSucceed => Instance[(short)103];

		public static LifeRecordItem RequestDetoxPoisonItemSucceed => Instance[(short)104];

		public static LifeRecordItem RequestHealthItemSucceed => Instance[(short)105];

		public static LifeRecordItem RequestHealDisorderOfQiItemSucceed => Instance[(short)106];

		public static LifeRecordItem RequestNeiliSucceed => Instance[(short)107];

		public static LifeRecordItem RequestKillWugSucceed => Instance[(short)108];

		public static LifeRecordItem RequestFoodSucceed => Instance[(short)109];

		public static LifeRecordItem RequestTeaWineSucceed => Instance[(short)110];

		public static LifeRecordItem RequestResourceSucceed => Instance[(short)111];

		public static LifeRecordItem RequestItemSucceed => Instance[(short)112];

		public static LifeRecordItem RequestRepairItemSucceed => Instance[(short)113];

		public static LifeRecordItem RequestAddPoisonToItemSucceed => Instance[(short)114];

		public static LifeRecordItem RequestInstructionOnLifeSkillSucceed => Instance[(short)115];

		public static LifeRecordItem RequestInstructionOnCombatSkillSucceed => Instance[(short)116];

		public static LifeRecordItem RequestInstructionOnLifeSkillFailToLearn => Instance[(short)117];

		public static LifeRecordItem RequestInstructionOnCombatSkillFailToLearn => Instance[(short)118];

		public static LifeRecordItem RequestInstructionOnReadingSucceed => Instance[(short)119];

		public static LifeRecordItem RequestInstructionOnBreakoutSucceed => Instance[(short)120];

		public static LifeRecordItem RequestHealOuterInjuryItemFail => Instance[(short)121];

		public static LifeRecordItem RequestHealInnerInjuryItemFail => Instance[(short)122];

		public static LifeRecordItem RequestDetoxPoisonItemFail => Instance[(short)123];

		public static LifeRecordItem RequestHealthItemFail => Instance[(short)124];

		public static LifeRecordItem RequestHealDisorderOfQiItemFail => Instance[(short)125];

		public static LifeRecordItem RequestNeiliFail => Instance[(short)126];

		public static LifeRecordItem RequestKillWugFail => Instance[(short)127];

		public static LifeRecordItem RequestFoodFail => Instance[(short)128];

		public static LifeRecordItem RequestTeaWineFail => Instance[(short)129];

		public static LifeRecordItem RequestResourceFail => Instance[(short)130];

		public static LifeRecordItem RequestItemFail => Instance[(short)131];

		public static LifeRecordItem RequestRepairItemFail => Instance[(short)132];

		public static LifeRecordItem RequestAddPoisonToItemFail => Instance[(short)133];

		public static LifeRecordItem RequestInstructionOnLifeSkillFail => Instance[(short)134];

		public static LifeRecordItem RequestInstructionOnCombatSkillFail => Instance[(short)135];

		public static LifeRecordItem RequestInstructionOnReadingFail => Instance[(short)136];

		public static LifeRecordItem RequestInstructionOnBreakoutFail => Instance[(short)137];

		public static LifeRecordItem AcceptRequestHealOuterInjuryItem => Instance[(short)138];

		public static LifeRecordItem AcceptRequestHealInnerInjuryItem => Instance[(short)139];

		public static LifeRecordItem AcceptRequestDetoxPoisonItem => Instance[(short)140];

		public static LifeRecordItem AcceptRequestHealthItem => Instance[(short)141];

		public static LifeRecordItem AcceptRequestHealDisorderOfQiItem => Instance[(short)142];

		public static LifeRecordItem AcceptRequestNeili => Instance[(short)143];

		public static LifeRecordItem AcceptRequestKillWug => Instance[(short)144];

		public static LifeRecordItem AcceptRequestFood => Instance[(short)145];

		public static LifeRecordItem AcceptRequestTeaWine => Instance[(short)146];

		public static LifeRecordItem AcceptRequestResource => Instance[(short)147];

		public static LifeRecordItem AcceptRequestItem => Instance[(short)148];

		public static LifeRecordItem AcceptRequestRepairItem => Instance[(short)149];

		public static LifeRecordItem AcceptRequestAddPoisonToItem => Instance[(short)150];

		public static LifeRecordItem AcceptRequestInstructionOnLifeSkill => Instance[(short)151];

		public static LifeRecordItem AcceptRequestInstructionOnCombatSkill => Instance[(short)152];

		public static LifeRecordItem AcceptRequestInstructionOnLifeSkillButFail => Instance[(short)153];

		public static LifeRecordItem AcceptRequestInstructionOnCombatSkillButFail => Instance[(short)154];

		public static LifeRecordItem AcceptRequestInstructionOnReading => Instance[(short)155];

		public static LifeRecordItem AcceptRequestInstructionOnBreakout => Instance[(short)156];

		public static LifeRecordItem RefuseRequestHealOuterInjuryItem => Instance[(short)157];

		public static LifeRecordItem RefuseRequestHealInnerInjuryItem => Instance[(short)158];

		public static LifeRecordItem RefuseRequestDetoxPoisonItem => Instance[(short)159];

		public static LifeRecordItem RefuseRequestHealthItem => Instance[(short)160];

		public static LifeRecordItem RefuseRequestHealDisorderOfQiItem => Instance[(short)161];

		public static LifeRecordItem RefuseRequestNeili => Instance[(short)162];

		public static LifeRecordItem RefuseRequestKillWug => Instance[(short)163];

		public static LifeRecordItem RefuseRequestFood => Instance[(short)164];

		public static LifeRecordItem RefuseRequestTeaWine => Instance[(short)165];

		public static LifeRecordItem RefuseRequestResource => Instance[(short)166];

		public static LifeRecordItem RefuseRequestItem => Instance[(short)167];

		public static LifeRecordItem RefuseRequestRepairItem => Instance[(short)168];

		public static LifeRecordItem RefuseRequestAddPoisonToItem => Instance[(short)169];

		public static LifeRecordItem RefuseRequestInstructionOnLifeSkill => Instance[(short)170];

		public static LifeRecordItem RefuseRequestInstructionOnCombatSkill => Instance[(short)171];

		public static LifeRecordItem RefuseRequestInstructionOnReading => Instance[(short)172];

		public static LifeRecordItem RefuseRequestInstructionOnBreakout => Instance[(short)173];

		public static LifeRecordItem RescueKidnappedCharacterSecretlyFail1 => Instance[(short)174];

		public static LifeRecordItem RescueKidnappedCharacterSecretlyFail2 => Instance[(short)175];

		public static LifeRecordItem RescueKidnappedCharacterSecretlyFail3 => Instance[(short)176];

		public static LifeRecordItem RescueKidnappedCharacterSecretlyFail4 => Instance[(short)177];

		public static LifeRecordItem RescueKidnappedCharacterSecretlySucceed => Instance[(short)178];

		public static LifeRecordItem RescueKidnappedCharacterSecretlySucceedAndEscaped => Instance[(short)179];

		public static LifeRecordItem KidnappedCharacterGetRescuedSecretly => Instance[(short)180];

		public static LifeRecordItem RescueKidnappedCharacterWithWitFail1 => Instance[(short)181];

		public static LifeRecordItem RescueKidnappedCharacterWithWitFail2 => Instance[(short)182];

		public static LifeRecordItem RescueKidnappedCharacterWithWitFail3 => Instance[(short)183];

		public static LifeRecordItem RescueKidnappedCharacterWithWitFail4 => Instance[(short)184];

		public static LifeRecordItem RescueKidnappedCharacterWithWitSucceed => Instance[(short)185];

		public static LifeRecordItem RescueKidnappedCharacterWithWitSucceedAndEscaped => Instance[(short)186];

		public static LifeRecordItem KidnappedCharacterGetRescuedWithWit => Instance[(short)187];

		public static LifeRecordItem RescueKidnappedCharacterWithForceFail1 => Instance[(short)188];

		public static LifeRecordItem RescueKidnappedCharacterWithForceFail2 => Instance[(short)189];

		public static LifeRecordItem RescueKidnappedCharacterWithForceFail3 => Instance[(short)190];

		public static LifeRecordItem RescueKidnappedCharacterWithForceFail4 => Instance[(short)191];

		public static LifeRecordItem RescueKidnappedCharacterWithForceSucceed => Instance[(short)192];

		public static LifeRecordItem RescueKidnappedCharacterWithForceSucceedAndEscaped => Instance[(short)193];

		public static LifeRecordItem KidnappedCharacterGetRescuedWithForce => Instance[(short)194];

		public static LifeRecordItem PoisonEnemyFail1 => Instance[(short)195];

		public static LifeRecordItem PoisonEnemyFail2 => Instance[(short)196];

		public static LifeRecordItem PoisonEnemyFail3 => Instance[(short)197];

		public static LifeRecordItem PoisonEnemyFail4 => Instance[(short)198];

		public static LifeRecordItem PoisonEnemySucceed => Instance[(short)199];

		public static LifeRecordItem PoisonEnemySucceedAndEscaped => Instance[(short)200];

		public static LifeRecordItem GetPoisonedByEnemySucceed => Instance[(short)201];

		public static LifeRecordItem PlotHarmEnemyFail1 => Instance[(short)202];

		public static LifeRecordItem PlotHarmEnemyFail2 => Instance[(short)203];

		public static LifeRecordItem PlotHarmEnemyFail3 => Instance[(short)204];

		public static LifeRecordItem PlotHarmEnemyFail4 => Instance[(short)205];

		public static LifeRecordItem PlotHarmEnemySucceed => Instance[(short)206];

		public static LifeRecordItem PlotHarmEnemySucceedAndEscaped => Instance[(short)207];

		public static LifeRecordItem GetPlottedAgainstSucceed => Instance[(short)208];

		public static LifeRecordItem StealResourceFail1 => Instance[(short)209];

		public static LifeRecordItem StealResourceFail2 => Instance[(short)210];

		public static LifeRecordItem StealResourceFail3 => Instance[(short)211];

		public static LifeRecordItem StealResourceFail4 => Instance[(short)212];

		public static LifeRecordItem StealResourceSucceed => Instance[(short)213];

		public static LifeRecordItem StealResourceSucceedAndEscaped => Instance[(short)214];

		public static LifeRecordItem StealResourceFailAndBeatenUp => Instance[(short)215];

		public static LifeRecordItem ResourceGetStolenSucceed => Instance[(short)216];

		public static LifeRecordItem BeatUpResourceStealer => Instance[(short)217];

		public static LifeRecordItem ScamResourceFail1 => Instance[(short)218];

		public static LifeRecordItem ScamResourceFail2 => Instance[(short)219];

		public static LifeRecordItem ScamResourceFail3 => Instance[(short)220];

		public static LifeRecordItem ScamResourceFail4 => Instance[(short)221];

		public static LifeRecordItem ScamResourceSucceed => Instance[(short)222];

		public static LifeRecordItem ScamResourceSucceedAndEscaped => Instance[(short)223];

		public static LifeRecordItem ScamResourceFailAndBeatenUp => Instance[(short)224];

		public static LifeRecordItem ResourceGetScammedSucceed => Instance[(short)225];

		public static LifeRecordItem BeatUpResourceScammer => Instance[(short)226];

		public static LifeRecordItem RobResourceFail1 => Instance[(short)227];

		public static LifeRecordItem RobResourceFail2 => Instance[(short)228];

		public static LifeRecordItem RobResourceFail3 => Instance[(short)229];

		public static LifeRecordItem RobResourceFail4 => Instance[(short)230];

		public static LifeRecordItem RobResourceSucceed => Instance[(short)231];

		public static LifeRecordItem RobResourceSucceedAndEscaped => Instance[(short)232];

		public static LifeRecordItem RobResourceFailAndBeatenUp => Instance[(short)233];

		public static LifeRecordItem ResourceGetRobbedSucceed => Instance[(short)234];

		public static LifeRecordItem BeatUpResourceRobber => Instance[(short)235];

		public static LifeRecordItem StealItemFail1 => Instance[(short)236];

		public static LifeRecordItem StealItemFail2 => Instance[(short)237];

		public static LifeRecordItem StealItemFail3 => Instance[(short)238];

		public static LifeRecordItem StealItemFail4 => Instance[(short)239];

		public static LifeRecordItem StealItemSucceed => Instance[(short)240];

		public static LifeRecordItem StealItemSucceedAndEscaped => Instance[(short)241];

		public static LifeRecordItem StealItemSucceedAndBeatenUp => Instance[(short)242];

		public static LifeRecordItem ItemGetStolenSucceed => Instance[(short)243];

		public static LifeRecordItem BeatUpItemStealer => Instance[(short)244];

		public static LifeRecordItem ScamItemFail1 => Instance[(short)245];

		public static LifeRecordItem ScamItemFail2 => Instance[(short)246];

		public static LifeRecordItem ScamItemFail3 => Instance[(short)247];

		public static LifeRecordItem ScamItemFail4 => Instance[(short)248];

		public static LifeRecordItem ScamItemSucceed => Instance[(short)249];

		public static LifeRecordItem ScamItemSucceedAndEscaped => Instance[(short)250];

		public static LifeRecordItem ScamItemFailAndBeatenUp => Instance[(short)251];

		public static LifeRecordItem ItemGetScammedSucceed => Instance[(short)252];

		public static LifeRecordItem BeatUpItemScammer => Instance[(short)253];

		public static LifeRecordItem RobItemFail1 => Instance[(short)254];

		public static LifeRecordItem RobItemFail2 => Instance[(short)255];

		public static LifeRecordItem RobItemFail3 => Instance[(short)256];

		public static LifeRecordItem RobItemFail4 => Instance[(short)257];

		public static LifeRecordItem RobItemSucceed => Instance[(short)258];

		public static LifeRecordItem RobItemSucceedAndEscaped => Instance[(short)259];

		public static LifeRecordItem RobItemFailAndBeatenUp => Instance[(short)260];

		public static LifeRecordItem ItemGetRobbedSucceed => Instance[(short)261];

		public static LifeRecordItem BeatUpItemRobber => Instance[(short)262];

		public static LifeRecordItem RobResourceFromGraveSucceed => Instance[(short)263];

		public static LifeRecordItem RobResourceFromGraveFail => Instance[(short)264];

		public static LifeRecordItem RobItemFromGraveSucceed => Instance[(short)265];

		public static LifeRecordItem RobItemFromGraveFail => Instance[(short)266];

		public static LifeRecordItem StealLifeSkillFail1 => Instance[(short)267];

		public static LifeRecordItem StealLifeSkillFail2 => Instance[(short)268];

		public static LifeRecordItem StealLifeSkillFail3 => Instance[(short)269];

		public static LifeRecordItem StealLifeSkillFail4 => Instance[(short)270];

		public static LifeRecordItem StealLifeSkillSucceed => Instance[(short)271];

		public static LifeRecordItem StealLifeSkillSucceedAndEscaped => Instance[(short)272];

		public static LifeRecordItem LifeSkillGetStolenSucceed => Instance[(short)273];

		public static LifeRecordItem ScamLifeSkillFail1 => Instance[(short)274];

		public static LifeRecordItem ScamLifeSkillFail2 => Instance[(short)275];

		public static LifeRecordItem ScamLifeSkillFail3 => Instance[(short)276];

		public static LifeRecordItem ScamLifeSkillFail4 => Instance[(short)277];

		public static LifeRecordItem ScamLifeSkillSucceed => Instance[(short)278];

		public static LifeRecordItem ScamLifeSkillSucceedAndEscaped => Instance[(short)279];

		public static LifeRecordItem LifeSkillGetScammedSucceed => Instance[(short)280];

		public static LifeRecordItem StealCombatSkillFail1 => Instance[(short)281];

		public static LifeRecordItem StealCombatSkillFail2 => Instance[(short)282];

		public static LifeRecordItem StealCombatSkillFail3 => Instance[(short)283];

		public static LifeRecordItem StealCombatSkillFail4 => Instance[(short)284];

		public static LifeRecordItem StealCombatSkillSucceed => Instance[(short)285];

		public static LifeRecordItem StealCombatSkillSucceedAndEscaped => Instance[(short)286];

		public static LifeRecordItem CombatSkillGetStolenSucceed => Instance[(short)287];

		public static LifeRecordItem ScamCombatSkillFail1 => Instance[(short)288];

		public static LifeRecordItem ScamCombatSkillFail2 => Instance[(short)289];

		public static LifeRecordItem ScamCombatSkillFail3 => Instance[(short)290];

		public static LifeRecordItem ScamCombatSkillFail4 => Instance[(short)291];

		public static LifeRecordItem ScamCombatSkillSucceed => Instance[(short)292];

		public static LifeRecordItem ScamCombatSkillSucceedAndEscaped => Instance[(short)293];

		public static LifeRecordItem CombatSkillGetScammedSucceed => Instance[(short)294];

		public static LifeRecordItem LifeSkillBattleWin => Instance[(short)295];

		public static LifeRecordItem LifeSkillBattleLose => Instance[(short)296];

		public static LifeRecordItem ExchangeResource => Instance[(short)297];

		public static LifeRecordItem GiveResource => Instance[(short)298];

		public static LifeRecordItem PurchaseItem => Instance[(short)299];

		public static LifeRecordItem SellItem => Instance[(short)300];

		public static LifeRecordItem GiveItem => Instance[(short)301];

		public static LifeRecordItem GivePoisonousItem => Instance[(short)302];

		public static LifeRecordItem GetResourceAsGift => Instance[(short)303];

		public static LifeRecordItem GetItemAsGift => Instance[(short)304];

		public static LifeRecordItem RefusePoisonousGift => Instance[(short)305];

		public static LifeRecordItem InstructLifeSkill => Instance[(short)306];

		public static LifeRecordItem InstructCombatSkill => Instance[(short)307];

		public static LifeRecordItem LearnLifeSkillWithInstructionSucceed => Instance[(short)308];

		public static LifeRecordItem LearnLifeSkillWithInstructionFail => Instance[(short)309];

		public static LifeRecordItem LearnCombatSkillWithInstructionSucceed => Instance[(short)310];

		public static LifeRecordItem LearnCombatSkillWithInstructionFail => Instance[(short)311];

		public static LifeRecordItem InviteToDrinkSucceed => Instance[(short)312];

		public static LifeRecordItem InviteToDrinkFail => Instance[(short)313];

		public static LifeRecordItem SellSucceed => Instance[(short)314];

		public static LifeRecordItem SellFail => Instance[(short)315];

		public static LifeRecordItem CureSucceed => Instance[(short)316];

		public static LifeRecordItem RepairItemSucceed => Instance[(short)317];

		public static LifeRecordItem BarbSucceed => Instance[(short)318];

		public static LifeRecordItem BarbMistake => Instance[(short)319];

		public static LifeRecordItem BarbFail => Instance[(short)320];

		public static LifeRecordItem AskForMoneySucceed => Instance[(short)321];

		public static LifeRecordItem AskForMoneyFail => Instance[(short)322];

		public static LifeRecordItem EntertainWithMusic => Instance[(short)323];

		public static LifeRecordItem EntertainWithChess => Instance[(short)324];

		public static LifeRecordItem EntertainWithPoem => Instance[(short)325];

		public static LifeRecordItem EntertainWithPainting => Instance[(short)326];

		public static LifeRecordItem AcceptInviteToDrink => Instance[(short)327];

		public static LifeRecordItem RefuseInviteToDrink => Instance[(short)328];

		public static LifeRecordItem AcceptSell => Instance[(short)329];

		public static LifeRecordItem RefuseSell => Instance[(short)330];

		public static LifeRecordItem AcceptCure => Instance[(short)331];

		public static LifeRecordItem AcceptRepairItem => Instance[(short)332];

		public static LifeRecordItem GetBarbSucceed => Instance[(short)333];

		public static LifeRecordItem GetBarbMistake => Instance[(short)334];

		public static LifeRecordItem GetBarbFail => Instance[(short)335];

		public static LifeRecordItem AcceptAskForMoney => Instance[(short)336];

		public static LifeRecordItem RefuseAskForMoney => Instance[(short)337];

		public static LifeRecordItem AcceptEntertainWithMusic => Instance[(short)338];

		public static LifeRecordItem AcceptEntertainWithChess => Instance[(short)339];

		public static LifeRecordItem AcceptEntertainWithPoem => Instance[(short)340];

		public static LifeRecordItem AcceptEntertainWithPainting => Instance[(short)341];

		public static LifeRecordItem MakeItem => Instance[(short)342];

		public static LifeRecordItem TaoismAwakeningSucceed => Instance[(short)343];

		public static LifeRecordItem TaoismAwakeningFail => Instance[(short)344];

		public static LifeRecordItem BuddismAwakeningSucceed => Instance[(short)345];

		public static LifeRecordItem BuddismAwakeningFail => Instance[(short)346];

		public static LifeRecordItem TaoismGetAwakenedSucceed => Instance[(short)347];

		public static LifeRecordItem TaoismGetAwakenedFail => Instance[(short)348];

		public static LifeRecordItem BuddismGetAwakenedSucceed => Instance[(short)349];

		public static LifeRecordItem BuddismGetAwakenedFail => Instance[(short)350];

		public static LifeRecordItem CollectTeaWineSucceed => Instance[(short)351];

		public static LifeRecordItem CollectTeaWineFail => Instance[(short)352];

		public static LifeRecordItem DivinationSucceed => Instance[(short)353];

		public static LifeRecordItem DivinationFail => Instance[(short)354];

		public static LifeRecordItem CricketBattleWin => Instance[(short)355];

		public static LifeRecordItem CricketBattleLose => Instance[(short)356];

		public static LifeRecordItem MakeLoveLegal => Instance[(short)1401];

		public static LifeRecordItem MakeLoveIllegal => Instance[(short)357];

		public static LifeRecordItem RapeFail => Instance[(short)358];

		public static LifeRecordItem RapeSucceed => Instance[(short)359];

		public static LifeRecordItem ReleaseKidnappedCharacter => Instance[(short)360];

		public static LifeRecordItem GetRapedFail => Instance[(short)361];

		public static LifeRecordItem GetRapedSucceed => Instance[(short)362];

		public static LifeRecordItem GetReleasedByKidnapper => Instance[(short)363];

		public static LifeRecordItem MerchantGetNewProduct => Instance[(short)364];

		public static LifeRecordItem UnexpectedResourceGain => Instance[(short)365];

		public static LifeRecordItem UnexpectedItemGain => Instance[(short)366];

		public static LifeRecordItem UnexpectedSkillBookGain => Instance[(short)367];

		public static LifeRecordItem UnexpectedHealthCure => Instance[(short)368];

		public static LifeRecordItem UnexpectedOuterInjuryCure => Instance[(short)369];

		public static LifeRecordItem UnexpectedInnerInjuryCure => Instance[(short)370];

		public static LifeRecordItem UnexpectedPoisonCure => Instance[(short)371];

		public static LifeRecordItem UnexpectedDisorderOfQiCure => Instance[(short)372];

		public static LifeRecordItem UnexpectedResourceLose => Instance[(short)373];

		public static LifeRecordItem UnexpectedItemLose => Instance[(short)374];

		public static LifeRecordItem UnexpectedSkillBookLose => Instance[(short)375];

		public static LifeRecordItem UnexpectedHealthHarm => Instance[(short)376];

		public static LifeRecordItem UnexpectedOuterInjuryHarm => Instance[(short)377];

		public static LifeRecordItem UnexpectedInnerInjuryHarm => Instance[(short)378];

		public static LifeRecordItem UnexpectedPoisonHarm => Instance[(short)379];

		public static LifeRecordItem UnexpectedDisorderOfQiHarm => Instance[(short)380];

		public static LifeRecordItem KillHereticRandomEnemy => Instance[(short)381];

		public static LifeRecordItem KillRighteousRandomEnemy => Instance[(short)382];

		public static LifeRecordItem DefeatedByHereticRandomEnemy => Instance[(short)383];

		public static LifeRecordItem DefeatedByRighteousRandomEnemy => Instance[(short)384];

		public static LifeRecordItem MonvBad => Instance[(short)385];

		public static LifeRecordItem DayueYaochangBad => Instance[(short)386];

		public static LifeRecordItem JinHuangerBad => Instance[(short)387];

		public static LifeRecordItem YiyihouBad => Instance[(short)388];

		public static LifeRecordItem WeiQiBad => Instance[(short)389];

		public static LifeRecordItem YixiangBad => Instance[(short)390];

		public static LifeRecordItem ShufangBad => Instance[(short)391];

		public static LifeRecordItem JixiBad => Instance[(short)392];

		public static LifeRecordItem MonvGood => Instance[(short)393];

		public static LifeRecordItem DayueYaochangGood => Instance[(short)394];

		public static LifeRecordItem JinHuangerGood => Instance[(short)395];

		public static LifeRecordItem YiyihouGood => Instance[(short)396];

		public static LifeRecordItem WeiQiGood => Instance[(short)397];

		public static LifeRecordItem YixiangGood => Instance[(short)398];

		public static LifeRecordItem XuefengGood => Instance[(short)399];

		public static LifeRecordItem ShufangGood => Instance[(short)400];

		public static LifeRecordItem PregnantWithSamsara0 => Instance[(short)401];

		public static LifeRecordItem PregnantWithSamsara1 => Instance[(short)402];

		public static LifeRecordItem PregnantWithSamsara2 => Instance[(short)403];

		public static LifeRecordItem PregnantWithSamsara3 => Instance[(short)404];

		public static LifeRecordItem PregnantWithSamsara4 => Instance[(short)405];

		public static LifeRecordItem PregnantWithSamsara5 => Instance[(short)406];

		public static LifeRecordItem GainAuthority => Instance[(short)407];

		public static LifeRecordItem SectPunishNormal => Instance[(short)408];

		public static LifeRecordItem SectPunishElope => Instance[(short)409];

		public static LifeRecordItem ExpelVillager => Instance[(short)410];

		public static LifeRecordItem SavedFromInfection => Instance[(short)411];

		public static LifeRecordItem ChangeGrade => Instance[(short)412];

		public static LifeRecordItem AutoChangeGrade => Instance[(short)1414];

		public static LifeRecordItem ExpelledByTaiwu => Instance[(short)413];

		public static LifeRecordItem InsteadSectPunishElope => Instance[(short)414];

		public static LifeRecordItem AvoidSectPunishElope => Instance[(short)415];

		public static LifeRecordItem JoinJoustForSpouse => Instance[(short)416];

		public static LifeRecordItem GetHusbandByJoustForSpouse => Instance[(short)417];

		public static LifeRecordItem GetWifeByJoustForSpouse => Instance[(short)418];

		public static LifeRecordItem NoHusbandByJoustForSpouse => Instance[(short)419];

		public static LifeRecordItem SectCompetitionBeWinner => Instance[(short)420];

		public static LifeRecordItem SectCompetitionBeParticipant => Instance[(short)421];

		public static LifeRecordItem SectCompetitionBeHost => Instance[(short)422];

		public static LifeRecordItem WulinConferenceBeParticipant => Instance[(short)423];

		public static LifeRecordItem WulinConferenceBeWinner => Instance[(short)424];

		public static LifeRecordItem WulinConferenceBeWinnerButTaiwu => Instance[(short)425];

		public static LifeRecordItem WulinConferenceBeHost => Instance[(short)426];

		public static LifeRecordItem WulinConferenceBeKilledByYufu => Instance[(short)427];

		public static LifeRecordItem WulinConferenceDonation => Instance[(short)428];

		public static LifeRecordItem BeAttackedAndDieByWuYingLing => Instance[(short)429];

		public static LifeRecordItem NaturalDisasterGiveDeath => Instance[(short)430];

		public static LifeRecordItem NaturalDisasterHappen => Instance[(short)431];

		public static LifeRecordItem NaturalDisasterButSurvive => Instance[(short)432];

		public static LifeRecordItem NormalInformationChangeLovingItemSubType => Instance[(short)433];

		public static LifeRecordItem NormalInformationChangeHatingItemSubType => Instance[(short)434];

		public static LifeRecordItem NormalInformationChangeIdealSect => Instance[(short)435];

		public static LifeRecordItem NormalInformationChangeBaseMorality => Instance[(short)436];

		public static LifeRecordItem NormalInformationChangeLifeSkillTypeInterest => Instance[(short)437];

		public static LifeRecordItem RobGraveEncounterSkeleton => Instance[(short)438];

		public static LifeRecordItem RobGraveFailed => Instance[(short)439];

		public static LifeRecordItem SectPunishLevelLowest => Instance[(short)440];

		public static LifeRecordItem PrincipalSectPunishLevelMiddle => Instance[(short)441];

		public static LifeRecordItem PrincipalSectPunishLevelHighest => Instance[(short)442];

		public static LifeRecordItem NonPrincipalSectPunishLevelLowest => Instance[(short)443];

		public static LifeRecordItem NonPrincipalSectPunishLevelHighest => Instance[(short)444];

		public static LifeRecordItem BecomeSwornSiblingByThreatened => Instance[(short)445];

		public static LifeRecordItem MarriedByThreatened => Instance[(short)446];

		public static LifeRecordItem GetAdoptedFatherByThreatened => Instance[(short)447];

		public static LifeRecordItem GetAdoptedMotherByThreatened => Instance[(short)448];

		public static LifeRecordItem GetAdoptedSonByThreatened => Instance[(short)449];

		public static LifeRecordItem GetAdoptedDaughterByThreatened => Instance[(short)450];

		public static LifeRecordItem AddMentorByThreatened => Instance[(short)451];

		public static LifeRecordItem SeverSwornSiblingByThreatened => Instance[(short)452];

		public static LifeRecordItem DivorceByThreatened => Instance[(short)453];

		public static LifeRecordItem SeverMentorByThreatened => Instance[(short)454];

		public static LifeRecordItem SeverAdoptiveFatherByThreatened => Instance[(short)455];

		public static LifeRecordItem SeverAdoptiveMotherByThreatened => Instance[(short)456];

		public static LifeRecordItem SeverAdoptiveSonByThreatened => Instance[(short)457];

		public static LifeRecordItem SeverAdoptiveDaughterByThreatened => Instance[(short)458];

		public static LifeRecordItem GetThreatenedAdoptiveFather => Instance[(short)459];

		public static LifeRecordItem GetThreatenedAdoptiveMother => Instance[(short)460];

		public static LifeRecordItem GetThreatenedAdoptiveSon => Instance[(short)461];

		public static LifeRecordItem GetThreatenedAdoptiveDaughter => Instance[(short)462];

		public static LifeRecordItem ApproveTaiwuByThreatened => Instance[(short)463];

		public static LifeRecordItem FourSeasonsAdventureBeParticipant => Instance[(short)464];

		public static LifeRecordItem FourSeasonsAdventureBeWinner => Instance[(short)465];

		public static LifeRecordItem EndAdored => Instance[(short)466];

		public static LifeRecordItem GetMentor => Instance[(short)467];

		public static LifeRecordItem GetMentee => Instance[(short)468];

		public static LifeRecordItem SeverAdoptiveParent => Instance[(short)469];

		public static LifeRecordItem SeverAdoptiveChild => Instance[(short)470];

		public static LifeRecordItem SeverMentor => Instance[(short)471];

		public static LifeRecordItem SeverMentee => Instance[(short)472];

		public static LifeRecordItem Divorce => Instance[(short)473];

		public static LifeRecordItem ThreatenSucceed => Instance[(short)474];

		public static LifeRecordItem AdmonishSucceed => Instance[(short)475];

		public static LifeRecordItem ChangeBehaviorTypeByAdmonishedGood => Instance[(short)476];

		public static LifeRecordItem ReduceDebtByAdmonished => Instance[(short)477];

		public static LifeRecordItem ReduceDebtByThreatened => Instance[(short)478];

		public static LifeRecordItem ChangeBehaviorTypeByAdmonishedBad => Instance[(short)479];

		public static LifeRecordItem GainLegendaryBook => Instance[(short)480];

		public static LifeRecordItem BoostedByLegendaryBooks => Instance[(short)481];

		public static LifeRecordItem ActCrazy => Instance[(short)482];

		public static LifeRecordItem LegendaryBookShocked => Instance[(short)483];

		public static LifeRecordItem LegendaryBookInsane => Instance[(short)484];

		public static LifeRecordItem LegendaryBookConsumed => Instance[(short)485];

		public static LifeRecordItem DecideToContestForLegendaryBook => Instance[(short)486];

		public static LifeRecordItem FinishContestForLegendaryBook => Instance[(short)487];

		public static LifeRecordItem LegendaryBookChallengeWin => Instance[(short)488];

		public static LifeRecordItem LegendaryBookChallengeLose => Instance[(short)489];

		public static LifeRecordItem AcceptLegendaryBookChallengeWin => Instance[(short)490];

		public static LifeRecordItem AcceptLegendaryBookChallengeLose => Instance[(short)491];

		public static LifeRecordItem AcceptLegendaryBookChallengeEscape => Instance[(short)492];

		public static LifeRecordItem LegendaryBookChallengeEscaped => Instance[(short)493];

		public static LifeRecordItem LegendaryBookChallengeSelfEscaped => Instance[(short)494];

		public static LifeRecordItem AcceptLegendaryBookChallengeEnemyEscaped => Instance[(short)495];

		public static LifeRecordItem RefuseRequestLegendaryBookChallenge => Instance[(short)496];

		public static LifeRecordItem RequestLegendaryBookChallengeFail => Instance[(short)497];

		public static LifeRecordItem AcceptRequestLegendaryBook => Instance[(short)498];

		public static LifeRecordItem RequestLegendaryBookSucceed => Instance[(short)499];

		public static LifeRecordItem RequestLegendaryBookFail => Instance[(short)500];

		public static LifeRecordItem RefuseRequestLegendaryBook => Instance[(short)501];

		public static LifeRecordItem AcceptRequestExchangeLegendaryBook => Instance[(short)502];

		public static LifeRecordItem RequestExchangeLegendaryBookSucceed => Instance[(short)503];

		public static LifeRecordItem RefuseRequestExchangeLegendaryBook => Instance[(short)504];

		public static LifeRecordItem RequestExchangeLegendaryBookFail => Instance[(short)505];

		public static LifeRecordItem GiveLegendaryBookFail => Instance[(short)506];

		public static LifeRecordItem RefuseGiveLegendaryBook => Instance[(short)507];

		public static LifeRecordItem DefeatLegendaryBookInsaneJust => Instance[(short)508];

		public static LifeRecordItem DefeatLegendaryBookInsaneKind => Instance[(short)509];

		public static LifeRecordItem DefeatLegendaryBookInsaneEven => Instance[(short)510];

		public static LifeRecordItem DefeatLegendaryBookInsaneRebel => Instance[(short)511];

		public static LifeRecordItem DefeatLegendaryBookInsaneEgoistic => Instance[(short)512];

		public static LifeRecordItem LegendaryBookInsaneDefeatedJust => Instance[(short)513];

		public static LifeRecordItem LegendaryBookInsaneDefeatedKind => Instance[(short)514];

		public static LifeRecordItem LegendaryBookInsaneDefeatedEven => Instance[(short)515];

		public static LifeRecordItem LegendaryBookInsaneDefeatedRebel => Instance[(short)516];

		public static LifeRecordItem LegendaryBookInsaneDefeatedEgoistic => Instance[(short)517];

		public static LifeRecordItem ShockedInsaneEscaped => Instance[(short)518];

		public static LifeRecordItem ReleaseShockedInsane => Instance[(short)519];

		public static LifeRecordItem UnderAttackEscaped => Instance[(short)520];

		public static LifeRecordItem ReleaseUnderAttack => Instance[(short)521];

		public static LifeRecordItem DefeatConsumed => Instance[(short)522];

		public static LifeRecordItem BeDefetedByConsumed => Instance[(short)523];

		public static LifeRecordItem AcceptRequestExchangeLegendaryBookByExp => Instance[(short)524];

		public static LifeRecordItem RequestExchangeLegendaryBookSucceedByExp => Instance[(short)525];

		public static LifeRecordItem ResignPositionToStudyLegendaryBook => Instance[(short)526];

		public static LifeRecordItem SoundOutLoverMind => Instance[(short)527];

		public static LifeRecordItem SoundOutMind => Instance[(short)528];

		public static LifeRecordItem RedeemMindSucceed => Instance[(short)529];

		public static LifeRecordItem RedeemMindFail => Instance[(short)530];

		public static LifeRecordItem AcceptRedeemMind => Instance[(short)531];

		public static LifeRecordItem RefuseRedeemMind => Instance[(short)532];

		public static LifeRecordItem FirstDateWithLover => Instance[(short)533];

		public static LifeRecordItem FirstDateWithTaiwu => Instance[(short)534];

		public static LifeRecordItem SelectLoverToken => Instance[(short)535];

		public static LifeRecordItem SelectLoverToken2 => Instance[(short)536];

		public static LifeRecordItem DateWithLover => Instance[(short)537];

		public static LifeRecordItem DateWithLover2 => Instance[(short)538];

		public static LifeRecordItem TillDeathDoUsPart => Instance[(short)539];

		public static LifeRecordItem CelebrateBirthday => Instance[(short)540];

		public static LifeRecordItem CelebrateSelfBirthday => Instance[(short)541];

		public static LifeRecordItem CelebrateAnniversary => Instance[(short)542];

		public static LifeRecordItem BeCaughtCheating => Instance[(short)543];

		public static LifeRecordItem CaughtCheating => Instance[(short)544];

		public static LifeRecordItem PregnancyWithWife => Instance[(short)545];

		public static LifeRecordItem PregnancyWithHusband => Instance[(short)546];

		public static LifeRecordItem TeaTasting => Instance[(short)547];

		public static LifeRecordItem TeaTastingLifeSkillBattleWin => Instance[(short)548];

		public static LifeRecordItem TeaTastingLifeSkillBattleLose => Instance[(short)549];

		public static LifeRecordItem TeaTastingDisorderOfQi => Instance[(short)550];

		public static LifeRecordItem WineTasting => Instance[(short)551];

		public static LifeRecordItem WineTastingLifeSkillBattleWin => Instance[(short)552];

		public static LifeRecordItem WineTastingLifeSkillBattleLose => Instance[(short)553];

		public static LifeRecordItem WineTastingDisorderOfQi => Instance[(short)554];

		public static LifeRecordItem FirstNameChanged => Instance[(short)555];

		public static LifeRecordItem LifeSkillModel => Instance[(short)556];

		public static LifeRecordItem CombatSkillModel => Instance[(short)557];

		public static LifeRecordItem PromoteReputation => Instance[(short)558];

		public static LifeRecordItem ReputationPromoted => Instance[(short)559];

		public static LifeRecordItem CapabilityCultivated => Instance[(short)560];

		public static LifeRecordItem BroughtToTaiwuByBeggars => Instance[(short)561];

		public static LifeRecordItem DiscardRevengeForCivilianSkill => Instance[(short)562];

		public static LifeRecordItem CivilianSkillDissolveResentment => Instance[(short)563];

		public static LifeRecordItem PersuadeWithdrawlFromOrganization => Instance[(short)564];

		public static LifeRecordItem WithdrawlFromOrganization => Instance[(short)565];

		public static LifeRecordItem FreeMedicalConsultation => Instance[(short)566];

		public static LifeRecordItem OfferTreasures => Instance[(short)567];

		public static LifeRecordItem ReceiveOfferedTreasures => Instance[(short)568];

		public static LifeRecordItem ForcefulPurchase => Instance[(short)569];

		public static LifeRecordItem ForcefulSale => Instance[(short)570];

		public static LifeRecordItem BegForMoney => Instance[(short)571];

		public static LifeRecordItem AbsurdlyForceToLeave => Instance[(short)572];

		public static LifeRecordItem AbsurdlyForcedToLeave => Instance[(short)573];

		public static LifeRecordItem DiagnoseWithMedicine => Instance[(short)574];

		public static LifeRecordItem DiagnosedWithMedicine => Instance[(short)575];

		public static LifeRecordItem DiagnoseWithNonMedicine => Instance[(short)576];

		public static LifeRecordItem DiagnosedWithWrongMedicine => Instance[(short)577];

		public static LifeRecordItem ExtendLifeSpan => Instance[(short)578];

		public static LifeRecordItem LifeSpanExtended => Instance[(short)579];

		public static LifeRecordItem PersuadeToBecomeMonk => Instance[(short)580];

		public static LifeRecordItem BecomeMonkPersuaded => Instance[(short)581];

		public static LifeRecordItem FailToPersuadeToBecomeMonk => Instance[(short)582];

		public static LifeRecordItem ExpiateDeadSouls => Instance[(short)583];

		public static LifeRecordItem ExociseXiangshuInfectionVictoryInCombat => Instance[(short)584];

		public static LifeRecordItem BecomeExociseXiangshuInfectionVictoryInCombat => Instance[(short)585];

		public static LifeRecordItem ExociseXiangshuInfectionVictoryInCombatDefeated => Instance[(short)586];

		public static LifeRecordItem TribulationSucceeded => Instance[(short)587];

		public static LifeRecordItem TribulationFailed => Instance[(short)588];

		public static LifeRecordItem TribulationCanceled => Instance[(short)589];

		public static LifeRecordItem TribulationContinued => Instance[(short)590];

		public static LifeRecordItem GuidingEvilToGoodSucceed => Instance[(short)591];

		public static LifeRecordItem GuidingEvilGoodSucceed => Instance[(short)592];

		public static LifeRecordItem GuidingEvilToGoodFail => Instance[(short)593];

		public static LifeRecordItem VisitBuddhismTemples => Instance[(short)594];

		public static LifeRecordItem EpiphanyThruVisitTemples => Instance[(short)595];

		public static LifeRecordItem EpiphanyThruVisitTemplesCombatSkill => Instance[(short)596];

		public static LifeRecordItem EpiphanyThruVisitTemplesLifeSkill => Instance[(short)597];

		public static LifeRecordItem EpiphanyThruVisitTemplesExperience => Instance[(short)598];

		public static LifeRecordItem DivineUnexpectedGain => Instance[(short)599];

		public static LifeRecordItem DivineUnexpectedHarm => Instance[(short)600];

		public static LifeRecordItem ExchangeFates => Instance[(short)601];

		public static LifeRecordItem BecomeExchangeFates => Instance[(short)602];

		public static LifeRecordItem ImmortalityGained => Instance[(short)603];

		public static LifeRecordItem ImmortalityLost => Instance[(short)604];

		public static LifeRecordItem ImmortalityRegained => Instance[(short)605];

		public static LifeRecordItem TaiwuReincarnation => Instance[(short)606];

		public static LifeRecordItem TaiwuReincarnationPregnancy => Instance[(short)607];

		public static LifeRecordItem MixPoisonHotRedRotten => Instance[(short)608];

		public static LifeRecordItem MixPoisonHotRottenIllusory => Instance[(short)609];

		public static LifeRecordItem MixPoisonHotRottenGloomy => Instance[(short)610];

		public static LifeRecordItem MixPoisonHotRottenCold => Instance[(short)611];

		public static LifeRecordItem MixPoisonRedRottenIllusory => Instance[(short)612];

		public static LifeRecordItem MixPoisonRedRottenGloomy => Instance[(short)613];

		public static LifeRecordItem MixPoisonRedRottenCold => Instance[(short)614];

		public static LifeRecordItem MixPoisonHotRedIllusory => Instance[(short)615];

		public static LifeRecordItem MixPoisonHotRedGloomy => Instance[(short)616];

		public static LifeRecordItem MixPoisonHotRedCold => Instance[(short)617];

		public static LifeRecordItem MixPoisonGloomyColdIllusory => Instance[(short)618];

		public static LifeRecordItem MixPoisonRottenGloomyCold => Instance[(short)619];

		public static LifeRecordItem MixPoisonHotGloomyCold => Instance[(short)620];

		public static LifeRecordItem MixPoisonRedGloomyCold => Instance[(short)621];

		public static LifeRecordItem MixPoisonRottenColdIllusory => Instance[(short)622];

		public static LifeRecordItem MixPoisonHotColdIllusory => Instance[(short)623];

		public static LifeRecordItem MixPoisonRedColdIllusory => Instance[(short)624];

		public static LifeRecordItem MixPoisonRottenGloomyIllusory => Instance[(short)625];

		public static LifeRecordItem MixPoisonHotGloomyIllusory => Instance[(short)626];

		public static LifeRecordItem MixPoisonRedGloomyIllusory => Instance[(short)627];

		public static LifeRecordItem DiggingXiangshuMinionCombatLost => Instance[(short)628];

		public static LifeRecordItem DiggingXiangshuMinionCombatWon => Instance[(short)629];

		public static LifeRecordItem SectMainStoryXuehouJixiKills => Instance[(short)630];

		public static LifeRecordItem SectMainStoryWudangTreasure => Instance[(short)631];

		public static LifeRecordItem SectMainStoryXuannvJoinOrg => Instance[(short)632];

		public static LifeRecordItem SectMainStoryYuanshanGetAbsorbed => Instance[(short)633];

		public static LifeRecordItem SectMainStoryYuanshanResistSucceed => Instance[(short)634];

		public static LifeRecordItem SectMainStoryYuanshanResistOrdinary => Instance[(short)635];

		public static LifeRecordItem SectMainStoryYuanshanResistFailed => Instance[(short)636];

		public static LifeRecordItem SectMainStoryXuehouZombieKills => Instance[(short)637];

		public static LifeRecordItem SectMainStoryShixiangSkillEnemy => Instance[(short)638];

		public static LifeRecordItem SectMainStoryWuxianMethysis0 => Instance[(short)639];

		public static LifeRecordItem SectMainStoryWuxianPoison => Instance[(short)640];

		public static LifeRecordItem SectMainStoryWuxianAssault => Instance[(short)641];

		public static LifeRecordItem SectMainStoryWuxianMethysis1 => Instance[(short)642];

		public static LifeRecordItem SectMainStoryEmeiInfighting => Instance[(short)643];

		public static LifeRecordItem SectMainStoryJieqingAssassin => Instance[(short)644];

		public static LifeRecordItem WulinConferencePraiseAndGifts => Instance[(short)645];

		public static LifeRecordItem NormalInformationChangeIdealSectNegative => Instance[(short)646];

		public static LifeRecordItem SectMainStoryXuehouJixiRescueTaiwu => Instance[(short)647];

		public static LifeRecordItem SectMainStoryRanshanJoinThreeFactionCompetetion => Instance[(short)648];

		public static LifeRecordItem SectMainStoryRanshanThreeFactionCompetetionWin => Instance[(short)649];

		public static LifeRecordItem SectMainStoryRanshanThreeFactionCompetetionLose => Instance[(short)650];

		public static LifeRecordItem GainExpByStroll => Instance[(short)651];

		public static LifeRecordItem GainExpByReadingOldBook => Instance[(short)652];

		public static LifeRecordItem PunishedAlongsideSpouse => Instance[(short)653];

		public static LifeRecordItem DecideToAdoptFoundling => Instance[(short)654];

		public static LifeRecordItem AdoptFoundlingFail => Instance[(short)655];

		public static LifeRecordItem AdoptFoundlingSucceed => Instance[(short)656];

		public static LifeRecordItem FoundlingGetAdopted => Instance[(short)657];

		public static LifeRecordItem ClaimFoundlingSucceed => Instance[(short)658];

		public static LifeRecordItem FoundlingGetClaimed => Instance[(short)659];

		public static LifeRecordItem SectMainStoryWudangVillagerKilled => Instance[(short)660];

		public static LifeRecordItem SectMainStoryShixiangFallIll => Instance[(short)661];

		public static LifeRecordItem KillAnimal => Instance[(short)662];

		public static LifeRecordItem DefeatedByAnimal => Instance[(short)663];

		public static LifeRecordItem EnterEnemyNest => Instance[(short)664];

		public static LifeRecordItem DieFromEnemyNest => Instance[(short)665];

		public static LifeRecordItem EscapeFromEnemyNest => Instance[(short)666];

		public static LifeRecordItem GetSecretSpreadInVeryHighProbability => Instance[(short)667];

		public static LifeRecordItem GetSecretSpreadInHighProbability => Instance[(short)668];

		public static LifeRecordItem GetSecretSpreadInLowProbability => Instance[(short)669];

		public static LifeRecordItem GetSecretSpreadInVeryLowProbability => Instance[(short)670];

		public static LifeRecordItem SpreadSecretFail => Instance[(short)671];

		public static LifeRecordItem SpreadSecretSuccess => Instance[(short)672];

		public static LifeRecordItem HeardSecretSpreadInVeryHighProbability => Instance[(short)673];

		public static LifeRecordItem HeardSecretSpreadInHighProbability => Instance[(short)674];

		public static LifeRecordItem HeardSecretSpreadInLowProbability => Instance[(short)675];

		public static LifeRecordItem HeardSecretSpreadInVeryLowProbability => Instance[(short)676];

		public static LifeRecordItem RequestKeepSecretFail => Instance[(short)677];

		public static LifeRecordItem RequestKeepSecretSuccess => Instance[(short)678];

		public static LifeRecordItem BeRequestedToKeepSecret => Instance[(short)679];

		public static LifeRecordItem ThreadNeedleMatchFail => Instance[(short)680];

		public static LifeRecordItem ThreadNeedleSeparateFail => Instance[(short)681];

		public static LifeRecordItem ThreadNeedleMatchSuccess => Instance[(short)682];

		public static LifeRecordItem ThreadNeedleSeparateSuccess => Instance[(short)683];

		public static LifeRecordItem ThreadNeedleBeMatched1 => Instance[(short)684];

		public static LifeRecordItem ThreadNeedleBeSeparated1 => Instance[(short)685];

		public static LifeRecordItem ThreadNeedleBeMatched2 => Instance[(short)686];

		public static LifeRecordItem ThreadNeedleBeSeparated2 => Instance[(short)687];

		public static LifeRecordItem SpreadSecretKnown => Instance[(short)688];

		public static LifeRecordItem SectMainStoryXuannvBirthOfMirrorCreatedImposture => Instance[(short)689];

		public static LifeRecordItem EscapeFromEnemyNestBySelf => Instance[(short)690];

		public static LifeRecordItem SaveFromInfection => Instance[(short)691];

		public static LifeRecordItem SaveFromEnemyNest => Instance[(short)692];

		public static LifeRecordItem SaveFromEnemyNestFailed => Instance[(short)693];

		public static LifeRecordItem TameCarrierSucceed => Instance[(short)694];

		public static LifeRecordItem TameCarrierFail => Instance[(short)695];

		public static LifeRecordItem ReleaseCarrier => Instance[(short)696];

		public static LifeRecordItem DLCLoongRidingEffectQiuniuAudience => Instance[(short)697];

		public static LifeRecordItem DLCLoongRidingEffectQiuniu => Instance[(short)698];

		public static LifeRecordItem DLCLoongRidingEffectYazi => Instance[(short)699];

		public static LifeRecordItem DLCLoongRidingEffectChaofeng => Instance[(short)700];

		public static LifeRecordItem DLCLoongRidingEffectPulao => Instance[(short)701];

		public static LifeRecordItem DLCLoongRidingEffectSuanni => Instance[(short)702];

		public static LifeRecordItem DLCLoongRidingEffectBaxia => Instance[(short)703];

		public static LifeRecordItem DLCLoongRidingEffectBian => Instance[(short)704];

		public static LifeRecordItem DLCLoongRidingEffectFuxi => Instance[(short)705];

		public static LifeRecordItem DLCLoongRidingEffectChiwen => Instance[(short)706];

		public static LifeRecordItem DefeatLoong => Instance[(short)707];

		public static LifeRecordItem DefeatedByLoong => Instance[(short)708];

		public static LifeRecordItem DLCLoongRidingEffectYazi2 => Instance[(short)709];

		public static LifeRecordItem DieFromAge => Instance[(short)710];

		public static LifeRecordItem DieFromPoorHealth => Instance[(short)711];

		public static LifeRecordItem KilledInPublic => Instance[(short)712];

		public static LifeRecordItem KilledInPrivate => Instance[(short)713];

		public static LifeRecordItem KilledAfterXiangshuInfected => Instance[(short)714];

		public static LifeRecordItem Assassinated => Instance[(short)715];

		public static LifeRecordItem KilledByXiangshu => Instance[(short)716];

		public static LifeRecordItem PurchaseItem1 => Instance[(short)717];

		public static LifeRecordItem SellItem1 => Instance[(short)718];

		public static LifeRecordItem CleanBodyReincarnationSuccess => Instance[(short)719];

		public static LifeRecordItem CleanBodyReincarnationFail => Instance[(short)720];

		public static LifeRecordItem EvilBodyReincarnationSuccess => Instance[(short)721];

		public static LifeRecordItem EvilBodyReincarnationFail => Instance[(short)722];

		public static LifeRecordItem WugKingForestSpiritBecomeEnemy => Instance[(short)723];

		public static LifeRecordItem SecretMakeEnemy => Instance[(short)724];

		public static LifeRecordItem SecretBeMadeEnemy => Instance[(short)725];

		public static LifeRecordItem CleanBodyDefeatAnimal => Instance[(short)726];

		public static LifeRecordItem EvilBodyDefeatAnimal => Instance[(short)727];

		public static LifeRecordItem CleanBodyDefeatHereticRandomEnemy => Instance[(short)728];

		public static LifeRecordItem EvilBodyDefeatHereticRandomEnemy => Instance[(short)729];

		public static LifeRecordItem CleanBodyDefeatRighteousRandomEnemy => Instance[(short)730];

		public static LifeRecordItem EvilBodyDefeatRighteousRandomEnemy => Instance[(short)731];

		public static LifeRecordItem WuxianParanoiaAdded => Instance[(short)732];

		public static LifeRecordItem WuxianParanoiaAttack => Instance[(short)733];

		public static LifeRecordItem WuxianParanoiaErased => Instance[(short)734];

		public static LifeRecordItem WugKingRedEyeLoseItem => Instance[(short)735];

		public static LifeRecordItem WugForestSpiritReduceFavorability => Instance[(short)736];

		public static LifeRecordItem WugKingForestSpiritBeBecomeEnemy => Instance[(short)737];

		public static LifeRecordItem WugKingBlackBloodChangeDisorderOfQi => Instance[(short)738];

		public static LifeRecordItem WugDevilInsideXiangshuInfection => Instance[(short)739];

		public static LifeRecordItem WugCorpseWormChangeHealth => Instance[(short)740];

		public static LifeRecordItem WugKingIceSilkwormLoseNeili => Instance[(short)741];

		public static LifeRecordItem WugKingGoldenSilkwormEatGrownWug => Instance[(short)742];

		public static LifeRecordItem WugAzureMarrowAddPoison => Instance[(short)743];

		public static LifeRecordItem WugAzureMarrowAddWug => Instance[(short)744];

		public static LifeRecordItem WugAzureMarrowBeAddWug => Instance[(short)745];

		public static LifeRecordItem WuxianParanoiaErased2 => Instance[(short)746];

		public static LifeRecordItem WuxianDecreasedMood => Instance[(short)747];

		public static LifeRecordItem WuxianDecreasedFavorability => Instance[(short)748];

		public static LifeRecordItem WuxianQiDecline => Instance[(short)749];

		public static LifeRecordItem WuxianPoisoning => Instance[(short)750];

		public static LifeRecordItem WuxianLoseItem => Instance[(short)751];

		public static LifeRecordItem WugDevilInsideChangeHappiness => Instance[(short)752];

		public static LifeRecordItem WugRedEyeChangeToGrown => Instance[(short)753];

		public static LifeRecordItem WugForestSpiritChangeToGrown => Instance[(short)754];

		public static LifeRecordItem WugBlackBloodChangeToGrown => Instance[(short)755];

		public static LifeRecordItem WugDevilInsideChangeToGrown => Instance[(short)756];

		public static LifeRecordItem WugCorpseWormChangeToGrown => Instance[(short)757];

		public static LifeRecordItem WugCorpseWormBeChangeToGrown => Instance[(short)758];

		public static LifeRecordItem WugIceSilkwormChangeToGrown => Instance[(short)759];

		public static LifeRecordItem WugGoldenSilkwormChangeToGrown => Instance[(short)760];

		public static LifeRecordItem WugAzureMarrowChangeToGrown => Instance[(short)761];

		public static LifeRecordItem WugAzureMarrowBeChangeToGrown => Instance[(short)762];

		public static LifeRecordItem ManageLearnLifeSkillSuccess => Instance[(short)763];

		public static LifeRecordItem ManageLearnCombatSkillSuccess => Instance[(short)764];

		public static LifeRecordItem ManageLearnLifeSkillFail => Instance[(short)765];

		public static LifeRecordItem ManageLearnCombatSkillFail => Instance[(short)766];

		public static LifeRecordItem ManageLifeSkillAbilityUp => Instance[(short)767];

		public static LifeRecordItem ManageCombatSkillAbilityUp => Instance[(short)768];

		public static LifeRecordItem SmallVillagerXiangshuCompletelyInfected => Instance[(short)769];

		public static LifeRecordItem SmallVillagerSavedFromInfection => Instance[(short)770];

		public static LifeRecordItem SmallVillagerSaveFromInfection => Instance[(short)771];

		public static LifeRecordItem StorageResourceToTreasury => Instance[(short)772];

		public static LifeRecordItem StorageItemToTreasury => Instance[(short)773];

		public static LifeRecordItem TakeResourceFromTreasury => Instance[(short)774];

		public static LifeRecordItem TakeItemFromTreasury => Instance[(short)775];

		public static LifeRecordItem TaiwuStorageResourceToTreasury => Instance[(short)776];

		public static LifeRecordItem TaiwuStorageItemToTreasury => Instance[(short)777];

		public static LifeRecordItem TaiwuTakeResourceFromTreasury => Instance[(short)778];

		public static LifeRecordItem TaiwuTakeItemFromTreasury => Instance[(short)779];

		public static LifeRecordItem DecideToGuardTreasury => Instance[(short)780];

		public static LifeRecordItem FinishGuardingTreasury => Instance[(short)781];

		public static LifeRecordItem IntrudeTreasuryCancelSupportMakeEnemy => Instance[(short)782];

		public static LifeRecordItem IntrudeTreasuryBeCancelSupportMakeEnemy => Instance[(short)783];

		public static LifeRecordItem IntrudeTreasuryCancelSupport => Instance[(short)784];

		public static LifeRecordItem IntrudeTreasuryBeCancelSupport => Instance[(short)785];

		public static LifeRecordItem IntrudeTreasuryMakeEnemyOthers => Instance[(short)786];

		public static LifeRecordItem IntrudeTreasuryBeMakeEnemyOthers => Instance[(short)787];

		public static LifeRecordItem IntrudeTreasuryLostMorale => Instance[(short)788];

		public static LifeRecordItem IntrudeTreasuryBeLostMorale => Instance[(short)789];

		public static LifeRecordItem IntrudeTreasuryBeLostMorale2 => Instance[(short)790];

		public static LifeRecordItem PlunderTreasuryCancelSupportMakeEnemy => Instance[(short)791];

		public static LifeRecordItem PlunderTreasuryBeCancelSupportMakeEnemy => Instance[(short)792];

		public static LifeRecordItem PlunderTreasuryCancelSupport => Instance[(short)793];

		public static LifeRecordItem PlunderTreasuryBeCancelSupport => Instance[(short)794];

		public static LifeRecordItem PlunderTreasuryMakeEnemyOthers => Instance[(short)795];

		public static LifeRecordItem PlunderTreasuryBeMakeEnemyOthers => Instance[(short)796];

		public static LifeRecordItem PlunderTreasuryLostMorale => Instance[(short)797];

		public static LifeRecordItem PlunderTreasuryBeLostMorale => Instance[(short)798];

		public static LifeRecordItem PlunderTreasuryBeLostMorale2 => Instance[(short)799];

		public static LifeRecordItem DonateTreasuryProvideSupport => Instance[(short)800];

		public static LifeRecordItem DonateTreasuryBeProvideSupport => Instance[(short)801];

		public static LifeRecordItem DonateTreasuryGetMorale => Instance[(short)802];

		public static LifeRecordItem DonateTreasuryBeGetMorale => Instance[(short)803];

		public static LifeRecordItem DonateTreasuryGetMorale2 => Instance[(short)804];

		public static LifeRecordItem TreasuryDistributeResource => Instance[(short)805];

		public static LifeRecordItem TreasuryDistributeItem => Instance[(short)806];

		public static LifeRecordItem PoisonEnemyFail12 => Instance[(short)807];

		public static LifeRecordItem PoisonEnemyFail22 => Instance[(short)808];

		public static LifeRecordItem PoisonEnemyFail32 => Instance[(short)809];

		public static LifeRecordItem PoisonEnemyFail42 => Instance[(short)810];

		public static LifeRecordItem PoisonEnemySucceed2 => Instance[(short)811];

		public static LifeRecordItem PoisonEnemySucceedAndEscaped2 => Instance[(short)812];

		public static LifeRecordItem GetPoisonedByEnemySucceed2 => Instance[(short)813];

		public static LifeRecordItem PlotHarmEnemyFail12 => Instance[(short)814];

		public static LifeRecordItem PlotHarmEnemyFail22 => Instance[(short)815];

		public static LifeRecordItem PlotHarmEnemyFail32 => Instance[(short)816];

		public static LifeRecordItem PlotHarmEnemyFail42 => Instance[(short)817];

		public static LifeRecordItem PlotHarmEnemySucceed2 => Instance[(short)818];

		public static LifeRecordItem PlotHarmEnemySucceedAndEscaped2 => Instance[(short)819];

		public static LifeRecordItem GetPlottedAgainstSucceed2 => Instance[(short)820];

		public static LifeRecordItem SectMainStoryBaihuaManiaLow => Instance[(short)821];

		public static LifeRecordItem SectMainStoryBaihuaManiaHigh => Instance[(short)822];

		public static LifeRecordItem SectMainStoryBaihuaManiaAttack => Instance[(short)823];

		public static LifeRecordItem SectMainStoryBaihuaManiaAttacked => Instance[(short)824];

		public static LifeRecordItem SectMainStoryBaihuaManiaCure => Instance[(short)825];

		public static LifeRecordItem SectMainStoryBaihuaManiaCured => Instance[(short)826];

		public static LifeRecordItem GiveUpLegendaryBookSuccessHuaJu => Instance[(short)827];

		public static LifeRecordItem GiveUpLegendaryBookSuccessXuanZhi => Instance[(short)828];

		public static LifeRecordItem GiveUpLegendaryBookSuccessYingJiao => Instance[(short)829];

		public static LifeRecordItem SecretMakeEnemy2 => Instance[(short)830];

		public static LifeRecordItem SecretBeMadeEnemy2 => Instance[(short)831];

		public static LifeRecordItem DecideToHuntFugitive => Instance[(short)832];

		public static LifeRecordItem FinishHuntFugitive => Instance[(short)833];

		public static LifeRecordItem DecideToEscapePunishment => Instance[(short)834];

		public static LifeRecordItem FinishEscapePunishment => Instance[(short)835];

		public static LifeRecordItem DecideToSeekAsylum => Instance[(short)836];

		public static LifeRecordItem FinishSeekAsylum => Instance[(short)837];

		public static LifeRecordItem SeekAsylumSuccess => Instance[(short)838];

		public static LifeRecordItem DecideToEscortPrisoner => Instance[(short)839];

		public static LifeRecordItem EscortPrisonerSucceed => Instance[(short)840];

		public static LifeRecordItem ImprisonedShaoLin => Instance[(short)841];

		public static LifeRecordItem ImprisonedEmei1 => Instance[(short)842];

		public static LifeRecordItem ImprisonedEmei2 => Instance[(short)843];

		public static LifeRecordItem ImprisonedBaihua => Instance[(short)844];

		public static LifeRecordItem ImprisonedWudang => Instance[(short)845];

		public static LifeRecordItem ImprisonedYuanshan => Instance[(short)846];

		public static LifeRecordItem ImprisonedShingXiang => Instance[(short)847];

		public static LifeRecordItem ImprisonedRanShan => Instance[(short)848];

		public static LifeRecordItem ImprisonedXuanNv => Instance[(short)849];

		public static LifeRecordItem ImprisonedZhuJian => Instance[(short)850];

		public static LifeRecordItem ImprisonedKongSang => Instance[(short)851];

		public static LifeRecordItem ImprisonedJinGang => Instance[(short)852];

		public static LifeRecordItem ImprisonedWuXian => Instance[(short)853];

		public static LifeRecordItem ImprisonedJieQing1 => Instance[(short)854];

		public static LifeRecordItem ImprisonedJieQing2 => Instance[(short)855];

		public static LifeRecordItem ImprisonedFuLong => Instance[(short)856];

		public static LifeRecordItem ImprisonedXueHou => Instance[(short)857];

		public static LifeRecordItem IntrudePrisonCancelSupportMakeEnemyNpc => Instance[(short)858];

		public static LifeRecordItem IntrudePrisonCancelSupportMakeEnemyTaiwu => Instance[(short)859];

		public static LifeRecordItem IntrudePrisonCancelSupportNpc => Instance[(short)860];

		public static LifeRecordItem IntrudePrisonCancelSupportTaiwu => Instance[(short)861];

		public static LifeRecordItem IntrudePrisonMakeEnemyOthersNpc => Instance[(short)862];

		public static LifeRecordItem IntrudePrisonMakeEnemyOthersTaiwu => Instance[(short)863];

		public static LifeRecordItem RequestTheReleaseOfTheCriminalNpc => Instance[(short)864];

		public static LifeRecordItem RequestTheReleaseOfTheCriminalTaiwu => Instance[(short)865];

		public static LifeRecordItem ImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityNpc => Instance[(short)866];

		public static LifeRecordItem ImprisonedXiangshuInfectedSupportIncreaseAndFavorabilityTaiwu => Instance[(short)867];

		public static LifeRecordItem ImprisonedXiangshuInfectedIncreaseFavorabilityNpc => Instance[(short)868];

		public static LifeRecordItem ImprisonedXiangshuInfectedIncreaseFavorabilityTaiwu => Instance[(short)869];

		public static LifeRecordItem ImprisonedXiangshuInfectedNpc => Instance[(short)870];

		public static LifeRecordItem ImprisonedXiangshuInfectedTaiwu => Instance[(short)871];

		public static LifeRecordItem RobbedFromPrisonNpc => Instance[(short)872];

		public static LifeRecordItem PrisonBreakIntrudePrisonCancelSupportMakeEnemyNpc => Instance[(short)873];

		public static LifeRecordItem PrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu => Instance[(short)874];

		public static LifeRecordItem PrisonBreakIntrudePrisonCancelSupportNpc => Instance[(short)875];

		public static LifeRecordItem PrisonBreakIntrudePrisonCancelSupportTaiwu => Instance[(short)876];

		public static LifeRecordItem PrisonBreakIntrudePrisonMakeEnemyOthersNpc => Instance[(short)877];

		public static LifeRecordItem PrisonBreakIntrudePrisonMakeEnemyOthersTaiwu => Instance[(short)878];

		public static LifeRecordItem ResistArrestIntrudePrisonCancelSupportMakeEnemyNpc => Instance[(short)879];

		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwu => Instance[(short)880];

		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonCancelSupportNpc => Instance[(short)881];

		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonCancelSupportTaiwu => Instance[(short)882];

		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpc => Instance[(short)883];

		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwu => Instance[(short)884];

		public static LifeRecordItem ArrestFailedCaptor => Instance[(short)885];

		public static LifeRecordItem ArrestFailedCriminal => Instance[(short)886];

		public static LifeRecordItem ResistArresEngageInBattleTaiwu => Instance[(short)887];

		public static LifeRecordItem ArrestedSuccessfullyCaptor => Instance[(short)888];

		public static LifeRecordItem ArrestedSuccessfullyCriminal => Instance[(short)889];

		public static LifeRecordItem ReceiveCriminalsCaptor => Instance[(short)890];

		public static LifeRecordItem ReceiveCriminalsTaiwu => Instance[(short)891];

		public static LifeRecordItem ReceiveCriminalsCriminal => Instance[(short)892];

		public static LifeRecordItem BuyHandOverTheCriminalCaptor => Instance[(short)893];

		public static LifeRecordItem BuyHandOverTheCriminalTaiwu => Instance[(short)894];

		public static LifeRecordItem LifeSkillBattleHandOverTheCriminalCaptor => Instance[(short)895];

		public static LifeRecordItem LifeSkillBattleHandOverTheCriminalTaiwu => Instance[(short)896];

		public static LifeRecordItem LifeSkillBattleLoseHandOverTheCriminalCaptor => Instance[(short)897];

		public static LifeRecordItem LifeSkillBattleLoseHandOverTheCriminalTaiwu => Instance[(short)898];

		public static LifeRecordItem VictoryInCombatHandOverTheCriminalCaptor => Instance[(short)899];

		public static LifeRecordItem VictoryInCombatHandOverTheCriminalTaiwu => Instance[(short)900];

		public static LifeRecordItem FailureInCombatHandOverTheCriminalCaptor => Instance[(short)901];

		public static LifeRecordItem FailureInCombatHandOverTheCriminalTaiwu => Instance[(short)902];

		public static LifeRecordItem SectMainStoryFulongFightSucceed => Instance[(short)903];

		public static LifeRecordItem SectMainStoryFulongFightFail => Instance[(short)904];

		public static LifeRecordItem SectMainStoryFulongRobbery => Instance[(short)905];

		public static LifeRecordItem SectMainStoryFulongRobberKilledByTaiwu => Instance[(short)906];

		public static LifeRecordItem SectMainStoryFulongProtect => Instance[(short)907];

		public static LifeRecordItem HonestSectPunishLevel1 => Instance[(short)908];

		public static LifeRecordItem HonestSectPunishLevel2 => Instance[(short)909];

		public static LifeRecordItem HonestSectPunishLevel3 => Instance[(short)910];

		public static LifeRecordItem HonestSectPunishLevel4 => Instance[(short)911];

		public static LifeRecordItem HonestSectPunishLevel5 => Instance[(short)912];

		public static LifeRecordItem HonestSectPunishTogetherWithSpouseLevel5 => Instance[(short)913];

		public static LifeRecordItem ArrestedSectPunishLevel1 => Instance[(short)914];

		public static LifeRecordItem ArrestedSectPunishLevel2 => Instance[(short)915];

		public static LifeRecordItem ArrestedSectPunishLevel3 => Instance[(short)916];

		public static LifeRecordItem ArrestedSectPunishLevel4 => Instance[(short)917];

		public static LifeRecordItem ArrestedSectPunishLevel5 => Instance[(short)918];

		public static LifeRecordItem ArrestedSectPunishTogetherWithSpouseLevel5 => Instance[(short)919];

		public static LifeRecordItem BeImplicatedSectPunishLevel5 => Instance[(short)920];

		public static LifeRecordItem BeReleasedUponCompletionOfASentence => Instance[(short)921];

		public static LifeRecordItem PrisonBreak => Instance[(short)922];

		public static LifeRecordItem SendingToPrison1Taiwu => Instance[(short)923];

		public static LifeRecordItem SendingToPrison2Taiwu => Instance[(short)924];

		public static LifeRecordItem SendingToPrisonCriminal => Instance[(short)925];

		public static LifeRecordItem SentToPrisonTaiwu => Instance[(short)926];

		public static LifeRecordItem SentToPrisonCriminal => Instance[(short)927];

		public static LifeRecordItem CatchCriminalsWinTaiwu => Instance[(short)928];

		public static LifeRecordItem CatchCriminalsWinCriminal => Instance[(short)929];

		public static LifeRecordItem CatchCriminalsFailedTaiwu => Instance[(short)930];

		public static LifeRecordItem CatchCriminalsFailedCriminal => Instance[(short)931];

		public static LifeRecordItem BuyHandOverTheCriminalCaptorByExp => Instance[(short)932];

		public static LifeRecordItem BuyHandOverTheCriminalTaiwuByExp => Instance[(short)933];

		public static LifeRecordItem SendingToPrison1TaiwuByExp => Instance[(short)934];

		public static LifeRecordItem VillagerMigrateResources => Instance[(short)935];

		public static LifeRecordItem VillagerCookingIngredient => Instance[(short)936];

		public static LifeRecordItem VillagerMakingItem => Instance[(short)937];

		public static LifeRecordItem VillagerRepairItem0 => Instance[(short)938];

		public static LifeRecordItem VillagerRepairItem1 => Instance[(short)939];

		public static LifeRecordItem VillagerDisassembleItem0 => Instance[(short)940];

		public static LifeRecordItem VillagerDisassembleItem1 => Instance[(short)941];

		public static LifeRecordItem VillagerRefiningMedicine => Instance[(short)942];

		public static LifeRecordItem VillagerDetoxify0 => Instance[(short)943];

		public static LifeRecordItem VillagerDetoxify1 => Instance[(short)944];

		public static LifeRecordItem VillagerEnvenomedItem => Instance[(short)945];

		public static LifeRecordItem VillagerSoldItem => Instance[(short)946];

		public static LifeRecordItem VillagerBuyItem => Instance[(short)947];

		public static LifeRecordItem VillagerSeverEnemy => Instance[(short)948];

		public static LifeRecordItem VillagerEmotionUp => Instance[(short)949];

		public static LifeRecordItem VillagerMakeFriends => Instance[(short)950];

		public static LifeRecordItem VillagerGetMarried => Instance[(short)951];

		public static LifeRecordItem VillagerBecomeBrothers => Instance[(short)952];

		public static LifeRecordItem VillagerAdopt => Instance[(short)953];

		public static LifeRecordItem VillagerTreatment0 => Instance[(short)954];

		public static LifeRecordItem VillagerTreatment1 => Instance[(short)955];

		public static LifeRecordItem VillagerBeTreatment0 => Instance[(short)956];

		public static LifeRecordItem VillagerBeTreatment1 => Instance[(short)957];

		public static LifeRecordItem XiangshuInfectedPrisonTaiwuVillage => Instance[(short)958];

		public static LifeRecordItem XiangshuInfectedPrisonSettlement => Instance[(short)959];

		public static LifeRecordItem VillagerBeRepairItem1 => Instance[(short)960];

		public static LifeRecordItem TaiwuVillagerTakeItem => Instance[(short)961];

		public static LifeRecordItem TaiwuVillagerStorageItem => Instance[(short)962];

		public static LifeRecordItem TaiwuVillagerStorageResources => Instance[(short)963];

		public static LifeRecordItem TaiwuVillagerTakeResources => Instance[(short)964];

		public static LifeRecordItem LiteratiEntertainingUp => Instance[(short)965];

		public static LifeRecordItem LiteratiEntertainingDown => Instance[(short)966];

		public static LifeRecordItem LiteratiBuildingRelationshipUp => Instance[(short)967];

		public static LifeRecordItem LiteratiBuildingRelationshipDown => Instance[(short)968];

		public static LifeRecordItem LiteratiSpreadingInfluenceUp => Instance[(short)969];

		public static LifeRecordItem LiteratiSpreadingInfluenceDown => Instance[(short)970];

		public static LifeRecordItem SwordTombKeeperBuildingRelationshipUp => Instance[(short)971];

		public static LifeRecordItem SwordTombKeeperBuildingRelationshipDown => Instance[(short)972];

		public static LifeRecordItem SwordTombKeeperSpreadingInfluenceUp => Instance[(short)973];

		public static LifeRecordItem SwordTombKeeperSpreadingInfluenceDown => Instance[(short)974];

		public static LifeRecordItem InquireSwordTomb => Instance[(short)975];

		public static LifeRecordItem GuardingSwordTomb => Instance[(short)976];

		public static LifeRecordItem VillagerPrioritizedActions => Instance[(short)977];

		public static LifeRecordItem VillagerPrioritizedActionsStop => Instance[(short)978];

		public static LifeRecordItem EnvenomedItemOverload => Instance[(short)979];

		public static LifeRecordItem DetoxifyItemOverload => Instance[(short)980];

		public static LifeRecordItem VillagerEnvenomedItemOverload => Instance[(short)981];

		public static LifeRecordItem VillagerDetoxifyItemOverload => Instance[(short)982];

		public static LifeRecordItem VillagerCookingIngredientFailed0 => Instance[(short)983];

		public static LifeRecordItem VillagerCookingIngredientFailed1 => Instance[(short)984];

		public static LifeRecordItem VillagerMakingItemFailed0 => Instance[(short)985];

		public static LifeRecordItem VillagerMakingItemFailed1 => Instance[(short)986];

		public static LifeRecordItem VillagerRepairFailed => Instance[(short)987];

		public static LifeRecordItem VillagerDisassembleItemFailed => Instance[(short)988];

		public static LifeRecordItem VillagerRefiningMedicineFailed0 => Instance[(short)989];

		public static LifeRecordItem VillagerRefiningMedicineFailed1 => Instance[(short)990];

		public static LifeRecordItem VillagerAddPoisonToItemFailed => Instance[(short)991];

		public static LifeRecordItem VillagerDetoxItemFailed => Instance[(short)992];

		public static LifeRecordItem VillagerDistanceFailed0 => Instance[(short)993];

		public static LifeRecordItem VillagerDistanceFailed1 => Instance[(short)994];

		public static LifeRecordItem VillagerDistanceFailed2 => Instance[(short)995];

		public static LifeRecordItem VillagerAttainmentsFailed => Instance[(short)996];

		public static LifeRecordItem TaiwuPunishmentTongyong => Instance[(short)997];

		public static LifeRecordItem TaiwuPunishmentShaolin => Instance[(short)998];

		public static LifeRecordItem TaiwuPunishmentEmei => Instance[(short)999];

		public static LifeRecordItem TaiwuPunishmentBaihua => Instance[(short)1000];

		public static LifeRecordItem TaiwuPunishmentWudang => Instance[(short)1001];

		public static LifeRecordItem TaiwuPunishmentYuanshan => Instance[(short)1002];

		public static LifeRecordItem TaiwuPunishmentShingXiang => Instance[(short)1003];

		public static LifeRecordItem TaiwuPunishmentRanShan => Instance[(short)1004];

		public static LifeRecordItem TaiwuPunishmentXuanNv => Instance[(short)1005];

		public static LifeRecordItem TaiwuPunishmentZhuJian => Instance[(short)1006];

		public static LifeRecordItem TaiwuPunishmentKongSang => Instance[(short)1007];

		public static LifeRecordItem TaiwuPunishmentJinGang => Instance[(short)1008];

		public static LifeRecordItem TaiwuPunishmentWuXian => Instance[(short)1009];

		public static LifeRecordItem TaiwuPunishmentJieQing => Instance[(short)1010];

		public static LifeRecordItem TaiwuPunishmentFuLong => Instance[(short)1011];

		public static LifeRecordItem TaiwuPunishmentXueHou => Instance[(short)1012];

		public static LifeRecordItem SectPunishLevel5Expel => Instance[(short)1013];

		public static LifeRecordItem BeImplicatedSectPunishLevel5New => Instance[(short)1014];

		public static LifeRecordItem BeImplicatedSectPunishLevel5Expel => Instance[(short)1015];

		public static LifeRecordItem ResistArrestIntrudePrisonCancelSupportMakeEnemyNpcGuard => Instance[(short)1016];

		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonCancelSupportMakeEnemyTaiwuWanted => Instance[(short)1017];

		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonCancelSupportNpcGuard => Instance[(short)1018];

		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonCancelSupportTaiwuWanted => Instance[(short)1019];

		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersNpcGuard => Instance[(short)1020];

		public static LifeRecordItem ResistArresPrisonBreakIntrudePrisonMakeEnemyOthersTaiwuWanted => Instance[(short)1021];

		public static LifeRecordItem ForgiveForCivilianSkill => Instance[(short)1022];

		public static LifeRecordItem BeggarEatSomeoneFood => Instance[(short)1023];

		public static LifeRecordItem SomeoneFoodEatedByBeggar => Instance[(short)1024];

		public static LifeRecordItem AristocratReleasePrisoner => Instance[(short)1025];

		public static LifeRecordItem PrisonerBeReleaseByAristocrat => Instance[(short)1026];

		public static LifeRecordItem JieQingPunishmentAssassinSetOut => Instance[(short)1027];

		public static LifeRecordItem JieQingPunishmentAssassinSucceed => Instance[(short)1028];

		public static LifeRecordItem JieQingPunishmentAssassinBeSucceed => Instance[(short)1029];

		public static LifeRecordItem JieQingPunishmentAssassinFailed => Instance[(short)1030];

		public static LifeRecordItem JieQingPunishmentAssassinBeFailed => Instance[(short)1031];

		public static LifeRecordItem JieQingPunishmentAssassinGiveUp => Instance[(short)1032];

		public static LifeRecordItem ExociseXiangshuInfectionVictoryInCombatDie => Instance[(short)1033];

		public static LifeRecordItem BecomeExociseXiangshuInfectionVictoryInCombatDie => Instance[(short)1034];

		public static LifeRecordItem ArrestFailedTaiwu => Instance[(short)1035];

		public static LifeRecordItem ArrestedSuccessfullyTaiwu => Instance[(short)1036];

		public static LifeRecordItem LifeSkillBattleLoseAndTheArrestFailedCaptor => Instance[(short)1037];

		public static LifeRecordItem LifeSkillBattleWinAndAvoidArrestTaiwu => Instance[(short)1038];

		public static LifeRecordItem LifeSkillBattleWinAndSuccessfulArrestCaptor => Instance[(short)1039];

		public static LifeRecordItem LifeSkillBattleLoseAndWasArrestedTaiwu => Instance[(short)1040];

		public static LifeRecordItem FailedArrestForBriberyCaptorByAuthority => Instance[(short)1041];

		public static LifeRecordItem BribeSucceededInAvoidingArrestTaiwuByAuthority => Instance[(short)1042];

		public static LifeRecordItem FailedArrestForBriberyCaptorByExp => Instance[(short)1043];

		public static LifeRecordItem BribeSucceededInAvoidingArrestTaiwuByExp => Instance[(short)1044];

		public static LifeRecordItem FailedArrestForBriberyCaptorByMoney => Instance[(short)1045];

		public static LifeRecordItem BribeSucceededInAvoidingArrestTaiwuByMoney => Instance[(short)1046];

		public static LifeRecordItem SubmitToCaptureMeeklyTaiwu => Instance[(short)1047];

		public static LifeRecordItem SubmitToCaptureMeeklyCaptor => Instance[(short)1048];

		public static LifeRecordItem NormalInformationChangeProfession => Instance[(short)1049];

		public static LifeRecordItem FeedTheAnimal => Instance[(short)1050];

		public static LifeRecordItem ProfessionDoctorLifeTransition => Instance[(short)1051];

		public static LifeRecordItem ProfessionDoctorLifeTransitionTaiwu => Instance[(short)1052];

		public static LifeRecordItem CombatSkillKeyPointComprehensionByExp => Instance[(short)1053];

		public static LifeRecordItem CombatSkillKeyPointComprehensionByItems => Instance[(short)1054];

		public static LifeRecordItem CombatSkillKeyPointComprehensionByLoveRelationship => Instance[(short)1055];

		public static LifeRecordItem CombatSkillKeyPointComprehensionByHatredRelationship => Instance[(short)1056];

		public static LifeRecordItem SpiritualDebtKongsangPoisoned => Instance[(short)1057];

		public static LifeRecordItem MartialArtistSkill3NPCItemDropCaseA => Instance[(short)1058];

		public static LifeRecordItem MartialArtistSkill3NPCItemDropCaseB => Instance[(short)1059];

		public static LifeRecordItem SectPunishElopeSucceedJust => Instance[(short)1060];

		public static LifeRecordItem SectPunishElopeSucceedKind => Instance[(short)1061];

		public static LifeRecordItem SectPunishElopeSucceedEven => Instance[(short)1062];

		public static LifeRecordItem SectPunishElopeSucceed => Instance[(short)1063];

		public static LifeRecordItem VillagerGetRefineItem => Instance[(short)1064];

		public static LifeRecordItem VillagerUpgradeRefineItem => Instance[(short)1065];

		public static LifeRecordItem VillagerTreatmentTaiwu => Instance[(short)1066];

		public static LifeRecordItem VillagerReduceXiangshuInfect => Instance[(short)1067];

		public static LifeRecordItem VillagerEarnMoney => Instance[(short)1068];

		public static LifeRecordItem VillagerBeEarnedMoney => Instance[(short)1069];

		public static LifeRecordItem VillagerBeSoldItem => Instance[(short)1070];

		public static LifeRecordItem VillagerBePurchasedItem => Instance[(short)1071];

		public static LifeRecordItem VillagerGetMerchantFavorability => Instance[(short)1072];

		public static LifeRecordItem VillagerGetMerchantFavorabilityTaiwu => Instance[(short)1073];

		public static LifeRecordItem LiteratiBeEntertainedUp => Instance[(short)1074];

		public static LifeRecordItem LiteratiBeEntertainedDown => Instance[(short)1075];

		public static LifeRecordItem LiteratiSpreadingInfluenceCultureUp => Instance[(short)1076];

		public static LifeRecordItem LiteratiSpreadingInfluenceCultureDown => Instance[(short)1077];

		public static LifeRecordItem LiteratiSpreadingInfluenceSafetyUp => Instance[(short)1078];

		public static LifeRecordItem LiteratiSpreadingInfluenceSafetyDown => Instance[(short)1079];

		public static LifeRecordItem LiteratiConnectRelationshipUp => Instance[(short)1080];

		public static LifeRecordItem LiteratiConnectRelationshipDown => Instance[(short)1081];

		public static LifeRecordItem LiteratiConnectRelationshipUpTaiwu => Instance[(short)1082];

		public static LifeRecordItem LiteratiConnectRelationshipDownTaiwu => Instance[(short)1083];

		public static LifeRecordItem LiteratiBeConnectedRelationshipUp => Instance[(short)1084];

		public static LifeRecordItem LiteratiBeConnectedRelationshipDown => Instance[(short)1085];

		public static LifeRecordItem GuardingSwordTombXiangshuInfectUp => Instance[(short)1086];

		public static LifeRecordItem GuardingSwordTombSucceed => Instance[(short)1087];

		public static LifeRecordItem VillagerMakeEnemy => Instance[(short)1088];

		public static LifeRecordItem VillagerConfessLoveSucceed => Instance[(short)1089];

		public static LifeRecordItem OrderProduct => Instance[(short)1090];

		public static LifeRecordItem ReceiveProduct => Instance[(short)1091];

		public static LifeRecordItem BeOrderProduct => Instance[(short)1092];

		public static LifeRecordItem BeReceiveProduct => Instance[(short)1093];

		public static LifeRecordItem CaptureOrder => Instance[(short)1094];

		public static LifeRecordItem BeCaptureOrder => Instance[(short)1095];

		public static LifeRecordItem CaptureOrderIntermediator => Instance[(short)1096];

		public static LifeRecordItem OrderProductForOthers => Instance[(short)1097];

		public static LifeRecordItem BeOrderProductForOthers => Instance[(short)1098];

		public static LifeRecordItem DeliveredOrderProduct => Instance[(short)1099];

		public static LifeRecordItem BeDeliveredOrderProduct => Instance[(short)1100];

		public static LifeRecordItem AcquisitionDiscard => Instance[(short)1101];

		public static LifeRecordItem ShopBuildingBaseDevelopLifeSkill => Instance[(short)1102];

		public static LifeRecordItem ShopBuildingBaseDevelopCombatSkill => Instance[(short)1103];

		public static LifeRecordItem ShopBuildingPersonalityDevelopLifeSkill => Instance[(short)1104];

		public static LifeRecordItem ShopBuildingPersonalityDevelopCombatSkill => Instance[(short)1105];

		public static LifeRecordItem ShopBuildingLeaderDevelopLifeSkill => Instance[(short)1106];

		public static LifeRecordItem ShopBuildingLeaderDevelopCombatSkill => Instance[(short)1107];

		public static LifeRecordItem ShopBuildingLearnLifeSkill => Instance[(short)1108];

		public static LifeRecordItem ShopBuildingLearnCombatSkill => Instance[(short)1109];

		public static LifeRecordItem JoinTaiwuVillageAfterTaiwuVillageStoneClaimed => Instance[(short)1110];

		public static LifeRecordItem TaiwuVillagerFinishedReading => Instance[(short)1111];

		public static LifeRecordItem TaiwuVillagerSalaryReceived => Instance[(short)1112];

		public static LifeRecordItem ChangeGradeDrop => Instance[(short)1113];

		public static LifeRecordItem FarmerCollectMaterial => Instance[(short)1114];

		public static LifeRecordItem JoinOrganization => Instance[(short)1115];

		public static LifeRecordItem BreakAwayOrganization => Instance[(short)1116];

		public static LifeRecordItem ChangeOrganization => Instance[(short)1117];

		public static LifeRecordItem VillagerFavorabilityUp => Instance[(short)1118];

		public static LifeRecordItem VillagerFavorabilityDown => Instance[(short)1119];

		public static LifeRecordItem VillagerFavorabilityUpPerson => Instance[(short)1120];

		public static LifeRecordItem VillagerFavorabilityDownPerson => Instance[(short)1121];

		public static LifeRecordItem TeamUpProtection => Instance[(short)1122];

		public static LifeRecordItem TeamUpRescue => Instance[(short)1123];

		public static LifeRecordItem TeamUpMourn => Instance[(short)1124];

		public static LifeRecordItem TeamUpVisitFriendOrFamily => Instance[(short)1125];

		public static LifeRecordItem TeamUpFindTreasure => Instance[(short)1126];

		public static LifeRecordItem TeamUpFindSpecialMaterial => Instance[(short)1127];

		public static LifeRecordItem TeamUpTakeRevenge => Instance[(short)1128];

		public static LifeRecordItem TeamUpContestForLegendaryBook => Instance[(short)1129];

		public static LifeRecordItem TeamUpEscapeFromPrison => Instance[(short)1130];

		public static LifeRecordItem TeamUpSeekAsylum => Instance[(short)1131];

		public static LifeRecordItem GetInfected => Instance[(short)1132];

		public static LifeRecordItem DieByInfected => Instance[(short)1133];

		public static LifeRecordItem InheritLegacy => Instance[(short)1134];

		public static LifeRecordItem Banquet_1 => Instance[(short)1135];

		public static LifeRecordItem Banquet_2 => Instance[(short)1136];

		public static LifeRecordItem Banquet_3 => Instance[(short)1137];

		public static LifeRecordItem Banquet_4 => Instance[(short)1138];

		public static LifeRecordItem Banquet_5 => Instance[(short)1139];

		public static LifeRecordItem Banquet_6 => Instance[(short)1140];

		public static LifeRecordItem Banquet_7 => Instance[(short)1141];

		public static LifeRecordItem Banquet_8 => Instance[(short)1142];

		public static LifeRecordItem Banquet_9 => Instance[(short)1143];

		public static LifeRecordItem Banquet_10 => Instance[(short)1144];

		public static LifeRecordItem SectMainStoryWudangInjured => Instance[(short)1145];

		public static LifeRecordItem ExtendDarkAshTime => Instance[(short)1146];

		public static LifeRecordItem AdoreInMarriage => Instance[(short)1147];

		public static LifeRecordItem SameAreaDistantMarriage => Instance[(short)1148];

		public static LifeRecordItem SameStateDistantMarriage => Instance[(short)1149];

		public static LifeRecordItem DifferentStateDistantMarriage => Instance[(short)1150];

		public static LifeRecordItem GoToOuterWorlds => Instance[(short)1151];

		public static LifeRecordItem BackFromOuterWorlds => Instance[(short)1152];

		public static LifeRecordItem SectMainStoryXuehouJixiDrainNeili => Instance[(short)1153];

		public static LifeRecordItem SectMainStoryXuehouTaiwuTransferFiveElements => Instance[(short)1154];

		public static LifeRecordItem AlertnessUpBySecretInformation => Instance[(short)1155];

		public static LifeRecordItem AlertnessDownBySecretInformation => Instance[(short)1156];

		public static LifeRecordItem ConsummateLevelIncreased => Instance[(short)1157];

		public static LifeRecordItem CombatSkillQualificationGrowthGuaranteed => Instance[(short)1158];

		public static LifeRecordItem CombatSkillQualificationGrowthPersonality => Instance[(short)1159];

		public static LifeRecordItem CombatSkillQualificationGrowthMentor => Instance[(short)1160];

		public static LifeRecordItem LifeSkillQualificationGrowthGuaranteed => Instance[(short)1161];

		public static LifeRecordItem LifeSkillQualificationGrowthPersonality => Instance[(short)1162];

		public static LifeRecordItem LifeSkillQualificationGrowthMentor => Instance[(short)1163];

		public static LifeRecordItem IdentityActionHelpCivilians => Instance[(short)1164];

		public static LifeRecordItem IdentityActionHelpCiviliansTarget => Instance[(short)1205];

		public static LifeRecordItem IdentityActionFightHeretics => Instance[(short)1165];

		public static LifeRecordItem IdentityActionFightHereticsTarget => Instance[(short)1206];

		public static LifeRecordItem IdentityActionShaolin0 => Instance[(short)1166];

		public static LifeRecordItem IdentityActionShaolin0Target => Instance[(short)1207];

		public static LifeRecordItem IdentityActionShaolin1 => Instance[(short)1167];

		public static LifeRecordItem IdentityActionShaolin2 => Instance[(short)1168];

		public static LifeRecordItem IdentityActionShaolin2Target => Instance[(short)1208];

		public static LifeRecordItem IdentityActionShaolin3 => Instance[(short)1169];

		public static LifeRecordItem IdentityActionShaolin4 => Instance[(short)1170];

		public static LifeRecordItem IdentityActionShaolin4Target => Instance[(short)1375];

		public static LifeRecordItem IdentityActionShaolin5 => Instance[(short)1171];

		public static LifeRecordItem IdentityActionShaolin5Target => Instance[(short)1376];

		public static LifeRecordItem IdentityActionShaolin6 => Instance[(short)1172];

		public static LifeRecordItem IdentityActionEmei0 => Instance[(short)1173];

		public static LifeRecordItem IdentityActionEmei0Target => Instance[(short)1380];

		public static LifeRecordItem IdentityActionEmei1 => Instance[(short)1174];

		public static LifeRecordItem IdentityActionEmei4 => Instance[(short)1175];

		public static LifeRecordItem IdentityActionEmei4Target => Instance[(short)1209];

		public static LifeRecordItem IdentityActionEmei5 => Instance[(short)1176];

		public static LifeRecordItem IdentityActionEmei6 => Instance[(short)1177];

		public static LifeRecordItem IdentityActionEmei6Target => Instance[(short)1210];

		public static LifeRecordItem IdentityActionBaihua0 => Instance[(short)1178];

		public static LifeRecordItem IdentityActionBaihua0Target => Instance[(short)1211];

		public static LifeRecordItem IdentityActionBaihua1 => Instance[(short)1179];

		public static LifeRecordItem IdentityActionBaihua2 => Instance[(short)1180];

		public static LifeRecordItem IdentityActionBaihua3 => Instance[(short)1181];

		public static LifeRecordItem IdentityActionBaihua3Target => Instance[(short)1212];

		public static LifeRecordItem IdentityActionBaihua5 => Instance[(short)1183];

		public static LifeRecordItem IdentityActionBaihua5Target => Instance[(short)1213];

		public static LifeRecordItem IdentityActionWudang5 => Instance[(short)1188];

		public static LifeRecordItem IdentityActionYuanshan1 => Instance[(short)1191];

		public static LifeRecordItem IdentityActionYuanshan1Target => Instance[(short)1218];

		public static LifeRecordItem IdentityActionYuanshan3 => Instance[(short)1193];

		public static LifeRecordItem IdentityActionYuanshan3Target => Instance[(short)1219];

		public static LifeRecordItem IdentityActionYuanshan6 => Instance[(short)1195];

		public static LifeRecordItem IdentityActionYuanshan6Target => Instance[(short)1384];

		public static LifeRecordItem IdentityActionShixiang0 => Instance[(short)1196];

		public static LifeRecordItem IdentityActionShixiang1 => Instance[(short)1197];

		public static LifeRecordItem IdentityActionShixiang2 => Instance[(short)1198];

		public static LifeRecordItem IdentityActionShixiang3 => Instance[(short)1199];

		public static LifeRecordItem IdentityActionShixiang4 => Instance[(short)1200];

		public static LifeRecordItem IdentityActionShixiang5 => Instance[(short)1201];

		public static LifeRecordItem IdentityActionShixiang5Target => Instance[(short)1221];

		public static LifeRecordItem IdentityActionShixiang6 => Instance[(short)1202];

		public static LifeRecordItem IdentityActionShixiang6Target => Instance[(short)1222];

		public static LifeRecordItem IdentityActionShixiang7 => Instance[(short)1203];

		public static LifeRecordItem IdentityActionShixiang7Target => Instance[(short)1223];

		public static LifeRecordItem IdentityActionShixiang8 => Instance[(short)1204];

		public static LifeRecordItem IdentityActionShixiang8Target => Instance[(short)1224];

		public static LifeRecordItem IdentityActionRanShan1 => Instance[(short)1225];

		public static LifeRecordItem IdentityActionRanShan1Target => Instance[(short)1226];

		public static LifeRecordItem IdentityActionRanShan2 => Instance[(short)1227];

		public static LifeRecordItem IdentityActionRanShan2Target => Instance[(short)1228];

		public static LifeRecordItem IdentityActionRanShan3 => Instance[(short)1229];

		public static LifeRecordItem IdentityActionRanShan4 => Instance[(short)1230];

		public static LifeRecordItem IdentityActionRanShan5 => Instance[(short)1231];

		public static LifeRecordItem IdentityActionRanShan6 => Instance[(short)1232];

		public static LifeRecordItem IdentityActionRanShan7 => Instance[(short)1233];

		public static LifeRecordItem IdentityActionRanShan7Target => Instance[(short)1234];

		public static LifeRecordItem IdentityActionRanShan8 => Instance[(short)1235];

		public static LifeRecordItem IdentityActionRanShan8Target => Instance[(short)1236];

		public static LifeRecordItem IdentityActionXuanNv1 => Instance[(short)1237];

		public static LifeRecordItem IdentityActionXuanNv1Target => Instance[(short)1238];

		public static LifeRecordItem IdentityActionXuanNv2 => Instance[(short)1239];

		public static LifeRecordItem IdentityActionXuanNv2Target => Instance[(short)1388];

		public static LifeRecordItem IdentityActionXuanNv3 => Instance[(short)1240];

		public static LifeRecordItem IdentityActionXuanNv3Audience => Instance[(short)1389];

		public static LifeRecordItem IdentityActionXuanNv4 => Instance[(short)1241];

		public static LifeRecordItem IdentityActionXuanNv4Target => Instance[(short)1242];

		public static LifeRecordItem IdentityActionXuanNv5 => Instance[(short)1243];

		public static LifeRecordItem IdentityActionXuanNv5Target => Instance[(short)1244];

		public static LifeRecordItem IdentityActionXuanNv6 => Instance[(short)1245];

		public static LifeRecordItem IdentityActionXuanNv7 => Instance[(short)1246];

		public static LifeRecordItem IdentityActionZhuJian1 => Instance[(short)1247];

		public static LifeRecordItem IdentityActionZhuJian1Target => Instance[(short)1248];

		public static LifeRecordItem IdentityActionZhuJian2 => Instance[(short)1249];

		public static LifeRecordItem IdentityActionZhuJian3 => Instance[(short)1250];

		public static LifeRecordItem IdentityActionZhuJian4 => Instance[(short)1251];

		public static LifeRecordItem IdentityActionZhuJian5 => Instance[(short)1252];

		public static LifeRecordItem IdentityActionZhuJian8 => Instance[(short)1377];

		public static LifeRecordItem IdentityActionKongSang1 => Instance[(short)1256];

		public static LifeRecordItem IdentityActionKongSang1Target => Instance[(short)1257];

		public static LifeRecordItem IdentityActionKongSang2 => Instance[(short)1258];

		public static LifeRecordItem IdentityActionKongSang3 => Instance[(short)1259];

		public static LifeRecordItem IdentityActionKongSang4A => Instance[(short)1260];

		public static LifeRecordItem IdentityActionKongSang4B => Instance[(short)1261];

		public static LifeRecordItem IdentityActionKongSang5A => Instance[(short)1262];

		public static LifeRecordItem IdentityActionKongSang5B => Instance[(short)1263];

		public static LifeRecordItem IdentityActionKongSang6 => Instance[(short)1264];

		public static LifeRecordItem IdentityActionKongSang6Target => Instance[(short)1265];

		public static LifeRecordItem IdentityActionKongSang7 => Instance[(short)1266];

		public static LifeRecordItem IdentityActionKongSang7Target => Instance[(short)1267];

		public static LifeRecordItem IdentityActionKongSang8A => Instance[(short)1268];

		public static LifeRecordItem IdentityActionKongSang8ATarget => Instance[(short)1390];

		public static LifeRecordItem IdentityActionKongSang8B => Instance[(short)1269];

		public static LifeRecordItem IdentityActionKongSang9A => Instance[(short)1270];

		public static LifeRecordItem IdentityActionKongSang9ATarget => Instance[(short)1391];

		public static LifeRecordItem IdentityActionKongSang9B => Instance[(short)1271];

		public static LifeRecordItem IdentityActionKongSang10 => Instance[(short)1272];

		public static LifeRecordItem IdentityActionKongSang10Target => Instance[(short)1273];

		public static LifeRecordItem IdentityActionJingGangZong2Steal => Instance[(short)1277];

		public static LifeRecordItem IdentityActionJingGangZong2Rob => Instance[(short)1278];

		public static LifeRecordItem IdentityActionJingGangZong2Scam => Instance[(short)1279];

		public static LifeRecordItem IdentityActionJingGangZong3 => Instance[(short)1280];

		public static LifeRecordItem IdentityActionJingGangZong4 => Instance[(short)1281];

		public static LifeRecordItem IdentityActionJingGangZong4Target => Instance[(short)1282];

		public static LifeRecordItem IdentityActionJingGangZong5 => Instance[(short)1283];

		public static LifeRecordItem IdentityActionJingGangZong5Target => Instance[(short)1284];

		public static LifeRecordItem IdentityActionJingGangZong6 => Instance[(short)1285];

		public static LifeRecordItem IdentityActionJingGangZong6Target => Instance[(short)1286];

		public static LifeRecordItem IdentityActionJingGangZong7 => Instance[(short)1287];

		public static LifeRecordItem IdentityActionWuXian1 => Instance[(short)1288];

		public static LifeRecordItem IdentityActionWuXian2 => Instance[(short)1289];

		public static LifeRecordItem IdentityActionWuXian2Target => Instance[(short)1290];

		public static LifeRecordItem IdentityActionWuXian3 => Instance[(short)1291];

		public static LifeRecordItem IdentityActionWuXian3Target => Instance[(short)1292];

		public static LifeRecordItem IdentityActionWuXian4 => Instance[(short)1293];

		public static LifeRecordItem IdentityActionWuXian4Target => Instance[(short)1378];

		public static LifeRecordItem IdentityActionWuXian5 => Instance[(short)1294];

		public static LifeRecordItem IdentityActionWuXian6 => Instance[(short)1295];

		public static LifeRecordItem IdentityActionJieQing1A => Instance[(short)1296];

		public static LifeRecordItem IdentityActionJieQing1B => Instance[(short)1297];

		public static LifeRecordItem IdentityActionJieQing2 => Instance[(short)1298];

		public static LifeRecordItem IdentityActionJieQing2Target => Instance[(short)1392];

		public static LifeRecordItem IdentityActionJieQing3 => Instance[(short)1299];

		public static LifeRecordItem IdentityActionJieQing4 => Instance[(short)1300];

		public static LifeRecordItem IdentityActionJieQing5 => Instance[(short)1301];

		public static LifeRecordItem IdentityActionJieQing6A => Instance[(short)1302];

		public static LifeRecordItem IdentityActionJieQing6B => Instance[(short)1303];

		public static LifeRecordItem IdentityActionJieQing7 => Instance[(short)1304];

		public static LifeRecordItem IdentityActionJieQing7Target => Instance[(short)1381];

		public static LifeRecordItem IdentityActionJieQing8 => Instance[(short)1305];

		public static LifeRecordItem IdentityActionFuLong2 => Instance[(short)1308];

		public static LifeRecordItem IdentityActionFuLong6 => Instance[(short)1314];

		public static LifeRecordItem IdentityActionXveHou2StealA => Instance[(short)1317];

		public static LifeRecordItem IdentityActionXveHou2StealB => Instance[(short)1318];

		public static LifeRecordItem IdentityActionXveHou3RobA => Instance[(short)1319];

		public static LifeRecordItem IdentityActionXveHou3RobB => Instance[(short)1320];

		public static LifeRecordItem IdentityActionXveHou4ScamA => Instance[(short)1321];

		public static LifeRecordItem IdentityActionXveHou4ScamB => Instance[(short)1322];

		public static LifeRecordItem IdentityActionXveHou5 => Instance[(short)1323];

		public static LifeRecordItem IdentityActionXveHou6 => Instance[(short)1324];

		public static LifeRecordItem IdentityActionXveHou7 => Instance[(short)1325];

		public static LifeRecordItem IdentityActionXveHou7Target => Instance[(short)1326];

		public static LifeRecordItem IdentityActionChengZhen1 => Instance[(short)1330];

		public static LifeRecordItem IdentityActionChengZhen1TargetA => Instance[(short)1331];

		public static LifeRecordItem IdentityActionChengZhen1TargetB => Instance[(short)1332];

		public static LifeRecordItem IdentityActionChengZhen2 => Instance[(short)1333];

		public static LifeRecordItem IdentityActionChengZhen2TargetA => Instance[(short)1334];

		public static LifeRecordItem IdentityActionChengZhen2TargetB => Instance[(short)1335];

		public static LifeRecordItem IdentityActionChengZhen3 => Instance[(short)1336];

		public static LifeRecordItem IdentityActionChengZhen4 => Instance[(short)1337];

		public static LifeRecordItem IdentityActionChengZhen5 => Instance[(short)1338];

		public static LifeRecordItem IdentityActionChengZhen6 => Instance[(short)1339];

		public static LifeRecordItem IdentityActionChengZhen6Target => Instance[(short)1340];

		public static LifeRecordItem IdentityActionChengZhen7 => Instance[(short)1341];

		public static LifeRecordItem IdentityActionChengZhen7Target => Instance[(short)1342];

		public static LifeRecordItem IdentityActionChengZhen8 => Instance[(short)1343];

		public static LifeRecordItem IdentityActionChengZhen8Target => Instance[(short)1344];

		public static LifeRecordItem IdentityActionChengZhen9 => Instance[(short)1345];

		public static LifeRecordItem IdentityActionChengZhen9Target => Instance[(short)1346];

		public static LifeRecordItem IdentityActionChengZhen10 => Instance[(short)1347];

		public static LifeRecordItem IdentityActionChengZhen10TargetA => Instance[(short)1348];

		public static LifeRecordItem IdentityActionChengZhen10TargetB => Instance[(short)1349];

		public static LifeRecordItem IdentityActionChengZhen11 => Instance[(short)1350];

		public static LifeRecordItem IdentityActionChengZhen12 => Instance[(short)1351];

		public static LifeRecordItem IdentityActionChengZhen13 => Instance[(short)1352];

		public static LifeRecordItem IdentityActionChengZhen13Target => Instance[(short)1353];

		public static LifeRecordItem IdentityActionChengZhen14 => Instance[(short)1354];

		public static LifeRecordItem IdentityActionChengZhen15 => Instance[(short)1355];

		public static LifeRecordItem IdentityActionChengZhen16 => Instance[(short)1356];

		public static LifeRecordItem IdentityActionChengZhen16Target => Instance[(short)1357];

		public static LifeRecordItem IdentityActionChengZhen17 => Instance[(short)1358];

		public static LifeRecordItem IdentityActionChengZhen18 => Instance[(short)1359];

		public static LifeRecordItem IdentityActionChengZhen19 => Instance[(short)1360];

		public static LifeRecordItem IdentityActionChengZhen20 => Instance[(short)1361];

		public static LifeRecordItem IdentityActionChengZhen21 => Instance[(short)1362];

		public static LifeRecordItem IdentityActionChengZhen22 => Instance[(short)1363];

		public static LifeRecordItem BehaviorTypeAction1 => Instance[(short)1364];

		public static LifeRecordItem BehaviorTypeAction1Target => Instance[(short)1402];

		public static LifeRecordItem BehaviorTypeAction2 => Instance[(short)1365];

		public static LifeRecordItem BehaviorTypeAction2Target => Instance[(short)1403];

		public static LifeRecordItem BehaviorTypeAction3 => Instance[(short)1366];

		public static LifeRecordItem BehaviorTypeAction4 => Instance[(short)1367];

		public static LifeRecordItem BehaviorTypeAction5 => Instance[(short)1368];

		public static LifeRecordItem BehaviorTypeAction6 => Instance[(short)1369];

		public static LifeRecordItem CherryPickResource => Instance[(short)1370];

		public static LifeRecordItem IdentityActionCaptureCricket1 => Instance[(short)1373];

		public static LifeRecordItem DLCLoongRidingEffectBaxia02 => Instance[(short)1374];

		public static LifeRecordItem WeiQiBadOther => Instance[(short)1386];

		public static LifeRecordItem WeiQiGoodOther => Instance[(short)1387];

		public static LifeRecordItem TwelveImmortalsEffectAdored => Instance[(short)1393];

		public static LifeRecordItem TwelveImmortalsEffectEnemy => Instance[(short)1394];

		public static LifeRecordItem TwelveImmortalsEffectSuxia => Instance[(short)1395];

		public static LifeRecordItem TwelveImmortalsEffectBecomeMoTian => Instance[(short)1396];

		public static LifeRecordItem TwelveImmortalsEffectBeAttackByMoTian => Instance[(short)1397];

		public static LifeRecordItem TwelveImmortalsEffectBeAttackByJiao => Instance[(short)1398];

		public static LifeRecordItem TwelveImmortalsEffectBeAttackByMirror => Instance[(short)1399];

		public static LifeRecordItem TwelveImmortalsEffectBeAttackBySkeletonDemon => Instance[(short)1400];

		public static LifeRecordItem DemonHeirRevenge => Instance[(short)1404];

		public static LifeRecordItem DefeatDemonHeir => Instance[(short)1405];

		public static LifeRecordItem BeDefetedByDemonHeir => Instance[(short)1406];

		public static LifeRecordItem DemonHeirDefeatTaiwu => Instance[(short)1407];

		public static LifeRecordItem DemonHeirRebirth1 => Instance[(short)1408];

		public static LifeRecordItem DemonHeirRebirth2 => Instance[(short)1409];

		public static LifeRecordItem DLCCricketTurnToCricketForm => Instance[(short)1410];

		public static LifeRecordItem DLCCricketRetranmogrifyToHuman => Instance[(short)1411];

		public static LifeRecordItem DecideToParticipateNewAdventure => Instance[(short)1412];

		public static LifeRecordItem LeaveNewAdventure => Instance[(short)1413];

		public static LifeRecordItem DLCChickenRetranmogrifyToHuman => Instance[(short)1415];

		public static LifeRecordItem DLCChickenTurnToChickenForm => Instance[(short)1416];

		public static LifeRecordItem DLCLoongRetranmogrifyToHuman => Instance[(short)1417];

		public static LifeRecordItem DLCLoongTurnToLoongForm => Instance[(short)1418];

		public static LifeRecordItem XiangshuSkill0NPCEvilCase => Instance[(short)1419];

		public static LifeRecordItem XiangshuSkill0TaiwuEvilCase => Instance[(short)1420];

		public static LifeRecordItem XiangshuSkill1NPCEvilCorruption => Instance[(short)1421];

		public static LifeRecordItem XiangshuSkill1TaiwuEvilCorruption => Instance[(short)1422];

		public static LifeRecordItem XiangshuSkill0NPCItemDropCase => Instance[(short)1423];

		public static LifeRecordItem XiangshuSkill2TaiwuItemDropCase => Instance[(short)1424];

		public static LifeRecordItem RequestHealInjurySucceedByRes => Instance[(short)1425];

		public static LifeRecordItem RequestDetoxPoisonSucceedByRes => Instance[(short)1426];

		public static LifeRecordItem RequestHealthSucceedByRes => Instance[(short)1427];

		public static LifeRecordItem RequestHealDisorderOfQiSucceedByRes => Instance[(short)1428];

		public static LifeRecordItem RequestHealInjuryFailByRes => Instance[(short)1429];

		public static LifeRecordItem RequestDetoxPoisonFailByRes => Instance[(short)1430];

		public static LifeRecordItem RequestHealthFailByRes => Instance[(short)1431];

		public static LifeRecordItem RequestHealDisorderOfQiFailByRes => Instance[(short)1432];

		public static LifeRecordItem AcceptRequestHealInjuryByRes => Instance[(short)1433];

		public static LifeRecordItem AcceptRequestDetoxPoisonByRes => Instance[(short)1434];

		public static LifeRecordItem AcceptRequestHealthByRes => Instance[(short)1435];

		public static LifeRecordItem AcceptRequestHealDisorderOfQiByRes => Instance[(short)1436];

		public static LifeRecordItem RefuseRequestHealInjuryByRes => Instance[(short)1437];

		public static LifeRecordItem RefuseRequestDetoxPoisonByRes => Instance[(short)1438];

		public static LifeRecordItem RefuseRequestHealthByRes => Instance[(short)1439];

		public static LifeRecordItem RefuseRequestHealDisorderOfQiByRes => Instance[(short)1440];
	}

	public static LifeRecord Instance = new LifeRecord();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Desc", "RelatedIds", "TemplateId" };

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
		_dataArray.Add(new LifeRecordItem(0, LocalStringManager.GetConfig("LifeRecord_language", "Name_0"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_0"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1, LocalStringManager.GetConfig("LifeRecord_language", "Name_1"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(2, LocalStringManager.GetConfig("LifeRecord_language", "Name_2"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_2"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(3, LocalStringManager.GetConfig("LifeRecord_language", "Name_3"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_3"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(4, LocalStringManager.GetConfig("LifeRecord_language", "Name_4"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_4"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(5, LocalStringManager.GetConfig("LifeRecord_language", "Name_5"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_5"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short> { 6 }, -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(6, LocalStringManager.GetConfig("LifeRecord_language", "Name_6"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_6"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 5 }, -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(7, LocalStringManager.GetConfig("LifeRecord_language", "Name_7"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_7"), new string[6] { "Location", "Cricket", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(8, LocalStringManager.GetConfig("LifeRecord_language", "Name_8"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_8"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(9, LocalStringManager.GetConfig("LifeRecord_language", "Name_9"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_9"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(10, LocalStringManager.GetConfig("LifeRecord_language", "Name_10"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_10"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(11, LocalStringManager.GetConfig("LifeRecord_language", "Name_11"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_11"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(12, LocalStringManager.GetConfig("LifeRecord_language", "Name_12"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_12"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(13, LocalStringManager.GetConfig("LifeRecord_language", "Name_13"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_13"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(14, LocalStringManager.GetConfig("LifeRecord_language", "Name_14"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_14"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 15 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(15, LocalStringManager.GetConfig("LifeRecord_language", "Name_15"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_15"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 14 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(16, LocalStringManager.GetConfig("LifeRecord_language", "Name_16"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_16"), new string[6] { "Location", "Item", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(17, LocalStringManager.GetConfig("LifeRecord_language", "Name_17"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_17"), new string[6] { "Location", "Item", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(18, LocalStringManager.GetConfig("LifeRecord_language", "Name_18"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_18"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(19, LocalStringManager.GetConfig("LifeRecord_language", "Name_19"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_19"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(20, LocalStringManager.GetConfig("LifeRecord_language", "Name_20"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_20"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(21, LocalStringManager.GetConfig("LifeRecord_language", "Name_21"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_21"), new string[6] { "Location", "LifeSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(22, LocalStringManager.GetConfig("LifeRecord_language", "Name_22"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_22"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(23, LocalStringManager.GetConfig("LifeRecord_language", "Name_23"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_23"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(24, LocalStringManager.GetConfig("LifeRecord_language", "Name_24"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_24"), new string[6] { "Location", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(25, LocalStringManager.GetConfig("LifeRecord_language", "Name_25"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_25"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(26, LocalStringManager.GetConfig("LifeRecord_language", "Name_26"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_26"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 28 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(27, LocalStringManager.GetConfig("LifeRecord_language", "Name_27"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_27"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 29 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(28, LocalStringManager.GetConfig("LifeRecord_language", "Name_28"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_28"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 26 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(29, LocalStringManager.GetConfig("LifeRecord_language", "Name_29"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_29"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 27 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(30, LocalStringManager.GetConfig("LifeRecord_language", "Name_30"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_30"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(31, LocalStringManager.GetConfig("LifeRecord_language", "Name_31"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_31"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 31 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(32, LocalStringManager.GetConfig("LifeRecord_language", "Name_32"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_32"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 34 }, -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(33, LocalStringManager.GetConfig("LifeRecord_language", "Name_33"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_33"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 35 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(34, LocalStringManager.GetConfig("LifeRecord_language", "Name_34"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_34"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 32 }, -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(35, LocalStringManager.GetConfig("LifeRecord_language", "Name_35"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_35"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 33 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(36, LocalStringManager.GetConfig("LifeRecord_language", "Name_36"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_36"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 36 }, -30000, ELifeRecordScoreType.Normal, 30, 15, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(37, LocalStringManager.GetConfig("LifeRecord_language", "Name_37"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_37"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 38 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(38, LocalStringManager.GetConfig("LifeRecord_language", "Name_38"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_38"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 37 }, -30000, ELifeRecordScoreType.Normal, 30, 17, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(39, LocalStringManager.GetConfig("LifeRecord_language", "Name_39"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_39"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 39 }, -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(40, LocalStringManager.GetConfig("LifeRecord_language", "Name_40"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_40"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 41 }, -30000, ELifeRecordScoreType.Normal, 10, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(41, LocalStringManager.GetConfig("LifeRecord_language", "Name_41"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_41"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 40 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(42, LocalStringManager.GetConfig("LifeRecord_language", "Name_42"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_42"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 42 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(43, LocalStringManager.GetConfig("LifeRecord_language", "Name_43"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_43"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 43 }, -30000, ELifeRecordScoreType.Normal, 40, 18, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(44, LocalStringManager.GetConfig("LifeRecord_language", "Name_44"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_44"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 44 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(45, LocalStringManager.GetConfig("LifeRecord_language", "Name_45"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_45"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 45 }, -30000, ELifeRecordScoreType.Normal, 30, 14, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(46, LocalStringManager.GetConfig("LifeRecord_language", "Name_46"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_46"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 48, 49 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(47, LocalStringManager.GetConfig("LifeRecord_language", "Name_47"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_47"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 48, 49 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(48, LocalStringManager.GetConfig("LifeRecord_language", "Name_48"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_48"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 46, 47 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(49, LocalStringManager.GetConfig("LifeRecord_language", "Name_49"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_49"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 46, 47 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(50, LocalStringManager.GetConfig("LifeRecord_language", "Name_50"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_50"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(51, LocalStringManager.GetConfig("LifeRecord_language", "Name_51"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_51"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(52, LocalStringManager.GetConfig("LifeRecord_language", "Name_52"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_52"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(53, LocalStringManager.GetConfig("LifeRecord_language", "Name_53"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_53"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 55 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(54, LocalStringManager.GetConfig("LifeRecord_language", "Name_54"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_54"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 56 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(55, LocalStringManager.GetConfig("LifeRecord_language", "Name_55"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_55"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 53 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(56, LocalStringManager.GetConfig("LifeRecord_language", "Name_56"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_56"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 54 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(57, LocalStringManager.GetConfig("LifeRecord_language", "Name_57"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_57"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(58, LocalStringManager.GetConfig("LifeRecord_language", "Name_58"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_58"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(59, LocalStringManager.GetConfig("LifeRecord_language", "Name_59"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_59"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new LifeRecordItem(60, LocalStringManager.GetConfig("LifeRecord_language", "Name_60"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_60"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(61, LocalStringManager.GetConfig("LifeRecord_language", "Name_61"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_61"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(62, LocalStringManager.GetConfig("LifeRecord_language", "Name_62"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_62"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(63, LocalStringManager.GetConfig("LifeRecord_language", "Name_63"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_63"), new string[6] { "Location", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(64, LocalStringManager.GetConfig("LifeRecord_language", "Name_64"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_64"), new string[6] { "Location", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(65, LocalStringManager.GetConfig("LifeRecord_language", "Name_65"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_65"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(66, LocalStringManager.GetConfig("LifeRecord_language", "Name_66"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_66"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(67, LocalStringManager.GetConfig("LifeRecord_language", "Name_67"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_67"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(68, LocalStringManager.GetConfig("LifeRecord_language", "Name_68"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_68"), new string[6] { "Location", "Settlement", "OrgGrade", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(69, LocalStringManager.GetConfig("LifeRecord_language", "Name_69"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_69"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(70, LocalStringManager.GetConfig("LifeRecord_language", "Name_70"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_70"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(71, LocalStringManager.GetConfig("LifeRecord_language", "Name_71"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_71"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(72, LocalStringManager.GetConfig("LifeRecord_language", "Name_72"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_72"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(73, LocalStringManager.GetConfig("LifeRecord_language", "Name_73"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_73"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(74, LocalStringManager.GetConfig("LifeRecord_language", "Name_74"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_74"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(75, LocalStringManager.GetConfig("LifeRecord_language", "Name_75"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_75"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(76, LocalStringManager.GetConfig("LifeRecord_language", "Name_76"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_76"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(77, LocalStringManager.GetConfig("LifeRecord_language", "Name_77"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_77"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(78, LocalStringManager.GetConfig("LifeRecord_language", "Name_78"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_78"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(79, LocalStringManager.GetConfig("LifeRecord_language", "Name_79"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_79"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(80, LocalStringManager.GetConfig("LifeRecord_language", "Name_80"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_80"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(81, LocalStringManager.GetConfig("LifeRecord_language", "Name_81"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_81"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(82, LocalStringManager.GetConfig("LifeRecord_language", "Name_82"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_82"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(83, LocalStringManager.GetConfig("LifeRecord_language", "Name_83"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_83"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(84, LocalStringManager.GetConfig("LifeRecord_language", "Name_84"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_84"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(85, LocalStringManager.GetConfig("LifeRecord_language", "Name_85"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_85"), new string[6] { "Character", "Location", "CombatType", "", "", "" }, isSourceRecord: true, new List<short> { 86 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(86, LocalStringManager.GetConfig("LifeRecord_language", "Name_86"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_86"), new string[6] { "Character", "Location", "CombatType", "", "", "" }, isSourceRecord: true, new List<short> { 85 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(87, LocalStringManager.GetConfig("LifeRecord_language", "Name_87"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_87"), new string[6] { "Character", "Location", "CombatType", "", "", "" }, isSourceRecord: true, new List<short> { 88 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(88, LocalStringManager.GetConfig("LifeRecord_language", "Name_88"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_88"), new string[6] { "Character", "Location", "CombatType", "", "", "" }, isSourceRecord: true, new List<short> { 87 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(89, LocalStringManager.GetConfig("LifeRecord_language", "Name_89"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_89"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 90 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(90, LocalStringManager.GetConfig("LifeRecord_language", "Name_90"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_90"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 89 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(91, LocalStringManager.GetConfig("LifeRecord_language", "Name_91"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_91"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 712 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(92, LocalStringManager.GetConfig("LifeRecord_language", "Name_92"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_92"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 713 }, -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(93, LocalStringManager.GetConfig("LifeRecord_language", "Name_93"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_93"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 96 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(94, LocalStringManager.GetConfig("LifeRecord_language", "Name_94"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_94"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 97 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(95, LocalStringManager.GetConfig("LifeRecord_language", "Name_95"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_95"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 98 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(96, LocalStringManager.GetConfig("LifeRecord_language", "Name_96"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_96"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 93 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(97, LocalStringManager.GetConfig("LifeRecord_language", "Name_97"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_97"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 94 }, -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(98, LocalStringManager.GetConfig("LifeRecord_language", "Name_98"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_98"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 95 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(99, LocalStringManager.GetConfig("LifeRecord_language", "Name_99"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_99"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(100, LocalStringManager.GetConfig("LifeRecord_language", "Name_100"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_100"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(101, LocalStringManager.GetConfig("LifeRecord_language", "Name_101"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_101"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(102, LocalStringManager.GetConfig("LifeRecord_language", "Name_102"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_102"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 138 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(103, LocalStringManager.GetConfig("LifeRecord_language", "Name_103"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_103"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 139 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(104, LocalStringManager.GetConfig("LifeRecord_language", "Name_104"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_104"), new string[6] { "Character", "Location", "Item", "PoisonType", "", "" }, isSourceRecord: true, new List<short> { 140 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(105, LocalStringManager.GetConfig("LifeRecord_language", "Name_105"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_105"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 141 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(106, LocalStringManager.GetConfig("LifeRecord_language", "Name_106"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_106"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 142 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(107, LocalStringManager.GetConfig("LifeRecord_language", "Name_107"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_107"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 143 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(108, LocalStringManager.GetConfig("LifeRecord_language", "Name_108"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_108"), new string[6] { "Character", "Location", "Item", "Item", "", "" }, isSourceRecord: true, new List<short> { 144 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(109, LocalStringManager.GetConfig("LifeRecord_language", "Name_109"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_109"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 145 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(110, LocalStringManager.GetConfig("LifeRecord_language", "Name_110"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_110"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 146 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(111, LocalStringManager.GetConfig("LifeRecord_language", "Name_111"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_111"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 147 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(112, LocalStringManager.GetConfig("LifeRecord_language", "Name_112"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_112"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 148 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(113, LocalStringManager.GetConfig("LifeRecord_language", "Name_113"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_113"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 149 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(114, LocalStringManager.GetConfig("LifeRecord_language", "Name_114"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_114"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 150 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(115, LocalStringManager.GetConfig("LifeRecord_language", "Name_115"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_115"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 151 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(116, LocalStringManager.GetConfig("LifeRecord_language", "Name_116"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_116"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 152 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(117, LocalStringManager.GetConfig("LifeRecord_language", "Name_117"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_117"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 153 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(118, LocalStringManager.GetConfig("LifeRecord_language", "Name_118"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_118"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 154 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(119, LocalStringManager.GetConfig("LifeRecord_language", "Name_119"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_119"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 155 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new LifeRecordItem(120, LocalStringManager.GetConfig("LifeRecord_language", "Name_120"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_120"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short> { 156 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(121, LocalStringManager.GetConfig("LifeRecord_language", "Name_121"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_121"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 157 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(122, LocalStringManager.GetConfig("LifeRecord_language", "Name_122"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_122"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 158 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(123, LocalStringManager.GetConfig("LifeRecord_language", "Name_123"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_123"), new string[6] { "Character", "Location", "Item", "PoisonType", "", "" }, isSourceRecord: true, new List<short> { 159 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(124, LocalStringManager.GetConfig("LifeRecord_language", "Name_124"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_124"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 160 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(125, LocalStringManager.GetConfig("LifeRecord_language", "Name_125"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_125"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 161 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(126, LocalStringManager.GetConfig("LifeRecord_language", "Name_126"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_126"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 162 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(127, LocalStringManager.GetConfig("LifeRecord_language", "Name_127"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_127"), new string[6] { "Character", "Location", "Item", "Item", "", "" }, isSourceRecord: true, new List<short> { 163 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(128, LocalStringManager.GetConfig("LifeRecord_language", "Name_128"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_128"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 164 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(129, LocalStringManager.GetConfig("LifeRecord_language", "Name_129"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_129"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 165 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(130, LocalStringManager.GetConfig("LifeRecord_language", "Name_130"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_130"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 166 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(131, LocalStringManager.GetConfig("LifeRecord_language", "Name_131"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_131"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 167 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(132, LocalStringManager.GetConfig("LifeRecord_language", "Name_132"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_132"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 168 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(133, LocalStringManager.GetConfig("LifeRecord_language", "Name_133"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_133"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 169 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(134, LocalStringManager.GetConfig("LifeRecord_language", "Name_134"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_134"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 170 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(135, LocalStringManager.GetConfig("LifeRecord_language", "Name_135"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_135"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 171 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(136, LocalStringManager.GetConfig("LifeRecord_language", "Name_136"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_136"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 172 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(137, LocalStringManager.GetConfig("LifeRecord_language", "Name_137"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_137"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short> { 173 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(138, LocalStringManager.GetConfig("LifeRecord_language", "Name_138"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_138"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 102 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(139, LocalStringManager.GetConfig("LifeRecord_language", "Name_139"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_139"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 103 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(140, LocalStringManager.GetConfig("LifeRecord_language", "Name_140"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_140"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 104 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(141, LocalStringManager.GetConfig("LifeRecord_language", "Name_141"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_141"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 105 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(142, LocalStringManager.GetConfig("LifeRecord_language", "Name_142"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_142"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 106 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(143, LocalStringManager.GetConfig("LifeRecord_language", "Name_143"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_143"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 107 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(144, LocalStringManager.GetConfig("LifeRecord_language", "Name_144"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_144"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 108 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(145, LocalStringManager.GetConfig("LifeRecord_language", "Name_145"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_145"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 109 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(146, LocalStringManager.GetConfig("LifeRecord_language", "Name_146"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_146"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 110 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(147, LocalStringManager.GetConfig("LifeRecord_language", "Name_147"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_147"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 111 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(148, LocalStringManager.GetConfig("LifeRecord_language", "Name_148"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_148"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 112 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(149, LocalStringManager.GetConfig("LifeRecord_language", "Name_149"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_149"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 113 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(150, LocalStringManager.GetConfig("LifeRecord_language", "Name_150"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_150"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 114 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(151, LocalStringManager.GetConfig("LifeRecord_language", "Name_151"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_151"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 115 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(152, LocalStringManager.GetConfig("LifeRecord_language", "Name_152"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_152"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 116 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(153, LocalStringManager.GetConfig("LifeRecord_language", "Name_153"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_153"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 117 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(154, LocalStringManager.GetConfig("LifeRecord_language", "Name_154"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_154"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 118 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(155, LocalStringManager.GetConfig("LifeRecord_language", "Name_155"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_155"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 119 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(156, LocalStringManager.GetConfig("LifeRecord_language", "Name_156"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_156"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 120 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(157, LocalStringManager.GetConfig("LifeRecord_language", "Name_157"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_157"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 121 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(158, LocalStringManager.GetConfig("LifeRecord_language", "Name_158"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_158"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 122 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(159, LocalStringManager.GetConfig("LifeRecord_language", "Name_159"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_159"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 123 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(160, LocalStringManager.GetConfig("LifeRecord_language", "Name_160"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_160"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 124 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(161, LocalStringManager.GetConfig("LifeRecord_language", "Name_161"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_161"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 125 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(162, LocalStringManager.GetConfig("LifeRecord_language", "Name_162"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_162"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 126 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(163, LocalStringManager.GetConfig("LifeRecord_language", "Name_163"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_163"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 127 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(164, LocalStringManager.GetConfig("LifeRecord_language", "Name_164"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_164"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 128 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(165, LocalStringManager.GetConfig("LifeRecord_language", "Name_165"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_165"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 129 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(166, LocalStringManager.GetConfig("LifeRecord_language", "Name_166"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_166"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 130 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(167, LocalStringManager.GetConfig("LifeRecord_language", "Name_167"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_167"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 131 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(168, LocalStringManager.GetConfig("LifeRecord_language", "Name_168"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_168"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 132 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(169, LocalStringManager.GetConfig("LifeRecord_language", "Name_169"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_169"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 133 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(170, LocalStringManager.GetConfig("LifeRecord_language", "Name_170"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_170"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 134 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(171, LocalStringManager.GetConfig("LifeRecord_language", "Name_171"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_171"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 135 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(172, LocalStringManager.GetConfig("LifeRecord_language", "Name_172"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_172"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 136 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(173, LocalStringManager.GetConfig("LifeRecord_language", "Name_173"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_173"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 137 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(174, LocalStringManager.GetConfig("LifeRecord_language", "Name_174"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_174"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(175, LocalStringManager.GetConfig("LifeRecord_language", "Name_175"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_175"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(176, LocalStringManager.GetConfig("LifeRecord_language", "Name_176"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_176"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(177, LocalStringManager.GetConfig("LifeRecord_language", "Name_177"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_177"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(178, LocalStringManager.GetConfig("LifeRecord_language", "Name_178"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_178"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 180 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(179, LocalStringManager.GetConfig("LifeRecord_language", "Name_179"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_179"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 180 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new LifeRecordItem(180, LocalStringManager.GetConfig("LifeRecord_language", "Name_180"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_180"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 178, 179 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(181, LocalStringManager.GetConfig("LifeRecord_language", "Name_181"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_181"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(182, LocalStringManager.GetConfig("LifeRecord_language", "Name_182"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_182"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(183, LocalStringManager.GetConfig("LifeRecord_language", "Name_183"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_183"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(184, LocalStringManager.GetConfig("LifeRecord_language", "Name_184"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_184"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(185, LocalStringManager.GetConfig("LifeRecord_language", "Name_185"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_185"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 187 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(186, LocalStringManager.GetConfig("LifeRecord_language", "Name_186"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_186"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 187 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(187, LocalStringManager.GetConfig("LifeRecord_language", "Name_187"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_187"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 185, 186 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(188, LocalStringManager.GetConfig("LifeRecord_language", "Name_188"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_188"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(189, LocalStringManager.GetConfig("LifeRecord_language", "Name_189"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_189"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(190, LocalStringManager.GetConfig("LifeRecord_language", "Name_190"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_190"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(191, LocalStringManager.GetConfig("LifeRecord_language", "Name_191"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_191"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(192, LocalStringManager.GetConfig("LifeRecord_language", "Name_192"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_192"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 194 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(193, LocalStringManager.GetConfig("LifeRecord_language", "Name_193"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_193"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 194 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(194, LocalStringManager.GetConfig("LifeRecord_language", "Name_194"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_194"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 192, 193 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(195, LocalStringManager.GetConfig("LifeRecord_language", "Name_195"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_195"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(196, LocalStringManager.GetConfig("LifeRecord_language", "Name_196"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_196"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(197, LocalStringManager.GetConfig("LifeRecord_language", "Name_197"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_197"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(198, LocalStringManager.GetConfig("LifeRecord_language", "Name_198"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_198"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(199, LocalStringManager.GetConfig("LifeRecord_language", "Name_199"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_199"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 201 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(200, LocalStringManager.GetConfig("LifeRecord_language", "Name_200"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_200"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 201 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(201, LocalStringManager.GetConfig("LifeRecord_language", "Name_201"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_201"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 199, 200 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(202, LocalStringManager.GetConfig("LifeRecord_language", "Name_202"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_202"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(203, LocalStringManager.GetConfig("LifeRecord_language", "Name_203"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_203"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(204, LocalStringManager.GetConfig("LifeRecord_language", "Name_204"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_204"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(205, LocalStringManager.GetConfig("LifeRecord_language", "Name_205"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_205"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(206, LocalStringManager.GetConfig("LifeRecord_language", "Name_206"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_206"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 208 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(207, LocalStringManager.GetConfig("LifeRecord_language", "Name_207"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_207"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 208 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(208, LocalStringManager.GetConfig("LifeRecord_language", "Name_208"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_208"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 206, 207 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(209, LocalStringManager.GetConfig("LifeRecord_language", "Name_209"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_209"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(210, LocalStringManager.GetConfig("LifeRecord_language", "Name_210"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_210"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(211, LocalStringManager.GetConfig("LifeRecord_language", "Name_211"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_211"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(212, LocalStringManager.GetConfig("LifeRecord_language", "Name_212"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_212"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(213, LocalStringManager.GetConfig("LifeRecord_language", "Name_213"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_213"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 216 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(214, LocalStringManager.GetConfig("LifeRecord_language", "Name_214"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_214"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 216 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(215, LocalStringManager.GetConfig("LifeRecord_language", "Name_215"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_215"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 217 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(216, LocalStringManager.GetConfig("LifeRecord_language", "Name_216"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_216"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 213, 214 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(217, LocalStringManager.GetConfig("LifeRecord_language", "Name_217"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_217"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 215 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(218, LocalStringManager.GetConfig("LifeRecord_language", "Name_218"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_218"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(219, LocalStringManager.GetConfig("LifeRecord_language", "Name_219"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_219"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(220, LocalStringManager.GetConfig("LifeRecord_language", "Name_220"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_220"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(221, LocalStringManager.GetConfig("LifeRecord_language", "Name_221"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_221"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(222, LocalStringManager.GetConfig("LifeRecord_language", "Name_222"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_222"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 225 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(223, LocalStringManager.GetConfig("LifeRecord_language", "Name_223"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_223"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 225 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(224, LocalStringManager.GetConfig("LifeRecord_language", "Name_224"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_224"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 226 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(225, LocalStringManager.GetConfig("LifeRecord_language", "Name_225"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_225"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 222, 223 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(226, LocalStringManager.GetConfig("LifeRecord_language", "Name_226"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_226"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 224 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(227, LocalStringManager.GetConfig("LifeRecord_language", "Name_227"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_227"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(228, LocalStringManager.GetConfig("LifeRecord_language", "Name_228"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_228"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(229, LocalStringManager.GetConfig("LifeRecord_language", "Name_229"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_229"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(230, LocalStringManager.GetConfig("LifeRecord_language", "Name_230"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_230"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(231, LocalStringManager.GetConfig("LifeRecord_language", "Name_231"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_231"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 234 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(232, LocalStringManager.GetConfig("LifeRecord_language", "Name_232"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_232"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 234 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(233, LocalStringManager.GetConfig("LifeRecord_language", "Name_233"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_233"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 235 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(234, LocalStringManager.GetConfig("LifeRecord_language", "Name_234"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_234"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 231, 232 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(235, LocalStringManager.GetConfig("LifeRecord_language", "Name_235"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_235"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 233 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(236, LocalStringManager.GetConfig("LifeRecord_language", "Name_236"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_236"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(237, LocalStringManager.GetConfig("LifeRecord_language", "Name_237"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_237"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(238, LocalStringManager.GetConfig("LifeRecord_language", "Name_238"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_238"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(239, LocalStringManager.GetConfig("LifeRecord_language", "Name_239"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_239"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new LifeRecordItem(240, LocalStringManager.GetConfig("LifeRecord_language", "Name_240"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_240"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 243 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(241, LocalStringManager.GetConfig("LifeRecord_language", "Name_241"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_241"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 243 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(242, LocalStringManager.GetConfig("LifeRecord_language", "Name_242"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_242"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 244 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(243, LocalStringManager.GetConfig("LifeRecord_language", "Name_243"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_243"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 240, 241 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(244, LocalStringManager.GetConfig("LifeRecord_language", "Name_244"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_244"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 242 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(245, LocalStringManager.GetConfig("LifeRecord_language", "Name_245"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_245"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(246, LocalStringManager.GetConfig("LifeRecord_language", "Name_246"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_246"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(247, LocalStringManager.GetConfig("LifeRecord_language", "Name_247"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_247"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(248, LocalStringManager.GetConfig("LifeRecord_language", "Name_248"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_248"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(249, LocalStringManager.GetConfig("LifeRecord_language", "Name_249"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_249"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 252 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(250, LocalStringManager.GetConfig("LifeRecord_language", "Name_250"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_250"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 252 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(251, LocalStringManager.GetConfig("LifeRecord_language", "Name_251"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_251"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 253 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(252, LocalStringManager.GetConfig("LifeRecord_language", "Name_252"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_252"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 249, 250 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(253, LocalStringManager.GetConfig("LifeRecord_language", "Name_253"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_253"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 251 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(254, LocalStringManager.GetConfig("LifeRecord_language", "Name_254"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_254"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(255, LocalStringManager.GetConfig("LifeRecord_language", "Name_255"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_255"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(256, LocalStringManager.GetConfig("LifeRecord_language", "Name_256"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_256"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(257, LocalStringManager.GetConfig("LifeRecord_language", "Name_257"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_257"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(258, LocalStringManager.GetConfig("LifeRecord_language", "Name_258"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_258"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 261 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(259, LocalStringManager.GetConfig("LifeRecord_language", "Name_259"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_259"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 261 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(260, LocalStringManager.GetConfig("LifeRecord_language", "Name_260"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_260"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 262 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(261, LocalStringManager.GetConfig("LifeRecord_language", "Name_261"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_261"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 258, 259 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(262, LocalStringManager.GetConfig("LifeRecord_language", "Name_262"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_262"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 260 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(263, LocalStringManager.GetConfig("LifeRecord_language", "Name_263"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_263"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(264, LocalStringManager.GetConfig("LifeRecord_language", "Name_264"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_264"), new string[6] { "Character", "Location", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(265, LocalStringManager.GetConfig("LifeRecord_language", "Name_265"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_265"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(266, LocalStringManager.GetConfig("LifeRecord_language", "Name_266"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_266"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(267, LocalStringManager.GetConfig("LifeRecord_language", "Name_267"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_267"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(268, LocalStringManager.GetConfig("LifeRecord_language", "Name_268"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_268"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(269, LocalStringManager.GetConfig("LifeRecord_language", "Name_269"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_269"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(270, LocalStringManager.GetConfig("LifeRecord_language", "Name_270"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_270"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(271, LocalStringManager.GetConfig("LifeRecord_language", "Name_271"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_271"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 273 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(272, LocalStringManager.GetConfig("LifeRecord_language", "Name_272"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_272"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 273 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(273, LocalStringManager.GetConfig("LifeRecord_language", "Name_273"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_273"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 271, 272 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(274, LocalStringManager.GetConfig("LifeRecord_language", "Name_274"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_274"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(275, LocalStringManager.GetConfig("LifeRecord_language", "Name_275"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_275"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(276, LocalStringManager.GetConfig("LifeRecord_language", "Name_276"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_276"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(277, LocalStringManager.GetConfig("LifeRecord_language", "Name_277"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_277"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(278, LocalStringManager.GetConfig("LifeRecord_language", "Name_278"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_278"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 280 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(279, LocalStringManager.GetConfig("LifeRecord_language", "Name_279"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_279"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 280 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(280, LocalStringManager.GetConfig("LifeRecord_language", "Name_280"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_280"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 278, 279 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(281, LocalStringManager.GetConfig("LifeRecord_language", "Name_281"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_281"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(282, LocalStringManager.GetConfig("LifeRecord_language", "Name_282"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_282"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(283, LocalStringManager.GetConfig("LifeRecord_language", "Name_283"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_283"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(284, LocalStringManager.GetConfig("LifeRecord_language", "Name_284"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_284"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(285, LocalStringManager.GetConfig("LifeRecord_language", "Name_285"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_285"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 287 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(286, LocalStringManager.GetConfig("LifeRecord_language", "Name_286"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_286"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 287 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(287, LocalStringManager.GetConfig("LifeRecord_language", "Name_287"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_287"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 285, 286 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(288, LocalStringManager.GetConfig("LifeRecord_language", "Name_288"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_288"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(289, LocalStringManager.GetConfig("LifeRecord_language", "Name_289"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_289"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(290, LocalStringManager.GetConfig("LifeRecord_language", "Name_290"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_290"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(291, LocalStringManager.GetConfig("LifeRecord_language", "Name_291"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_291"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(292, LocalStringManager.GetConfig("LifeRecord_language", "Name_292"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_292"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 294 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(293, LocalStringManager.GetConfig("LifeRecord_language", "Name_293"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_293"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 294 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(294, LocalStringManager.GetConfig("LifeRecord_language", "Name_294"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_294"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 292, 293 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(295, LocalStringManager.GetConfig("LifeRecord_language", "Name_295"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_295"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(296, LocalStringManager.GetConfig("LifeRecord_language", "Name_296"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_296"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(297, LocalStringManager.GetConfig("LifeRecord_language", "Name_297"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_297"), new string[6] { "Character", "Location", "Resource", "Integer", "Resource", "Integer" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(298, LocalStringManager.GetConfig("LifeRecord_language", "Name_298"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_298"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 303 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(299, LocalStringManager.GetConfig("LifeRecord_language", "Name_299"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_299"), new string[6] { "Character", "Location", "Resource", "Integer", "Item", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new LifeRecordItem(300, LocalStringManager.GetConfig("LifeRecord_language", "Name_300"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_300"), new string[6] { "Character", "Location", "Resource", "Integer", "Item", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(301, LocalStringManager.GetConfig("LifeRecord_language", "Name_301"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_301"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 304 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(302, LocalStringManager.GetConfig("LifeRecord_language", "Name_302"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_302"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 305 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(303, LocalStringManager.GetConfig("LifeRecord_language", "Name_303"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_303"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 298 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(304, LocalStringManager.GetConfig("LifeRecord_language", "Name_304"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_304"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 301 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(305, LocalStringManager.GetConfig("LifeRecord_language", "Name_305"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_305"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 302 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(306, LocalStringManager.GetConfig("LifeRecord_language", "Name_306"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_306"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 308, 309 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(307, LocalStringManager.GetConfig("LifeRecord_language", "Name_307"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_307"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 310, 311 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(308, LocalStringManager.GetConfig("LifeRecord_language", "Name_308"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_308"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 306 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(309, LocalStringManager.GetConfig("LifeRecord_language", "Name_309"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_309"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 306 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(310, LocalStringManager.GetConfig("LifeRecord_language", "Name_310"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_310"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 307 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(311, LocalStringManager.GetConfig("LifeRecord_language", "Name_311"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_311"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 307 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(312, LocalStringManager.GetConfig("LifeRecord_language", "Name_312"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_312"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 327 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(313, LocalStringManager.GetConfig("LifeRecord_language", "Name_313"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_313"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 328 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(314, LocalStringManager.GetConfig("LifeRecord_language", "Name_314"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_314"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 329 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(315, LocalStringManager.GetConfig("LifeRecord_language", "Name_315"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_315"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 330 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(316, LocalStringManager.GetConfig("LifeRecord_language", "Name_316"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_316"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 331 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(317, LocalStringManager.GetConfig("LifeRecord_language", "Name_317"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_317"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 332 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(318, LocalStringManager.GetConfig("LifeRecord_language", "Name_318"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_318"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 333 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(319, LocalStringManager.GetConfig("LifeRecord_language", "Name_319"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_319"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 334 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(320, LocalStringManager.GetConfig("LifeRecord_language", "Name_320"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_320"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 335 }, -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(321, LocalStringManager.GetConfig("LifeRecord_language", "Name_321"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_321"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 336 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(322, LocalStringManager.GetConfig("LifeRecord_language", "Name_322"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_322"), new string[6] { "Character", "Location", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short> { 337 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(323, LocalStringManager.GetConfig("LifeRecord_language", "Name_323"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_323"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 338 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(324, LocalStringManager.GetConfig("LifeRecord_language", "Name_324"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_324"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 339 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(325, LocalStringManager.GetConfig("LifeRecord_language", "Name_325"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_325"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 340 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(326, LocalStringManager.GetConfig("LifeRecord_language", "Name_326"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_326"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 341 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(327, LocalStringManager.GetConfig("LifeRecord_language", "Name_327"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_327"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 312 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(328, LocalStringManager.GetConfig("LifeRecord_language", "Name_328"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_328"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 313 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(329, LocalStringManager.GetConfig("LifeRecord_language", "Name_329"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_329"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 314 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(330, LocalStringManager.GetConfig("LifeRecord_language", "Name_330"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_330"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 315 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(331, LocalStringManager.GetConfig("LifeRecord_language", "Name_331"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_331"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 316 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(332, LocalStringManager.GetConfig("LifeRecord_language", "Name_332"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_332"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 317 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(333, LocalStringManager.GetConfig("LifeRecord_language", "Name_333"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_333"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 318 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(334, LocalStringManager.GetConfig("LifeRecord_language", "Name_334"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_334"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 319 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(335, LocalStringManager.GetConfig("LifeRecord_language", "Name_335"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_335"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 320 }, -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(336, LocalStringManager.GetConfig("LifeRecord_language", "Name_336"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_336"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 321 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(337, LocalStringManager.GetConfig("LifeRecord_language", "Name_337"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_337"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 322 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(338, LocalStringManager.GetConfig("LifeRecord_language", "Name_338"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_338"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 323 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(339, LocalStringManager.GetConfig("LifeRecord_language", "Name_339"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_339"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 324 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(340, LocalStringManager.GetConfig("LifeRecord_language", "Name_340"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_340"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 325 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(341, LocalStringManager.GetConfig("LifeRecord_language", "Name_341"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_341"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 326 }, -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(342, LocalStringManager.GetConfig("LifeRecord_language", "Name_342"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_342"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Calculated, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(343, LocalStringManager.GetConfig("LifeRecord_language", "Name_343"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_343"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 347 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(344, LocalStringManager.GetConfig("LifeRecord_language", "Name_344"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_344"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 348 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(345, LocalStringManager.GetConfig("LifeRecord_language", "Name_345"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_345"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 349 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(346, LocalStringManager.GetConfig("LifeRecord_language", "Name_346"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_346"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 350 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(347, LocalStringManager.GetConfig("LifeRecord_language", "Name_347"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_347"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 343 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(348, LocalStringManager.GetConfig("LifeRecord_language", "Name_348"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_348"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 344 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(349, LocalStringManager.GetConfig("LifeRecord_language", "Name_349"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_349"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 345 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(350, LocalStringManager.GetConfig("LifeRecord_language", "Name_350"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_350"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 346 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(351, LocalStringManager.GetConfig("LifeRecord_language", "Name_351"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_351"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(352, LocalStringManager.GetConfig("LifeRecord_language", "Name_352"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_352"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(353, LocalStringManager.GetConfig("LifeRecord_language", "Name_353"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_353"), new string[6] { "Character", "Location", "SecretInformationTemplate", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(354, LocalStringManager.GetConfig("LifeRecord_language", "Name_354"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_354"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(355, LocalStringManager.GetConfig("LifeRecord_language", "Name_355"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_355"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 356 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(356, LocalStringManager.GetConfig("LifeRecord_language", "Name_356"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_356"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 355 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(357, LocalStringManager.GetConfig("LifeRecord_language", "Name_357"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_357"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 357 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(358, LocalStringManager.GetConfig("LifeRecord_language", "Name_358"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_358"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 361 }, -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(359, LocalStringManager.GetConfig("LifeRecord_language", "Name_359"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_359"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 362 }, -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new LifeRecordItem(360, LocalStringManager.GetConfig("LifeRecord_language", "Name_360"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_360"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 363 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(361, LocalStringManager.GetConfig("LifeRecord_language", "Name_361"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_361"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 358 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(362, LocalStringManager.GetConfig("LifeRecord_language", "Name_362"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_362"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 359 }, -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(363, LocalStringManager.GetConfig("LifeRecord_language", "Name_363"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_363"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 360 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(364, LocalStringManager.GetConfig("LifeRecord_language", "Name_364"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_364"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(365, LocalStringManager.GetConfig("LifeRecord_language", "Name_365"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_365"), new string[6] { "Location", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(366, LocalStringManager.GetConfig("LifeRecord_language", "Name_366"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_366"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(367, LocalStringManager.GetConfig("LifeRecord_language", "Name_367"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_367"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(368, LocalStringManager.GetConfig("LifeRecord_language", "Name_368"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_368"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(369, LocalStringManager.GetConfig("LifeRecord_language", "Name_369"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_369"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(370, LocalStringManager.GetConfig("LifeRecord_language", "Name_370"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_370"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(371, LocalStringManager.GetConfig("LifeRecord_language", "Name_371"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_371"), new string[6] { "Location", "PoisonType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(372, LocalStringManager.GetConfig("LifeRecord_language", "Name_372"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_372"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(373, LocalStringManager.GetConfig("LifeRecord_language", "Name_373"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_373"), new string[6] { "Location", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(374, LocalStringManager.GetConfig("LifeRecord_language", "Name_374"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_374"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(375, LocalStringManager.GetConfig("LifeRecord_language", "Name_375"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_375"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(376, LocalStringManager.GetConfig("LifeRecord_language", "Name_376"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_376"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(377, LocalStringManager.GetConfig("LifeRecord_language", "Name_377"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_377"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(378, LocalStringManager.GetConfig("LifeRecord_language", "Name_378"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_378"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(379, LocalStringManager.GetConfig("LifeRecord_language", "Name_379"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_379"), new string[6] { "Location", "PoisonType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(380, LocalStringManager.GetConfig("LifeRecord_language", "Name_380"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_380"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(381, LocalStringManager.GetConfig("LifeRecord_language", "Name_381"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_381"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(382, LocalStringManager.GetConfig("LifeRecord_language", "Name_382"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_382"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(383, LocalStringManager.GetConfig("LifeRecord_language", "Name_383"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_383"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(384, LocalStringManager.GetConfig("LifeRecord_language", "Name_384"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_384"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(385, LocalStringManager.GetConfig("LifeRecord_language", "Name_385"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_385"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(386, LocalStringManager.GetConfig("LifeRecord_language", "Name_386"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_386"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(387, LocalStringManager.GetConfig("LifeRecord_language", "Name_387"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_387"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(388, LocalStringManager.GetConfig("LifeRecord_language", "Name_388"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_388"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(389, LocalStringManager.GetConfig("LifeRecord_language", "Name_389"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_389"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(390, LocalStringManager.GetConfig("LifeRecord_language", "Name_390"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_390"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(391, LocalStringManager.GetConfig("LifeRecord_language", "Name_391"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_391"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(392, LocalStringManager.GetConfig("LifeRecord_language", "Name_392"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_392"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(393, LocalStringManager.GetConfig("LifeRecord_language", "Name_393"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_393"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(394, LocalStringManager.GetConfig("LifeRecord_language", "Name_394"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_394"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(395, LocalStringManager.GetConfig("LifeRecord_language", "Name_395"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_395"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(396, LocalStringManager.GetConfig("LifeRecord_language", "Name_396"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_396"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(397, LocalStringManager.GetConfig("LifeRecord_language", "Name_397"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_397"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(398, LocalStringManager.GetConfig("LifeRecord_language", "Name_398"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_398"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(399, LocalStringManager.GetConfig("LifeRecord_language", "Name_399"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_399"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(400, LocalStringManager.GetConfig("LifeRecord_language", "Name_400"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_400"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(401, LocalStringManager.GetConfig("LifeRecord_language", "Name_401"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_401"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(402, LocalStringManager.GetConfig("LifeRecord_language", "Name_402"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_402"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(403, LocalStringManager.GetConfig("LifeRecord_language", "Name_403"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_403"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(404, LocalStringManager.GetConfig("LifeRecord_language", "Name_404"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_404"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(405, LocalStringManager.GetConfig("LifeRecord_language", "Name_405"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_405"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(406, LocalStringManager.GetConfig("LifeRecord_language", "Name_406"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_406"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 90, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(407, LocalStringManager.GetConfig("LifeRecord_language", "Name_407"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_407"), new string[6] { "Character", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(408, LocalStringManager.GetConfig("LifeRecord_language", "Name_408"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_408"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(409, LocalStringManager.GetConfig("LifeRecord_language", "Name_409"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_409"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(410, LocalStringManager.GetConfig("LifeRecord_language", "Name_410"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_410"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 413 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(411, LocalStringManager.GetConfig("LifeRecord_language", "Name_411"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_411"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 691 }, -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(412, LocalStringManager.GetConfig("LifeRecord_language", "Name_412"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_412"), new string[6] { "Location", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(413, LocalStringManager.GetConfig("LifeRecord_language", "Name_413"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_413"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 410 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(414, LocalStringManager.GetConfig("LifeRecord_language", "Name_414"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_414"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 20, 5, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(415, LocalStringManager.GetConfig("LifeRecord_language", "Name_415"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_415"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, 6, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(416, LocalStringManager.GetConfig("LifeRecord_language", "Name_416"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_416"), new string[6] { "Location", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(417, LocalStringManager.GetConfig("LifeRecord_language", "Name_417"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_417"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(418, LocalStringManager.GetConfig("LifeRecord_language", "Name_418"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_418"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(419, LocalStringManager.GetConfig("LifeRecord_language", "Name_419"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_419"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Normal));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new LifeRecordItem(420, LocalStringManager.GetConfig("LifeRecord_language", "Name_420"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_420"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(421, LocalStringManager.GetConfig("LifeRecord_language", "Name_421"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_421"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(422, LocalStringManager.GetConfig("LifeRecord_language", "Name_422"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_422"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(423, LocalStringManager.GetConfig("LifeRecord_language", "Name_423"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_423"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(424, LocalStringManager.GetConfig("LifeRecord_language", "Name_424"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_424"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(425, LocalStringManager.GetConfig("LifeRecord_language", "Name_425"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_425"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(426, LocalStringManager.GetConfig("LifeRecord_language", "Name_426"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_426"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(427, LocalStringManager.GetConfig("LifeRecord_language", "Name_427"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_427"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(428, LocalStringManager.GetConfig("LifeRecord_language", "Name_428"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_428"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(429, LocalStringManager.GetConfig("LifeRecord_language", "Name_429"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_429"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(430, LocalStringManager.GetConfig("LifeRecord_language", "Name_430"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_430"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(431, LocalStringManager.GetConfig("LifeRecord_language", "Name_431"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_431"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(432, LocalStringManager.GetConfig("LifeRecord_language", "Name_432"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_432"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(433, LocalStringManager.GetConfig("LifeRecord_language", "Name_433"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_433"), new string[6] { "Location", "Character", "ItemSubType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(434, LocalStringManager.GetConfig("LifeRecord_language", "Name_434"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_434"), new string[6] { "Location", "Character", "ItemSubType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(435, LocalStringManager.GetConfig("LifeRecord_language", "Name_435"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_435"), new string[6] { "Location", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(436, LocalStringManager.GetConfig("LifeRecord_language", "Name_436"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_436"), new string[6] { "Location", "Character", "BehaviorType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(437, LocalStringManager.GetConfig("LifeRecord_language", "Name_437"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_437"), new string[6] { "Location", "Character", "LifeSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(438, LocalStringManager.GetConfig("LifeRecord_language", "Name_438"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_438"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(439, LocalStringManager.GetConfig("LifeRecord_language", "Name_439"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_439"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(440, LocalStringManager.GetConfig("LifeRecord_language", "Name_440"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_440"), new string[6] { "PunishmentType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(441, LocalStringManager.GetConfig("LifeRecord_language", "Name_441"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_441"), new string[6] { "PunishmentType", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(442, LocalStringManager.GetConfig("LifeRecord_language", "Name_442"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_442"), new string[6] { "PunishmentType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(443, LocalStringManager.GetConfig("LifeRecord_language", "Name_443"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_443"), new string[6] { "PunishmentType", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(444, LocalStringManager.GetConfig("LifeRecord_language", "Name_444"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_444"), new string[6] { "PunishmentType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(445, LocalStringManager.GetConfig("LifeRecord_language", "Name_445"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_445"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(446, LocalStringManager.GetConfig("LifeRecord_language", "Name_446"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_446"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(447, LocalStringManager.GetConfig("LifeRecord_language", "Name_447"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_447"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 461, 462 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(448, LocalStringManager.GetConfig("LifeRecord_language", "Name_448"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_448"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 461, 462 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(449, LocalStringManager.GetConfig("LifeRecord_language", "Name_449"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_449"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 459, 460 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(450, LocalStringManager.GetConfig("LifeRecord_language", "Name_450"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_450"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 459, 460 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(451, LocalStringManager.GetConfig("LifeRecord_language", "Name_451"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_451"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(452, LocalStringManager.GetConfig("LifeRecord_language", "Name_452"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_452"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(453, LocalStringManager.GetConfig("LifeRecord_language", "Name_453"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_453"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(454, LocalStringManager.GetConfig("LifeRecord_language", "Name_454"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_454"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(455, LocalStringManager.GetConfig("LifeRecord_language", "Name_455"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_455"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(456, LocalStringManager.GetConfig("LifeRecord_language", "Name_456"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_456"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(457, LocalStringManager.GetConfig("LifeRecord_language", "Name_457"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_457"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(458, LocalStringManager.GetConfig("LifeRecord_language", "Name_458"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_458"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(459, LocalStringManager.GetConfig("LifeRecord_language", "Name_459"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_459"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 449, 450 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(460, LocalStringManager.GetConfig("LifeRecord_language", "Name_460"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_460"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 449, 450 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(461, LocalStringManager.GetConfig("LifeRecord_language", "Name_461"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_461"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 447, 448 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(462, LocalStringManager.GetConfig("LifeRecord_language", "Name_462"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_462"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 447, 448 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(463, LocalStringManager.GetConfig("LifeRecord_language", "Name_463"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_463"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(464, LocalStringManager.GetConfig("LifeRecord_language", "Name_464"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_464"), new string[6] { "Location", "Adventure", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(465, LocalStringManager.GetConfig("LifeRecord_language", "Name_465"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_465"), new string[6] { "Location", "Adventure", "CharacterTitle", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(466, LocalStringManager.GetConfig("LifeRecord_language", "Name_466"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_466"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, 16, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(467, LocalStringManager.GetConfig("LifeRecord_language", "Name_467"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_467"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 468 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(468, LocalStringManager.GetConfig("LifeRecord_language", "Name_468"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_468"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 467 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(469, LocalStringManager.GetConfig("LifeRecord_language", "Name_469"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_469"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 470 }, -30000, ELifeRecordScoreType.Normal, 40, 12, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(470, LocalStringManager.GetConfig("LifeRecord_language", "Name_470"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_470"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 469 }, -30000, ELifeRecordScoreType.Normal, 40, 11, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(471, LocalStringManager.GetConfig("LifeRecord_language", "Name_471"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_471"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 472 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(472, LocalStringManager.GetConfig("LifeRecord_language", "Name_472"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_472"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(473, LocalStringManager.GetConfig("LifeRecord_language", "Name_473"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_473"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 473 }, -30000, ELifeRecordScoreType.Normal, 40, 13, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(474, LocalStringManager.GetConfig("LifeRecord_language", "Name_474"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_474"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(475, LocalStringManager.GetConfig("LifeRecord_language", "Name_475"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_475"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(476, LocalStringManager.GetConfig("LifeRecord_language", "Name_476"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_476"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(477, LocalStringManager.GetConfig("LifeRecord_language", "Name_477"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_477"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(478, LocalStringManager.GetConfig("LifeRecord_language", "Name_478"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_478"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(479, LocalStringManager.GetConfig("LifeRecord_language", "Name_479"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_479"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems8()
	{
		_dataArray.Add(new LifeRecordItem(480, LocalStringManager.GetConfig("LifeRecord_language", "Name_480"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_480"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(481, LocalStringManager.GetConfig("LifeRecord_language", "Name_481"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_481"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(482, LocalStringManager.GetConfig("LifeRecord_language", "Name_482"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_482"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(483, LocalStringManager.GetConfig("LifeRecord_language", "Name_483"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_483"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(484, LocalStringManager.GetConfig("LifeRecord_language", "Name_484"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_484"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(485, LocalStringManager.GetConfig("LifeRecord_language", "Name_485"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_485"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(486, LocalStringManager.GetConfig("LifeRecord_language", "Name_486"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_486"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(487, LocalStringManager.GetConfig("LifeRecord_language", "Name_487"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_487"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(488, LocalStringManager.GetConfig("LifeRecord_language", "Name_488"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_488"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 491 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(489, LocalStringManager.GetConfig("LifeRecord_language", "Name_489"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_489"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 490 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(490, LocalStringManager.GetConfig("LifeRecord_language", "Name_490"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_490"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 489 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(491, LocalStringManager.GetConfig("LifeRecord_language", "Name_491"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_491"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 488 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(492, LocalStringManager.GetConfig("LifeRecord_language", "Name_492"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_492"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 493 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(493, LocalStringManager.GetConfig("LifeRecord_language", "Name_493"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_493"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 492 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(494, LocalStringManager.GetConfig("LifeRecord_language", "Name_494"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_494"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 495 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(495, LocalStringManager.GetConfig("LifeRecord_language", "Name_495"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_495"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 494 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(496, LocalStringManager.GetConfig("LifeRecord_language", "Name_496"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_496"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 497 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(497, LocalStringManager.GetConfig("LifeRecord_language", "Name_497"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_497"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 496 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(498, LocalStringManager.GetConfig("LifeRecord_language", "Name_498"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_498"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 499 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(499, LocalStringManager.GetConfig("LifeRecord_language", "Name_499"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_499"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 498 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(500, LocalStringManager.GetConfig("LifeRecord_language", "Name_500"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_500"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 501 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(501, LocalStringManager.GetConfig("LifeRecord_language", "Name_501"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_501"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 500 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(502, LocalStringManager.GetConfig("LifeRecord_language", "Name_502"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_502"), new string[6] { "Character", "Location", "Item", "Resource", "Integer", "" }, isSourceRecord: true, new List<short> { 503 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(503, LocalStringManager.GetConfig("LifeRecord_language", "Name_503"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_503"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 502 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(504, LocalStringManager.GetConfig("LifeRecord_language", "Name_504"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_504"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 505 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(505, LocalStringManager.GetConfig("LifeRecord_language", "Name_505"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_505"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 504 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(506, LocalStringManager.GetConfig("LifeRecord_language", "Name_506"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_506"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 507 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(507, LocalStringManager.GetConfig("LifeRecord_language", "Name_507"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_507"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 506 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(508, LocalStringManager.GetConfig("LifeRecord_language", "Name_508"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_508"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 513 }, -30000, ELifeRecordScoreType.Normal, 70, 3, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(509, LocalStringManager.GetConfig("LifeRecord_language", "Name_509"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_509"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 514 }, -30000, ELifeRecordScoreType.Normal, 70, 7, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(510, LocalStringManager.GetConfig("LifeRecord_language", "Name_510"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_510"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 515 }, -30000, ELifeRecordScoreType.Normal, 70, 8, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(511, LocalStringManager.GetConfig("LifeRecord_language", "Name_511"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_511"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 516 }, -30000, ELifeRecordScoreType.Normal, 70, 10, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(512, LocalStringManager.GetConfig("LifeRecord_language", "Name_512"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_512"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 517 }, -30000, ELifeRecordScoreType.Normal, 70, 2, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(513, LocalStringManager.GetConfig("LifeRecord_language", "Name_513"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_513"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 508 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(514, LocalStringManager.GetConfig("LifeRecord_language", "Name_514"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_514"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 509 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(515, LocalStringManager.GetConfig("LifeRecord_language", "Name_515"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_515"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 510 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(516, LocalStringManager.GetConfig("LifeRecord_language", "Name_516"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_516"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 511 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(517, LocalStringManager.GetConfig("LifeRecord_language", "Name_517"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_517"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 512 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(518, LocalStringManager.GetConfig("LifeRecord_language", "Name_518"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_518"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 519 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(519, LocalStringManager.GetConfig("LifeRecord_language", "Name_519"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_519"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 518 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(520, LocalStringManager.GetConfig("LifeRecord_language", "Name_520"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_520"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 521 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(521, LocalStringManager.GetConfig("LifeRecord_language", "Name_521"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_521"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 520 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(522, LocalStringManager.GetConfig("LifeRecord_language", "Name_522"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_522"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 523 }, -30000, ELifeRecordScoreType.Normal, 70, 1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(523, LocalStringManager.GetConfig("LifeRecord_language", "Name_523"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_523"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 522 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(524, LocalStringManager.GetConfig("LifeRecord_language", "Name_524"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_524"), new string[6] { "Character", "Location", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short> { 525 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(525, LocalStringManager.GetConfig("LifeRecord_language", "Name_525"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_525"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 524 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(526, LocalStringManager.GetConfig("LifeRecord_language", "Name_526"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_526"), new string[6] { "Location", "Item", "Settlement", "OrgGrade", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(527, LocalStringManager.GetConfig("LifeRecord_language", "Name_527"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_527"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 528 }, -30000, ELifeRecordScoreType.Normal, 49, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(528, LocalStringManager.GetConfig("LifeRecord_language", "Name_528"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_528"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 527 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(529, LocalStringManager.GetConfig("LifeRecord_language", "Name_529"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_529"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 531 }, -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(530, LocalStringManager.GetConfig("LifeRecord_language", "Name_530"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_530"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 532 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(531, LocalStringManager.GetConfig("LifeRecord_language", "Name_531"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_531"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 529 }, -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(532, LocalStringManager.GetConfig("LifeRecord_language", "Name_532"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_532"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 530 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(533, LocalStringManager.GetConfig("LifeRecord_language", "Name_533"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_533"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 534 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(534, LocalStringManager.GetConfig("LifeRecord_language", "Name_534"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_534"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 533 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(535, LocalStringManager.GetConfig("LifeRecord_language", "Name_535"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_535"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 536 }, -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(536, LocalStringManager.GetConfig("LifeRecord_language", "Name_536"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_536"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 535 }, -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(537, LocalStringManager.GetConfig("LifeRecord_language", "Name_537"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_537"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 538 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(538, LocalStringManager.GetConfig("LifeRecord_language", "Name_538"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_538"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 537 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(539, LocalStringManager.GetConfig("LifeRecord_language", "Name_539"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_539"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems9()
	{
		_dataArray.Add(new LifeRecordItem(540, LocalStringManager.GetConfig("LifeRecord_language", "Name_540"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_540"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 541 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(541, LocalStringManager.GetConfig("LifeRecord_language", "Name_541"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_541"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 540 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(542, LocalStringManager.GetConfig("LifeRecord_language", "Name_542"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_542"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(543, LocalStringManager.GetConfig("LifeRecord_language", "Name_543"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_543"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 544 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(544, LocalStringManager.GetConfig("LifeRecord_language", "Name_544"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_544"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 543 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(545, LocalStringManager.GetConfig("LifeRecord_language", "Name_545"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_545"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 546 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(546, LocalStringManager.GetConfig("LifeRecord_language", "Name_546"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_546"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 545 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(547, LocalStringManager.GetConfig("LifeRecord_language", "Name_547"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_547"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(548, LocalStringManager.GetConfig("LifeRecord_language", "Name_548"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_548"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 549 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(549, LocalStringManager.GetConfig("LifeRecord_language", "Name_549"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_549"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 548 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(550, LocalStringManager.GetConfig("LifeRecord_language", "Name_550"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_550"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(551, LocalStringManager.GetConfig("LifeRecord_language", "Name_551"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_551"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(552, LocalStringManager.GetConfig("LifeRecord_language", "Name_552"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_552"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 553 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(553, LocalStringManager.GetConfig("LifeRecord_language", "Name_553"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_553"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 552 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(554, LocalStringManager.GetConfig("LifeRecord_language", "Name_554"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_554"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(555, LocalStringManager.GetConfig("LifeRecord_language", "Name_555"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_555"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(556, LocalStringManager.GetConfig("LifeRecord_language", "Name_556"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_556"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(557, LocalStringManager.GetConfig("LifeRecord_language", "Name_557"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_557"), new string[6] { "Location", "CombatSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(558, LocalStringManager.GetConfig("LifeRecord_language", "Name_558"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_558"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 559 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(559, LocalStringManager.GetConfig("LifeRecord_language", "Name_559"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_559"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 558 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(560, LocalStringManager.GetConfig("LifeRecord_language", "Name_560"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_560"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(561, LocalStringManager.GetConfig("LifeRecord_language", "Name_561"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_561"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(562, LocalStringManager.GetConfig("LifeRecord_language", "Name_562"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_562"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(563, LocalStringManager.GetConfig("LifeRecord_language", "Name_563"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_563"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(564, LocalStringManager.GetConfig("LifeRecord_language", "Name_564"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_564"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 565 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(565, LocalStringManager.GetConfig("LifeRecord_language", "Name_565"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_565"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 564 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(566, LocalStringManager.GetConfig("LifeRecord_language", "Name_566"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_566"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(567, LocalStringManager.GetConfig("LifeRecord_language", "Name_567"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_567"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 568 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(568, LocalStringManager.GetConfig("LifeRecord_language", "Name_568"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_568"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 567 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(569, LocalStringManager.GetConfig("LifeRecord_language", "Name_569"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_569"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short> { 570 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(570, LocalStringManager.GetConfig("LifeRecord_language", "Name_570"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_570"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 569 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(571, LocalStringManager.GetConfig("LifeRecord_language", "Name_571"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_571"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(572, LocalStringManager.GetConfig("LifeRecord_language", "Name_572"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_572"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 573 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(573, LocalStringManager.GetConfig("LifeRecord_language", "Name_573"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_573"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 572 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(574, LocalStringManager.GetConfig("LifeRecord_language", "Name_574"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_574"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 575 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(575, LocalStringManager.GetConfig("LifeRecord_language", "Name_575"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_575"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 574 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(576, LocalStringManager.GetConfig("LifeRecord_language", "Name_576"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_576"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 577 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(577, LocalStringManager.GetConfig("LifeRecord_language", "Name_577"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_577"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 576 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(578, LocalStringManager.GetConfig("LifeRecord_language", "Name_578"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_578"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 579 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(579, LocalStringManager.GetConfig("LifeRecord_language", "Name_579"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_579"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 578 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(580, LocalStringManager.GetConfig("LifeRecord_language", "Name_580"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_580"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 581 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(581, LocalStringManager.GetConfig("LifeRecord_language", "Name_581"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_581"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 580 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(582, LocalStringManager.GetConfig("LifeRecord_language", "Name_582"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_582"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(583, LocalStringManager.GetConfig("LifeRecord_language", "Name_583"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_583"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(584, LocalStringManager.GetConfig("LifeRecord_language", "Name_584"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_584"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 585 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(585, LocalStringManager.GetConfig("LifeRecord_language", "Name_585"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_585"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 584 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(586, LocalStringManager.GetConfig("LifeRecord_language", "Name_586"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_586"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(587, LocalStringManager.GetConfig("LifeRecord_language", "Name_587"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_587"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 90, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(588, LocalStringManager.GetConfig("LifeRecord_language", "Name_588"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_588"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(589, LocalStringManager.GetConfig("LifeRecord_language", "Name_589"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_589"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(590, LocalStringManager.GetConfig("LifeRecord_language", "Name_590"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_590"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 70, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(591, LocalStringManager.GetConfig("LifeRecord_language", "Name_591"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_591"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 592 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(592, LocalStringManager.GetConfig("LifeRecord_language", "Name_592"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_592"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 591 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(593, LocalStringManager.GetConfig("LifeRecord_language", "Name_593"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_593"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(594, LocalStringManager.GetConfig("LifeRecord_language", "Name_594"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_594"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(595, LocalStringManager.GetConfig("LifeRecord_language", "Name_595"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_595"), new string[6] { "Location", "CombatSkill", "LifeSkill", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(596, LocalStringManager.GetConfig("LifeRecord_language", "Name_596"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_596"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(597, LocalStringManager.GetConfig("LifeRecord_language", "Name_597"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_597"), new string[6] { "Location", "LifeSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(598, LocalStringManager.GetConfig("LifeRecord_language", "Name_598"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_598"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(599, LocalStringManager.GetConfig("LifeRecord_language", "Name_599"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_599"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
	}

	private void CreateItems10()
	{
		_dataArray.Add(new LifeRecordItem(600, LocalStringManager.GetConfig("LifeRecord_language", "Name_600"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_600"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(601, LocalStringManager.GetConfig("LifeRecord_language", "Name_601"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_601"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 602 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(602, LocalStringManager.GetConfig("LifeRecord_language", "Name_602"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_602"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 601 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(603, LocalStringManager.GetConfig("LifeRecord_language", "Name_603"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_603"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 90, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(604, LocalStringManager.GetConfig("LifeRecord_language", "Name_604"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_604"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(605, LocalStringManager.GetConfig("LifeRecord_language", "Name_605"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_605"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(606, LocalStringManager.GetConfig("LifeRecord_language", "Name_606"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_606"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 90, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(607, LocalStringManager.GetConfig("LifeRecord_language", "Name_607"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_607"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 90, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(608, LocalStringManager.GetConfig("LifeRecord_language", "Name_608"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_608"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(609, LocalStringManager.GetConfig("LifeRecord_language", "Name_609"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_609"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(610, LocalStringManager.GetConfig("LifeRecord_language", "Name_610"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_610"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(611, LocalStringManager.GetConfig("LifeRecord_language", "Name_611"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_611"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(612, LocalStringManager.GetConfig("LifeRecord_language", "Name_612"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_612"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(613, LocalStringManager.GetConfig("LifeRecord_language", "Name_613"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_613"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(614, LocalStringManager.GetConfig("LifeRecord_language", "Name_614"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_614"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(615, LocalStringManager.GetConfig("LifeRecord_language", "Name_615"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_615"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(616, LocalStringManager.GetConfig("LifeRecord_language", "Name_616"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_616"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(617, LocalStringManager.GetConfig("LifeRecord_language", "Name_617"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_617"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(618, LocalStringManager.GetConfig("LifeRecord_language", "Name_618"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_618"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(619, LocalStringManager.GetConfig("LifeRecord_language", "Name_619"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_619"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(620, LocalStringManager.GetConfig("LifeRecord_language", "Name_620"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_620"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(621, LocalStringManager.GetConfig("LifeRecord_language", "Name_621"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_621"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(622, LocalStringManager.GetConfig("LifeRecord_language", "Name_622"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_622"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(623, LocalStringManager.GetConfig("LifeRecord_language", "Name_623"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_623"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(624, LocalStringManager.GetConfig("LifeRecord_language", "Name_624"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_624"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(625, LocalStringManager.GetConfig("LifeRecord_language", "Name_625"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_625"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(626, LocalStringManager.GetConfig("LifeRecord_language", "Name_626"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_626"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(627, LocalStringManager.GetConfig("LifeRecord_language", "Name_627"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_627"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(628, LocalStringManager.GetConfig("LifeRecord_language", "Name_628"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_628"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(629, LocalStringManager.GetConfig("LifeRecord_language", "Name_629"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_629"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(630, LocalStringManager.GetConfig("LifeRecord_language", "Name_630"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_630"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(631, LocalStringManager.GetConfig("LifeRecord_language", "Name_631"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_631"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(632, LocalStringManager.GetConfig("LifeRecord_language", "Name_632"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_632"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(633, LocalStringManager.GetConfig("LifeRecord_language", "Name_633"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_633"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(634, LocalStringManager.GetConfig("LifeRecord_language", "Name_634"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_634"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(635, LocalStringManager.GetConfig("LifeRecord_language", "Name_635"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_635"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(636, LocalStringManager.GetConfig("LifeRecord_language", "Name_636"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_636"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(637, LocalStringManager.GetConfig("LifeRecord_language", "Name_637"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_637"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(638, LocalStringManager.GetConfig("LifeRecord_language", "Name_638"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_638"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(639, LocalStringManager.GetConfig("LifeRecord_language", "Name_639"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_639"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(640, LocalStringManager.GetConfig("LifeRecord_language", "Name_640"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_640"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(641, LocalStringManager.GetConfig("LifeRecord_language", "Name_641"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_641"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(642, LocalStringManager.GetConfig("LifeRecord_language", "Name_642"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_642"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(643, LocalStringManager.GetConfig("LifeRecord_language", "Name_643"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_643"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(644, LocalStringManager.GetConfig("LifeRecord_language", "Name_644"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_644"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(645, LocalStringManager.GetConfig("LifeRecord_language", "Name_645"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_645"), new string[6] { "Settlement", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(646, LocalStringManager.GetConfig("LifeRecord_language", "Name_646"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_646"), new string[6] { "Location", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(647, LocalStringManager.GetConfig("LifeRecord_language", "Name_647"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_647"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(648, LocalStringManager.GetConfig("LifeRecord_language", "Name_648"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_648"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(649, LocalStringManager.GetConfig("LifeRecord_language", "Name_649"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_649"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(650, LocalStringManager.GetConfig("LifeRecord_language", "Name_650"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_650"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(651, LocalStringManager.GetConfig("LifeRecord_language", "Name_651"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_651"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(652, LocalStringManager.GetConfig("LifeRecord_language", "Name_652"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_652"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(653, LocalStringManager.GetConfig("LifeRecord_language", "Name_653"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_653"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(654, LocalStringManager.GetConfig("LifeRecord_language", "Name_654"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_654"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(655, LocalStringManager.GetConfig("LifeRecord_language", "Name_655"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_655"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(656, LocalStringManager.GetConfig("LifeRecord_language", "Name_656"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_656"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 657 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(657, LocalStringManager.GetConfig("LifeRecord_language", "Name_657"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_657"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 656 }, -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(658, LocalStringManager.GetConfig("LifeRecord_language", "Name_658"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_658"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 659 }, -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(659, LocalStringManager.GetConfig("LifeRecord_language", "Name_659"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_659"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 658 }, -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems11()
	{
		_dataArray.Add(new LifeRecordItem(660, LocalStringManager.GetConfig("LifeRecord_language", "Name_660"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_660"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(661, LocalStringManager.GetConfig("LifeRecord_language", "Name_661"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_661"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(662, LocalStringManager.GetConfig("LifeRecord_language", "Name_662"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_662"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(663, LocalStringManager.GetConfig("LifeRecord_language", "Name_663"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_663"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(664, LocalStringManager.GetConfig("LifeRecord_language", "Name_664"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_664"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(665, LocalStringManager.GetConfig("LifeRecord_language", "Name_665"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_665"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(666, LocalStringManager.GetConfig("LifeRecord_language", "Name_666"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_666"), new string[6] { "Character", "Location", "Adventure", "", "", "" }, isSourceRecord: true, new List<short> { 692 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(667, LocalStringManager.GetConfig("LifeRecord_language", "Name_667"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_667"), new string[6] { "Location", "SecretInformation", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(668, LocalStringManager.GetConfig("LifeRecord_language", "Name_668"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_668"), new string[6] { "Location", "SecretInformation", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(669, LocalStringManager.GetConfig("LifeRecord_language", "Name_669"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_669"), new string[6] { "Location", "SecretInformation", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(670, LocalStringManager.GetConfig("LifeRecord_language", "Name_670"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_670"), new string[6] { "Location", "SecretInformation", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(671, LocalStringManager.GetConfig("LifeRecord_language", "Name_671"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_671"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(672, LocalStringManager.GetConfig("LifeRecord_language", "Name_672"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_672"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(673, LocalStringManager.GetConfig("LifeRecord_language", "Name_673"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_673"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(674, LocalStringManager.GetConfig("LifeRecord_language", "Name_674"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_674"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(675, LocalStringManager.GetConfig("LifeRecord_language", "Name_675"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_675"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(676, LocalStringManager.GetConfig("LifeRecord_language", "Name_676"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_676"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(677, LocalStringManager.GetConfig("LifeRecord_language", "Name_677"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_677"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(678, LocalStringManager.GetConfig("LifeRecord_language", "Name_678"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_678"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(679, LocalStringManager.GetConfig("LifeRecord_language", "Name_679"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_679"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(680, LocalStringManager.GetConfig("LifeRecord_language", "Name_680"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_680"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(681, LocalStringManager.GetConfig("LifeRecord_language", "Name_681"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_681"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(682, LocalStringManager.GetConfig("LifeRecord_language", "Name_682"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_682"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(683, LocalStringManager.GetConfig("LifeRecord_language", "Name_683"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_683"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(684, LocalStringManager.GetConfig("LifeRecord_language", "Name_684"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_684"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(685, LocalStringManager.GetConfig("LifeRecord_language", "Name_685"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_685"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(686, LocalStringManager.GetConfig("LifeRecord_language", "Name_686"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_686"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(687, LocalStringManager.GetConfig("LifeRecord_language", "Name_687"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_687"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(688, LocalStringManager.GetConfig("LifeRecord_language", "Name_688"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_688"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(689, LocalStringManager.GetConfig("LifeRecord_language", "Name_689"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_689"), new string[6] { "CharacterRealName", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(690, LocalStringManager.GetConfig("LifeRecord_language", "Name_690"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_690"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(691, LocalStringManager.GetConfig("LifeRecord_language", "Name_691"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_691"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 411 }, -30000, ELifeRecordScoreType.Normal, 50, 4, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(692, LocalStringManager.GetConfig("LifeRecord_language", "Name_692"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_692"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 666 }, -30000, ELifeRecordScoreType.Normal, 50, 9, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(693, LocalStringManager.GetConfig("LifeRecord_language", "Name_693"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_693"), new string[6] { "Character", "Location", "Adventure", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(694, LocalStringManager.GetConfig("LifeRecord_language", "Name_694"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_694"), new string[6] { "Item", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(695, LocalStringManager.GetConfig("LifeRecord_language", "Name_695"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_695"), new string[6] { "Item", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(696, LocalStringManager.GetConfig("LifeRecord_language", "Name_696"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_696"), new string[6] { "Item", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(697, LocalStringManager.GetConfig("LifeRecord_language", "Name_697"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_697"), new string[6] { "Character", "Location", "JiaoLoong", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(698, LocalStringManager.GetConfig("LifeRecord_language", "Name_698"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_698"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(699, LocalStringManager.GetConfig("LifeRecord_language", "Name_699"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_699"), new string[6] { "Character", "Location", "JiaoLoong", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(700, LocalStringManager.GetConfig("LifeRecord_language", "Name_700"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_700"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(701, LocalStringManager.GetConfig("LifeRecord_language", "Name_701"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_701"), new string[6] { "JiaoLoong", "Cricket", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(702, LocalStringManager.GetConfig("LifeRecord_language", "Name_702"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_702"), new string[6] { "Location", "JiaoLoong", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(703, LocalStringManager.GetConfig("LifeRecord_language", "Name_703"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_703"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(704, LocalStringManager.GetConfig("LifeRecord_language", "Name_704"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_704"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(705, LocalStringManager.GetConfig("LifeRecord_language", "Name_705"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_705"), new string[6] { "Location", "JiaoLoong", "Item", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(706, LocalStringManager.GetConfig("LifeRecord_language", "Name_706"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_706"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(707, LocalStringManager.GetConfig("LifeRecord_language", "Name_707"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_707"), new string[6] { "CharacterTemplate", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(708, LocalStringManager.GetConfig("LifeRecord_language", "Name_708"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_708"), new string[6] { "CharacterTemplate", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(709, LocalStringManager.GetConfig("LifeRecord_language", "Name_709"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_709"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(710, LocalStringManager.GetConfig("LifeRecord_language", "Name_710"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_710"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(711, LocalStringManager.GetConfig("LifeRecord_language", "Name_711"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_711"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(712, LocalStringManager.GetConfig("LifeRecord_language", "Name_712"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_712"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 91 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(713, LocalStringManager.GetConfig("LifeRecord_language", "Name_713"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_713"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 92 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(714, LocalStringManager.GetConfig("LifeRecord_language", "Name_714"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_714"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(715, LocalStringManager.GetConfig("LifeRecord_language", "Name_715"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_715"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(716, LocalStringManager.GetConfig("LifeRecord_language", "Name_716"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_716"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(717, LocalStringManager.GetConfig("LifeRecord_language", "Name_717"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_717"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(718, LocalStringManager.GetConfig("LifeRecord_language", "Name_718"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_718"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(719, LocalStringManager.GetConfig("LifeRecord_language", "Name_719"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_719"), new string[6] { "Character", "Location", "CombatType", "", "", "" }, isSourceRecord: true, new List<short> { 720 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
	}

	private void CreateItems12()
	{
		_dataArray.Add(new LifeRecordItem(720, LocalStringManager.GetConfig("LifeRecord_language", "Name_720"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_720"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 719 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(721, LocalStringManager.GetConfig("LifeRecord_language", "Name_721"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_721"), new string[6] { "Character", "Location", "CombatType", "", "", "" }, isSourceRecord: true, new List<short> { 722 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(722, LocalStringManager.GetConfig("LifeRecord_language", "Name_722"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_722"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 721 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(723, LocalStringManager.GetConfig("LifeRecord_language", "Name_723"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_723"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 737 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(724, LocalStringManager.GetConfig("LifeRecord_language", "Name_724"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_724"), new string[6] { "Character", "Location", "SecretInformationTemplate", "", "", "" }, isSourceRecord: true, new List<short> { 725 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(725, LocalStringManager.GetConfig("LifeRecord_language", "Name_725"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_725"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 724 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(726, LocalStringManager.GetConfig("LifeRecord_language", "Name_726"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_726"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(727, LocalStringManager.GetConfig("LifeRecord_language", "Name_727"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_727"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(728, LocalStringManager.GetConfig("LifeRecord_language", "Name_728"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_728"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(729, LocalStringManager.GetConfig("LifeRecord_language", "Name_729"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_729"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(730, LocalStringManager.GetConfig("LifeRecord_language", "Name_730"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_730"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(731, LocalStringManager.GetConfig("LifeRecord_language", "Name_731"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_731"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(732, LocalStringManager.GetConfig("LifeRecord_language", "Name_732"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_732"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(733, LocalStringManager.GetConfig("LifeRecord_language", "Name_733"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_733"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(734, LocalStringManager.GetConfig("LifeRecord_language", "Name_734"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_734"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(735, LocalStringManager.GetConfig("LifeRecord_language", "Name_735"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_735"), new string[6] { "Item", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(736, LocalStringManager.GetConfig("LifeRecord_language", "Name_736"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_736"), new string[6] { "Item", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(737, LocalStringManager.GetConfig("LifeRecord_language", "Name_737"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_737"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 723 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(738, LocalStringManager.GetConfig("LifeRecord_language", "Name_738"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_738"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(739, LocalStringManager.GetConfig("LifeRecord_language", "Name_739"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_739"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(740, LocalStringManager.GetConfig("LifeRecord_language", "Name_740"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_740"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(741, LocalStringManager.GetConfig("LifeRecord_language", "Name_741"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_741"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(742, LocalStringManager.GetConfig("LifeRecord_language", "Name_742"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_742"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(743, LocalStringManager.GetConfig("LifeRecord_language", "Name_743"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_743"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(744, LocalStringManager.GetConfig("LifeRecord_language", "Name_744"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_744"), new string[6] { "Character", "Location", "Item", "Item", "", "" }, isSourceRecord: true, new List<short> { 745 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(745, LocalStringManager.GetConfig("LifeRecord_language", "Name_745"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_745"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 744 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(746, LocalStringManager.GetConfig("LifeRecord_language", "Name_746"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_746"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(747, LocalStringManager.GetConfig("LifeRecord_language", "Name_747"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_747"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(748, LocalStringManager.GetConfig("LifeRecord_language", "Name_748"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_748"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(749, LocalStringManager.GetConfig("LifeRecord_language", "Name_749"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_749"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(750, LocalStringManager.GetConfig("LifeRecord_language", "Name_750"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_750"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(751, LocalStringManager.GetConfig("LifeRecord_language", "Name_751"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_751"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(752, LocalStringManager.GetConfig("LifeRecord_language", "Name_752"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_752"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(753, LocalStringManager.GetConfig("LifeRecord_language", "Name_753"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_753"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(754, LocalStringManager.GetConfig("LifeRecord_language", "Name_754"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_754"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(755, LocalStringManager.GetConfig("LifeRecord_language", "Name_755"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_755"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(756, LocalStringManager.GetConfig("LifeRecord_language", "Name_756"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_756"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(757, LocalStringManager.GetConfig("LifeRecord_language", "Name_757"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_757"), new string[6] { "Character", "Location", "Item", "Item", "", "" }, isSourceRecord: true, new List<short> { 758 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(758, LocalStringManager.GetConfig("LifeRecord_language", "Name_758"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_758"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 757 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(759, LocalStringManager.GetConfig("LifeRecord_language", "Name_759"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_759"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(760, LocalStringManager.GetConfig("LifeRecord_language", "Name_760"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_760"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(761, LocalStringManager.GetConfig("LifeRecord_language", "Name_761"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_761"), new string[6] { "Character", "Location", "Item", "Item", "", "" }, isSourceRecord: true, new List<short> { 762 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(762, LocalStringManager.GetConfig("LifeRecord_language", "Name_762"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_762"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 761 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(763, LocalStringManager.GetConfig("LifeRecord_language", "Name_763"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_763"), new string[6] { "Item", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(764, LocalStringManager.GetConfig("LifeRecord_language", "Name_764"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_764"), new string[6] { "Item", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(765, LocalStringManager.GetConfig("LifeRecord_language", "Name_765"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_765"), new string[6] { "LifeSkillType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(766, LocalStringManager.GetConfig("LifeRecord_language", "Name_766"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_766"), new string[6] { "CombatSkillType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(767, LocalStringManager.GetConfig("LifeRecord_language", "Name_767"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_767"), new string[6] { "LifeSkillType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(768, LocalStringManager.GetConfig("LifeRecord_language", "Name_768"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_768"), new string[6] { "CombatSkillType", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(769, LocalStringManager.GetConfig("LifeRecord_language", "Name_769"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_769"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(770, LocalStringManager.GetConfig("LifeRecord_language", "Name_770"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_770"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 771 }, -30000, ELifeRecordScoreType.Absolute, 80, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(771, LocalStringManager.GetConfig("LifeRecord_language", "Name_771"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_771"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 770 }, -30000, ELifeRecordScoreType.Normal, 50, 4, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(772, LocalStringManager.GetConfig("LifeRecord_language", "Name_772"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_772"), new string[6] { "Settlement", "Resource", "Integer", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(773, LocalStringManager.GetConfig("LifeRecord_language", "Name_773"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_773"), new string[6] { "Settlement", "Item", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(774, LocalStringManager.GetConfig("LifeRecord_language", "Name_774"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_774"), new string[6] { "Settlement", "Resource", "Integer", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(775, LocalStringManager.GetConfig("LifeRecord_language", "Name_775"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_775"), new string[6] { "Settlement", "Item", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(776, LocalStringManager.GetConfig("LifeRecord_language", "Name_776"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_776"), new string[6] { "Settlement", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(777, LocalStringManager.GetConfig("LifeRecord_language", "Name_777"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_777"), new string[6] { "Settlement", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(778, LocalStringManager.GetConfig("LifeRecord_language", "Name_778"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_778"), new string[6] { "Settlement", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(779, LocalStringManager.GetConfig("LifeRecord_language", "Name_779"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_779"), new string[6] { "Settlement", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
	}

	private void CreateItems13()
	{
		_dataArray.Add(new LifeRecordItem(780, LocalStringManager.GetConfig("LifeRecord_language", "Name_780"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_780"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(781, LocalStringManager.GetConfig("LifeRecord_language", "Name_781"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_781"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(782, LocalStringManager.GetConfig("LifeRecord_language", "Name_782"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_782"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(783, LocalStringManager.GetConfig("LifeRecord_language", "Name_783"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_783"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(784, LocalStringManager.GetConfig("LifeRecord_language", "Name_784"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_784"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(785, LocalStringManager.GetConfig("LifeRecord_language", "Name_785"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_785"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(786, LocalStringManager.GetConfig("LifeRecord_language", "Name_786"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_786"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(787, LocalStringManager.GetConfig("LifeRecord_language", "Name_787"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_787"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(788, LocalStringManager.GetConfig("LifeRecord_language", "Name_788"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_788"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(789, LocalStringManager.GetConfig("LifeRecord_language", "Name_789"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_789"), new string[6] { "Settlement", "Float", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(790, LocalStringManager.GetConfig("LifeRecord_language", "Name_790"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_790"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(791, LocalStringManager.GetConfig("LifeRecord_language", "Name_791"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_791"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(792, LocalStringManager.GetConfig("LifeRecord_language", "Name_792"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_792"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(793, LocalStringManager.GetConfig("LifeRecord_language", "Name_793"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_793"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(794, LocalStringManager.GetConfig("LifeRecord_language", "Name_794"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_794"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(795, LocalStringManager.GetConfig("LifeRecord_language", "Name_795"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_795"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(796, LocalStringManager.GetConfig("LifeRecord_language", "Name_796"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_796"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(797, LocalStringManager.GetConfig("LifeRecord_language", "Name_797"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_797"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(798, LocalStringManager.GetConfig("LifeRecord_language", "Name_798"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_798"), new string[6] { "Settlement", "Float", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(799, LocalStringManager.GetConfig("LifeRecord_language", "Name_799"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_799"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(800, LocalStringManager.GetConfig("LifeRecord_language", "Name_800"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_800"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(801, LocalStringManager.GetConfig("LifeRecord_language", "Name_801"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_801"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(802, LocalStringManager.GetConfig("LifeRecord_language", "Name_802"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_802"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(803, LocalStringManager.GetConfig("LifeRecord_language", "Name_803"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_803"), new string[6] { "Settlement", "Float", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(804, LocalStringManager.GetConfig("LifeRecord_language", "Name_804"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_804"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(805, LocalStringManager.GetConfig("LifeRecord_language", "Name_805"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_805"), new string[6] { "Settlement", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(806, LocalStringManager.GetConfig("LifeRecord_language", "Name_806"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_806"), new string[6] { "Settlement", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(807, LocalStringManager.GetConfig("LifeRecord_language", "Name_807"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_807"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(808, LocalStringManager.GetConfig("LifeRecord_language", "Name_808"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_808"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(809, LocalStringManager.GetConfig("LifeRecord_language", "Name_809"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_809"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(810, LocalStringManager.GetConfig("LifeRecord_language", "Name_810"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_810"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(811, LocalStringManager.GetConfig("LifeRecord_language", "Name_811"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_811"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 813 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(812, LocalStringManager.GetConfig("LifeRecord_language", "Name_812"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_812"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 813 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(813, LocalStringManager.GetConfig("LifeRecord_language", "Name_813"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_813"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 811, 812 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(814, LocalStringManager.GetConfig("LifeRecord_language", "Name_814"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_814"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(815, LocalStringManager.GetConfig("LifeRecord_language", "Name_815"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_815"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(816, LocalStringManager.GetConfig("LifeRecord_language", "Name_816"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_816"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(817, LocalStringManager.GetConfig("LifeRecord_language", "Name_817"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_817"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(818, LocalStringManager.GetConfig("LifeRecord_language", "Name_818"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_818"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 820 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(819, LocalStringManager.GetConfig("LifeRecord_language", "Name_819"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_819"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 820 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(820, LocalStringManager.GetConfig("LifeRecord_language", "Name_820"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_820"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 818, 819 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(821, LocalStringManager.GetConfig("LifeRecord_language", "Name_821"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_821"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(822, LocalStringManager.GetConfig("LifeRecord_language", "Name_822"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_822"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(823, LocalStringManager.GetConfig("LifeRecord_language", "Name_823"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_823"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 824 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(824, LocalStringManager.GetConfig("LifeRecord_language", "Name_824"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_824"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 823 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(825, LocalStringManager.GetConfig("LifeRecord_language", "Name_825"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_825"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 826 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(826, LocalStringManager.GetConfig("LifeRecord_language", "Name_826"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_826"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 825 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(827, LocalStringManager.GetConfig("LifeRecord_language", "Name_827"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_827"), new string[6] { "Item", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(828, LocalStringManager.GetConfig("LifeRecord_language", "Name_828"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_828"), new string[6] { "Item", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(829, LocalStringManager.GetConfig("LifeRecord_language", "Name_829"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_829"), new string[6] { "Item", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(830, LocalStringManager.GetConfig("LifeRecord_language", "Name_830"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_830"), new string[6] { "Character", "Location", "SecretInformation", "", "", "" }, isSourceRecord: true, new List<short> { 831 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(831, LocalStringManager.GetConfig("LifeRecord_language", "Name_831"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_831"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 830 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(832, LocalStringManager.GetConfig("LifeRecord_language", "Name_832"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_832"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(833, LocalStringManager.GetConfig("LifeRecord_language", "Name_833"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_833"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(834, LocalStringManager.GetConfig("LifeRecord_language", "Name_834"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_834"), new string[6] { "Location", "PunishmentType", "Settlement", "Location", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(835, LocalStringManager.GetConfig("LifeRecord_language", "Name_835"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_835"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(836, LocalStringManager.GetConfig("LifeRecord_language", "Name_836"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_836"), new string[6] { "Location", "PunishmentType", "Settlement", "Settlement", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(837, LocalStringManager.GetConfig("LifeRecord_language", "Name_837"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_837"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(838, LocalStringManager.GetConfig("LifeRecord_language", "Name_838"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_838"), new string[6] { "Location", "Settlement", "OrgGrade", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(839, LocalStringManager.GetConfig("LifeRecord_language", "Name_839"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_839"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems14()
	{
		_dataArray.Add(new LifeRecordItem(840, LocalStringManager.GetConfig("LifeRecord_language", "Name_840"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_840"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(841, LocalStringManager.GetConfig("LifeRecord_language", "Name_841"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_841"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(842, LocalStringManager.GetConfig("LifeRecord_language", "Name_842"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_842"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(843, LocalStringManager.GetConfig("LifeRecord_language", "Name_843"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_843"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(844, LocalStringManager.GetConfig("LifeRecord_language", "Name_844"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_844"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(845, LocalStringManager.GetConfig("LifeRecord_language", "Name_845"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_845"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(846, LocalStringManager.GetConfig("LifeRecord_language", "Name_846"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_846"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(847, LocalStringManager.GetConfig("LifeRecord_language", "Name_847"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_847"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(848, LocalStringManager.GetConfig("LifeRecord_language", "Name_848"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_848"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(849, LocalStringManager.GetConfig("LifeRecord_language", "Name_849"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_849"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(850, LocalStringManager.GetConfig("LifeRecord_language", "Name_850"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_850"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(851, LocalStringManager.GetConfig("LifeRecord_language", "Name_851"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_851"), new string[6] { "Settlement", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(852, LocalStringManager.GetConfig("LifeRecord_language", "Name_852"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_852"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(853, LocalStringManager.GetConfig("LifeRecord_language", "Name_853"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_853"), new string[6] { "Settlement", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(854, LocalStringManager.GetConfig("LifeRecord_language", "Name_854"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_854"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(855, LocalStringManager.GetConfig("LifeRecord_language", "Name_855"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_855"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(856, LocalStringManager.GetConfig("LifeRecord_language", "Name_856"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_856"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(857, LocalStringManager.GetConfig("LifeRecord_language", "Name_857"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_857"), new string[6] { "Settlement", "BodyPartType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(858, LocalStringManager.GetConfig("LifeRecord_language", "Name_858"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_858"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(859, LocalStringManager.GetConfig("LifeRecord_language", "Name_859"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_859"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(860, LocalStringManager.GetConfig("LifeRecord_language", "Name_860"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_860"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(861, LocalStringManager.GetConfig("LifeRecord_language", "Name_861"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_861"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(862, LocalStringManager.GetConfig("LifeRecord_language", "Name_862"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_862"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(863, LocalStringManager.GetConfig("LifeRecord_language", "Name_863"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_863"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(864, LocalStringManager.GetConfig("LifeRecord_language", "Name_864"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_864"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 865 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(865, LocalStringManager.GetConfig("LifeRecord_language", "Name_865"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_865"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short> { 864 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(866, LocalStringManager.GetConfig("LifeRecord_language", "Name_866"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_866"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(867, LocalStringManager.GetConfig("LifeRecord_language", "Name_867"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_867"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(868, LocalStringManager.GetConfig("LifeRecord_language", "Name_868"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_868"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(869, LocalStringManager.GetConfig("LifeRecord_language", "Name_869"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_869"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(870, LocalStringManager.GetConfig("LifeRecord_language", "Name_870"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_870"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 871 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(871, LocalStringManager.GetConfig("LifeRecord_language", "Name_871"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_871"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short> { 870 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(872, LocalStringManager.GetConfig("LifeRecord_language", "Name_872"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_872"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(873, LocalStringManager.GetConfig("LifeRecord_language", "Name_873"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_873"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(874, LocalStringManager.GetConfig("LifeRecord_language", "Name_874"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_874"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(875, LocalStringManager.GetConfig("LifeRecord_language", "Name_875"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_875"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(876, LocalStringManager.GetConfig("LifeRecord_language", "Name_876"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_876"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(877, LocalStringManager.GetConfig("LifeRecord_language", "Name_877"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_877"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(878, LocalStringManager.GetConfig("LifeRecord_language", "Name_878"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_878"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(879, LocalStringManager.GetConfig("LifeRecord_language", "Name_879"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_879"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(880, LocalStringManager.GetConfig("LifeRecord_language", "Name_880"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_880"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(881, LocalStringManager.GetConfig("LifeRecord_language", "Name_881"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_881"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(882, LocalStringManager.GetConfig("LifeRecord_language", "Name_882"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_882"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(883, LocalStringManager.GetConfig("LifeRecord_language", "Name_883"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_883"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(884, LocalStringManager.GetConfig("LifeRecord_language", "Name_884"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_884"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(885, LocalStringManager.GetConfig("LifeRecord_language", "Name_885"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_885"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 886, 1035 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(886, LocalStringManager.GetConfig("LifeRecord_language", "Name_886"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_886"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 885 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(887, LocalStringManager.GetConfig("LifeRecord_language", "Name_887"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_887"), new string[6] { "Character", "Character", "Location", "Settlement", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(888, LocalStringManager.GetConfig("LifeRecord_language", "Name_888"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_888"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 889, 1036 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(889, LocalStringManager.GetConfig("LifeRecord_language", "Name_889"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_889"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 888 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(890, LocalStringManager.GetConfig("LifeRecord_language", "Name_890"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_890"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(891, LocalStringManager.GetConfig("LifeRecord_language", "Name_891"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_891"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(892, LocalStringManager.GetConfig("LifeRecord_language", "Name_892"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_892"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(893, LocalStringManager.GetConfig("LifeRecord_language", "Name_893"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_893"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 894 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(894, LocalStringManager.GetConfig("LifeRecord_language", "Name_894"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_894"), new string[6] { "Character", "Character", "Settlement", "Resource", "Integer", "" }, isSourceRecord: true, new List<short> { 893 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(895, LocalStringManager.GetConfig("LifeRecord_language", "Name_895"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_895"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 896 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(896, LocalStringManager.GetConfig("LifeRecord_language", "Name_896"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_896"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 895 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(897, LocalStringManager.GetConfig("LifeRecord_language", "Name_897"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_897"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 898 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(898, LocalStringManager.GetConfig("LifeRecord_language", "Name_898"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_898"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 897 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(899, LocalStringManager.GetConfig("LifeRecord_language", "Name_899"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_899"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 900 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
	}

	private void CreateItems15()
	{
		_dataArray.Add(new LifeRecordItem(900, LocalStringManager.GetConfig("LifeRecord_language", "Name_900"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_900"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 899 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(901, LocalStringManager.GetConfig("LifeRecord_language", "Name_901"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_901"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 902 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(902, LocalStringManager.GetConfig("LifeRecord_language", "Name_902"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_902"), new string[6] { "Character", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 901 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(903, LocalStringManager.GetConfig("LifeRecord_language", "Name_903"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_903"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(904, LocalStringManager.GetConfig("LifeRecord_language", "Name_904"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_904"), new string[6] { "Location", "Resource", "Integer", "Resource", "Integer", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(905, LocalStringManager.GetConfig("LifeRecord_language", "Name_905"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_905"), new string[6] { "Location", "Resource", "Integer", "Resource", "Integer", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(906, LocalStringManager.GetConfig("LifeRecord_language", "Name_906"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_906"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(907, LocalStringManager.GetConfig("LifeRecord_language", "Name_907"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_907"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(908, LocalStringManager.GetConfig("LifeRecord_language", "Name_908"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_908"), new string[6] { "PunishmentType", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(909, LocalStringManager.GetConfig("LifeRecord_language", "Name_909"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_909"), new string[6] { "PunishmentType", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(910, LocalStringManager.GetConfig("LifeRecord_language", "Name_910"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_910"), new string[6] { "PunishmentType", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(911, LocalStringManager.GetConfig("LifeRecord_language", "Name_911"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_911"), new string[6] { "PunishmentType", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 10, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(912, LocalStringManager.GetConfig("LifeRecord_language", "Name_912"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_912"), new string[6] { "PunishmentType", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(913, LocalStringManager.GetConfig("LifeRecord_language", "Name_913"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_913"), new string[6] { "PunishmentType", "Settlement", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(914, LocalStringManager.GetConfig("LifeRecord_language", "Name_914"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_914"), new string[6] { "PunishmentType", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(915, LocalStringManager.GetConfig("LifeRecord_language", "Name_915"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_915"), new string[6] { "PunishmentType", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(916, LocalStringManager.GetConfig("LifeRecord_language", "Name_916"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_916"), new string[6] { "PunishmentType", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(917, LocalStringManager.GetConfig("LifeRecord_language", "Name_917"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_917"), new string[6] { "PunishmentType", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 10, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(918, LocalStringManager.GetConfig("LifeRecord_language", "Name_918"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_918"), new string[6] { "PunishmentType", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(919, LocalStringManager.GetConfig("LifeRecord_language", "Name_919"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_919"), new string[6] { "PunishmentType", "Settlement", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(920, LocalStringManager.GetConfig("LifeRecord_language", "Name_920"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_920"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(921, LocalStringManager.GetConfig("LifeRecord_language", "Name_921"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_921"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(922, LocalStringManager.GetConfig("LifeRecord_language", "Name_922"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_922"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(923, LocalStringManager.GetConfig("LifeRecord_language", "Name_923"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_923"), new string[6] { "Character", "Settlement", "Resource", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(924, LocalStringManager.GetConfig("LifeRecord_language", "Name_924"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_924"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(925, LocalStringManager.GetConfig("LifeRecord_language", "Name_925"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_925"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(926, LocalStringManager.GetConfig("LifeRecord_language", "Name_926"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_926"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short> { 927 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(927, LocalStringManager.GetConfig("LifeRecord_language", "Name_927"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_927"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 926 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(928, LocalStringManager.GetConfig("LifeRecord_language", "Name_928"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_928"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 929 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(929, LocalStringManager.GetConfig("LifeRecord_language", "Name_929"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_929"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 928 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(930, LocalStringManager.GetConfig("LifeRecord_language", "Name_930"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_930"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short> { 931 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(931, LocalStringManager.GetConfig("LifeRecord_language", "Name_931"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_931"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 930 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(932, LocalStringManager.GetConfig("LifeRecord_language", "Name_932"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_932"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 933 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(933, LocalStringManager.GetConfig("LifeRecord_language", "Name_933"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_933"), new string[6] { "Character", "Character", "Settlement", "Integer", "", "" }, isSourceRecord: true, new List<short> { 932 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(934, LocalStringManager.GetConfig("LifeRecord_language", "Name_934"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_934"), new string[6] { "Character", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(935, LocalStringManager.GetConfig("LifeRecord_language", "Name_935"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_935"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(936, LocalStringManager.GetConfig("LifeRecord_language", "Name_936"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_936"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(937, LocalStringManager.GetConfig("LifeRecord_language", "Name_937"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_937"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(938, LocalStringManager.GetConfig("LifeRecord_language", "Name_938"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_938"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(939, LocalStringManager.GetConfig("LifeRecord_language", "Name_939"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_939"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 960 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(940, LocalStringManager.GetConfig("LifeRecord_language", "Name_940"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_940"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(941, LocalStringManager.GetConfig("LifeRecord_language", "Name_941"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_941"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(942, LocalStringManager.GetConfig("LifeRecord_language", "Name_942"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_942"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(943, LocalStringManager.GetConfig("LifeRecord_language", "Name_943"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_943"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(944, LocalStringManager.GetConfig("LifeRecord_language", "Name_944"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_944"), new string[6] { "Location", "Item", "Item", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(945, LocalStringManager.GetConfig("LifeRecord_language", "Name_945"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_945"), new string[6] { "Location", "Item", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(946, LocalStringManager.GetConfig("LifeRecord_language", "Name_946"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_946"), new string[6] { "Character", "Location", "Item", "Resource", "Integer", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(947, LocalStringManager.GetConfig("LifeRecord_language", "Name_947"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_947"), new string[6] { "Character", "Location", "Item", "Resource", "Integer", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(948, LocalStringManager.GetConfig("LifeRecord_language", "Name_948"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_948"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(949, LocalStringManager.GetConfig("LifeRecord_language", "Name_949"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_949"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(950, LocalStringManager.GetConfig("LifeRecord_language", "Name_950"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_950"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(951, LocalStringManager.GetConfig("LifeRecord_language", "Name_951"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_951"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(952, LocalStringManager.GetConfig("LifeRecord_language", "Name_952"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_952"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(953, LocalStringManager.GetConfig("LifeRecord_language", "Name_953"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_953"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(954, LocalStringManager.GetConfig("LifeRecord_language", "Name_954"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_954"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }, isSourceRecord: true, new List<short> { 956 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(955, LocalStringManager.GetConfig("LifeRecord_language", "Name_955"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_955"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 957 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(956, LocalStringManager.GetConfig("LifeRecord_language", "Name_956"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_956"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 954 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(957, LocalStringManager.GetConfig("LifeRecord_language", "Name_957"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_957"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 955 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(958, LocalStringManager.GetConfig("LifeRecord_language", "Name_958"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_958"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(959, LocalStringManager.GetConfig("LifeRecord_language", "Name_959"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_959"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
	}

	private void CreateItems16()
	{
		_dataArray.Add(new LifeRecordItem(960, LocalStringManager.GetConfig("LifeRecord_language", "Name_960"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_960"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 939 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(961, LocalStringManager.GetConfig("LifeRecord_language", "Name_961"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_961"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(962, LocalStringManager.GetConfig("LifeRecord_language", "Name_962"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_962"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(963, LocalStringManager.GetConfig("LifeRecord_language", "Name_963"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_963"), new string[6] { "Integer", "Resource", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(964, LocalStringManager.GetConfig("LifeRecord_language", "Name_964"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_964"), new string[6] { "Integer", "Resource", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(965, LocalStringManager.GetConfig("LifeRecord_language", "Name_965"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_965"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(966, LocalStringManager.GetConfig("LifeRecord_language", "Name_966"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_966"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(967, LocalStringManager.GetConfig("LifeRecord_language", "Name_967"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_967"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(968, LocalStringManager.GetConfig("LifeRecord_language", "Name_968"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_968"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(969, LocalStringManager.GetConfig("LifeRecord_language", "Name_969"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_969"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(970, LocalStringManager.GetConfig("LifeRecord_language", "Name_970"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_970"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(971, LocalStringManager.GetConfig("LifeRecord_language", "Name_971"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_971"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(972, LocalStringManager.GetConfig("LifeRecord_language", "Name_972"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_972"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(973, LocalStringManager.GetConfig("LifeRecord_language", "Name_973"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_973"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(974, LocalStringManager.GetConfig("LifeRecord_language", "Name_974"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_974"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(975, LocalStringManager.GetConfig("LifeRecord_language", "Name_975"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_975"), new string[6] { "SwordTomb", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(976, LocalStringManager.GetConfig("LifeRecord_language", "Name_976"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_976"), new string[6] { "CharacterTemplate", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(977, LocalStringManager.GetConfig("LifeRecord_language", "Name_977"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_977"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(978, LocalStringManager.GetConfig("LifeRecord_language", "Name_978"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_978"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(979, LocalStringManager.GetConfig("LifeRecord_language", "Name_979"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_979"), new string[6] { "Location", "Item", "Item", "Item", "Item", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(980, LocalStringManager.GetConfig("LifeRecord_language", "Name_980"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_980"), new string[6] { "Location", "Item", "Item", "Item", "Item", "Item" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(981, LocalStringManager.GetConfig("LifeRecord_language", "Name_981"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_981"), new string[6] { "Location", "Item", "Item", "Item", "Item", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(982, LocalStringManager.GetConfig("LifeRecord_language", "Name_982"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_982"), new string[6] { "Location", "Item", "Item", "Item", "Item", "Item" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(983, LocalStringManager.GetConfig("LifeRecord_language", "Name_983"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_983"), new string[6] { "Location", "Building", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(984, LocalStringManager.GetConfig("LifeRecord_language", "Name_984"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_984"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(985, LocalStringManager.GetConfig("LifeRecord_language", "Name_985"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_985"), new string[6] { "Location", "Building", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(986, LocalStringManager.GetConfig("LifeRecord_language", "Name_986"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_986"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(987, LocalStringManager.GetConfig("LifeRecord_language", "Name_987"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_987"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(988, LocalStringManager.GetConfig("LifeRecord_language", "Name_988"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_988"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(989, LocalStringManager.GetConfig("LifeRecord_language", "Name_989"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_989"), new string[6] { "Location", "Building", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(990, LocalStringManager.GetConfig("LifeRecord_language", "Name_990"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_990"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(991, LocalStringManager.GetConfig("LifeRecord_language", "Name_991"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_991"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(992, LocalStringManager.GetConfig("LifeRecord_language", "Name_992"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_992"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(993, LocalStringManager.GetConfig("LifeRecord_language", "Name_993"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_993"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(994, LocalStringManager.GetConfig("LifeRecord_language", "Name_994"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_994"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(995, LocalStringManager.GetConfig("LifeRecord_language", "Name_995"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_995"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(996, LocalStringManager.GetConfig("LifeRecord_language", "Name_996"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_996"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(997, LocalStringManager.GetConfig("LifeRecord_language", "Name_997"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_997"), new string[6] { "Settlement", "Integer", "Location", "Integer", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(998, LocalStringManager.GetConfig("LifeRecord_language", "Name_998"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_998"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(999, LocalStringManager.GetConfig("LifeRecord_language", "Name_999"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_999"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1000, LocalStringManager.GetConfig("LifeRecord_language", "Name_1000"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1000"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1001, LocalStringManager.GetConfig("LifeRecord_language", "Name_1001"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1001"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1002, LocalStringManager.GetConfig("LifeRecord_language", "Name_1002"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1002"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1003, LocalStringManager.GetConfig("LifeRecord_language", "Name_1003"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1003"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1004, LocalStringManager.GetConfig("LifeRecord_language", "Name_1004"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1004"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1005, LocalStringManager.GetConfig("LifeRecord_language", "Name_1005"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1005"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1006, LocalStringManager.GetConfig("LifeRecord_language", "Name_1006"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1006"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1007, LocalStringManager.GetConfig("LifeRecord_language", "Name_1007"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1007"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1008, LocalStringManager.GetConfig("LifeRecord_language", "Name_1008"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1008"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1009, LocalStringManager.GetConfig("LifeRecord_language", "Name_1009"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1009"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1010, LocalStringManager.GetConfig("LifeRecord_language", "Name_1010"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1010"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1011, LocalStringManager.GetConfig("LifeRecord_language", "Name_1011"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1011"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1012, LocalStringManager.GetConfig("LifeRecord_language", "Name_1012"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1012"), new string[6] { "Integer", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1013, LocalStringManager.GetConfig("LifeRecord_language", "Name_1013"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1013"), new string[6] { "PunishmentType", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1014, LocalStringManager.GetConfig("LifeRecord_language", "Name_1014"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1014"), new string[6] { "Character", "Settlement", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1015, LocalStringManager.GetConfig("LifeRecord_language", "Name_1015"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1015"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1016, LocalStringManager.GetConfig("LifeRecord_language", "Name_1016"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1016"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1017, LocalStringManager.GetConfig("LifeRecord_language", "Name_1017"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1017"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1018, LocalStringManager.GetConfig("LifeRecord_language", "Name_1018"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1018"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1019, LocalStringManager.GetConfig("LifeRecord_language", "Name_1019"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1019"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems17()
	{
		_dataArray.Add(new LifeRecordItem(1020, LocalStringManager.GetConfig("LifeRecord_language", "Name_1020"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1020"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1021, LocalStringManager.GetConfig("LifeRecord_language", "Name_1021"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1021"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1022, LocalStringManager.GetConfig("LifeRecord_language", "Name_1022"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1022"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1023, LocalStringManager.GetConfig("LifeRecord_language", "Name_1023"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1023"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 1024 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1024, LocalStringManager.GetConfig("LifeRecord_language", "Name_1024"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1024"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1023 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1025, LocalStringManager.GetConfig("LifeRecord_language", "Name_1025"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1025"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1026, LocalStringManager.GetConfig("LifeRecord_language", "Name_1026"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1026"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1027, LocalStringManager.GetConfig("LifeRecord_language", "Name_1027"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1027"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1028, LocalStringManager.GetConfig("LifeRecord_language", "Name_1028"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1028"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1029 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1029, LocalStringManager.GetConfig("LifeRecord_language", "Name_1029"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1029"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1028 }, -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1030, LocalStringManager.GetConfig("LifeRecord_language", "Name_1030"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1030"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1031 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1031, LocalStringManager.GetConfig("LifeRecord_language", "Name_1031"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1031"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1030 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1032, LocalStringManager.GetConfig("LifeRecord_language", "Name_1032"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1032"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1033, LocalStringManager.GetConfig("LifeRecord_language", "Name_1033"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1033"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short> { 1034 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1034, LocalStringManager.GetConfig("LifeRecord_language", "Name_1034"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1034"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1033 }, -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1035, LocalStringManager.GetConfig("LifeRecord_language", "Name_1035"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1035"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 885 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1036, LocalStringManager.GetConfig("LifeRecord_language", "Name_1036"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1036"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 888 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1037, LocalStringManager.GetConfig("LifeRecord_language", "Name_1037"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1037"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1038 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1038, LocalStringManager.GetConfig("LifeRecord_language", "Name_1038"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1038"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short> { 1037 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1039, LocalStringManager.GetConfig("LifeRecord_language", "Name_1039"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1039"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1040 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1040, LocalStringManager.GetConfig("LifeRecord_language", "Name_1040"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1040"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short> { 1039 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1041, LocalStringManager.GetConfig("LifeRecord_language", "Name_1041"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1041"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1042 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1042, LocalStringManager.GetConfig("LifeRecord_language", "Name_1042"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1042"), new string[6] { "Character", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short> { 1041 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1043, LocalStringManager.GetConfig("LifeRecord_language", "Name_1043"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1043"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1044 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1044, LocalStringManager.GetConfig("LifeRecord_language", "Name_1044"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1044"), new string[6] { "Character", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short> { 1043 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1045, LocalStringManager.GetConfig("LifeRecord_language", "Name_1045"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1045"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1046 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1046, LocalStringManager.GetConfig("LifeRecord_language", "Name_1046"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1046"), new string[6] { "Character", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short> { 1045 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1047, LocalStringManager.GetConfig("LifeRecord_language", "Name_1047"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1047"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short> { 1048 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1048, LocalStringManager.GetConfig("LifeRecord_language", "Name_1048"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1048"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1047 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1049, LocalStringManager.GetConfig("LifeRecord_language", "Name_1049"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1049"), new string[6] { "Location", "Character", "Profession", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1050, LocalStringManager.GetConfig("LifeRecord_language", "Name_1050"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1050"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1051, LocalStringManager.GetConfig("LifeRecord_language", "Name_1051"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1051"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1052 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1052, LocalStringManager.GetConfig("LifeRecord_language", "Name_1052"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1052"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1051 }, -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1053, LocalStringManager.GetConfig("LifeRecord_language", "Name_1053"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1053"), new string[6] { "CombatSkill", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1054, LocalStringManager.GetConfig("LifeRecord_language", "Name_1054"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1054"), new string[6] { "CombatSkill", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1055, LocalStringManager.GetConfig("LifeRecord_language", "Name_1055"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1055"), new string[6] { "CombatSkill", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1056, LocalStringManager.GetConfig("LifeRecord_language", "Name_1056"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1056"), new string[6] { "CombatSkill", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1057, LocalStringManager.GetConfig("LifeRecord_language", "Name_1057"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1057"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1058, LocalStringManager.GetConfig("LifeRecord_language", "Name_1058"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1058"), new string[6] { "Location", "Character", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1059, LocalStringManager.GetConfig("LifeRecord_language", "Name_1059"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1059"), new string[6] { "Location", "Character", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1060, LocalStringManager.GetConfig("LifeRecord_language", "Name_1060"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1060"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1061, LocalStringManager.GetConfig("LifeRecord_language", "Name_1061"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1061"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1062, LocalStringManager.GetConfig("LifeRecord_language", "Name_1062"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1062"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1063, LocalStringManager.GetConfig("LifeRecord_language", "Name_1063"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1063"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1064, LocalStringManager.GetConfig("LifeRecord_language", "Name_1064"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1064"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1065, LocalStringManager.GetConfig("LifeRecord_language", "Name_1065"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1065"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1066, LocalStringManager.GetConfig("LifeRecord_language", "Name_1066"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1066"), new string[6] { "Character", "Location", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1067, LocalStringManager.GetConfig("LifeRecord_language", "Name_1067"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1067"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1068, LocalStringManager.GetConfig("LifeRecord_language", "Name_1068"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1068"), new string[6] { "Character", "Resource", "Integer", "", "", "" }, isSourceRecord: true, new List<short> { 1069 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1069, LocalStringManager.GetConfig("LifeRecord_language", "Name_1069"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1069"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1068 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1070, LocalStringManager.GetConfig("LifeRecord_language", "Name_1070"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1070"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 947 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1071, LocalStringManager.GetConfig("LifeRecord_language", "Name_1071"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1071"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 946 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1072, LocalStringManager.GetConfig("LifeRecord_language", "Name_1072"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1072"), new string[6] { "Character", "Location", "MerchantType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1073, LocalStringManager.GetConfig("LifeRecord_language", "Name_1073"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1073"), new string[6] { "Character", "Location", "MerchantType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1074, LocalStringManager.GetConfig("LifeRecord_language", "Name_1074"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1074"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1075, LocalStringManager.GetConfig("LifeRecord_language", "Name_1075"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1075"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1076, LocalStringManager.GetConfig("LifeRecord_language", "Name_1076"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1076"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1077, LocalStringManager.GetConfig("LifeRecord_language", "Name_1077"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1077"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1078, LocalStringManager.GetConfig("LifeRecord_language", "Name_1078"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1078"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1079, LocalStringManager.GetConfig("LifeRecord_language", "Name_1079"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1079"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
	}

	private void CreateItems18()
	{
		_dataArray.Add(new LifeRecordItem(1080, LocalStringManager.GetConfig("LifeRecord_language", "Name_1080"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1080"), new string[6] { "Settlement", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1081, LocalStringManager.GetConfig("LifeRecord_language", "Name_1081"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1081"), new string[6] { "Settlement", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1082, LocalStringManager.GetConfig("LifeRecord_language", "Name_1082"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1082"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1083, LocalStringManager.GetConfig("LifeRecord_language", "Name_1083"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1083"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1084, LocalStringManager.GetConfig("LifeRecord_language", "Name_1084"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1084"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1085, LocalStringManager.GetConfig("LifeRecord_language", "Name_1085"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1085"), new string[6] { "Character", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1086, LocalStringManager.GetConfig("LifeRecord_language", "Name_1086"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1086"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1087, LocalStringManager.GetConfig("LifeRecord_language", "Name_1087"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1087"), new string[6] { "CharacterTemplate", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1088, LocalStringManager.GetConfig("LifeRecord_language", "Name_1088"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1088"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1089, LocalStringManager.GetConfig("LifeRecord_language", "Name_1089"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1089"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1090, LocalStringManager.GetConfig("LifeRecord_language", "Name_1090"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1090"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1092 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1091, LocalStringManager.GetConfig("LifeRecord_language", "Name_1091"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1091"), new string[6] { "Character", "Item", "", "", "", "" }, isSourceRecord: true, new List<short> { 1093 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1092, LocalStringManager.GetConfig("LifeRecord_language", "Name_1092"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1092"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1090 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1093, LocalStringManager.GetConfig("LifeRecord_language", "Name_1093"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1093"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1091 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1094, LocalStringManager.GetConfig("LifeRecord_language", "Name_1094"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1094"), new string[6] { "Character", "Character", "", "", "", "" }, isSourceRecord: true, new List<short> { 1095 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1095, LocalStringManager.GetConfig("LifeRecord_language", "Name_1095"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1095"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1094 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1096, LocalStringManager.GetConfig("LifeRecord_language", "Name_1096"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1096"), new string[6] { "Character", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1097, LocalStringManager.GetConfig("LifeRecord_language", "Name_1097"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1097"), new string[6] { "Character", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short> { 1098 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1098, LocalStringManager.GetConfig("LifeRecord_language", "Name_1098"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1098"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1097 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1099, LocalStringManager.GetConfig("LifeRecord_language", "Name_1099"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1099"), new string[6] { "Character", "Character", "Item", "", "", "" }, isSourceRecord: true, new List<short> { 1100 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1100, LocalStringManager.GetConfig("LifeRecord_language", "Name_1100"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1100"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1099 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1101, LocalStringManager.GetConfig("LifeRecord_language", "Name_1101"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1101"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1102, LocalStringManager.GetConfig("LifeRecord_language", "Name_1102"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1102"), new string[6] { "Building", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1103, LocalStringManager.GetConfig("LifeRecord_language", "Name_1103"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1103"), new string[6] { "Building", "CombatSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1104, LocalStringManager.GetConfig("LifeRecord_language", "Name_1104"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1104"), new string[6] { "Building", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1105, LocalStringManager.GetConfig("LifeRecord_language", "Name_1105"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1105"), new string[6] { "Building", "CombatSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1106, LocalStringManager.GetConfig("LifeRecord_language", "Name_1106"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1106"), new string[6] { "Character", "Building", "LifeSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1107, LocalStringManager.GetConfig("LifeRecord_language", "Name_1107"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1107"), new string[6] { "Character", "Building", "CombatSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1108, LocalStringManager.GetConfig("LifeRecord_language", "Name_1108"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1108"), new string[6] { "Building", "Item", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1109, LocalStringManager.GetConfig("LifeRecord_language", "Name_1109"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1109"), new string[6] { "Building", "Item", "Integer", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1110, LocalStringManager.GetConfig("LifeRecord_language", "Name_1110"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1110"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1111, LocalStringManager.GetConfig("LifeRecord_language", "Name_1111"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1111"), new string[6] { "Item", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1112, LocalStringManager.GetConfig("LifeRecord_language", "Name_1112"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1112"), new string[6] { "Building", "Integer", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1113, LocalStringManager.GetConfig("LifeRecord_language", "Name_1113"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1113"), new string[6] { "Location", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1114, LocalStringManager.GetConfig("LifeRecord_language", "Name_1114"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1114"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1115, LocalStringManager.GetConfig("LifeRecord_language", "Name_1115"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1115"), new string[6] { "Settlement", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1116, LocalStringManager.GetConfig("LifeRecord_language", "Name_1116"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1116"), new string[6] { "Settlement", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1117, LocalStringManager.GetConfig("LifeRecord_language", "Name_1117"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1117"), new string[6] { "Settlement", "Settlement", "OrgGrade", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1118, LocalStringManager.GetConfig("LifeRecord_language", "Name_1118"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1118"), new string[6] { "Character", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1119, LocalStringManager.GetConfig("LifeRecord_language", "Name_1119"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1119"), new string[6] { "Character", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1120, LocalStringManager.GetConfig("LifeRecord_language", "Name_1120"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1120"), new string[6] { "Character", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1121, LocalStringManager.GetConfig("LifeRecord_language", "Name_1121"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1121"), new string[6] { "Character", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1122, LocalStringManager.GetConfig("LifeRecord_language", "Name_1122"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1122"), new string[6] { "Location", "Character", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1123, LocalStringManager.GetConfig("LifeRecord_language", "Name_1123"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1123"), new string[6] { "Location", "Character", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1124, LocalStringManager.GetConfig("LifeRecord_language", "Name_1124"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1124"), new string[6] { "Location", "Character", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1125, LocalStringManager.GetConfig("LifeRecord_language", "Name_1125"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1125"), new string[6] { "Location", "Character", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1126, LocalStringManager.GetConfig("LifeRecord_language", "Name_1126"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1126"), new string[6] { "Location", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1127, LocalStringManager.GetConfig("LifeRecord_language", "Name_1127"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1127"), new string[6] { "Location", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1128, LocalStringManager.GetConfig("LifeRecord_language", "Name_1128"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1128"), new string[6] { "Location", "Character", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1129, LocalStringManager.GetConfig("LifeRecord_language", "Name_1129"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1129"), new string[6] { "Location", "Character", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1130, LocalStringManager.GetConfig("LifeRecord_language", "Name_1130"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1130"), new string[6] { "Location", "Character", "Location", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1131, LocalStringManager.GetConfig("LifeRecord_language", "Name_1131"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1131"), new string[6] { "Settlement", "Character", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1132, LocalStringManager.GetConfig("LifeRecord_language", "Name_1132"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1132"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1133, LocalStringManager.GetConfig("LifeRecord_language", "Name_1133"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1133"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 0, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1134, LocalStringManager.GetConfig("LifeRecord_language", "Name_1134"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1134"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1135, LocalStringManager.GetConfig("LifeRecord_language", "Name_1135"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1135"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1136, LocalStringManager.GetConfig("LifeRecord_language", "Name_1136"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1136"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 65, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1137, LocalStringManager.GetConfig("LifeRecord_language", "Name_1137"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1137"), new string[6] { "Item", "Item", "Feast", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1138, LocalStringManager.GetConfig("LifeRecord_language", "Name_1138"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1138"), new string[6] { "Item", "Item", "Feast", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 75, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1139, LocalStringManager.GetConfig("LifeRecord_language", "Name_1139"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1139"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 55, -1, ELifeRecordDisplayType.Relation));
	}

	private void CreateItems19()
	{
		_dataArray.Add(new LifeRecordItem(1140, LocalStringManager.GetConfig("LifeRecord_language", "Name_1140"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1140"), new string[6] { "Item", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1141, LocalStringManager.GetConfig("LifeRecord_language", "Name_1141"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1141"), new string[6] { "Item", "Item", "Feast", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 65, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1142, LocalStringManager.GetConfig("LifeRecord_language", "Name_1142"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1142"), new string[6] { "Item", "Item", "Feast", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1143, LocalStringManager.GetConfig("LifeRecord_language", "Name_1143"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1143"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1144, LocalStringManager.GetConfig("LifeRecord_language", "Name_1144"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1144"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1145, LocalStringManager.GetConfig("LifeRecord_language", "Name_1145"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1145"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1146, LocalStringManager.GetConfig("LifeRecord_language", "Name_1146"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1146"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1147, LocalStringManager.GetConfig("LifeRecord_language", "Name_1147"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1147"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1148, LocalStringManager.GetConfig("LifeRecord_language", "Name_1148"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1148"), new string[6] { "Settlement", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1149, LocalStringManager.GetConfig("LifeRecord_language", "Name_1149"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1149"), new string[6] { "Settlement", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1150, LocalStringManager.GetConfig("LifeRecord_language", "Name_1150"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1150"), new string[6] { "Settlement", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1151, LocalStringManager.GetConfig("LifeRecord_language", "Name_1151"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1151"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1152, LocalStringManager.GetConfig("LifeRecord_language", "Name_1152"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1152"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1153, LocalStringManager.GetConfig("LifeRecord_language", "Name_1153"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1153"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1154, LocalStringManager.GetConfig("LifeRecord_language", "Name_1154"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1154"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1155, LocalStringManager.GetConfig("LifeRecord_language", "Name_1155"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1155"), new string[6] { "SecretInformation", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1156, LocalStringManager.GetConfig("LifeRecord_language", "Name_1156"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1156"), new string[6] { "SecretInformation", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1157, LocalStringManager.GetConfig("LifeRecord_language", "Name_1157"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1157"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1158, LocalStringManager.GetConfig("LifeRecord_language", "Name_1158"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1158"), new string[6] { "Location", "CombatSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1159, LocalStringManager.GetConfig("LifeRecord_language", "Name_1159"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1159"), new string[6] { "Location", "PersonalityType", "CombatSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1160, LocalStringManager.GetConfig("LifeRecord_language", "Name_1160"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1160"), new string[6] { "Character", "Location", "CombatSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1161, LocalStringManager.GetConfig("LifeRecord_language", "Name_1161"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1161"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1162, LocalStringManager.GetConfig("LifeRecord_language", "Name_1162"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1162"), new string[6] { "Location", "PersonalityType", "LifeSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1163, LocalStringManager.GetConfig("LifeRecord_language", "Name_1163"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1163"), new string[6] { "Character", "Location", "LifeSkillType", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1164, LocalStringManager.GetConfig("LifeRecord_language", "Name_1164"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1164"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1165, LocalStringManager.GetConfig("LifeRecord_language", "Name_1165"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1165"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1166, LocalStringManager.GetConfig("LifeRecord_language", "Name_1166"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1166"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1167, LocalStringManager.GetConfig("LifeRecord_language", "Name_1167"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1167"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1168, LocalStringManager.GetConfig("LifeRecord_language", "Name_1168"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1168"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1169, LocalStringManager.GetConfig("LifeRecord_language", "Name_1169"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1169"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1170, LocalStringManager.GetConfig("LifeRecord_language", "Name_1170"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1170"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1171, LocalStringManager.GetConfig("LifeRecord_language", "Name_1171"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1171"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1172, LocalStringManager.GetConfig("LifeRecord_language", "Name_1172"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1172"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1173, LocalStringManager.GetConfig("LifeRecord_language", "Name_1173"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1173"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1174, LocalStringManager.GetConfig("LifeRecord_language", "Name_1174"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1174"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1175, LocalStringManager.GetConfig("LifeRecord_language", "Name_1175"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1175"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1176, LocalStringManager.GetConfig("LifeRecord_language", "Name_1176"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1176"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1177, LocalStringManager.GetConfig("LifeRecord_language", "Name_1177"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1177"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1178, LocalStringManager.GetConfig("LifeRecord_language", "Name_1178"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1178"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1179, LocalStringManager.GetConfig("LifeRecord_language", "Name_1179"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1179"), new string[6] { "Location", "Integer", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1180, LocalStringManager.GetConfig("LifeRecord_language", "Name_1180"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1180"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1181, LocalStringManager.GetConfig("LifeRecord_language", "Name_1181"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1181"), new string[6] { "Location", "Integer", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1182, LocalStringManager.GetConfig("LifeRecord_language", "Name_1182"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1182"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1183, LocalStringManager.GetConfig("LifeRecord_language", "Name_1183"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1183"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1184, LocalStringManager.GetConfig("LifeRecord_language", "Name_1184"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1184"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1185, LocalStringManager.GetConfig("LifeRecord_language", "Name_1185"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1185"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1186, LocalStringManager.GetConfig("LifeRecord_language", "Name_1186"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1186"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1187, LocalStringManager.GetConfig("LifeRecord_language", "Name_1187"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1187"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1188, LocalStringManager.GetConfig("LifeRecord_language", "Name_1188"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1188"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1189, LocalStringManager.GetConfig("LifeRecord_language", "Name_1189"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1189"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1190, LocalStringManager.GetConfig("LifeRecord_language", "Name_1190"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1190"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1191, LocalStringManager.GetConfig("LifeRecord_language", "Name_1191"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1191"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1192, LocalStringManager.GetConfig("LifeRecord_language", "Name_1192"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1192"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1193, LocalStringManager.GetConfig("LifeRecord_language", "Name_1193"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1193"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1194, LocalStringManager.GetConfig("LifeRecord_language", "Name_1194"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1194"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1195, LocalStringManager.GetConfig("LifeRecord_language", "Name_1195"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1195"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1384 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1196, LocalStringManager.GetConfig("LifeRecord_language", "Name_1196"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1196"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1197, LocalStringManager.GetConfig("LifeRecord_language", "Name_1197"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1197"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1198, LocalStringManager.GetConfig("LifeRecord_language", "Name_1198"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1198"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1199, LocalStringManager.GetConfig("LifeRecord_language", "Name_1199"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1199"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
	}

	private void CreateItems20()
	{
		_dataArray.Add(new LifeRecordItem(1200, LocalStringManager.GetConfig("LifeRecord_language", "Name_1200"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1200"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1201, LocalStringManager.GetConfig("LifeRecord_language", "Name_1201"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1201"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1202, LocalStringManager.GetConfig("LifeRecord_language", "Name_1202"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1202"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1203, LocalStringManager.GetConfig("LifeRecord_language", "Name_1203"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1203"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1204, LocalStringManager.GetConfig("LifeRecord_language", "Name_1204"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1204"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1205, LocalStringManager.GetConfig("LifeRecord_language", "Name_1205"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1205"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1206, LocalStringManager.GetConfig("LifeRecord_language", "Name_1206"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1206"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1207, LocalStringManager.GetConfig("LifeRecord_language", "Name_1207"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1207"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1208, LocalStringManager.GetConfig("LifeRecord_language", "Name_1208"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1208"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1209, LocalStringManager.GetConfig("LifeRecord_language", "Name_1209"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1209"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1210, LocalStringManager.GetConfig("LifeRecord_language", "Name_1210"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1210"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1211, LocalStringManager.GetConfig("LifeRecord_language", "Name_1211"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1211"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1212, LocalStringManager.GetConfig("LifeRecord_language", "Name_1212"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1212"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1213, LocalStringManager.GetConfig("LifeRecord_language", "Name_1213"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1213"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1214, LocalStringManager.GetConfig("LifeRecord_language", "Name_1214"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1214"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1215, LocalStringManager.GetConfig("LifeRecord_language", "Name_1215"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1215"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1216, LocalStringManager.GetConfig("LifeRecord_language", "Name_1216"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1216"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1217, LocalStringManager.GetConfig("LifeRecord_language", "Name_1217"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1217"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1218, LocalStringManager.GetConfig("LifeRecord_language", "Name_1218"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1218"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1219, LocalStringManager.GetConfig("LifeRecord_language", "Name_1219"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1219"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1220, LocalStringManager.GetConfig("LifeRecord_language", "Name_1220"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1220"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1221, LocalStringManager.GetConfig("LifeRecord_language", "Name_1221"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1221"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1222, LocalStringManager.GetConfig("LifeRecord_language", "Name_1222"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1222"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1223, LocalStringManager.GetConfig("LifeRecord_language", "Name_1223"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1223"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1224, LocalStringManager.GetConfig("LifeRecord_language", "Name_1224"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1224"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1225, LocalStringManager.GetConfig("LifeRecord_language", "Name_1225"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1225"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1226, LocalStringManager.GetConfig("LifeRecord_language", "Name_1226"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1226"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1227, LocalStringManager.GetConfig("LifeRecord_language", "Name_1227"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1227"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1228, LocalStringManager.GetConfig("LifeRecord_language", "Name_1228"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1228"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1229, LocalStringManager.GetConfig("LifeRecord_language", "Name_1229"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1229"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1230, LocalStringManager.GetConfig("LifeRecord_language", "Name_1230"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1230"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1231, LocalStringManager.GetConfig("LifeRecord_language", "Name_1231"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1231"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1232, LocalStringManager.GetConfig("LifeRecord_language", "Name_1232"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1232"), new string[6] { "Location", "Integer", "Item", "Integer", "Item", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1233, LocalStringManager.GetConfig("LifeRecord_language", "Name_1233"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1233"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1234, LocalStringManager.GetConfig("LifeRecord_language", "Name_1234"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1234"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1235, LocalStringManager.GetConfig("LifeRecord_language", "Name_1235"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1235"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1236, LocalStringManager.GetConfig("LifeRecord_language", "Name_1236"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1236"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1237, LocalStringManager.GetConfig("LifeRecord_language", "Name_1237"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1237"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1238, LocalStringManager.GetConfig("LifeRecord_language", "Name_1238"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1238"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1239, LocalStringManager.GetConfig("LifeRecord_language", "Name_1239"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1239"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1240, LocalStringManager.GetConfig("LifeRecord_language", "Name_1240"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1240"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1241, LocalStringManager.GetConfig("LifeRecord_language", "Name_1241"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1241"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1242, LocalStringManager.GetConfig("LifeRecord_language", "Name_1242"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1242"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1243, LocalStringManager.GetConfig("LifeRecord_language", "Name_1243"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1243"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1244, LocalStringManager.GetConfig("LifeRecord_language", "Name_1244"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1244"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1245, LocalStringManager.GetConfig("LifeRecord_language", "Name_1245"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1245"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1246, LocalStringManager.GetConfig("LifeRecord_language", "Name_1246"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1246"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1247, LocalStringManager.GetConfig("LifeRecord_language", "Name_1247"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1247"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1248, LocalStringManager.GetConfig("LifeRecord_language", "Name_1248"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1248"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1249, LocalStringManager.GetConfig("LifeRecord_language", "Name_1249"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1249"), new string[6] { "Location", "Integer", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1250, LocalStringManager.GetConfig("LifeRecord_language", "Name_1250"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1250"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1251, LocalStringManager.GetConfig("LifeRecord_language", "Name_1251"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1251"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1252, LocalStringManager.GetConfig("LifeRecord_language", "Name_1252"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1252"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1253, LocalStringManager.GetConfig("LifeRecord_language", "Name_1253"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1253"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1254, LocalStringManager.GetConfig("LifeRecord_language", "Name_1254"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1254"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1255, LocalStringManager.GetConfig("LifeRecord_language", "Name_1255"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1255"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1256, LocalStringManager.GetConfig("LifeRecord_language", "Name_1256"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1256"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1257, LocalStringManager.GetConfig("LifeRecord_language", "Name_1257"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1257"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1258, LocalStringManager.GetConfig("LifeRecord_language", "Name_1258"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1258"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1259, LocalStringManager.GetConfig("LifeRecord_language", "Name_1259"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1259"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
	}

	private void CreateItems21()
	{
		_dataArray.Add(new LifeRecordItem(1260, LocalStringManager.GetConfig("LifeRecord_language", "Name_1260"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1260"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1261, LocalStringManager.GetConfig("LifeRecord_language", "Name_1261"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1261"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1262, LocalStringManager.GetConfig("LifeRecord_language", "Name_1262"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1262"), new string[6] { "Location", "LifeSkillType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1263, LocalStringManager.GetConfig("LifeRecord_language", "Name_1263"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1263"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1264, LocalStringManager.GetConfig("LifeRecord_language", "Name_1264"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1264"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1265, LocalStringManager.GetConfig("LifeRecord_language", "Name_1265"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1265"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1266, LocalStringManager.GetConfig("LifeRecord_language", "Name_1266"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1266"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1267, LocalStringManager.GetConfig("LifeRecord_language", "Name_1267"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1267"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1268, LocalStringManager.GetConfig("LifeRecord_language", "Name_1268"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1268"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short> { 1390 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1269, LocalStringManager.GetConfig("LifeRecord_language", "Name_1269"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1269"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1270, LocalStringManager.GetConfig("LifeRecord_language", "Name_1270"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1270"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short> { 1391 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1271, LocalStringManager.GetConfig("LifeRecord_language", "Name_1271"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1271"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1272, LocalStringManager.GetConfig("LifeRecord_language", "Name_1272"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1272"), new string[6] { "Location", "Integer", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1273, LocalStringManager.GetConfig("LifeRecord_language", "Name_1273"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1273"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1274, LocalStringManager.GetConfig("LifeRecord_language", "Name_1274"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1274"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1275, LocalStringManager.GetConfig("LifeRecord_language", "Name_1275"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1275"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1276, LocalStringManager.GetConfig("LifeRecord_language", "Name_1276"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1276"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1277, LocalStringManager.GetConfig("LifeRecord_language", "Name_1277"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1277"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1278, LocalStringManager.GetConfig("LifeRecord_language", "Name_1278"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1278"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1279, LocalStringManager.GetConfig("LifeRecord_language", "Name_1279"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1279"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1280, LocalStringManager.GetConfig("LifeRecord_language", "Name_1280"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1280"), new string[6] { "Location", "Settlement", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1281, LocalStringManager.GetConfig("LifeRecord_language", "Name_1281"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1281"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1282, LocalStringManager.GetConfig("LifeRecord_language", "Name_1282"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1282"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1283, LocalStringManager.GetConfig("LifeRecord_language", "Name_1283"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1283"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1284, LocalStringManager.GetConfig("LifeRecord_language", "Name_1284"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1284"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1285, LocalStringManager.GetConfig("LifeRecord_language", "Name_1285"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1285"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1286, LocalStringManager.GetConfig("LifeRecord_language", "Name_1286"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1286"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1287, LocalStringManager.GetConfig("LifeRecord_language", "Name_1287"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1287"), new string[6] { "Location", "Settlement", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1288, LocalStringManager.GetConfig("LifeRecord_language", "Name_1288"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1288"), new string[6] { "Location", "Integer", "Resource", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1289, LocalStringManager.GetConfig("LifeRecord_language", "Name_1289"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1289"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1290, LocalStringManager.GetConfig("LifeRecord_language", "Name_1290"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1290"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1291, LocalStringManager.GetConfig("LifeRecord_language", "Name_1291"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1291"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1292, LocalStringManager.GetConfig("LifeRecord_language", "Name_1292"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1292"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1293, LocalStringManager.GetConfig("LifeRecord_language", "Name_1293"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1293"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1294, LocalStringManager.GetConfig("LifeRecord_language", "Name_1294"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1294"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1295, LocalStringManager.GetConfig("LifeRecord_language", "Name_1295"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1295"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1296, LocalStringManager.GetConfig("LifeRecord_language", "Name_1296"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1296"), new string[6] { "Location", "SecretInformation", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1297, LocalStringManager.GetConfig("LifeRecord_language", "Name_1297"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1297"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1298, LocalStringManager.GetConfig("LifeRecord_language", "Name_1298"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1298"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short> { 1392 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1299, LocalStringManager.GetConfig("LifeRecord_language", "Name_1299"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1299"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1300, LocalStringManager.GetConfig("LifeRecord_language", "Name_1300"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1300"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1301, LocalStringManager.GetConfig("LifeRecord_language", "Name_1301"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1301"), new string[6] { "Character", "Character", "Location", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1302, LocalStringManager.GetConfig("LifeRecord_language", "Name_1302"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1302"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1303, LocalStringManager.GetConfig("LifeRecord_language", "Name_1303"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1303"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1304, LocalStringManager.GetConfig("LifeRecord_language", "Name_1304"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1304"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1305, LocalStringManager.GetConfig("LifeRecord_language", "Name_1305"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1305"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1306, LocalStringManager.GetConfig("LifeRecord_language", "Name_1306"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1306"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1307, LocalStringManager.GetConfig("LifeRecord_language", "Name_1307"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1307"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1308, LocalStringManager.GetConfig("LifeRecord_language", "Name_1308"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1308"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1309, LocalStringManager.GetConfig("LifeRecord_language", "Name_1309"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1309"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1310, LocalStringManager.GetConfig("LifeRecord_language", "Name_1310"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1310"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1311, LocalStringManager.GetConfig("LifeRecord_language", "Name_1311"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1311"), new string[6] { "Location", "CombatSkill", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1312, LocalStringManager.GetConfig("LifeRecord_language", "Name_1312"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1312"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1313, LocalStringManager.GetConfig("LifeRecord_language", "Name_1313"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1313"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1314, LocalStringManager.GetConfig("LifeRecord_language", "Name_1314"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1314"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1315, LocalStringManager.GetConfig("LifeRecord_language", "Name_1315"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1315"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1316, LocalStringManager.GetConfig("LifeRecord_language", "Name_1316"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1316"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1317, LocalStringManager.GetConfig("LifeRecord_language", "Name_1317"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1317"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1318, LocalStringManager.GetConfig("LifeRecord_language", "Name_1318"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1318"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1319, LocalStringManager.GetConfig("LifeRecord_language", "Name_1319"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1319"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
	}

	private void CreateItems22()
	{
		_dataArray.Add(new LifeRecordItem(1320, LocalStringManager.GetConfig("LifeRecord_language", "Name_1320"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1320"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1321, LocalStringManager.GetConfig("LifeRecord_language", "Name_1321"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1321"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1322, LocalStringManager.GetConfig("LifeRecord_language", "Name_1322"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1322"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1323, LocalStringManager.GetConfig("LifeRecord_language", "Name_1323"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1323"), new string[6] { "Character", "Location", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1324, LocalStringManager.GetConfig("LifeRecord_language", "Name_1324"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1324"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1325, LocalStringManager.GetConfig("LifeRecord_language", "Name_1325"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1325"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1326, LocalStringManager.GetConfig("LifeRecord_language", "Name_1326"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1326"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1327, LocalStringManager.GetConfig("LifeRecord_language", "Name_1327"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1327"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1328, LocalStringManager.GetConfig("LifeRecord_language", "Name_1328"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1328"), new string[6] { "Character", "Location", "CombatSkill", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1329, LocalStringManager.GetConfig("LifeRecord_language", "Name_1329"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1329"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1330, LocalStringManager.GetConfig("LifeRecord_language", "Name_1330"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1330"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1331, LocalStringManager.GetConfig("LifeRecord_language", "Name_1331"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1331"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1332, LocalStringManager.GetConfig("LifeRecord_language", "Name_1332"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1332"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1333, LocalStringManager.GetConfig("LifeRecord_language", "Name_1333"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1333"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1334, LocalStringManager.GetConfig("LifeRecord_language", "Name_1334"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1334"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1335, LocalStringManager.GetConfig("LifeRecord_language", "Name_1335"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1335"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1336, LocalStringManager.GetConfig("LifeRecord_language", "Name_1336"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1336"), new string[6] { "Location", "MerchantType", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1337, LocalStringManager.GetConfig("LifeRecord_language", "Name_1337"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1337"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1338, LocalStringManager.GetConfig("LifeRecord_language", "Name_1338"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1338"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1339, LocalStringManager.GetConfig("LifeRecord_language", "Name_1339"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1339"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1340, LocalStringManager.GetConfig("LifeRecord_language", "Name_1340"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1340"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1341, LocalStringManager.GetConfig("LifeRecord_language", "Name_1341"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1341"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1342, LocalStringManager.GetConfig("LifeRecord_language", "Name_1342"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1342"), new string[6] { "Character", "Location", "Settlement", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1343, LocalStringManager.GetConfig("LifeRecord_language", "Name_1343"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1343"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1344, LocalStringManager.GetConfig("LifeRecord_language", "Name_1344"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1344"), new string[6] { "Character", "Location", "Settlement", "Integer", "Item", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1345, LocalStringManager.GetConfig("LifeRecord_language", "Name_1345"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1345"), new string[6] { "Location", "Settlement", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1346, LocalStringManager.GetConfig("LifeRecord_language", "Name_1346"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1346"), new string[6] { "Character", "Location", "Settlement", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1347, LocalStringManager.GetConfig("LifeRecord_language", "Name_1347"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1347"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1348, LocalStringManager.GetConfig("LifeRecord_language", "Name_1348"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1348"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1349, LocalStringManager.GetConfig("LifeRecord_language", "Name_1349"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1349"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1350, LocalStringManager.GetConfig("LifeRecord_language", "Name_1350"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1350"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1351, LocalStringManager.GetConfig("LifeRecord_language", "Name_1351"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1351"), new string[6] { "Location", "MerchantType", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1352, LocalStringManager.GetConfig("LifeRecord_language", "Name_1352"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1352"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1353, LocalStringManager.GetConfig("LifeRecord_language", "Name_1353"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1353"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1354, LocalStringManager.GetConfig("LifeRecord_language", "Name_1354"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1354"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1355, LocalStringManager.GetConfig("LifeRecord_language", "Name_1355"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1355"), new string[6] { "Location", "Integer", "Resource", "MerchantType", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1356, LocalStringManager.GetConfig("LifeRecord_language", "Name_1356"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1356"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1357, LocalStringManager.GetConfig("LifeRecord_language", "Name_1357"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1357"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1358, LocalStringManager.GetConfig("LifeRecord_language", "Name_1358"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1358"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1359, LocalStringManager.GetConfig("LifeRecord_language", "Name_1359"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1359"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1360, LocalStringManager.GetConfig("LifeRecord_language", "Name_1360"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1360"), new string[6] { "Location", "Integer", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1361, LocalStringManager.GetConfig("LifeRecord_language", "Name_1361"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1361"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1362, LocalStringManager.GetConfig("LifeRecord_language", "Name_1362"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1362"), new string[6] { "Character", "Location", "SecretInformationTemplate", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1363, LocalStringManager.GetConfig("LifeRecord_language", "Name_1363"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1363"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1364, LocalStringManager.GetConfig("LifeRecord_language", "Name_1364"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1364"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1402 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1365, LocalStringManager.GetConfig("LifeRecord_language", "Name_1365"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1365"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1403 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1366, LocalStringManager.GetConfig("LifeRecord_language", "Name_1366"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1366"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1367, LocalStringManager.GetConfig("LifeRecord_language", "Name_1367"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1367"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1368, LocalStringManager.GetConfig("LifeRecord_language", "Name_1368"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1368"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1369, LocalStringManager.GetConfig("LifeRecord_language", "Name_1369"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1369"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1370, LocalStringManager.GetConfig("LifeRecord_language", "Name_1370"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1370"), new string[6] { "Location", "Resource", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1371, LocalStringManager.GetConfig("LifeRecord_language", "Name_1371"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1371"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1372, LocalStringManager.GetConfig("LifeRecord_language", "Name_1372"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1372"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1373, LocalStringManager.GetConfig("LifeRecord_language", "Name_1373"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1373"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1374, LocalStringManager.GetConfig("LifeRecord_language", "Name_1374"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1374"), new string[6] { "Location", "JiaoLoong", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1375, LocalStringManager.GetConfig("LifeRecord_language", "Name_1375"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1375"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1376, LocalStringManager.GetConfig("LifeRecord_language", "Name_1376"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1376"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1377, LocalStringManager.GetConfig("LifeRecord_language", "Name_1377"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1377"), new string[6] { "Location", "Item", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Produce));
		_dataArray.Add(new LifeRecordItem(1378, LocalStringManager.GetConfig("LifeRecord_language", "Name_1378"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1378"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1379, LocalStringManager.GetConfig("LifeRecord_language", "Name_1379"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1379"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
	}

	private void CreateItems23()
	{
		_dataArray.Add(new LifeRecordItem(1380, LocalStringManager.GetConfig("LifeRecord_language", "Name_1380"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1380"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1381, LocalStringManager.GetConfig("LifeRecord_language", "Name_1381"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1381"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1382, LocalStringManager.GetConfig("LifeRecord_language", "Name_1382"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1382"), new string[6] { "Character", "Location", "Integer", "Item", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1383, LocalStringManager.GetConfig("LifeRecord_language", "Name_1383"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1383"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1384, LocalStringManager.GetConfig("LifeRecord_language", "Name_1384"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1384"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1195 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1385, LocalStringManager.GetConfig("LifeRecord_language", "Name_1385"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1385"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1386, LocalStringManager.GetConfig("LifeRecord_language", "Name_1386"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1386"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1387, LocalStringManager.GetConfig("LifeRecord_language", "Name_1387"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1387"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Absolute, 20, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1388, LocalStringManager.GetConfig("LifeRecord_language", "Name_1388"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1388"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1389, LocalStringManager.GetConfig("LifeRecord_language", "Name_1389"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1389"), new string[6] { "Character", "Location", "Character", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1390, LocalStringManager.GetConfig("LifeRecord_language", "Name_1390"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1390"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1268 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1391, LocalStringManager.GetConfig("LifeRecord_language", "Name_1391"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1391"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1270 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Study));
		_dataArray.Add(new LifeRecordItem(1392, LocalStringManager.GetConfig("LifeRecord_language", "Name_1392"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1392"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1298 }, -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1393, LocalStringManager.GetConfig("LifeRecord_language", "Name_1393"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1393"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1394, LocalStringManager.GetConfig("LifeRecord_language", "Name_1394"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1394"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1395, LocalStringManager.GetConfig("LifeRecord_language", "Name_1395"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1395"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1396, LocalStringManager.GetConfig("LifeRecord_language", "Name_1396"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1396"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1397, LocalStringManager.GetConfig("LifeRecord_language", "Name_1397"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1397"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1398, LocalStringManager.GetConfig("LifeRecord_language", "Name_1398"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1398"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1399, LocalStringManager.GetConfig("LifeRecord_language", "Name_1399"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1399"), new string[6] { "Location", "CharacterTemplate", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1400, LocalStringManager.GetConfig("LifeRecord_language", "Name_1400"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1400"), new string[6] { "Location", "Character", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, -1, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1401, LocalStringManager.GetConfig("LifeRecord_language", "Name_1401"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1401"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1401 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1402, LocalStringManager.GetConfig("LifeRecord_language", "Name_1402"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1402"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1364 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1403, LocalStringManager.GetConfig("LifeRecord_language", "Name_1403"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1403"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1365 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1404, LocalStringManager.GetConfig("LifeRecord_language", "Name_1404"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1404"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 80, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1405, LocalStringManager.GetConfig("LifeRecord_language", "Name_1405"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1405"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short> { 1406 }, -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1406, LocalStringManager.GetConfig("LifeRecord_language", "Name_1406"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1406"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1405 }, -30000, ELifeRecordScoreType.Normal, 20, -1, ELifeRecordDisplayType.Combat));
		_dataArray.Add(new LifeRecordItem(1407, LocalStringManager.GetConfig("LifeRecord_language", "Name_1407"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1407"), new string[6] { "Character", "Location", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 90, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1408, LocalStringManager.GetConfig("LifeRecord_language", "Name_1408"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1408"), new string[6] { "Location", "Integer", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 100, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1409, LocalStringManager.GetConfig("LifeRecord_language", "Name_1409"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1409"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 100, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1410, LocalStringManager.GetConfig("LifeRecord_language", "Name_1410"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1410"), new string[6] { "Cricket", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1411, LocalStringManager.GetConfig("LifeRecord_language", "Name_1411"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1411"), new string[6] { "Cricket", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Great));
		_dataArray.Add(new LifeRecordItem(1412, LocalStringManager.GetConfig("LifeRecord_language", "Name_1412"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1412"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1413, LocalStringManager.GetConfig("LifeRecord_language", "Name_1413"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1413"), new string[6] { "Location", "Adventure", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1414, LocalStringManager.GetConfig("LifeRecord_language", "Name_1414"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1414"), new string[6] { "OrgGrade", "OrgGrade", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 70, -1, ELifeRecordDisplayType.Relation));
		_dataArray.Add(new LifeRecordItem(1415, LocalStringManager.GetConfig("LifeRecord_language", "Name_1415"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1415"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1416, LocalStringManager.GetConfig("LifeRecord_language", "Name_1416"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1416"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1417, LocalStringManager.GetConfig("LifeRecord_language", "Name_1417"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1417"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1418, LocalStringManager.GetConfig("LifeRecord_language", "Name_1418"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1418"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Invalid, -1, -1, ELifeRecordDisplayType.NoCategory));
		_dataArray.Add(new LifeRecordItem(1419, LocalStringManager.GetConfig("LifeRecord_language", "Name_1419"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1419"), new string[6] { "Character", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 30, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1420, LocalStringManager.GetConfig("LifeRecord_language", "Name_1420"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1420"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1421, LocalStringManager.GetConfig("LifeRecord_language", "Name_1421"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1421"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1422, LocalStringManager.GetConfig("LifeRecord_language", "Name_1422"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1422"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1423, LocalStringManager.GetConfig("LifeRecord_language", "Name_1423"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1423"), new string[6] { "Location", "Character", "Item", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Negative));
		_dataArray.Add(new LifeRecordItem(1424, LocalStringManager.GetConfig("LifeRecord_language", "Name_1424"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1424"), new string[6] { "Location", "", "", "", "", "" }, isSourceRecord: true, new List<short>(), -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Crime));
		_dataArray.Add(new LifeRecordItem(1425, LocalStringManager.GetConfig("LifeRecord_language", "Name_1425"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1425"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }, isSourceRecord: true, new List<short> { 1433 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1426, LocalStringManager.GetConfig("LifeRecord_language", "Name_1426"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1426"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }, isSourceRecord: true, new List<short> { 1434 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1427, LocalStringManager.GetConfig("LifeRecord_language", "Name_1427"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1427"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }, isSourceRecord: true, new List<short> { 1435 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1428, LocalStringManager.GetConfig("LifeRecord_language", "Name_1428"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1428"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }, isSourceRecord: true, new List<short> { 1436 }, -30000, ELifeRecordScoreType.Normal, 60, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1429, LocalStringManager.GetConfig("LifeRecord_language", "Name_1429"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1429"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }, isSourceRecord: true, new List<short> { 1437 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1430, LocalStringManager.GetConfig("LifeRecord_language", "Name_1430"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1430"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }, isSourceRecord: true, new List<short> { 1438 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1431, LocalStringManager.GetConfig("LifeRecord_language", "Name_1431"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1431"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }, isSourceRecord: true, new List<short> { 1439 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1432, LocalStringManager.GetConfig("LifeRecord_language", "Name_1432"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1432"), new string[6] { "Character", "Location", "Integer", "Resource", "", "" }, isSourceRecord: true, new List<short> { 1440 }, -30000, ELifeRecordScoreType.Normal, 40, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1433, LocalStringManager.GetConfig("LifeRecord_language", "Name_1433"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1433"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1425 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1434, LocalStringManager.GetConfig("LifeRecord_language", "Name_1434"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1434"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1426 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1435, LocalStringManager.GetConfig("LifeRecord_language", "Name_1435"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1435"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1427 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1436, LocalStringManager.GetConfig("LifeRecord_language", "Name_1436"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1436"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1428 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1437, LocalStringManager.GetConfig("LifeRecord_language", "Name_1437"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1437"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1429 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1438, LocalStringManager.GetConfig("LifeRecord_language", "Name_1438"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1438"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1430 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
		_dataArray.Add(new LifeRecordItem(1439, LocalStringManager.GetConfig("LifeRecord_language", "Name_1439"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1439"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1431 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
	}

	private void CreateItems24()
	{
		_dataArray.Add(new LifeRecordItem(1440, LocalStringManager.GetConfig("LifeRecord_language", "Name_1440"), LocalStringManager.GetConfig("LifeRecord_language", "Desc_1440"), new string[6] { "", "", "", "", "", "" }, isSourceRecord: false, new List<short> { 1432 }, -30000, ELifeRecordScoreType.Normal, 50, -1, ELifeRecordDisplayType.Normal));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<LifeRecordItem>(1441);
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
		CreateItems17();
		CreateItems18();
		CreateItems19();
		CreateItems20();
		CreateItems21();
		CreateItems22();
		CreateItems23();
		CreateItems24();
	}
}

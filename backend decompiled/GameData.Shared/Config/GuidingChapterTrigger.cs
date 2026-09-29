using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class GuidingChapterTrigger : ConfigData<GuidingChapterTriggerItem, short>
{
	public static class DefKey
	{
		public const short Trigger1 = 0;

		public const short Trigger2 = 1;

		public const short Trigger3 = 2;

		public const short Trigger4 = 3;

		public const short Trigger5 = 4;

		public const short Trigger6 = 5;

		public const short Trigger7 = 6;

		public const short Trigger8 = 7;

		public const short Trigger9 = 8;

		public const short Trigger10 = 9;

		public const short Trigger11 = 10;

		public const short Trigger12 = 11;

		public const short Trigger13 = 12;

		public const short Trigger14 = 13;

		public const short Trigger15 = 14;

		public const short Trigger16 = 15;

		public const short Trigger18 = 16;

		public const short Trigger19 = 17;

		public const short Trigger20 = 18;

		public const short Trigger21 = 19;

		public const short Trigger22 = 20;

		public const short Trigger23 = 21;

		public const short Trigger24 = 22;

		public const short Trigger25 = 23;

		public const short Trigger26 = 24;

		public const short Trigger27 = 25;

		public const short Trigger28 = 26;

		public const short Trigger29 = 27;

		public const short Trigger30 = 28;

		public const short Trigger31 = 29;

		public const short Trigger32 = 30;

		public const short Trigger33 = 31;

		public const short Trigger34 = 32;

		public const short Trigger35 = 33;

		public const short Trigger36 = 34;

		public const short Trigger37 = 35;

		public const short Trigger38 = 36;

		public const short Trigger39 = 37;

		public const short Trigger40 = 38;

		public const short Trigger41 = 39;

		public const short Trigger42 = 40;

		public const short Trigger43 = 41;

		public const short Trigger44 = 42;

		public const short Trigger45 = 43;

		public const short Trigger46 = 44;

		public const short Trigger47 = 45;

		public const short Trigger48 = 46;

		public const short Trigger49 = 47;

		public const short Trigger50 = 48;

		public const short Trigger51 = 49;

		public const short Trigger52 = 50;

		public const short Trigger53 = 51;

		public const short Trigger54 = 52;

		public const short Trigger55 = 53;

		public const short Trigger56 = 54;

		public const short Trigger57 = 55;

		public const short Trigger58 = 56;

		public const short Trigger59 = 57;

		public const short Trigger60 = 58;

		public const short Trigger61 = 59;

		public const short WorldStatusSectStory = 60;

		public const short ArriveAreaWithSectExam = 61;

		public const short FirstEnterHeal = 62;

		public const short FirstEnterCombat = 63;

		public const short FirstEnterViewUsingMedicine = 64;

		public const short Trigger68 = 65;

		public const short FirstEnterPartWorldMap = 66;

		public const short FirstEnterShop = 67;

		public const short FirstEnterCharacterInfoWithLoveAndHate = 68;

		public const short FirstEnterCharacterInfo = 69;

		public const short Trigger73 = 70;

		public const short Trigger74 = 71;

		public const short FirstEnterReadingEvent = 72;

		public const short FirstEnterTreasury = 73;

		public const short Trigger77 = 74;

		public const short FirstOpenUISkillAttainment = 75;

		public const short FirstEnterViewCraftsmanForCharacter = 76;

		public const short Trigger80 = 77;

		public const short FirstEnterReading = 78;

		public const short FirstOpenUISkillBreak = 79;

		public const short FirstEnterExchange = 80;

		public const short FirstEnterBookExchange = 81;

		public const short FirstEnterViewBuildingManageForResource = 82;

		public const short FirstEnterViewBuildingManageForMake = 83;

		public const short FirstEnterViewBuildingManageForShop = 84;

		public const short FirstEnterViewBuildingManageForExpand = 85;

		public const short FirstOpenUIGenealogy = 86;

		public const short FirstOpenUIAttainmentOverview = 87;

		public const short Trigger90 = 88;

		public const short FirstEnterViewBuildingManageForChicken = 89;

		public const short FirstEnterViewBuildingManageForEntertain = 90;

		public const short FirstEnterBounty = 91;

		public const short FirstEnterViewCharacterMenuItemsWithFood = 92;

		public const short FirstEnterViewCharacterMenuItemsWithPoison = 93;

		public const short FirstEnterViewCharacterMenuItemsWithMedicine = 94;

		public const short FirstEnterViewBuildingManageForLineage = 95;

		public const short FirstEnterCharacterAttribute = 96;

		public const short FirstEnterViewSamsara = 97;

		public const short FirstEnterSettlementInformation = 98;

		public const short FirstOpenUIStoneHouse = 99;

		public const short FirstOpenUIVillagerRoleDesc = 100;

		public const short FirstEnterCharacterInjury = 101;

		public const short FirstEnterViewMakeForMake = 102;

		public const short FirstEnterViewMakeForRepair = 103;

		public const short FirstEnterViewMakeForRefine = 104;

		public const short FirstEnterViewCraftsmanForBuilding = 105;

		public const short FirstEnterItemMultiplyOperationPanelForRepair = 106;

		public const short FirstEnterItemMultiplyOperationPanelForDisassemble = 107;

		public const short Trigger109 = 108;

		public const short FirstOpenUICharacterSkillSummary = 109;

		public const short FirstOpenUILegendaryBook = 110;

		public const short FirstEnterLevel7Shop = 111;

		public const short Trigger113 = 112;

		public const short FirstEnterCheckInscription = 113;

		public const short FirstEnterSamsaraPlatform = 114;

		public const short Trigger116 = 115;

		public const short FirstEnterViewBuildingManageForResidence = 116;

		public const short FirstEnterViewChoosyResource = 117;

		public const short FirstEnterLifeSummary = 118;

		public const short Trigger120 = 119;

		public const short Trigger121 = 120;

		public const short FirstEnterViewBuildingManageForPrison = 121;

		public const short FirstEnterPrison = 122;

		public const short Trigger124 = 123;

		public const short FirstEnterViewSectLaw = 124;

		public const short Trigger126 = 125;

		public const short FirstOpenUIVillagerRole = 126;

		public const short FirstEnterCharacterInfoWithFeatureReincarnationBonus = 127;

		public const short FirstEnterOverFavorShop = 128;

		public const short FirstEnterTeaHorseCaravan = 129;

		public const short FirstEnterWarehouse = 130;

		public const short FirstEnterViewSkillBreakBonusSelect = 131;

		public const short FirstEnterCharacterInfoGroupFavorite6 = 132;

		public const short FirstEnterMenuEquipment = 133;

		public const short Trigger135 = 134;

		public const short FirstEnterViewMakeForRemovePoison = 135;

		public const short FirstEnterViewMakeForWeave = 136;

		public const short FirstEnterViewMakeForAddPoison = 137;

		public const short FirstEnterViewCharacterMenuItems = 138;

		public const short Trigger140 = 139;

		public const short OpenUIStoneHouseWithFallen = 140;

		public const short OpenUICharacterSkillSummary = 141;

		public const short Trigger143 = 142;

		public const short Trigger144 = 143;

		public const short Trigger145 = 144;

		public const short Trigger146 = 145;

		public const short CombatAttackSkillCanCast = 146;

		public const short CombatAcceptAnyDamage = 147;

		public const short FirstEnterCombatUseItemPanel = 148;

		public const short CombatGoneMadInjury = 149;

		public const short CombatInAttackRange = 150;

		public const short CombatCanFleeHalfFallen = 151;

		public const short CombatCritical = 152;

		public const short CombatAddWugBySkill = 153;

		public const short FirstMercyButton = 154;

		public const short CombatAgileOrLegSkillCanCast = 155;

		public const short Trigger157 = 156;

		public const short CombatAnyMark = 157;

		public const short CombatAcceptWug = 158;

		public const short CombatFatalMark = 159;

		public const short CombatMindMark = 160;

		public const short CombatNeiliAllocationMark = 161;

		public const short CombatInjuryMark = 162;

		public const short CombatQiDisorderMark = 163;

		public const short CombatHealthMark = 164;

		public const short CombatStateMark = 165;

		public const short CombatWugMark = 166;

		public const short CombatPoisonMark = 167;

		public const short CombatFlawMark = 168;

		public const short CombatAcupointMark = 169;

		public const short CombatCastBounceDefendSkill = 170;

		public const short CombatCastFightBackDefendSkill = 171;

		public const short CombatCastAttackSkill = 172;

		public const short CombatNeiliAllocationAnyStatus = 173;

		public const short CombatSkillSilence = 174;

		public const short MapMove = 175;

		public const short MapMoveInCricket = 176;

		public const short MapMoveInTreasure = 177;

		public const short MapMoveInSettlement = 178;

		public const short MapMoveInSect = 179;

		public const short MapMoveInSectShaolin = 180;

		public const short MapMoveInSectEmei = 181;

		public const short MapMoveInSectBaihua = 182;

		public const short MapMoveInSectWudang = 183;

		public const short MapMoveInSectYuanshan = 184;

		public const short MapMoveInSectShixiang = 185;

		public const short MapMoveInSectRanshan = 186;

		public const short MapMoveInSectXuannv = 187;

		public const short MapMoveInSectZhujian = 188;

		public const short MapMoveInSectKongsang = 189;

		public const short MapMoveInSectJingang = 190;

		public const short MapMoveInSectWuxian = 191;

		public const short MapMoveInSectJieqing = 192;

		public const short MapMoveInSectFulong = 193;

		public const short MapMoveInSectXuehou = 194;

		public const short MapMoveInTaiwuVillage = 195;

		public const short MapMoveInAsh = 196;

		public const short MapMoveInXiangshuMinion = 197;

		public const short MapMoveInHereticOrRighteous = 198;

		public const short MapMoveInMerchant = 199;

		public const short MapMoveInCity = 200;

		public const short MapMoveInPickup = 201;

		public const short Trigger204 = 202;

		public const short Trigger205 = 203;

		public const short Trigger206 = 204;

		public const short Trigger207 = 205;

		public const short Trigger208 = 206;

		public const short Trigger209 = 207;

		public const short Trigger210 = 208;

		public const short Trigger211 = 209;

		public const short Trigger212 = 210;

		public const short Trigger213 = 211;

		public const short SwordTombInvasion = 212;

		public const short Trigger215 = 213;

		public const short Trigger216 = 214;

		public const short Trigger217 = 215;

		public const short Trigger218 = 216;

		public const short Trigger219 = 217;

		public const short Trigger220 = 218;

		public const short Trigger221 = 219;

		public const short Trigger222 = 220;

		public const short Trigger223 = 221;

		public const short Trigger224 = 222;

		public const short Trigger225 = 223;

		public const short EquipOverload = 224;

		public const short Trigger227 = 225;

		public const short MapMoveShowBlock = 226;

		public const short Trigger229 = 227;

		public const short MapMoveInAdventure = 228;

		public const short CombatWinDie = 229;

		public const short Trigger232 = 230;

		public const short Trigger233 = 231;

		public const short Trigger234 = 232;

		public const short Trigger235 = 233;

		public const short WorldStatusTaiwuOverload = 234;

		public const short CanLinkToBonusCell = 235;

		public const short Trigger238 = 236;

		public const short Trigger239 = 237;

		public const short Trigger240 = 238;

		public const short Trigger241 = 239;

		public const short Trigger242 = 240;

		public const short Trigger243 = 241;

		public const short WorldStatusOverload = 242;

		public const short FirstEnterCharacterInfoSamsaraCount1 = 243;

		public const short Trigger246 = 244;

		public const short CombatEquipAgile = 245;

		public const short FirstHate = 246;

		public const short FirstLove = 247;

		public const short FirstPlantHeavenlyTree = 248;

		public const short Trigger251 = 249;

		public const short ArrangeTeammate = 250;

		public const short CombatMixPoisonAffect = 251;

		public const short CombatPoisonAffect = 252;

		public const short FirstEnterProfessionWithSkill = 253;

		public const short FirstChangeAlertness = 254;

		public const short FirstChangeFavorability = 255;

		public const short Trigger258 = 256;

		public const short FirstChangeFavorabilityToFavorite5 = 257;

		public const short FirstSelectDebateCard = 258;

		public const short FirstEnterCombatTipEquipTypeAttackAgileDefense = 259;

		public const short FirstEnterCombatTip = 260;

		public const short FirstShowTipForArmor = 261;

		public const short FirstShowTipForCarrier = 262;

		public const short FirstShowTipForWeapon = 263;

		public const short FirstFiveElementConflict = 264;

		public const short CostMainAttribute = 265;

		public const short FirstFinishReadingCombatSkillBook = 266;

		public const short Trigger269 = 267;

		public const short Trigger270 = 268;

		public const short CombatDistanceMoreOrEqual = 269;

		public const short FirstAffectedByPoisonedItem = 270;

		public const short Trigger273 = 271;

		public const short Trigger274 = 272;

		public const short CombatDefendOrNotLegAttackSkillCanCast = 273;

		public const short CombatCanChangeTrick = 274;

		public const short FirstEnterCricketCombat = 275;

		public const short TimeBallAcuPointLessThan5 = 276;

		public const short TimeBallAcuPointLessThan10 = 277;

		public const short Trigger281 = 278;

		public const short CombatNormalAttack = 279;

		public const short FirstEnterCombatBegin = 280;

		public const short FirstEnterCombatResult = 281;

		public const short Trigger285 = 282;

		public const short Trigger286 = 283;

		public const short FirstEnterCricketCombatResult = 284;

		public const short FirstExitUISkillBreak = 285;

		public const short Trigger289 = 286;

		public const short Trigger290 = 287;

		public const short FirstTimeObtainFuyuFaith = 288;

		public const short Trigger292 = 289;

		public const short FirstGetWugKing = 290;

		public const short Trigger294 = 291;

		public const short CombatAddAnyTrick = 292;

		public const short Trigger296 = 293;

		public const short Trigger297 = 294;

		public const short Trigger298 = 295;

		public const short FirstUnlockDebateStrategy = 296;

		public const short Trigger300 = 297;

		public const short Trigger301 = 298;

		public const short Trigger302 = 299;

		public const short Trigger303 = 300;

		public const short Trigger304 = 301;

		public const short Trigger305 = 302;

		public const short CloseReadingWithCombatSkillBook = 303;

		public const short CombatMakeDirectDamage = 304;

		public const short FirstUnlockVowStele = 305;

		public const short HaveLoopingBonus = 306;

		public const short HaveReadingBonus = 307;

		public const short Trigger312 = 308;

		public const short Trigger313 = 309;

		public const short Trigger314 = 310;

		public const short TimeBallPassMonthWithAcuPointRemain = 311;

		public const short ShopHasExtraGoods = 312;

		public const short Trigger317 = 313;

		public const short Trigger318 = 314;

		public const short Trigger319 = 315;

		public const short SkillBreakPlateOverHalf = 316;

		public const short ActiveLoopOrReadTriggered = 317;

		public const short FirstUnlockProfessionExtraSkill = 318;

		public const short UnlockSwordLegacy = 319;

		public const short UnlockCollectResource = 320;

		public const short CombatCanUnlockAttackWithRawCreate = 321;

		public const short Trigger327 = 322;

		public const short CombatUnlockAttackSkill = 323;

		public const short Trigger329 = 324;

		public const short Trigger330 = 325;

		public const short Trigger331 = 326;

		public const short CloseReadingWithLifeSkillBook = 327;

		public const short Trigger333 = 328;

		public const short CombatAcceptWugBySkill = 329;

		public const short CombatEnemyCastAttackSkill = 330;

		public const short Trigger337 = 331;

		public const short Trigger338 = 332;

		public const short CombatTeammateCommandSkipCd = 333;

		public const short CombatBossAddPhase = 334;

		public const short CombatAcceptCritical = 335;

		public const short Trigger342 = 336;

		public const short Trigger343 = 337;

		public const short Trigger344 = 338;

		public const short Trigger345 = 339;

		public const short Trigger346 = 340;

		public const short Trigger347 = 341;

		public const short Trigger348 = 342;

		public const short Trigger349 = 343;

		public const short Trigger350 = 344;

		public const short Trigger351 = 345;

		public const short Trigger352 = 346;

		public const short Trigger353 = 347;

		public const short Trigger354 = 348;

		public const short Trigger355 = 349;

		public const short Trigger356 = 350;

		public const short Trigger357 = 351;

		public const short Trigger358 = 352;

		public const short Trigger359 = 353;

		public const short Trigger360 = 354;

		public const short Trigger361 = 355;

		public const short Trigger362 = 356;

		public const short Trigger363 = 357;

		public const short Trigger364 = 358;

		public const short Trigger365 = 359;
	}

	public static class DefValue
	{
		public static GuidingChapterTriggerItem Trigger1 => Instance[(short)0];

		public static GuidingChapterTriggerItem Trigger2 => Instance[(short)1];

		public static GuidingChapterTriggerItem Trigger3 => Instance[(short)2];

		public static GuidingChapterTriggerItem Trigger4 => Instance[(short)3];

		public static GuidingChapterTriggerItem Trigger5 => Instance[(short)4];

		public static GuidingChapterTriggerItem Trigger6 => Instance[(short)5];

		public static GuidingChapterTriggerItem Trigger7 => Instance[(short)6];

		public static GuidingChapterTriggerItem Trigger8 => Instance[(short)7];

		public static GuidingChapterTriggerItem Trigger9 => Instance[(short)8];

		public static GuidingChapterTriggerItem Trigger10 => Instance[(short)9];

		public static GuidingChapterTriggerItem Trigger11 => Instance[(short)10];

		public static GuidingChapterTriggerItem Trigger12 => Instance[(short)11];

		public static GuidingChapterTriggerItem Trigger13 => Instance[(short)12];

		public static GuidingChapterTriggerItem Trigger14 => Instance[(short)13];

		public static GuidingChapterTriggerItem Trigger15 => Instance[(short)14];

		public static GuidingChapterTriggerItem Trigger16 => Instance[(short)15];

		public static GuidingChapterTriggerItem Trigger18 => Instance[(short)16];

		public static GuidingChapterTriggerItem Trigger19 => Instance[(short)17];

		public static GuidingChapterTriggerItem Trigger20 => Instance[(short)18];

		public static GuidingChapterTriggerItem Trigger21 => Instance[(short)19];

		public static GuidingChapterTriggerItem Trigger22 => Instance[(short)20];

		public static GuidingChapterTriggerItem Trigger23 => Instance[(short)21];

		public static GuidingChapterTriggerItem Trigger24 => Instance[(short)22];

		public static GuidingChapterTriggerItem Trigger25 => Instance[(short)23];

		public static GuidingChapterTriggerItem Trigger26 => Instance[(short)24];

		public static GuidingChapterTriggerItem Trigger27 => Instance[(short)25];

		public static GuidingChapterTriggerItem Trigger28 => Instance[(short)26];

		public static GuidingChapterTriggerItem Trigger29 => Instance[(short)27];

		public static GuidingChapterTriggerItem Trigger30 => Instance[(short)28];

		public static GuidingChapterTriggerItem Trigger31 => Instance[(short)29];

		public static GuidingChapterTriggerItem Trigger32 => Instance[(short)30];

		public static GuidingChapterTriggerItem Trigger33 => Instance[(short)31];

		public static GuidingChapterTriggerItem Trigger34 => Instance[(short)32];

		public static GuidingChapterTriggerItem Trigger35 => Instance[(short)33];

		public static GuidingChapterTriggerItem Trigger36 => Instance[(short)34];

		public static GuidingChapterTriggerItem Trigger37 => Instance[(short)35];

		public static GuidingChapterTriggerItem Trigger38 => Instance[(short)36];

		public static GuidingChapterTriggerItem Trigger39 => Instance[(short)37];

		public static GuidingChapterTriggerItem Trigger40 => Instance[(short)38];

		public static GuidingChapterTriggerItem Trigger41 => Instance[(short)39];

		public static GuidingChapterTriggerItem Trigger42 => Instance[(short)40];

		public static GuidingChapterTriggerItem Trigger43 => Instance[(short)41];

		public static GuidingChapterTriggerItem Trigger44 => Instance[(short)42];

		public static GuidingChapterTriggerItem Trigger45 => Instance[(short)43];

		public static GuidingChapterTriggerItem Trigger46 => Instance[(short)44];

		public static GuidingChapterTriggerItem Trigger47 => Instance[(short)45];

		public static GuidingChapterTriggerItem Trigger48 => Instance[(short)46];

		public static GuidingChapterTriggerItem Trigger49 => Instance[(short)47];

		public static GuidingChapterTriggerItem Trigger50 => Instance[(short)48];

		public static GuidingChapterTriggerItem Trigger51 => Instance[(short)49];

		public static GuidingChapterTriggerItem Trigger52 => Instance[(short)50];

		public static GuidingChapterTriggerItem Trigger53 => Instance[(short)51];

		public static GuidingChapterTriggerItem Trigger54 => Instance[(short)52];

		public static GuidingChapterTriggerItem Trigger55 => Instance[(short)53];

		public static GuidingChapterTriggerItem Trigger56 => Instance[(short)54];

		public static GuidingChapterTriggerItem Trigger57 => Instance[(short)55];

		public static GuidingChapterTriggerItem Trigger58 => Instance[(short)56];

		public static GuidingChapterTriggerItem Trigger59 => Instance[(short)57];

		public static GuidingChapterTriggerItem Trigger60 => Instance[(short)58];

		public static GuidingChapterTriggerItem Trigger61 => Instance[(short)59];

		public static GuidingChapterTriggerItem WorldStatusSectStory => Instance[(short)60];

		public static GuidingChapterTriggerItem ArriveAreaWithSectExam => Instance[(short)61];

		public static GuidingChapterTriggerItem FirstEnterHeal => Instance[(short)62];

		public static GuidingChapterTriggerItem FirstEnterCombat => Instance[(short)63];

		public static GuidingChapterTriggerItem FirstEnterViewUsingMedicine => Instance[(short)64];

		public static GuidingChapterTriggerItem Trigger68 => Instance[(short)65];

		public static GuidingChapterTriggerItem FirstEnterPartWorldMap => Instance[(short)66];

		public static GuidingChapterTriggerItem FirstEnterShop => Instance[(short)67];

		public static GuidingChapterTriggerItem FirstEnterCharacterInfoWithLoveAndHate => Instance[(short)68];

		public static GuidingChapterTriggerItem FirstEnterCharacterInfo => Instance[(short)69];

		public static GuidingChapterTriggerItem Trigger73 => Instance[(short)70];

		public static GuidingChapterTriggerItem Trigger74 => Instance[(short)71];

		public static GuidingChapterTriggerItem FirstEnterReadingEvent => Instance[(short)72];

		public static GuidingChapterTriggerItem FirstEnterTreasury => Instance[(short)73];

		public static GuidingChapterTriggerItem Trigger77 => Instance[(short)74];

		public static GuidingChapterTriggerItem FirstOpenUISkillAttainment => Instance[(short)75];

		public static GuidingChapterTriggerItem FirstEnterViewCraftsmanForCharacter => Instance[(short)76];

		public static GuidingChapterTriggerItem Trigger80 => Instance[(short)77];

		public static GuidingChapterTriggerItem FirstEnterReading => Instance[(short)78];

		public static GuidingChapterTriggerItem FirstOpenUISkillBreak => Instance[(short)79];

		public static GuidingChapterTriggerItem FirstEnterExchange => Instance[(short)80];

		public static GuidingChapterTriggerItem FirstEnterBookExchange => Instance[(short)81];

		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForResource => Instance[(short)82];

		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForMake => Instance[(short)83];

		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForShop => Instance[(short)84];

		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForExpand => Instance[(short)85];

		public static GuidingChapterTriggerItem FirstOpenUIGenealogy => Instance[(short)86];

		public static GuidingChapterTriggerItem FirstOpenUIAttainmentOverview => Instance[(short)87];

		public static GuidingChapterTriggerItem Trigger90 => Instance[(short)88];

		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForChicken => Instance[(short)89];

		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForEntertain => Instance[(short)90];

		public static GuidingChapterTriggerItem FirstEnterBounty => Instance[(short)91];

		public static GuidingChapterTriggerItem FirstEnterViewCharacterMenuItemsWithFood => Instance[(short)92];

		public static GuidingChapterTriggerItem FirstEnterViewCharacterMenuItemsWithPoison => Instance[(short)93];

		public static GuidingChapterTriggerItem FirstEnterViewCharacterMenuItemsWithMedicine => Instance[(short)94];

		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForLineage => Instance[(short)95];

		public static GuidingChapterTriggerItem FirstEnterCharacterAttribute => Instance[(short)96];

		public static GuidingChapterTriggerItem FirstEnterViewSamsara => Instance[(short)97];

		public static GuidingChapterTriggerItem FirstEnterSettlementInformation => Instance[(short)98];

		public static GuidingChapterTriggerItem FirstOpenUIStoneHouse => Instance[(short)99];

		public static GuidingChapterTriggerItem FirstOpenUIVillagerRoleDesc => Instance[(short)100];

		public static GuidingChapterTriggerItem FirstEnterCharacterInjury => Instance[(short)101];

		public static GuidingChapterTriggerItem FirstEnterViewMakeForMake => Instance[(short)102];

		public static GuidingChapterTriggerItem FirstEnterViewMakeForRepair => Instance[(short)103];

		public static GuidingChapterTriggerItem FirstEnterViewMakeForRefine => Instance[(short)104];

		public static GuidingChapterTriggerItem FirstEnterViewCraftsmanForBuilding => Instance[(short)105];

		public static GuidingChapterTriggerItem FirstEnterItemMultiplyOperationPanelForRepair => Instance[(short)106];

		public static GuidingChapterTriggerItem FirstEnterItemMultiplyOperationPanelForDisassemble => Instance[(short)107];

		public static GuidingChapterTriggerItem Trigger109 => Instance[(short)108];

		public static GuidingChapterTriggerItem FirstOpenUICharacterSkillSummary => Instance[(short)109];

		public static GuidingChapterTriggerItem FirstOpenUILegendaryBook => Instance[(short)110];

		public static GuidingChapterTriggerItem FirstEnterLevel7Shop => Instance[(short)111];

		public static GuidingChapterTriggerItem Trigger113 => Instance[(short)112];

		public static GuidingChapterTriggerItem FirstEnterCheckInscription => Instance[(short)113];

		public static GuidingChapterTriggerItem FirstEnterSamsaraPlatform => Instance[(short)114];

		public static GuidingChapterTriggerItem Trigger116 => Instance[(short)115];

		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForResidence => Instance[(short)116];

		public static GuidingChapterTriggerItem FirstEnterViewChoosyResource => Instance[(short)117];

		public static GuidingChapterTriggerItem FirstEnterLifeSummary => Instance[(short)118];

		public static GuidingChapterTriggerItem Trigger120 => Instance[(short)119];

		public static GuidingChapterTriggerItem Trigger121 => Instance[(short)120];

		public static GuidingChapterTriggerItem FirstEnterViewBuildingManageForPrison => Instance[(short)121];

		public static GuidingChapterTriggerItem FirstEnterPrison => Instance[(short)122];

		public static GuidingChapterTriggerItem Trigger124 => Instance[(short)123];

		public static GuidingChapterTriggerItem FirstEnterViewSectLaw => Instance[(short)124];

		public static GuidingChapterTriggerItem Trigger126 => Instance[(short)125];

		public static GuidingChapterTriggerItem FirstOpenUIVillagerRole => Instance[(short)126];

		public static GuidingChapterTriggerItem FirstEnterCharacterInfoWithFeatureReincarnationBonus => Instance[(short)127];

		public static GuidingChapterTriggerItem FirstEnterOverFavorShop => Instance[(short)128];

		public static GuidingChapterTriggerItem FirstEnterTeaHorseCaravan => Instance[(short)129];

		public static GuidingChapterTriggerItem FirstEnterWarehouse => Instance[(short)130];

		public static GuidingChapterTriggerItem FirstEnterViewSkillBreakBonusSelect => Instance[(short)131];

		public static GuidingChapterTriggerItem FirstEnterCharacterInfoGroupFavorite6 => Instance[(short)132];

		public static GuidingChapterTriggerItem FirstEnterMenuEquipment => Instance[(short)133];

		public static GuidingChapterTriggerItem Trigger135 => Instance[(short)134];

		public static GuidingChapterTriggerItem FirstEnterViewMakeForRemovePoison => Instance[(short)135];

		public static GuidingChapterTriggerItem FirstEnterViewMakeForWeave => Instance[(short)136];

		public static GuidingChapterTriggerItem FirstEnterViewMakeForAddPoison => Instance[(short)137];

		public static GuidingChapterTriggerItem FirstEnterViewCharacterMenuItems => Instance[(short)138];

		public static GuidingChapterTriggerItem Trigger140 => Instance[(short)139];

		public static GuidingChapterTriggerItem OpenUIStoneHouseWithFallen => Instance[(short)140];

		public static GuidingChapterTriggerItem OpenUICharacterSkillSummary => Instance[(short)141];

		public static GuidingChapterTriggerItem Trigger143 => Instance[(short)142];

		public static GuidingChapterTriggerItem Trigger144 => Instance[(short)143];

		public static GuidingChapterTriggerItem Trigger145 => Instance[(short)144];

		public static GuidingChapterTriggerItem Trigger146 => Instance[(short)145];

		public static GuidingChapterTriggerItem CombatAttackSkillCanCast => Instance[(short)146];

		public static GuidingChapterTriggerItem CombatAcceptAnyDamage => Instance[(short)147];

		public static GuidingChapterTriggerItem FirstEnterCombatUseItemPanel => Instance[(short)148];

		public static GuidingChapterTriggerItem CombatGoneMadInjury => Instance[(short)149];

		public static GuidingChapterTriggerItem CombatInAttackRange => Instance[(short)150];

		public static GuidingChapterTriggerItem CombatCanFleeHalfFallen => Instance[(short)151];

		public static GuidingChapterTriggerItem CombatCritical => Instance[(short)152];

		public static GuidingChapterTriggerItem CombatAddWugBySkill => Instance[(short)153];

		public static GuidingChapterTriggerItem FirstMercyButton => Instance[(short)154];

		public static GuidingChapterTriggerItem CombatAgileOrLegSkillCanCast => Instance[(short)155];

		public static GuidingChapterTriggerItem Trigger157 => Instance[(short)156];

		public static GuidingChapterTriggerItem CombatAnyMark => Instance[(short)157];

		public static GuidingChapterTriggerItem CombatAcceptWug => Instance[(short)158];

		public static GuidingChapterTriggerItem CombatFatalMark => Instance[(short)159];

		public static GuidingChapterTriggerItem CombatMindMark => Instance[(short)160];

		public static GuidingChapterTriggerItem CombatNeiliAllocationMark => Instance[(short)161];

		public static GuidingChapterTriggerItem CombatInjuryMark => Instance[(short)162];

		public static GuidingChapterTriggerItem CombatQiDisorderMark => Instance[(short)163];

		public static GuidingChapterTriggerItem CombatHealthMark => Instance[(short)164];

		public static GuidingChapterTriggerItem CombatStateMark => Instance[(short)165];

		public static GuidingChapterTriggerItem CombatWugMark => Instance[(short)166];

		public static GuidingChapterTriggerItem CombatPoisonMark => Instance[(short)167];

		public static GuidingChapterTriggerItem CombatFlawMark => Instance[(short)168];

		public static GuidingChapterTriggerItem CombatAcupointMark => Instance[(short)169];

		public static GuidingChapterTriggerItem CombatCastBounceDefendSkill => Instance[(short)170];

		public static GuidingChapterTriggerItem CombatCastFightBackDefendSkill => Instance[(short)171];

		public static GuidingChapterTriggerItem CombatCastAttackSkill => Instance[(short)172];

		public static GuidingChapterTriggerItem CombatNeiliAllocationAnyStatus => Instance[(short)173];

		public static GuidingChapterTriggerItem CombatSkillSilence => Instance[(short)174];

		public static GuidingChapterTriggerItem MapMove => Instance[(short)175];

		public static GuidingChapterTriggerItem MapMoveInCricket => Instance[(short)176];

		public static GuidingChapterTriggerItem MapMoveInTreasure => Instance[(short)177];

		public static GuidingChapterTriggerItem MapMoveInSettlement => Instance[(short)178];

		public static GuidingChapterTriggerItem MapMoveInSect => Instance[(short)179];

		public static GuidingChapterTriggerItem MapMoveInSectShaolin => Instance[(short)180];

		public static GuidingChapterTriggerItem MapMoveInSectEmei => Instance[(short)181];

		public static GuidingChapterTriggerItem MapMoveInSectBaihua => Instance[(short)182];

		public static GuidingChapterTriggerItem MapMoveInSectWudang => Instance[(short)183];

		public static GuidingChapterTriggerItem MapMoveInSectYuanshan => Instance[(short)184];

		public static GuidingChapterTriggerItem MapMoveInSectShixiang => Instance[(short)185];

		public static GuidingChapterTriggerItem MapMoveInSectRanshan => Instance[(short)186];

		public static GuidingChapterTriggerItem MapMoveInSectXuannv => Instance[(short)187];

		public static GuidingChapterTriggerItem MapMoveInSectZhujian => Instance[(short)188];

		public static GuidingChapterTriggerItem MapMoveInSectKongsang => Instance[(short)189];

		public static GuidingChapterTriggerItem MapMoveInSectJingang => Instance[(short)190];

		public static GuidingChapterTriggerItem MapMoveInSectWuxian => Instance[(short)191];

		public static GuidingChapterTriggerItem MapMoveInSectJieqing => Instance[(short)192];

		public static GuidingChapterTriggerItem MapMoveInSectFulong => Instance[(short)193];

		public static GuidingChapterTriggerItem MapMoveInSectXuehou => Instance[(short)194];

		public static GuidingChapterTriggerItem MapMoveInTaiwuVillage => Instance[(short)195];

		public static GuidingChapterTriggerItem MapMoveInAsh => Instance[(short)196];

		public static GuidingChapterTriggerItem MapMoveInXiangshuMinion => Instance[(short)197];

		public static GuidingChapterTriggerItem MapMoveInHereticOrRighteous => Instance[(short)198];

		public static GuidingChapterTriggerItem MapMoveInMerchant => Instance[(short)199];

		public static GuidingChapterTriggerItem MapMoveInCity => Instance[(short)200];

		public static GuidingChapterTriggerItem MapMoveInPickup => Instance[(short)201];

		public static GuidingChapterTriggerItem Trigger204 => Instance[(short)202];

		public static GuidingChapterTriggerItem Trigger205 => Instance[(short)203];

		public static GuidingChapterTriggerItem Trigger206 => Instance[(short)204];

		public static GuidingChapterTriggerItem Trigger207 => Instance[(short)205];

		public static GuidingChapterTriggerItem Trigger208 => Instance[(short)206];

		public static GuidingChapterTriggerItem Trigger209 => Instance[(short)207];

		public static GuidingChapterTriggerItem Trigger210 => Instance[(short)208];

		public static GuidingChapterTriggerItem Trigger211 => Instance[(short)209];

		public static GuidingChapterTriggerItem Trigger212 => Instance[(short)210];

		public static GuidingChapterTriggerItem Trigger213 => Instance[(short)211];

		public static GuidingChapterTriggerItem SwordTombInvasion => Instance[(short)212];

		public static GuidingChapterTriggerItem Trigger215 => Instance[(short)213];

		public static GuidingChapterTriggerItem Trigger216 => Instance[(short)214];

		public static GuidingChapterTriggerItem Trigger217 => Instance[(short)215];

		public static GuidingChapterTriggerItem Trigger218 => Instance[(short)216];

		public static GuidingChapterTriggerItem Trigger219 => Instance[(short)217];

		public static GuidingChapterTriggerItem Trigger220 => Instance[(short)218];

		public static GuidingChapterTriggerItem Trigger221 => Instance[(short)219];

		public static GuidingChapterTriggerItem Trigger222 => Instance[(short)220];

		public static GuidingChapterTriggerItem Trigger223 => Instance[(short)221];

		public static GuidingChapterTriggerItem Trigger224 => Instance[(short)222];

		public static GuidingChapterTriggerItem Trigger225 => Instance[(short)223];

		public static GuidingChapterTriggerItem EquipOverload => Instance[(short)224];

		public static GuidingChapterTriggerItem Trigger227 => Instance[(short)225];

		public static GuidingChapterTriggerItem MapMoveShowBlock => Instance[(short)226];

		public static GuidingChapterTriggerItem Trigger229 => Instance[(short)227];

		public static GuidingChapterTriggerItem MapMoveInAdventure => Instance[(short)228];

		public static GuidingChapterTriggerItem CombatWinDie => Instance[(short)229];

		public static GuidingChapterTriggerItem Trigger232 => Instance[(short)230];

		public static GuidingChapterTriggerItem Trigger233 => Instance[(short)231];

		public static GuidingChapterTriggerItem Trigger234 => Instance[(short)232];

		public static GuidingChapterTriggerItem Trigger235 => Instance[(short)233];

		public static GuidingChapterTriggerItem WorldStatusTaiwuOverload => Instance[(short)234];

		public static GuidingChapterTriggerItem CanLinkToBonusCell => Instance[(short)235];

		public static GuidingChapterTriggerItem Trigger238 => Instance[(short)236];

		public static GuidingChapterTriggerItem Trigger239 => Instance[(short)237];

		public static GuidingChapterTriggerItem Trigger240 => Instance[(short)238];

		public static GuidingChapterTriggerItem Trigger241 => Instance[(short)239];

		public static GuidingChapterTriggerItem Trigger242 => Instance[(short)240];

		public static GuidingChapterTriggerItem Trigger243 => Instance[(short)241];

		public static GuidingChapterTriggerItem WorldStatusOverload => Instance[(short)242];

		public static GuidingChapterTriggerItem FirstEnterCharacterInfoSamsaraCount1 => Instance[(short)243];

		public static GuidingChapterTriggerItem Trigger246 => Instance[(short)244];

		public static GuidingChapterTriggerItem CombatEquipAgile => Instance[(short)245];

		public static GuidingChapterTriggerItem FirstHate => Instance[(short)246];

		public static GuidingChapterTriggerItem FirstLove => Instance[(short)247];

		public static GuidingChapterTriggerItem FirstPlantHeavenlyTree => Instance[(short)248];

		public static GuidingChapterTriggerItem Trigger251 => Instance[(short)249];

		public static GuidingChapterTriggerItem ArrangeTeammate => Instance[(short)250];

		public static GuidingChapterTriggerItem CombatMixPoisonAffect => Instance[(short)251];

		public static GuidingChapterTriggerItem CombatPoisonAffect => Instance[(short)252];

		public static GuidingChapterTriggerItem FirstEnterProfessionWithSkill => Instance[(short)253];

		public static GuidingChapterTriggerItem FirstChangeAlertness => Instance[(short)254];

		public static GuidingChapterTriggerItem FirstChangeFavorability => Instance[(short)255];

		public static GuidingChapterTriggerItem Trigger258 => Instance[(short)256];

		public static GuidingChapterTriggerItem FirstChangeFavorabilityToFavorite5 => Instance[(short)257];

		public static GuidingChapterTriggerItem FirstSelectDebateCard => Instance[(short)258];

		public static GuidingChapterTriggerItem FirstEnterCombatTipEquipTypeAttackAgileDefense => Instance[(short)259];

		public static GuidingChapterTriggerItem FirstEnterCombatTip => Instance[(short)260];

		public static GuidingChapterTriggerItem FirstShowTipForArmor => Instance[(short)261];

		public static GuidingChapterTriggerItem FirstShowTipForCarrier => Instance[(short)262];

		public static GuidingChapterTriggerItem FirstShowTipForWeapon => Instance[(short)263];

		public static GuidingChapterTriggerItem FirstFiveElementConflict => Instance[(short)264];

		public static GuidingChapterTriggerItem CostMainAttribute => Instance[(short)265];

		public static GuidingChapterTriggerItem FirstFinishReadingCombatSkillBook => Instance[(short)266];

		public static GuidingChapterTriggerItem Trigger269 => Instance[(short)267];

		public static GuidingChapterTriggerItem Trigger270 => Instance[(short)268];

		public static GuidingChapterTriggerItem CombatDistanceMoreOrEqual => Instance[(short)269];

		public static GuidingChapterTriggerItem FirstAffectedByPoisonedItem => Instance[(short)270];

		public static GuidingChapterTriggerItem Trigger273 => Instance[(short)271];

		public static GuidingChapterTriggerItem Trigger274 => Instance[(short)272];

		public static GuidingChapterTriggerItem CombatDefendOrNotLegAttackSkillCanCast => Instance[(short)273];

		public static GuidingChapterTriggerItem CombatCanChangeTrick => Instance[(short)274];

		public static GuidingChapterTriggerItem FirstEnterCricketCombat => Instance[(short)275];

		public static GuidingChapterTriggerItem TimeBallAcuPointLessThan5 => Instance[(short)276];

		public static GuidingChapterTriggerItem TimeBallAcuPointLessThan10 => Instance[(short)277];

		public static GuidingChapterTriggerItem Trigger281 => Instance[(short)278];

		public static GuidingChapterTriggerItem CombatNormalAttack => Instance[(short)279];

		public static GuidingChapterTriggerItem FirstEnterCombatBegin => Instance[(short)280];

		public static GuidingChapterTriggerItem FirstEnterCombatResult => Instance[(short)281];

		public static GuidingChapterTriggerItem Trigger285 => Instance[(short)282];

		public static GuidingChapterTriggerItem Trigger286 => Instance[(short)283];

		public static GuidingChapterTriggerItem FirstEnterCricketCombatResult => Instance[(short)284];

		public static GuidingChapterTriggerItem FirstExitUISkillBreak => Instance[(short)285];

		public static GuidingChapterTriggerItem Trigger289 => Instance[(short)286];

		public static GuidingChapterTriggerItem Trigger290 => Instance[(short)287];

		public static GuidingChapterTriggerItem FirstTimeObtainFuyuFaith => Instance[(short)288];

		public static GuidingChapterTriggerItem Trigger292 => Instance[(short)289];

		public static GuidingChapterTriggerItem FirstGetWugKing => Instance[(short)290];

		public static GuidingChapterTriggerItem Trigger294 => Instance[(short)291];

		public static GuidingChapterTriggerItem CombatAddAnyTrick => Instance[(short)292];

		public static GuidingChapterTriggerItem Trigger296 => Instance[(short)293];

		public static GuidingChapterTriggerItem Trigger297 => Instance[(short)294];

		public static GuidingChapterTriggerItem Trigger298 => Instance[(short)295];

		public static GuidingChapterTriggerItem FirstUnlockDebateStrategy => Instance[(short)296];

		public static GuidingChapterTriggerItem Trigger300 => Instance[(short)297];

		public static GuidingChapterTriggerItem Trigger301 => Instance[(short)298];

		public static GuidingChapterTriggerItem Trigger302 => Instance[(short)299];

		public static GuidingChapterTriggerItem Trigger303 => Instance[(short)300];

		public static GuidingChapterTriggerItem Trigger304 => Instance[(short)301];

		public static GuidingChapterTriggerItem Trigger305 => Instance[(short)302];

		public static GuidingChapterTriggerItem CloseReadingWithCombatSkillBook => Instance[(short)303];

		public static GuidingChapterTriggerItem CombatMakeDirectDamage => Instance[(short)304];

		public static GuidingChapterTriggerItem FirstUnlockVowStele => Instance[(short)305];

		public static GuidingChapterTriggerItem HaveLoopingBonus => Instance[(short)306];

		public static GuidingChapterTriggerItem HaveReadingBonus => Instance[(short)307];

		public static GuidingChapterTriggerItem Trigger312 => Instance[(short)308];

		public static GuidingChapterTriggerItem Trigger313 => Instance[(short)309];

		public static GuidingChapterTriggerItem Trigger314 => Instance[(short)310];

		public static GuidingChapterTriggerItem TimeBallPassMonthWithAcuPointRemain => Instance[(short)311];

		public static GuidingChapterTriggerItem ShopHasExtraGoods => Instance[(short)312];

		public static GuidingChapterTriggerItem Trigger317 => Instance[(short)313];

		public static GuidingChapterTriggerItem Trigger318 => Instance[(short)314];

		public static GuidingChapterTriggerItem Trigger319 => Instance[(short)315];

		public static GuidingChapterTriggerItem SkillBreakPlateOverHalf => Instance[(short)316];

		public static GuidingChapterTriggerItem ActiveLoopOrReadTriggered => Instance[(short)317];

		public static GuidingChapterTriggerItem FirstUnlockProfessionExtraSkill => Instance[(short)318];

		public static GuidingChapterTriggerItem UnlockSwordLegacy => Instance[(short)319];

		public static GuidingChapterTriggerItem UnlockCollectResource => Instance[(short)320];

		public static GuidingChapterTriggerItem CombatCanUnlockAttackWithRawCreate => Instance[(short)321];

		public static GuidingChapterTriggerItem Trigger327 => Instance[(short)322];

		public static GuidingChapterTriggerItem CombatUnlockAttackSkill => Instance[(short)323];

		public static GuidingChapterTriggerItem Trigger329 => Instance[(short)324];

		public static GuidingChapterTriggerItem Trigger330 => Instance[(short)325];

		public static GuidingChapterTriggerItem Trigger331 => Instance[(short)326];

		public static GuidingChapterTriggerItem CloseReadingWithLifeSkillBook => Instance[(short)327];

		public static GuidingChapterTriggerItem Trigger333 => Instance[(short)328];

		public static GuidingChapterTriggerItem CombatAcceptWugBySkill => Instance[(short)329];

		public static GuidingChapterTriggerItem CombatEnemyCastAttackSkill => Instance[(short)330];

		public static GuidingChapterTriggerItem Trigger337 => Instance[(short)331];

		public static GuidingChapterTriggerItem Trigger338 => Instance[(short)332];

		public static GuidingChapterTriggerItem CombatTeammateCommandSkipCd => Instance[(short)333];

		public static GuidingChapterTriggerItem CombatBossAddPhase => Instance[(short)334];

		public static GuidingChapterTriggerItem CombatAcceptCritical => Instance[(short)335];

		public static GuidingChapterTriggerItem Trigger342 => Instance[(short)336];

		public static GuidingChapterTriggerItem Trigger343 => Instance[(short)337];

		public static GuidingChapterTriggerItem Trigger344 => Instance[(short)338];

		public static GuidingChapterTriggerItem Trigger345 => Instance[(short)339];

		public static GuidingChapterTriggerItem Trigger346 => Instance[(short)340];

		public static GuidingChapterTriggerItem Trigger347 => Instance[(short)341];

		public static GuidingChapterTriggerItem Trigger348 => Instance[(short)342];

		public static GuidingChapterTriggerItem Trigger349 => Instance[(short)343];

		public static GuidingChapterTriggerItem Trigger350 => Instance[(short)344];

		public static GuidingChapterTriggerItem Trigger351 => Instance[(short)345];

		public static GuidingChapterTriggerItem Trigger352 => Instance[(short)346];

		public static GuidingChapterTriggerItem Trigger353 => Instance[(short)347];

		public static GuidingChapterTriggerItem Trigger354 => Instance[(short)348];

		public static GuidingChapterTriggerItem Trigger355 => Instance[(short)349];

		public static GuidingChapterTriggerItem Trigger356 => Instance[(short)350];

		public static GuidingChapterTriggerItem Trigger357 => Instance[(short)351];

		public static GuidingChapterTriggerItem Trigger358 => Instance[(short)352];

		public static GuidingChapterTriggerItem Trigger359 => Instance[(short)353];

		public static GuidingChapterTriggerItem Trigger360 => Instance[(short)354];

		public static GuidingChapterTriggerItem Trigger361 => Instance[(short)355];

		public static GuidingChapterTriggerItem Trigger362 => Instance[(short)356];

		public static GuidingChapterTriggerItem Trigger363 => Instance[(short)357];

		public static GuidingChapterTriggerItem Trigger364 => Instance[(short)358];

		public static GuidingChapterTriggerItem Trigger365 => Instance[(short)359];
	}

	public static GuidingChapterTrigger Instance = new GuidingChapterTrigger();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Chapters", "TemplateId" };

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
		_dataArray.Add(new GuidingChapterTriggerItem(0, new List<short> { 104 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(1, new List<short> { 24 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(2, new List<short>(), 0));
		_dataArray.Add(new GuidingChapterTriggerItem(3, new List<short> { 346 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(4, new List<short> { 170, 328 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(5, new List<short> { 341 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(6, new List<short> { 340 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(7, new List<short> { 329 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(8, new List<short> { 115 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(9, new List<short> { 325 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(10, new List<short> { 319 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(11, new List<short> { 321 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(12, new List<short> { 332 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(13, new List<short> { 327 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(14, new List<short> { 333 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(15, new List<short> { 323 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(16, new List<short> { 330 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(17, new List<short> { 316 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(18, new List<short> { 324 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(19, new List<short> { 106, 107 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(20, new List<short> { 313 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(21, new List<short> { 320 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(22, new List<short> { 314 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(23, new List<short> { 318 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(24, new List<short> { 326 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(25, new List<short> { 304 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(26, new List<short> { 305 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(27, new List<short> { 306 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(28, new List<short> { 50 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(29, new List<short> { 131 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(30, new List<short> { 162 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(31, new List<short> { 151 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(32, new List<short> { 160 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(33, new List<short> { 168 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(34, new List<short> { 165 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(35, new List<short> { 166 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(36, new List<short> { 159 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(37, new List<short> { 154 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(38, new List<short> { 157 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(39, new List<short> { 158 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(40, new List<short> { 155 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(41, new List<short> { 156 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(42, new List<short> { 161 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(43, new List<short> { 153 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(44, new List<short> { 163 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(45, new List<short> { 167 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(46, new List<short> { 164 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(47, new List<short> { 152 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(48, new List<short> { 143 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(49, new List<short> { 147 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(50, new List<short> { 144 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(51, new List<short> { 34 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(52, new List<short> { 146 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(53, new List<short> { 32 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(54, new List<short> { 150 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(55, new List<short> { 149 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(56, new List<short> { 141 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(57, new List<short> { 142 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(58, new List<short> { 148 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(59, new List<short> { 145 }, 0));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new GuidingChapterTriggerItem(60, new List<short> { 57 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(61, new List<short>(), 0));
		_dataArray.Add(new GuidingChapterTriggerItem(62, new List<short> { 116 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(63, new List<short> { 221, 267, 271 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(64, new List<short> { 118 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(65, new List<short> { 189 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(66, new List<short> { 17 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(67, new List<short> { 42, 43, 46 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(68, new List<short> { 84 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(69, new List<short>
		{
			73, 74, 75, 76, 77, 78, 79, 80, 98, 99,
			101
		}, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(70, new List<short>(), 0));
		_dataArray.Add(new GuidingChapterTriggerItem(71, new List<short> { 40 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(72, new List<short> { 187 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(73, new List<short> { 41 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(74, new List<short> { 100, 354 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(75, new List<short> { 90 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(76, new List<short> { 335 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(77, new List<short> { 184, 185 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(78, new List<short> { 180, 181 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(79, new List<short> { 194, 195, 197 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(80, new List<short> { 133 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(81, new List<short> { 136 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(82, new List<short> { 280, 287 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(83, new List<short> { 289 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(84, new List<short> { 288 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(85, new List<short> { 279 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(86, new List<short> { 122 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(87, new List<short> { 89, 90 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(88, new List<short> { 201, 204, 206, 254 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(89, new List<short> { 296 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(90, new List<short> { 294 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(91, new List<short> { 38 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(92, new List<short> { 308 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(93, new List<short> { 310 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(94, new List<short> { 309 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(95, new List<short> { 293 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(96, new List<short> { 91, 93, 94, 95, 96, 97 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(97, new List<short> { 87 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(98, new List<short> { 32, 33 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(99, new List<short> { 292 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(100, new List<short> { 302 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(101, new List<short> { 102, 117 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(102, new List<short> { 334 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(103, new List<short> { 336 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(104, new List<short> { 338 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(105, new List<short> { 335 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(106, new List<short> { 336 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(107, new List<short> { 337 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(108, new List<short>(), 0));
		_dataArray.Add(new GuidingChapterTriggerItem(109, new List<short> { 179 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(110, new List<short> { 215 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(111, new List<short> { 44 }, 6));
		_dataArray.Add(new GuidingChapterTriggerItem(112, new List<short> { 207, 208, 209, 211 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(113, new List<short> { 4 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(114, new List<short> { 297 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(115, new List<short> { 299 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(116, new List<short> { 290 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(117, new List<short> { 304 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(118, new List<short> { 123 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(119, new List<short> { 274, 275, 278 }, 0));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new GuidingChapterTriggerItem(120, new List<short> { 287 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(121, new List<short> { 36 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(122, new List<short> { 37 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(123, new List<short> { 119 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(124, new List<short> { 35 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(125, new List<short> { 291 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(126, new List<short> { 301 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(127, new List<short> { 88 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(128, new List<short> { 44 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(129, new List<short> { 298 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(130, new List<short> { 295 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(131, new List<short> { 199 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(132, new List<short> { 4 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(133, new List<short> { 311, 312 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(134, new List<short> { 191, 192, 193 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(135, new List<short> { 340 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(136, new List<short> { 342 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(137, new List<short> { 339 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(138, new List<short> { 303 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(139, new List<short>(), 0));
		_dataArray.Add(new GuidingChapterTriggerItem(140, new List<short> { 7 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(141, new List<short> { 178 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(142, new List<short> { 282 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(143, new List<short> { 273, 277 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(144, new List<short> { 283 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(145, new List<short> { 266 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(146, new List<short> { 256 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(147, new List<short> { 236 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(148, new List<short> { 269 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(149, new List<short> { 263 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(150, new List<short> { 222, 226 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(151, new List<short> { 270 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(152, new List<short> { 228 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(153, new List<short> { 111, 112, 113, 114 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(154, new List<short> { 272 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(155, new List<short> { 252 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(156, new List<short> { 358 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(157, new List<short> { 233, 235 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(158, new List<short> { 111, 113, 114 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(159, new List<short> { 238 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(160, new List<short> { 241 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(161, new List<short> { 246 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(162, new List<short> { 237, 268, 105 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(163, new List<short> { 244 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(164, new List<short> { 247 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(165, new List<short> { 245 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(166, new List<short> { 243 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(167, new List<short> { 242, 268 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(168, new List<short> { 239 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(169, new List<short> { 240 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(170, new List<short> { 261 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(171, new List<short> { 260 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(172, new List<short> { 259 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(173, new List<short> { 248 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(174, new List<short> { 262 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(175, new List<short> { 19, 20 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(176, new List<short> { 347 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(177, new List<short> { 27 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(178, new List<short> { 31 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(179, new List<short> { 51 }, 0));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new GuidingChapterTriggerItem(180, new List<short> { 58, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(181, new List<short> { 59 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(182, new List<short> { 60 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(183, new List<short> { 61, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(184, new List<short> { 62, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(185, new List<short> { 63, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(186, new List<short> { 64, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(187, new List<short> { 65, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(188, new List<short> { 66, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(189, new List<short> { 67, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(190, new List<short> { 68 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(191, new List<short> { 69 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(192, new List<short> { 70, 52 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(193, new List<short> { 71 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(194, new List<short> { 72 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(195, new List<short> { 300 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(196, new List<short> { 8 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(197, new List<short> { 49 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(198, new List<short> { 48 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(199, new List<short> { 47 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(200, new List<short> { 22 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(201, new List<short> { 25 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(202, new List<short> { 212 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(203, new List<short> { 173 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(204, new List<short> { 53 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(205, new List<short> { 39 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(206, new List<short> { 174 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(207, new List<short> { 174 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(208, new List<short> { 14 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(209, new List<short> { 54 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(210, new List<short> { 55 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(211, new List<short> { 213 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(212, new List<short> { 13 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(213, new List<short> { 15 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(214, new List<short> { 10 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(215, new List<short> { 137 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(216, new List<short> { 135 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(217, new List<short> { 135 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(218, new List<short> { 139 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(219, new List<short> { 132 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(220, new List<short> { 140 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(221, new List<short> { 134 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(222, new List<short> { 343 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(223, new List<short> { 85 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(224, new List<short> { 312 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(225, new List<short> { 49 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(226, new List<short> { 21 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(227, new List<short> { 258 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(228, new List<short>(), 0));
		_dataArray.Add(new GuidingChapterTriggerItem(229, new List<short> { 272 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(230, new List<short> { 171 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(231, new List<short> { 169 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(232, new List<short> { 170 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(233, new List<short> { 336 }, 20));
		_dataArray.Add(new GuidingChapterTriggerItem(234, new List<short> { 337 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(235, new List<short> { 198 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(236, new List<short> { 204 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(237, new List<short> { 108 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(238, new List<short> { 172 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(239, new List<short> { 6 }, 0));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new GuidingChapterTriggerItem(240, new List<short> { 38, 39 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(241, new List<short> { 0 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(242, new List<short> { 26 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(243, new List<short> { 88 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(244, new List<short> { 5 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(245, new List<short> { 255 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(246, new List<short> { 121 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(247, new List<short> { 120 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(248, new List<short> { 331 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(249, new List<short> { 355 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(250, new List<short> { 265 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(251, new List<short> { 108 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(252, new List<short> { 109 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(253, new List<short> { 344 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(254, new List<short> { 83 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(255, new List<short> { 82 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(256, new List<short> { 7 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(257, new List<short> { 138 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(258, new List<short> { 356 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(259, new List<short> { 249 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(260, new List<short> { 202, 203 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(261, new List<short> { 317 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(262, new List<short> { 322 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(263, new List<short> { 315 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(264, new List<short> { 210 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(265, new List<short> { 92 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(266, new List<short> { 182 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(267, new List<short> { 207 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(268, new List<short> { 81 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(269, new List<short> { 270 }, 100));
		_dataArray.Add(new GuidingChapterTriggerItem(270, new List<short> { 341 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(271, new List<short> { 106 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(272, new List<short> { 110 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(273, new List<short> { 250, 251 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(274, new List<short> { 230 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(275, new List<short> { 349 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(276, new List<short> { 29 }, 50));
		_dataArray.Add(new GuidingChapterTriggerItem(277, new List<short> { 28 }, 100));
		_dataArray.Add(new GuidingChapterTriggerItem(278, new List<short> { 205 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(279, new List<short> { 229, 223, 224, 225, 227 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(280, new List<short> { 100, 217, 218 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(281, new List<short> { 220 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(282, new List<short> { 201 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(283, new List<short> { 12 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(284, new List<short> { 350 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(285, new List<short> { 200 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(286, new List<short> { 284, 285, 286 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(287, new List<short> { 281 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(288, new List<short> { 9 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(289, new List<short> { 86 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(290, new List<short> { 111 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(291, new List<short> { 130 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(292, new List<short> { 253 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(293, new List<short> { 128 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(294, new List<short> { 264 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(295, new List<short> { 126 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(296, new List<short> { 183 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(297, new List<short> { 129 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(298, new List<short> { 124 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(299, new List<short> { 127 }, 0));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new GuidingChapterTriggerItem(300, new List<short> { 18 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(301, new List<short> { 125 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(302, new List<short> { 307 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(303, new List<short> { 179 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(304, new List<short> { 234 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(305, new List<short> { 281 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(306, new List<short> { 188 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(307, new List<short> { 186 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(308, new List<short> { 216 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(309, new List<short> { 121 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(310, new List<short> { 120 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(311, new List<short> { 190 }, 10));
		_dataArray.Add(new GuidingChapterTriggerItem(312, new List<short> { 45 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(313, new List<short> { 359 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(314, new List<short> { 6 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(315, new List<short> { 276 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(316, new List<short> { 196 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(317, new List<short> { 190 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(318, new List<short> { 345 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(319, new List<short> { 1, 2, 3 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(320, new List<short> { 23 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(321, new List<short> { 232 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(322, new List<short> { 360 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(323, new List<short> { 231 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(324, new List<short> { 2 }, 100));
		_dataArray.Add(new GuidingChapterTriggerItem(325, new List<short> { 3 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(326, new List<short> { 348 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(327, new List<short> { 178 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(328, new List<short> { 357 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(329, new List<short> { 112 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(330, new List<short> { 257 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(331, new List<short> { 103 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(332, new List<short> { 290 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(333, new List<short> { 266 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(334, new List<short> { 11 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(335, new List<short> { 228 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(336, new List<short> { 361 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(337, new List<short> { 362 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(338, new List<short> { 363 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(339, new List<short> { 364 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(340, new List<short> { 365 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(341, new List<short> { 366 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(342, new List<short> { 368 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(343, new List<short> { 369 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(344, new List<short> { 371 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(345, new List<short> { 372 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(346, new List<short> { 373 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(347, new List<short> { 374 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(348, new List<short> { 375 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(349, new List<short> { 376 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(350, new List<short> { 377 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(351, new List<short> { 378 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(352, new List<short> { 379 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(353, new List<short> { 380 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(354, new List<short> { 381 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(355, new List<short> { 382 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(356, new List<short> { 386 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(357, new List<short> { 383 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(358, new List<short> { 384 }, 0));
		_dataArray.Add(new GuidingChapterTriggerItem(359, new List<short> { 385 }, 0));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<GuidingChapterTriggerItem>(360);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
	}
}

using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class InstantNotification : ConfigData<InstantNotificationItem, short>
{
	public static class DefKey
	{
		public const short BuildingUpgradingCompleted = 0;

		public const short BuildingDemolitionCompleted = 1;

		public const short BuildingCraftingCompleted = 2;

		public const short BuildingConstructionCompleted = 3;

		public const short BuildingProductGenerated = 4;

		public const short BuildingDamaged = 5;

		public const short BuildingRuined = 6;

		public const short BeginBuildingConstruction = 7;

		public const short BeginBuildingUpgrading = 8;

		public const short BeginBuildingDemolition = 9;

		public const short CancelBuildingDemolition = 10;

		public const short CandidateArrived = 11;

		public const short CandidateLeaved = 12;

		public const short JoinTaiwuVillage = 13;

		public const short LeaveTaiwuVillage = 14;

		public const short WarehouseItemLost = 15;

		public const short BuildingLoseAuthority = 16;

		public const short DiscoverRelay = 17;

		public const short WalkThroughAbyss = 18;

		public const short BeginAdventure = 19;

		public const short NaturalDisasterEncountered = 20;

		public const short JoinGroup = 21;

		public const short LeaveGroup = 22;

		public const short BehaviorTypeChanged = 23;

		public const short SectInheritedApprovingReceived = 292;

		public const short InheritedApprovingRateReceived = 24;

		public const short FameIncreased = 25;

		public const short FameDecreased = 26;

		public const short HappinessIncreased = 27;

		public const short HappinessDecreased = 28;

		public const short FavorabilityIncreased = 29;

		public const short FavorabilityDecreased = 30;

		public const short FavorabilityIncreasedAcrossLevels = 31;

		public const short FavorabilityDecreasedAcrossLevels = 32;

		public const short LovingItemRevealed = 33;

		public const short HatingItemRevealed = 34;

		public const short LovingItemRevealedNothing = 35;

		public const short HatingItemRevealedNothing = 36;

		public const short EatBloodDew = 37;

		public const short CombatSkillLearned = 38;

		public const short HealthIncreased = 39;

		public const short HealthDecreased = 40;

		public const short XiangshuInfectionIncreased = 41;

		public const short XiangshuInfectionDecreased = 42;

		public const short XiangshuPartlyInfected = 43;

		public const short XiangshuCompletelyInfected = 44;

		public const short MainAttributeRecovered = 45;

		public const short MainAttributeConsumed = 46;

		public const short DisorderOfQiIncreased = 47;

		public const short DisorderOfQiDecreased = 48;

		public const short InjuryIncreased = 49;

		public const short InjuryDecreased = 50;

		public const short PoisonIncreased = 51;

		public const short PoisonDecreased = 52;

		public const short ExpIncreased = 53;

		public const short ExpDecreased = 54;

		public const short ResourceIncreased = 55;

		public const short ResourceDecreased = 56;

		public const short GetItem = 57;

		public const short LoseItem = 58;

		public const short CharacterGrownUp = 59;

		public const short CharacterDead = 60;

		public const short CricketDead = 61;

		public const short FamilyDied = 62;

		public const short EnemyDied = 63;

		public const short EnemyLucky = 64;

		public const short EnemyUnlucky = 65;

		public const short EnemyLoseInLifeSkill = 66;

		public const short EnemyLoseInCombat = 67;

		public const short EnemyGreatLoseInCombat = 68;

		public const short FamilyMiscarriage = 69;

		public const short AbandonExposed = 70;

		public const short AbandonAcknowledged = 71;

		public const short FamilyAbandon = 72;

		public const short SelfImmoralLove = 73;

		public const short FamilyHaveKid = 74;

		public const short HaveKid = 75;

		public const short FamilyImmoralKid = 76;

		public const short ReligiousFamilyHaveKid = 77;

		public const short FamilyInLove = 78;

		public const short FamilyImmoralLove = 79;

		public const short ReligiousFamilyInLove = 80;

		public const short FamilyMarried = 81;

		public const short FamilyImmoralMarriage = 82;

		public const short FamilyBeFriendWithEnemy = 83;

		public const short FamilyJieyiWithEnemy = 84;

		public const short FamilyAdoptedMaleEnemy = 85;

		public const short FamilyAdoptedFemaleEnemy = 86;

		public const short FamilyAdoptedByMaleEnemy = 87;

		public const short FamilyAdoptedByFemaleEnemy = 88;

		public const short FamilyEndedImmoralLove = 89;

		public const short FamilyEndedFriendshipWithEnemy = 90;

		public const short FamilyEndedJieyiWithEnemy = 91;

		public const short LoverHaveSex = 92;

		public const short TaiwuVillageIdleCount = 93;

		public const short ProfessionSeniorityIncrease = 94;

		public const short ProfessionUnlockSkill = 95;

		public const short ProfessionSkillHasCoolDown = 96;

		public const short ProfessionSkillEffectIsEnd = 97;

		public const short ProfessionHunterSkill0 = 98;

		public const short ProfessionMartialArtistSkill2 = 99;

		public const short ProfessionLiteratiSkill2 = 100;

		public const short ProfessionCivilianSkill1 = 101;

		public const short ProfessionCivilianSkill2 = 102;

		public const short ProfessionDoctorSkill1 = 103;

		public const short ProfessionMonkBreakFoodRule = 104;

		public const short ProfessionMonkBreakLoveRule = 105;

		public const short ProfessionHunterSkill0None = 106;

		public const short SettlementStoryGoodEnd = 107;

		public const short SettlementStoryBadEnd = 108;

		public const short ReadInCombat = 109;

		public const short ReadInLifeSkillCombat = 110;

		public const short ReadInCombatNoChance = 111;

		public const short ReadInLifeSkillCombatNoChance = 112;

		public const short BookRepairSuccess = 113;

		public const short ReincarnationArchitectureReincarnationEnd = 114;

		public const short TheNestOfRegulationDies = 115;

		public const short XuannvBlockMusicTranscribe = 116;

		public const short XuannvStateMusicTranscribe = 117;

		public const short DuChuangYiGeReady = 118;

		public const short CultureDecline = 119;

		public const short ThunderPowerGrow = 120;

		public const short FloodPowerGrow = 121;

		public const short BlazePowerGrow = 122;

		public const short StormPowerGrow = 123;

		public const short SandPowerGrow = 124;

		public const short ThunderPowerDecline = 125;

		public const short FloodPowerDecline = 126;

		public const short BlazePowerDecline = 127;

		public const short StormPowerDecline = 128;

		public const short SandPowerDecline = 129;

		public const short JiaoAbilityUp = 130;

		public const short JiaoAbilityDown = 131;

		public const short JiaoGiftAbilityUp = 132;

		public const short JiaoGiftAbilityDown = 133;

		public const short JiaoAbilityUpPercent = 134;

		public const short JiaoAbilityDownPercent = 135;

		public const short JiaoAbilityUpFloat = 136;

		public const short JiaoAbilityDownFloat = 137;

		public const short WugKingEscape = 138;

		public const short WugKingParasitiferDead = 139;

		public const short WugKingDead = 140;

		public const short WugKingDeadSpecial = 141;

		public const short KnowMonkSecret = 142;

		public const short GraceIncreased = 143;

		public const short WugKingEscape1 = 144;

		public const short WugKingEscape2 = 145;

		public const short QiArtInCombatNoChance = 146;

		public const short QiArtInLifeSkillCombatNoChance = 147;

		public const short SectStoryBaihuaToAnimal = 148;

		public const short SectStoryBaihuaToHuman = 149;

		public const short MechanismOfDetonation = 150;

		public const short ProfessionSeniorityIncrease1 = 151;

		public const short BlockResourceRecovery = 152;

		public const short ShenTreeGrow = 153;

		public const short BeastUpgrade = 154;

		public const short BeastDowngrade = 155;

		public const short GatherCompanions = 156;

		public const short DisseminateSecretInformation = 157;

		public const short DisseminateInformation = 158;

		public const short RecommendFellowUp = 159;

		public const short RecommendFellowDown = 160;

		public const short ComradePropertyUp = 161;

		public const short ComradeCombatSkillUp = 162;

		public const short ComradeLifeSkillUp = 163;

		public const short ComradeFeatureUp = 164;

		public const short ReleasePrisoners = 165;

		public const short DriveAwayPeople = 166;

		public const short QuenchHatred = 167;

		public const short VisitTemple = 168;

		public const short DrinkTeaRecharge = 169;

		public const short ReleaseSouls = 170;

		public const short SectPunishmentWarrantRelieved = 171;

		public const short SectPunishmentCharacterFeatureRelieved = 172;

		public const short ResignationPosition = 173;

		public const short Legacy = 174;

		public const short CultureUp = 175;

		public const short SecurityUp = 176;

		public const short CultureDown = 177;

		public const short SecurityDown = 178;

		public const short MapPickupsResource = 179;

		public const short MapPickupsFoodIngredients = 180;

		public const short MapPickupsMaterials = 181;

		public const short MapPickupsHerbal0 = 182;

		public const short MapPickupsHerbal1 = 183;

		public const short MapPickupsPoison = 184;

		public const short MapPickupsInjuryMedicine = 185;

		public const short MapPickupsAntidote = 186;

		public const short MapPickupsGainMedicine = 187;

		public const short MapPickupsFruit = 188;

		public const short MapPickupsChickenDishes = 189;

		public const short MapPickupsMeatDishes = 190;

		public const short MapPickupsVegetarianDishes = 191;

		public const short MapPickupsSeafoodDishes = 192;

		public const short MapPickupsWine = 193;

		public const short MapPickupsTea = 194;

		public const short MapPickupsTool = 195;

		public const short MapPickupsAccessory = 196;

		public const short MapPickupsPoisonCream = 197;

		public const short MapPickupsHarrier = 198;

		public const short MapPickupsToken = 199;

		public const short MapPickupsNeedleBox = 200;

		public const short MapPickupsThorn = 201;

		public const short MapPickupsHiddenWeapon = 202;

		public const short MapPickupsFlute = 203;

		public const short MapPickupsGloves = 204;

		public const short MapPickupsFurGloves = 205;

		public const short MapPickupsPestle = 206;

		public const short MapPickupsSword = 207;

		public const short MapPickupsBlade = 208;

		public const short MapPickupsPolearm = 209;

		public const short MapPickupQin = 210;

		public const short MapPickupsWhisk = 211;

		public const short MapPickupsWhip = 212;

		public const short MapPickupsCrest = 213;

		public const short MapPickupsShoes = 214;

		public const short MapPickupsArmor = 215;

		public const short MapPickupsArmGuard = 216;

		public const short MapPickupsCarDrop = 217;

		public const short MapPickupsExp = 218;

		public const short MapPickupsReading = 219;

		public const short MapPickupsQiArt = 220;

		public const short MapPickupsMorale = 221;

		public const short MapPickupsProperty = 222;

		public const short MapPickupsEnemyEscape = 223;

		public const short BuildingExp = 224;

		public const short WalkThroughDestroyBlock = 225;

		public const short WalkThroughErosionBlock = 226;

		public const short ComradePropertyUpNew = 227;

		public const short ComradeCombatSkillUpNew = 228;

		public const short ComradeLifeSkillUpNew = 229;

		public const short ComradePropertyUpNew1 = 230;

		public const short ComradeCombatSkillUpNew1 = 231;

		public const short ComradeLifeSkillUpNew1 = 232;

		public const short CharacterEscape = 233;

		public const short GraceUp = 234;

		public const short GraceDown = 235;

		public const short ExpelEnemy = 236;

		public const short ExpelRighteous = 237;

		public const short ExpelXiangshuMinion = 238;

		public const short ExpelBeast = 239;

		public const short MapPickupsPoisonCorrected = 240;

		public const short MapPickupsInjuryMedicineCorrected = 241;

		public const short MapPickupsAntidoteCorrected = 242;

		public const short MapPickupsGainMedicineCorrected = 243;

		public const short MapPickupsResourceUpdate = 244;

		public const short MapPickupsExpUpdate = 245;

		public const short MapPickupsMoraleUpdate = 246;

		public const short MapPickupsItemUpdate = 247;

		public const short MapPickupsReadingUpdate = 248;

		public const short MapPickupsQiArtUpdate = 249;

		public const short MakeItemOutsideSettlement = 250;

		public const short GainFuyuFaith1 = 251;

		public const short GainFuyuFaith2 = 252;

		public const short GainFuyuFaith3 = 253;

		public const short MapPickupsMedicineUpdate = 254;

		public const short JixiKillTemplateEnemy = 255;

		public const short NeiliRecovery = 256;

		public const short AdventureRedeem = 257;

		public const short AdventureCharacterFollow = 258;

		public const short AdventureStopFollow = 259;

		public const short AdventureAttendBanquet = 260;

		public const short AdventureKillHeretics = 261;

		public const short AdventureBecomeEnemy = 262;

		public const short AdventureMusicStart = 263;

		public const short AdventureChessStart = 264;

		public const short AdventurePoemStart = 265;

		public const short AdventurePaintStart = 266;

		public const short AdventureGiveUpRedeem = 267;

		public const short AdventureXRSDElementStoneBuffMetal = 268;

		public const short AdventureXRSDElementStoneBuffWood = 269;

		public const short AdventureXRSDElementStoneBuffWater = 270;

		public const short AdventureXRSDElementStoneBuffFire = 271;

		public const short AdventureXRSDElementStoneBuffEarth = 272;

		public const short AdventureXRSDElementStoneDeBuffMetal0 = 273;

		public const short AdventureXRSDElementStoneDeBuffWood0 = 274;

		public const short AdventureXRSDElementStoneDeBuffWater0 = 275;

		public const short AdventureXRSDElementStoneDeBuffFire0 = 276;

		public const short AdventureXRSDElementStoneDeBuffEarth0 = 277;

		public const short AdventureXRSDElementStoneDeBuffMetal1 = 278;

		public const short AdventureXRSDElementStoneDeBuffWood1 = 279;

		public const short AdventureXRSDElementStoneDeBuffWater1 = 280;

		public const short AdventureXRSDElementStoneDeBuffFire1 = 281;

		public const short AdventureXRSDElementStoneDeBuffEarth1 = 282;

		public const short AdventureXRSDNeiliChangeMetal = 285;

		public const short AdventureXRSDNeiliChangeWood = 286;

		public const short AdventureXRSDNeiliChangeWater = 287;

		public const short AdventureXRSDNeiliChangeFire = 288;

		public const short AdventureXRSDNeiliChangeEarth = 289;

		public const short AdventureCharacterDie = 283;

		public const short AdventureCharacterDie0 = 284;

		public const short AlertnessUp = 290;

		public const short AlertnessDown = 291;

		public const short CricketHPUp = 293;

		public const short CricketSPUp = 294;

		public const short CricketVigorUp = 295;

		public const short CricketStrengthUp = 296;

		public const short CricketBiteUp = 297;

		public const short CricketDeadlinessUp = 298;

		public const short CricketDamageUp = 299;

		public const short CricketCrippleUp = 300;

		public const short CricketDefenceUp = 301;

		public const short CricketDamageReduceUp = 302;

		public const short CricketCounterUp = 303;

		public const short CricketDurabilityUp = 304;

		public const short BlastTrap = 305;

		public const short ShootTrap = 306;

		public const short GasTrap = 307;

		public const short ScreamTrap = 308;

		public const short MistTrap = 309;

		public const short AutoOperationDiscard = 310;

		public const short AutoOperationDisassemble = 311;

		public const short PrepareEscape = 312;

		public const short MonvGood = 313;

		public const short MonvBad = 314;

		public const short DayueYaochangGood = 315;

		public const short DayueYaochangBad = 316;

		public const short JiuhanGood = 317;

		public const short JiuhanBad = 318;

		public const short JinHuangerGood = 319;

		public const short JinHuangerBad = 320;

		public const short YiyihouGood = 321;

		public const short YiyihouBad = 322;

		public const short WeiQiGood = 323;

		public const short WeiQiBad = 324;

		public const short YixiangGood = 325;

		public const short YixiangBad = 326;

		public const short XuefengGood = 327;

		public const short XuefengBad = 328;

		public const short ShufangGood = 329;

		public const short ShufangBad = 330;

		public const short JinHuangerGoodFailed = 331;

		public const short JinHuangerBadFailed = 332;

		public const short WeiQiGoodStart = 333;

		public const short WeiQiBadStart = 334;

		public const short TaiwuAsXiangshuSkill0 = 335;

		public const short TaiwuAsXiangshuSkill1 = 336;
	}

	public static class DefValue
	{
		public static InstantNotificationItem BuildingUpgradingCompleted => Instance[(short)0];

		public static InstantNotificationItem BuildingDemolitionCompleted => Instance[(short)1];

		public static InstantNotificationItem BuildingCraftingCompleted => Instance[(short)2];

		public static InstantNotificationItem BuildingConstructionCompleted => Instance[(short)3];

		public static InstantNotificationItem BuildingProductGenerated => Instance[(short)4];

		public static InstantNotificationItem BuildingDamaged => Instance[(short)5];

		public static InstantNotificationItem BuildingRuined => Instance[(short)6];

		public static InstantNotificationItem BeginBuildingConstruction => Instance[(short)7];

		public static InstantNotificationItem BeginBuildingUpgrading => Instance[(short)8];

		public static InstantNotificationItem BeginBuildingDemolition => Instance[(short)9];

		public static InstantNotificationItem CancelBuildingDemolition => Instance[(short)10];

		public static InstantNotificationItem CandidateArrived => Instance[(short)11];

		public static InstantNotificationItem CandidateLeaved => Instance[(short)12];

		public static InstantNotificationItem JoinTaiwuVillage => Instance[(short)13];

		public static InstantNotificationItem LeaveTaiwuVillage => Instance[(short)14];

		public static InstantNotificationItem WarehouseItemLost => Instance[(short)15];

		public static InstantNotificationItem BuildingLoseAuthority => Instance[(short)16];

		public static InstantNotificationItem DiscoverRelay => Instance[(short)17];

		public static InstantNotificationItem WalkThroughAbyss => Instance[(short)18];

		public static InstantNotificationItem BeginAdventure => Instance[(short)19];

		public static InstantNotificationItem NaturalDisasterEncountered => Instance[(short)20];

		public static InstantNotificationItem JoinGroup => Instance[(short)21];

		public static InstantNotificationItem LeaveGroup => Instance[(short)22];

		public static InstantNotificationItem BehaviorTypeChanged => Instance[(short)23];

		public static InstantNotificationItem SectInheritedApprovingReceived => Instance[(short)292];

		public static InstantNotificationItem InheritedApprovingRateReceived => Instance[(short)24];

		public static InstantNotificationItem FameIncreased => Instance[(short)25];

		public static InstantNotificationItem FameDecreased => Instance[(short)26];

		public static InstantNotificationItem HappinessIncreased => Instance[(short)27];

		public static InstantNotificationItem HappinessDecreased => Instance[(short)28];

		public static InstantNotificationItem FavorabilityIncreased => Instance[(short)29];

		public static InstantNotificationItem FavorabilityDecreased => Instance[(short)30];

		public static InstantNotificationItem FavorabilityIncreasedAcrossLevels => Instance[(short)31];

		public static InstantNotificationItem FavorabilityDecreasedAcrossLevels => Instance[(short)32];

		public static InstantNotificationItem LovingItemRevealed => Instance[(short)33];

		public static InstantNotificationItem HatingItemRevealed => Instance[(short)34];

		public static InstantNotificationItem LovingItemRevealedNothing => Instance[(short)35];

		public static InstantNotificationItem HatingItemRevealedNothing => Instance[(short)36];

		public static InstantNotificationItem EatBloodDew => Instance[(short)37];

		public static InstantNotificationItem CombatSkillLearned => Instance[(short)38];

		public static InstantNotificationItem HealthIncreased => Instance[(short)39];

		public static InstantNotificationItem HealthDecreased => Instance[(short)40];

		public static InstantNotificationItem XiangshuInfectionIncreased => Instance[(short)41];

		public static InstantNotificationItem XiangshuInfectionDecreased => Instance[(short)42];

		public static InstantNotificationItem XiangshuPartlyInfected => Instance[(short)43];

		public static InstantNotificationItem XiangshuCompletelyInfected => Instance[(short)44];

		public static InstantNotificationItem MainAttributeRecovered => Instance[(short)45];

		public static InstantNotificationItem MainAttributeConsumed => Instance[(short)46];

		public static InstantNotificationItem DisorderOfQiIncreased => Instance[(short)47];

		public static InstantNotificationItem DisorderOfQiDecreased => Instance[(short)48];

		public static InstantNotificationItem InjuryIncreased => Instance[(short)49];

		public static InstantNotificationItem InjuryDecreased => Instance[(short)50];

		public static InstantNotificationItem PoisonIncreased => Instance[(short)51];

		public static InstantNotificationItem PoisonDecreased => Instance[(short)52];

		public static InstantNotificationItem ExpIncreased => Instance[(short)53];

		public static InstantNotificationItem ExpDecreased => Instance[(short)54];

		public static InstantNotificationItem ResourceIncreased => Instance[(short)55];

		public static InstantNotificationItem ResourceDecreased => Instance[(short)56];

		public static InstantNotificationItem GetItem => Instance[(short)57];

		public static InstantNotificationItem LoseItem => Instance[(short)58];

		public static InstantNotificationItem CharacterGrownUp => Instance[(short)59];

		public static InstantNotificationItem CharacterDead => Instance[(short)60];

		public static InstantNotificationItem CricketDead => Instance[(short)61];

		public static InstantNotificationItem FamilyDied => Instance[(short)62];

		public static InstantNotificationItem EnemyDied => Instance[(short)63];

		public static InstantNotificationItem EnemyLucky => Instance[(short)64];

		public static InstantNotificationItem EnemyUnlucky => Instance[(short)65];

		public static InstantNotificationItem EnemyLoseInLifeSkill => Instance[(short)66];

		public static InstantNotificationItem EnemyLoseInCombat => Instance[(short)67];

		public static InstantNotificationItem EnemyGreatLoseInCombat => Instance[(short)68];

		public static InstantNotificationItem FamilyMiscarriage => Instance[(short)69];

		public static InstantNotificationItem AbandonExposed => Instance[(short)70];

		public static InstantNotificationItem AbandonAcknowledged => Instance[(short)71];

		public static InstantNotificationItem FamilyAbandon => Instance[(short)72];

		public static InstantNotificationItem SelfImmoralLove => Instance[(short)73];

		public static InstantNotificationItem FamilyHaveKid => Instance[(short)74];

		public static InstantNotificationItem HaveKid => Instance[(short)75];

		public static InstantNotificationItem FamilyImmoralKid => Instance[(short)76];

		public static InstantNotificationItem ReligiousFamilyHaveKid => Instance[(short)77];

		public static InstantNotificationItem FamilyInLove => Instance[(short)78];

		public static InstantNotificationItem FamilyImmoralLove => Instance[(short)79];

		public static InstantNotificationItem ReligiousFamilyInLove => Instance[(short)80];

		public static InstantNotificationItem FamilyMarried => Instance[(short)81];

		public static InstantNotificationItem FamilyImmoralMarriage => Instance[(short)82];

		public static InstantNotificationItem FamilyBeFriendWithEnemy => Instance[(short)83];

		public static InstantNotificationItem FamilyJieyiWithEnemy => Instance[(short)84];

		public static InstantNotificationItem FamilyAdoptedMaleEnemy => Instance[(short)85];

		public static InstantNotificationItem FamilyAdoptedFemaleEnemy => Instance[(short)86];

		public static InstantNotificationItem FamilyAdoptedByMaleEnemy => Instance[(short)87];

		public static InstantNotificationItem FamilyAdoptedByFemaleEnemy => Instance[(short)88];

		public static InstantNotificationItem FamilyEndedImmoralLove => Instance[(short)89];

		public static InstantNotificationItem FamilyEndedFriendshipWithEnemy => Instance[(short)90];

		public static InstantNotificationItem FamilyEndedJieyiWithEnemy => Instance[(short)91];

		public static InstantNotificationItem LoverHaveSex => Instance[(short)92];

		public static InstantNotificationItem TaiwuVillageIdleCount => Instance[(short)93];

		public static InstantNotificationItem ProfessionSeniorityIncrease => Instance[(short)94];

		public static InstantNotificationItem ProfessionUnlockSkill => Instance[(short)95];

		public static InstantNotificationItem ProfessionSkillHasCoolDown => Instance[(short)96];

		public static InstantNotificationItem ProfessionSkillEffectIsEnd => Instance[(short)97];

		public static InstantNotificationItem ProfessionHunterSkill0 => Instance[(short)98];

		public static InstantNotificationItem ProfessionMartialArtistSkill2 => Instance[(short)99];

		public static InstantNotificationItem ProfessionLiteratiSkill2 => Instance[(short)100];

		public static InstantNotificationItem ProfessionCivilianSkill1 => Instance[(short)101];

		public static InstantNotificationItem ProfessionCivilianSkill2 => Instance[(short)102];

		public static InstantNotificationItem ProfessionDoctorSkill1 => Instance[(short)103];

		public static InstantNotificationItem ProfessionMonkBreakFoodRule => Instance[(short)104];

		public static InstantNotificationItem ProfessionMonkBreakLoveRule => Instance[(short)105];

		public static InstantNotificationItem ProfessionHunterSkill0None => Instance[(short)106];

		public static InstantNotificationItem SettlementStoryGoodEnd => Instance[(short)107];

		public static InstantNotificationItem SettlementStoryBadEnd => Instance[(short)108];

		public static InstantNotificationItem ReadInCombat => Instance[(short)109];

		public static InstantNotificationItem ReadInLifeSkillCombat => Instance[(short)110];

		public static InstantNotificationItem ReadInCombatNoChance => Instance[(short)111];

		public static InstantNotificationItem ReadInLifeSkillCombatNoChance => Instance[(short)112];

		public static InstantNotificationItem BookRepairSuccess => Instance[(short)113];

		public static InstantNotificationItem ReincarnationArchitectureReincarnationEnd => Instance[(short)114];

		public static InstantNotificationItem TheNestOfRegulationDies => Instance[(short)115];

		public static InstantNotificationItem XuannvBlockMusicTranscribe => Instance[(short)116];

		public static InstantNotificationItem XuannvStateMusicTranscribe => Instance[(short)117];

		public static InstantNotificationItem DuChuangYiGeReady => Instance[(short)118];

		public static InstantNotificationItem CultureDecline => Instance[(short)119];

		public static InstantNotificationItem ThunderPowerGrow => Instance[(short)120];

		public static InstantNotificationItem FloodPowerGrow => Instance[(short)121];

		public static InstantNotificationItem BlazePowerGrow => Instance[(short)122];

		public static InstantNotificationItem StormPowerGrow => Instance[(short)123];

		public static InstantNotificationItem SandPowerGrow => Instance[(short)124];

		public static InstantNotificationItem ThunderPowerDecline => Instance[(short)125];

		public static InstantNotificationItem FloodPowerDecline => Instance[(short)126];

		public static InstantNotificationItem BlazePowerDecline => Instance[(short)127];

		public static InstantNotificationItem StormPowerDecline => Instance[(short)128];

		public static InstantNotificationItem SandPowerDecline => Instance[(short)129];

		public static InstantNotificationItem JiaoAbilityUp => Instance[(short)130];

		public static InstantNotificationItem JiaoAbilityDown => Instance[(short)131];

		public static InstantNotificationItem JiaoGiftAbilityUp => Instance[(short)132];

		public static InstantNotificationItem JiaoGiftAbilityDown => Instance[(short)133];

		public static InstantNotificationItem JiaoAbilityUpPercent => Instance[(short)134];

		public static InstantNotificationItem JiaoAbilityDownPercent => Instance[(short)135];

		public static InstantNotificationItem JiaoAbilityUpFloat => Instance[(short)136];

		public static InstantNotificationItem JiaoAbilityDownFloat => Instance[(short)137];

		public static InstantNotificationItem WugKingEscape => Instance[(short)138];

		public static InstantNotificationItem WugKingParasitiferDead => Instance[(short)139];

		public static InstantNotificationItem WugKingDead => Instance[(short)140];

		public static InstantNotificationItem WugKingDeadSpecial => Instance[(short)141];

		public static InstantNotificationItem KnowMonkSecret => Instance[(short)142];

		public static InstantNotificationItem GraceIncreased => Instance[(short)143];

		public static InstantNotificationItem WugKingEscape1 => Instance[(short)144];

		public static InstantNotificationItem WugKingEscape2 => Instance[(short)145];

		public static InstantNotificationItem QiArtInCombatNoChance => Instance[(short)146];

		public static InstantNotificationItem QiArtInLifeSkillCombatNoChance => Instance[(short)147];

		public static InstantNotificationItem SectStoryBaihuaToAnimal => Instance[(short)148];

		public static InstantNotificationItem SectStoryBaihuaToHuman => Instance[(short)149];

		public static InstantNotificationItem MechanismOfDetonation => Instance[(short)150];

		public static InstantNotificationItem ProfessionSeniorityIncrease1 => Instance[(short)151];

		public static InstantNotificationItem BlockResourceRecovery => Instance[(short)152];

		public static InstantNotificationItem ShenTreeGrow => Instance[(short)153];

		public static InstantNotificationItem BeastUpgrade => Instance[(short)154];

		public static InstantNotificationItem BeastDowngrade => Instance[(short)155];

		public static InstantNotificationItem GatherCompanions => Instance[(short)156];

		public static InstantNotificationItem DisseminateSecretInformation => Instance[(short)157];

		public static InstantNotificationItem DisseminateInformation => Instance[(short)158];

		public static InstantNotificationItem RecommendFellowUp => Instance[(short)159];

		public static InstantNotificationItem RecommendFellowDown => Instance[(short)160];

		public static InstantNotificationItem ComradePropertyUp => Instance[(short)161];

		public static InstantNotificationItem ComradeCombatSkillUp => Instance[(short)162];

		public static InstantNotificationItem ComradeLifeSkillUp => Instance[(short)163];

		public static InstantNotificationItem ComradeFeatureUp => Instance[(short)164];

		public static InstantNotificationItem ReleasePrisoners => Instance[(short)165];

		public static InstantNotificationItem DriveAwayPeople => Instance[(short)166];

		public static InstantNotificationItem QuenchHatred => Instance[(short)167];

		public static InstantNotificationItem VisitTemple => Instance[(short)168];

		public static InstantNotificationItem DrinkTeaRecharge => Instance[(short)169];

		public static InstantNotificationItem ReleaseSouls => Instance[(short)170];

		public static InstantNotificationItem SectPunishmentWarrantRelieved => Instance[(short)171];

		public static InstantNotificationItem SectPunishmentCharacterFeatureRelieved => Instance[(short)172];

		public static InstantNotificationItem ResignationPosition => Instance[(short)173];

		public static InstantNotificationItem Legacy => Instance[(short)174];

		public static InstantNotificationItem CultureUp => Instance[(short)175];

		public static InstantNotificationItem SecurityUp => Instance[(short)176];

		public static InstantNotificationItem CultureDown => Instance[(short)177];

		public static InstantNotificationItem SecurityDown => Instance[(short)178];

		public static InstantNotificationItem MapPickupsResource => Instance[(short)179];

		public static InstantNotificationItem MapPickupsFoodIngredients => Instance[(short)180];

		public static InstantNotificationItem MapPickupsMaterials => Instance[(short)181];

		public static InstantNotificationItem MapPickupsHerbal0 => Instance[(short)182];

		public static InstantNotificationItem MapPickupsHerbal1 => Instance[(short)183];

		public static InstantNotificationItem MapPickupsPoison => Instance[(short)184];

		public static InstantNotificationItem MapPickupsInjuryMedicine => Instance[(short)185];

		public static InstantNotificationItem MapPickupsAntidote => Instance[(short)186];

		public static InstantNotificationItem MapPickupsGainMedicine => Instance[(short)187];

		public static InstantNotificationItem MapPickupsFruit => Instance[(short)188];

		public static InstantNotificationItem MapPickupsChickenDishes => Instance[(short)189];

		public static InstantNotificationItem MapPickupsMeatDishes => Instance[(short)190];

		public static InstantNotificationItem MapPickupsVegetarianDishes => Instance[(short)191];

		public static InstantNotificationItem MapPickupsSeafoodDishes => Instance[(short)192];

		public static InstantNotificationItem MapPickupsWine => Instance[(short)193];

		public static InstantNotificationItem MapPickupsTea => Instance[(short)194];

		public static InstantNotificationItem MapPickupsTool => Instance[(short)195];

		public static InstantNotificationItem MapPickupsAccessory => Instance[(short)196];

		public static InstantNotificationItem MapPickupsPoisonCream => Instance[(short)197];

		public static InstantNotificationItem MapPickupsHarrier => Instance[(short)198];

		public static InstantNotificationItem MapPickupsToken => Instance[(short)199];

		public static InstantNotificationItem MapPickupsNeedleBox => Instance[(short)200];

		public static InstantNotificationItem MapPickupsThorn => Instance[(short)201];

		public static InstantNotificationItem MapPickupsHiddenWeapon => Instance[(short)202];

		public static InstantNotificationItem MapPickupsFlute => Instance[(short)203];

		public static InstantNotificationItem MapPickupsGloves => Instance[(short)204];

		public static InstantNotificationItem MapPickupsFurGloves => Instance[(short)205];

		public static InstantNotificationItem MapPickupsPestle => Instance[(short)206];

		public static InstantNotificationItem MapPickupsSword => Instance[(short)207];

		public static InstantNotificationItem MapPickupsBlade => Instance[(short)208];

		public static InstantNotificationItem MapPickupsPolearm => Instance[(short)209];

		public static InstantNotificationItem MapPickupQin => Instance[(short)210];

		public static InstantNotificationItem MapPickupsWhisk => Instance[(short)211];

		public static InstantNotificationItem MapPickupsWhip => Instance[(short)212];

		public static InstantNotificationItem MapPickupsCrest => Instance[(short)213];

		public static InstantNotificationItem MapPickupsShoes => Instance[(short)214];

		public static InstantNotificationItem MapPickupsArmor => Instance[(short)215];

		public static InstantNotificationItem MapPickupsArmGuard => Instance[(short)216];

		public static InstantNotificationItem MapPickupsCarDrop => Instance[(short)217];

		public static InstantNotificationItem MapPickupsExp => Instance[(short)218];

		public static InstantNotificationItem MapPickupsReading => Instance[(short)219];

		public static InstantNotificationItem MapPickupsQiArt => Instance[(short)220];

		public static InstantNotificationItem MapPickupsMorale => Instance[(short)221];

		public static InstantNotificationItem MapPickupsProperty => Instance[(short)222];

		public static InstantNotificationItem MapPickupsEnemyEscape => Instance[(short)223];

		public static InstantNotificationItem BuildingExp => Instance[(short)224];

		public static InstantNotificationItem WalkThroughDestroyBlock => Instance[(short)225];

		public static InstantNotificationItem WalkThroughErosionBlock => Instance[(short)226];

		public static InstantNotificationItem ComradePropertyUpNew => Instance[(short)227];

		public static InstantNotificationItem ComradeCombatSkillUpNew => Instance[(short)228];

		public static InstantNotificationItem ComradeLifeSkillUpNew => Instance[(short)229];

		public static InstantNotificationItem ComradePropertyUpNew1 => Instance[(short)230];

		public static InstantNotificationItem ComradeCombatSkillUpNew1 => Instance[(short)231];

		public static InstantNotificationItem ComradeLifeSkillUpNew1 => Instance[(short)232];

		public static InstantNotificationItem CharacterEscape => Instance[(short)233];

		public static InstantNotificationItem GraceUp => Instance[(short)234];

		public static InstantNotificationItem GraceDown => Instance[(short)235];

		public static InstantNotificationItem ExpelEnemy => Instance[(short)236];

		public static InstantNotificationItem ExpelRighteous => Instance[(short)237];

		public static InstantNotificationItem ExpelXiangshuMinion => Instance[(short)238];

		public static InstantNotificationItem ExpelBeast => Instance[(short)239];

		public static InstantNotificationItem MapPickupsPoisonCorrected => Instance[(short)240];

		public static InstantNotificationItem MapPickupsInjuryMedicineCorrected => Instance[(short)241];

		public static InstantNotificationItem MapPickupsAntidoteCorrected => Instance[(short)242];

		public static InstantNotificationItem MapPickupsGainMedicineCorrected => Instance[(short)243];

		public static InstantNotificationItem MapPickupsResourceUpdate => Instance[(short)244];

		public static InstantNotificationItem MapPickupsExpUpdate => Instance[(short)245];

		public static InstantNotificationItem MapPickupsMoraleUpdate => Instance[(short)246];

		public static InstantNotificationItem MapPickupsItemUpdate => Instance[(short)247];

		public static InstantNotificationItem MapPickupsReadingUpdate => Instance[(short)248];

		public static InstantNotificationItem MapPickupsQiArtUpdate => Instance[(short)249];

		public static InstantNotificationItem MakeItemOutsideSettlement => Instance[(short)250];

		public static InstantNotificationItem GainFuyuFaith1 => Instance[(short)251];

		public static InstantNotificationItem GainFuyuFaith2 => Instance[(short)252];

		public static InstantNotificationItem GainFuyuFaith3 => Instance[(short)253];

		public static InstantNotificationItem MapPickupsMedicineUpdate => Instance[(short)254];

		public static InstantNotificationItem JixiKillTemplateEnemy => Instance[(short)255];

		public static InstantNotificationItem NeiliRecovery => Instance[(short)256];

		public static InstantNotificationItem AdventureRedeem => Instance[(short)257];

		public static InstantNotificationItem AdventureCharacterFollow => Instance[(short)258];

		public static InstantNotificationItem AdventureStopFollow => Instance[(short)259];

		public static InstantNotificationItem AdventureAttendBanquet => Instance[(short)260];

		public static InstantNotificationItem AdventureKillHeretics => Instance[(short)261];

		public static InstantNotificationItem AdventureBecomeEnemy => Instance[(short)262];

		public static InstantNotificationItem AdventureMusicStart => Instance[(short)263];

		public static InstantNotificationItem AdventureChessStart => Instance[(short)264];

		public static InstantNotificationItem AdventurePoemStart => Instance[(short)265];

		public static InstantNotificationItem AdventurePaintStart => Instance[(short)266];

		public static InstantNotificationItem AdventureGiveUpRedeem => Instance[(short)267];

		public static InstantNotificationItem AdventureXRSDElementStoneBuffMetal => Instance[(short)268];

		public static InstantNotificationItem AdventureXRSDElementStoneBuffWood => Instance[(short)269];

		public static InstantNotificationItem AdventureXRSDElementStoneBuffWater => Instance[(short)270];

		public static InstantNotificationItem AdventureXRSDElementStoneBuffFire => Instance[(short)271];

		public static InstantNotificationItem AdventureXRSDElementStoneBuffEarth => Instance[(short)272];

		public static InstantNotificationItem AdventureXRSDElementStoneDeBuffMetal0 => Instance[(short)273];

		public static InstantNotificationItem AdventureXRSDElementStoneDeBuffWood0 => Instance[(short)274];

		public static InstantNotificationItem AdventureXRSDElementStoneDeBuffWater0 => Instance[(short)275];

		public static InstantNotificationItem AdventureXRSDElementStoneDeBuffFire0 => Instance[(short)276];

		public static InstantNotificationItem AdventureXRSDElementStoneDeBuffEarth0 => Instance[(short)277];

		public static InstantNotificationItem AdventureXRSDElementStoneDeBuffMetal1 => Instance[(short)278];

		public static InstantNotificationItem AdventureXRSDElementStoneDeBuffWood1 => Instance[(short)279];

		public static InstantNotificationItem AdventureXRSDElementStoneDeBuffWater1 => Instance[(short)280];

		public static InstantNotificationItem AdventureXRSDElementStoneDeBuffFire1 => Instance[(short)281];

		public static InstantNotificationItem AdventureXRSDElementStoneDeBuffEarth1 => Instance[(short)282];

		public static InstantNotificationItem AdventureXRSDNeiliChangeMetal => Instance[(short)285];

		public static InstantNotificationItem AdventureXRSDNeiliChangeWood => Instance[(short)286];

		public static InstantNotificationItem AdventureXRSDNeiliChangeWater => Instance[(short)287];

		public static InstantNotificationItem AdventureXRSDNeiliChangeFire => Instance[(short)288];

		public static InstantNotificationItem AdventureXRSDNeiliChangeEarth => Instance[(short)289];

		public static InstantNotificationItem AdventureCharacterDie => Instance[(short)283];

		public static InstantNotificationItem AdventureCharacterDie0 => Instance[(short)284];

		public static InstantNotificationItem AlertnessUp => Instance[(short)290];

		public static InstantNotificationItem AlertnessDown => Instance[(short)291];

		public static InstantNotificationItem CricketHPUp => Instance[(short)293];

		public static InstantNotificationItem CricketSPUp => Instance[(short)294];

		public static InstantNotificationItem CricketVigorUp => Instance[(short)295];

		public static InstantNotificationItem CricketStrengthUp => Instance[(short)296];

		public static InstantNotificationItem CricketBiteUp => Instance[(short)297];

		public static InstantNotificationItem CricketDeadlinessUp => Instance[(short)298];

		public static InstantNotificationItem CricketDamageUp => Instance[(short)299];

		public static InstantNotificationItem CricketCrippleUp => Instance[(short)300];

		public static InstantNotificationItem CricketDefenceUp => Instance[(short)301];

		public static InstantNotificationItem CricketDamageReduceUp => Instance[(short)302];

		public static InstantNotificationItem CricketCounterUp => Instance[(short)303];

		public static InstantNotificationItem CricketDurabilityUp => Instance[(short)304];

		public static InstantNotificationItem BlastTrap => Instance[(short)305];

		public static InstantNotificationItem ShootTrap => Instance[(short)306];

		public static InstantNotificationItem GasTrap => Instance[(short)307];

		public static InstantNotificationItem ScreamTrap => Instance[(short)308];

		public static InstantNotificationItem MistTrap => Instance[(short)309];

		public static InstantNotificationItem AutoOperationDiscard => Instance[(short)310];

		public static InstantNotificationItem AutoOperationDisassemble => Instance[(short)311];

		public static InstantNotificationItem PrepareEscape => Instance[(short)312];

		public static InstantNotificationItem MonvGood => Instance[(short)313];

		public static InstantNotificationItem MonvBad => Instance[(short)314];

		public static InstantNotificationItem DayueYaochangGood => Instance[(short)315];

		public static InstantNotificationItem DayueYaochangBad => Instance[(short)316];

		public static InstantNotificationItem JiuhanGood => Instance[(short)317];

		public static InstantNotificationItem JiuhanBad => Instance[(short)318];

		public static InstantNotificationItem JinHuangerGood => Instance[(short)319];

		public static InstantNotificationItem JinHuangerBad => Instance[(short)320];

		public static InstantNotificationItem YiyihouGood => Instance[(short)321];

		public static InstantNotificationItem YiyihouBad => Instance[(short)322];

		public static InstantNotificationItem WeiQiGood => Instance[(short)323];

		public static InstantNotificationItem WeiQiBad => Instance[(short)324];

		public static InstantNotificationItem YixiangGood => Instance[(short)325];

		public static InstantNotificationItem YixiangBad => Instance[(short)326];

		public static InstantNotificationItem XuefengGood => Instance[(short)327];

		public static InstantNotificationItem XuefengBad => Instance[(short)328];

		public static InstantNotificationItem ShufangGood => Instance[(short)329];

		public static InstantNotificationItem ShufangBad => Instance[(short)330];

		public static InstantNotificationItem JinHuangerGoodFailed => Instance[(short)331];

		public static InstantNotificationItem JinHuangerBadFailed => Instance[(short)332];

		public static InstantNotificationItem WeiQiGoodStart => Instance[(short)333];

		public static InstantNotificationItem WeiQiBadStart => Instance[(short)334];

		public static InstantNotificationItem TaiwuAsXiangshuSkill0 => Instance[(short)335];

		public static InstantNotificationItem TaiwuAsXiangshuSkill1 => Instance[(short)336];
	}

	public static InstantNotification Instance = new InstantNotification();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "SimpleDesc", "Desc", "TemplateId", "Type", "MergeableParameters" };

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
		_dataArray.Add(new InstantNotificationItem(0, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_0"), 2, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_0"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_0"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(1, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_1"), 2, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_1"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_1"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(2, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_2"), 1, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_2"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_2"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(3, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_3"), 2, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_3"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_3"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(4, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_4"), 1, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_4"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_4"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(5, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_5"), 1, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_5"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_5"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(6, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_6"), 2, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_6"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_6"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(7, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_7"), 2, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_7"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_7"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(8, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_8"), 2, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_8"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_8"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(9, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_9"), 2, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_9"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_9"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(10, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_10"), 2, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_10"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_10"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(11, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_11"), 1, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_11"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_11"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(12, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_12"), 1, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_12"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_12"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(13, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_13"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_13"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_13"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(14, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_14"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_14"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_14"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(15, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_15"), 1, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_15"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_15"), allowByEventFunction: false, new string[4] { "Item", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(16, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_16"), 2, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_16"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_16"), allowByEventFunction: false, new string[4] { "Settlement", "Building", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(17, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_17"), 2, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_17"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_17"), allowByEventFunction: false, new string[4] { "Location", "Settlement", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(18, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_18"), 1, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_18"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_18"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(19, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_19"), 2, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_19"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_19"), allowByEventFunction: false, new string[4] { "Location", "Adventure", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(20, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_20"), 1, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_20"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_20"), allowByEventFunction: false, new string[4] { "Location", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(21, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_21"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_21"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_21"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(22, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_22"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_22"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_22"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(23, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_23"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_23"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_23"), allowByEventFunction: false, new string[4] { "Character", "BehaviorType", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(24, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_24"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_24"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_24"), allowByEventFunction: false, new string[4] { "Settlement", "Character", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(25, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_25"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_25"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_25"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(26, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_26"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_26"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_26"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(27, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_27"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_27"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_27"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(28, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_28"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_28"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_28"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(29, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_29"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_29"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_29"), allowByEventFunction: false, new string[4] { "Settlement", "Character", "Character", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(30, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_30"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_30"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_30"), allowByEventFunction: false, new string[4] { "Settlement", "Character", "Character", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(31, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_31"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_31"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_31"), allowByEventFunction: false, new string[4] { "Character", "Character", "FavorabilityType", "" }, null));
		_dataArray.Add(new InstantNotificationItem(32, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_32"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_32"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_32"), allowByEventFunction: false, new string[4] { "Character", "Character", "FavorabilityType", "" }, null));
		_dataArray.Add(new InstantNotificationItem(33, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_33"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_33"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_33"), allowByEventFunction: false, new string[4] { "Settlement", "Character", "ItemSubType", "" }, null));
		_dataArray.Add(new InstantNotificationItem(34, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_34"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_34"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_34"), allowByEventFunction: false, new string[4] { "Settlement", "Character", "ItemSubType", "" }, null));
		_dataArray.Add(new InstantNotificationItem(35, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_35"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_35"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_35"), allowByEventFunction: false, new string[4] { "Settlement", "Character", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(36, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_36"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_36"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_36"), allowByEventFunction: false, new string[4] { "Settlement", "Character", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(37, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_37"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_37"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_37"), allowByEventFunction: false, new string[4] { "Character", "Item", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(38, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_38"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_38"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_38"), allowByEventFunction: false, new string[4] { "Character", "CombatSkill", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(39, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_39"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_39"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_39"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(40, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_40"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_40"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_40"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(41, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_41"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_41"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_41"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(42, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_42"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_42"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_42"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(43, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_43"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_43"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_43"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(44, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_44"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_44"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_44"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(45, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_45"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_45"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_45"), allowByEventFunction: false, new string[4] { "Character", "CharacterPropertyReferencedType", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(46, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_46"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_46"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_46"), allowByEventFunction: false, new string[4] { "Character", "CharacterPropertyReferencedType", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(47, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_47"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_47"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_47"), allowByEventFunction: false, new string[4] { "Character", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(48, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_48"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_48"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_48"), allowByEventFunction: false, new string[4] { "Character", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(49, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_49"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_49"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_49"), allowByEventFunction: false, new string[4] { "Character", "BodyPartType", "InjuryType", "" }, null));
		_dataArray.Add(new InstantNotificationItem(50, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_50"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_50"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_50"), allowByEventFunction: false, new string[4] { "Character", "BodyPartType", "InjuryType", "" }, null));
		_dataArray.Add(new InstantNotificationItem(51, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_51"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_51"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_51"), allowByEventFunction: false, new string[4] { "Character", "PoisonType", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(52, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_52"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_52"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_52"), allowByEventFunction: false, new string[4] { "Character", "PoisonType", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(53, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_53"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_53"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_53"), allowByEventFunction: false, new string[4] { "Character", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(54, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_54"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_54"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_54"), allowByEventFunction: false, new string[4] { "Character", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(55, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_55"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_55"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_55"), allowByEventFunction: false, new string[4] { "Character", "Resource", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(56, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_56"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_56"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_56"), allowByEventFunction: false, new string[4] { "Character", "Resource", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(57, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_57"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_57"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_57"), allowByEventFunction: false, new string[4] { "Character", "Item", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(58, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_58"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_58"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_58"), allowByEventFunction: false, new string[4] { "Character", "Item", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(59, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_59"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_59"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_59"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new InstantNotificationItem(60, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_60"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_60"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_60"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(61, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_61"), 1, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_61"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_61"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(62, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_62"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_62"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_62"), allowByEventFunction: false, new string[4] { "Character", "Location", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(63, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_63"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_63"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_63"), allowByEventFunction: false, new string[4] { "Character", "Location", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(64, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_64"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_64"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_64"), allowByEventFunction: false, new string[4] { "Character", "Location", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(65, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_65"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_65"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_65"), allowByEventFunction: false, new string[4] { "Character", "Location", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(66, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_66"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_66"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_66"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(67, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_67"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_67"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_67"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(68, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_68"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_68"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_68"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(69, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_69"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_69"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_69"), allowByEventFunction: false, new string[4] { "Character", "Character", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(70, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_70"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_70"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_70"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(71, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_71"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_71"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_71"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(72, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_72"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_72"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_72"), allowByEventFunction: false, new string[4] { "Character", "Character", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(73, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_73"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_73"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_73"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(74, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_74"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_74"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_74"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(75, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_75"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_75"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_75"), allowByEventFunction: false, new string[4] { "Character", "Character", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(76, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_76"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_76"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_76"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(77, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_77"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_77"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_77"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(78, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_78"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_78"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_78"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(79, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_79"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_79"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_79"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(80, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_80"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_80"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_80"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(81, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_81"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_81"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_81"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(82, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_82"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_82"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_82"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(83, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_83"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_83"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_83"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(84, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_84"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_84"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_84"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(85, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_85"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_85"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_85"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(86, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_86"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_86"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_86"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(87, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_87"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_87"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_87"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(88, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_88"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_88"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_88"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(89, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_89"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_89"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_89"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(90, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_90"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_90"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_90"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(91, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_91"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_91"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_91"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(92, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_92"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_92"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_92"), allowByEventFunction: false, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(93, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_93"), 2, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_93"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_93"), allowByEventFunction: false, new string[4] { "Settlement", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(94, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_94"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_94"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_94"), allowByEventFunction: false, new string[4] { "Profession", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(95, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_95"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_95"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_95"), allowByEventFunction: false, new string[4] { "Profession", "ProfessionSkill", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(96, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_96"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_96"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_96"), allowByEventFunction: false, new string[4] { "ProfessionSkill", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(97, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_97"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_97"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_97"), allowByEventFunction: false, new string[4] { "ProfessionSkill", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(98, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_98"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_98"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_98"), allowByEventFunction: false, new string[4] { "OrgGrade", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(99, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_99"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_99"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_99"), allowByEventFunction: false, new string[4] { "Location", "CombatSkillType", "Character", "Integer" }, null));
		_dataArray.Add(new InstantNotificationItem(100, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_100"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_100"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_100"), allowByEventFunction: false, new string[4] { "Location", "LifeSkillType", "Character", "Integer" }, null));
		_dataArray.Add(new InstantNotificationItem(101, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_101"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_101"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_101"), allowByEventFunction: false, new string[4] { "Character", "Character", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(102, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_102"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_102"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_102"), allowByEventFunction: false, new string[4] { "Character", "Character", "OrgGrade", "" }, null));
		_dataArray.Add(new InstantNotificationItem(103, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_103"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_103"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_103"), allowByEventFunction: false, new string[4] { "Character", "Location", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(104, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_104"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_104"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_104"), allowByEventFunction: false, new string[4] { "Character", "Profession", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(105, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_105"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_105"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_105"), allowByEventFunction: false, new string[4] { "Character", "Profession", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(106, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_106"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_106"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_106"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(107, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_107"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_107"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_107"), allowByEventFunction: false, new string[4] { "Settlement", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(108, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_108"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_108"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_108"), allowByEventFunction: false, new string[4] { "Settlement", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(109, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_109"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_109"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_109"), allowByEventFunction: false, new string[4] { "Item", "Integer", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(110, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_110"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_110"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_110"), allowByEventFunction: false, new string[4] { "Item", "Integer", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(111, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_111"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_111"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_111"), allowByEventFunction: false, new string[4] { "Item", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(112, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_112"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_112"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_112"), allowByEventFunction: false, new string[4] { "Item", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(113, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_113"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_113"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_113"), allowByEventFunction: false, new string[4] { "Item", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(114, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_114"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_114"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_114"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(115, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_115"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_115"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_115"), allowByEventFunction: false, new string[4] { "Location", "Adventure", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(116, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_116"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_116"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_116"), allowByEventFunction: false, new string[4] { "Settlement", "Music", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(117, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_117"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_117"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_117"), allowByEventFunction: false, new string[4] { "MapState", "Music", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(118, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_118"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_118"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_118"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(119, EInstantNotificationType.TaiwuVillage, LocalStringManager.GetConfig("InstantNotification_language", "Name_119"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_119"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_119"), allowByEventFunction: false, new string[4] { "Settlement", "Character", "Building", "" }, null));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new InstantNotificationItem(120, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_120"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_120"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_120"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(121, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_121"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_121"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_121"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(122, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_122"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_122"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_122"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(123, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_123"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_123"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_123"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(124, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_124"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_124"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_124"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(125, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_125"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_125"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_125"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(126, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_126"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_126"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_126"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(127, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_127"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_127"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_127"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(128, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_128"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_128"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_128"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(129, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_129"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_129"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_129"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(130, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_130"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_130"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_130"), allowByEventFunction: false, new string[4] { "JiaoLoong", "JiaoProperty", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(131, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_131"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_131"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_131"), allowByEventFunction: false, new string[4] { "JiaoLoong", "JiaoProperty", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(132, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_132"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_132"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_132"), allowByEventFunction: false, new string[4] { "JiaoLoong", "JiaoProperty", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(133, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_133"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_133"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_133"), allowByEventFunction: false, new string[4] { "JiaoLoong", "JiaoProperty", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(134, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_134"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_134"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_134"), allowByEventFunction: false, new string[4] { "JiaoLoong", "JiaoProperty", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(135, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_135"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_135"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_135"), allowByEventFunction: false, new string[4] { "JiaoLoong", "JiaoProperty", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(136, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_136"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_136"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_136"), allowByEventFunction: false, new string[4] { "JiaoLoong", "JiaoProperty", "Float", "" }, null));
		_dataArray.Add(new InstantNotificationItem(137, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_137"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_137"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_137"), allowByEventFunction: false, new string[4] { "JiaoLoong", "JiaoProperty", "Float", "" }, null));
		_dataArray.Add(new InstantNotificationItem(138, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_138"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_138"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_138"), allowByEventFunction: false, new string[4] { "Item", "Character", "Location", "" }, null));
		_dataArray.Add(new InstantNotificationItem(139, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_139"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_139"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_139"), allowByEventFunction: false, new string[4] { "Item", "Location", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(140, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_140"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_140"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_140"), allowByEventFunction: false, new string[4] { "Character", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(141, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_141"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_141"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_141"), allowByEventFunction: false, new string[4] { "Character", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(142, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_142"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_142"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_142"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(143, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_143"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_143"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_143"), allowByEventFunction: false, new string[4] { "Location", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(144, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_144"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_144"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_144"), allowByEventFunction: false, new string[4] { "Item", "CharacterTemplate", "Location", "" }, null));
		_dataArray.Add(new InstantNotificationItem(145, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_145"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_145"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_145"), allowByEventFunction: false, new string[4] { "Item", "Location", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(146, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_146"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_146"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_146"), allowByEventFunction: false, new string[4] { "CombatSkill", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(147, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_147"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_147"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_147"), allowByEventFunction: false, new string[4] { "CombatSkill", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(148, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_148"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_148"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_148"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(149, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_149"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_149"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_149"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(150, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_150"), 1, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_150"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_150"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(151, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_151"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_151"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_151"), allowByEventFunction: false, new string[4] { "Profession", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(152, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_152"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_152"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_152"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(153, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_153"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_153"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_153"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(154, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_154"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_154"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_154"), allowByEventFunction: false, new string[4] { "Item", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(155, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_155"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_155"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_155"), allowByEventFunction: false, new string[4] { "Item", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(156, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_156"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_156"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_156"), allowByEventFunction: false, new string[4] { "Integer", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(157, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_157"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_157"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_157"), allowByEventFunction: false, new string[4] { "SecretInformation", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(158, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_158"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_158"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_158"), allowByEventFunction: false, new string[4] { "Location", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(159, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_159"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_159"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_159"), allowByEventFunction: false, new string[4] { "Character", "Integer", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(160, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_160"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_160"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_160"), allowByEventFunction: false, new string[4] { "Character", "Integer", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(161, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_161"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_161"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_161"), allowByEventFunction: false, new string[4] { "Character", "CharacterPropertyReferencedType", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(162, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_162"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_162"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_162"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(163, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_163"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_163"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_163"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(164, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_164"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_164"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_164"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(165, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_165"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_165"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_165"), allowByEventFunction: false, new string[4] { "Settlement", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(166, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_166"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_166"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_166"), allowByEventFunction: false, new string[4] { "Location", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(167, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_167"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_167"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_167"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(168, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_168"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_168"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_168"), allowByEventFunction: false, new string[4] { "Location", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(169, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_169"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_169"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_169"), allowByEventFunction: false, new string[4] { "Character", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(170, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_170"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_170"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_170"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(171, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_171"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_171"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_171"), allowByEventFunction: false, new string[4] { "Character", "Settlement", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(172, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_172"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_172"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_172"), allowByEventFunction: false, new string[4] { "Character", "Settlement", "", "" }, new List<sbyte> { 1 }));
		_dataArray.Add(new InstantNotificationItem(173, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_173"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_173"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_173"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(174, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_174"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_174"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_174"), allowByEventFunction: false, new string[4] { "Legacy", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(175, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_175"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_175"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_175"), allowByEventFunction: false, new string[4] { "Settlement", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(176, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_176"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_176"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_176"), allowByEventFunction: false, new string[4] { "Settlement", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(177, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_177"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_177"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_177"), allowByEventFunction: false, new string[4] { "Settlement", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(178, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_178"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_178"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_178"), allowByEventFunction: false, new string[4] { "Settlement", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(179, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_179"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_179"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_179"), allowByEventFunction: false, new string[4] { "Location", "Resource", "Integer", "" }, null));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new InstantNotificationItem(180, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_180"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_180"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_180"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(181, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_181"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_181"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_181"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(182, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_182"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_182"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_182"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(183, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_183"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_183"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_183"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(184, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_184"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_184"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_184"), allowByEventFunction: false, new string[4] { "Item", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(185, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_185"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_185"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_185"), allowByEventFunction: false, new string[4] { "Item", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(186, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_186"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_186"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_186"), allowByEventFunction: false, new string[4] { "Item", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(187, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_187"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_187"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_187"), allowByEventFunction: false, new string[4] { "Item", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(188, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_188"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_188"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_188"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(189, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_189"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_189"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_189"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(190, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_190"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_190"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_190"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(191, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_191"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_191"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_191"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(192, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_192"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_192"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_192"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(193, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_193"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_193"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_193"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(194, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_194"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_194"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_194"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(195, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_195"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_195"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_195"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(196, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_196"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_196"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_196"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(197, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_197"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_197"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_197"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(198, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_198"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_198"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_198"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(199, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_199"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_199"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_199"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(200, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_200"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_200"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_200"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(201, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_201"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_201"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_201"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(202, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_202"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_202"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_202"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(203, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_203"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_203"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_203"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(204, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_204"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_204"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_204"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(205, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_205"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_205"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_205"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(206, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_206"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_206"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_206"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(207, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_207"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_207"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_207"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(208, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_208"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_208"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_208"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(209, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_209"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_209"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_209"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(210, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_210"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_210"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_210"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(211, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_211"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_211"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_211"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(212, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_212"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_212"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_212"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(213, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_213"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_213"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_213"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(214, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_214"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_214"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_214"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(215, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_215"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_215"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_215"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(216, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_216"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_216"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_216"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(217, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_217"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_217"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_217"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(218, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_218"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_218"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_218"), allowByEventFunction: false, new string[4] { "Location", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(219, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_219"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_219"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_219"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(220, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_220"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_220"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_220"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(221, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_221"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_221"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_221"), allowByEventFunction: false, new string[4] { "MapState", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(222, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_222"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_222"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_222"), allowByEventFunction: false, new string[4] { "Character", "CharacterPropertyReferencedType", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(223, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_223"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_223"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_223"), allowByEventFunction: false, new string[4] { "Location", "CharacterTemplate", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(224, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_224"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_224"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_224"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(225, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_225"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_225"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_225"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(226, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_226"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_226"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_226"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(227, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_227"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_227"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_227"), allowByEventFunction: false, new string[4] { "Character", "OrgGrade", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(228, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_228"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_228"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_228"), allowByEventFunction: false, new string[4] { "Character", "OrgGrade", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(229, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_229"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_229"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_229"), allowByEventFunction: false, new string[4] { "Character", "OrgGrade", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(230, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_230"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_230"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_230"), allowByEventFunction: false, new string[4] { "Character", "CharGrade", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(231, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_231"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_231"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_231"), allowByEventFunction: false, new string[4] { "Character", "CharGrade", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(232, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_232"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_232"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_232"), allowByEventFunction: false, new string[4] { "Character", "CharGrade", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(233, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_233"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_233"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_233"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(234, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_234"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_234"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_234"), allowByEventFunction: false, new string[4] { "Location", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(235, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_235"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_235"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_235"), allowByEventFunction: false, new string[4] { "Location", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(236, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_236"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_236"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_236"), allowByEventFunction: false, new string[4] { "CharacterTemplate", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(237, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_237"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_237"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_237"), allowByEventFunction: false, new string[4] { "CharacterTemplate", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(238, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_238"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_238"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_238"), allowByEventFunction: false, new string[4] { "CharacterTemplate", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(239, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_239"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_239"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_239"), allowByEventFunction: false, new string[4] { "CharacterTemplate", "", "", "" }, null));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new InstantNotificationItem(240, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_240"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_240"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_240"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(241, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_241"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_241"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_241"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(242, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_242"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_242"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_242"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(243, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_243"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_243"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_243"), allowByEventFunction: false, new string[4] { "Location", "Item", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(244, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_244"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_244"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_244"), allowByEventFunction: false, new string[4] { "Resource", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(245, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_245"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_245"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_245"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(246, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_246"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_246"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_246"), allowByEventFunction: false, new string[4] { "MapState", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(247, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_247"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_247"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_247"), allowByEventFunction: false, new string[4] { "Item", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(248, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_248"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_248"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_248"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(249, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_249"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_249"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_249"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(250, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_250"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_250"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_250"), allowByEventFunction: false, new string[4] { "", "", "", "" }, new List<sbyte>()));
		_dataArray.Add(new InstantNotificationItem(251, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_251"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_251"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_251"), allowByEventFunction: false, new string[4] { "Character", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(252, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_252"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_252"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_252"), allowByEventFunction: false, new string[4] { "Integer", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(253, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_253"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_253"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_253"), allowByEventFunction: false, new string[4] { "Integer", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(254, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_254"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_254"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_254"), allowByEventFunction: false, new string[4] { "Item", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(255, EInstantNotificationType.Item, LocalStringManager.GetConfig("InstantNotification_language", "Name_255"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_255"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_255"), allowByEventFunction: false, new string[4] { "Location", "Integer", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(256, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_256"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_256"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_256"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(257, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_257"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_257"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_257"), allowByEventFunction: true, new string[4] { "Character", "Character", "Character", "" }, null));
		_dataArray.Add(new InstantNotificationItem(258, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_258"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_258"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_258"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(259, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_259"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_259"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_259"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(260, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_260"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_260"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_260"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(261, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_261"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_261"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_261"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(262, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_262"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_262"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_262"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(263, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_263"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_263"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_263"), allowByEventFunction: true, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(264, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_264"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_264"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_264"), allowByEventFunction: true, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(265, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_265"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_265"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_265"), allowByEventFunction: true, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(266, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_266"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_266"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_266"), allowByEventFunction: true, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(267, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_267"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_267"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_267"), allowByEventFunction: true, new string[4] { "Character", "Character", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(268, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_268"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_268"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_268"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(269, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_269"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_269"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_269"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(270, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_270"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_270"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_270"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(271, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_271"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_271"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_271"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(272, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_272"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_272"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_272"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(273, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_273"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_273"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_273"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(274, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_274"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_274"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_274"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(275, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_275"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_275"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_275"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(276, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_276"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_276"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_276"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(277, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_277"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_277"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_277"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(278, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_278"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_278"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_278"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(279, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_279"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_279"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_279"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(280, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_280"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_280"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_280"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(281, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_281"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_281"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_281"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(282, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_282"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_282"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_282"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(283, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_283"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_283"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_283"), allowByEventFunction: false, new string[4] { "Character", "Adventure", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(284, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_284"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_284"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_284"), allowByEventFunction: false, new string[4] { "AdventureElement", "Text", "Adventure", "" }, null));
		_dataArray.Add(new InstantNotificationItem(285, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_285"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_285"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_285"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(286, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_286"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_286"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_286"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(287, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_287"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_287"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_287"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(288, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_288"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_288"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_288"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(289, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_289"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_289"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_289"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(290, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_290"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_290"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_290"), allowByEventFunction: false, new string[4] { "Character", "Character", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(291, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_291"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_291"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_291"), allowByEventFunction: false, new string[4] { "Character", "Character", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(292, EInstantNotificationType.Society, LocalStringManager.GetConfig("InstantNotification_language", "Name_292"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_292"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_292"), allowByEventFunction: false, new string[4] { "Settlement", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(293, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_293"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_293"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_293"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(294, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_294"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_294"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_294"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(295, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_295"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_295"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_295"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(296, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_296"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_296"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_296"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(297, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_297"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_297"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_297"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(298, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_298"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_298"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_298"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(299, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_299"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_299"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_299"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, null));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new InstantNotificationItem(300, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_300"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_300"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_300"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(301, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_301"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_301"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_301"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(302, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_302"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_302"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_302"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(303, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_303"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_303"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_303"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(304, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_304"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_304"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_304"), allowByEventFunction: false, new string[4] { "Cricket", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(305, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_305"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_305"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_305"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(306, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_306"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_306"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_306"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(307, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_307"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_307"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_307"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(308, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_308"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_308"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_308"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(309, EInstantNotificationType.Property, LocalStringManager.GetConfig("InstantNotification_language", "Name_309"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_309"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_309"), allowByEventFunction: true, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(310, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_310"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_310"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_310"), allowByEventFunction: false, new string[4] { "Item", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(311, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_311"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_311"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_311"), allowByEventFunction: false, new string[4] { "Item", "Item", "", "" }, new List<sbyte> { 0, 1 }));
		_dataArray.Add(new InstantNotificationItem(312, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_312"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_312"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_312"), allowByEventFunction: false, new string[4] { "Character", "Character", "Integer", "" }, null));
		_dataArray.Add(new InstantNotificationItem(313, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_313"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_313"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_313"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(314, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_314"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_314"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_314"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(315, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_315"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_315"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_315"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(316, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_316"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_316"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_316"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(317, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_317"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_317"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_317"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(318, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_318"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_318"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_318"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(319, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_319"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_319"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_319"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(320, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_320"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_320"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_320"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(321, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_321"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_321"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_321"), allowByEventFunction: false, new string[4] { "Character", "Character", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(322, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_322"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_322"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_322"), allowByEventFunction: false, new string[4] { "Character", "Character", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(323, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_323"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_323"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_323"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(324, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_324"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_324"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_324"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(325, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_325"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_325"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_325"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(326, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_326"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_326"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_326"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(327, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_327"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_327"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_327"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(328, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_328"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_328"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_328"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(329, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_329"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_329"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_329"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(330, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_330"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_330"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_330"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(331, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_331"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_331"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_331"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(332, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_332"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_332"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_332"), allowByEventFunction: false, new string[4] { "", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(333, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_333"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_333"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_333"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(334, EInstantNotificationType.DuringMonth, LocalStringManager.GetConfig("InstantNotification_language", "Name_334"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_334"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_334"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, null));
		_dataArray.Add(new InstantNotificationItem(335, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_335"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_335"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_335"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
		_dataArray.Add(new InstantNotificationItem(336, EInstantNotificationType.Team, LocalStringManager.GetConfig("InstantNotification_language", "Name_336"), 0, LocalStringManager.GetConfig("InstantNotification_language", "SimpleDesc_336"), LocalStringManager.GetConfig("InstantNotification_language", "Desc_336"), allowByEventFunction: false, new string[4] { "Character", "", "", "" }, new List<sbyte> { 0 }));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<InstantNotificationItem>(337);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
	}
}

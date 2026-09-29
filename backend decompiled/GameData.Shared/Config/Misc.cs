using System;
using System.Collections.Generic;
using Config.Common;
using GameData.Domains.Extra;
using GameData.Utilities;

namespace Config;

[Serializable]
public class Misc : ConfigData<MiscItem, short>
{
	public static class DefKey
	{
		public const short ResourceFood = 0;

		public const short ResourceWood = 1;

		public const short ResourceMetal = 2;

		public const short ResourceJade = 3;

		public const short ResourceFabric = 4;

		public const short ResourceHerb = 5;

		public const short ResourceMoney = 6;

		public const short ResourceAuthority = 7;

		public const short ResourceExp = 8;

		public const short BloodDew0 = 9;

		public const short BloodDew1 = 10;

		public const short BloodDew2 = 11;

		public const short BloodDew3 = 12;

		public const short BloodDew4 = 13;

		public const short BloodDew5 = 14;

		public const short BloodDew6 = 15;

		public const short BloodDew7 = 16;

		public const short BloodDew8 = 17;

		public const short SweepNet = 18;

		public const short Teleogryllus = 19;

		public const short LongHornedGrasshopper = 20;

		public const short Grasshopper = 21;

		public const short DrumwingedKatydid = 22;

		public const short GoldenPipa = 23;

		public const short BambooSandfly = 24;

		public const short SmallYellowSandfly = 25;

		public const short PearGreenSandfly = 26;

		public const short FlowerSandfly = 27;

		public const short BlackSandfly = 28;

		public const short BrayingSandfly = 29;

		public const short BigYellowSandfly = 30;

		public const short GrassYellowSandfly = 31;

		public const short KitchenSandfly = 32;

		public const short MirrorSandfly = 33;

		public const short TripleTail = 34;

		public const short GoldenSandfly = 35;

		public const short Katydid = 36;

		public const short WesternPresentMonv0 = 37;

		public const short WesternPresentMonv1 = 38;

		public const short WesternPresentMonv2 = 39;

		public const short WesternPresentMonv3 = 40;

		public const short WesternPresentMonv4 = 41;

		public const short WesternPresentDayueYaochang0 = 42;

		public const short WesternPresentDayueYaochang1 = 43;

		public const short WesternPresentDayueYaochang2 = 44;

		public const short WesternPresentDayueYaochang3 = 45;

		public const short WesternPresentDayueYaochang4 = 46;

		public const short WesternPresentJiuhan0 = 47;

		public const short WesternPresentJiuhan1 = 48;

		public const short WesternPresentJiuhan2 = 49;

		public const short WesternPresentJiuhan3 = 50;

		public const short WesternPresentJiuhan4 = 51;

		public const short WesternPresentJinHuanger0 = 52;

		public const short WesternPresentJinHuanger1 = 53;

		public const short WesternPresentJinHuanger2 = 54;

		public const short WesternPresentJinHuanger3 = 55;

		public const short WesternPresentJinHuanger4 = 56;

		public const short WesternPresentYiYihou0 = 57;

		public const short WesternPresentYiYihou1 = 58;

		public const short WesternPresentYiYihou2 = 59;

		public const short WesternPresentYiYihou3 = 60;

		public const short WesternPresentYiYihou4 = 61;

		public const short WesternPresentWeiQi0 = 62;

		public const short WesternPresentWeiQi1 = 63;

		public const short WesternPresentWeiQi2 = 64;

		public const short WesternPresentWeiQi3 = 65;

		public const short WesternPresentWeiQi4 = 66;

		public const short WesternPresentYixiang0 = 67;

		public const short WesternPresentYixiang1 = 68;

		public const short WesternPresentYixiang2 = 69;

		public const short WesternPresentYixiang3 = 70;

		public const short WesternPresentYixiang4 = 71;

		public const short WesternPresentXuefeng0 = 72;

		public const short WesternPresentXuefeng1 = 73;

		public const short WesternPresentXuefeng2 = 74;

		public const short WesternPresentXuefeng3 = 75;

		public const short WesternPresentXuefeng4 = 76;

		public const short WesternPresentShuFang0 = 77;

		public const short WesternPresentShuFang1 = 78;

		public const short WesternPresentShuFang2 = 79;

		public const short WesternPresentShuFang3 = 80;

		public const short WesternPresentShuFang4 = 81;

		public const short Rope0 = 82;

		public const short Rope1 = 83;

		public const short Rope2 = 84;

		public const short Rope3 = 85;

		public const short Rope4 = 86;

		public const short Rope5 = 87;

		public const short Rope6 = 88;

		public const short Rope7 = 89;

		public const short Rope8 = 90;

		public const short Jar0 = 91;

		public const short Jar1 = 92;

		public const short Jar2 = 93;

		public const short Jar3 = 94;

		public const short Jar4 = 95;

		public const short Jar5 = 96;

		public const short Jar6 = 97;

		public const short Jar7 = 98;

		public const short Jar8 = 99;

		public const short NormalResourceKeyConstruct1 = 100;

		public const short NormalResourceKeyConstruct2 = 101;

		public const short NormalResourceKeyConstruct3 = 102;

		public const short NormalResourceKeyConstruct4 = 103;

		public const short NormalResourceKeyConstruct5 = 104;

		public const short NormalResourceKeyConstruct6 = 105;

		public const short NormalResourceKeyConstruct7 = 106;

		public const short NormalResourceKeyConstruct8 = 107;

		public const short NormalResourceKeyConstruct9 = 108;

		public const short NormalResourceKeyConstruct10 = 109;

		public const short RareResourceKeyConstruct1 = 110;

		public const short RareResourceKeyConstruct2 = 111;

		public const short RareResourceKeyConstruct3 = 112;

		public const short RareResourceKeyConstruct4 = 113;

		public const short RareResourceKeyConstruct5 = 114;

		public const short RareResourceKeyConstruct6 = 115;

		public const short RareResourceKeyConstruct7 = 116;

		public const short RareResourceKeyConstruct8 = 117;

		public const short RareResourceKeyConstruct9 = 118;

		public const short RareResourceKeyConstruct10 = 119;

		public const short MaterialKeyConstruct0 = 120;

		public const short MaterialKeyConstruct1 = 121;

		public const short MaterialKeyConstruct2 = 122;

		public const short MaterialKeyConstruct3 = 123;

		public const short MaterialKeyConstruct4 = 124;

		public const short MaterialKeyConstruct5 = 125;

		public const short MaterialKeyConstruct6 = 126;

		public const short MaterialKeyConstruct7 = 127;

		public const short MaterialKeyConstruct8 = 128;

		public const short MaterialKeyConstruct9 = 129;

		public const short CombatSkillKeyConstruct0 = 130;

		public const short CombatSkillKeyConstruct1 = 131;

		public const short CombatSkillKeyConstruct2 = 132;

		public const short CombatSkillKeyConstruct3 = 133;

		public const short CombatSkillKeyConstruct4 = 134;

		public const short CombatSkillKeyConstruct5 = 135;

		public const short CombatSkillKeyConstruct6 = 136;

		public const short CombatSkillKeyConstruct7 = 137;

		public const short CombatSkillKeyConstruct8 = 138;

		public const short CombatSkillKeyConstruct9 = 139;

		public const short CombatSkillKeyConstruct10 = 140;

		public const short CombatSkillKeyConstruct11 = 141;

		public const short CombatSkillKeyConstruct12 = 142;

		public const short CombatSkillKeyConstruct13 = 143;

		public const short CombatSkillKeyConstruct14 = 144;

		public const short CombatSkillKeyConstruct15 = 145;

		public const short MusicKeyConstruct0 = 146;

		public const short MusicKeyConstruct1 = 147;

		public const short MusicKeyConstruct2 = 148;

		public const short MusicKeyConstruct3 = 149;

		public const short ChessKeyConstruct0 = 150;

		public const short ChessKeyConstruct1 = 151;

		public const short ChessKeyConstruct2 = 152;

		public const short ChessKeyConstruct3 = 153;

		public const short PoemKeyConstruct0 = 154;

		public const short PoemKeyConstruct1 = 155;

		public const short PoemKeyConstruct2 = 156;

		public const short PoemKeyConstruct3 = 157;

		public const short PaintingKeyConstruct0 = 158;

		public const short PaintingKeyConstruct1 = 159;

		public const short PaintingKeyConstruct2 = 160;

		public const short PaintingKeyConstruct3 = 161;

		public const short MathKeyConstruct0 = 162;

		public const short MathKeyConstruct1 = 163;

		public const short MathKeyConstruct2 = 164;

		public const short MathKeyConstruct3 = 165;

		public const short AppraisalKeyConstruct0 = 166;

		public const short AppraisalKeyConstruct1 = 167;

		public const short AppraisalKeyConstruct2 = 168;

		public const short AppraisalKeyConstruct3 = 169;

		public const short AppraisalKeyConstruct4 = 170;

		public const short ForgingKeyConstruct0 = 171;

		public const short ForgingKeyConstruct1 = 172;

		public const short ForgingKeyConstruct2 = 173;

		public const short ForgingKeyConstruct3 = 174;

		public const short ForgingKeyConstruct4 = 175;

		public const short ForgingKeyConstruct5 = 176;

		public const short WoodworkingKeyConstruct0 = 177;

		public const short WoodworkingKeyConstruct1 = 178;

		public const short WoodworkingKeyConstruct2 = 179;

		public const short WoodworkingKeyConstruct3 = 180;

		public const short WoodworkingKeyConstruct4 = 181;

		public const short WoodworkingKeyConstruct5 = 182;

		public const short MedicineKeyConstruct0 = 183;

		public const short MedicineKeyConstruct1 = 184;

		public const short MedicineKeyConstruct2 = 185;

		public const short MedicineKeyConstruct3 = 186;

		public const short MedicineKeyConstruct4 = 187;

		public const short MedicineKeyConstruct5 = 188;

		public const short ToxicologyKeyConstruct0 = 189;

		public const short ToxicologyKeyConstruct1 = 190;

		public const short ToxicologyKeyConstruct2 = 191;

		public const short ToxicologyKeyConstruct3 = 192;

		public const short ToxicologyKeyConstruct4 = 193;

		public const short ToxicologyKeyConstruct5 = 194;

		public const short WeavingKeyConstruct0 = 195;

		public const short WeavingKeyConstruct1 = 196;

		public const short WeavingKeyConstruct2 = 197;

		public const short WeavingKeyConstruct3 = 198;

		public const short WeavingKeyConstruct4 = 199;

		public const short WeavingKeyConstruct5 = 200;

		public const short JadeKeyConstruct0 = 201;

		public const short JadeKeyConstruct1 = 202;

		public const short JadeKeyConstruct2 = 203;

		public const short JadeKeyConstruct3 = 204;

		public const short JadeKeyConstruct4 = 205;

		public const short JadeKeyConstruct5 = 206;

		public const short TaoismKeyConstruct0 = 207;

		public const short TaoismKeyConstruct1 = 208;

		public const short TaoismKeyConstruct2 = 209;

		public const short TaoismKeyConstruct3 = 210;

		public const short BuddhismKeyConstruct0 = 211;

		public const short BuddhismKeyConstruct1 = 212;

		public const short BuddhismKeyConstruct2 = 213;

		public const short BuddhismKeyConstruct3 = 214;

		public const short CookingKeyConstruct0 = 215;

		public const short CookingKeyConstruct1 = 216;

		public const short CookingKeyConstruct2 = 217;

		public const short CookingKeyConstruct3 = 218;

		public const short CookingKeyConstruct4 = 219;

		public const short CookingKeyConstruct5 = 220;

		public const short EclecticKeyConstruct0 = 221;

		public const short EclecticKeyConstruct1 = 222;

		public const short EclecticKeyConstruct2 = 223;

		public const short EclecticKeyConstruct3 = 224;

		public const short TaiwuGenealogy = 225;

		public const short WesternRegionsMap = 226;

		public const short WheelOfKarma = 227;

		public const short SevenColorIronPlate = 228;

		public const short SwordFragmentsStart = 229;

		public const short SwordFragments1 = 230;

		public const short SwordFragments2 = 231;

		public const short SwordFragments3 = 232;

		public const short SwordFragments4 = 233;

		public const short SwordFragments5 = 234;

		public const short SwordFragments6 = 235;

		public const short SwordFragments7 = 236;

		public const short SwordFragments8 = 237;

		public const short SwordFragmentsEnd = 238;

		public const short FuyuSwordGrip = 239;

		public const short LegacyBookNeigong = 240;

		public const short LegacyBookPosing = 241;

		public const short LegacyBookStunt = 242;

		public const short LegacyBookFistAndPalm = 243;

		public const short LegacyBookFinger = 244;

		public const short LegacyBookLeg = 245;

		public const short LegacyBookThrow = 246;

		public const short LegacyBookSword = 247;

		public const short LegacyBookBlade = 248;

		public const short LegacyBookPolearm = 249;

		public const short LegacyBookSpecial = 250;

		public const short LegacyBookWhip = 251;

		public const short LegacyBookControllableShot = 252;

		public const short LegacyBookCombatMusic = 253;

		public const short ShenJianSpiritWords = 254;

		public const short HuanSheSpiritWords = 255;

		public const short FuCangSpiritWords = 256;

		public const short YinShenSpiritWords = 257;

		public const short QuLiuWuSpiritWords = 258;

		public const short ShenJianMysteryWords = 259;

		public const short HuanSheMysteryWords = 260;

		public const short FuCangMysteryWords = 261;

		public const short YinShenMysteryWords = 262;

		public const short QuLiuWuMysteryWords = 263;

		public const short TestingNeedle = 264;

		public const short TianJieFuLu = 265;

		public const short HomingPigeon = 266;

		public const short WuYing = 267;

		public const short LuggageOfHuanxin = 268;

		public const short HuanxinBloodyWutong = 269;

		public const short TwelveBambooThorn = 270;

		public const short RemainsOfXiangong = 271;

		public const short NiceLittleBoat = 272;

		public const short FuyuSwordFurnace = 273;

		public const short SevenCutBlackBamboo = 274;

		public const short DLCGoldenWeb = 275;

		public const short DLCLoongScale = 276;

		public const short BrokenBowl = 277;

		public const short GrainSac = 278;

		public const short CrippledShoes = 279;

		public const short BoardSword = 280;

		public const short BrushInk = 281;

		public const short TridentBell = 282;

		public const short BuddhismRosary = 283;

		public const short GoldenCup = 284;

		public const short JadePendent = 285;

		public const short BasketOnBack = 286;

		public const short HuntingBow = 287;

		public const short Hammer = 288;

		public const short IronBowl = 289;

		public const short NineNeedles = 290;

		public const short DivinationSticks = 291;

		public const short Abacus = 292;

		public const short TeaPot = 293;

		public const short RoyalSash = 294;

		public const short ThanksLetter0 = 295;

		public const short ThanksLetter1 = 296;

		public const short ThanksLetter2 = 297;

		public const short ThanksLetter3 = 298;

		public const short ThanksLetter4 = 299;

		public const short ThanksLetter5 = 300;

		public const short ThanksLetter6 = 301;

		public const short ThanksLetter7 = 302;

		public const short ThanksLetter8 = 303;

		public const short SectMainStoryItemWudangMountainSeedNormal = 304;

		public const short SectMainStoryItemWudangCaveSeedNormal = 305;

		public const short SectMainStoryItemWudangCanyonSeedNormal = 306;

		public const short SectMainStoryItemWudangSwampSeedNormal = 307;

		public const short SectMainStoryItemWudangHillSeedNormal = 308;

		public const short SectMainStoryItemWudangTaoyuanSeedNormal = 309;

		public const short SectMainStoryItemWudangFieldSeedNormal = 310;

		public const short SectMainStoryItemWudangLakeSeedNormal = 311;

		public const short SectMainStoryItemWudangWoodlandSeedNormal = 312;

		public const short SectMainStoryItemWudangJungleSeedNormal = 313;

		public const short SectMainStoryItemWudangRiverBeachSeedNormal = 314;

		public const short SectMainStoryItemWudangValleySeedNormal = 315;

		public const short SectMainStoryItemWudangMountainSeed = 316;

		public const short SectMainStoryItemWudangCaveSeed = 317;

		public const short SectMainStoryItemWudangCanyonSeed = 318;

		public const short SectMainStoryItemWudangSwampSeed = 319;

		public const short SectMainStoryItemWudangHillSeed = 320;

		public const short SectMainStoryItemWudangTaoyuanSeed = 321;

		public const short SectMainStoryItemWudangFieldSeed = 322;

		public const short SectMainStoryItemWudangLakeSeed = 323;

		public const short SectMainStoryItemWudangWoodlandSeed = 324;

		public const short SectMainStoryItemWudangJungleSeed = 325;

		public const short SectMainStoryItemWudangRiverBeachSeed = 326;

		public const short SectMainStoryItemWudangValleySeed = 327;

		public const short BrokenMuddyStatue = 328;

		public const short MuddyStatue = 329;

		public const short MuddyStatue2 = 330;

		public const short MuddyStatue3 = 331;

		public const short EmeiWhiteGibbonToken = 332;

		public const short FuyuSwordFragment = 333;

		public const short SectMainStoryItemWudang0 = 334;

		public const short SectMainStoryItemWudang1 = 335;

		public const short SectMainStoryItemWudang2 = 336;

		public const short SectMainStoryItemWudang3 = 337;

		public const short SectMainStoryItemWudang4 = 338;

		public const short SectMainStoryItemWudang5 = 339;

		public const short SectMainStoryItemWudang6 = 340;

		public const short SectMainStoryItemWudang7 = 341;

		public const short SectMainStoryItemWudang8 = 342;

		public const short SectMainStoryItemWudang9 = 343;

		public const short SectMainStoryItemWudang10 = 344;

		public const short SectMainStoryItemYuanshanRosary = 345;

		public const short RanshanJadeAmulet = 346;

		public const short RanshanJadeSword = 347;

		public const short RanshanJadeRing = 348;

		public const short SectMainStoryItemXuannvNotes = 349;

		public const short SectMainStoryItemZhujianTongshengHead = 350;

		public const short SectMainStoryItemZhujianTongshengLeftArm = 351;

		public const short SectMainStoryItemZhujianTongshengRightArm = 352;

		public const short SectMainStoryItemZhujianTongshengLeftLeg = 353;

		public const short SectMainStoryItemZhujianTongshengRightLeg = 354;

		public const short SectMainStoryItemZhujianTongshengTorso = 355;

		public const short SectMainStoryItemZhujianWeaponPrototype = 356;

		public const short SectMainStoryItemZhujianWeaponPrototype1 = 357;

		public const short SectMainStoryItemZhujianWeaponPrototype2 = 358;

		public const short SectMainStoryItemJingangSutraFragments = 359;

		public const short SectMainStoryItemJingangSutraAuthentic = 360;

		public const short SectMainStoryItemJingangSutraFake = 361;

		public const short SectMainStoryItemJingangSutraEastern = 362;

		public const short SectMainStoryItemJingangEerieAmulet = 363;

		public const short SectMainStoryUpgradeItemJingangJewel = 392;

		public const short SectMainStoryItemWuxianWugFairy = 364;

		public const short JieqingAssassinationToken = 365;

		public const short SectMainStoryItemJieQingStars = 366;

		public const short SectMainStoryFulongChickenFeather = 368;

		public const short SectMainStoryFulongFeatherCoat = 369;

		public const short SectMainStoryFulongChickenMap = 370;

		public const short AntiqueBell = 371;

		public const short AntiqueJadeBat = 372;

		public const short AntiqueJadeFox = 373;

		public const short AntiqueJadeButterfly = 374;

		public const short AdventureXRSDAuraRemnantMetal = 381;

		public const short AdventureXRSDAuraRemnantWood = 382;

		public const short AdventureXRSDAuraRemnantWater = 383;

		public const short AdventureXRSDAuraRemnantFire = 384;

		public const short AdventureXRSDAuraRemnantEarth = 385;

		public const short MetalNeiliStone = 375;

		public const short WoodNeiliStone = 376;

		public const short WaterNeiliStone = 377;

		public const short FireNeiliStone = 378;

		public const short EarthNeiliStone = 379;

		public const short SealOfMerchant = 380;

		public const short CombatSkill = 386;

		public const short LifeSkill = 387;

		public const short Information = 388;

		public const short SecretInformation = 389;

		public const short AdventureYZGFXNPitem1 = 390;

		public const short AdventureYZGFXNPitem2 = 391;

		public const short AdventureQMLWHotTreasure = 393;

		public const short AdventureQMLWIceTreasure = 394;

		public const short AdventureQMLWEndlessTreasure = 395;

		public const short Prisoner = 475;

		public const short Poison0 = 476;

		public const short Poison1 = 477;

		public const short Poison2 = 478;

		public const short Poison3 = 479;

		public const short Poison4 = 480;

		public const short Poison5 = 481;

		public const short InnerInjury = 482;

		public const short OutterInjury = 483;

		public const short DamageHugeSword = 510;

		public const short MainStoryBoundaryJade = 511;

		public const short MainStorySeverMindPill = 512;

		public const short MainStoryFenchen = 534;

		public const short SectMainStoryItemJieQingPearls = 535;
	}

	public static class DefValue
	{
		public static MiscItem ResourceFood => Instance[(short)0];

		public static MiscItem ResourceWood => Instance[(short)1];

		public static MiscItem ResourceMetal => Instance[(short)2];

		public static MiscItem ResourceJade => Instance[(short)3];

		public static MiscItem ResourceFabric => Instance[(short)4];

		public static MiscItem ResourceHerb => Instance[(short)5];

		public static MiscItem ResourceMoney => Instance[(short)6];

		public static MiscItem ResourceAuthority => Instance[(short)7];

		public static MiscItem ResourceExp => Instance[(short)8];

		public static MiscItem BloodDew0 => Instance[(short)9];

		public static MiscItem BloodDew1 => Instance[(short)10];

		public static MiscItem BloodDew2 => Instance[(short)11];

		public static MiscItem BloodDew3 => Instance[(short)12];

		public static MiscItem BloodDew4 => Instance[(short)13];

		public static MiscItem BloodDew5 => Instance[(short)14];

		public static MiscItem BloodDew6 => Instance[(short)15];

		public static MiscItem BloodDew7 => Instance[(short)16];

		public static MiscItem BloodDew8 => Instance[(short)17];

		public static MiscItem SweepNet => Instance[(short)18];

		public static MiscItem Teleogryllus => Instance[(short)19];

		public static MiscItem LongHornedGrasshopper => Instance[(short)20];

		public static MiscItem Grasshopper => Instance[(short)21];

		public static MiscItem DrumwingedKatydid => Instance[(short)22];

		public static MiscItem GoldenPipa => Instance[(short)23];

		public static MiscItem BambooSandfly => Instance[(short)24];

		public static MiscItem SmallYellowSandfly => Instance[(short)25];

		public static MiscItem PearGreenSandfly => Instance[(short)26];

		public static MiscItem FlowerSandfly => Instance[(short)27];

		public static MiscItem BlackSandfly => Instance[(short)28];

		public static MiscItem BrayingSandfly => Instance[(short)29];

		public static MiscItem BigYellowSandfly => Instance[(short)30];

		public static MiscItem GrassYellowSandfly => Instance[(short)31];

		public static MiscItem KitchenSandfly => Instance[(short)32];

		public static MiscItem MirrorSandfly => Instance[(short)33];

		public static MiscItem TripleTail => Instance[(short)34];

		public static MiscItem GoldenSandfly => Instance[(short)35];

		public static MiscItem Katydid => Instance[(short)36];

		public static MiscItem WesternPresentMonv0 => Instance[(short)37];

		public static MiscItem WesternPresentMonv1 => Instance[(short)38];

		public static MiscItem WesternPresentMonv2 => Instance[(short)39];

		public static MiscItem WesternPresentMonv3 => Instance[(short)40];

		public static MiscItem WesternPresentMonv4 => Instance[(short)41];

		public static MiscItem WesternPresentDayueYaochang0 => Instance[(short)42];

		public static MiscItem WesternPresentDayueYaochang1 => Instance[(short)43];

		public static MiscItem WesternPresentDayueYaochang2 => Instance[(short)44];

		public static MiscItem WesternPresentDayueYaochang3 => Instance[(short)45];

		public static MiscItem WesternPresentDayueYaochang4 => Instance[(short)46];

		public static MiscItem WesternPresentJiuhan0 => Instance[(short)47];

		public static MiscItem WesternPresentJiuhan1 => Instance[(short)48];

		public static MiscItem WesternPresentJiuhan2 => Instance[(short)49];

		public static MiscItem WesternPresentJiuhan3 => Instance[(short)50];

		public static MiscItem WesternPresentJiuhan4 => Instance[(short)51];

		public static MiscItem WesternPresentJinHuanger0 => Instance[(short)52];

		public static MiscItem WesternPresentJinHuanger1 => Instance[(short)53];

		public static MiscItem WesternPresentJinHuanger2 => Instance[(short)54];

		public static MiscItem WesternPresentJinHuanger3 => Instance[(short)55];

		public static MiscItem WesternPresentJinHuanger4 => Instance[(short)56];

		public static MiscItem WesternPresentYiYihou0 => Instance[(short)57];

		public static MiscItem WesternPresentYiYihou1 => Instance[(short)58];

		public static MiscItem WesternPresentYiYihou2 => Instance[(short)59];

		public static MiscItem WesternPresentYiYihou3 => Instance[(short)60];

		public static MiscItem WesternPresentYiYihou4 => Instance[(short)61];

		public static MiscItem WesternPresentWeiQi0 => Instance[(short)62];

		public static MiscItem WesternPresentWeiQi1 => Instance[(short)63];

		public static MiscItem WesternPresentWeiQi2 => Instance[(short)64];

		public static MiscItem WesternPresentWeiQi3 => Instance[(short)65];

		public static MiscItem WesternPresentWeiQi4 => Instance[(short)66];

		public static MiscItem WesternPresentYixiang0 => Instance[(short)67];

		public static MiscItem WesternPresentYixiang1 => Instance[(short)68];

		public static MiscItem WesternPresentYixiang2 => Instance[(short)69];

		public static MiscItem WesternPresentYixiang3 => Instance[(short)70];

		public static MiscItem WesternPresentYixiang4 => Instance[(short)71];

		public static MiscItem WesternPresentXuefeng0 => Instance[(short)72];

		public static MiscItem WesternPresentXuefeng1 => Instance[(short)73];

		public static MiscItem WesternPresentXuefeng2 => Instance[(short)74];

		public static MiscItem WesternPresentXuefeng3 => Instance[(short)75];

		public static MiscItem WesternPresentXuefeng4 => Instance[(short)76];

		public static MiscItem WesternPresentShuFang0 => Instance[(short)77];

		public static MiscItem WesternPresentShuFang1 => Instance[(short)78];

		public static MiscItem WesternPresentShuFang2 => Instance[(short)79];

		public static MiscItem WesternPresentShuFang3 => Instance[(short)80];

		public static MiscItem WesternPresentShuFang4 => Instance[(short)81];

		public static MiscItem Rope0 => Instance[(short)82];

		public static MiscItem Rope1 => Instance[(short)83];

		public static MiscItem Rope2 => Instance[(short)84];

		public static MiscItem Rope3 => Instance[(short)85];

		public static MiscItem Rope4 => Instance[(short)86];

		public static MiscItem Rope5 => Instance[(short)87];

		public static MiscItem Rope6 => Instance[(short)88];

		public static MiscItem Rope7 => Instance[(short)89];

		public static MiscItem Rope8 => Instance[(short)90];

		public static MiscItem Jar0 => Instance[(short)91];

		public static MiscItem Jar1 => Instance[(short)92];

		public static MiscItem Jar2 => Instance[(short)93];

		public static MiscItem Jar3 => Instance[(short)94];

		public static MiscItem Jar4 => Instance[(short)95];

		public static MiscItem Jar5 => Instance[(short)96];

		public static MiscItem Jar6 => Instance[(short)97];

		public static MiscItem Jar7 => Instance[(short)98];

		public static MiscItem Jar8 => Instance[(short)99];

		public static MiscItem NormalResourceKeyConstruct1 => Instance[(short)100];

		public static MiscItem NormalResourceKeyConstruct2 => Instance[(short)101];

		public static MiscItem NormalResourceKeyConstruct3 => Instance[(short)102];

		public static MiscItem NormalResourceKeyConstruct4 => Instance[(short)103];

		public static MiscItem NormalResourceKeyConstruct5 => Instance[(short)104];

		public static MiscItem NormalResourceKeyConstruct6 => Instance[(short)105];

		public static MiscItem NormalResourceKeyConstruct7 => Instance[(short)106];

		public static MiscItem NormalResourceKeyConstruct8 => Instance[(short)107];

		public static MiscItem NormalResourceKeyConstruct9 => Instance[(short)108];

		public static MiscItem NormalResourceKeyConstruct10 => Instance[(short)109];

		public static MiscItem RareResourceKeyConstruct1 => Instance[(short)110];

		public static MiscItem RareResourceKeyConstruct2 => Instance[(short)111];

		public static MiscItem RareResourceKeyConstruct3 => Instance[(short)112];

		public static MiscItem RareResourceKeyConstruct4 => Instance[(short)113];

		public static MiscItem RareResourceKeyConstruct5 => Instance[(short)114];

		public static MiscItem RareResourceKeyConstruct6 => Instance[(short)115];

		public static MiscItem RareResourceKeyConstruct7 => Instance[(short)116];

		public static MiscItem RareResourceKeyConstruct8 => Instance[(short)117];

		public static MiscItem RareResourceKeyConstruct9 => Instance[(short)118];

		public static MiscItem RareResourceKeyConstruct10 => Instance[(short)119];

		public static MiscItem MaterialKeyConstruct0 => Instance[(short)120];

		public static MiscItem MaterialKeyConstruct1 => Instance[(short)121];

		public static MiscItem MaterialKeyConstruct2 => Instance[(short)122];

		public static MiscItem MaterialKeyConstruct3 => Instance[(short)123];

		public static MiscItem MaterialKeyConstruct4 => Instance[(short)124];

		public static MiscItem MaterialKeyConstruct5 => Instance[(short)125];

		public static MiscItem MaterialKeyConstruct6 => Instance[(short)126];

		public static MiscItem MaterialKeyConstruct7 => Instance[(short)127];

		public static MiscItem MaterialKeyConstruct8 => Instance[(short)128];

		public static MiscItem MaterialKeyConstruct9 => Instance[(short)129];

		public static MiscItem CombatSkillKeyConstruct0 => Instance[(short)130];

		public static MiscItem CombatSkillKeyConstruct1 => Instance[(short)131];

		public static MiscItem CombatSkillKeyConstruct2 => Instance[(short)132];

		public static MiscItem CombatSkillKeyConstruct3 => Instance[(short)133];

		public static MiscItem CombatSkillKeyConstruct4 => Instance[(short)134];

		public static MiscItem CombatSkillKeyConstruct5 => Instance[(short)135];

		public static MiscItem CombatSkillKeyConstruct6 => Instance[(short)136];

		public static MiscItem CombatSkillKeyConstruct7 => Instance[(short)137];

		public static MiscItem CombatSkillKeyConstruct8 => Instance[(short)138];

		public static MiscItem CombatSkillKeyConstruct9 => Instance[(short)139];

		public static MiscItem CombatSkillKeyConstruct10 => Instance[(short)140];

		public static MiscItem CombatSkillKeyConstruct11 => Instance[(short)141];

		public static MiscItem CombatSkillKeyConstruct12 => Instance[(short)142];

		public static MiscItem CombatSkillKeyConstruct13 => Instance[(short)143];

		public static MiscItem CombatSkillKeyConstruct14 => Instance[(short)144];

		public static MiscItem CombatSkillKeyConstruct15 => Instance[(short)145];

		public static MiscItem MusicKeyConstruct0 => Instance[(short)146];

		public static MiscItem MusicKeyConstruct1 => Instance[(short)147];

		public static MiscItem MusicKeyConstruct2 => Instance[(short)148];

		public static MiscItem MusicKeyConstruct3 => Instance[(short)149];

		public static MiscItem ChessKeyConstruct0 => Instance[(short)150];

		public static MiscItem ChessKeyConstruct1 => Instance[(short)151];

		public static MiscItem ChessKeyConstruct2 => Instance[(short)152];

		public static MiscItem ChessKeyConstruct3 => Instance[(short)153];

		public static MiscItem PoemKeyConstruct0 => Instance[(short)154];

		public static MiscItem PoemKeyConstruct1 => Instance[(short)155];

		public static MiscItem PoemKeyConstruct2 => Instance[(short)156];

		public static MiscItem PoemKeyConstruct3 => Instance[(short)157];

		public static MiscItem PaintingKeyConstruct0 => Instance[(short)158];

		public static MiscItem PaintingKeyConstruct1 => Instance[(short)159];

		public static MiscItem PaintingKeyConstruct2 => Instance[(short)160];

		public static MiscItem PaintingKeyConstruct3 => Instance[(short)161];

		public static MiscItem MathKeyConstruct0 => Instance[(short)162];

		public static MiscItem MathKeyConstruct1 => Instance[(short)163];

		public static MiscItem MathKeyConstruct2 => Instance[(short)164];

		public static MiscItem MathKeyConstruct3 => Instance[(short)165];

		public static MiscItem AppraisalKeyConstruct0 => Instance[(short)166];

		public static MiscItem AppraisalKeyConstruct1 => Instance[(short)167];

		public static MiscItem AppraisalKeyConstruct2 => Instance[(short)168];

		public static MiscItem AppraisalKeyConstruct3 => Instance[(short)169];

		public static MiscItem AppraisalKeyConstruct4 => Instance[(short)170];

		public static MiscItem ForgingKeyConstruct0 => Instance[(short)171];

		public static MiscItem ForgingKeyConstruct1 => Instance[(short)172];

		public static MiscItem ForgingKeyConstruct2 => Instance[(short)173];

		public static MiscItem ForgingKeyConstruct3 => Instance[(short)174];

		public static MiscItem ForgingKeyConstruct4 => Instance[(short)175];

		public static MiscItem ForgingKeyConstruct5 => Instance[(short)176];

		public static MiscItem WoodworkingKeyConstruct0 => Instance[(short)177];

		public static MiscItem WoodworkingKeyConstruct1 => Instance[(short)178];

		public static MiscItem WoodworkingKeyConstruct2 => Instance[(short)179];

		public static MiscItem WoodworkingKeyConstruct3 => Instance[(short)180];

		public static MiscItem WoodworkingKeyConstruct4 => Instance[(short)181];

		public static MiscItem WoodworkingKeyConstruct5 => Instance[(short)182];

		public static MiscItem MedicineKeyConstruct0 => Instance[(short)183];

		public static MiscItem MedicineKeyConstruct1 => Instance[(short)184];

		public static MiscItem MedicineKeyConstruct2 => Instance[(short)185];

		public static MiscItem MedicineKeyConstruct3 => Instance[(short)186];

		public static MiscItem MedicineKeyConstruct4 => Instance[(short)187];

		public static MiscItem MedicineKeyConstruct5 => Instance[(short)188];

		public static MiscItem ToxicologyKeyConstruct0 => Instance[(short)189];

		public static MiscItem ToxicologyKeyConstruct1 => Instance[(short)190];

		public static MiscItem ToxicologyKeyConstruct2 => Instance[(short)191];

		public static MiscItem ToxicologyKeyConstruct3 => Instance[(short)192];

		public static MiscItem ToxicologyKeyConstruct4 => Instance[(short)193];

		public static MiscItem ToxicologyKeyConstruct5 => Instance[(short)194];

		public static MiscItem WeavingKeyConstruct0 => Instance[(short)195];

		public static MiscItem WeavingKeyConstruct1 => Instance[(short)196];

		public static MiscItem WeavingKeyConstruct2 => Instance[(short)197];

		public static MiscItem WeavingKeyConstruct3 => Instance[(short)198];

		public static MiscItem WeavingKeyConstruct4 => Instance[(short)199];

		public static MiscItem WeavingKeyConstruct5 => Instance[(short)200];

		public static MiscItem JadeKeyConstruct0 => Instance[(short)201];

		public static MiscItem JadeKeyConstruct1 => Instance[(short)202];

		public static MiscItem JadeKeyConstruct2 => Instance[(short)203];

		public static MiscItem JadeKeyConstruct3 => Instance[(short)204];

		public static MiscItem JadeKeyConstruct4 => Instance[(short)205];

		public static MiscItem JadeKeyConstruct5 => Instance[(short)206];

		public static MiscItem TaoismKeyConstruct0 => Instance[(short)207];

		public static MiscItem TaoismKeyConstruct1 => Instance[(short)208];

		public static MiscItem TaoismKeyConstruct2 => Instance[(short)209];

		public static MiscItem TaoismKeyConstruct3 => Instance[(short)210];

		public static MiscItem BuddhismKeyConstruct0 => Instance[(short)211];

		public static MiscItem BuddhismKeyConstruct1 => Instance[(short)212];

		public static MiscItem BuddhismKeyConstruct2 => Instance[(short)213];

		public static MiscItem BuddhismKeyConstruct3 => Instance[(short)214];

		public static MiscItem CookingKeyConstruct0 => Instance[(short)215];

		public static MiscItem CookingKeyConstruct1 => Instance[(short)216];

		public static MiscItem CookingKeyConstruct2 => Instance[(short)217];

		public static MiscItem CookingKeyConstruct3 => Instance[(short)218];

		public static MiscItem CookingKeyConstruct4 => Instance[(short)219];

		public static MiscItem CookingKeyConstruct5 => Instance[(short)220];

		public static MiscItem EclecticKeyConstruct0 => Instance[(short)221];

		public static MiscItem EclecticKeyConstruct1 => Instance[(short)222];

		public static MiscItem EclecticKeyConstruct2 => Instance[(short)223];

		public static MiscItem EclecticKeyConstruct3 => Instance[(short)224];

		public static MiscItem TaiwuGenealogy => Instance[(short)225];

		public static MiscItem WesternRegionsMap => Instance[(short)226];

		public static MiscItem WheelOfKarma => Instance[(short)227];

		public static MiscItem SevenColorIronPlate => Instance[(short)228];

		public static MiscItem SwordFragmentsStart => Instance[(short)229];

		public static MiscItem SwordFragments1 => Instance[(short)230];

		public static MiscItem SwordFragments2 => Instance[(short)231];

		public static MiscItem SwordFragments3 => Instance[(short)232];

		public static MiscItem SwordFragments4 => Instance[(short)233];

		public static MiscItem SwordFragments5 => Instance[(short)234];

		public static MiscItem SwordFragments6 => Instance[(short)235];

		public static MiscItem SwordFragments7 => Instance[(short)236];

		public static MiscItem SwordFragments8 => Instance[(short)237];

		public static MiscItem SwordFragmentsEnd => Instance[(short)238];

		public static MiscItem FuyuSwordGrip => Instance[(short)239];

		public static MiscItem LegacyBookNeigong => Instance[(short)240];

		public static MiscItem LegacyBookPosing => Instance[(short)241];

		public static MiscItem LegacyBookStunt => Instance[(short)242];

		public static MiscItem LegacyBookFistAndPalm => Instance[(short)243];

		public static MiscItem LegacyBookFinger => Instance[(short)244];

		public static MiscItem LegacyBookLeg => Instance[(short)245];

		public static MiscItem LegacyBookThrow => Instance[(short)246];

		public static MiscItem LegacyBookSword => Instance[(short)247];

		public static MiscItem LegacyBookBlade => Instance[(short)248];

		public static MiscItem LegacyBookPolearm => Instance[(short)249];

		public static MiscItem LegacyBookSpecial => Instance[(short)250];

		public static MiscItem LegacyBookWhip => Instance[(short)251];

		public static MiscItem LegacyBookControllableShot => Instance[(short)252];

		public static MiscItem LegacyBookCombatMusic => Instance[(short)253];

		public static MiscItem ShenJianSpiritWords => Instance[(short)254];

		public static MiscItem HuanSheSpiritWords => Instance[(short)255];

		public static MiscItem FuCangSpiritWords => Instance[(short)256];

		public static MiscItem YinShenSpiritWords => Instance[(short)257];

		public static MiscItem QuLiuWuSpiritWords => Instance[(short)258];

		public static MiscItem ShenJianMysteryWords => Instance[(short)259];

		public static MiscItem HuanSheMysteryWords => Instance[(short)260];

		public static MiscItem FuCangMysteryWords => Instance[(short)261];

		public static MiscItem YinShenMysteryWords => Instance[(short)262];

		public static MiscItem QuLiuWuMysteryWords => Instance[(short)263];

		public static MiscItem TestingNeedle => Instance[(short)264];

		public static MiscItem TianJieFuLu => Instance[(short)265];

		public static MiscItem HomingPigeon => Instance[(short)266];

		public static MiscItem WuYing => Instance[(short)267];

		public static MiscItem LuggageOfHuanxin => Instance[(short)268];

		public static MiscItem HuanxinBloodyWutong => Instance[(short)269];

		public static MiscItem TwelveBambooThorn => Instance[(short)270];

		public static MiscItem RemainsOfXiangong => Instance[(short)271];

		public static MiscItem NiceLittleBoat => Instance[(short)272];

		public static MiscItem FuyuSwordFurnace => Instance[(short)273];

		public static MiscItem SevenCutBlackBamboo => Instance[(short)274];

		public static MiscItem DLCGoldenWeb => Instance[(short)275];

		public static MiscItem DLCLoongScale => Instance[(short)276];

		public static MiscItem BrokenBowl => Instance[(short)277];

		public static MiscItem GrainSac => Instance[(short)278];

		public static MiscItem CrippledShoes => Instance[(short)279];

		public static MiscItem BoardSword => Instance[(short)280];

		public static MiscItem BrushInk => Instance[(short)281];

		public static MiscItem TridentBell => Instance[(short)282];

		public static MiscItem BuddhismRosary => Instance[(short)283];

		public static MiscItem GoldenCup => Instance[(short)284];

		public static MiscItem JadePendent => Instance[(short)285];

		public static MiscItem BasketOnBack => Instance[(short)286];

		public static MiscItem HuntingBow => Instance[(short)287];

		public static MiscItem Hammer => Instance[(short)288];

		public static MiscItem IronBowl => Instance[(short)289];

		public static MiscItem NineNeedles => Instance[(short)290];

		public static MiscItem DivinationSticks => Instance[(short)291];

		public static MiscItem Abacus => Instance[(short)292];

		public static MiscItem TeaPot => Instance[(short)293];

		public static MiscItem RoyalSash => Instance[(short)294];

		public static MiscItem ThanksLetter0 => Instance[(short)295];

		public static MiscItem ThanksLetter1 => Instance[(short)296];

		public static MiscItem ThanksLetter2 => Instance[(short)297];

		public static MiscItem ThanksLetter3 => Instance[(short)298];

		public static MiscItem ThanksLetter4 => Instance[(short)299];

		public static MiscItem ThanksLetter5 => Instance[(short)300];

		public static MiscItem ThanksLetter6 => Instance[(short)301];

		public static MiscItem ThanksLetter7 => Instance[(short)302];

		public static MiscItem ThanksLetter8 => Instance[(short)303];

		public static MiscItem SectMainStoryItemWudangMountainSeedNormal => Instance[(short)304];

		public static MiscItem SectMainStoryItemWudangCaveSeedNormal => Instance[(short)305];

		public static MiscItem SectMainStoryItemWudangCanyonSeedNormal => Instance[(short)306];

		public static MiscItem SectMainStoryItemWudangSwampSeedNormal => Instance[(short)307];

		public static MiscItem SectMainStoryItemWudangHillSeedNormal => Instance[(short)308];

		public static MiscItem SectMainStoryItemWudangTaoyuanSeedNormal => Instance[(short)309];

		public static MiscItem SectMainStoryItemWudangFieldSeedNormal => Instance[(short)310];

		public static MiscItem SectMainStoryItemWudangLakeSeedNormal => Instance[(short)311];

		public static MiscItem SectMainStoryItemWudangWoodlandSeedNormal => Instance[(short)312];

		public static MiscItem SectMainStoryItemWudangJungleSeedNormal => Instance[(short)313];

		public static MiscItem SectMainStoryItemWudangRiverBeachSeedNormal => Instance[(short)314];

		public static MiscItem SectMainStoryItemWudangValleySeedNormal => Instance[(short)315];

		public static MiscItem SectMainStoryItemWudangMountainSeed => Instance[(short)316];

		public static MiscItem SectMainStoryItemWudangCaveSeed => Instance[(short)317];

		public static MiscItem SectMainStoryItemWudangCanyonSeed => Instance[(short)318];

		public static MiscItem SectMainStoryItemWudangSwampSeed => Instance[(short)319];

		public static MiscItem SectMainStoryItemWudangHillSeed => Instance[(short)320];

		public static MiscItem SectMainStoryItemWudangTaoyuanSeed => Instance[(short)321];

		public static MiscItem SectMainStoryItemWudangFieldSeed => Instance[(short)322];

		public static MiscItem SectMainStoryItemWudangLakeSeed => Instance[(short)323];

		public static MiscItem SectMainStoryItemWudangWoodlandSeed => Instance[(short)324];

		public static MiscItem SectMainStoryItemWudangJungleSeed => Instance[(short)325];

		public static MiscItem SectMainStoryItemWudangRiverBeachSeed => Instance[(short)326];

		public static MiscItem SectMainStoryItemWudangValleySeed => Instance[(short)327];

		public static MiscItem BrokenMuddyStatue => Instance[(short)328];

		public static MiscItem MuddyStatue => Instance[(short)329];

		public static MiscItem MuddyStatue2 => Instance[(short)330];

		public static MiscItem MuddyStatue3 => Instance[(short)331];

		public static MiscItem EmeiWhiteGibbonToken => Instance[(short)332];

		public static MiscItem FuyuSwordFragment => Instance[(short)333];

		public static MiscItem SectMainStoryItemWudang0 => Instance[(short)334];

		public static MiscItem SectMainStoryItemWudang1 => Instance[(short)335];

		public static MiscItem SectMainStoryItemWudang2 => Instance[(short)336];

		public static MiscItem SectMainStoryItemWudang3 => Instance[(short)337];

		public static MiscItem SectMainStoryItemWudang4 => Instance[(short)338];

		public static MiscItem SectMainStoryItemWudang5 => Instance[(short)339];

		public static MiscItem SectMainStoryItemWudang6 => Instance[(short)340];

		public static MiscItem SectMainStoryItemWudang7 => Instance[(short)341];

		public static MiscItem SectMainStoryItemWudang8 => Instance[(short)342];

		public static MiscItem SectMainStoryItemWudang9 => Instance[(short)343];

		public static MiscItem SectMainStoryItemWudang10 => Instance[(short)344];

		public static MiscItem SectMainStoryItemYuanshanRosary => Instance[(short)345];

		public static MiscItem RanshanJadeAmulet => Instance[(short)346];

		public static MiscItem RanshanJadeSword => Instance[(short)347];

		public static MiscItem RanshanJadeRing => Instance[(short)348];

		public static MiscItem SectMainStoryItemXuannvNotes => Instance[(short)349];

		public static MiscItem SectMainStoryItemZhujianTongshengHead => Instance[(short)350];

		public static MiscItem SectMainStoryItemZhujianTongshengLeftArm => Instance[(short)351];

		public static MiscItem SectMainStoryItemZhujianTongshengRightArm => Instance[(short)352];

		public static MiscItem SectMainStoryItemZhujianTongshengLeftLeg => Instance[(short)353];

		public static MiscItem SectMainStoryItemZhujianTongshengRightLeg => Instance[(short)354];

		public static MiscItem SectMainStoryItemZhujianTongshengTorso => Instance[(short)355];

		public static MiscItem SectMainStoryItemZhujianWeaponPrototype => Instance[(short)356];

		public static MiscItem SectMainStoryItemZhujianWeaponPrototype1 => Instance[(short)357];

		public static MiscItem SectMainStoryItemZhujianWeaponPrototype2 => Instance[(short)358];

		public static MiscItem SectMainStoryItemJingangSutraFragments => Instance[(short)359];

		public static MiscItem SectMainStoryItemJingangSutraAuthentic => Instance[(short)360];

		public static MiscItem SectMainStoryItemJingangSutraFake => Instance[(short)361];

		public static MiscItem SectMainStoryItemJingangSutraEastern => Instance[(short)362];

		public static MiscItem SectMainStoryItemJingangEerieAmulet => Instance[(short)363];

		public static MiscItem SectMainStoryUpgradeItemJingangJewel => Instance[(short)392];

		public static MiscItem SectMainStoryItemWuxianWugFairy => Instance[(short)364];

		public static MiscItem JieqingAssassinationToken => Instance[(short)365];

		public static MiscItem SectMainStoryItemJieQingStars => Instance[(short)366];

		public static MiscItem SectMainStoryFulongChickenFeather => Instance[(short)368];

		public static MiscItem SectMainStoryFulongFeatherCoat => Instance[(short)369];

		public static MiscItem SectMainStoryFulongChickenMap => Instance[(short)370];

		public static MiscItem AntiqueBell => Instance[(short)371];

		public static MiscItem AntiqueJadeBat => Instance[(short)372];

		public static MiscItem AntiqueJadeFox => Instance[(short)373];

		public static MiscItem AntiqueJadeButterfly => Instance[(short)374];

		public static MiscItem AdventureXRSDAuraRemnantMetal => Instance[(short)381];

		public static MiscItem AdventureXRSDAuraRemnantWood => Instance[(short)382];

		public static MiscItem AdventureXRSDAuraRemnantWater => Instance[(short)383];

		public static MiscItem AdventureXRSDAuraRemnantFire => Instance[(short)384];

		public static MiscItem AdventureXRSDAuraRemnantEarth => Instance[(short)385];

		public static MiscItem MetalNeiliStone => Instance[(short)375];

		public static MiscItem WoodNeiliStone => Instance[(short)376];

		public static MiscItem WaterNeiliStone => Instance[(short)377];

		public static MiscItem FireNeiliStone => Instance[(short)378];

		public static MiscItem EarthNeiliStone => Instance[(short)379];

		public static MiscItem SealOfMerchant => Instance[(short)380];

		public static MiscItem CombatSkill => Instance[(short)386];

		public static MiscItem LifeSkill => Instance[(short)387];

		public static MiscItem Information => Instance[(short)388];

		public static MiscItem SecretInformation => Instance[(short)389];

		public static MiscItem AdventureYZGFXNPitem1 => Instance[(short)390];

		public static MiscItem AdventureYZGFXNPitem2 => Instance[(short)391];

		public static MiscItem AdventureQMLWHotTreasure => Instance[(short)393];

		public static MiscItem AdventureQMLWIceTreasure => Instance[(short)394];

		public static MiscItem AdventureQMLWEndlessTreasure => Instance[(short)395];

		public static MiscItem Prisoner => Instance[(short)475];

		public static MiscItem Poison0 => Instance[(short)476];

		public static MiscItem Poison1 => Instance[(short)477];

		public static MiscItem Poison2 => Instance[(short)478];

		public static MiscItem Poison3 => Instance[(short)479];

		public static MiscItem Poison4 => Instance[(short)480];

		public static MiscItem Poison5 => Instance[(short)481];

		public static MiscItem InnerInjury => Instance[(short)482];

		public static MiscItem OutterInjury => Instance[(short)483];

		public static MiscItem DamageHugeSword => Instance[(short)510];

		public static MiscItem MainStoryBoundaryJade => Instance[(short)511];

		public static MiscItem MainStorySeverMindPill => Instance[(short)512];

		public static MiscItem MainStoryFenchen => Instance[(short)534];

		public static MiscItem SectMainStoryItemJieQingPearls => Instance[(short)535];
	}

	public static Misc Instance = new Misc();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "ItemSubType", "GroupId", "Desc", "FunctionDesc", "ResourceType", "MakeItemSubType", "TaskLock", "BreakBonusEffect", "RequireCombatConfig",
		"StateBuryAmount", "CombatUseEffect", "CombatPrepareUseEffect", "TemplateId", "Grade", "Icon"
	};

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
		_dataArray.Add(new MiscItem(0, LocalStringManager.GetConfig("Misc_language", "Name_0"), 12, 1200, 0, 0, null, LocalStringManager.GetConfig("Misc_language", "Desc_0"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_0"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 5, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(1, LocalStringManager.GetConfig("Misc_language", "Name_1"), 12, 1200, 0, 0, null, LocalStringManager.GetConfig("Misc_language", "Desc_1"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_1"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 5, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(2, LocalStringManager.GetConfig("Misc_language", "Name_2"), 12, 1200, 0, 0, null, LocalStringManager.GetConfig("Misc_language", "Desc_2"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_2"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 5, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(3, LocalStringManager.GetConfig("Misc_language", "Name_3"), 12, 1200, 0, 0, null, LocalStringManager.GetConfig("Misc_language", "Desc_3"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_3"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 5, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(4, LocalStringManager.GetConfig("Misc_language", "Name_4"), 12, 1200, 0, 0, null, LocalStringManager.GetConfig("Misc_language", "Desc_4"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_4"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 5, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(5, LocalStringManager.GetConfig("Misc_language", "Name_5"), 12, 1200, 0, 0, null, LocalStringManager.GetConfig("Misc_language", "Desc_5"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_5"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 5, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(6, LocalStringManager.GetConfig("Misc_language", "Name_6"), 12, 1200, 0, 0, null, LocalStringManager.GetConfig("Misc_language", "Desc_6"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_6"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(7, LocalStringManager.GetConfig("Misc_language", "Name_7"), 12, 1200, 0, 0, null, LocalStringManager.GetConfig("Misc_language", "Desc_7"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_7"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(8, LocalStringManager.GetConfig("Misc_language", "Name_8"), 12, 1200, 0, 8, null, LocalStringManager.GetConfig("Misc_language", "Desc_8"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_8"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(9, LocalStringManager.GetConfig("Misc_language", "Name_9"), 12, 1200, 0, 9, "icon_Misc_jiupinxuelu", LocalStringManager.GetConfig("Misc_language", "Desc_9"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_9"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 100, 0, 0, 600, 3, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), 40, 25, 0, new IntPair(0, 0), 0, 0, 1, canUseOnPrepareCombat: true, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(10, LocalStringManager.GetConfig("Misc_language", "Name_10"), 12, 1200, 1, 9, "icon_Misc_bapinxuelu", LocalStringManager.GetConfig("Misc_language", "Desc_10"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_10"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 200, 0, 0, 1200, 4, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), 40, 50, 0, new IntPair(0, 0), 0, 0, 1, canUseOnPrepareCombat: true, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(11, LocalStringManager.GetConfig("Misc_language", "Name_11"), 12, 1200, 2, 9, "icon_Misc_qipinxuelu", LocalStringManager.GetConfig("Misc_language", "Desc_11"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_11"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 600, 0, 0, 1800, 5, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), 40, 100, 0, new IntPair(0, 0), 0, 0, 1, canUseOnPrepareCombat: true, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(12, LocalStringManager.GetConfig("Misc_language", "Name_12"), 12, 1200, 3, 9, "icon_Misc_liupinxuelu", LocalStringManager.GetConfig("Misc_language", "Desc_12"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_12"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 1500, 0, 0, 3000, 6, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), 40, 200, 0, new IntPair(0, 0), 0, 0, 1, canUseOnPrepareCombat: true, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(13, LocalStringManager.GetConfig("Misc_language", "Name_13"), 12, 1200, 4, 9, "icon_Misc_wupinxuelu", LocalStringManager.GetConfig("Misc_language", "Desc_13"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_13"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 3100, 1, 0, 4200, 7, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), 40, 400, 0, new IntPair(0, 0), 0, 0, 1, canUseOnPrepareCombat: true, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(14, LocalStringManager.GetConfig("Misc_language", "Name_14"), 12, 1200, 5, 9, "icon_Misc_sipinxuelu", LocalStringManager.GetConfig("Misc_language", "Desc_14"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_14"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 5600, 2, 0, 5400, 7, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), 40, 800, 0, new IntPair(0, 0), 0, 0, 1, canUseOnPrepareCombat: true, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(15, LocalStringManager.GetConfig("Misc_language", "Name_15"), 12, 1200, 6, 9, "icon_Misc_sanpinxielou", LocalStringManager.GetConfig("Misc_language", "Desc_15"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_15"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 9200, 3, 0, 7200, 8, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), 40, 1600, 0, new IntPair(0, 0), 0, 0, 1, canUseOnPrepareCombat: true, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(16, LocalStringManager.GetConfig("Misc_language", "Name_16"), 12, 1200, 7, 9, "icon_Misc_erpinxielou", LocalStringManager.GetConfig("Misc_language", "Desc_16"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_16"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 14100, 4, 0, 9000, 8, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), 40, 3200, 0, new IntPair(0, 0), 0, 0, 1, canUseOnPrepareCombat: true, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(17, LocalStringManager.GetConfig("Misc_language", "Name_17"), 12, 1200, 8, 9, "icon_Misc_yipinxielou", LocalStringManager.GetConfig("Misc_language", "Desc_17"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_17"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 20500, 5, 0, 10800, 8, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), 40, 6400, 0, new IntPair(0, 0), 0, 0, 1, canUseOnPrepareCombat: true, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(18, LocalStringManager.GetConfig("Misc_language", "Name_18"), 12, 1200, 0, -1, "icon_Misc_buchongwang", LocalStringManager.GetConfig("Misc_language", "Desc_18"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_18"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 100, 0, 0, 600, 3, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(19, LocalStringManager.GetConfig("Misc_language", "Name_19"), 12, 1204, 0, -1, "icon_Misc_youhulu", LocalStringManager.GetConfig("Misc_language", "Desc_19"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_19"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(20, LocalStringManager.GetConfig("Misc_language", "Name_20"), 12, 1204, 0, -1, "icon_Misc_youhulu", LocalStringManager.GetConfig("Misc_language", "Desc_20"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_20"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(21, LocalStringManager.GetConfig("Misc_language", "Name_21"), 12, 1204, 0, -1, "icon_Misc_youhulu", LocalStringManager.GetConfig("Misc_language", "Desc_21"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_21"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(22, LocalStringManager.GetConfig("Misc_language", "Name_22"), 12, 1204, 0, -1, "icon_Misc_guchimingzhong", LocalStringManager.GetConfig("Misc_language", "Desc_22"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_22"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(23, LocalStringManager.GetConfig("Misc_language", "Name_23"), 12, 1204, 0, -1, "icon_Misc_guchimingzhong", LocalStringManager.GetConfig("Misc_language", "Desc_23"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_23"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(24, LocalStringManager.GetConfig("Misc_language", "Name_24"), 12, 1204, 0, -1, "icon_Misc_guchimingzhong", LocalStringManager.GetConfig("Misc_language", "Desc_24"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_24"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(25, LocalStringManager.GetConfig("Misc_language", "Name_25"), 12, 1204, 0, -1, "icon_Misc_xiaohuangling", LocalStringManager.GetConfig("Misc_language", "Desc_25"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_25"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(26, LocalStringManager.GetConfig("Misc_language", "Name_26"), 12, 1204, 0, -1, "icon_Misc_xiaohuangling", LocalStringManager.GetConfig("Misc_language", "Desc_26"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_26"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(27, LocalStringManager.GetConfig("Misc_language", "Name_27"), 12, 1204, 0, -1, "icon_Misc_xiaohuangling", LocalStringManager.GetConfig("Misc_language", "Desc_27"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_27"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(28, LocalStringManager.GetConfig("Misc_language", "Name_28"), 12, 1204, 0, -1, "icon_Misc_moling", LocalStringManager.GetConfig("Misc_language", "Desc_28"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_28"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(29, LocalStringManager.GetConfig("Misc_language", "Name_29"), 12, 1204, 0, -1, "icon_Misc_moling", LocalStringManager.GetConfig("Misc_language", "Desc_29"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_29"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(30, LocalStringManager.GetConfig("Misc_language", "Name_30"), 12, 1204, 0, -1, "icon_Misc_moling", LocalStringManager.GetConfig("Misc_language", "Desc_30"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_30"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(31, LocalStringManager.GetConfig("Misc_language", "Name_31"), 12, 1204, 0, -1, "icon_Misc_caohuangling", LocalStringManager.GetConfig("Misc_language", "Desc_31"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_31"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(32, LocalStringManager.GetConfig("Misc_language", "Name_32"), 12, 1204, 0, -1, "icon_Misc_caohuangling", LocalStringManager.GetConfig("Misc_language", "Desc_32"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_32"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(33, LocalStringManager.GetConfig("Misc_language", "Name_33"), 12, 1204, 0, -1, "icon_Misc_caohuangling", LocalStringManager.GetConfig("Misc_language", "Desc_33"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_33"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(34, LocalStringManager.GetConfig("Misc_language", "Name_34"), 12, 1204, 0, -1, "icon_Misc_sanwei", LocalStringManager.GetConfig("Misc_language", "Desc_34"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_34"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(35, LocalStringManager.GetConfig("Misc_language", "Name_35"), 12, 1204, 0, -1, "icon_Misc_sanwei", LocalStringManager.GetConfig("Misc_language", "Desc_35"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_35"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(36, LocalStringManager.GetConfig("Misc_language", "Name_36"), 12, 1204, 0, -1, "icon_Misc_sanwei", LocalStringManager.GetConfig("Misc_language", "Desc_36"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_36"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 50, 0, 0, 1800, 8, 0, allowRandomCreate: true, 50, isSpecial: true, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(37, LocalStringManager.GetConfig("Misc_language", "Name_37"), 12, 1203, 4, 37, "icon_Misc_guandiao", LocalStringManager.GetConfig("Misc_language", "Desc_37"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_37"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 30, 9300, 2, 10, 4200, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(38, LocalStringManager.GetConfig("Misc_language", "Name_38"), 12, 1203, 5, 37, "icon_Misc_baige", LocalStringManager.GetConfig("Misc_language", "Desc_38"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_38"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 20, 16800, 3, 12, 5400, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(39, LocalStringManager.GetConfig("Misc_language", "Name_39"), 12, 1203, 6, 37, "icon_Misc_jiaoxiaoyumao", LocalStringManager.GetConfig("Misc_language", "Desc_39"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_39"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 27600, 4, 14, 7200, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(40, LocalStringManager.GetConfig("Misc_language", "Name_40"), 12, 1203, 7, 37, "icon_Misc_miniewamaotouying", LocalStringManager.GetConfig("Misc_language", "Desc_40"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_40"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 30, 42300, 5, 16, 9000, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(41, LocalStringManager.GetConfig("Misc_language", "Name_41"), 12, 1203, 8, 37, "icon_Misc_taiyangshenyumao", LocalStringManager.GetConfig("Misc_language", "Desc_41"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_41"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 61500, 6, 18, 10800, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(42, LocalStringManager.GetConfig("Misc_language", "Name_42"), 12, 1203, 4, 42, "icon_Misc_tuoling", LocalStringManager.GetConfig("Misc_language", "Desc_42"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_42"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 9300, 2, 10, 4200, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(43, LocalStringManager.GetConfig("Misc_language", "Name_43"), 12, 1203, 5, 42, "icon_Misc_maodunmingdijian", LocalStringManager.GetConfig("Misc_language", "Desc_43"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_43"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 16800, 3, 12, 5400, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(44, LocalStringManager.GetConfig("Misc_language", "Name_44"), 12, 1203, 6, 42, "icon_Misc_delitiebang", LocalStringManager.GetConfig("Misc_language", "Desc_44"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_44"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 27600, 4, 14, 7200, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(45, LocalStringManager.GetConfig("Misc_language", "Name_45"), 12, 1203, 7, 42, "icon_Misc_yiluodetangdao", LocalStringManager.GetConfig("Misc_language", "Desc_45"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_45"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 250, 42300, 5, 16, 9000, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(46, LocalStringManager.GetConfig("Misc_language", "Name_46"), 12, 1203, 8, 42, "icon_Misc_huangjinkaijia", LocalStringManager.GetConfig("Misc_language", "Desc_46"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_46"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1000, 61500, 6, 18, 10800, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(47, LocalStringManager.GetConfig("Misc_language", "Name_47"), 12, 1203, 4, 47, "icon_Misc_weisidɑzhennvxiang", LocalStringManager.GetConfig("Misc_language", "Desc_47"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_47"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 70, 9300, 2, 10, 4200, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(48, LocalStringManager.GetConfig("Misc_language", "Name_48"), 12, 1203, 5, 47, "icon_Misc_changshengjun", LocalStringManager.GetConfig("Misc_language", "Desc_48"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_48"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 90, 16800, 3, 12, 5400, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(49, LocalStringManager.GetConfig("Misc_language", "Name_49"), 12, 1203, 6, 47, "icon_Misc_dashiwangdiaoxiang", LocalStringManager.GetConfig("Misc_language", "Desc_49"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_49"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 120, 27600, 4, 14, 7200, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(50, LocalStringManager.GetConfig("Misc_language", "Name_50"), 12, 1203, 7, 47, "icon_Misc_lingweng", LocalStringManager.GetConfig("Misc_language", "Desc_50"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_50"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 42300, 5, 16, 9000, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(51, LocalStringManager.GetConfig("Misc_language", "Name_51"), 12, 1203, 8, 47, "icon_Misc_weinasinvshenxiang", LocalStringManager.GetConfig("Misc_language", "Desc_51"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_51"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 800, 61500, 6, 18, 10800, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(52, LocalStringManager.GetConfig("Misc_language", "Name_52"), 12, 1203, 4, 52, "icon_Misc_putaojiu", LocalStringManager.GetConfig("Misc_language", "Desc_52"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_52"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 9300, 2, 10, 4200, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(53, LocalStringManager.GetConfig("Misc_language", "Name_53"), 12, 1203, 5, 52, "icon_Misc_liuliyeguangbei", LocalStringManager.GetConfig("Misc_language", "Desc_53"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_53"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 20, 16800, 3, 12, 5400, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(54, LocalStringManager.GetConfig("Misc_language", "Name_54"), 12, 1203, 6, 52, "icon_Misc_longgaojiu", LocalStringManager.GetConfig("Misc_language", "Desc_54"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_54"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 27600, 4, 14, 7200, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(55, LocalStringManager.GetConfig("Misc_language", "Name_55"), 12, 1203, 7, 52, "icon_Misc_yaokunjiu", LocalStringManager.GetConfig("Misc_language", "Desc_55"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_55"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 42300, 5, 16, 9000, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(56, LocalStringManager.GetConfig("Misc_language", "Name_56"), 12, 1203, 8, 52, "icon_Misc_shoushoumanaobei", LocalStringManager.GetConfig("Misc_language", "Desc_56"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_56"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 20, 61500, 6, 18, 10800, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(57, LocalStringManager.GetConfig("Misc_language", "Name_57"), 12, 1203, 4, 57, "icon_Misc_suoluohuachong", LocalStringManager.GetConfig("Misc_language", "Desc_57"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_57"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 9300, 2, 10, 4200, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(58, LocalStringManager.GetConfig("Misc_language", "Name_58"), 12, 1203, 5, 57, "icon_Misc_guiyehuaguan", LocalStringManager.GetConfig("Misc_language", "Desc_58"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_58"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 16800, 3, 12, 5400, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(59, LocalStringManager.GetConfig("Misc_language", "Name_59"), 12, 1203, 6, 57, "icon_Misc_luweidi", LocalStringManager.GetConfig("Misc_language", "Desc_59"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_59"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 27600, 4, 14, 7200, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new MiscItem(60, LocalStringManager.GetConfig("Misc_language", "Name_60"), 12, 1203, 7, 57, "icon_Misc_suopalizuosirong", LocalStringManager.GetConfig("Misc_language", "Desc_60"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_60"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 30, 42300, 5, 16, 9000, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(61, LocalStringManager.GetConfig("Misc_language", "Name_61"), 12, 1203, 8, 57, "icon_Misc_huohuanbu", LocalStringManager.GetConfig("Misc_language", "Desc_61"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_61"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 30, 61500, 6, 18, 10800, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(62, LocalStringManager.GetConfig("Misc_language", "Name_62"), 12, 1203, 4, 62, "icon_Misc_foya", LocalStringManager.GetConfig("Misc_language", "Desc_62"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_62"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 9300, 2, 10, 4200, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(63, LocalStringManager.GetConfig("Misc_language", "Name_63"), 12, 1203, 5, 62, "icon_Misc_baihuojiaohuozhong", LocalStringManager.GetConfig("Misc_language", "Desc_63"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_63"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 16800, 3, 12, 5400, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(64, LocalStringManager.GetConfig("Misc_language", "Name_64"), 12, 1203, 6, 62, "icon_Misc_xidaduokuxingxiang", LocalStringManager.GetConfig("Misc_language", "Desc_64"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_64"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 27600, 4, 14, 7200, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(65, LocalStringManager.GetConfig("Misc_language", "Name_65"), 12, 1203, 7, 62, "icon_Misc_dazhujiaodewangguan", LocalStringManager.GetConfig("Misc_language", "Desc_65"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_65"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 40, 42300, 5, 16, 9000, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(66, LocalStringManager.GetConfig("Misc_language", "Name_66"), 12, 1203, 8, 62, "icon_Misc_jinshenguhui", LocalStringManager.GetConfig("Misc_language", "Desc_66"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_66"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 61500, 6, 18, 10800, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(67, LocalStringManager.GetConfig("Misc_language", "Name_67"), 12, 1203, 4, 67, "icon_Misc_baoshi", LocalStringManager.GetConfig("Misc_language", "Desc_67"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_67"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 30, 9300, 2, 10, 4200, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(68, LocalStringManager.GetConfig("Misc_language", "Name_68"), 12, 1203, 5, 67, "icon_Misc_jingcunzhu", LocalStringManager.GetConfig("Misc_language", "Desc_68"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_68"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 16800, 3, 12, 5400, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(69, LocalStringManager.GetConfig("Misc_language", "Name_69"), 12, 1203, 6, 67, "icon_Misc_yutianyu", LocalStringManager.GetConfig("Misc_language", "Desc_69"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_69"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 30, 27600, 4, 14, 7200, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(70, LocalStringManager.GetConfig("Misc_language", "Name_70"), 12, 1203, 7, 67, "icon_Misc_yangsuizhu", LocalStringManager.GetConfig("Misc_language", "Desc_70"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_70"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 42300, 5, 16, 9000, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(71, LocalStringManager.GetConfig("Misc_language", "Name_71"), 12, 1203, 8, 67, "icon_Misc_zuanshi", LocalStringManager.GetConfig("Misc_language", "Desc_71"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_71"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 20, 61500, 6, 18, 10800, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(72, LocalStringManager.GetConfig("Misc_language", "Name_72"), 12, 1203, 4, 72, "icon_Misc_miandai", LocalStringManager.GetConfig("Misc_language", "Desc_72"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_72"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 9300, 2, 10, 4200, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(73, LocalStringManager.GetConfig("Misc_language", "Name_73"), 12, 1203, 5, 72, "icon_Misc_bosiliujinyinhu", LocalStringManager.GetConfig("Misc_language", "Desc_73"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_73"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 40, 16800, 3, 12, 5400, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(74, LocalStringManager.GetConfig("Misc_language", "Name_74"), 12, 1203, 6, 72, "icon_Misc_sichouhuangfu", LocalStringManager.GetConfig("Misc_language", "Desc_74"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_74"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 40, 27600, 4, 14, 7200, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(75, LocalStringManager.GetConfig("Misc_language", "Name_75"), 12, 1203, 7, 72, "icon_Misc_jinyuxianghushenfu", LocalStringManager.GetConfig("Misc_language", "Desc_75"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_75"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 42300, 5, 16, 9000, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(76, LocalStringManager.GetConfig("Misc_language", "Name_76"), 12, 1203, 8, 72, "icon_Misc_guanghuiwangguan", LocalStringManager.GetConfig("Misc_language", "Desc_76"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_76"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 40, 61500, 6, 18, 10800, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(77, LocalStringManager.GetConfig("Misc_language", "Name_77"), 12, 1203, 4, 77, "icon_Misc_dunhuangxingtu", LocalStringManager.GetConfig("Misc_language", "Desc_77"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_77"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 9300, 2, 10, 4200, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(78, LocalStringManager.GetConfig("Misc_language", "Name_78"), 12, 1203, 5, 77, "icon_Misc_yangpishengjing", LocalStringManager.GetConfig("Misc_language", "Desc_78"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_78"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 20, 16800, 3, 12, 5400, 7, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(79, LocalStringManager.GetConfig("Misc_language", "Name_79"), 12, 1203, 6, 77, "icon_Misc_manufadian", LocalStringManager.GetConfig("Misc_language", "Desc_79"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_79"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 40, 27600, 4, 14, 7200, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(80, LocalStringManager.GetConfig("Misc_language", "Name_80"), 12, 1203, 7, 77, "icon_Misc_hemashishi", LocalStringManager.GetConfig("Misc_language", "Desc_80"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_80"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 30, 42300, 5, 16, 9000, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(81, LocalStringManager.GetConfig("Misc_language", "Name_81"), 12, 1203, 8, 77, "icon_Misc_sihaiwenshu", LocalStringManager.GetConfig("Misc_language", "Desc_81"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_81"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 40, 61500, 6, 18, 10800, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.WesternPresent, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(82, LocalStringManager.GetConfig("Misc_language", "Name_82"), 12, 1206, 0, 82, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_82"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_82"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 300, 0, 1, 600, 3, 0, allowRandomCreate: true, 45, isSpecial: false, 4, 181, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, 6, 4, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(83, LocalStringManager.GetConfig("Misc_language", "Name_83"), 12, 1206, 1, 82, "icon_Misc_funiusuo", LocalStringManager.GetConfig("Misc_language", "Desc_83"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_83"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 50, 600, 0, 2, 1200, 4, 0, allowRandomCreate: true, 40, isSpecial: false, 4, 181, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 25, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, 6, 4, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(84, LocalStringManager.GetConfig("Misc_language", "Name_84"), 12, 1206, 2, 82, "icon_Misc_wucaisheng", LocalStringManager.GetConfig("Misc_language", "Desc_84"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_84"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 40, 1800, 1, 3, 1800, 5, 0, allowRandomCreate: true, 35, isSpecial: false, 4, 181, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 30, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, 6, 4, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(85, LocalStringManager.GetConfig("Misc_language", "Name_85"), 12, 1206, 3, 82, "icon_Misc_bairensuo", LocalStringManager.GetConfig("Misc_language", "Desc_85"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_85"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 60, 4500, 2, 4, 3000, 6, 0, allowRandomCreate: true, 30, isSpecial: false, 4, 181, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 35, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, 6, 4, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(86, LocalStringManager.GetConfig("Misc_language", "Name_86"), 12, 1206, 4, 82, "icon_Misc_zhuxiachangsuo", LocalStringManager.GetConfig("Misc_language", "Desc_86"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_86"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 40, 9300, 3, 5, 4200, 7, 0, allowRandomCreate: true, 25, isSpecial: false, 4, 181, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 40, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, 6, 4, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(87, LocalStringManager.GetConfig("Misc_language", "Name_87"), 12, 1206, 5, 82, "icon_Misc_qianjiaosheng", LocalStringManager.GetConfig("Misc_language", "Desc_87"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_87"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 60, 16800, 4, 6, 5400, 7, 0, allowRandomCreate: true, 20, isSpecial: false, 4, 181, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 45, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, 6, 4, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(88, LocalStringManager.GetConfig("Misc_language", "Name_88"), 12, 1206, 6, 82, "icon_Misc_wanjiechanyunsuo", LocalStringManager.GetConfig("Misc_language", "Desc_88"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_88"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 50, 27600, 5, 7, 7200, 8, 0, allowRandomCreate: true, 15, isSpecial: false, 4, 181, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 50, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, 6, 4, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(89, LocalStringManager.GetConfig("Misc_language", "Name_89"), 12, 1206, 7, 82, "icon_Misc_wuzhongsuo", LocalStringManager.GetConfig("Misc_language", "Desc_89"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_89"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 60, 42300, 6, 8, 9000, 8, 0, allowRandomCreate: true, 10, isSpecial: false, 4, 181, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 60, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, 6, 4, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(90, LocalStringManager.GetConfig("Misc_language", "Name_90"), 12, 1206, 8, 82, "icon_Misc_kunxiansheng", LocalStringManager.GetConfig("Misc_language", "Desc_90"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_90"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 40, 61500, 6, 9, 10800, 8, 0, allowRandomCreate: true, 5, isSpecial: false, 4, 181, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 70, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, 6, 4, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(91, LocalStringManager.GetConfig("Misc_language", "Name_91"), 12, 1201, 0, 91, "icon_Misc_dancuzhiguan", LocalStringManager.GetConfig("Misc_language", "Desc_91"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_91"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 80, 300, 0, 2, 600, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(92, LocalStringManager.GetConfig("Misc_language", "Name_92"), 12, 1201, 1, 91, "icon_Misc_cizhicuzhiguan", LocalStringManager.GetConfig("Misc_language", "Desc_92"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_92"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 60, 600, 0, 4, 1200, 4, 0, allowRandomCreate: true, 40, isSpecial: false, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 20, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(93, LocalStringManager.GetConfig("Misc_language", "Name_93"), 12, 1201, 2, 91, "icon_Misc_zishacuzhiguan", LocalStringManager.GetConfig("Misc_language", "Desc_93"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_93"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 70, 1800, 0, 6, 1800, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 25, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(94, LocalStringManager.GetConfig("Misc_language", "Name_94"), 12, 1201, 3, 91, "icon_Misc_bainicuzhiguan", LocalStringManager.GetConfig("Misc_language", "Desc_94"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_94"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 70, 4500, 1, 8, 3000, 6, 0, allowRandomCreate: true, 30, isSpecial: false, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 35, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(95, LocalStringManager.GetConfig("Misc_language", "Name_95"), 12, 1201, 4, 91, "icon_Misc_laoqingzhuancuzhiguan", LocalStringManager.GetConfig("Misc_language", "Desc_95"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_95"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 90, 9300, 2, 10, 4200, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 45, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(96, LocalStringManager.GetConfig("Misc_language", "Name_96"), 12, 1201, 5, 91, "icon_Misc_moyucuzhiguan", LocalStringManager.GetConfig("Misc_language", "Desc_96"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_96"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 80, 16800, 3, 12, 5400, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 55, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(97, LocalStringManager.GetConfig("Misc_language", "Name_97"), 12, 1201, 6, 91, "icon_Misc_yunisajincuzhiguan", LocalStringManager.GetConfig("Misc_language", "Desc_97"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_97"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 70, 27600, 4, 14, 7200, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 70, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(98, LocalStringManager.GetConfig("Misc_language", "Name_98"), 12, 1201, 7, 91, "icon_Misc_longxinglushacuzhiguan", LocalStringManager.GetConfig("Misc_language", "Desc_98"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_98"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 60, 42300, 5, 16, 9000, 8, 0, allowRandomCreate: true, 10, isSpecial: false, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 85, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(99, LocalStringManager.GetConfig("Misc_language", "Name_99"), 12, 1201, 8, 91, "icon_Misc_bainiandengnicuzhiguan", LocalStringManager.GetConfig("Misc_language", "Desc_99"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_99"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 80, 61500, 6, 18, 10800, 8, 0, allowRandomCreate: true, 5, isSpecial: false, -1, -1, 1200, new List<int>(), -1, 0, 0, new IntPair(0, 0), 100, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(100, LocalStringManager.GetConfig("Misc_language", "Name_100"), 12, 1205, 1, -1, "icon_Misc_shuijing", LocalStringManager.GetConfig("Misc_language", "Desc_100"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_100"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 50, 2000, 1, 2, 600, 4, 0, allowRandomCreate: true, 0, isSpecial: true, 0, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 15),
			new TreasureStateInfo(2, 15),
			new TreasureStateInfo(3, 15),
			new TreasureStateInfo(4, 15),
			new TreasureStateInfo(5, 15),
			new TreasureStateInfo(6, 15),
			new TreasureStateInfo(7, 15),
			new TreasureStateInfo(8, 15),
			new TreasureStateInfo(9, 15),
			new TreasureStateInfo(10, 15),
			new TreasureStateInfo(11, 15),
			new TreasureStateInfo(12, 15),
			new TreasureStateInfo(13, 15),
			new TreasureStateInfo(14, 15),
			new TreasureStateInfo(15, 15)
		}, EMiscResourceMaterialType.Low, EMiscFilterType.KeyItem, -1, -1, 0, 200, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(101, LocalStringManager.GetConfig("Misc_language", "Name_101"), 12, 1205, 1, -1, "icon_Misc_huoshi", LocalStringManager.GetConfig("Misc_language", "Desc_101"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_101"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 2000, 1, 2, 600, 4, 0, allowRandomCreate: true, 0, isSpecial: true, 2, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 15),
			new TreasureStateInfo(2, 15),
			new TreasureStateInfo(3, 15),
			new TreasureStateInfo(4, 15),
			new TreasureStateInfo(5, 15),
			new TreasureStateInfo(6, 15),
			new TreasureStateInfo(7, 15),
			new TreasureStateInfo(8, 15),
			new TreasureStateInfo(9, 15),
			new TreasureStateInfo(10, 15),
			new TreasureStateInfo(11, 15),
			new TreasureStateInfo(12, 15),
			new TreasureStateInfo(13, 15),
			new TreasureStateInfo(14, 15),
			new TreasureStateInfo(15, 15)
		}, EMiscResourceMaterialType.Low, EMiscFilterType.KeyItem, -1, -1, 0, 200, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(102, LocalStringManager.GetConfig("Misc_language", "Name_102"), 12, 1205, 1, -1, "icon_Misc_qingqingmiaomu", LocalStringManager.GetConfig("Misc_language", "Desc_102"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_102"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 2000, 1, 2, 600, 4, 0, allowRandomCreate: true, 0, isSpecial: true, 1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 15),
			new TreasureStateInfo(2, 15),
			new TreasureStateInfo(3, 15),
			new TreasureStateInfo(4, 15),
			new TreasureStateInfo(5, 15),
			new TreasureStateInfo(6, 15),
			new TreasureStateInfo(7, 15),
			new TreasureStateInfo(8, 15),
			new TreasureStateInfo(9, 15),
			new TreasureStateInfo(10, 15),
			new TreasureStateInfo(11, 15),
			new TreasureStateInfo(12, 15),
			new TreasureStateInfo(13, 15),
			new TreasureStateInfo(14, 15),
			new TreasureStateInfo(15, 15)
		}, EMiscResourceMaterialType.Low, EMiscFilterType.KeyItem, -1, -1, 0, 200, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(103, LocalStringManager.GetConfig("Misc_language", "Name_103"), 12, 1205, 1, -1, "icon_Misc_guyan", LocalStringManager.GetConfig("Misc_language", "Desc_103"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_103"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 2000, 1, 2, 600, 4, 0, allowRandomCreate: true, 0, isSpecial: true, 2, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 15),
			new TreasureStateInfo(2, 15),
			new TreasureStateInfo(3, 15),
			new TreasureStateInfo(4, 15),
			new TreasureStateInfo(5, 15),
			new TreasureStateInfo(6, 15),
			new TreasureStateInfo(7, 15),
			new TreasureStateInfo(8, 15),
			new TreasureStateInfo(9, 15),
			new TreasureStateInfo(10, 15),
			new TreasureStateInfo(11, 15),
			new TreasureStateInfo(12, 15),
			new TreasureStateInfo(13, 15),
			new TreasureStateInfo(14, 15),
			new TreasureStateInfo(15, 15)
		}, EMiscResourceMaterialType.Low, EMiscFilterType.KeyItem, -1, -1, 0, 200, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(104, LocalStringManager.GetConfig("Misc_language", "Name_104"), 12, 1205, 1, -1, "icon_Misc_baicaoyaozi", LocalStringManager.GetConfig("Misc_language", "Desc_104"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_104"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 2000, 1, 2, 600, 4, 0, allowRandomCreate: true, 0, isSpecial: true, 5, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 15),
			new TreasureStateInfo(2, 15),
			new TreasureStateInfo(3, 15),
			new TreasureStateInfo(4, 15),
			new TreasureStateInfo(5, 15),
			new TreasureStateInfo(6, 15),
			new TreasureStateInfo(7, 15),
			new TreasureStateInfo(8, 15),
			new TreasureStateInfo(9, 15),
			new TreasureStateInfo(10, 15),
			new TreasureStateInfo(11, 15),
			new TreasureStateInfo(12, 15),
			new TreasureStateInfo(13, 15),
			new TreasureStateInfo(14, 15),
			new TreasureStateInfo(15, 15)
		}, EMiscResourceMaterialType.Low, EMiscFilterType.KeyItem, -1, -1, 0, 200, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(105, LocalStringManager.GetConfig("Misc_language", "Name_105"), 12, 1205, 1, -1, "icon_Misc_funi", LocalStringManager.GetConfig("Misc_language", "Desc_105"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_105"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 2000, 1, 2, 600, 4, 0, allowRandomCreate: true, 0, isSpecial: true, 5, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 15),
			new TreasureStateInfo(2, 15),
			new TreasureStateInfo(3, 15),
			new TreasureStateInfo(4, 15),
			new TreasureStateInfo(5, 15),
			new TreasureStateInfo(6, 15),
			new TreasureStateInfo(7, 15),
			new TreasureStateInfo(8, 15),
			new TreasureStateInfo(9, 15),
			new TreasureStateInfo(10, 15),
			new TreasureStateInfo(11, 15),
			new TreasureStateInfo(12, 15),
			new TreasureStateInfo(13, 15),
			new TreasureStateInfo(14, 15),
			new TreasureStateInfo(15, 15)
		}, EMiscResourceMaterialType.Low, EMiscFilterType.KeyItem, -1, -1, 0, 200, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(106, LocalStringManager.GetConfig("Misc_language", "Name_106"), 12, 1205, 1, -1, "icon_Misc_baihuazhongzi", LocalStringManager.GetConfig("Misc_language", "Desc_106"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_106"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 2000, 1, 2, 600, 4, 0, allowRandomCreate: true, 0, isSpecial: true, 4, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 15),
			new TreasureStateInfo(2, 15),
			new TreasureStateInfo(3, 15),
			new TreasureStateInfo(4, 15),
			new TreasureStateInfo(5, 15),
			new TreasureStateInfo(6, 15),
			new TreasureStateInfo(7, 15),
			new TreasureStateInfo(8, 15),
			new TreasureStateInfo(9, 15),
			new TreasureStateInfo(10, 15),
			new TreasureStateInfo(11, 15),
			new TreasureStateInfo(12, 15),
			new TreasureStateInfo(13, 15),
			new TreasureStateInfo(14, 15),
			new TreasureStateInfo(15, 15)
		}, EMiscResourceMaterialType.Low, EMiscFilterType.KeyItem, -1, -1, 0, 200, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(107, LocalStringManager.GetConfig("Misc_language", "Name_107"), 12, 1205, 1, -1, "icon_Misc_puyu", LocalStringManager.GetConfig("Misc_language", "Desc_107"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_107"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 2000, 1, 2, 600, 4, 0, allowRandomCreate: true, 0, isSpecial: true, 3, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 15),
			new TreasureStateInfo(2, 15),
			new TreasureStateInfo(3, 15),
			new TreasureStateInfo(4, 15),
			new TreasureStateInfo(5, 15),
			new TreasureStateInfo(6, 15),
			new TreasureStateInfo(7, 15),
			new TreasureStateInfo(8, 15),
			new TreasureStateInfo(9, 15),
			new TreasureStateInfo(10, 15),
			new TreasureStateInfo(11, 15),
			new TreasureStateInfo(12, 15),
			new TreasureStateInfo(13, 15),
			new TreasureStateInfo(14, 15),
			new TreasureStateInfo(15, 15)
		}, EMiscResourceMaterialType.Low, EMiscFilterType.KeyItem, -1, -1, 0, 200, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(108, LocalStringManager.GetConfig("Misc_language", "Name_108"), 12, 1205, 1, -1, "icon_Misc_wotu", LocalStringManager.GetConfig("Misc_language", "Desc_108"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_108"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 2000, 1, 2, 600, 4, 0, allowRandomCreate: true, 0, isSpecial: true, 1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 15),
			new TreasureStateInfo(2, 15),
			new TreasureStateInfo(3, 15),
			new TreasureStateInfo(4, 15),
			new TreasureStateInfo(5, 15),
			new TreasureStateInfo(6, 15),
			new TreasureStateInfo(7, 15),
			new TreasureStateInfo(8, 15),
			new TreasureStateInfo(9, 15),
			new TreasureStateInfo(10, 15),
			new TreasureStateInfo(11, 15),
			new TreasureStateInfo(12, 15),
			new TreasureStateInfo(13, 15),
			new TreasureStateInfo(14, 15),
			new TreasureStateInfo(15, 15)
		}, EMiscResourceMaterialType.Low, EMiscFilterType.KeyItem, -1, -1, 0, 200, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(109, LocalStringManager.GetConfig("Misc_language", "Name_109"), 12, 1205, 1, -1, "icon_Misc_youshou", LocalStringManager.GetConfig("Misc_language", "Desc_109"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_109"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 2000, 1, 2, 600, 4, 0, allowRandomCreate: true, 0, isSpecial: true, 0, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 15),
			new TreasureStateInfo(2, 15),
			new TreasureStateInfo(3, 15),
			new TreasureStateInfo(4, 15),
			new TreasureStateInfo(5, 15),
			new TreasureStateInfo(6, 15),
			new TreasureStateInfo(7, 15),
			new TreasureStateInfo(8, 15),
			new TreasureStateInfo(9, 15),
			new TreasureStateInfo(10, 15),
			new TreasureStateInfo(11, 15),
			new TreasureStateInfo(12, 15),
			new TreasureStateInfo(13, 15),
			new TreasureStateInfo(14, 15),
			new TreasureStateInfo(15, 15)
		}, EMiscResourceMaterialType.Low, EMiscFilterType.KeyItem, -1, -1, 0, 200, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(110, LocalStringManager.GetConfig("Misc_language", "Name_110"), 12, 1205, 6, -1, "icon_Misc_jinwuhui", LocalStringManager.GetConfig("Misc_language", "Desc_110"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_110"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 50, 92000, 5, 7, 3600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, 2, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 6),
			new TreasureStateInfo(2, 6),
			new TreasureStateInfo(3, 6),
			new TreasureStateInfo(4, 6),
			new TreasureStateInfo(5, 6),
			new TreasureStateInfo(6, 6),
			new TreasureStateInfo(7, 6),
			new TreasureStateInfo(8, 6),
			new TreasureStateInfo(9, 6),
			new TreasureStateInfo(10, 6),
			new TreasureStateInfo(11, 6),
			new TreasureStateInfo(12, 6),
			new TreasureStateInfo(13, 6),
			new TreasureStateInfo(14, 6),
			new TreasureStateInfo(15, 6)
		}, EMiscResourceMaterialType.High, EMiscFilterType.KeyItem, -1, -1, 0, 1500, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(111, LocalStringManager.GetConfig("Misc_language", "Name_111"), 12, 1205, 6, -1, "icon_Misc_yingxingshi", LocalStringManager.GetConfig("Misc_language", "Desc_111"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_111"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 92000, 5, 7, 3600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, 2, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 6),
			new TreasureStateInfo(2, 6),
			new TreasureStateInfo(3, 6),
			new TreasureStateInfo(4, 6),
			new TreasureStateInfo(5, 6),
			new TreasureStateInfo(6, 6),
			new TreasureStateInfo(7, 6),
			new TreasureStateInfo(8, 6),
			new TreasureStateInfo(9, 6),
			new TreasureStateInfo(10, 6),
			new TreasureStateInfo(11, 6),
			new TreasureStateInfo(12, 6),
			new TreasureStateInfo(13, 6),
			new TreasureStateInfo(14, 6),
			new TreasureStateInfo(15, 6)
		}, EMiscResourceMaterialType.High, EMiscFilterType.KeyItem, -1, -1, 0, 1500, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(112, LocalStringManager.GetConfig("Misc_language", "Name_112"), 12, 1205, 6, -1, "icon_Misc_miyuqizhang", LocalStringManager.GetConfig("Misc_language", "Desc_112"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_112"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 92000, 5, 7, 3600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, 1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 6),
			new TreasureStateInfo(2, 6),
			new TreasureStateInfo(3, 6),
			new TreasureStateInfo(4, 6),
			new TreasureStateInfo(5, 6),
			new TreasureStateInfo(6, 6),
			new TreasureStateInfo(7, 6),
			new TreasureStateInfo(8, 6),
			new TreasureStateInfo(9, 6),
			new TreasureStateInfo(10, 6),
			new TreasureStateInfo(11, 6),
			new TreasureStateInfo(12, 6),
			new TreasureStateInfo(13, 6),
			new TreasureStateInfo(14, 6),
			new TreasureStateInfo(15, 6)
		}, EMiscResourceMaterialType.High, EMiscFilterType.KeyItem, -1, -1, 0, 1500, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(113, LocalStringManager.GetConfig("Misc_language", "Name_113"), 12, 1205, 6, -1, "icon_Misc_taishilongzhi", LocalStringManager.GetConfig("Misc_language", "Desc_113"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_113"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 92000, 5, 7, 3600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, 1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 6),
			new TreasureStateInfo(2, 6),
			new TreasureStateInfo(3, 6),
			new TreasureStateInfo(4, 6),
			new TreasureStateInfo(5, 6),
			new TreasureStateInfo(6, 6),
			new TreasureStateInfo(7, 6),
			new TreasureStateInfo(8, 6),
			new TreasureStateInfo(9, 6),
			new TreasureStateInfo(10, 6),
			new TreasureStateInfo(11, 6),
			new TreasureStateInfo(12, 6),
			new TreasureStateInfo(13, 6),
			new TreasureStateInfo(14, 6),
			new TreasureStateInfo(15, 6)
		}, EMiscResourceMaterialType.High, EMiscFilterType.KeyItem, -1, -1, 0, 1500, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(114, LocalStringManager.GetConfig("Misc_language", "Name_114"), 12, 1205, 6, -1, "icon_Misc_changchunjiuqiaoshi", LocalStringManager.GetConfig("Misc_language", "Desc_114"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_114"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 92000, 5, 7, 3600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, 5, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 6),
			new TreasureStateInfo(2, 6),
			new TreasureStateInfo(3, 6),
			new TreasureStateInfo(4, 6),
			new TreasureStateInfo(5, 6),
			new TreasureStateInfo(6, 6),
			new TreasureStateInfo(7, 6),
			new TreasureStateInfo(8, 6),
			new TreasureStateInfo(9, 6),
			new TreasureStateInfo(10, 6),
			new TreasureStateInfo(11, 6),
			new TreasureStateInfo(12, 6),
			new TreasureStateInfo(13, 6),
			new TreasureStateInfo(14, 6),
			new TreasureStateInfo(15, 6)
		}, EMiscResourceMaterialType.High, EMiscFilterType.KeyItem, -1, -1, 0, 1500, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(115, LocalStringManager.GetConfig("Misc_language", "Name_115"), 12, 1205, 6, -1, "icon_Misc_xuansheshi", LocalStringManager.GetConfig("Misc_language", "Desc_115"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_115"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 92000, 5, 7, 3600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, 5, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 6),
			new TreasureStateInfo(2, 6),
			new TreasureStateInfo(3, 6),
			new TreasureStateInfo(4, 6),
			new TreasureStateInfo(5, 6),
			new TreasureStateInfo(6, 6),
			new TreasureStateInfo(7, 6),
			new TreasureStateInfo(8, 6),
			new TreasureStateInfo(9, 6),
			new TreasureStateInfo(10, 6),
			new TreasureStateInfo(11, 6),
			new TreasureStateInfo(12, 6),
			new TreasureStateInfo(13, 6),
			new TreasureStateInfo(14, 6),
			new TreasureStateInfo(15, 6)
		}, EMiscResourceMaterialType.High, EMiscFilterType.KeyItem, -1, -1, 0, 1500, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(116, LocalStringManager.GetConfig("Misc_language", "Name_116"), 12, 1205, 6, -1, "icon_Misc_qixiangfengwang", LocalStringManager.GetConfig("Misc_language", "Desc_116"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_116"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 92000, 5, 7, 3600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, 4, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 6),
			new TreasureStateInfo(2, 6),
			new TreasureStateInfo(3, 6),
			new TreasureStateInfo(4, 6),
			new TreasureStateInfo(5, 6),
			new TreasureStateInfo(6, 6),
			new TreasureStateInfo(7, 6),
			new TreasureStateInfo(8, 6),
			new TreasureStateInfo(9, 6),
			new TreasureStateInfo(10, 6),
			new TreasureStateInfo(11, 6),
			new TreasureStateInfo(12, 6),
			new TreasureStateInfo(13, 6),
			new TreasureStateInfo(14, 6),
			new TreasureStateInfo(15, 6)
		}, EMiscResourceMaterialType.High, EMiscFilterType.KeyItem, -1, -1, 0, 1500, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(117, LocalStringManager.GetConfig("Misc_language", "Name_117"), 12, 1205, 6, -1, "icon_Misc_shengshaeryuanqi", LocalStringManager.GetConfig("Misc_language", "Desc_117"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_117"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 92000, 5, 7, 3600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, 4, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 6),
			new TreasureStateInfo(2, 6),
			new TreasureStateInfo(3, 6),
			new TreasureStateInfo(4, 6),
			new TreasureStateInfo(5, 6),
			new TreasureStateInfo(6, 6),
			new TreasureStateInfo(7, 6),
			new TreasureStateInfo(8, 6),
			new TreasureStateInfo(9, 6),
			new TreasureStateInfo(10, 6),
			new TreasureStateInfo(11, 6),
			new TreasureStateInfo(12, 6),
			new TreasureStateInfo(13, 6),
			new TreasureStateInfo(14, 6),
			new TreasureStateInfo(15, 6)
		}, EMiscResourceMaterialType.High, EMiscFilterType.KeyItem, -1, -1, 0, 1500, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(118, LocalStringManager.GetConfig("Misc_language", "Name_118"), 12, 1205, 6, -1, "icon_Misc_dilingxue", LocalStringManager.GetConfig("Misc_language", "Desc_118"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_118"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 92000, 5, 7, 3600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, 3, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 6),
			new TreasureStateInfo(2, 6),
			new TreasureStateInfo(3, 6),
			new TreasureStateInfo(4, 6),
			new TreasureStateInfo(5, 6),
			new TreasureStateInfo(6, 6),
			new TreasureStateInfo(7, 6),
			new TreasureStateInfo(8, 6),
			new TreasureStateInfo(9, 6),
			new TreasureStateInfo(10, 6),
			new TreasureStateInfo(11, 6),
			new TreasureStateInfo(12, 6),
			new TreasureStateInfo(13, 6),
			new TreasureStateInfo(14, 6),
			new TreasureStateInfo(15, 6)
		}, EMiscResourceMaterialType.High, EMiscFilterType.KeyItem, -1, -1, 0, 1500, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(119, LocalStringManager.GetConfig("Misc_language", "Name_119"), 12, 1205, 6, -1, "icon_Misc_xudiyinsha", LocalStringManager.GetConfig("Misc_language", "Desc_119"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_119"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 92000, 5, 7, 3600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, 3, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.V78R31, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 6),
			new TreasureStateInfo(2, 6),
			new TreasureStateInfo(3, 6),
			new TreasureStateInfo(4, 6),
			new TreasureStateInfo(5, 6),
			new TreasureStateInfo(6, 6),
			new TreasureStateInfo(7, 6),
			new TreasureStateInfo(8, 6),
			new TreasureStateInfo(9, 6),
			new TreasureStateInfo(10, 6),
			new TreasureStateInfo(11, 6),
			new TreasureStateInfo(12, 6),
			new TreasureStateInfo(13, 6),
			new TreasureStateInfo(14, 6),
			new TreasureStateInfo(15, 6)
		}, EMiscResourceMaterialType.High, EMiscFilterType.KeyItem, -1, -1, 0, 1500, hasGiftEvent: false));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new MiscItem(120, LocalStringManager.GetConfig("Misc_language", "Name_120"), 12, 1205, 3, 120, "icon_Misc_jinggangsuokou", LocalStringManager.GetConfig("Misc_language", "Desc_120"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_120"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 15000, 1, 4, 1500, 6, 0, allowRandomCreate: true, 30, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 2, 3, 4 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 3),
			new TreasureStateInfo(6, 2),
			new TreasureStateInfo(14, 2),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(7, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(121, LocalStringManager.GetConfig("Misc_language", "Name_121"), 12, 1205, 3, 120, "icon_Misc_heihuoyao", LocalStringManager.GetConfig("Misc_language", "Desc_121"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_121"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1200, 15000, 1, 4, 1500, 6, 0, allowRandomCreate: true, 30, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 2, 3, 4 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 3),
			new TreasureStateInfo(6, 2),
			new TreasureStateInfo(14, 2),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(7, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(122, LocalStringManager.GetConfig("Misc_language", "Name_122"), 12, 1205, 3, 120, "icon_Misc_bainianshaxin", LocalStringManager.GetConfig("Misc_language", "Desc_122"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_122"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1200, 15000, 1, 4, 1500, 6, 0, allowRandomCreate: true, 30, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 2, 3, 4 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 3),
			new TreasureStateInfo(6, 2),
			new TreasureStateInfo(12, 2),
			new TreasureStateInfo(14, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(7, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(123, LocalStringManager.GetConfig("Misc_language", "Name_123"), 12, 1205, 3, 120, "icon_Misc_jinganglun", LocalStringManager.GetConfig("Misc_language", "Desc_123"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_123"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 15000, 1, 4, 1500, 6, 0, allowRandomCreate: true, 30, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 2, 3, 4 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 3),
			new TreasureStateInfo(6, 2),
			new TreasureStateInfo(12, 2),
			new TreasureStateInfo(14, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(7, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(124, LocalStringManager.GetConfig("Misc_language", "Name_124"), 12, 1205, 3, 120, "icon_Misc_yutaoguan", LocalStringManager.GetConfig("Misc_language", "Desc_124"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_124"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 15000, 1, 4, 1500, 6, 0, allowRandomCreate: true, 30, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 2, 3, 4 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 3),
			new TreasureStateInfo(10, 3),
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(5, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(125, LocalStringManager.GetConfig("Misc_language", "Name_125"), 12, 1205, 3, 120, "icon_Misc_sishelong", LocalStringManager.GetConfig("Misc_language", "Desc_125"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_125"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 15000, 1, 4, 1500, 6, 0, allowRandomCreate: true, 30, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 2, 3, 4 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(12, 3),
			new TreasureStateInfo(10, 3),
			new TreasureStateInfo(13, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(5, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(126, LocalStringManager.GetConfig("Misc_language", "Name_126"), 12, 1205, 3, 120, "icon_Misc_yinxianbaipeng", LocalStringManager.GetConfig("Misc_language", "Desc_126"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_126"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 15000, 1, 4, 1500, 6, 0, allowRandomCreate: true, 30, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 2, 3, 4 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 3),
			new TreasureStateInfo(9, 2),
			new TreasureStateInfo(10, 2),
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(8, 1),
			new TreasureStateInfo(11, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(127, LocalStringManager.GetConfig("Misc_language", "Name_127"), 12, 1205, 3, 120, "icon_Misc_fengshuiqidan", LocalStringManager.GetConfig("Misc_language", "Desc_127"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_127"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 15000, 1, 4, 1500, 6, 0, allowRandomCreate: true, 30, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 2, 3, 4 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 3),
			new TreasureStateInfo(9, 2),
			new TreasureStateInfo(10, 2),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(14, 1),
			new TreasureStateInfo(4, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(128, LocalStringManager.GetConfig("Misc_language", "Name_128"), 12, 1205, 3, 120, "icon_Misc_zhenyuanbixieshou", LocalStringManager.GetConfig("Misc_language", "Desc_128"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_128"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 15000, 1, 4, 1500, 6, 0, allowRandomCreate: true, 30, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 2, 3, 4 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(7, 3),
			new TreasureStateInfo(9, 2),
			new TreasureStateInfo(10, 2),
			new TreasureStateInfo(13, 1),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(1, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(129, LocalStringManager.GetConfig("Misc_language", "Name_129"), 12, 1205, 3, 120, "icon_Misc_wudanju", LocalStringManager.GetConfig("Misc_language", "Desc_129"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_129"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1200, 15000, 1, 4, 1500, 6, 0, allowRandomCreate: true, 30, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 2, 3, 4 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(7, 3),
			new TreasureStateInfo(9, 2),
			new TreasureStateInfo(10, 2),
			new TreasureStateInfo(8, 1),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(5, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(130, LocalStringManager.GetConfig("Misc_language", "Name_130"), 12, 1205, 5, 130, "icon_Misc_jueyindan", LocalStringManager.GetConfig("Misc_language", "Desc_130"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_130"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 200, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(8, 1),
			new TreasureStateInfo(11, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(131, LocalStringManager.GetConfig("Misc_language", "Name_131"), 12, 1205, 5, 130, "icon_Misc_qilinzao", LocalStringManager.GetConfig("Misc_language", "Desc_131"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_131"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 300, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(4, 2),
			new TreasureStateInfo(13, 2),
			new TreasureStateInfo(3, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(132, LocalStringManager.GetConfig("Misc_language", "Name_132"), 12, 1205, 5, 130, "icon_Misc_fengkongbaiji", LocalStringManager.GetConfig("Misc_language", "Desc_132"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_132"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 250, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(133, LocalStringManager.GetConfig("Misc_language", "Name_133"), 12, 1205, 5, 130, "icon_Misc_sihulong", LocalStringManager.GetConfig("Misc_language", "Desc_133"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_133"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1200, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(4, 1),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(14, 1),
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(11, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(134, LocalStringManager.GetConfig("Misc_language", "Name_134"), 12, 1205, 5, 130, "icon_Misc_changshengjian", LocalStringManager.GetConfig("Misc_language", "Desc_134"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_134"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(8, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(13, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(135, LocalStringManager.GetConfig("Misc_language", "Name_135"), 12, 1205, 5, 130, "icon_Misc_longgujingou", LocalStringManager.GetConfig("Misc_language", "Desc_135"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_135"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(5, 2),
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(136, LocalStringManager.GetConfig("Misc_language", "Name_136"), 12, 1205, 5, 130, "icon_Misc_jueguangbi", LocalStringManager.GetConfig("Misc_language", "Desc_136"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_136"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 2),
			new TreasureStateInfo(13, 2),
			new TreasureStateInfo(14, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(137, LocalStringManager.GetConfig("Misc_language", "Name_137"), 12, 1205, 5, 130, "icon_Misc_zangjiandan", LocalStringManager.GetConfig("Misc_language", "Desc_137"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_137"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(4, 1),
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(5, 1),
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(13, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(138, LocalStringManager.GetConfig("Misc_language", "Name_138"), 12, 1205, 5, 130, "icon_Misc_zhendaodan", LocalStringManager.GetConfig("Misc_language", "Desc_138"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_138"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(11, 1),
			new TreasureStateInfo(5, 1),
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(14, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(139, LocalStringManager.GetConfig("Misc_language", "Name_139"), 12, 1205, 5, 130, "icon_Misc_pozhentieju", LocalStringManager.GetConfig("Misc_language", "Desc_139"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_139"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1500, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 2),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(9, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(140, LocalStringManager.GetConfig("Misc_language", "Name_140"), 12, 1205, 5, 130, "icon_Misc_zhenyandan", LocalStringManager.GetConfig("Misc_language", "Desc_140"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_140"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(7, 2),
			new TreasureStateInfo(11, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(141, LocalStringManager.GetConfig("Misc_language", "Name_141"), 12, 1205, 5, 130, "icon_Misc_baizhuanruansuo", LocalStringManager.GetConfig("Misc_language", "Desc_141"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_141"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 200, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(4, 2),
			new TreasureStateInfo(12, 2)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(142, LocalStringManager.GetConfig("Misc_language", "Name_142"), 12, 1205, 5, 130, "icon_Misc_zhuiguangbaozhu", LocalStringManager.GetConfig("Misc_language", "Desc_142"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_142"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 2),
			new TreasureStateInfo(9, 2)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(143, LocalStringManager.GetConfig("Misc_language", "Name_143"), 12, 1205, 5, 130, "icon_Misc_qisexinxian", LocalStringManager.GetConfig("Misc_language", "Desc_143"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_143"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 150, 56000, 3, 6, 2700, 7, 0, allowRandomCreate: true, 20, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 4, 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(8, 3),
			new TreasureStateInfo(3, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(144, LocalStringManager.GetConfig("Misc_language", "Name_144"), 12, 1205, 1, 130, "icon_Misc_lianshenjiushi", LocalStringManager.GetConfig("Misc_language", "Desc_144"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_144"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 2000, 0, 2, 600, 4, 0, allowRandomCreate: true, 40, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(4, 1),
			new TreasureStateInfo(9, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(145, LocalStringManager.GetConfig("Misc_language", "Name_145"), 12, 1205, 7, 130, "icon_Misc_hanyutai", LocalStringManager.GetConfig("Misc_language", "Desc_145"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_145"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1500, 141000, 5, 8, 4500, 8, 0, allowRandomCreate: true, 10, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(11, 1),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(10, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(146, LocalStringManager.GetConfig("Misc_language", "Name_146"), 12, 1205, 0, 146, "icon_Misc_shilehuiyintai", LocalStringManager.GetConfig("Misc_language", "Desc_146"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_146"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(8, 2),
			new TreasureStateInfo(3, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(147, LocalStringManager.GetConfig("Misc_language", "Name_147"), 12, 1205, 2, 146, "icon_Misc_chaoxinshi", LocalStringManager.GetConfig("Misc_language", "Desc_147"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_147"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1200, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(8, 2),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(6, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(148, LocalStringManager.GetConfig("Misc_language", "Name_148"), 12, 1205, 4, 146, "icon_Misc_shiwaixiangen", LocalStringManager.GetConfig("Misc_language", "Desc_148"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_148"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(8, 2),
			new TreasureStateInfo(3, 2),
			new TreasureStateInfo(6, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(149, LocalStringManager.GetConfig("Misc_language", "Name_149"), 12, 1205, 6, 146, "icon_Misc_qicaiwutongjia", LocalStringManager.GetConfig("Misc_language", "Desc_149"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_149"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(8, 1),
			new TreasureStateInfo(3, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(150, LocalStringManager.GetConfig("Misc_language", "Name_150"), 12, 1205, 0, 150, "icon_Misc_junzishipan", LocalStringManager.GetConfig("Misc_language", "Desc_150"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_150"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(13, 2),
			new TreasureStateInfo(1, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(151, LocalStringManager.GetConfig("Misc_language", "Name_151"), 12, 1205, 2, 150, "icon_Misc_baoshiqizi", LocalStringManager.GetConfig("Misc_language", "Desc_151"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_151"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(13, 2),
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(6, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(152, LocalStringManager.GetConfig("Misc_language", "Name_152"), 12, 1205, 4, 150, "icon_Misc_kongmingjing", LocalStringManager.GetConfig("Misc_language", "Desc_152"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_152"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 200, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(13, 2),
			new TreasureStateInfo(1, 2),
			new TreasureStateInfo(6, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(153, LocalStringManager.GetConfig("Misc_language", "Name_153"), 12, 1205, 6, 150, "icon_Misc_fanglüetuiyan", LocalStringManager.GetConfig("Misc_language", "Desc_153"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_153"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(13, 1),
			new TreasureStateInfo(1, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(154, LocalStringManager.GetConfig("Misc_language", "Name_154"), 12, 1205, 0, 154, "icon_Misc_mingjiabeike", LocalStringManager.GetConfig("Misc_language", "Desc_154"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_154"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(7, 2),
			new TreasureStateInfo(4, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(155, LocalStringManager.GetConfig("Misc_language", "Name_155"), 12, 1205, 2, 154, "icon_Misc_shenguituobeixiang", LocalStringManager.GetConfig("Misc_language", "Desc_155"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_155"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1200, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(7, 2),
			new TreasureStateInfo(4, 1),
			new TreasureStateInfo(6, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(156, LocalStringManager.GetConfig("Misc_language", "Name_156"), 12, 1205, 4, 154, "icon_Misc_zhaoyeyueguangdan", LocalStringManager.GetConfig("Misc_language", "Desc_156"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_156"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 50, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(7, 2),
			new TreasureStateInfo(4, 2),
			new TreasureStateInfo(6, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(157, LocalStringManager.GetConfig("Misc_language", "Name_157"), 12, 1205, 6, 154, "icon_Misc_qianshuwanxianggui", LocalStringManager.GetConfig("Misc_language", "Desc_157"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_157"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1500, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(4, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(158, LocalStringManager.GetConfig("Misc_language", "Name_158"), 12, 1205, 0, 158, "icon_Misc_jingseqiangcai", LocalStringManager.GetConfig("Misc_language", "Desc_158"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_158"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 300, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 2),
			new TreasureStateInfo(8, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(159, LocalStringManager.GetConfig("Misc_language", "Name_159"), 12, 1205, 2, 158, "icon_Misc_baiseyanbo", LocalStringManager.GetConfig("Misc_language", "Desc_159"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_159"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 2),
			new TreasureStateInfo(8, 1),
			new TreasureStateInfo(6, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(160, LocalStringManager.GetConfig("Misc_language", "Name_160"), 12, 1205, 4, 158, "icon_Misc_baicaixiangmushi", LocalStringManager.GetConfig("Misc_language", "Desc_160"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_160"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 2),
			new TreasureStateInfo(8, 2),
			new TreasureStateInfo(6, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(161, LocalStringManager.GetConfig("Misc_language", "Name_161"), 12, 1205, 6, 158, "icon_Misc_yujinghuatai", LocalStringManager.GetConfig("Misc_language", "Desc_161"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_161"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(8, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(162, LocalStringManager.GetConfig("Misc_language", "Name_162"), 12, 1205, 0, 162, "icon_Misc_riguixingyi", LocalStringManager.GetConfig("Misc_language", "Desc_162"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_162"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 300, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(13, 1),
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(4, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(163, LocalStringManager.GetConfig("Misc_language", "Name_163"), 12, 1205, 2, 162, "icon_Misc_wangxingzhu", LocalStringManager.GetConfig("Misc_language", "Desc_163"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_163"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 200, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(13, 1),
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(4, 1),
			new TreasureStateInfo(2, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(164, LocalStringManager.GetConfig("Misc_language", "Name_164"), 12, 1205, 4, 162, "icon_Misc_kunlunshanshenxiang", LocalStringManager.GetConfig("Misc_language", "Desc_164"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_164"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(13, 1),
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(4, 1),
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(3, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(165, LocalStringManager.GetConfig("Misc_language", "Name_165"), 12, 1205, 6, 162, "icon_Misc_shengmieliangxingtu", LocalStringManager.GetConfig("Misc_language", "Desc_165"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_165"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(13, 1),
			new TreasureStateInfo(7, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(166, LocalStringManager.GetConfig("Misc_language", "Name_166"), 12, 1205, 0, 166, "icon_Misc_shengxiangnijinlu", LocalStringManager.GetConfig("Misc_language", "Desc_166"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_166"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(14, 1),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(8, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(167, LocalStringManager.GetConfig("Misc_language", "Name_167"), 12, 1205, 2, 166, "icon_Misc_yiyuzhenwan", LocalStringManager.GetConfig("Misc_language", "Desc_167"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_167"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 300, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(14, 1),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(8, 1),
			new TreasureStateInfo(11, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(168, LocalStringManager.GetConfig("Misc_language", "Name_168"), 12, 1205, 4, 166, "icon_Misc_shiwaishanshuidan", LocalStringManager.GetConfig("Misc_language", "Desc_168"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_168"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(14, 2),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(8, 1),
			new TreasureStateInfo(11, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(169, LocalStringManager.GetConfig("Misc_language", "Name_169"), 12, 1205, 6, 166, "icon_Misc_yunlongxuanqingchi", LocalStringManager.GetConfig("Misc_language", "Desc_169"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_169"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(14, 2),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(8, 1),
			new TreasureStateInfo(11, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(170, LocalStringManager.GetConfig("Misc_language", "Name_170"), 12, 1205, 6, 166, "icon_Misc_jinyuchenglupan", LocalStringManager.GetConfig("Misc_language", "Desc_170"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_170"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(14, 2),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(8, 1),
			new TreasureStateInfo(11, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(171, LocalStringManager.GetConfig("Misc_language", "Name_171"), 12, 1205, 0, 171, "icon_Misc_hongluduandatai", LocalStringManager.GetConfig("Misc_language", "Desc_171"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_171"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1500, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(14, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(172, LocalStringManager.GetConfig("Misc_language", "Name_172"), 12, 1205, 2, 171, "icon_Misc_tiantieli", LocalStringManager.GetConfig("Misc_language", "Desc_172"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_172"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 2),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(14, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(173, LocalStringManager.GetConfig("Misc_language", "Name_173"), 12, 1205, 4, 171, "icon_Misc_huanjinsha", LocalStringManager.GetConfig("Misc_language", "Desc_173"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_173"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(14, 1),
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(3, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(174, LocalStringManager.GetConfig("Misc_language", "Name_174"), 12, 1205, 4, 171, "icon_Misc_huahuochenjinchi", LocalStringManager.GetConfig("Misc_language", "Desc_174"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_174"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(14, 1),
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(3, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(175, LocalStringManager.GetConfig("Misc_language", "Name_175"), 12, 1205, 6, 171, "icon_Misc_longwangshuifu", LocalStringManager.GetConfig("Misc_language", "Desc_175"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_175"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(14, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(176, LocalStringManager.GetConfig("Misc_language", "Name_176"), 12, 1205, 7, 171, "icon_Misc_shenhuoluxin", LocalStringManager.GetConfig("Misc_language", "Desc_176"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_176"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 200, 141000, 5, 8, 4500, 8, 0, allowRandomCreate: true, 10, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(7, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(177, LocalStringManager.GetConfig("Misc_language", "Name_177"), 12, 1205, 0, 177, "icon_Misc_zhimubaibao", LocalStringManager.GetConfig("Misc_language", "Desc_177"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_177"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 300, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(12, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(178, LocalStringManager.GetConfig("Misc_language", "Name_178"), 12, 1205, 2, 177, "icon_Misc_touseqiongzhi", LocalStringManager.GetConfig("Misc_language", "Desc_178"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_178"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 200, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(12, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(179, LocalStringManager.GetConfig("Misc_language", "Name_179"), 12, 1205, 4, 177, "icon_Misc_bairenju", LocalStringManager.GetConfig("Misc_language", "Desc_179"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_179"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(3, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new MiscItem(180, LocalStringManager.GetConfig("Misc_language", "Name_180"), 12, 1205, 4, 177, "icon_Misc_panshanshuilong", LocalStringManager.GetConfig("Misc_language", "Desc_180"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_180"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(3, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(181, LocalStringManager.GetConfig("Misc_language", "Name_181"), 12, 1205, 6, 177, "icon_Misc_yingulengyanmei", LocalStringManager.GetConfig("Misc_language", "Desc_181"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_181"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(6, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(182, LocalStringManager.GetConfig("Misc_language", "Name_182"), 12, 1205, 7, 177, "icon_Misc_shenmugen", LocalStringManager.GetConfig("Misc_language", "Desc_182"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_182"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 141000, 5, 8, 4500, 8, 0, allowRandomCreate: true, 10, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(12, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(183, LocalStringManager.GetConfig("Misc_language", "Name_183"), 12, 1205, 0, 183, "icon_Misc_hongmuyaogui", LocalStringManager.GetConfig("Misc_language", "Desc_183"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_183"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1500, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(184, LocalStringManager.GetConfig("Misc_language", "Name_184"), 12, 1205, 2, 183, "icon_Misc_hanyubingguan", LocalStringManager.GetConfig("Misc_language", "Desc_184"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_184"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1500, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(185, LocalStringManager.GetConfig("Misc_language", "Name_185"), 12, 1205, 4, 183, "icon_Misc_sishidingguangzhu", LocalStringManager.GetConfig("Misc_language", "Desc_185"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_185"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(186, LocalStringManager.GetConfig("Misc_language", "Name_186"), 12, 1205, 4, 183, "icon_Misc_tongyuanbaiqiaodan", LocalStringManager.GetConfig("Misc_language", "Desc_186"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_186"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(187, LocalStringManager.GetConfig("Misc_language", "Name_187"), 12, 1205, 6, 183, "icon_Misc_shuihuowuyantan", LocalStringManager.GetConfig("Misc_language", "Desc_187"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_187"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(3, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(188, LocalStringManager.GetConfig("Misc_language", "Name_188"), 12, 1205, 7, 183, "icon_Misc_shennongxie", LocalStringManager.GetConfig("Misc_language", "Desc_188"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_188"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 20, 141000, 5, 8, 4500, 8, 0, allowRandomCreate: true, 10, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(3, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(189, LocalStringManager.GetConfig("Misc_language", "Name_189"), 12, 1205, 0, 189, "icon_Misc_xinglujia", LocalStringManager.GetConfig("Misc_language", "Desc_189"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_189"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(13, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(190, LocalStringManager.GetConfig("Misc_language", "Name_190"), 12, 1205, 2, 189, "icon_Misc_birenxiang", LocalStringManager.GetConfig("Misc_language", "Desc_190"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_190"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(13, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(191, LocalStringManager.GetConfig("Misc_language", "Name_191"), 12, 1205, 4, 189, "icon_Misc_tunguihuazhanglu", LocalStringManager.GetConfig("Misc_language", "Desc_191"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_191"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 200, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(13, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(192, LocalStringManager.GetConfig("Misc_language", "Name_192"), 12, 1205, 4, 189, "icon_Misc_sirenlong", LocalStringManager.GetConfig("Misc_language", "Desc_192"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_192"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(12, 1),
			new TreasureStateInfo(13, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(193, LocalStringManager.GetConfig("Misc_language", "Name_193"), 12, 1205, 6, 189, "icon_Misc_huaxiedan", LocalStringManager.GetConfig("Misc_language", "Desc_193"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_193"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 300, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(12, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(194, LocalStringManager.GetConfig("Misc_language", "Name_194"), 12, 1205, 7, 189, "icon_Misc_qixiangshenlongmu", LocalStringManager.GetConfig("Misc_language", "Desc_194"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_194"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 141000, 5, 8, 4500, 8, 0, allowRandomCreate: true, 10, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(10, 1),
			new TreasureStateInfo(12, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(195, LocalStringManager.GetConfig("Misc_language", "Name_195"), 12, 1205, 0, 195, "icon_Misc_zhijiranliao", LocalStringManager.GetConfig("Misc_language", "Desc_195"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_195"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(10, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(196, LocalStringManager.GetConfig("Misc_language", "Name_196"), 12, 1205, 2, 195, "icon_Misc_xuanshexigu", LocalStringManager.GetConfig("Misc_language", "Desc_196"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_196"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 2),
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(10, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(197, LocalStringManager.GetConfig("Misc_language", "Name_197"), 12, 1205, 4, 195, "icon_Misc_baihuazhongzi", LocalStringManager.GetConfig("Misc_language", "Desc_197"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_197"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 2),
			new TreasureStateInfo(9, 2),
			new TreasureStateInfo(10, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(198, LocalStringManager.GetConfig("Misc_language", "Name_198"), 12, 1205, 4, 195, "icon_Misc_qizhentailuan", LocalStringManager.GetConfig("Misc_language", "Desc_198"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_198"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 200, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 2),
			new TreasureStateInfo(9, 2),
			new TreasureStateInfo(10, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(199, LocalStringManager.GetConfig("Misc_language", "Name_199"), 12, 1205, 6, 195, "icon_Misc_shiersecaican", LocalStringManager.GetConfig("Misc_language", "Desc_199"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_199"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(10, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(200, LocalStringManager.GetConfig("Misc_language", "Name_200"), 12, 1205, 7, 195, "icon_Misc_shencaijingci", LocalStringManager.GetConfig("Misc_language", "Desc_200"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_200"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 100, 141000, 5, 8, 4500, 8, 0, allowRandomCreate: true, 10, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(3, 1),
			new TreasureStateInfo(9, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(201, LocalStringManager.GetConfig("Misc_language", "Name_201"), 12, 1205, 0, 201, "icon_Misc_sanshanmaoshi", LocalStringManager.GetConfig("Misc_language", "Desc_201"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_201"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(10, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(202, LocalStringManager.GetConfig("Misc_language", "Name_202"), 12, 1205, 2, 201, "icon_Misc_huochigongjing", LocalStringManager.GetConfig("Misc_language", "Desc_202"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_202"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(7, 2),
			new TreasureStateInfo(9, 1),
			new TreasureStateInfo(10, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(203, LocalStringManager.GetConfig("Misc_language", "Name_203"), 12, 1205, 4, 201, "icon_Misc_huanbaosha", LocalStringManager.GetConfig("Misc_language", "Desc_203"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_203"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(7, 2),
			new TreasureStateInfo(9, 2),
			new TreasureStateInfo(10, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(204, LocalStringManager.GetConfig("Misc_language", "Name_204"), 12, 1205, 4, 201, "icon_Misc_jingangju", LocalStringManager.GetConfig("Misc_language", "Desc_204"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_204"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(7, 2),
			new TreasureStateInfo(9, 2),
			new TreasureStateInfo(10, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(205, LocalStringManager.GetConfig("Misc_language", "Name_205"), 12, 1205, 6, 201, "icon_Misc_linglongbabao", LocalStringManager.GetConfig("Misc_language", "Desc_205"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_205"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 50, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(10, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(206, LocalStringManager.GetConfig("Misc_language", "Name_206"), 12, 1205, 7, 201, "icon_Misc_qiannianyumu", LocalStringManager.GetConfig("Misc_language", "Desc_206"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_206"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 141000, 5, 8, 4500, 8, 0, allowRandomCreate: true, 10, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(9, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(207, LocalStringManager.GetConfig("Misc_language", "Name_207"), 12, 1205, 0, 207, "icon_Misc_xianghuobeiji", LocalStringManager.GetConfig("Misc_language", "Desc_207"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_207"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(4, 2),
			new TreasureStateInfo(7, 2)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(208, LocalStringManager.GetConfig("Misc_language", "Name_208"), 12, 1205, 2, 207, "icon_Misc_xianshidaocang", LocalStringManager.GetConfig("Misc_language", "Desc_208"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_208"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(4, 1),
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(5, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(209, LocalStringManager.GetConfig("Misc_language", "Name_209"), 12, 1205, 4, 207, "icon_Misc_xianshanyunqi", LocalStringManager.GetConfig("Misc_language", "Desc_209"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_209"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(4, 2),
			new TreasureStateInfo(7, 2),
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(5, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(210, LocalStringManager.GetConfig("Misc_language", "Name_210"), 12, 1205, 6, 207, "icon_Misc_zijinliandanlu", LocalStringManager.GetConfig("Misc_language", "Desc_210"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_210"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(4, 1),
			new TreasureStateInfo(7, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(211, LocalStringManager.GetConfig("Misc_language", "Name_211"), 12, 1205, 0, 211, "icon_Misc_gaosengsheli", LocalStringManager.GetConfig("Misc_language", "Desc_211"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_211"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 20, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 2),
			new TreasureStateInfo(11, 2)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(212, LocalStringManager.GetConfig("Misc_language", "Name_212"), 12, 1205, 2, 211, "icon_Misc_zhixinfoyao", LocalStringManager.GetConfig("Misc_language", "Desc_212"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_212"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 50, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(11, 1),
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(5, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(213, LocalStringManager.GetConfig("Misc_language", "Name_213"), 12, 1205, 4, 211, "icon_Misc_kurongshuangshu", LocalStringManager.GetConfig("Misc_language", "Desc_213"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_213"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(11, 1),
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(5, 1),
			new TreasureStateInfo(15, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(214, LocalStringManager.GetConfig("Misc_language", "Name_214"), 12, 1205, 6, 211, "icon_Misc_sanshiwubuzhenjing", LocalStringManager.GetConfig("Misc_language", "Desc_214"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_214"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(1, 1),
			new TreasureStateInfo(11, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(215, LocalStringManager.GetConfig("Misc_language", "Name_215"), 12, 1205, 0, 215, "icon_Misc_baiqianwanzhan", LocalStringManager.GetConfig("Misc_language", "Desc_215"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_215"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(14, 2),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(2, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(216, LocalStringManager.GetConfig("Misc_language", "Name_216"), 12, 1205, 2, 215, "icon_Misc_tiantiexuanding", LocalStringManager.GetConfig("Misc_language", "Desc_216"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_216"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(14, 1),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(5, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(217, LocalStringManager.GetConfig("Misc_language", "Name_217"), 12, 1205, 4, 215, "icon_Misc_sijiliufeng", LocalStringManager.GetConfig("Misc_language", "Desc_217"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_217"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(14, 2),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(5, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(218, LocalStringManager.GetConfig("Misc_language", "Name_218"), 12, 1205, 4, 215, "icon_Misc_tianchenghuayu", LocalStringManager.GetConfig("Misc_language", "Desc_218"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_218"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(14, 2),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(2, 1),
			new TreasureStateInfo(5, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(219, LocalStringManager.GetConfig("Misc_language", "Name_219"), 12, 1205, 6, 215, "icon_Misc_shuangerwanguohu", LocalStringManager.GetConfig("Misc_language", "Desc_219"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_219"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 300, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(14, 1),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(2, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(220, LocalStringManager.GetConfig("Misc_language", "Name_220"), 12, 1205, 7, 215, "icon_Misc_shuijingbingzhuan", LocalStringManager.GetConfig("Misc_language", "Desc_220"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_220"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 141000, 5, 8, 4500, 8, 0, allowRandomCreate: true, 10, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(14, 1),
			new TreasureStateInfo(6, 1),
			new TreasureStateInfo(2, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(221, LocalStringManager.GetConfig("Misc_language", "Name_221"), 12, 1205, 0, 221, "icon_Misc_jinzhuangyushi", LocalStringManager.GetConfig("Misc_language", "Desc_221"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_221"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 500, 1000, 0, 1, 300, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(11, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(222, LocalStringManager.GetConfig("Misc_language", "Name_222"), 12, 1205, 2, 221, "icon_Misc_xibanxingtou", LocalStringManager.GetConfig("Misc_language", "Desc_222"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_222"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 900, 6000, 0, 3, 900, 5, 0, allowRandomCreate: true, 35, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 1, 2, 3 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(15, 2),
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(11, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(223, LocalStringManager.GetConfig("Misc_language", "Name_223"), 12, 1205, 4, 221, "icon_Misc_mingyuanshanshui", LocalStringManager.GetConfig("Misc_language", "Desc_223"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_223"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 1500, 31000, 2, 5, 2100, 7, 0, allowRandomCreate: true, 25, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 3, 4, 5 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(7, 1),
			new TreasureStateInfo(11, 1),
			new TreasureStateInfo(6, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(224, LocalStringManager.GetConfig("Misc_language", "Name_224"), 12, 1205, 6, 221, "icon_Misc_qihuayidan", LocalStringManager.GetConfig("Misc_language", "Desc_224"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_224"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 600, 92000, 4, 7, 3600, 8, 0, allowRandomCreate: true, 15, isSpecial: false, -1, -1, 120, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int> { 5, 6 }, EMiscGenerateType.Any, new List<TreasureStateInfo>
		{
			new TreasureStateInfo(15, 1),
			new TreasureStateInfo(11, 1)
		}, EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(225, LocalStringManager.GetConfig("Misc_language", "Name_225"), 12, 1205, 8, -1, "icon_Misc_taiwuzupu", LocalStringManager.GetConfig("Misc_language", "Desc_225"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_225"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(226, LocalStringManager.GetConfig("Misc_language", "Name_226"), 12, 1205, 8, -1, "icon_Misc_xiyuditu", LocalStringManager.GetConfig("Misc_language", "Desc_226"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_226"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(227, LocalStringManager.GetConfig("Misc_language", "Name_227"), 12, 1205, 8, -1, "icon_Misc_liudaozhuanlun", LocalStringManager.GetConfig("Misc_language", "Desc_227"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_227"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.KeyItem, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(228, LocalStringManager.GetConfig("Misc_language", "Name_228"), 12, 1205, 0, -1, "icon_Misc_qisetiepan", LocalStringManager.GetConfig("Misc_language", "Desc_228"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_228"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 10, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(229, LocalStringManager.GetConfig("Misc_language", "Name_229"), 12, 1200, 8, 229, "icon_Misc_monvyisuipian", LocalStringManager.GetConfig("Misc_language", "Desc_229"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_229"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 10, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 100, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(230, LocalStringManager.GetConfig("Misc_language", "Name_230"), 12, 1200, 8, 229, "icon_Misc_fuxietiesuipian", LocalStringManager.GetConfig("Misc_language", "Desc_230"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_230"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 80, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 100, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(231, LocalStringManager.GetConfig("Misc_language", "Name_231"), 12, 1200, 8, 229, "icon_Misc_daxuanningsuipian", LocalStringManager.GetConfig("Misc_language", "Desc_231"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_231"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 40, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 100, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(232, LocalStringManager.GetConfig("Misc_language", "Name_232"), 12, 1200, 8, 229, "icon_Misc_fenghuangjiansuipian", LocalStringManager.GetConfig("Misc_language", "Desc_232"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_232"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 50, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 100, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(233, LocalStringManager.GetConfig("Misc_language", "Name_233"), 12, 1200, 8, 229, "icon_Misc_fenshenliansuipian", LocalStringManager.GetConfig("Misc_language", "Desc_233"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_233"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 20, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 100, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(234, LocalStringManager.GetConfig("Misc_language", "Name_234"), 12, 1200, 8, 229, "icon_Misc_jielongbosuipian", LocalStringManager.GetConfig("Misc_language", "Desc_234"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_234"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 60, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 100, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(235, LocalStringManager.GetConfig("Misc_language", "Name_235"), 12, 1200, 8, 229, "icon_Misc_rongchenyinsuipian", LocalStringManager.GetConfig("Misc_language", "Desc_235"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_235"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 10, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 100, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(236, LocalStringManager.GetConfig("Misc_language", "Name_236"), 12, 1200, 8, 229, "icon_Misc_qiumomusuipian", LocalStringManager.GetConfig("Misc_language", "Desc_236"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_236"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 70, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 100, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(237, LocalStringManager.GetConfig("Misc_language", "Name_237"), 12, 1200, 8, 229, "icon_Misc_guishenxiasuipian", LocalStringManager.GetConfig("Misc_language", "Desc_237"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_237"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 10, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 100, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(238, LocalStringManager.GetConfig("Misc_language", "Name_238"), 12, 1200, 8, 229, "icon_Misc_fuyujiansuipian", LocalStringManager.GetConfig("Misc_language", "Desc_238"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_238"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 30, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 100, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(239, LocalStringManager.GetConfig("Misc_language", "Name_239"), 12, 1200, 0, 229, "icon_Misc_fuyujianbing", LocalStringManager.GetConfig("Misc_language", "Desc_239"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_239"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new MiscItem(240, LocalStringManager.GetConfig("Misc_language", "Name_240"), 12, 1202, 8, -1, "icon_Misc_hunxinmozijue", LocalStringManager.GetConfig("Misc_language", "Desc_240"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_240"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(241, LocalStringManager.GetConfig("Misc_language", "Name_241"), 12, 1202, 8, -1, "icon_Misc_baiyixinghuaji", LocalStringManager.GetConfig("Misc_language", "Desc_241"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_241"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(242, LocalStringManager.GetConfig("Misc_language", "Name_242"), 12, 1202, 8, -1, "icon_Misc_daquanqianfa", LocalStringManager.GetConfig("Misc_language", "Desc_242"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_242"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(243, LocalStringManager.GetConfig("Misc_language", "Name_243"), 12, 1202, 8, -1, "icon_Misc_xianglongyanhua", LocalStringManager.GetConfig("Misc_language", "Desc_243"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_243"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(244, LocalStringManager.GetConfig("Misc_language", "Name_244"), 12, 1202, 8, -1, "icon_Misc_xinguancanjian", LocalStringManager.GetConfig("Misc_language", "Desc_244"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_244"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(245, LocalStringManager.GetConfig("Misc_language", "Name_245"), 12, 1202, 8, -1, "icon_Misc_bashanzhibaojing", LocalStringManager.GetConfig("Misc_language", "Desc_245"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_245"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(246, LocalStringManager.GetConfig("Misc_language", "Name_246"), 12, 1202, 8, -1, "icon_Misc_huayingqishu", LocalStringManager.GetConfig("Misc_language", "Desc_246"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_246"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(247, LocalStringManager.GetConfig("Misc_language", "Name_247"), 12, 1202, 8, -1, "icon_Misc_wumingjiandian", LocalStringManager.GetConfig("Misc_language", "Desc_247"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_247"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(248, LocalStringManager.GetConfig("Misc_language", "Name_248"), 12, 1202, 8, -1, "icon_Misc_shishamoluolu", LocalStringManager.GetConfig("Misc_language", "Desc_248"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_248"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(249, LocalStringManager.GetConfig("Misc_language", "Name_249"), 12, 1202, 8, -1, "icon_Misc_yihuakaitian", LocalStringManager.GetConfig("Misc_language", "Desc_249"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_249"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(250, LocalStringManager.GetConfig("Misc_language", "Name_250"), 12, 1202, 8, -1, "icon_Misc_wuxianxuanyuanshu", LocalStringManager.GetConfig("Misc_language", "Desc_250"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_250"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(251, LocalStringManager.GetConfig("Misc_language", "Name_251"), 12, 1202, 8, -1, "icon_Misc_jiusizhencang", LocalStringManager.GetConfig("Misc_language", "Desc_251"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_251"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(252, LocalStringManager.GetConfig("Misc_language", "Name_252"), 12, 1202, 8, -1, "icon_Misc_tiantongshenshu", LocalStringManager.GetConfig("Misc_language", "Desc_252"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_252"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(253, LocalStringManager.GetConfig("Misc_language", "Name_253"), 12, 1202, 8, -1, "icon_Misc_shennvjueyin", LocalStringManager.GetConfig("Misc_language", "Desc_253"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_253"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -99, 0, 0, 0, 36, 21600, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.LegendaryBook, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(254, LocalStringManager.GetConfig("Misc_language", "Name_254"), 12, 1200, 8, -1, "icon_Misc_shenjianlingwen", LocalStringManager.GetConfig("Misc_language", "Desc_254"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_254"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 10, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: true, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Invalid, 12, 11, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(255, LocalStringManager.GetConfig("Misc_language", "Name_255"), 12, 1200, 8, -1, "icon_Misc_huanshelingwen", LocalStringManager.GetConfig("Misc_language", "Desc_255"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_255"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 10, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: true, canTriggerCommonEvent: false, -1, 0, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Invalid, 12, 11, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(256, LocalStringManager.GetConfig("Misc_language", "Name_256"), 12, 1200, 8, -1, "icon_Misc_fucanglingwen", LocalStringManager.GetConfig("Misc_language", "Desc_256"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_256"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 10, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: true, canTriggerCommonEvent: false, -1, 0, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Invalid, 12, 11, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(257, LocalStringManager.GetConfig("Misc_language", "Name_257"), 12, 1200, 8, -1, "icon_Misc_yinshenlingwen", LocalStringManager.GetConfig("Misc_language", "Desc_257"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_257"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 10, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: true, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Invalid, 12, 11, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(258, LocalStringManager.GetConfig("Misc_language", "Name_258"), 12, 1200, 8, -1, "icon_Misc_quliuwulingwen", LocalStringManager.GetConfig("Misc_language", "Desc_258"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_258"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 10, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: true, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Invalid, 12, 11, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(259, LocalStringManager.GetConfig("Misc_language", "Name_259"), 12, 1200, 8, -1, "icon_Misc_shenjianyaowen", LocalStringManager.GetConfig("Misc_language", "Desc_259"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_259"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 10, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: true, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Invalid, 13, 11, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(260, LocalStringManager.GetConfig("Misc_language", "Name_260"), 12, 1200, 8, -1, "icon_Misc_huansheyaowen", LocalStringManager.GetConfig("Misc_language", "Desc_260"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_260"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 10, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: true, canTriggerCommonEvent: false, -1, 0, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Invalid, 13, 11, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(261, LocalStringManager.GetConfig("Misc_language", "Name_261"), 12, 1200, 8, -1, "icon_Misc_fucangyaowen", LocalStringManager.GetConfig("Misc_language", "Desc_261"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_261"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 10, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: true, canTriggerCommonEvent: false, -1, 0, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Invalid, 13, 11, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(262, LocalStringManager.GetConfig("Misc_language", "Name_262"), 12, 1200, 8, -1, "icon_Misc_yinshenyaowen", LocalStringManager.GetConfig("Misc_language", "Desc_262"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_262"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 10, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: true, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Invalid, 13, 11, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(263, LocalStringManager.GetConfig("Misc_language", "Name_263"), 12, 1200, 8, -1, "icon_Misc_quliuwuyaowen", LocalStringManager.GetConfig("Misc_language", "Desc_263"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_263"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 10, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: true, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Invalid, 13, 11, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(264, LocalStringManager.GetConfig("Misc_language", "Name_264"), 12, 1200, 0, -1, "icon_Misc_yanduyinzhen", LocalStringManager.GetConfig("Misc_language", "Desc_264"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_264"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 300, 0, 1, 600, 3, 0, allowRandomCreate: true, 45, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(265, LocalStringManager.GetConfig("Misc_language", "Name_265"), 12, 1200, 8, -1, "icon_Misc_tianjiefulu", LocalStringManager.GetConfig("Misc_language", "Desc_265"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_265"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 0, 0, 0, 0, 0, 1025, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: true, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(266, LocalStringManager.GetConfig("Misc_language", "Name_266"), 12, 1200, 0, 266, "icon_Misc_xinge", LocalStringManager.GetConfig("Misc_language", "Desc_266"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_266"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 10, 100, 0, 0, 600, 3, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 12, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(267, LocalStringManager.GetConfig("Misc_language", "Name_267"), 12, 1207, 8, -1, "icon_Misc_wuyingling", LocalStringManager.GetConfig("Misc_language", "Desc_267"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_267"), transferable: true, stackable: false, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, -7, 10, 61500, 6, 18, 10800, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(268, LocalStringManager.GetConfig("Misc_language", "Name_268"), 12, 1200, 0, -1, "icon_Misc_huanxindexingli", LocalStringManager.GetConfig("Misc_language", "Desc_268"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_268"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 7000, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(269, LocalStringManager.GetConfig("Misc_language", "Name_269"), 12, 1200, 0, -1, "icon_Misc_huanxinxuewutong", LocalStringManager.GetConfig("Misc_language", "Desc_269"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_269"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, 1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(270, LocalStringManager.GetConfig("Misc_language", "Name_270"), 12, 1200, 0, -1, "icon_Misc_shierzhiqingzhuci", LocalStringManager.GetConfig("Misc_language", "Desc_270"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_270"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, 1, 0, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(271, LocalStringManager.GetConfig("Misc_language", "Name_271"), 12, 1200, 0, -1, "icon_Misc_xuxiangongdecanhai", LocalStringManager.GetConfig("Misc_language", "Desc_271"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_271"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(272, LocalStringManager.GetConfig("Misc_language", "Name_272"), 12, 1200, 0, -1, "icon_Misc_laokaodexiaochuan", LocalStringManager.GetConfig("Misc_language", "Desc_272"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_272"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(273, LocalStringManager.GetConfig("Misc_language", "Name_273"), 12, 1200, 8, -1, "icon_Misc_zijinliandanlu", LocalStringManager.GetConfig("Misc_language", "Desc_273"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_273"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(274, LocalStringManager.GetConfig("Misc_language", "Name_274"), 12, 1200, 8, -1, "icon_Misc_qijiexuanzhu", LocalStringManager.GetConfig("Misc_language", "Desc_274"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_274"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, 1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(275, LocalStringManager.GetConfig("Misc_language", "Name_275"), 12, 1200, 8, -1, "icon_Misc_yilvjinsi", LocalStringManager.GetConfig("Misc_language", "Desc_275"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_275"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, -99, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, 0, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short> { 182, 183, 184, 185, 186, 264 }, new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, 6, 4, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(276, LocalStringManager.GetConfig("Misc_language", "Name_276"), 12, 1200, 8, -1, "icon_Misc_longlin", LocalStringManager.GetConfig("Misc_language", "Desc_276"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_276"), transferable: false, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 100, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(277, LocalStringManager.GetConfig("Misc_language", "Name_277"), 12, 1200, 0, 277, "icon_Misc_powan", LocalStringManager.GetConfig("Misc_language", "Desc_277"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_277"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(278, LocalStringManager.GetConfig("Misc_language", "Name_278"), 12, 1200, 1, 277, "icon_Misc_gunang", LocalStringManager.GetConfig("Misc_language", "Desc_278"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_278"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(279, LocalStringManager.GetConfig("Misc_language", "Name_279"), 12, 1200, 2, 277, "icon_Misc_canlv", LocalStringManager.GetConfig("Misc_language", "Desc_279"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_279"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(280, LocalStringManager.GetConfig("Misc_language", "Name_280"), 12, 1200, 3, 277, "icon_Misc_yaodao", LocalStringManager.GetConfig("Misc_language", "Desc_280"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_280"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(281, LocalStringManager.GetConfig("Misc_language", "Name_281"), 12, 1200, 4, 277, "icon_Misc_bimo", LocalStringManager.GetConfig("Misc_language", "Desc_281"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_281"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(282, LocalStringManager.GetConfig("Misc_language", "Name_282"), 12, 1200, 5, 277, "icon_Misc_sanqingling", LocalStringManager.GetConfig("Misc_language", "Desc_282"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_282"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(283, LocalStringManager.GetConfig("Misc_language", "Name_283"), 12, 1200, 6, 277, "icon_Misc_fozhu", LocalStringManager.GetConfig("Misc_language", "Desc_283"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_283"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(284, LocalStringManager.GetConfig("Misc_language", "Name_284"), 12, 1200, 7, 277, "icon_Misc_jinzun", LocalStringManager.GetConfig("Misc_language", "Desc_284"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_284"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(285, LocalStringManager.GetConfig("Misc_language", "Name_285"), 12, 1200, 8, 277, "icon_Misc_yupei", LocalStringManager.GetConfig("Misc_language", "Desc_285"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_285"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(286, LocalStringManager.GetConfig("Misc_language", "Name_286"), 12, 1200, 0, 277, "icon_Misc_beilou", LocalStringManager.GetConfig("Misc_language", "Desc_286"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_286"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(287, LocalStringManager.GetConfig("Misc_language", "Name_287"), 12, 1200, 1, 277, "icon_Misc_liegong", LocalStringManager.GetConfig("Misc_language", "Desc_287"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_287"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(288, LocalStringManager.GetConfig("Misc_language", "Name_288"), 12, 1200, 2, 277, "icon_Misc_tiechui", LocalStringManager.GetConfig("Misc_language", "Desc_288"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_288"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(289, LocalStringManager.GetConfig("Misc_language", "Name_289"), 12, 1200, 3, 277, "icon_Misc_tiebo", LocalStringManager.GetConfig("Misc_language", "Desc_289"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_289"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(290, LocalStringManager.GetConfig("Misc_language", "Name_290"), 12, 1200, 4, 277, "icon_Misc_jiuzhen", LocalStringManager.GetConfig("Misc_language", "Desc_290"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_290"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(291, LocalStringManager.GetConfig("Misc_language", "Name_291"), 12, 1200, 5, 277, "icon_Misc_qiantong", LocalStringManager.GetConfig("Misc_language", "Desc_291"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_291"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(292, LocalStringManager.GetConfig("Misc_language", "Name_292"), 12, 1200, 6, 277, "icon_Misc_suanpan", LocalStringManager.GetConfig("Misc_language", "Desc_292"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_292"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(293, LocalStringManager.GetConfig("Misc_language", "Name_293"), 12, 1200, 7, 277, "icon_Misc_chahu", LocalStringManager.GetConfig("Misc_language", "Desc_293"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_293"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(294, LocalStringManager.GetConfig("Misc_language", "Name_294"), 12, 1200, 8, 277, "icon_Misc_yinshou", LocalStringManager.GetConfig("Misc_language", "Desc_294"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_294"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(295, LocalStringManager.GetConfig("Misc_language", "Name_295"), 12, 1200, 0, 295, "icon_Misc_ganxiexin", LocalStringManager.GetConfig("Misc_language", "Desc_295"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_295"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 300, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(296, LocalStringManager.GetConfig("Misc_language", "Name_296"), 12, 1200, 1, 295, "icon_Misc_ganxiexin", LocalStringManager.GetConfig("Misc_language", "Desc_296"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_296"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 600, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(297, LocalStringManager.GetConfig("Misc_language", "Name_297"), 12, 1200, 2, 295, "icon_Misc_ganxiexin", LocalStringManager.GetConfig("Misc_language", "Desc_297"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_297"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 900, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(298, LocalStringManager.GetConfig("Misc_language", "Name_298"), 12, 1200, 3, 295, "icon_Misc_ganxiexin", LocalStringManager.GetConfig("Misc_language", "Desc_298"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_298"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 1200, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(299, LocalStringManager.GetConfig("Misc_language", "Name_299"), 12, 1200, 4, 295, "icon_Misc_ganxiexin", LocalStringManager.GetConfig("Misc_language", "Desc_299"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_299"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 1500, 0, hasGiftEvent: false));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new MiscItem(300, LocalStringManager.GetConfig("Misc_language", "Name_300"), 12, 1200, 5, 295, "icon_Misc_ganxiexin", LocalStringManager.GetConfig("Misc_language", "Desc_300"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_300"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 1800, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(301, LocalStringManager.GetConfig("Misc_language", "Name_301"), 12, 1200, 6, 295, "icon_Misc_ganxiexin", LocalStringManager.GetConfig("Misc_language", "Desc_301"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_301"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 2100, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(302, LocalStringManager.GetConfig("Misc_language", "Name_302"), 12, 1200, 7, 295, "icon_Misc_ganxiexin", LocalStringManager.GetConfig("Misc_language", "Desc_302"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_302"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 2400, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(303, LocalStringManager.GetConfig("Misc_language", "Name_303"), 12, 1200, 8, 295, "icon_Misc_ganxiexin", LocalStringManager.GetConfig("Misc_language", "Desc_303"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_303"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 2700, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(304, LocalStringManager.GetConfig("Misc_language", "Name_304"), 12, 1200, 5, 304, "icon_Misc_shanyueshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_304"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_304"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 16800, 4, 12, 5400, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(305, LocalStringManager.GetConfig("Misc_language", "Name_305"), 12, 1200, 5, 304, "icon_Misc_dongxueshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_305"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_305"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 16800, 4, 12, 5400, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(306, LocalStringManager.GetConfig("Misc_language", "Name_306"), 12, 1200, 5, 304, "icon_Misc_xiagushenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_306"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_306"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 16800, 4, 12, 5400, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(307, LocalStringManager.GetConfig("Misc_language", "Name_307"), 12, 1200, 5, 304, "icon_Misc_zhaozeshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_307"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_307"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 16800, 4, 12, 5400, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(308, LocalStringManager.GetConfig("Misc_language", "Name_308"), 12, 1200, 5, 304, "icon_Misc_qiulingshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_308"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_308"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 16800, 4, 12, 5400, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(309, LocalStringManager.GetConfig("Misc_language", "Name_309"), 12, 1200, 5, 304, "icon_Misc_taoyuanshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_309"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_309"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 16800, 4, 12, 5400, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(310, LocalStringManager.GetConfig("Misc_language", "Name_310"), 12, 1200, 5, 304, "icon_Misc_yuanyeshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_310"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_310"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 16800, 4, 12, 5400, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(311, LocalStringManager.GetConfig("Misc_language", "Name_311"), 12, 1200, 5, 304, "icon_Misc_huposhenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_311"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_311"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 16800, 4, 12, 5400, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(312, LocalStringManager.GetConfig("Misc_language", "Name_312"), 12, 1200, 5, 304, "icon_Misc_lindishenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_312"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_312"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 16800, 4, 12, 5400, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(313, LocalStringManager.GetConfig("Misc_language", "Name_313"), 12, 1200, 5, 304, "icon_Misc_milinshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_313"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_313"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 16800, 4, 12, 5400, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(314, LocalStringManager.GetConfig("Misc_language", "Name_314"), 12, 1200, 5, 304, "icon_Misc_hetanshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_314"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_314"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 16800, 4, 12, 5400, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(315, LocalStringManager.GetConfig("Misc_language", "Name_315"), 12, 1200, 5, 304, "icon_Misc_xigushenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_315"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_315"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 16800, 4, 12, 5400, 8, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(316, LocalStringManager.GetConfig("Misc_language", "Name_316"), 12, 1200, 5, 316, "icon_Misc_shanyuetongtianshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_316"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_316"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(317, LocalStringManager.GetConfig("Misc_language", "Name_317"), 12, 1200, 5, 316, "icon_Misc_dongxuetongtianshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_317"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_317"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(318, LocalStringManager.GetConfig("Misc_language", "Name_318"), 12, 1200, 5, 316, "icon_Misc_xiagutongtianshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_318"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_318"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(319, LocalStringManager.GetConfig("Misc_language", "Name_319"), 12, 1200, 5, 316, "icon_Misc_zhaozetongtianshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_319"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_319"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(320, LocalStringManager.GetConfig("Misc_language", "Name_320"), 12, 1200, 5, 316, "icon_Misc_qiulingtongtianshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_320"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_320"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(321, LocalStringManager.GetConfig("Misc_language", "Name_321"), 12, 1200, 5, 316, "icon_Misc_taoyuantongtianshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_321"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_321"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(322, LocalStringManager.GetConfig("Misc_language", "Name_322"), 12, 1200, 5, 316, "icon_Misc_yuanyetongtianshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_322"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_322"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(323, LocalStringManager.GetConfig("Misc_language", "Name_323"), 12, 1200, 5, 316, "icon_Misc_hupotongtianshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_323"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_323"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(324, LocalStringManager.GetConfig("Misc_language", "Name_324"), 12, 1200, 5, 316, "icon_Misc_linditongtianshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_324"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_324"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(325, LocalStringManager.GetConfig("Misc_language", "Name_325"), 12, 1200, 5, 316, "icon_Misc_milintongtianshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_325"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_325"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(326, LocalStringManager.GetConfig("Misc_language", "Name_326"), 12, 1200, 5, 316, "icon_Misc_hetantongtianshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_326"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_326"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(327, LocalStringManager.GetConfig("Misc_language", "Name_327"), 12, 1200, 5, 316, "icon_Misc_xigutongtianshenmuzhong", LocalStringManager.GetConfig("Misc_language", "Desc_327"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_327"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(328, LocalStringManager.GetConfig("Misc_language", "Name_328"), 12, 1200, 0, -1, "icon_Misc_angzangdediaoxiang3", LocalStringManager.GetConfig("Misc_language", "Desc_328"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_328"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(329, LocalStringManager.GetConfig("Misc_language", "Name_329"), 12, 1200, 0, -1, "icon_Misc_angzangdediaoxiang", LocalStringManager.GetConfig("Misc_language", "Desc_329"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_329"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(330, LocalStringManager.GetConfig("Misc_language", "Name_330"), 12, 1200, 0, -1, "icon_Misc_angzangdediaoxiang", LocalStringManager.GetConfig("Misc_language", "Desc_330"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_330"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(331, LocalStringManager.GetConfig("Misc_language", "Name_331"), 12, 1200, 0, -1, "icon_Misc_angzangdediaoxiang2", LocalStringManager.GetConfig("Misc_language", "Desc_331"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_331"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(332, LocalStringManager.GetConfig("Misc_language", "Name_332"), 12, 1200, 8, -1, "icon_Misc_zushimiling", LocalStringManager.GetConfig("Misc_language", "Desc_332"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_332"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(333, LocalStringManager.GetConfig("Misc_language", "Name_333"), 12, 1200, 0, -1, "icon_Misc_fuyujiancanpian", LocalStringManager.GetConfig("Misc_language", "Desc_333"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_333"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(334, LocalStringManager.GetConfig("Misc_language", "Name_334"), 12, 1200, 8, -1, "icon_Misc_liujinhuoling", LocalStringManager.GetConfig("Misc_language", "Desc_334"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_334"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(335, LocalStringManager.GetConfig("Misc_language", "Name_335"), 12, 1200, 8, -1, "icon_Misc_qingtongbaojuan", LocalStringManager.GetConfig("Misc_language", "Desc_335"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_335"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(336, LocalStringManager.GetConfig("Misc_language", "Name_336"), 12, 1200, 8, -1, "icon_Misc_wangfangpingfabian", LocalStringManager.GetConfig("Misc_language", "Desc_336"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_336"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(337, LocalStringManager.GetConfig("Misc_language", "Name_337"), 12, 1200, 8, -1, "icon_Misc_taishangyuyiwen", LocalStringManager.GetConfig("Misc_language", "Desc_337"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_337"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(338, LocalStringManager.GetConfig("Misc_language", "Name_338"), 12, 1200, 8, -1, "icon_Misc_huojing", LocalStringManager.GetConfig("Misc_language", "Desc_338"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_338"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(339, LocalStringManager.GetConfig("Misc_language", "Name_339"), 12, 1200, 8, -1, "icon_Misc_xuanzhoujinzhi", LocalStringManager.GetConfig("Misc_language", "Desc_339"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_339"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(340, LocalStringManager.GetConfig("Misc_language", "Name_340"), 12, 1200, 8, -1, "icon_Misc_nanhuozhu", LocalStringManager.GetConfig("Misc_language", "Desc_340"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_340"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(341, LocalStringManager.GetConfig("Misc_language", "Name_341"), 12, 1200, 8, -1, "icon_Misc_jiuchibanfu", LocalStringManager.GetConfig("Misc_language", "Desc_341"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_341"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(342, LocalStringManager.GetConfig("Misc_language", "Name_342"), 12, 1200, 8, -1, "icon_Misc_ziyuhuban", LocalStringManager.GetConfig("Misc_language", "Desc_342"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_342"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(343, LocalStringManager.GetConfig("Misc_language", "Name_343"), 12, 1200, 8, -1, "icon_Misc_xuandanzhishu", LocalStringManager.GetConfig("Misc_language", "Desc_343"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_343"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(344, LocalStringManager.GetConfig("Misc_language", "Name_344"), 12, 1200, 0, -1, "icon_Misc_latadaozhangsuoyiliudebaiyu", LocalStringManager.GetConfig("Misc_language", "Desc_344"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_344"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(345, LocalStringManager.GetConfig("Misc_language", "Name_345"), 12, 1200, 8, -1, "icon_Misc_huanianzhu", LocalStringManager.GetConfig("Misc_language", "Desc_345"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_345"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(346, LocalStringManager.GetConfig("Misc_language", "Name_346"), 12, 1200, 0, -1, "icon_Misc_kailiepuyu", LocalStringManager.GetConfig("Misc_language", "Desc_346"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_346"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(347, LocalStringManager.GetConfig("Misc_language", "Name_347"), 12, 1200, 0, -1, "icon_Misc_duanbingmujian", LocalStringManager.GetConfig("Misc_language", "Desc_347"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_347"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(348, LocalStringManager.GetConfig("Misc_language", "Name_348"), 12, 1200, 0, -1, "icon_Misc_yinyanghetao", LocalStringManager.GetConfig("Misc_language", "Desc_348"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_348"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(349, LocalStringManager.GetConfig("Misc_language", "Name_349"), 12, 1200, 5, -1, "icon_Misc_guluanjingshuiyao", LocalStringManager.GetConfig("Misc_language", "Desc_349"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_349"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(350, LocalStringManager.GetConfig("Misc_language", "Name_350"), 12, 1200, 0, -1, "icon_Misc_tou", LocalStringManager.GetConfig("Misc_language", "Desc_350"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_350"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(351, LocalStringManager.GetConfig("Misc_language", "Name_351"), 12, 1200, 0, -1, "icon_Misc_zuobi", LocalStringManager.GetConfig("Misc_language", "Desc_351"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_351"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(352, LocalStringManager.GetConfig("Misc_language", "Name_352"), 12, 1200, 0, -1, "icon_Misc_youbi", LocalStringManager.GetConfig("Misc_language", "Desc_352"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_352"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(353, LocalStringManager.GetConfig("Misc_language", "Name_353"), 12, 1200, 0, -1, "icon_Misc_zuotui", LocalStringManager.GetConfig("Misc_language", "Desc_353"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_353"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(354, LocalStringManager.GetConfig("Misc_language", "Name_354"), 12, 1200, 0, -1, "icon_Misc_youtui", LocalStringManager.GetConfig("Misc_language", "Desc_354"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_354"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(355, LocalStringManager.GetConfig("Misc_language", "Name_355"), 12, 1200, 0, -1, "icon_Misc_qugan", LocalStringManager.GetConfig("Misc_language", "Desc_355"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_355"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(356, LocalStringManager.GetConfig("Misc_language", "Name_356"), 12, 1200, 0, -1, "icon_Misc_weichengbingren", LocalStringManager.GetConfig("Misc_language", "Desc_356"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_356"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(357, LocalStringManager.GetConfig("Misc_language", "Name_357"), 12, 1200, 0, -1, "icon_Misc_weichengbingren", LocalStringManager.GetConfig("Misc_language", "Desc_357"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_357"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(358, LocalStringManager.GetConfig("Misc_language", "Name_358"), 12, 1200, 0, -1, "icon_Misc_weichengbingren", LocalStringManager.GetConfig("Misc_language", "Desc_358"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_358"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(359, LocalStringManager.GetConfig("Misc_language", "Name_359"), 12, 1200, 0, -1, "icon_Misc_xiyucanjing", LocalStringManager.GetConfig("Misc_language", "Desc_359"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_359"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new MiscItem(360, LocalStringManager.GetConfig("Misc_language", "Name_360"), 12, 1200, 7, -1, "icon_Misc_xiyuzhenjing", LocalStringManager.GetConfig("Misc_language", "Desc_360"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_360"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(361, LocalStringManager.GetConfig("Misc_language", "Name_361"), 12, 1200, 0, -1, "icon_Misc_cuozijiajing", LocalStringManager.GetConfig("Misc_language", "Desc_361"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_361"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(362, LocalStringManager.GetConfig("Misc_language", "Name_362"), 12, 1200, 7, -1, "icon_Misc_dongchuanzhenjing", LocalStringManager.GetConfig("Misc_language", "Desc_362"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_362"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(363, LocalStringManager.GetConfig("Misc_language", "Name_363"), 12, 1200, 0, -1, "icon_Misc_guguaidefopai", LocalStringManager.GetConfig("Misc_language", "Desc_363"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_363"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(364, LocalStringManager.GetConfig("Misc_language", "Name_364"), 12, 1200, 8, -1, "icon_Misc_guxian", LocalStringManager.GetConfig("Misc_language", "Desc_364"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_364"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(365, LocalStringManager.GetConfig("Misc_language", "Name_365"), 12, 1200, 8, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_365"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_365"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(366, LocalStringManager.GetConfig("Misc_language", "Name_366"), 12, 1200, 8, -1, "icon_Misc_qiwenxingdou", LocalStringManager.GetConfig("Misc_language", "Desc_366"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_366"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(367, LocalStringManager.GetConfig("Misc_language", "Name_367"), 12, 1200, 8, -1, "icon_Misc_shangxingguimian", LocalStringManager.GetConfig("Misc_language", "Desc_367"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_367"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(368, LocalStringManager.GetConfig("Misc_language", "Name_368"), 12, 1200, 6, -1, "icon_Misc_yuanjiyu", LocalStringManager.GetConfig("Misc_language", "Desc_368"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_368"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(369, LocalStringManager.GetConfig("Misc_language", "Name_369"), 12, 1200, 8, -1, "icon_Misc_wucaiyuyi", LocalStringManager.GetConfig("Misc_language", "Desc_369"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_369"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: true, 4, 265, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(370, LocalStringManager.GetConfig("Misc_language", "Name_370"), 12, 1200, 0, -1, "icon_Misc_shenjitu", LocalStringManager.GetConfig("Misc_language", "Desc_370"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_370"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 10, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(371, LocalStringManager.GetConfig("Misc_language", "Name_371"), 12, 1200, 0, -1, "icon_Misc_pojiudelingdang", LocalStringManager.GetConfig("Misc_language", "Desc_371"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_371"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(372, LocalStringManager.GetConfig("Misc_language", "Name_372"), 12, 1200, 3, -1, "icon_Misc_gulaodeyubianfu", LocalStringManager.GetConfig("Misc_language", "Desc_372"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_372"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 2000, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(373, LocalStringManager.GetConfig("Misc_language", "Name_373"), 12, 1200, 3, -1, "icon_Misc_gulaodeyuhuli", LocalStringManager.GetConfig("Misc_language", "Desc_373"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_373"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 4000, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(374, LocalStringManager.GetConfig("Misc_language", "Name_374"), 12, 1200, 3, -1, "icon_Misc_gulaodeyuhudie", LocalStringManager.GetConfig("Misc_language", "Desc_374"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_374"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 6000, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(375, LocalStringManager.GetConfig("Misc_language", "Name_375"), 12, 1200, 5, 375, "icon_Misc_jingangmozhu", LocalStringManager.GetConfig("Misc_language", "Desc_375"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_375"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 5600, 2, 0, 5400, 7, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 60, new IntPair(0, 20), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(376, LocalStringManager.GetConfig("Misc_language", "Name_376"), 12, 1200, 5, 375, "icon_Misc_zixiamozhu", LocalStringManager.GetConfig("Misc_language", "Desc_376"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_376"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 5600, 2, 0, 5400, 7, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 60, new IntPair(1, 20), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(377, LocalStringManager.GetConfig("Misc_language", "Name_377"), 12, 1200, 5, 375, "icon_Misc_xuanyinmozhu", LocalStringManager.GetConfig("Misc_language", "Desc_377"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_377"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 5600, 2, 0, 5400, 7, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 60, new IntPair(2, 20), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(378, LocalStringManager.GetConfig("Misc_language", "Name_378"), 12, 1200, 5, 375, "icon_Misc_chunyangmozhu", LocalStringManager.GetConfig("Misc_language", "Desc_378"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_378"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 5600, 2, 0, 5400, 7, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 60, new IntPair(3, 20), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(379, LocalStringManager.GetConfig("Misc_language", "Name_379"), 12, 1200, 5, 375, "icon_Misc_guiyuanmozhu", LocalStringManager.GetConfig("Misc_language", "Desc_379"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_379"), transferable: true, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 10, 5600, 2, 0, 5400, 7, 0, allowRandomCreate: true, 50, isSpecial: false, -1, -1, 1, new List<int>(), -1, 0, 60, new IntPair(4, 20), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(380, LocalStringManager.GetConfig("Misc_language", "Name_380"), 12, 1200, 8, -1, "icon_Misc_qibaohaoyin", LocalStringManager.GetConfig("Misc_language", "Desc_380"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_380"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 6, 0, 50, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(381, LocalStringManager.GetConfig("Misc_language", "Name_381"), 12, 1200, 4, 381, "icon_Misc_jingangcanxi", LocalStringManager.GetConfig("Misc_language", "Desc_381"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_381"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(382, LocalStringManager.GetConfig("Misc_language", "Name_382"), 12, 1200, 4, 381, "icon_Misc_zixiacanxi", LocalStringManager.GetConfig("Misc_language", "Desc_382"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_382"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(383, LocalStringManager.GetConfig("Misc_language", "Name_383"), 12, 1200, 4, 381, "icon_Misc_xuanyincanxi", LocalStringManager.GetConfig("Misc_language", "Desc_383"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_383"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(384, LocalStringManager.GetConfig("Misc_language", "Name_384"), 12, 1200, 4, 381, "icon_Misc_chunyangcanxi", LocalStringManager.GetConfig("Misc_language", "Desc_384"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_384"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(385, LocalStringManager.GetConfig("Misc_language", "Name_385"), 12, 1200, 4, 381, "icon_Misc_guiyuancanxi", LocalStringManager.GetConfig("Misc_language", "Desc_385"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_385"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(386, LocalStringManager.GetConfig("Misc_language", "Name_386"), 12, 1200, 0, -1, "icon_Misc_wuxue", LocalStringManager.GetConfig("Misc_language", "Desc_386"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_386"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(387, LocalStringManager.GetConfig("Misc_language", "Name_387"), 12, 1200, 0, -1, "icon_Misc_jiyi", LocalStringManager.GetConfig("Misc_language", "Desc_387"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_387"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(388, LocalStringManager.GetConfig("Misc_language", "Name_388"), 12, 1200, 0, -1, "icon_Misc_jianwen", LocalStringManager.GetConfig("Misc_language", "Desc_388"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_388"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(389, LocalStringManager.GetConfig("Misc_language", "Name_389"), 12, 1200, 0, -1, "icon_Misc_miwen", LocalStringManager.GetConfig("Misc_language", "Desc_389"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_389"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(390, LocalStringManager.GetConfig("Misc_language", "Name_390"), 12, 1200, 4, -1, "icon_Misc_birenxiang", LocalStringManager.GetConfig("Misc_language", "Desc_390"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_390"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(391, LocalStringManager.GetConfig("Misc_language", "Name_391"), 12, 1200, 4, -1, "icon_Misc_moyingling", LocalStringManager.GetConfig("Misc_language", "Desc_391"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_391"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(392, LocalStringManager.GetConfig("Misc_language", "Name_392"), 12, 1200, 8, -1, "icon_Misc_suopohebaozhu", LocalStringManager.GetConfig("Misc_language", "Desc_392"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_392"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int> { 62 }, -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(393, LocalStringManager.GetConfig("Misc_language", "Name_393"), 12, 1200, 8, -1, "icon_Misc_barebaowu", LocalStringManager.GetConfig("Misc_language", "Desc_393"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_393"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(394, LocalStringManager.GetConfig("Misc_language", "Name_394"), 12, 1200, 8, -1, "icon_Misc_bahanbaowu", LocalStringManager.GetConfig("Misc_language", "Desc_394"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_394"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(395, LocalStringManager.GetConfig("Misc_language", "Name_395"), 12, 1200, 8, -1, "icon_Misc_wujianbaowu", LocalStringManager.GetConfig("Misc_language", "Desc_395"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_395"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(396, LocalStringManager.GetConfig("Misc_language", "Name_396"), 12, 1200, 0, -1, "icon_Misc_yifujiangwuquanzhang", LocalStringManager.GetConfig("Misc_language", "Desc_396"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_396"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: true, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(397, LocalStringManager.GetConfig("Misc_language", "Name_397"), 12, 1200, 0, -1, "icon_Misc_yifujiangwuzhifa", LocalStringManager.GetConfig("Misc_language", "Desc_397"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_397"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: true, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(398, LocalStringManager.GetConfig("Misc_language", "Name_398"), 12, 1200, 0, -1, "icon_Misc_yifujiangwujianfa", LocalStringManager.GetConfig("Misc_language", "Desc_398"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_398"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: true, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(399, LocalStringManager.GetConfig("Misc_language", "Name_399"), 12, 1200, 0, -1, "icon_Misc_yifujiangwudaofa", LocalStringManager.GetConfig("Misc_language", "Desc_399"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_399"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: true, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(400, LocalStringManager.GetConfig("Misc_language", "Name_400"), 12, 1200, 0, -1, "icon_Misc_yifujiangwuchangbing", LocalStringManager.GetConfig("Misc_language", "Desc_400"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_400"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: true, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(401, LocalStringManager.GetConfig("Misc_language", "Name_401"), 12, 1200, 0, -1, "icon_Misc_yifujiangwuanqi", LocalStringManager.GetConfig("Misc_language", "Desc_401"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_401"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: true, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(402, LocalStringManager.GetConfig("Misc_language", "Name_402"), 12, 1200, 0, -1, "icon_Misc_yifujiangwuyushe", LocalStringManager.GetConfig("Misc_language", "Desc_402"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_402"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: true, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(403, LocalStringManager.GetConfig("Misc_language", "Name_403"), 12, 1200, 0, -1, "icon_Misc_yifujiangwuruanbing", LocalStringManager.GetConfig("Misc_language", "Desc_403"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_403"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: true, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(404, LocalStringManager.GetConfig("Misc_language", "Name_404"), 12, 1200, 0, -1, "icon_Misc_yifujiangwuqimen", LocalStringManager.GetConfig("Misc_language", "Desc_404"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_404"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: true, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(405, LocalStringManager.GetConfig("Misc_language", "Name_405"), 12, 1200, 0, -1, "icon_Misc_yifujiangwuyueqi", LocalStringManager.GetConfig("Misc_language", "Desc_405"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_405"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: true, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(406, LocalStringManager.GetConfig("Misc_language", "Name_406"), 12, 1200, 0, -1, "icon_Misc_yifujiangwutuifa", LocalStringManager.GetConfig("Misc_language", "Desc_406"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_406"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: true, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(407, LocalStringManager.GetConfig("Misc_language", "Name_407"), 12, 1200, 0, -1, "icon_Misc_yipinxielou", LocalStringManager.GetConfig("Misc_language", "Desc_407"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_407"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(408, LocalStringManager.GetConfig("Misc_language", "Name_408"), 12, 1200, 8, -1, "icon_Misc_yilvjinsi", LocalStringManager.GetConfig("Misc_language", "Desc_408"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_408"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(409, LocalStringManager.GetConfig("Misc_language", "Name_409"), 12, 1200, 4, 409, "icon_Misc_pagejuezhi", LocalStringManager.GetConfig("Misc_language", "Desc_409"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_409"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(410, LocalStringManager.GetConfig("Misc_language", "Name_410"), 12, 1200, 4, 410, "icon_Misc_pagecloud", LocalStringManager.GetConfig("Misc_language", "Desc_410"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_410"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(411, LocalStringManager.GetConfig("Misc_language", "Name_411"), 12, 1200, 4, 411, "icon_Misc_pagewind", LocalStringManager.GetConfig("Misc_language", "Desc_411"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_411"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(412, LocalStringManager.GetConfig("Misc_language", "Name_412"), 12, 1200, 0, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_412"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_412"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(413, LocalStringManager.GetConfig("Misc_language", "Name_413"), 12, 1200, 1, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_413"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_413"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(414, LocalStringManager.GetConfig("Misc_language", "Name_414"), 12, 1200, 2, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_414"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_414"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(415, LocalStringManager.GetConfig("Misc_language", "Name_415"), 12, 1200, 0, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_415"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_415"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(416, LocalStringManager.GetConfig("Misc_language", "Name_416"), 12, 1200, 1, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_416"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_416"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(417, LocalStringManager.GetConfig("Misc_language", "Name_417"), 12, 1200, 2, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_417"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_417"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(418, LocalStringManager.GetConfig("Misc_language", "Name_418"), 12, 1200, 2, -1, "icon_Misc_tiezhui", LocalStringManager.GetConfig("Misc_language", "Desc_418"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_418"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(419, LocalStringManager.GetConfig("Misc_language", "Name_419"), 12, 1200, 0, -1, "icon_Misc_poyingguangzhen", LocalStringManager.GetConfig("Misc_language", "Desc_419"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_419"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
	}

	private void CreateItems7()
	{
		_dataArray.Add(new MiscItem(420, LocalStringManager.GetConfig("Misc_language", "Name_420"), 12, 1200, 0, -1, "icon_Misc_poyingguangzhen", LocalStringManager.GetConfig("Misc_language", "Desc_420"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_420"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(421, LocalStringManager.GetConfig("Misc_language", "Name_421"), 12, 1200, 0, -1, "icon_Misc_poyingguangzhen", LocalStringManager.GetConfig("Misc_language", "Desc_421"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_421"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(422, LocalStringManager.GetConfig("Misc_language", "Name_422"), 12, 1200, 4, -1, "icon_Misc_yuzhou", LocalStringManager.GetConfig("Misc_language", "Desc_422"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_422"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(423, LocalStringManager.GetConfig("Misc_language", "Name_423"), 12, 1200, 4, -1, "icon_Misc_taofu", LocalStringManager.GetConfig("Misc_language", "Desc_423"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_423"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(424, LocalStringManager.GetConfig("Misc_language", "Name_424"), 12, 1200, 4, -1, "icon_Misc_taohuaniang", LocalStringManager.GetConfig("Misc_language", "Desc_424"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_424"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(425, LocalStringManager.GetConfig("Misc_language", "Name_425"), 12, 1200, 5, -1, "icon_Misc_taohuaniang", LocalStringManager.GetConfig("Misc_language", "Desc_425"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_425"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: true, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(426, LocalStringManager.GetConfig("Misc_language", "Name_426"), 12, 1200, 0, -1, "icon_Misc_gujiangzhanqi", LocalStringManager.GetConfig("Misc_language", "Desc_426"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_426"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(427, LocalStringManager.GetConfig("Misc_language", "Name_427"), 12, 1200, 0, -1, "icon_Misc_powudengzhan", LocalStringManager.GetConfig("Misc_language", "Desc_427"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_427"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(428, LocalStringManager.GetConfig("Misc_language", "Name_428"), 12, 1200, 0, -1, "icon_Misc_tongyongshuye", LocalStringManager.GetConfig("Misc_language", "Desc_428"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_428"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(429, LocalStringManager.GetConfig("Misc_language", "Name_429"), 12, 1200, 0, -1, "icon_Misc_tongyongshuye", LocalStringManager.GetConfig("Misc_language", "Desc_429"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_429"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(430, LocalStringManager.GetConfig("Misc_language", "Name_430"), 12, 1200, 0, -1, "icon_Misc_suiyu", LocalStringManager.GetConfig("Misc_language", "Desc_430"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_430"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(431, LocalStringManager.GetConfig("Misc_language", "Name_431"), 12, 1200, 0, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_431"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_431"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(432, LocalStringManager.GetConfig("Misc_language", "Name_432"), 12, 1200, 0, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_432"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_432"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(433, LocalStringManager.GetConfig("Misc_language", "Name_433"), 12, 1200, 0, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_433"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_433"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(434, LocalStringManager.GetConfig("Misc_language", "Name_434"), 12, 1200, 0, -1, "icon_Misc_kuanbingbishou", LocalStringManager.GetConfig("Misc_language", "Desc_434"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_434"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(435, LocalStringManager.GetConfig("Misc_language", "Name_435"), 12, 1200, 0, -1, "icon_Misc_xiaguanfengdai", LocalStringManager.GetConfig("Misc_language", "Desc_435"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_435"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(436, LocalStringManager.GetConfig("Misc_language", "Name_436"), 12, 1200, 0, -1, "icon_Misc_shangguanhualu", LocalStringManager.GetConfig("Misc_language", "Desc_436"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_436"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(437, LocalStringManager.GetConfig("Misc_language", "Name_437"), 12, 1200, 0, -1, "icon_Misc_cangshanxuejing", LocalStringManager.GetConfig("Misc_language", "Desc_437"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_437"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(438, LocalStringManager.GetConfig("Misc_language", "Name_438"), 12, 1200, 0, -1, "icon_Misc_erhaiyuehua", LocalStringManager.GetConfig("Misc_language", "Desc_438"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_438"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, 1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(439, LocalStringManager.GetConfig("Misc_language", "Name_439"), 12, 1200, 0, -1, "icon_Misc_kunlunyu", LocalStringManager.GetConfig("Misc_language", "Desc_439"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_439"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(440, LocalStringManager.GetConfig("Misc_language", "Name_440"), 12, 1200, 0, -1, "icon_Misc_tinyuantongyao", LocalStringManager.GetConfig("Misc_language", "Desc_440"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_440"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(441, LocalStringManager.GetConfig("Misc_language", "Name_441"), 12, 1200, 0, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_441"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_441"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(442, LocalStringManager.GetConfig("Misc_language", "Name_442"), 12, 1200, 0, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_442"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_442"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(443, LocalStringManager.GetConfig("Misc_language", "Name_443"), 12, 1200, 0, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_443"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_443"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(444, LocalStringManager.GetConfig("Misc_language", "Name_444"), 12, 1200, 0, -1, "icon_Misc_sanyanghuan", LocalStringManager.GetConfig("Misc_language", "Desc_444"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_444"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(445, LocalStringManager.GetConfig("Misc_language", "Name_445"), 12, 1200, 0, -1, "icon_Misc_tianquanping", LocalStringManager.GetConfig("Misc_language", "Desc_445"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_445"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(446, LocalStringManager.GetConfig("Misc_language", "Name_446"), 12, 1200, 0, -1, "icon_Misc_chongdi", LocalStringManager.GetConfig("Misc_language", "Desc_446"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_446"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(447, LocalStringManager.GetConfig("Misc_language", "Name_447"), 12, 1200, 0, -1, "icon_Misc_huazhan", LocalStringManager.GetConfig("Misc_language", "Desc_447"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_447"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(448, LocalStringManager.GetConfig("Misc_language", "Name_448"), 12, 1200, 0, -1, "icon_Misc_qingmingzhu", LocalStringManager.GetConfig("Misc_language", "Desc_448"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_448"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(449, LocalStringManager.GetConfig("Misc_language", "Name_449"), 12, 1200, 0, -1, "icon_Misc_yuqianchabao", LocalStringManager.GetConfig("Misc_language", "Desc_449"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_449"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(450, LocalStringManager.GetConfig("Misc_language", "Name_450"), 12, 1200, 0, -1, "icon_Misc_xiasui", LocalStringManager.GetConfig("Misc_language", "Desc_450"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_450"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(451, LocalStringManager.GetConfig("Misc_language", "Name_451"), 12, 1200, 0, -1, "icon_Misc_yilvchansi", LocalStringManager.GetConfig("Misc_language", "Desc_451"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_451"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(452, LocalStringManager.GetConfig("Misc_language", "Name_452"), 12, 1200, 0, -1, "icon_Misc_xinmaisui", LocalStringManager.GetConfig("Misc_language", "Desc_452"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_452"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(453, LocalStringManager.GetConfig("Misc_language", "Name_453"), 12, 1200, 0, -1, "icon_Misc_xibianyuanshi", LocalStringManager.GetConfig("Misc_language", "Desc_453"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_453"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(454, LocalStringManager.GetConfig("Misc_language", "Name_454"), 12, 1200, 0, -1, "icon_Misc_quduxiangnang", LocalStringManager.GetConfig("Misc_language", "Desc_454"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_454"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(455, LocalStringManager.GetConfig("Misc_language", "Name_455"), 12, 1200, 0, -1, "icon_Misc_fuchawan", LocalStringManager.GetConfig("Misc_language", "Desc_455"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_455"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(456, LocalStringManager.GetConfig("Misc_language", "Name_456"), 12, 1200, 0, -1, "icon_Misc_yibajiusaozhou", LocalStringManager.GetConfig("Misc_language", "Desc_456"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_456"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(457, LocalStringManager.GetConfig("Misc_language", "Name_457"), 12, 1200, 0, -1, "icon_Misc_pinganzhichuan", LocalStringManager.GetConfig("Misc_language", "Desc_457"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_457"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(458, LocalStringManager.GetConfig("Misc_language", "Name_458"), 12, 1200, 0, -1, "icon_Misc_sancailouping", LocalStringManager.GetConfig("Misc_language", "Desc_458"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_458"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(459, LocalStringManager.GetConfig("Misc_language", "Name_459"), 12, 1200, 0, -1, "icon_Misc_jiyuehongye", LocalStringManager.GetConfig("Misc_language", "Desc_459"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_459"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(460, LocalStringManager.GetConfig("Misc_language", "Name_460"), 12, 1200, 0, -1, "icon_Misc_yizhiwanju", LocalStringManager.GetConfig("Misc_language", "Desc_460"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_460"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(461, LocalStringManager.GetConfig("Misc_language", "Name_461"), 12, 1200, 0, -1, "icon_Misc_shidi", LocalStringManager.GetConfig("Misc_language", "Desc_461"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_461"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(462, LocalStringManager.GetConfig("Misc_language", "Name_462"), 12, 1200, 0, -1, "icon_Misc_xiaoxiaoganmianzhang", LocalStringManager.GetConfig("Misc_language", "Desc_462"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_462"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(463, LocalStringManager.GetConfig("Misc_language", "Name_463"), 12, 1200, 0, -1, "icon_Misc_yixiaotanyancai", LocalStringManager.GetConfig("Misc_language", "Desc_463"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_463"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(464, LocalStringManager.GetConfig("Misc_language", "Name_464"), 12, 1200, 0, -1, "icon_Misc_nuantan", LocalStringManager.GetConfig("Misc_language", "Desc_464"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_464"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(465, LocalStringManager.GetConfig("Misc_language", "Name_465"), 12, 1200, 0, -1, "icon_Misc_xiaotangyuanmo", LocalStringManager.GetConfig("Misc_language", "Desc_465"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_465"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(466, LocalStringManager.GetConfig("Misc_language", "Name_466"), 12, 1200, 0, -1, "icon_Misc_lingnmeihuaya", LocalStringManager.GetConfig("Misc_language", "Desc_466"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_466"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(467, LocalStringManager.GetConfig("Misc_language", "Name_467"), 12, 1200, 0, -1, "icon_Misc_huiqibao", LocalStringManager.GetConfig("Misc_language", "Desc_467"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_467"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 1500, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(468, LocalStringManager.GetConfig("Misc_language", "Name_468"), 12, 1200, 0, -1, "icon_Misc_fengmaqi", LocalStringManager.GetConfig("Misc_language", "Desc_468"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_468"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(469, LocalStringManager.GetConfig("Misc_language", "Name_469"), 12, 1200, 0, -1, "icon_Misc_tongpai", LocalStringManager.GetConfig("Misc_language", "Desc_469"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_469"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(470, LocalStringManager.GetConfig("Misc_language", "Name_470"), 12, 1200, 4, -1, "icon_Misc_gaojipoyingguangzhen", LocalStringManager.GetConfig("Misc_language", "Desc_470"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_470"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(471, LocalStringManager.GetConfig("Misc_language", "Name_471"), 12, 1200, 4, -1, "icon_Misc_kailiepuyu", LocalStringManager.GetConfig("Misc_language", "Desc_471"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_471"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(472, LocalStringManager.GetConfig("Misc_language", "Name_472"), 12, 1200, 0, -1, "icon_Misc_jnjl_yuer_1", LocalStringManager.GetConfig("Misc_language", "Desc_472"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_472"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(473, LocalStringManager.GetConfig("Misc_language", "Name_473"), 12, 1200, 0, -1, "icon_Misc_jnjl_yuer_2", LocalStringManager.GetConfig("Misc_language", "Desc_473"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_473"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(474, LocalStringManager.GetConfig("Misc_language", "Name_474"), 12, 1200, 0, -1, "icon_Misc_jnjl_yuer_3", LocalStringManager.GetConfig("Misc_language", "Desc_474"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_474"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(475, LocalStringManager.GetConfig("Misc_language", "Name_475"), 12, 1200, 0, -1, null, LocalStringManager.GetConfig("Misc_language", "Desc_475"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_475"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(476, LocalStringManager.GetConfig("Misc_language", "Name_476"), 12, 1200, 0, -1, "icon_Medicine_liedu", LocalStringManager.GetConfig("Misc_language", "Desc_476"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_476"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(477, LocalStringManager.GetConfig("Misc_language", "Name_477"), 12, 1200, 0, -1, "icon_Medicine_yudu", LocalStringManager.GetConfig("Misc_language", "Desc_477"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_477"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(478, LocalStringManager.GetConfig("Misc_language", "Name_478"), 12, 1200, 0, -1, "icon_Medicine_handu", LocalStringManager.GetConfig("Misc_language", "Desc_478"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_478"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(479, LocalStringManager.GetConfig("Misc_language", "Name_479"), 12, 1200, 0, -1, "icon_Medicine_chidu", LocalStringManager.GetConfig("Misc_language", "Desc_479"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_479"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
	}

	private void CreateItems8()
	{
		_dataArray.Add(new MiscItem(480, LocalStringManager.GetConfig("Misc_language", "Name_480"), 12, 1200, 0, -1, "icon_Medicine_fudu", LocalStringManager.GetConfig("Misc_language", "Desc_480"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_480"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(481, LocalStringManager.GetConfig("Misc_language", "Name_481"), 12, 1200, 0, -1, "icon_Medicine_huandu", LocalStringManager.GetConfig("Misc_language", "Desc_481"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_481"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(482, LocalStringManager.GetConfig("Misc_language", "Name_482"), 12, 1200, 0, -1, "icon_Medicine_neishang", LocalStringManager.GetConfig("Misc_language", "Desc_482"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_482"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(483, LocalStringManager.GetConfig("Misc_language", "Name_483"), 12, 1200, 0, -1, "icon_Medicine_waishang", LocalStringManager.GetConfig("Misc_language", "Desc_483"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_483"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 10, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Resource, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(484, LocalStringManager.GetConfig("Misc_language", "Name_484"), 12, 1200, 0, -1, "icon_Misc_jnjl_yuer_4", LocalStringManager.GetConfig("Misc_language", "Desc_484"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_484"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(485, LocalStringManager.GetConfig("Misc_language", "Name_485"), 12, 1200, 0, -1, "icon_Misc_flyaway_shizi", LocalStringManager.GetConfig("Misc_language", "Desc_485"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_485"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(486, LocalStringManager.GetConfig("Misc_language", "Name_486"), 12, 1200, 0, -1, "icon_Misc_flyaway_yexingyi", LocalStringManager.GetConfig("Misc_language", "Desc_486"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_486"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(487, LocalStringManager.GetConfig("Misc_language", "Name_487"), 12, 1200, 0, -1, "icon_Misc_wuxinghuolingzhu", LocalStringManager.GetConfig("Misc_language", "Desc_487"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_487"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(488, LocalStringManager.GetConfig("Misc_language", "Name_488"), 12, 1200, 0, -1, "icon_Misc_wuxingjinglingzhu", LocalStringManager.GetConfig("Misc_language", "Desc_488"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_488"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(489, LocalStringManager.GetConfig("Misc_language", "Name_489"), 12, 1200, 0, -1, "icon_Misc_wuxingmulingzhu", LocalStringManager.GetConfig("Misc_language", "Desc_489"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_489"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(490, LocalStringManager.GetConfig("Misc_language", "Name_490"), 12, 1200, 0, -1, "icon_Misc_wuxingtulingzhu", LocalStringManager.GetConfig("Misc_language", "Desc_490"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_490"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(491, LocalStringManager.GetConfig("Misc_language", "Name_491"), 12, 1200, 0, -1, "icon_Misc_wuxingshuilingzhu", LocalStringManager.GetConfig("Misc_language", "Desc_491"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_491"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(492, LocalStringManager.GetConfig("Misc_language", "Name_492"), 12, 1200, 0, -1, "icon_Misc_dingxindan", LocalStringManager.GetConfig("Misc_language", "Desc_492"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_492"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(493, LocalStringManager.GetConfig("Misc_language", "Name_493"), 12, 1200, 0, -1, "icon_Misc_huaxingfu", LocalStringManager.GetConfig("Misc_language", "Desc_493"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_493"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(494, LocalStringManager.GetConfig("Misc_language", "Name_494"), 12, 1200, 0, -1, "icon_Misc_yinshenfu", LocalStringManager.GetConfig("Misc_language", "Desc_494"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_494"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(495, LocalStringManager.GetConfig("Misc_language", "Name_495"), 12, 1200, 0, -1, "icon_Misc_huosufu", LocalStringManager.GetConfig("Misc_language", "Desc_495"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_495"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(496, LocalStringManager.GetConfig("Misc_language", "Name_496"), 12, 1200, 0, -1, "icon_Misc_tieyifu", LocalStringManager.GetConfig("Misc_language", "Desc_496"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_496"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(497, LocalStringManager.GetConfig("Misc_language", "Name_497"), 12, 1200, 0, -1, "icon_Misc_wulouchanzhu", LocalStringManager.GetConfig("Misc_language", "Desc_497"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_497"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(498, LocalStringManager.GetConfig("Misc_language", "Name_498"), 12, 1200, 0, -1, "icon_Misc_traptool", LocalStringManager.GetConfig("Misc_language", "Desc_498"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_498"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(499, LocalStringManager.GetConfig("Misc_language", "Name_499"), 12, 1200, 0, -1, "icon_Misc_warehousekey", LocalStringManager.GetConfig("Misc_language", "Desc_499"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_499"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(500, LocalStringManager.GetConfig("Misc_language", "Name_500"), 12, 1200, 0, -1, "icon_Misc_tongyongshuye", LocalStringManager.GetConfig("Misc_language", "Desc_500"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_500"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(501, LocalStringManager.GetConfig("Misc_language", "Name_501"), 12, 1200, 0, -1, "icon_Misc_tongyongshuye", LocalStringManager.GetConfig("Misc_language", "Desc_501"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_501"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(502, LocalStringManager.GetConfig("Misc_language", "Name_502"), 12, 1200, 0, -1, "icon_Misc_tongyongshuye", LocalStringManager.GetConfig("Misc_language", "Desc_502"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_502"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(503, LocalStringManager.GetConfig("Misc_language", "Name_503"), 12, 1200, 0, -1, "icon_Misc_tongyongshuye", LocalStringManager.GetConfig("Misc_language", "Desc_503"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_503"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(504, LocalStringManager.GetConfig("Misc_language", "Name_504"), 12, 1200, 0, -1, "icon_Misc_tongyongshuye", LocalStringManager.GetConfig("Misc_language", "Desc_504"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_504"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(505, LocalStringManager.GetConfig("Misc_language", "Name_505"), 12, 1200, 0, -1, "icon_Misc_tongyongshuye", LocalStringManager.GetConfig("Misc_language", "Desc_505"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_505"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(506, LocalStringManager.GetConfig("Misc_language", "Name_506"), 12, 1200, 0, -1, "icon_Misc_shenjitu", LocalStringManager.GetConfig("Misc_language", "Desc_506"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_506"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(507, LocalStringManager.GetConfig("Misc_language", "Name_507"), 12, 1200, 0, -1, "icon_Misc_shenguangzhili", LocalStringManager.GetConfig("Misc_language", "Desc_507"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_507"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(508, LocalStringManager.GetConfig("Misc_language", "Name_508"), 12, 1200, 0, -1, "icon_Misc_huoba", LocalStringManager.GetConfig("Misc_language", "Desc_508"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_508"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(509, LocalStringManager.GetConfig("Misc_language", "Name_509"), 12, 1200, 8, -1, "icon_Misc_qisetiepan", LocalStringManager.GetConfig("Misc_language", "Desc_509"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_509"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(510, LocalStringManager.GetConfig("Misc_language", "Name_510"), 12, 1200, 0, -1, "icon_Misc_cansunjujian", LocalStringManager.GetConfig("Misc_language", "Desc_510"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_510"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 600, 0, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int> { 168 }, -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(511, LocalStringManager.GetConfig("Misc_language", "Name_511"), 12, 1200, 8, -1, "icon_Misc_zhenjieyusui", LocalStringManager.GetConfig("Misc_language", "Desc_511"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_511"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(512, LocalStringManager.GetConfig("Misc_language", "Name_512"), 12, 1200, 8, -1, "icon_Misc_juenianniwan", LocalStringManager.GetConfig("Misc_language", "Desc_512"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_512"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: true, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: true));
		_dataArray.Add(new MiscItem(513, LocalStringManager.GetConfig("Misc_language", "Name_513"), 12, 1200, 0, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_513"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_513"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 300, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(514, LocalStringManager.GetConfig("Misc_language", "Name_514"), 12, 1200, 0, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_514"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_514"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 300, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(515, LocalStringManager.GetConfig("Misc_language", "Name_515"), 12, 1200, 0, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_515"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_515"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 300, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(516, LocalStringManager.GetConfig("Misc_language", "Name_516"), 12, 1200, 1, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_516"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_516"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 900, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(517, LocalStringManager.GetConfig("Misc_language", "Name_517"), 12, 1200, 1, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_517"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_517"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 900, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(518, LocalStringManager.GetConfig("Misc_language", "Name_518"), 12, 1200, 1, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_518"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_518"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 900, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(519, LocalStringManager.GetConfig("Misc_language", "Name_519"), 12, 1200, 2, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_519"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_519"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 2700, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(520, LocalStringManager.GetConfig("Misc_language", "Name_520"), 12, 1200, 3, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_520"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_520"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 8100, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(521, LocalStringManager.GetConfig("Misc_language", "Name_521"), 12, 1200, 4, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_521"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_521"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 24300, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(522, LocalStringManager.GetConfig("Misc_language", "Name_522"), 12, 1200, 0, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_522"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_522"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 300, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(523, LocalStringManager.GetConfig("Misc_language", "Name_523"), 12, 1200, 0, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_523"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_523"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 300, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(524, LocalStringManager.GetConfig("Misc_language", "Name_524"), 12, 1200, 0, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_524"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_524"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 300, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(525, LocalStringManager.GetConfig("Misc_language", "Name_525"), 12, 1200, 1, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_525"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_525"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 900, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(526, LocalStringManager.GetConfig("Misc_language", "Name_526"), 12, 1200, 1, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_526"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_526"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 900, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(527, LocalStringManager.GetConfig("Misc_language", "Name_527"), 12, 1200, 1, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_527"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_527"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 900, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(528, LocalStringManager.GetConfig("Misc_language", "Name_528"), 12, 1200, 2, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_528"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_528"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 2700, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(529, LocalStringManager.GetConfig("Misc_language", "Name_529"), 12, 1200, 3, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_529"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_529"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 8100, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(530, LocalStringManager.GetConfig("Misc_language", "Name_530"), 12, 1200, 4, -1, "icon_Misc_changsheng", LocalStringManager.GetConfig("Misc_language", "Desc_530"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_530"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: true, 0, 30, 24300, 0, 0, 50, 8, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 20, 1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, 80, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(531, LocalStringManager.GetConfig("Misc_language", "Name_531"), 12, 1200, 6, -1, "icon_Misc_barehuiyan", LocalStringManager.GetConfig("Misc_language", "Desc_531"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_531"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 218700, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(532, LocalStringManager.GetConfig("Misc_language", "Name_532"), 12, 1200, 6, -1, "icon_Misc_bahanhuiyan", LocalStringManager.GetConfig("Misc_language", "Desc_532"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_532"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 218700, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(533, LocalStringManager.GetConfig("Misc_language", "Name_533"), 12, 1200, 6, -1, "icon_Misc_wujianhuiyan", LocalStringManager.GetConfig("Misc_language", "Desc_533"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_533"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 218700, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: false, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(534, LocalStringManager.GetConfig("Misc_language", "Name_534"), 12, 1200, 8, -1, "icon_Misc_fenchen", LocalStringManager.GetConfig("Misc_language", "Desc_534"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_534"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 50, 8, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(535, LocalStringManager.GetConfig("Misc_language", "Name_535"), 12, 1200, 8, -1, "icon_Misc_luanxinglinlangzhu", LocalStringManager.GetConfig("Misc_language", "Desc_535"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_535"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(536, LocalStringManager.GetConfig("Misc_language", "Name_536"), 12, 1200, 0, -1, "icon_Misc_anmenyaoshi", LocalStringManager.GetConfig("Misc_language", "Desc_536"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_536"), transferable: false, stackable: true, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: true, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(537, LocalStringManager.GetConfig("Misc_language", "Name_537"), 12, 1200, 8, -1, "icon_Misc_xuxiangongdeluwei", LocalStringManager.GetConfig("Misc_language", "Desc_537"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_537"), transferable: false, stackable: false, wagerable: false, refinable: false, poisonable: false, repairable: false, inheritable: false, consumable: false, 0, 0, 0, 0, 0, 0, 0, 0, allowRandomCreate: false, 0, isSpecial: true, -1, -1, -1, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
		_dataArray.Add(new MiscItem(538, LocalStringManager.GetConfig("Misc_language", "Name_538"), 12, 1200, 8, -1, "icon_Misc_yilvjinsi", LocalStringManager.GetConfig("Misc_language", "Desc_538"), LocalStringManager.GetConfig("Misc_language", "FunctionDesc_538"), transferable: true, stackable: true, wagerable: true, refinable: false, poisonable: false, repairable: false, inheritable: true, consumable: false, 0, 0, 61500, 6, 18, 10800, 8, 0, allowRandomCreate: true, 5, isSpecial: false, -1, -1, 36, new List<int>(), -1, 0, 0, new IntPair(0, 0), 0, 0, -1, canUseOnPrepareCombat: false, allowUseInPlayAndTest: false, canTriggerCommonEvent: false, -1, 60, new List<short>(), new List<int>(), EMiscGenerateType.Invalid, new List<TreasureStateInfo>(), EMiscResourceMaterialType.Invalid, EMiscFilterType.Other, -1, -1, 0, 0, hasGiftEvent: false));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<MiscItem>(539);
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

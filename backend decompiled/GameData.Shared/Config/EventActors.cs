using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class EventActors : ConfigData<EventActorsItem, short>
{
	public static class DefKey
	{
		public const short NestBoy = 0;

		public const short NestGirl = 1;

		public const short NestChild = 2;

		public const short NestWoman = 3;

		public const short LostWife = 4;

		public const short LostChildMine = 5;

		public const short LostHusband = 6;

		public const short LostHusMom = 7;

		public const short LostChildHis = 8;

		public const short PassByMan = 9;

		public const short PassByWoman = 10;

		public const short HelperShaolin = 11;

		public const short HelperEmei = 12;

		public const short HelperBaihua = 13;

		public const short HelperWudang = 14;

		public const short HelperYuanshan = 15;

		public const short HelperShixiang = 16;

		public const short HelperRanshan = 17;

		public const short HelperXuannv = 18;

		public const short HelperZhujian = 19;

		public const short HelperKongsang = 20;

		public const short HelperJingang = 21;

		public const short HelperWuxian = 22;

		public const short HelperJieqing = 23;

		public const short HelperFulong = 24;

		public const short HelperXuehou = 25;

		public const short PoisonPassBy = 26;

		public const short PoisonPrincess = 27;

		public const short PoisonOld = 28;

		public const short PoisonSick = 29;

		public const short PoisonCutter = 30;

		public const short PoisonBoy = 31;

		public const short MarriageServant = 32;

		public const short MarriageOldMan = 33;

		public const short MarriageOldWoman = 34;

		public const short MarriageBrother = 35;

		public const short MarriageSister = 36;

		public const short MarriageEServant = 37;

		public const short MarriageCuiE = 38;

		public const short MarriageHerdsman = 39;

		public const short MarriageGuide = 40;

		public const short MarriageFamilyHolder = 41;

		public const short MarriageWizard = 42;

		public const short MarriageStoler = 43;

		public const short MarriageGoodPerson = 44;

		public const short MarriageBadPerson = 45;

		public const short MarriageWoman = 46;

		public const short MarriageChild = 47;

		public const short MarriageHunterOld = 48;

		public const short MarriageNobleWoman = 49;

		public const short MarriageMoonOld = 50;

		public const short MarriageTeller = 51;

		public const short MarriageMakerLow = 52;

		public const short MarriageMakerMiddle = 53;

		public const short MarriageMakerHigh = 54;

		public const short MarriageCambel = 55;

		public const short MarriageEvenKeeper = 56;

		public const short MarriageJustKeeper = 57;

		public const short MarriageKindKeeper = 58;

		public const short MarriageRebelKeeper = 59;

		public const short MarriageGoisticKeeper = 60;

		public const short MarriageLocal = 61;

		public const short SectGuideShaolin = 62;

		public const short SectGuideEmei = 63;

		public const short SectGuideBaihua = 64;

		public const short SectGuideWudang = 65;

		public const short SectGuideYuanshan = 66;

		public const short SectGuideShixiang = 67;

		public const short SectGuideRanshan = 68;

		public const short SectGuideXuannv = 69;

		public const short SectGuideZhujian = 70;

		public const short SectGuideKongsang = 71;

		public const short SectGuideJingang = 72;

		public const short SectGuideWuxian = 73;

		public const short SectGuideJieqing = 74;

		public const short SectGuideFulong = 75;

		public const short SectGuideXuehou = 76;

		public const short BuildingGuideZhujian = 77;

		public const short MarriageMaid = 78;

		public const short JianghuActor = 79;

		public const short BookShopActor = 80;

		public const short WeaponShopActor = 81;

		public const short AccessoryShopActor = 82;

		public const short ConstructionShopActor = 83;

		public const short MaterialShopActor = 84;

		public const short FoodShopActor = 85;

		public const short CricketConferenceGuide = 86;

		public const short CricketBusinessman = 87;

		public const short CricketOldMan = 88;

		public const short SectSickShaolin = 89;

		public const short SectSickEmei = 90;

		public const short SectSickBaihua = 91;

		public const short SectSickWudang = 92;

		public const short SectSickYuanshan = 93;

		public const short SectSickShixiang = 94;

		public const short SectSickRanshan = 95;

		public const short SectSickXuannv = 96;

		public const short SectSickZhujian = 97;

		public const short SectSickKongsang = 98;

		public const short SectSickJingang = 99;

		public const short SectSickWuxian = 100;

		public const short SectSickJieqing = 101;

		public const short SectSickFulong = 102;

		public const short SectSickXuehou = 103;

		public const short Beggar = 104;

		public const short SectMainStoryKongsang = 105;

		public const short SectMainStoryXuannv = 106;

		public const short SectMainStoryShaolin0 = 107;

		public const short SectMainStoryShaolin1 = 108;

		public const short SectMainStoryShaolin3 = 328;

		public const short SectMainStoryXuehou0 = 109;

		public const short SectMainStoryXuehou1 = 110;

		public const short SectMainStoryWudang1 = 111;

		public const short SectMainStoryWudang2 = 112;

		public const short SectMainStoryWudang3 = 113;

		public const short SectMainStoryWudang4 = 114;

		public const short SectMainStoryWudang5 = 115;

		public const short SectMainStoryWudang6 = 116;

		public const short SectMainStoryWudang7 = 117;

		public const short SectMainStoryWudang8 = 118;

		public const short SectMainStoryWudang9 = 119;

		public const short SectMainStoryWudang10 = 120;

		public const short SectMainStoryXuehou2 = 121;

		public const short SectMainStoryXuehou3 = 122;

		public const short SectMainStoryXuehou4 = 123;

		public const short SectMainStoryRanshan = 124;

		public const short SectMainStoryWudang11 = 125;

		public const short SectMainStoryShixiang1 = 126;

		public const short SectMainStoryShixiang2 = 127;

		public const short SectMainStoryKongsangActingHead = 128;

		public const short SectMainStoryShaolin2 = 129;

		public const short SectMainStoryShixiang3 = 130;

		public const short SectMainStoryShixiang4 = 131;

		public const short SectMainStoryShixiang5 = 132;

		public const short SectMainStoryWudangChengzhu = 133;

		public const short SectMainStoryWudangTraveller = 134;

		public const short SectMainStoryWudangDrunkard = 135;

		public const short SectMainStoryWudangLittleTaoistMonk = 136;

		public const short SectMainStoryWudangDuck = 137;

		public const short SectMainStoryXuannv1 = 138;

		public const short SectMainStoryXuannv2 = 139;

		public const short SectMainStoryEmei0 = 140;

		public const short SectMainStoryEmei1 = 141;

		public const short SectMainStoryEmei2 = 142;

		public const short SectMainStoryEmei3 = 143;

		public const short SectMainStoryEmei4 = 144;

		public const short SectMainStoryEmei5 = 145;

		public const short SectMainStoryEmei6 = 146;

		public const short SectMainStoryEmei7 = 147;

		public const short SectMainStoryXuannvShadowOfMirror = 148;

		public const short SectMainStoryEmeiGibbonShadow = 149;

		public const short SectMainStoryEmeiShadows = 150;

		public const short SectMainStoryXuannvGirl = 151;

		public const short CrossArchiveShadow = 152;

		public const short CrossArchiveArchitect = 153;

		public const short DLCLoongKeeperBrother = 154;

		public const short DLCLoongKeeperSister = 155;

		public const short SectMainStoryWuxianGirlInMist = 156;

		public const short SectMainStoryJingangResident = 157;

		public const short SectMainStoryJingangExorcist = 158;

		public const short SectMainStoryJingangGhost = 159;

		public const short SectMainStoryJingangSoul = 160;

		public const short SectMainStoryWuxianGrandma = 161;

		public const short SectMainStoryWuxianLady = 162;

		public const short SectMainStoryWuxianTeenager = 163;

		public const short SectMainStoryWuxianYouth = 164;

		public const short SectMainStoryWuxianPoisonOld = 165;

		public const short SectMainStoryRanshan0 = 166;

		public const short SectMainStoryRanshan1 = 167;

		public const short SectMainStoryRanshan2 = 168;

		public const short SectMainStoryRanshan3 = 169;

		public const short SectMainStoryRanshan4 = 170;

		public const short SectMainStoryRanshan5 = 171;

		public const short SectMainStoryRanshan6 = 172;

		public const short SectMainStoryRanshan7 = 173;

		public const short SectMainStoryRanshan8 = 174;

		public const short SectMainStoryRanshan9 = 175;

		public const short SectMainStoryRanshan10 = 176;

		public const short SectMainStoryBaihuaGuard0 = 177;

		public const short SectMainStoryBaihuaGuard1 = 178;

		public const short SectMainStoryBaihuaShadowFengqing = 179;

		public const short SectMainStoryBaihuaShadowHuanxin = 180;

		public const short SectMainStoryBaihuaShadowXiangshu = 181;

		public const short SectMainStoryBaihuaShadowAnonymMale = 182;

		public const short SectMainStoryBaihuaShadowAnonymFemale = 183;

		public const short SectMainStoryBaihuaFengqing = 184;

		public const short SectMainStoryBaihuaAnonymMaleRelieved = 185;

		public const short SectMainStoryBaihuaAnonymFemaleRelieved = 186;

		public const short SectMainStoryAnonymMale = 187;

		public const short SectMainStoryAnonymFemale = 188;

		public const short SectMainStoryRanshan11 = 189;

		public const short SectMainStoryRanshan12 = 190;

		public const short SectMainStoryRanshan13 = 191;

		public const short SectMainStoryRanshan14 = 192;

		public const short SectMainStoryRanshan15 = 193;

		public const short SectMainStoryRanshan16 = 194;

		public const short SectMainStoryRanshan17 = 195;

		public const short SectMainStoryRanshan18 = 196;

		public const short SectMainStoryRanshan19 = 197;

		public const short SectMainStoryRanshan20 = 198;

		public const short SectMainStoryRanshan21 = 199;

		public const short SectMainStoryRanshan22 = 200;

		public const short SectMainStoryRanshan23 = 201;

		public const short SectMainStoryRanshan24 = 202;

		public const short SectMainStoryRanshan25 = 203;

		public const short SectMainStoryFulongUsher = 204;

		public const short SectMainStoryFulongMaskedWoman = 205;

		public const short SectMainStoryFulongLazuliForm = 206;

		public const short ChickenClever0 = 207;

		public const short ChickenClever1 = 208;

		public const short ChickenClever2 = 209;

		public const short ChickenClever3 = 210;

		public const short ChickenClever4 = 211;

		public const short ChickenClever5 = 212;

		public const short ChickenClever6 = 213;

		public const short ChickenClever7 = 214;

		public const short ChickenClever8 = 215;

		public const short ChickenLucky0 = 216;

		public const short ChickenLucky1 = 217;

		public const short ChickenLucky2 = 218;

		public const short ChickenLucky3 = 219;

		public const short ChickenLucky4 = 220;

		public const short ChickenLucky5 = 221;

		public const short ChickenLucky6 = 222;

		public const short ChickenLucky7 = 223;

		public const short ChickenLucky8 = 224;

		public const short ChickenPerceptive0 = 225;

		public const short ChickenPerceptive1 = 226;

		public const short ChickenPerceptive2 = 227;

		public const short ChickenPerceptive3 = 228;

		public const short ChickenPerceptive4 = 229;

		public const short ChickenPerceptive5 = 230;

		public const short ChickenPerceptive6 = 231;

		public const short ChickenPerceptive7 = 232;

		public const short ChickenPerceptive8 = 233;

		public const short ChickenFirm0 = 234;

		public const short ChickenFirm1 = 235;

		public const short ChickenFirm2 = 236;

		public const short ChickenFirm3 = 237;

		public const short ChickenFirm4 = 238;

		public const short ChickenFirm5 = 239;

		public const short ChickenFirm6 = 240;

		public const short ChickenFirm7 = 241;

		public const short ChickenFirm8 = 242;

		public const short ChickenCalm0 = 243;

		public const short ChickenCalm1 = 244;

		public const short ChickenCalm2 = 245;

		public const short ChickenCalm3 = 246;

		public const short ChickenCalm4 = 247;

		public const short ChickenCalm5 = 248;

		public const short ChickenCalm6 = 249;

		public const short ChickenCalm7 = 250;

		public const short ChickenCalm8 = 251;

		public const short ChickenEnthusiastic0 = 252;

		public const short ChickenEnthusiastic1 = 253;

		public const short ChickenEnthusiastic2 = 254;

		public const short ChickenEnthusiastic3 = 255;

		public const short ChickenEnthusiastic4 = 256;

		public const short ChickenEnthusiastic5 = 257;

		public const short ChickenEnthusiastic6 = 258;

		public const short ChickenEnthusiastic7 = 259;

		public const short ChickenEnthusiastic8 = 260;

		public const short ChickenBrave0 = 261;

		public const short ChickenBrave1 = 262;

		public const short ChickenBrave2 = 263;

		public const short ChickenBrave3 = 264;

		public const short ChickenBrave4 = 265;

		public const short ChickenBrave5 = 266;

		public const short ChickenBrave6 = 267;

		public const short ChickenBrave7 = 268;

		public const short ChickenBrave8 = 269;

		public const short TaiWuVillager = 270;

		public const short HeadOfTongsheng = 271;

		public const short Ouyezi = 272;

		public const short ShadowOfHeavenlyLord = 273;

		public const short SectMainStoryZhujian1 = 274;

		public const short SectMainStoryZhujian2 = 275;

		public const short SectMainStoryZhujian3 = 276;

		public const short SectMainStoryZhujian4 = 277;

		public const short SectMainStoryZhujian5 = 278;

		public const short SectMainStoryZhujian6 = 279;

		public const short GeneralShaolinMember = 280;

		public const short GeneralEmeiMember = 281;

		public const short GeneraBaihuaMember = 282;

		public const short GeneralWudangMember = 283;

		public const short GeneralYuanshanMember = 284;

		public const short GeneralShixiangMember = 285;

		public const short GeneralRanshanMember = 286;

		public const short GeneralXuannvMember = 287;

		public const short GeneralZhujianMember = 288;

		public const short GeneralKongsangMember = 289;

		public const short GeneralJingangMember = 290;

		public const short GeneralWuxianMember = 291;

		public const short GeneralJieqingMember = 292;

		public const short GeneralFulongMember = 293;

		public const short GeneralXuehouMember = 294;

		public const short RemakeEmeiJefferyi = 295;

		public const short SectMainStoryYuanshan1 = 296;

		public const short SectMainStoryYuanshan2 = 297;

		public const short SectMainStoryYuanshan3 = 298;

		public const short SectMainStoryYuanshan4 = 299;

		public const short SectMainStoryYuanshan5 = 300;

		public const short SectMainStoryYuanshan6 = 301;

		public const short SectMainStoryYuanshan7 = 302;

		public const short SectMainStoryYuanshan8 = 303;

		public const short SectMainStoryYuanshan9 = 304;

		public const short SectMainStoryYuanshan10 = 305;

		public const short SectMainStoryYuanshan11 = 306;

		public const short SectMainStoryYuanshan12 = 307;

		public const short SectMainStoryYuanshan13 = 308;

		public const short SectMainStoryYuanshan14 = 309;

		public const short SectMainStoryYuanshanSeven0 = 310;

		public const short SectMainStoryYuanshanSeven1 = 311;

		public const short SectMainStoryWudangBaby = 312;

		public const short SectMainStoryWuxianGuxian = 313;

		public const short SectMainStoryXuehouDianxiaoer = 314;

		public const short SectMainStoryShixiangFeishi1 = 315;

		public const short SectMainStoryShixiangFeishi2 = 316;

		public const short SectMainStoryShixiangFeishi3 = 317;

		public const short SectMainStoryYuanshanShuoshuren = 318;

		public const short SectMainStoryRanshanGhost1 = 319;

		public const short SectMainStoryRanshanGhost2 = 320;

		public const short SectMainStoryRanshanGhost3 = 321;

		public const short Messenger = 322;

		public const short MainStoryHumanImmortalXu = 323;

		public const short MainStoryPureFireShadow = 324;

		public const short MainStoryEvilShadow = 325;

		public const short MainStoryBlackSmithShadow = 326;

		public const short MainStoryAlchemist = 327;

		public const short MainStoryPangu = 329;

		public const short MainStoryTiandi = 330;

		public const short MainStoryFuxi0 = 331;

		public const short MainStoryFuxi1 = 332;

		public const short MainStoryNvwa0 = 333;

		public const short MainStoryNvwa1 = 334;

		public const short MainStoryXiangshu = 335;

		public const short MainStoryDivineflameDayueSword = 336;

		public const short MainStoryDivineflameLonghun = 337;

		public const short MainStoryDivineflameXueshannvshen = 338;

		public const short MainStoryDivineflameXuenvQingling = 339;

		public const short MainStoryDivineflameChouhu = 340;

		public const short MainStoryDivineflameDuzhaifu = 341;

		public const short MainStoryDivineflameJianmuling = 342;

		public const short MainStoryDivineflameShengren = 343;

		public const short MainStoryDivineflameHuanggubo = 344;

		public const short MainStoryDivineflameHuanggubonvzixingtai = 345;

		public const short MainStoryDivineflameMonvxiaoniao = 346;

		public const short SectMainStoryJieqingOldman = 347;

		public const short SectMainStoryJieqingBai = 348;

		public const short SectMainStoryJieqing1 = 349;

		public const short SectMainStoryJieqing2 = 350;

		public const short SectMainStoryJieqing3 = 351;

		public const short SectMainStoryJieqing4 = 352;

		public const short SectMainStoryJieqingWudang1 = 353;

		public const short SectMainStoryJieqingWudang2 = 354;

		public const short JieqingActingHead = 355;

		public const short MainStoryDivineflameChiyou = 356;

		public const short MainStoryJianghuHermit = 363;

		public const short MainStoryMindAvatar = 364;

		public const short MainStoryLittleTaoist = 365;

		public const short MainStoryDivineflameChuniaojinhuanger = 366;

		public const short SectMainStoryEmeiXiake1 = 367;

		public const short SectMainStoryEmeiXiake2 = 368;

		public const short SectMainStoryEmeiActingHead = 369;

		public const short SectMainStoryEmeiEscapeMember = 370;

		public const short SectMainStoryEmeiPlayingKid = 371;
	}

	public static class DefValue
	{
		public static EventActorsItem NestBoy => Instance[(short)0];

		public static EventActorsItem NestGirl => Instance[(short)1];

		public static EventActorsItem NestChild => Instance[(short)2];

		public static EventActorsItem NestWoman => Instance[(short)3];

		public static EventActorsItem LostWife => Instance[(short)4];

		public static EventActorsItem LostChildMine => Instance[(short)5];

		public static EventActorsItem LostHusband => Instance[(short)6];

		public static EventActorsItem LostHusMom => Instance[(short)7];

		public static EventActorsItem LostChildHis => Instance[(short)8];

		public static EventActorsItem PassByMan => Instance[(short)9];

		public static EventActorsItem PassByWoman => Instance[(short)10];

		public static EventActorsItem HelperShaolin => Instance[(short)11];

		public static EventActorsItem HelperEmei => Instance[(short)12];

		public static EventActorsItem HelperBaihua => Instance[(short)13];

		public static EventActorsItem HelperWudang => Instance[(short)14];

		public static EventActorsItem HelperYuanshan => Instance[(short)15];

		public static EventActorsItem HelperShixiang => Instance[(short)16];

		public static EventActorsItem HelperRanshan => Instance[(short)17];

		public static EventActorsItem HelperXuannv => Instance[(short)18];

		public static EventActorsItem HelperZhujian => Instance[(short)19];

		public static EventActorsItem HelperKongsang => Instance[(short)20];

		public static EventActorsItem HelperJingang => Instance[(short)21];

		public static EventActorsItem HelperWuxian => Instance[(short)22];

		public static EventActorsItem HelperJieqing => Instance[(short)23];

		public static EventActorsItem HelperFulong => Instance[(short)24];

		public static EventActorsItem HelperXuehou => Instance[(short)25];

		public static EventActorsItem PoisonPassBy => Instance[(short)26];

		public static EventActorsItem PoisonPrincess => Instance[(short)27];

		public static EventActorsItem PoisonOld => Instance[(short)28];

		public static EventActorsItem PoisonSick => Instance[(short)29];

		public static EventActorsItem PoisonCutter => Instance[(short)30];

		public static EventActorsItem PoisonBoy => Instance[(short)31];

		public static EventActorsItem MarriageServant => Instance[(short)32];

		public static EventActorsItem MarriageOldMan => Instance[(short)33];

		public static EventActorsItem MarriageOldWoman => Instance[(short)34];

		public static EventActorsItem MarriageBrother => Instance[(short)35];

		public static EventActorsItem MarriageSister => Instance[(short)36];

		public static EventActorsItem MarriageEServant => Instance[(short)37];

		public static EventActorsItem MarriageCuiE => Instance[(short)38];

		public static EventActorsItem MarriageHerdsman => Instance[(short)39];

		public static EventActorsItem MarriageGuide => Instance[(short)40];

		public static EventActorsItem MarriageFamilyHolder => Instance[(short)41];

		public static EventActorsItem MarriageWizard => Instance[(short)42];

		public static EventActorsItem MarriageStoler => Instance[(short)43];

		public static EventActorsItem MarriageGoodPerson => Instance[(short)44];

		public static EventActorsItem MarriageBadPerson => Instance[(short)45];

		public static EventActorsItem MarriageWoman => Instance[(short)46];

		public static EventActorsItem MarriageChild => Instance[(short)47];

		public static EventActorsItem MarriageHunterOld => Instance[(short)48];

		public static EventActorsItem MarriageNobleWoman => Instance[(short)49];

		public static EventActorsItem MarriageMoonOld => Instance[(short)50];

		public static EventActorsItem MarriageTeller => Instance[(short)51];

		public static EventActorsItem MarriageMakerLow => Instance[(short)52];

		public static EventActorsItem MarriageMakerMiddle => Instance[(short)53];

		public static EventActorsItem MarriageMakerHigh => Instance[(short)54];

		public static EventActorsItem MarriageCambel => Instance[(short)55];

		public static EventActorsItem MarriageEvenKeeper => Instance[(short)56];

		public static EventActorsItem MarriageJustKeeper => Instance[(short)57];

		public static EventActorsItem MarriageKindKeeper => Instance[(short)58];

		public static EventActorsItem MarriageRebelKeeper => Instance[(short)59];

		public static EventActorsItem MarriageGoisticKeeper => Instance[(short)60];

		public static EventActorsItem MarriageLocal => Instance[(short)61];

		public static EventActorsItem SectGuideShaolin => Instance[(short)62];

		public static EventActorsItem SectGuideEmei => Instance[(short)63];

		public static EventActorsItem SectGuideBaihua => Instance[(short)64];

		public static EventActorsItem SectGuideWudang => Instance[(short)65];

		public static EventActorsItem SectGuideYuanshan => Instance[(short)66];

		public static EventActorsItem SectGuideShixiang => Instance[(short)67];

		public static EventActorsItem SectGuideRanshan => Instance[(short)68];

		public static EventActorsItem SectGuideXuannv => Instance[(short)69];

		public static EventActorsItem SectGuideZhujian => Instance[(short)70];

		public static EventActorsItem SectGuideKongsang => Instance[(short)71];

		public static EventActorsItem SectGuideJingang => Instance[(short)72];

		public static EventActorsItem SectGuideWuxian => Instance[(short)73];

		public static EventActorsItem SectGuideJieqing => Instance[(short)74];

		public static EventActorsItem SectGuideFulong => Instance[(short)75];

		public static EventActorsItem SectGuideXuehou => Instance[(short)76];

		public static EventActorsItem BuildingGuideZhujian => Instance[(short)77];

		public static EventActorsItem MarriageMaid => Instance[(short)78];

		public static EventActorsItem JianghuActor => Instance[(short)79];

		public static EventActorsItem BookShopActor => Instance[(short)80];

		public static EventActorsItem WeaponShopActor => Instance[(short)81];

		public static EventActorsItem AccessoryShopActor => Instance[(short)82];

		public static EventActorsItem ConstructionShopActor => Instance[(short)83];

		public static EventActorsItem MaterialShopActor => Instance[(short)84];

		public static EventActorsItem FoodShopActor => Instance[(short)85];

		public static EventActorsItem CricketConferenceGuide => Instance[(short)86];

		public static EventActorsItem CricketBusinessman => Instance[(short)87];

		public static EventActorsItem CricketOldMan => Instance[(short)88];

		public static EventActorsItem SectSickShaolin => Instance[(short)89];

		public static EventActorsItem SectSickEmei => Instance[(short)90];

		public static EventActorsItem SectSickBaihua => Instance[(short)91];

		public static EventActorsItem SectSickWudang => Instance[(short)92];

		public static EventActorsItem SectSickYuanshan => Instance[(short)93];

		public static EventActorsItem SectSickShixiang => Instance[(short)94];

		public static EventActorsItem SectSickRanshan => Instance[(short)95];

		public static EventActorsItem SectSickXuannv => Instance[(short)96];

		public static EventActorsItem SectSickZhujian => Instance[(short)97];

		public static EventActorsItem SectSickKongsang => Instance[(short)98];

		public static EventActorsItem SectSickJingang => Instance[(short)99];

		public static EventActorsItem SectSickWuxian => Instance[(short)100];

		public static EventActorsItem SectSickJieqing => Instance[(short)101];

		public static EventActorsItem SectSickFulong => Instance[(short)102];

		public static EventActorsItem SectSickXuehou => Instance[(short)103];

		public static EventActorsItem Beggar => Instance[(short)104];

		public static EventActorsItem SectMainStoryKongsang => Instance[(short)105];

		public static EventActorsItem SectMainStoryXuannv => Instance[(short)106];

		public static EventActorsItem SectMainStoryShaolin0 => Instance[(short)107];

		public static EventActorsItem SectMainStoryShaolin1 => Instance[(short)108];

		public static EventActorsItem SectMainStoryShaolin3 => Instance[(short)328];

		public static EventActorsItem SectMainStoryXuehou0 => Instance[(short)109];

		public static EventActorsItem SectMainStoryXuehou1 => Instance[(short)110];

		public static EventActorsItem SectMainStoryWudang1 => Instance[(short)111];

		public static EventActorsItem SectMainStoryWudang2 => Instance[(short)112];

		public static EventActorsItem SectMainStoryWudang3 => Instance[(short)113];

		public static EventActorsItem SectMainStoryWudang4 => Instance[(short)114];

		public static EventActorsItem SectMainStoryWudang5 => Instance[(short)115];

		public static EventActorsItem SectMainStoryWudang6 => Instance[(short)116];

		public static EventActorsItem SectMainStoryWudang7 => Instance[(short)117];

		public static EventActorsItem SectMainStoryWudang8 => Instance[(short)118];

		public static EventActorsItem SectMainStoryWudang9 => Instance[(short)119];

		public static EventActorsItem SectMainStoryWudang10 => Instance[(short)120];

		public static EventActorsItem SectMainStoryXuehou2 => Instance[(short)121];

		public static EventActorsItem SectMainStoryXuehou3 => Instance[(short)122];

		public static EventActorsItem SectMainStoryXuehou4 => Instance[(short)123];

		public static EventActorsItem SectMainStoryRanshan => Instance[(short)124];

		public static EventActorsItem SectMainStoryWudang11 => Instance[(short)125];

		public static EventActorsItem SectMainStoryShixiang1 => Instance[(short)126];

		public static EventActorsItem SectMainStoryShixiang2 => Instance[(short)127];

		public static EventActorsItem SectMainStoryKongsangActingHead => Instance[(short)128];

		public static EventActorsItem SectMainStoryShaolin2 => Instance[(short)129];

		public static EventActorsItem SectMainStoryShixiang3 => Instance[(short)130];

		public static EventActorsItem SectMainStoryShixiang4 => Instance[(short)131];

		public static EventActorsItem SectMainStoryShixiang5 => Instance[(short)132];

		public static EventActorsItem SectMainStoryWudangChengzhu => Instance[(short)133];

		public static EventActorsItem SectMainStoryWudangTraveller => Instance[(short)134];

		public static EventActorsItem SectMainStoryWudangDrunkard => Instance[(short)135];

		public static EventActorsItem SectMainStoryWudangLittleTaoistMonk => Instance[(short)136];

		public static EventActorsItem SectMainStoryWudangDuck => Instance[(short)137];

		public static EventActorsItem SectMainStoryXuannv1 => Instance[(short)138];

		public static EventActorsItem SectMainStoryXuannv2 => Instance[(short)139];

		public static EventActorsItem SectMainStoryEmei0 => Instance[(short)140];

		public static EventActorsItem SectMainStoryEmei1 => Instance[(short)141];

		public static EventActorsItem SectMainStoryEmei2 => Instance[(short)142];

		public static EventActorsItem SectMainStoryEmei3 => Instance[(short)143];

		public static EventActorsItem SectMainStoryEmei4 => Instance[(short)144];

		public static EventActorsItem SectMainStoryEmei5 => Instance[(short)145];

		public static EventActorsItem SectMainStoryEmei6 => Instance[(short)146];

		public static EventActorsItem SectMainStoryEmei7 => Instance[(short)147];

		public static EventActorsItem SectMainStoryXuannvShadowOfMirror => Instance[(short)148];

		public static EventActorsItem SectMainStoryEmeiGibbonShadow => Instance[(short)149];

		public static EventActorsItem SectMainStoryEmeiShadows => Instance[(short)150];

		public static EventActorsItem SectMainStoryXuannvGirl => Instance[(short)151];

		public static EventActorsItem CrossArchiveShadow => Instance[(short)152];

		public static EventActorsItem CrossArchiveArchitect => Instance[(short)153];

		public static EventActorsItem DLCLoongKeeperBrother => Instance[(short)154];

		public static EventActorsItem DLCLoongKeeperSister => Instance[(short)155];

		public static EventActorsItem SectMainStoryWuxianGirlInMist => Instance[(short)156];

		public static EventActorsItem SectMainStoryJingangResident => Instance[(short)157];

		public static EventActorsItem SectMainStoryJingangExorcist => Instance[(short)158];

		public static EventActorsItem SectMainStoryJingangGhost => Instance[(short)159];

		public static EventActorsItem SectMainStoryJingangSoul => Instance[(short)160];

		public static EventActorsItem SectMainStoryWuxianGrandma => Instance[(short)161];

		public static EventActorsItem SectMainStoryWuxianLady => Instance[(short)162];

		public static EventActorsItem SectMainStoryWuxianTeenager => Instance[(short)163];

		public static EventActorsItem SectMainStoryWuxianYouth => Instance[(short)164];

		public static EventActorsItem SectMainStoryWuxianPoisonOld => Instance[(short)165];

		public static EventActorsItem SectMainStoryRanshan0 => Instance[(short)166];

		public static EventActorsItem SectMainStoryRanshan1 => Instance[(short)167];

		public static EventActorsItem SectMainStoryRanshan2 => Instance[(short)168];

		public static EventActorsItem SectMainStoryRanshan3 => Instance[(short)169];

		public static EventActorsItem SectMainStoryRanshan4 => Instance[(short)170];

		public static EventActorsItem SectMainStoryRanshan5 => Instance[(short)171];

		public static EventActorsItem SectMainStoryRanshan6 => Instance[(short)172];

		public static EventActorsItem SectMainStoryRanshan7 => Instance[(short)173];

		public static EventActorsItem SectMainStoryRanshan8 => Instance[(short)174];

		public static EventActorsItem SectMainStoryRanshan9 => Instance[(short)175];

		public static EventActorsItem SectMainStoryRanshan10 => Instance[(short)176];

		public static EventActorsItem SectMainStoryBaihuaGuard0 => Instance[(short)177];

		public static EventActorsItem SectMainStoryBaihuaGuard1 => Instance[(short)178];

		public static EventActorsItem SectMainStoryBaihuaShadowFengqing => Instance[(short)179];

		public static EventActorsItem SectMainStoryBaihuaShadowHuanxin => Instance[(short)180];

		public static EventActorsItem SectMainStoryBaihuaShadowXiangshu => Instance[(short)181];

		public static EventActorsItem SectMainStoryBaihuaShadowAnonymMale => Instance[(short)182];

		public static EventActorsItem SectMainStoryBaihuaShadowAnonymFemale => Instance[(short)183];

		public static EventActorsItem SectMainStoryBaihuaFengqing => Instance[(short)184];

		public static EventActorsItem SectMainStoryBaihuaAnonymMaleRelieved => Instance[(short)185];

		public static EventActorsItem SectMainStoryBaihuaAnonymFemaleRelieved => Instance[(short)186];

		public static EventActorsItem SectMainStoryAnonymMale => Instance[(short)187];

		public static EventActorsItem SectMainStoryAnonymFemale => Instance[(short)188];

		public static EventActorsItem SectMainStoryRanshan11 => Instance[(short)189];

		public static EventActorsItem SectMainStoryRanshan12 => Instance[(short)190];

		public static EventActorsItem SectMainStoryRanshan13 => Instance[(short)191];

		public static EventActorsItem SectMainStoryRanshan14 => Instance[(short)192];

		public static EventActorsItem SectMainStoryRanshan15 => Instance[(short)193];

		public static EventActorsItem SectMainStoryRanshan16 => Instance[(short)194];

		public static EventActorsItem SectMainStoryRanshan17 => Instance[(short)195];

		public static EventActorsItem SectMainStoryRanshan18 => Instance[(short)196];

		public static EventActorsItem SectMainStoryRanshan19 => Instance[(short)197];

		public static EventActorsItem SectMainStoryRanshan20 => Instance[(short)198];

		public static EventActorsItem SectMainStoryRanshan21 => Instance[(short)199];

		public static EventActorsItem SectMainStoryRanshan22 => Instance[(short)200];

		public static EventActorsItem SectMainStoryRanshan23 => Instance[(short)201];

		public static EventActorsItem SectMainStoryRanshan24 => Instance[(short)202];

		public static EventActorsItem SectMainStoryRanshan25 => Instance[(short)203];

		public static EventActorsItem SectMainStoryFulongUsher => Instance[(short)204];

		public static EventActorsItem SectMainStoryFulongMaskedWoman => Instance[(short)205];

		public static EventActorsItem SectMainStoryFulongLazuliForm => Instance[(short)206];

		public static EventActorsItem ChickenClever0 => Instance[(short)207];

		public static EventActorsItem ChickenClever1 => Instance[(short)208];

		public static EventActorsItem ChickenClever2 => Instance[(short)209];

		public static EventActorsItem ChickenClever3 => Instance[(short)210];

		public static EventActorsItem ChickenClever4 => Instance[(short)211];

		public static EventActorsItem ChickenClever5 => Instance[(short)212];

		public static EventActorsItem ChickenClever6 => Instance[(short)213];

		public static EventActorsItem ChickenClever7 => Instance[(short)214];

		public static EventActorsItem ChickenClever8 => Instance[(short)215];

		public static EventActorsItem ChickenLucky0 => Instance[(short)216];

		public static EventActorsItem ChickenLucky1 => Instance[(short)217];

		public static EventActorsItem ChickenLucky2 => Instance[(short)218];

		public static EventActorsItem ChickenLucky3 => Instance[(short)219];

		public static EventActorsItem ChickenLucky4 => Instance[(short)220];

		public static EventActorsItem ChickenLucky5 => Instance[(short)221];

		public static EventActorsItem ChickenLucky6 => Instance[(short)222];

		public static EventActorsItem ChickenLucky7 => Instance[(short)223];

		public static EventActorsItem ChickenLucky8 => Instance[(short)224];

		public static EventActorsItem ChickenPerceptive0 => Instance[(short)225];

		public static EventActorsItem ChickenPerceptive1 => Instance[(short)226];

		public static EventActorsItem ChickenPerceptive2 => Instance[(short)227];

		public static EventActorsItem ChickenPerceptive3 => Instance[(short)228];

		public static EventActorsItem ChickenPerceptive4 => Instance[(short)229];

		public static EventActorsItem ChickenPerceptive5 => Instance[(short)230];

		public static EventActorsItem ChickenPerceptive6 => Instance[(short)231];

		public static EventActorsItem ChickenPerceptive7 => Instance[(short)232];

		public static EventActorsItem ChickenPerceptive8 => Instance[(short)233];

		public static EventActorsItem ChickenFirm0 => Instance[(short)234];

		public static EventActorsItem ChickenFirm1 => Instance[(short)235];

		public static EventActorsItem ChickenFirm2 => Instance[(short)236];

		public static EventActorsItem ChickenFirm3 => Instance[(short)237];

		public static EventActorsItem ChickenFirm4 => Instance[(short)238];

		public static EventActorsItem ChickenFirm5 => Instance[(short)239];

		public static EventActorsItem ChickenFirm6 => Instance[(short)240];

		public static EventActorsItem ChickenFirm7 => Instance[(short)241];

		public static EventActorsItem ChickenFirm8 => Instance[(short)242];

		public static EventActorsItem ChickenCalm0 => Instance[(short)243];

		public static EventActorsItem ChickenCalm1 => Instance[(short)244];

		public static EventActorsItem ChickenCalm2 => Instance[(short)245];

		public static EventActorsItem ChickenCalm3 => Instance[(short)246];

		public static EventActorsItem ChickenCalm4 => Instance[(short)247];

		public static EventActorsItem ChickenCalm5 => Instance[(short)248];

		public static EventActorsItem ChickenCalm6 => Instance[(short)249];

		public static EventActorsItem ChickenCalm7 => Instance[(short)250];

		public static EventActorsItem ChickenCalm8 => Instance[(short)251];

		public static EventActorsItem ChickenEnthusiastic0 => Instance[(short)252];

		public static EventActorsItem ChickenEnthusiastic1 => Instance[(short)253];

		public static EventActorsItem ChickenEnthusiastic2 => Instance[(short)254];

		public static EventActorsItem ChickenEnthusiastic3 => Instance[(short)255];

		public static EventActorsItem ChickenEnthusiastic4 => Instance[(short)256];

		public static EventActorsItem ChickenEnthusiastic5 => Instance[(short)257];

		public static EventActorsItem ChickenEnthusiastic6 => Instance[(short)258];

		public static EventActorsItem ChickenEnthusiastic7 => Instance[(short)259];

		public static EventActorsItem ChickenEnthusiastic8 => Instance[(short)260];

		public static EventActorsItem ChickenBrave0 => Instance[(short)261];

		public static EventActorsItem ChickenBrave1 => Instance[(short)262];

		public static EventActorsItem ChickenBrave2 => Instance[(short)263];

		public static EventActorsItem ChickenBrave3 => Instance[(short)264];

		public static EventActorsItem ChickenBrave4 => Instance[(short)265];

		public static EventActorsItem ChickenBrave5 => Instance[(short)266];

		public static EventActorsItem ChickenBrave6 => Instance[(short)267];

		public static EventActorsItem ChickenBrave7 => Instance[(short)268];

		public static EventActorsItem ChickenBrave8 => Instance[(short)269];

		public static EventActorsItem TaiWuVillager => Instance[(short)270];

		public static EventActorsItem HeadOfTongsheng => Instance[(short)271];

		public static EventActorsItem Ouyezi => Instance[(short)272];

		public static EventActorsItem ShadowOfHeavenlyLord => Instance[(short)273];

		public static EventActorsItem SectMainStoryZhujian1 => Instance[(short)274];

		public static EventActorsItem SectMainStoryZhujian2 => Instance[(short)275];

		public static EventActorsItem SectMainStoryZhujian3 => Instance[(short)276];

		public static EventActorsItem SectMainStoryZhujian4 => Instance[(short)277];

		public static EventActorsItem SectMainStoryZhujian5 => Instance[(short)278];

		public static EventActorsItem SectMainStoryZhujian6 => Instance[(short)279];

		public static EventActorsItem GeneralShaolinMember => Instance[(short)280];

		public static EventActorsItem GeneralEmeiMember => Instance[(short)281];

		public static EventActorsItem GeneraBaihuaMember => Instance[(short)282];

		public static EventActorsItem GeneralWudangMember => Instance[(short)283];

		public static EventActorsItem GeneralYuanshanMember => Instance[(short)284];

		public static EventActorsItem GeneralShixiangMember => Instance[(short)285];

		public static EventActorsItem GeneralRanshanMember => Instance[(short)286];

		public static EventActorsItem GeneralXuannvMember => Instance[(short)287];

		public static EventActorsItem GeneralZhujianMember => Instance[(short)288];

		public static EventActorsItem GeneralKongsangMember => Instance[(short)289];

		public static EventActorsItem GeneralJingangMember => Instance[(short)290];

		public static EventActorsItem GeneralWuxianMember => Instance[(short)291];

		public static EventActorsItem GeneralJieqingMember => Instance[(short)292];

		public static EventActorsItem GeneralFulongMember => Instance[(short)293];

		public static EventActorsItem GeneralXuehouMember => Instance[(short)294];

		public static EventActorsItem RemakeEmeiJefferyi => Instance[(short)295];

		public static EventActorsItem SectMainStoryYuanshan1 => Instance[(short)296];

		public static EventActorsItem SectMainStoryYuanshan2 => Instance[(short)297];

		public static EventActorsItem SectMainStoryYuanshan3 => Instance[(short)298];

		public static EventActorsItem SectMainStoryYuanshan4 => Instance[(short)299];

		public static EventActorsItem SectMainStoryYuanshan5 => Instance[(short)300];

		public static EventActorsItem SectMainStoryYuanshan6 => Instance[(short)301];

		public static EventActorsItem SectMainStoryYuanshan7 => Instance[(short)302];

		public static EventActorsItem SectMainStoryYuanshan8 => Instance[(short)303];

		public static EventActorsItem SectMainStoryYuanshan9 => Instance[(short)304];

		public static EventActorsItem SectMainStoryYuanshan10 => Instance[(short)305];

		public static EventActorsItem SectMainStoryYuanshan11 => Instance[(short)306];

		public static EventActorsItem SectMainStoryYuanshan12 => Instance[(short)307];

		public static EventActorsItem SectMainStoryYuanshan13 => Instance[(short)308];

		public static EventActorsItem SectMainStoryYuanshan14 => Instance[(short)309];

		public static EventActorsItem SectMainStoryYuanshanSeven0 => Instance[(short)310];

		public static EventActorsItem SectMainStoryYuanshanSeven1 => Instance[(short)311];

		public static EventActorsItem SectMainStoryWudangBaby => Instance[(short)312];

		public static EventActorsItem SectMainStoryWuxianGuxian => Instance[(short)313];

		public static EventActorsItem SectMainStoryXuehouDianxiaoer => Instance[(short)314];

		public static EventActorsItem SectMainStoryShixiangFeishi1 => Instance[(short)315];

		public static EventActorsItem SectMainStoryShixiangFeishi2 => Instance[(short)316];

		public static EventActorsItem SectMainStoryShixiangFeishi3 => Instance[(short)317];

		public static EventActorsItem SectMainStoryYuanshanShuoshuren => Instance[(short)318];

		public static EventActorsItem SectMainStoryRanshanGhost1 => Instance[(short)319];

		public static EventActorsItem SectMainStoryRanshanGhost2 => Instance[(short)320];

		public static EventActorsItem SectMainStoryRanshanGhost3 => Instance[(short)321];

		public static EventActorsItem Messenger => Instance[(short)322];

		public static EventActorsItem MainStoryHumanImmortalXu => Instance[(short)323];

		public static EventActorsItem MainStoryPureFireShadow => Instance[(short)324];

		public static EventActorsItem MainStoryEvilShadow => Instance[(short)325];

		public static EventActorsItem MainStoryBlackSmithShadow => Instance[(short)326];

		public static EventActorsItem MainStoryAlchemist => Instance[(short)327];

		public static EventActorsItem MainStoryPangu => Instance[(short)329];

		public static EventActorsItem MainStoryTiandi => Instance[(short)330];

		public static EventActorsItem MainStoryFuxi0 => Instance[(short)331];

		public static EventActorsItem MainStoryFuxi1 => Instance[(short)332];

		public static EventActorsItem MainStoryNvwa0 => Instance[(short)333];

		public static EventActorsItem MainStoryNvwa1 => Instance[(short)334];

		public static EventActorsItem MainStoryXiangshu => Instance[(short)335];

		public static EventActorsItem MainStoryDivineflameDayueSword => Instance[(short)336];

		public static EventActorsItem MainStoryDivineflameLonghun => Instance[(short)337];

		public static EventActorsItem MainStoryDivineflameXueshannvshen => Instance[(short)338];

		public static EventActorsItem MainStoryDivineflameXuenvQingling => Instance[(short)339];

		public static EventActorsItem MainStoryDivineflameChouhu => Instance[(short)340];

		public static EventActorsItem MainStoryDivineflameDuzhaifu => Instance[(short)341];

		public static EventActorsItem MainStoryDivineflameJianmuling => Instance[(short)342];

		public static EventActorsItem MainStoryDivineflameShengren => Instance[(short)343];

		public static EventActorsItem MainStoryDivineflameHuanggubo => Instance[(short)344];

		public static EventActorsItem MainStoryDivineflameHuanggubonvzixingtai => Instance[(short)345];

		public static EventActorsItem MainStoryDivineflameMonvxiaoniao => Instance[(short)346];

		public static EventActorsItem SectMainStoryJieqingOldman => Instance[(short)347];

		public static EventActorsItem SectMainStoryJieqingBai => Instance[(short)348];

		public static EventActorsItem SectMainStoryJieqing1 => Instance[(short)349];

		public static EventActorsItem SectMainStoryJieqing2 => Instance[(short)350];

		public static EventActorsItem SectMainStoryJieqing3 => Instance[(short)351];

		public static EventActorsItem SectMainStoryJieqing4 => Instance[(short)352];

		public static EventActorsItem SectMainStoryJieqingWudang1 => Instance[(short)353];

		public static EventActorsItem SectMainStoryJieqingWudang2 => Instance[(short)354];

		public static EventActorsItem JieqingActingHead => Instance[(short)355];

		public static EventActorsItem MainStoryDivineflameChiyou => Instance[(short)356];

		public static EventActorsItem MainStoryJianghuHermit => Instance[(short)363];

		public static EventActorsItem MainStoryMindAvatar => Instance[(short)364];

		public static EventActorsItem MainStoryLittleTaoist => Instance[(short)365];

		public static EventActorsItem MainStoryDivineflameChuniaojinhuanger => Instance[(short)366];

		public static EventActorsItem SectMainStoryEmeiXiake1 => Instance[(short)367];

		public static EventActorsItem SectMainStoryEmeiXiake2 => Instance[(short)368];

		public static EventActorsItem SectMainStoryEmeiActingHead => Instance[(short)369];

		public static EventActorsItem SectMainStoryEmeiEscapeMember => Instance[(short)370];

		public static EventActorsItem SectMainStoryEmeiPlayingKid => Instance[(short)371];
	}

	public static EventActors Instance = new EventActors();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "Name", "Clothing", "TemplateId", "Texture", "SpineName", "SpineSkinName" };

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
		_dataArray.Add(new EventActorsItem(0, LocalStringManager.GetConfig("EventActors_language", "Name_0"), null, null, null, 1, new byte[2] { 8, 12 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(1, LocalStringManager.GetConfig("EventActors_language", "Name_1"), null, null, null, 0, new byte[2] { 8, 12 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(2, LocalStringManager.GetConfig("EventActors_language", "Name_2"), null, null, null, -1, new byte[2] { 5, 8 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(3, LocalStringManager.GetConfig("EventActors_language", "Name_3"), null, null, null, 0, new byte[2] { 18, 25 }, new short[2] { 500, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(4, LocalStringManager.GetConfig("EventActors_language", "Name_4"), null, null, null, 0, new byte[2] { 18, 18 }, new short[2] { 800, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(5, LocalStringManager.GetConfig("EventActors_language", "Name_5"), null, null, null, -1, new byte[2] { 5, 5 }, new short[2] { 800, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(6, LocalStringManager.GetConfig("EventActors_language", "Name_6"), null, null, null, 1, new byte[2] { 20, 20 }, new short[2] { 800, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(7, LocalStringManager.GetConfig("EventActors_language", "Name_7"), null, null, null, 0, new byte[2] { 50, 70 }, new short[2] { 0, 900 }, 15, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(8, LocalStringManager.GetConfig("EventActors_language", "Name_8"), null, null, null, -1, new byte[2] { 5, 5 }, new short[2] { 800, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(9, LocalStringManager.GetConfig("EventActors_language", "Name_9"), null, null, null, 1, new byte[2] { 16, 30 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(10, LocalStringManager.GetConfig("EventActors_language", "Name_10"), null, null, null, 0, new byte[2] { 16, 30 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(11, LocalStringManager.GetConfig("EventActors_language", "Name_11"), null, null, null, 1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 19, isMonk: true, -1));
		_dataArray.Add(new EventActorsItem(12, LocalStringManager.GetConfig("EventActors_language", "Name_12"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 22, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(13, LocalStringManager.GetConfig("EventActors_language", "Name_13"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 25, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(14, LocalStringManager.GetConfig("EventActors_language", "Name_14"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 28, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(15, LocalStringManager.GetConfig("EventActors_language", "Name_15"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 32, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(16, LocalStringManager.GetConfig("EventActors_language", "Name_16"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 35, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(17, LocalStringManager.GetConfig("EventActors_language", "Name_17"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 38, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(18, LocalStringManager.GetConfig("EventActors_language", "Name_18"), null, null, null, 0, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 41, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(19, LocalStringManager.GetConfig("EventActors_language", "Name_19"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 44, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(20, LocalStringManager.GetConfig("EventActors_language", "Name_20"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 47, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(21, LocalStringManager.GetConfig("EventActors_language", "Name_21"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 50, isMonk: true, -1));
		_dataArray.Add(new EventActorsItem(22, LocalStringManager.GetConfig("EventActors_language", "Name_22"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 53, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(23, LocalStringManager.GetConfig("EventActors_language", "Name_23"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 56, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(24, LocalStringManager.GetConfig("EventActors_language", "Name_24"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 59, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(25, LocalStringManager.GetConfig("EventActors_language", "Name_25"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 62, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(26, LocalStringManager.GetConfig("EventActors_language", "Name_26"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(27, LocalStringManager.GetConfig("EventActors_language", "Name_27"), null, null, null, 0, new byte[2] { 20, 20 }, new short[2] { 600, 900 }, 17, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(28, LocalStringManager.GetConfig("EventActors_language", "Name_28"), null, null, null, 1, new byte[2] { 60, 90 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(29, LocalStringManager.GetConfig("EventActors_language", "Name_29"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(30, LocalStringManager.GetConfig("EventActors_language", "Name_30"), null, null, null, 1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(31, LocalStringManager.GetConfig("EventActors_language", "Name_31"), null, null, null, 1, new byte[2] { 16, 16 }, new short[2] { 0, 900 }, 11, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(32, LocalStringManager.GetConfig("EventActors_language", "Name_32"), null, null, null, 1, new byte[2] { 16, 30 }, new short[2] { 0, 900 }, 2, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(33, LocalStringManager.GetConfig("EventActors_language", "Name_33"), null, null, null, 1, new byte[2] { 50, 90 }, new short[2] { 0, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(34, LocalStringManager.GetConfig("EventActors_language", "Name_34"), null, null, null, 0, new byte[2] { 50, 90 }, new short[2] { 0, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(35, LocalStringManager.GetConfig("EventActors_language", "Name_35"), null, null, null, 1, new byte[2] { 10, 15 }, new short[2] { 0, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(36, LocalStringManager.GetConfig("EventActors_language", "Name_36"), null, null, null, 0, new byte[2] { 10, 15 }, new short[2] { 0, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(37, LocalStringManager.GetConfig("EventActors_language", "Name_37"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 2, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(38, LocalStringManager.GetConfig("EventActors_language", "Name_38"), null, null, null, 0, new byte[2] { 18, 18 }, new short[2] { 500, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(39, LocalStringManager.GetConfig("EventActors_language", "Name_39"), null, null, null, 1, new byte[2] { 16, 40 }, new short[2] { 0, 900 }, 1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(40, LocalStringManager.GetConfig("EventActors_language", "Name_40"), null, null, null, -1, new byte[2] { 16, 30 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(41, LocalStringManager.GetConfig("EventActors_language", "Name_41"), null, null, null, 1, new byte[2] { 60, 90 }, new short[2] { 0, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(42, LocalStringManager.GetConfig("EventActors_language", "Name_42"), null, null, null, -1, new byte[2] { 30, 50 }, new short[2] { 0, 900 }, 5, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(43, LocalStringManager.GetConfig("EventActors_language", "Name_43"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(44, LocalStringManager.GetConfig("EventActors_language", "Name_44"), null, null, null, -1, new byte[2] { 30, 50 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(45, LocalStringManager.GetConfig("EventActors_language", "Name_45"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(46, LocalStringManager.GetConfig("EventActors_language", "Name_46"), null, null, null, 0, new byte[2] { 30, 50 }, new short[2] { 0, 900 }, 15, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(47, LocalStringManager.GetConfig("EventActors_language", "Name_47"), null, null, null, -1, new byte[2] { 6, 12 }, new short[2] { 0, 900 }, 15, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(48, LocalStringManager.GetConfig("EventActors_language", "Name_48"), null, null, null, -1, new byte[2] { 40, 60 }, new short[2] { 0, 900 }, 7, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(49, LocalStringManager.GetConfig("EventActors_language", "Name_49"), null, null, null, 0, new byte[2] { 35, 40 }, new short[2] { 600, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(50, LocalStringManager.GetConfig("EventActors_language", "Name_50"), null, null, null, 1, new byte[2] { 90, 120 }, new short[2] { 0, 900 }, 9, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(51, LocalStringManager.GetConfig("EventActors_language", "Name_51"), null, null, null, 1, new byte[2] { 30, 60 }, new short[2] { 0, 900 }, 14, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(52, LocalStringManager.GetConfig("EventActors_language", "Name_52"), null, null, null, 0, new byte[2] { 20, 30 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(53, LocalStringManager.GetConfig("EventActors_language", "Name_53"), null, null, null, 0, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 15, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(54, LocalStringManager.GetConfig("EventActors_language", "Name_54"), null, null, null, 0, new byte[2] { 40, 50 }, new short[2] { 0, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(55, LocalStringManager.GetConfig("EventActors_language", "Name_55"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 15, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(56, LocalStringManager.GetConfig("EventActors_language", "Name_56"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 2, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(57, LocalStringManager.GetConfig("EventActors_language", "Name_57"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 2, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(58, LocalStringManager.GetConfig("EventActors_language", "Name_58"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 2, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(59, LocalStringManager.GetConfig("EventActors_language", "Name_59"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 2, isMonk: false, -1));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new EventActorsItem(60, LocalStringManager.GetConfig("EventActors_language", "Name_60"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 2, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(61, LocalStringManager.GetConfig("EventActors_language", "Name_61"), null, null, null, -1, new byte[2] { 50, 60 }, new short[2] { 0, 900 }, 0, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(62, LocalStringManager.GetConfig("EventActors_language", "Name_62"), null, null, null, 1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 18, isMonk: true, -1));
		_dataArray.Add(new EventActorsItem(63, LocalStringManager.GetConfig("EventActors_language", "Name_63"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 21, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(64, LocalStringManager.GetConfig("EventActors_language", "Name_64"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 24, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(65, LocalStringManager.GetConfig("EventActors_language", "Name_65"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 27, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(66, LocalStringManager.GetConfig("EventActors_language", "Name_66"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 31, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(67, LocalStringManager.GetConfig("EventActors_language", "Name_67"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 34, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(68, LocalStringManager.GetConfig("EventActors_language", "Name_68"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 37, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(69, LocalStringManager.GetConfig("EventActors_language", "Name_69"), null, null, null, 0, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 40, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(70, LocalStringManager.GetConfig("EventActors_language", "Name_70"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 43, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(71, LocalStringManager.GetConfig("EventActors_language", "Name_71"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 46, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(72, LocalStringManager.GetConfig("EventActors_language", "Name_72"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 49, isMonk: true, -1));
		_dataArray.Add(new EventActorsItem(73, LocalStringManager.GetConfig("EventActors_language", "Name_73"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 52, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(74, LocalStringManager.GetConfig("EventActors_language", "Name_74"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 55, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(75, LocalStringManager.GetConfig("EventActors_language", "Name_75"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 58, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(76, LocalStringManager.GetConfig("EventActors_language", "Name_76"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 61, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(77, LocalStringManager.GetConfig("EventActors_language", "Name_77"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 43, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(78, LocalStringManager.GetConfig("EventActors_language", "Name_78"), null, null, null, 0, new byte[2] { 16, 30 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(79, LocalStringManager.GetConfig("EventActors_language", "Name_79"), null, null, null, -1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 3, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(80, LocalStringManager.GetConfig("EventActors_language", "Name_80"), null, null, null, -1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(81, LocalStringManager.GetConfig("EventActors_language", "Name_81"), null, null, null, -1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 7, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(82, LocalStringManager.GetConfig("EventActors_language", "Name_82"), null, null, null, -1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 15, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(83, LocalStringManager.GetConfig("EventActors_language", "Name_83"), null, null, null, -1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 13, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(84, LocalStringManager.GetConfig("EventActors_language", "Name_84"), null, null, null, -1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 11, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(85, LocalStringManager.GetConfig("EventActors_language", "Name_85"), null, null, null, -1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(86, LocalStringManager.GetConfig("EventActors_language", "Name_86"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 2, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(87, LocalStringManager.GetConfig("EventActors_language", "Name_87"), null, null, null, -1, new byte[2] { 30, 50 }, new short[2] { 0, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(88, LocalStringManager.GetConfig("EventActors_language", "Name_88"), null, null, null, -1, new byte[2] { 40, 60 }, new short[2] { 0, 900 }, 8, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(89, LocalStringManager.GetConfig("EventActors_language", "Name_89"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 19, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(90, LocalStringManager.GetConfig("EventActors_language", "Name_90"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 22, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(91, LocalStringManager.GetConfig("EventActors_language", "Name_91"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 25, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(92, LocalStringManager.GetConfig("EventActors_language", "Name_92"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 28, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(93, LocalStringManager.GetConfig("EventActors_language", "Name_93"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 32, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(94, LocalStringManager.GetConfig("EventActors_language", "Name_94"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 35, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(95, LocalStringManager.GetConfig("EventActors_language", "Name_95"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 38, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(96, LocalStringManager.GetConfig("EventActors_language", "Name_96"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 41, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(97, LocalStringManager.GetConfig("EventActors_language", "Name_97"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 44, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(98, LocalStringManager.GetConfig("EventActors_language", "Name_98"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 47, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(99, LocalStringManager.GetConfig("EventActors_language", "Name_99"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 50, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(100, LocalStringManager.GetConfig("EventActors_language", "Name_100"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 53, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(101, LocalStringManager.GetConfig("EventActors_language", "Name_101"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 56, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(102, LocalStringManager.GetConfig("EventActors_language", "Name_102"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 59, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(103, LocalStringManager.GetConfig("EventActors_language", "Name_103"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 62, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(104, LocalStringManager.GetConfig("EventActors_language", "Name_104"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 9, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(105, LocalStringManager.GetConfig("EventActors_language", "Name_105"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 48, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(106, LocalStringManager.GetConfig("EventActors_language", "Name_106"), null, null, null, 0, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 41, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(107, LocalStringManager.GetConfig("EventActors_language", "Name_107"), null, null, null, 1, new byte[2] { 55, 60 }, new short[2] { 0, 900 }, 20, isMonk: true, 2));
		_dataArray.Add(new EventActorsItem(108, LocalStringManager.GetConfig("EventActors_language", "Name_108"), null, null, null, 1, new byte[2] { 18, 19 }, new short[2] { 0, 900 }, 18, isMonk: true, 0));
		_dataArray.Add(new EventActorsItem(109, LocalStringManager.GetConfig("EventActors_language", "Name_109"), null, null, null, 1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(110, LocalStringManager.GetConfig("EventActors_language", "Name_110"), "NpcFace_shanzhuyouzai", "NpcFace/keaishanzhu", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(111, LocalStringManager.GetConfig("EventActors_language", "Name_111"), null, null, null, 1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(112, LocalStringManager.GetConfig("EventActors_language", "Name_112"), null, null, null, 1, new byte[2] { 90, 120 }, new short[2] { 0, 900 }, 1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(113, LocalStringManager.GetConfig("EventActors_language", "Name_113"), null, null, null, 0, new byte[2] { 18, 20 }, new short[2] { 600, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(114, LocalStringManager.GetConfig("EventActors_language", "Name_114"), null, null, null, 1, new byte[2] { 20, 25 }, new short[2] { 0, 900 }, 52, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(115, LocalStringManager.GetConfig("EventActors_language", "Name_115"), null, null, null, -1, new byte[2] { 6, 12 }, new short[2] { 0, 900 }, 15, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(116, LocalStringManager.GetConfig("EventActors_language", "Name_116"), null, null, null, 1, new byte[2] { 90, 120 }, new short[2] { 0, 900 }, 0, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(117, LocalStringManager.GetConfig("EventActors_language", "Name_117"), null, null, null, 1, new byte[2] { 90, 120 }, new short[2] { 0, 900 }, 14, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(118, LocalStringManager.GetConfig("EventActors_language", "Name_118"), null, null, null, 0, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 15, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(119, LocalStringManager.GetConfig("EventActors_language", "Name_119"), null, null, null, 1, new byte[2] { 60, 90 }, new short[2] { 600, 900 }, 14, isMonk: false, -1));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new EventActorsItem(120, LocalStringManager.GetConfig("EventActors_language", "Name_120"), null, null, null, 1, new byte[2] { 90, 120 }, new short[2] { 0, 900 }, 5, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(121, LocalStringManager.GetConfig("EventActors_language", "Name_121"), null, null, null, 1, new byte[2] { 20, 30 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(122, LocalStringManager.GetConfig("EventActors_language", "Name_122"), null, null, null, 0, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(123, LocalStringManager.GetConfig("EventActors_language", "Name_123"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(124, LocalStringManager.GetConfig("EventActors_language", "Name_124"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(125, LocalStringManager.GetConfig("EventActors_language", "Name_125"), null, null, null, 1, new byte[2] { 18, 25 }, new short[2] { 0, 900 }, 14, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(126, LocalStringManager.GetConfig("EventActors_language", "Name_126"), null, null, null, 1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(127, LocalStringManager.GetConfig("EventActors_language", "Name_127"), null, null, null, 0, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(128, LocalStringManager.GetConfig("EventActors_language", "Name_128"), null, null, null, -1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 48, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(129, LocalStringManager.GetConfig("EventActors_language", "Name_129"), null, null, null, 1, new byte[2] { 18, 40 }, new short[2] { 0, 900 }, 19, isMonk: true, -1));
		_dataArray.Add(new EventActorsItem(130, LocalStringManager.GetConfig("EventActors_language", "Name_130"), null, null, null, -1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(131, LocalStringManager.GetConfig("EventActors_language", "Name_131"), "NpcFace_feishitangdizi", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(132, LocalStringManager.GetConfig("EventActors_language", "Name_132"), "NpcFace_yizugaoshou", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(133, LocalStringManager.GetConfig("EventActors_language", "Name_133"), null, null, null, -1, new byte[2] { 30, 50 }, new short[2] { 0, 900 }, 17, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(134, LocalStringManager.GetConfig("EventActors_language", "Name_134"), null, null, null, 1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 11, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(135, LocalStringManager.GetConfig("EventActors_language", "Name_135"), null, null, null, 1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 0, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(136, LocalStringManager.GetConfig("EventActors_language", "Name_136"), null, null, null, 1, new byte[2] { 16, 20 }, new short[2] { 500, 599 }, 27, isMonk: false, 0));
		_dataArray.Add(new EventActorsItem(137, LocalStringManager.GetConfig("EventActors_language", "Name_137"), "NpcFace_wudangya", "NpcFace/yaya", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(138, LocalStringManager.GetConfig("EventActors_language", "Name_138"), null, null, null, -1, new byte[2] { 40, 60 }, new short[2] { 0, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(139, LocalStringManager.GetConfig("EventActors_language", "Name_139"), null, null, null, -1, new byte[2] { 20, 30 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(140, LocalStringManager.GetConfig("EventActors_language", "Name_140"), null, null, null, 1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 22, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(141, LocalStringManager.GetConfig("EventActors_language", "Name_141"), null, null, null, 1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 22, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(142, LocalStringManager.GetConfig("EventActors_language", "Name_142"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 22, isMonk: false, 0));
		_dataArray.Add(new EventActorsItem(143, LocalStringManager.GetConfig("EventActors_language", "Name_143"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 22, isMonk: false, 2));
		_dataArray.Add(new EventActorsItem(144, LocalStringManager.GetConfig("EventActors_language", "Name_144"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 22, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(145, LocalStringManager.GetConfig("EventActors_language", "Name_145"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 22, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(146, LocalStringManager.GetConfig("EventActors_language", "Name_146"), null, null, null, 0, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 22, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(147, LocalStringManager.GetConfig("EventActors_language", "Name_147"), null, null, null, 1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 22, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(148, LocalStringManager.GetConfig("EventActors_language", "Name_148"), "NpcFace_tiannvxuying", "NpcFace/tiannvxuying", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(149, LocalStringManager.GetConfig("EventActors_language", "Name_149"), "NpcFace_emeibaiyuanheiying", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(150, LocalStringManager.GetConfig("EventActors_language", "Name_150"), "NpcFace_emeizhanglaojiabanheiyiren", "NpcFace/heiyiren", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(151, LocalStringManager.GetConfig("EventActors_language", "Name_151"), null, null, null, 0, new byte[2] { 5, 6 }, new short[2] { 0, 900 }, 15, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(152, LocalStringManager.GetConfig("EventActors_language", "Name_152"), "NpcFace_menghuijudaheiying", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(153, LocalStringManager.GetConfig("EventActors_language", "Name_153"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 2, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(154, LocalStringManager.GetConfig("EventActors_language", "Name_154"), "NpcFace_huanlongshigege", "NpcFace/huanlongshixiong", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(155, LocalStringManager.GetConfig("EventActors_language", "Name_155"), "NpcFace_huanlongshimeimei", "NpcFace/huanlongshimei", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(156, LocalStringManager.GetConfig("EventActors_language", "Name_156"), "NpcFace_wuzhongshaonv", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(157, LocalStringManager.GetConfig("EventActors_language", "Name_157"), null, null, null, 1, new byte[2] { 60, 70 }, new short[2] { 0, 900 }, 10, isMonk: false, 0));
		_dataArray.Add(new EventActorsItem(158, LocalStringManager.GetConfig("EventActors_language", "Name_158"), null, null, null, 1, new byte[2] { 40, 60 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(159, LocalStringManager.GetConfig("EventActors_language", "Name_159"), "NpcFace_jingangguiyingsengren", "NpcFace/gaosenghunpo_2", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(160, LocalStringManager.GetConfig("EventActors_language", "Name_160"), "NpcFace_gaosenghunling", "NpcFace/gaosenghunpo_1", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(161, LocalStringManager.GetConfig("EventActors_language", "Name_161"), null, null, null, 0, new byte[2] { 60, 70 }, new short[2] { 400, 500 }, 52, isMonk: false, 1));
		_dataArray.Add(new EventActorsItem(162, LocalStringManager.GetConfig("EventActors_language", "Name_162"), null, null, null, 0, new byte[2] { 30, 40 }, new short[2] { 500, 600 }, 52, isMonk: false, 0));
		_dataArray.Add(new EventActorsItem(163, LocalStringManager.GetConfig("EventActors_language", "Name_163"), null, null, null, 0, new byte[2] { 20, 30 }, new short[2] { 400, 600 }, 52, isMonk: false, 1));
		_dataArray.Add(new EventActorsItem(164, LocalStringManager.GetConfig("EventActors_language", "Name_164"), null, null, null, 1, new byte[2] { 20, 30 }, new short[2] { 0, 900 }, 52, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(165, LocalStringManager.GetConfig("EventActors_language", "Name_165"), null, null, null, 1, new byte[2] { 60, 90 }, new short[2] { 0, 900 }, 52, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(166, LocalStringManager.GetConfig("EventActors_language", "Name_166"), null, null, null, 1, new byte[2] { 18, 25 }, new short[2] { 600, 900 }, 37, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(167, LocalStringManager.GetConfig("EventActors_language", "Name_167"), null, null, null, 0, new byte[2] { 6, 12 }, new short[2] { 0, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(168, LocalStringManager.GetConfig("EventActors_language", "Name_168"), null, null, null, 1, new byte[2] { 6, 12 }, new short[2] { 0, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(169, LocalStringManager.GetConfig("EventActors_language", "Name_169"), null, null, null, -1, new byte[2] { 6, 12 }, new short[2] { 0, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(170, LocalStringManager.GetConfig("EventActors_language", "Name_170"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 600, 900 }, 38, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(171, LocalStringManager.GetConfig("EventActors_language", "Name_171"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 37, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(172, LocalStringManager.GetConfig("EventActors_language", "Name_172"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 37, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(173, LocalStringManager.GetConfig("EventActors_language", "Name_173"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 38, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(174, LocalStringManager.GetConfig("EventActors_language", "Name_174"), null, null, null, -1, new byte[2] { 6, 12 }, new short[2] { 0, 900 }, 15, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(175, LocalStringManager.GetConfig("EventActors_language", "Name_175"), null, null, null, 1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 37, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(176, LocalStringManager.GetConfig("EventActors_language", "Name_176"), null, null, null, 1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(177, LocalStringManager.GetConfig("EventActors_language", "Name_177"), null, null, null, 1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(178, LocalStringManager.GetConfig("EventActors_language", "Name_178"), null, null, null, 1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 11, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(179, LocalStringManager.GetConfig("EventActors_language", "Name_179"), "NpcFace_baihuazhuxianfengqingjianying", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new EventActorsItem(180, LocalStringManager.GetConfig("EventActors_language", "Name_180"), "NpcFace_baihuazhuxianhuanxinjianying", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(181, LocalStringManager.GetConfig("EventActors_language", "Name_181"), "NpcFace_xiangshu2", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(182, LocalStringManager.GetConfig("EventActors_language", "Name_182"), "NpcFace_wumingzhirennanjianying", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(183, LocalStringManager.GetConfig("EventActors_language", "Name_183"), "NpcFace_wumingzhirennvjianying", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(184, LocalStringManager.GetConfig("EventActors_language", "Name_184"), "NpcFace_baihuazhuxianfengqing", "NpcFace/fengpopo_qingchun", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(185, LocalStringManager.GetConfig("EventActors_language", "Name_185"), "NpcFace_wumingzhirennanjietuo", "NpcFace/nan_chudai_jietuo", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(186, LocalStringManager.GetConfig("EventActors_language", "Name_186"), "NpcFace_wumingzhirennvjietuo", "NpcFace/nv_chudai_jietuo", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(187, LocalStringManager.GetConfig("EventActors_language", "Name_187"), "NpcFace_wumingzhirennan", "NpcFace/nan_chudai_biaozhun", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(188, LocalStringManager.GetConfig("EventActors_language", "Name_188"), "NpcFace_wumingzhirennv", "NpcFace/nv_chudai_biaozhun", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(189, LocalStringManager.GetConfig("EventActors_language", "Name_189"), null, null, null, 1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(190, LocalStringManager.GetConfig("EventActors_language", "Name_190"), null, null, null, 0, new byte[2] { 20, 25 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(191, LocalStringManager.GetConfig("EventActors_language", "Name_191"), null, null, null, 1, new byte[2] { 16, 20 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(192, LocalStringManager.GetConfig("EventActors_language", "Name_192"), null, null, null, 1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 15, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(193, LocalStringManager.GetConfig("EventActors_language", "Name_193"), null, null, null, 1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 11, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(194, LocalStringManager.GetConfig("EventActors_language", "Name_194"), "NpcFace_guiguziwu", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(195, LocalStringManager.GetConfig("EventActors_language", "Name_195"), null, null, null, 1, new byte[2] { 60, 70 }, new short[2] { 0, 900 }, 4, isMonk: false, 0));
		_dataArray.Add(new EventActorsItem(196, LocalStringManager.GetConfig("EventActors_language", "Name_196"), null, null, null, 0, new byte[2] { 16, 20 }, new short[2] { 600, 900 }, 11, isMonk: false, 1));
		_dataArray.Add(new EventActorsItem(197, LocalStringManager.GetConfig("EventActors_language", "Name_197"), null, null, null, 0, new byte[2] { 16, 20 }, new short[2] { 600, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(198, LocalStringManager.GetConfig("EventActors_language", "Name_198"), null, null, null, 1, new byte[2] { 16, 20 }, new short[2] { 600, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(199, LocalStringManager.GetConfig("EventActors_language", "Name_199"), null, null, null, 0, new byte[2] { 20, 25 }, new short[2] { 500, 900 }, 13, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(200, LocalStringManager.GetConfig("EventActors_language", "Name_200"), null, null, null, 1, new byte[2] { 20, 25 }, new short[2] { 500, 900 }, 13, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(201, LocalStringManager.GetConfig("EventActors_language", "Name_201"), null, null, null, 0, new byte[2] { 16, 20 }, new short[2] { 800, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(202, LocalStringManager.GetConfig("EventActors_language", "Name_202"), null, null, null, 1, new byte[2] { 16, 20 }, new short[2] { 800, 900 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(203, LocalStringManager.GetConfig("EventActors_language", "Name_203"), null, null, null, 0, new byte[2] { 16, 20 }, new short[2] { 0, 100 }, 16, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(204, LocalStringManager.GetConfig("EventActors_language", "Name_204"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 59, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(205, LocalStringManager.GetConfig("EventActors_language", "Name_205"), "NpcFace_mengmianshenminvzi", "NpcFace/longyufu_mengmian", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(206, LocalStringManager.GetConfig("EventActors_language", "Name_206"), "NpcFace_liulishouxing", "NpcFace/liuli_shouxing", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(207, LocalStringManager.GetConfig("EventActors_language", "Name_207"), "NpcFace_chicken_clever0", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(208, LocalStringManager.GetConfig("EventActors_language", "Name_208"), "NpcFace_chicken_clever1", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(209, LocalStringManager.GetConfig("EventActors_language", "Name_209"), "NpcFace_chicken_clever2", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(210, LocalStringManager.GetConfig("EventActors_language", "Name_210"), "NpcFace_chicken_clever3", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(211, LocalStringManager.GetConfig("EventActors_language", "Name_211"), "NpcFace_chicken_clever4", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(212, LocalStringManager.GetConfig("EventActors_language", "Name_212"), "NpcFace_chicken_clever5", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(213, LocalStringManager.GetConfig("EventActors_language", "Name_213"), "NpcFace_chicken_clever6", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(214, LocalStringManager.GetConfig("EventActors_language", "Name_214"), "NpcFace_chicken_clever7", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(215, LocalStringManager.GetConfig("EventActors_language", "Name_215"), "NpcFace_chicken_clever8", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(216, LocalStringManager.GetConfig("EventActors_language", "Name_216"), "NpcFace_chicken_lucky0", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(217, LocalStringManager.GetConfig("EventActors_language", "Name_217"), "NpcFace_chicken_lucky1", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(218, LocalStringManager.GetConfig("EventActors_language", "Name_218"), "NpcFace_chicken_lucky2", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(219, LocalStringManager.GetConfig("EventActors_language", "Name_219"), "NpcFace_chicken_lucky3", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(220, LocalStringManager.GetConfig("EventActors_language", "Name_220"), "NpcFace_chicken_lucky4", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(221, LocalStringManager.GetConfig("EventActors_language", "Name_221"), "NpcFace_chicken_lucky5", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(222, LocalStringManager.GetConfig("EventActors_language", "Name_222"), "NpcFace_chicken_lucky6", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(223, LocalStringManager.GetConfig("EventActors_language", "Name_223"), "NpcFace_chicken_lucky7", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(224, LocalStringManager.GetConfig("EventActors_language", "Name_224"), "NpcFace_chicken_lucky8", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(225, LocalStringManager.GetConfig("EventActors_language", "Name_225"), "NpcFace_chicken_perceptive0", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(226, LocalStringManager.GetConfig("EventActors_language", "Name_226"), "NpcFace_chicken_perceptive1", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(227, LocalStringManager.GetConfig("EventActors_language", "Name_227"), "NpcFace_chicken_perceptive2", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(228, LocalStringManager.GetConfig("EventActors_language", "Name_228"), "NpcFace_chicken_perceptive3", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(229, LocalStringManager.GetConfig("EventActors_language", "Name_229"), "NpcFace_chicken_perceptive4", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(230, LocalStringManager.GetConfig("EventActors_language", "Name_230"), "NpcFace_chicken_perceptive5", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(231, LocalStringManager.GetConfig("EventActors_language", "Name_231"), "NpcFace_chicken_perceptive6", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(232, LocalStringManager.GetConfig("EventActors_language", "Name_232"), "NpcFace_chicken_perceptive7", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(233, LocalStringManager.GetConfig("EventActors_language", "Name_233"), "NpcFace_chicken_perceptive8", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(234, LocalStringManager.GetConfig("EventActors_language", "Name_234"), "NpcFace_chicken_firm0", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(235, LocalStringManager.GetConfig("EventActors_language", "Name_235"), "NpcFace_chicken_firm1", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(236, LocalStringManager.GetConfig("EventActors_language", "Name_236"), "NpcFace_chicken_firm2", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(237, LocalStringManager.GetConfig("EventActors_language", "Name_237"), "NpcFace_chicken_firm3", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(238, LocalStringManager.GetConfig("EventActors_language", "Name_238"), "NpcFace_chicken_firm4", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(239, LocalStringManager.GetConfig("EventActors_language", "Name_239"), "NpcFace_chicken_firm5", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new EventActorsItem(240, LocalStringManager.GetConfig("EventActors_language", "Name_240"), "NpcFace_chicken_firm6", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(241, LocalStringManager.GetConfig("EventActors_language", "Name_241"), "NpcFace_chicken_firm7", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(242, LocalStringManager.GetConfig("EventActors_language", "Name_242"), "NpcFace_chicken_firm8", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(243, LocalStringManager.GetConfig("EventActors_language", "Name_243"), "NpcFace_chicken_calm0", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(244, LocalStringManager.GetConfig("EventActors_language", "Name_244"), "NpcFace_chicken_calm1", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(245, LocalStringManager.GetConfig("EventActors_language", "Name_245"), "NpcFace_chicken_calm2", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(246, LocalStringManager.GetConfig("EventActors_language", "Name_246"), "NpcFace_chicken_calm3", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(247, LocalStringManager.GetConfig("EventActors_language", "Name_247"), "NpcFace_chicken_calm4", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(248, LocalStringManager.GetConfig("EventActors_language", "Name_248"), "NpcFace_chicken_calm5", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(249, LocalStringManager.GetConfig("EventActors_language", "Name_249"), "NpcFace_chicken_calm6", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(250, LocalStringManager.GetConfig("EventActors_language", "Name_250"), "NpcFace_chicken_calm7", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(251, LocalStringManager.GetConfig("EventActors_language", "Name_251"), "NpcFace_chicken_calm8", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(252, LocalStringManager.GetConfig("EventActors_language", "Name_252"), "NpcFace_chicken_enthusiastic0", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(253, LocalStringManager.GetConfig("EventActors_language", "Name_253"), "NpcFace_chicken_enthusiastic1", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(254, LocalStringManager.GetConfig("EventActors_language", "Name_254"), "NpcFace_chicken_enthusiastic2", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(255, LocalStringManager.GetConfig("EventActors_language", "Name_255"), "NpcFace_chicken_enthusiastic3", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(256, LocalStringManager.GetConfig("EventActors_language", "Name_256"), "NpcFace_chicken_enthusiastic4", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(257, LocalStringManager.GetConfig("EventActors_language", "Name_257"), "NpcFace_chicken_enthusiastic5", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(258, LocalStringManager.GetConfig("EventActors_language", "Name_258"), "NpcFace_chicken_enthusiastic6", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(259, LocalStringManager.GetConfig("EventActors_language", "Name_259"), "NpcFace_chicken_enthusiastic7", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(260, LocalStringManager.GetConfig("EventActors_language", "Name_260"), "NpcFace_chicken_enthusiastic8", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(261, LocalStringManager.GetConfig("EventActors_language", "Name_261"), "NpcFace_chicken_brave0", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(262, LocalStringManager.GetConfig("EventActors_language", "Name_262"), "NpcFace_chicken_brave1", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(263, LocalStringManager.GetConfig("EventActors_language", "Name_263"), "NpcFace_chicken_brave2", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(264, LocalStringManager.GetConfig("EventActors_language", "Name_264"), "NpcFace_chicken_brave3", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(265, LocalStringManager.GetConfig("EventActors_language", "Name_265"), "NpcFace_chicken_brave4", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(266, LocalStringManager.GetConfig("EventActors_language", "Name_266"), "NpcFace_chicken_brave5", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(267, LocalStringManager.GetConfig("EventActors_language", "Name_267"), "NpcFace_chicken_brave6", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(268, LocalStringManager.GetConfig("EventActors_language", "Name_268"), "NpcFace_chicken_brave7", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(269, LocalStringManager.GetConfig("EventActors_language", "Name_269"), "NpcFace_chicken_brave8", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(270, LocalStringManager.GetConfig("EventActors_language", "Name_270"), null, null, null, -1, new byte[2] { 20, 60 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(271, LocalStringManager.GetConfig("EventActors_language", "Name_271"), "NpcFace_tongshengtou", "NpcFace/tongsheng_tou", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(272, LocalStringManager.GetConfig("EventActors_language", "Name_272"), "NpcFace_ouyanzi", "NpcFace/ouyezi", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(273, LocalStringManager.GetConfig("EventActors_language", "Name_273"), "NpcFace_tiandiheiying", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(274, LocalStringManager.GetConfig("EventActors_language", "Name_274"), null, null, null, 1, new byte[2] { 18, 25 }, new short[2] { 500, 900 }, 43, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(275, LocalStringManager.GetConfig("EventActors_language", "Name_275"), null, null, null, 0, new byte[2] { 18, 25 }, new short[2] { 500, 900 }, 43, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(276, LocalStringManager.GetConfig("EventActors_language", "Name_276"), null, null, null, 1, new byte[2] { 70, 80 }, new short[2] { 0, 900 }, 44, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(277, LocalStringManager.GetConfig("EventActors_language", "Name_277"), null, null, null, 1, new byte[2] { 70, 80 }, new short[2] { 0, 900 }, 43, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(278, LocalStringManager.GetConfig("EventActors_language", "Name_278"), null, null, null, -1, new byte[2] { 70, 80 }, new short[2] { 0, 900 }, 43, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(279, LocalStringManager.GetConfig("EventActors_language", "Name_279"), null, null, null, 1, new byte[2] { 18, 60 }, new short[2] { 500, 900 }, 44, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(280, LocalStringManager.GetConfig("EventActors_language", "Name_280"), null, null, null, 1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 19, isMonk: true, -1));
		_dataArray.Add(new EventActorsItem(281, LocalStringManager.GetConfig("EventActors_language", "Name_281"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 22, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(282, LocalStringManager.GetConfig("EventActors_language", "Name_282"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 25, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(283, LocalStringManager.GetConfig("EventActors_language", "Name_283"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 28, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(284, LocalStringManager.GetConfig("EventActors_language", "Name_284"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 32, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(285, LocalStringManager.GetConfig("EventActors_language", "Name_285"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 35, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(286, LocalStringManager.GetConfig("EventActors_language", "Name_286"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 38, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(287, LocalStringManager.GetConfig("EventActors_language", "Name_287"), null, null, null, 0, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 41, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(288, LocalStringManager.GetConfig("EventActors_language", "Name_288"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 44, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(289, LocalStringManager.GetConfig("EventActors_language", "Name_289"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 47, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(290, LocalStringManager.GetConfig("EventActors_language", "Name_290"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 50, isMonk: true, -1));
		_dataArray.Add(new EventActorsItem(291, LocalStringManager.GetConfig("EventActors_language", "Name_291"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 53, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(292, LocalStringManager.GetConfig("EventActors_language", "Name_292"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 56, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(293, LocalStringManager.GetConfig("EventActors_language", "Name_293"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 59, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(294, LocalStringManager.GetConfig("EventActors_language", "Name_294"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 62, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(295, LocalStringManager.GetConfig("EventActors_language", "Name_295"), "NpcFace_chicken_clever0", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(296, LocalStringManager.GetConfig("EventActors_language", "Name_296"), null, null, null, 1, new byte[2] { 30, 60 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(297, LocalStringManager.GetConfig("EventActors_language", "Name_297"), null, null, null, 0, new byte[2] { 30, 60 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(298, LocalStringManager.GetConfig("EventActors_language", "Name_298"), null, null, null, -1, new byte[2] { 30, 60 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(299, LocalStringManager.GetConfig("EventActors_language", "Name_299"), null, null, null, -1, new byte[2] { 18, 25 }, new short[2] { 0, 900 }, 32, isMonk: false, -1));
	}

	private void CreateItems5()
	{
		_dataArray.Add(new EventActorsItem(300, LocalStringManager.GetConfig("EventActors_language", "Name_300"), null, null, null, 1, new byte[2] { 18, 25 }, new short[2] { 0, 900 }, 32, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(301, LocalStringManager.GetConfig("EventActors_language", "Name_301"), null, null, null, 0, new byte[2] { 18, 25 }, new short[2] { 0, 900 }, 32, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(302, LocalStringManager.GetConfig("EventActors_language", "Name_302"), null, null, null, 0, new byte[2] { 18, 18 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(303, LocalStringManager.GetConfig("EventActors_language", "Name_303"), null, null, null, 1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(304, LocalStringManager.GetConfig("EventActors_language", "Name_304"), null, null, null, -1, new byte[2] { 18, 25 }, new short[2] { 0, 900 }, 11, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(305, LocalStringManager.GetConfig("EventActors_language", "Name_305"), null, null, null, 0, new byte[2] { 18, 25 }, new short[2] { 0, 900 }, 33, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(306, LocalStringManager.GetConfig("EventActors_language", "Name_306"), null, null, null, -1, new byte[2] { 40, 60 }, new short[2] { 0, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(307, LocalStringManager.GetConfig("EventActors_language", "Name_307"), null, null, null, -1, new byte[2] { 50, 70 }, new short[2] { 0, 900 }, 33, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(308, LocalStringManager.GetConfig("EventActors_language", "Name_308"), null, null, null, 1, new byte[2] { 30, 60 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(309, LocalStringManager.GetConfig("EventActors_language", "Name_309"), null, null, null, 1, new byte[2] { 60, 70 }, new short[2] { 0, 900 }, 33, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(310, LocalStringManager.GetConfig("EventActors_language", "Name_310"), "NpcFace_diqidaitaiwunan", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(311, LocalStringManager.GetConfig("EventActors_language", "Name_311"), "NpcFace_diqidaitaiwunv", null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(312, LocalStringManager.GetConfig("EventActors_language", "Name_312"), null, null, null, -1, new byte[2] { 1, 1 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(313, LocalStringManager.GetConfig("EventActors_language", "Name_313"), "NpcFace_guxianlihui", "NpcFace/guchong", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(314, LocalStringManager.GetConfig("EventActors_language", "Name_314"), null, null, null, 1, new byte[2] { 20, 30 }, new short[2] { 0, 900 }, 2, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(315, LocalStringManager.GetConfig("EventActors_language", "Name_315"), null, null, null, 1, new byte[2] { 80, 90 }, new short[2] { 0, 900 }, 11, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(316, LocalStringManager.GetConfig("EventActors_language", "Name_316"), null, null, null, 0, new byte[2] { 80, 90 }, new short[2] { 0, 900 }, 0, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(317, LocalStringManager.GetConfig("EventActors_language", "Name_317"), null, null, null, -1, new byte[2] { 80, 90 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(318, LocalStringManager.GetConfig("EventActors_language", "Name_318"), null, null, null, 1, new byte[2] { 40, 50 }, new short[2] { 200, 300 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(319, LocalStringManager.GetConfig("EventActors_language", "Name_319"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 37, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(320, LocalStringManager.GetConfig("EventActors_language", "Name_320"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 38, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(321, LocalStringManager.GetConfig("EventActors_language", "Name_321"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 38, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(322, LocalStringManager.GetConfig("EventActors_language", "Name_322"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(323, LocalStringManager.GetConfig("EventActors_language", "Name_323"), "NpcFace_xuxiangongrenxing", "NpcFace/xuxiangong_renxing", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(324, LocalStringManager.GetConfig("EventActors_language", "Name_324"), "NpcFace_shenhuoziwuxiaoheiying", "NpcFace/shenhuoziwuxiao_heiying", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(325, LocalStringManager.GetConfig("EventActors_language", "Name_325"), "NpcFace_heiyanziwuxiaorenxinheiying", "NpcFace/heiyanziwuxiao_renxing_heiying", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(326, LocalStringManager.GetConfig("EventActors_language", "Name_326"), "NpcFace_xiaotiejiangheiying", "NpcFace/xiaotiejiang_heiying", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(327, LocalStringManager.GetConfig("EventActors_language", "Name_327"), null, null, null, -1, new byte[2] { 30, 60 }, new short[2] { 0, 900 }, 11, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(328, LocalStringManager.GetConfig("EventActors_language", "Name_328"), null, null, null, 1, new byte[2] { 55, 60 }, new short[2] { 0, 900 }, 19, isMonk: true, 2));
		_dataArray.Add(new EventActorsItem(329, LocalStringManager.GetConfig("EventActors_language", "Name_329"), "NpcFace_pangu", "NpcFace/tianshenpangu", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(330, LocalStringManager.GetConfig("EventActors_language", "Name_330"), "NpcFace_xianfengtiandi", "NpcFace/tianshenxianfengtiandi", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(331, LocalStringManager.GetConfig("EventActors_language", "Name_331"), "NpcFace_fuxi", "NpcFace/fuxi", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(332, LocalStringManager.GetConfig("EventActors_language", "Name_332"), "NpcFace_fuxi", "NpcFace/fuxi", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(333, LocalStringManager.GetConfig("EventActors_language", "Name_333"), "NpcFace_nvwa", "NpcFace/nvwa", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(334, LocalStringManager.GetConfig("EventActors_language", "Name_334"), "NpcFace_nvwa", "NpcFace/nvwa", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(335, LocalStringManager.GetConfig("EventActors_language", "Name_335"), "NpcFace_xiangshu1", "NpcFace/xiangshu_wusuolian", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(336, LocalStringManager.GetConfig("EventActors_language", "Name_336"), "NpcFace_dayuejujian", "NpcFace/dayuejujian", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(337, LocalStringManager.GetConfig("EventActors_language", "Name_337"), "NpcFace_longhunweiqi", "NpcFace/longhun", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(338, LocalStringManager.GetConfig("EventActors_language", "Name_338"), "NpcFace_xueshannvshen", "NpcFace/xueshannvshen", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(339, LocalStringManager.GetConfig("EventActors_language", "Name_339"), "NpcFace_qingling", "NpcFace/xuenvqingling", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(340, LocalStringManager.GetConfig("EventActors_language", "Name_340"), "NpcFace_chouhu", "NpcFace/chouhu", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(341, LocalStringManager.GetConfig("EventActors_language", "Name_341"), "NpcFace_duzhaifu", "NpcFace/duzhaifu", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(342, LocalStringManager.GetConfig("EventActors_language", "Name_342"), "NpcFace_jianmuling", "NpcFace/jianmuling", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(343, LocalStringManager.GetConfig("EventActors_language", "Name_343"), "NpcFace_huimieshijiexingcunzhe", "NpcFace/huimieshijiexingcunzhe", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(344, LocalStringManager.GetConfig("EventActors_language", "Name_344"), "NpcFace_huanggubo", "NpcFace/huanggubo", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(345, LocalStringManager.GetConfig("EventActors_language", "Name_345"), "NpcFace_huanggubonvzixintai", "NpcFace/huanggubo_nv", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(346, LocalStringManager.GetConfig("EventActors_language", "Name_346"), "NpcFace_monvxiaoniao", "NpcFace/monvxiaoniao", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(347, LocalStringManager.GetConfig("EventActors_language", "Name_347"), null, null, null, 1, new byte[2] { 60, 70 }, new short[2] { 0, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(348, LocalStringManager.GetConfig("EventActors_language", "Name_348"), null, null, null, 1, new byte[2] { 60, 70 }, new short[2] { 0, 900 }, 4, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(349, LocalStringManager.GetConfig("EventActors_language", "Name_349"), null, null, null, -1, new byte[2] { 18, 25 }, new short[2] { 0, 900 }, 56, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(350, LocalStringManager.GetConfig("EventActors_language", "Name_350"), null, null, null, -1, new byte[2] { 18, 25 }, new short[2] { 0, 900 }, 56, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(351, LocalStringManager.GetConfig("EventActors_language", "Name_351"), null, null, null, -1, new byte[2] { 18, 25 }, new short[2] { 0, 900 }, 55, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(352, LocalStringManager.GetConfig("EventActors_language", "Name_352"), null, null, null, -1, new byte[2] { 18, 25 }, new short[2] { 0, 900 }, 55, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(353, LocalStringManager.GetConfig("EventActors_language", "Name_353"), null, null, null, 0, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 28, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(354, LocalStringManager.GetConfig("EventActors_language", "Name_354"), null, null, null, 1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 28, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(355, LocalStringManager.GetConfig("EventActors_language", "Name_355"), null, null, null, -1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 57, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(356, LocalStringManager.GetConfig("EventActors_language", "Name_356"), "NpcFace_chiyoubenti", "NpcFace/chiyoubenti", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(357, LocalStringManager.GetConfig("EventActors_language", "Name_357"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 2, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(358, LocalStringManager.GetConfig("EventActors_language", "Name_358"), null, null, null, 1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 13, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(359, LocalStringManager.GetConfig("EventActors_language", "Name_359"), null, null, null, 0, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 13, isMonk: false, -1));
	}

	private void CreateItems6()
	{
		_dataArray.Add(new EventActorsItem(360, LocalStringManager.GetConfig("EventActors_language", "Name_360"), null, null, null, 0, new byte[2] { 10, 13 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(361, LocalStringManager.GetConfig("EventActors_language", "Name_361"), "NpcFace_shanzhuzubei", "NpcFace/shanzhu_zubei", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(362, LocalStringManager.GetConfig("EventActors_language", "Name_362"), "NpcFace_lingshe", "NpcFace/lingshe_zhuxian", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, 2, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(363, LocalStringManager.GetConfig("EventActors_language", "Name_363"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(364, LocalStringManager.GetConfig("EventActors_language", "Name_364"), null, null, null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(365, LocalStringManager.GetConfig("EventActors_language", "Name_365"), "NpcFace_ranchenzidaotong", "NpcFace/ranchenzi_daotong", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(366, LocalStringManager.GetConfig("EventActors_language", "Name_366"), "NpcFace_jinhuangerfenghuangchuniaoxingtai", "NpcFace/fenghuangchuniao", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(367, LocalStringManager.GetConfig("EventActors_language", "Name_367"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 3, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(368, LocalStringManager.GetConfig("EventActors_language", "Name_368"), null, null, null, -1, new byte[2] { 20, 40 }, new short[2] { 0, 900 }, 11, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(369, LocalStringManager.GetConfig("EventActors_language", "Name_369"), null, null, null, -1, new byte[2] { 30, 40 }, new short[2] { 0, 900 }, 23, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(370, LocalStringManager.GetConfig("EventActors_language", "Name_370"), null, null, null, -1, new byte[2] { 18, 25 }, new short[2] { 0, 900 }, 21, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(371, LocalStringManager.GetConfig("EventActors_language", "Name_371"), null, null, null, -1, new byte[2] { 6, 12 }, new short[2] { 0, 900 }, 10, isMonk: false, -1));
		_dataArray.Add(new EventActorsItem(372, LocalStringManager.GetConfig("EventActors_language", "Name_372"), "NpcFace_heiyan", "NpcFace/heiyan", null, -1, new byte[2] { 18, 60 }, new short[2] { 0, 900 }, -1, isMonk: false, -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<EventActorsItem>(373);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
		CreateItems5();
		CreateItems6();
	}
}

using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class CombatConfig : ConfigData<CombatConfigItem, short>
{
	public static class DefKey
	{
		public const short PlayNormal = 0;

		public const short BeatNormal = 1;

		public const short DieNormal = 2;

		public const short TestNormal = 3;

		public const short NpcNormal = 242;

		public const short PlayNoFlee = 4;

		public const short BeatNoFlee = 5;

		public const short DieNoFlee = 6;

		public const short BeatShort = 7;

		public const short BeatMiddle = 8;

		public const short BeatFar = 9;

		public const short DieShort = 10;

		public const short DieMiddle = 11;

		public const short DieFar = 12;

		public const short DieGold = 13;

		public const short DieWood = 14;

		public const short DieWater = 15;

		public const short DieFire = 16;

		public const short DieSoil = 17;

		public const short DieMixed = 18;

		public const short DieGoldNoFlee = 19;

		public const short DieWoodNoFlee = 20;

		public const short DieWaterNoFlee = 21;

		public const short DieFireNoFlee = 22;

		public const short DieSoilNoFlee = 23;

		public const short DieMixedNoFlee = 24;

		public const short DieFistAndPalm = 25;

		public const short DieFinger = 26;

		public const short DieLeg = 27;

		public const short DieThrow = 28;

		public const short DieSword = 29;

		public const short DieBlade = 30;

		public const short DiePolearm = 31;

		public const short DieSpecial = 32;

		public const short DieWhip = 33;

		public const short DieControllableShot = 34;

		public const short DieCombatMusic = 35;

		public const short BossMoNv = 36;

		public const short BossDaYueYaoChang = 37;

		public const short BossJiuHan = 38;

		public const short BossJinHuangEr = 39;

		public const short BossYiYiHou = 40;

		public const short BossWeiQi = 41;

		public const short BossYiXiang = 42;

		public const short BossXueFeng = 43;

		public const short BossShuFang = 44;

		public const short OutBossMoNv = 45;

		public const short OutBossDaYueYaoChang = 46;

		public const short OutBossJiuHan = 47;

		public const short OutBossJinHuangEr = 48;

		public const short OutBossYiYiHou = 49;

		public const short OutBossWeiQi = 50;

		public const short OutBossYiXiang = 51;

		public const short OutBossXueFeng = 52;

		public const short OutBossShuFang = 53;

		public const short RockBossMoNv = 54;

		public const short RockBossDaYueYaoChang = 55;

		public const short RockBossJiuHan = 56;

		public const short RockBossJinHuangEr = 57;

		public const short RockBossYiYiHou = 58;

		public const short RockBossWeiQi = 59;

		public const short RockBossYiXiang = 60;

		public const short RockBossXueFeng = 61;

		public const short RockBossShuFang = 62;

		public const short BambooBossMoNv = 63;

		public const short BambooBossDaYueYaoChang = 64;

		public const short BambooBossJiuHan = 65;

		public const short BambooBossJinHuangEr = 66;

		public const short BambooBossYiYiHou = 67;

		public const short BambooBossWeiQi = 68;

		public const short BambooBossYiXiang = 69;

		public const short BambooBossXueFeng = 70;

		public const short BambooBossShuFang = 71;

		public const short BossXiangShu = 72;

		public const short BossRanChenZi = 73;

		public const short BossHuanXin = 74;

		public const short BossLongYuFu = 75;

		public const short BossZiWuXiao = 76;

		public const short BeatNoReward = 77;

		public const short DieNoReward = 78;

		public const short PlayCombatFistAndPalm = 79;

		public const short PlayCombatFinger = 80;

		public const short PlayCombatLeg = 81;

		public const short PlayCombatThrow = 82;

		public const short PlayCombatSword = 83;

		public const short PlayCombatBlade = 84;

		public const short PlayCombatPolearm = 85;

		public const short PlayCombatSpecial = 86;

		public const short PlayCombatWhip = 87;

		public const short PlayCombatControllableShot = 88;

		public const short PlayCombatMusic = 89;

		public const short WulinConferenceShaolin = 90;

		public const short WulinConferenceEmei = 91;

		public const short WulinConferenceBaihua = 92;

		public const short WulinConferenceWudang = 93;

		public const short WulinConferenceYuanshan = 94;

		public const short WulinConferenceShixiang = 95;

		public const short WulinConferenceRanshan = 96;

		public const short WulinConferenceXuannv = 97;

		public const short WulinConferenceZhujian = 98;

		public const short WulinConferenceKongsang = 99;

		public const short WulinConferenceJingang = 100;

		public const short WulinConferenceWuxian = 101;

		public const short WulinConferenceJieqing = 102;

		public const short WulinConferenceFulong = 103;

		public const short WulinConferenceXuehou = 104;

		public const short PlayCombatShaolin = 105;

		public const short PlayCombatEmei = 106;

		public const short PlayCombatBaihua = 107;

		public const short PlayCombatWudang = 108;

		public const short PlayCombatYuanshan = 109;

		public const short PlayCombatShixiang = 110;

		public const short PlayCombatRanshan = 111;

		public const short PlayCombatXuannv = 112;

		public const short PlayCombatZhujian = 113;

		public const short PlayCombatKongsang = 114;

		public const short PlayCombatJingang = 115;

		public const short PlayCombatWuxian = 116;

		public const short PlayCombatJieqing = 117;

		public const short PlayCombatFulong = 118;

		public const short PlayCombatXuehou = 119;

		public const short PlayNoKidnap = 120;

		public const short BeatNoKidnap = 121;

		public const short DieNoKidnap = 122;

		public const short BeatNone = 123;

		public const short DieNone = 124;

		public const short Tutorial3 = 249;

		public const short Tutorial4 = 125;

		public const short OutBossMoNvNoFlee = 126;

		public const short OutBossDaYueYaoChangNoFlee = 127;

		public const short OutBossJiuHanNoFlee = 128;

		public const short OutBossJinHuangErNoFlee = 129;

		public const short OutBossYiYiHouNoFlee = 130;

		public const short OutBossWeiQiNoFlee = 131;

		public const short OutBossYiXiangNoFlee = 132;

		public const short OutBossXueFengNoFlee = 133;

		public const short OutBossShuFangNoFlee = 134;

		public const short BossXiangShuNoFlee = 135;

		public const short TestCombat1Count = 136;

		public const short TestCombat2Count = 137;

		public const short TestCombat3Count = 138;

		public const short TestCombat4Count = 139;

		public const short TestCombat5Count = 140;

		public const short TestCombat6Count = 141;

		public const short TestCombat7Count = 142;

		public const short TestCombat8Count = 143;

		public const short TestCombat9Count = 144;

		public const short BeatNoRewardKidnapFlee = 145;

		public const short BeatCombatFistAndPalm = 146;

		public const short BeatCombatFinger = 147;

		public const short BeatCombatLeg = 148;

		public const short BeatCombatThrow = 149;

		public const short BeatCombatSword = 150;

		public const short BeatCombatBlade = 151;

		public const short BeatCombatPolearm = 152;

		public const short BeatCombatSpecial = 153;

		public const short BeatCombatWhip = 154;

		public const short BeatCombatControllableShot = 155;

		public const short BeatCombatMusic = 156;

		public const short LegendaryBookAdventurePosingBeat = 157;

		public const short LegendaryBookAdventurePosingDie = 158;

		public const short LegendaryBookAdventureStuntBeat = 159;

		public const short LegendaryBookAdventureStuntDie = 160;

		public const short LegendaryBookUnlock = 161;

		public const short LegendaryBookConsumed = 162;

		public const short BeatEnemyHealDamage = 163;

		public const short LiaoWumingTryPoison0 = 164;

		public const short LiaoWumingTryPoison1 = 165;

		public const short LiaoWumingTryPoison2 = 166;

		public const short DieNoRewardKidnapFlee = 167;

		public const short BeatNoKidnapEnemyNoFlee = 168;

		public const short DieNoKidnapFlee = 169;

		public const short BeatNoKidnapFlee = 170;

		public const short ShaoLinStory = 171;

		public const short PlayNormalInTeam = 172;

		public const short DieJixi = 173;

		public const short DieLiaoWuming = 174;

		public const short PlayNoKidnapRewardFlee = 175;

		public const short SectMainStoryEmeiDie = 176;

		public const short ShiHoujiuFirstCombat = 177;

		public const short BeatNoKidnapEscapeWithReward = 178;

		public const short DieMixedForEscape = 179;

		public const short DieNoKidnapFleeExecution = 180;

		public const short DieNoKidnapExecution = 181;

		public const short LoongWhite = 182;

		public const short LoongBlack = 183;

		public const short LoongGreen = 184;

		public const short LoongRed = 185;

		public const short LoongYellow = 186;

		public const short MinionLoongWhite = 187;

		public const short MinionLoongBlack = 188;

		public const short MinionLoongGreen = 189;

		public const short MinionLoongRed = 190;

		public const short MinionLoongYellow = 191;

		public const short JiaoCombatNoCarrierReceived = 192;

		public const short InfectedCombat = 193;

		public const short DieZhuxian = 194;

		public const short BeatCombatHuaju = 195;

		public const short BeatCombatXuanzhi = 196;

		public const short BeatCombatRanshan = 197;

		public const short BaihuaAnonymEscape = 198;

		public const short BeatNoKidNapNoEscapeEnemyDisplayTitle = 199;

		public const short DieZhuxian1 = 200;

		public const short BeatCombatRanshanNeg = 201;

		public const short BeatCombatRanshanNeg1 = 202;

		public const short BaihuaAnonymInvincible = 203;

		public const short BaihuaAnonymFinalBattle = 204;

		public const short FulongNoSeventySevenBattle = 205;

		public const short DieNoKidnapNoEnemyFlee = 206;

		public const short DieNoKidnapRewardExecution = 207;

		public const short BeatCombatZhujian = 208;

		public const short BeatCombatInsidefurnace = 209;

		public const short DieYanshi = 210;

		public const short DemonSlayerTrialDefault = 211;

		public const short PlayWithGearMate = 223;

		public const short InteractionTimeLimit = 224;

		public const short SectMainStoryYuanshanDieNoFlee = 225;

		public const short SectMainStoryYuanshaBeatNoRewardKidnapFlee = 226;

		public const short FightDeepGuard = 227;

		public const short FightGuard = 228;

		public const short TutorialNeilCombat = 241;

		public const short SectStoryXuehouInvincibleManInRed = 229;

		public const short FiveElementsStoneMetal0 = 230;

		public const short FiveElementsStoneWood0 = 231;

		public const short FiveElementsStoneWater0 = 232;

		public const short FiveElementsStoneFire0 = 233;

		public const short FiveElementsStoneEarth0 = 234;

		public const short FiveElementsStoneMetal1 = 235;

		public const short FiveElementsStoneWood1 = 236;

		public const short FiveElementsStoneWater1 = 237;

		public const short FiveElementsStoneFire1 = 238;

		public const short FiveElementsStoneEarth1 = 239;

		public const short SectStoryJieqingYuchanAssists = 243;

		public const short SectStoryJieqingMilevilion = 244;

		public const short MainStoryMeetYufu = 245;

		public const short NpcWulinNormal = 246;

		public const short MainStoryImmortalsCombat = 250;

		public const short DieNoKidnapRewardFleeExecution = 253;

		public const short FenChenCombat = 254;

		public const short WanXiangMiXinCombat = 255;

		public const short XieYinLuanXinCombat = 256;

		public const short XionMoRanXinCombat = 257;

		public const short ShihoujiuBeatNormal = 258;

		public const short EmeiBattleNormal = 259;

		public const short XiaoHeShangCombat = 260;

		public const short XiangshuMinionBeatNormal = 261;

		public const short XiangshuMinionDieNormal = 262;
	}

	public static class DefValue
	{
		public static CombatConfigItem PlayNormal => Instance[(short)0];

		public static CombatConfigItem BeatNormal => Instance[(short)1];

		public static CombatConfigItem DieNormal => Instance[(short)2];

		public static CombatConfigItem TestNormal => Instance[(short)3];

		public static CombatConfigItem NpcNormal => Instance[(short)242];

		public static CombatConfigItem PlayNoFlee => Instance[(short)4];

		public static CombatConfigItem BeatNoFlee => Instance[(short)5];

		public static CombatConfigItem DieNoFlee => Instance[(short)6];

		public static CombatConfigItem BeatShort => Instance[(short)7];

		public static CombatConfigItem BeatMiddle => Instance[(short)8];

		public static CombatConfigItem BeatFar => Instance[(short)9];

		public static CombatConfigItem DieShort => Instance[(short)10];

		public static CombatConfigItem DieMiddle => Instance[(short)11];

		public static CombatConfigItem DieFar => Instance[(short)12];

		public static CombatConfigItem DieGold => Instance[(short)13];

		public static CombatConfigItem DieWood => Instance[(short)14];

		public static CombatConfigItem DieWater => Instance[(short)15];

		public static CombatConfigItem DieFire => Instance[(short)16];

		public static CombatConfigItem DieSoil => Instance[(short)17];

		public static CombatConfigItem DieMixed => Instance[(short)18];

		public static CombatConfigItem DieGoldNoFlee => Instance[(short)19];

		public static CombatConfigItem DieWoodNoFlee => Instance[(short)20];

		public static CombatConfigItem DieWaterNoFlee => Instance[(short)21];

		public static CombatConfigItem DieFireNoFlee => Instance[(short)22];

		public static CombatConfigItem DieSoilNoFlee => Instance[(short)23];

		public static CombatConfigItem DieMixedNoFlee => Instance[(short)24];

		public static CombatConfigItem DieFistAndPalm => Instance[(short)25];

		public static CombatConfigItem DieFinger => Instance[(short)26];

		public static CombatConfigItem DieLeg => Instance[(short)27];

		public static CombatConfigItem DieThrow => Instance[(short)28];

		public static CombatConfigItem DieSword => Instance[(short)29];

		public static CombatConfigItem DieBlade => Instance[(short)30];

		public static CombatConfigItem DiePolearm => Instance[(short)31];

		public static CombatConfigItem DieSpecial => Instance[(short)32];

		public static CombatConfigItem DieWhip => Instance[(short)33];

		public static CombatConfigItem DieControllableShot => Instance[(short)34];

		public static CombatConfigItem DieCombatMusic => Instance[(short)35];

		public static CombatConfigItem BossMoNv => Instance[(short)36];

		public static CombatConfigItem BossDaYueYaoChang => Instance[(short)37];

		public static CombatConfigItem BossJiuHan => Instance[(short)38];

		public static CombatConfigItem BossJinHuangEr => Instance[(short)39];

		public static CombatConfigItem BossYiYiHou => Instance[(short)40];

		public static CombatConfigItem BossWeiQi => Instance[(short)41];

		public static CombatConfigItem BossYiXiang => Instance[(short)42];

		public static CombatConfigItem BossXueFeng => Instance[(short)43];

		public static CombatConfigItem BossShuFang => Instance[(short)44];

		public static CombatConfigItem OutBossMoNv => Instance[(short)45];

		public static CombatConfigItem OutBossDaYueYaoChang => Instance[(short)46];

		public static CombatConfigItem OutBossJiuHan => Instance[(short)47];

		public static CombatConfigItem OutBossJinHuangEr => Instance[(short)48];

		public static CombatConfigItem OutBossYiYiHou => Instance[(short)49];

		public static CombatConfigItem OutBossWeiQi => Instance[(short)50];

		public static CombatConfigItem OutBossYiXiang => Instance[(short)51];

		public static CombatConfigItem OutBossXueFeng => Instance[(short)52];

		public static CombatConfigItem OutBossShuFang => Instance[(short)53];

		public static CombatConfigItem RockBossMoNv => Instance[(short)54];

		public static CombatConfigItem RockBossDaYueYaoChang => Instance[(short)55];

		public static CombatConfigItem RockBossJiuHan => Instance[(short)56];

		public static CombatConfigItem RockBossJinHuangEr => Instance[(short)57];

		public static CombatConfigItem RockBossYiYiHou => Instance[(short)58];

		public static CombatConfigItem RockBossWeiQi => Instance[(short)59];

		public static CombatConfigItem RockBossYiXiang => Instance[(short)60];

		public static CombatConfigItem RockBossXueFeng => Instance[(short)61];

		public static CombatConfigItem RockBossShuFang => Instance[(short)62];

		public static CombatConfigItem BambooBossMoNv => Instance[(short)63];

		public static CombatConfigItem BambooBossDaYueYaoChang => Instance[(short)64];

		public static CombatConfigItem BambooBossJiuHan => Instance[(short)65];

		public static CombatConfigItem BambooBossJinHuangEr => Instance[(short)66];

		public static CombatConfigItem BambooBossYiYiHou => Instance[(short)67];

		public static CombatConfigItem BambooBossWeiQi => Instance[(short)68];

		public static CombatConfigItem BambooBossYiXiang => Instance[(short)69];

		public static CombatConfigItem BambooBossXueFeng => Instance[(short)70];

		public static CombatConfigItem BambooBossShuFang => Instance[(short)71];

		public static CombatConfigItem BossXiangShu => Instance[(short)72];

		public static CombatConfigItem BossRanChenZi => Instance[(short)73];

		public static CombatConfigItem BossHuanXin => Instance[(short)74];

		public static CombatConfigItem BossLongYuFu => Instance[(short)75];

		public static CombatConfigItem BossZiWuXiao => Instance[(short)76];

		public static CombatConfigItem BeatNoReward => Instance[(short)77];

		public static CombatConfigItem DieNoReward => Instance[(short)78];

		public static CombatConfigItem PlayCombatFistAndPalm => Instance[(short)79];

		public static CombatConfigItem PlayCombatFinger => Instance[(short)80];

		public static CombatConfigItem PlayCombatLeg => Instance[(short)81];

		public static CombatConfigItem PlayCombatThrow => Instance[(short)82];

		public static CombatConfigItem PlayCombatSword => Instance[(short)83];

		public static CombatConfigItem PlayCombatBlade => Instance[(short)84];

		public static CombatConfigItem PlayCombatPolearm => Instance[(short)85];

		public static CombatConfigItem PlayCombatSpecial => Instance[(short)86];

		public static CombatConfigItem PlayCombatWhip => Instance[(short)87];

		public static CombatConfigItem PlayCombatControllableShot => Instance[(short)88];

		public static CombatConfigItem PlayCombatMusic => Instance[(short)89];

		public static CombatConfigItem WulinConferenceShaolin => Instance[(short)90];

		public static CombatConfigItem WulinConferenceEmei => Instance[(short)91];

		public static CombatConfigItem WulinConferenceBaihua => Instance[(short)92];

		public static CombatConfigItem WulinConferenceWudang => Instance[(short)93];

		public static CombatConfigItem WulinConferenceYuanshan => Instance[(short)94];

		public static CombatConfigItem WulinConferenceShixiang => Instance[(short)95];

		public static CombatConfigItem WulinConferenceRanshan => Instance[(short)96];

		public static CombatConfigItem WulinConferenceXuannv => Instance[(short)97];

		public static CombatConfigItem WulinConferenceZhujian => Instance[(short)98];

		public static CombatConfigItem WulinConferenceKongsang => Instance[(short)99];

		public static CombatConfigItem WulinConferenceJingang => Instance[(short)100];

		public static CombatConfigItem WulinConferenceWuxian => Instance[(short)101];

		public static CombatConfigItem WulinConferenceJieqing => Instance[(short)102];

		public static CombatConfigItem WulinConferenceFulong => Instance[(short)103];

		public static CombatConfigItem WulinConferenceXuehou => Instance[(short)104];

		public static CombatConfigItem PlayCombatShaolin => Instance[(short)105];

		public static CombatConfigItem PlayCombatEmei => Instance[(short)106];

		public static CombatConfigItem PlayCombatBaihua => Instance[(short)107];

		public static CombatConfigItem PlayCombatWudang => Instance[(short)108];

		public static CombatConfigItem PlayCombatYuanshan => Instance[(short)109];

		public static CombatConfigItem PlayCombatShixiang => Instance[(short)110];

		public static CombatConfigItem PlayCombatRanshan => Instance[(short)111];

		public static CombatConfigItem PlayCombatXuannv => Instance[(short)112];

		public static CombatConfigItem PlayCombatZhujian => Instance[(short)113];

		public static CombatConfigItem PlayCombatKongsang => Instance[(short)114];

		public static CombatConfigItem PlayCombatJingang => Instance[(short)115];

		public static CombatConfigItem PlayCombatWuxian => Instance[(short)116];

		public static CombatConfigItem PlayCombatJieqing => Instance[(short)117];

		public static CombatConfigItem PlayCombatFulong => Instance[(short)118];

		public static CombatConfigItem PlayCombatXuehou => Instance[(short)119];

		public static CombatConfigItem PlayNoKidnap => Instance[(short)120];

		public static CombatConfigItem BeatNoKidnap => Instance[(short)121];

		public static CombatConfigItem DieNoKidnap => Instance[(short)122];

		public static CombatConfigItem BeatNone => Instance[(short)123];

		public static CombatConfigItem DieNone => Instance[(short)124];

		public static CombatConfigItem Tutorial3 => Instance[(short)249];

		public static CombatConfigItem Tutorial4 => Instance[(short)125];

		public static CombatConfigItem OutBossMoNvNoFlee => Instance[(short)126];

		public static CombatConfigItem OutBossDaYueYaoChangNoFlee => Instance[(short)127];

		public static CombatConfigItem OutBossJiuHanNoFlee => Instance[(short)128];

		public static CombatConfigItem OutBossJinHuangErNoFlee => Instance[(short)129];

		public static CombatConfigItem OutBossYiYiHouNoFlee => Instance[(short)130];

		public static CombatConfigItem OutBossWeiQiNoFlee => Instance[(short)131];

		public static CombatConfigItem OutBossYiXiangNoFlee => Instance[(short)132];

		public static CombatConfigItem OutBossXueFengNoFlee => Instance[(short)133];

		public static CombatConfigItem OutBossShuFangNoFlee => Instance[(short)134];

		public static CombatConfigItem BossXiangShuNoFlee => Instance[(short)135];

		public static CombatConfigItem TestCombat1Count => Instance[(short)136];

		public static CombatConfigItem TestCombat2Count => Instance[(short)137];

		public static CombatConfigItem TestCombat3Count => Instance[(short)138];

		public static CombatConfigItem TestCombat4Count => Instance[(short)139];

		public static CombatConfigItem TestCombat5Count => Instance[(short)140];

		public static CombatConfigItem TestCombat6Count => Instance[(short)141];

		public static CombatConfigItem TestCombat7Count => Instance[(short)142];

		public static CombatConfigItem TestCombat8Count => Instance[(short)143];

		public static CombatConfigItem TestCombat9Count => Instance[(short)144];

		public static CombatConfigItem BeatNoRewardKidnapFlee => Instance[(short)145];

		public static CombatConfigItem BeatCombatFistAndPalm => Instance[(short)146];

		public static CombatConfigItem BeatCombatFinger => Instance[(short)147];

		public static CombatConfigItem BeatCombatLeg => Instance[(short)148];

		public static CombatConfigItem BeatCombatThrow => Instance[(short)149];

		public static CombatConfigItem BeatCombatSword => Instance[(short)150];

		public static CombatConfigItem BeatCombatBlade => Instance[(short)151];

		public static CombatConfigItem BeatCombatPolearm => Instance[(short)152];

		public static CombatConfigItem BeatCombatSpecial => Instance[(short)153];

		public static CombatConfigItem BeatCombatWhip => Instance[(short)154];

		public static CombatConfigItem BeatCombatControllableShot => Instance[(short)155];

		public static CombatConfigItem BeatCombatMusic => Instance[(short)156];

		public static CombatConfigItem LegendaryBookAdventurePosingBeat => Instance[(short)157];

		public static CombatConfigItem LegendaryBookAdventurePosingDie => Instance[(short)158];

		public static CombatConfigItem LegendaryBookAdventureStuntBeat => Instance[(short)159];

		public static CombatConfigItem LegendaryBookAdventureStuntDie => Instance[(short)160];

		public static CombatConfigItem LegendaryBookUnlock => Instance[(short)161];

		public static CombatConfigItem LegendaryBookConsumed => Instance[(short)162];

		public static CombatConfigItem BeatEnemyHealDamage => Instance[(short)163];

		public static CombatConfigItem LiaoWumingTryPoison0 => Instance[(short)164];

		public static CombatConfigItem LiaoWumingTryPoison1 => Instance[(short)165];

		public static CombatConfigItem LiaoWumingTryPoison2 => Instance[(short)166];

		public static CombatConfigItem DieNoRewardKidnapFlee => Instance[(short)167];

		public static CombatConfigItem BeatNoKidnapEnemyNoFlee => Instance[(short)168];

		public static CombatConfigItem DieNoKidnapFlee => Instance[(short)169];

		public static CombatConfigItem BeatNoKidnapFlee => Instance[(short)170];

		public static CombatConfigItem ShaoLinStory => Instance[(short)171];

		public static CombatConfigItem PlayNormalInTeam => Instance[(short)172];

		public static CombatConfigItem DieJixi => Instance[(short)173];

		public static CombatConfigItem DieLiaoWuming => Instance[(short)174];

		public static CombatConfigItem PlayNoKidnapRewardFlee => Instance[(short)175];

		public static CombatConfigItem SectMainStoryEmeiDie => Instance[(short)176];

		public static CombatConfigItem ShiHoujiuFirstCombat => Instance[(short)177];

		public static CombatConfigItem BeatNoKidnapEscapeWithReward => Instance[(short)178];

		public static CombatConfigItem DieMixedForEscape => Instance[(short)179];

		public static CombatConfigItem DieNoKidnapFleeExecution => Instance[(short)180];

		public static CombatConfigItem DieNoKidnapExecution => Instance[(short)181];

		public static CombatConfigItem LoongWhite => Instance[(short)182];

		public static CombatConfigItem LoongBlack => Instance[(short)183];

		public static CombatConfigItem LoongGreen => Instance[(short)184];

		public static CombatConfigItem LoongRed => Instance[(short)185];

		public static CombatConfigItem LoongYellow => Instance[(short)186];

		public static CombatConfigItem MinionLoongWhite => Instance[(short)187];

		public static CombatConfigItem MinionLoongBlack => Instance[(short)188];

		public static CombatConfigItem MinionLoongGreen => Instance[(short)189];

		public static CombatConfigItem MinionLoongRed => Instance[(short)190];

		public static CombatConfigItem MinionLoongYellow => Instance[(short)191];

		public static CombatConfigItem JiaoCombatNoCarrierReceived => Instance[(short)192];

		public static CombatConfigItem InfectedCombat => Instance[(short)193];

		public static CombatConfigItem DieZhuxian => Instance[(short)194];

		public static CombatConfigItem BeatCombatHuaju => Instance[(short)195];

		public static CombatConfigItem BeatCombatXuanzhi => Instance[(short)196];

		public static CombatConfigItem BeatCombatRanshan => Instance[(short)197];

		public static CombatConfigItem BaihuaAnonymEscape => Instance[(short)198];

		public static CombatConfigItem BeatNoKidNapNoEscapeEnemyDisplayTitle => Instance[(short)199];

		public static CombatConfigItem DieZhuxian1 => Instance[(short)200];

		public static CombatConfigItem BeatCombatRanshanNeg => Instance[(short)201];

		public static CombatConfigItem BeatCombatRanshanNeg1 => Instance[(short)202];

		public static CombatConfigItem BaihuaAnonymInvincible => Instance[(short)203];

		public static CombatConfigItem BaihuaAnonymFinalBattle => Instance[(short)204];

		public static CombatConfigItem FulongNoSeventySevenBattle => Instance[(short)205];

		public static CombatConfigItem DieNoKidnapNoEnemyFlee => Instance[(short)206];

		public static CombatConfigItem DieNoKidnapRewardExecution => Instance[(short)207];

		public static CombatConfigItem BeatCombatZhujian => Instance[(short)208];

		public static CombatConfigItem BeatCombatInsidefurnace => Instance[(short)209];

		public static CombatConfigItem DieYanshi => Instance[(short)210];

		public static CombatConfigItem DemonSlayerTrialDefault => Instance[(short)211];

		public static CombatConfigItem PlayWithGearMate => Instance[(short)223];

		public static CombatConfigItem InteractionTimeLimit => Instance[(short)224];

		public static CombatConfigItem SectMainStoryYuanshanDieNoFlee => Instance[(short)225];

		public static CombatConfigItem SectMainStoryYuanshaBeatNoRewardKidnapFlee => Instance[(short)226];

		public static CombatConfigItem FightDeepGuard => Instance[(short)227];

		public static CombatConfigItem FightGuard => Instance[(short)228];

		public static CombatConfigItem TutorialNeilCombat => Instance[(short)241];

		public static CombatConfigItem SectStoryXuehouInvincibleManInRed => Instance[(short)229];

		public static CombatConfigItem FiveElementsStoneMetal0 => Instance[(short)230];

		public static CombatConfigItem FiveElementsStoneWood0 => Instance[(short)231];

		public static CombatConfigItem FiveElementsStoneWater0 => Instance[(short)232];

		public static CombatConfigItem FiveElementsStoneFire0 => Instance[(short)233];

		public static CombatConfigItem FiveElementsStoneEarth0 => Instance[(short)234];

		public static CombatConfigItem FiveElementsStoneMetal1 => Instance[(short)235];

		public static CombatConfigItem FiveElementsStoneWood1 => Instance[(short)236];

		public static CombatConfigItem FiveElementsStoneWater1 => Instance[(short)237];

		public static CombatConfigItem FiveElementsStoneFire1 => Instance[(short)238];

		public static CombatConfigItem FiveElementsStoneEarth1 => Instance[(short)239];

		public static CombatConfigItem SectStoryJieqingYuchanAssists => Instance[(short)243];

		public static CombatConfigItem SectStoryJieqingMilevilion => Instance[(short)244];

		public static CombatConfigItem MainStoryMeetYufu => Instance[(short)245];

		public static CombatConfigItem NpcWulinNormal => Instance[(short)246];

		public static CombatConfigItem MainStoryImmortalsCombat => Instance[(short)250];

		public static CombatConfigItem DieNoKidnapRewardFleeExecution => Instance[(short)253];

		public static CombatConfigItem FenChenCombat => Instance[(short)254];

		public static CombatConfigItem WanXiangMiXinCombat => Instance[(short)255];

		public static CombatConfigItem XieYinLuanXinCombat => Instance[(short)256];

		public static CombatConfigItem XionMoRanXinCombat => Instance[(short)257];

		public static CombatConfigItem ShihoujiuBeatNormal => Instance[(short)258];

		public static CombatConfigItem EmeiBattleNormal => Instance[(short)259];

		public static CombatConfigItem XiaoHeShangCombat => Instance[(short)260];

		public static CombatConfigItem XiangshuMinionBeatNormal => Instance[(short)261];

		public static CombatConfigItem XiangshuMinionDieNormal => Instance[(short)262];
	}

	public static CombatConfig Instance = new CombatConfig();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "SpecialTeammateCommands", "SpecialTeammateCommandBubbleTexts", "CombatSkillType", "Sect", "CaptureRequireRope", "Scene", "EnemyAi", "TemplateId", "Bgm" };

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
		_dataArray.Add(new CombatConfigItem(0, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(1, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(2, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(3, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 5400u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(4, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(5, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(6, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(7, 1, isBossCombat: false, 20, 60, -1, 60, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(8, 1, isBossCombat: false, 50, 90, -1, 90, 70, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(9, 1, isBossCombat: false, 80, 120, -1, 120, 100, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(10, 2, isBossCombat: false, 20, 60, -1, 60, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(11, 2, isBossCombat: false, 50, 90, -1, 90, 70, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(12, 2, isBossCombat: false, 80, 120, -1, 120, 100, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(13, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 0 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(14, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 1 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(15, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 2 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(16, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 3 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(17, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 4 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(18, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 5 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(19, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 0 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(20, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 1 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(21, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 2 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(22, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 3 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(23, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 4 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(24, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 5 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(25, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 3 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(26, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 4 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(27, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 5 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(28, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 6 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(29, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 7 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(30, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 8 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(31, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 9 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(32, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 10 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(33, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 11 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(34, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 12 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(35, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 13 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(36, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_monv_monvyi" }, 31, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(37, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_dayueyaochang_zhanyaoji" }, 27, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(38, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jiuhan_hanshankongming" }, 25, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(39, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jinhuanger_fenghuangjian" }, 26, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(40, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yiyihou_yiwuyuhongyan" }, 28, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(41, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_weiqi_hualong" }, 24, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(42, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yixiang_rongchenyin" }, 23, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(43, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_xuefeng_aozhan" }, 29, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(44, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_shufang_jiucaixia" }, 30, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(45, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_monv_monvyi" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(46, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_dayueyaochang_zhanyaoji" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(47, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jiuhan_hanshankongming" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(48, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jinhuanger_fenghuangjian" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(49, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yiyihou_yiwuyuhongyan" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(50, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_weiqi_hualong" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(51, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yixiang_rongchenyin" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(52, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_xuefeng_aozhan" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(53, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: true, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_shufang_jiucaixia" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(54, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_monv_monvyi" }, 31, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(55, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_dayueyaochang_zhanyaoji" }, 27, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(56, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jiuhan_hanshankongming" }, 25, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(57, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jinhuanger_fenghuangjian" }, 26, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(58, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yiyihou_yiwuyuhongyan" }, 28, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(59, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_weiqi_hualong" }, 24, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new CombatConfigItem(60, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yixiang_rongchenyin" }, 23, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(61, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_xuefeng_aozhan" }, 29, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(62, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_shufang_jiucaixia" }, 30, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(63, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_monv_monvyi" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(64, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_dayueyaochang_zhanyaoji" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(65, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jiuhan_hanshankongming" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(66, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_jinhuanger_fenghuangjian" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(67, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yiyihou_yiwuyuhongyan" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(68, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_weiqi_hualong" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(69, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yixiang_rongchenyin" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(70, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_xuefeng_aozhan" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(71, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 300, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_shufang_jiucaixia" }, -1, -1, skipChangePhase: false, startInSecondPhase: true, 1f));
		_dataArray.Add(new CombatConfigItem(72, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_xs" }, 39, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(73, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[3] { "combat_rcz_part_1", "combat_rcz_part_2", "combat_rcz_part_3" }, 40, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(74, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_hx" }, 34, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(75, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_yufu" }, 32, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(76, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_zwx" }, 33, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(77, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(78, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(79, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 3 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(80, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 4 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(81, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 5 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(82, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 6 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(83, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 7 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(84, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 8 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(85, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 9 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(86, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 10 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(87, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 11 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(88, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 12 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(89, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 13 }, -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(90, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(91, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 2, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(92, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 3, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(93, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 4, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(94, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 5, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(95, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 6, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(96, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 7, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(97, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 8, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(98, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 9, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(99, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 10, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(100, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 11, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(101, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 12, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(102, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 13, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(103, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 14, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(104, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 15, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(105, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(106, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 2, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(107, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 3, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(108, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 4, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(109, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 5, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(110, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 6, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(111, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 7, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(112, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 8, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(113, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 9, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(114, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 10, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(115, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 11, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(116, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 12, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(117, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 13, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(118, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 14, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(119, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), 15, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
	}

	private void CreateItems2()
	{
		_dataArray.Add(new CombatConfigItem(120, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(121, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(122, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(123, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(124, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(125, 2, isBossCombat: true, 20, 120, 45, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(126, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_monv_monvyi" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(127, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_dayueyaochang_zhanyaoji" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(128, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_jiuhan_hanshankongming" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(129, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_jinhuanger_fenghuangjian" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(130, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_yiyihou_yiwuyuhongyan" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(131, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_weiqi_hualong" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(132, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_yixiang_rongchenyin" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(133, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_xuefeng_aozhan" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(134, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_shufang_jiucaixia" }, -1, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(135, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.RightWin, 1800u, new string[1] { "combat_xs" }, 39, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(136, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 1800u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(137, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 2700u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(138, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 3600u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(139, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 4500u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(140, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 5400u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(141, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 6300u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(142, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 7200u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(143, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 8100u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(144, 3, isBossCombat: false, 20, 120, 40, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 9000u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(145, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(146, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 3 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(147, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 4 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(148, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 5 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(149, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 6 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(150, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 7 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(151, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 8 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(152, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 9 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(153, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 10 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(154, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 11 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(155, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 12 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(156, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte> { 1, 2, 13 }, -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(157, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(158, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(159, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(160, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(161, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: false, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "legendbookbattle" }, 43, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(162, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "legendbookbattle" }, 43, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(163, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: true, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: false, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(164, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(165, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(166, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(167, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(168, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(169, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(170, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(171, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "story_shaolin" }, 44, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(172, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(173, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: true, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(174, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(175, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(176, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_emei" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(177, 0, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: true, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(178, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(179, 2, isBossCombat: false, 20, 120, 110, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte> { 5 }, new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
	}

	private void CreateItems3()
	{
		_dataArray.Add(new CombatConfigItem(180, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(181, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(182, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 200, lootAllInventory: false, 100, 275, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "loong_battle" }, 45, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(183, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 200, lootAllInventory: false, 100, 275, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "loong_battle" }, 46, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(184, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 200, lootAllInventory: false, 100, 275, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "loong_battle" }, 47, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(185, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 200, lootAllInventory: false, 100, 275, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "loong_battle" }, 48, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(186, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 200, lootAllInventory: false, 100, 275, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "loong_battle" }, 49, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(187, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: true, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 45, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(188, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: true, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 46, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(189, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: true, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 47, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(190, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: true, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 48, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(191, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: true, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 49, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(192, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(193, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(194, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>
		{
			new List<sbyte> { 34, 38, 32 },
			new List<sbyte> { 33, 31, 32 },
			new List<sbyte> { 36, 37, 35 }
		}, new string[3]
		{
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_194_0"),
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_194_1"),
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_194_2")
		}, new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_ranshan" }, 50, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(195, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>
		{
			new List<sbyte>(),
			new List<sbyte> { 34, 38, 32 },
			new List<sbyte>()
		}, new string[3]
		{
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_195_0"),
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_195_1"),
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_195_2")
		}, new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(196, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>
		{
			new List<sbyte>(),
			new List<sbyte>(),
			new List<sbyte> { 33, 31, 32 }
		}, new string[3]
		{
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_196_0"),
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_196_1"),
			LocalStringManager.GetConfig("CombatConfig_language", "SpecialTeammateCommandBubbleTexts_196_2")
		}, new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(197, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 50, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(198, 1, isBossCombat: true, 20, 120, 90, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: true, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, 1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(199, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: true, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(200, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_ranshan" }, 50, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(201, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>
		{
			new List<sbyte> { 31, 36, 38 },
			new List<sbyte>(),
			new List<sbyte>()
		}, new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, 50, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(202, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>
		{
			new List<sbyte> { 33, 31, 32 },
			new List<sbyte>(),
			new List<sbyte>()
		}, new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(203, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 1800u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(204, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(205, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_fulongtan2" }, 51, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(206, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(207, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(208, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(209, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_zhujian" }, 52, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(210, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_zhujian" }, 52, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(211, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(212, 2, isBossCombat: false, 20, 90, 20, 90, 70, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(213, 2, isBossCombat: false, 50, 120, 120, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(214, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 28800u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(215, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 14400u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(216, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 7200u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(217, 2, isBossCombat: false, 20, 90, 20, 90, 70, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 28800u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(218, 2, isBossCombat: false, 20, 90, 20, 90, 70, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 14400u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(219, 2, isBossCombat: false, 20, 90, 20, 90, 70, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 7200u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(220, 2, isBossCombat: false, 50, 120, 120, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 28800u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(221, 2, isBossCombat: false, 50, 120, 120, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 14400u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(222, 2, isBossCombat: false, 50, 120, 120, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: true, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 7200u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(223, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, 25, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(224, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.LeftWin, 7200u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(225, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "sectstory_yuanshan" }, 53, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(226, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(227, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: true, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(228, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: false, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: true, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(229, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 1800u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(230, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(231, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(232, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(233, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(234, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(235, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(236, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(237, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(238, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(239, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
	}

	private void CreateItems4()
	{
		_dataArray.Add(new CombatConfigItem(240, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(241, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.RightWin, 2700u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(242, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.TiredMark, 10800u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(243, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(244, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(245, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(246, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.TiredMark, 10800u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(247, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: false, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(248, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(249, 2, isBossCombat: false, 20, 120, 70, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(250, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_twelve_immortals" }, 43, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(251, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_xs" }, 39, -1, skipChangePhase: false, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(252, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "mainstory_lastbattle_part_1" }, 57, -1, skipChangePhase: true, startInSecondPhase: false, 0.6f));
		_dataArray.Add(new CombatConfigItem(253, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(254, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_zwx" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(255, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_03" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(256, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_04" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(257, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_05" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(258, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: true, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(259, 0, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: false, allowRandomFavorability: true, allowPrepare: false, allowVitalDemon: false, allowVitalDemonBetray: false, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: false, allowDropItem: false, 0, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.TiredMark, 10800u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(260, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: false, 100, lootAllInventory: false, 100, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "combat_05" }, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(261, 1, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(262, 2, isBossCombat: false, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: true, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
		_dataArray.Add(new CombatConfigItem(263, 2, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: false, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: true, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 0, -1, captureNoCarrier: false, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, new string[1] { "mainstory_lastbattle_part_1" }, 73, -1, skipChangePhase: false, startInSecondPhase: false, 0.6f));
		_dataArray.Add(new CombatConfigItem(264, 1, isBossCombat: true, 20, 120, -1, 100, 40, hideDistance: false, enemyAnonymous: false, isOutBoss: false, 50, selfCanFlee: true, enemyCanFlee: false, enemyOnlyFlee: false, isGroupMemberLeave: true, allowShowMercy: false, allowGroupMember: true, allowRandomFavorability: true, allowPrepare: true, allowVitalDemon: true, allowVitalDemonBetray: true, affectTemporaryCharacter: false, new List<List<sbyte>>(), new string[0], new List<sbyte>(), new List<sbyte>(), -1, dropResource: true, allowDropItem: true, 100, lootAllInventory: false, 100, 275, captureNoCarrier: true, enemyHealDamage: false, selfFatalDamageReduceHealth: true, enemyFatalDamageReduceHealth: true, ECombatConfigForceDefeatType.Invalid, 0u, null, -1, -1, skipChangePhase: true, startInSecondPhase: false, 1f));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<CombatConfigItem>(265);
		CreateItems0();
		CreateItems1();
		CreateItems2();
		CreateItems3();
		CreateItems4();
	}
}

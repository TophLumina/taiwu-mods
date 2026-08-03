using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class ProfessionFormula : ConfigData<ProfessionFormulaItem, int>
{
	/// <summary>
	/// 配置表定义Key
	/// </summary>
	public static class DefKey
	{
		/// <summary>
		/// 资历获取_山人_1
		/// </summary>
		public const int AddSenioritySavage1 = 0;

		/// <summary>
		/// 资历获取_山人_2
		/// </summary>
		public const int AddSenioritySavage2 = 1;

		/// <summary>
		/// 资历获取_山人_3
		/// </summary>
		public const int AddSenioritySavage3 = 2;

		/// <summary>
		/// 资历获取_山人_4
		/// </summary>
		public const int AddSenioritySavage4 = 3;

		/// <summary>
		/// 资历获取_山人_5
		/// </summary>
		public const int AddSenioritySavage5 = 4;

		/// <summary>
		/// 资历获取_山人_6
		/// </summary>
		public const int AddSenioritySavage6 = 5;

		/// <summary>
		/// 资历获取_山人_7
		/// </summary>
		public const int AddSenioritySavage7 = 6;

		/// <summary>
		/// 资历获取_山人_8
		/// </summary>
		public const int AddSenioritySavage8 = 7;

		/// <summary>
		/// 资历获取_猎户_1
		/// </summary>
		public const int AddSeniorityHunter1 = 8;

		/// <summary>
		/// 资历获取_猎户_2
		/// </summary>
		public const int AddSeniorityHunter2 = 9;

		/// <summary>
		/// 资历获取_猎户_3
		/// </summary>
		public const int AddSeniorityHunter3 = 10;

		/// <summary>
		/// 资历获取_猎户_4
		/// </summary>
		public const int AddSeniorityHunter4 = 11;

		/// <summary>
		/// 资历获取_猎户_5
		/// </summary>
		public const int AddSeniorityHunter5 = 12;

		/// <summary>
		/// 资历获取_猎户_6
		/// </summary>
		public const int AddSeniorityHunter6 = 13;

		/// <summary>
		/// 资历获取_猎户_7
		/// </summary>
		public const int AddSeniorityHunter7 = 14;

		/// <summary>
		/// 资历获取_猎户_8
		/// </summary>
		public const int AddSeniorityHunter8 = 15;

		/// <summary>
		/// 资历获取_匠人_1
		/// </summary>
		public const int AddSeniorityCraft1 = 16;

		/// <summary>
		/// 资历获取_匠人_2
		/// </summary>
		public const int AddSeniorityCraft2 = 17;

		/// <summary>
		/// 资历获取_匠人_3
		/// </summary>
		public const int AddSeniorityCraft3 = 18;

		/// <summary>
		/// 资历获取_匠人_4
		/// </summary>
		public const int AddSeniorityCraft4 = 19;

		/// <summary>
		/// 资历获取_匠人_5
		/// </summary>
		public const int AddSeniorityCraft5 = 20;

		/// <summary>
		/// 资历获取_匠人_6_1
		/// </summary>
		public const int AddSeniorityCraft61 = 21;

		/// <summary>
		/// 资历获取_匠人_6_2
		/// </summary>
		public const int AddSeniorityCraft62 = 22;

		/// <summary>
		/// 资历获取_武师_1
		/// </summary>
		public const int AddSeniorityMartialArtist1 = 23;

		/// <summary>
		/// 资历获取_武师_2
		/// </summary>
		public const int AddSeniorityMartialArtist2 = 24;

		/// <summary>
		/// 资历获取_武师_3
		/// </summary>
		public const int AddSeniorityMartialArtist3 = 25;

		/// <summary>
		/// 资历获取_武师_4
		/// </summary>
		public const int AddSeniorityMartialArtist4 = 26;

		/// <summary>
		/// 资历获取_武师_5
		/// </summary>
		public const int AddSeniorityMartialArtist5 = 27;

		/// <summary>
		/// 资历获取_武师_6
		/// </summary>
		public const int AddSeniorityMartialArtist6 = 28;

		/// <summary>
		/// 资历获取_武师_7
		/// </summary>
		public const int AddSeniorityMartialArtist7 = 29;

		/// <summary>
		/// 资历获取_武师_练功
		/// </summary>
		public const int AddSeniorityMartialArtist8 = 30;

		/// <summary>
		/// 资历获取_才俊_1
		/// </summary>
		public const int AddSeniorityLiterati1 = 31;

		/// <summary>
		/// 资历获取_才俊_2
		/// </summary>
		public const int AddSeniorityLiterati2 = 32;

		/// <summary>
		/// 资历获取_才俊_3
		/// </summary>
		public const int AddSeniorityLiterati3 = 33;

		/// <summary>
		/// 资历获取_才俊_4
		/// </summary>
		public const int AddSeniorityLiterati4 = 34;

		/// <summary>
		/// 资历获取_才俊_5
		/// </summary>
		public const int AddSeniorityLiterati5 = 35;

		/// <summary>
		/// 资历获取_才俊_6
		/// </summary>
		public const int AddSeniorityLiterati6 = 36;

		/// <summary>
		/// 资历获取_道长_1
		/// </summary>
		public const int AddSeniorityTaoistMonk1 = 37;

		/// <summary>
		/// 资历获取_道长_2
		/// </summary>
		public const int AddSeniorityTaoistMonk2 = 38;

		/// <summary>
		/// 资历获取_道长_3
		/// </summary>
		public const int AddSeniorityTaoistMonk3 = 39;

		/// <summary>
		/// 资历获取_道长_4
		/// </summary>
		public const int AddSeniorityTaoistMonk4 = 40;

		/// <summary>
		/// 资历获取_道长_5
		/// </summary>
		public const int AddSeniorityTaoistMonk5 = 41;

		/// <summary>
		/// 资历获取_道长_6
		/// </summary>
		public const int AddSeniorityTaoistMonk6 = 42;

		/// <summary>
		/// 资历获取_高僧_1
		/// </summary>
		public const int AddSeniorityBuddhistMonk1 = 43;

		/// <summary>
		/// 资历获取_高僧_2
		/// </summary>
		public const int AddSeniorityBuddhistMonk2 = 44;

		/// <summary>
		/// 资历获取_高僧_3
		/// </summary>
		public const int AddSeniorityBuddhistMonk3 = 45;

		/// <summary>
		/// 资历获取_高僧_4
		/// </summary>
		public const int AddSeniorityBuddhistMonk4 = 46;

		/// <summary>
		/// 资历获取_高僧_5
		/// </summary>
		public const int AddSeniorityBuddhistMonk5 = 47;

		/// <summary>
		/// 资历获取_高僧_6
		/// </summary>
		public const int AddSeniorityBuddhistMonk6 = 48;

		/// <summary>
		/// 资历获取_豪客_1
		/// </summary>
		public const int AddSeniorityWineTaster1 = 49;

		/// <summary>
		/// 资历获取_豪客_2
		/// </summary>
		public const int AddSeniorityWineTaster2 = 50;

		/// <summary>
		/// 资历获取_豪客_3
		/// </summary>
		public const int AddSeniorityWineTaster3 = 51;

		/// <summary>
		/// 资历获取_豪客_4
		/// </summary>
		public const int AddSeniorityWineTaster4 = 52;

		/// <summary>
		/// 资历获取_豪客_5
		/// </summary>
		public const int AddSeniorityWineTaster5 = 53;

		/// <summary>
		/// 资历获取_豪客_6
		/// </summary>
		public const int AddSeniorityWineTaster6 = 54;

		/// <summary>
		/// 资历获取_豪客_7
		/// </summary>
		public const int AddSeniorityWineTaster7 = 55;

		/// <summary>
		/// 资历获取_名门_1
		/// </summary>
		public const int AddSeniorityAristocrat1 = 56;

		/// <summary>
		/// 资历获取_名门_2
		/// </summary>
		public const int AddSeniorityAristocrat2 = 57;

		/// <summary>
		/// 资历获取_名门_3
		/// </summary>
		public const int AddSeniorityAristocrat3 = 58;

		/// <summary>
		/// 资历获取_名门_4
		/// </summary>
		public const int AddSeniorityAristocrat4 = 59;

		/// <summary>
		/// 资历获取_名门_5
		/// </summary>
		public const int AddSeniorityAristocrat5 = 60;

		/// <summary>
		/// 资历获取_乞丐_1
		/// </summary>
		public const int AddSeniorityBeggar1 = 61;

		/// <summary>
		/// 资历获取_乞丐_2
		/// </summary>
		public const int AddSeniorityBeggar2 = 62;

		/// <summary>
		/// 资历获取_乞丐_3
		/// </summary>
		public const int AddSeniorityBeggar3 = 63;

		/// <summary>
		/// 资历获取_乞丐_4
		/// </summary>
		public const int AddSeniorityBeggar4 = 64;

		/// <summary>
		/// 资历获取_乞丐_5
		/// </summary>
		public const int AddSeniorityBeggar5 = 65;

		/// <summary>
		/// 资历获取_平民_1
		/// </summary>
		public const int AddSeniorityCivilian1 = 66;

		/// <summary>
		/// 资历获取_平民_2
		/// </summary>
		public const int AddSeniorityCivilian2 = 67;

		/// <summary>
		/// 资历获取_平民_3
		/// </summary>
		public const int AddSeniorityCivilian3 = 68;

		/// <summary>
		/// 资历获取_平民_4
		/// </summary>
		public const int AddSeniorityCivilian4 = 69;

		/// <summary>
		/// 资历获取_平民_5
		/// </summary>
		public const int AddSeniorityCivilian5 = 70;

		/// <summary>
		/// 资历获取_平民_6
		/// </summary>
		public const int AddSeniorityCivilian6 = 71;

		/// <summary>
		/// 资历获取_旅人_1
		/// </summary>
		public const int AddSeniorityTraveler1 = 72;

		/// <summary>
		/// 资历获取_旅人_2
		/// </summary>
		public const int AddSeniorityTraveler2 = 73;

		/// <summary>
		/// 资历获取_旅人_3
		/// </summary>
		public const int AddSeniorityTraveler3 = 74;

		/// <summary>
		/// 资历获取_旅人_4
		/// </summary>
		public const int AddSeniorityTraveler4 = 75;

		/// <summary>
		/// 资历获取_旅人_5
		/// </summary>
		public const int AddSeniorityTraveler5 = 76;

		/// <summary>
		/// 资历获取_旅人_6
		/// </summary>
		public const int AddSeniorityTraveler6 = 77;

		/// <summary>
		/// 资历获取_云游僧_1
		/// </summary>
		public const int AddSeniorityTravelingBuddhistMonk1 = 78;

		/// <summary>
		/// 资历获取_云游僧_2
		/// </summary>
		public const int AddSeniorityTravelingBuddhistMonk2 = 79;

		/// <summary>
		/// 资历获取_云游僧_3
		/// </summary>
		public const int AddSeniorityTravelingBuddhistMonk3 = 80;

		/// <summary>
		/// 资历获取_云游僧_4
		/// </summary>
		public const int AddSeniorityTravelingBuddhistMonk4 = 81;

		/// <summary>
		/// 资历获取_云游僧_5
		/// </summary>
		public const int AddSeniorityTravelingBuddhistMonk5 = 82;

		/// <summary>
		/// 资历获取_大夫_1
		/// </summary>
		public const int AddSeniorityDoctor1 = 83;

		/// <summary>
		/// 资历获取_大夫_2
		/// </summary>
		public const int AddSeniorityDoctor2 = 84;

		/// <summary>
		/// 资历获取_大夫_3
		/// </summary>
		public const int AddSeniorityDoctor3 = 85;

		/// <summary>
		/// 资历获取_大夫_4
		/// </summary>
		public const int AddSeniorityDoctor4 = 86;

		/// <summary>
		/// 资历获取_大夫_5
		/// </summary>
		public const int AddSeniorityDoctor5 = 87;

		/// <summary>
		/// 资历获取_大夫_6
		/// </summary>
		public const int AddSeniorityDoctor6 = 88;

		/// <summary>
		/// 资历获取_大夫_7
		/// </summary>
		public const int AddSeniorityDoctor7 = 89;

		/// <summary>
		/// 资历获取_大夫_8
		/// </summary>
		public const int AddSeniorityDoctor8 = 90;

		/// <summary>
		/// 资历获取_云游道_1
		/// </summary>
		public const int AddSeniorityTravelingTaoistMonk1 = 91;

		/// <summary>
		/// 资历获取_云游道_2
		/// </summary>
		public const int AddSeniorityTravelingTaoistMonk2 = 92;

		/// <summary>
		/// 资历获取_云游道_3
		/// </summary>
		public const int AddSeniorityTravelingTaoistMonk3 = 93;

		/// <summary>
		/// 资历获取_云游道_4
		/// </summary>
		public const int AddSeniorityTravelingTaoistMonk4 = 94;

		/// <summary>
		/// 资历获取_云游道_5
		/// </summary>
		public const int AddSeniorityTravelingTaoistMonk5 = 95;

		/// <summary>
		/// 资历获取_富商_1
		/// </summary>
		public const int AddSeniorityCapitalist1 = 96;

		/// <summary>
		/// 资历获取_富商_2
		/// </summary>
		public const int AddSeniorityCapitalist2 = 97;

		/// <summary>
		/// 资历获取_富商_3
		/// </summary>
		public const int AddSeniorityCapitalist3 = 98;

		/// <summary>
		/// 资历获取_富商_4
		/// </summary>
		public const int AddSeniorityCapitalist4 = 99;

		/// <summary>
		/// 资历获取_贵客_1
		/// </summary>
		public const int AddSeniorityTeaTaster1 = 100;

		/// <summary>
		/// 资历获取_贵客_2
		/// </summary>
		public const int AddSeniorityTeaTaster2 = 101;

		/// <summary>
		/// 资历获取_贵客_3
		/// </summary>
		public const int AddSeniorityTeaTaster3 = 102;

		/// <summary>
		/// 资历获取_贵客_4
		/// </summary>
		public const int AddSeniorityTeaTaster4 = 103;

		/// <summary>
		/// 资历获取_贵客_5
		/// </summary>
		public const int AddSeniorityTeaTaster5 = 104;

		/// <summary>
		/// 资历获取_贵客_6
		/// </summary>
		public const int AddSeniorityTeaTaster6 = 105;

		/// <summary>
		/// 资历获取_贵客_7
		/// </summary>
		public const int AddSeniorityTeaTaster7 = 106;

		/// <summary>
		/// 资历获取_王公_1
		/// </summary>
		public const int AddSeniorityDuke1 = 107;

		/// <summary>
		/// 资历获取_王公_2
		/// </summary>
		public const int AddSeniorityDuke2 = 108;

		/// <summary>
		/// 资历获取_王公_3
		/// </summary>
		public const int AddSeniorityDuke3 = 109;

		/// <summary>
		/// 资历获取_王公_4
		/// </summary>
		public const int AddSeniorityDuke4 = 110;

		/// <summary>
		/// 资历获取_王公_5
		/// </summary>
		public const int AddSeniorityDuke5 = 111;

		/// <summary>
		/// 资历获取_王公_6
		/// </summary>
		public const int AddSeniorityDuke6 = 112;

		/// <summary>
		/// 技能效果_王公_获取蛐蛐模拟次数
		/// </summary>
		public const int SkillDukeGetCricketSimulateCount = 113;
	}

	/// <summary>
	/// 配置表快捷访问
	/// </summary>
	public static class DefValue
	{
		/// <summary>
		/// 资历获取_山人_1
		/// </summary>
		public static ProfessionFormulaItem AddSenioritySavage1 => Instance[0];

		/// <summary>
		/// 资历获取_山人_2
		/// </summary>
		public static ProfessionFormulaItem AddSenioritySavage2 => Instance[1];

		/// <summary>
		/// 资历获取_山人_3
		/// </summary>
		public static ProfessionFormulaItem AddSenioritySavage3 => Instance[2];

		/// <summary>
		/// 资历获取_山人_4
		/// </summary>
		public static ProfessionFormulaItem AddSenioritySavage4 => Instance[3];

		/// <summary>
		/// 资历获取_山人_5
		/// </summary>
		public static ProfessionFormulaItem AddSenioritySavage5 => Instance[4];

		/// <summary>
		/// 资历获取_山人_6
		/// </summary>
		public static ProfessionFormulaItem AddSenioritySavage6 => Instance[5];

		/// <summary>
		/// 资历获取_山人_7
		/// </summary>
		public static ProfessionFormulaItem AddSenioritySavage7 => Instance[6];

		/// <summary>
		/// 资历获取_山人_8
		/// </summary>
		public static ProfessionFormulaItem AddSenioritySavage8 => Instance[7];

		/// <summary>
		/// 资历获取_猎户_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityHunter1 => Instance[8];

		/// <summary>
		/// 资历获取_猎户_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityHunter2 => Instance[9];

		/// <summary>
		/// 资历获取_猎户_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityHunter3 => Instance[10];

		/// <summary>
		/// 资历获取_猎户_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityHunter4 => Instance[11];

		/// <summary>
		/// 资历获取_猎户_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityHunter5 => Instance[12];

		/// <summary>
		/// 资历获取_猎户_6
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityHunter6 => Instance[13];

		/// <summary>
		/// 资历获取_猎户_7
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityHunter7 => Instance[14];

		/// <summary>
		/// 资历获取_猎户_8
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityHunter8 => Instance[15];

		/// <summary>
		/// 资历获取_匠人_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCraft1 => Instance[16];

		/// <summary>
		/// 资历获取_匠人_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCraft2 => Instance[17];

		/// <summary>
		/// 资历获取_匠人_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCraft3 => Instance[18];

		/// <summary>
		/// 资历获取_匠人_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCraft4 => Instance[19];

		/// <summary>
		/// 资历获取_匠人_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCraft5 => Instance[20];

		/// <summary>
		/// 资历获取_匠人_6_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCraft61 => Instance[21];

		/// <summary>
		/// 资历获取_匠人_6_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCraft62 => Instance[22];

		/// <summary>
		/// 资历获取_武师_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityMartialArtist1 => Instance[23];

		/// <summary>
		/// 资历获取_武师_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityMartialArtist2 => Instance[24];

		/// <summary>
		/// 资历获取_武师_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityMartialArtist3 => Instance[25];

		/// <summary>
		/// 资历获取_武师_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityMartialArtist4 => Instance[26];

		/// <summary>
		/// 资历获取_武师_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityMartialArtist5 => Instance[27];

		/// <summary>
		/// 资历获取_武师_6
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityMartialArtist6 => Instance[28];

		/// <summary>
		/// 资历获取_武师_7
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityMartialArtist7 => Instance[29];

		/// <summary>
		/// 资历获取_武师_练功
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityMartialArtist8 => Instance[30];

		/// <summary>
		/// 资历获取_才俊_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityLiterati1 => Instance[31];

		/// <summary>
		/// 资历获取_才俊_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityLiterati2 => Instance[32];

		/// <summary>
		/// 资历获取_才俊_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityLiterati3 => Instance[33];

		/// <summary>
		/// 资历获取_才俊_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityLiterati4 => Instance[34];

		/// <summary>
		/// 资历获取_才俊_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityLiterati5 => Instance[35];

		/// <summary>
		/// 资历获取_才俊_6
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityLiterati6 => Instance[36];

		/// <summary>
		/// 资历获取_道长_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTaoistMonk1 => Instance[37];

		/// <summary>
		/// 资历获取_道长_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTaoistMonk2 => Instance[38];

		/// <summary>
		/// 资历获取_道长_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTaoistMonk3 => Instance[39];

		/// <summary>
		/// 资历获取_道长_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTaoistMonk4 => Instance[40];

		/// <summary>
		/// 资历获取_道长_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTaoistMonk5 => Instance[41];

		/// <summary>
		/// 资历获取_道长_6
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTaoistMonk6 => Instance[42];

		/// <summary>
		/// 资历获取_高僧_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityBuddhistMonk1 => Instance[43];

		/// <summary>
		/// 资历获取_高僧_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityBuddhistMonk2 => Instance[44];

		/// <summary>
		/// 资历获取_高僧_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityBuddhistMonk3 => Instance[45];

		/// <summary>
		/// 资历获取_高僧_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityBuddhistMonk4 => Instance[46];

		/// <summary>
		/// 资历获取_高僧_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityBuddhistMonk5 => Instance[47];

		/// <summary>
		/// 资历获取_高僧_6
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityBuddhistMonk6 => Instance[48];

		/// <summary>
		/// 资历获取_豪客_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityWineTaster1 => Instance[49];

		/// <summary>
		/// 资历获取_豪客_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityWineTaster2 => Instance[50];

		/// <summary>
		/// 资历获取_豪客_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityWineTaster3 => Instance[51];

		/// <summary>
		/// 资历获取_豪客_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityWineTaster4 => Instance[52];

		/// <summary>
		/// 资历获取_豪客_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityWineTaster5 => Instance[53];

		/// <summary>
		/// 资历获取_豪客_6
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityWineTaster6 => Instance[54];

		/// <summary>
		/// 资历获取_豪客_7
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityWineTaster7 => Instance[55];

		/// <summary>
		/// 资历获取_名门_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityAristocrat1 => Instance[56];

		/// <summary>
		/// 资历获取_名门_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityAristocrat2 => Instance[57];

		/// <summary>
		/// 资历获取_名门_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityAristocrat3 => Instance[58];

		/// <summary>
		/// 资历获取_名门_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityAristocrat4 => Instance[59];

		/// <summary>
		/// 资历获取_名门_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityAristocrat5 => Instance[60];

		/// <summary>
		/// 资历获取_乞丐_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityBeggar1 => Instance[61];

		/// <summary>
		/// 资历获取_乞丐_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityBeggar2 => Instance[62];

		/// <summary>
		/// 资历获取_乞丐_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityBeggar3 => Instance[63];

		/// <summary>
		/// 资历获取_乞丐_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityBeggar4 => Instance[64];

		/// <summary>
		/// 资历获取_乞丐_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityBeggar5 => Instance[65];

		/// <summary>
		/// 资历获取_平民_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCivilian1 => Instance[66];

		/// <summary>
		/// 资历获取_平民_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCivilian2 => Instance[67];

		/// <summary>
		/// 资历获取_平民_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCivilian3 => Instance[68];

		/// <summary>
		/// 资历获取_平民_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCivilian4 => Instance[69];

		/// <summary>
		/// 资历获取_平民_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCivilian5 => Instance[70];

		/// <summary>
		/// 资历获取_平民_6
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCivilian6 => Instance[71];

		/// <summary>
		/// 资历获取_旅人_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTraveler1 => Instance[72];

		/// <summary>
		/// 资历获取_旅人_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTraveler2 => Instance[73];

		/// <summary>
		/// 资历获取_旅人_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTraveler3 => Instance[74];

		/// <summary>
		/// 资历获取_旅人_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTraveler4 => Instance[75];

		/// <summary>
		/// 资历获取_旅人_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTraveler5 => Instance[76];

		/// <summary>
		/// 资历获取_旅人_6
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTraveler6 => Instance[77];

		/// <summary>
		/// 资历获取_云游僧_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTravelingBuddhistMonk1 => Instance[78];

		/// <summary>
		/// 资历获取_云游僧_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTravelingBuddhistMonk2 => Instance[79];

		/// <summary>
		/// 资历获取_云游僧_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTravelingBuddhistMonk3 => Instance[80];

		/// <summary>
		/// 资历获取_云游僧_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTravelingBuddhistMonk4 => Instance[81];

		/// <summary>
		/// 资历获取_云游僧_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTravelingBuddhistMonk5 => Instance[82];

		/// <summary>
		/// 资历获取_大夫_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDoctor1 => Instance[83];

		/// <summary>
		/// 资历获取_大夫_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDoctor2 => Instance[84];

		/// <summary>
		/// 资历获取_大夫_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDoctor3 => Instance[85];

		/// <summary>
		/// 资历获取_大夫_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDoctor4 => Instance[86];

		/// <summary>
		/// 资历获取_大夫_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDoctor5 => Instance[87];

		/// <summary>
		/// 资历获取_大夫_6
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDoctor6 => Instance[88];

		/// <summary>
		/// 资历获取_大夫_7
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDoctor7 => Instance[89];

		/// <summary>
		/// 资历获取_大夫_8
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDoctor8 => Instance[90];

		/// <summary>
		/// 资历获取_云游道_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTravelingTaoistMonk1 => Instance[91];

		/// <summary>
		/// 资历获取_云游道_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTravelingTaoistMonk2 => Instance[92];

		/// <summary>
		/// 资历获取_云游道_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTravelingTaoistMonk3 => Instance[93];

		/// <summary>
		/// 资历获取_云游道_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTravelingTaoistMonk4 => Instance[94];

		/// <summary>
		/// 资历获取_云游道_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTravelingTaoistMonk5 => Instance[95];

		/// <summary>
		/// 资历获取_富商_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCapitalist1 => Instance[96];

		/// <summary>
		/// 资历获取_富商_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCapitalist2 => Instance[97];

		/// <summary>
		/// 资历获取_富商_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCapitalist3 => Instance[98];

		/// <summary>
		/// 资历获取_富商_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityCapitalist4 => Instance[99];

		/// <summary>
		/// 资历获取_贵客_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTeaTaster1 => Instance[100];

		/// <summary>
		/// 资历获取_贵客_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTeaTaster2 => Instance[101];

		/// <summary>
		/// 资历获取_贵客_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTeaTaster3 => Instance[102];

		/// <summary>
		/// 资历获取_贵客_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTeaTaster4 => Instance[103];

		/// <summary>
		/// 资历获取_贵客_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTeaTaster5 => Instance[104];

		/// <summary>
		/// 资历获取_贵客_6
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTeaTaster6 => Instance[105];

		/// <summary>
		/// 资历获取_贵客_7
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityTeaTaster7 => Instance[106];

		/// <summary>
		/// 资历获取_王公_1
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDuke1 => Instance[107];

		/// <summary>
		/// 资历获取_王公_2
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDuke2 => Instance[108];

		/// <summary>
		/// 资历获取_王公_3
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDuke3 => Instance[109];

		/// <summary>
		/// 资历获取_王公_4
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDuke4 => Instance[110];

		/// <summary>
		/// 资历获取_王公_5
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDuke5 => Instance[111];

		/// <summary>
		/// 资历获取_王公_6
		/// </summary>
		public static ProfessionFormulaItem AddSeniorityDuke6 => Instance[112];

		/// <summary>
		/// 技能效果_王公_获取蛐蛐模拟次数
		/// </summary>
		public static ProfessionFormulaItem SkillDukeGetCricketSimulateCount => Instance[113];
	}

	/// <summary>
	/// 配置表实例
	/// </summary>
	public static ProfessionFormula Instance = new ProfessionFormula();

	private readonly HashSet<string> RequiredFields = new HashSet<string> { "TemplateId" };

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
		_dataArray.Add(new ProfessionFormulaItem(0, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 20 }, 3000));
		_dataArray.Add(new ProfessionFormulaItem(1, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 1 }, 28200));
		_dataArray.Add(new ProfessionFormulaItem(2, EProfessionFormulaType.SeniorityGainFormula9, new int[1] { 28200 }, 28200));
		_dataArray.Add(new ProfessionFormulaItem(3, EProfessionFormulaType.SeniorityGainFormula9, new int[1] { 123000 }, 123000));
		_dataArray.Add(new ProfessionFormulaItem(4, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 2 }, 14100));
		_dataArray.Add(new ProfessionFormulaItem(5, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 1 }, 61500));
		_dataArray.Add(new ProfessionFormulaItem(6, EProfessionFormulaType.SeniorityGainFormula12, new int[2] { 250, 100 }, 70500));
		_dataArray.Add(new ProfessionFormulaItem(7, EProfessionFormulaType.SeniorityGainFormula1, new int[1], 24000));
		_dataArray.Add(new ProfessionFormulaItem(8, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 20, 4, 2 }, 6480));
		_dataArray.Add(new ProfessionFormulaItem(9, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 50, 4, 2 }, 16200));
		_dataArray.Add(new ProfessionFormulaItem(10, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 100, 4, 2 }, 32400));
		_dataArray.Add(new ProfessionFormulaItem(11, EProfessionFormulaType.SeniorityGainFormula4, new int[3] { 10, 2, 2 }, 10000));
		_dataArray.Add(new ProfessionFormulaItem(12, EProfessionFormulaType.SeniorityGainFormula4, new int[3] { 5, 2, 2 }, 25000));
		_dataArray.Add(new ProfessionFormulaItem(13, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 100, 2, 2 }, 10000));
		_dataArray.Add(new ProfessionFormulaItem(14, EProfessionFormulaType.SeniorityGainFormula9, new int[1] { 162000 }, 162000));
		_dataArray.Add(new ProfessionFormulaItem(15, EProfessionFormulaType.SeniorityGainFormula9, new int[1] { 810000 }, 810000));
		_dataArray.Add(new ProfessionFormulaItem(16, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 100, 2, 3 }, 100000));
		_dataArray.Add(new ProfessionFormulaItem(17, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 20, 2, 3 }, 20000));
		_dataArray.Add(new ProfessionFormulaItem(18, EProfessionFormulaType.SeniorityGainFormula5, new int[4] { 10, 2, 3, 100 }, 10000));
		_dataArray.Add(new ProfessionFormulaItem(19, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 5, 2, 3 }, 5000));
		_dataArray.Add(new ProfessionFormulaItem(20, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 3 }, 4800));
		_dataArray.Add(new ProfessionFormulaItem(21, EProfessionFormulaType.SeniorityGainFormula12, new int[2] { 25, 100 }, 7050));
		_dataArray.Add(new ProfessionFormulaItem(22, EProfessionFormulaType.SeniorityGainFormula12, new int[2] { 25, 100 }, 4600));
		_dataArray.Add(new ProfessionFormulaItem(23, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 5 }, 7125));
		_dataArray.Add(new ProfessionFormulaItem(24, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 5 }, 14250));
		_dataArray.Add(new ProfessionFormulaItem(25, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 5 }, 14250));
		_dataArray.Add(new ProfessionFormulaItem(26, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 1000, 1, 2 }, 100000));
		_dataArray.Add(new ProfessionFormulaItem(27, EProfessionFormulaType.SeniorityGainFormula4, new int[3] { 100, 2, 2 }, 50000));
		_dataArray.Add(new ProfessionFormulaItem(28, EProfessionFormulaType.SeniorityGainFormula4, new int[3] { 3, 2, 2 }, 30000));
		_dataArray.Add(new ProfessionFormulaItem(29, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 500, 0, 2 }, 32000));
		_dataArray.Add(new ProfessionFormulaItem(30, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 1000 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(31, EProfessionFormulaType.SeniorityGainFormula7, new int[2] { 3, 2 }, 22500));
		_dataArray.Add(new ProfessionFormulaItem(32, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 100, 2, 2 }, 10000));
		_dataArray.Add(new ProfessionFormulaItem(33, EProfessionFormulaType.SeniorityGainFormula2, new int[1] { 1 }, 9000));
		_dataArray.Add(new ProfessionFormulaItem(34, EProfessionFormulaType.SeniorityGainFormula2, new int[1] { 1 }, 9000));
		_dataArray.Add(new ProfessionFormulaItem(35, EProfessionFormulaType.SeniorityGainFormula2, new int[1] { 10 }, 90000));
		_dataArray.Add(new ProfessionFormulaItem(36, EProfessionFormulaType.SeniorityGainFormula4, new int[3] { 3, 2, 2 }, 30000));
		_dataArray.Add(new ProfessionFormulaItem(37, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 50, 2, 3 }, 50000));
		_dataArray.Add(new ProfessionFormulaItem(38, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 5, 2, 3 }, 5000));
		_dataArray.Add(new ProfessionFormulaItem(39, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 50, 2, 3 }, 50000));
		_dataArray.Add(new ProfessionFormulaItem(40, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 50, 2, 3 }, 50000));
		_dataArray.Add(new ProfessionFormulaItem(41, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 5 }, 14250));
		_dataArray.Add(new ProfessionFormulaItem(42, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 100, 2, 2 }, 10000));
		_dataArray.Add(new ProfessionFormulaItem(43, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 50, 2, 3 }, 50000));
		_dataArray.Add(new ProfessionFormulaItem(44, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 5, 2, 3 }, 5000));
		_dataArray.Add(new ProfessionFormulaItem(45, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 100, 2, 2 }, 40000));
		_dataArray.Add(new ProfessionFormulaItem(46, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 20, 2, 2 }, 8000));
		_dataArray.Add(new ProfessionFormulaItem(47, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 10 }, 36000));
		_dataArray.Add(new ProfessionFormulaItem(48, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 100, 2, 2 }, 10000));
		_dataArray.Add(new ProfessionFormulaItem(49, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 2 }, 20500));
		_dataArray.Add(new ProfessionFormulaItem(50, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 10 }, 4100));
		_dataArray.Add(new ProfessionFormulaItem(51, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 300, 2, 2 }, 30000));
		_dataArray.Add(new ProfessionFormulaItem(52, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 2 }, 30750));
		_dataArray.Add(new ProfessionFormulaItem(53, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 200, 2, 2 }, 20000));
		_dataArray.Add(new ProfessionFormulaItem(54, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 100, 2, 2 }, 10000));
		_dataArray.Add(new ProfessionFormulaItem(55, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 4 }, 10250));
		_dataArray.Add(new ProfessionFormulaItem(56, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 50 }, 10000));
		_dataArray.Add(new ProfessionFormulaItem(57, EProfessionFormulaType.SeniorityGainFormula2, new int[1] { 50 }, 10000));
		_dataArray.Add(new ProfessionFormulaItem(58, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 1000 }, 200000));
		_dataArray.Add(new ProfessionFormulaItem(59, EProfessionFormulaType.SeniorityGainFormula2, new int[1] { 10 }, 240000));
	}

	private void CreateItems1()
	{
		_dataArray.Add(new ProfessionFormulaItem(60, EProfessionFormulaType.SeniorityGainFormula4, new int[3] { 50, 2, 2 }, 25000));
		_dataArray.Add(new ProfessionFormulaItem(61, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 10 }, 10240));
		_dataArray.Add(new ProfessionFormulaItem(62, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 50, 2, 2 }, 5000));
		_dataArray.Add(new ProfessionFormulaItem(63, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 2 }, 10250));
		_dataArray.Add(new ProfessionFormulaItem(64, EProfessionFormulaType.SeniorityGainFormula8, new int[3] { 500, 4, 2 }, 8000));
		_dataArray.Add(new ProfessionFormulaItem(65, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 500, 0, 2 }, 32000));
		_dataArray.Add(new ProfessionFormulaItem(66, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 50, 2, 3 }, 50000));
		_dataArray.Add(new ProfessionFormulaItem(67, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 10 }, 36000));
		_dataArray.Add(new ProfessionFormulaItem(68, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 50, 4, 2 }, 20000));
		_dataArray.Add(new ProfessionFormulaItem(69, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 50, 4, 2 }, 20000));
		_dataArray.Add(new ProfessionFormulaItem(70, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 50, 4, 2 }, 20000));
		_dataArray.Add(new ProfessionFormulaItem(71, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 500, 0, 2 }, 32000));
		_dataArray.Add(new ProfessionFormulaItem(72, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 10 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(73, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 2 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(74, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 10 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(75, EProfessionFormulaType.SeniorityGainFormula9, new int[1] { 30000 }, 30000));
		_dataArray.Add(new ProfessionFormulaItem(76, EProfessionFormulaType.SeniorityGainFormula9, new int[1] { 5000 }, 5000));
		_dataArray.Add(new ProfessionFormulaItem(77, EProfessionFormulaType.SeniorityGainFormula9, new int[1] { 5000 }, 5000));
		_dataArray.Add(new ProfessionFormulaItem(78, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 100, 2, 2 }, 10000));
		_dataArray.Add(new ProfessionFormulaItem(79, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 200, 2, 2 }, 20000));
		_dataArray.Add(new ProfessionFormulaItem(80, EProfessionFormulaType.SeniorityGainFormula7, new int[2] { 3, 2 }, 22500));
		_dataArray.Add(new ProfessionFormulaItem(81, EProfessionFormulaType.SeniorityGainFormula9, new int[1] { 50000 }, 50000));
		_dataArray.Add(new ProfessionFormulaItem(82, EProfessionFormulaType.SeniorityGainFormula7, new int[2] { 3, 2 }, 22500));
		_dataArray.Add(new ProfessionFormulaItem(83, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 30, 2, 3 }, 30000));
		_dataArray.Add(new ProfessionFormulaItem(84, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 20, 2, 3 }, 20000));
		_dataArray.Add(new ProfessionFormulaItem(85, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 10, 2, 3 }, 10000));
		_dataArray.Add(new ProfessionFormulaItem(86, EProfessionFormulaType.SeniorityGainFormula10, new int[6] { 250, 500, 1000, 2000, 4000, 8000 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(87, EProfessionFormulaType.SeniorityGainFormula10, new int[3] { 1000, 2000, 16000 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(88, EProfessionFormulaType.SeniorityGainFormula0, new int[0], -1));
		_dataArray.Add(new ProfessionFormulaItem(89, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 100 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(90, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 4 }, 7050));
		_dataArray.Add(new ProfessionFormulaItem(91, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 150, 1, 2 }, 30000));
		_dataArray.Add(new ProfessionFormulaItem(92, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 10 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(93, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 50, 2, 2 }, 20000));
		_dataArray.Add(new ProfessionFormulaItem(94, EProfessionFormulaType.SeniorityGainFormula1, new int[1] { 100 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(95, EProfessionFormulaType.SeniorityGainFormula7, new int[2] { 3, 2 }, 22500));
		_dataArray.Add(new ProfessionFormulaItem(96, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 4 }, 15375));
		_dataArray.Add(new ProfessionFormulaItem(97, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 4 }, 15375));
		_dataArray.Add(new ProfessionFormulaItem(98, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 2 }, 30750));
		_dataArray.Add(new ProfessionFormulaItem(99, EProfessionFormulaType.SeniorityGainFormula11, new int[3] { 10000, 100, 100 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(100, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 2 }, 20500));
		_dataArray.Add(new ProfessionFormulaItem(101, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 10 }, 4100));
		_dataArray.Add(new ProfessionFormulaItem(102, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 300, 2, 2 }, 30000));
		_dataArray.Add(new ProfessionFormulaItem(103, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 2 }, 30750));
		_dataArray.Add(new ProfessionFormulaItem(104, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 200, 2, 2 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(105, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 100, 2, 2 }, 10000));
		_dataArray.Add(new ProfessionFormulaItem(106, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 4 }, 10250));
		_dataArray.Add(new ProfessionFormulaItem(107, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 2 }, 30750));
		_dataArray.Add(new ProfessionFormulaItem(108, EProfessionFormulaType.SeniorityGainFormula3, new int[3] { 500, 2, 2 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(109, EProfessionFormulaType.SeniorityGainFormula9, new int[1] { 10250 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(110, EProfessionFormulaType.SeniorityGainFormula9, new int[1] { 153750 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(111, EProfessionFormulaType.SeniorityGainFormula6, new int[1] { 2 }, 30750));
		_dataArray.Add(new ProfessionFormulaItem(112, EProfessionFormulaType.SeniorityGainFormula9, new int[1] { 307500 }, -1));
		_dataArray.Add(new ProfessionFormulaItem(113, EProfessionFormulaType.SeniorityGainFormula9, new int[1] { 18 }, -1));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ProfessionFormulaItem>(114);
		CreateItems0();
		CreateItems1();
	}
}

using System;
using System.Collections.Generic;
using Config.Common;

namespace Config;

[Serializable]
public class Profession : ConfigData<ProfessionItem, int>
{
	public static class DefKey
	{
		public const int Savage = 0;

		public const int Hunter = 1;

		public const int Craft = 2;

		public const int MartialArtist = 3;

		public const int Literati = 4;

		public const int TaoistMonk = 5;

		public const int BuddhistMonk = 6;

		public const int WineTaster = 7;

		public const int Aristocrat = 8;

		public const int Beggar = 9;

		public const int Civilian = 10;

		public const int Traveler = 11;

		public const int TravelingBuddhistMonk = 12;

		public const int Doctor = 13;

		public const int TravelingTaoistMonk = 14;

		public const int Capitalist = 15;

		public const int TeaTaster = 16;

		public const int Duke = 17;

		public const int Xiangshu = 18;
	}

	public static class DefValue
	{
		public static ProfessionItem Savage => Instance[0];

		public static ProfessionItem Hunter => Instance[1];

		public static ProfessionItem Craft => Instance[2];

		public static ProfessionItem MartialArtist => Instance[3];

		public static ProfessionItem Literati => Instance[4];

		public static ProfessionItem TaoistMonk => Instance[5];

		public static ProfessionItem BuddhistMonk => Instance[6];

		public static ProfessionItem WineTaster => Instance[7];

		public static ProfessionItem Aristocrat => Instance[8];

		public static ProfessionItem Beggar => Instance[9];

		public static ProfessionItem Civilian => Instance[10];

		public static ProfessionItem Traveler => Instance[11];

		public static ProfessionItem TravelingBuddhistMonk => Instance[12];

		public static ProfessionItem Doctor => Instance[13];

		public static ProfessionItem TravelingTaoistMonk => Instance[14];

		public static ProfessionItem Capitalist => Instance[15];

		public static ProfessionItem TeaTaster => Instance[16];

		public static ProfessionItem Duke => Instance[17];

		public static ProfessionItem Xiangshu => Instance[18];
	}

	public static Profession Instance = new Profession();

	private readonly HashSet<string> RequiredFields = new HashSet<string>
	{
		"Name", "Desc", "ProfessionSkills", "ExtraProfessionSkill", "BonusLifeSkills", "BonusCombatSkills", "BonusClothing", "ConflictingProfessions", "CompatibleProfessions", "SeniorityGainTips",
		"DemandTeachingText", "DemandTeachingFinishText", "TemplateId", "TextureBig", "Texture", "TextureSmall", "NameSprite", "ProfessionSeniorityPerMonth"
	};

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
		_dataArray.Add(new ProfessionItem(0, LocalStringManager.GetConfig("Profession_language", "Name_0"), LocalStringManager.GetConfig("Profession_language", "Desc_0"), "Profession_0_0", "Profession_1_0", "Profession_2_0", "bottom_profession_mingcheng_0", new int[3] { 0, 1, 2 }, 3, new List<sbyte> { 12 }, new List<sbyte>(), 0, 0u, new List<int> { 8, 17, 7, 16 }, new List<int> { 1, 9, 10 }, forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[7]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_0_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_0_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_0_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_0_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_0_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_0_5"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_0_6")
		}, new uint[7], new int[9] { 22800, 22940, 23144, 23400, 23550, 23800, 24160, 24200, 24480 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_0"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_0")));
		_dataArray.Add(new ProfessionItem(1, LocalStringManager.GetConfig("Profession_language", "Name_1"), LocalStringManager.GetConfig("Profession_language", "Desc_1"), "Profession_0_1", "Profession_1_1", "Profession_2_1", "bottom_profession_mingcheng_1", new int[3] { 4, 5, 6 }, 7, new List<sbyte> { 15 }, new List<sbyte>(), 1, 0u, new List<int> { 8, 17 }, new List<int> { 0, 9, 10 }, forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[8]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_1_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_1_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_1_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_1_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_1_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_1_5"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_1_6"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_1_7")
		}, new uint[8] { 0u, 0u, 0u, 0u, 0u, 0u, 2764950u, 2764950u }, new int[9] { 15600, 15688, 16280, 16800, 17400, 18800, 20160, 21200, 22080 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_1"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_1")));
		_dataArray.Add(new ProfessionItem(2, LocalStringManager.GetConfig("Profession_language", "Name_2"), LocalStringManager.GetConfig("Profession_language", "Desc_2"), "Profession_0_2", "Profession_1_2", "Profession_2_2", "bottom_profession_mingcheng_2", new int[3] { 8, 9, 10 }, 11, new List<sbyte> { 11, 6, 10, 7 }, new List<sbyte>(), 2, 0u, new List<int>(), new List<int>(), forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[6]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_2_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_2_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_2_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_2_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_2_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_2_5")
		}, new uint[6], new int[9] { 12000, 12580, 13200, 13800, 15000, 16000, 17600, 18400, 20160 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_2"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_2")));
		_dataArray.Add(new ProfessionItem(3, LocalStringManager.GetConfig("Profession_language", "Name_3"), LocalStringManager.GetConfig("Profession_language", "Desc_3"), "Profession_0_3", "Profession_1_3", "Profession_2_3", "bottom_profession_mingcheng_3", new int[3] { 12, 13, 14 }, 15, new List<sbyte>(), new List<sbyte>
		{
			0, 1, 2, 3, 4, 5, 6, 7, 8, 9,
			10, 11, 12, 13
		}, 3, 0u, new List<int> { 4 }, new List<int>(), forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[8]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_3_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_3_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_3_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_3_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_3_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_3_5"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_3_6"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_3_7")
		}, new uint[8], new int[9] { 6900, 7622, 8360, 9600, 12000, 13200, 14720, 16000, 18000 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_3"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_3")));
		_dataArray.Add(new ProfessionItem(4, LocalStringManager.GetConfig("Profession_language", "Name_4"), LocalStringManager.GetConfig("Profession_language", "Desc_4"), "Profession_0_4", "Profession_1_4", "Profession_2_4", "bottom_profession_mingcheng_4", new int[3] { 16, 17, 18 }, 19, new List<sbyte> { 0, 1, 2, 3 }, new List<sbyte>(), 4, 0u, new List<int> { 3 }, new List<int>(), forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[6]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_4_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_4_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_4_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_4_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_4_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_4_5")
		}, new uint[6], new int[9] { 6600, 7400, 8096, 9240, 11250, 13000, 14400, 15600, 17760 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_4"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_4")));
		_dataArray.Add(new ProfessionItem(5, LocalStringManager.GetConfig("Profession_language", "Name_5"), LocalStringManager.GetConfig("Profession_language", "Desc_5"), "Profession_0_5", "Profession_1_5", "Profession_2_5", "bottom_profession_mingcheng_5", new int[3] { 20, 21, 22 }, 23, new List<sbyte> { 12 }, new List<sbyte>(), 5, 0u, new List<int> { 6, 12 }, new List<int> { 14 }, forbidWine: false, forbidMeat: true, forbidSex: true, reinitOnCrossArchive: false, new string[6]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_5_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_5_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_5_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_5_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_5_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_5_5")
		}, new uint[6], new int[9] { 3300, 3626, 4048, 4680, 5400, 7000, 9600, 11200, 14400 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_5"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_5")));
		_dataArray.Add(new ProfessionItem(6, LocalStringManager.GetConfig("Profession_language", "Name_6"), LocalStringManager.GetConfig("Profession_language", "Desc_6"), "Profession_0_6", "Profession_1_6", "Profession_2_6", "bottom_profession_mingcheng_6", new int[3] { 24, 25, 26 }, 27, new List<sbyte> { 13 }, new List<sbyte>(), 6, 0u, new List<int> { 5, 14 }, new List<int> { 12 }, forbidWine: true, forbidMeat: true, forbidSex: true, reinitOnCrossArchive: false, new string[6]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_6_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_6_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_6_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_6_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_6_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_6_5")
		}, new uint[6], new int[9] { 3420, 3626, 3960, 4680, 5400, 7000, 9920, 11600, 14880 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_6"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_6")));
		_dataArray.Add(new ProfessionItem(7, LocalStringManager.GetConfig("Profession_language", "Name_7"), LocalStringManager.GetConfig("Profession_language", "Desc_7"), "Profession_0_7", "Profession_1_7", "Profession_2_7", "bottom_profession_mingcheng_7", new int[3] { 28, 29, 30 }, 31, new List<sbyte> { 5 }, new List<sbyte>(), 7, 0u, new List<int> { 9, 10, 16 }, new List<int> { 8 }, forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[6]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_7_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_7_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_7_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_7_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_7_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_7_5")
		}, new uint[6], new int[9] { 4200, 4588, 5192, 6000, 7050, 8400, 11200, 13200, 16800 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_7"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_7")));
		_dataArray.Add(new ProfessionItem(8, LocalStringManager.GetConfig("Profession_language", "Name_8"), LocalStringManager.GetConfig("Profession_language", "Desc_8"), "Profession_0_8", "Profession_1_8", "Profession_2_8", "bottom_profession_mingcheng_8", new int[3] { 32, 33, 34 }, 35, new List<sbyte> { 5 }, new List<sbyte>(), 8, 0u, new List<int> { 0, 1, 9, 10 }, new List<int> { 7, 17 }, forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[5]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_8_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_8_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_8_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_8_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_8_4")
		}, new uint[5], new int[9] { 3180, 3478, 3872, 4440, 5100, 6800, 9280, 10800, 13920 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_8"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_8")));
		_dataArray.Add(new ProfessionItem(9, LocalStringManager.GetConfig("Profession_language", "Name_9"), LocalStringManager.GetConfig("Profession_language", "Desc_9"), "Profession_0_9", "Profession_1_9", "Profession_2_9", "bottom_profession_mingcheng_9", new int[3] { 36, 37, 38 }, 39, new List<sbyte> { 15 }, new List<sbyte>(), 9, 0u, new List<int> { 8, 17, 7, 16 }, new List<int> { 0, 1, 10 }, forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[5]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_9_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_9_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_9_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_9_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_9_4")
		}, new uint[5], new int[9] { 23400, 23458, 23760, 24000, 24300, 24400, 24640, 24800, 24960 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_9"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_9")));
		_dataArray.Add(new ProfessionItem(10, LocalStringManager.GetConfig("Profession_language", "Name_10"), LocalStringManager.GetConfig("Profession_language", "Desc_10"), "Profession_0_10", "Profession_1_10", "Profession_2_10", "bottom_profession_mingcheng_10", new int[3] { 40, 41, 42 }, 43, new List<sbyte> { 14 }, new List<sbyte>(), 10, 0u, new List<int> { 8, 17 }, new List<int> { 0, 1, 9 }, forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[6]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_10_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_10_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_10_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_10_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_10_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_10_5")
		}, new uint[6], new int[9] { 10800, 11840, 12496, 12960, 14100, 15000, 16960, 18000, 19680 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_10"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_10")));
		_dataArray.Add(new ProfessionItem(11, LocalStringManager.GetConfig("Profession_language", "Name_11"), LocalStringManager.GetConfig("Profession_language", "Desc_11"), "Profession_0_11", "Profession_1_11", "Profession_2_11", "bottom_profession_mingcheng_11", new int[3] { 44, 45, 46 }, 47, new List<sbyte> { 15 }, new List<sbyte>(), 11, 0u, new List<int>(), new List<int>(), forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[6]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_11_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_11_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_11_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_11_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_11_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_11_5")
		}, new uint[6], new int[9] { 17400, 17760, 18040, 18600, 19500, 22000, 22400, 23040, 24000 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_11"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_11")));
		_dataArray.Add(new ProfessionItem(12, LocalStringManager.GetConfig("Profession_language", "Name_12"), LocalStringManager.GetConfig("Profession_language", "Desc_12"), "Profession_0_12", "Profession_1_12", "Profession_2_12", "bottom_profession_mingcheng_12", new int[3] { 48, 49, 50 }, 51, new List<sbyte> { 13 }, new List<sbyte>(), 12, 0u, new List<int> { 5, 14 }, new List<int> { 6 }, forbidWine: true, forbidMeat: true, forbidSex: true, reinitOnCrossArchive: false, new string[5]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_12_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_12_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_12_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_12_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_12_4")
		}, new uint[5], new int[9] { 4500, 4958, 5544, 6360, 7500, 8900, 11680, 13800, 17040 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_12"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_12")));
		_dataArray.Add(new ProfessionItem(13, LocalStringManager.GetConfig("Profession_language", "Name_13"), LocalStringManager.GetConfig("Profession_language", "Desc_13"), "Profession_0_13", "Profession_1_13", "Profession_2_13", "bottom_profession_mingcheng_13", new int[3] { 52, 53, 54 }, 55, new List<sbyte> { 9, 8 }, new List<sbyte>(), 13, 0u, new List<int>(), new List<int>(), forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[7]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_13_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_13_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_13_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_13_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_13_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_13_5"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_13_6")
		}, new uint[7], new int[9] { 9000, 9990, 10560, 12000, 13500, 15000, 16000, 16800, 18240 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_13"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_13")));
		_dataArray.Add(new ProfessionItem(14, LocalStringManager.GetConfig("Profession_language", "Name_14"), LocalStringManager.GetConfig("Profession_language", "Desc_14"), "Profession_0_14", "Profession_1_14", "Profession_2_14", "bottom_profession_mingcheng_14", new int[3] { 56, 57, 58 }, 59, new List<sbyte> { 4 }, new List<sbyte>(), 14, 0u, new List<int> { 6, 12 }, new List<int> { 5 }, forbidWine: false, forbidMeat: true, forbidSex: true, reinitOnCrossArchive: false, new string[5]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_14_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_14_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_14_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_14_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_14_4")
		}, new uint[5], new int[9] { 4440, 4884, 5456, 6240, 7350, 8800, 11520, 13600, 16800 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_14"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_14")));
		_dataArray.Add(new ProfessionItem(15, LocalStringManager.GetConfig("Profession_language", "Name_15"), LocalStringManager.GetConfig("Profession_language", "Desc_15"), "Profession_0_15", "Profession_1_15", "Profession_2_15", "bottom_profession_mingcheng_15", new int[3] { 60, 61, 62 }, 63, new List<sbyte> { 15 }, new List<sbyte>(), 15, 0u, new List<int>(), new List<int>(), forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[4]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_15_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_15_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_15_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_15_3")
		}, new uint[4], new int[9] { 3600, 3848, 4224, 4920, 5700, 7200, 10240, 12000, 15360 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_15"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_15")));
		_dataArray.Add(new ProfessionItem(16, LocalStringManager.GetConfig("Profession_language", "Name_16"), LocalStringManager.GetConfig("Profession_language", "Desc_16"), "Profession_0_16", "Profession_1_16", "Profession_2_16", "bottom_profession_mingcheng_16", new int[3] { 64, 65, 66 }, 67, new List<sbyte> { 5 }, new List<sbyte>(), 16, 0u, new List<int> { 0, 1, 7 }, new List<int> { 17 }, forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[6]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_16_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_16_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_16_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_16_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_16_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_16_5")
		}, new uint[6], new int[9] { 4080, 4440, 4928, 5760, 6750, 8400, 10880, 12800, 16320 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_16"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_16")));
		_dataArray.Add(new ProfessionItem(17, LocalStringManager.GetConfig("Profession_language", "Name_17"), LocalStringManager.GetConfig("Profession_language", "Desc_17"), "Profession_0_17", "Profession_1_17", "Profession_2_17", "bottom_profession_mingcheng_17", new int[3] { 68, 69, 70 }, 71, new List<sbyte> { 5 }, new List<sbyte>(), 17, 0u, new List<int> { 0, 1, 9, 10 }, new List<int> { 16, 8 }, forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[6]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_17_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_17_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_17_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_17_3"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_17_4"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_17_5")
		}, new uint[6], new int[9] { 3840, 4144, 4576, 5400, 6300, 7800, 10240, 12400, 15840 }, LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_17"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_17")));
		_dataArray.Add(new ProfessionItem(18, LocalStringManager.GetConfig("Profession_language", "Name_18"), LocalStringManager.GetConfig("Profession_language", "Desc_18"), "Profession_0_18", "Profession_1_18", "Profession_2_18", "bottom_profession_mingcheng_18", new int[3] { 72, 73, 74 }, 75, new List<sbyte>(), new List<sbyte>(), 107, 5093790u, new List<int>(), new List<int>(), forbidWine: false, forbidMeat: false, forbidSex: false, reinitOnCrossArchive: true, new string[4]
		{
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_18_0"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_18_1"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_18_2"),
			LocalStringManager.GetConfig("Profession_language", "SeniorityGainTips_18_3")
		}, new uint[4], new int[9], LocalStringManager.GetConfig("Profession_language", "DemandTeachingText_18"), LocalStringManager.GetConfig("Profession_language", "DemandTeachingFinishText_18")));
	}

	public override void Init()
	{
		base.Init();
		_dataArray = new List<ProfessionItem>(19);
		CreateItems0();
	}
}
